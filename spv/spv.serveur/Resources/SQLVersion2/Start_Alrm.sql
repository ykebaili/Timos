create or replace
PROCEDURE Start_Alrm (Id NUMBER, AlGereeId NUMBER, SiteId NUMBER,
    EquipId NUMBER, LiaiId NUMBER, AlarmNum NUMBER, AlarmCl VARCHAR2, AlarmNumObj NUMBER,
    AlarmType NUMBER, AlarmDate VARCHAR2, AlarmGrave NUMBER, AlarmNseuil VARCHAR2,
    AlarmVseuil	NUMBER, AlarmNumal VARCHAR2, AlarmTexte NUMBER, AlarmInfo VARCHAR2,
    AlarmNomL VARCHAR2, AlarmComment VARCHAR2, AlarmLocal NUMBER, AlarmCommut NUMBER,
    AlarmIddeb NUMBER, CablSId NUMBER, CablPId NUMBER, Acquittee NUMBER, Iana NUMBER,
    TsPrOper IN OUT NOCOPY VARCHAR2, Debord IN OUT NUMBER)

IS
    Mess   VARCHAR2 (1800);  /* taille max des messages Oracle */

    ProgNb	NUMBER;	     /* Nb. de programmes concernés par l'alarme */
    ProgId	PROG.PROG_ID%TYPE;
    ClientId	CLIENT.CLIENT_ID%TYPE;
    ProgOper 	NUMBER;	     /* Etat opérationnel du programme concerné. 0 si plusieurs */

	EltSiteId	NUMBER;		/* ID du site de l'élément en défaut */
    EltSiteNom     VARCHAR2 (40);  /* nom du site contenant l'élt. en défaut. ' ' pour une liaison
				inter-site */
	EltTypeId   NUMBER;  /* ID du type de l'équipement ou de la liaison ou du site */
    EltTypeNom   VARCHAR2 (40);  /* nom du type de l'équipement ou de la liaison ou du site */

	EltId    NUMBER;  /* ID de l'équipement ou nom de la liaison ou du site
						 en défaut */
    EltNom    VARCHAR2 (80);  /* Position de l'équipement ou nom de la liaison ou du site
								 en défaut */
    FEltG    VARCHAR2 (4000);/* Consigne de l'élément géré en défaut */
    FAlG     VARCHAR2 (4000);/* Consigne de l'alarme gérée */

    Al2Fait	 BOOLEAN;    /* Si des alarmes masquées BRI surviennent, ALRM2 sera écrit.
				Au moment du démasquage d'une alarme en cours, il ne faut pas
				l'écrire à nouveau, sinon erreur PK_ALARM2 */
    Al3Fait	 BOOLEAN;    /* Si des alarmes masquées BRI surviennent, ALRM3 sera écrit.
				Au moment du démasquage d'une alarme en cours, il ne faut pas
				l'écrire à nouveau, sinon erreur PK_ALARM3 */

    CliConc  VARCHAR2 (1000);/* nom des clients concernés par l'alarme */
    PrConc   VARCHAR2 (1000);/* nom des programmes concernés */
    PrEtat   VARCHAR2 (100); /* état des programmes concernés */
    SStr     VARCHAR2 (900); /* sous- string de TsPrOper */
    SPrId    VARCHAR2 (10);  /* Id du programme */
    SPos     NUMBER;	     /* position dans ce sous-string */

    Sonne    NUMBER;	     /* 1 s'il faut sonner pour cette alarme, 0 sinon */
    Acquit   NUMBER;	     /* 1 s'il faut acquitter cette alarme, 0 sinon */

    stBindingVarInfo VARCHAR2 (2000);

    CURSOR cAl2 IS
		select * from ALARM2
			where ALARM2_ID = Id;

    CURSOR cAl3 IS
		select * from ALARM3
			where ALARM3_ID = Id;

    CURSOR cProg IS
        select A.PROG_ID, B.PROG_OPER, CLIENT.CLIENT_ID
            from PROG A, PROG_REP B, CLIENT
	    	where A.PROG_ID = SPrId and
		      A.CLIENT_ID = CLIENT.CLIENT_ID and
		      A.PROG_ID = B.PROG_ID;
BEGIN

    if (not IsMaskedAdm (AlarmCl, CablSId, CablPId)) then

--        insert into test values (SEQ_TEST.NEXTVAL, 'Start_Alrm: SiteId = '||SiteId ||
 --     ' EquipId = '|| EquipId || ' LiaiId = ' || LiaiId);

    	maj_oper (Id, SiteId, EquipId, LiaiId, AlarmLocal, AlarmGrave, AlarmCommut, ProgNb, 
    			  EltSiteId, EltSiteNom, EltTypeId, EltTypeNom, EltId, EltNom, 
    			  TsPrOper, Debord);

--		insert into test values (SEQ_TEST.NEXTVAL, 'Start_Alrm: TsPrOper = '||TsPrOper);
	Al2Fait := FALSE;
	for vAl2 in cAl2 loop
		Al2Fait := TRUE;
	end loop;

	if (NOT Al2Fait and Debord = 0) then
	    insert into ALARM2 (ALARM2_ID, ALARM2_TSPROPER) values (Id, TsPrOper);
	elsif (NOT Al2Fait and Debord = 1) then
	    SStr := TsPrOper || 'Debordement';
	    insert into ALARM2 (ALARM2_ID, ALARM2_TSPROPER) values (Id, SStr);
	end if;

    	CliConc := ';';
    	PrConc  := ';';
    	PrEtat  := ';';
    	SStr    := TsPrOper;
	SPos    := INSTR (SStr, ';') +1;

	while (SPos < LENGTH (SStr)) loop
	    SStr    := SUBSTR (SStr, SPos);
	    SPos    := INSTR (SStr, ';') +1;
	end loop;

    	while (LENGTH (SStr) > 0) loop
	    SPos  := INSTR  (SStr, ',') -1;
	    SPrId := SUBSTR (SStr, 1, SPos);
