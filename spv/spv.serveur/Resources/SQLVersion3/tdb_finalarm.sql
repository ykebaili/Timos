create or replace
TRIGGER tdb_finalarm before delete on FINALARM for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);

    Erreur_Trigger   EXCEPTION;		-- interblocage entre alarmes, si plusieurs EM
    Erreur2_Trigger  EXCEPTION;
    PRAGMA EXCEPTION_INIT (Erreur_trigger,  -6512);
    PRAGMA EXCEPTION_INIT (Erreur2_trigger, -60);

    i		     integer;	  -- compteur banal

    TsPrOper VARCHAR2 (900); /* Chaîne donnant l'état opérationnel des prog. concernés par
				cette alarme. 70 prog. au max.
				Structure : NbProg; ProgId, OldProgOper, ProgOper, ProgMsk;
				ProgId,  etc... */
    Debord   NUMBER;	     /* 1 si débordement de la chaîne TsPrOper, 0 sinon */

    CURSOR cDeb is
	select ALARMDATA_ID from ALARM
	    where ALARM_ID = :old.ALARM_ID;

    CURSOR cMasked (IdAlarmData NUMBER) is
	select * from ALARMDATA_CORREL
	    where ALARMDATA_BINDINGID = IdAlarmData
	for update of ALARMDATA_ID;

    CURSOR cAlarm (Id NUMBER) is
	select ALARM.ALARM_ID, ALARM.ALARMGEREE_ID,
              ALARM.ALARM_NUM, ALARM.ALARM_CL, ALARM.ALARM_NUMOBJ, ALARM.ALARM_DATE, ALARM.ALARM_GRAVE,
              ALARM.ALARM_NUMAL, ALARM.ALARM_TEXTE, ALARM.ALARM_INFO, ALARM.ALARM_COMMENT,
              ALARM.ALARM_COMMUT, ALARM.ALARM_IDDEB,
              ALARMDATA.ALARMDATA_ID,
              ALARMDATA.EQUIP_ID, ALARMDATA.SITE_ID, ALARMDATA.LIAI_ID,
              ALARMDATA.ALARMGEREE_TYPAL, ALARMDATA.ALARMGEREE_NSEUIL, ALARMDATA.alarmdata_VSEUIL,
              ALARMDATA.ALARMGEREE_NOM, ALARMDATA.ALARMGEREE_LOCAL, ALARMDATA.ACCES_ACCESC_ID,
              ALARMDATA.ALARMDATA_ACK, ALARMDATA.ALARMDATA_IANA
          from ALARM, ALARMDATA
	    where ALARMDATA.ALARMDATA_ID = Id
            and ALARM.ALARMDATA_ID = ALARMDATA.ALARMDATA_ID; /* Correspond à l'alarme masquée à tort */

    infos_diag_table diagramme.infos_diag_t;
begin
    /* Si le trigger est déclenché par suite d'un enregistrement créé par réplication,
    on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
		return;
	end if;

    Debord := 0;
SetTrace('tdb_finalarm 1');
    for cFinAl in cDeb loop
SetTrace('tdb_finalarm 2');    
    	for cMas in cMasked (cFinAl.ALARMDATA_ID) loop /* al. masquée à tort par l'al mère */
SetTrace('tdb_finalarm 3 ' || cMas.ALARMDATA_ID);        
            for cAl in cAlarm (cMas.ALARMDATA_ID) loop
SetTrace('tdb_finalarm 4');            
		for i in 1..10 loop	-- 10 essais max
	    	    begin
SetTrace('tdb_finalarm 5');                    
                        pack_alarme.Start_Alrm (cAl.ALARM_ID, cAl.ALARMDATA_ID, cAl.ALARMGEREE_ID,
                                                cAl.SITE_ID, cAl.EQUIP_ID, cAl.LIAI_ID,
                                                cAl.ALARM_NUM, cAl.ALARM_CL, cAl.ALARM_NUMOBJ, 
                                                cAl.ALARMGEREE_TYPAL, cAl.ALARM_DATE, cAl.ALARM_GRAVE, 
                                                cAl.ALARMGEREE_NSEUIL, cAl.alarmdata_VSEUIL, cAl.ALARM_NUMAL, 
                                                cAl.ALARM_TEXTE, cAl.ALARM_INFO, cAl.ALARMGEREE_NOM,
                                                cAl.ALARM_COMMENT, cAl.ALARMGEREE_LOCAL, cAl.ALARM_COMMUT, 
                                                cAl.ALARM_IDDEB, NULL, cAl.ACCES_ACCESC_ID, cAl.alarmdata_ACK, 
                                                cAl.alarmdata_IANA, infos_diag_table);
			exit;

	    	    exception
    			when Erreur_Trigger or Erreur2_Trigger then
		    	    null;
		    end;
		end loop;	/* fin des essais StartAlrm */

	    end loop;		/* fin du traitement sur l'alarme masquée */
	end loop;		/* fin de la boucle sur les alarmes masquées */

    	delete ALARMDATA_CORREL
	    where ALARMDATA_BINDINGID = cFinAl.ALARMDATA_ID;
    end loop;			/* fin de la boucle sur les alarmes mères retombées */

--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end  TDB_FINALARM;
