create or replace
TRIGGER tub_acces_accesc2 BEFORE UPDATE ON acces_accesc2 FOR EACH ROW

DECLARE
    ToDayStr	VARCHAR2 (20);	/* date et heure actuelle au format YYYY MM DD HH24:MI:SS */
    ToDaySec	NUMBER;		/* idem en nombre de secondes depuis le 01/01/1998 00:00:00 */
    Mess	VARCHAR2 (1800);   /* message d'alarme */
    OldMask	NUMBER;		/* 1 si l'alarme était masquée avant le changement, 0 sinon  */
    NewMask	NUMBER;		/* 1 si l'alarme devient masquée après le changement, 0 sinon */

    ProgNb	NUMBER;		/* idem */
    SiteId	NUMBER;		/* Id du site en défaut */
    EquipId	NUMBER;		/* Id de l'équipement en défaut */
    LiaiId	NUMBER;		/* Id de la liaison en défaut */

	EltSiteId     NUMBER;  /* ID du site contenant l'élt. en défaut. ' ' pour une liaison
				inter-site. Inutilisé ici */
    EltSiteNom     VARCHAR2 (40);  /* nom du site contenant l'élt. en défaut. ' ' pour une liaison
				inter-site. Inutilisé ici */
	EltTypeId    	NUMBER;
				/* ID du type de l'équipement, de la liaison ou du site */
    EltTypeNom    	VARCHAR2 (40);
				/* nom du type de l'équipement, de la liaison ou du site */
	EltId    NUMBER;  	/* ID de l'équuipement ou nom de la liaison ou du site en
				défaut. Inutilisé ici */				
    EltNom    VARCHAR2 (80);  	/* Position de l'équuipement ou nom de la liaison ou du site en
				défaut. Inutilisé ici */

    TsPrOper VARCHAR2 (900); /* Chaîne donnant l'état opérationnel des prog. concernés par
				cette alarme. 70 prog. au max.
				Structure : NbProg; ProgId, OldProgOper, ProgOper, ProgMsk;
				NON Maintenant : Structure : ProgId, OldProgOper, ProgOper, ProgMsk; ProgId,  etc... */
    Debord   NUMBER;	     /* 1 si débordement de la chaîne TsPrOper, 0 sinon */
    Routage	VARCHAR2 (40);	-- Permet de savoir si un routage est associé au programme

    TsPrOper2 VARCHAR2(900);
    ProgOper	NUMBER;		/* Etat opérationnel d'un programme */
    ProgMsk	NUMBER;		/* Masque d'un programme */

    CURSOR cAlarm (Id NUMBER) is
	select ALARM.ALARM_ID, ALARM.ALARMGEREE_ID,
              ALARM.ALARM_NUM, ALARM.ALARM_CL, ALARM.ALARM_NUMOBJ, ALARM.ALARM_DATE, ALARM.ALARM_GRAVE,
              ALARM.ALARM_NUMAL, ALARM.ALARM_TEXTE, ALARM.ALARM_INFO, ALARM.ALARM_COMMENT,
              ALARM.ALARM_COMMUT, ALARM.ALARM_IDDEB,
              ALARMDATA.EQUIP_ID, ALARMDATA.SITE_ID, ALARMDATA.LIAI_ID,
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

    CURSOR CurProg (Id NUMBER) is	/* liste des programmes concernés par ce masquage */
	select distinct PROG_ID from PROG_usedsites, ACCES, ACCES_ACCESC		-- al. de site
	    where ACCES_ACCESC_ID = Id and
		  ACCES_ACCESC.ACCES1_ID = ACCES.ACCES_ID and
		  ACCES.SITE_ID = PROG_usedsites.SITE_ID
    	union
	select distinct PROG_ID from PROG_usedliais, ACCES, ACCES_ACCESC		-- al. de liaison
	    where ACCES_ACCESC_ID = Id and
		  ACCES_ACCESC.ACCES1_ID = ACCES.ACCES_ID and
		  ACCES.LIAI_ID = PROG_usedliais.LIAI_ID
    	union				-- al. d'équipement câblé
	select distinct PROG_ID from CABLEQU_EQUIP, PROG_CABL, ACCES, ACCES_ACCESC
	    where ACCES_ACCESC_ID = Id and
		  ACCES_ACCESC.ACCES1_ID = ACCES.ACCES_ID and
		  ACCES.EQUIP_ID = CABLEQU_EQUIP.EQUIP_ID and
		  CABLEQU_EQUIP.CABLEQU_ID = PROG_CABL.CABLEQU_ID
	union				-- al. d'équipement GSITE ou IS ou SYST ou TRAP
	select distinct PROG_ID from CABLEQU_EQUIP, PROG_CABL, ACCES_ACCESC
	    where ACCES_ACCESC_ID = Id and
		  ACCES_ACCESC.ACCES_BINDINGID = CABLEQU_EQUIP.EQUIP_ID and
		  CABLEQU_EQUIP.CABLEQU_ID = PROG_CABL.CABLEQU_ID
	union				-- al. d'équ. de multiplexage
	select distinct PROG_ID from CABLEQU_EQUIP, LIAI_CABLEQU, PROG_usedliais, ACCES, ACCES_ACCESC
	    where ACCES_ACCESC_ID = Id and
		  ACCES_ACCESC.ACCES1_ID = ACCES.ACCES_ID and
		  ACCES.EQUIP_ID = CABLEQU_EQUIP.EQUIP_ID and
		  CABLEQU_EQUIP.CABLEQU_ID = LIAI_CABLEQU.CABLEQU_ID and
		  LIAI_CABLEQU.LIAI_ID = PROG_usedliais.LIAI_ID;

  /*  CURSOR CurTop (Id NUMBER) IS
    select TOP_ID from top_SITE, ACCES, ACCES_ACCESC		-- al. de site
	    where ACCES_ACCESC_ID = Id and
		  ACCES_ACCESC.ACCES1_ID = ACCES.ACCES_ID and
		  ACCES.SITE_ID = top_SITE.SITE_ID
    	union
	select TOP_ID from top_LIAITEMPU, ACCES, ACCES_ACCESC		-- al. de liaison
	    where ACCES_ACCESC_ID = Id and
		  ACCES_ACCESC.ACCES1_ID = ACCES.ACCES_ID and
		  ACCES.LIAI_ID = top_LIAITEMPU.LIAI_ID
    	union				-- al. d'équipement câblé
	select TOP_ID from CABLEQU_EQUIP, top_CABLEQU, ACCES, ACCES_ACCESC
	    where ACCES_ACCESC_ID = Id and
		  ACCES_ACCESC.ACCES1_ID = ACCES.ACCES_ID and
		  ACCES.EQUIP_ID = CABLEQU_EQUIP.EQUIP_ID and
		  CABLEQU_EQUIP.CABLEQU_ID = top_CABLEQU.CABLEQU_ID
	union				-- al. d'équipement GSITE ou IS ou SYST ou TRAP
	select TOP_ID from CABLEQU_EQUIP, top_CABLEQU, ACCES_ACCESC
	    where ACCES_ACCESC_ID = Id and
		  ACCES_ACCESC.ACCES_BINDINGID = CABLEQU_EQUIP.EQUIP_ID and
		  CABLEQU_EQUIP.CABLEQU_ID = top_CABLEQU.CABLEQU_ID
	union				-- al. d'équ. de multiplexage
	select TOP_ID from CABLEQU_EQUIP, LIAI_CABLEQU, top_LIAITEMPU, ACCES, ACCES_ACCESC
	    where ACCES_ACCESC_ID = Id and
		  ACCES_ACCESC.ACCES1_ID = ACCES.ACCES_ID and
		  ACCES.EQUIP_ID = CABLEQU_EQUIP.EQUIP_ID and
		  CABLEQU_EQUIP.CABLEQU_ID = LIAI_CABLEQU.CABLEQU_ID and
		  LIAI_CABLEQU.LIAI_ID = top_LIAITEMPU.LIAI_ID;*/

    CURSOR CurProg2 (Id NUMBER) is	/* liste des programmes à démasquer */
	select * from PROG_MSK
	    where CABL_ID = Id and TYPE = 1;

