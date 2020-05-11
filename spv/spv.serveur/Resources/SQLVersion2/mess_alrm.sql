create or replace
PROCEDURE mess_alrm (Mess IN OUT VARCHAR2,
    Id NUMBER, AlarmIddeb NUMBER, AlGereeId NUMBER, SiteId NUMBER, EquipId NUMBER,
    LiaiId NUMBER, AlarmNum NUMBER, AlarmCl VARCHAR2, AlarmNumObj NUMBER,
    AlarmType NUMBER, AlarmDate VARCHAR2, AlarmGrave NUMBER, AlarmNseuil VARCHAR2,
    AlarmVseuil	NUMBER, AlarmNumal VARCHAR2, AlarmTexte NUMBER, AlarmInfo VARCHAR2,
    AlarmNomL VARCHAR2, AlarmComment VARCHAR2, AlarmCommut NUMBER,
    ProgNom VARCHAR2, ClientNom VARCHAR2, ProgOper VARCHAR2,
    EltSiteNom VARCHAR2, Typeq VARCHAR2, Poseq VARCHAR2, TsPrOper VARCHAR2,
    FEltG VARCHAR2, FAlG VARCHAR2, Sonne NUMBER, Acquit NUMBER, Acquittee NUMBER, stBindingVarInfo VARCHAR2)

IS
    BindingId 		NUMBER;
    BindingType 	NUMBER;
    MessId		NUMBER;
    MaxMess		NUMBER;			/* Taille max. de la variable Mess (à ne pas dépasser) */
    MaxChamps   	NUMBER;			/* Taille max. accordée à certains champs */
    AlarmInfoLoc	VARCHAR2 (1024);
    ProgNomLoc		VARCHAR2 (1000);
    ClientNomLoc	VARCHAR2 (1000);
    FEltGLoc		VARCHAR2 (500);
    FAlGLoc		VARCHAR2 (500);
    BindingInfoLoc 	VARCHAR2 (500);

BEGIN
    /* Vérifications de taille */

 --   insert into test values(seq_test.nextval, 'mess_alrm TsPrOper' || TsPrOper);

    MaxMess  		:= 1800;
    MaxChamps 		:= 1496;
    AlarmInfoLoc 	:= AlarmInfo;
    ProgNomLoc 		:= ProgNom;
    ClientNomLoc 	:= ClientNom;
    FEltGLoc 		:= substr (FEltG, 1, 500);
    FAlGLoc  		:= substr (FAlG, 1, 500);
    BindingInfoLoc 	:= substr (stBindingVarInfo, 1, 500);

    IF (NVL(LENGTH(AlarmInfo), 0) + NVL(LENGTH(ProgNom),        0) +
        NVL(LENGTH(ClientNom), 0) + NVL(LENGTH(ProgOper),       0) +
	NVL(LENGTH(TsPrOper),  0) + NVL(LENGTH(FEltGLoc),       0) +
	NVL(LENGTH(FAlGLoc),   0) + NVL(LENGTH(BindingInfoLoc), 0) > MaxChamps) THEN
	-- On sacrifie les champs longs correspondants et on met 'Debordement' dedans
	AlarmInfoLoc	:= 'Debordement';
	ProgNomLoc 	:= 'Debordement';
	ClientNomLoc 	:= 'Debordement';
	FEltGLoc 	:= NULL;
	FAlGLoc  	:= NULL;
	BindingInfoLoc 	:= 'Debordement';
    END IF;

    select SEQ_MESSALRM.NEXTVAL into MessId from dual;

--    Mess := CONCAT (Mess, '0#');
    Mess := '0#';			-- Code du message
    Mess := CONCAT (Mess, '34#');	-- Nb. de # dans ce message
    Mess := CONCAT (Mess, Id);	   	Mess := CONCAT (Mess, '#'); /* Id alarme */
--  Mess := CONCAT (Mess, AlarmNum); 	Mess := CONCAT (Mess, '#'); /* Num envoyé par l'EM */
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
--    Mess := CONCAT (Mess, to_char (Acquittee)); Mess := CONCAT (Mess,  '#');  /* Acquittée */
    Mess := CONCAT (Mess, to_char (Sonne));   	Mess := CONCAT (Mess,  '#');  /* Sonner */
    Mess := CONCAT (Mess, '0');   	Mess := CONCAT (Mess,  '#');  /* Type sonnerie */
    Mess := CONCAT (Mess, AlarmCommut);	Mess := CONCAT (Mess,  '#');  /* 1 : chgt. état commutateur, 0 : alarme */
    Mess := CONCAT (Mess, EltSiteNom);	Mess := CONCAT (Mess,  '#');  /* ID du site de l'élt. en défaut */
    Mess := CONCAT (Mess, Typeq);	Mess := CONCAT (Mess,  '#');  /* Type (d'équip, de liai) de l'élt. en défaut */
    Mess := CONCAT (Mess, Poseq);	Mess := CONCAT (Mess,  '#');  /* Position de l'élt. en défaut */
    Mess := CONCAT (Mess, ProgNomLoc);	Mess := CONCAT (Mess,  '#');  /* Nom du prog. concerné par l'alarme ou ' ' ou '+' */
    Mess := CONCAT (Mess, ClientNomLoc); Mess := CONCAT (Mess,  '#');  /* Nom du client concerné par l'alarme ou ' ' ou '+' */
    Mess := CONCAT (Mess, ProgOper);	Mess := CONCAT (Mess,  '#');  /* Etat opér. du prog. concerné par l'alarme ou ' ' */
    Mess := CONCAT (Mess, TsPrOper);	Mess := CONCAT (Mess,  '#');  /* Etat opér. des prog. concernés par l'alarme (<= 70) */
    Mess := CONCAT (Mess, FEltGLoc); Mess := CONCAT (Mess,  '#');  /* Consigne de l'élément géré en défaut */
    Mess := CONCAT (Mess, FAlGLoc);  Mess := CONCAT (Mess,  '#');  /* Consigne de l'alarme gérée */
    Mess := CONCAT (Mess, BindingInfoLoc);	Mess := CONCAT (Mess,  '#');  /*<nom de var.visible1> = <valeur de var.visible1>;<nom de var.visible2> = <valeur de var.visible2>;... */

-- dbms_lock.sleep (0.02); -- attendre que le précédent message soit émis (20 ms.)

--     dbms_alert.signal ('Alarme', Mess);

--insert into test values(seq_test.nextval, 'mess_alrm' || Mess);

    insert into MESSALRM (MESSALRM_ID, MESSALRM_MESS, MESSALRM_SENT, MESSALRM_NATURE)
	values (MessId, Mess, 0, 0);

  /*  insert into MAILALRM (MAILALRM_ID, MAILALRM_MESS, MAILALRM_SENT, MAILALRM_NATURE)
	values (MessId, Mess, 0, 0);*/

END mess_alrm;
