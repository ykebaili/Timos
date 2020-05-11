create or replace
TRIGGER tib_alarm before insert on ALARM for each row
declare
    IsAccesId	integer;	/* ACCES_ID correspondant au n° IS et NUMAL (ou n° IP2PORT et NUMAL) */
    NumBit   	NUMBER;		/* n° bit si alarme série : 1 .. */
    OrigAccesId integer;	/* ACCES_ID de l'objet à l'origine de l'alarme */
    MessId	integer;	/* ID du message série correspondant à cette alarme */
    ScriptId	integer;	/* Id du script à déclencher éventuellement */
    Nb		integer;	/* Nb. banal */
    Str		varchar2 (80);  /* banal */
    StrTest	varchar2 (1024);/* pour insert en table TEST */
    OldId	integer;	/* ID de l'alarme déjà présente sur cet accès */
    Grave	number;		/* gravité réelle de l'alarme */
    lGrave	number;		/* valeur temporaire de la gravité */
    CablageId	number;		/* ID de ACCES_ACCESC ou BITMESS de cette alarme */
    MaskAdm	boolean;	/* true si al. masquée par Adm, false sinon */
    Info	varchar2 (256);	/* ALARM_INFO, pour alarme GSITE */
    Pos		NUMBER;		/* Position dans une chaîne de caractère */
    Pos2	NUMBER;		/* idem */
    AlarmId	NUMBER;		/* Id de l'alarme à faire retomber */
    ARetomber   BOOLEAN;	/* true si "Alarme à faire retomber" */
    commutOID	varchar2 (128);	/*typeq.commut-OID*/
    typeq_commut number;
    EquipState   number; 	/*l'etat du commutateur*/
    DecalGrave   number; 	/* décalage entre la valeur de la gravité dans les combo et dans la base.
			  	   Combo 0="Avertissement" .. codé 3 dans la base */
    Signat	varchar2 (1256);/* Signature de l'alarme :
					ALARM_CL + ALARM_NUMOBJ + ALARM_NUMAL
					+ ALARM_INFO si ALARM_TEXTE = 3 ou 4 (GSITE ou Système)
					+ ALARM_IANA + EquipId si ALARM_CL = TRAPG ou TRAPS */
    BagotId	 number;	/* Id dans la table BAGOT */
    BagotEC	 number;	/* Bagot en cours */
    BagotCpt	 number;	/* Compteur de bagots */
    BagotAlId	 number;	/* Id de l'alarme précédente */
    BagotAlIddeb number;	/* Id de l'alarme précédente */
    ModCalc number; -- Mode de calcul standard ou NEC
    
    AlarmSec            ALARMDATA.ALARMDATA_SECDEBUT%TYPE;
    AlarmDate           ALARMDATA.ALARMDATA_DATEDEBUT%TYPE;
    AlarmeSecDebut      ALARMDATA.ALARMDATA_SECDEBUT%TYPE;
    SiteId              ALARMDATA.SITE_ID%TYPE;
    EquipId             ALARMDATA.EQUIP_ID%TYPE;
    LiaiId              ALARMDATA.LIAI_ID%TYPE;
    NumeroIana          ALARMDATA.ALARMDATA_IANA%TYPE;
    AlarmegereeTypAl    ALARMDATA.ALARMGEREE_TYPAL%TYPE;
    AlarmeLocale        ALARMDATA.ALARMGEREE_LOCAL%TYPE;
    AccesAccescId       ACCES_ACCESC.ACCES_ACCESC_ID%TYPE;
    AlarmeVSeuil        ALARMDATA.ALARMDATA_VSEUIL%TYPE;
    AlarmgereeNSeuil    ALARMDATA.ALARMGEREE_NSEUIL%TYPE;
    AlarmgereeNom       ALARMGEREE.ALARMGEREE_NOM%TYPE;
    AlarmgereeTypAl     ALARMGEREE.ALARMGEREE_TYPAL%TYPE;
    AlarmeComment       ALARMDATA.ALARMDATA_COMMENT%TYPE;
    AlarmgereeSeuilOid  ALARMGEREE.ALARMGEREE_SEUILOID%TYPE;
    AlarmIdDeb          ALARM.ALARM_ID%TYPE;
    AlarmeAck           ALARMDATA.ALARMDATA_ACK%TYPE;
    AlarmeAckWho        ALARMDATA.ALARMDATA_ACKWHO%TYPE;
    AlarmeAckWhen       ALARMDATA.ALARMDATA_ACKWHEN%TYPE;
    AlarmeId            ALARMDATA.ALARMDATA_ID%TYPE;
    

    cursor CxionP is			/* IS GTR ou IP2PORT */
	     select * from ACCES_ACCESC	where ACCES2_ID = IsAccesId;

    cursor CxionG is			/* GSITE ou alarme SYSTème */
	     select * from ACCES_ACCESC 	where ACCES_BINDINGID = IsAccesId
	     and ACCES1_ID = 0 and ACCES2_ID = 0;

    cursor CxionTGS is 			/* Trap SNMP générique ou spécifique */
	     select * from ACCES_ACCESC where ACCES_ACCESC_ID = IsAccesId;

    cursor CBagot (Sig VARCHAR2) is	/* Recherche de l'alarme dans la table BAGOT */
	select * from BAGOT
	where BAGOT_SIG = Sig;

    cursor cAlarmOld (Id NUMBER) is	/* Données de l'alarme précédente */
	select * from ALARM
	where ALARM_ID = Id;

 /*  cursor cAlarm2Old (Id NUMBER) is	-- Données de l'alarme précédente
	select * from ALARM2
	where ALARM2_ID = Id;

    cursor cAlarm3Old (Id NUMBER) is	-- Données de l'alarme précédente
	select * from ALARM3
	where ALARM3_ID = Id;*/

