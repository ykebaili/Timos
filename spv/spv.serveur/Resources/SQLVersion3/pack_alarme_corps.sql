create or replace
PACKAGE BODY PACK_ALARME AS


    --===================================================================================================
    -- Mise à jour de l'état opérationnel de l'équipement et de ses dépendances suite
    -- à l'arrivée d'une alarme
    PROCEDURE maj_oper (Id NUMBER, SiteId NUMBER, EquipId NUMBER,
                        LiaiId NUMBER, AlarmLocal NUMBER, AlarmGrave NUMBER, is_commut spv_types.is_commut_t,
                        EltSiteId IN OUT NUMBER, EltSiteNom IN OUT NOCOPY VARCHAR2, 
                        EltTypeId IN OUT NUMBER, EltTypeNom IN OUT NOCOPY VARCHAR2, 
                        EltId IN OUT NUMBER, EltNom IN OUT NOCOPY VARCHAR2,
                        infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t) IS
                        
    	/* Cette procédure met à jour l'état opérationnel de l'élément géré en défaut,
	   ainsi que l'état opérationnel des CABLEQU et des programmes que cela concerne */

    BEGIN

        if (SiteId is not NULL) then
	     pack_site.maj_oper_site (Id, SiteId, AlarmLocal, AlarmGrave, 
					  EltSiteId, EltSiteNom, EltTypeId, EltTypeNom, EltId, EltNom, 
					  infos_diag_table);
        elsif (EquipId is not NULL) then
	     equipement.maj_oper_equip (Id, EquipId, AlarmLocal, AlarmGrave, is_commut, 
					   EltSiteId, EltSiteNom, EltTypeId, EltTypeNom, EltId, EltNom,
					   infos_diag_table);
        elsif (LiaiId is not NULL) then
	     EltSiteId := spv_types.c_inex_objet_id;
	     liaison.maj_oper_liai (Id, LiaiId, AlarmLocal, AlarmGrave, EltTypeId, EltTypeNom,
					  EltId, EltNom, infos_diag_table);
        end if;

    END maj_oper;
    --==========================================================================================================
    
    
    
    --==========================================================================================================
    PROCEDURE mess_alrm (Mess IN OUT NOCOPY VARCHAR2,
                          IdEvt NUMBER, IdAlarmData NUMBER, AlarmIddeb NUMBER, AlGereeId NUMBER, SiteId NUMBER, EquipId NUMBER,
                          LiaiId NUMBER, AlarmNum NUMBER, AlarmCl VARCHAR2, AlarmNumObj NUMBER,
                          AlarmType NUMBER, AlarmDate VARCHAR2, AlarmGrave NUMBER, AlarmNseuil VARCHAR2,
                          AlarmVseuil	NUMBER, AlarmNumal VARCHAR2, AlarmTexte NUMBER, AlarmInfo VARCHAR2,
                          AlarmNomL VARCHAR2, AlarmComment VARCHAR2, is_commut spv_types.is_commut_t,
                          ProgNom VARCHAR2, ClientNom VARCHAR2, ProgOper VARCHAR2,
                          EltSiteNom VARCHAR2, EltTypeNom VARCHAR2, EltPosNom VARCHAR2, TsPrOper VARCHAR2,
                          Sonne NUMBER, Acquit NUMBER, Acquittee NUMBER, stBindingVarInfo VARCHAR2) IS

        BindingId       NUMBER;
        BindingType 	NUMBER;
        MessId		NUMBER;
        MaxMess		NUMBER;			/* Taille max. de la variable Mess (à ne pas dépasser) */
        MaxChamps   	NUMBER;			/* Taille max. accordée à certains champs */
        AlarmInfoLoc	VARCHAR2 (1024);
        ProgNomLoc	VARCHAR2 (1000);		/* Programmes concernés */
        ClientNomLoc	VARCHAR2 (1000);	/* Clients concernés */
        FEltGLoc	VARCHAR2 (500)  := '';
        FAlGLoc		VARCHAR2 (500)  := '';
        BindingInfoLoc 	VARCHAR2 (500);

    BEGIN
    
        MaxMess  	:= 1800;
        MaxChamps 	:= 1496;
        AlarmInfoLoc 	:= AlarmInfo;
        ProgNomLoc 	:= ProgNom;
        ClientNomLoc 	:= ClientNom;
        --FEltGLoc 	:= substr (FEltG, 1, 500);
        --FAlGLoc  	:= substr (FAlG, 1, 500);
        BindingInfoLoc 	:= substr (stBindingVarInfo, 1, 500);
        


        IF (NVL(LENGTH(AlarmInfo), 0) + NVL(LENGTH(ProgNom),        0) +
            NVL(LENGTH(ClientNom), 0) + NVL(LENGTH(ProgOper),       0) +
            NVL(LENGTH(TsPrOper),  0) + NVL(LENGTH(FEltGLoc),       0) +
            NVL(LENGTH(FAlGLoc),   0) + NVL(LENGTH(BindingInfoLoc), 0) > MaxChamps) THEN
            -- On sacrifie les champs longs correspondants et on met 'Debordement' dedans
            AlarmInfoLoc	:= c_debordement;
            ProgNomLoc 	        := c_debordement;
            ClientNomLoc 	:= c_debordement;
            BindingInfoLoc 	:= c_debordement;
        END IF;

        select SEQ_MESSALRM.NEXTVAL into MessId from dual;

        Mess := '0#';			-- Code du message
        Mess := CONCAT (Mess, '35#');	-- Nb. de # dans ce message
        Mess := CONCAT (Mess, IdEvt);	   	Mess := CONCAT (Mess, '#'); /* Id événement alarme */
        Mess := CONCAT (Mess, IdAlarmData);	   	Mess := CONCAT (Mess, '#'); /* Id alarmdata */
        Mess := CONCAT (Mess, MessId); 	Mess := CONCAT (Mess, '#'); /* stockage dans MESSALRM */
        Mess := CONCAT (Mess, AlGereeId);   Mess := CONCAT (Mess, '#');

        if (NOT (SiteId IS NULL)) then
            BindingId:=SiteId;
            BindingType:=1;
        elsif (NOT (EquipId IS NULL)) then
            BindingId:=EquipId;
            BindingType:=4;
        elsif (NOT (LiaiId IS NULL)) then
            BindingId:=LiaiId;
            BindingType:=5;
        else
            BindingId:=999;
            BindingType:=9;
        end if;

        Mess := CONCAT (Mess, BindingId);   Mess := CONCAT (Mess,  '#');  /* BindingId */
        Mess := CONCAT (Mess, BindingType); Mess := CONCAT (Mess,  '#');  /* BindingType */
        Mess := CONCAT (Mess, AlarmIddeb);  Mess := CONCAT (Mess,  '#');  /* Id début al. */
        Mess := CONCAT (Mess, AlarmNomL);  	Mess := CONCAT (Mess,  '#');  /* Nom de l'al. gérée */
        Mess := CONCAT (Mess, AlarmCl);    	Mess := CONCAT (Mess,  '#');  /* Classe : IS etc.. */
        Mess := CONCAT (Mess, AlarmNumObj);	Mess := CONCAT (Mess,  '#');  /* n°objet : IS */
        Mess := CONCAT (Mess, AlarmType);  	Mess := CONCAT (Mess,  '#');  /* Type al. gérée */
        Mess := CONCAT (Mess, AlarmDate);  	Mess := CONCAT (Mess,  '#');  /* date */
        Mess := CONCAT (Mess, AlarmGrave); 	Mess := CONCAT (Mess,  '#');  /* gravité alarme */
        Mess := CONCAT (Mess, AlarmNseuil);	Mess := CONCAT (Mess,  '#');  /* Nom seuil */
        Mess := CONCAT (Mess, AlarmVseuil);	Mess := CONCAT (Mess,  '#');  /* Valeur seuil */
        Mess := CONCAT (Mess, AlarmNumal); 	Mess := CONCAT (Mess,  '#');
        Mess := CONCAT (Mess, AlarmTexte); 	Mess := CONCAT (Mess,  '#');  /* Texte : 0 = al. phy. etc..*/
        Mess := CONCAT (Mess, AlarmComment);Mess := CONCAT (Mess,  '#');  /* Commentaire de al. gérée */
        Mess := CONCAT (Mess, AlarmInfoLoc); 	Mess := CONCAT (Mess,  '#');  /* Info additionnelle fournie par l'EM */
        Mess := CONCAT (Mess, to_char (Acquit));  	Mess := CONCAT (Mess,  '#');  /* A Acquitter */
        Mess := CONCAT (Mess, to_char (Sonne));   	Mess := CONCAT (Mess,  '#');  /* Sonner */
        Mess := CONCAT (Mess, '0');   	Mess := CONCAT (Mess,  '#');  /* Type sonnerie */
        Mess := CONCAT (Mess, is_commut);	Mess := CONCAT (Mess,  '#');  /* 1 : chgt. état commutateur, 0 : alarme */
        Mess := CONCAT (Mess, EltSiteNom);	Mess := CONCAT (Mess,  '#');  /* Nom du site de l'élt. en défaut */
        Mess := CONCAT (Mess, EltTypeNom);	Mess := CONCAT (Mess,  '#');  /* Type (d'équip, de liai) de l'élt. en défaut */
        Mess := CONCAT (Mess, EltPosNom);	Mess := CONCAT (Mess,  '#');  /* Position de l'élt. en défaut */
        Mess := CONCAT (Mess, ProgNomLoc);	Mess := CONCAT (Mess,  '#');  /* Programmes concernés par l'alarme */
        Mess := CONCAT (Mess, ClientNomLoc); Mess := CONCAT (Mess,  '#');  /* Clients concernés par l'alarme */
        Mess := CONCAT (Mess, ProgOper);	Mess := CONCAT (Mess,  '#');  /* Etat opér. du prog. concerné par l'alarme ou ' ' si plusieurs */
        Mess := CONCAT (Mess, TsPrOper);	Mess := CONCAT (Mess,  '#');  /* Etat opér. des prog. concernés par l'alarme (<= 70) */
        Mess := CONCAT (Mess, FEltGLoc); Mess := CONCAT (Mess,  '#');  /* Consigne de l'élément géré en défaut */
        Mess := CONCAT (Mess, FAlGLoc);  Mess := CONCAT (Mess,  '#');  /* Consigne de l'alarme gérée */
        Mess := CONCAT (Mess, BindingInfoLoc);	Mess := CONCAT (Mess,  '#');  /*<nom de var.visible1> = <valeur de var.visible1>;<nom de var.visible2> = <valeur de var.visible2>;... */

        insert into MESSALRM (MESSALRM_ID, MESSALRM_MESS, MESSALRM_SENT, MESSALRM_NATURE)
            values (MessId, Mess, 0, 0);

    END mess_alrm;
    --==========================================================================================================
    
    
    
    --==========================================================================================================
    PROCEDURE formate (infos_diag_table diagramme.infos_diag_t, 
                       CliConc IN OUT NOCOPY VARCHAR2, PrConc IN OUT NOCOPY VARCHAR2, 
                       PrConcAl3 IN OUT NOCOPY VARCHAR2, PrEtat IN OUT NOCOPY VARCHAR2,
                       TsPrOper IN OUT NOCOPY VARCHAR2) IS
                       
        infos_diag  diagramme.infos_diag_r;
        l_index diagramme.index_t;
        
        c_sep_service CONSTANT VARCHAR2(1) := ';';              -- separateur de service
        c_sep_item CONSTANT VARCHAR2(1) := '!';                 -- separateur d'item dans un service
    BEGIN

        CliConc := c_sep_service;
        PrConc  := c_sep_service;
        PrConcAl3 := c_sep_service;
        PrEtat  := c_sep_service;
        
        l_index := infos_diag_table.FIRST;
        LOOP
            EXIT WHEN l_index IS NULL;
            infos_diag := infos_diag_table(l_index); 
            PrConc := PrConc || infos_diag.m_diag_id || c_sep_item || infos_diag.m_diag_label || c_sep_service;
            PrConcAl3 := PrConcAl3 || infos_diag.m_diag_id || c_sep_service;
            PrEtat := PrEtat || infos_diag.m_new_coeff_oper || c_sep_service;
            TsPrOper := TsPrOper || infos_diag.m_diag_id || c_sep_item 
                    || infos_diag.m_old_coeff_oper || c_sep_item
                    || infos_diag.m_new_coeff_oper || c_sep_item || c_sep_service;
            l_index := infos_diag_table.NEXT(l_index);              
        END LOOP;
    EXCEPTION
        WHEN VALUE_ERROR THEN
            CliConc := c_debordement;
            PrConc := c_debordement;
            PrConcAl3 := c_debordement;
            PrEtat := c_debordement;
            TsPrOper := c_debordement;
    END;
    --==========================================================================================================
    
    
                       
    --==========================================================================================================
    PROCEDURE post_alrm (IdEvt NUMBER, IdAlarmData NUMBER, AlGereeId NUMBER, SiteId NUMBER, EquipId NUMBER,
                        LiaiId NUMBER, AlarmNum NUMBER, AlarmCl VARCHAR2, AlarmNumObj NUMBER, 
                        AlarmType NUMBER, AlarmDate VARCHAR2, AlarmGrave NUMBER, AlarmNseuil VARCHAR2,
                        AlarmVseuil	NUMBER, AlarmNumal VARCHAR2, AlarmTexte NUMBER, AlarmInfo VARCHAR2,
                        AlarmNomL VARCHAR2, AlarmComment VARCHAR2, AlarmLocal NUMBER, 
                        is_commut spv_types.is_commut_t,
                        AlarmIddeb NUMBER, CablSId NUMBER, CablPId NUMBER, Sonne NUMBER, Acquit NUMBER,
                        Acquittee NUMBER, Iana NUMBER, ClasseObjetEnDefaut NUMBER) IS
                        
    	-- Id est l'identifiant du nouveau message d'alarme (début ou fin).
        Mess     VARCHAR2 (1800);/* taille max. du message autorisé par Oracle : 1800 octets */
        ProgOper	NUMBER;	     /* Etat opérationnel du programme concerné par cette alarme.
				0 si plusieurs programmes concernés */
        ClientId	CLIENT.CLIENT_ID%TYPE;
        EltSiteId   NUMBER;  /* ID du site contenant l'élt. en défaut. */
	EltSiteNom  VARCHAR2(40);	/* Nom du site de l'élément en défaut; ' ' pour une liaison
									inter-sites */
        EltTypeId  NUMBER;	     /* Id du type d'équipement ou de liaison */
        EltTypeNom   VARCHAR2 (40);  /* nom du type de l'équipement ou de la liaison. 'SITE' 
				pour une alarme	de site */
        EltId    NUMBER;  /* ID de l'équipement ou de la liaison ou du site 
				en défaut */
	EltNom	VARCHAR2(80);	/* Nom de l'équipement ou de la liaison ou du site en défaut */ 
        TsPrOper VARCHAR2 (900); /* Chaîne donnant l'état opérationnel des prog. concernés par 
				cette alarme. 70 prog. au max.
				Structure : NbProg; ProgId, OldProgOper, ProgOper, ProgMsk; 
				ProgId,  etc... */
        Debord   NUMBER;	     /* 1 si débordement de la chaîne TsPrOper, 0 sinon */

        CliConc  VARCHAR2 (1000);/* nom des clients concernés par l'alarme */
        PrConc   VARCHAR2 (1000);/* ID et nom des programmes concernés */
        PrConcAl3   VARCHAR2 (1000);/* ID des programmes concernés */
        PrEtat   VARCHAR2 (100); /* état des programmes concernés */
        SStr     VARCHAR2 (900); /* sous- string de TsPrOper */
        SPrId    VARCHAR2 (50);  /* Id du programme */
        SPos     NUMBER;	     /* position dans ce sous-string */
        stBindingVarInfo VARCHAR2 (2000);/* pour les TRAP */
			     /*<nom de var.visible1> = <valeur de var.visible1>;<nom de var.visible2> = <valeur de var.visible2>;... */ 
			     
	progActif     NUMBER;
	TsPrOperTmp   VARCHAR2 (900);
	TsPrOperPos   NUMBER;
        
        infos_diag_table diagramme.infos_diag_t;

    BEGIN
        Debord  := 0;

        if (is_commut = spv_types.c_not_commut) then
            if not correl_alrm (Mess, IdEvt, IdAlarmData, SiteId, EquipId, LiaiId, CO_SEC1998 (AlarmDate), 
                                AlarmGrave, AlarmIddeb, infos_diag_table) then
				/* Traitement des corrélations d'alarmes */
                return;		/* Il n'y a plus rien à faire */
            end if;

            if IsMaskedAdm (AlarmCl, CablSId, CablPId) then
                return;		/* l'alarme est masquée par l'Administrateur */
            end if;
        end if;
   
        pack_alarme.maj_oper (IdEvt, SiteId, EquipId, LiaiId, AlarmLocal, AlarmGrave, is_commut, 
                              EltSiteId, EltSiteNom, EltTypeId, EltTypeNom, EltId, EltNom, infos_diag_table);
				/* met à jour l'état opérationnel de l'élément géré en défaut,
				   des CABLEQU et des programmes que cela concerne */

        formate (infos_diag_table, CliConc, PrConc, PrConcAl3, PrEtat, TsPrOper);

        insert into ALARM2 (ALARM2_ID, ALARM2_TSPROPER) values (IdEvt, TsPrOper);

        insert into ALARM3 (ALARM3_ID, ALARM3_CLICONC, ALARM3_PRCONC, ALARM3_PRETAT, 
                            ALARM3_ELTSITEID, ALARM3_ELTTYPEID, ALARM3_ELTID, 
                            ALARM3_ELTCLASSE)
	    values (IdEvt, CliConc, PrConcAl3, PrEtat, EltSiteId, EltTypeId, EltId, ClasseObjetEnDefaut);

        if IsMaskedBri (AlarmCl, CablSId, CablPId) then
            return;		/* l'alarme est masquée par un Brigadier autorisé */
        end if;

        if AlarmGrave > 0 and not IsToAff (AlarmCl, CablSId, CablPId) then
            return;		/* l'alarme n'est pas à afficher sur les consoles */
        end if;
   
        /*traitement de binding variables des traps*/
        stBindingVarInfo := '';
        if (AlarmCl = 'TRAPG' or AlarmCl = 'TRAPS' ) then
            stBindingVarInfo := BindingVarInfo (AlarmInfo, EquipId, Iana, AlarmNumObj);
        end if;

	EltSiteNom := ' ';
	if (EltSiteId is not null) then
		EltSiteNom := pack_site.GetSiteNom (EltSiteId);
	end if;
	
        mess_alrm (Mess, IdEvt, IdAlarmData, AlarmIddeb, AlGereeId, SiteId, EquipId, LiaiId, AlarmNum, AlarmCl, 
                   AlarmNumObj, AlarmType, AlarmDate, AlarmGrave, AlarmNseuil, AlarmVseuil, 
                   AlarmNumal, AlarmTexte, AlarmInfo, AlarmNomL, AlarmComment, is_commut, 
                  PrConc, CliConc, PrEtat, EltSiteNom, EltTypeNom, EltNom, TsPrOper, 
                  Sonne, Acquit, Acquittee, stBindingVarInfo);
	       
        INSERT_TRAPALARM( IdEvt, AlarmDate, AlarmGrave, AlGereeId, EquipId);

    END post_alrm;
    --==========================================================================================================
    
    
    
    --==========================================================================================================
    PROCEDURE start_alrm (IdEvt NUMBER, IdAlarmData NUMBER, AlGereeId NUMBER, SiteId NUMBER,
                          EquipId NUMBER, LiaiId NUMBER, AlarmNum NUMBER, AlarmCl VARCHAR2, AlarmNumObj NUMBER,
                          AlarmType NUMBER, AlarmDate VARCHAR2, AlarmGrave NUMBER, AlarmNseuil VARCHAR2,
                          AlarmVseuil	NUMBER, AlarmNumal VARCHAR2, AlarmTexte NUMBER, AlarmInfo VARCHAR2,
                          AlarmNomL VARCHAR2, AlarmComment VARCHAR2, AlarmLocal NUMBER, 
                          is_commut spv_types.is_commut_t,
                          AlarmIddeb NUMBER, CablSId NUMBER, CablPId NUMBER, Acquittee NUMBER, Iana NUMBER,
                          infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t)

    IS
        Mess   VARCHAR2 (1800);  /* taille max des messages Oracle */

        ProgNb	NUMBER;	     /* Nb. de programmes concernés par l'alarme */
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

        TsPrOper VARCHAR2 (900); /* Chaîne donnant l'état opérationnel des prog. concernés par 
				cette alarme. 70 prog. au max.
				Structure : NbProg; ProgId, OldProgOper, ProgOper, ProgMsk; 
				ProgId,  etc... */
        CliConc  VARCHAR2 (1000);/* nom des clients concernés par l'alarme */
        PrConc   VARCHAR2 (1000);/* ID et nom des programmes concernés */
        PrConcAl3 VARCHAR2 (1000);/* ID  des programmes concernés */
        PrEtat   VARCHAR2 (100); /* état des programmes concernés */
        SStr     VARCHAR2 (900); /* sous- string de TsPrOper */
        SPos     NUMBER;	     /* position dans ce sous-string */

        Sonne    NUMBER;	     /* 1 s'il faut sonner pour cette alarme, 0 sinon */
        Acquit   NUMBER;	     /* 1 s'il faut acquitter cette alarme, 0 sinon */

        stBindingVarInfo VARCHAR2 (2000);

        CURSOR cAl2 IS
            select * from ALARM2
              where ALARM2_ID = IdEvt;

        CURSOR cAl3 IS
            select * from ALARM3
              where ALARM3_ID = IdEvt;
        
    BEGIN

        if (not IsMaskedAdm (AlarmCl, CablSId, CablPId)) then

            maj_oper (IdEvt, SiteId, EquipId, LiaiId, AlarmLocal, AlarmGrave, is_commut, 
                      EltSiteId, EltSiteNom, EltTypeId, EltTypeNom, EltId, EltNom,
                      infos_diag_table);
                      
            formate(infos_diag_table, CliConc, PrConc, PrConcAl3, PrEtat, TsPrOper);

            Al2Fait := FALSE;
            for vAl2 in cAl2 loop
                Al2Fait := TRUE;
            end loop;

            if (NOT Al2Fait) then
                insert into ALARM2 (ALARM2_ID, ALARM2_TSPROPER) values (IdEvt, TsPrOper);
            end if;


            Al3Fait := FALSE;
            for vAl3 in cAl3 loop
		Al3Fait := TRUE;
            end loop;

            if (NOT Al3Fait) then           
  		insert into ALARM3 (ALARM3_ID, ALARM3_CLICONC, ALARM3_PRCONC, ALARM3_PRETAT,
				ALARM3_ELTSITEID, ALARM3_ELTTYPEID, ALARM3_ELTID,
			        ALARM3_ELTCLASSE)
		    values (IdEvt, CliConc, PrConcAl3, PrEtat, EltSiteId, EltTypeId, EltId,
                            GetClasseObjetEnDefaut (EquipId, LiaiId, SiteId));
            end if;

            if (not IsMaskedBri (AlarmCl, CablSId, CablPId)) then
                if (CablPId > 0) then
                    select ALARMGEREE_SON, ALARMGEREE_ACQ into Sonne, Acquit
                        from ACCES_ACCESC
                        where ACCES_ACCESC_ID = CablPId;
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

                    mess_alrm  (Mess, IdEvt, IdAlarmData, AlarmIddeb, AlGereeId,
                                SiteId, EquipId, LiaiId,
                                AlarmNum, AlarmCl, AlarmNumObj, AlarmType,
                                AlarmDate, AlarmGrave, AlarmNseuil, AlarmVseuil,
                                AlarmNumal, AlarmTexte, AlarmInfo, AlarmNomL,
                                AlarmComment, is_commut, PrConc, CliConc, PrEtat,
                                EltSiteNom, EltTypeNom, EltNom, TsPrOper, Sonne, Acquit, Acquittee, stBindingVarInfo);

                end if; /* l'alarme gérée est à afficher sur les consoles */
            end if; /* l'alarme n'est pas masquée par le Brigadier */
        end if;	/* l'alarme n'est pas masquée par l'Administrateur */

    END	Start_Alrm;
    --==========================================================================================================
    
    
    
    --==========================================================================================================
    PROCEDURE stop_alrm (Mess IN OUT NOCOPY VARCHAR2, Id NUMBER, AlGereeId NUMBER,
                         SiteId NUMBER, EquipId NUMBER, LiaiId NUMBER,
                         AlarmCl VARCHAR2, AlarmNumObj NUMBER, AlarmNumal VARCHAR2, 
                         infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t)
