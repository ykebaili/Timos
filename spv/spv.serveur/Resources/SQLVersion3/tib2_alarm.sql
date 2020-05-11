create or replace
FUNCTION tib2_alarm
      	(AlarmId NUMBER, AlarmDate VARCHAR2,
	AlarmCl VARCHAR2, AlarmTxt NUMBER, AlarmNumal VARCHAR2, AlarmNumobj NUMBER,
	AlarmComment VARCHAR2, AlarmInfo VARCHAR2, MessId IN OUT NUMBER, IsAccesId IN OUT NUMBER,
	NumBit IN OUT NUMBER)
RETURN BOOLEAN
IS

    Nb	integer;	/* nombre banal */
    Id1 NUMBER;		/* sous-adresse */
    Id2 NUMBER;		/* sous-adresse */
    Str	varchar2 (40);  /* banal */
    Str2 varchar2 (1000); /* banal */
/* Appelé au début de tib_alarm, afin de diminuer la taille de ce trigger.
   Trouve IsAccesId : Id de l'accès sur l'IS */

    Ident  VARCHAR2 (256);  /* identité d'une alarme TRAP :
			OID enterprise;Generic Trap;Specific trap; */
    Cable  boolean;	/* true si le câblage existe, false sinon */
    Messg  boolean;	/* true si le message existe, false sinon */
    NumCarte NUMBER;	/* n° carte de l'IS : 1 à 8 pour les GTR et 1 à 6 pour les SEM */
    NbAcc    NUMBER;	/* nb. max. d'accès par carte SEM (8 en principe) */
    EquipRef EQUIP.SITE_EQUIP_COMMENT%TYPE;
			/* IS xx/GTR yy ou IS xx/SEM yy   xx : n° IS, yy : n° accès
			    ou IS xx	pour les alarmes systèmes de l'IS
			    IP2PORTx où x désigne le numéro de l'IP2PORT en question
			    ou le nom de l'équipement IDU ou MIU NEC */
    Pos		NUMBER;	/* position du séparateur dans la chaîne à analyser */
    Pos2	NUMBER; /* position d'un autre élément dans la chaîne à analyser */
    NomAcc      ACCES.ACCES_NOM%TYPE;

    cursor Cab is
    	select ACCES_ID
	    from EQUIP, ACCES
	    where SITE_EQUIP_COMMENT = EquipRef and
		  ACCES_TYPE = 7 and
		  ACCES_NOM = NomAcc and
		  EQUIP.EQUIP_ID = ACCES.EQUIP_ID;

    cursor CMess is
        select MESS_ID
	    from ACCES_ACCESC
	    where ACCES2_ID = IsAccesId;

    cursor CGsite is
	select EQUIP_ID
	    from EQUIP
	    where SITE_EQUIP_COMMENT = AlarmNumal;

    cursor CTrap (Id NUMBER, Ident VARCHAR2) is
	select ACCES_ACCESC_ID
	    from ACCES_ACCESC, ACCES
	    where ACCES_BINDINGID = Id and
		  ACCES_IDENT  = Ident and
		  ACCES_ACCESC.ACCES1_ID = ACCES.ACCES_ID;

    cursor CSystem is
	select EQUIP_ID
	    from EQUIP
	    where SITE_EQUIP_COMMENT = EquipRef and
		  TYPEQ_ID in (1, 2, 3, 4, 5);