begin
    AlarmeLocale := 1;
    
    /* Si le trigger est déclenché par suite d'un enregistrement créé par réplication,
       on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
	return;
    end if;

    if (:new.ALARM_NUM is null) then
        :new.ALARM_NUM := :new.ALARM_ID;
    end if;

    ModCalc := GetModCalc;		-- Mode de calcul standard ou NEC

--    lock table ACCES_ACCESC in share row exclusive mode;
	/* Ce lock sur la table ACCES_ACCESC permet d'éviter un interblocage
	entre deux sources d'alarmes */

    AlarmSec := CO_SEC1998 (:new.ALARM_DATE);
    :new.ALARM_SEC := AlarmSec;
    AlarmDate := CO_DATE (:new.ALARM_DATE);
    
    ScriptId 	:= 0;	/* pas de script à déclencher à priori */
    ARetomber 	:= false;

    AlarmeSecDebut := NULL;

    DecalGrave := 3;

    if (ToNumber (:new.ALARM_COMMENT) >= 0 and CheckStr (:new.ALARM_COMMENT, '0123456789') = 1) then
	       NumeroIana := ToNumber (:new.ALARM_COMMENT);
    end if;

--  On regarde d'abord les alarmes système FUTUROCOM (9485) envoyés par TRAP :
--  N° Trap = 20	: retombée d'alarme en cours

    if (:new.ALARM_CL = 'E10B') then	-- Une alarme autocom. Alcatel E10B est considérée comme un TRAPS
	       :new.ALARM_CL := 'TRAPS';
    end if;

    if (:new.ALARM_CL = 'TRAPS' and :new.ALARM_COMMENT = 9485 and :new.ALARM_NUMOBJ = 20) then
      	Pos  := INSTR  (:new.ALARM_INFO, '=');
      	Pos2 := INSTR  (:new.ALARM_INFO, ';', Pos);
      	Str  := SUBSTR (:new.ALARM_INFO, Pos+2, Pos2 - Pos -2);

      	AlarmId := TO_NUMBER (Str);
      --	AlarmId := TO_NUMBER (:new.ALARM_INFO);

      	select ALARM_CL, ALARM_TEXTE, ALARM_NUMOBJ, ALARM_NUMAL, ALARM_INFO, 
                ALARMDATA_IANA, ALARMGEREE_TYPAL, ALARMDATA_SECDEBUT, ALARMDATA.ALARMDATA_ID
      	    into :new.ALARM_CL, :new.ALARM_TEXTE, :new.ALARM_NUMOBJ, :new.ALARM_NUMAL,
      		 :new.ALARM_INFO, :new.ALARM_COMMENT, AlarmegereeTypAl, AlarmeSecDebut, AlarmeId
      	    from ALARM, ALARMDATA
      	    where ALARM_ID = AlarmId and ALARMDATA.ALARMDATA_ID = ALARM.ALARMDATA_ID;
      	:new.ALARM_GRAVE := 0;		-- On veut faire retomber cette alarme
      	:new.ALARM_TYPMAJ := 'M';

      	if (:new.ALARM_CL in ('TRAPG', 'TRAPS')) then
      	    select ACCES_ACCESC_ID
      	    	into IsAccesId
      	    	from ACCES_ACCESC_REP
      	    	where ALARM_ID = AlarmId;

      	elsif (:new.ALARM_CL != 'IS_S') then
      	    select ACCES2_ID
      		into IsAccesId
      		from ACCES_ACCESC_REP, ACCES_ACCESC
      		where ACCES_ACCESC_REP.ALARM_ID = AlarmId and
      		      ACCES_ACCESC_REP.ACCES_ACCESC_ID = ACCES_ACCESC.ACCES_ACCESC_ID;
      	end if;

	     ARetomber := true;

