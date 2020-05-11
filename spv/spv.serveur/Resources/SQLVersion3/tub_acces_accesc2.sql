create or replace
TRIGGER tub_acces_accesc2 BEFORE UPDATE ON acces_accesc2 FOR EACH ROW

DECLARE
    ToDayStr	VARCHAR2 (20);	/* date et heure actuelle au format YYYY MM DD HH24:MI:SS */
    ToDaySec	NUMBER;		/* idem en nombre de secondes depuis le 01/01/1998 00:00:00 */
    Mess	VARCHAR2 (1800);   /* message d'alarme */
    OldMask	NUMBER;		/* 1 si l'alarme était masquée avant le changement, 0 sinon  */
    NewMask	NUMBER;		/* 1 si l'alarme devient masquée après le changement, 0 sinon */

    SiteId	NUMBER;		/* Id du site en défaut */
    EquipId	NUMBER;		/* Id de l'équipement en défaut */
    LiaiId	NUMBER;		/* Id de la liaison en défaut */

    EltSiteId   NUMBER;  /* ID du site contenant l'élt. en défaut. ' ' pour une liaison
				inter-site. Inutilisé ici */
    EltSiteNom  VARCHAR2 (40);  /* nom du site contenant l'élt. en défaut. ' ' pour une liaison
				inter-site. Inutilisé ici */
    EltTypeId   NUMBER;
				/* ID du type de l'équipement, de la liaison ou du site */
    EltTypeNom  VARCHAR2 (40);
				/* nom du type de l'équipement, de la liaison ou du site */
    EltId       NUMBER;  	/* ID de l'équuipement ou nom de la liaison ou du site en
				défaut. Inutilisé ici */				
    EltNom      VARCHAR2 (80);  	/* Position de l'équuipement ou nom de la liaison ou du site en
				défaut. Inutilisé ici */

    Routage	VARCHAR2 (40);	-- Permet de savoir si un routage est associé au programme

    TsPrOper2   VARCHAR2(900);

    ProgMsk	NUMBER;		/* Masque d'un programme */
    infos_diag_table diagramme.infos_diag_t;
    infos_diag_table2 diagramme.infos_diag_t;
    l_coeff diagramme.etat_oper_t;

    CURSOR cAlarm (Id NUMBER) is
	select ALARM.ALARM_ID, ALARM.ALARMGEREE_ID,
              ALARM.ALARM_NUM, ALARM.ALARM_CL, ALARM.ALARM_NUMOBJ, ALARM.ALARM_DATE, ALARM.ALARM_GRAVE,
              ALARM.ALARM_NUMAL, ALARM.ALARM_TEXTE, ALARM.ALARM_INFO, ALARM.ALARM_COMMENT,
              ALARM.ALARM_COMMUT, ALARM.ALARM_IDDEB,
              ALARMDATA.ALARMDATA_ID, ALARMDATA.EQUIP_ID, ALARMDATA.SITE_ID, ALARMDATA.LIAI_ID,
              ALARMDATA.ALARMGEREE_TYPAL, ALARMDATA.ALARMGEREE_NSEUIL, ALARMDATA.ALARMDATA_VSEUIL,
              ALARMDATA.ALARMGEREE_NOM, ALARMDATA.ALARMGEREE_LOCAL, ALARMDATA.ACCES_ACCESC_ID,
              ALARMDATA.ALARMDATA_ACK, ALARMDATA.ALARMDATA_IANA
          from ALARM, ALARMDATA
	    where ALARM_ID = Id
            and ALARM.ALARMDATA_ID = ALARMDATA.ALARMDATA_ID;

    CURSOR cAcc (Id NUMBER) is
	select A.ACCES1_ID, A.ALARMGEREE_ID, A.ACCES_BINDINGID,
	       B.ALARMGEREE_GRAVE,
	       B.ALARM_ID, B.SITE_ID, B.EQUIP_ID, B.LIAI_ID, B.ALARM_CL,
	       B.ALARM_NUMOBJ, B.ALARM_NUMAL
 	    from ACCES_ACCESC A, ACCES_ACCESC_REP B
	    where A.ACCES_ACCESC_ID = Id and
	  	  A.ACCES_ACCESC_ID = B.ACCES_ACCESC_ID;