BEGIN
    /* Si le trigger est déclenché par suite d'un enregistrement créé par réplication,
       on ne fait pas le traitement */
    if (ETAT_REPLICATION = 1) then
		return;
	end if;
	if dbms_reputil.from_remote=TRUE then
		return;
    end if;

    ToDayStr := to_char (sysdate, 'YYYY MM DD HH24:MI:SS');
    ToDaySec := CO_SEC1998 (ToDayStr);
    Debord   := 0;

    update ACCES_ACCESC
	set MSKBRI_MIN = :new.MSKBRI_MIN,
	    MSKBRI_MAX = :new.MSKBRI_MAX,
	    MSKADM_MIN = :new.MSKADM_MIN,
	    MSKADM_MAX = :new.MSKADM_MAX,
	    MSKADM_HOW = :new.MSKADM_HOW
	    where ACCES_ACCESC_ID = :new.ACCES_ACCESC2_ID;


  /*  insert into TRACETMP (trace_id, trace_mess) values (seq_trace.nextval,  ' new ACCES_ACCESC2_ID : ' ||  to_char ( :new.ACCES_ACCESC2_ID)
    ||' new MSKBRI_MIN : ' || to_char (:new.MSKBRI_MIN) ||
    ' new MSKBRI_MAX : ' || to_char (:new.MSKBRI_MAX));*/

    :new.TRIG := 0;

    OldMask  := :old.BRI_MASQUE;
  /*  if (ToDaySec >= :new.MSKBRI_MIN) and (ToDaySec <= :new.MSKBRI_MAX) then
	NewMask := 1;
    else
	NewMask := 0;
    end if;

    :new.BRI_MASQUE := Newmask;*/
    Newmask := :new.BRI_MASQUE;

    --insert into TRACETMP (trace_id, trace_mess)
    --values (seq_trace.nextval, ' new BRI_MASQUE : ' || to_char (:new.BRI_MASQUE));


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
		for vProg in CurProg (:new.ACCES_ACCESC2_ID) loop
    		    update PROG
		    set PROG_MASQUE = 1
		    where PROG_ID = vProg.PROG_ID and
	      		  PROG_MASQUE = 0; 	-- pour respecter les masquages adm. éventuels
		end loop;

	    if (vAcc2.ALARM_ID is not null) then	/* l'alarme était en cours */
		    maj_oper  (vAcc2.ALARM_ID, vAcc2.SITE_ID, vAcc2.EQUIP_ID, vAcc2.LIAI_ID,
			   1, 0, 0, ProgNb, EltSiteId, EltSiteNom, EltTypeId, EltTypeNom, EltId, EltNom, 
			   TsPrOper, Debord);
			/* on fait retomber artificiellement cette alarme, afin de
			   calculer TsPrOper qui est utilisé pour mettre à jour
			   les "boutons programmes". On introduit le "masque" au préalable
			   pour que TsPrOper en tienne compte.
			   On suppose à priori que l'alarme est locale, ce qui est
			   utilisé pour connaître l'état opérationnel du programme.
			   Cette donnée est peut être inutile. A supprimer ultérieurement !! */

		    TsPrOper2 := TsPrOper;
				/* sauvegarde de TsPrOper, représentant l'état opérationnel
				des programmes, indépendamment de l'alarme qui vient d'être
				masquée */

                    --insert into tracetmp (trace_id, trace_mess)
                    --values (seq_trace.nextval, ' before stop-alrm');

		    Stop_Alrm (Mess, vAcc2.ALARM_ID, vAcc2.ALARMGEREE_ID, vAcc2.SITE_ID,
			   vAcc2.EQUIP_ID, vAcc2.LIAI_ID, vAcc2.ALARM_CL, vAcc2.ALARM_NUMOBJ,
			   vAcc2.ALARM_NUMAL, TsPrOper);
				/* on arrête l'alarme sur les postes clients, car
				on ne recevra plus de message de cette alarme */

		    maj_oper  (vAcc2.ALARM_ID, vAcc2.SITE_ID, vAcc2.EQUIP_ID, vAcc2.LIAI_ID,
			   1, vAcc2.ALARMGEREE_GRAVE, 0, ProgNb, EltSiteId, EltSiteNom, EltTypeId, EltTypeNom, 
			   EltId, EltNom, TsPrOper, Debord);
			/* enfin, on calcule à nouveau l'état opérationnel, avec la vraie
			   gravité de l'alarme en cours. */

		else			/* l'alarme masquée n'était pas en cours */

                --insert into tracetmp (trace_id, trace_mess)
                    --values (seq_trace.nextval, ' alarme masquée ne était pas en cours');

		    ProgNb   := 0;
		    TsPrOper := '';
		    Debord   := 0;
		    for vProg in CurProg (:new.ACCES_ACCESC2_ID) loop
		    	select B.PROG_OPER, PROG_MASQUE into ProgOper, ProgMsk
			    from PROG A, PROG_REP B
			    where A.PROG_ID = vProg.PROG_ID and
				  A.PROG_ID = B.PROG_ID;

		    	if ((TsPrOper is NULL or length (TsPrOper) <= 800) and Debord = 0) then