--	insert into test values (seq_test.nextval, Str);
    end if; --  N° Trap = 20	: retombée d'alarme en cours

--  N° Trap = 21	: montée manuelle d'une alarme
    if (:new.ALARM_CL = 'TRAPS' and :new.ALARM_COMMENT = 9485 and :new.ALARM_NUMOBJ = 21) then
    	:new.ALARM_TYPMAJ := 'M';

    	StrTest := '';

    	Pos  := INSTR  (:new.ALARM_INFO, '=');
    	Pos2 := INSTR  (:new.ALARM_INFO, ';', Pos);
    	Str  := SUBSTR (:new.ALARM_INFO, Pos+2, Pos2 - Pos -2);
    	:new.ALARM_GRAVE	:= to_number (Str);
    	StrTest	:= StrTest || Str || ' | ';

    	Pos  := INSTR  (:new.ALARM_INFO, '=', Pos2 +1);
    	Pos2 := INSTR  (:new.ALARM_INFO, ';', Pos);
    	Str  := SUBSTR (:new.ALARM_INFO, Pos+2, Pos2 - Pos -2);
    	:new.ALARM_CL		:= substr (Str, 1, 11);
    	StrTest	:= StrTest || Str || ' | ';

    	Pos  := INSTR  (:new.ALARM_INFO, '=', Pos2 +1);
    	Pos2 := INSTR  (:new.ALARM_INFO, ';', Pos);
    	Str  := SUBSTR (:new.ALARM_INFO, Pos+2, Pos2 - Pos -2);
    	:new.ALARM_TEXTE	:= to_number (Str);
    	StrTest	:= StrTest || Str || ' | ';

    	Pos  := INSTR  (:new.ALARM_INFO, '=', Pos2 +1);
    	Pos2 := INSTR  (:new.ALARM_INFO, ';', Pos);
    	Str  := SUBSTR (:new.ALARM_INFO, Pos+2, Pos2 - Pos -2);
    	:new.ALARM_NUMOBJ	:= to_number (Str);
    	StrTest	:= StrTest || Str || ' | ';

    	Pos  := INSTR  (:new.ALARM_INFO, '=', Pos2 +1);
    	Pos2 := INSTR  (:new.ALARM_INFO, ';', Pos);
    	Str  := SUBSTR (:new.ALARM_INFO, Pos+2, Pos2 - Pos -2);
    	:new.ALARM_NUMAL	:= substr (Str, 1, 40);
    	StrTest	:= StrTest || Str || ' | ';

    	Pos  := INSTR  (:new.ALARM_INFO, '=', Pos2 +1);
    	Pos2 := INSTR  (:new.ALARM_INFO, ';', Pos);
    	Str  := SUBSTR (:new.ALARM_INFO, Pos+2, Pos2 - Pos -2);
    	:new.ALARM_COMMENT	:= Str;
    	if (ToNumber (Str) >= 0) then
    	    NumeroIana := ToNumber (Str);
    	end if;
    	StrTest	:= StrTest || Str || ' | ';

    	Pos  := INSTR  (:new.ALARM_INFO, '=', Pos2 +1);
    	Str  := SUBSTR (:new.ALARM_INFO, Pos+2);	-- Tous les caractères suivants
    	Str  := REPLACE (Str, '}', ';');
    	StrTest := StrTest || Str || ' | ';
    	:new.ALARM_INFO := Str;

    --	insert into test values (seq_test.nextval, StrTest);
    end if; --  N° Trap = 21	: montée d'une alarme


    if (not (ARetomber and (:new.ALARM_CL = 'TRAPG' or :new.ALARM_CL = 'TRAPS'))) then
    	if (NOT tib2_alarm
	    (:new.ALARM_ID, :new.ALARM_DATE, :new.ALARM_CL, :new.ALARM_TEXTE, :new.ALARM_NUMAL,
	     :new.ALARM_NUMOBJ, :new.ALARM_COMMENT, :new.ALARM_INFO, MessId, IsAccesId, NumBit))
    	then
	    :new.ALARMGEREE_ID := 0;
	    AlarmegereeTypAl   := 0;
  	    :new.ALARM_COMMUT  := 0;
	    SiteId       := NULL;



	    return;
    	end if;		/* recherche de l'Id de l'accès sur l'IS */
    end if;

    if (NOT ARetomber and :new.ALARM_CL = 'IP2') then	/* La gravité est contenue dans ALARM_INFO */
    	/* La gravité (début ou fin d'alarme) est contenue dans le libellé de l'événement
	   ayant provoqué le trap. Cet événement est décrit dans la première variable
	   du trap, sous la forme DIGn_ON (début d'alarme) ou DIGn_OFF (fin d'alarme).
	   Le "trap" IP2 est transformé en alarme boucle dans SpvTrap2Svc. Ici, ce n'est
	   donc plus un trap, mais une alarme boucle.
	*/
      	Pos  := INSTR (:new.ALARM_INFO, '=');		-- première variable
      	Pos  := INSTR (:new.ALARM_INFO, '_', Pos);
      	Pos2 := INSTR (:new.ALARM_INFO, ';', Pos);
      	Str  := SUBSTR (:new.ALARM_INFO, Pos + 1, Pos2 - Pos - 1);

      	if (Str = 'ON') then
      	    Grave := 4;				-- début d'alarme
      	else
      	    Grave := 0;				-- Fin d'alarme
      	end if;