/*
    CURSOR CurDiag (Id NUMBER) is	-- liste des programmes concernés par ce masquage 
	select distinct NTWDIAG_ID from NETWORK_GRAPH, ACCES, ACCES_ACCESC		-- al. de site
	    where ACCES_ACCESC_ID = Id and
		  ACCES_ACCESC.ACCES1_ID = ACCES.ACCES_ID and
		  ACCES.SITE_ID = NETWORK_GRAPH.SITE_ID
    	union
	select distinct NTWDIAG_ID from NETWORK_GRAPH, ACCES, ACCES_ACCESC		-- al. de liaison
	    where ACCES_ACCESC_ID = Id and
		  ACCES_ACCESC.ACCES1_ID = ACCES.ACCES_ID and
		  ACCES.LIAI_ID = NETWORK_GRAPH.LIAI_ID
    	union				-- al. d'équipement câblé
	select distinct NTWDIAG_ID from NETWORK_GRAPH, ACCES, ACCES_ACCESC
	    where ACCES_ACCESC_ID = Id and
		  ACCES_ACCESC.ACCES1_ID = ACCES.ACCES_ID and
		  ACCES.EQUIP_ID = NETWORK_GRAPH.EQUIP_ID
	union				-- al. d'équipement GSITE ou IS ou SYST ou TRAP
	select distinct NTWDIAG_ID from NETWORK_GRAPH, ACCES_ACCESC
	    where ACCES_ACCESC_ID = Id and
		  ACCES_ACCESC.ACCES_BINDINGID = NETWORK_GRAPH.EQUIP_ID;*/
                  /*
	union				-- al. d'équ. de multiplexage
	select distinct PROG_ID from CABLEQU_EQUIP, LIAI_CABLEQU, PROG_usedliais, ACCES, ACCES_ACCESC
	    where ACCES_ACCESC_ID = Id and
		  ACCES_ACCESC.ACCES1_ID = ACCES.ACCES_ID and
		  ACCES.EQUIP_ID = CABLEQU_EQUIP.EQUIP_ID and
		  CABLEQU_EQUIP.CABLEQU_ID = LIAI_CABLEQU.CABLEQU_ID and
		  LIAI_CABLEQU.LIAI_ID = PROG_usedliais.LIAI_ID;*/

    diag_table lien_acces_alarme.diag_id_t;
    diag_masque_table lien_acces_alarme.diag_id_t;
    
    /*
    CURSOR CurDiag2 (Id NUMBER) IS      -- Liste des diagrammes à démasquer
        SELECT * FROM network_diag_masque
            WHERE acces_accesc_id = Id; */

BEGIN
    /* Si le trigger est déclenché par suite d'un enregistrement créé par réplication,
       on ne fait pas le traitement */
    if (ETAT_REPLICATION = 1) then
		return;
	end if;
	if dbms_reputil.from_remote=TRUE then
		return;
    end if;