--	    	    	    ProgNb := ProgNb +1;
		    	    TsPrOper := TsPrOper || to_char (vProg.PROG_ID) || ',' || to_char (ProgOper) ||
		    	            ',' || to_char (ProgOper) || ',' || to_char (ProgMsk) || ';';
		        elsif (length (TsPrOper) > 800) then
			    Debord := 1;
			end if;
		    end loop;

--		    TsPrOper2 := to_char (ProgNb) || ';' || TsPrOper;
	    	end if;

		for vProg in CurProg (:new.ACCES_ACCESC2_ID) loop
		    insert into PROG_MSK (CABL_ID, PROG_ID, TYPE, MSK)
			values (:new.ACCES_ACCESC2_ID, vProg.PROG_ID, 1, 1);
		end loop;

	    	Mask_Alrm (Mess, ' ', 0, to_char (:new.ACCES_ACCESC2_ID), 1,
			   SiteId, EquipId, LiaiId, TsPrOper2);
					/* les clients masquent l'alarme --
					ACCES_ACCESC2_ID sert de signature pour le message */
	    end if;	/* masquage */

	    if (OldMask = 1 and NewMask = 0) then 	/* on vient de démasquer l'alarme */
		ProgNb 	 := 0;
		TsPrOper := '';
		Debord   := 0;
		for vProg in CurProg2 (:new.ACCES_ACCESC2_ID) loop
		    update PROG
			set PROG_MASQUE = 0
			where PROG_ID = vProg.PROG_ID;

		    select B.PROG_OPER, PROG_MASQUE into ProgOper, ProgMsk
			from PROG A, PROG_REP B
			where A.PROG_ID = vProg.PROG_ID and
			      A.PROG_ID = B.PROG_ID;

		    if ((TsPrOper is NULL or length (TsPrOper) <= 800) and Debord = 0) then