-- JPB	:new.ALARM_GRAVE := Grave;
    end if;

    Nb := 0;
    MaskAdm := false;

    if (:new.ALARM_CL = 'GSITE' or :new.ALARM_CL = 'SYST' or
	    (:new.ALARM_CL = 'IS' and :new.ALARM_TEXTE = 3)) then
      	for cx in CxionG loop
      	    Nb := Nb +1;
      	    select ALARM_ID into OldId 		from ACCES_ACCESC_REP
      		    where ACCES_ACCESC_ID = cx.ACCES_ACCESC_ID;
      				   -- Id de l'alarme en cours
      --	    OldId := cx.ALARM_ID;  -- Id de l'alarme en cours

      	    AccesAccescId := cx.ACCES_ACCESC_ID;

      	    if (cx.MSKADM_MAX > 0) then
      		      MaskAdm := IsMaskedAdm ('IS', 0, cx.ACCES_ACCESC_ID);
      	    end if;
      	    if (cx.SCRIPT_ID is not null) then
      		      ScriptId := cx.SCRIPT_ID;
      	    end if;
        end loop;

    elsif (:new.ALARM_CL = 'TRAPG' or :new.ALARM_CL = 'TRAPS') then
      	for cx in CxionTGS loop
      	    Nb := Nb +1;

      	    select ALARM_ID into OldId
      	     	from ACCES_ACCESC_REP
      		    where ACCES_ACCESC_ID = IsAccesId; -- Id de l'alarme en cours

      	    AccesAccescId 	:= cx.ACCES_ACCESC_ID;
      	    :new.ALARMGEREE_ID  := cx.ALARMGEREE_ID;

      	    if (ARetomber) then
      		    Grave 		:= 0;
      		    :new.ALARM_GRAVE := 0;
      	    else
      		    Grave		:= :new.ALARM_GRAVE;	-- Gravité calculée dans l'EM
      	    end if;

      	    EquipId	:= cx.ACCES_BINDINGID;

      	    if (cx.MSKADM_MAX > 0) then
      		      MaskAdm := IsMaskedAdm ('IS', 0, cx.ACCES_ACCESC_ID);
      	    end if;
      	    if (cx.SCRIPT_ID is not null) then
      		      ScriptId := cx.SCRIPT_ID;
      	    end if;
        end loop;

    else		-- Alarme GTR ou IP2PORT
    	for cx in CxionP loop
    	    Nb := Nb +1;
    	    select ALARM_ID into OldId	from ACCES_ACCESC_REP
    		      where ACCES_ACCESC_ID = cx.ACCES_ACCESC_ID;
    				   -- Id de l'alarme en cours
    --	    OldId := cx.ALARM_ID;  -- Id de l'alarme en cours

    	    if (cx.MSKADM_MAX > 0) then
    		      MaskAdm := IsMaskedAdm ('IS', 0, cx.ACCES_ACCESC_ID);
    	    end if;
    	    if (cx.SCRIPT_ID is not null) then
    		      ScriptId := cx.SCRIPT_ID;
    	    end if;
      end loop;
    end if;

    if (OldId is not NULL and :new.ALARM_GRAVE > 0) then
	insert into ERROR (ERROR_ID, ERROR_TYP, ERROR_LIBELLE)
	    values (SEQ_ERROR.NEXTVAL, 0,
		'Date ' || :new.ALARM_DATE ||' Alarme deja en cours sur cet acces ' ||
		To_Char (:new.ALARM_NUMOBJ) || '/' || :new.ALARM_NUMAL);
	:new.ALARMGEREE_ID := 0;
	AlarmeLocale   := 0;
  	:new.ALARM_COMMUT  := 0;
	SiteId	   := NULL;

