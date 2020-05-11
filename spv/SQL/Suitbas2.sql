--==========================================================================
--   SUITBAS2.SQL  contient tous les ordres de cr�ation d'objets,
--   Pouvant �tre relanc�s sans probl�me

--                non g�n�r�s par AMC * Designor.

--   A lancer apr�s CREBAS.SQL.
--	Version du 06/05/99
--   
--==========================================================================


/*  Test des proc�dures stock�es :
Sous SQL*Plus, faire :
SQL> set serveroutput on

Dans les proc�dures, mettre les lignes :
dbms_output.put_line (....);   imprime le string qui doit �tre un VARCHAR2
*/


--==========================================================================
--       Modifications � apporter aux tables cr��es par AMC*Designor
--       et proc�dures stock�es accompagnant des triggers
--==========================================================================

-- Cette fonction permet aux Triggers de lire "dbarep_repetat" de la table DBAREP
-- 	pour indiquer aux triggers si oui/non ils doivent executer leurs codes.
-- 		si la valeur est 0 => etat normal
-- 		si la valeur est 1 => etat replication => triggers non actifs!

create or replace FUNCTION etat_replication return number is
	result	number(1);
begin
	select dbarep_repetat into result
	from dbarep
	where DBAREP_ID = 1;
	return	result;
end etat_replication;
/

-- Cette fonction permet aux Triggers de lire la valeur de "dbarep_repetat"
-- du 2�me fanion :	
-- 		si la valeur est 0 => insertion des donn�es dans la table Journal
-- 		si la valeur est 1 => le journal n�est plus aliment�.

create or replace FUNCTION etat_journal return number is
	result	number(1);
begin
	select dbarep_repetat into result
	from dbarep
	where DBAREP_ID = 2;
	return	result;
end etat_journal;
/


---------------------
-- FIN REPLICATION --
---------------------


-- Pour qu'un enregistrement puisse �tre cr�� dans la table valeurs, il faut que 
-- les foreign key vers les objets p�res puissent �tre nulles; en effet, une valeur ne peut
-- appartenir � tous ces objets r�f�renc�s � la fois, mais � un et un seul d'entre eux. Ce
-- dernier point est � v�rifier par un trigger.

-- le check "NON NULL" a �t� supprim� dans le MPD

-- Cr�ation du trigger de v�rification qu'une et une seule foreign key existe.
--
-- Ceci concerne les tables ACCES, ALARM, ALARMGEREE, DESSIN, FICHE, VALEURS
-- et CONTACT.

--    ACCES  -------------------------------------------------
--
-- Remise de ti_acces dans son �tat normal : enl�vement du traitement des IS,
-- � faire dans l'applicatif.
-- JPB 28/03/99
--
-- Modif. X.L. le 25/11/99 pour mettre � 0 acces_nbocc � la cr�ation
-- enlev� �galement les parties de code qui �taient en commentaire et qui concernaient la
-- cr�ation de message s�rie (fait dans spv depuis un moment).
-- Pour cela ti_acces est remplac� par tib_acces
--
-- Modif. X.L. le 21/07/00 pour l'init. de ACCES_NBMAXOCC.
-- Modif. JPB. le 24/10/02 pour l'init. de ACCES_CPTDOC.
-- Modif. X.L. le 03/02/05 : on v�rifie que le type de l'acc�s est bien d�fini dans la table PARAM.
-- Modif. X.L. le 26/10/09 : suppression du trigger TIB_ACCES.




------------------------------------------------
--
-- Modif. X.L. le 21/07/00 pour la mise � jour de ACCES_NBMAXOCC dans le cas d'une entr�e
-- s�rie, suivant le contenu de MESS_ID et �galement pour le contr�le de ACCES_NBOCC par
-- rapport � ACCES_NBMAXOCC.
--
-- Modif. X.L. le 03/02/05 : on v�rifie que le type de l'acc�s est bien d�fini dans la table PARAM.
-- Modif. X.L. le 26/10/09 : suppression du trigger TUB_ACCES.
--
------------------------------------------------


--    FIN DE ACCES   ------------------------------------------


--    ACQUITTEMENT   ------------------------------------------

create or replace
TRIGGER tib_acquittement before insert on ACQUITTEMENT for each row
declare
    MessId           integer;
    Mess     	VARCHAR2 (100);	/* taille max. du message autoris� par Oracle : 1800 octets */
begin
	/* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
	   on ne fait pas le traitement */
	if dbms_reputil.from_remote=TRUE then
		return;
	end if;

	select SEQ_ACQUITTEMENT.nextval into :new.ACQUITTEMENT_ID from DUAL;
        
        if (:new.ACK = 1) then
            select SEQ_MESSALRM.NEXTVAL into MessId from dual;

            Mess := '5#';				-- Code du message
            Mess := CONCAT (Mess, '7#');		-- Nb. de #
            Mess := CONCAT (Mess, '0#');		/* Alarm_Id */
            Mess := CONCAT (Mess, MessId); 	Mess := CONCAT (Mess, '#'); /* stockage dans MESSALRM */
            Mess := CONCAT (Mess, '0#');		/* Alarmgeree_Id */
            Mess := CONCAT (Mess, :new.LISTALRM_ID); Mess := CONCAT (Mess, '#'); /* ListAlarm associ�e � la sonnerie en cours */
            Mess := CONCAT (Mess, '0#');		/* BindingTyp */

            insert into MESSALRM (MESSALRM_ID, MESSALRM_MESS, MESSALRM_SENT, MESSALRM_NATURE)
                values (MessId, Mess, 0, 0);
-- dbms_lock.sleep (0.02); -- attendre que le pr�c�dent message soit �mis (20 ms.)
-- dbms_alert.signal ('Alarme', Mess);

    end if;
end tib_acquittement;
/




-- 18/09/03 : JPB : Modification du message MESSALRM, pour introduire le nb. de # envoy�s
--

create or replace
TRIGGER tib_acquittement before insert on ACQUITTEMENT for each row
declare
    MessId           integer;
    Mess     	VARCHAR2 (100);	/* taille max. du message autoris� par Oracle : 1800 octets */
begin
	/* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
	   on ne fait pas le traitement */
	if dbms_reputil.from_remote=TRUE then
		return;
	end if;

	select SEQ_ACQUITTEMENT.nextval into :new.ACQUITTEMENT_ID from DUAL;
        
        if (:new.ACK = 1) then
            select SEQ_MESSALRM.NEXTVAL into MessId from dual;

            Mess := '5#';				-- Code du message
            Mess := CONCAT (Mess, '7#');		-- Nb. de #
            Mess := CONCAT (Mess, '0#');		/* Alarm_Id */
            Mess := CONCAT (Mess, MessId); 	Mess := CONCAT (Mess, '#'); /* stockage dans MESSALRM */
            Mess := CONCAT (Mess, '0#');		/* Alarmgeree_Id */
            Mess := CONCAT (Mess, :new.LISTALRM_ID); Mess := CONCAT (Mess, '#'); /* ListAlarm associ�e � la sonnerie en cours */
            Mess := CONCAT (Mess, '0#');		/* BindingTyp */

            insert into MESSALRM (MESSALRM_ID, MESSALRM_MESS, MESSALRM_SENT, MESSALRM_NATURE)
                values (MessId, Mess, 0, 0);
-- dbms_lock.sleep (0.02); -- attendre que le pr�c�dent message soit �mis (20 ms.)
-- dbms_alert.signal ('Alarme', Mess);

    end if;
end tib_acquittement;
/


--    FIN DE ACQUITTEMENT   -----------------------------------
---------------------------------------------------------------


--    ALARM   -------------------------------------------------
--

--
--	18/09/03 : JPB : changement pour nouveau format de messages.
--	Apr�s les codes du message, on ins�re le nombre de # contenu dans le message.
--	Ceci permet d'introduire de nouveaux types de messages, sans perturber les
--	traitements ant�rieurs (GIS par exemple).
--
-- 	ATTENTION : la taille totale de Mess ne doit pas d�passer 1800 caract�res.
-- 	cf. PostAlrm, Start_Alrm qui sont les fonctions appelantes dans lesquelles
-- 	cette variable est d�finie.
--
--	Modif. X.L. le 16/04/06 pour contr�le de taille
--
-- Evaluation de taille de la variable Mess :
--  Code message 		'0#'	   2		   2
--  Nb de # 			'34#'	   3		   5
--  Id alarme				  10		  15
--  MessId				  10		  25
--  AlGereeId				   6		  31
--  BindingId				   6		  37
--  BindingType				   6		  43
--  AlarmIddeb				  10		  53
--  AlarmNomL				  20		  73			
--  AlarmCl				   5		  78
--  AlarmNumObj				  10		  88
--  AlarmType				   3		  91
--  AlarmDate				  20		 111
--  AlarmGrave				   2		 113
--  AlarmNseuil				  20		 133
--  AlarmVseuil				   5		 138		
--  AlarmNumal				  16		 154		
--  AlarmTexte				   2		 156
--  AlarmComment			  80		 236
--  AlarmInfo				1025		1261
--  Acquit				   2		1263
--  Sonne				   2		1265
--  Type sonne			'0#'	   2		1267
--  AlarmCommut				   2		1269
--  SiteNom				  20		1289
--  Typeq				  20		1309
--  Poseq				  20		1329
--  ProgNom				 411		
--  ClientNom				 411
--  ProgOper
--  TsPrOper
--  FEltG
--  FAlg
--  BindingVarInfo
--  Jusqu'� ProgNom non compris, on peut atteindre 1329 caract�res. Si de ce total on enl�ve AlarmInfo, on tombe
--  � 1329 - 1025 = 304. Donc les champs restant (AlarmInfo, ProgNom, ClientNom, ProgOper, TsPrOper, FEltG, FAlg,
--  BindingVarInfo doivent �tre inf�rieurs � 1800 - 304 = 1496 caract�res. Ce nombre va nous permettre la mise en place
--  de la protection de longueur.

create or replace
PROCEDURE mess_alrm (Mess IN OUT VARCHAR2,
    Id NUMBER, AlarmIddeb NUMBER, AlGereeId NUMBER, SiteId NUMBER, EquipId NUMBER,
    LiaiId NUMBER, AlarmNum NUMBER, AlarmCl VARCHAR2, AlarmNumObj NUMBER,
    AlarmType NUMBER, AlarmDate VARCHAR2, AlarmGrave NUMBER, AlarmNseuil VARCHAR2,
    AlarmVseuil	NUMBER, AlarmNumal VARCHAR2, AlarmTexte NUMBER, AlarmInfo VARCHAR2,
    AlarmNomL VARCHAR2, AlarmComment VARCHAR2, AlarmCommut NUMBER,
    ProgNom VARCHAR2, ClientNom VARCHAR2, ProgOper VARCHAR2,
    SiteNom VARCHAR2, Typeq VARCHAR2, Poseq VARCHAR2, TsPrOper VARCHAR2,
    FEltG VARCHAR2, FAlG VARCHAR2, Sonne NUMBER, Acquit NUMBER, Acquittee NUMBER, stBindingVarInfo VARCHAR2)

IS
    BindingId 		NUMBER;
    BindingType 	NUMBER;
    MessId		NUMBER;
    MaxMess		NUMBER;			/* Taille max. de la variable Mess (� ne pas d�passer) */
    MaxChamps   	NUMBER;			/* Taille max. accord�e � certains champs */
    AlarmInfoLoc	VARCHAR2 (1024);
    ProgNomLoc		VARCHAR2 (1000);
    ClientNomLoc	VARCHAR2 (1000);
    FEltGLoc		VARCHAR2 (500);
    FAlGLoc		VARCHAR2 (500);
    BindingInfoLoc 	VARCHAR2 (500);

BEGIN
    /* V�rifications de taille */

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
--  Mess := CONCAT (Mess, AlarmNum); 	Mess := CONCAT (Mess, '#'); /* Num envoy� par l'EM */
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
    Mess := CONCAT (Mess, AlarmIddeb);  Mess := CONCAT (Mess,  '#');  /* Id d�but al. */
    Mess := CONCAT (Mess, AlarmNomL);  	Mess := CONCAT (Mess,  '#');  /* Nom de l'al. g�r�e */
    Mess := CONCAT (Mess, AlarmCl);    	Mess := CONCAT (Mess,  '#');  /* Classe : IS etc.. */
    Mess := CONCAT (Mess, AlarmNumObj);	Mess := CONCAT (Mess,  '#');  /* n�objet : IS */
    Mess := CONCAT (Mess, AlarmType);  	Mess := CONCAT (Mess,  '#');  /* Type al. g�r�e */
    Mess := CONCAT (Mess, AlarmDate);  	Mess := CONCAT (Mess,  '#');  /* date */
    Mess := CONCAT (Mess, AlarmGrave); 	Mess := CONCAT (Mess,  '#');  /* gravit� alarme */
    Mess := CONCAT (Mess, AlarmNseuil);	Mess := CONCAT (Mess,  '#');  /* Nom seuil */
    Mess := CONCAT (Mess, AlarmVseuil);	Mess := CONCAT (Mess,  '#');  /* Valeur seuil */
    Mess := CONCAT (Mess, AlarmNumal); 	Mess := CONCAT (Mess,  '#');
    Mess := CONCAT (Mess, AlarmTexte); 	Mess := CONCAT (Mess,  '#');  /* Texte : 0 = al. phy. etc..*/
    Mess := CONCAT (Mess, AlarmComment);Mess := CONCAT (Mess,  '#');  /* Commentaire de al. g�r�e */
    Mess := CONCAT (Mess, AlarmInfoLoc); 	Mess := CONCAT (Mess,  '#');  /* Info additionnelle fournie par l'EM */
    Mess := CONCAT (Mess, to_char (Acquit));  	Mess := CONCAT (Mess,  '#');  /* A Acquitter */
--    Mess := CONCAT (Mess, to_char (Acquittee)); Mess := CONCAT (Mess,  '#');  /* Acquitt�e */
    Mess := CONCAT (Mess, to_char (Sonne));   	Mess := CONCAT (Mess,  '#');  /* Sonner */
    Mess := CONCAT (Mess, '0');   	Mess := CONCAT (Mess,  '#');  /* Type sonnerie */
    Mess := CONCAT (Mess, AlarmCommut);	Mess := CONCAT (Mess,  '#');  /* 1 : chgt. �tat commutateur, 0 : alarme */
    Mess := CONCAT (Mess, SiteNom);	Mess := CONCAT (Mess,  '#');  /* Site de l'�lt. en d�faut */
    Mess := CONCAT (Mess, Typeq);	Mess := CONCAT (Mess,  '#');  /* Type (d'�quip, de liai) de l'�lt. en d�faut */
    Mess := CONCAT (Mess, Poseq);	Mess := CONCAT (Mess,  '#');  /* Position de l'�lt. en d�faut */
    Mess := CONCAT (Mess, ProgNomLoc);	Mess := CONCAT (Mess,  '#');  /* Nom du prog. concern� par l'alarme ou ' ' ou '+' */
    Mess := CONCAT (Mess, ClientNomLoc); Mess := CONCAT (Mess,  '#');  /* Nom du client concern� par l'alarme ou ' ' ou '+' */
    Mess := CONCAT (Mess, ProgOper);	Mess := CONCAT (Mess,  '#');  /* Etat op�r. du prog. concern� par l'alarme ou ' ' */
    Mess := CONCAT (Mess, TsPrOper);	Mess := CONCAT (Mess,  '#');  /* Etat op�r. des prog. concern�s par l'alarme (<= 70) */
    Mess := CONCAT (Mess, FEltGLoc); Mess := CONCAT (Mess,  '#');  /* Consigne de l'�l�ment g�r� en d�faut */
    Mess := CONCAT (Mess, FAlGLoc);  Mess := CONCAT (Mess,  '#');  /* Consigne de l'alarme g�r�e */
    Mess := CONCAT (Mess, BindingInfoLoc);	Mess := CONCAT (Mess,  '#');  /*<nom de var.visible1> = <valeur de var.visible1>;<nom de var.visible2> = <valeur de var.visible2>;... */

-- dbms_lock.sleep (0.02); -- attendre que le pr�c�dent message soit �mis (20 ms.)

--     dbms_alert.signal ('Alarme', Mess);

--insert into test values(seq_test.nextval, 'mess_alrm' || Mess);

    insert into MESSALRM (MESSALRM_ID, MESSALRM_MESS, MESSALRM_SENT, MESSALRM_NATURE)
	values (MessId, Mess, 0, 0);

  /*  insert into MAILALRM (MAILALRM_ID, MAILALRM_MESS, MAILALRM_SENT, MAILALRM_NATURE)
	values (MessId, Mess, 0, 0);*/

END mess_alrm;
/


-- 18/09/03 : JPB : Modification du message MESSALRM, pour introduire le nb. de # envoy�s
--

CREATE OR REPLACE PROCEDURE Stop_Alrm (Mess IN OUT VARCHAR2, Id NUMBER, AlGereeId NUMBER,
    SiteId NUMBER, EquipId NUMBER, LiaiId NUMBER, 
    AlarmCl VARCHAR2, AlarmNumObj NUMBER, AlarmNumal VARCHAR2, TsPrOper VARCHAR2)
/* Cette proc�dure est activ�e lorsqu'on "d�classe" une alarme (elle devient "fille")
   alors qu'elle �tait en cours.
   Il faut donc l'arr�ter.
*/

IS
    BindingId 	NUMBER;
    BindingType NUMBER;
    MessId	NUMBER;
    AlarmNomL	VARCHAR2 (40);
    AlarmType	NUMBER;
    SiteNom	VARCHAR2 (40);

BEGIN
    select SEQ_MESSALRM.NEXTVAL into MessId from dual;

--    Mess := CONCAT (Mess, '4#');
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
	    where SITE_ID = SiteId;	/* Pour Vid�o (signature alarme) */
    elsif (NOT (EquipId IS NULL)) then
	BindingId:=EquipId;
	BindingType:=4;
	select SITE_NOM into SiteNom
	    from EQUIP, SITE
	    where EQUIP_ID = EquipId and
		  EQUIP.SITE_ID = SITE.SITE_ID;	/* Pour Vid�o (signature alarme) */
    elsif (NOT (LiaiId IS NULL)) then
	BindingId:=LiaiId;
	BindingType:=5;
	SiteNom := ' ';
    else
	BindingId:=999;
	BindingType:=9;
	SiteNom := ' ';
    end if;

    Mess := CONCAT (Mess, BindingId);   Mess := CONCAT (Mess,  '#');  /* BindingId */
    Mess := CONCAT (Mess, BindingType); Mess := CONCAT (Mess,  '#');  /* BindingType */
    Mess := CONCAT (Mess, AlarmCl);    	Mess := CONCAT (Mess,  '#');  /* Classe : IS etc.. */
    Mess := CONCAT (Mess, AlarmNumObj);	Mess := CONCAT (Mess,  '#');  /* n�objet : IS */
    Mess := CONCAT (Mess, AlarmNumal); 	Mess := CONCAT (Mess,  '#');
    Mess := CONCAT (Mess, TsPrOper);	Mess := CONCAT (Mess,  '#');  /* Etat op�r. des prog. concern�s par l'alarme (<= 70) */ 

--insert into test values(seq_test.nextval, 'Stop_Alrm' || Mess);

    insert into MESSALRM (MESSALRM_ID, MESSALRM_MESS, MESSALRM_SENT, MESSALRM_NATURE)
	values (MessId, Mess, 0, 0);

-- dbms_lock.sleep (0.02); -- attendre que le pr�c�dent message soit �mis (20 ms.)  
-- dbms_alert.signal ('Alarme', Mess);
-- return;	/* Windows NT */

    select ALARMGEREE_NOM, ALARMGEREE_TYPAL
	into AlarmNomL, AlarmType
	from ALARMGEREE
	where ALARMGEREE_ID = AlGereeId;
/*
    mess_video (Mess, Id, null, AlGereeId, SiteId, EquipId, LiaiId, null, AlarmCl, AlarmNumObj, 
    	    AlarmType, '1998 01 01 00:00:00', 0, null, null, AlarmNumal, null, ' ', 
	    AlarmNomL, null, null, ' ', ' ', 0, SiteNom, ' ', null, null, '', '');
*/
END  Stop_Alrm;
/



create or replace
FUNCTION TsCoupe (NodeId NUMBER) RETURN BOOLEAN
IS	-- Retourne TRUE si tous les chemins issus du noeud sont coup�s

    Grave     NUMBER;	-- r�sultat d'une recherche locale : �tat op�rationnel
    Node      NUMBER;	-- Id du noeud suivant
    LiaiId    NUMBER; 	-- Id de la liaison suivante
    Ring      NUMBER; 	-- Si la liaison est de type anneau

BEGIN
-- dbms_output.put_line ('TsCoupe site '||to_char(NodeId));

    if (NodeId = 0) then
	     return FALSE;		-- r�cursion termin�e
    end if;

    select NEXT_S, LIAI_IDS, B.PROG_OPER_GRAVE
	    into Node, LiaiId, Grave
      from PROG_OPER A, PROG_OPER_REP B
	    where A.NODE_ID = NodeId and A.NODE_ID = B.NODE_ID;

    Grave := NVL (Grave, 0);

    if (Grave > 2) then		-- Non fonctionnel
	     return TRUE;
    end if;

    if (Node = 0 or Node is null) then
	     return FALSE;		-- On est arriv� au bout de la cha�ne
    end if;

    loop

    	select LIAI_OPER into Grave
    	    from LIAI_REP
    	    where LIAI_ID = LiaiId;

      Grave := NVL (Grave, 0);

    	-- JL le 25/01/2006 pour la supervision d'une liaison anneau
    	if (Node = NodeId) then

    		select TYPLIAI_RING into Ring
    		from TYPLIAI T, PROG_OPER P, LIAI L
    		where L.TYPLIAI_ID = T.TYPLIAI_ID
    		and L.LIAI_ID = P.LIAI_IDS
    		and P.NODE_ID = Node;

    		if (Ring = 1) then
    			if (Grave > 2) then
    				return TRUE;
    			else
    	    	return FALSE;
    			end if;
    		end if;
    	end if;
    	-- fin de maj

    	if (Grave <= 2 AND NOT TsCoupe (Node)) then
    	    return FALSE;	-- un des chemins, au moins, est passant
      end if;

    	select NEXT_P, LIAI_IDP
    	    into Node, LiaiId
                from PROG_OPER
    	    where NODE_ID = Node;

    	if (Node = 0) then
    	    return TRUE;
    	end if;
    end loop;

    return TRUE;

END TsCoupe;
/


CREATE OR REPLACE FUNCTION Max2 (A number, B number) RETURN NUMBER
IS

BEGIN
    if (A >= B) then
	return A;
    else
        return B;
    end if;
END Max2;
/


CREATE OR REPLACE FUNCTION Max3 (A number, B number, C number) RETURN NUMBER
IS

BEGIN
    if (A >= Max2 (B, C)) then
	return A;
    else
        return Max2 (B, C);
    end if;
END Max3;
/


CREATE OR REPLACE FUNCTION Max4 (A number, B number, C number, D number) RETURN NUMBER
IS

BEGIN
    if (A >= Max3 (B, C, D)) then
	return A;
    else
        return Max3 (B, C, D);
    end if;
END Max4;
/


------------------------------------------------------------------------------------------------
--
-- Mise � jour des �quipements suite � un c�blage
--
-- On met � jour EQUIP_TOSURV si n�cessaire.
-- On d�masque les alarmes de l'�quipement si n�cessaire.
-- Si n�cessaire signifie que l'�quipement est mis dans un c�blage pour la premi�re fois.
--
-- X.L. cr�ation le 28/11/03
--
------------------------------------------------------------------------------------------------
CREATE OR REPLACE PROCEDURE UpdateEquipAfterCablequ
(
	lCablequId IN NUMBER		-- ID du c�blage � ordonner
)
IS
	bTrouv	BOOLEAN;

	CURSOR CEquip IS		-- Liste des �quip. du CablEqu
		SELECT equip_id FROM cablequ_equip
		WHERE cablequ_id = lCablequId;

	CURSOR CCablequOther (lEquipId number) IS	-- Liste des autres c�blages de cet �quipement
		SELECT cablequ_id FROM cablequ_equip
		WHERE cablequ_id != lCablequId
		AND equip_id = lEquipId;

BEGIN
	FOR rCEquip IN CEquip LOOP
		bTrouv := FALSE;
		FOR rCCablequOther IN CCablequOther (rCEquip.Equip_ID) LOOP
			bTrouv := TRUE;
			EXIT;
		END LOOP;

		IF NOT bTrouv THEN
			update EQUIP set EQUIP_TOSURV = 1 where EQUIP_ID = rCEquip.EQUIP_ID;
			SetMaskAdmEquip (rCEquip.EQUIP_ID, 0);
		END IF;
	END LOOP;
END UpdateEquipAfterCablequ;
/



-- Fonction permettant de conna�tre le param�tre de calcul des �tats
-- op�rationnels (0 = standard, 1 = NEC).
CREATE OR REPLACE FUNCTION GetModCalc
RETURN NUMBER IS
	ModCalc	VARCHAR2 (2);
	
	CURSOR CurSel IS
		SELECT param_valeur FROM param WHERE param_type = 9 AND param_valeur like 'CALC_OBJ_OPER=%';

BEGIN
	FOR rCurSel IN CurSel LOOP
		ModCalc := SUBSTR (rCurSel.param_valeur, 15);
		IF ModCalc IS NOT NULL THEN
			RETURN TO_NUMBER (ModCalc);
		END IF;
		EXIT;
	END LOOP;
	RETURN 0;
END GetModCalc;
/


CREATE OR REPLACE FUNCTION GetOperElt (Grave NUMBER, AlarmLocal NUMBER, ModCalc NUMBER)
RETURN NUMBER IS
	OperElt	NUMBER;
BEGIN
    if (ModCalc = 0) then		-- Standard
	if (Grave >= 6 and AlarmLocal > 0)   then
		OperElt := 3;	/* Alarme locale majeure ou critique : non fonctionnel */
        elsif (Grave > 0 and AlarmLocal > 0) then
		OperElt := 2;	/* Alarme locale mineure : d�grad� suite � d�faut local */
        elsif (Grave > 0 and AlarmLocal = 0) then
		OperElt := 1;	/* Alarme distante : d�grad� suite � d�faut distant */
        else
		OperElt := 0;	/* Fin d'alarme */
        end if;
    else				-- Cas NEC
        if (Grave >= 6)   then
		OperElt := 3;	/* Alarme locale majeure ou critique : non fonctionnel */
        elsif (Grave > 4) then
		OperElt := 2;	/* Alarme locale mineure : d�grad� suite � d�faut local */
        elsif (Grave > 2) then
		OperElt := 1;	/* Alarme distante : d�grad� suite � d�faut distant */
        else
		OperElt := 0;	/* Fin d'alarme */
        end if;
    end if;

    return OperElt;

END GetOperElt;
/

--Cr�� par ZN le 10/01/08 
-- table alarm_prog contien tous les programes (actives et pas actives) concern�s par alarm
create or replace Procedure MajAlarmProg(AlarmId NUMBER, ProgId NUMBER)
is

  cnt NUMBER;
		
begin
    select count(*)  into cnt from alarm_prog where alarm_id=AlarmId 
	     and prog_id=ProgId;
	  
    if(cnt<1) then
	       insert into alarm_prog values (AlarmId, ProgId);
	  end if;

end MajAlarmProg;
/

-- Calcule TsPrOper 
-- ZN 5/11/07 
create or replace procedure FindTsPrOper
(
  ProgId   IN NUMBER,
  ModCalc  IN NUMBER,
  ErrWarn     BOOLEAN,	/* TRUE si une erreur */
  ErrMin	BOOLEAN,	/* TRUE si une erreur mineure existe */
  ErrMaj	BOOLEAN,	/* TRUE si une erreur majeure existe */
  ErrTs	BOOLEAN,	/* TRUE si tous les chemins sont coup�s entre un des noeuds*/
 -- OperElt IN OUT NUMBER,		/* Etat op�rationnel du site en cause */
  TsPrOper IN OUT VARCHAR2,
  Debord IN OUT NUMBER
)
IS
  OperProg	NUMBER;		/* Etat op�rationnel du programme :
					0 : tout va bien
					1 : erreurs mineures rencontr�es
					2 : perte de la redondance
					3 : non fonctionnel */
	OldOperProg NUMBER;		/* ancien �tat op�rationnel du programme */
	ProgMsk	NUMBER;		/* Etat de masquage du programme :
					0 : non masqu�
					1 : masquage brigadier
					2 : masquage administrateur */
BEGIN
 --   	insert into test values (SEQ_TEST.NEXTVAL, 'FindTsPrOper : ProgId = '||ProgId ||
 --     ' ModCalc = '|| ModCalc || ' OperElt = ' || OperElt  );

if (ModCalc = 0) then	-- Cas standard SPV
    	if (ErrTs  /*   or OperElt >= 3*/) then
    	  OperProg := 3;
    	elsif (ErrMaj /*or OperElt = 2*/) then
    	  OperProg := 2;
    	elsif (ErrMin /*or OperElt = 1*/) then
    	  OperProg := 1;
    	else
    	  OperProg := 0;
    	end if;
 --   	insert into test values (SEQ_TEST.NEXTVAL, 'FindTsPrOper : OperProg := ' || OperProg);

  else			-- Cas NEC
    	if (ErrTs or ErrMaj    /* or OperElt >= 3*/) then
    	    OperProg := 3;
    	elsif (ErrMin /* or OperElt = 2*/) then
    	    OperProg := 2;
    	elsif (ErrWarn /*or OperElt = 1*/) then
    	    OperProg := 1;
    	else
    	    OperProg := 0;
    	end if;
  end if;

  select B.PROG_OPER, PROG_MASQUE
    	    into OldOperprog, ProgMsk from PROG A, PROG_REP B
    	    where A.PROG_ID = ProgId and
    		  A.PROG_ID = B.PROG_ID;
    
  update PROG_REP set PROG_OPER = OperProg
    	    where PROG_ID = ProgId;

  if ((TsPrOper is NULL or length (TsPrOper) <= 800) and Debord = 0) then
    --	    ProgNb := ProgNb +1;
    	    TsPrOper := TsPrOper || to_char (ProgId) || ',' || to_char (OldOperProg) ||
    		    	',' || to_char (OperProg) || ',' || to_char (ProgMsk) || ';';
    		   --- insert into test values(TsPrOper);
  elsif (length (TsPrOper) > 800) then
    	    Debord := 1;
    	    ----insert into test values('debord=1');
  end if;

end FindTsPrOper;
/



--Calcule TsPrOper pour des programmes utilisants le site SiteId
-- ou pour des programmes utilisants une topologie utilisante le site SiteId.
--Cette procedure est appel� par MajOperSite, MajOperInclus, OperEnglob
-- et par TsPrOperTop.
--ZN 5/11/07
create or replace procedure TsPrOperProg
(
  ProgId   IN NUMBER,
  ModCalc  IN NUMBER,
--  OperElt IN OUT NUMBER,		--Etat op�rationnel du site en cause 
  TsPrOper IN OUT VARCHAR2,
  Debord IN OUT NUMBER
)
IS
  ErrWarn     BOOLEAN;	-- TRUE si une erreur 
  ErrMin	    BOOLEAN;	-- TRUE si une erreur mineure existe 
  ErrMaj	    BOOLEAN;	-- TRUE si une erreur majeure existe 
  ErrTs	      BOOLEAN;	-- TRUE si tous les chemins sont coup�s entre un des noeuds
				          ---origine et un noeud destination 
  Routage	    VARCHAR2 (40);	-- Permet de savoir si un routage est associ� au programme
  GraveProg   NUMBER;
  GraveLiai   NUMBER;
  Grave       NUMBER;
 
  
	/*CURSOR CurRes (Prog NUMBER) is	-- les r�seaux contenus dans le programme
	select unique PROG_OPER_RESEAU from PROG_OPER
	where PROG_ID = Prog;

  CURSOR CurProg2 (Prog NUMBER, Reseau NUMBER) is	-- les sites d'entr�e d'un programme
	select * from PROG_OPER
	where PROG_ID  = Prog and
	      PROG_OPER_RESEAU = Reseau and SITE_NUM = 1;*/
	      
	CURSOR CurProg2 (Prog NUMBER) is	-- les sites d'entr�e d'un programme
	select * from PROG_OPER
	where PROG_ID  = Prog and SITE_NUM = 1;
	
	CURSOR CurGraveProg (Prog NUMBER) is 
    select max(PROG_OPER_GRAVE) MAX from PROG_OPER_REP
	      where PROG_ID  = ProgId ;
	 
   CURSOR CurGraveLiai (Prog NUMBER) is     
  	    select max(LIAI_REP.LIAI_OPER) MAX from LIAI_REP, PROG_OPER
      	    where PROG_OPER.PROG_ID = Prog
            and (LIAI_REP.LIAI_ID = PROG_OPER.LIAI_IDS
            or LIAI_REP.LIAI_ID = PROG_OPER.LIAI_IDP);

	 
	Active NUMBER;

BEGIN
  ErrWarn := FALSE;
  ErrMin := FALSE;
  ErrMaj := FALSE;
  ErrTs  := FALSE;

  select PROG_ROUTAGE, prog_actif into Routage, Active
    	    from PROG
    	    where PROG_ID = ProgId;
    	    
  GraveProg :=0;
  GraveLiai :=0;

  
  if(Active>0) then
--  	if (Routage is NULL) then		-- Pas de routage
 --     for vRes in CurRes (ProgId) loop
      
      for vGraveProg in CurGraveProg (ProgId) loop 
        GraveProg := vGraveProg.MAX;
      end loop;
      
      for vGraveLiai in CurGraveLiai (ProgId) loop 
        GraveLiai := vGraveLiai.MAX;
      end loop;
      
      Grave := Max2(GraveProg, GraveLiai);
	      
      if(	 Grave>0  ) then
                   --   	for vProg2 in CurProg2 (ProgId, vRes.PROG_OPER_RESEAU) loop 
        for vProg2 in CurProg2 (ProgId) loop 
        -- boucle sur tous les sites d'entr�e du programme
          	
       	  ErrTs   := ErrTs  or TsCoupe (vProg2.NODE_ID);
       	  if(ErrTs) then
       	    exit;
       	  end if;
       	end loop;	-- boucle sur les sites d'entr�e du programme
        if(ErrTs=FALSE)then
            if (Grave > 2) then
              ErrMaj  := TRUE;
            else
              ErrMin := ((ModCalc <>0 ) and (Grave > 1)) or ((ModCalc =0 ) and (Grave > 0));
              ErrWarn := (ErrMin=false) and (ModCalc <>0 ) and (Grave > 0);
            end if;
        end if; --if(ErrTs=FALSE)
     --     end loop;	-- boucle sur les sites d'entr�e du programme
   --   end loop;		-- boucle sur les r�seaux du programme
      end if; --if(	 Grave=0 )
      
  /*	else --Routage
  	  -- en cas de routage, on ne calcule pas la connexit� (celle-ci d�pend du routage)
  	  select max (PROG_OPER_GRAVE) into OperElt
  		    from PROG_OPER_REP 	where PROG_ID = ProgId;
  	end if;		-- si pas de routage*/
/*  else --non active
    OperElt:=0;*/
  end if;

 /* FindTsPrOper(ProgId, ModCalc, ErrWarn, ErrMin, ErrMaj, ErrTs,	OperElt,
              TsPrOper, Debord);*/
    FindTsPrOper(ProgId, ModCalc, ErrWarn, ErrMin, ErrMaj, ErrTs,	
              TsPrOper, Debord);
    	
end TsPrOperProg;
/



--MAJ la table  PROG_OPER_REP pour des programmes utilisants le site SiteId
-- ou pour des programmes utilisants une topologie utilisante le site SiteId.
--Cette procedure est appel� par MajOperSite et par UpdateProgOperTop.
--ZN 5/11/07
CREATE OR REPLACE PROCEDURE UpdateProgOperProg
(
  ProgId  IN NUMBER,
  SiteId  IN NUMBER,
  AlarmId IN NUMBER,
  OperElt IN OUT NUMBER		/* Etat op�rationnel du site en cause */
)
IS

    OperEqu	NUMBER;		/* Max. �tat op�r. des CABLEQU du programme dans ce site */
 --   OperTop NUMBER;   /*Max. �tat op�r. des CABLEQU des topologies, utilis�es  par le programme dans ce site */
    Active NUMBER;
BEGIN

  select prog_actif into Active from prog where prog_id=ProgId;
  if(Active>0) then
    select max (PROG_CABL_GRAVE) into OperEqu
  	from PROG_CABL_REP
  	where PROG_ID = ProgId and SITE_ID = SiteId;
    -- alarmes des �quipements (�tat oper)
  	OperEqu := NVL (OperEqu, 0);
  
  	OperElt := Max2 (OperElt, OperEqu);
  	
 -- 	OperTop := FindOperTopProg(ProgId, SiteId);
--	OperElt := Max2 (OperElt, OperTop);
  else --prog non active
    OperElt := 0;
  end if;

	update PROG_OPER_REP
	  set PROG_OPER_GRAVE = OperElt
	  where PROG_ID = ProgId and  SITE_ID = SiteId;	

  MajAlarmProg(AlarmId, ProgId);
  
END UpdateProgOperProg;
/

--
--	Modif JPB le 02/10/06 : reprise du traitement concernant TsPrOper
--
-- Modif. ZN le 6/11/07 prend en compte d'inclusion des topologies
--
CREATE OR REPLACE PROCEDURE MajOperSite 
		(Id NUMBER, SiteId NUMBER, AlarmLocal NUMBER, AlarmGrave NUMBER,
		 ProgNb IN OUT NUMBER,
		 SiteNom IN OUT VARCHAR2, Poseq IN OUT VARCHAR2,
     TsPrOper IN OUT VARCHAR2, Debord IN OUT NUMBER)
	/* Cette proc�dure met � jour l'�tat op�rationnel du site en d�faut,
	   ainsi que l'�tat op�rationnel des programmes que cela concerne 
	AlarmGrave : gravit� alarme */
IS
    OperElt	NUMBER;		/* Etat op�rationnel du site en cause */
    Grave	NUMBER;		/* Gravit� des alarmes restantes */
    GraveS	NUMBER;		/* Gravit� restante pour des alarmes SEM */

    Routage	VARCHAR2 (40);	-- Permet de savoir si un routage est associ� au programme
   ModCalc	NUMBER;

 	  
	CURSOR CurProg is
	  select distinct Prog_id from PROG_usedsites  where SITE_ID = SiteId;
	 

BEGIN
    ModCalc := GetModCalc;		-- Mode de calcul standard ou NEC

    -- Mise � jour de SiteNom et Poseq

    select SITE_NOM, SITE_NOM into SiteNom, Poseq
	       from SITE where SITE_ID = SiteId;	

    -- Mise � jour de l'�tat op�rationnel du site

    select MAX (ALARMGEREE_GRAVE) into Grave from ACCES_ACCESC_REP
	     where SITE_ID = SiteId and  ALARM_ID <> Id;
		-- Valeur de la gravit� � prendre en compte en d�but d'alarme
	        -- on regarde les autres alarmes
    Grave := NVL (Grave, 0); 
		-- Retomb�e d'alarme, cas o� il n'y a pas d'autre alarme pour ce site
		-- (SITE_ID est NULL)

 /*   select MAX (ALARMGEREE_GRAVE) into GraveS from BITMESS, BITMESS_REP
  	where BITMESS_REP.SITE_ID = SiteId and   
	      BITMESS_REP.ALARM_ID <> Id and
	      BITMESS.BITMESS_ID = BITMESS_REP.BITMESS_ID;
		-- Valeur de la gravit� � prendre en compte en d�but d'alarme
		-- on regarde les autres alarmes
    GraveS := NVL (GraveS, 0); */
		-- Retomb�e d'alarme, cas o� il n'y a pas d'autre alarme pour ce site
		-- (SITE_ID est NULL)

    --Grave := Max3 (Grave, GraveS, AlarmGrave);
    Grave := Max2 (Grave, AlarmGrave);

    OperElt := GetOperElt (Grave, AlarmLocal, ModCalc);

    update SITE_REP
	     set SITE_OPER = OperElt	where SITE_ID = SiteId;
    -- Mise � jour de l'�tat op�rationnel de tous les programmes qui utilisent ce site

  --  for vProg in CurProgOper loop
  for vProg in CurProg loop
      UpdateProgOperProg(vProg.PROG_ID, SiteId, Id, OperElt);
	 end loop;
    
 /*   for vTop in CurTop loop
      UpdateProgOperTop(vTop.top_id, SiteId, Id, OperElt);
    end loop;*/

    ProgNb   := 0;

    -- 70 prog. au max. Structure : ProgId, OldOper, ProgOper, ProgMsk; ProgId, 
    -- OldOper, ProgOper, ProgMsk; etc... 

    for vProg in CurProg loop --tous les programmes utilisant ce SiteId
       TsPrOperProg(vProg.PROG_ID, ModCalc,/* OperElt,*/ TsPrOper, Debord);
    end loop;		-- boucle sur les programmes affect�s par cette erreur
    
 /*   for vTop in CurTop loop
  --  insert into test values(seq_test.nextval, 'MajOperSite top_id ' || vTop.top_id);
      TsPrOperTop(vTop.top_id, ModCalc, OperElt, TsPrOper, Debord);
    end loop;*/
    
--    TsPrOper := to_char (ProgNb) || ';' || TsPrOper;

END MajOperSite;
/



CREATE OR REPLACE FUNCTION OperSupport (LiaiId NUMBER, OperElt NUMBER)	
RETURN NUMBER
	/* Cette proc�dure calcule la gravit� des supports :
	Une liaison est vue en tant que telle (ex. 30N 007). Elle peut �tre
	coup�e parce que un de ses supports est coup�.
	A l'oppos�, un "sous-�quipement" n'est pas utilis� directement
	(on met un �quipement dans un c�blage). Un �quipement peut �tre en panne
	parce que un de ses sous-�quipements est en panne.

	OperElt : �tat op�rationnel de la liaison */

IS

    lOper 	NUMBER;

    CURSOR cSup is		-- recherche du support
	select * from LIAI_LIAIC
	    where LIAI_ID = LiaiId;

BEGIN

    lOper := OperElt;
-- dbms_output.put_line ('OPERSUPPORT LiaiId '||to_char(LiaiId)||' OperElt '||to_char(OperElt));

    for vSup in cSup loop	-- recherche du support
	select LIAI_OPER into lOper
	    from LIAI_REP
	    where LIAI_ID = vSup.LIAI_BINDINGID;
	lOper := NVL (lOper, 0);

	lOper := Max2 (lOper, OperElt);

	lOper := OperSupport (vSup.LIAI_BINDINGID, lOper);	
    end loop;

    return lOper;
END	OperSupport;
/


CREATE OR REPLACE PROCEDURE MajOperSupte (Id NUMBER, LiaiId NUMBER, OperL NUMBER, 
					  AlarmLocal NUMBER)
	/* Cette proc�dure met � jour l'�tat des support�s,
	en tenant compte de l'�tat des supports pr�c�dents (OperL) */
	-- Id : Id de l'alarme
	-- OperL : �tat op�rationnel de la liaison, provenant des supports

IS 
    OperElt	NUMBER;		-- �tat du support�
    lGrave	Number;		-- gravit� banale
    OwnGrave	Number;		-- gravit� alarmes propres au support�
  --  OwnGraveS	Number;		-- idem pour SEM

    CURSOR cSupte is	-- ensemble des support�s de LiaiId
	select * from LIAI_LIAIC
	    where LIAI_BINDINGID = LiaiId;

BEGIN
/* dbms_output.put_line ('MAJSUPTE DEBUT OperL '||to_char(OperL)||' Local '||
to_char(AlarmLocal)||' LiaiId '||to_char (LiaiId)||' Id '||to_char(Id)); */

    for vSupte in cSupte loop
    	select MAX (ALARMGEREE_GRAVE) into OwnGrave from ACCES_ACCESC_REP
	    where LIAI_ID = vSupte.LIAI_ID and   
				-- Valeur de la gravit� � prendre en compte en d�but d'alarme
	      	  ALARM_ID <> Id;   -- on regarde les autres alarmes
    	OwnGrave := NVL (OwnGrave, 0);

  /*      select MAX (ALARMGEREE_GRAVE) into OwnGraveS from BITMESS, BITMESS_REP
	    where BITMESS_REP.LIAI_ID = vSupte.LIAI_ID and 	 
				-- Valeur de la gravit� � prendre en compte en d�but d'alarme
	      	  BITMESS_REP.ALARM_ID <> Id and
				-- on regarde les autres alarmes
		  BITMESS.BITMESS_ID = BITMESS_REP.BITMESS_ID;
    	OwnGraveS := NVL (OwnGraveS, 0); 

    	lGrave := Max2 (OwnGrave, OwnGraveS);*/
    	
    	lGrave := OwnGrave;

    	if (lGrave >= 6 and AlarmLocal > 0)   then
	    OperElt:= 3;	/* Alarme locale majeure ou critique : non fonctionnel */
    	elsif (lGrave > 0 and AlarmLocal > 0) then
	    OperElt:= 2;	/* Alarme locale mineure : d�grad� suite � d�faut local */
    	elsif (lGrave > 0 and AlarmLocal = 0) then
	    OperElt:= 1;	/* Alarme distante : d�grad� suite � d�faut distant */
    	else
	    OperElt:= 0;	/* Fin d'alarme */
    	end if;

	OperElt := Max2 (OperL, OperElt);

        update LIAI_REP
	    set LIAI_OPER = OperElt
	    where LIAI_ID = vSupte.LIAI_ID;

--	insert into SUPTES_TEMP (ALARM_ID, LIAI_ID, GRAVE) values (Id, vSupte.LIAI_ID, lGrave);

	MajOperSupte (Id, vSupte.LIAI_ID, OperElt, AlarmLocal);
    end loop;
END MajOperSupte;
/



---------------------------------------------
--
-- GG	Modif. le 22/07/03	Poseq est la concat�nation
--				de la ville et du point de l'extr�mit� 
--				EXT.EXT_VILLE || ' ' || EXT.EXT_POINT
--
--	Modif JPB le 02/10/06 : reprise du traitement concernant TsPrOper
--
-- Modif. ZN le 6/11/07 prend en compte d'inclusion des topologies
--
---------------------------------------------

CREATE OR REPLACE PROCEDURE MajOperLiai 
		(Id NUMBER, LiaiId NUMBER, AlarmLocal NUMBER, AlarmGrave NUMBER, 
		 ProgNb IN OUT NUMBER, Typeq IN OUT VARCHAR2, Poseq IN OUT VARCHAR2,
     TsPrOper IN OUT VARCHAR2, Debord IN OUT NUMBER)
		 		 
	/* Cette proc�dure met � jour l'�tat op�rationnel de la liaison en d�faut	   

	Id	   : Id de l'alarme
	LiaiId	   : Id de la liaison trait�e
	AlarmGrave : gravit� alarme	*/

IS

    OperElt	NUMBER;		/* Etat op�rationnel de la liaison en cause */

    Grave	NUMBER;		/* Gravit� des alarmes restantes */
 --   GraveS	NUMBER;		/* Gravit� banale (BitMess etc..) */

    SiteId	NUMBER;		/* Id du site contenant l'�quipement en d�faut */
    SiteIndex	NUMBER;		/* Index de ce site */

    ModCalc	NUMBER;		/* Mode de calcul (standard ou NEC) */

/*  CURSOR CurProg is			-- les programmes concern�s par cette liaison en alarme
	select distinct PROG.PROG_ID, GRAVE
	    from PROG_usedliais, SUPTES_TEMP, PROG
	    where ALARM_ID = Id and
		  PROG_usedliais.LIAI_ID = SUPTES_TEMP.LIAI_ID and
		  PROG_usedliais.PROG_ID = PROG.PROG_ID and
		  PROG_LIAIBOUND is NULL;*/
		  
		  CURSOR CurProg is			-- les programmes concern�s par cette liaison en alarme
	select PROG_ID from PROG_usedliais  where Liai_id=LiaiId;   
		  
/*	CURSOR CurTop is			-- les topologies concern�es par cette liaison en alarme
  select TOP_ID, GRAVE
	    from top_LIAI, SUPTES_TEMP
	    where ALARM_ID = Id and
		  top_LIAI.LIAI_ID = SUPTES_TEMP.LIAI_ID ;*/
		  

BEGIN
--  insert into test values (SEQ_TEST.NEXTVAL, 'MAJOPERLIAI : LiaiId '||to_char(LiaiId));

    ModCalc := GetModCalc;		-- Mode de calcul standard ou NEC

    -- Mise � jour de Poseq et Typeq
    -- Modif. GG le 22/07/03
    -- Modif. JPB le 01/11/03. Voir remarque V 1.087

    select GetLiaiNom (LiaiId), TYPLIAI_NOM
	   into Poseq, Typeq 	from LIAI
	   where LIAI_ID = LiaiId;
    -- Mise � jour de l'�tat op�rationnel de la liaison

    select MAX (ALARMGEREE_GRAVE) into Grave from ACCES_ACCESC_REP
	     where LIAI_ID = LiaiId and ALARM_ID <> Id;  
		-- Valeur de la gravit� � prendre en compte en d�but d'alarme
 		-- on regarde les autres alarmes
    Grave := NVL (Grave, 0);

  /*  select MAX (ALARMGEREE_GRAVE) into GraveS from BITMESS, BITMESS_REP
	   where BITMESS_REP.LIAI_ID = LiaiId and 	 
	      BITMESS_REP.ALARM_ID <> Id and
	      BITMESS.BITMESS_ID = BITMESS_REP.BITMESS_ID;
		-- Valeur de la gravit� � prendre en compte en d�but d'alarme
 		-- on regarde les autres alarmes
    GraveS := NVL (GraveS, 0); */

   -- Grave := Max3 (Grave, GraveS, AlarmGrave);	-- cas d'une panne des �quips. de multiplexage
   Grave := Max2 (Grave, AlarmGrave);	-- cas d'une panne des �quips. de multiplexage

    OperElt := GetOperElt (Grave, AlarmLocal, ModCalc);

    -- Prendre en compte l'�tat op�rationnel des supports

    OperElt := Max2 (OperElt, OperSupport (LiaiId, OperElt));

    update LIAI_REP
	     set LIAI_OPER = OperElt	where LIAI_ID = LiaiId;

    -- Mise � jour de l'�tat op�rationnel des support�s

--    insert into SUPTES_TEMP (ALARM_ID, LIAI_ID, GRAVE) values (Id, LiaiId, Grave);

    MajOperSupte (Id, LiaiId, OperElt, AlarmLocal);

    -- Mise � jour de l'�tat op�rationnel de tous les programmes qui utilisent cette liaison
    -- (ou l'un de ses support�s) dans le site o� elle aboutit

-- ZN. l'etat operationelle des cablages n'est pas chang�, inutille de calculer PROG_CABL_REP.prog_oper_grave

 /*       select SITE_DESTID into SiteId
	   from LIAI	where LIAI_ID = LiaiId;

  select SITE_OPER into OperElt
	       from SITE_REP where SITE_ID = SiteId;
	  OperElt := NVL (OperElt, 0);

  for vProg in CurProg loop
	    UpdateProgOperProg(vProg.Prog_Id, SiteId, Id, OperElt);
    end loop;	*/
    
    
  /*  for vTop in CurTop loop
	    UpdateProgOperTop(vTop.TOP_ID, SiteId, Id, OperElt);
    end loop;	*/	

    ProgNb   := 0;
--    TsPrOper := '';  -- 70 prog. au max. Structure : NbProg; ProgId, OldOper, ProgOper, ProgMsk; 
--			ProgId, OldOper, ProgOper, ProgMsk; etc...
--    Debord   := 0;

    for vProg in CurProg loop
      MajAlarmProg(Id, vProg.PROG_ID);
    	TsPrOperProg(vProg.PROG_ID, ModCalc, /* OperElt,*/ TsPrOper, Debord);
    end loop;		-- boucle sur les programmes affect�s par cette erreur

 --   TsPrOper := to_char (ProgNb) || ';' || TsPrOper;
 
/*    for vTop in CurTop loop
      TsPrOperTopLiai(vTop.top_id, SiteId, ModCalc, OperElt, TsPrOper, Debord);
    end loop;*/

 --   delete SUPTES_TEMP where ALARM_ID = Id;
END MajOperLiai;
/

-- Modif. X.L. le 21/07/06 : pass� LPrOper � une taille de 900 au lieu de 450; en effet, quand il y a un grand
-- nombre de concern�s, il y a d�bordement. Ceci dit cela ne suffit pas => � revoir.
--
--	Modif JPB le 02/10/06 : reprise du traitement concernant TsPrOper
--
-- Modif. ZN le 6/11/07 prend en compte d'inclusion des topologies

CREATE OR REPLACE FUNCTION MajOperInclus 
		(Id NUMBER, EquipId NUMBER, AlarmGrave NUMBER, AlarmLocal NUMBER,
		 ProgNb IN OUT NUMBER, TsPrOper IN OUT VARCHAR2, Debord IN OUT NUMBER)
RETURN NUMBER 
IS
	/* Cette fonction met � jour l'�tat op�rationnel de l'�quipement 
	   en tenant compte des �quipements inclus dans l'�quip. en d�faut.
	   Elle met aussi � jour l'�tat op�rationnel des CABLEQU et des programmes 
	   que cela concerne.
	   Retourne la gravit� correspondante.

	Id	   : Id de l'alarme
	EquipId	   : Id de l'�quipement trait�
	AlarmGrave : gravit� alarme
	ProgNb	   : nb. programmes concern�s par cette alarme
	TsPrOper   : cha�ne d�crivant l'�tat op�rationnel de ces programmes */

    OperElt	NUMBER;		/* Etat op�rationnel de l'�lt. g�r� en cause */
    Grave	NUMBER;		/* Gravit� des alarmes restantes */
  --  GraveS	NUMBER;		/* Gravit� restante pour des alarmes SEM */
    GraveI	NUMBER;		/* Max de la gravit� des alarmes des �quipements inclus */

    SiteId	NUMBER;		/* Id du site de l'�quipement en d�faut */
    OperSite	NUMBER;		/* Etat op�r. de ce site */
 /*   OperProg	NUMBER;		-- Etat op�rationnel du programme :
			--		0 : tout va bien
			--		1 : erreurs mineures rencontr�es
			--		2 : perte de la redondance
			--		3 : non fonctionnel 
    OldOperProg NUMBER;		-- ancien �tat op�rationnel du programme 
    ProgMsk	NUMBER;		-- Etat de masquage du programme :
				--	0 : non masqu�
			--		1 : masquage brigadier
			--		2 : masquage administrateur 

    ErrWarn	BOOLEAN;	-- TRUE si une erreur existe 
    ErrMin	BOOLEAN;	-- TRUE si une erreur mineure existe 
    ErrMaj	BOOLEAN;	-- TRUE si une erreur majeure existe 
    ErrTs	BOOLEAN;	-- TRUE si tous les chemins sont coup�s entre un des noeuds
				   --origine et un noeud destination 
*/
    ModCalc	NUMBER;		/* Mode de calcul standard ou NEC */

    LProgNb	NUMBER;		/* Nb. de programmes correspondant � des liaisons en panne 
				(mpx) */
--    LPrOper	VARCHAR2 (450); /* Etat op�rationnel de ces liaisons */
    LPrOper	VARCHAR2 (900); /* Etat op�rationnel de ces liaisons */

    LTypeq	VARCHAR2 (40);	/* Sauvegarde de TypEqu */
    LPoseq	VARCHAR2 (80);	/* Sauvegarde de Poseq */

    Buf		VARCHAR2 (100); -- banal
 --   Routage	VARCHAR2 (40);	-- Permet de savoir si un routage est associ� au programme

    --PROG_CABL contienne tous les c�blages utilis�s par le programme, y compris des c�blages
    --de topologie. C'est vrai aussi pour des programmes rout�s
    CURSOR CurProg is			-- les programmes utilisant cet �quip. dans un c�blage
	select distinct PROG_ID from CABLEQU_EQUIP, PROG_CABL
	    where CABLEQU_EQUIP.EQUIP_ID = EquipId and
		  CABLEQU_EQUIP.CABLEQU_ID = PROG_CABL.CABLEQU_ID;

/*		  
		CURSOR CurTop is
		select TOP_ID from CABLEQU_EQUIP, TOP_CABLEQU
	    where CABLEQU_EQUIP.EQUIP_ID = EquipId and
		  CABLEQU_EQUIP.CABLEQU_ID = TOP_CABLEQU.CABLEQU_ID;*/

    CURSOR CurCablequ is		-- les c�blages utilisant cet �quipement
	select CABLEQU_ID from CABLEQU_EQUIP
	    where EQUIP_ID = EquipId;

  /*  CURSOR CurProg1 (Idl NUMBER) is	-- tous les prog. concern�s par ce c�blage
					-- (prestations + liaisons support)
	select * from PROG_CABL
	where CABLEQU_ID = Idl;*/
	
/*	CURSOR CurTopCabl (Idl NUMBER) is --tous les topo concern�es par ce c�blage
		select * from TOP_CABLEQU
	    where CABLEQU_ID = Idl;*/

/*    CURSOR CurProg2 (Prog NUMBER) is	-- les sites d'entr�e d'un programme
	select * from PROG_OPER
	where PROG_ID  = Prog and
	      SITE_NUM = 1;*/

    CURSOR CurLiai (Idl NUMBER) is	-- les liaisons concern�es par ce c�blage
	select LIAI_ID from LIAI_CABLEQU, CABLEQU_EQUIP
	where LIAI_CABLEQU.CABLEQU_ID = CABLEQU_EQUIP.CABLEQU_ID and
	      EQUIP_ID = Idl;

    CURSOR CurInclus is			-- les �quipements inclus dans cet �quipement
	select EQUIP_ID from EQUIP
	    where EQUIP_BINDINGID = EquipId;
	    
	CURSOR CurProgCabl (Idl NUMBER) is	-- tous les prog. concern�s par ce c�blage
	select distinct prog_id from PROG_CABL
	where CABLEQU_ID = Idl;

BEGIN

    ModCalc := GetModCalc;		-- Mode de calcul standard ou NEC
--  insert into test values (SEQ_TEST.NEXTVAL, 'MAJOPERINCLUS : Id, EquipId '||to_char(Id)||'; '||to_char(EquipId));

    -- Mise � jour de l'�tat op�rationnel de l'�quipement

    Grave := 0;
    select MAX (ALARMGEREE_GRAVE) into Grave from ACCES_ACCESC_REP
        where EQUIP_ID = EquipId and 
	      ALARM_ID is not NULL; 
		-- Valeur de la gravit� � prendre en compte en d�but d'alarme
 		-- on regarde les autres alarmes
 		-- on regarde les alarmes en cours sur cet �quip.
    Grave := NVL (Grave, 0);

 /*   select MAX (ALARMGEREE_GRAVE) into GraveS from BITMESS, BITMESS_REP
	   where BITMESS_REP.EQUIP_ID = EquipId and   
	      BITMESS_REP.ALARM_ID is not NULL and
	      BITMESS.BITMESS_ID = BITMESS_REP.BITMESS_ID;
		-- Valeur de la gravit� � prendre en compte en d�but d'alarme
 		-- on regarde les autres alarmes
 		-- on regarde les alarmes en cours sur cet �quip.
    GraveS := NVL (GraveS, 0); */

    GraveI := 0;
    select PARAM_VALEUR into Buf  from PARAM
	   where PARAM_VALEUR like 'ALARM_ENGLOB%';

    if (INSTR (Buf, 'true') > 0) then  -- il faut tenir compte des englobants / englob�s
  /*      CURSOR CurInclus is			-- les �quipements inclus dans cet �quipement
	select EQUIP_ID from EQUIP
	    where EQUIP_BINDINGID = EquipId;*/
    	for vInc in CurInclus loop
    	    GraveI := Max2 (GraveI, MajOperInclus (Id, vInc.EQUIP_ID, AlarmGrave, AlarmLocal, ProgNb, TsPrOper, Debord));
    	end loop;
    end if;

   -- Grave := Max3 (Grave, GraveS, GraveI);
    Grave := Max2 (Grave, GraveI);
    
    OperElt := GetOperElt (Grave, AlarmLocal, ModCalc);

    update EQUIP_REP	set EQUIP_OPER = OperElt
	     where EQUIP_ID = EquipId;		-- le max des alarmes sur cet �quipement

    select SITE_ID into SiteId from EQUIP
	     where EQUIP_ID = EquipId;

    select SITE_OPER into OperSite	from SITE_REP
	     where SITE_ID = SiteId;
    
    OperSite := NVL (OperSite, 0);

    -- Mise � jour de l'�tat op�rationnel de tous les programmes qui utilisent cet �quipement

    for vCabl in CurCablequ loop    -- boucle sur tous les CABLEQU qui contiennent l'�quipement

    	select max (EQUIP_OPER) into OperElt	-- max. Oper pour les �quipements du CABLEQU
    	    from EQUIP_REP, CABLEQU_EQUIP
    	    where  CABLEQU_EQUIP.CABLEQU_ID = vCabl.CABLEQU_ID and
    		   CABLEQU_EQUIP.EQUIP_ID = EQUIP_REP.EQUIP_ID;
    
    	OperElt := NVL (OperElt, 0);		--  OperElt : �tat op�rationnel 
    	                                -- max �tat operationnel du cablage
    
    	OperElt := Max2 (OperElt, OperSite);
    
      --pour des cablages des programmes ou des cablages des topologies ou des cablages de liaisons 
     	update PROG_CABL_REP
    	    set PROG_CABL_GRAVE = OperElt
    	    where CABLEQU_ID = vCabl.CABLEQU_ID;
    	    
      
   /*   CURSOR CurProgCabl (Idl NUMBER) is	-- tous les prog. concern�s par ce c�blage
	select distinct prog_id from PROG_CABL
	where CABLEQU_ID = Idl;*/
	
      for vCurProgCabl in CurProgCabl(vCabl.CABLEQU_ID) loop --tous les programmes concern�es par ce c�blage 
    		UpdateProgOperProg(vCurProgCabl.PROG_ID, SiteId, Id, OperElt);
    	end loop;
    	
  /*    -- Mise � jour de l'�tat op�rationnel de tous les programmes qui utilisent
      -- des  topologies qui utilisent cet �quipement
    	for vCurTopCabl in CurTopCabl (vCabl.CABLEQU_ID) loop --tous les topo concern�es par ce c�blage
		    UpdateProgOperTop(vCurTopCabl.top_id, SiteId, Id, OperElt);
      end loop;*/

	-- Pour chacun des programmes qui utilisent cet �quipement, OperElt repr�sente son
	-- �tat op�rationnel, en tenant compte aussi des alarmes de site.
	-- Les alarmes de liaisons inter-sites seront prises en compte dans le 
	-- traitement suivant, qui consid�re aussi les redondances �ventuelles.
    end loop; --CurCablequ

    -- 70 prog. au max. Structure : ProgId, OldOper, ProgOper, ProgMsk; ProgId, 
    -- OldOper, ProgOper, ProgMsk; etc... 

 /*  CURSOR CurProg is			-- les programmes utilisant cet �quip. dans un c�blage
	select distinct PROG_ID from CABLEQU_EQUIP, PROG_CABL
	    where CABLEQU_EQUIP.EQUIP_ID = EquipId and
		  CABLEQU_EQUIP.CABLEQU_ID = PROG_CABL.CABLEQU_ID;*/

    for vProg in CurProg loop -- les programmes de utilisant cet �quip. dans un c�blage
      OperElt := 0;

   -- 	insert into test values (SEQ_TEST.NEXTVAL, 'MAJOPERINCLUS : PROG_ID = '||vProg.PROG_ID);

      TsPrOperProg(vProg.PROG_ID, ModCalc, /*OperElt,*/ TsPrOper, Debord);
    end loop;		-- boucle sur les programmes affect�s par cette erreur
    
 /*   for vTop in CurTop loop
      OperElt:=0;
  --    insert into test values (SEQ_TEST.NEXTVAL, 'MAJOPERINCLUS : top_ID = '||vTop.top_id);

      TsPrOperTop(vTop.top_id, ModCalc, OperElt, TsPrOper, Debord);
    end loop;*/

    LProgNb := 0;
    LPrOper := '';

--    for vCabl in CurCablequ loop    -- boucle sur tous les CABLEQU qui contiennent l'�quipement
/*
      for vLiai in CurLiai (EquipId) loop 	-- boucle sur les liaisons concern�es par ce c�blage
						-- cas des �quipements de multiplexage
	     MajOperLiai (Id, vLiai.LIAI_ID, AlarmLocal, AlarmGrave, LProgNb, LTypeq, LPoseq, LPrOper, Debord);
--	    ProgNb  := ProgNb + LProgNb;
--	    LPrOper := SUBSTR (LPrOper, INSTR (LPrOper, ';') +1);

 	    if ((TsPrOper is NULL or length (TsPrOper) <= 800) and Debord = 0) then
  		      TsPrOper := TsPrOper || LPrOper;
  	    else
  		      Debord := 1;
  	    end if;
      end loop;
*/--les etats operationelles des liaisons ne sont pas chang�s, 
--l'etat des cablages des liaisons est deja pris en compte
--    end loop;

    return Grave;
     
END MajOperInclus;
/



--
--	Modif JPB le 02/10/06 : reprise du traitement concernant TsPrOper
--
-- Modif. ZN le 6/11/07 prend en compte d'inclusion des topologies
--
create or replace
PROCEDURE OperEnglob (AlarmGrave NUMBER, EquipId NUMBER, AlarmLocal NUMBER,
					ProgNb IN OUT NUMBER, TsPrOper IN OUT VARCHAR2, Debord IN OUT NUMBER)
IS
	/* Signale � l'englobant un changement de l'�tat op�rationnel d'un �quipement inclus.
	Modifie en cons�quence l'�tat op�rationnel de l'englobant, afin que son affichage
	soit correct.
	Ne modifie pas l'�tat op�rationnel des programmes utilisant l'englobant,
	car ces programmes ne sont pas affect�s.   A REVOIR

	AlarmGrave : gravit� max. de l'�quipement inclus (et de ses sous-�quipements)
	EquipId	   : Id de l'englobant
	AlarmLocal : pr�cise si l'alarme est locale ou vient du distant (SIA par exemple) */

    Grave	NUMBER;		/* Gravit� des alarmes restantes */
 --   GraveS	NUMBER;		/* Gravit� restante pour des alarmes SEM */
    OperElt	NUMBER;		/* Etat op�rationnel de l'�lt. g�r� en cause */
    BindingId	NUMBER;		/* Id de l'englobant de EquipId. 0 si fini */


    OperSite	NUMBER;		/* Etat op�r. de ce site */
 /*  ErrWarn	BOOLEAN;	--TRUE si une erreur existe
    ErrMin	BOOLEAN;	-- TRUE si une erreur mineure existe
    ErrMaj	BOOLEAN;	-- TRUE si une erreur majeure existe
   ErrTs	BOOLEAN;	-- TRUE si tous les chemins sont coup�s entre un des noeuds
				--origine et un noeud destination */

    ModCalc	NUMBER;		/* Mode de calcul standard ou NEC */

--    OperProg	NUMBER;		--Etat op�rationnel du programme :
				--	0 : tout va bien
				--	1 : erreurs mineures rencontr�es
				--	2 : perte de la redondance
				--	3 : non fonctionnel
--    OldOperProg NUMBER;		/* ancien �tat op�rationnel du programme */
--    ProgMsk	NUMBER;		 Etat de masquage du programme :
				--	0 : non masqu�
				--	1 : masquage brigadier
				--	2 : masquage administrateur

  --  Routage	VARCHAR2 (40);	-- Permet de savoir si un routage est associ� au programme

    CURSOR CurProg is			-- les programmes utilisant cet �quip. dans un c�blage
	select distinct PROG_ID from CABLEQU_EQUIP, PROG_CABL
	    where CABLEQU_EQUIP.EQUIP_ID = EquipId and
		  CABLEQU_EQUIP.CABLEQU_ID = PROG_CABL.CABLEQU_ID ;


 /*   CURSOR CurTop is
    select TOP_ID from CABLEQU_EQUIP, TOP_CABLEQU
	    where CABLEQU_EQUIP.EQUIP_ID = EquipId and
		  CABLEQU_EQUIP.CABLEQU_ID = top_CABLEQU.CABLEQU_ID;*/

    CURSOR CurCablequ is		-- les c�blages utilisant cet �quipement
	select CABLEQU_ID from CABLEQU_EQUIP
	    where EQUIP_ID = EquipId;

    CURSOR CurProg1 (Idl NUMBER) is	-- tous les prog. concern�s par ce c�blage
					-- (prestations + liaisons support)
	select distinct prog_id, site_id from PROG_CABL
	where CABLEQU_ID = Idl;

/*    CURSOR CurProg2 (Prog NUMBER) is	-- les sites d'entr�e d'un programme
	select * from PROG_OPER
	where PROG_ID  = Prog and
	      SITE_NUM = 1;*/

BEGIN

    ModCalc := GetModCalc;		-- Mode de calcul standard ou NEC

    select MAX (ALARMGEREE_GRAVE) into Grave from ACCES_ACCESC_REP
        where EQUIP_ID = EquipId and
	      ALARM_ID is not NULL;
		-- Valeur de la gravit� � prendre en compte en d�but d'alarme
		-- on regarde les alarmes en cours sur cet �quip.
    Grave := NVL (Grave, 0);

  /*  select MAX (ALARMGEREE_GRAVE) into GraveS from BITMESS, BITMESS_REP
	     where BITMESS_REP.EQUIP_ID = EquipId and
	      BITMESS_REP.ALARM_ID is not NULL and
	      BITMESS.BITMESS_ID = BITMESS_REP.BITMESS_ID;
		-- Valeur de la gravit� � prendre en compte en d�but d'alarme
		-- on regarde les alarmes en cours sur cet �quip.
    GraveS := NVL (GraveS, 0);

    Grave := Max3 (Grave, GraveS, AlarmGrave);*/
    Grave := Max2 (Grave, AlarmGrave);

    OperElt := GetOperElt (Grave, AlarmLocal, ModCalc);

    update EQUIP_REP
	     set EQUIP_OPER = OperElt	where EQUIP_ID = EquipId;

    -- Mise � jour de l'�tat op�rationnel de tous les programmes qui utilisent cet �quipement

    for vCabl in CurCablequ loop    -- boucle sur tous les CABLEQU qui contiennent l'�quipement

    	select max (EQUIP_OPER) into OperElt	-- max. Oper pour les �quipements du CABLEQU
    	    from EQUIP_REP, CABLEQU_EQUIP
    	    where  CABLEQU_EQUIP.CABLEQU_ID = vCabl.CABLEQU_ID and
    		   CABLEQU_EQUIP.EQUIP_ID = EQUIP_REP.EQUIP_ID;
    	OperElt := NVL (OperElt, 0);

    	update PROG_CABL_REP
    	    set PROG_CABL_GRAVE = OperElt
    	    where CABLEQU_ID = vCabl.CABLEQU_ID;

    	for vProg in CurProg1 (vCabl.CABLEQU_ID) loop	/* tous les PROG_CABL tq CABLEQU_ID = Id */
    -- insert into test values ('EQUIP '||to_char(EquipId)||' PROG '||to_char(vProg.PROG_ID));
    	    select max (PROG_CABL_GRAVE) into OperElt
    	    	from PROG_CABL_REP	-- max. Oper pour les CABLEQU de ce prog. dans ce site
    	    	where PROG_ID = vProg.PROG_ID and
    		      SITE_ID = vProg.SITE_ID;
    	    OperElt := NVL (OperElt, 0);

    	    select SITE_OPER into OperSite
    		from SITE_REP
    		where SITE_ID = vProg.SITE_ID;
    	    OperSite := NVL (OperSite, 0);

    	    OperElt := Max2 (OperElt, OperSite);
    -- insert into test values ('OperElt '||to_char(OperElt));
    	    update PROG_OPER_REP
    	    	set PROG_OPER_GRAVE = OperElt
    	    	where PROG_ID = vProg.PROG_ID and
    		      SITE_ID = vProg.SITE_ID;

    		-- OperElt est le max. de l'�tat op�r. des CABLEQU, pour ts. les PROG qui
    		-- utilisent cet �quip.
    		-- Ceci tient compte aussi des alarmes de site.
    		-- Les alarmes de liaisons inter-sites seront prises en compte dans le
    		-- traitement suivant, qui consid�re aussi les redondances �ventuelles.
    	end loop;
    end loop;

    -- 70 prog. au max. Structure : ProgId, OldOper, ProgOper, ProgMsk; ProgId,
    -- OldOper, ProgOper, ProgMsk; etc...

    for vProg in CurProg loop --PROG_ID from CABLEQU_EQUIP, PROG_CABLEQU
  /*  	ErrWarn := FALSE;
    	ErrMin := FALSE;
    	ErrMaj := FALSE;
    	ErrTs  := FALSE;

    	select PROG_ROUTAGE into Routage
    	    from PROG
    	    where PROG_ID = vProg.PROG_ID;

    	if (Routage is NULL) then		-- Pas de routage
    	    for vProg2 in CurProg2 (vProg.PROG_ID) loop
    		-- boucle sur tous les sites d'entr�e du programme
    	    	ErrWarn := ErrWarn or EWarn   (vProg2.NODE_ID);
    	    	ErrMin  := ErrMin  or EMin    (vProg2.NODE_ID, ModCalc);
    	    	ErrMaj  := ErrMaj  or ECoupe  (vProg2.NODE_ID);
    	    	ErrTs   := ErrTs   or TsCoupe (vProg2.NODE_ID);
    	    end loop;	-- boucle sur les sites d'entr�e du programme

    	else
    	-- en cas de routage, on ne calcule pas la connexit� (celle-ci d�pend du routage)
    	    select max (PROG_OPER_GRAVE) into OperElt
    		from PROG_OPER_REP
    	    	where PROG_ID = vProg.PROG_ID;
    	end if;		-- si pas de routage

    	if (ModCalc = 0) then	-- Cas standard SPV
    	    if (ErrTs     or OperElt >= 3) then
    	    	OperProg := 3;
    	    elsif (ErrMaj or OperElt = 2) then
    	    	OperProg := 2;
    	    elsif (ErrMin or OperElt = 1) then
    	    	OperProg := 1;
    	    else
    	    	OperProg := 0;
    	    end if;

    	else			-- Cas NEC
    	    if (ErrMaj     or OperElt >= 3) then
    	    	OperProg := 3;
    	    elsif (ErrMin  or OperElt = 2) then
    	    	OperProg := 2;
    	    elsif (ErrWarn or OperElt = 1) then
    	    	OperProg := 1;
    	    else
    	    	OperProg := 0;
    	    end if;
    	end if;

    	select B.PROG_OPER, PROG_MASQUE
    	    into OldOperprog, ProgMsk
    	    from PROG A, PROG_REP B
    	    where A.PROG_ID = vProg.PROG_ID and
    		  A.PROG_ID = B.PROG_ID;

            update PROG_REP
    	    set PROG_OPER = OperProg
    	    where PROG_ID = vProg.PROG_ID;

    	if ((TsPrOper is NULL or length (TsPrOper) <= 800) and Debord = 0) then
    --	    ProgNb := ProgNb +1;
    	    TsPrOper := TsPrOper || to_char (vProg.PROG_ID) || ',' || to_char (OldOperProg) ||
    		    	',' || to_char (OperProg) || ',' || to_char (ProgMsk) || ';';
    	elsif (length (TsPrOper) > 800) then
    	    Debord := 1;
    	end if;*/

    	--  insert into test values (SEQ_TEST.NEXTVAL, 'OperEnglob : prog_ID = '||vProg.PROG_ID);

      TsPrOperProg(vProg.PROG_ID, ModCalc, /* OperElt,*/ TsPrOper, Debord);
    end loop;		-- boucle sur les programmes affect�s par cette erreur

  /*  for vTop in CurTop loop
      -- 	  insert into test values (SEQ_TEST.NEXTVAL, 'OperEnglob : top_ID = '||vTop.top_id);

      TsPrOperTop(vTop.top_id, ModCalc, OperElt, TsPrOper, Debord);
    end loop;*/

    BindingId := 0;
    select EQUIP_BINDINGID into BindingId
	     from EQUIP	where EQUIP_ID = EquipId;

    BindingId := NVL (BindingId, 0);

    if (BindingId > 0) then
	     OperEnglob (Grave, BindingId, AlarmLocal, ProgNb, TsPrOper, Debord);
    end if;
END   OperEnglob;
/

--
--	Modif JPB le 02/10/06 : reprise du traitement concernant TsPrOper
--

CREATE OR REPLACE PROCEDURE MajOperEquip
	(Id NUMBER, EquipId NUMBER, AlarmLocal NUMBER, AlarmGrave NUMBER, AlarmCommut NUMBER,
	 ProgNb IN OUT NUMBER,
	 SiteNom IN OUT VARCHAR2, TypEqu IN OUT VARCHAR2, Poseq IN OUT VARCHAR2, 
	 TsPrOper IN OUT VARCHAR2, Debord IN OUT NUMBER)
IS
	/* Cette proc�dure met � jour l'�tat op�rationnel de l'�quipement en d�faut, 
	   ainsi que l'�tat op�rationnel des CABLEQU et des programmes que cela concerne.
	Tient compte des "sous-�quipements" (ie. �quipements inclus).
	Un "sous-�quipement" n'est pas utilis� directement (on met un �quipement dans un c�blage). 
	Un �quipement peut �tre en panne parce que un de ses sous-�quipements est en panne.
	FAUX - FAUX - FAUX !!!
	On met � jour l'�tat op�rationnel des �quipements qui contiennent celui-ci (OperEnglob).

	Lorsqu'un �quipement est en panne, il faut donc mettre � jour imm�diatement
	l'�tat op�rationnel des �quipements qui le concernent.
	AlarmGrave : gravit� alarme */

    OperElt	NUMBER;		-- Etat op�rationnel de l'�lt. g�r� en cause 
    Grave	NUMBER;		-- Gravit� des alarmes restantes 
    LBaie	NUMBER;		-- Num�ro de baie 
    BindingId	NUMBER;		-- Id de l'englobant de EquipId. 0 si fini 
    Buf		VARCHAR2 (100); -- banal
    ModCalc	NUMBER;		-- Mode de calcul standard ou NEC

BEGIN
--  lock table PROG_OPER in exclusive mode;

  	--insert into test values (SEQ_TEST.NEXTVAL, 'MajOperEquip : EquipId = '||EquipId ||
   -- ' AlarmCommut = ' || AlarmCommut);

    ModCalc := GetModCalc;

    -- Mise � jour de SiteNom, TypEqu et Poseq
    -- Modif. JPB le 01/11/03. Voir remarque V 1.087
    LBaie := 0;
    select SITE_NOM, TYPEQ_NOM, GetEquipNom (EquipId, 0), BAIE_ID
      	into SiteNom, TypEqu, Poseq, LBaie
      	from EQUIP, SITE
      	where EQUIP_ID = EquipId and 
      	      EQUIP.SITE_ID  = SITE.SITE_ID;

    -- Mise � jour de l'�tat op�rationnel de l'�quipement et des programmes qui l'utilisent
    if (AlarmCommut = 1) then
/*
        update EQUIP
	    set EQUIP_COMMUT = AlarmGrave	-- Position d'un commutateur
	    where EQUIP_ID   = EquipId;
*/
    	ProgNb   := 0;
    --	TsPrOper := '';
    --	Debord   := 0;
    	Grave    := MajOperInclus (Id, EquipId, AlarmGrave, AlarmLocal, ProgNb, TsPrOper, Debord);
    --	TsPrOper := to_char (ProgNb) || ';' || TsPrOper;
    	return;

    else
    	ProgNb   := 0;
    --	TsPrOper := '';
    --   	Debord   := 0;
    	Grave    := MajOperInclus (Id, EquipId, AlarmGrave, AlarmLocal, ProgNb, TsPrOper, Debord);
    	
   --   insert into test values (SEQ_TEST.NEXTVAL, 'MajOperEquip : TsPrOper = '||TsPrOper ||
   --           ' Grave =  ' || Grave);
    
    end if;

    OperElt := GetOperElt (Grave, AlarmLocal, ModCalc);

    update EQUIP_REP
	     set EQUIP_OPER = OperElt 	where EQUIP_ID = EquipId;

  -- Mise � jour de l'�tat op�rationnel des �quipements qui contiennent celui-ci
  -- Un seul niveau, car l'appel est r�cursif

    select PARAM_VALEUR into Buf from PARAM
       where PARAM_VALEUR like 'ALARM_ENGLOB%';

    if (INSTR (Buf, 'true') > 0) then	-- il faut tenir compte des englobants / englob�s
       BindingId := 0;
       

       select EQUIP_BINDINGID into BindingId
         from EQUIP  where EQUIP_ID = EquipId;
       
       BindingId := NVL (BindingId, 0);

    	if (BindingId > 0) then
    	    OperEnglob (Grave, BindingId, AlarmLocal, ProgNb, TsPrOper, Debord);
    	end if;
   end if;
     
--    TsPrOper := to_char (ProgNb) || ';' || TsPrOper;
END MajOperEquip;
/



CREATE OR REPLACE PROCEDURE Maj2OperEquip (EquipId NUMBER, CablequId NUMBER)
IS
	/* Cette proc�dure met � jour l'�tat op�rationnel du CABLEQU et des programmes 
	que cela concerne, lorsqu'on supprime ou qu'on ajoute un �quipement dans un c�blage */

    Id 		NUMBER;		/* Id de l'alarme en cours */
    AlarmLocal	NUMBER;		/* Donn�es de l'alarme en cours */
    AlarmGrave	NUMBER;	
    AlarmCommut	NUMBER;
    ProgId	NUMBER;		/* Id du programme trait� */
    ProgNb	NUMBER;
    TypEqu	VARCHAR2 (40);
    Poseq	VARCHAR2 (80); 
    TsPrOper	VARCHAR2 (900);

    OperElt	NUMBER;		/* Etat op�rationnel de l'�lt. g�r� en cause */

    SiteId	NUMBER;		/* Id du site contenant l'�quipement en d�faut */

    OperSite	NUMBER;		/* Etat op�r. de ce site */
    OperLiai	NUMBER;		/* Max. �tat op�r. des liaisons du programme dans ce site */

    OperProg	NUMBER;		/* Etat op�rationnel du programme :
					0 : tout va bien
					1 : erreurs mineures rencontr�es
					2 : perte de la redondance
					3 : non fonctionnel */
    OldOperProg NUMBER;		/* ancien �tat op�rationnel du programme */
    ProgMsk	NUMBER;		/* Etat de masquage du programme :
					0 : non masqu�
					1 : masquage brigadier
					2 : masquage administrateur */

    ErrWarn	BOOLEAN;	/* TRUE si une erreur existe */
    ErrMin	BOOLEAN;	/* TRUE si une erreur mineure existe */
    ErrMaj	BOOLEAN;	/* TRUE si une erreur majeure existe */
    ErrTs	BOOLEAN;	/* TRUE si tous les chemins sont coup�s entre un des noeuds
				origine et un noeud destination */

    Routage	VARCHAR2 (40);	-- Permet de savoir si un routage est associ� au programme

    ModCalc	NUMBER;		/* Mode de calcul standard ou NEC */

    LProgNb	NUMBER;		/* Nb. de programmes correspondant � des liaisons en panne 
				(mpx) */
    LPrOper	VARCHAR2 (450); /* Etat op�rationnel de ces liaisons */

    Debord 	NUMBER;		/* 1 si d�bordement, 0 sinon */

    CURSOR CurProg1 (Idl NUMBER) is
	select distinct prog_id, site_id from PROG_CABL
	where CABLEQU_ID = Idl;

    CURSOR CurProg2 (Prog NUMBER) is	-- les sites d'entr�e d'un programme
	select * from PROG_OPER
	where PROG_ID  = Prog and
	      SITE_NUM = 1;

    CURSOR CurLiai (Idl NUMBER) is
	select * from LIAI_CABLEQU
	where CABLEQU_ID = Idl;

    CURSOR CurAl is
	select B.ALARM_ID from ACCES_ACCESC A, ACCES_ACCESC_REP B
	    where A.ACCES_ACCESC_ID = B.ACCES_ACCESC_ID and
		  (B.EQUIP_ID = EquipId or A.ACCES_BINDINGID = EquipId);

BEGIN

-- 	  insert into test values (SEQ_TEST.NEXTVAL, 'Maj2OperEquip : EquipId = '||EquipId);

    ModCalc := GetModCalc;		-- Mode de calcul standard ou NEC

    select EQUIP_OPER into OperElt
    	from EQUIP_REP
    	where EQUIP_ID = EquipId;

    if (OperElt = 0) then
	     return;		/* pas d'alarme en cours, il n'y a rien � faire */
    end if;

--    lock table PROG_OPER in exclusive mode;

    -- Mise � jour de l'�tat op�rationnel de tous les programmes qui utilisent cet �quipement

    select max (EQUIP_OPER) into OperElt	-- max. Oper pour les �quipements du CABLEQU
    	from EQUIP_REP, CABLEQU_EQUIP
    	where	CABLEQU_EQUIP.CABLEQU_ID = CablequId and
		  CABLEQU_EQUIP.EQUIP_ID = EQUIP_REP.EQUIP_ID; --  OperElt : �tat op�rationnel 
      
    OperElt := NVL (OperElt, 0);
-- insert into test values (SEQ_TEST.NEXTVAL, 'OperElt ' || to_char (OperElt));

    update PROG_CABL_REP
    	set PROG_CABL_GRAVE = OperElt
    	where CABLEQU_ID = CablequId;

    for vProg in CurProg1 (CablequId) loop	/* tous les PROG_CABL tq CABLEQU_ID = Id */
    	SiteId := vProg.SITE_ID;
    	ProgId := vProg.PROG_ID;
    
    	 select max (PROG_CABL_GRAVE) into OperElt
    	    from PROG_CABL_REP
    	    where PROG_ID = ProgId and  SITE_ID = SiteId;
		  
      -- max. Oper pour les CABLEQU de ce prog. dans ce site
	     OperElt := NVL (OperElt, 0);

	     select SITE_OPER into OperSite
	     from SITE_REP  where SITE_ID = SiteId;
	   
       OperSite := NVL (OperSite, 0);

	   OperElt := Max2 (OperElt, OperSite);
-- insert into test values (SEQ_TEST.NEXTVAL, 'Prog ' || to_char (vProg.PROG_ID) ||
-- ' OperElt ' || to_char (OperElt));

	   update PROG_OPER_REP
	      set PROG_OPER_GRAVE = OperElt
	      where PROG_ID = ProgId and SITE_ID = SiteId;

	-- OperElt est le max. de l'�tat op�r. des CABLEQU, pour ts. les PROG qui 
	-- utilisent cet �quip.
	-- Ceci tient compte aussi des alarmes de site.
	-- Les alarmes de liaisons inter-sites seront prises en compte dans le 
	-- traitement suivant, qui consid�re aussi les redondances �ventuelles.
    end loop;

	-- 70 prog. au max. Structure : NbProg; ProgId, OldOper, ProgOper, ProgMsk; ProgId, 
	-- OldOper, ProgOper, ProgMsk; etc... 

    ProgNb   := 0;
    Debord   := 0;
    TsPrOper := '';  

    for vProg in CurProg1 (CablequId) loop	/* tous les programmes tq CABLEQU_ID = Id */
      OperElt := 0;
/*    	ErrWarn := FALSE;
    	ErrMin := FALSE;
    	ErrMaj := FALSE;
    	ErrTs  := FALSE;
    	

    	select PROG_ROUTAGE into Routage
    	    from PROG
    	    where PROG_ID = vProg.PROG_ID;
    
    	if (Routage is NULL) then		-- Pas de routage
    	    for vProg2 in CurProg2 (vProg.PROG_ID) loop 
    		-- boucle sur tous les sites d'entr�e du programme
    	    	ErrWarn := ErrWarn or EWarn   (vProg2.NODE_ID);
    	    	ErrMin  := ErrMin  or EMin    (vProg2.NODE_ID, ModCalc);
    	    	ErrMaj  := ErrMaj  or ECoupe  (vProg2.NODE_ID);
    	    	ErrTs   := ErrTs   or TsCoupe (vProg2.NODE_ID);

	       end loop;	-- boucle sur les sites d'entr�e du programme

	     else
	       -- en cas de routage, on ne calcule pas la connexit� (celle-ci d�pend du routage)
	       select max (PROG_OPER_GRAVE) into OperElt
		        from PROG_OPER_REP
	    	    where PROG_ID = vProg.PROG_ID;
	     end if;		-- si pas de routage

	     if (ModCalc = 0) then	-- Cas standard SPV
    	    if (ErrTs     or OperElt >= 3) then
    	    	OperProg := 3;
    	    elsif (ErrMaj or OperElt = 2) then
    	    	OperProg := 2;
    	    elsif (ErrMin or OperElt = 1) then
    	    	OperProg := 1;
    	    else
    	    	OperProg := 0;
    	    end if;

	     else			-- Cas NEC
    	    if (ErrMaj     or OperElt >= 3) then
    	    	OperProg := 3;
    	    elsif (ErrMin  or OperElt = 2) then
    	    	OperProg := 2;
    	    elsif (ErrWarn or OperElt = 1) then
    	    	OperProg := 1;
    	    else
    	    	OperProg := 0;
    	    end if;
	     end if;
--	insert into test values (SEQ_TEST.NEXTVAL, 'MAJOPERINCLUS : OperProg '||to_char(vProg.PROG_ID)||'; '||to_char(OperProg));

	     select B.PROG_OPER, PROG_MASQUE
	       into OldOperprog, ProgMsk
	       from PROG A, PROG_REP B
	       where A.PROG_ID = vProg.PROG_ID and
		      A.PROG_ID = B.PROG_ID;

       update PROG_REP
	       set PROG_OPER = OperProg
	       where PROG_ID = vProg.PROG_ID;

	     if ((TsPrOper is NULL or length (TsPrOper) <= 800) and Debord = 0) then
--	    ProgNb := ProgNb +1;
	       TsPrOper := TsPrOper || to_char (vProg.PROG_ID) || ',' || to_char (OldOperProg) ||
		    	',' || to_char (OperProg) || ',' || to_char (ProgMsk) || ';';
	     elsif (length (TsPrOper) > 800) then
	       Debord := 1;
	     end if;
*/
        TsPrOperProg(vProg.PROG_ID, ModCalc,/* OperElt,*/ TsPrOper, Debord);
    end loop;		-- boucle sur les programmes affect�s par cette erreur
-- insert into test values (SEQ_TEST.NEXTVAL, 'TsPrOper ' || TsPrOper);

    for vAl in CurAl loop
	     LProgNb := 0;
	     LPrOper := '';

	     for vLiai in CurLiai (CablequId) loop 	-- cas des �quipements de multiplexage ( * from LIAI_CABLEQU)
  	    MajOperLiai (vAl.ALARM_ID, vLiai.LIAI_ID, AlarmLocal, AlarmGrave, LProgNb,
  		         TypEqu, Poseq, LPrOper, Debord);
  --	    ProgNb  := ProgNb + LProgNb;
  	    LPrOper := SUBSTR (LPrOper, INSTR (LPrOper, ';') +1);
  
  	    if ((TsPrOper is NULL or length (TsPrOper) <= 800) and Debord = 0) then
  		      TsPrOper := TsPrOper || LPrOper;
  	    else
  		      Debord := 1;
  	    end if;
       end loop;

--   	TsPrOper := to_char (ProgNb) || ';' || TsPrOper;

	     update ALARM2
	       set ALARM2_TSPROPER = TsPrOper
	       where ALARM2_ID = vAl.ALARM_ID;
    end loop;

END Maj2OperEquip;
/


CREATE OR REPLACE PROCEDURE maj_oper (Id NUMBER, SiteId NUMBER, EquipId NUMBER,
    LiaiId NUMBER, AlarmLocal NUMBER, AlarmGrave NUMBER, AlarmCommut NUMBER,
    ProgNb IN OUT NUMBER, 
    SiteNom IN OUT VARCHAR2, Typeq IN OUT VARCHAR2, Poseq IN OUT VARCHAR2, 
    TsPrOper IN OUT VARCHAR2, Debord IN OUT NUMBER)
	/* Cette proc�dure met � jour l'�tat op�rationnel de l'�l�ment g�r� en d�faut,
	   ainsi que l'�tat op�rationnel des CABLEQU et des programmes que cela concerne */

IS
	-- Id est l'identifiant du nouveau message d'alarme (d�but ou fin).
BEGIN

--    	insert into test values (SEQ_TEST.NEXTVAL, 'maj_oper : SiteId = '||SiteId ||
 --     ' EquipId = '|| EquipId || ' LiaiId = ' || LiaiId);

    delete alarm_prog where alarm_id= Id;
    
    if (SiteId is not NULL) then
	     Typeq := 'SITE';
	     MajOperSite (Id, SiteId, AlarmLocal, AlarmGrave, ProgNb, SiteNom, Poseq, TsPrOper, Debord);
    elsif (EquipId is not NULL) then
	     MajOperEquip (Id, EquipId, AlarmLocal, AlarmGrave, AlarmCommut, ProgNb, SiteNom, Typeq, Poseq, TsPrOper, Debord);
    elsif (LiaiId is not NULL) then
	     SiteNom := ' ';
	     MajOperLiai (Id, LiaiId, AlarmLocal, AlarmGrave, ProgNb, Typeq, Poseq, TsPrOper, Debord);
    end if;

END maj_oper;
/


CREATE OR REPLACE FUNCTION AlarmNature (Id NUMBER)
RETURN NUMBER
	/* Cette fonction retourne :
	- 0 si l'alarme est autonome,
	- 1 si c'est une alarme m�re,
	- 2 si c'est une alarme fille. */

IS
    CURSOR c1 is
	select * from ALARM_ALARMC
	    where ALARM_ID = Id
	    for update of ALARM_ID;

    CURSOR c2 is
	select * from ALARM_ALARMC
	    where ALARM_BINDINGID = Id
	    for update of ALARM_ID;

BEGIN
    for c in c1 loop
	return 2;	/* alarme fille */
    end loop;

    for c in c2 loop
	return 1;	/* alarme m�re */
    end loop;

    return 0;		/* alarme autonome */

END AlarmNature;
/


CREATE OR REPLACE FUNCTION IsMaskedLiai (LiaiId1 NUMBER, LiaiId2 NUMBER)
RETURN BOOLEAN
	/* Cette fonction retourne TRUE si la liaison LiaiId1 est masqu�e par LiaiId2, 
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
/


CREATE OR REPLACE FUNCTION IsMaskedBy (Id1 NUMBER, EquipId1 NUMBER, LiaiId1 NUMBER, 
				       Id2 NUMBER, EquipId2 NUMBER, LiaiId2 NUMBER)
RETURN BOOLEAN
	/* Cette fonction retourne TRUE si Id1 est masqu� par Id2, FALSE sinon.
	Une alarme ne peut �tre masqu�e que par une alarme m�re ou autonome.
	Id1 est masqu� par Id2 ssi (pour l'instant) :
	- elles arrivent "� peu pr�s en m�me temps". Cette condition est v�rifi�e par le 
	programme appelant, qui n'appelle cette fonction que pour ces alarmes l�;
	- Id1 et Id2 sont des alarmes d'�quipements appartenant au m�me programme, dans 
	le m�me site,
	et le n� d'ordre de l'�quip. de Id2 est strictement inf�rieur � celui de Id1,
	- OU Id1 et Id2 sont des alarmes de liaisons et la liaison de Id1 est support�e 
	par celle de Id2.

	ATTENTION : le masquage a lieu si cette condition est v�rifi�e dans AU MOINS UN
	des c�blages auxquels l'�quipement appartient.

	Cette fonction appelle AlarmNature. */
IS

    CURSOR cMasked is
	select * from EQUIP_MSK
	    where EQUIP_ID = EquipId1 and
		  EQUIP_BINDINGID = EquipId2;

BEGIN

    if (AlarmNature (Id2) = 2) then	/* Id2 est une alarme fille */
	     return FALSE;
    end if;

    if (EquipId1 is not null and EquipId2 is not null) then	
					/* Alarmes d'�quipement */
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
/


create or replace
FUNCTION correl_alrm (Mess IN OUT VARCHAR2,
    Id NUMBER, SiteId NUMBER, EquipId NUMBER, LiaiId NUMBER, DateAlSec NUMBER, AlarmGrave NUMBER,
    AlarmIddeb NUMBER, TsPrOper IN OUT VARCHAR2, Debord IN OUT NUMBER)
RETURN BOOLEAN
	/* Cette fonction effectue les diff�rents traitements li�s � la corr�lation des alarmes.
	   Elle appelle les proc�dures ou fonctions :
		- IsMaskedBy (Id1, Id2)
		- AlarmNature (Id)
		- MaskeBy (Id1, Id2)
	   Elle retourne :
	   	- FALSE : arr�ter le traitement d'alarme (alarme masqu�e)
	   	- TRUE  : continuer le traitement d'alarme (alarme ind�pendante ou m�re) */

IS
    PrecTime	integer;	/* Pr�cision de datation des EDC, en sec. */
    Nature	integer;	/* Nature d'une alarme */

    CURSOR cAccesc is
	select B.ALARM_ID, B.SITE_ID, B.EQUIP_ID, B.LIAI_ID, A.ALARMGEREE_ID, B.ALARM_CL,
	       B.ALARM_NUMOBJ, B.ALARM_NUMAL
	    from ACCES_ACCESC A, ACCES_ACCESC_REP B
	    where A.ACCES_ACCESC_ID = B.ACCES_ACCESC_ID and
		  A.COMMUT = 0 and
		  ABS (DateAlSec - B.ALARM_SEC) <= PrecTime and
		  B.ALARM_ID != Id;
	/*union
	select B.ALARM_ID, B.SITE_ID, B.EQUIP_ID, B.LIAI_ID, A.ALARMGEREE_ID, B.ALARM_CL,
	       B.ALARM_NUMOBJ, B.ALARM_NUMAL
	    from BITMESS A, BITMESS_REP B
	    where A.BITMESS_ID = B.BITMESS_ID and
		  ABS (DateAlSec - B.ALARM_SEC) <= PrecTime and
		  B.ALARM_ID != Id;*/
			-- Toutes les autres alarmes en cours, d�marr�es en m�me temps que Id

    CURSOR cAlarm is
	select ALARM_ID from ALARM_ALARMC
	    where ALARM_ID = AlarmIddeb;

    AlarmType 	NUMBER;
    AlarmNseuil VARCHAR2 (50);
    AlarmNomL 	VARCHAR2 (50);
    AlarmComment VARCHAR2(260);

    ProgNb	NUMBER;		/* inutilis� ici */

    SiteNom     VARCHAR2 (40);  /* nom du site contenant l'�lt. en d�faut. ' ' pour une liaison
				inter-site. Inutilis� ici */
    Typeq    VARCHAR2 (40);  	/* nom du type de l'�quipement ou de la liaison.
				'SITE' pour une alarme	de site . Inutilis� ici*/
    Poseq    VARCHAR2 (80);  	/* Position de l'�quipement ou nom de la liaison ou du site en
				d�faut. Inutilis� ici */

BEGIN

    PrecTime := 4;	/* Pr�cision de datation IS en s. : 2 s. * 2 IS */

    if (AlarmGrave > 0) then	/* D�but d'alarme */
    	for cAl in cAccesc loop /* Boucle sur les alarmes arriv�es � peu pr�s en m�me temps */
  	    if (IsMaskedBy (Id, EquipId, LiaiId, cAl.ALARM_ID, cAl.EQUIP_ID, cAl.LIAI_ID)) then
  				/* Id est masqu�e par cAl.ALARM_ID */
  				/* On ne peut �tre masqu� que par une alarme m�re ou autonome */
  		      insert into ALARM_ALARMC (ALARM_ID, ALARM_BINDINGID) values (Id, cAl.ALARM_ID);
    --        insert into test values(seq_test.nextval, 'correl1 Eq1= ' || EquipId || 'correl1 Eq2= ' ||cAl.EQUIP_ID);
  		      return FALSE;	/* Alarme fille */
  	    end if;
	    end loop;

    	for cAl in cAccesc loop	/* Ces alarmes sont elles masqu�es par la nouvelle alarme ? */
  	    if (IsMaskedBy (cAl.ALARM_ID, cAl.EQUIP_ID, cAl.LIAI_ID, Id, EquipId, LiaiId)) then
 -- 				  insert into test values(seq_test.nextval, 'correl2 Eq1= ' || cAl.EQUIP_ID || 'correl2 Eq2= ' ||EquipId);

          /* Id masque cAl.ALARM_ID */
  		      Nature := AlarmNature (cAl.ALARM_ID);
  				/* Alarme autonome (0), m�re (1), fille (2) */

  --				insert into test values(seq_test.nextval, 'Debut dalarm Nature=' || Nature);

        		if (Nature = 1) then
        		    update ALARM_ALARMC			/* cAl.ALARM_ID �tait une alarme m�re */
        			set ALARM_BINDINGID = Id	/* Elle est d�class�e par Id */
        			where ALARM_BINDINGID = cAl.ALARM_ID;
        		end if;

        		if (Nature != 2) then		/* cAl.ALARM_ID n'est pas une alarme fille :
        						   on la masque */
        		    insert into ALARM_ALARMC (ALARM_ID, ALARM_BINDINGID)
        			     values (cAl.ALARM_ID, Id);

        --			    	insert into test values (SEQ_TEST.NEXTVAL, 'correl_alrm : SiteId = '||cAl.SITE_ID ||
         --     ' EquipId = '|| cAl.EQUIP_ID || ' LiaiId = ' || cAl.LIAI_ID);

        		    maj_oper (cAl.ALARM_ID, cAl.SITE_ID, cAl.EQUIP_ID, cAl.LIAI_ID, 0, 0, 0,
        			      ProgNb, SiteNom, Typeq, Poseq, TsPrOper, Debord);
        						/* "retomb�e" de cAl.ALARM_ID */

        /* insert into testcorr (Id,T,V1,V2) values (SEQ_TEST.NEXTVAL,'OFF2', cAl.ALARM_NUMAL, cAl.ALARM_ID); */

        		    delete ALARM2 where ALARM2_ID = cAl.ALARM_ID;

        		    Stop_Alrm (Mess, cAl.ALARM_ID, cAl.ALARMGEREE_ID, cAl.SITE_ID, cAl.EQUIP_ID,
        			       cAl.LIAI_ID, cAl.ALARM_CL, cAl.ALARM_NUMOBJ, cAl.ALARM_NUMAL, TsPrOper);
        			/* envoi du message de retomb�e de l'alarme pour chacune de ces alarmes
        			   qui sont masqu�es par la nouvelle alarme arriv�e */
        		end if;	/* retomb�e de cAl.ALARM_ID */

      	  end if;--IsMaskedBy
	    end loop;

    else			/* Fin d'alarme */
    	Nature := AlarmNature (AlarmIddeb);
---    	insert into test values(seq_test.nextval, 'Fin dalarm Nature=' || Nature);


	   if (Nature = 1) then 	/* Alarme m�re */
	    insert into FINALARM (FINALARM_ID, ALARM_ID) values (SEQ_FINALARM.NEXTVAL, Id);
	   elsif (Nature = 2) then	/* Alarme fille */
	    delete ALARM_ALARMC
  	        where ALARM_ID = AlarmIddeb;
	    return FALSE;
     end if;

    end if;--Fin d'alarme

    return TRUE;

END correl_alrm;
/

create or replace
FUNCTION IsMaskedAdm (AlarmCl VARCHAR2, CablS NUMBER, CablP NUMBER)
RETURN BOOLEAN
	/* Cette fonction retourne TRUE si l'alarme est masqu�e par un Administrateur autoris�
	   (l'alarme n'apparait pas sur les �crans, mais l'�tat op�rationnel de l'�l�ment
	   g�r� et des programmes qui l'utilisent, est modifi�).
	   La fonction retourne FALSE dans le cas contraire. */

IS

    ToDayStr	VARCHAR2 (20);	/* date et heure actuelle au format YYYY MM DD HH24:MI:SS */
    ToDaySec	NUMBER;		/* idem en nombre de secondes depuis le 01/01/1998 00:00:00 */
    MskMin	NUMBER;		/* valeur min. du masquage, en nb. secondes */
    MskMax	NUMBER;		/* valeur max. du masquage, en nb. secondes */

BEGIN

    ToDayStr := to_char (sysdate, 'YYYY MM DD HH24:MI:SS');
    ToDaySec := CO_SEC1998 (ToDayStr);

  --  if (AlarmCl != 'IS_S') then
	select MSKADM_MIN, MSKADM_MAX into MskMin, MskMax
	    from ACCES_ACCESC
	    where ACCES_ACCESC_ID = CablP;
	if (ToDaySec >= MskMin and ToDaySec < MskMax) then
	    return TRUE;
	else
     	    return FALSE;
	end if;

 /*   else
	select MSKADM_MIN, MSKADM_MAX into MskMin, MskMax
	    from BITMESS
	    where BITMESS_ID = CablS;
	if (ToDaySec >= MskMin and ToDaySec < MskMax) then
	    return TRUE;
	else
     	    return FALSE;
	end if;
    end if;*/

    return FALSE;
END IsMaskedAdm;
/


create or replace
FUNCTION IsMaskedBri (AlarmCl VARCHAR2, CablS NUMBER, CablP NUMBER)
RETURN BOOLEAN
	/* Cette fonction retourne TRUE si l'alarme est masqu�e par un Brigadier autoris�
	   (l'alarme n'apparait pas sur les �crans, mais l'�tat op�rationnel de l'�l�ment
	   g�r� et des programmes qui l'utilisent, est modifi�).
	   La fonction retourne FALSE dans le cas contraire. */

IS

    ToDayStr	VARCHAR2 (20);	/* date et heure actuelle au format YYYY MM DD HH24:MI:SS */
    ToDaySec	NUMBER;		/* idem en nombre de secondes depuis le 01/01/1998 00:00:00 */
    MskMin	NUMBER;		/* valeur min. du masquage, en nb. secondes */
    MskMax	NUMBER;		/* valeur max. du masquage, en nb. secondes */

BEGIN

    ToDayStr := to_char (sysdate, 'YYYY MM DD HH24:MI:SS');
    ToDaySec := CO_SEC1998 (ToDayStr);

 --   if (AlarmCl != 'IS_S') then
	select MSKBRI_MIN, MSKBRI_MAX into MskMin, MskMax
	    from ACCES_ACCESC
	    where ACCES_ACCESC_ID = CablP;
	if (ToDaySec >= MskMin and ToDaySec < MskMax) then
	    return TRUE;
	else
     	    return FALSE;
	end if;

  /*  else
	select MSKBRI_MIN, MSKBRI_MAX into MskMin, MskMax
	    from BITMESS
	    where BITMESS_ID = CablS;
	if (ToDaySec >= MskMin and ToDaySec < MskMax) then
	    return TRUE;
	else
     	    return FALSE;
	end if;
    end if;*/

    return FALSE;
END IsMaskedBri;
/

--================================================================================
-- Indique si une alarme est � afficher sur les consoles ou non
--
-- renvoie TRUE si c'est le cas, FALSE dans le cas contraire
--
-- X.L. Cr�ation le 23/02/04
--
-- Modif. X.L. le 05/10/06 � la demande de G.G. (GlobeCast). On change le principe
-- de fonctionnement. Les acc�s des �quipements n'h�ritent plus de l'info TOAFF
-- lorsqu'on modifie l'alarme g�r�e correspondante de l'acc�s du type d'�quipement.
-- En cons�quence, on affiche si TOAFF est � 1 au niveau de l'alarme g�r�e du
-- type d'�quipement et de l'acc�s de l'�quipement.
--
--================================================================================
create or replace
FUNCTION IsToAff (AlarmCl VARCHAR2, CablS NUMBER, CablP NUMBER)
RETURN BOOLEAN
	/* Cette fonction retourne TRUE si l'alarme est masqu�e par un Brigadier autoris�
	   (l'alarme n'apparait pas sur les �crans, mais l'�tat op�rationnel de l'�l�ment
	   g�r� et des programmes qui l'utilisent, est modifi�).
	   La fonction retourne FALSE dans le cas contraire. */

IS

    ToAff		acces_accesc.alarmgeree_toaff%TYPE;
    ToAff2		alarmgeree.alarmgeree_toaff%TYPE;
    AccesId		acces.acces_id%TYPE;

BEGIN

    ToAff := 1;
    ToAff2 := 1;

--    if (AlarmCl != 'IS_S') then
	select ACC.alarmgeree_toaff, acces1_id, ALG.alarmgeree_toaff into ToAff, AccesId, ToAff2
	    from ALARMGEREE ALG, ACCES_ACCESC ACC
	    where ACCES_ACCESC_ID = CablP
	    and ALG.ALARMGEREE_ID = ACC.ALARMGEREE_ID;

	if (ToAff = 0 or ToAff2 = 0) then
	    return FALSE;
	end if;

   /* else
	select bitmess.alarmgeree_toaff, alarmgeree.alarmgeree_toaff into ToAff, ToAff2
	    from ALARMGEREE, BITMESS
	    where BITMESS_ID = CablS
	    and ALARMGEREE.ALARMGEREE_ID = BITMESS.ALARMGEREE_ID;

	if (ToAff = 0 or ToAff2 = 0) then
	    return false;
	end if;
    end if;*/

    return TRUE;
END IsToAff;
/

/*
* 	Cette fonction recherche l'Id de l'acc�s sur l'IS (IsAccesId),
*	correspondant � ce n� IS + Numal.
*
*	Pour les SEM :
*	Numal = ((NumCarte -1)*8 + NumAcc -1) * 10000 + NumBit
*
*	Pour les traps, IsAccesId correspond � l'Id de l'alarme g�r�e dans ACCES_ACCESC
*
*	Modif. X.L. le 09/04/03 pour introduction de l'IP2PORT. Un trap IP2PORT pour entr�e digitale
*	est ins�r� comme un trap � ceci pr�s que l'objet est IP2 au lieu de TRAPG ou TRAPS. Le reste
*	des informations est conforme � un trap. Ici, il faut traduire les informations comme si
*	elles �manaient d'une alarme boucle (ce qui en fait est le cas). Il en est de m�me des �quipements
*	IDU/MIU de NEC qui sont tra�t�s au niveau alarme comme des IP2PORT (le service trap les transmet
*	en tant que IP2).
*
*       Modif JPB le 24/07/03 : dans les trap, ALARM_INFO contient l'EQUIP_ID du NE en d�faut
*	Idx n'est plus pass� en param�tre.
*
*	Modif JPB le 21/02/04 : NbAcc vaut 8 et non 6.
*
*	Modif X.L. le 08/02/05 pour adapter aux �quipements de collecte NEC MIU et IDU/ODU
*
*	Modif X.L. le 03/11/05 pour corriger un bug lorsque l'�quipement de collecte est
*	un IDU ou MIU NEC. dans ce cas, EquipRef qui repr�sente le nom de l'�quipement
*	n'est pas limit� � 12 caract�res. Donc maintenant EquipRef est dimensionn�
*	� EQUIP.SITE_EQUIP_COMMENT%TYPE.
*/
 
CREATE OR REPLACE FUNCTION tib2_alarm 
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
/* Appel� au d�but de tib_alarm, afin de diminuer la taille de ce trigger.
   Trouve IsAccesId : Id de l'acc�s sur l'IS */

    Ident  VARCHAR2 (256);  /* identit� d'une alarme TRAP : 
			OID enterprise;Generic Trap;Specific trap; */
    Cable  boolean;	/* true si le c�blage existe, false sinon */
    Messg  boolean;	/* true si le message existe, false sinon */
    NumCarte NUMBER;	/* n� carte de l'IS : 1 � 8 pour les GTR et 1 � 6 pour les SEM */
    NumAcc   NUMBER;	/* n� acc�s sur la carte : 1 � 48 pour GTR et 1 � 8 pour SEM
						   1 � 16 pour un IP2PORT */
    NbAcc    NUMBER;	/* nb. max. d'acc�s par carte SEM (8 en principe) */
    EquipRef EQUIP.SITE_EQUIP_COMMENT%TYPE;
			/* IS xx/GTR yy ou IS xx/SEM yy   xx : n� IS, yy : n� acc�s
			    ou IS xx	pour les alarmes syst�mes de l'IS 
			    IP2PORTx o� x d�signe le num�ro de l'IP2PORT en question
			    ou le nom de l'�quipement IDU ou MIU NEC */
    Pos		NUMBER;	/* position du s�parateur dans la cha�ne � analyser */
    Pos2	NUMBER; /* position d'un autre �l�ment dans la cha�ne � analyser */

    cursor Cab is
    	select ACCES_ID 
	    from EQUIP, ACCES
	    where SITE_EQUIP_COMMENT = EquipRef and
		  ACCES_TYPE = 7 and
		  ACCES_NOM = To_Char (NumAcc) and 
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

    if (AlarmCl = 'GSITE' or AlarmCl = 'SYST') then /* GSITE ou alarmes SYST�me */
	for vGs in CGsite loop
	    IsAccesId := vGs.EQUIP_ID;  /* dans ce cas, IsAccesId correspond � l'Id de 
					"l'�quipement" GSITE ou "SYST�me" */
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

    if (AlarmCl = 'TRAPG') then		/* Trap g�n�rique SNMP */
	Ident := AlarmComment || ';' || to_char (AlarmNumobj) || ';0;' ;
    end if;

    if (AlarmCl = 'TRAPS') then		/* Trap sp�cifique SNMP */   
	Ident := AlarmComment || ';6;' || to_char (AlarmNumobj) || ';' ;
    end if;		-- Exemple : 2258;6;103;

    if (AlarmCl = 'TRAPG' or AlarmCl = 'TRAPS') then
	Id1 := GetStr (AlarmInfo, 0, ';');	-- EquipId du NE en d�faut
--	insert into test values (SEQ_TEST.NEXTVAL, 'Info '|| AlarmInfo);
--	insert into test values (SEQ_TEST.NEXTVAL, 'ID1 '||Id1||' Ident '||Ident);

	for vTr in CTrap (Id1, Ident) loop
	    IsAccesId := vTr.ACCES_ACCESC_ID;
--	    insert into test values (SEQ_TEST.NEXTVAL, 'IsAccesId '||IsAccesId);
	    Cable := TRUE;
	    exit;
	end loop;

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

    if (AlarmCl = 'IS' and AlarmTxt = 3) then	/* Alarme syst�me sur une IS */
	EquipRef := 'IS ' || lpad (To_Char (AlarmNumobj), 2);
	for vGy in CSystem loop
	    IsAccesId := vGy.EQUIP_ID;  /* dans ce cas, IsAccesId correspond � l'Id de 
					"l'�quipement" IS */
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

    if (AlarmCl = 'IS_S') then		/* Alarme s�rie */
    	Nb   := FLOOR (TO_NUMBER (AlarmNumal) / 10000);
	NumCarte := FLOOR (Nb / NbAcc) +1;
	NumAcc	 := MOD (Nb, NbAcc) +1;
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
	    NumAcc	 := MOD (TO_NUMBER (AlarmNumal) -1, 48) +1;
	    EquipRef := 'IS ' || lpad (To_Char (AlarmNumobj), 2) || '/GTR ' ||
		         lpad (To_Char (NumCarte), 2);
	else				/* IP2PORT */
	    /* Recherche de l'�quipement IP2PORT ou NEC (IDU/MIU) ou IP2CHOICE ayant �mis l'alarme */
	    Id1 := GetStr (AlarmInfo, 0, ';');	-- EquipId du NE en d�faut

	    select SITE_EQUIP_COMMENT into EquipRef
		from EQUIP
		WHERE EQUIP_ID = Id1;

	    /* Recherche de l'acc�s de l'IP2PORT ayant provoqu� l'alarme.
		Cet acc�s est la premi�re des variables du Trap.
		Cette premi�re variable se pr�sente sous la forme Event_code = DIGn_ON ou
		Event_code = DIGn_OFF o� n est le num�ro de l'entr�e alarme sur l'IP2PORT */
	    Pos := INSTR (AlarmInfo, '=');		-- premi�re variable
	    Pos := INSTR (AlarmInfo, 'DIG', Pos);
	    Pos2 := INSTR (AlarmInfo, '_', Pos);
	    NumAcc := TO_NUMBER (SUBSTR (AlarmInfo, Pos + 3, Pos2 - Pos - 3)); 

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
/	


/*
*	Cr�ation JPB 1998
*
*	Modification X.L. le 22/08/02 pour prise en compte des TRAPS fictifs SNA
*	Ces traps sont consid�r�s comme �tant �mis par l'entreprise Futurocom
*	Les renseignements dans ALARMGEREE sont suffisants. On renvoie donc
*	la gravit� d'origine qui s'y trouve.
*
*	Modifi� JPB le 10/11/02 : am�lioration des traitements de traps, homog�nisation
*	de ALARM_INFO en d�but et fin d'alarme. Suppression d'�critures parasites.
*	Modifi� JPB le 20/12/02 : modification de l'appel de LookupIndex, pour le traitement
*	des traps 190 et 191 du XNA
*
*	Modif X.L. le 10/01/03 pour trap SmartJog envoy�s par l'agent Futurocom
*	Ajout du param�tre addresse IP � la fonction LookupIndex.
*
*	Modif X.L. le 30/01/03 pour prise en compte des TRAPS fictifs AM32.
*	Ces traps sont consid�r�s comme �tant �mis par l'entreprise Futurocom
*	Les renseignements dans ALARMGEREE sont suffisants. On renvoie donc
*	la gravit� d'origine qui s'y trouve.
*
*	Modif. X.L. le 09/04/03 pour prise en compte de l'IP2PORT comme �quipement
*	de collecte d'alarme boucle
*
*	Modif. JPB le 19/06/03 : utilisation du trap fictif '9485;6;20;', utilis�
*	pour faire retomber une alarme en cours.
*
*       Modif. JPB le 22/07/03 : plus de traitements sp�cifiques en fonction des traps et 
*       des constructeurs. L'aspect sp�cifique est report� dans certaines fonctions de 
*       SpvTrap2Svc.
*       Donc : suppression de LookupIndex et tib_trap. Modification de tib_alarm
*       Suppression du traitement TRAP. Seuls sont conserv�s TRAPG ou TRAPS.
*	Init de ALARM_AQUITTEE, ALARM_ACQUITWHO et ALARM_ACQUITWHEN.
*	
*	Modif. JPB le 08/10/03 : utilisation du trap fictif '9485;6;21;', utilis�
*	pour d�clencher manuellement une alarme.
*	On trouve en VarBinds les valeurs suivantes, dans cet ordre :
*		- ALARM_GRAVE
*		- ALARM_CL
*		- ALARM_TEXTE
*		- ALARM_NUMOBJ
*		- ALARM_NUMAL
*		- ALARM_IANA
*		- ALARM_INFO
*
*	Modif. X.L. le 10/03/04 : correction d'un bug. Curseur CxionG, dans la clause where, ajout de la condition
*	ACCES1_ID et ACCES2_ID � 0. En effet, on peut avoir des enregistrements dont ACCES1_ID et/ou ACCES2_ID
*	diff�rents de 0 avec m�me ACCES_BINDINGID.
*
*	Modif JPB le 18/02/05   : correction d'une erreur concernant les TRAPG, lors de la retomb�e d'alarme : elle ne se faisait pas.
*	
*	Modif ZN le 04/01/06 : 1.Utilisation du trap de commutation.
*			       2.Sauvegarde d'etat des commutateurs dans equip.commut.
*
*	Modif JPB le 08/05/06	: le traitement du trap 20 �tait en commentaire. On avait une erreur avec l'ordre  AlarmId := TO_NUMBER (:new.ALARM_INFO);
*
*	Modif JPB le 20/12/06 	: traitement des alarmes bagottantes.
*				  La gravit� des alarmes est choisie par l'op�rateur, et non prise dans le trap : demande GG + C Gavoille
*				  (lue dans ACCES_ACCESC_REP ou BITMESS_REP).
*
*   	Modif JPB le 30/03/07 : suppression temporaire du traitement BAGOT, en raison des blocages d�tect�s avec PurgeBagot
*

*	Modif XL le 25/06/09 : si ALARM_NUM est vide, on l'initialise � ALARM_ID.
*
*/
create or replace
TRIGGER tib_alarm before insert on ALARM for each row
declare
    IsAccesId	integer;	/* ACCES_ID correspondant au n� IS et NUMAL (ou n� IP2PORT et NUMAL) */
    NumBit   	NUMBER;		/* n� bit si alarme s�rie : 1 .. */
    OrigAccesId integer;	/* ACCES_ID de l'objet � l'origine de l'alarme */
    MessId	integer;	/* ID du message s�rie correspondant � cette alarme */
    ScriptId	integer;	/* Id du script � d�clencher �ventuellement */
    Nb		integer;	/* Nb. banal */
    Str		varchar2 (80);  /* banal */
    StrTest	varchar2 (1024);/* pour insert en table TEST */
    OldId	integer;	/* ID de l'alarme d�j� pr�sente sur cet acc�s */
    Grave	number;		/* gravit� r�elle de l'alarme */
    lGrave	number;		/* valeur temporaire de la gravit� */
    CablageId	number;		/* ID de ACCES_ACCESC ou BITMESS de cette alarme */
    MaskAdm	boolean;	/* true si al. masqu�e par Adm, false sinon */
    Info	varchar2 (256);	/* ALARM_INFO, pour alarme GSITE */
    Pos		NUMBER;		/* Position dans une cha�ne de caract�re */
    Pos2	NUMBER;		/* idem */
    AlarmId	NUMBER;		/* Id de l'alarme � faire retomber */
    ARetomber   BOOLEAN;	/* true si "Alarme � faire retomber" */
    commutOID	varchar2 (128);	/*typeq.commut-OID*/
    typeq_commut number;
    EquipState   number; 	/*l'etat du commutateur*/
    DecalGrave   number; 	/* d�calage entre la valeur de la gravit� dans les combo et dans la base.
			  	   Combo 0="Avertissement" .. cod� 3 dans la base */
    Signat	varchar2 (1256);/* Signature de l'alarme :
					ALARM_CL + ALARM_NUMOBJ + ALARM_NUMAL
					+ ALARM_INFO si ALARM_TEXTE = 3 ou 4 (GSITE ou Syst�me)
					+ ALARM_IANA + EquipId si ALARM_CL = TRAPG ou TRAPS */
    BagotId	 number;	/* Id dans la table BAGOT */
    BagotEC	 number;	/* Bagot en cours */
    BagotCpt	 number;	/* Compteur de bagots */
    BagotAlId	 number;	/* Id de l'alarme pr�c�dente */
    BagotAlIddeb number;	/* Id de l'alarme pr�c�dente */
    ModCalc number; -- Mode de calcul standard ou NEC
    
    AlarmSec            ALARME.ALARME_SECDEBUT%TYPE;
    AlarmDate           ALARME.ALARME_DATEDEBUT%TYPE;
    AlarmeSecDebut      ALARME.ALARME_SECDEBUT%TYPE;
    SiteId              ALARME.SITE_ID%TYPE;
    EquipId             ALARME.EQUIP_ID%TYPE;
    LiaiId              ALARME.LIAI_ID%TYPE;
    NumeroIana          ALARME.ALARME_IANA%TYPE;
    AlarmegereeTypAl    ALARME.ALARMGEREE_TYPAL%TYPE;
    AlarmeLocale        ALARME.ALARMGEREE_LOCAL%TYPE;
    AccesAccescId       ACCES_ACCESC.ACCES_ACCESC_ID%TYPE;
    AlarmeVSeuil        ALARME.ALARME_VSEUIL%TYPE;
    AlarmgereeNSeuil    ALARME.ALARMGEREE_NSEUIL%TYPE;
    AlarmgereeNom       ALARMGEREE.ALARMGEREE_NOM%TYPE;
    AlarmgereeTypAl     ALARMGEREE.ALARMGEREE_TYPAL%TYPE;
    AlarmeComment       ALARME.ALARME_COMMENT%TYPE;
    AlarmgereeSeuilOid  ALARMGEREE.ALARMGEREE_SEUILOID%TYPE;
    AlarmIdDeb          ALARM.ALARM_ID%TYPE;
    AlarmeAck           ALARME.ALARME_ACK%TYPE;
    AlarmeAckWho        ALARME.ALARME_ACKWHO%TYPE;
    AlarmeAckWhen       ALARME.ALARME_ACKWHEN%TYPE;
    

    cursor CxionP is			/* IS GTR ou IP2PORT */
	     select * from ACCES_ACCESC	where ACCES2_ID = IsAccesId;

    cursor CxionG is			/* GSITE ou alarme SYST�me */
	     select * from ACCES_ACCESC 	where ACCES_BINDINGID = IsAccesId
	     and ACCES1_ID = 0 and ACCES2_ID = 0;

    cursor CxionTGS is 			/* Trap SNMP g�n�rique ou sp�cifique */
	     select * from ACCES_ACCESC where ACCES_ACCESC_ID = IsAccesId;

    cursor CBagot (Sig VARCHAR2) is	/* Recherche de l'alarme dans la table BAGOT */
	select * from BAGOT
	where BAGOT_SIG = Sig;

    cursor cAlarmOld (Id NUMBER) is	/* Donn�es de l'alarme pr�c�dente */
	select * from ALARM
	where ALARM_ID = Id;

 /*  cursor cAlarm2Old (Id NUMBER) is	-- Donn�es de l'alarme pr�c�dente
	select * from ALARM2
	where ALARM2_ID = Id;

    cursor cAlarm3Old (Id NUMBER) is	-- Donn�es de l'alarme pr�c�dente
	select * from ALARM3
	where ALARM3_ID = Id;*/

begin
    AlarmeLocale := 1;
    
    /* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
       on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
	return;
    end if;

    if (:new.ALARM_NUM is null) then
        :new.ALARM_NUM := :new.ALARM_ID;
    end if;

    ModCalc := GetModCalc;		-- Mode de calcul standard ou NEC

--    lock table ACCES_ACCESC in share row exclusive mode;
	/* Ce lock sur la table ACCES_ACCESC permet d'�viter un interblocage
	entre deux sources d'alarmes */

    AlarmSec := CO_SEC1998 (:new.ALARM_DATE);
    AlarmDate := CO_DATE (:new.ALARM_DATE);
    
    ScriptId 	:= 0;	/* pas de script � d�clencher � priori */
    ARetomber 	:= false;

    AlarmeSecDebut := NULL;

    DecalGrave := 3;

    if (ToNumber (:new.ALARM_COMMENT) >= 0 and CheckStr (:new.ALARM_COMMENT, '0123456789') = 1) then
	       NumeroIana := ToNumber (:new.ALARM_COMMENT);
    end if;

--  On regarde d'abord les alarmes syst�me FUTUROCOM (9485) envoy�s par TRAP :
--  N� Trap = 20	: retomb�e d'alarme en cours

    if (:new.ALARM_CL = 'E10B') then	-- Une alarme autocom. Alcatel E10B est consid�r�e comme un TRAPS
	       :new.ALARM_CL := 'TRAPS';
    end if;

    if (:new.ALARM_CL = 'TRAPS' and :new.ALARM_COMMENT = 9485 and :new.ALARM_NUMOBJ = 20) then
      	Pos  := INSTR  (:new.ALARM_INFO, '=');
      	Pos2 := INSTR  (:new.ALARM_INFO, ';', Pos);
      	Str  := SUBSTR (:new.ALARM_INFO, Pos+2, Pos2 - Pos -2);

      	AlarmId := TO_NUMBER (Str);
      --	AlarmId := TO_NUMBER (:new.ALARM_INFO);

      	select ALARM_CL, ALARM_TEXTE, ALARM_NUMOBJ, ALARM_NUMAL, ALARM_INFO, 
                ALARME_IANA, ALARMGEREE_TYPAL, ALARME_SECDEBUT
      	    into :new.ALARM_CL, :new.ALARM_TEXTE, :new.ALARM_NUMOBJ, :new.ALARM_NUMAL,
      		 :new.ALARM_INFO, :new.ALARM_COMMENT, AlarmegereeTypAl, AlarmeSecDebut
      	    from ALARM, ALARME
      	    where ALARM_ID = AlarmId and ALARME.ALARM_IDDEB = AlarmId;
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
    end if; --  N� Trap = 20	: retomb�e d'alarme en cours

--  N� Trap = 21	: mont�e manuelle d'une alarme
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
    	Str  := SUBSTR (:new.ALARM_INFO, Pos+2);	-- Tous les caract�res suivants
    	Str  := REPLACE (Str, '}', ';');
    	StrTest := StrTest || Str || ' | ';
    	:new.ALARM_INFO := Str;

    --	insert into test values (seq_test.nextval, StrTest);
    end if; --  N� Trap = 21	: mont�e d'une alarme


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
    	end if;		/* recherche de l'Id de l'acc�s sur l'IS */
    end if;

    if (NOT ARetomber and :new.ALARM_CL = 'IP2') then	/* La gravit� est contenue dans ALARM_INFO */
    	/* La gravit� (d�but ou fin d'alarme) est contenue dans le libell� de l'�v�nement
	   ayant provoqu� le trap. Cet �v�nement est d�crit dans la premi�re variable
	   du trap, sous la forme DIGn_ON (d�but d'alarme) ou DIGn_OFF (fin d'alarme).
	   Le "trap" IP2 est transform� en alarme boucle dans SpvTrap2Svc. Ici, ce n'est
	   donc plus un trap, mais une alarme boucle.
	*/
      	Pos  := INSTR (:new.ALARM_INFO, '=');		-- premi�re variable
      	Pos  := INSTR (:new.ALARM_INFO, '_', Pos);
      	Pos2 := INSTR (:new.ALARM_INFO, ';', Pos);
      	Str  := SUBSTR (:new.ALARM_INFO, Pos + 1, Pos2 - Pos - 1);

      	if (Str = 'ON') then
      	    Grave := 4;				-- d�but d'alarme
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
      		    Grave		:= :new.ALARM_GRAVE;	-- Gravit� calcul�e dans l'EM
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

    /* Recherche de OrigAccesId (Id de l'acc�s alarme sur l'�lt. g�r�) */
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

    elsif (:new.ALARM_CL = 'TRAPG' or :new.ALARM_CL = 'TRAPS') then	/* TRAP SNMP G�n�rique ou sp�cifique */
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

        -- La gravit� est choisie par l'op�rateur demande GG + C GAVOILLE
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
    else			/* Alarme syst�me */
      	OrigAccesId := 0;
      	Grave := :new.ALARM_GRAVE;
      	:new.ALARMGEREE_ID := 1;
      	:new.ALARM_COMMUT  := 0;
      	Info := :new.ALARM_INFO;
      	:new.ALARM_INFO	   := 'Alarme systeme :' || Info;

    end if;	/* recherche de l'Id de l'acc�s sur l'�l�ment g�r� (�quip. par exemple) */

 --   insert into test values (seq_test.nextval, 'tib_alarm1 :new.ALARM_Grave = '|| :new.ALARM_Grave);

    if (ModCalc=1 and :new.ALARM_CL = 'TRAPS') then --NEC, pour les traps on prend la gravit� dans le trap
      Grave := :new.ALARM_GRAVE;		   --pour les acc�s boucle, on prend la gravit� de l'alarme g�r�e.
    end if;

    /* Recherche de l'�l�ment g�r� en d�faut */
    if (:new.ALARM_CL = 'GSITE' or :new.ALARM_CL = 'SYST' or :new.ALARM_CL = 'TRAP' or
	(:new.ALARM_CL = 'IS' and :new.ALARM_TEXTE = 3)) then
	EquipId := IsAccesId;
	SiteId := NULL;
	LiaiId := NULL;

    elsif (:new.ALARM_CL = 'TRAPG' or :new.ALARM_CL = 'TRAPS') then
	/* EQUIP_ID est d�j� rempli */
	SiteId := NULL;
	LiaiId := NULL;

    else
    	select SITE_ID, EQUIP_ID, LIAI_ID
	    into SiteId, EquipId, LiaiId
 	    from ACCES
	    where ACCES_ID = OrigAccesId;	/* recherche de l'�l�ment g�r� en d�faut */
    end if;

    /*d�j� fait pour les TRAPS*/
    if (:new.ALARM_COMMUT > 0 and :new.ALARM_CL <> 'TRAPG' and :new.ALARM_CL <> 'TRAPS') then
        if(:new.ALARM_GRAVE=0) then
            EquipState :=1;
     	else
	    EquipState := Grave - DecalGrave +2;
	end if;
	update equip_rep set equip_commut = EquipState where equip_id = EquipId;
    end if;

    if (:new.ALARM_GRAVE > 0) then	/* D�but d'alarme */
	     :new.ALARM_GRAVE := Grave;
      	if (:new.ALARM_COMMUT = 0) then
      	    select ALARMGEREE_NOM, ALARMGEREE_TYPAL, ALARMGEREE_LOCAL, ALARMGEREE_NSEUIL,
  	       ALARMGEREE_SEUILOID, ALARMGEREE_COMMENT
                  into AlarmgereeNom, AlarmgereeTypAl, AlarmeLocale, AlarmgereeNSeuil,
                        AlarmgereeSeuilOid, AlarmeComment
      	        from ALARMGEREE
  	        where ALARMGEREE_ID = :new.ALARMGEREE_ID;
                
                if (AlarmgereeSeuilOid is not null) then -- alarme de seuil
                    if (not ExtractValeurSeuil (:new.alarm_info, AlarmeVSeuil)) then
                        raise_application_error (-20000, 'Threshold message format not compliant');
                    end if;
                end if;
        else
            AlarmeLocale := 1;
        end if;

            -- Alarme GTR ou GSITE ou Alarme Syst�me ou TRAP
      	    update ACCES_ACCESC_REP
      	        set 	ALARM_ID   = :new.ALARM_ID,
      			ALARM_SEC  = CO_SEC1998 (:new.ALARM_DATE),
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
            -- Alarme GTR ou GSITE ou Alarme Syst�me ou TRAP
      	    if (AlarmIdDeb is NULL) then
            	    	select ALARM_ID, ALARM_SEC into AlarmIdDeb, AlarmeSecDebut
         	 	    from ACCES_ACCESC_REP
      		    where ACCES_ACCESC_ID = AccesAccescId; 	/* Id du d�but d'alarme correspondant */
      	    end if;

      	    update ACCES_ACCESC_REP
        		set 	ALARM_ID   = NULL,
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

    if (AlarmIdDeb is not NULL and (AlarmeSecDebut is NULL)) then
	select ALARME_SECDEBUT into AlarmeSecDebut
   	    from ALARME
	    where ALARM_IDDEB = AlarmIdDeb;
    end if;

    if (MaskAdm) then
	:new.ALARMGEREE_ID := 0;
--	:new.ALARM_LOCAL   := 0;
  	:new.ALARM_COMMUT  := 0;
	SiteId	   := NULL;
    end if;

    AlarmeAck     := 0;     -- alarme non encore acquitt�e
    AlarmeAckWho  := NULL;
    AlarmeAckWhen := NULL;
    
    insert into ALARM_TEMP (ALARM_ID, ALARMGEREE_ID, ALARM_IDDEB, ALARM_NUM, ALARM_CL, ALARM_NUMOBJ,
                            ALARM_NUMAL, ALARM_DATE, ALARM_HINSERT, ALARM_GRAVE, 
                            ALARM_COMMUT, ALARM_TEXTE, ALARM_INFO, ALARM_COMMENT, 
                            ALARM_TYPMAJ, ALARM_NBRSEQ)
    values (:new.ALARM_ID, :new.ALARMGEREE_ID, :new.ALARM_IDDEB, :new.ALARM_NUM, :new.ALARM_CL, :new.ALARM_NUMOBJ,
                            :new.ALARM_NUMAL, :new.ALARM_DATE, :new.ALARM_HINSERT, :new.ALARM_GRAVE, 
                            :new.ALARM_COMMUT, :new.ALARM_TEXTE, :new.ALARM_INFO, :new.ALARM_COMMENT, 
                            :new.ALARM_TYPMAJ, :new.ALARM_NBRSEQ);
                            
    if (AlarmIdDeb is null) then    -- D�but d'alarme
        insert into ALARME (ALARM_IDDEB, ALARME_SECDEBUT, SITE_ID, EQUIP_ID, LIAI_ID, ALARME_IANA,
                            ALARMGEREE_LOCAL, ACCES_ACCESC_ID, ALARME_VSEUIL, ALARMGEREE_NSEUIL,
                            ALARMGEREE_NOM, ALARMGEREE_TYPAL,
                            ALARME_COMMENT, ALARME_ACK, ALARME_ACKWHO, ALARME_ACKWHEN)
                    values (:NEW.ALARM_ID, AlarmeSecDebut, SiteId, EquipId, LiaiId, NumeroIana,
                            AlarmeLocale, AccesAccescId, AlarmeVSeuil, AlarmgereeNSeuil,
                            AlarmgereeNom, AlarmgereeTypAl,
                            AlarmeComment, AlarmeAck, AlarmeAckWho, AlarmeAckWhen);
    else                            -- Fin d'alarme, mettre � jour l'enregistrement ALARME existant
        update ALARME set ALARME_SECFIN = AlarmSec,
                          ALARME_DATEFIN = AlarmDate
        where ALARM_IDDEB = AlarmIdDeb;
    end if;

end tib_alarm;
/




/*
*	Traitement des alarmes bagottantes.
*	Ce job v�rifie l'�tat des alarmes qui bagottent (gr�ce � la table BAGOT), pour faire retomber celles qui se sont calm�es,
*	c'est � dire celles qui sont retomb�es depuis plus de deux minutes (tempo fixe, correspondant � la p�riode du job).
*
*	JP BORG	: 23/12/06. Cr�ation
*/
CREATE OR REPLACE PROCEDURE PurgeBagot (TFin NUMBER)
IS
    DateActu	  VARCHAR2 (20);	-- Date actuelle
    DateTFin	  NUMBER;		-- Date actuelle (en sec.) - TFin secondes

    Pos		  NUMBER;		-- Position recherch�e dans un string
    cc		  VARCHAR2 (1);		-- Caract�re lu

    AlarmId	  NUMBER;		-- Donn�es de l'alarme � recr�er.
    AlarmIddeb	  NUMBER;
    AlarmDebSec	  NUMBER;
    AlarmNum	  NUMBER;
    AlarmCl	  VARCHAR2 (11);
    AlarmNumObj	  NUMBER;
    AlarmNumal	  VARCHAR2 (40);
    AlarmDate	  VARCHAR2 (20);
    AlarmTexte	  NUMBER (2);
    AlarmComment  VARCHAR2 (256);
    AlarmInfo	  VARCHAR2 (1024);
    AlarmLocal	  NUMBER (1);
    AlarmGereeId  NUMBER;
    AlarmIANA	  NUMBER;
    AlarmSeq	  NUMBER;

    Cursor CBagot (DateFin NUMBER) is
	select * from BAGOT 
	    where BAGOT_TFINSEC > 0 and BAGOT_TFINSEC < DateFin; 
--	    for update of BAGOT_ID;

    Cursor cAlarm (Id NUMBER) is
	select * from ALARM
	    where ALARM_ID = Id;

BEGIN

    -- D�termination de l'heure actuelle, en sec.
    select to_char (sysdate, 'YYYY MM DD HH24:MI:SS') into DateActu from DUAL;
    DateTFin := CO_SEC1998 (DateActu) - TFin;

    for vBagot in CBagot (DateTFin) loop		-- on recherche les alarmes bagottantes retomb�es depuis plus de TFin / 60 minutes.
    	if (vBagot.Bagot_EC = 0) then
      -- settrace ('7');
	       delete BAGOT
		        where BAGOT_ID = vBagot.BAGOT_ID;	-- Ce n'�tait pas une alarme bagottante. Elle a �t� trait�e enti�rement.
	       commit;

	    else						-- Fin d'alarme bagottante
        -- settrace ('8');
  	    AlarmId := 0;
  	    for vAl in cAlarm (vBagot.ALARM_ID) loop	-- On doit remplacer la "Fin Bagottante" par une "Fin Normale"
      		AlarmId		:= vAl.ALARM_ID;
      		AlarmIddeb	:= vAl.ALARM_IDDEB;
  		    AlarmDebSec	:= vAl.ALARM_DEB_SEC;
    		  AlarmNum	:= vAl.ALARM_NUM;
      		AlarmCl		:= vAl.ALARM_CL;
      		AlarmNumObj	:= vAl.ALARM_NUMOBJ;
      		AlarmNumal	:= vAl.ALARM_NUMAL;
      		AlarmDate	:= vAl.ALARM_DATE;
      		AlarmTexte	:= vAl.ALARM_TEXTE;
      		AlarmComment	:= vAl.ALARM_COMMENT;

/*
		if (AlarmCl = 'TRAG' or AlarmCl = 'TRAPS') then
    			AlarmComment	:= vAl.ALARM_IANA;
    			AlarmInfo	:= substr (vAl.ALARM_INFO, 12, length (vAl.ALARM_INFO) -12);
		elsif (AlarmCl = 'GSITE') then
    			AlarmInfo	:= substr (vAl.ALARM_INFO, 15, length (vAl.ALARM_INFO) -15);
		else
    			AlarmInfo	:= vAl.ALARM_INFO;
		end if;
*/

      		if (AlarmCl = 'TRAG' or AlarmCl = 'TRAPS') then
          		    AlarmComment := vAl.ALARM_IANA;
      		end if;

      		-- On supprime tous les textes ajout�s devant le EquipId
      		Pos  := INSTR  (vAl.ALARM_INFO, ';') -1;
      
      		if (length (vAl.ALARM_INFO) > 0 and Pos > 0) then	
      		    loop
      		    	cc := SUBSTR (vAl.ALARM_INFO, Pos, 1);
      		    	if (ASCII (cc) < ASCII ('0') or ASCII (cc) > ASCII ('9')) then
      			    exit;
      		    	end if;
      
      		    	Pos := Pos -1;
      		    	if (Pos = 0) then
      			    exit;
      		    	end if;
      		    end loop;
      		end if;

      		if (Pos > 0) then
          		    AlarmInfo := substr (vAl.ALARM_INFO, Pos +1, length (vAl.ALARM_INFO) - Pos);
      		else
      		    AlarmInfo := vAl.ALARM_INFO;
      		end if;

    		  AlarmLocal	:= vAl.ALARM_LOCAL;
    		  AlarmGereeId	:= vAl.ALARMGEREE_ID;
    		  AlarmIANA	:= vAl.ALARM_IANA;
		      AlarmSeq	:= vAl.ALARM_NBRSEQ;
	      end loop;					-- 0 ou 1 alarme d�tect�e
		
	      delete BAGOT  where BAGOT_ID = vBagot.BAGOT_ID;

  	    if (AlarmId > 0) then
  	        delete ALARM  where ALARM_ID  = AlarmId;
  	        delete ALARM2 where ALARM2_ID = AlarmId;
  	        delete ALARM3 where ALARM3_ID = AlarmId;
  
  	        insert into ALARM (ALARM_ID, ALARM_NUM, ALARM_CL, ALARM_NUMOBJ, ALARM_NUMAL, ALARM_DATE, ALARM_GRAVE, ALARM_TEXTE,
  			           ALARM_COMMENT, ALARM_INFO, ALARMGEREE_ID, ALARM_IANA, ALARM_COMMUT, ALARM_NBRSEQ) values
  		    (AlarmId, AlarmNum, AlarmCl, AlarmNumObj, AlarmNumal, AlarmDate, 0, AlarmTexte, AlarmComment, AlarmInfo, AlarmGereeId,
  		     AlarmIANA, 0, AlarmSeq);
  	        -- On ne remplit pas IDDEB ici. Il sera calcul� dans TIB_ALARM, afin de correspondre au IDDEB enregistr� dans le Client SPV,
  	        -- ce qui permet de faire retomber l'alarme dans les listes d'ALC.
  
  	        update ALARM set
  		    ALARM_IDDEB    = AlarmIddeb,
  		    ALARM_DEB_SEC  = AlarmDebSec
  		    where ALARM_ID = AlarmId;
  	    	-- Maintenant, on met les bonnes valeurs pour ALARM_IDDEB et ALARM_DEB_SEC pour que les traitements ult�rieurs (consultation, calcul de QoS)
  	    	-- soient corrects sur le client SPV.
  	    end if;

	       commit;
	    end if;		-- BAGOT_EC > 0
    end loop;		-- for vBagot
END 	PurgeBagot;
/




/* 
    ZN 18/01/06
    Cette fonction trouve les noms des binding variables de trap et cr�e la chaine stBindingVarInfo comme
    <nom de var.visible1> = <valeur de var.visible1>;<nom de var.visible2> = <valeur de var.visible2>;...

	Modif JPB le 18/03/06 : d�calage de cette fonction, car elle est appel�e par PostAlrm etc...
*/

CREATE OR REPLACE FUNCTION BindingVarInfo 
(
	AlarmInfo 		VARCHAR2,
	EquipId			NUMBER,
	AlarmIana		NUMBER,
	AlarmNumObj             NUMBER
)
RETURN VARCHAR2 IS

    nbCount    NUMBER;	     /* resultat de la requ�te "select count(*) ..." */
    MibObjId   NUMBER;       /* MibObj_Id du trap */
    pos1       Number;	     /* debut d'information de binding variable */
    pos2       Number;	     /* fin d'information de binding variable */
    posVal     Number;	     /* debut de valeur de binding variable */
    stVal      VARCHAR2 (50);     /* valeur de binding variable */
    stBindingVarInfo VARCHAR2 (2000);

    Cursor cBindVar is 
		select MIBENUM_NOM, MIBENUM_VISIBLE from MIBENUM
		 where MIBOBJ_ID = MibObjId order by MIBENUM_CODE;

BEGIN

    pos1 	:= 1; 
    pos2 	:= 1; 
    posVal  	:= 1; 
    stVal 	:= '';
    stBindingVarInfo :='';

--    insert into test values (seq_test.nextval, 'EquipId = '||TO_CHAR(EquipId)||	' Iana = '||TO_CHAR(AlarmIana)|| 
--	' AlarmNumObj = '|| TO_CHAR(AlarmNumObj));

    /*substr (MIBOBJ_IANA, ...) because MIBOBJ_IANA has values like <iana>.xx.xx.xx */
    select count(*) into nbCount from mibobj, typeq_mibmodule, equip 
	where  mibobj.mibmodule_id = typeq_mibmodule.mibmodule_id 
	and typeq_mibmodule.typeq_id=equip.typeq_id 
	and equip.equip_id = EquipId
	and substr(MIBOBJ_IANA,1,INSTR(MIBOBJ_IANA,'.',1,1)-1) = TO_CHAR(AlarmIana)
	and MIBOBJ_TRAPNBR = AlarmNumObj;

    if (nbCount=1) then /*on connait la mib du trap*/

	select MIBOBJ_ID into MibObjId  from mibobj, typeq_mibmodule, equip 
	    where  mibobj.mibmodule_id = typeq_mibmodule.mibmodule_id 
		and typeq_mibmodule.typeq_id=equip.typeq_id 
		and equip.equip_id = EquipId
		and substr(MIBOBJ_IANA,1,INSTR(MIBOBJ_IANA,'.',1,1)-1) = TO_CHAR(AlarmIana)
		and MIBOBJ_TRAPNBR = AlarmNumObj;

	pos1 := INSTR(AlarmInfo, ';');
	for vBindVar in cBindVar  loop
	    pos2 := INSTR(AlarmInfo, ';', pos1+1, 1);
	    stVal := '';
	    if (vBindVar.MIBENUM_VISIBLE >0) then
		stBindingVarInfo := stBindingVarInfo || vBindVar.MIBENUM_NOM || ' = ';
		posVal := INSTR(AlarmInfo, '=', pos1+1, 1);
		
		if(posVal>0 and pos2>posVal) then
		    stVal := SUBSTR(AlarmInfo, posVal+1, pos2-posVal-1);
		end if;

		stBindingVarInfo := stBindingVarInfo || stVal || ';' ;
	    end if;
	
	    if(pos2>0) then
	    	pos1 := pos2;
	    end if;
	end loop;
	 
    end if; /*on connait la mib du trap*/

    return stBindingVarInfo;

END BindingVarInfo;
/


create or replace PROCEDURE INSERT_TRAPALARM
( 
  alarmId  number,
  alarmDate varchar2,
  alarmGrave 	number,
  alarmgereeId number ,
  equipId 	number
) AS

  TrapAlarmId NUMBER;
  alarmgereeNom Varchar2 (40);
  cnt         NUMBER;
    
  CURSOR curAlarmgereeNom(alarmGId number) is
    select alarmgeree_Nom from alarmgeree where alarmgeree_id=alarmGId;

BEGIN

  if (equipId is null) then -- ce n'est pas un alarm d'equipement 
	   return;
  end if;

  --On ne remplit pas la table trapalarm si l'agent Snmp Spv n'est pas lanc�.
  --L'agent Snmp Spv envoie des trapes est efface des recordes de la table trapalarm.
  --Si il n'est pas lanc� la table trapalarm sera aussi grande que la table alarme.

  select count(*) into cnt from param where PARAm_TYPE=9 and
                               PARAM_VALEUR='FillTrapAlarm = 1';
  if(cnt=0) then
	   return;
  end if;
 
  select seq_trapalarm.NEXTVAL into TrapAlarmId from dual;

  for vAlarmgereeNom in curAlarmgereeNom(alarmgereeId) loop
    alarmgereeNom:=vAlarmgereeNom.alarmgeree_Nom;
  end loop;

--on prend en compte que des alarmes d'equipements visibles par SNMP  
  select count(*) into cnt from MANAGER_OBJ where equip_id=equipId;
  if(cnt>0) then
    insert into trapalarm(trapalarm_id, alarm_id, alarm_date, alarm_grave,
                alarmgeree_id, alarmgeree_name, equip_id, trapalarm_sent)
                values (TrapAlarmId, alarmId, alarmDate, alarmGrave, alarmgereeId,
                alarmgereeNom, equipId, 0);
  end if;

END INSERT_TRAPALARM;
/

-- Modif. X.L. le 30/09/02 pour correction de la requ�te sur le type d'�quipement.
-- Cette requ�te doit inclure le classid car la table contient des types d'�quipements
-- et des types d'antennes. Donc si un type d'�quipement et un type d'antenne ont le m�me
-- nom, deux lignes sont renvoy�es par le select, ce qui g�n�re une erreur.
--
-- Modif JPB le 27/07/03 : ajout de "Aquittee"
--
-- Modif ZN le 18/01/06 : ajout de param�tre Iana; ajout de traitement des binding
-- variables des traps.
-- Modif JPB le 15/11/06 : Nouveau format de TsPrOper

/*
* PostAlrm
*/
create or replace
PROCEDURE PostAlrm (Id NUMBER, AlGereeId NUMBER, SiteId NUMBER, EquipId NUMBER,
    LiaiId NUMBER, AlarmNum NUMBER, AlarmCl VARCHAR2, AlarmNumObj NUMBER, 
    AlarmType NUMBER, AlarmDate VARCHAR2, AlarmGrave NUMBER, AlarmNseuil VARCHAR2,
    AlarmVseuil	NUMBER, AlarmNumal VARCHAR2, AlarmTexte NUMBER, AlarmInfo VARCHAR2,
    AlarmNomL VARCHAR2, AlarmComment VARCHAR2, AlarmLocal NUMBER, AlarmCommut NUMBER,
    AlarmIddeb NUMBER, CablSId NUMBER, CablPId NUMBER, Sonne NUMBER, Acquit NUMBER,
    Acquittee NUMBER, Iana NUMBER) 
IS
	-- Id est l'identifiant du nouveau message d'alarme (d�but ou fin).
    Mess     VARCHAR2 (1800);/* taille max. du message autoris� par Oracle : 1800 octets */
    ProgNb	NUMBER;	     /* Nb. de programmes concern�s par l'alarme */
    ProgNom  VARCHAR2 (40);  /* ' ' si pas de prog. concern� par cette alarme,
				nom du prog. si un seul prog. concern�,
				'+' si plusieurs prog. concern�s */
    ProgOper	NUMBER;	     /* Etat op�rationnel du programme concern� par cette alarme.
				0 si plusieurs programmes concern�s */
    ClientNom VARCHAR2 (40); /* ' ' si pas de client concern� par cette alarme,
				nom du client si un seul prog. concern�,
				'+' si plusieurs clients concern�s */
    SiteNom     VARCHAR2 (40);  /* nom du site contenant l'�lt. en d�faut. ' ' pour une liaison
				inter-site */
    Typequ   VARCHAR2 (40);  /* nom du type de l'�quipement ou de la liaison. 'SITE' 
				pour une alarme	de site */
    TypeqId  NUMBER;	     /* Id du type d'�quipement ou de liaison */
    Poseq    VARCHAR2 (80);  /* Position de l'�quipement ou nom de la liaison ou du site 
				en d�faut */
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
	     if not correl_alrm (Mess, Id, SiteId, EquipId, LiaiId, CO_SEC1998 (AlarmDate), AlarmGrave, AlarmIddeb, TsPrOper, Debord) then
				/* Traitement des corr�lations d'alarmes */
	       return;		/* Il n'y a plus rien � faire */
	     end if;

	     if IsMaskedAdm (AlarmCl, CablSId, CablPId) then
	       return;		/* l'alarme est masqu�e par l'Administrateur */
	     end if;
    end if;
    
 --   insert into test values (SEQ_TEST.NEXTVAL, 'PostAlrm : SiteId = '||SiteId ||
--      ' EquipId = '|| EquipId || ' LiaiId = ' || LiaiId);


    maj_oper (Id, SiteId, EquipId, LiaiId, AlarmLocal, AlarmGrave, AlarmCommut, ProgNb, SiteNom, Typequ, Poseq, TsPrOper, Debord);
				/* met � jour l'�tat op�rationnel de l'�l�ment g�r� en d�faut,
				   des CABLEQU et des programmes que cela concerne */
 --   insert into test values (SEQ_TEST.NEXTVAL, 'PostAlrm : TsPrOper = '||TsPrOper );

    if (Debord = 1) then
	     SStr := TsPrOper || 'Debordement';
    	 insert into ALARM2 (ALARM2_ID, ALARM2_TSPROPER) values (Id, SStr);
    else
    	 insert into ALARM2 (ALARM2_ID, ALARM2_TSPROPER) values (Id, TsPrOper);
    end if;


    CliConc := '';
    PrConc  := '';
    PrEtat  := '';

    SStr    := TsPrOper;
    SPos    := INSTR (SStr, ';') +1;
--    SStr    := SUBSTR (SStr, SPos);

    while (LENGTH (SStr) > 0) loop
	     SPos  := INSTR  (SStr, ',') -1;
	     SPrId := SUBSTR (SStr, 1, SPos);
	     
	     select PROG_NOM, B.PROG_OPER, CLIENT_NOM into ProgNom, ProgOper, ClientNom
	       from PROG A, PROG_REP B, CLIENT
	       where A.PROG_ID = to_number (SPrId) and
		      A.CLIENT_ID = CLIENT.CLIENT_ID and A.PROG_ID = B.PROG_ID;

	     CliConc  := CliConc || ClientNom || ';';

      -- Maj JL - V�rification si le programme est actif.
      select prog_actif into progActif from prog where prog_id = to_number (SPrId);

      if(progActif = 1) then	
    	 PrConc   := PrConc  || ProgNom   || ';';
 /*   	else	
    	 -- Modification de l'�tat op�rationnel du programme � 0.
  --  	 TsPrOper := SUBSTR(TsPrOper, 1, INSTR(TsPrOper, ',', 1)+2)||'0'||SUBSTR(TsPrOper, -3, 3);
 
     --modif ZN 26/12/07 -on change l'etat op�rationnel que du programme ou PROG_ID=SPrId
        TsPrOperTmp := ';' || TsPrOper;
        TsPrOperPos := INSTR(TsPrOperTmp, ';'||SPrId||',');
        
        if(TsPrOperPos>0) then --id est trouv�
          --commence par 2 pour supprimer la premier ';'
          TsPrOper := SUBSTR(TsPrOperTmp, 2, TsPrOperPos + LENGTH(SPrId) +2) ||'0'|| 
                      SUBSTR (TsPrOperTmp,TsPrOperPos + LENGTH(SPrId) +5);
        end if;*/
        
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

  /*  if (SiteId is not null) then
	     FEltG := GetDataFiche ('SITE', SiteId, 'SITE', SiteId);
    elsif (EquipId is not null) then
	     select TYPEQ_ID into TypeqId 
	     from TYPEQ  where TYPEQ_NOM = Typequ
	     and TYPEQ_CLASSID = 1024;
	     FEltG := GetDataFiche ('TYPEQ', TypeqId, 'EQUIP', EquipId);
    elsif (LiaiId is not null) then
      	select TYPLIAI_ID into TypeqId 
      	    from TYPLIAI
      	    where TYPLIAI_NOM = Typequ;
      	FEltG := GetDataFiche ('TYPLIAI', TypeqId, 'LIAI', LiaiId);
    end if;

    FAlG := GetDataFiche ('ALARMGEREE', AlGereeId, 'ALARMGEREE', AlGereeId);*/

    insert into ALARM3 (ALARM3_ID, ALARM3_CLICONC, ALARM3_PRCONC, ALARM3_PRETAT, 
			ALARM3_SITENOM, ALARM3_TYPEQ, ALARM3_EQTG, 
			ALARM3_FELTG, ALARM3_FALG)
	    values (Id, CliConc, PrConc, PrEtat, SiteNom, Typequ, Poseq, FEltG, FAlG);

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

    mess_alrm (Mess, Id, AlarmIddeb, AlGereeId, SiteId, EquipId, LiaiId, AlarmNum, AlarmCl, 
	       AlarmNumObj, AlarmType, AlarmDate, AlarmGrave, AlarmNseuil, AlarmVseuil, 
	       AlarmNumal, AlarmTexte, AlarmInfo, AlarmNomL, AlarmComment, AlarmCommut, 
	       PrConc, CliConc, PrEtat, SiteNom, Typequ, Poseq, TsPrOper, FEltG, FAlG, 
	       Sonne, Acquit, Acquittee, stBindingVarInfo);
	       
	  INSERT_TRAPALARM( Id, AlarmDate, AlarmGrave, AlGereeId, EquipId);

/*
    mess_video (Mess, Id, AlarmIddeb, AlGereeId, SiteId, EquipId, LiaiId, AlarmNum, AlarmCl, 
	       AlarmNumObj, AlarmType, AlarmDate, AlarmGrave, AlarmNseuil, AlarmVseuil, 
	       AlarmNumal, AlarmTexte, AlarmInfo, AlarmNomL, AlarmComment, AlarmCommut, 
	       PrConc, CliConc, PrEtat, SiteNom, Typequ, Poseq, TsPrOper, FEltG, FAlG);
*/
END PostAlrm;
/



create or replace trigger tu_alarm after update on ALARM for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    nb_rel           integer;     -- nombre de relations avec autres tables

begin
	/* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
	   on ne fait pas le traitement */
	if dbms_reputil.from_remote=TRUE then
		return;
	end if;

	nb_rel := 1;

	if (:old.SITE_ID is not null and :new.SITE_ID is null) then
		nb_rel := nb_rel - 1;
	end if;
	if (:old.SITE_ID is null and :new.SITE_ID is not null) then
		nb_rel := nb_rel + 1;
	end if;

	if (:old.EQUIP_ID is not null and :new.EQUIP_ID is null) then
		nb_rel := nb_rel - 1;
	end if;
	if (:old.EQUIP_ID is null and :new.EQUIP_ID is not null) then
		nb_rel := nb_rel + 1;
	end if;

	if (:old.LIAI_ID is not null and :new.LIAI_ID is null) then
		nb_rel := nb_rel - 1;
	end if;
	if (:old.LIAI_ID is null and :new.LIAI_ID is not null) then
		nb_rel := nb_rel + 1;
	end if;

	if (nb_rel != 1) then
      	    errno  := -20002;
	    errmsg := 'Un enr. dans ALARM doit avoir une et une seule relation avec une autre table';
	    raise integrity_error;
	end if;

--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end tu_alarm;
/


-- 
-- Cette proc�dure, activ�e toutes les 24 H, nettoie les alarmes les plus anciennes
-- (ie, toutes celles ayant commenc� � une date correspondant � la date du jour - xx mois)
-- De m�me, elle supprime les erreurs les plus anciennes, si le nb. d'enregistrements 
-- est sup�rieur � yy ainsi que les mails, si leur nombre d�passe zz
-- Ces trois param�tres (xx, yy, zz) sont pass�s � l'appel. Ils proviennent de Config.spv
--
-- La proc�dure teste aussi si on est en mode r�pliqu� et si dans ce cas, il s'agit du serveur
-- de secours. Dans ce cas l�, on vide enti�rement les tables MAILALRM et MESSALRM.
--
-- Valeurs autoris�es : 30 =< MaxJoursAl <= 48, 100 =< MaxErr <= 50000, 0 =< MaxMail <= 10000,
-- 0 =< MaxLog <= 10000
--
-- Modif. X.L. le 26/03/04 : purge �galement le contenu des tables MESSEM et MESSEMREAD
-- pour les enregistrements plus anciens ou �gaux � j-2.
--
-- Modif. X.L. le 12/07/05 pour avoir une finesse de la journ�e au niveau de la conservation
-- des alarmes plut�t que le mois.
--
-- Modif. JPB  le 26/07/05 pour mettre le minimum de jours � 10 (vs. 30) : demande GG
--
-- Modif. X.L. le 16/01/07 car la fonction IsSecours de l'utilisateur sys n'est plus exploitable
-- depuis l'abandon de la r�plication oracle. On a donc cr�� une telle fonction au niveau
-- du propri�taire des tables.
--
-- Modif. JF.L le 23/01/07 : ajout des tables GDCSVC, GDCSVC_TEMP, GDCSVC_TEMP2, LIAIVPIVCI, LIAIVPI,
-- PROG_LIAITEMP et VERROU au job de purge pour chaque serveur secours.
--
create or replace
PROCEDURE PurgeAlarmes (iMaxJoursAl NUMBER, iMaxErr NUMBER, iMaxMail NUMBER, iMaxLog NUMBER)
IS
    LastDayStr	VARCHAR2 (20);	-- date et heure actuelle - MaxJoursAl au format YYYY MM DD HH24:MI:SS
    LastDaySec	NUMBER;		-- idem en nombre de secondes depuis le 01/01/1998 00:00:00

    IdErrMax	NUMBER;		-- Id de la donn�e la plus r�cente
    IdErrMin	NUMBER;		-- Id de la donn�e la plus ancienne conserv�e

    SSecours	BOOLEAN;	-- False si c'est un serveur Normal, ou pas de r�plication
				-- True  pour le serveur Secours en r�plication
    MaxJoursAl	NUMBER;		-- Nb. max. de jours d'alarmes � garder
    MaxErr	NUMBER;		-- Nb. max. d'erreurs � garder
    MaxMail	NUMBER;		-- Nb. max. de mails � garder
    MaxLog	NUMBER;		-- Nb. max. de logs � garder

    MyDate	DATE;
BEGIN

    -- S�curit� sur les param�tres : valeurs autoris�es

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

    -- On supprime d'abord les fins d'alarme, correspondant � une alarme ayant d�marr� avant Idmax

    delete ALARM2 where ALARM2_ID in
	(select B.ALARM_ID from ALARM A, ALARM B
	     where A.ALARM_SEC <= LastDaySec and A.ALARM_ID = B.ALARM_IDDEB);
    delete ALARM3 where ALARM3_ID in
	(select B.ALARM_ID from ALARM A, ALARM B
	     where A.ALARM_SEC <= LastDaySec and A.ALARM_ID = B.ALARM_IDDEB);
    delete ALARM where ALARM_ID in
	(select B.ALARM_ID from ALARM A, ALARM B
	     where A.ALARM_SEC <= LastDaySec and A.ALARM_ID = B.ALARM_IDDEB);

    -- On supprime maintenant les alarmes ayant d�marr� avant LastDaySec

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

    -- Enfin, on met ALARM � jour

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

    -- On v�rifie si on est en mode r�pliqu� et dans ce cas, si on est "Secours"

    -- SSecours := Sys.Spv_Sys.IsSecours;
    SSecours := IsSecours;

    if (SSecours) then
	--	delete MAILALRM;
		delete MESSALRM;
		delete LOGSPV;
	   	delete GDCSVC;
   		delete GDCSVC_TEMP;
   		delete GDCSVC_TEMP2;
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
	(SEQ_LOGSPV.NEXTVAL, sysdate, 'Processus de purge effectu�');

    commit;

--  gestion des erreurs
EXCEPTION
    when OTHERS then
	rollback;
	insert into LOGSPV (LOG_ID, LOG_DATE, LOG_TEXT) values
	    (SEQ_LOGSPV.NEXTVAL, sysdate, 'Processus de purge : exception rencontr�e');
	commit;

END	PurgeAlarmes;
/


-- 
-- Cette proc�dure, activ�e toutes les 24 H, recopie le compteur d'alarmes rejet�es contenu
-- dans TESTEM de la colonne TESTEM_CURRENTREJECTEDAL � la colonne TESTEM_PREVIOUSREJECTEDAL
--
-- X.L. Cr�ation le 29/08/05
-- X.L. Modif. 23/06/06 pour ajouter la mise � jour de la colonne testem_totalrejectedal.
-- cette mise � jour avait �t� faite � une �poque et perdue des scripts par la suite.
--
CREATE OR REPLACE PROCEDURE SaveTestEmAlCounter
IS

BEGIN
    UPDATE testem SET	testem_totalrejectedal = testem_currentrejectedal - testem_previousrejectedal,
			testem_previousrejectedal = testem_currentrejectedal;

    commit;

--  gestion des erreurs
EXCEPTION
    when OTHERS then
	rollback;
	insert into LOGSPV (LOG_ID, LOG_DATE, LOG_TEXT) values
	    (SEQ_LOGSPV.NEXTVAL, sysdate, 'Processus SaveTestEmAlCounter : exception rencontr�e');
	commit;

END	SaveTestEmAlCounter;
/



--    FIN DE ALARM   ------------------------------------------

--    FINALARM   ----------------------------------------------
--
/*
* Start_Alrm
*/
--
-- Modif. X.L. le 23/02/04. L'appel � la fonction mess_alrm () est conditionn�
-- au fait que l'alarme soit � afficher (IsToAff ()).
--
create or replace
PROCEDURE Start_Alrm (Id NUMBER, AlGereeId NUMBER, SiteId NUMBER,
    EquipId NUMBER, LiaiId NUMBER, AlarmNum NUMBER, AlarmCl VARCHAR2, AlarmNumObj NUMBER,
    AlarmType NUMBER, AlarmDate VARCHAR2, AlarmGrave NUMBER, AlarmNseuil VARCHAR2,
    AlarmVseuil	NUMBER, AlarmNumal VARCHAR2, AlarmTexte NUMBER, AlarmInfo VARCHAR2,
    AlarmNomL VARCHAR2, AlarmComment VARCHAR2, AlarmLocal NUMBER, AlarmCommut NUMBER,
    AlarmIddeb NUMBER, CablSId NUMBER, CablPId NUMBER, Acquittee NUMBER, Iana NUMBER,
    TsPrOper IN OUT VARCHAR2, Debord IN OUT NUMBER)

IS
    Mess   VARCHAR2 (1800);  /* taille max des messages Oracle */

    ProgNb	NUMBER;	     /* Nb. de programmes concern�s par l'alarme */
    ProgNom  VARCHAR2 (40);  /* ' ' si pas de prog. concern� par cette alarme,
				nom du prog. si un seul prog. concern�,
				'+' si plusieurs prog. concern�s */
    ClientNom  VARCHAR2 (40);  /* ' ' si pas de client concern� par cette alarme,
				nom du client si un seul  concern�,
				'+' si plusieurs concern�s */
    ProgOper 	NUMBER;	     /* Etat op�rationnel du programme concern�. 0 si plusieurs */

    SiteNom     VARCHAR2 (40);  /* nom du site contenant l'�lt. en d�faut. ' ' pour une liaison
				inter-site */
    Typequ   VARCHAR2 (40);  /* nom du type de l'�quipement ou de la liaison. 'SITE'
				pour une alarme	de site */
    TypeqId  NUMBER;	     /* Id de ce type d'�quipement ou liaison */

    Poseq    VARCHAR2 (80);  /* Position de l'�quuipement ou nom de la liaison ou du site
				en d�faut */
    FEltG    VARCHAR2 (4000);/* Consigne de l'�l�ment g�r� en d�faut */
    FAlG     VARCHAR2 (4000);/* Consigne de l'alarme g�r�e */

    Al2Fait	 BOOLEAN;    /* Si des alarmes masqu�es BRI surviennent, ALRM2 sera �crit.
				Au moment du d�masquage d'une alarme en cours, il ne faut pas
				l'�crire � nouveau, sinon erreur PK_ALARM2 */
    Al3Fait	 BOOLEAN;    /* Si des alarmes masqu�es BRI surviennent, ALRM3 sera �crit.
				Au moment du d�masquage d'une alarme en cours, il ne faut pas
				l'�crire � nouveau, sinon erreur PK_ALARM3 */

    CliConc  VARCHAR2 (1000);/* nom des clients concern�s par l'alarme */
    PrConc   VARCHAR2 (1000);/* nom des programmes concern�s */
    PrEtat   VARCHAR2 (100); /* �tat des programmes concern�s */
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
        select PROG_NOM, B.PROG_OPER, CLIENT_NOM
            from PROG A, PROG_REP B, CLIENT
	    	where A.PROG_ID = SPrId and
		      A.CLIENT_ID = CLIENT.CLIENT_ID and
		      A.PROG_ID = B.PROG_ID;
BEGIN

    if (not IsMaskedAdm (AlarmCl, CablSId, CablPId)) then

--        insert into test values (SEQ_TEST.NEXTVAL, 'Start_Alrm: SiteId = '||SiteId ||
 --     ' EquipId = '|| EquipId || ' LiaiId = ' || LiaiId);

    	maj_oper (Id, SiteId, EquipId, LiaiId, AlarmLocal, AlarmGrave, AlarmCommut, ProgNb, SiteNom, Typequ, Poseq, TsPrOper, Debord);

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

    	CliConc := '';
    	PrConc  := '';
    	PrEtat  := '';
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
                ClientNom := rCProg.CLIENT_NOM;
                ProgNom := rCProg.PROG_NOM;
                ProgOper := rCProg.PROG_OPER;
                CliConc  := CliConc || ClientNom || ';';
                PrConc   := PrConc  || ProgNom   || ';';
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
				ALARM3_SITENOM, ALARM3_TYPEQ, ALARM3_EQTG,
			        ALARM3_FELTG, ALARM3_FALG)
		    values (Id, CliConc, PrConc, PrEtat, SiteNom, Typequ, Poseq, FEltG, FAlG);
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
		-- de voir des alarmes rester affich�es � la console.

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
			    SiteNom, Typequ, Poseq, TsPrOper, FEltG, FAlG, Sonne, Acquit, Acquittee, stBindingVarInfo);
/*
            mess_video (Mess, Id, AlarmIddeb, AlGereeId,
		       	SiteId, EquipId, LiaiId,
 			AlarmNum, AlarmCl, AlarmNumObj, AlarmType,
			AlarmDate, AlarmGrave, AlarmNseuil, AlarmVseuil,
	               	AlarmNumal, AlarmTexte, AlarmInfo, AlarmNomL,
			AlarmComment, AlarmCommut, PrConc, CliConc, to_char (ProgOper),
			SiteNom, Typequ, Poseq, TsPrOper, FEltG, FAlG);
*/
	    end if; /* l'alarme g�r�e est � afficher sur les consoles */
	end if; /* l'alarme n'est pas masqu�e par le Brigadier */
    end if;	/* l'alarme n'est pas masqu�e par l'Administrateur */

END	Start_Alrm;
/

create or replace trigger tdb_finalarm before delete on FINALARM for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);

    Erreur_Trigger   EXCEPTION;		-- interblocage entre alarmes, si plusieurs EM
    Erreur2_Trigger  EXCEPTION;
    PRAGMA EXCEPTION_INIT (Erreur_trigger,  -6512);
    PRAGMA EXCEPTION_INIT (Erreur2_trigger, -60);

    i		     integer;	  -- compteur banal

    TsPrOper VARCHAR2 (900); /* Cha�ne donnant l'�tat op�rationnel des prog. concern�s par 
				cette alarme. 70 prog. au max.
				Structure : NbProg; ProgId, OldProgOper, ProgOper, ProgMsk; 
				ProgId,  etc... */
    Debord   NUMBER;	     /* 1 si d�bordement de la cha�ne TsPrOper, 0 sinon */

    CURSOR cDeb is
	select * from ALARM
	    where ALARM_ID = :old.ALARM_ID;

    CURSOR cMasked (Iddeb NUMBER) is
	select * from ALARM_ALARMC
	    where ALARM_BINDINGID = Iddeb
	for update of ALARM_ID;

    CURSOR cAlarm (Id NUMBER) is
	select * from ALARM
	    where ALARM_ID = Id; /* Correspond � l'alarme masqu�e � tort */

begin
    /* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
    on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
		return;
	end if;

    Debord := 0;

    for cFinAl in cDeb loop
    	for cMas in cMasked (cFinAl.ALARM_IDDEB) loop /* al. masqu�e � tort par l'al m�re */
            for cAl in cAlarm (cMas.ALARM_ID) loop
		for i in 1..10 loop	-- 10 essais max
	    	    begin
			Start_Alrm (cAl.ALARM_ID, cAl.ALARMGEREE_ID, 
			   cAl.SITE_ID, cAl.EQUIP_ID, cAl.LIAI_ID,
 			   cAl.ALARM_NUM, cAl.ALARM_CL, cAl.ALARM_NUMOBJ, cAl.ALARM_TYPE, 
			   cAl.ALARM_DATE, cAl.ALARM_GRAVE, cAl.ALARM_NSEUIL, cAl.ALARM_VSEUIL, 
	               	   cAl.ALARM_NUMAL, cAl.ALARM_TEXTE, cAl.ALARM_INFO, cAl.ALARM_NOM, 
			   cAl.ALARM_COMMENT, cAl.ALARM_LOCAL, cAl.ALARM_COMMUT,
			   cAl.ALARM_IDDEB, cAl.CABLAGES_ID, cAl.CABLAGEP_ID, cAl.ALARM_AQUITTEE, cAl.ALARM_IANA, 
			   TsPrOper, Debord);

			exit;

	    	    exception
    			when Erreur_Trigger or Erreur2_Trigger then
		    	    null;
		    end;
		end loop;	/* fin des essais StartAlrm */

	    end loop;		/* fin du traitement sur l'alarme masqu�e */
	end loop;		/* fin de la boucle sur les alarmes masqu�es */

    	delete ALARM_ALARMC
	    where ALARM_BINDINGID = cFinAl.ALARM_IDDEB;
    end loop;			/* fin de la boucle sur les alarmes m�res retomb�es */
 
--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end  TDB_FINALARM;
/

--    FIN DE FINALARM   ---------------------------------------



--    CLIENT   ------------------------------------------

create OR REPLACE trigger td_client after delete on CLIENT for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    Mess     VARCHAR2 (1800);/* taille max. du message autoris� par Oracle : 1800 octets */

begin
    /* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
       on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
		return;
    end if;

    -- Contrainte int�grit� "Lien SPV" : on ne peut supprimer un client utilis� dans une fiche
    if (:old.CLIENT_NBREF > 0) then
	raise_application_error (-20000, 'On ne peut supprimer un Client utilis� dans une fiche');
    end if;

    -- Contrainte int�grit�. On ne peut supprimer ce client (n�cessaire pour les programmes
    -- rattach�s aux sites et aux liaisons : G805).
    if (:old.CLIENT_ID = 1) then
	raise_application_error (-20000, 'On ne peut supprimer ce client');
    end if;

exception
    when integrity_error then
       raise_application_error (errno, errmsg);
end td_client;
/

--    FIN DE CLIENT   ------------------------------------------



/*
-- ZN creation le 6/11/07
-- prend en compte d'inclusion des topologies

CREATE OR REPLACE PROCEDURE UpdateLiaiBP
(
  topId NUMBER,
  OldBp		PROG.PROG_BP%TYPE,
	NewBp		PROG.PROG_BP%TYPE
)
IS
  CURSOR CurLiai IS
		SELECT liai_id FROM top_liai WHERE top_id = topId;
	
  CURSOR CurTop IS
		SELECT childtop_id FROM top_top WHERE top_id = topId;
		
BEGIN
    FOR rCurLiai IN CurLiai LOOP
			UPDATE liai SET liai_debitocc = liai_debitocc - OldBp + NewBp
			WHERE liai_id = rCurLiai.liai_id;
		END LOOP;
		
		FOR rCurTop IN CurTop LOOP
		  UpdateLiaiBP( rCurTop.childtop_id, OldBp,	NewBp);
	  END LOOP;
	  
end UpdateLiaiBP;
/

--
-- X.L. cr�atioon le 06/06/04
-- Modif JPB le 06/06/04
-- PROG_BP est exprim�e en Kb/s dans PROG
-- LIAI_DEBITOCC est exprim� en Kb/s dans LIAI
--
-- X.L. modification le 17/06/04 pour mise � jour de la famille dans la table ORDRE
-- suite au changement de famille pour la prestation.
-- ZN 16/07/07 - prend en compte des topologies
-- Modif. ZN le 6/11/07 prend en compte d'inclusion des topologies

CREATE OR REPLACE TRIGGER tub_prog BEFORE UPDATE ON prog FOR EACH ROW
DECLARE
	OldBp		PROG.PROG_BP%TYPE;
	NewBp		PROG.PROG_BP%TYPE;
	FamilleNom	famille.famille_nom%TYPE;

	CURSOR CurLiai IS
		SELECT liai_id FROM prog_liai WHERE prog_id = :old.prog_id;
 
    
  CURSOR CurTop IS
  select top_id FROM prog_top WHERE prog_id = :old.prog_id; 
      
BEGIN
	
	if dbms_reputil.from_remote=TRUE then
		return;
	end if;

	-- Mise � jour de la bande passante des liaisons emprunt�es
	IF ((:old.prog_bp IS NOT NULL AND :new.prog_bp IS NULL) OR
	    (:old.prog_bp IS NULL AND :new.prog_bp IS NOT NULL) OR
     	    (:old.prog_bp != :new.prog_bp)) THEN
		OldBp := NVL (:old.prog_bp, 0);
		NewBp := NVL (:new.prog_bp, 0);

		FOR rCurLiai IN CurLiai LOOP
			UPDATE liai SET liai_debitocc = liai_debitocc - OldBp + NewBp
			WHERE liai_id = rCurLiai.liai_id;
		END LOOP;
		
		FOR rCurTop IN CurTop LOOP
		  UpdateLiaiBP( rCurTop.top_id, OldBp,	NewBp);
	  END LOOP;
	  
	END IF;
	

END tub_prog;
/


--  PROG_LIAI    -------------------------------------------------
--
-- Modif. X.L. le 05/06/04 pour mise � jour de la bande passante occup�e sur la liaison
--
create or replace trigger ti_progliai after insert on PROG_LIAI for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    Mess     VARCHAR2 (1800);-- taille max. du message autoris� par Oracle : 1800 octets 

begin
    -- Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
    --   on ne fait pas le traitement 
    if dbms_reputil.from_remote=TRUE then
		return;
    end if;

    MajDebitLiai (:new.liai_id, :new.prog_id, 1);

    --CMS_EltGere (Mess, 1, :new.LIAI_ID, :new.PROG_ID, 2);

--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end ti_progliai;
/
*/

-- X.L. cr�ation le 03/02/05
create or replace trigger tdb_param before delete on PARAM for each row
when (old.PARAM_TYPE = 3)

declare
    cursor CurAcces is
	select ACCES_ID from ACCES where ACCES_TYPE = :old.PARAM_ID;

begin
    /* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
       on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
		return;
    end if;

    for rCurAcces in CurAcces loop
	raise_application_error (-20002, 'Param�tre exploit� dans un acc�s; suppression impossible');
    end loop;
end tdb_param;
/


/*
-- X.L. cr�ation le 05/06/04
create or replace trigger tdb_progliai before delete on PROG_LIAI for each row

begin
    -- Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
     --  on ne fait pas le traitement 
    if dbms_reputil.from_remote=TRUE then
		return;
    end if;

    MajDebitLiai (:old.liai_id, :old.prog_id, -1);
end tdb_progliai;
/
*/


--    EQUIP      -------------------------------------------------
--

--==============================================================================================
-- Proc�dure v�rifiant que pour un �quipement faisant r�f�rence � une baie, il y a
-- coh�rence entre le site de la baie et le site de l'�quipement
--
-- X.L. 28/04/99
--
--==============================================================================================
CREATE OR REPLACE PROCEDURE VerfSiteBaieEquip
(
 lBaieId NUMBER, 	-- ID de la baie
 lSiteId NUMBER		-- ID du site auquel l'�quipement fait r�f�rence
)

IS
	lBaieSiteId	NUMBER;		-- ID du site de la baie

BEGIN
	IF lBaieId IS NULL THEN
		RETURN;
	END IF;

	SELECT site_id INTO lBaieSiteId
	FROM baie, salle
	WHERE baie_id = lBaieId AND salle.salle_id = baie.salle_id;

	IF (lSiteId = lBaieSiteId) THEN
	    RETURN;
	ELSE
	    raise_application_error (-20000, 'Cette baie n''appartient pas � ce site');
	END IF;
END VerfSiteBaieEquip;
/


--==============================================================================================
-- Proc�dure v�rifiant la coh�rence sur la saisie du num�ro de slot
--
-- X.L. 24/04/01
--
-- Modif. X.L. le 06/04/05 : le num�ro de slot peut maintenant �tre compos�, chaque
-- �l�ment de cette composition correspondant � un niveau d'inclusion.
-- premier niveau	 	: xx
-- niveau inclus suivant	: xx-yy
-- niveau inclus suivant	: xx-yy-zz
-- etc.
--==============================================================================================
CREATE OR REPLACE PROCEDURE VerfSlotEquip
(
 TypeqBindingId	NUMBER, -- ID du type de l'�quipement p�re
 TypeqId	NUMBER, -- ID du type d'�quipement de l'�quipement en cours
 BaieEquipCarte EQUIP.BAIE_EQUIP_CARTE%TYPE
) IS

    nNbSlot          integer;  -- Nb de slot sur l'�quipement p�re (ch�ssis)
    nPremSlot        integer;  -- N� du premier slot sur l'�quipement p�re
    nNbSlotOcc       integer;  -- Nb de slot qu'occupe le module
    nNumSlot         integer;  -- N� du slot choisi sur l'�quipement courant
    nNbOcc           integer;  -- Nb de slots d�j� occup�s par d'autre modules
    bVerfSlot	     typeq.typeq_verfslot%TYPE;  -- indicateur v�rif. slot active sur typeq p�re
    strNumSlot       equip.baie_equip_carte%TYPE;
    pos              integer;  -- Position du caract�re '-' dans le slot

BEGIN

    -- Si un nombre de slots (>= 1) occup�s par l'�quipement est pr�cis� au niveau du type
    -- d'�quipement, la saisie de la carte (ou slot) est obligatoire.

    nNbSlot := 0;
    nPremSlot := 0;
    bVerfSlot := 0;

    if (TypeqBindingId is not null) then
	select TYPEQ_PREMSLOT, TYPEQ_NBCXION, TYPEQ_VERFSLOT
	into nPremSlot, nNbSlot, bVerfSlot
	from TYPEQ
	where TYPEQ_ID = TypeqBindingId;
    end if;

    select TYPEQ_NBSLOTOCC
    into nNbSlotOcc
    from TYPEQ
    where  TYPEQ_ID = TypeqId;

    SELECT decode (rtrim (translate (BaieEquipCarte, '1234567890-', ' ')),
	      		NULL, BaieEquipCarte) into strNumSlot from dual;

    if (nNbSlotOcc > 0 and BaieEquipCarte is null) then
	raise_application_error (-20000,
		'Nombre de slots > 0 sur le type d''�quipement, vous devez donc saisir le num�ro de carte (ou slot) sur l''�quipement');
		-- Ne pas mettre la ligne ci-dessus sur 2 lignes, sinon on ne pourra pas l'extraire.
    end if;

    if (strNumSlot is null and bVerfSlot > 0) then
	raise_application_error (-20000,
		'V�rification de slot demand�e sur le type d''�quipement p�re;
		 saisissez un num�ro de carte (ou slot) purement num�rique');
    end if;

    if (bVerfSlot > 0 and strNumSlot is not null) then
	pos := INSTR (BaieEquipCarte, '-', -1);
	if (pos > 0) then
	   nNumSlot := to_number (substr (BaieEquipCarte, pos + 1));
	else
	   nNumSlot := to_number (BaieEquipCarte);
	end if;

	if (nNumSlot < nPremSlot or nNumSlot + nNbSlotOcc > nNbSlot + nPremSlot) then
	    raise_application_error (-20000,
	    	'N� de slot incompatible avec �quipement p�re');
	end if;
    end if;

EXCEPTION
    WHEN OTHERS THEN
	insert into ERROR (ERROR_ID, ERROR_TYP, ERROR_LIBELLE)
		values (SEQ_ERROR.NEXTVAL, 0, 'Erreur dans VerfSlotEquip');
END VerfSlotEquip;
/


--========================================================================================
-- Calcul de la valeur du champ unicit� pour l'�quipement
--
-- X.L. le 10/11/03 : cr�ation
--
-- X.L. Modif. le 05/01/04 pour un �quipement d�sign� par le commentaire et qui n'est pas
-- de type SATURNE IS ou CARTE GTR ou CARTE SEM, on ajoute le site_id dans le champs
-- unicit�; on peut ainsi avoir un m�me nom d'�quipement sur deux sites diff�rents, sauf
-- pour les IS.
--
-- X.L. Modif. le 24/05/04 pour tenir compte des slots virtuels dans le calcul
-- du champ unicit�.
--
-- Modif. X.L. le 09/09/04 car les select sur typeq pour chercher les ID de CARTE GTR,
-- CARTE SEM, SATURN IS provoquent des probl�mes de mutating lorsqu'on modifie le nom
-- d'un type d'�quipement; on enl�ve donc les curseurs de recherche correspondants.
--
-- Modif. X.L. le 02/02/05 : le contr�le de saisie obligatoire sur au moins BAIE_ID
-- ou SITE_EQUIP_COMMENT n'est valable que pour un �quipement (pas une antenne),
-- on ajoute donc le CLASSID = 1018 comme crit�re suppl�mentaire.
-- 
-- Modif Y.C. le 23/07/2007 : on utilise maintenant 4 champs diff�rents pour contr�ler l'unicit� : 
-- l'unicit� peut �tre d�finie s�par�ment sur le commentaire, la r�f�rence, la position ou l'adresse SNMP de l'�quipement
--
--
-- Modif Y.C. le 23/07/07 : v�rification que la r�f�rence, le commentaire , l'adresse IP et la 
-- position de la baie ne sont pas nuls (et non pas seulement le commentaire et la baie)
--
-- Modif. X.L. le 08/08/07 pour revoir la construction des champs d'unicit�.
-- Modif. X.L. le 27/10/09 suppression du trigger tiub_equip pour mettre les traitements correspondants
-- dans l'application cliente
--========================================================================================
		

--========================================================================================
--
-- Modifi� X.L. 14/04/99 envoi d'alerte � l'�quipement de m�diation pour prise en compte
-- du param�tre alarme fr�quente lorsque l'�quipement est une IS
--
-- Modifi� X.L. 28/04/99 afin d'ajouter le contr�le de coh�rence entre le site de l'�quipement
-- et le site de la baie.
--
-- Modifi� X.L. 19/07/99 pour transformer l'envoi d'alerte ORACLE qui fonctionne mal,
-- en insertion dans la table MESSALRM; A charge ensuite au process serveur EmessAlrm2 
-- d'envoyer un message correspondant � l'�quipement de m�diation par socket TCP/IP.
--
-- Modifi� X.L. 05/01/00 remplac� le libell� 'IS' par 'SATURNE IS' et dans le IF correspondant
-- equip_ref par un extrait de site_equip_comment
--
-- Modifi� X.L. 20/04/01 : introduction des modules (ou cartes) occupant un ou plusieurs slots.
-- On v�rifie que le num�ro de slot est saisi.
-- On v�rifie que le slot choisi est compatible avec l'�quipement p�re.
-- Rappel : un �quipement qui occupe plusieurs slots est ins�r� dans la table EQUIP autant de 
-- fois que le nombre de slots le n�cessite.
--
-- Modifi� JPB le 02/09/02 : s�paration alarmes / structure
-- 18/09/03 : JPB : Modification du message MESSALRM, pour introduire le nb. de # envoy�s
--
-- X.L. Modif. le 12/02/04 : lorsqu'un �quipement voit sa case "� surveiller" passer de
-- d�coch�e � coch�e ou l'inverse, on g�n�re un message dans la table EmessEM.
--
-- JPB  Modif le 26/01/05  : v�rification que les champs SITE_EQUIP_COMMENT et BAIE_ID
-- ne sont pas nuls simultan�ment
--
-- Modif. X.L. le 02/02/05 : le contr�le de saisie obligatoire sur au moins BAIE_ID
-- ou SITE_EQUIP_COMMENT n'est valable que pour un �quipement (pas une antenne),
-- on ajoute donc le CLASSID = 1018 comme crit�re suppl�mentaire.
--
--
-- Modif Y.C. le 23/07/07 : v�rification que la r�f�rence, le commentaire , l'adresse IP et la 
-- position de la baie ne sont pas nuls (et non pas seulement le commentaire et la baie)
--
-- Modif X.L. le 12/08/09 pour int�gration de la cr�ation dans TESTEM dans le cas
-- o� le type d'�quipement est EQUIP MEDIATION (typeq_id = 3)
--
--========================================================================================
create or replace trigger ti_equip after insert on EQUIP for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    Mess     VARCHAR2 (1800);/* taille max. du message autoris� par Oracle : 1800 octets */
    MessId           integer;

    strTypeqNom	     typeq.typeq_nom%TYPE;
    
    strNomEM         testem.TESTEM_EMNOM%TYPE;
    strNomService    testem.TESTEM_NOM%TYPE;
    nPos             number;
    nId              number;

begin

    /* traitement � effectuer sur les DEUX serveurs (s�paration alarme/structure) */
    if (:new.equip_commut = 0) then
    insert into EQUIP_REP (equip_id, equip_oper)
	values (:new.equip_id, 0);
    else
	insert into EQUIP_REP (equip_id, equip_oper, equip_commut)
		values (:new.equip_id, 0, :new.equip_commut);
    end if;

    /* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
       on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
		return;
    end if;

   if (:new.SITE_EQUIP_COMMENT is NULL and :new.BAIE_ID is NULL  and :new.EQUIP_REF is null and :new.EQUIP_ADDRIP is null and :new.EQUIP_CLASSID = 1018) then
	raise_application_error (-20000, 'Cet �quipement n''a pas de position g�ographique !');
    end if;

    if (:new.EQUIP_EQUIPID is not null) then
	-- Enregistrements pour occuper les diff�rents slots, lorsque plusieurs slots
	-- sont d�finis dans le type d'�quipement. On ne fait pas les contr�les, car les
	-- messages d'erreurs �ventuels seraient donn�s autant de fois que de slots d�finis.
	return;
    end if;

--    CMS_EltGere (Mess, 1, :new.EQUIP_ID, :new.SITE_ID, 1);

    -- Envoi � l'�quipement de m�diation du param�tre alarme fr�quente lorsque l'�quipement
    -- est une IS
    SELECT typeq_nom INTO strTypeqNom FROM typeq WHERE typeq_id = :new.typeq_id;

    IF strTypeqNom = 'SATURNE IS' THEN
	select SEQ_MESSALRM.NEXTVAL into MessId from dual;
	Mess := '6#';				-- Code du message
	Mess := CONCAT (Mess, '8#');		-- Nb. de #
	Mess := CONCAT (Mess, '0#');		/* Alarm_Id */
    	Mess := CONCAT (Mess, MessId);
	Mess := CONCAT (Mess, '#'); 		/* stockage dans MESSALRM */
    	Mess := CONCAT (Mess, '0#');		/* Alarmgeree_Id */
    	Mess := CONCAT (Mess, '0#');		/* BindingId */
   	Mess := CONCAT (Mess, '0#');		/* BindingTyp */
	Mess := Mess || 'D' || LTRIM (SUBSTR (:new.site_equip_comment, 3)) || '/'
		|| TO_CHAR (:new.equip_freqe) || '/#';

--insert into test values (seq_test.nextval, 'ti_equip' || Mess);

	insert into MESSALRM (MESSALRM_ID, MESSALRM_MESS, MESSALRM_SENT, MESSALRM_NATURE)
	    values (MessId, Mess, 0, 0);

	/*
	dbms_alert.signal ('Mediation',
		'D' || :new.equip_ref || '/' || TO_CHAR (:new.equip_freqe) || '/');
	*/
    END IF;

    -- V�rification que la baie appartient bien au site
    VerfSiteBaieEquip (:new.baie_id, :new.site_id);

    -- V�rification de la saisie des slots
    VerfSlotEquip (:new.TYPEQ_BINDINGID, :new.TYPEQ_ID, :new.BAIE_EQUIP_CARTE);

    -- On cr�e le message demandant la surveillance de l'�quipement dans la table MESSEM
    if (:new.EQUIP_TOSURV > 0) THEN
	insert into MESSEM (MESSEM_ID, MESSEM_MESS)
	values (SEQ_MESSEM.nextval, '#9#6#1#C#' || to_char (:new.equip_id) || '#');
    end if;

    -- Si l'�quipement est de type EQUIP MEDIATION (typeq_id = 3)
    if (:new.TYPEQ_ID = 3) THEN
        insert into ACCES_ACCESC 
            (ACCES_ACCESC_ID, ACCES1_ID, ACCES2_ID, ACCES_BINDINGID, ACCES_BINDINGCLASSID,
             COMMUT, ALARMGEREE_ID, ALARMGEREE_GRAVE, MSKADM_HOW)
        values
            (SEQ_ACCES_ACCESC.NEXTVAL, 0, 0, :new.EQUIP_ID, 8,
             0, 1, 7, 0);
             
        select SEQ_ACCES_ACCESC.CURRVAL into nId from dual;

        if (:new.EQUIP_INDEXSNMP is null or ValidNbr (:new.EQUIP_INDEXSNMP, 1, 20) < 0) THEN
            raise_application_error (-20000, 'For equipment type EQUIP MEDIATION, snmp index should be a number between 1 and 20');
        end if;
        
        update ACCES_ACCESC_REP set
            ALARM_CL = 'SYST',
            ALARM_NUMOBJ = TO_NUMBER (:new.EQUIP_INDEXSNMP),
            ALARM_NUMAL = :new.SITE_EQUIP_COMMENT,
            EQUIP_ID = :new.EQUIP_ID
            where ACCES_ACCESC_ID = nId;
            
        nPos := INSTR (:new.SITE_EQUIP_COMMENT, '/');
        strNomEM := SUBSTR (:new.SITE_EQUIP_COMMENT, 1, nPos - 1);
        strNomService := SUBSTR (:new.SITE_EQUIP_COMMENT, nPos + 1);
        
        if (nPos = 0 or strNomEM is null or strNomService is null) THEN
            raise_application_error (-20000, 'For equipment type EQUIP MEDIATION, equipement label should be like ''mediation_name/service_name''');
        end if;
        
        insert into TESTEM 
            (TESTEM_ID, TESTEM_CLASSID, TESTEM_NOM, TESTEM_DATE, TESTEM_NSEC,
             TESTEM_ETAT, TESTEM_EMNOM)
        values (TO_NUMBER(:new.EQUIP_INDEXSNMP), 2038, strNomService, sysdate, 0, 0, strNomEM);
    end if;
                            
--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error (errno, errmsg);
end ti_equip;
/



--==============================================================================================
-- Modifi� X.L. 25/03/99 introduction des SEM.
-- Remis dans son �tat ant�rieur le 28/03/99 par JPB
-- Le traitement des SEM est � faire dans l'applicatif.

-- Modifi� X.L. 14/04/99 envoi d'alerte � l'�quipement de m�diation pour prise en compte
-- du param�tre alarme fr�quente lorsque l'�quipement est une IS
--
-- Modifi� X.L. 28/04/99 afin d'ajouter le contr�le de coh�rence entre le site de l'�quipement
-- et le site de la baie.
--
-- Modifi� X.L. 19/07/99 pour remplacer les alertes ORACLE qui fonctionnent mal, par une
-- insertion dans la table MESSALRM; � charge ensuite au process serveur EmessAlrm2 d'exp�dier
-- le message correspondant vers l'�quipement de m�diation par socket TCP/IP.
--
-- Modifi� X.L. 05/01/00 remplac� le libell� 'IS' par 'SATURNE IS' et dans le IF correspondant
-- equip_ref par un extrait de site_equip_comment
--
-- Modifi� X.L. 01/08/00 : enl�vement du code en commentaire qui faisait appel � CreMessIs
--
-- Modifi� X.L. 12/10/00 : lorsqu'on modifie la colonne SITE_EQUIP_COMMENT ou la colonne
-- EQUIP_ADDRIP, il faut mettre � jour les champs correspondants dans ACCES_ACCESC (cas des
-- �quipements avec alarme de type TRAP SNMP).

-- Modifi� JPB  30/01/01 : TYPEQ_NOM est obtenu de EQUIP, sinon, une modification
-- de TYPEQ.TYPEQ_NOM provoque une mutating.
--
-- Modifi� X.L. 24/04/01 : appel � la fonction de contr�le des num�ros de slot
--
-- Modifi� JPB le 04/10/02 : ajout de EQUIP_INDEXSNMP
--
-- 18/09/03 : JPB : Modification du message MESSALRM, pour introduire le nb. de # envoy�s
--
-- X.L. Modif. le 12/02/04 : lorsqu'un �quipement voit sa case "� surveiller" passer de
-- d�coch�e � coch�e ou l'inverse, on g�n�re un message dans la table EmessEM.
--
-- JPB  Modif le 26/01/05  : v�rification que les champs SITE_EQUIP_COMMENT et BAIE_ID
-- ne sont pas nuls simultan�ment
--
-- Modif. X.L. le 02/02/05 : le contr�le de saisie obligatoire sur au moins BAIE_ID
-- ou SITE_EQUIP_COMMENT n'est valable que pour un �quipement (pas une antenne),
-- on ajoute donc le CLASSID = 1018 comme crit�re suppl�mentaire.
--
-- Modif Y.C. le 23/07/07 : v�rification que la r�f�rence, le commentaire , l'adresse IP et la 
-- position de la baie ne sont pas nuls (et non pas seulement le commentaire et la baie)

--ajout le MAJ de acces_accesc.COMMUT
--==============================================================================================

create or replace trigger tu_equip after update on EQUIP for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);

    Mess     	  VARCHAR2 (1800);/* taille max. du message autoris� par Oracle : 1800 octets */
    MessId	  integer;

    nIndex	  NUMBER;
    lEquipTrapNom equip.site_equip_comment%type;

    cursor cAccTrap is
	select ACCES_ACCESC_ID from ACCES_ACCESC, ACCES
	where  ACCES.EQUIP_ID = :old.EQUIP_ID
	and ACCES.ACCES_TYPE = 9
	and ACCES_ACCESC.ACCES1_ID = ACCES.ACCES_ID;

begin
    /* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
       on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
		return;
    end if;


 if (:new.SITE_EQUIP_COMMENT is NULL and :new.BAIE_ID is NULL and :new.EQUIP_REF is NULL and :new.EQUIP_ADDRIP is null and :new.EQUIP_CLASSID = 1018) then
	raise_application_error (-20000, 'Cet �quipement n''a pas de position g�ographique !');
    end if;

    -- Envoi � l'�quipement de m�diation du param�tre alarme fr�quente lorsque l'�quipement
    -- est une IS et que ce param�tre a �t� chang�
--    SELECT typeq_nom INTO strTypeqNom FROM typeq WHERE typeq_id = :new.typeq_id;

--     IF strTypeqNom = 'SATURNE IS'
     IF :new.TYPEQ_NOM = 'SATURNE IS'
	AND ((:new.equip_freqe IS NOT NULL AND :old.equip_freqe IS NULL) OR
	    (:new.equip_freqe IS NULL AND :old.equip_freqe IS NOT NULL) OR
	    (:new.equip_freqe != :old.equip_freqe)) THEN

	select SEQ_MESSALRM.NEXTVAL into MessId from dual;
	Mess := '6#';				-- Code du message
	Mess := CONCAT (Mess, '8#');		-- Nb. de #
	Mess := CONCAT (Mess, '0#');		/* Alarm_Id */
    	Mess := CONCAT (Mess, MessId);
	Mess := CONCAT (Mess, '#'); 		/* stockage dans MESSALRM */
    	Mess := CONCAT (Mess, '0#');		/* Alarmgeree_Id */
    	Mess := CONCAT (Mess, '0#');		/* BindingId */
   	Mess := CONCAT (Mess, '0#');		/* BindingTyp */
	Mess := Mess || 'D' || LTRIM (SUBSTR (:new.site_equip_comment, 3)) || '/'
		|| TO_CHAR (:new.equip_freqe) || '/#';

--insert into test values (seq_test.nextval, 'tu_equip' || Mess);

	insert into MESSALRM (MESSALRM_ID, MESSALRM_MESS, MESSALRM_SENT, MESSALRM_NATURE)
	    values (MessId, Mess, 0, 0);
	/*
	dbms_alert.signal ('Mediation',
		'D' || :new.equip_ref || '/' || TO_CHAR (:new.equip_freqe) || '/');
	*/
    END IF;

    -- V�rification que la baie appartient bien au site
    VerfSiteBaieEquip (:new.baie_id, :new.site_id);

    -- V�rification de la saisie des slots, dans le cas o� le slot est modifi�. On fait ce
    -- test pr�alable afin de n'avoir pas de probl�me de mutating suite � une modification
    -- sur le type d'�quipement (modif. du nom du type), entra�nant une mise � jour des
    -- �quipements
    if (:new.BAIE_EQUIP_CARTE != :old.BAIE_EQUIP_CARTE) then
	VerfSlotEquip (:new.TYPEQ_BINDINGID, :new.TYPEQ_ID, :new.BAIE_EQUIP_CARTE);
    end if;

    -- Mise � jour �ventuelle de ACCES_ACCESC pour les �quipements qui d�livrent des alarmes
    -- de type TRAP SNMP

    /* Dans le contexte SMT, ceci est fait dans le client
    if (:new.EQUIP_ADDRIP != :old.EQUIP_ADDRIP
        or (:new.EQUIP_ADDRIP is null and :old.EQUIP_ADDRIP is not null)
        or (:new.EQUIP_ADDRIP is not null and :old.EQUIP_ADDRIP is null)
        or (:new.EQUIP_INDEXSNMP != :old.EQUIP_INDEXSNMP)
        or (:new.EQUIP_INDEXSNMP is null and :old.EQUIP_INDEXSNMP is not null)
        or (:new.EQUIP_INDEXSNMP is not null and :old.EQUIP_INDEXSNMP is null)
        or :new.SITE_EQUIP_COMMENT != :old.SITE_EQUIP_COMMENT
        or :new.EQUIP_REF != :old.EQUIP_REF
        or (:new.EQUIP_COMMUT != :old.EQUIP_COMMUT)
        or (:new.EQUIP_COMMUT is null and :old.EQUIP_COMMUT is not null)
        or (:new.EQUIP_COMMUT is not null and :old.EQUIP_COMMUT is null)
        ) then

      	nIndex := instr (:new.SITE_EQUIP_COMMENT, ':');
      	if (nIndex > 0) then
      		lEquipTrapNom := rtrim (substr (:new.SITE_EQUIP_COMMENT, 1, nIndex - 1));
      	else
      		lEquipTrapNom := :new.SITE_EQUIP_COMMENT;
      	end if;

      	for rCTrap in cAccTrap loop
      	    update ACCES_ACCESC
      		set EQUIP_ADDRIP = :new.EQUIP_ADDRIP, EQUIP_TRAPNOM = lEquipTrapNom,
      		    EQUIP_INDEXSNMP = :new.EQUIP_INDEXSNMP, COMMUT = :new.EQUIP_COMMUT
      		where ACCES_ACCESC_ID = rCTrap.ACCES_ACCESC_ID;
      	end loop;
    
    end if;
    */

    -- On cr�e le message demandant la surveillance ou la non surveillance de l'�quipement
    -- dans la table MESSEM
    if (:old.equip_tosurv > 0 and :new.equip_tosurv = 0) or
       (:old.equip_tosurv > 0 and :new.equip_tosurv > 0 and (
	(:old.equip_addrip is null and :new.equip_addrip is not null) or
	(:old.equip_addrip is not null and :new.equip_addrip is null) or
	(:old.equip_addrip != :new.equip_addrip) or
	(:old.equip_emname is not null and :new.equip_emname is null) or
	(:old.equip_emname != :new.equip_emname))) then

	insert into MESSEM (MESSEM_ID, MESSEM_MESS)
	values (SEQ_MESSEM.nextval, '#9#9#1#S#' || to_char (:new.equip_id) || '#1#' ||
		:old.equip_addrip || '#' || :old.equip_emname || '#');
    end if;

    if (:old.equip_tosurv = 0 and :new.equip_tosurv > 0) or
       (:old.equip_tosurv > 0 and :new.equip_tosurv > 0 and (
	(:old.equip_addrip is null and :new.equip_addrip is not null) or
	(:old.equip_addrip is not null and :new.equip_addrip is null) or
	(:old.equip_addrip != :new.equip_addrip) or
	(:old.equip_emname is null and :new.equip_emname is not null) or
	(:old.equip_emname != :new.equip_emname))) then

	insert into MESSEM (MESSEM_ID, MESSEM_MESS)
	values (SEQ_MESSEM.nextval, '#9#6#1#C#' || to_char (:new.equip_id) || '#');
    end if;

--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error (errno, errmsg);
end 	tu_equip;
/



--==============================================================================================
-- X.L. Modif. le 12/02/04 : lorsqu'un �quipement voit sa case "� surveiller" passer de
-- d�coch�e � coch�e ou l'inverse, on g�n�re un message dans la table EmessEM.
--==============================================================================================
create or replace trigger td_equip after delete on EQUIP for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    Mess     VARCHAR2 (1800);/* taille max. du message autoris� par Oracle : 1800 octets */

begin

    /* traitement � effectuer sur les DEUX serveurs (s�paration alarme/structure) */
    delete EQUIP_REP 
	where EQUIP_ID = :old.EQUIP_ID;
	
	DELETE MANAGER_OBJ WHERE EQUIP_ID = :old.EQUIP_ID;
    DELETE TRAPALARM WHERE EQUIP_ID = :old.EQUIP_ID;

    /* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
       on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
		return;
    end if;

--    CMS_EltGere (Mess, 3, :new.EQUIP_ID, :new.SITE_ID, 1);

    -- On cr�e le message demandant la surveillance ou la non surveillance de l'�quipement
    -- dans la table MESSEM
    if (:old.equip_tosurv > 0) then
	insert into MESSEM (MESSEM_ID, MESSEM_MESS)
	values (SEQ_MESSEM.nextval, '#9#9#1#S#' || to_char (:old.equip_id) || '#0#' ||
		:old.equip_addrip || '#' || :old.equip_emname || '#');
    end if;

--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end td_equip;
/

--     FIN DE EQUIP     ------------------------------------------


--     EQUIP_MSK        ------------------------------------------

create or replace trigger tib_equip_msk before insert on EQUIP_MSK for each row

begin
	/* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
	   on ne fait pas le traitement */
	if dbms_reputil.from_remote=TRUE then
		return;
	end if;

	select SEQ_EQUIP_MSK.nextval into :new.EQUIP_MSK_ID from DUAL;
end tib_equip_msk;
/

--     FIN DE EQUIP_MSK  ------------------------------------------


create or replace trigger tdb_alarmgeree before delete on ALARMGEREE for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    Mess     VARCHAR2 (1800);/* taille max. du message autoris� par Oracle : 1800 octets */

begin

    /* traitement � effectuer sur les DEUX serveurs (s�paration alarme/structure)
       NE PAS METTRE :
	if dbms_reputil.from_remote=TRUE then
		return;
	end if;

    */

    -- Effacement des alarmes correspondant � cette alarme g�r�e
    DELETE alarm WHERE alarmgeree_id = :old.ALARMGEREE_ID;

    DELETE TRAPALARM WHERE alarmgeree_id = :old.ALARMGEREE_ID;

--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end tdb_alarmgeree;
/


--    LIAI       -------------------------------------------------

-- Cr�� par JPB le 02/09/02 : s�paration alarmes / structure

create or replace trigger ti_liai after insert on LIAI for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);

begin

    /* traitement � effectuer sur les DEUX serveurs (s�paration alarme/structure) */
    insert into LIAI_REP (liai_id, liai_oper)
	values (:new.liai_id, 0);

    /* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
    on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
	return;
    end if;

--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end ti_liai;
/


create or replace trigger td_liai after delete on LIAI for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);

begin

    /* traitement � effectuer sur les DEUX serveurs (s�paration alarme/structure) */
    delete LIAI_REP 
	where LIAI_ID = :old.liai_id;

    /* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
    on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
	return;
    end if;

--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end td_liai;
/


--
-- X.L. Cr�ation le 26/10/04
-- Mise � jour de l'�quipement liaison si on change
-- le nom de la liaison
-- JPB  Modif le 28/11/04 Pour tenir compte des liaisons de diffusion
-- Modif. JPB  le 26/12/04 pour supprimer GROUPSITE
--
/*
CREATE OR REPLACE TRIGGER tu_liai AFTER UPDATE ON liai FOR EACH ROW
DECLARE
	LiaiNom		VARCHAR2 (80);
	CURSOR CurEquip IS
		SELECT equip.equip_id FROM equip, equip_liai
		WHERE liai_id = :new.liai_id
		AND equip.equip_id = equip_liai.equip_id
		FOR UPDATE OF site_equip_comment NOWAIT;
BEGIN

	
	if dbms_reputil.from_remote=TRUE then
		return;
	end if;

	IF (:new.liai_extaid != :old.liai_extaid OR :new.liai_extbid != :old.liai_extbid OR
	    :new.liai_num != :old.liai_num OR :new.liai_dir != :old.liai_dir) THEN

		SELECT  A.ext_ville || '/' || A.ext_point ||
			decode (:new.liai_dir, 0, ' -> ', 1, ' <- ', ' <-> ') ||
		        B.ext_ville || '/' || B.ext_point || ' ' || :new.liai_num
		    INTO LiaiNom
		    FROM ext A, ext B
		    WHERE A.ext_id = :new.liai_extaid AND
		          B.ext_id = :new.liai_extbid;

		FOR rCurEquip IN CurEquip LOOP
			UPDATE equip SET site_equip_comment = LiaiNom
			WHERE CURRENT OF CurEquip;
		END LOOP;
	END IF;
END tu_liai;
/

--
-- X.L. Cr�ation le 26/10/04
-- Mise � jour des �quipements liaison si on change
-- le nom d'une extr�mit� (�quipements de type LINK_IN ou
-- LINK_OUT coupl�s � une liaison par EQUIP_LIAI).
-- Ces �quipements repr�sentent une liaison dans les c�blages
-- inter-�quipements lorsque cela est n�cessaire (remplacent
-- les ex NULL E et NULL S)
--
CREATE OR REPLACE TRIGGER tu_ext AFTER UPDATE ON ext FOR EACH ROW
DECLARE
	LiaiNom		VARCHAR2 (80);
	OldExtNom	EXT.EXT_NOM%TYPE;
	NewExtNom	EXT.EXT_NOM%TYPE;
	pos		NUMBER;

	CURSOR CurEquip IS
		SELECT equip.equip_id, equip.site_equip_comment, 
			liai.liai_id, liai_extaid, liai_extbid
		FROM equip, equip_liai, liai
		WHERE (liai_extaid = :new.ext_id OR liai_extbid = :new.ext_id)
		AND equip_liai.liai_id = liai.liai_id
		AND equip.equip_id = equip_liai.equip_id
		FOR UPDATE OF site_equip_comment NOWAIT;
BEGIN
	
	if dbms_reputil.from_remote=TRUE then
		return;
	end if;

	IF (:new.ext_ville != :old.ext_ville OR :new.ext_point != :old.ext_point) THEN
		FOR rCurEquip IN CurEquip LOOP
			LiaiNom := GetNewLiaiNom (rCurEquip.site_equip_comment, 
						:old.ext_ville, :old.ext_point,
						:new.ext_ville, :new.ext_point);
			IF LiaiNom != 'ERROR' THEN
				UPDATE equip SET site_equip_comment = LiaiNom
				WHERE CURRENT OF CurEquip;
			ELSE
				raise_application_error (-20000, 'tu_ext: erreur inconnue');
			END IF;
		END LOOP;
	END IF;	
END tu_ext;
/

--
-- X.L. cr�ation le 05/06/04
-- Mise � jour des r�servations pour les d�bits de liaison
--
CREATE OR REPLACE TRIGGER ti_liaireser AFTER INSERT ON liaireser FOR EACH ROW
BEGIN
    	-- Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
    	--on ne fait pas le traitement 
    	if dbms_reputil.from_remote=TRUE then
		return;
    	end if;

	UPDATE liai SET liai_debitreser = liai_debitreser + :new.liaireser_debit WHERE liai_id = :new.liai_id;
END;
/


--
-- X.L. cr�ation le 05/06/04
-- Mise � jour des r�servations pour les d�bits de liaison
--
CREATE OR REPLACE TRIGGER tdb_liaireser BEFORE DELETE ON liaireser FOR EACH ROW
BEGIN
    	-- Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
    	--on ne fait pas le traitement 
    	if dbms_reputil.from_remote=TRUE then
		return;
    	end if;

	UPDATE liai SET liai_debitreser = liai_debitreser - :old.liaireser_debit WHERE liai_id = :old.liai_id;
END;
/
*/
 
--    SITE       -------------------------------------------------

-- Cr�� par JPB le 02/09/02 : s�paration alarmes / structure

create or replace trigger ti_site after insert on SITE for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);

begin

    /* traitement � effectuer sur les DEUX serveurs (s�paration alarme/structure) */
    insert into SITE_REP (site_id, site_oper)
	values (:new.site_id, 0);

    /* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
    on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
	return;
    end if;

--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end ti_site;
/


create or replace trigger td_site after delete on SITE for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);

begin

    /* traitement � effectuer sur les DEUX serveurs (s�paration alarme/structure) */
    delete SITE_REP 
	where SITE_ID = :old.SITE_id;

    /* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
    on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
	return;
    end if;

    -- Contrainte int�grit�. On ne peut supprimer le site "FUTUROCOM"
    if (:old.SITE_ID = 1) then
	raise_application_error (-20000, 'On ne peut supprimer ce site');
    end if;

exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end td_site;
/


--    PROG       -------------------------------------------------

-- Cr�� par JPB le 02/09/02 : s�paration alarmes / structure

create or replace trigger ti_prog after insert on PROG for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);

begin

    /* traitement � effectuer sur les DEUX serveurs (s�paration alarme/structure) */
    insert into PROG_REP (prog_id, prog_oper)
	values (:new.prog_id, 0);

    /* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
    on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
	return;
    end if;

--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end ti_prog;
/


create or replace trigger td_prog after delete on PROG for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);

begin

    /* traitement � effectuer sur les DEUX serveurs (s�paration alarme/structure) */
    delete PROG_REP 
	where PROG_ID = :old.prog_id;

    /* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
    on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
	return;
    end if;

    -- Contrainte int�grit� "Lien SPV" : on ne peut supprimer un programme utilis� dans une fiche
    if (:old.PROG_NBREF > 0) then
	raise_application_error (-20000,
		'On ne peut supprimer un Programme utilis� dans une fiche');
    end if;

--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end td_prog;
/


--    PROG_OPER       -------------------------------------------------

-- Cr�� par JPB le 02/09/02 : s�paration alarmes / structure

create or replace trigger ti_progoper after insert on PROG_OPER for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);

begin

    /* traitement � effectuer sur les DEUX serveurs (s�paration alarme/structure) */
    insert into PROG_OPER_REP (node_id, prog_id, site_id, prog_oper_grave)
	values (:new.node_id, :new.prog_id, :new.site_id, 0);

    /* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
    on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
	return;
    end if;

--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end ti_progoper;
/


create or replace trigger td_progoper after delete on PROG_OPER for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);

begin

    /* traitement � effectuer sur les DEUX serveurs (s�paration alarme/structure) */
    delete PROG_OPER_REP 
	where NODE_ID = :old.node_ID;

    /* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
    on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
	return;
    end if;

--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end td_progoper;
/


--    PROG_CABL       -------------------------------------------------

-- Cr�� par JPB le 02/09/02 : s�paration alarmes / structure

create or replace trigger ti_progcabl after insert on PROG_CABL for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);

begin

    /* traitement � effectuer sur les DEUX serveurs (s�paration alarme/structure) */
    insert into PROG_CABL_REP (prog_id, cablequ_id, site_id, prog_cabl_grave)
	     values (:new.prog_id, :new.cablequ_id, :new.site_id, 0);

    /* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
    on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
	return;
    end if;

--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end ti_progcabl;
/


--    PROG_SERVICE       -------------------------------------------------

-- Cr�� par XL le 06/07/05
/*
create or replace trigger ti_prog_service after insert on PROG_SERVICE for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);

begin

    -- Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
    -- on ne fait pas le traitement 
    if dbms_reputil.from_remote=TRUE then
	return;
    end if;

    SpecTiProgService (:new.prog_id, :new.prog_fluxid);

--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end ti_prog_service;
/


-- Cr�� par XL le 06/07/05

create or replace trigger td_prog_service after delete on PROG_SERVICE for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);

begin

    -- Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
    --on ne fait pas le traitement 
    if dbms_reputil.from_remote=TRUE then
	return;
    end if;

    SpecTdProgService (:old.prog_id, :old.prog_fluxid);

--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end td_prog_service;
/
*/

create or replace trigger td_progcabl after delete on PROG_CABL for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);

begin

    /* traitement � effectuer sur les DEUX serveurs (s�paration alarme/structure) */
    delete PROG_CABL_REP where PROG_ID = :old.prog_id and CABLEQU_ID = :old.cablequ_id;
 
    /* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
    on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
	return;
    end if;

--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end td_progcabl;
/




--    CABLEQU    -------------------------------------------------
--

create or replace trigger ti_cablequ after insert on CABLEQU for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    Mess     VARCHAR2 (1800);/* taille max. du message autoris� par Oracle : 1800 octets */

begin
    /* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
       on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
		return;
    end if;

/*
    CMS_EltGere (Mess, 1, :new.CABLEQU_ID, :new.SITE_ID, 1);
*/

    null;
--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end ti_cablequ;
/

/*
create or replace trigger tub_cablequ before update on CABLEQU for each row
declare
    cursor CEquip is
	select CABLEQU_EQUIP.EQUIP_ID
	from EQUIP, CABLEQU_EQUIP
	where CABLEQU_ID = :old.CABLEQU_ID
	and EQUIP.EQUIP_ID = CABLEQU_EQUIP.EQUIP_ID
	and EQUIP_VIRTUEL = 0;
begin
	
	if dbms_reputil.from_remote=TRUE then
		return;
	end if;

    if (:old.MODELCABL_ID IS NULL and :new.MODELCABL_ID IS NOT NULL) or
	:old.MODELCABL_ID != :new.MODELCABL_ID then
	for rCEquip in CEquip loop
	    raise_application_error (-20000,
	        'Il existe des �quipements r�els dans le c�blage. Le mod�le n''est plus modifiable');
	end loop;
    end if;
end tub_cablequ;
/


create or replace trigger tu_cablequ after update on CABLEQU for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    Mess     VARCHAR2 (1800);--taille max. du message autoris� par Oracle : 1800 octets 

begin
    
    if dbms_reputil.from_remote=TRUE then
		return;
    end if;

    null;
--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end tu_cablequ;
/


--------------------------------------------------------------------------
--
-- X.L. modification le 09/06/04
-- Le message concernant le c�blage li� � une demande �tait au
-- pr�alable dans tdb_cablequ qui aurait d� �tre un trigger before
-- mais �tait en fait un trigger after; d'o� l'int�gration de son
-- code ici.
--------------------------------------------------------------------------
create or replace trigger td_cablequ after delete on CABLEQU for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    Mess     VARCHAR2 (1800); -- taille max. du message autoris� par Oracle : 1800 octets 
    nEtat	     number (1);

begin
    
    if dbms_reputil.from_remote=TRUE then
		return;
    end if;

    if (:old.ORDRE_ID is not null) then
	select ORDRE_ETAT into nEtat from ORDRE where ORDRE_ID = :old.ORDRE_ID;
	if (nEtat = 2) then	-- cable
		raise_application_error (-20000,
			'On ne peut supprimer un c�blage li� � une demande client � l''�tat CABLE');
	end if;
    end if;

--    CMS_EltGere (Mess, 3, :new.CABLEQU_ID, :new.SITE_ID, 1); 

    null;

--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end td_cablequ;
/
*/

-- Cr�ation X.L. le 07/10/04
-- On ne peut pas cr�er un c�blage de prestation si il existe d�j� un c�blage
-- pour la topologie r�f�renc�e par la prestation. Par contre, du fait que lorsqu'on
-- cr�e un c�blage de topologie, on cr�e �galement un enregistrement dans PROG_CABLEQU
-- pour chaque programme r�f�ren�ant la topologie, le trigger ne doit pas d�clencher
-- lorsque TOP_ID est non null.
--
-- MAJ JFL le 19/04/05
-- Ajout du SITE_ID dans la requ�te afin de mettre la restriction au niveau d'un site.
-- D�sormais, si un site  poss�de d�j� un c�blage de topologie, un c�blage de
-- prestation sera refus�.
--
-- supprim� par ZN 16/07/07 Multitopologie. Maintenant on permet de cr�er 
-- un c�blage de prestation si il existe d�j� un c�blage
-- pour la topologie r�f�renc�e par la prestationon. Et on permet de cr�er
-- des cablages de prestation et de topologie sur un site. 
-- On cr�e plus des enregistrement dans PROG_CABLEQU pour le cablage 
-- des topologies. Dans supervision on affiche le cablage de prestation pour 
-- prestation/site/cablage et le cablage de topologie pour 
-- prestation/topologie/site/cablage
/*
create or replace trigger ti_prog_cablequ after insert on PROG_CABLEQU for each row
when (new.TOP_ID is null)
declare

    SiteId 	number;

    cursor cTop is
	select TOP.TOP_ID, TOP_NOM
	from TOP_CABLEQU, TOP, PROG, CABLEQU
	where PROG.PROG_ID = :new.PROG_ID
	and TOP_CABLEQU.TOP_ID = PROG_TOPO1_ID
	and TOP.TOP_ID = TOP_CABLEQU.TOP_ID
	and CABLEQU.CABLEQU_ID = TOP_CABLEQU.CABLEQU_ID
	and CABLEQU.SITE_ID = SiteId
	union
	select TOP.TOP_ID, TOP_NOM
	from TOP_CABLEQU, TOP, PROG, CABLEQU
	where PROG.PROG_ID = :new.PROG_ID
	and TOP_CABLEQU.TOP_ID = PROG_TOPO2_ID
	and TOP.TOP_ID = TOP_CABLEQU.TOP_ID
	and CABLEQU.CABLEQU_ID = TOP_CABLEQU.CABLEQU_ID
	and CABLEQU.SITE_ID = SiteId;

begin
 -- Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
--     on ne fait pas le traitement 
    if dbms_reputil.from_remote=TRUE then
		return;
    end if;

    -- Recherche du site li� au c�blage de prestation.
    select SITE_ID into SiteId
    from CABLEQU 
    where CABLEQU_ID = :new.CABLEQU_ID;

    -- Recherche si d�j� un c�blage de topologie pour ce site.
    for rcTop in cTop loop
	raise_application_error (-20000, 'C�blage de prestation interdit car la topologie ' || rcTop.TOP_NOM || ' est d�j� c�bl�e');
    end loop;

end ti_prog_cablequ;
/
*/

-- Cr�ation X.L. le 29/09/04
-- On ne peut pas cr�er un c�blage de topologie si il existe d�j� un c�blage
-- pour une prestation faisant r�f�rence � cette topologie.
--
-- MAJ JFL le 19/04/05
-- Ajout du SITE_ID dans la requ�te afin de mettre la restriction au niveau d'un site.
-- D�sormais, si un site  poss�de d�j� un c�blage de prestation, un c�blage de
-- topologie sera refus�.
--
-- supprim� par ZN 16/07/07 Multitopologie. Maintenant on permet de cr�er 
-- un c�blage de prestation si il existe d�j� un c�blage
-- pour la topologie r�f�renc�e par la prestationon. Et on permet de cr�er
-- des cablages de prestation et de topologie sur un site. 
-- On cr�e plus des enregistrement dans PROG_CABLEQU pour le cablage 
-- des topologies. Dans supervision on affiche le cablage de prestation pour 
-- prestation/site/cablage et le cablage de topologie pour 
-- prestation/topologie/site/cablage
/*
create or replace trigger ti_top_cablequ after insert on TOP_CABLEQU for each row
declare

    SiteId 	number;

    cursor cProg is
	select PROG.PROG_ID, PROG_NOM
	from PROG_CABLEQU, PROG, CABLEQU
	where (PROG_TOPO1_ID = :new.TOP_ID or PROG_TOPO2_ID = :new.TOP_ID)
	and PROG_CABLEQU.PROG_ID = PROG.PROG_ID
	and ((TOP_ID != PROG_TOPO1_ID and TOP_ID != PROG_TOPO2_ID) or TOP_ID is null)
	and CABLEQU.CABLEQU_ID = PROG_CABLEQU.CABLEQU_ID
	and CABLEQU.SITE_ID = SiteId;
	
begin
    -- Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
    --  on ne fait pas le traitement 
    if dbms_reputil.from_remote=TRUE then
		return;
    end if;

    -- Recherche du site li� au c�blage de topologie.
    select SITE_ID into SiteId
    from CABLEQU 
    where CABLEQU_ID = :new.CABLEQU_ID;

    -- Recherche si d�j� un c�blage de prestation pour ce site.
    for rcProg in cProg loop
	raise_application_error (-20000, 'C�blage de topologie interdit car le programme ' || rcProg.PROG_NOM || ' est d�j� c�bl�');
    end loop;
end ti_top_cablequ;
/
*/

--     FIN DE CABLEQU     ------------------------------------------


--=====================================================================================
-- Fonction de recherche du n� d'alarme IS (numal) � partir du n� d'acc�s IS
-- sur lequel on est c�bl� et pour les SEM du n� de bit.
--
-- Retourne le n� d'alarme si pas de probl�me, sinon retourne -1

-- X.L. Cr�ation le 12/02/04
--
--=====================================================================================
CREATE OR REPLACE FUNCTION GetIsNumal
(
 lAccesId	NUMBER,			-- ID de l'acc�s IS auquel on est c�bl�
 BitNum		NUMBER			-- N� du bit d'alarme si acc�s SEM (sinon 0)
)
RETURN NUMBER IS
	EquipNom	equip.site_equip_comment%TYPE;
	AccesNom	acces.acces_nom%TYPE;
BEGIN
	IF (BitNum < 0) THEN
		RAISE_APPLICATION_ERROR (-20000, 'Un bit d''alarme SEM ne peut �tre n�gatif');
	END IF;

	SELECT site_equip_comment, acces_nom INTO EquipNom, AccesNom
	FROM equip, acces
	WHERE acces_id = lAccesId
	AND equip.equip_id = acces.equip_id;

	IF (SUBSTR (EquipNom, 7, 3) = 'GTR') THEN
		RETURN (TO_NUMBER (RTRIM (SUBSTR (EquipNom, 11, 2))) - 1) * 48 + TO_NUMBER (AccesNom);
	ELSE
		RETURN ((TO_NUMBER (RTRIM (SUBSTR (EquipNom, 11, 2))) - 1) * 6 + TO_NUMBER (AccesNom) - 1) * 10000 + BitNum;
	END IF;
END GetIsNumal;
/


--=====================================================================================
--
-- Proc�dure de cr�ation du message � destination de EmessEM. Ce message permet
-- � EmessEm d'�tre avis� des cr�ations ou modifications concernant les alarmes
-- � surveiller
-- Cette proc�dure n'est appel�e que lorsqu'une modification ou une cr�ation 
-- sur les param�tres int�ressant EmessEm a eu lieu
--
-- X.L. cr�ation le 18/02/04
-- X.L. modif. le 11/07/06 pour prise en compte des IP2CHOICE et autres EDC boucle
-- de type IP.
--
--=====================================================================================
CREATE OR REPLACE PROCEDURE CreateMessEmMessForAl
(
	Acces2Id	acces.acces_id%TYPE,			-- acces2_id
	Acces1Id	acces.acces_id%TYPE,			-- acces1_id
	AlMin		acces_accesc.alarmgeree_min%TYPE,	-- temporisation
	NewAlToSurv	acces_accesc.alarmgeree_tosurv%TYPE,	-- Nouvelle valeur d'indicateur de surveillance
	OldAlToSurv	acces_accesc.alarmgeree_tosurv%TYPE,	-- Ancienne valeur d'indicateur de surveillance
	TypSai		varchar2, 				-- Indicateur de (C)r�ation ou (M)odification
								-- (S)uppression
	BindingId	acces_accesc.acces_bindingid%TYPE,	-- ID de l'�quipement GSITE (si GSITE)
	FreqN		acces_accesc.alarmgeree_freqn%TYPE,	-- Fr�quence de l'alarme
	FreqD		acces_accesc.alarmgeree_freqd%TYPE	-- Temps de mesure de la fr�quence	
)

IS
	GtrId		typeq.typeq_id%TYPE;
	SemId		typeq.typeq_id%TYPE;
	Ip2Id		typeq.typeq_id%TYPE;
	GSiteId		typeq.typeq_id%TYPE;
	AccesIdent	acces.acces_ident%TYPE;
	AccesClass	acces.acces_classid%TYPE;
	AccesType	acces.acces_type%TYPE;
	EquipId		equip.equip_id%TYPE;
	EquipIp		equip.equip_addrip%TYPE;
	SiteId		site.site_id%TYPE;
	LiaiId		liai.liai_id%TYPE;
	TypObj		VARCHAR2 (1);
	ObjId		NUMBER;				-- ID de l'�quipement ou site ou liaison
	EquipNom	equip.site_equip_comment%TYPE;
	Mess		messem.messem_mess%TYPE;
	EmTypId		typeq.typeq_id%TYPE;
	EmTypNom	typeq.typeq_nom%TYPE;
	EmEqtId		equip.equip_id%TYPE;
	EmEqtNom	equip.site_equip_comment%TYPE;
	EmEqtIp		equip.equip_addrip%TYPE;
	EmAccNom	acces.acces_nom%TYPE;
	EqtToSurv	equip.equip_tosurv%TYPE;

	CURSOR cCollecte (RecAlName VARCHAR2) IS
		SELECT typeq_id FROM typeq WHERE typeq_nom = RecAlName;
BEGIN

	GtrId := 0;
	Ip2Id := 0;
	GSiteId := 0;
	SemId := 0;
	OPEN cCollecte ('CARTE GTR');
	FETCH cCollecte INTO GtrId;
	CLOSE cCollecte;

	OPEN cCollecte ('CARTE SEM');
	FETCH cCollecte INTO SemId;
	CLOSE cCollecte;

	OPEN cCollecte ('IP2PORT');
	FETCH cCollecte INTO Ip2Id;
	CLOSE cCollecte;

	OPEN cCollecte ('GSITE');
	FETCH cCollecte INTO GSiteId;
	CLOSE cCollecte;

	IF Acces1Id = 0 THEN	-- Equipement de collecte dont GSITE est le seul � nous int�resser
		SELECT site_equip_comment, equip_tosurv, typeq_id
		INTO EquipNom, EqtToSurv, EmTypId
		FROM equip
		WHERE equip_id = BindingId;

		IF EmTypId != GSiteId THEN
			RETURN;
		END IF;

	ELSE
		SELECT acces_classid, acces_type, equip.equip_id, equip_tosurv, acces_ident, site.site_id, liai.liai_id
		INTO AccesClass, AccesType, EquipId, EqtToSurv, AccesIdent, SiteId, LiaiId
		FROM liai, site, equip, acces
		WHERE acces_id = Acces1Id
		AND equip.equip_id (+) = acces.equip_id
		AND site.site_id (+) = acces.site_id
		AND liai.liai_id (+) = acces.liai_id;

		IF SiteId IS NOT NULL THEN
			TypObj := 'S';
			ObjId := SiteId;
			EqtToSurv := 1;
		ELSIF LiaiId IS NOT NULL THEN
			TypObj := 'L';
			ObjId := LiaiId;
			EqtToSurv := 1;
		ELSE
			TypObj := 'E';
			ObjId := EquipId;
		END IF;
	END IF;

	IF EqtToSurv = 0 OR AccesClass = 2035 OR AccesType = 2 THEN	
		-- L'�quipement n'est pas surveill� ou il s'agit d'un lien entre
		-- acc�s transmission ou c'est un acc�s s�rie (trait� au niveau bit)
		-- donc on ne fait rien
		RETURN;
	END IF;

	IF Acces1Id = 0 THEN						-- Eqt GSITE
		IF TypSai = 'S' THEN
			Mess := '#9#7#5#S#' || to_char (BindingId) || '#' || EquipNom || '#';
		ELSE
			Mess := '#9#11#5#' || TypSai || '#' || to_char (BindingId) || '#' || EquipNom || '#' ||
				 to_char (AlMin) || '#'  || to_char (FreqN) || '#' ||
				 to_char (FreqD) || '#' || to_char (NewAlToSurv) || '#';
		END IF;

	ELSIF (Acces2Id IS NULL OR Acces2Id = 0) AND Acces1Id > 0 THEN	-- Pour un trap
		SELECT equip_addrip INTO EquipIp FROM equip WHERE equip_id = EquipId;

		IF (TypSai = 'S') THEN
			Mess := '#9#8#4#S#' || EquipIp || '#' || to_char (EquipId) || '#' || AccesIdent || '#';
		ELSE
			Mess := '#9#12#4#' || TypSai || '#' || EquipIp || '#' ||
				to_char (EquipId) || '#' || AccesIdent || '#' || 
				to_char (AlMin) || '#'  || to_char (FreqN) || '#' ||
				to_char (FreqD) || '#' || to_char (NewAlToSurv) || '#';
		END IF;

	ELSIF (Acces2Id > 0) THEN
		IF EquipId IS NOT NULL THEN
			SELECT	E1.typeq_id, E1.equip_id, E1.typeq_nom, E1.site_equip_comment, E1.equip_addrip,
				A1.acces_nom
			INTO EmTypId, EmEqtId, EmTypNom, EmEqtNom, EmEqtIp, EmAccNom
			FROM equip E1, acces A1
			WHERE A1.acces_id = Acces2Id
			AND E1.equip_id = A1.equip_id;

		ELSIF SiteId IS NOT NULL OR LiaiId IS NOT NULL THEN
			SELECT	E1.typeq_id, E1.equip_id, E1.typeq_nom, E1.site_equip_comment, E1.equip_addrip,
				A1.acces_nom
			INTO EmTypId, EmEqtId, EmTypNom, EmEqtNom, EmEqtIp, EmAccNom
			FROM equip E1, acces A1
			WHERE A1.acces_id = Acces2Id
			AND E1.equip_id = A1.equip_id;
		END IF;

		IF (EmTypId = GtrId) THEN
			IF (TypSai = 'S') THEN
				Mess := '#9#9#2#S#' || TypObj || '#' || to_char (ObjId) || '#' || 
					ltrim (substr (EmEqtNom, 4, 2)) || '#' ||
					to_char ((to_number (substr (EmEqtNom, 11, 2)) - 1) * 48 + to_number (EmAccNom)) ||
					'#';

			ELSIF (NewAlToSurv != OldAlToSurv) THEN
				Mess := '#9#10#2#' || TypSai || '#' || TypObj || '#' || to_char (ObjId) || '#' ||
					ltrim (substr (EmEqtNom, 4, 2)) || '#' ||
					to_char ((to_number (substr (EmEqtNom, 11, 2)) - 1) * 48 + to_number (EmAccNom)) ||
					'#' || to_char (NewAlToSurv) || '#';
			END IF;

		ELSIF (EmTypId != SemId) THEN	-- IP2PORT ou IP2CHOICE ou autre EDC boucle de type IP (ex: NEC)
			IF (TypSai = 'S') THEN
				Mess := '#9#10#3#S#' || TypObj || '#' || to_char (ObjId) || '#' || EmEqtIp || '#' ||
					to_char (EmEqtId) || '#' || EmAccNom || '#';
			ELSE
				Mess := '#9#14#3#' || TypSai || '#' || TypObj || '#' || to_char (ObjId) || '#' ||
					EmEqtIp || '#' ||
					to_char (EmEqtId) || '#' || EmAccNom || '#' || to_char (AlMin) || '#' || 
					to_char (FreqN) || '#' || to_char (FreqD) || '#' || 
					to_char (NewAlToSurv) || '#';
			END IF;
		END IF;
	END IF;

	IF mess IS NOT NULL THEN
		INSERT INTO messem (messem_id, messem_mess)
		VALUES (seq_messem.NEXTVAL, Mess);
	END IF;

END CreateMessEmMessForAl;
/


--=====================================================================================
-- Proc�dure Mask_Alrm :
-- Cr�ation JPB le 21/10/99
--
-- Objet : signaler aux postes clients un d�but ou fin de masquage, afin de colorier
--	   les �lements masqu�s.
--
-- 18/09/03 : JPB : Modification du message MESSALRM, pour introduire le nb. de # envoy�s
--
--=====================================================================================

CREATE OR REPLACE PROCEDURE mask_alrm (Mess IN OUT VARCHAR2, 
	AlarmCl VARCHAR2, AlarmNumObj NUMBER, AlarmNumal VARCHAR2, AlarmGrave NUMBER,
	SiteId NUMBER, EquipId NUMBER, LiaiId NUMBER, TsPrOper VARCHAR2)
-- AlarmGrave = 1 en d�but de masquage (Brig.) ou
-- AlarmGrave = 0 en   fin de masquage (Brig.) ou
-- AlarmGrave = 3 en d�but de masquage (Adm.)  ou
-- AlarmGrave = 2 en   fin de masquage (Adm.)

IS
    MessId	NUMBER;
    BindingId	NUMBER;
    BindingType NUMBER;

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
    Mess := CONCAT (Mess, BindingId);   Mess := CONCAT (Mess,  '#');  /* BindingId */
    Mess := CONCAT (Mess, BindingType); Mess := CONCAT (Mess,  '#');  /* BindingType */

    Mess := CONCAT (Mess, '0#');  		/* Id d�but al. AlarmIddeb */
    Mess := CONCAT (Mess, ' #');		/* Nom de l'al. g�r�e AlarmNomL */
    Mess := CONCAT (Mess, AlarmCl);    	Mess := CONCAT (Mess,  '#');  /* Classe : IS etc.. */
    Mess := CONCAT (Mess, AlarmNumObj);	Mess := CONCAT (Mess,  '#');  /* n�objet : IS */
    Mess := CONCAT (Mess, '0#');		/* Type al. g�r�e AlarmType */
    Mess := CONCAT (Mess, ' #');		/* Date */
    Mess := CONCAT (Mess, AlarmGrave); 	Mess := CONCAT (Mess,  '#');  /* gravit� alarme */
    Mess := CONCAT (Mess, ' #');		/* Nom seuil */
    Mess := CONCAT (Mess, '0#');		/* Valeur seuil */
    Mess := CONCAT (Mess, AlarmNumal); 	Mess := CONCAT (Mess,  '#');
    Mess := CONCAT (Mess, TsPrOper); 	Mess := CONCAT (Mess,  '#');

--insert into test values (seq_test.nextval, 'mask_alrm' || Mess);
    insert into MESSALRM (MESSALRM_ID, MESSALRM_MESS, MESSALRM_SENT, MESSALRM_NATURE)
	values (MessId, Mess, 0, 0);
-- dbms_lock.sleep (0.02); -- attendre que le pr�c�dent message soit �mis (20 ms.)  
-- dbms_alert.signal ('Alarme', Mess);

END mask_alrm;
/



--=====================================================================================
-- Trigger sur acces_accesc :
-- Cr�ation X.L. le 29/10/99
-- 
-- Objet : D�tecter si le c�blage est entre IS et �quipement ou site ou liaison
-- afin d'envoyer alors �  l'�quipement de m�diation un message afin de l'inviter � consulter 
-- les temporisations de la carte IS correspondante.
-- Ce trigger suppose qu'un c�blage (en cr�ation ou modification) entre deux acc�s se fait
-- toujours par un insert dans la table acces_accesc et jamais par un update d'un
-- enregistrement existant.
-- Dans un c�blage avec IS, l'acc�s de l'IS est repr�sent� par acces2_id.
--
-- Modif. X.L. le 05/11/99 pour �liminer ce qui correspondait au pr�alable � la cr�ation
-- puisque le trigger �tait initialement pour INSERT et UPDATE
--
-- Modif JPB le 02/09/02 : s�paration alarmes / structure
--
-- 18/09/03 : JPB : Modification du message MESSALRM, pour introduire le nb. de # envoy�s
--
-- Modif. X.L. le 13/02/04 pour construction du message � destination de EmessEM
--
--=====================================================================================
CREATE OR REPLACE TRIGGER tu_acces_accesc AFTER UPDATE ON acces_accesc FOR EACH ROW

DECLARE
	Mess		VARCHAR2 (1800);
	MessId  	integer;

	CURSOR C1 IS
		SELECT acces_nom, acces_type, site_equip_comment, typeq.typeq_nom, typeq.typeq_id
		FROM acces, equip, typeq
		WHERE acces_id = :new.acces2_id
		AND equip.equip_id = acces.equip_id
		AND typeq.typeq_id = equip.typeq_id;

BEGIN

    	/* traitement � effectuer sur les DEUX serveurs (s�paration alarme/structure) */
    	update ACCES_ACCESC_REP
	    set ALARMGEREE_GRAVE  = :new.ALARMGEREE_GRAVE
	    where ACCES_ACCESC_ID = :new.ACCES_ACCESC_ID;

	/* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
	   on ne fait pas le traitement */
	if dbms_reputil.from_remote=TRUE then
		return;
	end if;

	IF :old.alarmgeree_min IS NOT NULL AND :new.alarmgeree_min IS NOT NULL
	   AND :new.alarmgeree_min != :old.alarmgeree_min THEN
		FOR rC1 IN C1 LOOP
			IF rC1.typeq_id = 1 THEN  -- Changement de tempo GTR

				    select SEQ_MESSALRM.NEXTVAL into MessId from dual;
				    Mess := '6#';			-- Code du message
				    Mess := CONCAT (Mess, '8#');	-- Nb. de #
				    Mess := CONCAT (Mess, '0#');	-- Alarm_Id
    				    Mess := CONCAT (Mess, MessId);
				    Mess := CONCAT (Mess, '#'); /* stockage dans MESSALRM */
	    			    Mess := CONCAT (Mess, '0#');	/* Alarmgeree_Id */
			    	    Mess := CONCAT (Mess, '0#');		/* BindingId */
   				    Mess := CONCAT (Mess, '0#');		/* BindingTyp */
				    Mess := Mess || '4' || rC1.site_equip_comment || '/'
					 || rc1.acces_nom || '/' 
					 || TO_CHAR (:new.acces_accesc_prebit) || '/'
					 || TO_CHAR (:new.acces_accesc_derbit) || '#';

--insert into test values(seq_test.nextval, 'tu_acces_accesc' || Mess);

				    insert into MESSALRM (MESSALRM_ID, MESSALRM_MESS,
							 MESSALRM_SENT, MESSALRM_NATURE)
			    	    values (MessId, Mess, 0, 0);
--  dbms_lock.sleep (0.02); -- attendre que le pr�c�dent message soit �mis (20 ms.)  
--  dbms_alert.signal ('Mediation', Mess);

			END IF;
			EXIT;
		END LOOP;
	END IF;

	-- Contruction du message pour EmessEM
	IF :new.alarmgeree_tosurv != :old.alarmgeree_tosurv OR :new.alarmgeree_min != :old.alarmgeree_min OR
	   :new.alarmgeree_freqn != :old.alarmgeree_freqn OR :new.alarmgeree_freqd != :old.alarmgeree_freqd THEN
		CreateMessEmMessForAl (:new.acces2_id, :new.acces1_id, :new.alarmgeree_min,
				    :new.alarmgeree_tosurv, :old.alarmgeree_tosurv, 'M',
				    :new.acces_bindingid, :new.alarmgeree_freqn, :new.alarmgeree_freqd);
	END IF;
END tu_acces_accesc;
/


--=====================================================================================
-- Trigger sur acces_accesc :
-- Cr�ation X.L. le 14/04/99
-- 
-- Objet : D�tecter si le c�blage est entre IS et �quipement ou site ou liaison
-- afin d'envoyer alors �  l'�quipement de m�diation un message afin de l'inviter � consulter 
-- les temporisations de la carte IS correspondante.
-- Ce trigger suppose qu'un c�blage (en cr�ation ou modification) entre deux acc�s se fait
-- toujours par un insert dans la table acces_accesc et jamais par un update d'un
-- enregistrement existant.
-- Dans un c�blage avec IS, l'acc�s de l'IS est repr�sent� par acces2_id.
--
-- Modif. X.L. le 05/05/99 pour introduction de la notion de CARTE GTR et CARTE SEM
--
-- Modif. X.L. le 19/07/99 pour remplacer les alertes ORACLE par un envoi de message par
-- socket TCP/IP, ceci par l'interm�diaire d'un insert dans la table MESSALARM et du
-- process serveur EmessAlrm2.
--
-- Modif. X.L. du 29/10/99 pour la cr�ation conjointe de acces_accesc2
--
-- Modif. X.L. le 05/11/99 pour �liminer ce qui concerne la modification puisque au
-- pr�alable, le curseur �tait pour INSERT et UPDATE
--
-- Modif. X.L. le 21/07/00 pour faire la mise � jour de ACCES_NBOCC sur ACCES
--
-- Modif JPB le 02/09/02 s�paration alarmes / structure
--
-- 18/09/03 : JPB : Modification du message MESSALRM, pour introduire le nb. de # envoy�s
--
-- 18/02/04 : X.L. : Modification pour ajout du message � destination de EmessEM
--
-- 05/06/04 : X.L. : Modification pour mise � jour du nombre de ports sur l'�quipements
--
-- ACCES_ACCESC2 g�r� maintenant par TIMOS
-- L'insertion dans ACCES_ACCESC_REP n'est faite que pour un acc�s alarme (X.L. 16/06/09)
--
-- 12/08/09 : X.L. : inhibition des parties sp�cifiques Globecast pour �viter les
-- probl�mes de mutating quand on cr�e un �quipement de type EQUIP MEDIATION (la partie
-- TESTEM est faite dans le trigger TI_EQUIP). A modifier quand on traitera Globecast
--
--=====================================================================================
create or replace TRIGGER ti_acces_accesc AFTER INSERT ON acces_accesc FOR EACH ROW
DECLARE
	Mess	VARCHAR2 (1800);
	MessId  integer;
	EquipId equip.equip_id%TYPE;
	ToSurv  equip.equip_tosurv%TYPE;
        
        /* Sp�cifique Globecast pour envoi de messages aux IS
	CURSOR C1 IS
		SELECT acces_nom, acces_type, site_equip_comment, typeq.typeq_nom, typeq.typeq_id
		FROM acces, equip, typeq
		WHERE acces_id = :new.acces2_id
		AND equip.equip_id = acces.equip_id
		AND typeq.typeq_id = equip.typeq_id;
                */
BEGIN
    	/* traitement � effectuer sur les DEUX serveurs (s�paration alarme/structure) */
	-- ACCES_ACCESC_REP n�cessaire uniquement pour les acc�s alarme
	if (:new.ACCES_BINDINGCLASSID = 0 or :new.ACCES_BINDINGCLASSID = 8) then
    		insert into ACCES_ACCESC_REP (acces_accesc_id, alarm_cl, alarm_numobj, alarm_numal,
			alarm_id, equip_id, site_id, liai_id, alarm_sec, alarmgeree_grave)
	    	values (:new.acces_accesc_id, null, null, null, null, null, null, null, null,
		    	:new.alarmgeree_grave);
	end if;
	/* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
	   on ne fait pas le traitement */
	if dbms_reputil.from_remote=TRUE then
		return;
	end if;
        
        /*
            Sp�cifique Globecast pour envoi de message aux IS
            FOR rC1 IN C1 LOOP
          	IF rC1.acces_type = 7 AND
		   (rC1.typeq_id = 1 OR rC1.typeq_id = 2) THEN
		    select SEQ_MESSALRM.NEXTVAL into MessId from dual;
		    Mess := '6#';				-- Code du message
		    Mess := CONCAT (Mess, '8#');		-- Nb. de #
		    Mess := CONCAT (Mess, '0#');		-- Alarm_Id
    		    Mess := CONCAT (Mess, MessId);
		    Mess := CONCAT (Mess, '#');     -- stockage dans MESSALRM
	    	    Mess := CONCAT (Mess, '0#');		-- Alarmgeree_Id
	    	    Mess := CONCAT (Mess, '0#');		-- BindingId
   		    Mess := CONCAT (Mess, '0#');		-- BindingTyp
		    Mess := Mess || '4' || rC1.site_equip_comment || '/'
			   	 || rc1.acces_nom || '/'
				 || TO_CHAR (:new.acces_accesc_prebit) || '/'
				 || TO_CHAR (:new.acces_accesc_derbit) || '#';
		    insert into MESSALRM (MESSALRM_ID, MESSALRM_MESS, MESSALRM_SENT,
					  MESSALRM_NATURE)
	    	    values (MessId, Mess, 0, 0);
		END IF;
		EXIT;
            END LOOP;
            */
            
        /* Dans le contexte SMT, on ne g�re plus le contr�le de l'occupation
           au niveau SPV
	IF (:new.acces1_id > 0) THEN
		UPDATE acces SET acces_nbocc = acces_nbocc + 1
		WHERE acces_id = :new.acces1_id;
	END IF;
	IF (:new.acces2_id > 0) THEN
		UPDATE acces SET acces_nbocc = acces_nbocc + 1
		WHERE acces_id = :new.acces2_id;
	END IF;
        */
        
/*	INSERT INTO ACCES_ACCESC2 (acces_accesc2_id, mskbri_min, mskbri_max, bri_masque,
		mskadm_min, mskadm_max, adm_masque, trig)
	VALUES (:new.acces_accesc_id, 0, 0, 0, 0, 0, 0, 0);*/
        
        IF (:new.ACCES1_ID > 0) THEN
            -- � modifier pour Globecast
            CreateMessEmMessForAl (:new.acces2_id, :new.acces1_id, :new.alarmgeree_min,
                                    :new.alarmgeree_tosurv, 0, 'C', :new.acces_bindingid,
                                    :new.alarmgeree_freqn, :new.alarmgeree_freqd);
        END IF;

/*
	IF (:new.acces1_id IS NOT NULL and :new.acces2_id IS NOT NULL) THEN
		MajEquipNbOcc (NULL, NULL, :new.acces1_id, :new.acces2_id);
	END IF;
*/
END ti_acces_accesc;
/



--=====================================================================================
-- Trigger sur acces_accesc :
-- Cr�ation X.L. le 29/10/99
-- 
--
-- Efface ACCES_ACCESC2.
--
-- Modif. X.L. le 19/11/99 pour mettre � jour ALARM
--
-- Modif. X.L. le 21/07/00 pour faire la mise � jour de ACCES_NBOCC sur ACCES
--
-- Modif. JPB  le 18/10/00 pour enlever la contrainte "Alarme non en cours sur l'acc�s"
--
-- Modif. JPB  le 02/09/02 pour s�parer les alarmes et la structure
--
-- Modif X.L. le 18/02/04 pour g�n�rer le message � destination de EmessEm
--
-- Modif. JPB  le 06/03/04 pour d�masquer les alarmes correspondant � cet acc�s
--
-- 05/06/04 : X.L. : Modification pour mise � jour du nombre de ports sur l'�quipements
--
-- 17/10/07 : ZN : Suppresion de cablequ_cablequl correspondent � old.acces_accesc_id
--
--=====================================================================================
create or replace TRIGGER tdb_acces_accesc BEFORE DELETE ON acces_accesc FOR EACH ROW

DECLARE
	EquipId	NUMBER;		-- Id �quip. en d�faut
	LiaiId	NUMBER;		-- Id liaison en d�faut
	SiteId	NUMBER;		-- Id site en d�faut

	Mess VARCHAR2 (2000);	-- Message � �mettre

	CURSOR C1 IS
		SELECT acces_type, typeq.typeq_nom
		FROM acces, equip, typeq
		WHERE acces_id = :old.acces2_id
		AND equip.equip_id = acces.equip_id
		AND typeq.typeq_id = equip.typeq_id;
BEGIN

	select EQUIP_ID, LIAI_ID, SITE_ID
	    into EquipId, LiaiId, SiteId
	    from ACCES
	    where ACCES_ID = :old.ACCES1_ID;

    	/* traitement � effectuer sur les DEUX serveurs (s�paration alarme/structure) */
    	delete ACCES_ACCESC_REP
	    where ACCES_ACCESC_ID = :old.ACCES_ACCESC_ID;

	/* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
	   on ne fait pas le traitement */
	if (ETAT_REPLICATION = 1) then
		return;
	end if;
	if dbms_reputil.from_remote=TRUE then
		return;
	end if;

--	UPDATE alarm SET cablagep_id = NULL
--	    WHERE cablagep_id = :old.acces_accesc_id;

        /* Dans le contexte SMT, un trigger sur un enfant ne doit pas mettre
           � jour un parent; ceci peut emp�cher la suppression ou la mise � jour
           du parent par l'application cliente
	IF (:old.acces1_id > 0) THEN
	    UPDATE acces SET acces_nbocc = acces_nbocc - 1
	    WHERE acces_id = :old.acces1_id;
	END IF;

	IF (:old.acces2_id > 0) THEN
	    UPDATE acces SET acces_nbocc = acces_nbocc - 1
	    WHERE acces_id = :old.acces2_id;
	END IF;
        */
        
	-- D�masquage des alarmes �ventuelles
	if (:old.MSKBRI_MIN > 0) then
	    Mask_Alrm (Mess, ' ', 0, to_char (:old.ACCES_ACCESC_ID), 0,
		       SiteId, EquipId, LiaiId, ''); -- D�masquage BRI
	end if;
	if (:old.MSKADM_MIN > 0) then
	    Mask_Alrm (Mess, ' ', 0, to_char (:old.ACCES_ACCESC_ID), 2,
		       SiteId, EquipId, LiaiId, ''); -- D�masquage ADM
	end if;

/*	DELETE acces_accesc2
	    WHERE acces_accesc2_id = :old.acces_accesc_id;*/
/*
	IF :old.alarm_id IS NOT NULL THEN
	    raise_application_error (-20000, 'Alarme en cours; d�c�blage interdit');
	END IF;
*/

	-- G�n�ration du message � destination de EmessEm
	CreateMessEmMessForAl (:old.acces2_id, :old.acces1_id, :old.alarmgeree_min, 0, 1, 'S',
			    :old.acces_bindingid, 0, 0);
/*
	IF (:old.acces1_id IS NOT NULL and :old.acces2_id IS NOT NULL) THEN
		MajEquipNbOcc (:old.acces1_id, :old.acces2_id, NULL, NULL);
	END IF;
*/
END	TDB_ACCES_ACCESC;
/



--=====================================================================================
--
-- Proc�dure de cr�ation du message � destination de EmessEM. Ce message permet
-- � EmessEm d'�tre avis� des cr�ations ou modifications concernant les alarmes
-- s�rie � surveiller
-- Cette proc�dure n'est appel�e que lorsqu'une modification, cr�ation, suppression
-- a eu lieu sur les bits d'alarme s�rie c�bl�s
--
-- X.L. cr�ation le 19/02/04
-- JFL  modif	 le 25/04/07 : ajout du curseur CAcces pour g�rer les valeurs non trouv�es
--
--=====================================================================================
CREATE OR REPLACE PROCEDURE CreateMessEmMessForAlS
(
 AccesEqt	acces.acces_id%TYPE,			-- Acc�s de l'�quipement
 BitNum		number,		-- N� du bit d'alarme s�rie
 ToSurv		alarmgeree.alarmgeree_tosurv%TYPE,	-- Indicateur d'alarme � surveiller
 TypSai		VARCHAR2				-- Type de saisie (C, M, S)
)
IS
	AccesNum	NUMBER;				-- N� d'acc�s sur l'IS
	EqtNom		equip.site_equip_comment%TYPE;	-- Nom de la carte IS
	EqtNum		NUMBER;				-- N� de carte SEM sur l'IS
	EqtId		equip.equip_id%TYPE;		-- ID de l'�qt trans.
	EqtToSurv	equip.equip_tosurv%TYPE;	-- Indicateur "� surveiller" de l'eqt trans.

	-- Recherche informations sur l'acc�s en cours de modification.
	cursor CAcces is
	    SELECT to_number (A1.acces_nom) as accesnom, E1.site_equip_comment as equipcomment,
	           E2.equip_id as equipid, E2.equip_tosurv as equiptosurv
	    FROM equip E2, acces A2, equip E1, acces A1, acces_accesc
	    WHERE acces1_id = AccesEqt
	    AND A1.acces_id = acces2_id
	    AND E1.equip_id = A1.equip_id
	    AND A2.acces_id = acces1_id
	    AND E2.equip_id = A2.equip_id;
BEGIN
        EqtId := null;
        
	for rCA in CAcces loop
	    AccesNum   := rCA.accesnom;
	    EqtNom     := rCA.equipcomment;
	    EqtId      := rCA.equipid;
	    EqtToSurv  := rCA.equiptosurv;
	    exit;
	end loop;

	if (EqtId is null or EqtId = 0) then
	        return;
	end if;
	
	IF (EqtToSurv = 0) THEN
		RETURN;
	END IF;

	IF TypSai = 'S' THEN
		INSERT INTO messem (messem_id, messem_mess)
		VALUES
		(seq_messem.NEXTVAL,
		 '#9#8#8#S#' || to_char (EqtId) || '#' || ltrim (substr (EqtNom, 4, 2)) || '#' ||
		 to_char (((to_number (substr (EqtNom, 11, 2)) - 1) * 8 + (AccesNum - 1)) * 10000 + BitNum) || '#');
	ELSE
		INSERT INTO messem (messem_id, messem_mess)
		VALUES
		(seq_messem.NEXTVAL,
		 '#9#9#8#' || TypSai || '#' || to_char (EqtId) || '#' || ltrim (substr (EqtNom, 4, 2)) || '#' ||
		 to_char (((to_number (substr (EqtNom, 11, 2)) - 1) * 8 + (AccesNum - 1)) * 10000 + BitNum) || '#' ||
		 to_char (ToSurv) || '#');
	END IF;

END CreateMessEmMessForAlS;
/




--========================================================================================
--
-- Cr�� par JPB le 29/01/01 : introduction du champ TYPLIAI_NOM
--
--========================================================================================

create or replace trigger tib_liai before insert on LIAI for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    strTypLiaiNom    varchar2 (40);

begin
    /* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
       on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
		return;
    end if;

    SELECT typliai_nom INTO strTypLiaiNom FROM typliai WHERE typliai_id = :new.typliai_id;
    :new.typliai_nom := strTypLiaiNom;

--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end	tib_liai;
/


/*
--========================================================================================
--
-- Cr�� par X.L. le 06/09/05 : Protection contre la modification du sens de la liaison
--
--========================================================================================

create or replace
trigger tub_liai before update on LIAI for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    strTypLiaiNom    varchar2 (40);

    cursor CurRefProg is
	select PROG_ID from PROG_LIAI where LIAI_ID = :new.LIAI_ID
	for update of PROG_ID nowait;

    cursor CurRefTop is
	select TOP_ID from TOP_LIAI where LIAI_ID = :new.LIAI_ID
	for update of TOP_ID nowait;

  

begin
    
    if dbms_reputil.from_remote=TRUE then
		return;
    end if;

    if (:new.SITE_ORIGID != :old.SITE_ORIGID or :new.SITE_DESTID != :old.SITE_DESTID) then
    	for rCurRefProg in CurRefProg loop
    		raise_application_error (-20000, 'Un programme utilise la liaison');
    	end loop;
    
    	for rCurRefTop in CurRefTop loop
    		raise_application_error (-20000, 'Une topologie utilise la liaison');
    	end loop;
    
  
    end if;

--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end	tub_liai;
/

*/


--========================================================================================
--
-- Cr�� par JPB le 29/01/01 : introduction du champ TYPLIAI_NOM dans LIAI
--
--========================================================================================

CREATE OR REPLACE TRIGGER tu_typliai AFTER UPDATE ON typliai FOR EACH ROW

DECLARE

    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    CURSOR c1 is
	select TYPLIAI_NOM from LIAI
	    where TYPLIAI_ID = :new.TYPLIAI_ID
	    for update of TYPLIAI_NOM nowait;

BEGIN
	/* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
	   on ne fait pas le traitement */
	if dbms_reputil.from_remote=TRUE then
		return;
	end if;

    if (:new.TYPLIAI_NOM != :old.TYPLIAI_NOM) then
    	for rc1 in c1 loop
    	    update LIAI
	        set TYPLIAI_NOM = :new.TYPLIAI_NOM
	    	where current of c1;
    	end loop;
    end if;

--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end	tu_typliai;
/

/*
-- ZN creation le 6/11/07
-- prend en compte d'inclusion des topologies
CREATE OR REPLACE PROCEDURE MajMask(TopId NUMBER, Mask NUMBER, OldMask NUMBER)
is
  CURSOR CurProg is
      select prog_id from prog_top where top_id=TopId;
      
  CURSOR CurTop is
      select top_id from top_top where childtop_id=TopId;
      
BEGIN 
  
  if(OldMask=-100000) then
    for vProg in CurProg loop
        update PROG  set PROG_MASQUE = Mask
        where PROG_ID = vProg.PROG_ID ;
    end loop;
  else
    for vProg in CurProg loop
        update PROG  set PROG_MASQUE = Mask
        where PROG_ID = vProg.PROG_ID and
        PROG_MASQUE = OldMask; 	-- pour respecter les masquages adm. �ventuels
    end loop;
  end if;
  
  for vTop in CurTop loop
    MajMask(vTop.top_id, Mask, OldMask);
  end loop;
           		
end MajMask;
/
*/

/*
-- ZN creation le 6/11/07
-- prend en compte d'inclusion des topologies
CREATE OR REPLACE PROCEDURE InsertMask(TopId NUMBER, CablId NUMBER, TypeM NUMBER, Mask NUMBER )
is
  CURSOR CurProg is
      select prog_id from prog_top where top_id=TopId;
      
  CURSOR CurTop is
      select top_id from top_top where childtop_id=TopId;
      
BEGIN 
  
  for vProg in CurProg loop
    insert into PROG_MSK (CABL_ID, PROG_ID, TYPE, MSK)
        			    values (CablId, vProg.PROG_ID, TypeM, Mask);
  end loop;
  
  for vTop in CurTop loop
    InsertMask(vTop.top_id, CablId, TypeM, Mask);
  end loop;
        		
end InsertMask;
/
*/



--=====================================================================================
-- Trigger sur acces_accesc2 :
-- Cr�ation JPB le 21/10/99
--
-- Objet : d�tecter le masquage d'une alarme en cours, afin d'effacer cette alarme des �crans
--
-- Modif. X.L. le 18/02/00 pour les insert dans prog_msk on pr�cise les colonnes du fait de
-- l'ajout de PROG_MSK_ID
-- Modif JPB le 09/06/00 en raison de l'utilisation de la proc�dure MaskModified
--
-- Modif. X.L. le 09/12/03 pour mise � jour de la nouvelle colonne MSKADM_HOW
--
-- Modif. X.L. le 07/01/06 afin d'effacer les informations de masquage dans ACCES_ACCESC
-- lorsque la date courante est sup�rieure � la date max. de masquage
--
--	Modif JPB le 02/10/06 : reprise du traitement concernant TsPrOper
--
-- Modif. ZN le 6/11/07 prend en compte d'inclusion des topologies

--=====================================================================================
 
CREATE OR REPLACE TRIGGER tub_acces_accesc2 BEFORE UPDATE ON acces_accesc2 FOR EACH ROW

DECLARE
    ToDayStr	VARCHAR2 (20);	/* date et heure actuelle au format YYYY MM DD HH24:MI:SS */
    ToDaySec	NUMBER;		/* idem en nombre de secondes depuis le 01/01/1998 00:00:00 */
    Mess	VARCHAR2 (1800);   /* message d'alarme */
    OldMask	NUMBER;		/* 1 si l'alarme �tait masqu�e avant le changement, 0 sinon  */
    NewMask	NUMBER;		/* 1 si l'alarme devient masqu�e apr�s le changement, 0 sinon */

    ProgNb	NUMBER;		/* idem */
    SiteId	NUMBER;		/* Id du site en d�faut */
    EquipId	NUMBER;		/* Id de l'�quipement en d�faut */
    LiaiId	NUMBER;		/* Id de la liaison en d�faut */

    SiteNom     VARCHAR2 (40);  /* nom du site contenant l'�lt. en d�faut. ' ' pour une liaison
				inter-site. Inutilis� ici */
    Typeq    	VARCHAR2 (40);  
				/* nom du type de l'�quipement ou de la liaison. 
				'SITE' pour une alarme	de site . Inutilis� ici*/
    Poseq    VARCHAR2 (80);  	/* Position de l'�quuipement ou nom de la liaison ou du site en 
				d�faut. Inutilis� ici */

    TsPrOper VARCHAR2 (900); /* Cha�ne donnant l'�tat op�rationnel des prog. concern�s par 
				cette alarme. 70 prog. au max.
				Structure : NbProg; ProgId, OldProgOper, ProgOper, ProgMsk;
				NON Maintenant : Structure : ProgId, OldProgOper, ProgOper, ProgMsk; ProgId,  etc... */
    Debord   NUMBER;	     /* 1 si d�bordement de la cha�ne TsPrOper, 0 sinon */
    Routage	VARCHAR2 (40);	-- Permet de savoir si un routage est associ� au programme

    TsPrOper2 VARCHAR2(900);
    ProgOper	NUMBER;		/* Etat op�rationnel d'un programme */
    ProgMsk	NUMBER;		/* Masque d'un programme */

    CURSOR cAlarm (Id NUMBER) is
	select * from ALARM
	    where ALARM_ID = Id;

    CURSOR cAcc (Id NUMBER) is
	select A.ACCES1_ID, A.ALARMGEREE_ID, A.ACCES_BINDINGID,
	       B.ALARMGEREE_GRAVE,
	       B.ALARM_ID, B.SITE_ID, B.EQUIP_ID, B.LIAI_ID, B.ALARM_CL, 
	       B.ALARM_NUMOBJ, B.ALARM_NUMAL
 	    from ACCES_ACCESC A, ACCES_ACCESC_REP B
	    where A.ACCES_ACCESC_ID = Id and
	  	  A.ACCES_ACCESC_ID = B.ACCES_ACCESC_ID;

    CURSOR CurProg (Id NUMBER) is	/* liste des programmes concern�s par ce masquage */
	select distinct PROG_ID from PROG_usedsites, ACCES, ACCES_ACCESC		-- al. de site
	    where ACCES_ACCESC_ID = Id and
		  ACCES_ACCESC.ACCES1_ID = ACCES.ACCES_ID and
		  ACCES.SITE_ID = PROG_usedsites.SITE_ID
    	union
	select distinct PROG_ID from PROG_usedliais, ACCES, ACCES_ACCESC		-- al. de liaison
	    where ACCES_ACCESC_ID = Id and
		  ACCES_ACCESC.ACCES1_ID = ACCES.ACCES_ID and
		  ACCES.LIAI_ID = PROG_usedliais.LIAI_ID
    	union				-- al. d'�quipement c�bl�
	select distinct PROG_ID from CABLEQU_EQUIP, PROG_CABL, ACCES, ACCES_ACCESC
	    where ACCES_ACCESC_ID = Id and
		  ACCES_ACCESC.ACCES1_ID = ACCES.ACCES_ID and
		  ACCES.EQUIP_ID = CABLEQU_EQUIP.EQUIP_ID and
		  CABLEQU_EQUIP.CABLEQU_ID = PROG_CABL.CABLEQU_ID
	union				-- al. d'�quipement GSITE ou IS ou SYST ou TRAP
	select distinct PROG_ID from CABLEQU_EQUIP, PROG_CABL, ACCES_ACCESC
	    where ACCES_ACCESC_ID = Id and
		  ACCES_ACCESC.ACCES_BINDINGID = CABLEQU_EQUIP.EQUIP_ID and
		  CABLEQU_EQUIP.CABLEQU_ID = PROG_CABL.CABLEQU_ID
	union				-- al. d'�qu. de multiplexage
	select distinct PROG_ID from CABLEQU_EQUIP, LIAI_CABLEQU, PROG_usedliais, ACCES, ACCES_ACCESC
	    where ACCES_ACCESC_ID = Id and
		  ACCES_ACCESC.ACCES1_ID = ACCES.ACCES_ID and
		  ACCES.EQUIP_ID = CABLEQU_EQUIP.EQUIP_ID and
		  CABLEQU_EQUIP.CABLEQU_ID = LIAI_CABLEQU.CABLEQU_ID and
		  LIAI_CABLEQU.LIAI_ID = PROG_usedliais.LIAI_ID;
  
  /*  CURSOR CurTop (Id NUMBER) IS
    select TOP_ID from top_SITE, ACCES, ACCES_ACCESC		-- al. de site
	    where ACCES_ACCESC_ID = Id and
		  ACCES_ACCESC.ACCES1_ID = ACCES.ACCES_ID and
		  ACCES.SITE_ID = top_SITE.SITE_ID
    	union
	select TOP_ID from top_LIAITEMPU, ACCES, ACCES_ACCESC		-- al. de liaison
	    where ACCES_ACCESC_ID = Id and
		  ACCES_ACCESC.ACCES1_ID = ACCES.ACCES_ID and
		  ACCES.LIAI_ID = top_LIAITEMPU.LIAI_ID
    	union				-- al. d'�quipement c�bl�
	select TOP_ID from CABLEQU_EQUIP, top_CABLEQU, ACCES, ACCES_ACCESC
	    where ACCES_ACCESC_ID = Id and
		  ACCES_ACCESC.ACCES1_ID = ACCES.ACCES_ID and
		  ACCES.EQUIP_ID = CABLEQU_EQUIP.EQUIP_ID and
		  CABLEQU_EQUIP.CABLEQU_ID = top_CABLEQU.CABLEQU_ID
	union				-- al. d'�quipement GSITE ou IS ou SYST ou TRAP
	select TOP_ID from CABLEQU_EQUIP, top_CABLEQU, ACCES_ACCESC
	    where ACCES_ACCESC_ID = Id and
		  ACCES_ACCESC.ACCES_BINDINGID = CABLEQU_EQUIP.EQUIP_ID and
		  CABLEQU_EQUIP.CABLEQU_ID = top_CABLEQU.CABLEQU_ID
	union				-- al. d'�qu. de multiplexage
	select TOP_ID from CABLEQU_EQUIP, LIAI_CABLEQU, top_LIAITEMPU, ACCES, ACCES_ACCESC
	    where ACCES_ACCESC_ID = Id and
		  ACCES_ACCESC.ACCES1_ID = ACCES.ACCES_ID and
		  ACCES.EQUIP_ID = CABLEQU_EQUIP.EQUIP_ID and
		  CABLEQU_EQUIP.CABLEQU_ID = LIAI_CABLEQU.CABLEQU_ID and
		  LIAI_CABLEQU.LIAI_ID = top_LIAITEMPU.LIAI_ID;*/
		  
    CURSOR CurProg2 (Id NUMBER) is	/* liste des programmes � d�masquer */
	select * from PROG_MSK
	    where CABL_ID = Id and TYPE = 1;

BEGIN
    /* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
       on ne fait pas le traitement */
    if (ETAT_REPLICATION = 1) then
		return;
	end if;
	if dbms_reputil.from_remote=TRUE then
		return;
    end if;

    ToDayStr := to_char (sysdate, 'YYYY MM DD HH24:MI:SS');
    ToDaySec := CO_SEC1998 (ToDayStr);
    Debord   := 0;

    update ACCES_ACCESC
	set MSKBRI_MIN = :new.MSKBRI_MIN,
	    MSKBRI_MAX = :new.MSKBRI_MAX,
	    MSKADM_MIN = :new.MSKADM_MIN,
	    MSKADM_MAX = :new.MSKADM_MAX,
	    MSKADM_HOW = :new.MSKADM_HOW
	    where ACCES_ACCESC_ID = :new.ACCES_ACCESC2_ID;
      
     
  /*  insert into TRACETMP (trace_id, trace_mess) values (seq_trace.nextval,  ' new ACCES_ACCESC2_ID : ' ||  to_char ( :new.ACCES_ACCESC2_ID)    
    ||' new MSKBRI_MIN : ' || to_char (:new.MSKBRI_MIN) || 
    ' new MSKBRI_MAX : ' || to_char (:new.MSKBRI_MAX));*/

    :new.TRIG := 0;

    OldMask  := :old.BRI_MASQUE;
  /*  if (ToDaySec >= :new.MSKBRI_MIN) and (ToDaySec <= :new.MSKBRI_MAX) then
	NewMask := 1;
    else
	NewMask := 0;
    end if;
    
    :new.BRI_MASQUE := Newmask;*/
    Newmask := :new.BRI_MASQUE;
    
    --insert into TRACETMP (trace_id, trace_mess)
    --values (seq_trace.nextval, ' new BRI_MASQUE : ' || to_char (:new.BRI_MASQUE));


    if (Oldmask != NewMask) then
	for vAcc2 in cAcc (:new.ACCES_ACCESC2_ID) loop
	    if vAcc2.ACCES1_ID > 0 then
    	    	select SITE_ID, EQUIP_ID, LIAI_ID
		    into SiteId, EquipId, LiaiId
 		    from ACCES
		    where ACCES_ID = vAcc2.ACCES1_ID ;
						/* recherche de l'�l�ment g�r� en d�faut */
	    else
		EquipId := vAcc2.ACCES_BINDINGID;
	    end if;

	    if (OldMask = 0 and NewMask = 1) then	/* on vient de masquer l'alarme */
		for vProg in CurProg (:new.ACCES_ACCESC2_ID) loop
    		    update PROG
		    set PROG_MASQUE = 1
		    where PROG_ID = vProg.PROG_ID and
	      		  PROG_MASQUE = 0; 	-- pour respecter les masquages adm. �ventuels
		end loop;

	    if (vAcc2.ALARM_ID is not null) then	/* l'alarme �tait en cours */
		    maj_oper  (vAcc2.ALARM_ID, vAcc2.SITE_ID, vAcc2.EQUIP_ID, vAcc2.LIAI_ID,
			   1, 0, 0, ProgNb, SiteNom, Typeq, Poseq, TsPrOper, Debord);
			/* on fait retomber artificiellement cette alarme, afin de
			   calculer TsPrOper qui est utilis� pour mettre � jour
			   les "boutons programmes". On introduit le "masque" au pr�alable
			   pour que TsPrOper en tienne compte.
			   On suppose � priori que l'alarme est locale, ce qui est
			   utilis� pour conna�tre l'�tat op�rationnel du programme.
			   Cette donn�e est peut �tre inutile. A supprimer ult�rieurement !! */

		    TsPrOper2 := TsPrOper;
				/* sauvegarde de TsPrOper, repr�sentant l'�tat op�rationnel
				des programmes, ind�pendamment de l'alarme qui vient d'�tre
				masqu�e */

                    --insert into tracetmp (trace_id, trace_mess)
                    --values (seq_trace.nextval, ' before stop-alrm');

		    Stop_Alrm (Mess, vAcc2.ALARM_ID, vAcc2.ALARMGEREE_ID, vAcc2.SITE_ID,
			   vAcc2.EQUIP_ID, vAcc2.LIAI_ID, vAcc2.ALARM_CL, vAcc2.ALARM_NUMOBJ,
			   vAcc2.ALARM_NUMAL, TsPrOper);
				/* on arr�te l'alarme sur les postes clients, car
				on ne recevra plus de message de cette alarme */

		    maj_oper  (vAcc2.ALARM_ID, vAcc2.SITE_ID, vAcc2.EQUIP_ID, vAcc2.LIAI_ID,
			   1, vAcc2.ALARMGEREE_GRAVE, 0, ProgNb, SiteNom, Typeq, Poseq, TsPrOper, Debord);
			/* enfin, on calcule � nouveau l'�tat op�rationnel, avec la vraie
			   gravit� de l'alarme en cours. */

		else			/* l'alarme masqu�e n'�tait pas en cours */
                
                --insert into tracetmp (trace_id, trace_mess)
                    --values (seq_trace.nextval, ' alarme masqu�e ne �tait pas en cours');
                    
		    ProgNb   := 0;
		    TsPrOper := '';
		    Debord   := 0;
		    for vProg in CurProg (:new.ACCES_ACCESC2_ID) loop
		    	select B.PROG_OPER, PROG_MASQUE into ProgOper, ProgMsk
			    from PROG A, PROG_REP B
			    where A.PROG_ID = vProg.PROG_ID and
				  A.PROG_ID = B.PROG_ID;

		    	if ((TsPrOper is NULL or length (TsPrOper) <= 800) and Debord = 0) then
--	    	    	    ProgNb := ProgNb +1;
		    	    TsPrOper := TsPrOper || to_char (vProg.PROG_ID) || ',' || to_char (ProgOper) ||
		    	            ',' || to_char (ProgOper) || ',' || to_char (ProgMsk) || ';';
		        elsif (length (TsPrOper) > 800) then
			    Debord := 1;
			end if;
		    end loop;

--		    TsPrOper2 := to_char (ProgNb) || ';' || TsPrOper;
	    	end if;

		for vProg in CurProg (:new.ACCES_ACCESC2_ID) loop
		    insert into PROG_MSK (CABL_ID, PROG_ID, TYPE, MSK)
			values (:new.ACCES_ACCESC2_ID, vProg.PROG_ID, 1, 1);
		end loop;

	    	Mask_Alrm (Mess, ' ', 0, to_char (:new.ACCES_ACCESC2_ID), 1,
			   SiteId, EquipId, LiaiId, TsPrOper2);
					/* les clients masquent l'alarme --
					ACCES_ACCESC2_ID sert de signature pour le message */
	    end if;	/* masquage */

	    if (OldMask = 1 and NewMask = 0) then 	/* on vient de d�masquer l'alarme */
		ProgNb 	 := 0;
		TsPrOper := '';
		Debord   := 0;
		for vProg in CurProg2 (:new.ACCES_ACCESC2_ID) loop
		    update PROG
			set PROG_MASQUE = 0
			where PROG_ID = vProg.PROG_ID;

		    select B.PROG_OPER, PROG_MASQUE into ProgOper, ProgMsk
			from PROG A, PROG_REP B
			where A.PROG_ID = vProg.PROG_ID and
			      A.PROG_ID = B.PROG_ID;

		    if ((TsPrOper is NULL or length (TsPrOper) <= 800) and Debord = 0) then
--	    	    	ProgNb := ProgNb +1;
		    	TsPrOper := TsPrOper || to_char (vProg.PROG_ID) || ',' || to_char (ProgOper) ||
		    	            ',' || to_char (ProgOper) || ',' || to_char (ProgMsk) || ';';
		    elsif (length (TsPrOper) > 800) then
			Debord := 1;
		    end if;
		end loop;
--		TsPrOper := to_char (ProgNb) || ';' || TsPrOper;

		delete PROG_MSK
		    where CABL_ID = :new.ACCES_ACCESC2_ID and
			  TYPE = 1;

--insert into tracetmp (trace_id, trace_mess)
                    --values (seq_trace.nextval, ' before Mask_Alrm');
                    
	    	Mask_Alrm (Mess, ' ', 0, to_char (:new.ACCES_ACCESC2_ID), 0, SiteId, EquipId, LiaiId, TsPrOper);
						/* les clients d�masquent l'alarme */

	    	if (vAcc2.ALARM_ID is not null) then	/* l'alarme est en cours */
		    for cAl in cAlarm (vAcc2.ALARM_ID) loop
		    	Start_Alrm (cAl.ALARM_ID, cAl.ALARMGEREE_ID,
			   cAl.SITE_ID, cAl.EQUIP_ID, cAl.LIAI_ID,
 			   cAl.ALARM_NUM, cAl.ALARM_CL, cAl.ALARM_NUMOBJ, cAl.ALARM_TYPE,
			   cAl.ALARM_DATE, cAl.ALARM_GRAVE, cAl.ALARM_NSEUIL, cAl.ALARM_VSEUIL,
	               	   cAl.ALARM_NUMAL, cAl.ALARM_TEXTE, cAl.ALARM_INFO, cAl.ALARM_NOM,
			   cAl.ALARM_COMMENT, cAl.ALARM_LOCAL, cAl.ALARM_COMMUT, cAl.ALARM_IDDEB,
			   cAl.CABLAGES_ID, cAl.CABLAGEP_ID, cAl.ALARM_AQUITTEE, cAl.ALARM_IANA,
			   TsPrOper, Debord);
		    end loop;
	    	end if;

		if (ToDaySec > :new.MSKBRI_MAX) then

		    -- P�riode de masquage d�pass�e, on efface les informations de masquage
		    -- dans ACCES_ACCESC

		    update ACCES_ACCESC
			set MSKBRI_MIN = 0,
			    MSKBRI_MAX = 0
		    where ACCES_ACCESC_ID = :new.ACCES_ACCESC2_ID;
		end if;

		:new.MSKBRI_MIN := 0;
		:new.MSKBRI_MAX := 0;
	    end if;		/* d�masquage */

	end loop;
    end if;		/* changement du masquage brigadier */

    OldMask  := :old.ADM_MASQUE;
    if (ToDaySec >= :new.MSKADM_MIN) and (ToDaySec <= :new.MSKADM_MAX) then
	NewMask := 1;
    else
	NewMask := 0;
    end if;

    :new.ADM_MASQUE := Newmask;

    if (OldMask != NewMask) then
    --insert into tracetmp (trace_id, trace_mess)
                    --values (seq_trace.nextval, ' mask admin');
	for vAcc2 in cAcc (:new.ACCES_ACCESC2_ID) loop
	    if vAcc2.ACCES1_ID > 0 then
    	    	select SITE_ID, EQUIP_ID, LIAI_ID
		    into SiteId, EquipId, LiaiId
 		    from ACCES
		    where ACCES_ID = vAcc2.ACCES1_ID ;
						/* recherche de l'�l�ment g�r� en d�faut */
	    else
		EquipId := vAcc2.ACCES_BINDINGID;
	    end if;

	    if (OldMask = 0 and NewMask = 1) then	/* on vient de masquer l'alarme */
		for vProg in CurProg (:new.ACCES_ACCESC2_ID) loop
    		    update PROG
		    set PROG_MASQUE = 2
		    where PROG_ID = vProg.PROG_ID;
		end loop;

	    	if (vAcc2.ALARM_ID is not null) then	/* l'alarme �tait en cours */
		    maj_oper  (vAcc2.ALARM_ID, vAcc2.SITE_ID, vAcc2.EQUIP_ID, vAcc2.LIAI_ID,
			   1, 0, 0, ProgNb, SiteNom, Typeq, Poseq, TsPrOper, Debord);
			/* on fait retomber artificiellement cette alarme, afin de
			   calculer TsPrOper qui est utilis� pour mettre � jour
			   les "boutons programmes". On introduit le "masque" au pr�alable
			   pour que TsPrOper en tienne compte.
			   On suppose � priori que l'alarme est locale, ce qui est
			   utilis� pour conna�tre l'�tat op�rationnel du programme.
			   Cette donn�e est peut �tre inutile. A supprimer ult�rieurement !! */

		    TsPrOper2 := TsPrOper;
				/* sauvegarde de TsPrOper, repr�sentant l'�tat op�rationnel
				des programmes, ind�pendamment de l'alarme qui vient d'�tre
				masqu�e */

		    Stop_Alrm (Mess, vAcc2.ALARM_ID, vAcc2.ALARMGEREE_ID, vAcc2.SITE_ID,
			   vAcc2.EQUIP_ID, vAcc2.LIAI_ID, vAcc2.ALARM_CL, vAcc2.ALARM_NUMOBJ,
			   vAcc2.ALARM_NUMAL, TsPrOper);
				/* on arr�te l'alarme sur les postes clients, car
				on ne recevra plus de message de celle-ci */

		    maj_oper  (vAcc2.ALARM_ID, vAcc2.SITE_ID, vAcc2.EQUIP_ID, vAcc2.LIAI_ID,
			   1, vAcc2.ALARMGEREE_GRAVE, 0, ProgNb, SiteNom, Typeq, Poseq, TsPrOper, Debord);
			/* enfin, on calcule � nouveau l'�tat op�rationnel, avec la vraie
			   gravit� de l'alarme en cours. */

		    delete ALARM2 where ALARM2_ID = vAcc2.ALARM_ID;

		else			/* l'alarme masqu�e n'�tait pas en cours */
		    ProgNb   := 0;
		    TsPrOper := '';
		    Debord   := 0;
		    for vProg in CurProg (:new.ACCES_ACCESC2_ID) loop
		    	select B.PROG_OPER, PROG_MASQUE into ProgOper, ProgMsk
			    from PROG A, PROG_REP B
			    where A.PROG_ID = vProg.PROG_ID and
				  A.PROG_ID = B.PROG_ID;

		    	if ((TsPrOper is NULL or length (TsPrOper) <= 800) and Debord = 0) then
--	    	    	    ProgNb := ProgNb +1;
		    	    TsPrOper := TsPrOper || to_char (vProg.PROG_ID) || ',' || to_char (ProgOper) ||
		    	            ',' || to_char (ProgOper) || ',' || to_char (ProgMsk) || ';';
		        elsif (length (TsPrOper) > 800) then
			    Debord := 1;
			end if;
		    end loop;
--		    TsPrOper2 := to_char (ProgNb) || ';' || TsPrOper;

	    	end if;

		for vProg in CurProg (:new.ACCES_ACCESC2_ID) loop
		    insert into PROG_MSK (CABL_ID, PROG_ID, TYPE, MSK)
			values (:new.ACCES_ACCESC2_ID, vProg.PROG_ID, 1, 2);
		end loop;

	    	Mask_Alrm (Mess, ' ', 0, to_char (:new.ACCES_ACCESC2_ID), 3,
			   SiteId, EquipId, LiaiId, TsPrOper2);
				/* les clients masquent l'alarme --
				ACCES_ACCESC2_ID sert de signature pour le message */
	    end if;	/* masquage */

	    if (OldMask = 1 and NewMask = 0) then	/* on vient de d�masquer l'alarme */
            
            --insert into tracetmp (trace_id, trace_mess)
                    --values (seq_trace.nextval, ' on vient de d�masquer alarme');
                    
		ProgNb 	 := 0;
		TsPrOper := '';
		Debord   := 0;
		for vProg in CurProg2 (:new.ACCES_ACCESC2_ID) loop
		    update PROG
			set PROG_MASQUE = 0
			where PROG_ID = vProg.PROG_ID;

		    select B.PROG_OPER, PROG_MASQUE into ProgOper, ProgMsk
			from PROG A, PROG_REP B
			where A.PROG_ID = vProg.PROG_ID and
			      A.PROG_ID = B.PROG_ID;

		    if ((TsPrOper is NULL or length (TsPrOper) <= 800) and Debord = 0) then
--	    	    	ProgNb := ProgNb +1;
		    	TsPrOper := TsPrOper || to_char (vProg.PROG_ID) || ',' || to_char (ProgOper) ||
		    	            ',' || to_char (ProgOper) || ',' || to_char (ProgMsk) || ';';
		    elsif (length (TsPrOper) > 800) then
			Debord := 1;
		    end if;
		end loop;
--		TsPrOper := to_char (ProgNb) || ';' || TsPrOper;

		delete PROG_MSK
		    where CABL_ID = :new.ACCES_ACCESC2_ID and
			  TYPE = 1;

--insert into tracetmp (trace_id, trace_mess)
                    --values (seq_trace.nextval, ' les clients d�masquent alarme ');
                    
	    	Mask_Alrm (Mess, ' ', 0, to_char (:new.ACCES_ACCESC2_ID), 2, SiteId, EquipId, LiaiId, TsPrOper);
						/* les clients d�masquent l'alarme */

	    	if (vAcc2.ALARM_ID is not null) then	/* l'alarme est en cours */
		    for cAl in cAlarm (vAcc2.ALARM_ID) loop
                    
                    --insert into tracetmp (trace_id, trace_mess)
                    --values (seq_trace.nextval, ' start alarme ' || to_char(cAl.ALARM_ID));
                    
		    	Start_Alrm (cAl.ALARM_ID, cAl.ALARMGEREE_ID,
			   cAl.SITE_ID, cAl.EQUIP_ID, cAl.LIAI_ID,
 			   cAl.ALARM_NUM, cAl.ALARM_CL, cAl.ALARM_NUMOBJ, cAl.ALARM_TYPE,
			   cAl.ALARM_DATE, cAl.ALARM_GRAVE, cAl.ALARM_NSEUIL, cAl.ALARM_VSEUIL,
	               	   cAl.ALARM_NUMAL, cAl.ALARM_TEXTE, cAl.ALARM_INFO, cAl.ALARM_NOM,
			   cAl.ALARM_COMMENT, cAl.ALARM_LOCAL, cAl.ALARM_COMMUT, cAl.ALARM_IDDEB,
			   cAl.CABLAGES_ID, cAl.CABLAGEP_ID, cAl.ALARM_AQUITTEE, cAl.ALARM_IANA,
			   TsPrOper, Debord);
		    end loop;
	    	end if;

		if (ToDaySec > :new.MSKADM_MAX) then

		    -- P�riode de masquage d�pass�e, on efface les informations de masquage
		    -- dans ACCES_ACCESC

		    update ACCES_ACCESC
			set MSKADM_MIN = 0,
			    MSKADM_MAX = 0
		    where ACCES_ACCESC_ID = :new.ACCES_ACCESC2_ID;
		end if;

		:new.MSKADM_MIN := 0;
		:new.MSKADM_MAX := 0;
	    end if;		/* d�masquage */

	end loop;
    end if;		/* changement du masquage Adm */

END	tub_acces_accesc2;
/


-- ======= Fin de ACCES_ACCESC ========================================================


--=====================================================================================
-- MaskModified
-- Cr�ation JPB le 09/06/2000
--
-- Cette proc�dure est lanc�e r�guli�rement (10 s.) par le process "FinAlarm"
-- (jouant le r�le de CRON sur EmessAlrm2).
-- Elle d�tecte si l'�tat d'un masquage a chang� et si oui, effectue les traitements
-- convenables (� la fois pour les alarmes boucles et s�rie).
--
--=====================================================================================

create or replace
PROCEDURE MaskModified
IS
    ToDayStr	VARCHAR2 (20);	/* date et heure actuelle au format YYYY MM DD HH24:MI:SS */
    ToDaySec	NUMBER;		/* idem en nombre de secondes depuis le 01/01/1998 00:00:00 */
    OldMask	NUMBER;		/* 1 si l'alarme �tait masqu�e avant le changement, 0 sinon  */
    NewMask	NUMBER;		/* 1 si l'alarme devient masqu�e apr�s le changement, 0 sinon */
    Modified	BOOLEAN;	/* TRUE si la base a �t� modifi�e */

    CURSOR CBri is			/* masquages demand�s */
	select ACCES_ACCESC2_ID, MSKBRI_MIN, MSKBRI_MAX, BRI_MASQUE
	    from ACCES_ACCESC2
	    where MSKBRI_MIN > 0;

    CURSOR CAdm is			/* masquages demand�s */
	select ACCES_ACCESC2_ID, MSKADM_MIN, MSKADM_MAX, ADM_MASQUE
	    from ACCES_ACCESC2
	    where MSKADM_MIN > 0;

  /*  CURSOR CSBri is			
	select BITMESS2_ID, MSKBRI_MIN, MSKBRI_MAX, BRI_MASQUE
	    from BITMESS2
	    where MSKBRI_MIN > 0;

    CURSOR CSAdm is			
	select BITMESS2_ID, MSKADM_MIN, MSKADM_MAX, ADM_MASQUE
	    from BITMESS2
	    where MSKADM_MIN > 0;*/

BEGIN

    ToDayStr := to_char (sysdate, 'YYYY MM DD HH24:MI:SS');
    ToDaySec := CO_SEC1998 (ToDayStr);
    Modified := FALSE;

    for vBri in CBri loop
	OldMask := vBri.BRI_MASQUE;
	if (ToDaySec >= vBri.MSKBRI_MIN) and (ToDaySec <= vBri.MSKBRI_MAX) then
	    NewMask := 1;
	else
	    NewMask := 0;
	end if;

	if (OldMask != Newmask) then
	  /*  update ACCES_ACCESC2
		set TRIG = 1
		where ACCES_ACCESC2_ID = vBri.ACCES_ACCESC2_ID;*/
                update ACCES_ACCESC2
		set BRI_MASQUE = NewMask
		where ACCES_ACCESC2_ID = vBri.ACCES_ACCESC2_ID;
	    Modified := TRUE;
	end if;
    end loop;

    for vAdm in CAdm loop
	OldMask := vAdm.ADM_MASQUE;
	if (ToDaySec >= vAdm.MSKADM_MIN) and (ToDaySec <= vAdm.MSKADM_MAX) then
	    NewMask := 1;
	else
	    NewMask := 0;
	end if;

	if (OldMask != Newmask) then
	   /* update ACCES_ACCESC2
		set TRIG = 1
		where ACCES_ACCESC2_ID = vAdm.ACCES_ACCESC2_ID;*/
                update ACCES_ACCESC2
		set ADM_MASQUE = NewMask
		where ACCES_ACCESC2_ID = vAdm.ACCES_ACCESC2_ID;
	    Modified := TRUE;
	end if;
    end loop;

 /*   for vSBri in CSBri loop
	OldMask := vSBri.BRI_MASQUE;
	if (ToDaySec >= vSBri.MSKBRI_MIN) and (ToDaySec <= vSBri.MSKBRI_MAX) then
	    NewMask := 1;
	else
	    NewMask := 0;
	end if;

	if (OldMask != Newmask) then
	    update BITMESS2
		set TRIG = 1
		where BITMESS2_ID = vSBri.BITMESS2_ID;
	    Modified := TRUE;
	end if;
    end loop;

    for vSAdm in CSAdm loop
	OldMask := vSAdm.ADM_MASQUE;
	if (ToDaySec >= vSAdm.MSKADM_MIN) and (ToDaySec <= vSAdm.MSKADM_MAX) then
	    NewMask := 1;
	else
	    NewMask := 0;
	end if;

	if (OldMask != Newmask) then
	    update BITMESS2
		set TRIG = 1
		where BITMESS2_ID = vSAdm.BITMESS2_ID;
	    Modified := TRUE;
	end if;
    end loop;*/

    if (Modified) then
	commit;
    end if;

END MaskModified;
/

--=====================================================================================
-- WatchDog
-- Cr�ation JPB le 14/06/2000
--
-- Cette proc�dure est lanc�e r�guli�rement (60 s.) par le process "FinAlarm"
-- (jouant le r�le de CRON sur EmessAlrm2).
-- Elle d�tecte le fonctionnement de l'�quipement de m�diation, du client GSITE et des
-- autres services activ�s sur l'EM, en testant la table TESTEM qui doit �tre mise � 
-- jour par ces services au moins une fois par minute.
-- En cas de probl�me, provoque une alarme syst�me.
--
-- Modif. X.L. le 19/11/03 pour prendre en compte le fait que plusieurs �quipements
-- de m�diation peuvent coexister. La modification porte sur l'insertion dans la
-- colonne ALARM_NUMAL, o� on concat�ne le nom r�seau de l'EM et le nom du service
-- tel que : Nom r�seau/Nom service.
--
-- Modif. X.L. le 26/02/04 la clause where de l'update sur testem est compl�t�e
-- avec le nom de l'�quipement de m�diation. Aurait d� �tre fait le 19/11/03.
--
-- Modif. X.L. le 28/10/05 pour introduire la recherche de la gravit� dans le
-- cas d'une alarme "licence nombre d'objet max. d�pass�" (testem_id = 10).
--
-- Modif JPB le 08/05/06 : Internationalisation
--
--=====================================================================================
CREATE OR REPLACE PROCEDURE WatchDog
IS
    ToDayStr	VARCHAR2 (20);	/* date et heure actuelle au format YYYY MM DD HH24:MI:SS */
    ToDaySec	NUMBER;		/* idem en nombre de secondes depuis le 01/01/1998 00:00:00 */
    Modified	BOOLEAN;	/* TRUE si la base a �t� modifi�e */

    CURSOR CTst is			/* table TESTEM */
	select *
	    from TESTEM;

    CURSOR CGrave (NomPC TESTEM.TESTEM_EMNOM%TYPE, NomService TESTEM.TESTEM_NOM%TYPE) is
	select ALARMGEREE_GRAVE
	from ACCES_ACCESC, EQUIP
	where SITE_EQUIP_COMMENT = NomPC || '/' || NomService
	and EQUIP.EQUIP_INDEXSNMP = 10
	and EQUIP.TYPEQ_ID = 3
	and ACCES_BINDINGID = EQUIP.EQUIP_ID;

    nGrave	NUMBER;

BEGIN

    ToDayStr := to_char (sysdate, 'YYYY MM DD HH24:MI:SS');
    ToDaySec := CO_SEC1998 (ToDayStr);
    Modified := FALSE;
    nGrave := 7;

    for vTst in CTst loop
/*
dbms_output.put_line ('ToDay '||ToDayStr||' CoSec '||
to_char (vTst.TESTEM_DATE, 'YYYY MM DD HH24:MI:SS')||' etat '||to_char(vTst.testem_etat));
*/
	if (ToDaySec > CO_SEC1998 (to_char (vTst.TESTEM_DATE, 'YYYY MM DD HH24:MI:SS')) +70
		and vTst.TESTEM_ETAT = 0) then

	    if (vTst.TESTEM_ID = 10) then	-- Alarme serveur pour nb objet d�pass�
		-- On va charcher la gravit� dans la table ACCES_ACCESC car celle-ci
		-- a �t� modifi�e par EmessAlrm2NT en fonction du pourcentage de d�passement

		for rCGrave in cGrave (vTst.TESTEM_EMNOM, vTst.TESTEM_NOM) loop
			nGrave := rCGrave.ALARMGEREE_GRAVE;
			exit;
		end loop;
	    end if;

	    insert into ALARM (ALARM_ID, ALARM_NUM, ALARM_CL, ALARM_NUMOBJ, ALARM_DATE,
				ALARM_GRAVE, ALARM_NUMAL, ALARM_COMMUT, ALARM_TEXTE)
		values (SEQ_ALARM.NEXTVAL, SEQ_ALARM.CURRVAL, 'SYST', vTst.TESTEM_ID,
			ToDayStr, nGrave, vTst.TESTEM_EMNOM || '/' || vTst.TESTEM_NOM, 0, 3);

	    update TESTEM 
		set TESTEM_ETAT = 1
		where TESTEM_ID = vTst.TESTEM_ID and TESTEM_EMNOM = vTst.TESTEM_EMNOM;

	    Modified := TRUE;
	end if;		/* d�but de panne */

	if (ToDaySec <= CO_SEC1998 (to_char (vTst.TESTEM_DATE, 'YYYY MM DD HH24:MI:SS')) +70
		and vTst.TESTEM_ETAT = 1) then
	    insert into ALARM (ALARM_ID, ALARM_NUM, ALARM_CL, ALARM_NUMOBJ, ALARM_DATE,
				ALARM_GRAVE, ALARM_NUMAL, ALARM_COMMUT, ALARM_TEXTE)
		values (SEQ_ALARM.NEXTVAL, SEQ_ALARM.CURRVAL, 'SYST', vTst.TESTEM_ID,
			ToDayStr, 0, vTst.TESTEM_EMNOM || '/' || vTst.TESTEM_NOM, 0, 3);
	    update TESTEM 
		set TESTEM_ETAT = 0
		where TESTEM_ID = vTst.TESTEM_ID and TESTEM_EMNOM = vTst.TESTEM_EMNOM;

	    Modified := TRUE;
	end if;		/* fin de panne */
    end loop;

    if (Modified) then
	commit;
    end if;

END WatchDog;
/


--=====================================================================================
-- SayIRun
-- Cr�ation JPB le 30/06/2000
--
-- Cette proc�dure permet de mettre � jour r�guli�rement TESTEM, afin de dire
-- que le service fonctionne bien.
-- On lui passe en param�tre le n� de la ligne correspondante dans TESTEM
--
-- Modif. X.L. le 19/11/03 pour tenir compte du fait que plusieurs �quipements de
-- m�diation peuvent coexister
--
--=====================================================================================

CREATE OR REPLACE PROCEDURE SayIRun (Num  NUMBER, EmName VARCHAR2)
IS
    ToDayStr	VARCHAR2 (20);	/* date et heure actuelle au format YYYY MM DD HH24:MI:SS */
    ToDaySec	NUMBER;		/* idem en nombre de secondes depuis le 01/01/1998 00:00:00 */
    NbLine	NUMBER;		/* Nombre de lignes dans testem r�pondant � ce nom de service */
    PrgName	TESTEM.TESTEM_NOM%type;	/* Nom du programme */

BEGIN

    select to_char (sysdate, 'YYYY MM DD HH24:MI:SS')
	into ToDayStr
	from DUAL;

    ToDaySec := CO_SEC1998 (ToDayStr);

/*
    select count(*) into NbLine from TESTEM where TESTEM_ID = Num and TESTEM_EMNOM = EmName;

    if (NbLine = 0) then	-- la ligne n'est pas cr��e dans TESTEM, on le fait
	PrgName := 'UNKNOWN';
	if (Num = 1) then
	    PrgName := 'Client GSite';
	elsif (Num = 2) then
	    PrgName := 'GIS';
	elsif (Num = 3) then
	    PrgName := 'Service TRAP SNMP';
	elsif (Num = 4) then
	    PrgName := 'Service ICMP';
	elsif (Num = 5) then
	    PrgName := 'Service MAIL';
	elsif (Num = 6) then
	    PrgName := 'Service POLLING';
	elsif (Num = 7) then
	    PrgName := 'Emess EM';
	elsif (Num = 8) then
	    PrgName := 'Service XNA';
	end if;
	    
	insert into 
	    TESTEM (TESTEM_ID, TESTEM_CLASSID, TESTEM_NOM, TESTEM_DATE, TESTEM_NSEC, TESTEM_ETAT, TESTEM_EMNOM)
	values (Num, 2038, PrgName, sysdate, ToDaySec, 0, EmName);
    else
*/
    	update TESTEM
	    set TESTEM_DATE = sysdate,
	        TESTEM_NSEC = ToDaySec
	    where TESTEM_ID = Num and TESTEM_EMNOM = EmName;
--    end if;

    commit;
END	SayIRun;
/



--=====================================================================================
-- SayIRunEmessEM
-- Cr�ation XL le 29/08/2005
--
-- Cette proc�dure remplit le m�me r�le que SayIRun pour les autres services,
-- elle est appel�e par EmessEM. Le dernier param�tre permet de mettre � jour
-- le compteur des alarmes rejet�es par EmessEM
--
--=====================================================================================

CREATE OR REPLACE PROCEDURE SayIRunEmessEM (Num  NUMBER, EmName VARCHAR2, NbRejectedAl NUMBER)
IS
    ToDayStr	VARCHAR2 (20);	/* date et heure actuelle au format YYYY MM DD HH24:MI:SS */
    ToDaySec	NUMBER;		/* idem en nombre de secondes depuis le 01/01/1998 00:00:00 */
    NbLine	NUMBER;		/* Nombre de lignes dans testem r�pondant � ce nom de service */
    PrgName	TESTEM.TESTEM_NOM%type;	/* Nom du programme */

BEGIN

    select to_char (sysdate, 'YYYY MM DD HH24:MI:SS')
	into ToDayStr
	from DUAL;

    ToDaySec := CO_SEC1998 (ToDayStr);

    update TESTEM
	set TESTEM_DATE = sysdate,
	TESTEM_NSEC = ToDaySec,
	TESTEM_CURRENTREJECTEDAL = NbRejectedAl
	    where TESTEM_ID = Num and TESTEM_EMNOM = EmName;

    commit;
END	SayIRunEmessEM;
/


--=====================================================================================
-- Trigger sur alarmgeree :
-- Cr�ation X.L. le 28/04/99
-- 
-- Objet : D�tecter la modification d'une temporisation d'alarme afin d'en aviser
-- l'�quipement de m�diation pour qu'il mette � jour en cons�quence les IS concern�es.
--
-- Modif. X.L. 19/07/99 pour remplacer les alertes ORACLE par un envoi de message par
-- socket TCP/IP, ceci par l'interm�daire d'un insert dans la table MESSALARM et du process
-- serveur EmessAlrm2.
--
-- Modif. X.L. le 21/10/99 afin que si une mise � jour de gravit� ou de tempo ou de
-- sonnerie ou d'acquittement est faite, la mise � jour soit report�e sur suivant le cas
-- ACCES_ACCESC ou BITMESS pour les acc�s c�bl�s. La mise � jour n'est faite que pour les
-- enregistrements dont la valeur est �gale � l'ancienne de l'alarme.
--
-- 18/09/03 : JPB : Modification du message MESSALRM, pour introduire le nb. de # envoy�s
--
-- 19/02/04 : X.L. : Modification pour prise en compte de la nouvelle case � cocher
-- de l'alarme g�r�e (� surveiller), ainsi que alarmgeree_freqn et alarmgeree_freqd,
-- ainsi que alarmgeree_toaff (� afficher sur console)
--
-- 12/11/04 : X.L. : Modification pour prise en compte des seuils haut et bas.
--
-- 06/10/06 : X.L. : � la demande de G.G. (GlobeCast), ne plus propager les modifications
-- faite sur l'alarme g�r�e vers les �quipements du type (sauf pour la fr�quence de l'alarme
-- qui n'est pas modifiable autrement et ce qui concerne les alarmes de site et de liaison)
--=====================================================================================
create or replace
TRIGGER tu_alarmgeree AFTER UPDATE ON alarmgeree FOR EACH ROW

DECLARE
	Mess	VARCHAR2 (1800);
	MessId  integer;
	FreqN	alarmgeree.alarmgeree_freqn%TYPE;
	FreqD	alarmgeree.alarmgeree_freqd%TYPE;

	-- Curseurs pour d�tecter si l'alarme est c�bl�e ou non (le message vers IS n'est envoy�
	-- que si l'alarme est c�bl�e).
	CURSOR C1 IS		-- Pour GTR de site ou de liaison
		SELECT A.acces_accesc_id, B.alarmgeree_grave, alarmgeree_min, alarmgeree_son,
			alarmgeree_acq, alarmgeree_tosurv, alarmgeree_toaff,
			alarmgeree_freqn, alarmgeree_freqd, acces.equip_id
		FROM acces_accesc A, acces_accesc_rep B, acces
		WHERE alarmgeree_id   = :new.alarmgeree_id
		AND acces.acces_id    = A.acces1_id
		AND acces.equip_id IS NULL
		AND A.acces_accesc_id = B.acces_accesc_id;

/*	CURSOR C2 IS		-- Pour SEM
		SELECT acces2_id FROM bitmess, acces_accesc
		WHERE bitmess.alarmgeree_id = :new.alarmgeree_id
		AND acces2_id = acces_id;
*/
	-- Curseurs pour mise � jour de acces_accesc et bitmess

	CURSOR C3 IS		-- Pour GTR et TRAP SNMP
		SELECT A.acces_accesc_id, alarmgeree_freqn, alarmgeree_freqd
		FROM acces_accesc A, acces_accesc_rep B
		WHERE alarmgeree_id    = :new.alarmgeree_id
		AND A.acces_accesc_id  = B.acces_accesc_id
		AND (alarmgeree_freqn  = :old.alarmgeree_freqn OR
		     alarmgeree_freqd  = :old.alarmgeree_freqd)	-- pour TRAP seulement
		FOR UPDATE OF alarmgeree_id NOWAIT;

BEGIN
	/* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
	   on ne fait pas le traitement */
	if dbms_reputil.from_remote=TRUE then
		return;
	end if;

	FOR rC1 IN C1 LOOP	-- Traitement des GTR de site ou de liaison

		-- Si l'acc�s n'est pas un acc�s d'�quipement (donc un acc�s de site
		-- ou de liaison), on met � jour acces_accesc � partir de l'alarme
		-- g�r�e m�me si les anciennes valeurs de l'alarme g�r�e ne sont pas
		-- identiques � celles de acces_accesc.

                /* cette propagation de la mise � jour est g�r�e
                   dans SMT au niveau de l'application cliente
		UPDATE acces_accesc
		SET alarmgeree_grave = :new.alarmgeree_grave,
		    alarmgeree_min = :new.alarmgeree_min,
		    alarmgeree_son = :new.alarmgeree_son,
		    alarmgeree_acq = :new.alarmgeree_acq,
		    alarmgeree_tosurv = :new.alarmgeree_tosurv,
		    alarmgeree_toaff = :new.alarmgeree_toaff,
		    alarmgeree_freqn = :new.alarmgeree_freqn,
		    alarmgeree_freqd = :new.alarmgeree_freqd
		WHERE acces_accesc_id = rc1.acces_accesc_id;
                */
                
		IF :new.alarmgeree_min != :old.alarmgeree_min THEN	-- Modif. de temporisation

			-- Message � destination de l'IS

			select SEQ_MESSALRM.NEXTVAL into MessId from dual;
			Mess := '6#';				-- Code du message
			Mess := CONCAT (Mess, '8#');		-- Nb. de #
			Mess := CONCAT (Mess, '0#');		/* Alarm_Id */
    			Mess := CONCAT (Mess, MessId);
			Mess := CONCAT (Mess, '#'); /* stockage dans MESSALRM */
		    	Mess := CONCAT (Mess, '0#');		/* Alarmgeree_Id */
		    	Mess := CONCAT (Mess, '0#');		/* BindingId */
		   	Mess := CONCAT (Mess, '0#');		/* BindingTyp */
			Mess := Mess || '9G' || TO_CHAR (:new.alarmgeree_id) || '/#';

--insert into test values(seq_test.nextval, 'tu_alarmgeree' || Mess);

		        insert into MESSALRM (MESSALRM_ID, MESSALRM_MESS, MESSALRM_SENT, MESSALRM_NATURE)
	    	        values (MessId, Mess, 0, 0);

		END IF;
		EXIT;
	END LOOP;



	-- Pour l'alarme fr�quente, on ne peut modifier que globalement au niveau
	-- de l'alarme g�r�e, donc cela doit suivre pour les �quipements.
        /* cette propagation de la mise � jour est g�r�e
           dans SMT au niveau de l'application cliente
	IF :new.alarmgeree_freqn != :old.alarmgeree_freqn OR
	   :new.alarmgeree_freqd != :old.alarmgeree_freqd THEN

		FOR rc3 in C3 LOOP

			UPDATE acces_accesc
			SET alarmgeree_freqn = :new.alarmgeree_freqn,
			    alarmgeree_freqd = :new.alarmgeree_freqd
			WHERE acces_accesc_id = rc3.acces_accesc_id;
		END LOOP;

	END IF;
        */

END tu_alarmgeree;
/



--======= Fin de ALARMGEREE ====================================================================


/*

--     PROG_LIAITEMP   -----------------------------------------------------

create or replace trigger tib_prog_liaitemp before insert on PROG_LIAITEMP for each row
begin
	
	if dbms_reputil.from_remote=TRUE then
		return;
	end if;
	
	select SEQ_PROG_LIAITEMP.nextval into :new.PROG_LIAITEMP_ID from DUAL;
end tib_prog_liaitemp;
*/

--     FIN PROG_LIAITEMP   -----------------------------------------------------


--     PROG_MSK   -----------------------------------------------------

create or replace trigger tib_prog_msk before insert on PROG_MSK for each row
begin
	/* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
	   on ne fait pas le traitement */
	if dbms_reputil.from_remote=TRUE then
		return;
	end if;

	select SEQ_PROG_MSK.nextval into :new.PROG_MSK_ID from DUAL;
end tib_prog_msk;
/

--     FIN PROG_MSK   -----------------------------------------------------


--    TYPEQ  -------------------------------------------------
--
-- X.L. le 19/07/00
--
-- Modif. X.L. le 18/12/00 pour qu'on ne puisse pas r�duire le nombre de slots d'un type
-- d'�quipement en de�a des slots occup�s par les sous �quipements du type.
--
-- Modifi� JPB le 30/01/01 : pour tenir compte de l'introduction du champ TYPEQ_NOM dans EQUIP
--
-- Modifi� par X.L. le 20/04/01 : afin de contr�ler qu'il n'existe pas d'�quipements du type
-- lorsqu'on modifie la colonne TYPEQ_NBSLOTOCC et qu'il n'existe pas d'�quipements support�s
-- par un �quipement de ce type lorsqu'on modifie les colonnes TYPEQ_PREMSLOT et TYPEQ_NBCXION
-- ceci pour un type d'�quipement.
--
-- Modifi� par X.L. le 09/09/04 : lorsqu'une erreur diff�rente de -20002 se produisait, elle
-- n'�tait pas retransmise. D'o� l'init. de errno � 0 en t�te de fonction et le test de errno
-- � 0 dans le traitement des exceptions.
--
-- Modifi� par X.L. le 13/01/05 : construction d'un message dans MESSEM lorsque TYPEQ_TOSURV
-- est modifi�.
--
create or replace
trigger tub_typeq before update on TYPEQ for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    nNoCxion	     integer;
    nMax	     integer;
    nNbEquip	     integer;
    nCarte	     integer;

    CURSOR c1 is
	select TYPEQ_NOM from EQUIP
	    where TYPEQ_ID = :new.TYPEQ_ID
	    for update of TYPEQ_NOM nowait;

   -- Curseur pour v�rifier qu'il n'existe pas d'�quipement inclus dans un �quipement du type
   -- en cours
   CURSOR cOcc is
	select EQUIP_ID from EQUIP
	   where TYPEQ_BINDINGID = :new.TYPEQ_ID;

   -- Curseur pour v�rifier qu'il n'existe pas d'�quipement du type
   CURSOR cEq is
	select EQUIP_ID from EQUIP
	   where TYPEQ_ID = :new.TYPEQ_ID;

   CURSOR cSupte is
	select decode (rtrim (translate (BAIE_EQUIP_CARTE, '1234567890', ' ')),
	      		                 NULL, BAIE_EQUIP_CARTE) carte
	from EQUIP
	where TYPEQ_BINDINGID = :new.TYPEQ_ID;

begin
    errno := 0;

	/* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
	   on ne fait pas le traitement */
	if dbms_reputil.from_remote=TRUE then
		return;
	end if;

    if (:new.TYPEQ_NOM != :old.TYPEQ_NOM) then
    	for rc1 in c1 loop
    	    update EQUIP
	        set TYPEQ_NOM = :new.TYPEQ_NOM
	    	where current of c1;
    	end loop;
    end if;

	if (:new.TYPEQ_NBCXION < :old.TYPEQ_NBCXION) then
		/*if (:new.TYPEQ_CLASSID = 1041) then	-- type de r�glette
			-- On ne doit pas pouvoir diminuer le nombre de connexions
			-- du type de r�glette en de�a des connexions effectivement c�bl�es
			nNoCxion := 0;
			select max (REGL_ACCES_NOCXION) into nNoCxion
			from REGLETTE_ACCES, REGLETTE
			where TYPEQ_ID = :new.TYPEQ_ID
			and REGLETTE_ACCES.REGL_ID = REGLETTE.REGL_ID;

			if (nNoCxion > :new.TYPEQ_NBCXION) then
		      	    errno  := -20002;
			    errmsg := 
				'Une r�glette est c�bl�e sur l''une des connexions supprim�es';
			    raise integrity_error;
			end if;
		elsif*/
                if(:new.TYPEQ_CLASSID = 1024 and :new.TYPEQ_VERFSLOT > 0) then
			-- Type d'�quipement avec affectation des slots contr�l�e
			-- On ne doit pas pouvoir diminuer le nombre de slots
			-- en de�a de ceux occup�s par les sous �quipements du type
			nMax := 0;
			for rcSupte in cSupte loop
				if (rcSupte.carte is not null) then -- purement num�rique
					nCarte := to_number (rcSupte.carte);
					if (nCarte > nMax) then
						nMax := nCarte;
					end if;
				end if;
			end loop;

			if (nMax > :new.TYPEQ_NBCXION + :old.TYPEQ_PREMSLOT - 1) then
				errno := -20002;
				errmsg := 'Un �quipement exploite un des slots supprim�s';
				raise integrity_error;
			end if;
		end if;
	end if;

	-- Type d'�quipement dont on a modifi� le num�ro du premier slot ou le nombre de
	-- slots qu'il occupe
        if (:new.TYPEQ_CLASSID = 1024) then

		if (:new.TYPEQ_PREMSLOT != :old.TYPEQ_PREMSLOT
		and :new.TYPEQ_VERFSLOT > 0) then
			for rcOcc in cOcc loop
			   errno := -20002;
			   errmsg := 'Il existe des �quipements de ce type int�grant d''autres �quipements. Modification interdite du num�ro de premier slot';
			   -- Ne pas mettre la ligne ci-dessus sur 2 lignes, sinon on ne pourra pas l'extraire.
			   raise integrity_error;
			end loop;
		end if;

		if (:new.TYPEQ_NBSLOTOCC != :old.TYPEQ_NBSLOTOCC) then
			for rcEq in cEq loop
			   errno := -20002;
			   errmsg := 'Il existe des �quipements de ce type. Modification du
				      nombre de slots interdite';
			   raise integrity_error;
			end loop;
		end if;
	end if;

	-- Type d'�quipement dont TYPEQ_TOSURV a �t� modifi�
	if (:new.TYPEQ_TOSURV != :old.TYPEQ_TOSURV) then
		insert into MESSEM (MESSEM_ID, MESSEM_DATE, MESSEM_MESS)
		values (SEQ_MESSEM.NEXTVAL, sysdate, '#9#7#7#M#' || to_char (:NEW.TYPEQ_ID) || '#' ||
			to_char (:new.TYPEQ_TOSURV) || '#');
	end if;
--  gestion des erreurs
exception
--    when integrity_error then
    when others then
       if (errno = 0) then
           errno := SQLCODE;
           errmsg := SQLERRM (errno);
       end if;
       raise_application_error(errno, errmsg);
end	tub_typeq;
/


-- X.L. Cr�ation le 13/01/05
-- JPB  Modif le 11/03/05 : appel dbms_reputil

create or replace trigger tdb_typeq before delete on TYPEQ for each row
begin

  DELETE MANAGER_OBJ WHERE TYPEQ_ID = :old.TYPEQ_ID;
  
	/* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
	   on ne fait pas le traitement */
	if dbms_reputil.from_remote=TRUE then
		return;
	end if;

	insert into MESSEM (MESSEM_ID, MESSEM_DATE, MESSEM_MESS)
	    values (SEQ_MESSEM.NEXTVAL, sysdate, '#9#6#7#S#' || to_char (:OLD.TYPEQ_ID) || '#');
	    
	delete TypeqIpTrouve where typeq_id=:OLD.TYPEQ_ID;
	
end	tdb_typeq;
/

--    FIN DE TYPEQ   ------------------------------------------





/*
*	Fonctions diverses utilis�es pour l'�change d'informations entre applications
*	JPB : 2002
*/

--
--	Fonction identique � CRichString::GetNextSubString
--	Elle extrait du string Str un substring � partir de Pos (1 au d�part, automatique apr�s)
--	Les sous-cha�nes sont s�par�es par le caract�re Separ.
--	La cha�ne peut, ou non, se terminer par Separ.
--	Retourne NULL � la fin.
--
CREATE OR REPLACE FUNCTION GetNextSubString 
(
    Str IN VARCHAR2, 
    Pos IN OUT NUMBER, 
    Separ IN VARCHAR2
)
RETURN VARCHAR2
IS
    i	NUMBER;		-- Position trouv�e pour le s�parateur
    Res	VARCHAR2 (128);	-- R�sultat � retourner

BEGIN
    i := INSTR (Str, Separ, Pos);
    if (i = 0) then
	i := LENGTH (Str) +1;
    end if;

    if (i > Pos) then
    	Res := SUBSTR (Str, Pos, i - Pos);
	Pos := i +1;
    else
	Res := NULL;
    end if;

    Res := LTRIM (Res);
    Res := RTRIM (Res);	-- On enl�ve les blancs de t�te et de queue
    return (Res);
END	GetNextSubString;
/


--
--	Cette Fonction v�rifie que le string d�sign� est vide
--

CREATE OR REPLACE FUNCTION IsNull (Str IN VARCHAR2)
RETURN BOOLEAN
IS
    
BEGIN
    if (Str is NULL) then
    	return TRUE;
    else
	return FALSE;
    end if;

END	IsNull;
/


--
--	Cette Fonction v�rifie que l'objet d�sign� existe (return TRUE).
--	TblNom	: 	nom de la table (classe de l'obj.)
--	ObjNom :	nom de l'objet  (instance de l'obj.)
--

CREATE OR REPLACE FUNCTION ExistObj (TblNom IN VARCHAR2, ObjNom IN VARCHAR2)
RETURN BOOLEAN
IS
    Trouve	BOOLEAN;	-- True si l'objet existe en BDD

    CURSOR CProg IS
	select * from PROG
	    where PROG_NOM = ObjNom;

    CURSOR CFamille IS
	select * from FAMILLE
	    where FAMILLE_NOM = ObjNom;

    CURSOR CTypProg IS
	select * from TYPPROG
	    where TYPPROG_NOM = ObjNom;

 /*   CURSOR CTop IS
	select * from TOP
	    where TOP_NOM = ObjNom;*/

BEGIN

    Trouve := FALSE;

    if (TblNom = 'PROG') then
	for vP in CProg loop
	    Trouve := TRUE;
	end loop;

    elsif (TblNom = 'FAMILLE') then
	for vP in CFamille loop
	    Trouve := TRUE;
	end loop;

    elsif (TblNom = 'TYPPROG') then
	for vP in CTypProg loop
	    Trouve := TRUE;
	end loop;

/*    elsif (TblNom = 'TOP') then
	for vP in CTop loop
	    Trouve := TRUE;
	end loop;*/

    else
	return FALSE;
    end if;

    return Trouve;

END	ExistObj;
/


--
--	Cette Fonction v�rifie que le string ObjNom est vide ou que l'objet d�sign� existe.
--	TblNom	: 	nom de la table (classe de l'obj.)
--	ObjNom :	string ou nom de l'objet  (instance de l'obj.)
--

CREATE OR REPLACE FUNCTION IsNullOrExistObj (TblNom IN VARCHAR2, ObjNom IN VARCHAR2)
RETURN BOOLEAN
IS
    
BEGIN

    if (ObjNom is NULL) then
    	return TRUE;
    else
	return (ExistObj (TblNom, ObjNom));
    end if;

END	IsNullOrExistObj;
/


--
--	Cette Fonction v�rifie que le string ObjNom est vide ou que l'objet d�sign� n'existe pas.
--	TblNom	: 	nom de la table (classe de l'obj.)
--	ObjNom :	string ou nom de l'objet  (instance de l'obj.)
--

CREATE OR REPLACE FUNCTION IsNullOrNotExistObj (TblNom IN VARCHAR2, ObjNom IN VARCHAR2)
RETURN BOOLEAN
IS
    
BEGIN

    if (ObjNom is NULL) then
    	return TRUE;
    else
	return (not ExistObj (TblNom, ObjNom));
    end if;

END	IsNullOrNotExistObj;
/


--
--	Cette Fonction v�rifie que le string ObjNom est vide ou vaut 'NULL'
--	ou que l'objet d�sign� existe.
--	TblNom	: 	nom de la table (classe de l'obj.)
--	ObjNom :	string ou nom de l'objet  (instance de l'obj.)
--

CREATE OR REPLACE FUNCTION IsNullOrSupprOrExistObj (TblNom IN VARCHAR2, ObjNom IN VARCHAR2)
RETURN BOOLEAN
IS
    
BEGIN

    if (ObjNom is NULL) then
    	return TRUE;
    elsif (ObjNom = 'NULL') then
	return TRUE;
    else
	return (ExistObj (TblNom, ObjNom));
    end if;

END	IsNullOrSupprOrExistObj;
/


--
--	Cette Fonction v�rifie que la famille ObjNom est vide ou existe.
--	Elle v�rifie aussi que les familles ne forment pas une boucle
--	ObjNom :  nom de la famille, � raccrocher � la famille FamNom
--

CREATE OR REPLACE FUNCTION IsNullOrExistFam (ObjNom IN VARCHAR2, FamNom IN VARCHAR2)
RETURN BOOLEAN
IS
    ObjId	  NUMBER; 	-- Id de la famille � accrocher
    FamId	  NUMBER;	-- Id de la famille d'accroche

    CURSOR CFam is
	select FAMILLE_ID from FAMILLE
	    where FAMILLE_NOM = ObjNom;

BEGIN

    if (FamNom is NULL) then
    	return TRUE;
    end if;
    if (not ExistObj ('FAMILLE', FamNom)) then
	return FALSE;
    end if;

    ObjId := NULL;
    for vFam in CFam loop
	ObjId := vFam.FAMILLE_ID;
    end loop;

    if (ObjId is NULL) then
	return TRUE;		-- Cr�ation
    end if;
        
    select FAMILLE_ID into FamId from FAMILLE
	where FAMILLE_NOM = FamNom;

    loop
	if (FamId = ObjId) then
	    return FALSE;
	end if;

	select FAMILLE_BINDINGID into FamId from FAMILLE
	    where FAMILLE_ID = FamId;

	if (FamId is NULL) then
	    return TRUE;
	end if;
    end loop;

EXCEPTION
    when OTHERS then
	return FALSE;

END	IsNullOrExistFam;
/


CREATE OR REPLACE FUNCTION IsNullOrSupprOrExistFam (ObjNom IN VARCHAR2, FamNom IN VARCHAR2)
RETURN BOOLEAN
IS

BEGIN

    if (FamNom = 'NULL') then
    	return TRUE;
    else
	return (IsNullOrExistFam (ObjNom, FamNom));
    end if;

END	IsNullOrSupprOrExistFam;
/




--================================================================================
--	Fin des API d'�change entre applications
--================================================================================









--=======================================================================================
--
-- Cr��s par JPB le 16/01/03 : s�paration alarmes / structure

create or replace trigger ti_xnasvc after insert on XNASVC for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);

begin

    /* traitement � effectuer sur les DEUX serveurs (s�paration alarme/structure) */
    insert into XNASVC_REP (equip_id, index_svc, type_svc, stp_id, board_nbr,
			    xnasvc_caract)
	values (:new.equip_id, :new.index_svc, :new.type_svc, :new.stp_id,
		:new.board_innbr + :new.board_outnbr + :new.board_ionbr + :new.board_othernb,
		:new.xnasvc_caract);

    /* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
       on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
		return;
    end if;

--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end	TI_XNASVC;
/


create or replace trigger td_xnasvc after delete on XNASVC for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);

begin

    /* traitement � effectuer sur les DEUX serveurs (s�paration alarme/structure) */
    delete XNASVC_REP 
	where EQUIP_ID  = :old.EQUIP_ID   and 
	      INDEX_SVC = :old.INDEX_SVC  and 
	      TYPE_SVC  = :old.TYPE_SVC	  and
	      XNASVC_CARACT = :old.XNASVC_CARACT;

    /* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
       on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
		return;
    end if;

--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end	TD_XNASVC;
/


/*
*	Ces 4 triggers ont pour but de remplir les champs SITE_NOM � partir de SITE_ID,
*	PROG_NOM � partir de PROG_ID, SSLOT_ID et DSLOT_ID � partir de SSLOT_NB, DSLOT_NB
*	(acc�s des �quipements de la famille %GDC%)
*/

create or replace trigger TIB_GDCSVC before insert on GDCSVC for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    nb_rel           integer;     -- nombre de relations avec autres tables

    SiteNom	     VARCHAR2 (40);
    ProgNom	     VARCHAR2 (40);
    SSlotId	     NUMBER;
    DSlotId	     NUMBER;

begin
    /* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
       on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
	return;
    end if;

    select SITE_NOM into SiteNom from SITE
	where SITE_ID = :new.SITE_ID;
    :new.SITE_NOM := SiteNom;

    if (:new.PROG_ID is not NULL and :new.PROG_ID > 0) then
	select PROG_NOM into ProgNom from PROG
	    where PROG_ID = :new.PROG_ID;
	:new.PROG_NOM := ProgNom;
    end if;

    if (:new.SSLOT_NB is not NULL and :new.SSLOT_NB > 0 and :new.SSLOT_ID is null) then
	select EQUIP_ID into SSlotId from EQUIP, TYPEQ, FAMILLE 
	    where EQUIP.BAIE_EQUIP_CARTE = to_char (:new.SSLOT_NB) and
		  EQUIP.SITE_ID    = :new.SITE_ID        and
		  EQUIP.TYPEQ_ID   = TYPEQ.TYPEQ_ID 	 and
		  TYPEQ.FAMILLE_ID = FAMILLE.FAMILLE_ID  and
		  FAMILLE_NOM like '%GDC%'		 and
		  TYPEQ.TYPEQ_NOM like '%ACCES%'	 and
		  EQUIP_INDEXSNMP = :new.SLINK_NB +1
	union
	select EQUIP_ID  from EQUIP
	    where EQUIP.BAIE_EQUIP_CARTE = to_char (:new.SSLOT_NB) and
		  EQUIP.SITE_ID    = :new.SITE_ID        and
		  (TYPEQ_NOM like '%NI%' or
		   TYPEQ_NOM like '%TI%' or TYPEQ_NOM like '%TO%' or TYPEQ_NOM like '%TIO%'); 
	:new.SSLOT_ID := SSlotId;
    end if;

    if (:new.DSLOT_NB is not NULL and :new.DSLOT_NB > 0 and :new.DSLOT_ID is null) then
	select EQUIP_ID into DSlotId from EQUIP, TYPEQ, FAMILLE 
	    where EQUIP.BAIE_EQUIP_CARTE = to_char (:new.DSLOT_NB) and
		  EQUIP.SITE_ID    = :new.SITE_ID        and
		  EQUIP.TYPEQ_ID   = TYPEQ.TYPEQ_ID 	 and
		  TYPEQ.FAMILLE_ID = FAMILLE.FAMILLE_ID  and
		  FAMILLE_NOM like '%GDC%'		 and
		  TYPEQ.TYPEQ_NOM like '%ACCES%'	 and
		  EQUIP_INDEXSNMP = :new.DLINK_NB +1
	union
	select EQUIP_ID  from EQUIP
	    where EQUIP.BAIE_EQUIP_CARTE = to_char (:new.DSLOT_NB) and
		  EQUIP.SITE_ID    = :new.SITE_ID        and
		  (TYPEQ_NOM like '%NI%' or
		   TYPEQ_NOM like '%TI%' or TYPEQ_NOM like '%TO%' or TYPEQ_NOM like '%TIO%'); 
	:new.DSLOT_ID := DSlotId;
    end if;
end TIB_GDCSVC;
/


create or replace trigger TUB_GDCSVC before update on GDCSVC for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    nb_rel           integer;     -- nombre de relations avec autres tables

    SiteNom	     VARCHAR2 (40);
    ProgNom	     VARCHAR2 (40);
    SSlotId	     NUMBER;
    DSlotId	     NUMBER;

begin
    /* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
       on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
	return;
    end if;

    select SITE_NOM into SiteNom from SITE
	where SITE_ID = :new.SITE_ID;
    :new.SITE_NOM := SiteNom;

    if (:new.PROG_ID is not NULL and :new.PROG_ID > 0) then
	select PROG_NOM into ProgNom from PROG
	    where PROG_ID = :new.PROG_ID;
	:new.PROG_NOM := ProgNom;
    end if;

    if (:new.SSLOT_NB is not NULL and :new.SSLOT_NB > 0 and :new.SSLOT_ID is null) then
	select EQUIP_ID into SSlotId from EQUIP, TYPEQ, FAMILLE 
	    where EQUIP.BAIE_EQUIP_CARTE = to_char (:new.SSLOT_NB) and
		  EQUIP.SITE_ID    = :new.SITE_ID        and
		  EQUIP.TYPEQ_ID   = TYPEQ.TYPEQ_ID 	 and
		  TYPEQ.FAMILLE_ID = FAMILLE.FAMILLE_ID  and
		  FAMILLE_NOM like '%GDC%'		 and
		  TYPEQ.TYPEQ_NOM like '%ACCES%'	 and
		  EQUIP_INDEXSNMP = :new.SLINK_NB +1
	union
	select EQUIP_ID  from EQUIP
	    where EQUIP.BAIE_EQUIP_CARTE = to_char (:new.SSLOT_NB) and
		  EQUIP.SITE_ID    = :new.SITE_ID        and
		  (TYPEQ_NOM like '%NI%' or
		   TYPEQ_NOM like '%TI%' or TYPEQ_NOM like '%TO%' or TYPEQ_NOM like '%TIO%'); 
	:new.SSLOT_ID := SSlotId;
    end if;

    if (:new.DSLOT_NB is not NULL and :new.DSLOT_NB > 0 and :new.DSLOT_ID is null) then
	select EQUIP_ID into DSlotId from EQUIP, TYPEQ, FAMILLE 
	    where EQUIP.BAIE_EQUIP_CARTE = to_char (:new.DSLOT_NB) and
		  EQUIP.SITE_ID    = :new.SITE_ID        and
		  EQUIP.TYPEQ_ID   = TYPEQ.TYPEQ_ID 	 and
		  TYPEQ.FAMILLE_ID = FAMILLE.FAMILLE_ID  and
		  FAMILLE_NOM like '%GDC%'		 and
		  TYPEQ.TYPEQ_NOM like '%ACCES%'	 and
		  EQUIP_INDEXSNMP = :new.DLINK_NB +1
	union
	select EQUIP_ID  from EQUIP
	    where EQUIP.BAIE_EQUIP_CARTE = to_char (:new.DSLOT_NB) and
		  EQUIP.SITE_ID    = :new.SITE_ID        and
		  (TYPEQ_NOM like '%NI%' or
		   TYPEQ_NOM like '%TI%' or TYPEQ_NOM like '%TO%' or TYPEQ_NOM like '%TIO%'); 
	:new.DSLOT_ID := DSlotId;
    end if;
end TU_GDCSVC;
/


create or replace trigger TIB_GDCSVCTEMP before insert on GDCSVC_TEMP for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    nb_rel           integer;     -- nombre de relations avec autres tables

    SiteNom	     VARCHAR2 (40);
    ProgNom	     VARCHAR2 (40);
    SSlotId	     NUMBER;
    DSlotId	     NUMBER;

begin
    /* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
       on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
	return;
    end if;

    select SITE_NOM into SiteNom from SITE
	where SITE_ID = :new.SITE_ID;
    :new.SITE_NOM := SiteNom;

    if (:new.PROG_ID is not NULL and :new.PROG_ID > 0) then
	select PROG_NOM into ProgNom from PROG
	    where PROG_ID = :new.PROG_ID;
	:new.PROG_NOM := ProgNom;
    end if;

    if (:new.SSLOT_NB is not NULL and :new.SSLOT_NB > 0 and :new.SSLOT_ID is null) then
	select EQUIP_ID into SSlotId from EQUIP, TYPEQ, FAMILLE 
	    where EQUIP.BAIE_EQUIP_CARTE = to_char (:new.SSLOT_NB) and
		  EQUIP.SITE_ID    = :new.SITE_ID        and
		  EQUIP.TYPEQ_ID   = TYPEQ.TYPEQ_ID 	 and
		  TYPEQ.FAMILLE_ID = FAMILLE.FAMILLE_ID  and
		  FAMILLE_NOM like '%GDC%'		 and
		  TYPEQ.TYPEQ_NOM like '%ACCES%'	 and
		  EQUIP_INDEXSNMP = :new.SLINK_NB +1
	union
	select EQUIP_ID  from EQUIP
	    where EQUIP.BAIE_EQUIP_CARTE = to_char (:new.SSLOT_NB) and
		  EQUIP.SITE_ID    = :new.SITE_ID        and
		  (TYPEQ_NOM like '%NI%' or
		   TYPEQ_NOM like '%TI%' or TYPEQ_NOM like '%TO%' or TYPEQ_NOM like '%TIO%'); 
	:new.SSLOT_ID := SSlotId;
    end if;

    if (:new.DSLOT_NB is not NULL and :new.DSLOT_NB > 0 and :new.DSLOT_ID is null) then
	select EQUIP_ID into DSlotId from EQUIP, TYPEQ, FAMILLE 
	    where EQUIP.BAIE_EQUIP_CARTE = to_char (:new.DSLOT_NB) and
		  EQUIP.SITE_ID    = :new.SITE_ID        and
		  EQUIP.TYPEQ_ID   = TYPEQ.TYPEQ_ID 	 and
		  TYPEQ.FAMILLE_ID = FAMILLE.FAMILLE_ID  and
		  FAMILLE_NOM like '%GDC%'		 and
		  TYPEQ.TYPEQ_NOM like '%ACCES%'	 and
		  EQUIP_INDEXSNMP = :new.DLINK_NB +1
	union
	select EQUIP_ID  from EQUIP
	    where EQUIP.BAIE_EQUIP_CARTE = to_char (:new.DSLOT_NB) and
		  EQUIP.SITE_ID    = :new.SITE_ID        and
		  (TYPEQ_NOM like '%NI%' or
		   TYPEQ_NOM like '%TI%' or TYPEQ_NOM like '%TO%' or TYPEQ_NOM like '%TIO%'); 
	:new.DSLOT_ID := DSlotId;
    end if;
end TIB_GDCSVCTEMP;
/


create or replace trigger TUB_GDCSVCTEMP before update on GDCSVC_TEMP for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    nb_rel           integer;     -- nombre de relations avec autres tables

    SiteNom	     VARCHAR2 (40);
    ProgNom	     VARCHAR2 (40);
    SSlotId	     NUMBER;
    DSlotId	     NUMBER;

begin
    /* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
       on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
	return;
    end if;

    select SITE_NOM into SiteNom from SITE
	where SITE_ID = :new.SITE_ID;
    :new.SITE_NOM := SiteNom;

    if (:new.PROG_ID is not NULL and :new.PROG_ID > 0) then
	select PROG_NOM into ProgNom from PROG
	    where PROG_ID = :new.PROG_ID;
	:new.PROG_NOM := ProgNom;
    end if;

    if (:new.SSLOT_NB is not NULL and :new.SSLOT_NB > 0 and :new.SSLOT_ID is null) then
	select EQUIP_ID into SSlotId from EQUIP, TYPEQ, FAMILLE 
	    where EQUIP.BAIE_EQUIP_CARTE = to_char (:new.SSLOT_NB) and
		  EQUIP.SITE_ID    = :new.SITE_ID        and
		  EQUIP.TYPEQ_ID   = TYPEQ.TYPEQ_ID 	 and
		  TYPEQ.FAMILLE_ID = FAMILLE.FAMILLE_ID  and
		  FAMILLE_NOM like '%GDC%'		 and
		  TYPEQ.TYPEQ_NOM like '%ACCES%'	 and
		  EQUIP_INDEXSNMP = :new.SLINK_NB +1
	union
	select EQUIP_ID  from EQUIP
	    where EQUIP.BAIE_EQUIP_CARTE = to_char (:new.SSLOT_NB) and
		  EQUIP.SITE_ID    = :new.SITE_ID        and
		  (TYPEQ_NOM like '%NI%' or
		   TYPEQ_NOM like '%TI%' or TYPEQ_NOM like '%TO%' or TYPEQ_NOM like '%TIO%'); 
	:new.SSLOT_ID := SSlotId;
    end if;

    if (:new.DSLOT_NB is not NULL and :new.DSLOT_NB > 0 and :new.DSLOT_ID is null) then
	select EQUIP_ID into DSlotId from EQUIP, TYPEQ, FAMILLE 
	    where EQUIP.BAIE_EQUIP_CARTE = to_char (:new.DSLOT_NB) and
		  EQUIP.SITE_ID    = :new.SITE_ID        and
		  EQUIP.TYPEQ_ID   = TYPEQ.TYPEQ_ID 	 and
		  TYPEQ.FAMILLE_ID = FAMILLE.FAMILLE_ID  and
		  FAMILLE_NOM like '%GDC%'		 and
		  TYPEQ.TYPEQ_NOM like '%ACCES%'	 and
		  EQUIP_INDEXSNMP = :new.DLINK_NB +1
	union
	select EQUIP_ID  from EQUIP
	    where EQUIP.BAIE_EQUIP_CARTE = to_char (:new.DSLOT_NB) and
		  EQUIP.SITE_ID    = :new.SITE_ID        and
		  (TYPEQ_NOM like '%NI%' or
		   TYPEQ_NOM like '%TI%' or TYPEQ_NOM like '%TO%' or TYPEQ_NOM like '%TIO%'); 
	:new.DSLOT_ID := DSlotId;
    end if;
end TU_GDCSVCTEMP;
/


--
--    Cette proc�dure v�rifie si les tables XNASVC et XNASVC_TEMP sont identiques.
--	+ si le nombre de rang�es est diff�rent, on efface XNASVC et on l'initialise � partir de
--	XNASVC_TEMP
--	+ si le nombre de rang�es est identique, il n'y a pas eu d'adjonction ou suppression de mat�riel.
--	Seul, le param�trage peut �tre diff�rent. Dans ce cas, on v�rifie chaque rang�e, et
--	si n�cessaire, on la recopie � partir de XNASVC_TEMP
--
--	Modif JPB le 12/11/03 : Maj pour permettre � plusieurs EM de fonctionner sur la m�me BDD.
--	Chacun ne met � jour que la portion de la base d�finie par "ThisEM".
--
--	Modif JPB le 15/02/05 : Fonctionnement incorrect lorsqu'une carte change de n�
--	ex : carte INNBR, OUNBR, IONBR = (0, 0, 0) remplac�e par (10,0,0), la rang�e (10,0,0)
--	n'apparait pas.

CREATE OR REPLACE PROCEDURE MajXnaSvc
(
    ThisEM	VARCHAR2	-- Nom de cet EM
)
IS
    NbRows	NUMBER;		-- Nb. de rang�es de XNASVC
    NbRowsTemp	NUMBER;		-- Nb. de rang�es de XNASVC_TEMP

    MinId	NUMBER;		-- Valeur min. de XNASVC_ID dans XNASVC
    MinIdTemp	NUMBER;		-- Valeur min. de XNASVC_ID dans XNASVC_TEMP

    CURSOR CTemp IS
	select * from XNASVC_TEMP where XNASVC_CARACT = ThisEM;

    CURSOR CXna (Id NUMBER) IS
	select * from XNASVC
	    where XNA_ID = Id
	    for update;

BEGIN
    select count(*) into NbRows from XNASVC where XNASVC_CARACT = ThisEM;
    select count(*) into NbRowsTemp from XNASVC_TEMP where XNASVC_CARACT = ThisEM;

    if (NbRows != NbRowsTemp) then
	delete XNASVC where XNASVC_CARACT = ThisEM;
	insert into XNASVC (XNA_ID, EQUIP_ADDRIP, STP_ID, MIB, VERSION_MIB, BOARD_INNBR, BOARD_OUTNBR, 
			    BOARD_IONBR, TX_CR, RX_CR, VPI, VCI, EQUIP_ID, INDEX_SVC, TYPE_SVC,
			    BOARD_OTHERNB, BOARD_TYPE, XNASVC_CARACT)
	    select XNA_ID, EQUIP_ADDRIP, STP_ID, MIB, VERSION_MIB, BOARD_INNBR, BOARD_OUTNBR, 
		   BOARD_IONBR, TX_CR, RX_CR, VPI, VCI, EQUIP_ID, INDEX_SVC, TYPE_SVC,
		   BOARD_OTHERNB, BOARD_TYPE, ThisEM
		from XNASVC_TEMP
		where XNASVC_CARACT = ThisEM;

    else
	select min (XNA_ID) into MinId from XNASVC where XNASVC_CARACT = ThisEM;
	select min (XNA_ID) into MinIdTemp from XNASVC_TEMP where XNASVC_CARACT = ThisEM;

	for vTemp in CTemp loop
	    for vXna in CXna (vTemp.XNA_ID - MinIdTemp + MinId) loop
		if (vTemp.EQUIP_ID	!= vXna.EQUIP_ID	or vXna.EQUIP_ID	is NULL or
		    vTemp.EQUIP_ADDRIP	!= vXna.EQUIP_ADDRIP	or vXna.EQUIP_ADDRIP	is NULL or
		    vTemp.STP_ID	!= vXna.STP_ID		or vXna.STP_ID		is NULL or
		    vTemp.BOARD_INNBR	!= vXna.BOARD_INNBR	or vXna.BOARD_INNBR	is NULL or
		    vTemp.BOARD_OUTNBR	!= vXna.BOARD_OUTNBR	or vXna.BOARD_OUTNBR	is NULL or
		    vTemp.BOARD_IONBR	!= vXna.BOARD_IONBR	or vXna.BOARD_IONBR	is NULL or
		    vTemp.MIB		!= vXna.MIB		or vXna.MIB		is NULL or
		    vTemp.VERSION_MIB	!= vXna.VERSION_MIB	or vXna.VERSION_MIB	is NULL or
		    vTemp.TX_CR		!= vXna.TX_CR		or vXna.TX_CR		is NULL or
		    vTemp.RX_CR		!= vXna.RX_CR		or vXna.RX_CR		is NULL or
		    vTemp.VPI		!= vXna.VPI		or vXna.VPI		is NULL or
		    vTemp.VCI		!= vXna.VCI		or vXna.VCI		is NULL or
		    vTemp.INDEX_SVC	!= vXna.INDEX_SVC	or vXna.INDEX_SVC	is NULL or
		    vTemp.TYPE_SVC	!= vXna.TYPE_SVC	or vXna.TYPE_SVC	is NULL or
		    vTemp.BOARD_OTHERNB != vXna.BOARD_OTHERNB	or vXna.BOARD_OTHERNB	is NULL or
		    vTemp.BOARD_TYPE	!= vXna.BOARD_TYPE	or vXna.BOARD_TYPE	is NULL or
		    vTemp.XNASVC_CARACT	!= vXna.XNASVC_CARACT	or vXna.XNASVC_CARACT	is NULL
		    )	then

		    update XNASVC set
			EQUIP_ID	= vTemp.EQUIP_ID,
			EQUIP_ADDRIP	= vTemp.EQUIP_ADDRIP,
		    	STP_ID		= vTemp.STP_ID,
			BOARD_INNBR	= vTemp.BOARD_INNBR,
			BOARD_OUTNBR	= vTemp.BOARD_OUTNBR,
			BOARD_IONBR	= vTemp.BOARD_IONBR,
		    	MIB		= vTemp.MIB,
		    	VERSION_MIB	= vTemp.VERSION_MIB,
		    	TX_CR		= vTemp.TX_CR,
		    	RX_CR		= vTemp.RX_CR,
		    	VPI		= vTemp.VPI,
		    	VCI		= vTemp.VCI,
		    	INDEX_SVC	= vTemp.INDEX_SVC,
		    	TYPE_SVC	= vTemp.TYPE_SVC,
			XNA_ID		= vTemp.XNA_ID,
			BOARD_OTHERNB	= vTemp.BOARD_OTHERNB,
			BOARD_TYPE	= vTemp.BOARD_TYPE,
			XNASVC_CARACT	= vTemp.XNASVC_CARACT
			where current of CXna;
		end if;

		if (vTemp.VPI is null and vXna.VPI is not null) then
		    update XNASVC set
			VPI = null
			where current of CXna;
		end if;

		if (vTemp.VCI is null and vXna.VCI is not null) then
		    update XNASVC set
			VCI = null
			where current of CXna;
		end if;
	    end loop;
	end loop;
    end if;
END	MajXnaSvc;
/


--
--    Cette proc�dure v�rifie si les tables GDCSVC et GDCSVC_TEMP sont identiques.
--	+ si le nombre de rang�es est diff�rent, on efface GDCSVC et on l'initialise � partir de
--	GDCSVC_TEMP
--	+ si le nombre de rang�es est identique, il n'y a pas eu d'adjonction ou suppression de mat�riel.
--	Seul, le param�trage peut �tre diff�rent. Dans ce cas, on v�rifie chaque rang�e, et
--	si n�cessaire, on la recopie � partir de GDCSVC_TEMP
--
--	18/09/03 : JPB - Modif : si la table est modifi�e, on envoie un message "8" pour
--	provoquer le rafra�chissement des vues des postes clients.
--	Modif JPB le 12/11/03 : Maj pour permettre � plusieurs EM de fonctionner sur la m�me BDD.
--	Chacun ne met � jour que la portion de la base d�finie par "ThisEM".
--
--	02/02/04 : JPB - Modif. Dans le insert into GDCSVC, le test "where GDCSVC_CARACT = ThisEM"
--	avait �t� oubli�.
--	15/02/05 : JPB - Ajout de EQUIP_ID dans le insert

CREATE OR REPLACE PROCEDURE MajGdcSvc
(
    ThisEM	VARCHAR2	-- Nom de cet EM
)
IS
    NbRows	NUMBER;		-- Nb. de rang�es de GDCSVC
    NbRowsTemp	NUMBER;		-- Nb. de rang�es de GDCSVC_TEMP

    bModif	BOOLEAN;	-- TRUE si la table a �t�t modifi�e
    MessId	NUMBER;		-- Identifiant du message � envoyer
    Mess	VARCHAR2 (20);  -- Message � envoyer

    MinId	NUMBER;		-- Valeur min. de GDCSVC_ID dans GDCSVC
    MinIdTemp	NUMBER;		-- Valeur min. de GDCSVC_ID dans GDCSVC_TEMP

    CURSOR CTemp IS
	select * from GDCSVC_TEMP where GDCSVC_CARACT = ThisEM;

    CURSOR CGdc (Id NUMBER) IS
	select * from GDCSVC
	    where GDCSVC_ID = Id
	    for update;

BEGIN
    bModif := FALSE;
    select count(*) into NbRows from GDCSVC where GDCSVC_CARACT = ThisEM; 
    select count(*) into NbRowsTemp from GDCSVC_TEMP where GDCSVC_CARACT = ThisEM; 

    if (NbRows != NbRowsTemp) then
	delete GDCSVC where GDCSVC_CARACT = ThisEM;
	insert into GDCSVC (GDCSVC_ID, EQUIP_ID, SERVICE_ID, SERVICE_TYPE, SPVC_ID, SVC_ID, PROG_ID, PROG_NOM, 
			    SITE_ID, SITE_NOM, 
			    SSLOT_NB, SSLOT_ID, SLINK_NB, SVPI, SVCI, DSLOT_NB, DSLOT_ID, 
			    DLINK_NB, DVPI, DVCI, STATUS, RANG, USED, ISGDC, LIAI_ID, XNA_ID,
			    GDC_REACHABLE, GDCSVC_CARACT)
	    select GDCSVC_ID, EQUIP_ID, SERVICE_ID, SERVICE_TYPE, SPVC_ID, SVC_ID, PROG_ID, PROG_NOM,
		   SITE_ID, SITE_NOM, 
		   SSLOT_NB, SSLOT_ID, SLINK_NB, SVPI, SVCI, DSLOT_NB, DSLOT_ID, 
		   DLINK_NB, DVPI, DVCI, STATUS, RANG, USED, ISGDC, LIAI_ID, XNA_ID, 
		   GDC_REACHABLE, ThisEM
		from GDCSVC_TEMP 
		where GDCSVC_CARACT = ThisEM;
	bModif := TRUE;

    else
	select min (GDCSVC_ID) into MinId from GDCSVC where GDCSVC_CARACT = ThisEM;
	select min (GDCSVC_ID) into MinIdTemp from GDCSVC_TEMP where GDCSVC_CARACT = ThisEM;

	for vTemp in CTemp loop
	    for vGdc in CGdc (vTemp.GDCSVC_ID - MinIdTemp + MinId) loop
--	    for vGdc in CGdc (vTemp.GDCSVC_ID) loop
		if (vTemp.EQUIP_ID	!= vGdc.EQUIP_ID	or vGdc.EQUIP_ID     is NULL or
		    vTemp.SERVICE_ID	!= vGdc.SERVICE_ID	or vGdc.SERVICE_ID   is NULL or
		    vTemp.SERVICE_TYPE  != vGdc.SERVICE_TYPE    or vGdc.SERVICE_TYPE is NULL or
		    vTemp.SPVC_ID	!= vGdc.SPVC_ID		or vGdc.SPVC_ID	     is NULL or
		    vTemp.SVC_ID	!= vGdc.SVC_ID		or vGdc.SVC_ID	     is NULL or
		    vTemp.PROG_ID	!= vGdc.PROG_ID		or vGdc.PROG_ID	     is NULL or
		    vTemp.PROG_NOM	!= vGdc.PROG_NOM	or vGdc.PROG_NOM     is NULL or
		    vTemp.SITE_ID	!= vGdc.SITE_ID		or vGdc.SITE_ID	     is NULL or
		    vTemp.SITE_NOM	!= vGdc.SITE_NOM	or vGdc.SITE_NOM     is NULL or
		    vTemp.SSLOT_NB	!= vGdc.SSLOT_NB	or vGdc.SSLOT_NB     is NULL or
		    vTemp.SSLOT_ID	!= vGdc.SSLOT_ID	or vGdc.SSLOT_ID     is NULL or
		    vTemp.SLINK_NB	!= vGdc.SLINK_NB	or vGdc.SLINK_NB     is NULL or
		    vTemp.SVPI		!= vGdc.SVPI		or vGdc.SVPI	     is NULL or
		    vTemp.SVCI		!= vGdc.SVCI		or vGdc.SVCI	     is NULL or
		    vTemp.DSLOT_NB	!= vGdc.DSLOT_NB	or vGdc.DSLOT_NB     is NULL or
		    vTemp.DSLOT_ID	!= vGdc.DSLOT_ID	or vGdc.DSLOT_ID     is NULL or
		    vTemp.DLINK_NB	!= vGdc.DLINK_NB	or vGdc.DLINK_NB     is NULL or
		    vTemp.DVPI		!= vGdc.DVPI		or vGdc.DVPI	     is NULL or
		    vTemp.DVCI		!= vGdc.DVCI		or vGdc.DVCI	     is NULL or
		    vTemp.STATUS	!= vGdc.STATUS		or vGdc.STATUS	     is NULL or
		    vTemp.RANG		!= vGdc.RANG		or vGdc.RANG	     is NULL or
		    vTemp.USED		!= vGdc.USED		or vGdc.USED	     is NULL or
		    vTemp.ISGDC		!= vGdc.ISGDC		or vGdc.ISGDC	     is NULL or
		    vTemp.LIAI_ID	!= vGdc.LIAI_ID		or vGdc.LIAI_ID      is NULL or
		    vTemp.XNA_ID	!= vGdc.XNA_ID		or vGdc.XNA_ID	     is NULL or
		    vTemp.GDC_REACHABLE != vGdc.GDC_REACHABLE	or vGdc.GDC_REACHABLE is NULL or
		    vTemp.GDCSVC_CARACT	!= vGdc.GDCSVC_CARACT	or vGdc.GDCSVC_CARACT is NULL)
		then
		    bModif := TRUE;
		    update GDCSVC set
			EQUIP_ID	= vTemp.EQUIP_ID,
			SERVICE_ID	= vTemp.SERVICE_ID,
			SERVICE_TYPE    = vTemp.SERVICE_TYPE,
		    	SPVC_ID		= vTemp.SPVC_ID,
		    	SVC_ID		= vTemp.SVC_ID,
		    	PROG_ID		= vTemp.PROG_ID,
			PROG_NOM	= vTemp.PROG_NOM,
		    	SITE_ID		= vTemp.SITE_ID,
		    	SITE_NOM	= vTemp.SITE_NOM,
		    	SSLOT_NB	= vTemp.SSLOT_NB,
		    	SSLOT_ID	= vTemp.SSLOT_ID,
		    	SLINK_NB	= vTemp.SLINK_NB,
		    	SVPI		= vTemp.SVPI,
		    	SVCI		= vTemp.SVCI,
		    	DSLOT_NB	= vTemp.DSLOT_NB,
		    	DSLOT_ID	= vTemp.DSLOT_ID,
		    	DLINK_NB	= vTemp.DLINK_NB,
		    	DVPI		= vTemp.DVPI,
		    	DVCI		= vTemp.DVCI,
		    	STATUS		= vTemp.STATUS,
		    	RANG		= vTemp.RANG,
		    	USED		= vTemp.USED,
		    	ISGDC		= vTemp.ISGDC,
		    	LIAI_ID		= vTemp.LIAI_ID,
		    	XNA_ID		= vTemp.XNA_ID,
			GDC_REACHABLE   = vTemp.GDC_REACHABLE,
			GDCSVC_CARACT	= vTemp.GDCSVC_CARACT
			where current of CGdc;
		end if;

		if (vTemp.SERVICE_ID is null and vGdc.SERVICE_ID is not null) then
		    update GDCSVC set
			SERVICE_ID = null
			where current of CGdc;
		    bModif := TRUE;
		end if;

		if (vTemp.SERVICE_TYPE is null and vGdc.SERVICE_TYPE is not null) then
		    update GDCSVC set
			SERVICE_TYPE = null
			where current of CGdc;
		    bModif := TRUE;
		end if;

		if (vTemp.SPVC_ID is null and vGdc.SPVC_ID is not null) then
		    update GDCSVC set
			SPVC_ID = null
			where current of CGdc;
		    bModif := TRUE;
		end if;

		if (vTemp.SVC_ID is null and vGdc.SVC_ID is not null) then
		    update GDCSVC set
			SVC_ID = null
			where current of CGdc;
		    bModif := TRUE;
		end if;

		if (vTemp.PROG_ID is null and vGdc.PROG_ID is not null) then
		    update GDCSVC set
			PROG_ID = null
			where current of CGdc;
		    bModif := TRUE;
		end if;

		if (vTemp.PROG_NOM is null and vGdc.PROG_NOM is not null) then
		    update GDCSVC set
			PROG_NOM = null
			where current of CGdc;
		    bModif := TRUE;
		end if;

		if (vTemp.SITE_ID is null and vGdc.SITE_ID is not null) then
		    update GDCSVC set
			SITE_ID = null
			where current of CGdc;
		    bModif := TRUE;
		end if;

		if (vTemp.SVPI is null and vGdc.SVPI is not null) then
		    update GDCSVC set
			SVPI = null
			where current of CGdc;
		    bModif := TRUE;
		end if;

		if (vTemp.SVCI is null and vGdc.SVCI is not null) then
		    update GDCSVC set
			SVCI = null
			where current of CGdc;
		    bModif := TRUE;
		end if;

		if (vTemp.DSLOT_NB is null and vGdc.DSLOT_NB is not null) then
		    update GDCSVC set
			DSLOT_NB = null
			where current of CGdc;
		    bModif := TRUE;
		end if;

		if (vTemp.DSLOT_ID is null and vGdc.DSLOT_ID is not null) then
		    update GDCSVC set
			DSLOT_ID = null
			where current of CGdc;
		    bModif := TRUE;
		end if;

		if (vTemp.DLINK_NB is null and vGdc.DLINK_NB is not null) then
		    update GDCSVC set
			DLINK_NB = null
			where current of CGdc;
		    bModif := TRUE;
		end if;

		if (vTemp.DVPI is null and vGdc.DVPI is not null) then
		    update GDCSVC set
			DVPI = null
			where current of CGdc;
		    bModif := TRUE;
		end if;

		if (vTemp.DVCI is null and vGdc.DVCI is not null) then
		    update GDCSVC set
			DVCI = null
			where current of CGdc;
		    bModif := TRUE;
		end if;

		if (vTemp.RANG is null and vGdc.RANG is not null) then
		    update GDCSVC set
			RANG = null
			where current of CGdc;
		    bModif := TRUE;
		end if;

		if (vTemp.LIAI_ID is null and vGdc.LIAI_ID is not null) then
		    update GDCSVC set
			LIAI_ID = null
			where current of CGdc;
		    bModif := TRUE;
		end if;

		if (vTemp.XNA_ID is null and vGdc.XNA_ID is not null) then
		    update GDCSVC set
			XNA_ID = null
			where current of CGdc;
		    bModif := TRUE;
		end if;

		if (vTemp.GDC_REACHABLE is null and vGdc.GDC_REACHABLE is not null) then
		    update GDCSVC set
			GDC_REACHABLE = null
			where current of CGdc;
		    bModif := TRUE;
		end if;

		if (vTemp.EQUIP_ID is null and vGdc.EQUIP_ID is not null) then
		    update GDCSVC set
			EQUIP_ID = null
			where current of CGdc;
		    bModif := TRUE;
		end if;
	    end loop;
	end loop;
    end if;

    if (bModif) then
	select SEQ_MESSALRM.NEXTVAL into MessId from dual;

	Mess := '8#2#';		-- message � envoyer
	insert into MESSALRM (MESSALRM_ID, MESSALRM_MESS, MESSALRM_SENT, MESSALRM_NATURE)
	    values (MessId, Mess, 0, 0);
    end if;
END	MajGdcSvc;
/


CREATE OR REPLACE PROCEDURE TestXnaSvc
IS
    NbRows	NUMBER;		-- Nb. de rang�es de XNASVC
    NbRowsTemp	NUMBER;		-- Nb. de rang�es de XNASVC_TEMP

    CURSOR CTemp IS
	select * from XNASVC_TEMP;

    CURSOR CXna (Id NUMBER, InNbr NUMBER, OutNbr NUMBER, IONbr NUMBER, OtherNbr NUMBER) IS
	select * from XNASVC
	    where EQUIP_ID = Id and
		  BOARD_INNBR  = InNbr  and
		  BOARD_OUTNBR = OutNbr and
		  BOARD_IONBR  = IONbr	and
		  BOARD_OTHERNB= OtherNbr
	    for update;

BEGIN
    select count(*) into NbRows from XNASVC; 
    select count(*) into NbRowsTemp from XNASVC_TEMP; 

	for vTemp in CTemp loop
	    for vXna in CXna (vTemp.EQUIP_ID, vTemp.BOARD_INNBR, vTemp.BOARD_OUTNBR, 
			      vTemp.BOARD_IONBR, vTemp.BOARD_OTHERNB) loop
		if (vTemp.EQUIP_ADDRIP	!= vXna.EQUIP_ADDRIP	or
		    vTemp.STP_ID	!= vXna.STP_ID		or 
		    vTemp.MIB		!= vXna.MIB		or
		    vTemp.VERSION_MIB	!= vXna.VERSION_MIB	or 
		    vTemp.TX_CR		!= vXna.TX_CR		or 
		    vTemp.RX_CR		!= vXna.RX_CR		or 
		    vTemp.VPI		!= vXna.VPI		or 
		    vTemp.VCI		!= vXna.VCI		or 
		    vTemp.INDEX_SVC	!= vXna.INDEX_SVC	or 
		    vTemp.TYPE_SVC	!= vXna.TYPE_SVC	or
		    vTemp.BOARD_OTHERNB != vXna.BOARD_OTHERNB   or
		    vTemp.BOARD_TYPE	!= vXna.BOARD_TYPE)	then
		dbms_output.put_line (' Diff�rence � Id '||to_char(vTemp.EQUIP_ID));
		end if;
	    end loop;
	end loop;
    
END	TestXnaSvc;
/


CREATE OR REPLACE PROCEDURE TestGdcSvc
IS
    NbRows	NUMBER;		-- Nb. de rang�es de GDCSVC
    NbRowsTemp	NUMBER;		-- Nb. de rang�es de GDCSVC_TEMP

    CURSOR CTemp IS
	select * from GDCSVC_TEMP;

    CURSOR CGdc (Id NUMBER) IS
	select * from GDCSVC
	    where GDCSVC_ID = Id
	    for update;

BEGIN

	for vTemp in CTemp loop
	    for vGdc in CGdc (vTemp.GDCSVC_ID) loop
		if (vTemp.SERVICE_ID	!= vGdc.SERVICE_ID	or
		    vTemp.SPVC_ID	!= vGdc.SPVC_ID		or 
		    vTemp.SVC_ID	!= vGdc.SVC_ID		or
		    vTemp.PROG_ID	!= vGdc.PROG_ID		or
		    vTemp.SITE_ID	!= vGdc.SITE_ID		or
		    vTemp.SITE_NOM	!= vGdc.SITE_NOM	or
		    vTemp.SSLOT_NB	!= vGdc.SSLOT_NB	or
		    vTemp.SSLOT_ID	!= vGdc.SSLOT_ID	or
		    vTemp.SLINK_NB	!= vGdc.SLINK_NB	or
		    vTemp.SVPI		!= vGdc.SVPI		or
		    vTemp.SVCI		!= vGdc.SVCI		or
		    vTemp.DSLOT_NB	!= vGdc.DSLOT_NB	or
		    vTemp.DSLOT_ID	!= vGdc.DSLOT_ID	or
		    vTemp.DLINK_NB	!= vGdc.DLINK_NB	or
		    vTemp.DVPI		!= vGdc.DVPI		or
		    vTemp.DVCI		!= vGdc.DVCI		or
		    vTemp.STATUS	!= vGdc.STATUS		or
		    vTemp.RANG		!= vGdc.RANG		or
		    vTemp.USED		!= vGdc.USED		or
		    vTemp.ISGDC		!= vGdc.ISGDC		or
		    vTemp.LIAI_ID	!= vGdc.LIAI_ID		or
		    vTemp.XNA_ID	!= vGdc.XNA_ID		or
		    vTemp.EQUIP_ID	!= vGdc.EQUIP_ID)	then

		dbms_output.put_line (' Diff�rence � Id '||to_char(vTemp.GDCSVC_ID));
		end if;

	    end loop;
	end loop;

END	TestGdcSvc;
/


--==========================================================================================
--
--	Proc�dures SetAlarm, ResetAlarm et fonction TestAlarm
--
--	Ces proc�dures agissent directement en BDD. Elles ne doivent pas �tre utilis�es
--	dans un contexte de r�plication de BDD. Dans ce cas, il faut utiliser en DLL
--	la fonction SendTrap, qui g�n�re r�ellement un trap, envoy� � EmessEM, donc
--	r�pliqu� si n�cessaire.
--
--	Ces proc�dures permettent de :
--		+ d�clencher une alarme (SetAlarm) si elle n'est pas d�j� en cours,
--		+ faire retomber une alarme (ResetAlarm) si elle est encours.
--	La fonction TestAlarm retourne TRUE si l'alarme est en cours et FALSE autrement.
--
--	Les alarmes "BOUCLE", "SERIE" ou "TRAP" doivent avoir �t� d�clar�es pr�alablement dans SPV
--	(caract�ristiques de l'alarme dans le type d'�quipement correspondant et
--	 c�blage de l'alarme dans l'�quipement ou "�l�ment g�r�"). 
--	 Les valeurs d�clar�es doivent correspondre aux param�tres pass�s � ces fonctions et proc�dures.
--	Les alarmes "SYST" n'ont pas besoin d'�tre d�clar�es pr�alablement. Elles doivent �tre rattach�es
--	� des �quipements existants et avoir �t� "c�bl�es" (ie. d�clar�es manuellement dans ACCES_ACCESC).
--
--	Cr��s par JPB le 28/04/03
--
--==========================================================================================

create or replace
FUNCTION TestAlarm
(
	Type	VARCHAR2,	-- 'BOUCLE', 'SERIE', 'TRAPG', 'TRAPS' ou 'SYST'
	EquCapture VARCHAR2,	-- Nom du type de l'�quipement de capture (aujourd'hui 'IS', 'IP2PORTS')
	NumObj	NUMBER,		-- N� de l'�quipement de capture auquel l'�l�ment g�r� est raccord�
				-- pour les alarmes 'BOUCLE' et 'SERIE'
				-- N� de trap pour les alarmes 'TRAPG' ou 'TRAPS'
	NumAl	VARCHAR2,	-- N� de l'acc�s sur l'�quipement de capture, auquel l'�l�ment g�r� est raccord�
				-- (alarmes 'BOUCLE'. Pour les 'IS' : (n� carte -1) * 48 + n� acc�s sur la carte)
				-- N� du bit d'alarme dans le message s�rie, pour les alarmes 'SERIE'
				-- (Pour les 'IS' : ((n� carte -1) * 8 + (n� acc�s sur la carte -1)) *10000 + n� bit)
				-- Adresse IP de l'�l�ment g�r� pour les 'TRAP'
				-- Identifiant de l'alarme pour les alarmes 'SYST'
	IANA	VARCHAR2	-- Pour les 'TRAP', n� IANA attribu� au fabricant de l'agent
)
RETURN BOOLEAN
IS
	AlarmCl VARCHAR2 (5);	-- Classe de l'alarme
	Id	NUMBER;		-- Id. de l'�l�ment g�r� en d�faut

	CURSOR CTest IS
	    select *
	    	from ACCES_ACCESC_REP
	    	where ALARM_CL 	   = AlarmCl and
		      ALARM_NUMOBJ = NumObj  and
		      ALARM_NUMAL  = NumAl;

/*	CURSOR CTestS IS	-- Alarme s�rie
	    select *
	    	from BITMESS_REP
	    	where ALARM_CL 	   = AlarmCl and
		      ALARM_NUMOBJ = NumObj  and
		      ALARM_NUMAL  = NumAl;*/

	CURSOR CTestSyst IS	-- Alarme syst�me
	    select *
	    	from ACCES_ACCESC_REP
	    	where ALARM_CL 	   = AlarmCl and
		      ALARM_NUMAL  = NumAl;
BEGIN

	if (Type = 'BOUCLE') then
	    if (EquCapture = 'IS') then
		AlarmCl := 'IS';
	    else
		AlarmCl := 'IP2';
	    end if;
	elsif (Type = 'SERIE') then
	    AlarmCl := 'IS_S';
	elsif (Type = 'TRAP')  then -- Temporaire, ce type va dispara�tre
		AlarmCl := 'TRAPS';
	   else
	   	AlarmCl := Type;
	   end if;

	Id := 0;
	for vTest in CTest loop
	    if (vTest.EQUIP_ID is not null) then
		Id := vTest.EQUIP_ID;
	    elsif (vTest.LIAI_ID is not null) then
		Id := vTest.LIAI_ID;
	    elsif (vTest.SITE_ID is not null) then
		Id := vTest.SITE_ID;
	    end if;
	end loop;

	/*if (Type = 'SERIE') then
	    for vTest in CTestS loop
	    	if (vTest.EQUIP_ID is not null) then
		    Id := vTest.EQUIP_ID;
	    	elsif (vTest.LIAI_ID is not null) then
		    Id := vTest.LIAI_ID;
	    	elsif (vTest.SITE_ID is not null) then
		    Id := vTest.SITE_ID;
	    	end if;
	    end loop;
	end if;*/

	if (Type = 'SYST') then
	    for vTest in CTestSyst loop
	    	if (vTest.EQUIP_ID is not null) then
		    Id := vTest.EQUIP_ID;
	    	elsif (vTest.LIAI_ID is not null) then
		    Id := vTest.LIAI_ID;
	    	elsif (vTest.SITE_ID is not null) then
		    Id := vTest.SITE_ID;
	    	end if;
	    end loop;
	end if;

	if (Id > 0) then
	    return TRUE;
	else
	    return FALSE;
	end if;

END	TestAlarm;
/

CREATE OR REPLACE PROCEDURE SetAlarm
(
	Grave	NUMBER,		-- Gravit� de l'alarme, selon la norme X733 :
				-- 0 : fin d'alarme
				-- 3 : avertissement
				-- 4 : ind�termin�
				-- 5 : mineur
				-- 6 : majeur
				-- 7 : critique
				-- ATTENTION, pour certaines alarmes, la gravit� est impos�e
				-- par la configuration et ne vaudra pas la valeur entr�e ici
	DateStr	VARCHAR2,	-- Date et heure du d�but de l'alarme, au format normalis� :
				-- 'YYYY MM DD HH:MN:SS'
				-- ou ''. Dans ce cas, la date et heure syst�me seront prises par d�faut
	Type	VARCHAR2,	-- 'BOUCLE', 'SERIE', 'TRAPG', 'TRAPS' ou 'SYST'
	EquCapture VARCHAR2,	-- Nom du type de l'�quipement de capture 
				-- (aujourd'hui 'IS', 'IP2PORTS' ou '' si raccordement direct � l'EM)
	NumObj	NUMBER,		-- N� de l'�quipement de capture auquel l'�l�ment g�r� est raccord�
				-- pour les alarmes 'BOUCLE' et 'SERIE'
				-- N� de trap pour les alarmes 'TRAP'
	NumAl	VARCHAR2,	-- N� de l'acc�s sur l'�quipement de capture, auquel l'�l�ment g�r� est raccord�
				-- (alarmes 'BOUCLE'. Pour les 'IS' : (n� carte -1) * 48 + n� acc�s sur la carte)
				-- N� du bit d'alarme dans le message s�rie, pour les alarmes 'SERIE'
				-- (Pour les 'IS' : ((n� carte -1) * 8 + (n� acc�s sur la carte -1)) *10000 + n� bit)
				-- Adresse IP de l'�l�ment g�r� pour les 'TRAP'
				-- Identifiant de l'alarme pour les alarmes 'SYST'
	Info	VARCHAR2,	-- Pour les 'TRAP' : champ "variable" du trap ("VarBinds"), cod� ainsi :
				-- OID1 = Valeur1;OID2 = Valeur2; etc....
				-- Pour les alarmes 'SYST' : message d'alarme syst�me
				-- limit� � 256 caract�res
	IANA	VARCHAR2	-- Pour les 'TRAP', n� IANA attribu� au fabricant de l'agent
)
IS
	AlarmCl VARCHAR2 (5);	-- Classe de l'alarme
	AlarmTxt NUMBER;	-- N� identifiant le type d'alarme
	DateS   VARCHAR2 (20);	-- Date de l'alarme

BEGIN
     
	if (Grave > 0 and TestAlarm (Type, EquCapture, NumObj, NumAl, IANA)) then
	    return;
	end if;			-- l'alarme est d�j� en cours

	if (DateStr is NULL) then
	    DateS := to_char (sysdate, 'YYYY MM DD HH24:MI:SS');
	else
	    DateS := DateStr;
	end if;

	if (Type = 'SYST') then
	    AlarmTxt := 3;
	else
	    AlarmTxt := 1;
	end if;

	if (Type = 'BOUCLE') then
	    if (EquCapture = 'IS') then
		AlarmCl := 'IS';
	    else
		AlarmCl := 'IP2';
	    end if;
	elsif (Type = 'SERIE') then
	    AlarmCl := 'IS_S';
	elsif (Type = 'TRAP')  then	-- Temporaire, ce type va dispara�tre
		AlarmCl := 'TRAPS';
	   else
	    	AlarmCl := Type;	-- ex. Type = 'TRAPG' ou 'TRAPS' ou autre
	   end if;

	insert into ALARM (alarm_id, alarm_num, alarm_cl, alarm_numobj, alarm_date, alarm_grave, 
			   alarm_local, alarm_numal, alarm_commut, alarm_texte, alarm_info, 
			   alarm_comment) 
	    values
	    (SEQ_ALARM.NEXTVAL, SEQ_ALARM.CURRVAL, AlarmCl, NumObj, DateS, Grave, 
	     1, Numal, 0, AlarmTxt, Info, IANA);
	commit;

END	SetAlarm;
/


CREATE OR REPLACE PROCEDURE ResetAlarm
(
	DateStr	VARCHAR2,	-- Date et heure de la fin de l'alarme, au format normalis� :
				-- 'YYYY MM DD HH:MN:SS'
				-- ou ''. Dans ce cas, la date et heure syst�me seront prises par d�faut
	Type	VARCHAR2,	-- 'BOUCLE', 'SERIE', 'TRAPG', 'TRAPS' ou 'SYST'
	EquCapture VARCHAR2,	-- Nom du type de l'�quipement de capture (aujourd'hui 'IS', 'IP2PORTS')
	NumObj	NUMBER,		-- N� de l'�quipement de capture auquel l'�l�ment g�r� est raccord�
				-- pour les alarmes 'BOUCLE' et 'SERIE'
				-- N� de trap pour les alarmes 'TRAP'
	NumAl	VARCHAR2,	-- N� de l'acc�s sur l'�quipement de capture, auquel l'�l�ment g�r� est raccord�
				-- (alarmes 'BOUCLE'. Pour les 'IS' : (n� carte -1) * 48 + n� acc�s sur la carte)
				-- N� du bit d'alarme dans le message s�rie, pour les alarmes 'SERIE'
				-- (Pour les 'IS' : ((n� carte -1) * 8 + (n� acc�s sur la carte -1)) *10000 + n� bit)
				-- Adresse IP de l'�l�ment g�r� pour les 'TRAP'
				-- Identifiant de l'alarme pour les alarmes 'SYST'
	Info	VARCHAR2,	-- Pour les 'TRAP' : champ "variable" du trap ("VarBinds"), cod� ainsi :
				-- OID1 = Valeur1;OID2 = Valeur2; etc....
				-- Pour les alarmes 'SYST' : message d'alarme syst�me
				-- limit� � 256 caract�res
	IANA	VARCHAR2	-- Pour les 'TRAP', n� IANA attribu� au fabricant de l'agent
)
IS

BEGIN   

	if (NOT TestAlarm (Type, EquCapture, NumObj, NumAl, IANA)) then
	    return;
	end if;			-- l'alarme n'est pas en cours

	SetAlarm (0, DateStr, Type, EquCapture, NumObj, Numal, Info, IANA);
END	ResetAlarm;
/



create or replace trigger TIB_SITE before insert on SITE for each row
when (new.SITE_DOMAINE is not null and new.site_emname is not null)
begin
	/* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
	   on ne fait pas le traitement */
	if dbms_reputil.from_remote=TRUE then
		return;
	end if;

	insert into MESSEM (MESSEM_ID, MESSEM_MESS)
	values (seq_messem.NEXTVAL, '#9#6#6#C#' || to_char (:new.site_id) || '#');
end;
/


create or replace trigger TUB_SITE before update on SITE for each row
when 
(((old.SITE_DOMAINE is null or old.site_emname is null)	
 and new.SITE_DOMAINE is not null and new.site_emname is not null) or
(old.SITE_DOMAINE != new.SITE_DOMAINE or old.SITE_EMNAME != new.SITE_EMNAME) or
((new.SITE_DOMAINE is null or new.site_emname is null)
 and old.SITE_DOMAINE is not null and old.site_emname is not null))

begin
	/* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
	   on ne fait pas le traitement */
	if dbms_reputil.from_remote=TRUE then
		return;
	end if;

	insert into MESSEM (MESSEM_ID, MESSEM_MESS)
	values (seq_messem.NEXTVAL, '#9#6#6#M#' || to_char (:new.site_id) || '#');
end;
/


create or replace trigger TDB_SITE before delete on SITE for each row
when (old.SITE_DOMAINE is not null and old.site_emname is not null)
begin
	/* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
	   on ne fait pas le traitement */
	if dbms_reputil.from_remote=TRUE then
		return;
	end if;

	insert into MESSEM (MESSEM_ID, MESSEM_MESS)
	values (seq_messem.NEXTVAL, '#9#6#6#S#' || to_char (:old.site_id) || '#');
end;
/


-- X.L. cr�ation le 06/06/04
-- X.L. Supprim� le 14/04/08 car tout ce qui concerne la table ORDRE n'est plus mis � jour.
-- D'autre part il existe un nouveau trigger ti_topliai sur la table TOP_LIAI et avec la
-- r�plication il ne doit exister qu'un seul trigger TI par table.
--CREATE OR REPLACE TRIGGER ti_top_liai AFTER INSERT ON top_liai FOR EACH ROW
--DECLARE
--	CURSOR CurOrdre IS
--		SELECT ordre_debitecr, ordretop_num, ordretop.ordre_id
--		FROM ordre, ordretop
--		WHERE top_id = :new.top_id
--		AND ordre.ordre_id = ordretop.ordre_id
--		AND ordre_etat = 1;				-- Etat r�serv�
--BEGIN
--	/* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
--	   on ne fait pas le traitement */
--	if dbms_reputil.from_remote=TRUE then
--		return;
--	end if;
--
--	-- Pour chaque liaison appartenant � un ordre dans l'�tat r�serv�, il faut
--	-- r�server la bande passante n�cessaire
--	FOR rCurOrdre IN CurOrdre LOOP
--		INSERT INTO liaireser (liaireser_id, liai_id, liaireser_debit, ordre_id, ordretop_num)
--		VALUES (seq_liaireser.NEXTVAL, :new.liai_id, rCurOrdre.ordre_debitecr, rCurOrdre.ordre_id,
--			rCurOrdre.ordretop_num);
--	END LOOP;
--END ti_top_liai;
--/


/*
-- X.L. cr�ation le 06/06/04
CREATE OR REPLACE TRIGGER tdb_top_liai BEFORE DELETE ON top_liai FOR EACH ROW
DECLARE
	CURSOR CurOrdre IS
		SELECT ordre_debitecr, ordretop_num, ordretop.ordre_id
		FROM ordre, ordretop
		WHERE top_id = :old.top_id
		AND ordre.ordre_id = ordretop.ordre_id
		AND ordre_etat = 1;				-- Etat r�serv�
BEGIN
	
	if dbms_reputil.from_remote=TRUE then
		return;
	end if;

	-- Pour chaque liaison appartenant � un ordre dans l'�tat r�serv�, il faut
	-- lib�rer la bande passante r�serv�e
	FOR rCurOrdre IN CurOrdre LOOP
		DELETE liaireser 
		WHERE ordre_id = rCurOrdre.ordre_id
		AND liai_id = :old.liai_id
		AND ordretop_num = rCurOrdre.ordretop_num;
	END LOOP;
END tdb_top_liai;
/
*/






/* ZN 13/01/06
	
	Ce trigger remplit le champ mibenum_nom si il est vide
*/
create or replace trigger tib_mibenum before insert on MIBENUM for each row
when (new.mibenum_nom is null)	

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);

begin
    /* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
       on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
		return;
    end if;

    :new.mibenum_nom := :new.mibenum_name;

--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end  tib_mibenum; 
/

/*
--Cr�� par ZN le 06/11/07 
create or replace Procedure ModifProgTop(TopId NUMBER, ProgId NUMBER, Val NUMBER)
is
  CURSOR cLiai IS
		SELECT liai_id FROM top_liai
		WHERE TOP_ID = TopId;
		
	CURSOR cTop IS
		SELECT childtop_id FROM top_top
		WHERE TOP_ID = TopId;
		
begin
    for rLiai in cLiai loop
	     MajDebitLiai (rLiai.liai_id, ProgId, Val);
    end loop;
    
    for rTop in cTop loop
	     ModifProgTop (rTop.childtop_id, ProgId, Val);
   end loop;

end ModifProgTop;
/



-- Cr�� par ZN le 16/10/07 
-- Modif. ZN le 6/11/07 prend en compte d'inclusion des topologies
create or replace trigger ti_progtop after insert on PROG_TOP for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    Mess     VARCHAR2 (1800);-- taille max. du message autoris� par Oracle : 1800 octets 

		
begin
    
    if dbms_reputil.from_remote=TRUE then
		return;
    end if;

  
    
    ModifProgTop(:new.TOP_ID, :new.prog_id, 1);
    
--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end ti_progtop;
/


--Cr�� par ZN le 06/11/07 
create or replace Procedure ModifTopLiai(TopId NUMBER, LiaiId NUMBER, Val NUMBER)
is
  CURSOR cProg IS
		SELECT prog_id FROM prog_top
		WHERE TOP_ID = TopId;
		
	CURSOR cTop IS
		SELECT TOP_ID FROM top_top
		WHERE  childtop_id = TopId;
		
begin
    for rProg in cProg loop
	      MajDebitLiai (LiaiId, rProg.prog_id, Val);
    end loop;
    
    for rTop in cTop loop
	     ModifTopLiai (rTop.TOP_ID, LiaiId, Val);
   end loop;

end ModifTopLiai;
/

-- Cr�� par ZN le 16/10/07 
-- Modif. ZN le 6/11/07 prend en compte d'inclusion des topologies
create or replace trigger ti_topLiai after insert on TOP_LIAI for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    Mess     VARCHAR2 (1800);--taille max. du message autoris� par Oracle : 1800 octets 

		
begin
    
    if dbms_reputil.from_remote=TRUE then
		return;
    end if;

      
    ModifTopLiai (:new.TOP_ID, :new.liai_id, 1);
    
--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end ti_topLiai;
/



-- Cr�� par ZN le 16/11/07 
-- Modif. ZN le 6/11/07 prend en compte d'inclusion des topologies
create or replace trigger tdb_progtop before delete on PROG_TOP for each row

declare

		
begin
   
    if dbms_reputil.from_remote=TRUE then
		return;
    end if;

     
    ModifProgTop(:old.TOP_ID, :old.prog_id, -1);
      
end tdb_progtop;
/

-- Cr�� par ZN le 16/11/07 
-- Modif. ZN le 6/11/07 prend en compte d'inclusion des topologies
create or replace trigger tdb_topliai before delete on TOP_LIAI for each row

declare

		
begin
    
    if dbms_reputil.from_remote=TRUE then
		return;
    end if;

     
    ModifTopLiai (:old.TOP_ID, :old.liai_id, -1);
    
end tdb_topliai;
/

-- Cr�� par ZN le 15/11/07 
create or replace trigger tiub_liai_topsrc_topdst before insert or update on liai_topsrc_topdst for each row
declare 
  nbr NUMBER;
  
begin

  
	if dbms_reputil.from_remote=TRUE then
		return;
	end if;
	
	nbr :=0;
	if(:new.fatherclass_id=1006) then --prog
	 select count(*) into nbr from prog where prog_id=:new.father_id;
	 if(nbr<1) then
	   	raise_application_error (-20000, 'Programme n''existe pas.');
    end if;
	end if; --1006

  if(:new.fatherclass_id=1049) then --top
    select count(*) into nbr from top where top_id=:new.father_id;
  	if(nbr<1) then
	   	raise_application_error (-20000, 'Topologie n''existe pas.');
    end if;
	end if; --1049
	
end tiub_liai_topsrc_topdst;
/
*/
--======================================================
-- JL - le 10/09/2007.
-- Trigger qui agit � la modification de la table PARAM.
-- ZN Modif. 21/11/2007 --traitement des programmes seulement si ALARM_SERVICE
-- est chang�e.
-- Utilisation de la table param_histo, parce que 
-- GETMODCALC appel�e par VerifAlarmEnCours\INSERTALARM\TI_ALARM\POSTALRM\...
-- ne peut pas ouvrir la table param, reserv�e par ce trigger
 
--======================================================
CREATE OR REPLACE TRIGGER tiu_param after insert or update on PARAM  for each row
DECLARE

-- Recherche tous les programmes non active.    
/*  CURSOR curGetAllProg IS
    SELECT prog_id FROM PROG where prog_actif=0;*/
    
    cnt NUMBER;

BEGIN

-- Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
--  on ne fait pas le traitement 
	   
	if dbms_reputil.from_remote=TRUE then
		return;
	end if;
	
	--VerifActifProg;
	
  if(:new.PARAM_TYPE = 9 and :new.PARAM_VALEUR<>:old.PARAM_VALEUR) then
    if( :new.PARAM_VALEUR='ALARM_SERVICE=0')then
      --insert into test values(seq_test.nextval, 'ALARM_SERVICE=0');
     
     select count(*) into cnt from param_histo;
     if(cnt>0) then
        update param_histo set	alarm_service_changed =1;
     else
        insert into param_histo values (1);
     end if;
     
   /*   FOR valGetAllProg IN curGetAllProg LOOP
        UPDATE prog SET prog_actif = 1 where prog_id=valGetAllProg.prog_id;
          -- Mise � jours des alarmes en cours.
        VerifAlarmEnCours(valGetAllProg.prog_id);
      END LOOP;
      
    elsif ( :new.PARAM_VALEUR='ALARM_SERVICE=1')then
     -- insert into test values(seq_test.nextval, 'ALARM_SERVICE=1');
      VerifActifProg(1);*/
    end if;
  end if;
 
END tiu_param;
/

/* create or replace trigger td_topcabl after delete on TOP_CABLEQU for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);

begin

    --traitement � effectuer sur les DEUX serveurs (s�paration alarme/structure) 
    delete TOP_CABLEQU_REP 
	where TOP_ID = :old.top_id and
	      CABLEQU_ID = :old.cablequ_id;

   --Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
   --on ne fait pas le traitement 
    if dbms_reputil.from_remote=TRUE then
	return;
    end if;

--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end td_topcabl;
/


create or replace trigger ti_topcabl after insert on TOP_CABLEQU for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);

begin

    -- traitement � effectuer sur les DEUX serveurs (s�paration alarme/structure) 
    insert into TOP_CABLEQU_REP (top_id, cablequ_id, grave)
	values (:new.top_id, :new.cablequ_id, 0);

    -- Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
    -- on ne fait pas le traitement 
    if dbms_reputil.from_remote=TRUE then
	return;
    end if;

--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end ti_topcabl;
/
*/
--=====================================================================================
-- Cr�ation ZN le 09/01/08

--=====================================================================================
CREATE OR REPLACE TRIGGER tdb_alarm BEFORE DELETE ON alarm FOR EACH ROW
BEGIN

  delete alarm_prog where alarm_id= :old.alarm_id;
  delete trapalarm where alarm_id= :old.alarm_id;
  
	/* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
	   on ne fait pas le traitement */
	if dbms_reputil.from_remote=TRUE then
		return;
	end if;	
	
END tdb_alarm;
/

--=====================================================================================
-- Cr�ation ZN le 13/06/08

create or replace trigger tdb_prog BEFORE delete on PROG for each row
begin

    /* traitement � effectuer sur les DEUX serveurs (s�paration alarme/structure) */
	delete alarm_prog where prog_id=:old.prog_id;

    /* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
    on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
	return;
    end if;

end td_prog;
/


create or replace
TRIGGER tiub_alarmgeree before insert or update on ALARMGEREE for each row
declare
    integrity_error  exception;
    nb_rel           integer;     -- nombre de relations avec autres tables
    ExistType	     boolean;

    strTable	VARCHAR2(30);
    lObjetId	NUMBER;

begin
	strTable := AlarmgereeGetFather (:new.ACCES_ID, lObjetId);

	:new.ALARMGEREE_UNICITE := AccesCalculUnicite (lObjetId, strTable, :new.ALARMGEREE_NOM);

end tiub_alarmgeree;
/


----------------------------------------------------------------------------------------
-- La table LICENCE est encore exploit�e par EmessEM
-- Modif. X.L. le 27/10/09 suppression de TU_LICENCE
----------------------------------------------------------------------------------------

----------------------------------------------------------------------------------------
-- La table LICENCE est encore exploit�e par EmessEM
-- Modif. X.L. le 27/10/09 suppression de TD_LICENCE
----------------------------------------------------------------------------------------


-- La suppression du type d'�quipement syst�me EQUIP MEDIATION est interdite
create or replace
trigger TD_TYPEQ after delete on TYPEQ for each row
begin
	if (:old.typeq_id = 3) THEN
        	raise_application_error (-20000, 'EQUIP MEDIATION is a system equipment type, we cannot erase it');
    	end if;
end TD_TYPEQ;
/