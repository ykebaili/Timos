--========================================================================================
--
-- La procédure SetTrace n'est exploitable qu'à partir de la version 8i de la bdd
-- elle permet d'inscrire, à partir d'un programme PL/SQL, des traces dans la table TRACE
-- même si ce programme n'inclut pas de commit.
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
-- La procédure SetErreurApp n'est exploitable qu'à partir de la version 8i de la bdd
-- elle permet d'inscrire, à partir d'un programme PL/SQL, les erreurs applicatives
-- dans la table  ERREURAPP même si ce programme n'inclut pas de commit.
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
--	API liées à la fiche
--	Créés par JPB 2001
--	Modif. par ZN 2005
--	Modif. par JPB le 31/08/2006 :
--	    Suite au traitement des contrôles, simplification des API.
--	    Le traitement des GetFromForm***  est fait dans GetFromFormIdO, qui utilise
--  	    l'Id de l'élément, l'Id de l'onglet et un paramètre pour indiquer si l'on sort la valeur ou le code d'une combo.
--	    Les autres doivent appeler ce traitement.
--
--===================================================================================

CREATE OR REPLACE FUNCTION GetStr (Val VARCHAR2, Indx NUMBER, Sep VARCHAR2)
RETURN VARCHAR2
/*
   Recherche une sous-chaîne dans une chaîne (1024 car. max.).
   Les sous-chaînes sont séparées par le caractère 'Sep'. La chaîne doit se terminer par 'Sep'.
   L'index de la sous-chaîne part de 0.
   Retourne la sous-chaîne ou '' si non trouvée.
*/

IS
    Res		VARCHAR2 (1024);/* résultat */
    Suiv	VARCHAR2 (1024);/* suite de la chaîne */
    Pos		NUMBER;		/* position de Sep dans la chaîne */
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
-- Recherche l'ID d'un élément dans une table, à partir du nom de la table et du
-- nom de l'élément dans cette table. Ceci pour un élément doté d'une fiche.
--
-- Met à jour EltId si l'élément est trouvé, retourne alors TRUE,
-- retourne FALSE autrement.
--
-- X.L. création le 04/12/03
--
-- Renommé par JPB en GetEltNom : toutes les API se terminant en Id s'appellent par l'Id
-- et pas par le nom.

-- Modif JPB le 24/05/04 : Le traitement de la table ACCES ne tenait pas compte des accès d'équipements
--
-- Modif X.L. le 27/12/04 pour tenir compte des types de sites
--
-- Modif X.L. le 08/08/07 pour tenir compte de la modification de désignation des équipements
-- dans l'étiquette d'une vue. Le nom passé doit être conforme à ce choix (0 = par référence,
-- 1 = par position géographique, 2 = par commentaire, 3 par adresse IP + index SNMP)
-- Quand c'est par position géographique, le nom doit intégrer le site et la salle.
--------------------------------------------------------------------------------------

-- NOTE : en raison de la structure de ACCES, on ne sait pas désigner par son nom
--	  l'accès d'un équipement (il porte le même nom que l'accès du type d'équipement
--	  correspondant). Cette procédure retourne la valeur du champ de l'ACCES DU TYPE.
--