/* JPB 300307
    	Signat := :new.ALARM_CL || ';' || to_char (:new.ALARM_NUMOBJ) || ';' || :new.ALARM_NUMAL || ';' || '%';
	delete BAGOT
	    where BAGOT_SIG like Signat;
Fin JPB */

	return;

    elsif (OldId is NULL and :new.ALARM_GRAVE = 0) then
	insert into ERROR (ERROR_ID, ERROR_TYP, ERROR_LIBELLE)
	    values (SEQ_ERROR.NEXTVAL, 0,
		'Date ' || :new.ALARM_DATE ||' Alarme non en cours sur cet acces ' ||
		 To_Char (:new.ALARM_NUMOBJ) || '/' || :new.ALARM_NUMAL);
	:new.ALARMGEREE_ID := 0;
	AlarmeLocale   := 0;
  	:new.ALARM_COMMUT  := 0;
	SiteId	   := NULL;

/* JPB 300307
    	Signat := :new.ALARM_CL || ';' || to_char (:new.ALARM_NUMOBJ) || ';' || :new.ALARM_NUMAL || ';' || '%';
	delete BAGOT
	    where BAGOT_SIG like Signat;
Fin JPB */

	return;
    end if;

    if (Nb = 0) then
	insert into ERROR (ERROR_ID, ERROR_TYP, ERROR_LIBELLE)
	    values (SEQ_ERROR.NEXTVAL, 0,
		'Date ' || :new.ALARM_DATE ||' Alarme non cablee ' ||
		To_Char (:new.ALARM_NUMOBJ) || '/' || :new.ALARM_NUMAL);
	:new.ALARMGEREE_ID := 0;
	AlarmeLocale   := 0;
  	:new.ALARM_COMMUT  := 0;
	SiteId	   := NULL;

/* JPB 300307
    	Signat := :new.ALARM_CL || ';' || to_char (:new.ALARM_NUMOBJ) || ';' || :new.ALARM_NUMAL || ';' || '%';
	delete BAGOT
	    where BAGOT_SIG like Signat;
Fin JPB */

	return;

    elsif (Nb > 1) then
	insert into ERROR (ERROR_ID, ERROR_TYP, ERROR_LIBELLE)
	    values (SEQ_ERROR.NEXTVAL, 0,
		'Date ' || :new.ALARM_DATE ||' Acces IS occupe plusieurs fois ' ||
		To_Char (:new.ALARM_NUMOBJ) || '/' || :new.ALARM_NUMAL);
	:new.ALARMGEREE_ID := 0;
	AlarmeLocale   := 0;
  	:new.ALARM_COMMUT  := 0;
	SiteId	   := NULL;

