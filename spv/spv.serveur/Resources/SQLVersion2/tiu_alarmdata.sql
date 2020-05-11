create or replace
TRIGGER TIU_ALARMDATA AFTER INSERT OR UPDATE ON ALARMDATA FOR EACH ROW 
	/* Appelle indirectement les fonctions ou procédures stockées suivantes :
		- correl_alrm,
		- IsMaskedAdm,
		- IsmaskedBri,
		- maj_oper,
		- mess_alrm
		- mess_video */
declare
    integrity_error  exception;
    Erreur_Trigger   EXCEPTION;			-- interblocage entre alarmes, si plusieurs EM
    Erreur2_Trigger  EXCEPTION;
    PRAGMA EXCEPTION_INIT (Erreur_trigger,  -6512);
    PRAGMA EXCEPTION_INIT (Erreur2_trigger, -60);

    errno            integer;
    errmsg           char(200);
    nb_rel           integer;     -- nombre de relations avec autres tables

    i		     integer;	  -- compteur banal

    Sonne	     integer;	  -- 1 s'il faut sonner pour cette alarme, 0 sinon
    Acquit     	     integer;	  -- 1 s'il faut acquitter cette alarme, 0 sinon
    
    AlarmCommut       ALARM.ALARM_COMMUT%TYPE;
    AlarmNum          ALARM.ALARM_NUM%TYPE;
    AlarmCl           ALARM.ALARM_CL%TYPE;
    AlarmNumobj       ALARM.ALARM_NUMOBJ%TYPE;
    AlarmGrave        ALARM.ALARM_GRAVE%TYPE;
    AlarmNumal        ALARM.ALARM_NUMAL%TYPE;
    AlarmTexte        ALARM.ALARM_TEXTE%TYPE;
    AlarmInfo         ALARM.ALARM_INFO%TYPE;
    AlarmgereeId      ALARM.ALARMGEREE_ID%TYPE;
    AlarmComment      ALARM.ALARM_COMMENT%TYPE;
    AlarmId           ALARM.ALARM_ID%TYPE;
    AlarmIdDeb        ALARM.ALARM_ID%TYPE;
    AlarmDate         ALARM.ALARM_DATE%TYPE;
    
    bTempTrouv      boolean;
    
    Cursor CTemp is
        select ALARM_ID, ALARM_COMMUT, ALARM_NUM, ALARM_CL, ALARM_NUMOBJ, ALARM_GRAVE, 
				ALARM_NUMAL, ALARM_TEXTE, ALARM_INFO, ALARM_COMMENT, ALARMGEREE_ID, ALARM_DATE,
				ALARM_IDDEB
            from alarm_temp 
            where ALARMDATA_ID = :new.ALARMDATA_ID
            order by ALARM_ID;

begin
	/* Si le trigger est déclenché par suite d'un enregistrement créé par réplication,
	   on ne fait pas le traitement */
	if dbms_reputil.from_remote=TRUE then
		return;
	end if;
        
        for rCTemp in CTemp loop
			  AlarmId		:= rCTemp.ALARM_ID;
			  if (rCTemp.ALARM_IDDEB is not null) then
					AlarmIdDeb := rCTemp.ALARM_IDDEB;
			  end if;
              bTempTrouv	:= true;
              AlarmCommut   := rCTemp.ALARM_COMMUT;
              AlarmNum      := rCTemp.ALARM_NUM;
              AlarmCl       := rCTemp.ALARM_CL;
              AlarmNumobj   := rCTemp.ALARM_NUMOBJ;
              AlarmGrave    := rCTemp.ALARM_GRAVE;
              AlarmNumal    := rCTemp.ALARM_NUMAL;
              AlarmTexte    := rCTemp.ALARM_TEXTE;
              AlarmInfo     := rCTemp.ALARM_INFO;
              AlarmComment  := rCTemp.ALARM_COMMENT;
              AlarmgereeId  := rCTemp.ALARMGEREE_ID;
              AlarmDate     := rCTemp.ALARM_DATE;
        end loop;
        
        if (not bTempTrouv) then
            raise_application_error (-20000, 'tiu_alarm, record not found in ALARM_TEMP');
        end if;
        
	if (AlarmgereeId = 0 and AlarmCommut = 0) then
	    return;	-- erreur détectée par TIB_ALARM
	end if;

/* JPB 300307
	if (:new.ALARM_TYPMAJ = 'B') then
	    return;		-- Alarme bagottante
	end if;
FIN JPB */

	nb_rel := 0;

	if (:new.SITE_ID is not null) then
		nb_rel := nb_rel + 1;
	end if;

	if (:new.EQUIP_ID is not null) then
		nb_rel := nb_rel + 1;
	end if;

	if (:new.LIAI_ID is not null) then
		nb_rel := nb_rel + 1;
	end if;

	if (:new.SITE_ID = 0) then
	    return;
	end if;

	if (nb_rel != 1) then
      	    errno  := -20002;
	    errmsg :=
                'An ALARMDATA record should have one and only one relation with an other table';
	    raise integrity_error;
	end if;

	if (:new.ACCES_ACCESC_ID is not null) then
	    select COUNT(*) into nb_rel from ACCES_ACCESC where ACCES_ACCESC_ID =
		:new.ACCES_ACCESC_ID;

          if (nb_rel != 1) then
              errno  := -20002;
	        errmsg :=
                    'When ACCES_ACCESC_ID is not null, ACCES_ACCESC_ID should refer to one record in ACCES_ACCESC';
	        raise integrity_error;
	    end if;

	    select ALARMGEREE_SON, ALARMGEREE_ACQ into Sonne, Acquit
		from ACCES_ACCESC
		where ACCES_ACCESC_ID = :new.ACCES_ACCESC_ID;
	end if;

        if (bTempTrouv) then
            for i in 1..10 loop	-- 10 essais max
                begin
                    PostAlrm (AlarmId, :new.ALARMDATA_ID, AlarmgereeId, :new.SITE_ID, :new.EQUIP_ID,
                      :new.LIAI_ID, AlarmNum, AlarmCl, AlarmNumobj,
                      :new.ALARMGEREE_TYPAL, AlarmDate,
                      AlarmGrave, :new.ALARMGEREE_NSEUIL, :new.ALARMDATA_VSEUIL, AlarmNumal, 
                      AlarmTexte, AlarmInfo, :new.ALARMGEREE_NOM, :new.ALARMDATA_COMMENT, :new.ALARMGEREE_LOCAL, 
                      AlarmCommut, AlarmIdDeb, null, :new.ACCES_ACCESC_ID, Sonne, Acquit, 0, :new.ALARMDATA_IANA,
                      GetClasseObjetEnDefaut (:new.EQUIP_ID, :new.LIAI_ID, :new.SITE_ID));

                    update ACQUITTEMENT
                        set ACK = 0;	/* alarme non acquittée */

                    exit;

                exception
                    when Erreur_Trigger or Erreur2_Trigger then
                        null;

                end;
            end loop;
        end if;

exception
    when integrity_error then
       raise_application_error (errno, errmsg);

END;
