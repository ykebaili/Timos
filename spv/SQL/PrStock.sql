--========================================================================================
--
-- La proc�dure SetTrace n'est exploitable qu'� partir de la version 8i de la bdd
-- elle permet d'inscrire, � partir d'un programme PL/SQL, des traces dans la table TRACE
-- m�me si ce programme n'inclut pas de commit.
--
--========================================================================================
CREATE OR REPLACE PROCEDURE SetTrace (Message VARCHAR2) IS
	PRAGMA AUTONOMOUS_TRANSACTION;
BEGIN
	INSERT INTO trace VALUES (seq_trace.NEXTVAL, Message);
	COMMIT;
END;
/

create or replace FUNCTION GetFormatDateString RETURN VARCHAR2 AS
BEGIN
  RETURN 'YYYY MM DD HH24:MI:SS';
END GETFORMATDATESTRING;
/



CREATE OR REPLACE FUNCTION BoolToChar (bool BOOLEAN)
RETURN VARCHAR2
IS
BEGIN
  if(bool) then
    return 'TRUE';
  else
    return 'FALSE';
  end if;
END;
/

--========================================================================================
--
-- La proc�dure SetErreurApp n'est exploitable qu'� partir de la version 8i de la bdd
-- elle permet d'inscrire, � partir d'un programme PL/SQL, les erreurs applicatives
-- dans la table  ERREURAPP m�me si ce programme n'inclut pas de commit.
--
--========================================================================================
CREATE OR REPLACE PROCEDURE SetErreurApp (Module VARCHAR2, Message VARCHAR2) IS
	PRAGMA AUTONOMOUS_TRANSACTION;
BEGIN
	INSERT INTO erreurapp VALUES (seq_erreurapp.NEXTVAL, SYSDATE, Module, Message);
	COMMIT;
END;
/




--===================================================================================
--
--	API li�es � la fiche
--	Cr��s par JPB 2001
--	Modif. par ZN 2005
--	Modif. par JPB le 31/08/2006 :
--	    Suite au traitement des contr�les, simplification des API.
--	    Le traitement des GetFromForm***  est fait dans GetFromFormIdO, qui utilise
--  	    l'Id de l'�l�ment, l'Id de l'onglet et un param�tre pour indiquer si l'on sort la valeur ou le code d'une combo.
--	    Les autres doivent appeler ce traitement.
--
--===================================================================================

CREATE OR REPLACE FUNCTION GetStr (Val VARCHAR2, Indx NUMBER, Sep VARCHAR2)
RETURN VARCHAR2
/*
   Recherche une sous-cha�ne dans une cha�ne (1024 car. max.).
   Les sous-cha�nes sont s�par�es par le caract�re 'Sep'. La cha�ne doit se terminer par 'Sep'.
   L'index de la sous-cha�ne part de 0.
   Retourne la sous-cha�ne ou '' si non trouv�e.
*/

IS
    Res		VARCHAR2 (1024);/* r�sultat */
    Suiv	VARCHAR2 (1024);/* suite de la cha�ne */
    Pos		NUMBER;		/* position de Sep dans la cha�ne */
    i		NUMBER;

BEGIN
    Suiv  := Val;

    for i in 0..Indx loop
	Pos := INSTR (Suiv, Sep);
	if (Pos = 0) then
	    return '';
	end if;
	
	Res  := SUBSTR (Suiv, 1, Pos -1);
	Suiv := SUBSTR (Suiv, Pos +1);
    end loop;

    return Res;
END	GetStr;
/

--------------------------------------------------------------------------------------
-- Recherche l'ID d'un �l�ment dans une table, � partir du nom de la table et du
-- nom de l'�l�ment dans cette table. Ceci pour un �l�ment dot� d'une fiche.
--
-- Met � jour EltId si l'�l�ment est trouv�, retourne alors TRUE,
-- retourne FALSE autrement.
--
-- X.L. cr�ation le 04/12/03
--
-- Renomm� par JPB en GetEltNom : toutes les API se terminant en Id s'appellent par l'Id
-- et pas par le nom.

-- Modif JPB le 24/05/04 : Le traitement de la table ACCES ne tenait pas compte des acc�s d'�quipements
--
-- Modif X.L. le 27/12/04 pour tenir compte des types de sites
--
-- Modif X.L. le 08/08/07 pour tenir compte de la modification de d�signation des �quipements
-- dans l'�tiquette d'une vue. Le nom pass� doit �tre conforme � ce choix (0 = par r�f�rence,
-- 1 = par position g�ographique, 2 = par commentaire, 3 par adresse IP + index SNMP)
-- Quand c'est par position g�ographique, le nom doit int�grer le site et la salle.
--------------------------------------------------------------------------------------

-- NOTE : en raison de la structure de ACCES, on ne sait pas d�signer par son nom
--	  l'acc�s d'un �quipement (il porte le m�me nom que l'acc�s du type d'�quipement
--	  correspondant). Cette proc�dure retourne la valeur du champ de l'ACCES DU TYPE.
--

create or replace
FUNCTION GetEltNom
(
 TableNom	VARCHAR2,		-- Nom de la table o� est enregistr� l'�l�ment
 EltNom		VARCHAR2,		-- Nom de l'�l�ment recherch� dans la table
 EltId OUT	NUMBER			-- ID de l'�l�ment � renseigner
)
RETURN BOOLEAN IS

    bRet BOOLEAN;			-- Valeur de retour
BEGIN

    bRet := TRUE;
    if (TableNom = 'TYPSITE') then
	select TYPSITE_ID into EltId from TYPSITE
	    where TYPSITE_NOM = EltNom;

    elsif (TableNom = 'SITE') then
	select SITE_ID into EltId from SITE
	    where SITE_NOM = EltNom;

    elsif (TableNom = 'TYPEQ') then
	select TYPEQ_ID into EltId from TYPEQ
	    where TYPEQ_NOM = EltNom;

    elsif (TableNom = 'EQUIP') then
	select EQUIP_ID into EltId from EQUIP
	    where EQUIP_REF = EltNom and
		EQUIP_ETIQ_VUE = 0
	union
	select EQUIP_ID from EQUIP, BAIE, SITE, SALLE
	    where
SITE_NOM ||' '|| SALLE_NOM || ' T: ' || SALLE_BAIE_TRAV ||' C: ' || SALLE_BAIE_CADRE ||' N: '||
BAIE_EQUIP_NICHE || ' E: ' || BAIE_EQUIP_EMPL || ' C: '||BAIE_EQUIP_CARTE = EltNom and
		EQUIP.BAIE_ID = BAIE.BAIE_ID and
		EQUIP.SITE_ID = SITE.SITE_ID and
		BAIE.SALLE_ID = SALLE.SALLE_ID and
		EQUIP_ETIQ_VUE = 1
	union
	select EQUIP_ID from EQUIP
	    where SITE_EQUIP_COMMENT = EltNom and
		EQUIP_ETIQ_VUE = 2
	union
	select EQUIP_ID from EQUIP
	    where EQUIP_ADDRIP || ' ' || EQUIP_INDEXSNMP = EltNom and
		EQUIP_ETIQ_VUE = 3;
    elsif (TableNom = 'TYPLIAI') then
	select TYPLIAI_ID into EltId from TYPLIAI
	    where TYPLIAI_NOM = EltNom;

    elsif (TableNom = 'LIAI') then
	select LIAI_ID into EltId from LIAI, EXT A, EXT B
	    where A.EXT_ID = LIAI_EXTAID and
		  B.EXT_ID = LIAI_EXTBID and
		  A.EXT_VILLE||'.'||A.EXT_POINT||decode (LIAI_DIR, 0, ' -> ', 1, ' <- ',
		  ' <-> ')||B.EXT_VILLE||'.'||B.EXT_POINT||' '||LIAI_NUM = EltNom;

    elsif (TableNom = 'TYPPROG') then
	select TYPPROG_ID into EltId from TYPPROG
	    where TYPPROG_NOM = EltNom;

    elsif (TableNom = 'PROG') then
	select PROG_ID into EltId from PROG
	    where PROG_NOM = EltNom;

    elsif (TableNom = 'CLIENT') then
	select CLIENT_ID into EltId from CLIENT
	    where CLIENT_NOM = EltNom;

   /* elsif (TableNom = 'PERIF') then
	select PERIF_ID into EltId from PERIF
	    where PERIF_NOM = EltNom;*/

    elsif (TableNom = 'ALARMGEREE') then
	select ALARMGEREE_ID into EltId from ALARMGEREE
	    where ALARMGEREE_NOM = EltNom;

    elsif (TableNom = 'SCRIPT') then
	select SCRIPT_ID into EltId from SCRIPT
	    where SCRIPT_NOM = EltNom;

    elsif (TableNom = 'ACCES') then
	select ACCES_ID into EltId from ACCES
	    where ACCES_NOM = EltNom and TYPEQ_ID is not null;

    else
	bRet := FALSE;
    end if;

    return bRet;
END	GetEltNom;
/



/*
	Cette fonction retourne le d�bit de la liaison, en b/s
	Retourne -1 si erreur
*/
CREATE OR REPLACE FUNCTION GetDebitLiai
(
    LiaiId	NUMBER		-- Id liaison
)
RETURN NUMBER

IS
    DebitLu	NUMBER;		-- d�bit lu
    DebitU	NUMBER;		-- unit�

BEGIN
    select LIAI_DEBIT, LIAI_UDEBIT into DebitLu, DebitU
	from LIAI
	where LIAI_ID = LiaiId;

    if (DebitU = 0) then
	return (DebitLu);
    elsif (DebitU = 1) then
	return (DebitLu * 1000);
    elsif (DebitU = 2) then
	return (DebitLu * 1000000);
    elsif (DebitU = 3) then
	return (DebitLu * 1000000000);
    end if;

    return (-1);    
END	GetDebitLiai;
/



--============================================================================
--	Fin des API "D�bit" et "Bande passante"
--============================================================================



--==============================================================================================
--
-- Modif. X.L. le 10/09/99
-- 
-- Concerne les proc�dures DelEntiteSerie et Del1Acces pour compl�ter le traitement
-- dans le cas o� l'effacement est cons�cutif � la suppression d'un �quipement
--
-- Modif JPB le 01/08/00
-- Pour tenir compte des modifications de la BDD (suppression de tables inutiles)
--
-- ModifJP Borg	: 28/02/02	Voir version 1.073
--
--==============================================================================================



--==============================================================================================
--
-- Cette fonction renvoie la valeur du param�tre demand� de la table PARAM
--
-- X.L. Cr�ation le 18/10/06
--
--==============================================================================================
CREATE OR REPLACE FUNCTION GetParamValue
(
 ParamName	VARCHAR2
)
RETURN VARCHAR2
IS
	Pos	NUMBER;				-- Position du caract�re = dans le param�tre lu en table
	Val	PARAM.PARAM_VALEUR%TYPE;	-- Valeur du param�tre

	CURSOR CParam IS
		SELECT param_valeur FROM param WHERE param_type = 9 AND param_valeur like ParamName || '%';

BEGIN
	IF ParamName IS NULL THEN
		RETURN NULL;
	END IF;

	Val := NULL;
	Pos := 0;

	FOR rCParam IN CParam LOOP
		Pos := INSTR (rCParam.param_valeur, '=');

		IF Pos = 0 THEN		-- Pas de valeur pour le param�tre
			RETURN NULL;
		END IF;

		Val := RTRIM (SUBSTR (rCParam.param_valeur, Pos + 1));
		
		EXIT;
	END LOOP;

	RETURN Val;
		
END GetParamValue;
/




--------------------------------------------
--
-- Cette fonction v�rifie que les caract�res d'une cha�ne appartiennent � un ensemble donn�
-- Retourne 1 si OK, 0 sinon.
--
-- JPB  Cr�ation le 05/01/03
---------------------------------------------
/*
* CheckStr
*/
CREATE OR REPLACE FUNCTION CheckStr
(
    lStr VARCHAR2,	-- Cha�ne � tester
    lSet VARCHAR2	-- Ensemble des caract�res autoris�s
)
RETURN NUMBER
IS
    Len	NUMBER;		-- Longueur de lStr
    i	NUMBER;		-- Banal
    Car VARCHAR2 (5);	-- Caract�re lu

BEGIN

    Len := LENGTH (lStr);
    for i in 1..Len loop
	Car := SUBSTR (lStr, i, 1);
	if (INSTR (lSet, Car) <= 0) then
	    return 0;
	end if;
    end loop;

    return 1;
END	CheckStr;
/


/*
* ValidNbr
*/
CREATE OR REPLACE FUNCTION ValidNbr (Val VARCHAR2, Mini NUMBER, Maxi NUMBER)
RETURN NUMBER	
/*
   V�rifie la validit� d'un nombre.
   Retourne sa valeur si OK, -1 sinon
*/

IS
   Nombre	NUMBER;		/* r�sultat */
   Longueur	NUMBER;		/* longueur de la cha�ne de caract�res */
   Car		CHAR;		/* caract�re � la position i */
   i		NUMBER;

BEGIN

   Nombre := to_number (Val);
   if (Nombre < Mini or Nombre > Maxi) then
   	return -1;
   end if;

   return Nombre;

EXCEPTION
    WHEN OTHERS THEN
	return -1;
END ValidNbr;
/


