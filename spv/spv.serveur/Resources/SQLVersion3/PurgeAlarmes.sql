create or replace
PROCEDURE PurgeAlarmes (iMaxJoursAl NUMBER, iMaxErr NUMBER, iMaxMail NUMBER, iMaxLog NUMBER)
IS
    LastDayStr	VARCHAR2 (20);	-- date et heure actuelle - MaxJoursAl au format YYYY MM DD HH24:MI:SS
    LastDaySec	NUMBER;		-- idem en nombre de secondes depuis le 01/01/1998 00:00:00

    IdErrMax	NUMBER;		-- Id de la donnée la plus récente
    IdErrMin	NUMBER;		-- Id de la donnée la plus ancienne conservée

    SSecours	BOOLEAN;	-- False si c'est un serveur Normal, ou pas de réplication
				-- True  pour le serveur Secours en réplication
    MaxJoursAl	NUMBER;		-- Nb. max. de jours d'alarmes à garder
    MaxErr	NUMBER;		-- Nb. max. d'erreurs à garder
    MaxMail	NUMBER;		-- Nb. max. de mails à garder
    MaxLog	NUMBER;		-- Nb. max. de logs à garder

    MyDate	DATE;
BEGIN

    -- Sécurité sur les paramètres : valeurs autorisées

    if (iMaxJoursAl < 10) then
	MaxJoursAl := 10;
    elsif (iMaxJoursAl > 1460) then
	MaxJoursAl := 1460;
    else
	MaxJoursAl := iMaxJoursAl;
    end if;

    if (iMaxErr < 100) then
	MaxErr := 100;
    else
	MaxErr := iMaxErr;
    end if;
    if (iMaxErr > 50000) then
	MaxErr := 50000;
    else
	MaxErr := iMaxErr;
    end if;

    if (iMaxMail < 0) then
	MaxMail := 0;
    else
	MaxMail := iMaxMail;
    end if;
    if (iMaxMail > 10000) then
	MaxMail := 10000;
    else
	MaxMail := iMaxMail;
    end if;

    if (iMaxLog < 0) then
	MaxLog := 0;
    else
	MaxLog := iMaxLog;
    end if;
    if (iMaxLog > 10000) then
	MaxLog := 10000;
    else
	MaxLog := iMaxLog;
    end if;

    -- Suppression des alarmes les plus anciennes

    --LastDayStr := to_char (ADD_MONTHS (sysdate, - MaxMoisAl), 'YYYY MM DD HH24:MI:SS');
    LastDayStr := to_char (sysdate - MaxJoursAl, 'YYYY MM DD HH24:MI:SS');
    LastDaySec := CO_SEC1998 (LastDayStr);

    -- On supprime d'abord les fins d'alarme, correspondant à une alarme ayant démarré avant Idmax

    delete ALARM2 where ALARM2_ID in
	(select B.ALARM_ID from ALARM A, ALARM B
	     where A.ALARM_SEC <= LastDaySec and A.ALARM_ID = B.ALARM_IDDEB);
    delete ALARM3 where ALARM3_ID in
	(select B.ALARM_ID from ALARM A, ALARM B
	     where A.ALARM_SEC <= LastDaySec and A.ALARM_ID = B.ALARM_IDDEB);
    delete ALARM where ALARM_ID in
	(select B.ALARM_ID from ALARM A, ALARM B
	     where A.ALARM_SEC <= LastDaySec and A.ALARM_ID = B.ALARM_IDDEB);

    -- On supprime maintenant les alarmes ayant démarré avant LastDaySec

    delete ALARM2 where ALARM2_ID in
	(select ALARM_ID from ALARM
	     where ALARM_SEC <= LastDaySec);
    delete ALARM3 where ALARM3_ID in
	(select ALARM_ID from ALARM
	     where ALARM_SEC <= LastDaySec);

    -- On fait "retomber" ces alarmes, si elles sont encore "en-cours"

    update ACCES_ACCESC_REP
	set ALARM_ID = NULL,
	    SITE_ID  = NULL,
	    EQUIP_ID = NULL,
	    LIAI_ID  = NULL,
	    ALARM_SEC= NULL
	where ALARM_ID in
	(select ALARM_ID from ALARM
	     where ALARM_SEC <= LastDaySec);

  /*  update BITMESS_REP
	set ALARM_ID = NULL,
	    SITE_ID  = NULL,
	    EQUIP_ID = NULL,
	    LIAI_ID  = NULL,
	    ALARM_SEC= NULL
	where ALARM_ID in
	(select ALARM_ID from ALARM
	     where ALARM_SEC <= LastDaySec);*/

    -- Enfin, on met ALARM à jour

    delete ALARM where ALARM_SEC <= LastDaySec;

    -- Suppression des erreurs les plus anciennes

    select max (ERROR_ID) into IdErrMax from ERROR;
    IdErrMin := IdErrMax - MaxErr;	-- on suppose qu'il n'y a pas eu de trous dans les Id

    if (IdErrMin > 0) then
	delete ERROR
	    where ERROR_ID < IdErrMin;
    end if;

    -- Suppression des mails les plus anciens

  /*  select max (MAILALRM_ID) into IdErrMax from MAILALRM;
    IdErrMin := IdErrMax - MaxMail;	-- on suppose qu'il n'y a pas eu de trous dans les Id

    if (IdErrMin > 0) then
	delete MAILALRM
	    where MAILALRM_ID < IdErrMin;
    end if;*/

    -- Suppression des logs les plus anciens

    select max (LOG_ID) into IdErrMax from LOGSPV;
    IdErrMin := IdErrMax - MaxLog;	-- on suppose qu'il n'y a pas eu de trous dans les Id

    if (IdErrMin > 0) then
	delete LOGSPV
	    where LOG_ID < IdErrMin;
    end if;

    -- On vérifie si on est en mode répliqué et dans ce cas, si on est "Secours"

    -- SSecours := Sys.Spv_Sys.IsSecours;
    SSecours := IsSecours;

    if (SSecours) then
	--	delete MAILALRM;
		delete MESSALRM;
		delete LOGSPV;
	--   	delete LIAIVPIVCI;
   	--	delete LIAIVPI;
	  -- 	delete PROG_LIAITEMP;
   	--	delete VERROU;
    end if;

    -- Purge des enregistrements de MESSEMREAD et MESSEM <= J - 2
    select SYSDATE - 2 into MyDate from DUAL;

    delete MESSEMREAD where MESSEM_ID in (select MESSEM_ID from MESSEM where MESSEM_DATE <= MyDate);
    delete MESSEM where MESSEM_DATE <= MyDate;

    insert into LOGSPV (LOG_ID, LOG_DATE, LOG_TEXT) values
	(SEQ_LOGSPV.NEXTVAL, sysdate, 'Processus de purge effectué');

    commit;

--  gestion des erreurs
EXCEPTION
    when OTHERS then
	rollback;
	insert into LOGSPV (LOG_ID, LOG_DATE, LOG_TEXT) values
	    (SEQ_LOGSPV.NEXTVAL, sysdate, 'Processus de purge : exception rencontrée');
	commit;

END	PurgeAlarmes;