create or replace
FUNCTION GetEltNom
(
 TableNom	VARCHAR2,		-- Nom de la table où est enregistré l'élément
 EltNom		VARCHAR2,		-- Nom de l'élément recherché dans la table
 EltId OUT	NUMBER			-- ID de l'élément à renseigner
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
	Cette fonction retourne le débit de la liaison, en b/s
	Retourne -1 si erreur
*/
CREATE OR REPLACE FUNCTION GetDebitLiai
(
    LiaiId	NUMBER		-- Id liaison
)
RETURN NUMBER

IS
    DebitLu	NUMBER;		-- débit lu
    DebitU	NUMBER;		-- unité

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
--	Fin des API "Débit" et "Bande passante"
--============================================================================



--==============================================================================================
--
-- Modif. X.L. le 10/09/99
-- 
-- Concerne les procédures DelEntiteSerie et Del1Acces pour compléter le traitement
-- dans le cas où l'effacement est consécutif à la suppression d'un équipement
--
-- Modif JPB le 01/08/00
-- Pour tenir compte des modifications de la BDD (suppression de tables inutiles)
--
-- ModifJP Borg	: 28/02/02	Voir version 1.073
--
--==============================================================================================



--==============================================================================================
--
-- Cette fonction renvoie la valeur du paramètre demandé de la table PARAM
--
-- X.L. Création le 18/10/06
--
--==============================================================================================
CREATE OR REPLACE FUNCTION GetParamValue
(
 ParamName	VARCHAR2
)
RETURN VARCHAR2
IS
	Pos	NUMBER;				-- Position du caractère = dans le paramètre lu en table
	Val	PARAM.PARAM_VALEUR%TYPE;	-- Valeur du paramètre

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

		IF Pos = 0 THEN		-- Pas de valeur pour le paramètre
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
-- Cette fonction vérifie que les caractères d'une chaîne appartiennent à un ensemble donné
-- Retourne 1 si OK, 0 sinon.
--
-- JPB  Création le 05/01/03
---------------------------------------------
/*
* CheckStr
*/
CREATE OR REPLACE FUNCTION CheckStr
(
    lStr VARCHAR2,	-- Chaîne à tester
    lSet VARCHAR2	-- Ensemble des caractères autorisés
)
RETURN NUMBER
IS
    Len	NUMBER;		-- Longueur de lStr
    i	NUMBER;		-- Banal
    Car VARCHAR2 (5);	-- Caractère lu

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
   Vérifie la validité d'un nombre.
   Retourne sa valeur si OK, -1 sinon
*/

IS
   Nombre	NUMBER;		/* résultat */
   Longueur	NUMBER;		/* longueur de la chaîne de caractères */
   Car		CHAR;		/* caractère à la position i */
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
-- Création JFL le 22/02/05							--
-- MAJ      JFL le 16/05/05 : prise en compte des tables 'ARCH%' (PB classId).	--
-- 										--
--	Retourne  '<nom table>' = nom de la table trouvée			--
--	Retourne  'NULL' 	= aucune nom de table trouvé pour ce CLASSID	--
--										--  
-- X.L. le 06/06/05 Rétablissement d'une modif. portée sur la version 2.116b	--
-- écrasée par la suite : les variables Result, NomTable, NomColTmp et NomCol	--
-- passent à 40 caractères. En effet le nom d'une table fait au plus 30		--
-- caractères, donc celui d'une colonne est forcément plus grand. Fiche F023	--
-- TDF.										--
-- X.L. le 03/08/07 : l'ajout de la table ERRIMP et le fait que ERRIMP_CLASSID  --
-- pouvait contenir des classid d'autres tables comme la table SITE (ce qui est --
-- normal) faisait que le nom de la table SITE n'était pas retourné pour le     --
-- classid 1008 (c'est ERRIMP qui était retourné à la place).                   --
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

	    -- Création ordre SQL simple pour voir si le CLASSID
	    -- passé en paramètre est issu de cette table.

	    OrdreSql := 'Select count(*) from ' || NomTable || ' Where ' ||
			NomCol || ' = ' || BddClassID;
		
	    CDynId := dbms_sql.open_cursor;

	    -- Init.
	    dbms_sql.parse (CDynId, OrdreSql, dbms_sql.native);
	    dbms_sql.define_column (CDynId, 1, NbClassId);

	    RetCDyn := dbms_sql.execute(CDynId);

    	    IF (dbms_sql.fetch_rows (CDynId) > 0) THEN

		dbms_sql.column_value (CDynId, 1, NbClassId);

		-- CLASSID trouvé?
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
-- Recherche si une table possède bien une colonne qui porte le nom passé	--
-- en paramètre.								--
--										--
-- Création JFL le 22/02/05							--
--										--
--	Retourne  '<nomCol>' = colonne existante				--
--	Retourne  'NULL'     = colonne inexistante				--
--										--   
--==============================================================================--
CREATE OR REPLACE FUNCTION CheckNomCol
(
    NomTable	VARCHAR2,	-- table
    NomCol	VARCHAR2	-- Colonne à chercher
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
-- Donne le nom d'un objet à partir de son ID
--
-- X.L. Création le 19/04/05
--
CREATE OR REPLACE FUNCTION GetObjNameFromObjId
(
 ObjetType	VARCHAR2,		-- Type de l'objet (ex: 'SITE')
 ObjetId	NUMBER			-- ID de l'objet
)
RETURN VARCHAR2 IS
	CursorName	NUMBER;			-- Numéro du curseur dynamique
	SelOrder	VARCHAR2 (200);		-- Ordre SQL dynamique
	ObjetNom	VARCHAR2 (80);
	Result		NUMBER;			-- Résultat de la requête dynamique
BEGIN
	SelOrder := 'select ' || ObjetType || '_NOM from ' || ObjetType ||
			' where ' || ObjetType || '_id = :ObjId';

	CursorName := DBMS_SQL.OPEN_CURSOR;
	DBMS_SQL.PARSE (CursorName, SelOrder, dbms_sql.native);
	DBMS_SQL.DEFINE_COLUMN (CursorName, 1, ObjetNom, 80);
	DBMS_SQL.BIND_VARIABLE (CursorName, ':ObjId', ObjetId);
	Result := DBMS_SQL.EXECUTE_AND_FETCH (CursorName);	 -- Une seule rangée attendue
	DBMS_SQL.COLUMN_VALUE (CursorName, 1, ObjetNom);
    	DBMS_SQL.close_cursor (CursorName);

	RETURN ObjetNom;
END GetObjNameFromObjId;
/




-------------------------------------------------------------------------------------------
--
--	Conversions de date
--	JPB Création
-------------------------------------------------------------------------------------------

CREATE OR REPLACE FUNCTION CO_SEC1998 (Val VARCHAR2)
RETURN NUMBER	
/* 
   Convertit une date de début ou fin d'alarme (YYYY MM DD HH24:MI:SS) 
   en nombre de secondes depuis le 01/01/1998 00:00:00.
   Conversion valable jusqu'au 29/02/2020.
   Après, on sera mort, préparer le bug de l'an 2020 et du travail pour nos successeurs !

   Retourne -1 si la date est incorrecte.
   
   Modif le 26 Mai 2002, pour remplacer Year, Month etc.. par An, Mois etc.., car 
   Oracle a réservé ces noms dans la version 8.1 !!
*/

IS
    An		NUMBER;	/* année   1998 - 2020 */
    Mois	NUMBER; /* mois    1 - 12 */
    Jour	NUMBER; /* jour    1 - 31 */
    Heure	NUMBER; /* heure   0 - 23 */
    Minute	NUMBER; /* minute  0 - 59 */
    Seconde	NUMBER; /* seconde 0 - 59 */
    Result	NUMBER; /* résultat */

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
RETURN DATE	/* Convertit une date de début ou fin d'alarme au format date */
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
-- Masquage ou démasquage administrateur d'un accès alarme d'un équipement
--
-- Lorsque nMask vaut 2, il s'agit d'un masquage consécutif à la création d'un équipement;
-- dans ce cas, on met la colonne MSKADM_HOW à 2.
-- Ne traite pas les alarmes SERIE.
--
-- JPB création le 08/03/04
--
------------------------------------------------------------------------------------------------
CREATE OR REPLACE PROCEDURE SetMaskAdmAccess
(
	lAccesAccescId 	IN NUMBER,	-- ID de l'accès (sur ACCES_ACCESC)
	nMask	 	IN NUMBER	-- Masquage si 1 ou 2, démasquage si 0
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
-- Masquage ou démasquage administrateur des accès alarmes d'un équipement
--
-- Lorsque nMask vaut 2, il s'agit d'un masquage consécutif à la création d'un équipement;
-- dans ce cas, on met la colonne MSKADM_HOW à 2.
--
-- X.L. création le 28/11/03
--
------------------------------------------------------------------------------------------------
create or replace
PROCEDURE SetMaskAdmEquip
(
	lEquipId IN NUMBER,		-- ID de l'équipement
	nMask	 IN NUMBER		-- Masquage si 1 ou 2, démasquage si 0
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
		AND acces_bindingclassid = 8);		-- 8 = connexion à un EDC

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

	-- Masquage des alarmes série
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
-- JP. B. Création le 20/02/01
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
	-- Réservation du script avant effacement.

	SELECT script_nom INTO lScript
	FROM   script WHERE script_id = lObjId FOR UPDATE OF script_nom;

	
	-- Modification des flags du script lui-même.
	-- Il sera réellement effacé par l'Equipement de Médiation, après
	-- qu'il ait arrêté les procédures activées par le script.
	UPDATE script
	SET script_start = 0, script_stop = 1, script_kill = 1
	WHERE script_id = lObjId;

END;
/




---------------------------------------------
--
-- Recherche le nom des différents éléments gérés câblés sur l'IS NumIS.
-- IS GTR seulement (pour l'instant)
--
-- JPB  Création le 14/04/99 
--
-- X.L. Modif. le 08/10/99 remplacé EXT_NOM par EXT_VILLE
---------------------------------------------

CREATE OR REPLACE PROCEDURE CABLAGE_IS (NumIS NUMBER) IS
/* Recherche du câblage des IS */

    AlarmNumal  VARCHAR2 (40);	-- n° accès sur l'IS

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

    	for vCab in CabP loop	-- boucle sur tous les accès IS correspondant à ce NUMAL
				-- normalement, un seul accès
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

	end loop;	-- boucle sur les accès IS
    end loop;		-- boucle sur les NUMAL

    commit;
END;
/




---------------------------------------------
--
-- Fonction de détermination de l'index d'un sous équipement.
-- Part de l'équipement en cours et construit l'index complet
-- par concaténation des index locaux à chaque  équipement,
-- ceci en remontant la hiérarchie.
--
-- X.L. Création le 29/03/01
-- JPB  Modif le 11/11/01	erreur si l'index du père vaut 0
-- GG	Modif le 16/07/03	pas de récursivité
---------------------------------------------

CREATE OR REPLACE FUNCTION GetIndexSNMP
(
 EquipId		NUMBER		-- ID du sous équipement
)
RETURN VARCHAR2 IS

	EquipBindingId	NUMBER;				-- ID de l'équipement père
	EquipIndexSnmp	EQUIP.EQUIP_INDEXSNMP%TYPE;	-- Index SNMP de l'équipement
	FullIndexSnmp	VARCHAR2 (512);			-- Index SNMP concaténé
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
-- Parcours récursif des familles de Types d'equipements
-- Cette fonction retourne le "nom complet" (ie Famille / Sous-Famille / Sous-Sous-Famille etc..)
-- de la famille dont on donne l'Id de la feuille
--
-- JPB  Création le 24/01/02
--
---------------------------------------------

CREATE OR REPLACE FUNCTION GetFamilyName
(
    Id	  IN NUMBER		-- Id de la feuille
)
RETURN VARCHAR2 IS

    FamilyName	VARCHAR2 (2000);-- valeur à retourner
 
    cursor CName is		-- famille Père
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
-- Cette fonction retourne l'Id du "père" de la famille dont on donne l'Id,
-- ou 0 pour un équipement "sans famille"
(
    Id	  IN NUMBER		-- Id de la feuille
)
RETURN NUMBER IS

    FatherId	NUMBER;		-- valeur à retourner
 
    cursor CName is		-- famille Père
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
*	    Extrémité A, extrémité B, sens de la liaison et numéro
*/

--Modif Z.N. le 29/07/09. "EXT_VILLE || '/' || A.EXT_POINT" est remplacé par EXT_NOM car Timos
--remplit que EXT_NOM

CREATE OR REPLACE FUNCTION GetLiaiNom
(
    LiaiId	NUMBER		-- Id de la liaison
)
RETURN VARCHAR2
IS
    Nom		VARCHAR2 (60);	-- Nom recherché

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
*	à partir de l'ancien nom de cette liaison
*	et du nouveau nom d'une extrémité
*
*	X.L. Création le 26/10/04
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
	FOR i IN 1..2 LOOP		-- Car il y a deux extrémités qui peuvent porter le même nom
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
-- Recherche du nom d'un équipement, en tenant compte du paramétrage de l'application
-- éventuellement défini dans la table PARAM.
--
-- X.L. le 10/05/01
-- Modif JPB le 10/05/01
-- Modif. X.L. le 25/05/04 pour que la fonction marche avec un équipement 
-- de la classe CANTENNE_ID.
-- Modif. JFL le 02/03/05 : utilisation de la fonction 'RTRIM' sur variable SiteEquipComment 
-- pour supprimer tous les espaces situés en fin de chaîne (ceux ajoutés par ICMP).
-- Modif. JPB le 19/11/06. Correction d'une erreur si SiteEquipComment is not null and BaieEquipCarte is null
-- Modif. X.L. le 08/08/07 pour donner la représentation conforme à l'étiquetage demandé
-- et représenté par le flag EQUIP_ETIQ_VUE (0 = par référence, 1 = par position géographique
-- 2 = par commentaire, 3 = par adresse IP et index SNMP).
--
--=======================================================================================
create or replace FUNCTION GetEquipNom
(
    EquipId	NUMBER,		-- Id de l'équipement
    NomComplet  NUMBER		-- si 1, on indique en plus le nom de la salle
                                -- si 2, on indique encore en plus le nom du site
)
RETURN VARCHAR2

IS
    Nom		EQUIP.SITE_EQUIP_COMMENT%TYPE;	-- Nom recherché
	nPos	integer;			-- Position signe égal dans le paramètre
	strPar  PARAM.PARAM_VALEUR%TYPE;	-- Nom du paramètre
	strVal  PARAM.PARAM_VALEUR%TYPE;	-- Valeur du paramètre


	-- Paramètre indiquant de prendre pour libellés Travée, Cadre, Niche, etc. (valeur 0),
	-- ou Travée, Bâti, Châssis, etc. (valeur 1), pour un équipement fils dont le
	-- commentaire pour situer l'équipement est vide.
	nAffEquipLocalLibel integer;

	-- Paramètre indiquant, parmi les coordonnées Travée, Cadre, etc., quelles sont celles
	-- à afficher (b0=carte, b1=emplacement, b2=niche, etc.)
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

	-- Recherche des paramètres ayant une incidence sur le nom de l'équipement

	strCoord := 'TCNEC';	-- Travée, Cadre, Niche, Emplacement, Carte
	for rcParam in cParam loop
		nPos := instr (rcParam.param_valeur, '=');
		if (nPos > 0) then	-- c'est un paramètre du type NOM_PARAM=VALEUR
			strPar := substr (rcParam.PARAM_VALEUR, 1, nPos - 1);
			strVal := substr (rcParam.PARAM_VALEUR, nPos + 1);
		end if;

		if (strPar = 'AFF_EQUIP_LOCAL_LIBEL') then
			if (to_number (strVal) = 1) then
			    strCoord := 'TBCES';-- Travée, Bâti, Châssis, Emplacement, Slot
			end if;
		elsif (strPar = 'AFF_EQUIP_ETIQU_COORD') then
			nAffEquipEtiquCoord := to_number (strVal);
		end if;
	end loop;

	-- Recherche des champs permettant de nommer l'équipement
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
	else					-- C'est un équipement

		if (EquipEtiqVue = 0) then	-- Désignation par référence
			Nom := EquipRef;
		elsif (EquipEtiqVue = 2) then	-- Désignation par commentaire
			Nom := RTRIM (SiteEquipComment);
		elsif (EquipEtiqVue = 3) then	-- Désignation par adresse IP + index SNMP
			Nom := RTRIM (EquipAddrIp) || ' ' || RTRIM (EquipIndexSnmp);
		else				-- Désignation par coordonnées géographiques
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
--  Le site doit correspondre à une des deux extrémités.
--
CREATE OR REPLACE FUNCTION OutSite (LiaiId NUMBER, SiteId NUMBER)
RETURN NUMBER
IS
    SiteAId	NUMBER;		-- Id du site correspondant à LIAI_EXTAID
    SiteBId	NUMBER;		-- Id du site correspondant à LIAI_EXTBID
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
--  Cette fonction retourne un nombre égal à la chaîne de caractères, si celle-ci est un nombre.
--  Accepte le . et la , comme séparateur décimal.
--  Elle retourne -1 sinon.
--
CREATE OR REPLACE FUNCTION ToNumber (Str VARCHAR2)
RETURN NUMBER
IS
    Nbr	  NUMBER;		-- Résultat à retourner
    lStr  VARCHAR2 (40);	-- Chaîne temporaire

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
-- Cette fonction retourne 1 si une famille (définie par son ID et CLASS_ID) vaut un ID
-- prédéfini, ou est fils de cet ID prédéfini. Sinon, retourne 0.
--
CREATE OR REPLACE FUNCTION IsSonOf (ObjId NUMBER, ClassId NUMBER, FatherId NUMBER)
RETURN NUMBER
IS
    BindingId	NUMBER;		-- Nom de la famille père de celle-ci
    
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
--	dbms_output.put_line ('Exception rencontrée');
	return 0;
END  IsSonOf;
/



--
-- Cette fonction trie les OID dans l'ordre attendu pour une chaîne de caractères
-- Attention, les nombres exprimés entre deux points doivent être compris entre 0 et 35
--
-- Création : JPB le 23/07/04

CREATE OR REPLACE FUNCTION SortOID 
(
    StrOID	VARCHAR2	-- OID à remplacer
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
-- Ceci suppose que le programme de réplication
-- renseigne correctement l'enregistrement
-- d'ID 3 dans dbarep. Cet enregistrement est mis
-- à jour d'une manière statique par le programme
-- de réplication à son lancement puis à son arrêt.
-- Tant que la réplication est lancée, dbarep_etat
-- vaut 1 pour cet enregistrement sur un secours;
-- quand on l'arrête il est mis à zéro.
-- Cette fonction est exploitée dans PurgeAlarmes
-- pour savoir si la purge a lieu sur le NORMAL ou
-- sur le SECOURS (dans le cas du secours, les
-- tables MESSALRM, MAILALRM, LOGSPV sont complètement
-- effacées.
--
-- X.L. création le 16/01/07
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
--   Fonction permettant d'insérer une alarme en base de données
--   
--   Développée à l'origine pour l'E10
--
--	Retourne  1 si succès
--	Retourne  0 dans le cas contraire
--  
--=============================================================================
--
create or replace
FUNCTION InsertAlarm
(
 AlClasse	VARCHAR2,		-- Classe de l'alarme (IS, IS_S, TRAPS, E10B, etc.)
 AlNumObj	NUMBER,			-- Numéro d'objet (N° d'IS, N° trap, N° NIDAL pour E10, etc.)
 AlDate		VARCHAR2,		-- Date de l'événement d'alarme au format YYYY MM DD HH24:MI:SS
 AlGrave	NUMBER,			-- Gravité de l'alarme (7:critique, 6:majeure, 5:mineure, etc.)
 ALNumal	VARCHAR2,		-- Numéro d'entrée alarme (cas IS)
 AlInfo		VARCHAR2,		-- Texte de l'alarme
 EquipId	NUMBER			-- ID en BDD de l'équipement
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
		RAISE_APPLICATION_ERROR (-20000, 'Fonction InsertAlarm, renseigner les paramètres obligatoires');
	END IF;

	AlInfoLoc  := TRANSLATE (SUBSTR (AlInfo, 1, 256), '#', '$');
	AlClassLoc := AlClasse;
	AlNumalLoc := AlNumal;

	IF AlClassLoc = 'E10B' THEN
		AlComment := '6486';	-- N° IANA Alcatel

		IF AlnumalLoc IS NULL THEN
			SELECT site_equip_comment INTO EquipLoc FROM equip WHERE equip_id = EquipId;
			IF LENGTH (EquipLoc) > 40 THEN
				AlNumalLoc := to_char (EquipId);
			ELSE
				AlNumalLoc := EquipLoc;
			END IF;
		END IF;
	END IF;
	--SetTrace ('Classe : ' || AlClassLoc || ' NumObj ' || AlNumObj || ' Date ' || AlDate || ' Gravité ' || AlGrave || ' ALNumal ' || ALNumal || ' Comment ' || alComment || ' info ' || AlInfoLoc);

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
--   Fonction permettant de retrouver l'ID d'un équipement E10 Alcatel
--
--   Les coordonnées de l'équipement doivent être dans SITE_EQUIP_COMMENT.
--   Le format doit être NCEN-AGEO ou NCEN est le nom du central trouvé dans
--   les messages d'alarmes E10 et AGEO le champ AGEO idem.
--
--	Retourne  l'ID de cet équipement ou -1 si non trouvé
--  
--=============================================================================
--
create or replace
FUNCTION GetEquipE10
(
 Ncen		VARCHAR2,		-- Nom du central
 Ageo		VARCHAR2		-- Adresse géographique
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
--   Fonction effectuant la retombée des alarmes d'un équipement précis
--   et de ses sous-équipements si demandé.
--
--   X.L. création le 26/02/07
-- 
--=============================================================================
--
create or replace
PROCEDURE ResetAlarm2
(
 EquipId	equip.equip_id%TYPE,		-- ID de l'équipement
 Included	boolean				-- si TRUE, faire retomber en plus les alarmes des équipements inclus
) IS
	-- Recherche des alarmes en cours d'un équipement
	CURSOR CurAl IS
		SELECT alarm.*
		FROM alarm, acces_accesc_rep
        	WHERE acces_accesc_rep.equip_id = EquipId 
	      	AND acces_accesc_rep.alarm_id IS NOT NULL
		AND alarm.alarm_id = acces_accesc_rep.alarm_id;

	-- Recherche des équipements englobés dans un équipement
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
--   Fonction effectuant la retombée des alarmes des autocom. E10 Alcatel
--   pour un équipement de médiation donné.
--   On balaye la liste des équipements et sous équipements correspondant 
--   aux E10B sous sa dépendance; on fait retomber les alarmes présentes 
--   correspondantes.
--
--   Retourne 1 si succès, 0 si échec
--  
--   X.L. création le 26/02/07
--
--=============================================================================
--
create or replace
FUNCTION ResetE10 (EquipMed	VARCHAR2)
return number IS

	TypeE10Id	typeq.typeq_id%TYPE;		-- ID en BDD du type d'équipement E10
	Val		param.param_valeur%TYPE;	-- Valeur d'un paramètre
	Pos		NUMBER;				-- Position du séparateur
	Ind		NUMBER;				-- Index de parcours
	TypeE10Nom	typeq.typeq_nom%TYPE;
	ListEquip	VARCHAR2 (2000);		-- Liste des ID des équipements E10

	-- Recherche des types d'équipements E10 définis dans PARAM
	CURSOR CurParam IS
		SELECT param_valeur FROM param WHERE param_type = 9 AND param_valeur LIKE 'TYPE_E10=%';

	-- Recherche des équipements E10 d'un type père donné
	CURSOR CurE10 (TypeqNom	VARCHAR2) IS
		SELECT equip_id FROM equip WHERE typeq_nom = TypeqNom;

BEGIN
	-- Le paramètre de type 9, TYPE_E10= donne la liste des noms des types d'équipement
	-- de type E10 (correspondant au noms de centraux, c'est à dire à l'englobant)
	-- dans la BDD sous la forme TYPE_E10=E10B;E10;etc.

	-- Acquisition du paramètre TYPE_E10 dans la table PARAM
	FOR rCurParam IN CurParam LOOP
		Val := rCurParam.param_valeur;
	END LOOP;		

	IF Val IS NULL THEN
		--settrace ('ResetE10 : paramètre TYPE_E10 non spécifié dans la table PARAM');
		RETURN 0;
	END IF;

	-- Extraction de la valeur du paramètre	
	Pos := INSTR (Val, '=');
	IF Pos > 0 THEN
		Val := SUBSTR (Val, Pos + 1);
	END IF;

	-- Pour chaque type d'E10 on recherche les équipements correspondants
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
--   Fonction effectuant la retombée des alarmes d'un autocom. E10 Alcatel
--   précis.
--
--   Retourne 1 si succès, 0 si échec
--  
--   X.L. création le 09/03/07
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
-- Procédure appelée par le trigger tiub_equip.
-- Son contenu peut être spécifique à un client (ex: OPT).
--
-- X.L.  Création le 20/12/06
------------------------------------------------------
CREATE OR REPLACE FUNCTION SpecTiubEquip
(
 EmName    VARCHAR2		-- Nom de l'équipement de médiation
)
RETURN VARCHAR2 IS
BEGIN
    RETURN NULL;
END SpecTiubEquip;
/




--==============================================================================================
--
-- Cette fonction retourne les Mibs d'in type d'équipement.
-- Exploitée quand le rapport sur les types d'équipement est demandés.
-- 
-- EM. Création le 05/09/07.
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
-- Fonction qui retourne le numéro du jour dans la semaine en fonction de son libellé.
--====================================================================================
CREATE OR REPLACE FUNCTION getNumJour (libJour VARCHAR2) RETURN NUMBER
IS

  strLibJour    VARCHAR2(10);
  numJour       NUMBER;

BEGIN
  -- On passe en majuscule le libellé du jour.
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
-- Procédure pour gérer les données périodiques.

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
  
  -- Récupération du numéro du jour actuel.
  SELECT to_number(to_char(sysdate, 'D'), 99) INTO numJour FROM dual;
  
  SELECT sysdate INTO now FROM dual;
  
  -- Détermination des numéros des jours de début et de fin de période.
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
    
  -- Insertion en base de données.
  INSERT INTO PROG_ACTIV (PROG_ACTIV_ID, PROG_ID, DATE_DEBUT, DATE_FIN, ACTIV_TYPE)
   VALUES (seq_progactiv.nextval, ProgId, dateJourDeb, dateJourFin, 'P');
   
  select job into jobNb from user_jobs where what like 'MajProgActiv%';
  dbms_job.run(jobNb);

/*      
  -- Détermination des dates en fonction des numéros de jour.
  IF (numJour > numJourDeb) THEN
    SELECT (sysdate + ((numJourDeb-numJour)+7)) INTO dateJourDeb FROM dual;
  ELSIF (numJour = numJourDeb) THEN
    -- Si les 2 numéros de jours sont égaux, on vérifie les heures puis les minutes si besoin.
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
  
    -- Si les 2 numéros de jours sont égaux, on vérifie les heures puis les minutes si besoin.
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
    
  -- Insertion en base de données.
  INSERT INTO PROG_ACTIV (PROG_ACTIV_ID, PROG_ID, DATE_DEBUT, DATE_FIN)
    VALUES (seq_progactiv.nextval, ProgId, to_date(to_char(dateJourDeb, 'DD/MM/YYYY')||' '||strHeureDeb, 'DD/MM/YYYY HH24:MI')
              , to_date(to_char(dateJourFin, 'DD/MM/YYYY')||' '||strHeureFin, 'DD/MM/YYYY HH24:MI'));*/
END SavePeriodique;
/ 



--==============================================
-- JL - le 10/09/2007.
-- Procédure pour gérer les données temporaires.
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
  
  -- Insertion en base de données.
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
-- Procédure de mise à jour des dates.

-- ZN modif. 27/11/07 - on ne supprime pas des intervales de la semaine en cours
-- qui sont pas finis; on ne recalcule plus des intervales à partir de prog_fonc;
-- le traitement des nouveaux intervales defini dans le dialoques Plages Horaires
-- est deplacé dans la fonction UpdateProgActiv

-- Cette procedure est appelée chaque semaine par le dbms_job
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
  
      -- ajout 1 semaine à les dates passés 
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
-- Procédure de mise à jour des dates.
-- ZN modif. 28/11/07
-- Cette procedure est appelée à la modification de dialogue Plages Horaires
--====================================
CREATE OR REPLACE PROCEDURE UpdateProgActiv (ProgId NUMBER, ProgFonc VARCHAR2)
IS

  --===========
  -- Variables.
  --===========
  posDeb      NUMBER;         -- Pour connaitre la position de début de la chaine à extraire.
  posFin      NUMBER;         -- Pour connaitre la position de fin de la chaine à extraire.
  strInter    VARCHAR2(100);  -- Chaîne intermédiaire pour traiter les périodes.  

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
-- Procédure qui vérifie les alarmes en cours et qui provoque la montée ou descente d'alarmes en conséquence.
--Modif ZN 9/1/08 - recherche de tous les porgrammes concernés par des alarms en cours.
--                - traitement des programmes actives et pas actives est identique 
--===========================================================================================================
create or replace
PROCEDURE VerifAlarmEnCours (ProgId NUMBER)
IS

  -- Curseur pour récupérer les alarmes en cours.
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

  -- Curseur pour récupérer le nom des programmes concernés par l'alarme en cours.
 /* CURSOR curGetProgsNoms (AlarmId NUMBER) IS
    SELECT alarm3_prconc
      FROM alarm3
      WHERE alarm3_id = AlarmId;*/

  -- Curseur pour récupérer les informations d'une alarme.
  CURSOR curGetAlarm (AlarmId NUMBER)IS
    SELECT alarm_cl, alarm_numobj, alarm_grave, alarm_numal, alarm_info, equip_id
      FROM alarm
      WHERE alarm_id = AlarmId;

  -- Curseur pour récupérer les programmes concernés par une alarm à partir d'un équipement.
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

  -- Vérification des alarmes en cours.
  FOR valGetAlarmEnCours IN curGetAlarmEnCours LOOP

--    IF (ProgActif = 1) THEN
      -- Si le programme est actif.
      FOR valGetAlarm IN curGetAlarm (valGetAlarmEnCours.alarm_id) LOOP
        -- On recherche si l'alarme en cours peut concerné le programme.
        --FOR valGetProgConc IN curGetProgConc (valGetAlarm.equip_id) LOOP
          select count(*) into cnt from alarm_prog where
          alarm_id= valGetAlarmEnCours.alarm_id and prog_id=ProgId;
         -- IF (valGetProgConc.prog_id = ProgId) THEN
--    insert into TEST values (SEQ_TEST.NEXTVAL,'VerifAlarmEnCours alarm_id'|| valGetAlarmEnCours.alarm_id
-- || 'prog_id '||ProgId  || ' cnt= '||cnt);
          IF (cnt>0) THEN
            -- On tombe l'alarme et on la remonte afin que le programme ne soit pas concerné.
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
      -- Vérification si le programme est concerné par une ou plusieurs alarmes en cours.
      FOR valGetProgsNoms IN curGetProgsNoms (valGetAlarmEnCours.alarm_id) LOOP
        SELECT prog_nom into ProgNom FROM prog WHERE prog_id=ProgId;

        IF (INSTR(valGetProgsNoms.alarm3_prconc, ProgNom, 1)<>0) THEN
          -- On tombe l'alarme et on la remonte afin que le programme ne soit pas concerné.
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
-- Procédure qui permet l'état actif ou non d'un programme selon ses plages horaire.

-- Modif ZN 21/11/07 - si le param. ALARM_SERVICE=0 on fait rien pour ne pas 
-- relentir la base, trigger tiu_param a deja fait cette travaille.
-- Changement du curseur curGetProgActiv - il faut traiter tous les intervales 
-- d'un programme en meme temp et pas un par un. 
-- Prend en compte des intervales avec date_debut ou date_fin = NULL.

-- Cette procedure est appelée chaque minute par le dbms_job
--==================================================================================
CREATE OR REPLACE PROCEDURE VerifActifProg
IS

  -- Recherche les plages horaires pour un programme donné.
/*  CURSOR curGetProgActiv (ProgId NUMBER) IS
    SELECT date_debut, date_fin
      FROM PROG_ACTIV
      WHERE prog_id = ProgId;*/
      
  -- Tous les programmes qui peuvent changer l'etat d'activité.    
  CURSOR curGetAllProg IS
    SELECT prog_id, prog_actif
      FROM PROG
      WHERE prog_fonc IS NOT NULL or prog_actif=0;
  
  -- Vérification du paramètre "ALARM_SERVICE".    
  CURSOR curParamALARMSERVICE is
  select param_valeur FROM param WHERE param_type = 9 AND param_valeur LIKE 'ALARM_SERVICE%';
   
  strParam    VARCHAR2(40); 
  todayDate   DATE;
  flagActif   NUMBER;
  cnt         NUMBER;
  changed     NUMBER;
  
BEGIN
  -- Vérification du paramètre "ALARM_SERVICE".
  for valParamALARMSERVICE in curParamALARMSERVICE loop
    strParam := valParamALARMSERVICE.param_valeur;
    exit;
  end loop;  
  
  IF(SUBSTR(strParam, 15, 1)= '1') THEN

   -- Récupération de la date du jour.
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
        
      -- Mise à jour du champ PROG_ACTIF de la table PROG.
      IF (flagActif <> valGetAllProg.prog_actif) THEN
        UPDATE PROG SET PROG_ACTIF = flagActif WHERE PROG_ID = valGetAllProg.prog_id;
        
        -- Mise à jours des alarmes en cours.
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
     
          -- Mise à jours des alarmes en cours.
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
-- Copie de toutes les alarmes gérées d'un accès boucle. Ne doit pas être exploitée pour un
-- accès série.
--
-- X.L. Création le 18/09/98
-- Modif. X.L. le 11/05/99 pour ne pas lier la copie de la fiche au fait que la colonne
-- fiche_id de l'alarme soit non nulle; en effet, cette colonne n'est en général pas mise à jour.
-- Modif. G.G. le 07/10/03 la colonne val_id n'est plus utilisée
---------------------------------------------------------------------------------------------

create or replace
PROCEDURE CopAlarmGeree
(TypeObjet VARCHAR2,		-- Type de l'objet devant posséder la future alarme
 lIdPere NUMBER,		-- Id du père de la future alarme
 lIdOrg NUMBER,			-- ID de l'accès d'origine
 lIdCop NUMBER			-- Id de l'accès copié
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

		-- Création d'une nouvelle alarme concernant le nouvel accès		
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

		-- Détermination de l'Id de la nouvelle alarme
		SELECT seq_alarmgeree.CURRVAL INTO lIdAlCop FROM dual;

		-- Copie de la fiche de l'alarme si celle-ci existe
		--CopFiche ('ALARMGEREE', 'ALARMGEREE', Rec.alarmgeree_id, lIdAlCop);

		-- Copie des causes possibles de l'alarme

		INSERT INTO alarmg_cause (alarmgeree_id, causeal_id)
		SELECT lIdAlCop, causeal_id FROM alarmg_cause
		WHERE alarmgeree_id = Rec.alarmgeree_id;

		-- Compléter, si nécessaire par copie des relations de regroupement d'alarme.
	END LOOP;

END	CopAlarmGeree;
/


/*
* GenAccesAccesc
*/
---------------------------------------------
--
-- Génération de l'enregistrement acces_accesc correspondant à un accès de type TRAP.
-- Cette fonction est appelée lorsqu'on génère les accès d'un équipement à partir
-- des accès d'un type d'équipement et que l'accès origine est de type TRAP SNMP
--
-- X.L. Création le 29/09/00
-- JPB  Modif le 04/10/02 : ajout de EQUIP_INDEXSNMP
--
-- X.L. Modif. le 17/02/04 : ajout de la prise en compte de la temporisation
-- ALARMGEREE_MIN et de l'indicateur d'alarme à surveiller ALARMGEREE_TOSURV.
--
-- JPB  Modif le 08/03/04 : appel de SetMaskAdmAccess
--
-- X.L. Modif. le 12/11/04 : ajout de la prise en compte des seuils haut et bas.
--
---------------------------------------------
CREATE OR REPLACE PROCEDURE GenAccesAccesc
(TypeqId        NUMBER,		-- ID du type d'équipement correspondant
 TypeqAccesId	NUMBER,		-- ID de l'accès du type d'équipement correspondant
 EquipIdCop	NUMBER,		-- ID de l'équipement copié
 lIdAccesCop	NUMBER		-- ID de l'accès généré de l'équipement
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

	if lEquipToSurv = 0  then		-- Il faut masquer l'accès alarme
		SetMaskAdmAccess (lAccesAccescId, 2);
	end if;
END	GenAccesAccesC;
/


---------------------------------------------
--
-- Génération des enregistrements acces_accesc correspondant aux accès de type TRAP.
-- Cette fonction est appelée après création de l'alarme gérée d'un accès alarme TRAP
-- d'un type d'équipement, pour générer l'acces_accesc de chaque accès correspondant
-- de chaque équipement existant du type.
--
-- La fonction est appelée que l'alarme gérée corresponde à un accès de type d'équipement,
-- de liaison, de site; c'est donc à elle de vérifier que les conditions sur l'accès sont
-- requises pour créer les acces_accesc
--
-- X.L. Création le 04/10/00
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
	-- Vérification que l'accès est bien un accès de type d'équipement et qu'il est
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
	lTypeSupte	NUMBER;		-- Type de la liaison supportée
	lTypeSupp	NUMBER;		-- Type de la liaison support
	lNbMaxSupte	NUMBER;		-- Nombre de supportés max. possibles du type
	lNbSupte	NUMBER;		-- Nombre de supportés effectifs du type

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

	-- S'il n'y a pas de support, on se contente de mettre à jour PROG_LIAITEP et TEMPU
	-- (grâce à SupportLiai) et ProgTProg

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

	-- Recherche du type de la liaison supportée

	SELECT typliai_id INTO lTypeSupte FROM liai WHERE liai_id = lBddId;

	-- Recherche du type de la liaison support

	SELECT typliai_id INTO lTypeSupp FROM liai WHERE liai_id = lSuppId;

	-- Recherche du nombre de supportés possibles du type lTypeSupte pour le support

/*	lNbMaxSupte := 0;
	FOR rcCur IN CurNbSupte LOOP
		lNbMaxSupte := rcCur.typliai_typliai_nb;
		EXIT;
	END LOOP;

	-- Recherche du nombre de supportés réels de ce type pour le support

	SELECT	count (*) INTO lNbSupte FROM liai_liaic, liai
	WHERE	liai_bindingid = lSuppId
	AND	liai.liai_id = liai_liaic.liai_id
	AND	typliai_id = lTypeSupte;

	IF lNbSupte > lNbMaxSupte THEN
      errno  := -20002;
	    errmsg := 'Nombre maximum de supportés autorisé de ce type, dépassé pour le support';
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
-- Cette fonction extrait la valeur du seuil mesuré et qui a
-- provoqué l'alarme.
-- Le format du message le contenant est le suivant :
-- "Seuil non respecté (Seuil bas : xx; Seuil haut: yy; Mesure: zz)"
-- X.L. Création le 27/11/09
--

	nPosParentheseOuvrante	NUMBER;
	nPosParentheseFermante	NUMBER;
	nPos2pointSeuilBas	NUMBER;
	nPos2pointSeuilHaut	NUMBER;
	nPos2PointMesure	NUMBER;
	nPosPointVirgSeuilBas	NUMBER;
	nPosPointVirgSeuilHaut	NUMBER;
BEGIN
	-- Vérification globale du format
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
