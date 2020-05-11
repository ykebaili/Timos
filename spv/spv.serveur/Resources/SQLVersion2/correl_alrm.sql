create or replace
FUNCTION correl_alrm (Mess IN OUT NOCOPY VARCHAR2,
    IdEvt NUMBER, IdAlarmData NUMBER, SiteId NUMBER, EquipId NUMBER, LiaiId NUMBER, 
    DateAlSec NUMBER, AlarmGrave NUMBER, AlarmIddeb NUMBER, TsPrOper IN OUT NOCOPY VARCHAR2, 
    Debord IN OUT NUMBER)
RETURN BOOLEAN
	/* Cette fonction effectue les différents traitements liés à la corrélation des alarmes.
	   Elle appelle les procédures ou fonctions :
		- IsMaskedBy (Id1, Id2)
		- AlarmNature (Id)
		- MaskeBy (Id1, Id2)
	   Elle retourne :
	   	- FALSE : arrêter le traitement d'alarme (alarme masquée)
	   	- TRUE  : continuer le traitement d'alarme (alarme indépendante ou mère) */

IS
    PrecTime	integer;	/* Précision de datation des EDC, en sec. */
    Nature	integer;	/* Nature d'une alarme */

    CURSOR cAccesc is
	select B.ALARM_ID, B.ALARMDATA_ID, B.SITE_ID, B.EQUIP_ID, B.LIAI_ID, A.ALARMGEREE_ID, 
		   B.ALARM_CL, B.ALARM_NUMOBJ, B.ALARM_NUMAL
	    from ACCES_ACCESC A, ACCES_ACCESC_REP B
	    where A.ACCES_ACCESC_ID = B.ACCES_ACCESC_ID and
		  A.COMMUT = 0 and
		  ABS (DateAlSec - B.ALARM_SEC) <= PrecTime and
		  B.ALARM_ID != IdEvt;
	
			-- Toutes les autres alarmes en cours, démarrées en même temps que IdEvt
/*
    CURSOR cAlarm is
	select ALARM_ID from ALARM_ALARMC
	    where ALARM_ID = AlarmIddeb;*/
	    
	CURSOR cAlarm is
	select ALARMDATA_ID from ALARMDATA_CORREL
	    where ALARMDATA_ID = IdAlarmData;
	

    AlarmType 	NUMBER;
    AlarmNseuil VARCHAR2 (50);
    AlarmNomL 	VARCHAR2 (50);
    AlarmComment VARCHAR2(260);

    ProgNb	NUMBER;		/* inutilisé ici */

	EltSiteId     NUMBER;  /* ID du site contenant l'élt. en défaut. 
								null pour une liaison inter-site. Inutilisé ici */
    EltSiteNom     VARCHAR2 (40);  /* nom du site contenant l'élt. en défaut. 
									  ' ' pour une liaison inter-site. Inutilisé ici */
	EltTypeId NUMBER;	/* ID du type de l'équipement ou de la liaison ou du site 
						   inutilisé ici */
    EltTypeNom    VARCHAR2 (40);  	/* nom du type de l'équipement ou de la liaison ou du site */
    EltId    NUMBER;  	/* ID de l'équipement ou de la liaison ou du site en défaut. 
							Inutilisé ici */
    EltNom    VARCHAR2 (80);  	/* Position de l'équipement ou nom de la liaison 
								   ou du site en défaut. Inutilisé ici */