BEGIN
    Cable := FALSE;
    Messg := FALSE;
    NbAcc := 8;

    if (AlarmCl = 'GSITE' or AlarmCl = 'SYST') then /* GSITE ou alarmes SYSTème */
	for vGs in CGsite loop
	    IsAccesId := vGs.EQUIP_ID;  /* dans ce cas, IsAccesId correspond à l'Id de
					"l'équipement" GSITE ou "SYSTème" */
	    Cable := TRUE;
	    exit;
	end loop;

	if (NOT Cable) then
	    Str2 := 'AlarmId '||to_char (AlarmId) ||
	   	    ' Date ' || AlarmDate ||' Non cablee ' || To_Char (AlarmNumobj) || '/' ||
		     AlarmNumal || '/' || AlarmInfo;
	    Str2 := substr (Str2, 0, 255);
	    insert into ERROR (ERROR_ID, ERROR_TYP, ERROR_LIBELLE)
		values (SEQ_ERROR.NEXTVAL, 0, Str2);
	    return FALSE;
	end if;

	return TRUE;
    end if;

    if (AlarmCl = 'TRAPG') then		/* Trap générique SNMP */
	Ident := AlarmComment || ';' || to_char (AlarmNumobj) || ';0;' ;
    end if;

    if (AlarmCl = 'TRAPS') then		/* Trap spécifique SNMP */
	Ident := AlarmComment || ';6;' || to_char (AlarmNumobj) || ';' ;
    end if;		-- Exemple : 2258;6;103;
SetTrace('Ident ' || Ident);
    if (AlarmCl = 'TRAPG' or AlarmCl = 'TRAPS') then
	Id1 := GetStr (AlarmInfo, 0, ';');	-- EquipId du NE en défaut
--	insert into test values (SEQ_TEST.NEXTVAL, 'Info '|| AlarmInfo);
--	insert into test values (SEQ_TEST.NEXTVAL, 'ID1 '||Id1||' Ident '||Ident);
SetTrace ('Id1 ' || Id1);
	for vTr in CTrap (Id1, Ident) loop
	    IsAccesId := vTr.ACCES_ACCESC_ID;
--	    insert into test values (SEQ_TEST.NEXTVAL, 'IsAccesId '||IsAccesId);
	    Cable := TRUE;
	    exit;
	end loop;
