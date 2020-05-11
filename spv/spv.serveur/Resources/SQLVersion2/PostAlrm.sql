create or replace
PROCEDURE PostAlrm (IdEvt NUMBER, IdAlarmData NUMBER, AlGereeId NUMBER, SiteId NUMBER, EquipId NUMBER,
    LiaiId NUMBER, AlarmNum NUMBER, AlarmCl VARCHAR2, AlarmNumObj NUMBER, 
    AlarmType NUMBER, AlarmDate VARCHAR2, AlarmGrave NUMBER, AlarmNseuil VARCHAR2,
    AlarmVseuil	NUMBER, AlarmNumal VARCHAR2, AlarmTexte NUMBER, AlarmInfo VARCHAR2,
    AlarmNomL VARCHAR2, AlarmComment VARCHAR2, AlarmLocal NUMBER, AlarmCommut NUMBER,
    AlarmIddeb NUMBER, CablSId NUMBER, CablPId NUMBER, Sonne NUMBER, Acquit NUMBER,
    Acquittee NUMBER, Iana NUMBER, ClasseObjetEnDefaut NUMBER) 
IS
	-- Id est l'identifiant du nouveau message d'alarme (d�but ou fin).
    Mess     VARCHAR2 (1800);/* taille max. du message autoris� par Oracle : 1800 octets */
    ProgNb	NUMBER;	     /* Nb. de programmes concern�s par l'alarme */
    ProgId	PROG.PROG_ID%TYPE;
    ProgOper	NUMBER;	     /* Etat op�rationnel du programme concern� par cette alarme.
				0 si plusieurs programmes concern�s */
    ClientId	CLIENT.CLIENT_ID%TYPE;
    EltSiteId   NUMBER;  /* ID du site contenant l'�lt. en d�faut. */
	EltSiteNom  VARCHAR2(40);	/* Nom du site de l'�l�ment en d�faut; ' ' pour une liaison
									inter-sites */
    EltTypeId  NUMBER;	     /* Id du type d'�quipement ou de liaison */
    EltTypeNom   VARCHAR2 (40);  /* nom du type de l'�quipement ou de la liaison. 'SITE' 
				pour une alarme	de site */
    EltId    NUMBER;  /* ID de l'�quipement ou de la liaison ou du site 
				en d�faut */
	EltNom	VARCHAR2(80);	/* Nom de l'�quipement ou de la liaison ou du site en d�faut */ 
    TsPrOper VARCHAR2 (900); /* Cha�ne donnant l'�tat op�rationnel des prog. concern�s par 
				cette alarme. 70 prog. au max.
				Structure : NbProg; ProgId, OldProgOper, ProgOper, ProgMsk; 
				ProgId,  etc... */
    Debord   NUMBER;	     /* 1 si d�bordement de la cha�ne TsPrOper, 0 sinon */

    CliConc  VARCHAR2 (1000);/* nom des clients concern�s par l'alarme */
    PrConc   VARCHAR2 (1000);/* nom des programmes concern�s */
    PrEtat   VARCHAR2 (100); /* �tat des programmes concern�s */
    SStr     VARCHAR2 (900); /* sous- string de TsPrOper */
    SPrId    VARCHAR2 (50);  /* Id du programme */
    SPos     NUMBER;	     /* position dans ce sous-string */
    FEltG    VARCHAR2 (4000);/* fiche �ventuelle de cet �quipement */    
    FAlG     VARCHAR2 (4000);/* fiche �ventuelle de l'alarme de cet �quipement */  
    stBindingVarInfo VARCHAR2 (2000);/* pour les TRAP */
			     /*<nom de var.visible1> = <valeur de var.visible1>;<nom de var.visible2> = <valeur de var.visible2>;... */ 
			     
	progActif     NUMBER;
	TsPrOperTmp   VARCHAR2 (900);
	TsPrOperPos   NUMBER;

BEGIN
    Debord  := 0;

    if (AlarmCommut = 0) then
	     if not correl_alrm (Mess, IdEvt, IdAlarmData, SiteId, EquipId, LiaiId, CO_SEC1998 (AlarmDate), AlarmGrave, AlarmIddeb, TsPrOper, Debord) then
				/* Traitement des corr�lations d'alarmes */
	       return;		/* Il n'y a plus rien � faire */
	     end if;

	     if IsMaskedAdm (AlarmCl, CablSId, CablPId) then
	       return;		/* l'alarme est masqu�e par l'Administrateur */
	     end if;
    end if;
    
 --   insert into test values (SEQ_TEST.NEXTVAL, 'PostAlrm : SiteId = '||SiteId ||
--      ' EquipId = '|| EquipId || ' LiaiId = ' || LiaiId);


    maj_oper (IdEvt, SiteId, EquipId, LiaiId, AlarmLocal, AlarmGrave, AlarmCommut, ProgNb, 
			  EltSiteId, EltSiteNom, EltTypeId, EltTypeNom, EltId, EltNom, TsPrOper, Debord);
				/* met � jour l'�tat op�rationnel de l'�l�ment g�r� en d�faut,
				   des CABLEQU et des programmes que cela concerne */
 --   insert into test values (SEQ_TEST.NEXTVAL, 'PostAlrm : TsPrOper = '||TsPrOper );

    if (Debord = 1) then
	     SStr := TsPrOper || 'Debordement';
    	 insert into ALARM2 (ALARM2_ID, ALARM2_TSPROPER) values (IdEvt, SStr);
    else
    	 insert into ALARM2 (ALARM2_ID, ALARM2_TSPROPER) values (IdEvt, TsPrOper);
    end if;


    CliConc := ';';
    PrConc  := ';';
    PrEtat  := ';';

    SStr    := TsPrOper;
    SPos    := INSTR (SStr, ';') +1;