/*
	    select PROG_NOM, B.PROG_OPER, CLIENT_NOM into ProgNom, ProgOper, ClientNom
	    	from PROG A, PROG_REP B, CLIENT
	    	where A.PROG_ID = SPrId and
		      A.CLIENT_ID = CLIENT.CLIENT_ID and
		      A.PROG_ID = B.PROG_ID;
*/
            FOR rCProg IN CProg LOOP
				ClientId := rCProg.CLIENT_ID;
                ProgId := rCProg.PROG_ID;
                ProgOper := rCProg.PROG_OPER;
                CliConc  := CliConc || ClientId || ';';
                PrConc   := PrConc  || ProgId   || ';';
                PrEtat   := PrEtat  || ProgOper  || ';';
                EXIT;
            END LOOP;

	    if (length (PrEtat) > 80) then		-- vs 85
	    	PrEtat := PrEtat || 'Debordement;';
	    	exit;
	    end if;
	    if (length (PrConc) > 990) then		-- vs 1000
	    	PrConc := PrConc || 'Debordement;';
	    	exit;
	    end if;
	    if (length (CliConc) > 990) then		-- vs 1000
	    	CliConc := CliConc || 'Debordement;';
	    	exit;
	    end if;

	    SPos  := INSTR  (SStr, ';') +1;
	    SStr  := SUBSTR (SStr, SPos);
    	end loop;

	Al3Fait := FALSE;
	for vAl3 in cAl3 loop
		Al3Fait := TRUE;
	end loop;

    /*	if (SiteId is not null) then
	    FEltG := GetDataFiche ('SITE', SiteId, 'SITE', SiteId);
    	elsif (EquipId is not null) then
	    select TYPEQ_ID into TypeqId
	    	from TYPEQ
	    	where TYPEQ_NOM = Typequ;
	    FEltG := GetDataFiche ('TYPEQ', TypeqId, 'EQUIP', EquipId);
    	elsif (LiaiId is not null) then
	    select TYPLIAI_ID into TypeqId
	    	from TYPLIAI
	    	where TYPLIAI_NOM = Typequ;
	    FEltG := GetDataFiche ('TYPLIAI', TypeqId, 'LIAI', LiaiId);
    	end if;

    	FAlG := GetDataFiche ('ALARMGEREE', AlGereeId, 'ALARMGEREE', AlGereeId);*/

	if (NOT Al3Fait) then
  		insert into ALARM3 (ALARM3_ID, ALARM3_CLICONC, ALARM3_PRCONC, ALARM3_PRETAT,
				ALARM3_ELTSITEID, ALARM3_ELTTYPEID, ALARM3_ELTID,
			        ALARM3_FELTG, ALARM3_FALG, ALARM3_ELTCLASSE)
		    values (Id, CliConc, PrConc, PrEtat, EltSiteId, EltTypeId, EltId, FEltG, FAlG,
					GetClasseObjetEnDefaut (EquipId, LiaiId, SiteId));
	end if;

 	if (not IsMaskedBri (AlarmCl, CablSId, CablPId)) then
	    if (CablPId > 0) then
	    	select ALARMGEREE_SON, ALARMGEREE_ACQ into Sonne, Acquit
		    from ACCES_ACCESC
		    where ACCES_ACCESC_ID = CablPId;
	  /*  elsif (CablSId > 0) then
	    	select ALARMGEREE_SON, ALARMGEREE_ACQ into Sonne, Acquit
		    from BITMESS
		    where BITMESS_ID = CablSId;*/
	    else
		Sonne  := 0;
		Acquit := 0;
	    end if;

	    if AlarmGrave = 0 OR IsToAff (AlarmCl, CablSId, CablPId) then
		-- Pour une fin d'alarme, on envoie toujours le message afin de ne pas risquer
		-- de voir des alarmes rester affichées à la console.

		/*traitement de binding variables des traps*/
    		stBindingVarInfo := '';
    		if (AlarmCl = 'TRAPG' or AlarmCl = 'TRAPS' ) then
		    stBindingVarInfo := BindingVarInfo (AlarmInfo, EquipId, Iana, AlarmNumObj);
    		end if;

		mess_alrm  (Mess, Id, AlarmIddeb, AlGereeId,
			    SiteId, EquipId, LiaiId,
 			    AlarmNum, AlarmCl, AlarmNumObj, AlarmType,
			    AlarmDate, AlarmGrave, AlarmNseuil, AlarmVseuil,
	               	    AlarmNumal, AlarmTexte, AlarmInfo, AlarmNomL,
			    AlarmComment, AlarmCommut, PrConc, CliConc, to_char (ProgOper),
			    EltSiteNom, EltTypeNom, EltNom, TsPrOper, FEltG, FAlG, Sonne, Acquit, Acquittee, stBindingVarInfo);

	    end if; /* l'alarme gérée est à afficher sur les consoles */
	end if; /* l'alarme n'est pas masquée par le Brigadier */
    end if;	/* l'alarme n'est pas masquée par l'Administrateur */

END	Start_Alrm;