/* JPB 300307
    	Signat := :new.ALARM_CL || ';' || to_char (:new.ALARM_NUMOBJ) || ';' || :new.ALARM_NUMAL || ';' || '%';
	delete BAGOT
	    where BAGOT_SIG like Signat;
Fin JPB */

	return;
    end if;

    /* Recherche de OrigAccesId (Id de l'accès alarme sur l'élt. géré) */
    if (:new.ALARM_CL = 'IS_S') then		/* SEM */
      	select ACCES1_ID into OrigAccesId
      	    from ACCES_ACCESC
      	    where ACCES2_ID = IsAccesId and
      		  ACCES_ACCESC_PREBIT <= NumBit and
      		  ACCES_ACCESC_DERBIT >= NumBit;

      	:new.ALARM_COMMUT := 0;

    elsif ((:new.ALARM_CL = 'IS' or :new.ALARM_CL = 'IP2') and		/* GTR ou IP2PORT */
	    (:new.ALARM_TEXTE is null or :new.ALARM_TEXTE != 3)) then
        select A.ACCES1_ID, B.ALARMGEREE_GRAVE, A.ALARMGEREE_ID, A.COMMUT, A.ACCES_ACCESC_ID
	         into OrigAccesId, Grave, :new.ALARMGEREE_ID, :new.ALARM_COMMUT, AccesAccescId
   	       from ACCES_ACCESC A, ACCES_ACCESC_REP B
	          where A.ACCES2_ID = IsAccesId and  A.ACCES_ACCESC_ID = B.ACCES_ACCESC_ID;

    elsif (:new.ALARM_CL = 'TRAPG' or :new.ALARM_CL = 'TRAPS') then	/* TRAP SNMP Générique ou spécifique */
      	select TYPEQ_COMMUT, COMMUT_OID into typeq_commut, commutOID
      	from typeq, ACCES_ACCESC where ACCES_ACCESC_id = IsAccesId and ACCES_ACCESC.typeq_id=typeq.typeq_id;

              /* insert into ERROR (ERROR_ID, ERROR_TYP, ERROR_LIBELLE)
	      values (SEQ_ERROR.NEXTVAL, 0,
		    'IsAccesId = ' || To_Char (IsAccesId));*/

      	if (typeq_commut > 0 and INSTR (:new.ALARM_INFO, commutOID || ' ') > 0 ) then

      	    :new.ALARM_COMMUT := 1;

      	    Pos  := INSTR  (:new.ALARM_INFO, commutOID || ' ');
      	    if (Pos<0) then
      		      Pos  := INSTR  (:new.ALARM_INFO, commutOID || '=');
      	    end if;
      	    Pos2 := INSTR  (:new.ALARM_INFO, '=', Pos);
      	    Pos  := INSTR  (:new.ALARM_INFO, ';', Pos);

      	    if (Pos2<0 or Pos<0) then
      	 	       EquipState := 1;
      	    else
      		      Str  := SUBSTR (:new.ALARM_INFO, Pos2+1, Pos - Pos2 -1);
      		      EquipState := TO_NUMBER(Str);
      	    end if;

	          if(EquipState<=0) then
        	       EquipState :=1;
            end if;

	         update equip_rep set equip_commut = EquipState where equip_id = EquipId;

	     else /*ce n'est pas le trape de commutation*/
	          :new.ALARM_COMMUT := 0;
	     end if;

    	OrigAccesId := 0;

    	AlarmeLocale   := 1;
    	:new.ALARM_INFO	   := 'Trap SNMP : ' || :new.ALARM_INFO;

        -- La gravité est choisie par l'opérateur demande GG + C GAVOILLE
    	select ALARMGEREE_GRAVE into Grave
    	     from ACCES_ACCESC_REP
    	     where ACCES_ACCESC_ID = IsAccesId;

    elsif (:new.ALARM_CL = 'GSITE') then	/* GSITE */
    	OrigAccesId := 0;
    	Grave := :new.ALARM_GRAVE;
    	:new.ALARMGEREE_ID := 1;
    	:new.ALARM_COMMUT  := 0;
    	Info := :new.ALARM_INFO;
    	:new.ALARM_INFO	   := 'Alarme GSITE :' || Info;
    else			/* Alarme système */
      	OrigAccesId := 0;
      	Grave := :new.ALARM_GRAVE;
      	:new.ALARMGEREE_ID := 1;
      	:new.ALARM_COMMUT  := 0;
      	Info := :new.ALARM_INFO;
      	:new.ALARM_INFO	   := 'Alarme systeme :' || Info;

    end if;	/* recherche de l'Id de l'accès sur l'élément géré (équip. par exemple) */

 --   insert into test values (seq_test.nextval, 'tib_alarm1 :new.ALARM_Grave = '|| :new.ALARM_Grave);

    if (ModCalc=1 and :new.ALARM_CL = 'TRAPS') then --NEC, pour les traps on prend la gravité dans le trap
      Grave := :new.ALARM_GRAVE;		   --pour les accès boucle, on prend la gravité de l'alarme gérée.
    end if;

    /* Recherche de l'élément géré en défaut */
    if (:new.ALARM_CL = 'GSITE' or :new.ALARM_CL = 'SYST' or :new.ALARM_CL = 'TRAP' or
	(:new.ALARM_CL = 'IS' and :new.ALARM_TEXTE = 3)) then
	EquipId := IsAccesId;
	SiteId := NULL;
	LiaiId := NULL;

    elsif (:new.ALARM_CL = 'TRAPG' or :new.ALARM_CL = 'TRAPS') then
	/* EQUIP_ID est déjà rempli */
	SiteId := NULL;
	LiaiId := NULL;

    else
    	select SITE_ID, EQUIP_ID, LIAI_ID
	    into SiteId, EquipId, LiaiId
 	    from ACCES
	    where ACCES_ID = OrigAccesId;	/* recherche de l'élément géré en défaut */
    end if;

    /*déjà fait pour les TRAPS*/
    if (:new.ALARM_COMMUT > 0 and :new.ALARM_CL <> 'TRAPG' and :new.ALARM_CL <> 'TRAPS') then
        if(:new.ALARM_GRAVE=0) then
            EquipState :=1;
     	else
	    EquipState := Grave - DecalGrave +2;
	end if;
	update equip_rep set equip_commut = EquipState where equip_id = EquipId;
    end if;

    :new.EVENEMENT_TYPE := 0;           -- Fin d'alarme
    if (:new.ALARM_GRAVE > 0) then	/* Début d'alarme */
        :new.EVENEMENT_TYPE := 1;
        :new.ALARM_GRAVE := Grave;
      	if (:new.ALARM_COMMUT = 0) then
      	    select ALARMGEREE_NOM, ALARMGEREE_TYPAL, ALARMGEREE_LOCAL, ALARMGEREE_NSEUIL,
  	       ALARMGEREE_SEUILOID, ALARMGEREE_COMMENT
                  into AlarmgereeNom, AlarmgereeTypAl, AlarmeLocale, AlarmgereeNSeuil,
                        AlarmgereeSeuilOid, AlarmeComment
      	        from ALARMGEREE
  	        where ALARMGEREE_ID = :new.ALARMGEREE_ID;
                
                if (RTRIM(AlarmgereeSeuilOid) is not null) then -- alarme de seuil
                    if (not ExtractValeurSeuil (:new.alarm_info, AlarmeVSeuil)) then
                        raise_application_error (-20000, 'Threshold message format not compliant');
                    end if;
                end if;
        else
            AlarmeLocale := 1;
        end if;

            -- Alarme GTR ou GSITE ou Alarme Système ou TRAP
      	    update ACCES_ACCESC_REP
      	        set 	ALARM_ID   = :new.ALARM_ID,
      			ALARM_SEC  = AlarmSec,
      			SITE_ID	   = SiteId,
      			EQUIP_ID   = EquipId,
      			LIAI_ID    = LiaiId,
      			ALARM_CL   = :new.ALARM_CL,
      			ALARM_NUMOBJ=:new.ALARM_NUMOBJ,
      			ALARM_NUMAL= :new.ALARM_NUMAL
      		where 	ACCES_ACCESC_ID = AccesAccescId;

      	if (ScriptId != 0) then
      	    insert into ACTIVATION (ACTIVATION_ID, ACTIVATION_TIME, ACTIVATION_PERIOD,
      				SCRIPT_ID, SCRIPT_PARAM) values
      		(SEQ_ACTIVATION.NEXTVAL, AlarmeSecDebut, 0, ScriptId, 1);
      	end if;

        AlarmIdDeb := NULL;

    else				/* Fin d'alarme */
            -- Alarme GTR ou GSITE ou Alarme Système ou TRAP
      	    if (AlarmIdDeb is NULL) then
            	    	select ALARM_ID, ALARM_SEC into AlarmIdDeb, AlarmeSecDebut
         	 	    from ACCES_ACCESC_REP
      		    where ACCES_ACCESC_ID = AccesAccescId; 	/* Id du début d'alarme correspondant */
      	    end if;

      	    update ACCES_ACCESC_REP
        		set 	ALARM_ID   = NULL,
        			ALARMDATA_ID = NULL,
        			ALARM_SEC  = NULL,
        			SITE_ID	   = NULL,
        			EQUIP_ID   = NULL,
        			LIAI_ID    = NULL,
        			ALARM_CL   = NULL,
        			ALARM_NUMOBJ=NULL,
        			ALARM_NUMAL= NULL
  		            where 	ACCES_ACCESC_ID = AccesAccescId;

	   --    end if;

    	if (:new.ALARM_COMMUT = 0) then
    	    select ALARMGEREE_LOCAL, ALARMGEREE_NOM, ALARMGEREE_TYPAL
                into AlarmeLocale, AlarmgereeNom, AlarmegereeTypAl
    	        from ALARMGEREE
	        where ALARMGEREE_ID = :new.ALARMGEREE_ID;
	else
	    AlarmeLocale := 1;
        end if;

	if (ScriptId != 0) then
	    insert into ACTIVATION (ACTIVATION_ID, ACTIVATION_TIME, ACTIVATION_PERIOD,
				SCRIPT_ID, SCRIPT_PARAM) values
		(SEQ_ACTIVATION.NEXTVAL, AlarmSec, 0, ScriptId, 0);
	end if;