--    SStr    := SUBSTR (SStr, SPos);

    while (LENGTH (SStr) > 0) loop
	     SPos  := INSTR  (SStr, ',') -1;
	     SPrId := SUBSTR (SStr, 1, SPos);
	     
	     select A.PROG_ID, B.PROG_OPER, CLIENT.CLIENT_ID
	       into ProgId, ProgOper, ClientId
	       from PROG A, PROG_REP B, CLIENT
	       where A.PROG_ID = to_number (SPrId) and
		      A.CLIENT_ID = CLIENT.CLIENT_ID and A.PROG_ID = B.PROG_ID;

	     --CliConc  := CliConc || ClientNom || ';';
	     CliConc  := CliConc || ClientId || ';';

      -- Maj JL - V�rification si le programme est actif.
      select prog_actif into progActif from prog where prog_id = to_number (SPrId);

      if(progActif = 1) then	
	     PrConc   := PrConc  || ProgId   || ';';
    	 --PrConc   := PrConc  || ProgNom   || ';';
        
      end if;
      -- fin Maj JL.

    	PrEtat   := PrEtat  || ProgOper  || ';';
    
    	if (length (PrEtat) > 80) then		-- vs 85
    	    PrEtat := PrEtat || 'Debordement;';
    	    PrConc := PrConc || 'Debordement;';
    	    CliConc := CliConc || 'Debordement;';
    	    exit;
    	end if;
    
    	if (length (PrConc) > 400) then		-- vs 500
    	    PrEtat := PrEtat || 'Debordement;';
    	    PrConc := PrConc || 'Debordement;';
    	    CliConc := CliConc || 'Debordement;';
    	    exit;
    	end if;

    	if (length (CliConc) > 400) then	-- vs 300
    	    PrEtat := PrEtat || 'Debordement;';
    	    PrConc := PrConc || 'Debordement;';
    	    CliConc := CliConc || 'Debordement;';
    	    exit;
    	end if;

    	SPos  := INSTR  (SStr, ';') +1;
    	SStr  := SUBSTR (SStr, SPos);
    end loop;


    insert into ALARM3 (ALARM3_ID, ALARM3_CLICONC, ALARM3_PRCONC, ALARM3_PRETAT, 
			ALARM3_ELTSITEID, ALARM3_ELTTYPEID, ALARM3_ELTID, 
			ALARM3_FELTG, ALARM3_FALG, ALARM3_ELTCLASSE)
	    values (IdEvt, CliConc, PrConc, PrEtat, EltSiteId, EltTypeId, EltId, FEltG, FAlG,
				ClasseObjetEnDefaut);

    if IsMaskedBri (AlarmCl, CablSId, CablPId) then
	     return;		/* l'alarme est masqu�e par un Brigadier autoris� */
    end if;

    if AlarmGrave > 0 and not IsToAff (AlarmCl, CablSId, CablPId) then
       return;		/* l'alarme n'est pas � afficher sur les consoles */
    end if;
   
    /*traitement de binding variables des traps*/
    stBindingVarInfo := '';
    if (AlarmCl = 'TRAPG' or AlarmCl = 'TRAPS' ) then
	     stBindingVarInfo := BindingVarInfo (AlarmInfo, EquipId, Iana, AlarmNumObj);
    end if;

	EltSiteNom := ' ';
	if (EltSiteId is not null) then
		EltSiteNom := GetSiteNom (EltSiteId);
	end if;
	
    mess_alrm (Mess, IdEvt, AlarmIddeb, AlGereeId, SiteId, EquipId, LiaiId, AlarmNum, AlarmCl, 
	       AlarmNumObj, AlarmType, AlarmDate, AlarmGrave, AlarmNseuil, AlarmVseuil, 
	       AlarmNumal, AlarmTexte, AlarmInfo, AlarmNomL, AlarmComment, AlarmCommut, 
	       PrConc, CliConc, PrEtat, EltSiteNom, EltTypeNom, EltNom, TsPrOper, FEltG, FAlG, 
	       Sonne, Acquit, Acquittee, stBindingVarInfo);
	       
	  INSERT_TRAPALARM( IdEvt, AlarmDate, AlarmGrave, AlGereeId, EquipId);


END PostAlrm;