SetTrace('tub_acces_accesc2');
    ToDayStr := to_char (sysdate, 'YYYY MM DD HH24:MI:SS');
    ToDaySec := CO_SEC1998 (ToDayStr);

    update ACCES_ACCESC
	set MSKBRI_MIN = :new.MSKBRI_MIN,
	    MSKBRI_MAX = :new.MSKBRI_MAX,
	    MSKADM_MIN = :new.MSKADM_MIN,
	    MSKADM_MAX = :new.MSKADM_MAX,
	    MSKADM_HOW = :new.MSKADM_HOW
	    where ACCES_ACCESC_ID = :new.ACCES_ACCESC2_ID;


    :new.TRIG := 0;

    OldMask  := :old.BRI_MASQUE;
    Newmask := :new.BRI_MASQUE;
    diag_table := lien_acces_alarme.get_diagrammes_concernes(:new.acces_accesc2_id);
    diag_masque_table := lien_acces_alarme.get_diagrammes_masques(:new.acces_accesc2_id);

    if (Oldmask != NewMask) then
	for vAcc2 in cAcc (:new.ACCES_ACCESC2_ID) loop
	    if vAcc2.ACCES1_ID > 0 then
    	    	select SITE_ID, EQUIP_ID, LIAI_ID
		    into SiteId, EquipId, LiaiId
 		    from ACCES
		    where ACCES_ID = vAcc2.ACCES1_ID ;
						/* recherche de l'élément géré en défaut */
	    else
		EquipId := vAcc2.ACCES_BINDINGID;
	    end if;

	    if (OldMask = 0 and NewMask = 1) then	/* on vient de masquer l'alarme */
                FOR i IN diag_table.FIRST .. diag_table.LAST LOOP
                    update NETWORK_DIAG
                      set NTWDIAG_MASQUE = 1
                      where NTWDIAG_ID = diag_table(i) and
                            NTWDIAG_MASQUE = 0; 	-- pour respecter les masquages adm. éventuels
		end loop;

	    if (vAcc2.ALARM_ID is not null) then	/* l'alarme était en cours */
		    pack_alarme.maj_oper  (vAcc2.ALARM_ID, vAcc2.SITE_ID, vAcc2.EQUIP_ID, vAcc2.LIAI_ID,
                                            alarme_geree.c_locale, alarme_geree.c_sans, spv_types.c_not_commut, 
                                            EltSiteId, EltSiteNom, EltTypeId, EltTypeNom, EltId, EltNom, 
                                            infos_diag_table);
			/* on fait retomber artificiellement cette alarme, afin de
			   calculer TsPrOper qui est utilisé pour mettre à jour
			   les "boutons programmes". On introduit le "masque" au préalable
			   pour que TsPrOper en tienne compte.
			   On suppose à priori que l'alarme est locale, ce qui est
			   utilisé pour connaître l'état opérationnel du programme.
			   Cette donnée est peut être inutile. A supprimer ultérieurement !! */

		    infos_diag_table2 := infos_diag_table;
				/* sauvegarde de TsPrOper, représentant l'état opérationnel
				des programmes, indépendamment de l'alarme qui vient d'être
				masquée */

                    infos_diag_table.DELETE;
		    pack_alarme.stop_alrm (Mess, vAcc2.ALARM_ID, vAcc2.ALARMGEREE_ID, vAcc2.SITE_ID,
                                          vAcc2.EQUIP_ID, vAcc2.LIAI_ID, vAcc2.ALARM_CL, vAcc2.ALARM_NUMOBJ,
                                          vAcc2.ALARM_NUMAL, infos_diag_table);
				/* on arrête l'alarme sur les postes clients, car
				on ne recevra plus de message de cette alarme */

		    pack_alarme.maj_oper  (vAcc2.ALARM_ID, vAcc2.SITE_ID, vAcc2.EQUIP_ID, vAcc2.LIAI_ID,
                                          alarme_geree.c_locale, vAcc2.ALARMGEREE_GRAVE, 
                                          spv_types.c_not_commut, EltSiteId, EltSiteNom, EltTypeId, 
                                          EltTypeNom, EltId, EltNom, infos_diag_table);
			/* enfin, on calcule à nouveau l'état opérationnel, avec la vraie
			   gravité de l'alarme en cours. */

		else			/* l'alarme masquée n'était pas en cours */

                    infos_diag_table.DELETE;
                    lien_acces_alarme.get_diagrammes_concernes(:new.acces_accesc2_id, infos_diag_table);
                    infos_diag_table2 := infos_diag_table;
                    /*
		    for vDiag in CurDiag (:new.ACCES_ACCESC2_ID) loop
		    	select B.NTWDREP_COEF, NTWDIAG_MASQUE into l_coeff, ProgMsk
			    from NETWORK_DIAG A, NTWDIAG_REP B
			    where A.NTWDIAG_ID = vDiag.NTWDIAG_ID and
				  A.NTWDIAG_ID = B.NTWDIAG_ID;
                                  
                        diagramme.maj_info_diag_table(vDiag.ntwdiag_id, l_coeff, l_coeff, ProgMsk,
                                                      infos_diag_table);

		    end loop;*/

	    	end if;

                FOR i IN diag_table.FIRST .. diag_table.LAST LOOP
		    insert into NETWORK_DIAG_MASQUE (NETWORK_DIAG_MASQUE_ID, ACCES_ACCESC_ID, NTWDIAG_ID, 
                                                     NETWORK_DIAG_MASQUE_ETAT)
			values (seq_network_diag_masque.NEXTVAL, :new.ACCES_ACCESC2_ID, diag_table(i), 
                                diagramme.c_masque_ope);
		END LOOP;

	    	pack_alarme.mask_alrm (Mess, ' ', 0, to_char (:new.ACCES_ACCESC2_ID), 1,
			   SiteId, EquipId, LiaiId, infos_diag_table2);
					/* les clients masquent l'alarme --
					ACCES_ACCESC2_ID sert de signature pour le message */
	    end if;	/* masquage */

	    if (OldMask = 1 and NewMask = 0) then 	/* on vient de démasquer l'alarme */
            
                infos_diag_table.DELETE;
                
                for i IN diag_masque_table.FIRST .. diag_masque_table.LAST LOOP
		    update NETWORK_DIAG
			set NTWDIAG_MASQUE = 0
			where NTWDIAG_ID = diag_masque_table(i);

		    select B.NTWDREP_COEF, NTWDIAG_MASQUE into l_coeff, ProgMsk
			from NETWORK_DIAG A, NTWDIAG_REP B
			where A.NTWDIAG_ID = diag_masque_table(i) and
			      A.NTWDIAG_ID = B.NTWDIAG_ID;
                              
                    diagramme.maj_info_diag_table(diag_masque_table(i), l_coeff, l_coeff, ProgMsk,
                                                  infos_diag_table);

		end loop;

		delete NETWORK_DIAG_MASQUE
		    where ACCES_ACCESC_ID = :new.ACCES_ACCESC2_ID;