/* Cette procédure est activée lorsqu'on "déclasse" une alarme (elle devient "fille")
   alors qu'elle était en cours.
   Il faut donc l'arrêter.
*/

    IS
        BindingId     NUMBER;
        BindingType   NUMBER;
        MessId        NUMBER;
        AlarmNomL     VARCHAR2 (40);
        AlarmType     NUMBER;
        SiteNom       VARCHAR2 (40);
        CliConc       VARCHAR2 (1000);/* nom des clients concernés par l'alarme */
        PrConc        VARCHAR2 (1000);/* ID et nom des programmes concernés */
        PrConcAl3     VARCHAR2 (1000);/* nom des programmes concernés */
        PrEtat        VARCHAR2 (100); /* état des programmes concernés */
        TsPrOper      VARCHAR2 (900); /* Chaîne donnant l'état opérationnel des prog. concernés par 
				cette alarme. 70 prog. au max.
				Structure : NbProg; ProgId, OldProgOper, ProgOper, ProgMsk; 
				ProgId,  etc... */

    BEGIN
        select SEQ_MESSALRM.NEXTVAL into MessId from dual;

        Mess := '4#';			-- Code du message
        Mess := CONCAT (Mess, '11#');	-- Nb. de #
        Mess := CONCAT (Mess, Id);	   	Mess := CONCAT (Mess, '#'); /* Id alarme */
        Mess := CONCAT (Mess, MessId); 	Mess := CONCAT (Mess, '#'); /* stockage dans MESSALRM */
        Mess := CONCAT (Mess, AlGereeId);   Mess := CONCAT (Mess, '#');

        if (NOT (SiteId IS NULL)) then
            BindingId:=SiteId;
            BindingType:=1;
            select SITE_NOM into SiteNom
                from SITE
                where SITE_ID = SiteId;	/* Pour Vidéo (signature alarme) */
        elsif (NOT (EquipId IS NULL)) then
            BindingId:=EquipId;
            BindingType:=4;
            select SITE_NOM into SiteNom
                from EQUIP, SITE
                where EQUIP_ID = EquipId and
		  EQUIP.SITE_ID = SITE.SITE_ID;	/* Pour Vidéo (signature alarme) */
        elsif (NOT (LiaiId IS NULL)) then
            BindingId:=LiaiId;
            BindingType:=5;
            SiteNom := ' ';
        else
            BindingId:=999;
            BindingType:=9;
            SiteNom := ' ';
        end if;
        
        formate(infos_diag_table, CliConc, PrConc, PrConcAl3, PrEtat, TsPrOper);

        Mess := CONCAT (Mess, BindingId);   Mess := CONCAT (Mess,  '#');  /* BindingId */
        Mess := CONCAT (Mess, BindingType); Mess := CONCAT (Mess,  '#');  /* BindingType */
        Mess := CONCAT (Mess, AlarmCl);    	Mess := CONCAT (Mess,  '#');  /* Classe : IS etc.. */
        Mess := CONCAT (Mess, AlarmNumObj);	Mess := CONCAT (Mess,  '#');  /* n°objet : IS */
        Mess := CONCAT (Mess, AlarmNumal); 	Mess := CONCAT (Mess,  '#');
        Mess := CONCAT (Mess, TsPrOper);	Mess := CONCAT (Mess,  '#');  /* Etat opér. des prog. concernés par l'alarme (<= 70) */

        insert into MESSALRM (MESSALRM_ID, MESSALRM_MESS, MESSALRM_SENT, MESSALRM_NATURE)
            values (MessId, Mess, 0, 0);

    END  stop_alrm;
    --==========================================================================================================
    
    
    --==========================================================================================================
    FUNCTION AlarmNature (IdAlarmeData NUMBER) RETURN alarme_nature_t
	/* Cette fonction retourne :
	- c_alarme_autonome si l'alarme est autonome,
	- c_alarme_mere si c'est une alarme mère,
	- c_alarme_fille si c'est une alarme fille. */
        -- Modif. X.L. le 08/01/2010 ALARM_ALARMC est remplacée
        -- par ALARMDATA_CORREL. L'ID passé en paramètre est
        -- maintenant l'ID de l'alarme dans ALARMDATA et non plus
        -- l'ID de l'événement alarme dans ALARM.
    IS
        CURSOR c1 is
            select * from ALARMDATA_CORREL
                where ALARMDATA_ID = IdAlarmeData
                for update of ALARMDATA_ID;

        CURSOR c2 is
            select * from ALARMDATA_CORREL
                where ALARMDATA_BINDINGID = IdAlarmeData
                for update of ALARMDATA_ID;

    BEGIN
        for rc1 in c1 loop
            return c_alarme_fille;
        end loop;

        for rc2 in c2 loop
            return c_alarme_mere;
        end loop;

        return c_alarme_autonome;

    END AlarmNature;
    --==========================================================================================================
    
    
    --==========================================================================================================    
    FUNCTION IsMaskedLiai (LiaiId1 NUMBER, LiaiId2 NUMBER) RETURN BOOLEAN
	/* Cette fonction retourne TRUE si la liaison LiaiId1 est masquée par LiaiId2,
	FALSE sinon. Elle tient compte des supports possibles */

    IS
        CURSOR cLiai is
            select * from LIAI_LIAIC
                where LIAI_ID = LiaiId1;

    BEGIN

        for vLiai in cLiai loop
            if vLiai.LIAI_BINDINGID = LiaiId2 then
                return TRUE;
            end if;

            if (IsMaskedLiai (vLiai.LIAI_BINDINGID, LiaiId2)) then
                return TRUE;
            end if;
        end loop;

        return FALSE;
    END	IsMaskedLiai;
    --==========================================================================================================


    --==========================================================================================================
    FUNCTION IsMaskedBy (Id1 NUMBER, EquipId1 NUMBER, LiaiId1 NUMBER,
                         Id2 NUMBER, EquipId2 NUMBER, LiaiId2 NUMBER)
    RETURN BOOLEAN
	/* Cette fonction retourne TRUE si Id1 est masqué par Id2, FALSE sinon.
	Une alarme ne peut être masquée que par une alarme mère ou autonome.
	Id1 est masqué par Id2 si (pour l'instant) :
	- elles arrivent "à peu près en même temps". Cette condition est vérifiée par le
	programme appelant, qui n'appelle cette fonction que pour ces alarmes là;
	- Id1 et Id2 sont des alarmes d'équipements appartenant au même programme, dans
	le même site,
	et le n° d'ordre de l'équip. de Id2 est strictement inférieur à celui de Id1,
	- OU Id1 et Id2 sont des alarmes de liaisons et la liaison de Id1 est supportée
	par celle de Id2.

	ATTENTION : le masquage a lieu si cette condition est vérifiée dans AU MOINS UN
	des câblages auxquels l'équipement appartient.

	Cette fonction appelle AlarmNature. */
    IS

        CURSOR cMasked is
            select * from EQUIP_MSK
                where EQUIP_ID = EquipId1 and
                      EQUIP_BINDINGID = EquipId2;

    BEGIN

        if (AlarmNature (Id2) = c_alarme_fille) then
	     return FALSE;
        end if;

        if (EquipId1 is not null and EquipId2 is not null) then
					/* Alarmes d'équipement */
            for cEq in cMasked loop
    --   	    insert into test values(seq_test.nextval, 'IsMaskedBy Eq1= ' || EquipId1 || ' Eq2= ' ||EquipId2);
    --   	    insert into test values(seq_test.nextval, 'EQUIP_MSK '|| cEq.EQUIP_MSK_ID ||  cEq.EQUIP_ID || cEq.EQUIP_BINDINGID || cEq.CABLEQU_ID);
                return TRUE;
            end loop;

            return FALSE;

        end if;

        if (LiaiId1 is not null and LiaiId2 is not null) then
					/* Alarmes de liaison */
            return (IsMaskedLiai (LiaiId1, LiaiId2));
        end if;

        return FALSE;

    END IsMaskedBy;
    --==========================================================================================================


    --==========================================================================================================
    FUNCTION correl_alrm (Mess IN OUT NOCOPY VARCHAR2,
                          IdEvt NUMBER, IdAlarmData NUMBER, SiteId NUMBER, EquipId NUMBER, LiaiId NUMBER, 
                          DateAlSec NUMBER, AlarmGrave NUMBER, AlarmIddeb NUMBER, 
                          infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t)
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
        Nature	alarme_nature_t;	/* Nature d'une alarme */

        CURSOR cAccesc is
            select B.ALARM_ID, B.ALARMDATA_ID, B.SITE_ID, B.EQUIP_ID, B.LIAI_ID, A.ALARMGEREE_ID, 
            	   B.ALARM_CL, B.ALARM_NUMOBJ, B.ALARM_NUMAL
                from ACCES_ACCESC A, ACCES_ACCESC_REP B
                where A.ACCES_ACCESC_ID = B.ACCES_ACCESC_ID and
                      A.COMMUT = spv_types.c_not_commut and
                      ABS (DateAlSec - B.ALARM_SEC) <= PrecTime and
                      B.ALARM_ID != IdEvt;
	
			-- Toutes les autres alarmes en cours, démarrées en même temps que IdEvt
	    
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
  		      return FALSE;	/* Alarme fille */
                end if;
	    end loop;

            for cAl in cAccesc loop	/* Ces alarmes sont elles masquées par la nouvelle alarme ? */
                if (IsMaskedBy (cAl.ALARMDATA_ID, cAl.EQUIP_ID, cAl.LIAI_ID, IdAlarmData, EquipId, LiaiId)) then
 

                    /* IdEvt masque cAl.ALARM_ID */
                    Nature := AlarmNature (cAl.ALARMDATA_ID);
                    /* Alarme autonome (0), mère (1), fille (2) */

                    if (Nature = c_alarme_mere) then
        		    -- update ALARM_ALARMC			/* cAl.ALARM_ID était une alarme mère */
        			-- set ALARM_BINDINGID = IdEvt	/* Elle est déclassée par IdEvt */
        			-- where ALARM_BINDINGID = cAl.ALARM_ID;
                        update ALARMDATA_CORREL						/* cAl.ALARMDATA_ID était une alarme mère */
                          set ALARMDATA_BINDINGID = IdAlarmData	/* Elle est déclassée par IdAlarmData */
                          where ALARMDATA_BINDINGID = cAl.ALARMDATA_ID;
                    end if;

                    if (Nature != c_alarme_fille) then		/* cAl.ALARMDATA_ID n'est pas une alarme fille :
        						   on la masque */
        			/*
        		    insert into ALARM_ALARMC (ALARM_ID, ALARM_BINDINGID)
        			     values (cAl.ALARM_ID, IdEvt);*/
                        insert into ALARMDATA_CORREL (ALARMDATA_ID, ALARMDATA_BINDINGID)
                          values (cAl.ALARMDATA_ID, IdAlarmData);

                        maj_oper (cAl.ALARM_ID, cAl.SITE_ID, cAl.EQUIP_ID, cAl.LIAI_ID, 0, 0, 0,
                                  EltSiteId, EltSiteNom, EltTypeId, EltTypeNom, EltId, EltNom, 
                                  infos_diag_table);
        						/* "retombée" de cAl.ALARM_ID */

                        delete ALARM2 where ALARM2_ID = cAl.ALARM_ID;

                        stop_alrm (Mess, cAl.ALARM_ID, cAl.ALARMGEREE_ID, cAl.SITE_ID, cAl.EQUIP_ID,
                                  cAl.LIAI_ID, cAl.ALARM_CL, cAl.ALARM_NUMOBJ, cAl.ALARM_NUMAL, infos_diag_table);
                                    /* envoi du message de retombée de l'alarme pour chacune de ces alarmes
                                      qui sont masquées par la nouvelle alarme arrivée */
                    end if;	/* retombée de cAl.ALARM_ID */

                end if;--IsMaskedBy
            end loop;

        else			/* Fin d'alarme */
            --Nature := AlarmNature (AlarmIddeb);
            Nature := AlarmNature (IdAlarmData);


            if (Nature = c_alarme_mere) then
                insert into FINALARM (FINALARM_ID, ALARM_ID) values (SEQ_FINALARM.NEXTVAL, IdEvt);
            elsif (Nature = c_alarme_fille) then
                --delete ALARM_ALARMC
                --    where ALARM_ID = AlarmIddeb;
                delete ALARMDATA_CORREL
                  where ALARMDATA_ID = IdAlarmData;
                return FALSE;
            end if;

        end if;--Fin d'alarme

        return TRUE;

    END correl_alrm;
    --==========================================================================================================



    --==========================================================================================================
    PROCEDURE mask_alrm (Mess IN OUT NOCOPY VARCHAR2,
                         AlarmCl VARCHAR2, AlarmNumObj NUMBER, AlarmNumal VARCHAR2, AlarmGrave NUMBER,
                         SiteId NUMBER, EquipId NUMBER, LiaiId NUMBER,
                         infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t)