if Cable = TRUE THEN SetTrace('Cable '); ELSE SetTrace ('Non cable'); END IF;
	if (NOT Cable) then
	    Str2 := 'AlarmId '||to_char (AlarmId) ||
	   	    ' Date ' || AlarmDate ||' Trap Non cable ' || '/' || AlarmNumal
		    ||' EquipId ' || Id1 || ' / ' || AlarmInfo;
	    Str2 := substr (Str2, 0, 255);
	    insert into ERROR (ERROR_ID, ERROR_TYP, ERROR_LIBELLE)
		values (SEQ_ERROR.NEXTVAL, 0, Str2);
	    return FALSE;
	end if;

	return TRUE;
    end if;		/* Trap G ou S */

    if (AlarmCl = 'IS' and AlarmTxt = 3) then	/* Alarme système sur une IS */
	EquipRef := 'IS ' || lpad (To_Char (AlarmNumobj), 2);
	for vGy in CSystem loop
	    IsAccesId := vGy.EQUIP_ID;  /* dans ce cas, IsAccesId correspond à l'Id de
					"l'équipement" IS */
	    Cable := TRUE;
	    exit;
	end loop;

	if (NOT Cable) then
	    Str2 := 'AlarmId '||to_char (AlarmId) ||
	   	    ' Date ' || AlarmDate ||' Al. systeme Non cablee ' || To_Char (AlarmNumobj)
		    || '/' || AlarmNumal || ' / ' || AlarmInfo;
	    Str2 := substr (Str2, 0, 255);
	    insert into ERROR (ERROR_ID, ERROR_TYP, ERROR_LIBELLE)
		values (SEQ_ERROR.NEXTVAL, 0, Str2);
	    return FALSE;
	end if;

	return TRUE;
    end if;

    if (AlarmCl = 'IS_S') then		/* Alarme série */
    	Nb   := FLOOR (TO_NUMBER (AlarmNumal) / 10000);
	NumCarte := FLOOR (Nb / NbAcc) +1;
	NomAcc	 := TO_CHAR(MOD (Nb, NbAcc) +1);
	NumBit	 := MOD (TO_NUMBER (AlarmNumal), 10000);

	EquipRef := 'IS ' || lpad (To_Char (AlarmNumobj), 2) || '/SEM ' ||
		     lpad (To_Char (NumCarte), 2);

	for vCab in Cab loop
	    IsAccesId := vCab.ACCES_ID;
	    Cable  := TRUE;
	    exit;
	end loop;

	if (NOT Cable) then
	    Str2 := 'AlarmId '||to_char (AlarmId) ||
	   	    ' Date ' || AlarmDate ||' Non cablee ' || To_Char (AlarmNumobj)
		    || '/' || AlarmNumal || ' / ' || AlarmInfo;
	    Str2 := substr (Str2, 0, 255);
	    insert into ERROR (ERROR_ID, ERROR_TYP, ERROR_LIBELLE)
		values (SEQ_ERROR.NEXTVAL, 0, Str2);
	    return FALSE;
	end if;

	for vMess in CMess loop
	    MessId := vMess.MESS_ID;
	    Messg  := TRUE;
	    exit;
	end loop;

	if (NOT Messg) then
	    Str2 := 'AlarmId '||to_char (AlarmId) ||
	   	    ' Date ' || AlarmDate ||' Message inexistant acces ' || to_char (IsAccesId)
		    || ' / ' || AlarmInfo;
	    Str2 := substr (Str2, 0, 255);
	    insert into ERROR (ERROR_ID, ERROR_TYP, ERROR_LIBELLE)
		values (SEQ_ERROR.NEXTVAL, 0, Str2);
	    return FALSE;
	end if;

    else				/* Alarme IS GTR ou DOMO  ou IP2PORT */

	if (AlarmCl = 'IS') then
	    NumCarte := FLOOR ((TO_NUMBER (AlarmNumal) -1) / 48 +1);
	    NomAcc	 := TO_CHAR(MOD (TO_NUMBER (AlarmNumal) -1, 48) +1);
	    EquipRef := 'IS ' || lpad (To_Char (AlarmNumobj), 2) || '/GTR ' ||
		         lpad (To_Char (NumCarte), 2);
	else				/* IP2PORT */
	    /* Recherche de l'équipement IP2PORT ou NEC (IDU/MIU) ou IP2CHOICE ayant émis l'alarme */
	    Id1 := GetStr (AlarmInfo, 0, ';');	-- EquipId du NE en défaut

	    select SITE_EQUIP_COMMENT into EquipRef
		from EQUIP
		WHERE EQUIP_ID = Id1;

	    /* Recherche de l'accès de l'IP2PORT ayant provoqué l'alarme.
		Cet accès est la première des variables du Trap.
		Cette première variable se présente sous la forme Event_code = DIGn_ON ou
		Event_code = DIGn_OFF où n est le numéro de l'entrée alarme sur l'IP2PORT */
	    Pos := INSTR (AlarmInfo, '=');		-- première variable
	    Pos := INSTR (AlarmInfo, 'DIG', Pos);
	    Pos2 := INSTR (AlarmInfo, '_', Pos);
	    NomAcc := SUBSTR (AlarmInfo, Pos + 3, Pos2 - Pos - 3);

	end if;

	for vCab in Cab loop
	    IsAccesId := vCab.ACCES_ID;
	    Cable  := TRUE;
	    exit;
	end loop;

	if (NOT Cable) then
	    Str2 := 'AlarmId '||to_char (AlarmId) ||
	   	    ' Date ' || AlarmDate ||' Non cablee ' || To_Char (AlarmNumobj)
		    || '/' || AlarmNumal || ' / ' || AlarmInfo;
	    Str2 := substr (Str2, 0, 255);
	    insert into ERROR (ERROR_ID, ERROR_TYP, ERROR_LIBELLE)
		values (SEQ_ERROR.NEXTVAL, 0, Str2);
	    return FALSE;
	end if;
   end if;

   return TRUE;

EXCEPTION
    WHEN OTHERS THEN
	insert into ERROR (ERROR_ID, ERROR_TYP, ERROR_LIBELLE)
		values (SEQ_ERROR.NEXTVAL, 0, 'Erreur dans TIB2_ALARM');
	return FALSE;

END  tib2_alarm;