--	    	    	ProgNb := ProgNb +1;
		    	TsPrOper := TsPrOper || to_char (vProg.PROG_ID) || ',' || to_char (ProgOper) ||
		    	            ',' || to_char (ProgOper) || ',' || to_char (ProgMsk) || ';';
		    elsif (length (TsPrOper) > 800) then
			Debord := 1;
		    end if;
		end loop;
--		TsPrOper := to_char (ProgNb) || ';' || TsPrOper;

		delete PROG_MSK
		    where CABL_ID = :new.ACCES_ACCESC2_ID and
			  TYPE = 1;

--insert into tracetmp (trace_id, trace_mess)
                    --values (seq_trace.nextval, ' before Mask_Alrm');

	    	Mask_Alrm (Mess, ' ', 0, to_char (:new.ACCES_ACCESC2_ID), 0, SiteId, EquipId, LiaiId, TsPrOper);
						/* les clients démasquent l'alarme */

	    	if (vAcc2.ALARM_ID is not null) then	/* l'alarme est en cours */
		    for cAl in cAlarm (vAcc2.ALARM_ID) loop
		    	Start_Alrm (cAl.ALARM_ID, cAl.ALARMGEREE_ID,
			   cAl.SITE_ID, cAl.EQUIP_ID, cAl.LIAI_ID,
 			   cAl.ALARM_NUM, cAl.ALARM_CL, cAl.ALARM_NUMOBJ, cAl.ALARMGEREE_TYPAL,
			   cAl.ALARM_DATE, cAl.ALARM_GRAVE, cAl.ALARMGEREE_NSEUIL, cAl.ALARMDATA_VSEUIL,
	               	   cAl.ALARM_NUMAL, cAl.ALARM_TEXTE, cAl.ALARM_INFO, cAl.ALARMGEREE_NOM,
			   cAl.ALARM_COMMENT, cAl.ALARMGEREE_LOCAL, cAl.ALARM_COMMUT, cAl.ALARM_IDDEB,
			   NULL, cAl.ACCES_ACCESC_ID, cAl.ALARMDATA_ACK, cAl.ALARMDATA_IANA,
			   TsPrOper, Debord);
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
		for vProg in CurProg (:new.ACCES_ACCESC2_ID) loop
    		    update PROG
		    set PROG_MASQUE = 2
		    where PROG_ID = vProg.PROG_ID;
		end loop;

	    	if (vAcc2.ALARM_ID is not null) then	/* l'alarme était en cours */
		    maj_oper  (vAcc2.ALARM_ID, vAcc2.SITE_ID, vAcc2.EQUIP_ID, vAcc2.LIAI_ID,
			   1, 0, 0, ProgNb, EltSiteId, EltSiteNom, EltTypeId, EltTypeNom, EltId, EltNom, 
			   TsPrOper, Debord);
			/* on fait retomber artificiellement cette alarme, afin de
			   calculer TsPrOper qui est utilisé pour mettre à jour
			   les "boutons programmes". On introduit le "masque" au préalable
			   pour que TsPrOper en tienne compte.
			   On suppose à priori que l'alarme est locale, ce qui est
			   utilisé pour connaître l'état opérationnel du programme.
			   Cette donnée est peut être inutile. A supprimer ultérieurement !! */

		    TsPrOper2 := TsPrOper;
				/* sauvegarde de TsPrOper, représentant l'état opérationnel
				des programmes, indépendamment de l'alarme qui vient d'être
				masquée */

		    Stop_Alrm (Mess, vAcc2.ALARM_ID, vAcc2.ALARMGEREE_ID, vAcc2.SITE_ID,
			   vAcc2.EQUIP_ID, vAcc2.LIAI_ID, vAcc2.ALARM_CL, vAcc2.ALARM_NUMOBJ,
			   vAcc2.ALARM_NUMAL, TsPrOper);
				/* on arrête l'alarme sur les postes clients, car
				on ne recevra plus de message de celle-ci */

		    maj_oper  (vAcc2.ALARM_ID, vAcc2.SITE_ID, vAcc2.EQUIP_ID, vAcc2.LIAI_ID,
			   1, vAcc2.ALARMGEREE_GRAVE, 0, ProgNb, EltSiteId, EltSiteNom, EltTypeId, EltTypeNom, 
			   EltId, EltNom, TsPrOper, Debord);
			/* enfin, on calcule à nouveau l'état opérationnel, avec la vraie
			   gravité de l'alarme en cours. */

		    delete ALARM2 where ALARM2_ID = vAcc2.ALARM_ID;

		else			/* l'alarme masquée n'était pas en cours */
		    ProgNb   := 0;
		    TsPrOper := '';
		    Debord   := 0;
		    for vProg in CurProg (:new.ACCES_ACCESC2_ID) loop
		    	select B.PROG_OPER, PROG_MASQUE into ProgOper, ProgMsk
			    from PROG A, PROG_REP B
			    where A.PROG_ID = vProg.PROG_ID and
				  A.PROG_ID = B.PROG_ID;

		    	if ((TsPrOper is NULL or length (TsPrOper) <= 800) and Debord = 0) then