-- AlarmGrave = 1 en début de masquage (Brig.) ou 2 (Adm.) et 0 en fin de masquage

    IS
        MessId	NUMBER;
        BindingId	NUMBER;
        BindingType NUMBER;
        CliConc       VARCHAR2 (1000);/* nom des clients concernés par l'alarme */
        PrConc        VARCHAR2 (1000);/* ID et nom des programmes concernés */
        PrConcAl3     VARCHAR2 (1000);/* nom des programmes concernés */
        PrEtat        VARCHAR2 (100); /* état des programmes concernés */
        TsPrOper      VARCHAR2 (900); /* Chaîne donnant l'état opérationnel des prog. concernés par 
				cette alarme. 70 prog. au max.
				Structure : NbProg; ProgId, OldProgOper, ProgOper, ProgMsk; 
				ProgId,  etc... */

    BEGIN
        select SEQ_MESSALRM.NEXTVAL into MessId from dual;

        Mess := '7#';				-- Code du message
        Mess := CONCAT (Mess, '18#');		-- Nb. de #
        Mess := CONCAT (Mess, '0#');		/* Alarm_Id */
        Mess := CONCAT (Mess, MessId); 	Mess := CONCAT (Mess, '#'); /* stockage dans MESSALRM */
        Mess := CONCAT (Mess, '0#');   		/* AlarmGeree_Id */

        if (NOT (SiteId IS NULL)) then
            BindingId:=SiteId;
            BindingType:=1;
        elsif (NOT (EquipId IS NULL)) then
            BindingId:=EquipId;
            BindingType:=4;
        elsif (NOT (LiaiId IS NULL)) then
            BindingId:=LiaiId;
            BindingType:=5;
        else
            BindingId:=999;
            BindingType:=9;
        end if;
        
        formate(infos_diag_table, CliConc, PrConc, PrConcAl3, PrEtat, TsPrOper);
        
        Mess := CONCAT (Mess, BindingId);   Mess := CONCAT (Mess,  '#');  /* BindingId */
        Mess := CONCAT (Mess, BindingType); Mess := CONCAT (Mess,  '#');  /* BindingType */

        Mess := CONCAT (Mess, '0#');  		/* Id début al. AlarmIddeb */
        Mess := CONCAT (Mess, ' #');		/* Nom de l'al. gérée AlarmNomL */
        Mess := CONCAT (Mess, AlarmCl);    	Mess := CONCAT (Mess,  '#');  /* Classe : IS etc.. */
        Mess := CONCAT (Mess, AlarmNumObj);	Mess := CONCAT (Mess,  '#');  /* n°objet : IS */
        Mess := CONCAT (Mess, '0#');		/* Type al. gérée AlarmType */
        Mess := CONCAT (Mess, ' #');		/* Date */
        Mess := CONCAT (Mess, AlarmGrave); 	Mess := CONCAT (Mess,  '#');  /* gravité alarme */
        Mess := CONCAT (Mess, ' #');		/* Nom seuil */
        Mess := CONCAT (Mess, '0#');		/* Valeur seuil */
        Mess := CONCAT (Mess, AlarmNumal); 	Mess := CONCAT (Mess,  '#');
        Mess := CONCAT (Mess, TsPrOper); 	Mess := CONCAT (Mess,  '#');

        insert into MESSALRM (MESSALRM_ID, MESSALRM_MESS, MESSALRM_SENT, MESSALRM_NATURE)
          values (MessId, Mess, 0, 0);

    END mask_alrm;
    --==========================================================================================================
END PACK_ALARME;