--insert into tracetmp (trace_id, trace_mess)
                    --values (seq_trace.nextval, ' before Mask_Alrm');

	    	pack_alarme.Mask_Alrm (Mess, ' ', 0, to_char (:new.ACCES_ACCESC2_ID), 0, SiteId, EquipId, LiaiId, 
                                       infos_diag_table);
						/* les clients démasquent l'alarme */

	    	if (vAcc2.ALARM_ID is not null) then	/* l'alarme est en cours */
		    for cAl in cAlarm (vAcc2.ALARM_ID) loop
		    	pack_alarme.start_alrm 
                                      (cAl.ALARM_ID, cAl.ALARMDATA_ID, cAl.ALARMGEREE_ID,
                                       cAl.SITE_ID, cAl.EQUIP_ID, cAl.LIAI_ID,
                                       cAl.ALARM_NUM, cAl.ALARM_CL, cAl.ALARM_NUMOBJ, cAl.ALARMGEREE_TYPAL,
                                       cAl.ALARM_DATE, cAl.ALARM_GRAVE, cAl.ALARMGEREE_NSEUIL, cAl.ALARMDATA_VSEUIL,
                                       cAl.ALARM_NUMAL, cAl.ALARM_TEXTE, cAl.ALARM_INFO, cAl.ALARMGEREE_NOM,
                                       cAl.ALARM_COMMENT, cAl.ALARMGEREE_LOCAL, cAl.ALARM_COMMUT, cAl.ALARM_IDDEB,
                                       NULL, cAl.ACCES_ACCESC_ID, cAl.ALARMDATA_ACK, cAl.ALARMDATA_IANA,
                                       infos_diag_table);
		    end loop;
	    	end if;

		if (ToDaySec > :new.MSKBRI_MAX) then

		    -- Période de masquage dépassée, on efface les informations de masquage
		    -- dans ACCES_ACCESC

		    update ACCES_ACCESC
			set MSKBRI_MIN = 0,
			    MSKBRI_MAX = 0
		    where ACCES_ACCESC_ID = :new.ACCES_ACCESC2_ID;
		end if;

		:new.MSKBRI_MIN := 0;
		:new.MSKBRI_MAX := 0;
	    end if;		/* démasquage */

	end loop;
    end if;		/* changement du masquage brigadier */

    OldMask  := :old.ADM_MASQUE;
    if (ToDaySec >= :new.MSKADM_MIN) and (ToDaySec <= :new.MSKADM_MAX) then
	NewMask := 1;
    else
	NewMask := 0;
    end if;

    :new.ADM_MASQUE := Newmask;

    if (OldMask != NewMask) then
    --insert into tracetmp (trace_id, trace_mess)
                    --values (seq_trace.nextval, ' mask admin');
	for vAcc2 in cAcc (:new.ACCES_ACCESC2_ID) loop
	    if vAcc2.ACCES1_ID > 0 then
    	    	select SITE_ID, EQUIP_ID, LIAI_ID
		    into SiteId, EquipId, LiaiId
 		    from ACCES
		    where ACCES_ID = vAcc2.ACCES1_ID ;
						/* recherche de l'élément géré en défaut */
	    else
		EquipId := vAcc2.ACCES_BINDINGID;
	    end if;

	    if (OldMask = 0 and NewMask = 1) then	/* on vient de masquer l'alarme */
                for i IN diag_table.FIRST .. diag_table.LAST LOOP
    		    update NETWORK_DIAG
		    set NTWDIAG_MASQUE = diagramme.c_masque_ope
		    where NTWDIAG_ID = diag_table(i);
		end loop;

	    	if (vAcc2.ALARM_ID is not null) then	/* l'alarme était en cours */
		    pack_alarme.maj_oper  (vAcc2.ALARM_ID, vAcc2.SITE_ID, vAcc2.EQUIP_ID, vAcc2.LIAI_ID,
                                           alarme_geree.c_locale, alarme_geree.c_sans, spv_types.c_not_commut, 
                                           EltSiteId, EltSiteNom, EltTypeId, EltTypeNom, EltId, EltNom, 
                                           infos_diag_table);
			/* on fait retomber artificiellement cette alarme, afin de
			   calculer TsPrOper qui est utilisé pour mettre à jour
			   les "boutons programmes". On introduit le "masque" au préalable
			   pour que TsPrOper en tienne compte.
			   On suppose à priori que l'alarme est locale, ce qui est
			   utilisé pour connaître l'état opérationnel du programme.
			   Cette donnée est peut être inutile. A supprimer ultérieurement !! */

                    infos_diag_table2 := infos_diag_table;
				/* sauvegarde de TsPrOper, représentant l'état opérationnel
				des programmes, indépendamment de l'alarme qui vient d'être
				masquée */

		    pack_alarme.stop_alrm (Mess, vAcc2.ALARM_ID, vAcc2.ALARMGEREE_ID, vAcc2.SITE_ID,
                                           vAcc2.EQUIP_ID, vAcc2.LIAI_ID, vAcc2.ALARM_CL, vAcc2.ALARM_NUMOBJ,
                                           vAcc2.ALARM_NUMAL, infos_diag_table);
				/* on arrête l'alarme sur les postes clients, car
				on ne recevra plus de message de celle-ci */

		    pack_alarme.maj_oper  (vAcc2.ALARM_ID, vAcc2.SITE_ID, vAcc2.EQUIP_ID, vAcc2.LIAI_ID,
                                            alarme_geree.c_locale, vAcc2.ALARMGEREE_GRAVE, spv_types.c_not_commut, 
                                            EltSiteId, EltSiteNom, EltTypeId, EltTypeNom, 
                                            EltId, EltNom, infos_diag_table);
			/* enfin, on calcule à nouveau l'état opérationnel, avec la vraie
			   gravité de l'alarme en cours. */

		    delete ALARM2 where ALARM2_ID = vAcc2.ALARM_ID;

		else			/* l'alarme masquée n'était pas en cours */
                    infos_diag_table.DELETE;
                    
                    for i IN diag_table.FIRST .. diag_table.LAST LOOP
		    	select B.NTWDREP_COEF, NTWDIAG_MASQUE into l_coeff, ProgMsk
			    from NETWORK_DIAG A, NTWDIAG_REP B
			    where A.NTWDIAG_ID = diag_table(i) and
				  A.NTWDIAG_ID = B.NTWDIAG_ID;
                                  
                        diagramme.maj_info_diag_table(diag_table(i), l_coeff, l_coeff, ProgMsk,
                                                      infos_diag_table);

		    end loop;
                    infos_diag_table2 := infos_diag_table;
	    	end if;

                for i IN diag_table.FIRST .. diag_table.LAST LOOP
		    insert into NETWORK_DIAG_MASQUE (NETWORK_DIAG_MASQUE_ID, ACCES_ACCESC_ID, NTWDIAG_ID, 
                                                     NETWORK_DIAG_MASQUE_ETAT)
			values (seq_network_diag_masque.NEXTVAL, :new.ACCES_ACCESC2_ID, diag_table(i), 
                                diagramme.c_masque_adm);
		end loop;

	    	pack_alarme.mask_alrm (Mess, ' ', 0, to_char (:new.ACCES_ACCESC2_ID), 3,
			   SiteId, EquipId, LiaiId, infos_diag_table2);
				/* les clients masquent l'alarme --
				ACCES_ACCESC2_ID sert de signature pour le message */
	    end if;	/* masquage */

	    if (OldMask = 1 and NewMask = 0) then	/* on vient de démasquer l'alarme */
            
                infos_diag_table.DELETE;

                for i IN diag_masque_table.FIRST .. diag_masque_table.LAST LOOP
		    update NETWORK_DIAG
			set NTWDIAG_MASQUE = diagramme.c_non_masque
			where NTWDIAG_ID = diag_masque_table(i);

		    select B.NTWDREP_COEF, NTWDIAG_MASQUE into l_coeff, ProgMsk
			from NETWORK_DIAG A, NTWDIAG_REP B
			where A.NTWDIAG_ID = diag_masque_table(i) and
			      A.NTWDIAG_ID = B.NTWDIAG_ID;

                    diagramme.maj_info_diag_table(diag_masque_table(i), l_coeff, l_coeff, ProgMsk,
                                                  infos_diag_table);
		end loop;

		delete NETWORK_DIAG_MASQUE
		    where ACCES_ACCESC_ID = :new.ACCES_ACCESC2_ID;


	    	pack_alarme.mask_alrm (Mess, ' ', 0, to_char (:new.ACCES_ACCESC2_ID), 2, SiteId, EquipId, 
                                       LiaiId, infos_diag_table);
						/* les clients démasquent l'alarme */

	    	if (vAcc2.ALARM_ID is not null) then	/* l'alarme est en cours */
		    for cAl in cAlarm (vAcc2.ALARM_ID) loop

                    --insert into tracetmp (trace_id, trace_mess)
                    --values (seq_trace.nextval, ' start alarme ' || to_char(cAl.ALARM_ID));
                           pack_alarme.start_alrm 
                                          (cAl.ALARM_ID, cAl.ALARMDATA_ID, cAl.ALARMGEREE_ID,
                                           cAl.SITE_ID, cAl.EQUIP_ID, cAl.LIAI_ID,
                                           cAl.ALARM_NUM, cAl.ALARM_CL, cAl.ALARM_NUMOBJ, cAl.ALARMGEREE_TYPAL,
                                           cAl.ALARM_DATE, cAl.ALARM_GRAVE, cAl.ALARMGEREE_NSEUIL, 
                                           cAl.ALARMDATA_VSEUIL, cAl.ALARM_NUMAL, cAl.ALARM_TEXTE, cAl.ALARM_INFO, 
                                           cAl.ALARMGEREE_NOM, cAl.ALARM_COMMENT, cAl.ALARMGEREE_LOCAL, 
                                           cAl.ALARM_COMMUT, cAl.ALARM_IDDEB, NULL, cAl.ACCES_ACCESC_ID, 
                                           cAl.ALARMDATA_ACK, cAl.ALARMDATA_IANA, infos_diag_table);
		    end loop;
	    	end if;

		if (ToDaySec > :new.MSKADM_MAX) then

		    -- Période de masquage dépassée, on efface les informations de masquage
		    -- dans ACCES_ACCESC

		    update ACCES_ACCESC
			set MSKADM_MIN = 0,
			    MSKADM_MAX = 0
		    where ACCES_ACCESC_ID = :new.ACCES_ACCESC2_ID;
		end if;

		:new.MSKADM_MIN := 0;
		:new.MSKADM_MAX := 0;
	    end if;		/* démasquage */

	end loop;
    end if;		/* changement du masquage Adm */

END	tub_acces_accesc2;