--==============================================================================--
--										--
-- Recherche le ClassID d'un Objet dans la base SPV afin de trouver le nom	--
-- de la table de cet Objet.							--
--										--
-- Cr�ation JFL le 22/02/05							--
-- MAJ      JFL le 16/05/05 : prise en compte des tables 'ARCH%' (PB classId).	--
-- 										--
--	Retourne  '<nom table>' = nom de la table trouv�e			--
--	Retourne  'NULL' 	= aucune nom de table trouv� pour ce CLASSID	--
--										--  
-- X.L. le 06/06/05 R�tablissement d'une modif. port�e sur la version 2.116b	--
-- �cras�e par la suite : les variables Result, NomTable, NomColTmp et NomCol	--
-- passent � 40 caract�res. En effet le nom d'une table fait au plus 30		--
-- caract�res, donc celui d'une colonne est forc�ment plus grand. Fiche F023	--
-- TDF.										--
-- X.L. le 03/08/07 : l'ajout de la table ERRIMP et le fait que ERRIMP_CLASSID  --
-- pouvait contenir des classid d'autres tables comme la table SITE (ce qui est --
-- normal) faisait que le nom de la table SITE n'�tait pas retourn� pour le     --
-- classid 1008 (c'est ERRIMP qui �tait retourn� � la place).                   --
--==============================================================================--
CREATE OR REPLACE FUNCTION GetTableNom
(
    BddClassID	NUMBER		-- ClassId Objet
)
RETURN VARCHAR2 IS

    Result	VARCHAR2(40);
    NomTable	VARCHAR2(40);
    NomColTmp	VARCHAR2(40);
    NomCol	VARCHAR2(40);

    -- SQL DYN
    OrdreSql   	varchar2(1000);
    CDynId	int;
    RetCDyn	int;
    NbClassId	number;

    cursor curNomTables is
	select TABLE_NAME
	from USER_TABLES
	order by TABLE_NAME;

    cursor curNomCol is
	select COLUMN_NAME
	from USER_TAB_COLUMNS
	where TABLE_NAME = NomTable
	and COLUMN_NAME  = NomColTmp;
BEGIN

    Result := 'NULL';

    -- Liste des tables de l'utilisateur.
    FOR rCurNomTables  IN curNomTables  LOOP
	NomTable := rCurNomTables.TABLE_NAME;

	IF (NomTable IS NULL) THEN
	    EXIT;
	END IF;

	NomTable  := upper(NomTable);
	NomColTmp := NomTable || '_CLASSID';
	NomCol    := '';

	-- Table avec colonne %_CLASSID?
	FOR rCurNomCol IN curNomCol LOOP
	    NomCol := rCurNomCol.COLUMN_NAME;
	    EXIT;
	END LOOP;

	IF (NomCol IS NOT NULL) THEN

	    -- Cr�ation ordre SQL simple pour voir si le CLASSID
	    -- pass� en param�tre est issu de cette table.

	    OrdreSql := 'Select count(*) from ' || NomTable || ' Where ' ||
			NomCol || ' = ' || BddClassID;
		
	    CDynId := dbms_sql.open_cursor;

	    -- Init.
	    dbms_sql.parse (CDynId, OrdreSql, dbms_sql.native);
	    dbms_sql.define_column (CDynId, 1, NbClassId);

	    RetCDyn := dbms_sql.execute(CDynId);

    	    IF (dbms_sql.fetch_rows (CDynId) > 0) THEN

		dbms_sql.column_value (CDynId, 1, NbClassId);

		-- CLASSID trouv�?
		IF (NbClassId > 0 and NomTable not like 'ARCH%' and NomTable != 'ERRIMP') THEN
		    Result := NomTable;
		    EXIT;

		END IF;

	    END IF;

	    dbms_sql.close_cursor (CDynId);

	END IF;

    END LOOP;

    return Result;

END GetTableNom;
/


--==============================================================================--
--										--
-- Recherche si une table poss�de bien une colonne qui porte le nom pass�	--
-- en param�tre.								--
--										--
-- Cr�ation JFL le 22/02/05							--
--										--
--	Retourne  '<nomCol>' = colonne existante				--
--	Retourne  'NULL'     = colonne inexistante				--
--										--   
--==============================================================================--
CREATE OR REPLACE FUNCTION CheckNomCol
(
    NomTable	VARCHAR2,	-- table
    NomCol	VARCHAR2	-- Colonne � chercher
)
RETURN VARCHAR2 IS

    Result	VARCHAR2(30);

    cursor curNomCol is
	select COLUMN_NAME
	from USER_TAB_COLUMNS
	where TABLE_NAME = NomTable
	and COLUMN_NAME  = NomCol;
BEGIN
    
    FOR rCurNomCol IN curNomCol LOOP
	Result := rCurNomCol.COLUMN_NAME;
	EXIT;
    END LOOP;

    IF (Result IS NULL) THEN
	Result := 'NULL';
    END IF;

    return Result;

END CheckNomCol;
/




---------------------------------------------------------------------------------------
-- Donne le nom d'un objet � partir de son ID
--
-- X.L. Cr�ation le 19/04/05
--
CREATE OR REPLACE FUNCTION GetObjNameFromObjId
(
 ObjetType	VARCHAR2,		-- Type de l'objet (ex: 'SITE')
 ObjetId	NUMBER			-- ID de l'objet
)
RETURN VARCHAR2 IS
	CursorName	NUMBER;			-- Num�ro du curseur dynamique
	SelOrder	VARCHAR2 (200);		-- Ordre SQL dynamique
	ObjetNom	VARCHAR2 (80);
	Result		NUMBER;			-- R�sultat de la requ�te dynamique
BEGIN
	SelOrder := 'select ' || ObjetType || '_NOM from ' || ObjetType ||
			' where ' || ObjetType || '_id = :ObjId';

	CursorName := DBMS_SQL.OPEN_CURSOR;
	DBMS_SQL.PARSE (CursorName, SelOrder, dbms_sql.native);
	DBMS_SQL.DEFINE_COLUMN (CursorName, 1, ObjetNom, 80);
	DBMS_SQL.BIND_VARIABLE (CursorName, ':ObjId', ObjetId);
	Result := DBMS_SQL.EXECUTE_AND_FETCH (CursorName);	 -- Une seule rang�e attendue
	DBMS_SQL.COLUMN_VALUE (CursorName, 1, ObjetNom);
    	DBMS_SQL.close_cursor (CursorName);

	RETURN ObjetNom;
END GetObjNameFromObjId;
/




-------------------------------------------------------------------------------------------
--
--	Conversions de date
--	JPB Cr�ation
-------------------------------------------------------------------------------------------

CREATE OR REPLACE FUNCTION CO_SEC1998 (Val VARCHAR2)
RETURN NUMBER	
/* 
   Convertit une date de d�but ou fin d'alarme (YYYY MM DD HH24:MI:SS) 
   en nombre de secondes depuis le 01/01/1998 00:00:00.
   Conversion valable jusqu'au 29/02/2020.
   Apr�s, on sera mort, pr�parer le bug de l'an 2020 et du travail pour nos successeurs !

   Retourne -1 si la date est incorrecte.
   
   Modif le 26 Mai 2002, pour remplacer Year, Month etc.. par An, Mois etc.., car 
   Oracle a r�serv� ces noms dans la version 8.1 !!
*/

IS
    An		NUMBER;	/* ann�e   1998 - 2020 */
    Mois	NUMBER; /* mois    1 - 12 */
    Jour	NUMBER; /* jour    1 - 31 */
    Heure	NUMBER; /* heure   0 - 23 */
    Minute	NUMBER; /* minute  0 - 59 */
    Seconde	NUMBER; /* seconde 0 - 59 */
    Result	NUMBER; /* r�sultat */

    TYPE TypMois  IS TABLE OF NUMBER INDEX BY BINARY_INTEGER;
    LMois	TypMois;/* jours depuis le 1 Janvier */

    Str		VARCHAR2 (20);

BEGIN
   
    LMois (1)   :=   0;
    LMois (2)   :=  31;
    LMois (3)   :=  59;
    LMois (4)   :=  90;
    LMois (5)   := 120;
    LMois (6)   := 151;
    LMois (7)   := 181;
    LMois (8)   := 212;
    LMois (9)   := 243;
    LMois (10)  := 273;
    LMois (11)  := 304;
    LMois (12)  := 334;

    An	:= ValidNbr (SUBSTR (Val, 1, 4), 1998, 2020);
    if (An < 0) then
	return -1;
    end if;

    Mois  := ValidNbr (SUBSTR (Val, 6, 2), 1, 12);
    if (Mois < 0) then
	return -1;
    end if;

    Jour  := ValidNbr (SUBSTR (Val, 9, 2), 1, 31);
    if (Jour < 0) then
	return -1;
    end if;

    Heure := ValidNbr (SUBSTR (Val, 12, 2), 0, 23);
    if (Heure < 0) then
	return -1;
    end if;

    Minute := ValidNbr (SUBSTR (Val, 15, 2), 0, 59);
    if (Minute < 0) then
	return -1;
    end if;

    Seconde := ValidNbr (SUBSTR (Val, 18, 2), 0, 59);
    if (Seconde < 0) then
	return -1;
    end if;

    /* Conversion en jours depuis le 1/1/98 */

    Result := (An - 1998) * 365 + LMois (Mois) + Jour -1;

    if ((An = 2000 and Mois > 2) or An > 2000) then
 	Result := Result + 1;	/* 2000 est bissextile */
    end if;
    if ((An = 2004 and Mois > 2) or An > 2004) then
 	Result := Result + 1;
    end if;
    if ((An = 2008 and Mois > 2) or An > 2008) then
 	Result := Result + 1;
    end if;
    if ((An = 2012 and Mois > 2) or An > 2012) then
 	Result := Result + 1;
    end if;
    if ((An = 2016 and Mois > 2) or An > 2016) then
 	Result := Result + 1;
    end if;

    /* Conversion en heures depuis le 1/1/98 */

    Result := Result * 24 + Heure;

    /* Conversion en minutes depuis le 1/1/98 */

    Result := Result * 60 + Minute;

    /* Conversion en secondes depuis le 1/1/98 */

    Result := Result * 60 + Seconde;
    
    return Result;
END CO_SEC1998;
/


create or replace
FUNCTION CO_DATE (Val VARCHAR2)
RETURN DATE	/* Convertit une date de d�but ou fin d'alarme au format date */
IS
    strFormat   VARCHAR2 (40);
BEGIN
    strFormat := GetFormatDateString();
    return TO_DATE (Val, strFormat);

EXCEPTION
    -- when OTHERS then return ('2035 12 31 00:00:00');
    when OTHERS then 
        raise_application_error (-20000, 'CO_DATE function, date format not compliant with ' || strFormat);
END CO_DATE;
/


------------------------------------------------------------------------------------------------
--
-- Masquage ou d�masquage administrateur d'un acc�s alarme d'un �quipement
--
-- Lorsque nMask vaut 2, il s'agit d'un masquage cons�cutif � la cr�ation d'un �quipement;
-- dans ce cas, on met la colonne MSKADM_HOW � 2.
-- Ne traite pas les alarmes SERIE.
--
-- JPB cr�ation le 08/03/04
--
------------------------------------------------------------------------------------------------
CREATE OR REPLACE PROCEDURE SetMaskAdmAccess
(
	lAccesAccescId 	IN NUMBER,	-- ID de l'acc�s (sur ACCES_ACCESC)
	nMask	 	IN NUMBER	-- Masquage si 1 ou 2, d�masquage si 0
)
IS
	Hdeb	acces_accesc2.mskadm_min%TYPE;
	Hfin	acces_accesc2.mskadm_max%TYPE;

BEGIN
	Hdeb := 0;
	HFin := 0;

	IF nMask > 0 THEN
		SELECT CO_SEC1998 (to_char (sysdate, 'YYYY MM DD HH24:MI:SS')) INTO Hdeb FROM dual;
		SELECT CO_SEC1998 ('2020 02 29 00:00:00') INTO Hfin FROM dual;
	END IF;

	-- Masquage des alarmes Trap, Boucle ou GSITE

	UPDATE acces_accesc2
	SET mskadm_min = Hdeb,
	    mskadm_max = Hfin,
	    mskadm_how = nMask
	WHERE acces_accesc2_id = lAccesAccescId;
END SetMaskAdmAccess;
/


------------------------------------------------------------------------------------------------
--
-- Masquage ou d�masquage administrateur des acc�s alarmes d'un �quipement
--
-- Lorsque nMask vaut 2, il s'agit d'un masquage cons�cutif � la cr�ation d'un �quipement;
-- dans ce cas, on met la colonne MSKADM_HOW � 2.
--
-- X.L. cr�ation le 28/11/03
--
------------------------------------------------------------------------------------------------
create or replace
PROCEDURE SetMaskAdmEquip
(
	lEquipId IN NUMBER,		-- ID de l'�quipement
	nMask	 IN NUMBER		-- Masquage si 1 ou 2, d�masquage si 0
)
IS
	Hdeb	acces_accesc2.mskadm_min%TYPE;
	Hfin	acces_accesc2.mskadm_max%TYPE;
BEGIN
	Hdeb := 0;
	HFin := 0;

	IF nMask > 0 THEN
		SELECT CO_SEC1998 (to_char (sysdate, 'YYYY MM DD HH24:MI:SS')) INTO Hdeb FROM dual;
		SELECT CO_SEC1998 ('2020 02 29 00:00:00') INTO Hfin FROM dual;
	END IF;

	-- Masquage des alarmes Trap ou GSITE
	UPDATE acces_accesc2
	SET mskadm_min = Hdeb,
	    mskadm_max = Hfin,
	    mskadm_how = nMask
	WHERE acces_accesc2_id IN (
		SELECT acces_accesc_id
		FROM acces_accesc
		WHERE acces_bindingid = lEquipId
		AND acces_bindingclassid = 8);		-- 8 = connexion � un EDC

	-- Masquage des alarmes boucle
	UPDATE acces_accesc2
	SET mskadm_min = Hdeb,
	    mskadm_max = Hfin,
	    mskadm_how = nMask
	WHERE acces_accesc2_id IN (
		SELECT acces_accesc_id
		FROM acces_accesc, acces
		WHERE acces2_id is not null and acces2_id != 0
		AND acces_id = acces1_id
		AND acces_bindingclassid = 8
		AND acces_accesc.mess_id is null
		AND acces.equip_id = lEquipId);

	-- Masquage des alarmes s�rie
	/*UPDATE bitmess2
	SET mskadm_min = Hdeb,
	    mskadm_max = Hfin,
	    mskadm_how = nMask
	WHERE bitmess2_id in (
		SELECT bitmess_id
		FROM bitmess, acces
		WHERE acces.equip_id = lEquipId
		AND acces.acces_id  = bitmess.acces1_id);*/
END SetMaskAdmEquip;
/




---------------------------------------------
--
-- Fonction de suppression d'un script
--
-- JP. B. Cr�ation le 20/02/01
-- JP. B. Modif le 20/04/03 : suppression d'un script contenant une fiche
--
---------------------------------------------

create or replace
PROCEDURE DelScript
(
 lObjId NUMBER		-- Id du script
)
IS
	lScript	VARCHAR2 (40);

BEGIN
	-- R�servation du script avant effacement.

	SELECT script_nom INTO lScript
	FROM   script WHERE script_id = lObjId FOR UPDATE OF script_nom;

	
	-- Modification des flags du script lui-m�me.
	-- Il sera r�ellement effac� par l'Equipement de M�diation, apr�s
	-- qu'il ait arr�t� les proc�dures activ�es par le script.
	UPDATE script
	SET script_start = 0, script_stop = 1, script_kill = 1
	WHERE script_id = lObjId;

END;
/




---------------------------------------------
--
-- Recherche le nom des diff�rents �l�ments g�r�s c�bl�s sur l'IS NumIS.
-- IS GTR seulement (pour l'instant)
--
-- JPB  Cr�ation le 14/04/99 
--
-- X.L. Modif. le 08/10/99 remplac� EXT_NOM par EXT_VILLE
---------------------------------------------

CREATE OR REPLACE PROCEDURE CABLAGE_IS (NumIS NUMBER) IS
/* Recherche du c�blage des IS */

    AlarmNumal  VARCHAR2 (40);	-- n� acc�s sur l'IS

    IsAccesId	NUMBER;
    OrigAccesId	NUMBER;
    SiteId	NUMBER;
    EquipId	NUMBER;
    LiaiId	NUMBER;

    SiteNom	VARCHAR2 (40);
    SiteLoc	VARCHAR2 (40);
    EquipRef	VARCHAR2 (40);
    EquipNom	VARCHAR2 (40);
    TypeqNom	VARCHAR2 (40);
    LiaiNom	VARCHAR2 (40);

    i		NUMBER;
    trouve	BOOLEAN;

    CURSOR CabP is
    	select ACCES_ID 
	    from ACCES, EQUIP
		where EQUIP_REF = to_char (NumIS) and
	          ACCES_NOM = AlarmNumal and 
		  EQUIP.EQUIP_ID = ACCES.EQUIP_ID;

    CURSOR CAcces is 
        select ACCES1_ID
   	    from ACCES_ACCESC
	    where ACCES2_ID = IsAccesId;

    CURSOR CLieu is
    	select *
 	    from ACCES
	    where ACCES_ID = OrigAccesId;

BEGIN

    for i in 1..384 loop	-- boucle sur tous les NUMAL de l'IS
	AlarmNumal := to_char (i);

    	for vCab in CabP loop	-- boucle sur tous les acc�s IS correspondant � ce NUMAL
				-- normalement, un seul acc�s
	    IsAccesId := vCab.ACCES_ID;
	    trouve := FALSE;

	    for vAcces in CAcces loop
		OrigAccesId := vAcces.ACCES1_ID;

		for vLieu in CLieu loop
		    SiteId   := vLieu.SITE_ID;
		    EquipId  := vLieu.EQUIP_ID;
		    LiaiId   := vLieu.LIAI_ID;

		    trouve := TRUE;
		    exit;
	    	end loop;
	    end loop;

	    SiteNom 	:= '';
	    EquipNom	:= '';
	    LiaiNom	:= '';

	    if (trouve and SiteId is not NULL) then
	    	select SITE_NOM into SiteNom
		    from SITE
		    where SITE_ID = SiteId;
	    end if;

	    if (trouve and EquipId is not NULL) then
	    	select SITE_NOM, TYPEQ.TYPEQ_NOM, SITE_EQUIP_COMMENT
		    into SiteLoc, TypeqNom, EquipRef
		    from EQUIP, SITE, TYPEQ
		    where EQUIP_ID = EquipId and
		      	  TYPEQ.TYPEQ_ID = EQUIP.TYPEQ_ID and
		      	  SITE.SITE_ID   = EQUIP.SITE_ID;
	    	EquipNom := SiteLoc ||' / '|| TypeqNom ||' / '|| EquipRef;
	    end if;

	    if (trouve and LiaiId is not NULL) then
	    	select A.EXT_VILLE || A.EXT_POINT || 
		       decode (LIAI_DIR, 0, ' -> ', 1, ' <- ', ' <-> ') ||
		       B.EXT_VILLE || B.EXT_POINT || ' ' || LIAI_NUM
		    into LiaiNom
		    from LIAI, EXT A, EXT B
		    where A.EXT_ID = LIAI_EXTAID and
		          B.EXT_ID = LIAI_EXTBID and
		          LIAI_ID  = LiaiId;
	    end if;

	    insert into ERROR (ERROR_ID, ERROR_TYP, ERROR_LIBELLE)
	    	values (SEQ_ERROR.NEXTVAL, i, 
		    'SITE : '|| SiteNom || ' EQUIP' || EquipNom || ' LIAI ' ||LiaiNom);

	end loop;	-- boucle sur les acc�s IS
    end loop;		-- boucle sur les NUMAL

    commit;
END;
/




---------------------------------------------
--
-- Fonction de d�termination de l'index d'un sous �quipement.
-- Part de l'�quipement en cours et construit l'index complet
-- par concat�nation des index locaux � chaque  �quipement,
-- ceci en remontant la hi�rarchie.
--
-- X.L. Cr�ation le 29/03/01
-- JPB  Modif le 11/11/01	erreur si l'index du p�re vaut 0
-- GG	Modif le 16/07/03	pas de r�cursivit�
---------------------------------------------

CREATE OR REPLACE FUNCTION GetIndexSNMP
(
 EquipId		NUMBER		-- ID du sous �quipement
)
RETURN VARCHAR2 IS

	EquipBindingId	NUMBER;				-- ID de l'�quipement p�re
	EquipIndexSnmp	EQUIP.EQUIP_INDEXSNMP%TYPE;	-- Index SNMP de l'�quipement
	FullIndexSnmp	VARCHAR2 (512);			-- Index SNMP concat�n�
BEGIN
	SELECT equip_bindingid, equip_indexsnmp
	   INTO EquipBindingId, EquipIndexSnmp
	   FROM equip
	   WHERE equip_id = EquipId;

	FullIndexSnmp := EquipIndexSnmp;
/*
	WHILE EquipBindingId IS NOT NULL LOOP
		SELECT equip_bindingid, equip_indexsnmp
		   INTO EquipBindingId, EquipIndexSnmp
		   FROM equip
		   WHERE equip_id = EquipBindingId;

		IF EquipIndexSnmp IS NOT NULL THEN
			FullIndexSnmp := EquipIndexSnmp || '.' || FullIndexSnmp;
		END IF;
	END LOOP;
*/
	if (FullIndexSnmp != '0') then
	    FullIndexSnmp := LTRIM (FullIndexSnmp, '0.');
	end if;

	RETURN FullIndexSnmp;
END GetIndexSNMP;
/


---------------------------------------------
--
-- Parcours r�cursif des familles de Types d'equipements
-- Cette fonction retourne le "nom complet" (ie Famille / Sous-Famille / Sous-Sous-Famille etc..)
-- de la famille dont on donne l'Id de la feuille
--
-- JPB  Cr�ation le 24/01/02
--
---------------------------------------------

CREATE OR REPLACE FUNCTION GetFamilyName
(
    Id	  IN NUMBER		-- Id de la feuille
)
RETURN VARCHAR2 IS

    FamilyName	VARCHAR2 (2000);-- valeur � retourner
 
    cursor CName is		-- famille P�re
	select *
	    from FAMILLE
	    where FAMILLE_ID = Id;

BEGIN

    FamilyName := '';
    for vName in CName loop
	if (vName.FAMILLE_BINDINGID Is NULL) then
	    exit;
	end if;

	FamilyName :=  GetFamilyName (vName.FAMILLE_BINDINGID) || ' / ' || vName.FAMILLE_NOM;
    end loop;

    FamilyName := LTRIM (FamilyName, ' /');
--  dbms_output.put_line ('Nom '|| FamilyName);

    return FamilyName;
END	GetFamilyName;
/


CREATE OR REPLACE FUNCTION GetFamilyFather
-- Cette fonction retourne l'Id du "p�re" de la famille dont on donne l'Id,
-- ou 0 pour un �quipement "sans famille"
(
    Id	  IN NUMBER		-- Id de la feuille
)
RETURN NUMBER IS

    FatherId	NUMBER;		-- valeur � retourner
 
    cursor CName is		-- famille P�re
	select *
	    from FAMILLE
	    where FAMILLE_ID = Id;

BEGIN

    FatherId := 0;
    for vName in CName loop
	if (vName.FAMILLE_BINDINGID is null or vName.FAMILLE_BINDINGID = 0) then
	    FatherId := vName.FAMILLE_ID;
	else
	    FatherId := GetFamilyFather (vName.FAMILLE_BINDINGID);
	end if;
    end loop;

--  dbms_output.put_line ('Father Id '|| to_char (FatherId));

    return FatherId;
END	GetFamilyFather;
/





/*
*	Retourne le nom de la liaison :
*	    Extr�mit� A, extr�mit� B, sens de la liaison et num�ro
*/

--Modif Z.N. le 29/07/09. "EXT_VILLE || '/' || A.EXT_POINT" est remplac� par EXT_NOM car Timos
--remplit que EXT_NOM

CREATE OR REPLACE FUNCTION GetLiaiNom
(
    LiaiId	NUMBER		-- Id de la liaison
)
RETURN VARCHAR2
IS
    Nom		VARCHAR2 (60);	-- Nom recherch�

BEGIN

   /* select A.EXT_VILLE || '/' || A.EXT_POINT || 
	   decode (LIAI_DIR, 0, ' -> ', 1, ' <- ', ' <-> ') ||
	   B.EXT_VILLE || '/' || B.EXT_POINT || ' ' || LIAI_NUM*/
	   select A.EXT_NOM || 
	   decode (LIAI_DIR, 0, ' -> ', 1, ' <- ', ' <-> ') ||
	   B.EXT_NOM || ' / ' || LIAI_NUM
		    into Nom
    from LIAI, EXT A, EXT B
    where A.EXT_ID = LIAI_EXTAID and
	  B.EXT_ID = LIAI_EXTBID and
	  LIAI_ID  = LiaiId;

    return (Nom);

EXCEPTION
    when NO_DATA_FOUND then
	return ('INEX');

    when OTHERS then
	return ('ERROR');
END	GetLiaiNom;
/	    	




/*
*	Retourne le nouveau nom de la liaison
*	� partir de l'ancien nom de cette liaison
*	et du nouveau nom d'une extr�mit�
*
*	X.L. Cr�ation le 26/10/04
*/
CREATE OR REPLACE FUNCTION GetNewLiaiNom
(
	OldLiaiNom	VARCHAR2,
	OldExtVille	EXT.EXT_VILLE%TYPE,
	OldExtPoint	EXT.EXT_POINT%TYPE,
	NewExtVille	EXT.EXT_VILLE%TYPE,
	NewExtPoint	EXT.EXT_POINT%TYPE
)
RETURN VARCHAR2
IS
	LiaiNom		VARCHAR2 (60);
	OldExtNom		EXT.EXT_NOM%TYPE;
	NewExtNom		EXT.EXT_NOM%TYPE;
	pos			NUMBER;
BEGIN
	LiaiNom := OldLiaiNom;
	OldExtNom := OldExtVille || '/' || OldExtPoint;
	NewExtNom := NewExtVille || '/' || NewExtPoint;
	FOR i IN 1..2 LOOP		-- Car il y a deux extr�mit�s qui peuvent porter le m�me nom
		pos := INSTR (LiaiNom, OldExtNom);
		IF (pos > 0) THEN
			LiaiNom := SUBSTR (LiaiNom, 1, pos - 1) || NewExtNom || 
				   SUBSTR (LiaiNom, pos + LENGTH (OldExtNom));
		ELSIF i = 1 THEN
			RETURN 'ERROR';
		END IF;
	END LOOP;
	return LiaiNom;
END GetNewLiaiNom;
/


--=======================================================================================
--
-- Recherche du nom d'un �quipement, en tenant compte du param�trage de l'application
-- �ventuellement d�fini dans la table PARAM.
--
-- X.L. le 10/05/01
-- Modif JPB le 10/05/01
-- Modif. X.L. le 25/05/04 pour que la fonction marche avec un �quipement 
-- de la classe CANTENNE_ID.
-- Modif. JFL le 02/03/05 : utilisation de la fonction 'RTRIM' sur variable SiteEquipComment 
-- pour supprimer tous les espaces situ�s en fin de cha�ne (ceux ajout�s par ICMP).
-- Modif. JPB le 19/11/06. Correction d'une erreur si SiteEquipComment is not null and BaieEquipCarte is null
-- Modif. X.L. le 08/08/07 pour donner la repr�sentation conforme � l'�tiquetage demand�
-- et repr�sent� par le flag EQUIP_ETIQ_VUE (0 = par r�f�rence, 1 = par position g�ographique
-- 2 = par commentaire, 3 = par adresse IP et index SNMP).
--
--=======================================================================================
create or replace FUNCTION GetEquipNom
(
    EquipId	NUMBER,		-- Id de l'�quipement
    NomComplet  NUMBER		-- si 1, on indique en plus le nom de la salle
                                -- si 2, on indique encore en plus le nom du site
)
RETURN VARCHAR2

IS
    Nom		EQUIP.SITE_EQUIP_COMMENT%TYPE;	-- Nom recherch�
	nPos	integer;			-- Position signe �gal dans le param�tre
	strPar  PARAM.PARAM_VALEUR%TYPE;	-- Nom du param�tre
	strVal  PARAM.PARAM_VALEUR%TYPE;	-- Valeur du param�tre


	-- Param�tre indiquant de prendre pour libell�s Trav�e, Cadre, Niche, etc. (valeur 0),
	-- ou Trav�e, B�ti, Ch�ssis, etc. (valeur 1), pour un �quipement fils dont le
	-- commentaire pour situer l'�quipement est vide.
	nAffEquipLocalLibel integer;

	-- Param�tre indiquant, parmi les coordonn�es Trav�e, Cadre, etc., quelles sont celles
	-- � afficher (b0=carte, b1=emplacement, b2=niche, etc.)
	nAffEquipEtiquCoord integer;

	EquipRef		EQUIP.EQUIP_REF%TYPE;
	SiteEquipComment	EQUIP.SITE_EQUIP_COMMENT%TYPE;
	EquipBindingId		EQUIP.EQUIP_BINDINGID%TYPE;
	BaieId			EQUIP.BAIE_ID%TYPE;
	SalleBaieTrav		BAIE.SALLE_BAIE_TRAV%TYPE;
	SalleBaieCadre		BAIE.SALLE_BAIE_CADRE%TYPE;
	BaieEquipNiche		EQUIP.BAIE_EQUIP_NICHE%TYPE;
	BaieEquipEmpl		EQUIP.BAIE_EQUIP_EMPL%TYPE;
	BaieEquipCarte		EQUIP.BAIE_EQUIP_CARTE%TYPE;
	EquipClassId		EQUIP.EQUIP_CLASSID%TYPE;
	EquipEtiqVue		EQUIP.EQUIP_ETIQ_VUE%TYPE;
	EquipAddrIp		EQUIP.EQUIP_ADDRIP%TYPE;
	EquipIndexSnmp		EQUIP.EQUIP_INDEXSNMP%TYPE;

	strCoord		VARCHAR2 (5);

	SiteNom			VARCHAR2 (40);
	SalleNom		VARCHAR2 (40);

	CURSOR cParam IS
		SELECT param_valeur FROM param
		WHERE param_type = 9;

BEGIN
	nAffEquipEtiquCoord := 31;

	-- Recherche des param�tres ayant une incidence sur le nom de l'�quipement

	strCoord := 'TCNEC';	-- Trav�e, Cadre, Niche, Emplacement, Carte
	for rcParam in cParam loop
		nPos := instr (rcParam.param_valeur, '=');
		if (nPos > 0) then	-- c'est un param�tre du type NOM_PARAM=VALEUR
			strPar := substr (rcParam.PARAM_VALEUR, 1, nPos - 1);
			strVal := substr (rcParam.PARAM_VALEUR, nPos + 1);
		end if;

		if (strPar = 'AFF_EQUIP_LOCAL_LIBEL') then
			if (to_number (strVal) = 1) then
			    strCoord := 'TBCES';-- Trav�e, B�ti, Ch�ssis, Emplacement, Slot
			end if;
		elsif (strPar = 'AFF_EQUIP_ETIQU_COORD') then
			nAffEquipEtiquCoord := to_number (strVal);
		end if;
	end loop;

	-- Recherche des champs permettant de nommer l'�quipement
	select EQUIP_REF, SITE_EQUIP_COMMENT, EQUIP_BINDINGID, EQUIP_CLASSID, BAIE_ID,
			BAIE_EQUIP_NICHE, BAIE_EQUIP_EMPL, BAIE_EQUIP_CARTE, EQUIP_ETIQ_VUE,
			EQUIP_ADDRIP, EQUIP_INDEXSNMP
	into	EquipRef, SiteEquipComment, EquipBindingId, EquipClassId, BaieId,
			BaieEquipNiche, BaieEquipEmpl, BaieEquipCarte, EquipEtiqVue,
			EquipAddrIp, EquipIndexSnmp
	from EQUIP
	where EQUIP_ID = EquipId;

	select SITE_NOM into SiteNom
	from EQUIP, SITE
	where EQUIP_ID = EquipId and
	      EQUIP.SITE_ID = SITE.SITE_ID;

	SalleNom := '';

	if (EquipClassId = 1034) then		-- C'est une antenne
		Nom := Equipref;
	else					-- C'est un �quipement

		if (EquipEtiqVue = 0) then	-- D�signation par r�f�rence
			Nom := EquipRef;
		elsif (EquipEtiqVue = 2) then	-- D�signation par commentaire
			Nom := RTRIM (SiteEquipComment);
		elsif (EquipEtiqVue = 3) then	-- D�signation par adresse IP + index SNMP
			Nom := RTRIM (EquipAddrIp) || ' ' || RTRIM (EquipIndexSnmp);
		else				-- D�signation par coordonn�es g�ographiques
			select SALLE_NOM into SalleNom
			from EQUIP, SALLE, BAIE
			where EQUIP_ID = EquipId and
			      EQUIP.BAIE_ID = BAIE.BAIE_ID and
			      BAIE.SALLE_ID = SALLE.SALLE_ID;

			select SALLE_BAIE_TRAV, SALLE_BAIE_CADRE
			into SalleBaieTrav, SalleBaieCadre
			from BAIE
			where BAIE_ID = BaieId;

			select decode (floor (nAffEquipEtiquCoord/16), 1,   
					substr (strCoord, 1, 1) || ': ' || SalleBaieTrav, '     ') ||
				   decode (mod(floor (nAffEquipEtiquCoord/8), 2), 0, '      ', 
				   ' ' || substr (strCoord, 2, 1) || ': ' || SalleBaieCadre) ||
				   decode (mod (floor (nAffEquipEtiquCoord/4), 2), 0, '      ',
				   ' ' || substr (strCoord, 3, 1) || ': ' || BaieEquipNiche) ||
				   decode (mod (floor (nAffEquipEtiquCoord/2), 2), 0, '      ',
				   ' ' || substr (strCoord, 4, 1) || ': ' || BaieEquipEmpl) ||
				   decode (mod (nAffEquipEtiquCoord, 2), 0, '      ',
				   ' ' || substr (strCoord, 5, 1) || ': ' || BaieEquipCarte)
			into Nom
			from DUAL;
                end if;
	end if;

	if (NomComplet > 0) then
	    Nom := SalleNom || ' ' || Nom;
	end if;
        
        if (NomComplet > 1) then
            Nom := SiteNom || ' ' || Nom;
        end if;

    return (Nom);

EXCEPTION
    when NO_DATA_FOUND then
	return ('INEX');

    when OTHERS then
	return ('ERROR');
END	GetEquipNom;
/



--
--  Cette fonction retourne 1 si la liaison sort du site, et 0 si elle y entre
--  Le site doit correspondre � une des deux extr�mit�s.
--
CREATE OR REPLACE FUNCTION OutSite (LiaiId NUMBER, SiteId NUMBER)
RETURN NUMBER
IS
    SiteAId	NUMBER;		-- Id du site correspondant � LIAI_EXTAID
    SiteBId	NUMBER;		-- Id du site correspondant � LIAI_EXTBID
    Orig	NUMBER;		-- Id du site origine
    Dest	NUMBER;		-- Id du site destination
    Dir		NUMBER;		-- LIAI_DIR de la liaison

BEGIN
    select SITE_ID into SiteAId
	from EXT, LIAI
	where EXT.EXT_ID = LIAI.LIAI_EXTAID and
	      LIAI_ID = LiaiId;

    select SITE_ID into SiteBId
	from EXT, LIAI
	where EXT.EXT_ID = LIAI.LIAI_EXTBID and
	      LIAI_ID = LiaiId;

    select LIAI_DIR into Dir
	from LIAI
	where LIAI_ID = LiaiId;

    if (Dir = 0) then
	Orig := SiteAId;
	Dest := SiteBId;
    else
	Orig := SiteBId;
	Dest := SiteAId;
    end if;

    if (SiteId = Orig) then
	return 1;
    else
	return 0;
    end if;
END	OutSite;
/


--
--  Cette fonction retourne un nombre �gal � la cha�ne de caract�res, si celle-ci est un nombre.
--  Accepte le . et la , comme s�parateur d�cimal.
--  Elle retourne -1 sinon.
--
CREATE OR REPLACE FUNCTION ToNumber (Str VARCHAR2)
RETURN NUMBER
IS
    Nbr	  NUMBER;		-- R�sultat � retourner
    lStr  VARCHAR2 (40);	-- Cha�ne temporaire

BEGIN
    lStr := REPLACE (Str, '.', ',');
    Nbr  := TO_NUMBER (lStr);
    return Nbr;

EXCEPTION
    when OTHERS then
	return -1;

END	ToNumber;
/


--
-- Cette fonction retourne 1 si une famille (d�finie par son ID et CLASS_ID) vaut un ID
-- pr�d�fini, ou est fils de cet ID pr�d�fini. Sinon, retourne 0.
--
CREATE OR REPLACE FUNCTION IsSonOf (ObjId NUMBER, ClassId NUMBER, FatherId NUMBER)
RETURN NUMBER
IS
    BindingId	NUMBER;		-- Nom de la famille p�re de celle-ci
    
BEGIN
--  dbms_output.put_line (' ObjId ' || to_char (ObjId) || ' ClassId ' || to_char (ClassId) ||
--		      ' FatherId ' || to_char (ObjId));
    if (ObjId = FatherId) then
	return 1;
    else
	select FAMILLE_BINDINGID into BindingId from FAMILLE
	    where FAMILLE_ID = ObjId and
		  FAMILLE_CLASSID = ClassId;

	if (BindingId is NULL) then
	    return 0;
	end if;

	return (IsSonOf (BindingId, ClassId, FatherId));
    end if;

EXCEPTION
    when OTHERS then
--	dbms_output.put_line ('Exception rencontr�e');
	return 0;
END  IsSonOf;
/



--
-- Cette fonction trie les OID dans l'ordre attendu pour une cha�ne de caract�res
-- Attention, les nombres exprim�s entre deux points doivent �tre compris entre 0 et 35
--
-- Cr�ation : JPB le 23/07/04

CREATE OR REPLACE FUNCTION SortOID 
(
    StrOID	VARCHAR2	-- OID � remplacer
)
RETURN VARCHAR2
IS
    Pos     NUMBER;
    Val	    NUMBER;
    Str0    VARCHAR2 (256);
    Str	    VARCHAR2 (256);
    Result  VARCHAR2 (256);

BEGIN
    Str    := StrOID;
    Result := '';

    LOOP
	Pos := INSTR (Str, '.', 1);
-- dbms_output.put_line ('STR : '||Str ||' ; POS : '|| to_char (Pos));
	IF (Pos = 0) THEN
/*
	    IF (to_number (Str) < 51) THEN
		Val := 191 - to_number (Str);
	    ELSIF (to_number (Str) < 77) THEN
		Val := to_number (Str) + 14;
	    ELSIF (to_number (Str) < 87) THEN
		Val := to_number (Str) - 29;
	    END IF;
*/
	    IF (to_number (Str) < 26) THEN
		Val := 65 + to_number (Str);
	    ELSIF (to_number (Str) < 36) THEN
		Val := to_number (Str) + 22;
	    END IF;

	    Result := Result || CHR (Val);
-- dbms_output.put_line ('RESULT : ' || Result);
	    return (Result);
    	END IF;

/*
	Str0   := SUBSTR (Str, 1, Pos -1);
        IF (to_number (Str0) < 51) THEN
	    Val := 191 - to_number (Str0);
	ELSIF (to_number (Str0) < 77) THEN
	    Val := to_number (Str0) + 14;
	ELSIF (to_number (Str0) < 87) THEN
	    Val := to_number (Str0) - 29;
	END IF;
*/
	Str0   := SUBSTR (Str, 1, Pos -1);
        IF (to_number (Str0) < 26) THEN
	    Val := 65 + to_number (Str0);
	ELSIF (to_number (Str0) < 36) THEN
	    Val := to_number (Str0) + 22;
	END IF;

	Result := Result || CHR (Val);

	Str    := SUBSTR (Str, Pos +1, LENGTH (Str) - Pos);
-- dbms_output.put_line ('STR0 : '|| Str0 || ' ; RESULT : ' || Result);
    END LOOP;

END	SortOID;
/





--
-- Cette fonction indique si on est sur le serveur
-- normal ou sur un secours.
-- Ceci suppose que le programme de r�plication
-- renseigne correctement l'enregistrement
-- d'ID 3 dans dbarep. Cet enregistrement est mis
-- � jour d'une mani�re statique par le programme
-- de r�plication � son lancement puis � son arr�t.
-- Tant que la r�plication est lanc�e, dbarep_etat
-- vaut 1 pour cet enregistrement sur un secours;
-- quand on l'arr�te il est mis � z�ro.
-- Cette fonction est exploit�e dans PurgeAlarmes
-- pour savoir si la purge a lieu sur le NORMAL ou
-- sur le SECOURS (dans le cas du secours, les
-- tables MESSALRM, MAILALRM, LOGSPV sont compl�tement
-- effac�es.
--
-- X.L. cr�ation le 16/01/07
--
CREATE OR REPLACE FUNCTION IsSecours
RETURN BOOLEAN IS
	CURSOR CurRep IS
		SELECT dbarep_repetat FROM dbarep WHERE dbarep_id = 3;

BEGIN
	FOR rCurRep IN CurRep LOOP
		IF rCurRep.dbarep_repetat = 1 THEN
			RETURN true;
		END IF;
	END LOOP;

	RETURN false;
END IsSecours;
/




--=============================================================================
--   Fonction permettant d'ins�rer une alarme en base de donn�es
--   
--   D�velopp�e � l'origine pour l'E10
--
--	Retourne  1 si succ�s
--	Retourne  0 dans le cas contraire
--  
--=============================================================================
--
create or replace
FUNCTION InsertAlarm
(
 AlClasse	VARCHAR2,		-- Classe de l'alarme (IS, IS_S, TRAPS, E10B, etc.)
 AlNumObj	NUMBER,			-- Num�ro d'objet (N� d'IS, N� trap, N� NIDAL pour E10, etc.)
 AlDate		VARCHAR2,		-- Date de l'�v�nement d'alarme au format YYYY MM DD HH24:MI:SS
 AlGrave	NUMBER,			-- Gravit� de l'alarme (7:critique, 6:majeure, 5:mineure, etc.)
 ALNumal	VARCHAR2,		-- Num�ro d'entr�e alarme (cas IS)
 AlInfo		VARCHAR2,		-- Texte de l'alarme
 EquipId	NUMBER			-- ID en BDD de l'�quipement
)
RETURN NUMBER IS
	AlComment	alarm.alarm_comment%TYPE;
	AlNumalLoc	alarm.alarm_numal%TYPE;
	ALClassLoc	alarm.alarm_cl%TYPE;
	EquipLoc	equip.site_equip_comment%TYPE;
	AlInfoLoc	alarm.alarm_info%TYPE;

BEGIN
	IF (AlInfo IS NULL OR EquipId IS NULL) AND 
	   (AlClasse = 'E10B' OR AlClasse = 'TRAPS' OR AlClasse = 'TRAPG') THEN
		RAISE_APPLICATION_ERROR (-20000, 'Fonction InsertAlarm, renseigner les param�tres obligatoires');
	END IF;

	AlInfoLoc  := TRANSLATE (SUBSTR (AlInfo, 1, 256), '#', '$');
	AlClassLoc := AlClasse;
	AlNumalLoc := AlNumal;

	IF AlClassLoc = 'E10B' THEN
		AlComment := '6486';	-- N� IANA Alcatel

		IF AlnumalLoc IS NULL THEN
			SELECT site_equip_comment INTO EquipLoc FROM equip WHERE equip_id = EquipId;
			IF LENGTH (EquipLoc) > 40 THEN
				AlNumalLoc := to_char (EquipId);
			ELSE
				AlNumalLoc := EquipLoc;
			END IF;
		END IF;
	END IF;
	--SetTrace ('Classe : ' || AlClassLoc || ' NumObj ' || AlNumObj || ' Date ' || AlDate || ' Gravit� ' || AlGrave || ' ALNumal ' || ALNumal || ' Comment ' || alComment || ' info ' || AlInfoLoc);

	INSERT INTO alarm (alarm_id, alarm_num, alarm_cl, alarm_numobj,
				 alarm_date, alarm_grave, alarm_numal, alarm_texte,
				 alarm_comment, alarm_info)
	VALUES
			  (seq_alarm.NEXTVAL, seq_alarm.CURRVAL, AlClassLoc, AlNumObj,
			   AlDate, AlGrave, AlNumalLoc, 1, AlComment, to_char (EquipId) || ';' || AlInfoLoc);

	RETURN 1;
END InsertAlarm;
/



--=============================================================================
--   Fonction permettant de retrouver l'ID d'un �quipement E10 Alcatel
--
--   Les coordonn�es de l'�quipement doivent �tre dans SITE_EQUIP_COMMENT.
--   Le format doit �tre NCEN-AGEO ou NCEN est le nom du central trouv� dans
--   les messages d'alarmes E10 et AGEO le champ AGEO idem.
--
--	Retourne  l'ID de cet �quipement ou -1 si non trouv�
--  
--=============================================================================
--
create or replace
FUNCTION GetEquipE10
(
 Ncen		VARCHAR2,		-- Nom du central
 Ageo		VARCHAR2		-- Adresse g�ographique
)
RETURN NUMBER IS
	NcenLoc VARCHAR2 (10);

	CURSOR CurCen IS
		SELECT equip_id FROM equip WHERE site_equip_comment = NcenLoc;

	CURSOR CurEquip IS
		SELECT equip_id FROM equip WHERE site_equip_comment = NCenLoc || '-' || Ageo;
BEGIN
	NcenLoc := RTRIM (Ncen);
	--SetTrace ('Ncen : ' || NcenLoc || ' Ageo : ' || Ageo);
	IF Ageo IS NULL THEN
		FOR rCurCen IN CurCen LOOP
			RETURN rCurCen.equip_id;
		END LOOP;
	ELSE
		FOR rCurEquip IN CurEquip LOOP
			RETURN rCurEquip.equip_id;
		END LOOP;
	END IF;
	RETURN -1;
END GetEquipE10;
/





--=============================================================================
--   Fonction effectuant la retomb�e des alarmes d'un �quipement pr�cis
--   et de ses sous-�quipements si demand�.
--
--   X.L. cr�ation le 26/02/07
-- 
--=============================================================================
--
create or replace
PROCEDURE ResetAlarm2
(
 EquipId	equip.equip_id%TYPE,		-- ID de l'�quipement
 Included	boolean				-- si TRUE, faire retomber en plus les alarmes des �quipements inclus
) IS
	-- Recherche des alarmes en cours d'un �quipement
	CURSOR CurAl IS
		SELECT alarm.*
		FROM alarm, acces_accesc_rep
        	WHERE acces_accesc_rep.equip_id = EquipId 
	      	AND acces_accesc_rep.alarm_id IS NOT NULL
		AND alarm.alarm_id = acces_accesc_rep.alarm_id;

	-- Recherche des �quipements englob�s dans un �quipement
	CURSOR CurInc (EquipId equip.equip_id%TYPE) IS
		SELECT equip_id FROM equip
		WHERE  equip_bindingid = EquipId;
                
        nRet  NUMBER;     -- Valeur de retour de la fonction InsertAlarm
        

BEGIN
	FOR rCurAl IN CurAl LOOP
		nRet := InsertAlarm ('E10B', rCurAl.alarm_numobj, to_char (sysdate, 'YYYY MM DD HH24:MI:SS'),
                                     0, rCurAl.alarm_numal, rCurAl.alarm_info, EquipId);
	END LOOP;

	IF Included THEN
		FOR rCurInc IN CurInc (EquipId) LOOP
			ResetAlarm2 (rCurInc.equip_id, Included);
		END LOOP;
	END IF;
END ResetAlarm2;
/




--=============================================================================
--   Fonction effectuant la retomb�e des alarmes des autocom. E10 Alcatel
--   pour un �quipement de m�diation donn�.
--   On balaye la liste des �quipements et sous �quipements correspondant 
--   aux E10B sous sa d�pendance; on fait retomber les alarmes pr�sentes 
--   correspondantes.
--
--   Retourne 1 si succ�s, 0 si �chec
--  
--   X.L. cr�ation le 26/02/07
--
--=============================================================================
--
create or replace
FUNCTION ResetE10 (EquipMed	VARCHAR2)
return number IS

	TypeE10Id	typeq.typeq_id%TYPE;		-- ID en BDD du type d'�quipement E10
	Val		param.param_valeur%TYPE;	-- Valeur d'un param�tre
	Pos		NUMBER;				-- Position du s�parateur
	Ind		NUMBER;				-- Index de parcours
	TypeE10Nom	typeq.typeq_nom%TYPE;
	ListEquip	VARCHAR2 (2000);		-- Liste des ID des �quipements E10

	-- Recherche des types d'�quipements E10 d�finis dans PARAM
	CURSOR CurParam IS
		SELECT param_valeur FROM param WHERE param_type = 9 AND param_valeur LIKE 'TYPE_E10=%';

	-- Recherche des �quipements E10 d'un type p�re donn�
	CURSOR CurE10 (TypeqNom	VARCHAR2) IS
		SELECT equip_id FROM equip WHERE typeq_nom = TypeqNom;

BEGIN
	-- Le param�tre de type 9, TYPE_E10= donne la liste des noms des types d'�quipement
	-- de type E10 (correspondant au noms de centraux, c'est � dire � l'englobant)
	-- dans la BDD sous la forme TYPE_E10=E10B;E10;etc.

	-- Acquisition du param�tre TYPE_E10 dans la table PARAM
	FOR rCurParam IN CurParam LOOP
		Val := rCurParam.param_valeur;
	END LOOP;		

	IF Val IS NULL THEN
		--settrace ('ResetE10 : param�tre TYPE_E10 non sp�cifi� dans la table PARAM');
		RETURN 0;
	END IF;

	-- Extraction de la valeur du param�tre	
	Pos := INSTR (Val, '=');
	IF Pos > 0 THEN
		Val := SUBSTR (Val, Pos + 1);
	END IF;

	-- Pour chaque type d'E10 on recherche les �quipements correspondants
	Ind := 0;
	WHILE TRUE LOOP
		TypeE10Nom := GetStr (Val, Ind, ';');

		EXIT WHEN TypeE10Nom IS NULL;
		--SetTrace ('Typeq : ' || TypeE10Nom);

		FOR rCurE10 IN CurE10 (TypeE10Nom) LOOP
			--SetTrace ('Eqt E10 : ' || rCurE10.equip_id);
			ResetAlarm2 (rCurE10.equip_id, TRUE);
		END LOOP;
		Ind := Ind + 1;
	END LOOP;
	COMMIT;
	RETURN 1;

EXCEPTION
	WHEN OTHERS THEN
		ROLLBACK;
		RETURN 0;				
END;
/




--=============================================================================
--   Fonction effectuant la retomb�e des alarmes d'un autocom. E10 Alcatel
--   pr�cis.
--
--   Retourne 1 si succ�s, 0 si �chec
--  
--   X.L. cr�ation le 09/03/07
--
--=============================================================================
--
create or replace
FUNCTION ResetEqtE10 (EquipId NUMBER)
RETURN NUMBER IS
BEGIN
	ResetAlarm2 (EquipId, TRUE);
	RETURN 1;
END ResetEqtE10;
/



------------------------------------------------------
--
-- Proc�dure appel�e par le trigger tiub_equip.
-- Son contenu peut �tre sp�cifique � un client (ex: OPT).
--
-- X.L.  Cr�ation le 20/12/06
------------------------------------------------------
CREATE OR REPLACE FUNCTION SpecTiubEquip
(
 EmName    VARCHAR2		-- Nom de l'�quipement de m�diation
)
RETURN VARCHAR2 IS
BEGIN
    RETURN NULL;
END SpecTiubEquip;
/




--==============================================================================================
--
-- Cette fonction retourne les Mibs d'in type d'�quipement.
-- Exploit�e quand le rapport sur les types d'�quipement est demand�s.
-- 
-- EM. Cr�ation le 05/09/07.
--
--==============================================================================================
create or replace function GetMibs
(
	TypeqId	NUMBER
)
RETURN VARCHAR2 IS

	longueur	NUMBER;
	nlongueur	NUMBER;
	Mib		MIBMODULE.MIBMODULE_NOM%TYPE;
	FullMibs	VARCHAR2 (2048);
	CURSOR		CMibModule (Id NUMBER) IS
		select MIBMODULE_NOM 
		from TYPEQ_MIBMODULE, MIBMODULE
		WHERE TYPEQ_MIBMODULE.TYPEQ_ID = Id
		AND TYPEQ_MIBMODULE.MIBMODULE_ID = MIBMODULE.MIBMODULE_ID;

BEGIN
	FullMibs:='';
	longueur:=0;
	for vMibModule in CMibModule (TypeqId) loop
		
		if (vMibModule.MIBMODULE_NOM is not NULL) then
			nlongueur := longueur + LENGTH(vMibModule.MIBMODULE_NOM);
			if (nlongueur<2048) then
				FullMibs := FullMibs || ' ';
				FullMibs := FullMibs || vMibModule.MIBMODULE_NOM;
				longueur := nlongueur;
			end if;
		end if;
	end loop;

	RETURN (FullMibs);
END GetMibs;
/



--====================================================================================
-- JL - le 10/09/2007.
-- Fonction qui retourne le num�ro du jour dans la semaine en fonction de son libell�.
--====================================================================================
CREATE OR REPLACE FUNCTION getNumJour (libJour VARCHAR2) RETURN NUMBER
IS

  strLibJour    VARCHAR2(10);
  numJour       NUMBER;

BEGIN
  -- On passe en majuscule le libell� du jour.
  strLibJour := UPPER(libJour);
  numJour := 0;

  IF (strLibJour = 'LUNDI') THEN
    numJour := 1;
  ELSIF (strLibJour = 'MARDI') THEN
    numJour := 2;
  ELSIF (strLibJour = 'MERCREDI') THEN
    numJour := 3;
  ELSIF (strLibJour = 'JEUDI') THEN
    numJour := 4;
  ELSIF (strLibJour = 'VENDREDI') THEN
    numJour := 5;
  ELSIF (strLibJour = 'SAMEDI') THEN
    numJour := 6;
  ELSIF (strLibJour = 'DIMANCHE') THEN
    numJour := 7;
  END IF;
  
  RETURN numJour;
END;
/



--==============================================
-- JL - le 10/09/2007.
-- Proc�dure pour g�rer les donn�es p�riodiques.

--ZN modif. 27/11/07 - des intervales qui sont pas finis 
--ont des dates de la semaine en cours
-- 
--==============================================
CREATE OR REPLACE PROCEDURE SavePeriodique (ProgId NUMBER, strPeriode VARCHAR2)
IS

  strChaine     VARCHAR2(100);
  posDeb        NUMBER;
  posFin        NUMBER;
  ordrePassage  NUMBER;
  strJourDeb    VARCHAR2(10);
  strJourFin    VARCHAR2(10);
  strHeureDeb   VARCHAR2(6);
  strHeureFin   VARCHAR2(6);
  numJour       NUMBER;
  numJourDeb    NUMBER;
  numJourFin    NUMBER;
  dateJourDeb   DATE;
  dateJourFin   DATE;
  dateJour      DATE;
  now           DATE;
  numHeureJour  NUMBER;
  numMinuteJour NUMBER;
  jobNb          NUMBER;
  
BEGIN

  if(ProgId <= 0) then
    return;
  end if;
  
  -- Recherche des ",".
  strChaine := SUBSTR(strPeriode, 3, LENGTH(strPeriode)-2);
  strChaine := REPLACE(strChaine, ';', ',');
  
  posDeb := 1;
  posFin := 1;
  ordrePassage := 1;
  
  WHILE (INSTR(strChaine, ',', posDeb)<>0) LOOP
    posFin := INSTR(strChaine, ',', posFin);
    
    IF (ordrePassage = 1) THEN
      strJourDeb := SUBSTR(strChaine, posDeb, posFin-posDeb);
    ELSIF (ordrePassage = 2) THEN
      strHeureDeb := SUBSTR(strChaine, posDeb, posFin-posDeb);
    ELSIF (ordrePassage = 3) THEN
      strJourFin := SUBSTR(strChaine, posDeb, posFin-posDeb);
    ELSIF (ordrePassage = 4) THEN
      strHeureFin := SUBSTR(strChaine, posDeb, posFin-posDeb);
    END IF;
    
    ordrePassage := ordrePassage+1;
    posFin := posFin+1;
    posDeb := posFin;
  END LOOP;
  
  if(strJourDeb='' or strJourFin='') then
    return;
  end if;
  
  -- R�cup�ration du num�ro du jour actuel.
  SELECT to_number(to_char(sysdate, 'D'), 99) INTO numJour FROM dual;
  
  SELECT sysdate INTO now FROM dual;
  
  -- D�termination des num�ros des jours de d�but et de fin de p�riode.
  numJourDeb := getNumJour(strJourDeb);
  numjourFin := getNumJour(strJourFin);
  
  strHeureDeb := REPLACE(strHeureDeb, 'H', ':');
  strHeureFin := REPLACE(strHeureFin, 'H', ':');
  
  SELECT (sysdate + (numJourDeb-numJour)) INTO dateJour FROM dual;
  dateJourDeb:=  to_date(to_char(dateJour, 'DD/MM/YYYY')||' '||strHeureDeb, 'DD/MM/YYYY HH24:MI');
  
  SELECT (sysdate + (numJourFin-numJour)) INTO dateJour FROM dual;
  dateJourFin:=  to_date(to_char(dateJour, 'DD/MM/YYYY')||' '||strHeureFin, 'DD/MM/YYYY HH24:MI');
  
  if(dateJourDeb>=dateJourFin) then
    dateJourFin:=dateJourFin+7;
  end if;
    
  -- Insertion en base de donn�es.
  INSERT INTO PROG_ACTIV (PROG_ACTIV_ID, PROG_ID, DATE_DEBUT, DATE_FIN, ACTIV_TYPE)
   VALUES (seq_progactiv.nextval, ProgId, dateJourDeb, dateJourFin, 'P');
   
  select job into jobNb from user_jobs where what like 'MajProgActiv%';
  dbms_job.run(jobNb);

/*      
  -- D�termination des dates en fonction des num�ros de jour.
  IF (numJour > numJourDeb) THEN
    SELECT (sysdate + ((numJourDeb-numJour)+7)) INTO dateJourDeb FROM dual;
  ELSIF (numJour = numJourDeb) THEN
    -- Si les 2 num�ros de jours sont �gaux, on v�rifie les heures puis les minutes si besoin.
    SELECT to_number(to_char(sysdate, 'HH24')) INTO numHeureJour FROM dual;
    
    IF (numHeureJour > to_number(LPAD(strHeureDeb,2))) THEN
      SELECT (sysdate +7) INTO dateJourDeb FROM dual;
    ELSIF (numHeureJour = to_number(LPAD(strHeureDeb,2))) THEN
      SELECT to_number(to_char(sysdate, 'MI')) INTO numMinuteJour FROM dual;
      
      IF (numMinuteJour >= to_number(SUBSTR(strHeureDeb,4,2))) THEN
        SELECT (sysdate +7) INTO dateJourDeb FROM dual;
      ELSE
        SELECT sysdate INTO dateJourDeb FROM dual;
      END IF;
      
    ELSE
      SELECT sysdate INTO dateJourDeb FROM dual;
    END IF;
    
  ELSE
    SELECT (sysdate + (numJourDeb-numJour)) INTO dateJourDeb FROM dual;
  END IF;
  
  IF (numJourDeb > numJourFin) THEN
    SELECT (dateJourDeb + ((numJourFin-numJourDeb)+7)) INTO dateJourFin FROM dual;
  ELSIF (numJourDeb = numJourFin) THEN
  
    -- Si les 2 num�ros de jours sont �gaux, on v�rifie les heures puis les minutes si besoin.
    IF (to_number(LPAD(strHeureDeb,2)) > to_number(LPAD(strHeureFin,2))) THEN
      SELECT (dateJourDeb + ((numJourFin-numJourDeb)+7)) INTO dateJourFin FROM dual;
    ELSIF (to_number(LPAD(strHeureDeb,2)) = to_number(LPAD(strHeureFin,2))) THEN
      
      IF (to_number(SUBSTR(strHeureDeb,4,2)) >= to_number(SUBSTR(strHeureFin,4,2))) THEN
        SELECT (dateJourDeb + ((numJourFin-numJourDeb)+7)) INTO dateJourFin FROM dual;
      ELSE
        dateJourFin := dateJourDeb;
      END IF;
      
    ELSE
      dateJourFin := dateJourDeb;
    END IF;
    
  ELSE
    SELECT (dateJourDeb + (numJourFin-numJourDeb)) INTO dateJourFin FROM dual;
  END IF;
  
  strHeureDeb := REPLACE(strHeureDeb, 'H', ':');
  strHeureFin := REPLACE(strHeureFin, 'H', ':');
    
  -- Insertion en base de donn�es.
  INSERT INTO PROG_ACTIV (PROG_ACTIV_ID, PROG_ID, DATE_DEBUT, DATE_FIN)
    VALUES (seq_progactiv.nextval, ProgId, to_date(to_char(dateJourDeb, 'DD/MM/YYYY')||' '||strHeureDeb, 'DD/MM/YYYY HH24:MI')
              , to_date(to_char(dateJourFin, 'DD/MM/YYYY')||' '||strHeureFin, 'DD/MM/YYYY HH24:MI'));*/
END SavePeriodique;
/ 



--==============================================
-- JL - le 10/09/2007.
-- Proc�dure pour g�rer les donn�es temporaires.
--
--Modif. ZN le 4/12/07 - ajout activ_type
--==============================================
CREATE OR REPLACE PROCEDURE SaveTemporaire (ProgId NUMBER, strTempo VARCHAR2)
IS

  strChaine     VARCHAR2(100);
  posDeb        NUMBER;
  posFin        NUMBER;
  ordrePassage  NUMBER;
  strDateDeb    VARCHAR2(30);
  strDateFin    VARCHAR2(30);
  
BEGIN
  -- Recherche des ",".
  strChaine := SUBSTR(strTempo, 3, LENGTH(strTempo)-2);
  strChaine := REPLACE(strChaine, ';', ',');
  
  posDeb := 1;
  posFin := 1;
  ordrePassage := 1;
  
  WHILE (INSTR(strChaine, ',', posDeb)<>0) LOOP
    posFin := INSTR(strChaine, ',', posFin);
    
    IF (ordrePassage = 1) THEN
      strDateDeb := SUBSTR(strChaine, posDeb, posFin-posDeb)||' ';
    ELSIF (ordrePassage = 2) THEN
      strDateDeb := strDateDeb||SUBSTR(strChaine, posDeb, posFin-posDeb);
    ELSIF (ordrePassage = 3) THEN
      strDateFin := SUBSTR(strChaine, posDeb, posFin-posDeb)||' ';
    ELSIF (ordrePassage = 4) THEN
      strDateFin := strDateFin||SUBSTR(strChaine, posDeb, posFin-posDeb);
    END IF;
    
    ordrePassage := ordrePassage+1;
    posFin := posFin+1;
    posDeb := posFin;
  END LOOP;
  
  -- Insertion en base de donn�es.
  IF (strDateDeb <> ' ' and strDateFin <> ' ') THEN
    INSERT INTO PROG_ACTIV (PROG_ACTIV_ID, PROG_ID, DATE_DEBUT, DATE_FIN, ACTIV_TYPE)
      VALUES (seq_progactiv.nextval, ProgId, to_date(strDateDeb, 'DD/MM/YYYY HH24:MI'), to_date(strDateFin, 'DD/MM/YYYY HH24:MI'), 'T');
  ELSIF (strDateDeb <> ' ' and strDateFin = ' ') THEN
    INSERT INTO PROG_ACTIV (PROG_ACTIV_ID, PROG_ID, DATE_DEBUT, ACTIV_TYPE)
      VALUES (seq_progactiv.nextval, ProgId, to_date(strDateDeb, 'DD/MM/YYYY HH24:MI'), 'T');
  ELSIF (strDateFin <> ' ' and strDateDeb = ' ') THEN
    INSERT INTO PROG_ACTIV (PROG_ACTIV_ID, PROG_ID, DATE_FIN, ACTIV_TYPE)
      VALUES (seq_progactiv.nextval, ProgId, to_date(strDateFin, 'DD/MM/YYYY HH24:MI'), 'T');
   --   insert into TEST values (SEQ_TEST.NEXTVAL, strDateFin);
  END IF;
END SaveTemporaire;
/



--====================================
-- JL - le 10/09/2007.
-- Proc�dure de mise � jour des dates.

-- ZN modif. 27/11/07 - on ne supprime pas des intervales de la semaine en cours
-- qui sont pas finis; on ne recalcule plus des intervales � partir de prog_fonc;
-- le traitement des nouveaux intervales defini dans le dialoques Plages Horaires
-- est deplac� dans la fonction UpdateProgActiv

-- Cette procedure est appel�e chaque semaine par le dbms_job
--====================================
CREATE OR REPLACE PROCEDURE MajProgActiv
IS

  now       DATE;
  cnt       NUMBER;
  dateStart   DATE;
  dateEnd     DATE;
  
  
  CURSOR curProgFinished IS
    SELECT PROG_ACTIV_ID, PROG_ID, DATE_DEBUT, DATE_FIN
    FROM prog_activ where ACTIV_TYPE='P'
    and DATE_FIN <= now;
    
  CURSOR curProgNow IS
    SELECT PROG_ACTIV_ID, PROG_ID, DATE_DEBUT, DATE_FIN
    FROM prog_activ where ACTIV_TYPE='P'
    and DATE_DEBUT < now and DATE_FIN > now;
    
BEGIN
  
  SELECT sysdate INTO now FROM dual;
  
      -- ajout 1 semaine � les dates pass�s 
  for rcurProgFinished in curProgFinished loop
    dateStart:=rcurProgFinished.DATE_DEBUT + 7;
    dateEnd:=rcurProgFinished.DATE_FIN + 7;
   
    --JOB MajProgActiv peut etre en retard
    while(dateStart < now) loop
        dateStart := dateStart+7;
        dateEnd := dateEnd + 7;
    end loop;
    
    --en cas de retarde de JOB MajProgActiv on peut avoir des meme intervales
    select count(*) into cnt from prog_activ where prog_id=rcurProgFinished.PROG_ID
      and DATE_DEBUT = dateStart and DATE_FIN = dateEnd and ACTIV_TYPE = 'P';
      
    if(cnt>0) then
      delete prog_activ where prog_activ_id=rcurProgFinished.prog_activ_id;
    else
      update prog_activ set DATE_DEBUT=dateStart, DATE_FIN=dateEnd
        where PROG_ACTIV_ID=rcurProgFinished.PROG_ACTIV_ID;
    end if;
  end loop;
  
  --si intervale est en cours on le duplic pour la semaine prochaine
  for rcurProgNow in curProgNow loop
    
    --en cas de retarde de JOB MajProgActiv on peut avoir des meme intervales
    select count(*) into cnt from prog_activ where prog_id=rcurProgNow.PROG_ID
      and DATE_DEBUT = rcurProgNow.DATE_DEBUT+7
      and DATE_FIN = rcurProgNow.DATE_FIN+7
      and ACTIV_TYPE = 'P';
      
    if(cnt=0) then
     insert into prog_activ (PROG_ACTIV_ID, PROG_ID, DATE_DEBUT,
       DATE_FIN, ACTIV_TYPE)
       values(seq_progactiv.nextval, rcurProgNow.prog_id,
       rcurProgNow.DATE_DEBUT+7, rcurProgNow.DATE_FIN+7, 'P');
    end if;
     
  end loop;
   
END MajProgActiv;
/

--====================================
-- JL - le 10/09/2007.
-- Proc�dure de mise � jour des dates.
-- ZN modif. 28/11/07
-- Cette procedure est appel�e � la modification de dialogue Plages Horaires
--====================================
CREATE OR REPLACE PROCEDURE UpdateProgActiv (ProgId NUMBER, ProgFonc VARCHAR2)
IS

  --===========
  -- Variables.
  --===========
  posDeb      NUMBER;         -- Pour connaitre la position de d�but de la chaine � extraire.
  posFin      NUMBER;         -- Pour connaitre la position de fin de la chaine � extraire.
  strInter    VARCHAR2(100);  -- Cha�ne interm�diaire pour traiter les p�riodes.  

BEGIN
    
    -- On supprime les enregistrements de PROG_ACTIV concernant le ProgId.
    DELETE PROG_ACTIV WHERE PROG_ID = ProgId;
    
    -- Traitement de ProgFonc.
    posDeb := 1;
    posFin := 1;
	
/*    if(ProgFonc ='') then 
	update prog set prog_actif=1 where prog_id=ProgId;
    else */
    
      WHILE (INSTR(ProgFonc, ';', posDeb)<>0) LOOP
      	posFin := INSTR(ProgFonc, ';', posFin);    
      	strInter := SUBSTR(ProgFonc, posDeb, posFin);
      	posFin := posFin+1;
      	posDeb := posFin;
      
      	IF (LPAD(strInter, 1)='T') THEN
        	saveTemporaire (ProgId, strInter);
      	ELSIF (LPAD(strInter, 1)='P') THEN
        	savePeriodique (ProgId, strInter);
      	END IF;
      END LOOP;
 --   end if;
    
 --   VerifActifProg();
 
END UpdateProgActiv;
/
--===========================================================================================================
-- JL - le 10/09/2007.
-- Proc�dure qui v�rifie les alarmes en cours et qui provoque la mont�e ou descente d'alarmes en cons�quence.
--Modif ZN 9/1/08 - recherche de tous les porgrammes concern�s par des alarms en cours.
--                - traitement des programmes actives et pas actives est identique 
--===========================================================================================================
create or replace
PROCEDURE VerifAlarmEnCours (ProgId NUMBER)
IS

  -- Curseur pour r�cup�rer les alarmes en cours.
  CURSOR curGetAlarmEnCours IS
    SELECT b.alarm_id
      FROM acces_accesc a, acces_accesc_rep b, acces_accesc2
      WHERE b.alarm_id IS NOT NULL
      AND a.commut = 0
      AND a.acces_accesc_id = b.acces_accesc_id
      AND a.acces_accesc_id = acces_accesc2_id;
   /* UNION
    SELECT c.alarm_id
      FROM bitmess_rep c, bitmess2
      WHERE c.alarm_id IS NOT NULL
      AND c.bitmess_id = bitmess2_id;*/

  -- Curseur pour r�cup�rer le nom des programmes concern�s par l'alarme en cours.
 /* CURSOR curGetProgsNoms (AlarmId NUMBER) IS
    SELECT alarm3_prconc
      FROM alarm3
      WHERE alarm3_id = AlarmId;*/

  -- Curseur pour r�cup�rer les informations d'une alarme.
  CURSOR curGetAlarm (AlarmId NUMBER)IS
    SELECT alarm_cl, alarm_numobj, alarm_grave, alarm_numal, alarm_info, equip_id
      FROM alarm
      WHERE alarm_id = AlarmId;

  -- Curseur pour r�cup�rer les programmes concern�s par une alarm � partir d'un �quipement.
/*  CURSOR curGetProgConc (EquipId NUMBER) IS
    SELECT prog_id
      FROM cablequ_equip, prog_cablequ
      WHERE equip_id = EquipId
      AND cablequ_equip.cablequ_id = prog_cablequ.cablequ_id;*/

  ProgActif         NUMBER(1);
  ProgNom           VARCHAR2(60);
  ReturnInsert      NUMBER;           -- Retour de la fonction InsertAlarm.
  cnt               NUMBER;

BEGIN

--   SELECT prog_actif into ProgActif FROM prog where prog_id = ProgId;

  -- V�rification des alarmes en cours.
  FOR valGetAlarmEnCours IN curGetAlarmEnCours LOOP

--    IF (ProgActif = 1) THEN
      -- Si le programme est actif.
      FOR valGetAlarm IN curGetAlarm (valGetAlarmEnCours.alarm_id) LOOP
        -- On recherche si l'alarme en cours peut concern� le programme.
        --FOR valGetProgConc IN curGetProgConc (valGetAlarm.equip_id) LOOP
          select count(*) into cnt from alarm_prog where
          alarm_id= valGetAlarmEnCours.alarm_id and prog_id=ProgId;
         -- IF (valGetProgConc.prog_id = ProgId) THEN
--    insert into TEST values (SEQ_TEST.NEXTVAL,'VerifAlarmEnCours alarm_id'|| valGetAlarmEnCours.alarm_id
-- || 'prog_id '||ProgId  || ' cnt= '||cnt);
          IF (cnt>0) THEN
            -- On tombe l'alarme et on la remonte afin que le programme ne soit pas concern�.
            ReturnInsert := InsertAlarm (valGetAlarm.alarm_cl, valGetAlarm.alarm_numobj, to_char(sysdate, 'YYYY MM DD HH24:MI:SS'), 0,
                                          valGetAlarm.alarm_numal, valGetAlarm.alarm_info, valGetAlarm.equip_id);

            IF (ReturnInsert = 1) THEN
              ReturnInsert := InsertAlarm (valGetAlarm.alarm_cl, valGetAlarm.alarm_numobj, to_char(sysdate, 'YYYY MM DD HH24:MI:SS'),
                                            valGetAlarm.alarm_grave, valGetAlarm.alarm_numal, valGetAlarm.alarm_info, valGetAlarm.equip_id);
            END IF;
          END IF;
      --END LOOP;
      END LOOP;
 /*   ELSE
      -- Si le programme est inactif.
      -- V�rification si le programme est concern� par une ou plusieurs alarmes en cours.
      FOR valGetProgsNoms IN curGetProgsNoms (valGetAlarmEnCours.alarm_id) LOOP
        SELECT prog_nom into ProgNom FROM prog WHERE prog_id=ProgId;

        IF (INSTR(valGetProgsNoms.alarm3_prconc, ProgNom, 1)<>0) THEN
          -- On tombe l'alarme et on la remonte afin que le programme ne soit pas concern�.
          FOR valGetAlarm IN curGetAlarm (valGetAlarmEnCours.alarm_id) LOOP
            ReturnInsert := InsertAlarm (valGetAlarm.alarm_cl, valGetAlarm.alarm_numobj, to_char(sysdate, 'YYYY MM DD HH24:MI:SS'), 0,
                                          valGetAlarm.alarm_numal, valGetAlarm.alarm_info, valGetAlarm.equip_id);

            IF (ReturnInsert = 1) THEN
              ReturnInsert := InsertAlarm (valGetAlarm.alarm_cl, valGetAlarm.alarm_numobj, to_char(sysdate, 'YYYY MM DD HH24:MI:SS'),
                                            valGetAlarm.alarm_grave, valGetAlarm.alarm_numal, valGetAlarm.alarm_info, valGetAlarm.equip_id);
            END IF;
          END LOOP;
        END IF;
      END LOOP;
    END IF;*/

  END LOOP;
END;
/
--==================================================================================
-- JL - le 10/09/2007.
-- Proc�dure qui permet l'�tat actif ou non d'un programme selon ses plages horaire.

-- Modif ZN 21/11/07 - si le param. ALARM_SERVICE=0 on fait rien pour ne pas 
-- relentir la base, trigger tiu_param a deja fait cette travaille.
-- Changement du curseur curGetProgActiv - il faut traiter tous les intervales 
-- d'un programme en meme temp et pas un par un. 
-- Prend en compte des intervales avec date_debut ou date_fin = NULL.

-- Cette procedure est appel�e chaque minute par le dbms_job
--==================================================================================
CREATE OR REPLACE PROCEDURE VerifActifProg
IS

  -- Recherche les plages horaires pour un programme donn�.
/*  CURSOR curGetProgActiv (ProgId NUMBER) IS
    SELECT date_debut, date_fin
      FROM PROG_ACTIV
      WHERE prog_id = ProgId;*/
      
  -- Tous les programmes qui peuvent changer l'etat d'activit�.    
  CURSOR curGetAllProg IS
    SELECT prog_id, prog_actif
      FROM PROG
      WHERE prog_fonc IS NOT NULL or prog_actif=0;
  
  -- V�rification du param�tre "ALARM_SERVICE".    
  CURSOR curParamALARMSERVICE is
  select param_valeur FROM param WHERE param_type = 9 AND param_valeur LIKE 'ALARM_SERVICE%';
   
  strParam    VARCHAR2(40); 
  todayDate   DATE;
  flagActif   NUMBER;
  cnt         NUMBER;
  changed     NUMBER;
  
BEGIN
  -- V�rification du param�tre "ALARM_SERVICE".
  for valParamALARMSERVICE in curParamALARMSERVICE loop
    strParam := valParamALARMSERVICE.param_valeur;
    exit;
  end loop;  
  
  IF(SUBSTR(strParam, 15, 1)= '1') THEN

   -- R�cup�ration de la date du jour.
    SELECT sysdate INTO todayDate FROM dual;
    
    FOR valGetAllProg IN curGetAllProg LOOP
       
      select count(*) into cnt from prog_activ where
        prog_id=valGetAllProg.prog_id and 
        (date_debut<=todayDate and date_fin>todayDate or
        date_debut is NULL and date_fin>todayDate or
        date_debut<=todayDate and date_fin is NULL);
          
      if(cnt>0) then
        flagActif := 0;
      else
        flagActif := 1;
      end if;  
    
--    insert into TEST values (SEQ_TEST.NEXTVAL,'VerifActifProg '|| strParam || 'prog_id '||valGetAllProg.prog_id
--        || ' flagActif '||flagActif);
        
      -- Mise � jour du champ PROG_ACTIF de la table PROG.
      IF (flagActif <> valGetAllProg.prog_actif) THEN
        UPDATE PROG SET PROG_ACTIF = flagActif WHERE PROG_ID = valGetAllProg.prog_id;
        
        -- Mise � jours des alarmes en cours.
        VerifAlarmEnCours(valGetAllProg.prog_id);
      END IF;
    END LOOP;--curGetAllProg
  ELSIF (SUBSTR(strParam, 15, 1)= '0') THEN
    
    select count(*) into cnt from param_histo;
    if(cnt>0) then
        select alarm_service_changed into changed from param_histo;	
     else
        insert into param_histo values (0);
        changed := 0;
     end if;
     
    if(changed=1) then
    
      -- On met tous les programmes comme actifs, les plages horaires ne sont pas prises en compte.
      FOR valGetAllProg IN curGetAllProg LOOP
         
        IF ( valGetAllProg.prog_actif < 1) THEN
          UPDATE PROG SET PROG_ACTIF = 1 WHERE PROG_ID = valGetAllProg.prog_id;
     
          -- Mise � jours des alarmes en cours.
          VerifAlarmEnCours(valGetAllProg.prog_id);
        end if;
      END LOOP;
        
      update param_histo set	alarm_service_changed =0;
        	
    end if;
  END IF;  
    
END VerifActifProg;
/

create or replace
FUNCTION AccesGetFather
(
 lModelSiteId	number,
 lSiteId	ACCES.SITE_ID%TYPE,
 lTypeqId	ACCES.TYPEQ_ID%TYPE,
 lModelEquipId	number,
 lEquipId	ACCES.EQUIP_ID%TYPE,
 lModelLiaiId	number,
 lLiaiId	ACCES.LIAI_ID%TYPE,
 lId	OUT	NUMBER
)
RETURN VARCHAR2 IS
	nb_rel		NUMBER;
	Father		VARCHAR2(30);
BEGIN
	nb_rel := 0;
	if (lModelSiteId is not null) then
		nb_rel := nb_rel + 1;
		Father := 'MODELSITE';
		lId := lModelSiteId;
	end if;

	if (lSiteId is not null) then
		nb_rel := nb_rel + 1;
		Father := 'SITE';
		lId := lSiteId;
	end if;

	if (lTypeqId	is not null) then
		nb_rel := nb_rel + 1;
		Father := 'TYPEQ';
		lId := lTypeqId;
	end if;

	if (lModelEquipId is not null) then
		nb_rel := nb_rel + 1;
		Father := 'MODELEQUIP';
		lId := lModelEquipId;
	end if;

	if (lEquipId	is not null) then
		nb_rel := nb_rel + 1;
		Father := 'EQUIP';
		lId := lEquipId;
	end if;

	if (lModelLiaiId is not null) then
		nb_rel := nb_rel + 1;
		Father := 'MODELLIAI';
		lId := lModelLiaiId;
	end if;

	if (lLiaiId is not null) then
		nb_rel := nb_rel + 1;
		Father := 'LIAI';
		lId := lLiaiId;
	end if;

	if (nb_rel != 1) then
	    RAISE_APPLICATION_ERROR (-20000,
              'An access row should have one and only one relation with an other table');
	    -- Ne pas mettre la ligne ci-dessus sur 2 lignes, sinon on ne pourra pas l'extraire.
	end if;

	RETURN Father;
END;
/

create or replace
FUNCTION AlarmGereeGetFather
(
 lAccesId	ACCES.ACCES_ID%TYPE,
 lObjetId       OUT NUMBER
)
RETURN VARCHAR2 IS
	lModelSiteId	number;
	lSiteId		ACCES.SITE_ID%TYPE;
	lTypeqId	ACCES.TYPEQ_ID%TYPE;
	lModelEquipId	number;
	lEquipId	ACCES.EQUIP_ID%TYPE;
	lModelLiaiId	number;
	lLiaiId		ACCES.LIAI_ID%TYPE;
	lId		NUMBER;

BEGIN
SetTrace ('AccesId ' || lAccesId);
	SELECT site_id, typeq_id, equip_id, liai_id
	INTO lSiteId, lTypeqId, lEquipId, lLiaiId
	FROM acces
	WHERE acces_id = lAccesId;

	IF lSiteId IS NULL AND lTypeqId IS NULL AND lLiaiId IS NULL THEN
		RAISE_APPLICATION_ERROR (-20000, 'ALARMGEREE should concern a site or a link or an equipement type');
	END IF;

	RETURN AccesGetFather (lModelSiteId, lSiteId, lTypeqId, lModelEquipId, lEquipId, lModelLiaiId, lLiaiId, lObjetId);
END AlarmGereeGetFather;
/

create or replace
FUNCTION AccesCalculUnicite 
(
 IdObjet	NUMBER,
 TableObjet	VARCHAR2,
 NomAcces	ACCES.ACCES_NOM%TYPE
)
RETURN VARCHAR2 IS
BEGIN
	IF IdObjet IS NULL OR TableObjet IS NULL THEN
		RAISE_APPLICATION_ERROR (-20000, 'AccesCalculeUnicite() : ID or Father table not filled');
	END IF;
	RETURN TableObjet || '/' || to_char (IdObjet) || '/' || NomAcces;
END;
/


---------------------------------------------------------------------------------------------
--
-- Copie de toutes les alarmes g�r�es d'un acc�s boucle. Ne doit pas �tre exploit�e pour un
-- acc�s s�rie.
--
-- X.L. Cr�ation le 18/09/98
-- Modif. X.L. le 11/05/99 pour ne pas lier la copie de la fiche au fait que la colonne
-- fiche_id de l'alarme soit non nulle; en effet, cette colonne n'est en g�n�ral pas mise � jour.
-- Modif. G.G. le 07/10/03 la colonne val_id n'est plus utilis�e
---------------------------------------------------------------------------------------------

create or replace
PROCEDURE CopAlarmGeree
(TypeObjet VARCHAR2,		-- Type de l'objet devant poss�der la future alarme
 lIdPere NUMBER,		-- Id du p�re de la future alarme
 lIdOrg NUMBER,			-- ID de l'acc�s d'origine
 lIdCop NUMBER			-- Id de l'acc�s copi�
)
IS
	lIdAlCop	NUMBER;

	CURSOR Calarm IS
		SELECT alarmgeree_id, 
--		       fiche_id, val_id, alarmgeree_nom, alarmgeree_acq, alarmgeree_son,
		       alarmgeree_nom, alarmgeree_acq, alarmgeree_son,
		       alarmgeree_typson, alarmgeree_min, alarmgeree_typal, alarmgeree_freqn,
		       alarmgeree_freqd, alarmgeree_grave, alarmgeree_local, alarmgeree_nseuil, 
		       alarmgeree_seuilb,
		       alarmgeree_seuilh, alarmgeree_corr, alarmgeree_comment,
		       alarmgeree_protocol, alarmgeree_unicite, alarmgeree_classid
		FROM alarmgeree
		WHERE acces_id = lIdOrg;

BEGIN

	FOR Rec IN Calarm LOOP

		-- Cr�ation d'une nouvelle alarme concernant le nouvel acc�s		
		INSERT INTO alarmgeree
			(alarmgeree_id, 
--			fiche_id, val_id, acces_id, alarmgeree_nom, alarmgeree_acq, alarmgeree_son,
			acces_id, alarmgeree_nom, alarmgeree_acq, alarmgeree_son,
			alarmgeree_typson, alarmgeree_min, alarmgeree_typal, alarmgeree_freqn,
			alarmgeree_freqd, alarmgeree_grave, alarmgeree_local, alarmgeree_nseuil, 
			alarmgeree_seuilb, alarmgeree_seuilh, alarmgeree_corr,
			alarmgeree_comment, alarmgeree_protocol, alarmgeree_unicite,
			alarmgeree_classid)
		VALUES (seq_alarmgeree.NEXTVAL, 
--			NULL, NULL, NULL, lIdCop, Rec.alarmgeree_nom, Rec.alarmgeree_acq,
                        lIdCop, Rec.alarmgeree_nom, Rec.alarmgeree_acq,
			Rec.alarmgeree_son, Rec.alarmgeree_typson, Rec.alarmgeree_min,
			Rec.alarmgeree_typal,
			Rec.alarmgeree_freqn, Rec.alarmgeree_freqd, Rec.alarmgeree_grave,
			Rec.alarmgeree_local,
			Rec.alarmgeree_nseuil, Rec.alarmgeree_seuilb, Rec.alarmgeree_seuilh,
			Rec.alarmgeree_corr, Rec.alarmgeree_comment, Rec.alarmgeree_protocol,
			TypeObjet || '/' || to_char (lIdPere) || '/' || Rec.alarmgeree_nom,
			Rec.alarmgeree_classid);

		-- D�termination de l'Id de la nouvelle alarme
		SELECT seq_alarmgeree.CURRVAL INTO lIdAlCop FROM dual;

		-- Copie de la fiche de l'alarme si celle-ci existe
		--CopFiche ('ALARMGEREE', 'ALARMGEREE', Rec.alarmgeree_id, lIdAlCop);

		-- Copie des causes possibles de l'alarme

		INSERT INTO alarmg_cause (alarmgeree_id, causeal_id)
		SELECT lIdAlCop, causeal_id FROM alarmg_cause
		WHERE alarmgeree_id = Rec.alarmgeree_id;

		-- Compl�ter, si n�cessaire par copie des relations de regroupement d'alarme.
	END LOOP;

END	CopAlarmGeree;
/


/*
* GenAccesAccesc
*/
---------------------------------------------
--
-- G�n�ration de l'enregistrement acces_accesc correspondant � un acc�s de type TRAP.
-- Cette fonction est appel�e lorsqu'on g�n�re les acc�s d'un �quipement � partir
-- des acc�s d'un type d'�quipement et que l'acc�s origine est de type TRAP SNMP
--
-- X.L. Cr�ation le 29/09/00
-- JPB  Modif le 04/10/02 : ajout de EQUIP_INDEXSNMP
--
-- X.L. Modif. le 17/02/04 : ajout de la prise en compte de la temporisation
-- ALARMGEREE_MIN et de l'indicateur d'alarme � surveiller ALARMGEREE_TOSURV.
--
-- JPB  Modif le 08/03/04 : appel de SetMaskAdmAccess
--
-- X.L. Modif. le 12/11/04 : ajout de la prise en compte des seuils haut et bas.
--
---------------------------------------------
CREATE OR REPLACE PROCEDURE GenAccesAccesc
(TypeqId        NUMBER,		-- ID du type d'�quipement correspondant
 TypeqAccesId	NUMBER,		-- ID de l'acc�s du type d'�quipement correspondant
 EquipIdCop	NUMBER,		-- ID de l'�quipement copi�
 lIdAccesCop	NUMBER		-- ID de l'acc�s g�n�r� de l'�quipement
)
IS
	lAlarmGereeId   	alarmgeree.alarmgeree_id%TYPE;
	lAlarmGereeGrave	alarmgeree.alarmgeree_grave%TYPE;
	lAlarmGereeMin		alarmgeree.alarmgeree_min%TYPE;
	lAlarmGereeToSurv	alarmgeree.alarmgeree_grave%TYPE;
	lAlarmGereeSeuilB	alarmgeree.alarmgeree_seuilb%TYPE;
	lAlarmGereeSeuilH	alarmgeree.alarmgeree_seuilh%TYPE;
	lEquipAddrIp		equip.equip_addrip%TYPE;
	lEquipIndex		equip.equip_indexsnmp%TYPE;
	lEquipTrapNom		equip.site_equip_comment%TYPE;
	nIndex			NUMBER;
	lAccesAccescId		NUMBER;
	lEquipToSurv		NUMBER;

BEGIN
	select SEQ_ACCES_ACCESC.NEXTVAL into lAccesAccescId from DUAL;

	SELECT alarmgeree_id, alarmgeree_grave, alarmgeree_min, alarmgeree_tosurv, 
		alarmgeree_seuilb, alarmgeree_seuilh,
		equip_addrip, equip_indexsnmp, site_equip_comment, equip_tosurv
	INTO lAlarmGereeId, lAlarmGereeGrave, lAlarmGereeMin, lAlarmGereeToSurv,
	     lAlarmGereeSeuilB, lAlarmGereeSeuilH,
	     lEquipAddrIp, lEquipIndex, lEquipTrapNom, lEquipToSurv
	FROM alarmgeree, equip
	WHERE acces_id = TypeqAccesId
	AND   equip_id = EquipIdCop;

	nIndex := INSTR (lEquipTrapNom, ':');
	IF (nIndex > 0) THEN
		lEquipTrapNom := RTRIM (SUBSTR (lEquipTrapNom, 1, nIndex - 1));
	END IF;

	INSERT INTO acces_accesc (acces_accesc_id, acces_bindingid,
				  acces1_id, acces2_id,
				  acces_bindingclassid, alarmgeree_id,
				  alarmgeree_grave, alarmgeree_min, alarmgeree_tosurv,
				  alarmgeree_seuilb, alarmgeree_seuilh,
				  equip_addrip, equip_indexsnmp,
				  typeq_id, equip_trapnom, commut)
	VALUES (lAccesAccescId, EquipIdCop, lIdAccesCop, 0, 8, lAlarmGereeId, 
		lAlarmGereeGrave, lAlarmGereeMin, lAlarmGereeToSurv,
		lAlarmGereeSeuilB, lAlarmGereeSeuilH,
		lEquipAddrIp, lEquipIndex, TypeqId, lEquipTrapNom, 0);

	if lEquipToSurv = 0  then		-- Il faut masquer l'acc�s alarme
		SetMaskAdmAccess (lAccesAccescId, 2);
	end if;
END	GenAccesAccesC;
/


---------------------------------------------
--
-- G�n�ration des enregistrements acces_accesc correspondant aux acc�s de type TRAP.
-- Cette fonction est appel�e apr�s cr�ation de l'alarme g�r�e d'un acc�s alarme TRAP
-- d'un type d'�quipement, pour g�n�rer l'acces_accesc de chaque acc�s correspondant
-- de chaque �quipement existant du type.
--
-- La fonction est appel�e que l'alarme g�r�e corresponde � un acc�s de type d'�quipement,
-- de liaison, de site; c'est donc � elle de v�rifier que les conditions sur l'acc�s sont
-- requises pour cr�er les acces_accesc
--
-- X.L. Cr�ation le 04/10/00
--
---------------------------------------------
CREATE OR REPLACE PROCEDURE GenAllAccesAccesc
(
	lAccesId	NUMBER
)
IS
	lCle		acces.acces_unicite%TYPE;
	lAccesEquipId	acces.acces_id%TYPE;
	lTypeqId	typeq.typeq_id%TYPE;
	strAccesNom	acces.acces_nom%TYPE;
	lAccesType	acces.acces_type%TYPE;
	

	CURSOR CEquip IS
		SELECT equip_id FROM equip WHERE typeq_id = lTypeqId;

BEGIN
	-- V�rification que l'acc�s est bien un acc�s de type d'�quipement et qu'il est
	-- de type TRAP SNMP
	SELECT typeq_id, acces_nom, acces_type
	INTO lTypeqId, strAccesNom, lAccesType
	FROM acces WHERE acces_id = lAccesId;

	IF (lTypeqId IS NOT NULL AND lAccesType = 9) THEN
		FOR rCEquip IN CEquip LOOP
			lCle := 'EQUIP/' || to_char (rCEquip.equip_id) || '/' || strAccesNom;
			SELECT acces_id INTO lAccesEquipId FROM acces WHERE acces_unicite = lCle;
			GenAccesAccesc (lTypeqId, lAccesId, rCEquip.equip_id, lAccesEquipId);
		END LOOP;
	END IF;
END	GenAllAccesAccesc;
/



create or replace
PROCEDURE DelLiaiLiaic
(
	lBddId		NUMBER	-- Id de la liaison
)
IS
 /*   cursor CProg is
	select PROG_ID from PROG_LIAITEMPU
	    where LIAI_ID = lBddId;

	  cursor CTop is
	select TOP_ID from TOP_LIAITEMPU
	    where LIAI_ID = lBddId;*/

BEGIN
 /*   FOR vProg in CProg LOOP
	   DelSupportLiaiTempu (vProg.PROG_ID, 'PROG', lBddId, false);
	--   ProgTProg (vProg.PROG_ID);
    END LOOP;

    FOR vTop in CTop LOOP
	   DelSupportLiaiTempu (vTop.TOP_ID, 'TOP', lBddId, false);
	--   TopTTop (vTop.TOP_ID);
    END LOOP;*/

    delete LIAI_LIAIC
	where LIAI_ID = lBddId;
END	DelLiaiLiaiC;
/



create or replace
PROCEDURE CreLiaiLiaic
(
	lBddId		NUMBER,		-- Id de la liaison
	lSuppId		NUMBER		-- Id du support
)
IS

	integrity_error	EXCEPTION;
	errno		INTEGER;
	errmsg		CHAR (200);
	lTypeSupte	NUMBER;		-- Type de la liaison support�e
	lTypeSupp	NUMBER;		-- Type de la liaison support
	lNbMaxSupte	NUMBER;		-- Nombre de support�s max. possibles du type
	lNbSupte	NUMBER;		-- Nombre de support�s effectifs du type

	/*CURSOR CurNbSupte IS
		SELECT typliai_typliai_nb FROM typliai_typliai
		WHERE  typliai_id = lTypeSupte AND typliai_bindingid = lTypeSupp;*/

  /*  	cursor CProg is
		select PROG_ID from PROG_LIAITEMPU
	    	where LIAI_ID = lBddId;

 	cursor CTop is
		select Top_ID from Top_LIAITEMPU
	    	where LIAI_ID = lBddId;*/

BEGIN

	-- S'il n'y a pas de support, on se contente de mettre � jour PROG_LIAITEP et TEMPU
	-- (gr�ce � SupportLiai) et ProgTProg

/*	IF lSuppId = 0 THEN
    	FOR vProg in CProg LOOP
	    	SupportLiaiTempu (vProg.PROG_ID, 'PROG', lBddId, true); -- Recherche toutes les liaisons / supports du prog.
	  --  	ProgTProg (vProg.PROG_ID);
     	END LOOP;

     	FOR vTop in CTop LOOP
	    	SupportLiaiTempu (vTop.Top_ID, 'TOP', lBddId, true); -- Recherche toutes les liaisons / supports de la topologie.
	  --  	TOPTTOP (vTop.Top_ID);
     	END LOOP;

	    RETURN;
	END IF;*/

	-- Insertion de l'enregistrement liai_liaic

	INSERT INTO liai_liaic (liai_id, liai_bindingid) VALUES (lBddId, lSuppId);

	-- Recherche du type de la liaison support�e

	SELECT typliai_id INTO lTypeSupte FROM liai WHERE liai_id = lBddId;

	-- Recherche du type de la liaison support

	SELECT typliai_id INTO lTypeSupp FROM liai WHERE liai_id = lSuppId;

	-- Recherche du nombre de support�s possibles du type lTypeSupte pour le support

/*	lNbMaxSupte := 0;
	FOR rcCur IN CurNbSupte LOOP
		lNbMaxSupte := rcCur.typliai_typliai_nb;
		EXIT;
	END LOOP;

	-- Recherche du nombre de support�s r�els de ce type pour le support

	SELECT	count (*) INTO lNbSupte FROM liai_liaic, liai
	WHERE	liai_bindingid = lSuppId
	AND	liai.liai_id = liai_liaic.liai_id
	AND	typliai_id = lTypeSupte;

	IF lNbSupte > lNbMaxSupte THEN
      errno  := -20002;
	    errmsg := 'Nombre maximum de support�s autoris� de ce type, d�pass� pour le support';
	    RAISE integrity_error;
	END IF;*/

/*	FOR vProg in CProg LOOP
     SupportLiaiTempu (vProg.PROG_ID, 'PROG', lBddId, true); -- Recherche toutes les liaisons / supports du prog.
  --   ProgTProg (vProg.PROG_ID);
 	END LOOP;

 	FOR vTop in CTop LOOP
	  SupportLiaiTempu (vTop.Top_ID, 'TOP', lBddId, true); -- Recherche toutes les liaisons / supports de la topologie.
--	  TOPTTOP (vTop.Top_ID);
  END LOOP;*/

--  gestion des erreurs
EXCEPTION
    WHEN integrity_error THEN
       raise_application_error (errno, errmsg);
END	CreLiaiLiaiC;
/



create or replace FUNCTION ExtractValeurSeuil
(
 AlarmInfo	ALARM.ALARM_INFO%TYPE,
 VSeuil	OUT	NUMBER
)
RETURN BOOLEAN
IS
--
-- Cette fonction extrait la valeur du seuil mesur� et qui a
-- provoqu� l'alarme.
-- Le format du message le contenant est le suivant :
-- "Seuil non respect� (Seuil bas : xx; Seuil haut: yy; Mesure: zz)"
-- X.L. Cr�ation le 27/11/09
--

	nPosParentheseOuvrante	NUMBER;
	nPosParentheseFermante	NUMBER;
	nPos2pointSeuilBas	NUMBER;
	nPos2pointSeuilHaut	NUMBER;
	nPos2PointMesure	NUMBER;
	nPosPointVirgSeuilBas	NUMBER;
	nPosPointVirgSeuilHaut	NUMBER;
BEGIN
	-- V�rification globale du format
	nPosParentheseOuvrante := INSTR (AlarmInfo, '(');
	IF (nPosParentheseOuvrante = 0) THEN
		return FALSE;
        END IF;

	nPos2pointSeuilBas := INSTR (AlarmInfo, ':', nPosParentheseOuvrante);
	IF (nPos2pointSeuilBas = 0) THEN
		RETURN FALSE;
        END IF;
        
	nPosPointVirgSeuilBas := INSTR (AlarmInfo, ';', nPos2pointSeuilBas);
	IF (nPosPointVirgSeuilBas = 0) THEN
		RETURN FALSE;
        END IF;
        
	nPos2pointSeuilHaut := INSTR (AlarmInfo, ':', nPosPointVirgSeuilBas);
	IF (nPos2pointSeuilHaut = 0) THEN
		RETURN FALSE;
        END IF;
        
	nPosPointVirgSeuilHaut := INSTR (AlarmInfo, ';', nPos2pointSeuilHaut);
	IF (nPosPointVirgSeuilHaut = 0) THEN
		RETURN FALSE;
        END IF;
        
	nPos2PointMesure := INSTR (AlarmInfo, ':', nPosPointVirgSeuilHaut);
	IF (nPos2PointMesure = 0) THEN
		RETURN FALSE;
        END IF;
        
	nPosParentheseFermante := INSTR (AlarmInfo, ')', nPos2PointMesure);
	IF (nPosParentheseFermante = 0) THEN
		RETURN FALSE;
        END IF;
        
	IF (nPosParentheseFermante - nPos2PointMesure <= 2) THEN	-- pas de valeur
		return false;
        END IF;
        
	IF (CheckStr (substr (AlarmInfo, nPos2PointMesure + 2, nPosParentheseFermante - nPos2PointMesure - 2), '0123456789,.-') = 0) THEN
		RETURN FALSE;
        END IF;
        
	VSeuil := to_number (substr (AlarmInfo, nPos2PointMesure + 2, nPosParentheseFermante - nPos2PointMesure - 2));
	RETURN TRUE;
	
END ExtractValeurSeuil;
/