--	    	    	    ProgNb := ProgNb +1;
		    	    TsPrOper := TsPrOper || to_char (vProg.PROG_ID) || ',' || to_char (ProgOper) ||
		    	            ',' || to_char (ProgOper) || ',' || to_char (ProgMsk) || ';';
		        elsif (length (TsPrOper) > 800) then
			    Debord := 1;
			end if;
		    end loop;
--		    TsPrOper2 := to_char (ProgNb) || ';' || TsPrOper;

	    	end if;

		for vProg in CurProg (:new.ACCES_ACCESC2_ID) loop
		    insert into PROG_MSK (CABL_ID, PROG_ID, TYPE, MSK)
			values (:new.ACCES_ACCESC2_ID, vProg.PROG_ID, 1, 2);
		end loop;

	    	Mask_Alrm (Mess, ' ', 0, to_char (:new.ACCES_ACCESC2_ID), 3,
			   SiteId, EquipId, LiaiId, TsPrOper2);
				/* les clients masquent l'alarme --
				ACCES_ACCESC2_ID sert de signature pour le message */
	    end if;	/* masquage */

	    if (OldMask = 1 and NewMask = 0) then	/* on vient de démasquer l'alarme */

            --insert into tracetmp (trace_id, trace_mess)
                    --values (seq_trace.nextval, ' on vient de démasquer alarme');

		ProgNb 	 := 0;
		TsPrOper := '';
		Debord   := 0;
		for vProg in CurProg2 (:new.ACCES_ACCESC2_ID) loop
		    update PROG
			set PROG_MASQUE = 0
			where PROG_ID = vProg.PROG_ID;

		    select B.PROG_OPER, PROG_MASQUE into ProgOper, ProgMsk
			from PROG A, PROG_REP B
			where A.PROG_ID = vProg.PROG_ID and
			      A.PROG_ID = B.PROG_ID;

		    if ((TsPrOper is NULL or length (TsPrOper) <= 800) and Debord = 0) then