BEGIN

    PrecTime := 4;	/* Précision de datation IS en s. : 2 s. * 2 IS */

    if (AlarmGrave > 0) then	/* Début d'alarme */
    	for cAl in cAccesc loop /* Boucle sur les alarmes arrivées à peu près en même temps */
  	    if (IsMaskedBy (IdAlarmData, EquipId, LiaiId, cAl.ALARMDATA_ID, cAl.EQUIP_ID, cAl.LIAI_ID)) then
  				/* IdEvt est masquée par cAl.ALARM_ID */
  				/* On ne peut être masqué que par une alarme mère ou autonome */
  		      --insert into ALARM_ALARMC (ALARM_ID, ALARM_BINDINGID) values (IdEvt, cAl.ALARM_ID);
  		      insert into ALARMDATA_CORREL (ALARMDATA_ID, ALARMDATA_BINDINGID) 
  					values (IdAlarmData, cAl.ALARMDATA_ID);
    --        insert into test values(seq_test.nextval, 'correl1 Eq1= ' || EquipId || 'correl1 Eq2= ' ||cAl.EQUIP_ID);
  		      return FALSE;	/* Alarme fille */
  	    end if;
	    end loop;

    	for cAl in cAccesc loop	/* Ces alarmes sont elles masquées par la nouvelle alarme ? */
  	    if (IsMaskedBy (cAl.ALARMDATA_ID, cAl.EQUIP_ID, cAl.LIAI_ID, IdAlarmData, EquipId, LiaiId)) then
 -- 				  insert into test values(seq_test.nextval, 'correl2 Eq1= ' || cAl.EQUIP_ID || 'correl2 Eq2= ' ||EquipId);

          /* IdEvt masque cAl.ALARM_ID */
  		      Nature := AlarmNature (cAl.ALARMDATA_ID);
  				/* Alarme autonome (0), mère (1), fille (2) */

  --				insert into test values(seq_test.nextval, 'Debut dalarm Nature=' || Nature);

        		if (Nature = 1) then
        		    -- update ALARM_ALARMC			/* cAl.ALARM_ID était une alarme mère */
        			-- set ALARM_BINDINGID = IdEvt	/* Elle est déclassée par IdEvt */
        			-- where ALARM_BINDINGID = cAl.ALARM_ID;
        			update ALARMDATA_CORREL						/* cAl.ALARMDATA_ID était une alarme mère */
        				set ALARMDATA_BINDINGID = IdAlarmData	/* Elle est déclassée par IdAlarmData */
        				where ALARMDATA_BINDINGID = cAl.ALARMDATA_ID;
        		end if;

        		if (Nature != 2) then		/* cAl.ALARMDATA_ID n'est pas une alarme fille :
        						   on la masque */
        			/*
        		    insert into ALARM_ALARMC (ALARM_ID, ALARM_BINDINGID)
        			     values (cAl.ALARM_ID, IdEvt);*/
        			insert into ALARMDATA_CORREL (ALARMDATA_ID, ALARMDATA_BINDINGID)
        			     values (cAl.ALARMDATA_ID, IdAlarmData);

        --			    	insert into test values (SEQ_TEST.NEXTVAL, 'correl_alrm : SiteId = '||cAl.SITE_ID ||
         --     ' EquipId = '|| cAl.EQUIP_ID || ' LiaiId = ' || cAl.LIAI_ID);

        		    maj_oper (cAl.ALARM_ID, cAl.SITE_ID, cAl.EQUIP_ID, cAl.LIAI_ID, 0, 0, 0,
        			      ProgNb, EltSiteId, EltSiteNom, EltTypeId, EltTypeNom, EltId, EltNom, TsPrOper, Debord);
        						/* "retombée" de cAl.ALARM_ID */

        /* insert into testcorr (IdEvt,T,V1,V2) values (SEQ_TEST.NEXTVAL,'OFF2', cAl.ALARM_NUMAL, cAl.ALARM_ID); */

        		    delete ALARM2 where ALARM2_ID = cAl.ALARM_ID;

        		    Stop_Alrm (Mess, cAl.ALARM_ID, cAl.ALARMGEREE_ID, cAl.SITE_ID, cAl.EQUIP_ID,
        			       cAl.LIAI_ID, cAl.ALARM_CL, cAl.ALARM_NUMOBJ, cAl.ALARM_NUMAL, TsPrOper);
        			/* envoi du message de retombée de l'alarme pour chacune de ces alarmes
        			   qui sont masquées par la nouvelle alarme arrivée */
        		end if;	/* retombée de cAl.ALARM_ID */

      	  end if;--IsMaskedBy
	    end loop;

    else			/* Fin d'alarme */
    	Nature := AlarmNature (AlarmIddeb);
---    	insert into test values(seq_test.nextval, 'Fin dalarm Nature=' || Nature);


	   if (Nature = 1) then 	/* Alarme mère */
	    insert into FINALARM (FINALARM_ID, ALARM_ID) values (SEQ_FINALARM.NEXTVAL, IdEvt);
	   elsif (Nature = 2) then	/* Alarme fille */
	    --delete ALARM_ALARMC
  	    --    where ALARM_ID = AlarmIddeb;
  	    delete ALARMDATA_CORREL
  	    where ALARMDATA_ID = IdAlarmData;
	    return FALSE;
     end if;

    end if;--Fin d'alarme

    return TRUE;

END correl_alrm;