/* JPB 300307
	update BAGOT
	    set ALARM_IDDEB   = :new.ALARM_IDDEB
	    where BAGOT_ID    = BagotId;-- Fin d'alarme normale
Fin JPB */

    end if;

    if (AlarmIdDeb is not NULL and (AlarmeSecDebut is NULL or AlarmeId is null)) then
	select ALARMDATA_SECDEBUT, ALARM.ALARMDATA_ID into AlarmeSecDebut, AlarmeId
   	    from ALARM, ALARMDATA
	    where ALARM_ID = AlarmIdDeb and ALARMDATA.ALARMDATA_ID = ALARM.ALARMDATA_ID;
    end if;

    if (MaskAdm) then
	:new.ALARMGEREE_ID := 0;
--	:new.ALARM_LOCAL   := 0;
  	:new.ALARM_COMMUT  := 0;
	SiteId	   := NULL;
    end if;

    AlarmeAck     := 0;     -- alarme non encore acquittée
    AlarmeAckWho  := NULL;
    AlarmeAckWhen := NULL;
    
    if (AlarmIdDeb is null) then
        select seq_alarmdata.NEXTVAL into AlarmeId from dual;
    end if;
    :new.ALARMDATA_ID := AlarmeId;
    :new.ALARM_IDDEB := AlarmIdDeb;
    
    insert into ALARM_TEMP (ALARM_ID, ALARMGEREE_ID, ALARM_IDDEB, ALARM_NUM, ALARM_CL, ALARM_NUMOBJ,
                            ALARM_NUMAL, ALARM_DATE, ALARM_HINSERT, ALARM_GRAVE, 
                            ALARM_COMMUT, ALARM_TEXTE, ALARM_INFO, ALARM_COMMENT, 
                            ALARM_TYPMAJ, ALARM_NBRSEQ, ALARMDATA_ID, ALARM_SEC, EVENEMENT_TYPE)
    values (:new.ALARM_ID, :new.ALARMGEREE_ID, :new.ALARM_IDDEB, :new.ALARM_NUM, :new.ALARM_CL, :new.ALARM_NUMOBJ,
                            :new.ALARM_NUMAL, :new.ALARM_DATE, :new.ALARM_HINSERT, :new.ALARM_GRAVE, 
                            :new.ALARM_COMMUT, :new.ALARM_TEXTE, :new.ALARM_INFO, :new.ALARM_COMMENT, 
                            :new.ALARM_TYPMAJ, :new.ALARM_NBRSEQ, AlarmeId, AlarmSec, :new.EVENEMENT_TYPE);
                            
    if (AlarmIdDeb is null) then    -- Début d'alarme
        insert into ALARMDATA (ALARMDATA_ID, ALARMDATA_SECDEBUT, SITE_ID, EQUIP_ID, LIAI_ID, ALARMDATA_IANA,
                            ALARMGEREE_LOCAL, ACCES_ACCESC_ID, ALARMDATA_VSEUIL, ALARMGEREE_NSEUIL,
                            ALARMGEREE_NOM, ALARMGEREE_TYPAL, ALARMGEREE_GRAVE,
                            ALARMDATA_COMMENT, ALARMDATA_ACK, ALARMDATA_ACKWHO, ALARMDATA_ACKWHEN)
                    values (AlarmeId, AlarmSec, SiteId, EquipId, LiaiId, NumeroIana,
                            AlarmeLocale, AccesAccescId, AlarmeVSeuil, AlarmgereeNSeuil,
                            AlarmgereeNom, AlarmgereeTypAl, Grave,
                            AlarmeComment, AlarmeAck, AlarmeAckWho, AlarmeAckWhen);
        update ACCES_ACCESC_REP set ALARMDATA_ID = AlarmeId where ACCES_ACCESC_ID = AccesAccescId;
    else                            -- Fin d'alarme, mettre à jour l'enregistrement ALARME existant
        update ALARMDATA set ALARMDATA_SECFIN = AlarmSec,
                          ALARMDATA_DATEFIN = AlarmDate
        where ALARMDATA_ID = AlarmeId;
    end if;

end tib_alarm;