--	    	    	ProgNb := ProgNb +1;
		    	TsPrOper := TsPrOper || to_char (vProg.PROG_ID) || ',' || to_char (ProgOper) ||
		    	            ',' || to_char (ProgOper) || ',' || to_char (ProgMsk) || ';';
		    elsif (length (TsPrOper) > 800) then
			Debord := 1;
		    end if;
		end loop;
--		TsPrOper := to_char (ProgNb) || ';' || TsPrOper;

		delete PROG_MSK
		    where CABL_ID = :new.ACCES_ACCESC2_ID and
			  TYPE = 1;

--insert into tracetmp (trace_id, trace_mess)
                    --values (seq_trace.nextval, ' les clients démasquent alarme ');

	    	Mask_Alrm (Mess, ' ', 0, to_char (:new.ACCES_ACCESC2_ID), 2, SiteId, EquipId, LiaiId, TsPrOper);
						/* les clients démasquent l'alarme */

	    	if (vAcc2.ALARM_ID is not null) then	/* l'alarme est en cours */
		    for cAl in cAlarm (vAcc2.ALARM_ID) loop

                    --insert into tracetmp (trace_id, trace_mess)
                    --values (seq_trace.nextval, ' start alarme ' || to_char(cAl.ALARM_ID));
                           Start_Alrm (cAl.ALARM_ID, cAl.ALARMGEREE_ID,
			   cAl.SITE_ID, cAl.EQUIP_ID, cAl.LIAI_ID,
 			   cAl.ALARM_NUM, cAl.ALARM_CL, cAl.ALARM_NUMOBJ, cAl.ALARMGEREE_TYPAL,
			   cAl.ALARM_DATE, cAl.ALARM_GRAVE, cAl.ALARMGEREE_NSEUIL, cAl.ALARMDATA_VSEUIL,
	               	   cAl.ALARM_NUMAL, cAl.ALARM_TEXTE, cAl.ALARM_INFO, cAl.ALARMGEREE_NOM,
			   cAl.ALARM_COMMENT, cAl.ALARMGEREE_LOCAL, cAl.ALARM_COMMUT, cAl.ALARM_IDDEB,
			   NULL, cAl.ACCES_ACCESC_ID, cAl.ALARMDATA_ACK, cAl.ALARMDATA_IANA,
			   TsPrOper, Debord);
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
