﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :2.0.50727.3053
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace spv.serveur {
    using System;
    
    
    /// <summary>
    ///   Une classe de ressource fortement typée destinée, entre autres, à la consultation des chaînes localisées.
    /// </summary>
    // Cette classe a été générée automatiquement par la classe StronglyTypedResourceBuilder
    // à l'aide d'un outil, tel que ResGen ou Visual Studio.
    // Pour ajouter ou supprimer un membre, modifiez votre fichier .ResX, puis réexécutez ResGen
    // avec l'option /str ou régénérez votre projet VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ScriptsSQLVersion2 {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ScriptsSQLVersion2() {
        }
        
        /// <summary>
        ///   Retourne l'instance ResourceManager mise en cache utilisée par cette classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("spv.serveur.ScriptsSQLVersion2", typeof(ScriptsSQLVersion2).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Remplace la propriété CurrentUICulture du thread actuel pour toutes
        ///   les recherches de ressources à l'aide de cette classe de ressource fortement typée.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à create or replace
        ///FUNCTION AlarmNature (Id NUMBER)
        ///RETURN NUMBER
        ///	/* Cette fonction retourne :
        ///	- 0 si l&apos;alarme est autonome,
        ///	- 1 si c&apos;est une alarme mère,
        ///	- 2 si c&apos;est une alarme fille. */
        ///-- Modif. X.L. le 08/01/2010 ALARM_ALARMC est remplacée
        ///-- par ALARMDATA_CORREL. L&apos;ID passé en paramètre est
        ///-- maintenant l&apos;ID de l&apos;alarme dans ALARMDATA et non plus
        ///-- l&apos;ID de l&apos;événement alarme dans ALARM.
        ///IS
        ///    CURSOR c1 is
        ///	select * from ALARMDATA_CORREL
        ///	    where ALARMDATA_ID = Id
        ///	    for update [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        internal static string AlarmNature {
            get {
                return ResourceManager.GetString("AlarmNature", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à create or replace
        ///FUNCTION CO_DATE (Val VARCHAR2)
        ///RETURN DATE	/* Convertit une date de début ou fin d&apos;alarme au format date */
        ///IS
        ///    strFormat   VARCHAR2 (40);
        ///BEGIN
        ///    strFormat := GetFormatDateString();
        ///    return TO_DATE (Val, strFormat);
        ///
        ///EXCEPTION
        ///    -- when OTHERS then return (&apos;2035 12 31 00:00:00&apos;);
        ///    when OTHERS then 
        ///        raise_application_error (-20000, &apos;CO_DATE function, date format not compliant with &apos; || strFormat);
        ///END CO_DATE;.
        /// </summary>
        internal static string co_date {
            get {
                return ResourceManager.GetString("co_date", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à create or replace
        ///FUNCTION correl_alrm (Mess IN OUT NOCOPY VARCHAR2,
        ///    IdEvt NUMBER, IdAlarmData NUMBER, SiteId NUMBER, EquipId NUMBER, LiaiId NUMBER, 
        ///    DateAlSec NUMBER, AlarmGrave NUMBER, AlarmIddeb NUMBER, TsPrOper IN OUT NOCOPY VARCHAR2, 
        ///    Debord IN OUT NUMBER)
        ///RETURN BOOLEAN
        ///	/* Cette fonction effectue les différents traitements liés à la corrélation des alarmes.
        ///	   Elle appelle les procédures ou fonctions :
        ///		- IsMaskedBy (Id1, Id2)
        ///		- AlarmNature (Id)
        ///		- MaskeBy (Id1, Id2)
        ///	   E [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        internal static string correl_alrm {
            get {
                return ResourceManager.GetString("correl_alrm", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à create or replace FUNCTION ExtractValeurSeuil
        ///(
        /// AlarmInfo	ALARM.ALARM_INFO%TYPE,
        /// VSeuil	OUT	NUMBER
        ///)
        ///RETURN BOOLEAN
        ///IS
        ///--
        ///-- Cette fonction extrait la valeur du seuil mesuré et qui a
        ///-- provoqué l&apos;alarme.
        ///-- Le format du message le contenant est le suivant :
        ///-- &quot;Seuil non respecté (Seuil bas : xx; Seuil haut: yy; Mesure: zz)&quot;
        ///-- X.L. Création le 27/11/09
        ///--
        ///
        ///	nPosParentheseOuvrante	NUMBER;
        ///	nPosParentheseFermante	NUMBER;
        ///	nPos2pointSeuilBas	NUMBER;
        ///	nPos2pointSeuilHaut	NUMBER;
        ///	nPos2Poi [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        internal static string ExtractValeurSeuil {
            get {
                return ResourceManager.GetString("ExtractValeurSeuil", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à create or replace
        ///FUNCTION GetClasseObjetEnDefaut(EquipId NUMBER, LiaiId NUMBER, SiteId NUMBER)
        ///return VARCHAR2 is
        ///
        ///-- Cette fonction retourne un nombre représentatif de la classe de l&apos;objet concerné
        ///-- par un événement ALARM.
        ///-- Un événement ALARM concerne soit un équipement (0), soit une liaison (1),
        ///-- soit un site (2). Si tous les ID passés en paramètre sont à NULL,
        ///-- la fonction retourne -1.
        ///
        ///	nRet NUMBER;
        ///BEGIN
        ///	nRet := -1;
        ///	if EquipId is not null then
        ///		nRet := 0;
        ///	elsif LiaiId is not [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        internal static string GetClasseObjetEnDefaut {
            get {
                return ResourceManager.GetString("GetClasseObjetEnDefaut", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à create or replace FUNCTION GetFormatDateString RETURN VARCHAR2 AS
        ///BEGIN
        ///  RETURN &apos;YYYY MM DD HH24:MI:SS&apos;;
        ///END GETFORMATDATESTRING;.
        /// </summary>
        internal static string GetFormatDateString {
            get {
                return ResourceManager.GetString("GetFormatDateString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à create or replace
        ///FUNCTION GetNomObjetEnDefaut(EquipId NUMBER, LiaiId NUMBER, SiteId NUMBER)
        ///return VARCHAR2 is
        ///
        ///-- Cette fonction retourne le nom de l&apos;objet en alarme
        ///
        ///	strNom VARCHAR2(200);
        ///	nClasse NUMBER;
        ///BEGIN
        ///	strNom := &apos;&apos;;
        ///	nClasse := GetClasseObjetEnDefaut(EquipId, LiaiId, SiteId);
        ///	if (nClasse = 0) then	-- equipement
        ///		strNom := GetEquipNom (EquipId, 1);
        ///	elsif (nClasse = 1) then -- liaison
        ///		strNom := GetLiaiNom (LiaiId);
        ///	elsif (nClasse = 2) then -- site
        ///		strNom := GetSiteNom (Si [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        internal static string GetNomObjetEnDefaut {
            get {
                return ResourceManager.GetString("GetNomObjetEnDefaut", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à create or replace
        ///FUNCTION GetSiteNom(SiteId NUMBER)
        ///return VARCHAR2 is
        ///
        ///-- Cette fonction retourne le nom du site
        ///
        ///	SiteNom SITE.SITE_NOM%TYPE;
        ///
        ///BEGIN
        ///	select SITE_NOM into SiteNom from SITE where SITE_ID = SiteId;
        ///	
        ///	return SiteNom;
        ///EXCEPTION
        ///    when NO_DATA_FOUND then
        ///	return (&apos;INEX&apos;);
        ///
        ///    when OTHERS then
        ///	return (&apos;ERROR&apos;);	
        ///END GetSiteNom;.
        /// </summary>
        internal static string GetSiteNom {
            get {
                return ResourceManager.GetString("GetSiteNom", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à DECLARE
        ///    nAck    NUMBER;
        ///    nMaskOpe  NUMBER;
        ///    nMaskAdm  NUMBER;
        ///    nGrave  NUMBER;
        ///    strAlarmNom ALARMDATA.ALARMGEREE_NOM%TYPE;
        ///    nType   NUMBER;
        ///    AlarmDate DATE;
        ///    DateAcquit DATE;
        ///    SecDebut NUMBER;
        ///
        ///    CURSOR CAlarm IS
        ///        SELECT * FROM alarm WHERE alarm_iddeb IS NULL order by alarm_id;
        ///
        ///BEGIN
        ///    FOR rCAlarm IN CAlarm LOOP
        ///        nAck := 0;
        ///        IF (length (rCAlarm.alarm_date) &lt; 19) THEN
        ///            SELECT to_date(substr (rCAlarm.alarm_date, 1, 8) ||
        ///			&apos;0 [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        internal static string InitialisationTableAlarme {
            get {
                return ResourceManager.GetString("InitialisationTableAlarme", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à DECLARE
        ///	AlarmeId 		NUMBER;
        ///	AlarmeBindingId		NUMBER;
        ///
        ///	CURSOR CAlarm_Alarmc IS
        ///		SELECT * FROM alarm_alarmc;
        ///BEGIN
        ///	DELETE alarmdata_correl;
        ///	FOR rCAlarm_Alarmc IN CAlarm_Alarmc LOOP
        ///		SELECT alarmdata_id INTO AlarmeId
        ///		    FROM alarm
        ///		    WHERE alarm_id = rCAlarm_Alarmc.alarm_id;
        ///
        ///		SELECT alarmdata_id INTO AlarmeId
        ///		    FROM alarm
        ///		    WHERE alarm_id = rCAlarm_Alarmc.alarm_bindingid;
        ///
        ///		INSERT INTO alarmdata_correl VALUES (AlarmeId, AlarmeBindingId);
        ///	END LOOP;
        ///END;	.
        /// </summary>
        internal static string InitialisationTableAlarmeCorrelation {
            get {
                return ResourceManager.GetString("InitialisationTableAlarmeCorrelation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à DECLARE
        ///	CURSOR CAccesAccescRep IS
        ///		SELECT * FROM acces_accesc_rep
        ///		    WHERE alarm_id IS NOT NULL;
        ///
        ///	CURSOR CAlarmData (AlarmId NUMBER) IS
        ///		SELECT alarmdata_id FROM alarm
        ///		    WHERE alarm_id = AlarmId;
        ///
        ///BEGIN
        ///	FOR rCAccesAccescRep IN CAccesAccescRep LOOP
        ///		FOR rCAlarmData IN CAlarmData (rCAccesAccescRep.alarm_id) LOOP
        ///			UPDATE acces_accesc_rep 
        ///			    SET alarmdata_id = rCAlarmData.alarmdata_id
        ///			    WHERE acces_accesc_id = rCAccesAccescRep.acces_accesc_id;
        ///			EXIT;
        ///		END LOOP;
        ///	END  [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        internal static string InitialiseAccesAccescRep {
            get {
                return ResourceManager.GetString("InitialiseAccesAccescRep", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à create or replace
        ///PROCEDURE maj_oper (Id NUMBER, SiteId NUMBER, EquipId NUMBER,
        ///    LiaiId NUMBER, AlarmLocal NUMBER, AlarmGrave NUMBER, AlarmCommut NUMBER,
        ///    ProgNb IN OUT NUMBER,
        ///    EltSiteId IN OUT NUMBER, EltSiteNom IN OUT NOCOPY VARCHAR2, 
        ///    EltTypeId IN OUT NUMBER, EltTypeNom IN OUT NOCOPY VARCHAR2, 
        ///    EltId IN OUT NUMBER, EltNom IN OUT NOCOPY VARCHAR2,
        ///    TsPrOper IN OUT NOCOPY VARCHAR2, Debord IN OUT NUMBER)
        ///	/* Cette procédure met à jour l&apos;état opérationnel de l&apos;élément géré en défa [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        internal static string maj_oper {
            get {
                return ResourceManager.GetString("maj_oper", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à create or replace
        ///PROCEDURE Maj2OperEquip(EquipId NUMBER, CablequId NUMBER)
        ///IS
        ///	/* Cette procédure met à jour l&apos;état opérationnel du CABLEQU et des programmes
        ///	que cela concerne, lorsqu&apos;on supprime ou qu&apos;on ajoute un équipement dans un câblage */
        ///
        ///    Id 		NUMBER;		/* Id de l&apos;alarme en cours */
        ///    AlarmLocal	NUMBER;		/* Données de l&apos;alarme en cours */
        ///    AlarmGrave	NUMBER;
        ///    AlarmCommut	NUMBER;
        ///    ProgId	NUMBER;		/* Id du programme traité */
        ///    ProgNb	NUMBER;
        ///    EltTypeId   NUMBER;
        ///    E [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        internal static string Maj2OperEquip {
            get {
                return ResourceManager.GetString("Maj2OperEquip", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à create or replace
        ///PROCEDURE MajOperEquip
        ///	(Id NUMBER, EquipId NUMBER, AlarmLocal NUMBER, AlarmGrave NUMBER, AlarmCommut NUMBER,
        ///	 ProgNb IN OUT NUMBER,
        ///	 EltSiteId IN OUT NUMBER, EltSiteNom IN OUT NOCOPY VARCHAR2,
        ///	 EltTypeId IN OUT NUMBER, EltTypeNom IN OUT NOCOPY VARCHAR2, 
        ///	 EltId IN OUT NUMBER, EltNom IN OUT NOCOPY VARCHAR2,
        ///	 TsPrOper IN OUT NOCOPY VARCHAR2, Debord IN OUT NUMBER)
        ///IS
        ///	/* Cette procédure met à jour l&apos;état opérationnel de l&apos;équipement en défaut,
        ///	   ainsi que l&apos;état opérationnel [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        internal static string MajOperEquip {
            get {
                return ResourceManager.GetString("MajOperEquip", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à create or replace
        ///PROCEDURE MajOperLiai
        ///		(Id NUMBER, LiaiId NUMBER, AlarmLocal NUMBER, AlarmGrave NUMBER,
        ///		 ProgNb IN OUT NUMBER, EltTypeId IN OUT NUMBER, EltTypeNom IN OUT NOCOPY VARCHAR2,
        ///		 EltId IN OUT NUMBER, EltNom IN OUT NOCOPY VARCHAR2,
        ///		 TsPrOper IN OUT NOCOPY VARCHAR2, Debord IN OUT NUMBER)
        ///
        ///	/* Cette procédure met à jour l&apos;état opérationnel de la liaison en défaut
        ///
        ///	Id	   : Id de l&apos;alarme
        ///	LiaiId	   : Id de la liaison traitée
        ///	AlarmGrave : gravité alarme	*/
        ///
        ///IS
        ///
        ///    OperElt	NUMB [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        internal static string MajOperLiai {
            get {
                return ResourceManager.GetString("MajOperLiai", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à create or replace
        ///PROCEDURE MajOperSite
        ///		(Id NUMBER, SiteId NUMBER, AlarmLocal NUMBER, AlarmGrave NUMBER,
        ///		 ProgNb IN OUT NUMBER,
        ///		 EltSiteId IN OUT NUMBER, EltSiteNom IN OUT NOCOPY VARCHAR2, 
        ///		 EltTypeId IN OUT NUMBER, EltTypeNom IN OUT NOCOPY VARCHAR2,
        ///		 EltId IN OUT NUMBER, EltNom IN OUT NOCOPY VARCHAR2,
        ///		 TsPrOper IN OUT NOCOPY VARCHAR2, Debord IN OUT NUMBER)
        ///	/* Cette procédure met à jour l&apos;état opérationnel du site en défaut,
        ///	   ainsi que l&apos;état opérationnel des programmes que cela con [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        internal static string MajOperSite {
            get {
                return ResourceManager.GetString("MajOperSite", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à DECLARE
        ///	nClasse NUMBER;
        ///    EquipId NUMBER;
        ///    LiaiId NUMBER;
        ///    SiteId NUMBER;
        ///    EltSiteId NUMBER;
        ///    EltId NUMBER;
        ///    EltTypeId NUMBER;
        ///    CliConc1 ALARM3.ALARM3_CLICONC%TYPE;
        ///    PrConc1 ALARM3.ALARM3_PRCONC%TYPE;
        ///    CliConc2 ALARM3.ALARM3_CLICONC%TYPE;
        ///    PrConc2 ALARM3.ALARM3_PRCONC%TYPE;
        ///    PrEtat ALARM3.ALARM3_PRETAT%TYPE;
        ///    nPos NUMBER;
        ///    EltNom VARCHAR2(40);
        ///    
        ///    CURSOR CAlarm3 IS
        ///        SELECT * FROM alarm3;
        ///
        ///    CURSOR CAlarme (AlarmId NUMBER) IS
        ///	SELECT al [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        internal static string MajTableAlarm3 {
            get {
                return ResourceManager.GetString("MajTableAlarm3", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à DECLARE
        ///    CURSOR CAlarm1 IS
        ///        SELECT * FROM alarm WHERE alarm_iddeb IS NOT NULL;
        ///
        ///    CURSOR CAlarm2 (AlarmIdDeb ALARM.ALARM_ID%TYPE) IS
        ///		SELECT * FROM alarm WHERE alarm_id = AlarmIdDeb;
        ///
        ///BEGIN
        ///    FOR rCAlarm1 IN CAlarm1 LOOP
        ///		FOR rCAlarm2 IN CAlarm2 (rCAlarm1.alarm_iddeb) LOOP
        ///			UPDATE alarmdata SET
        ///	    		alarmdata_datefin = to_date (rCAlarm1.alarm_date, &apos;YYYY MM DD HH24:MI:SS&apos;),
        ///            	alarmdata_secfin = rCAlarm1.alarm_sec
        ///            WHERE alarmdata_id = rCAlarm1.alarmdata [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        internal static string MajTableAlarmeFromAlarmFin {
            get {
                return ResourceManager.GetString("MajTableAlarmeFromAlarmFin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à create or replace
        ///PROCEDURE mess_alrm (Mess IN OUT VARCHAR2,
        ///    Id NUMBER, AlarmIddeb NUMBER, AlGereeId NUMBER, SiteId NUMBER, EquipId NUMBER,
        ///    LiaiId NUMBER, AlarmNum NUMBER, AlarmCl VARCHAR2, AlarmNumObj NUMBER,
        ///    AlarmType NUMBER, AlarmDate VARCHAR2, AlarmGrave NUMBER, AlarmNseuil VARCHAR2,
        ///    AlarmVseuil	NUMBER, AlarmNumal VARCHAR2, AlarmTexte NUMBER, AlarmInfo VARCHAR2,
        ///    AlarmNomL VARCHAR2, AlarmComment VARCHAR2, AlarmCommut NUMBER,
        ///    ProgNom VARCHAR2, ClientNom VARCHAR2, ProgOper VA [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        internal static string mess_alrm {
            get {
                return ResourceManager.GetString("mess_alrm", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à create or replace
        ///PROCEDURE PostAlrm (IdEvt NUMBER, IdAlarmData NUMBER, AlGereeId NUMBER, SiteId NUMBER, EquipId NUMBER,
        ///    LiaiId NUMBER, AlarmNum NUMBER, AlarmCl VARCHAR2, AlarmNumObj NUMBER, 
        ///    AlarmType NUMBER, AlarmDate VARCHAR2, AlarmGrave NUMBER, AlarmNseuil VARCHAR2,
        ///    AlarmVseuil	NUMBER, AlarmNumal VARCHAR2, AlarmTexte NUMBER, AlarmInfo VARCHAR2,
        ///    AlarmNomL VARCHAR2, AlarmComment VARCHAR2, AlarmLocal NUMBER, AlarmCommut NUMBER,
        ///    AlarmIddeb NUMBER, CablSId NUMBER, CablPId NUMBER, So [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        internal static string PostAlrm {
            get {
                return ResourceManager.GetString("PostAlrm", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à declare
        ///  CURSOR CAccesAccesc2 IS
        ///    select acces_accesc_id from acces_accesc, acces_accesc2
        ///    where acces_accesc2_id (+) = acces_accesc_id
        ///    and acces_accesc2_id is null;
        ///begin
        ///  for rCAccesAccesc2 in CAccesAccesc2 loop
        ///      insert into acces_accesc2 values (
        ///        rCAccesAccesc2.acces_accesc_id, 0, 0, 0, 0, 0, 0, 0, null, 0, seq_acces_accesc2.nextval);
        ///  end loop;
        ///end;.
        /// </summary>
        internal static string ReparationAccesAccesc2 {
            get {
                return ResourceManager.GetString("ReparationAccesAccesc2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à create or replace
        ///PROCEDURE SetAlarm
        ///(
        ///	Grave	NUMBER,		-- Gravité de l&apos;alarme, selon la norme X733 :
        ///				-- 0 : fin d&apos;alarme
        ///				-- 3 : avertissement
        ///				-- 4 : indéterminé
        ///				-- 5 : mineur
        ///				-- 6 : majeur
        ///				-- 7 : critique
        ///				-- ATTENTION, pour certaines alarmes, la gravité est imposée
        ///				-- par la configuration et ne vaudra pas la valeur entrée ici
        ///	DateStr	VARCHAR2,	-- Date et heure du début de l&apos;alarme, au format normalisé :
        ///				-- &apos;YYYY MM DD HH:MN:SS&apos;
        ///				-- ou &apos;&apos;. Dans ce cas, la [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        internal static string SetAlarm {
            get {
                return ResourceManager.GetString("SetAlarm", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à create or replace
        ///PROCEDURE Start_Alrm (Id NUMBER, AlGereeId NUMBER, SiteId NUMBER,
        ///    EquipId NUMBER, LiaiId NUMBER, AlarmNum NUMBER, AlarmCl VARCHAR2, AlarmNumObj NUMBER,
        ///    AlarmType NUMBER, AlarmDate VARCHAR2, AlarmGrave NUMBER, AlarmNseuil VARCHAR2,
        ///    AlarmVseuil	NUMBER, AlarmNumal VARCHAR2, AlarmTexte NUMBER, AlarmInfo VARCHAR2,
        ///    AlarmNomL VARCHAR2, AlarmComment VARCHAR2, AlarmLocal NUMBER, AlarmCommut NUMBER,
        ///    AlarmIddeb NUMBER, CablSId NUMBER, CablPId NUMBER, Acquittee NUMBER, Iana N [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        internal static string Start_Alrm {
            get {
                return ResourceManager.GetString("Start_Alrm", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à create or replace
        ///TRIGGER &quot;SPVOPT&quot;.tdb_finalarm before delete on FINALARM for each row
        ///
        ///declare
        ///    integrity_error  exception;
        ///    errno            integer;
        ///    errmsg           char(200);
        ///
        ///    Erreur_Trigger   EXCEPTION;		-- interblocage entre alarmes, si plusieurs EM
        ///    Erreur2_Trigger  EXCEPTION;
        ///    PRAGMA EXCEPTION_INIT (Erreur_trigger,  -6512);
        ///    PRAGMA EXCEPTION_INIT (Erreur2_trigger, -60);
        ///
        ///    i		     integer;	  -- compteur banal
        ///
        ///    TsPrOper VARCHAR2 (900); /* Chaîne donnant l&apos; [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        internal static string tdb_finalarm {
            get {
                return ResourceManager.GetString("tdb_finalarm", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à create or replace
        ///TRIGGER tib_acces_accesc before insert on acces_accesc for each row
        ///begin
        ///    -- S&apos;il cela concerne un équipement de médiation, il faut mettre à jour
        ///    -- le bindingid
        ///    if (:new.acces1_id = 0 and :new.acces2_id = 0 and :new.acces_bindingclassid = 8 and
        ///        :new.equip_id is not null and :new.alarmgeree_id = 1) then
        ///        :new.acces_bindingid := :new.equip_id;
        ///    end if;
        ///end;
        ///.
        /// </summary>
        internal static string tib_acces_accesc {
            get {
                return ResourceManager.GetString("tib_acces_accesc", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à create or replace
        ///TRIGGER tib_alarm before insert on ALARM for each row
        ///declare
        ///    IsAccesId	integer;	/* ACCES_ID correspondant au n° IS et NUMAL (ou n° IP2PORT et NUMAL) */
        ///    NumBit   	NUMBER;		/* n° bit si alarme série : 1 .. */
        ///    OrigAccesId integer;	/* ACCES_ID de l&apos;objet à l&apos;origine de l&apos;alarme */
        ///    MessId	integer;	/* ID du message série correspondant à cette alarme */
        ///    ScriptId	integer;	/* Id du script à déclencher éventuellement */
        ///    Nb		integer;	/* Nb. banal */
        ///    Str		varchar2 [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        internal static string tib_alarm {
            get {
                return ResourceManager.GetString("tib_alarm", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à create or replace
        ///TRIGGER TIU_ALARMDATA AFTER INSERT OR UPDATE ON ALARMDATA FOR EACH ROW 
        ///	/* Appelle indirectement les fonctions ou procédures stockées suivantes :
        ///		- correl_alrm,
        ///		- IsMaskedAdm,
        ///		- IsmaskedBri,
        ///		- maj_oper,
        ///		- mess_alrm
        ///		- mess_video */
        ///declare
        ///    integrity_error  exception;
        ///    Erreur_Trigger   EXCEPTION;			-- interblocage entre alarmes, si plusieurs EM
        ///    Erreur2_Trigger  EXCEPTION;
        ///    PRAGMA EXCEPTION_INIT (Erreur_trigger,  -6512);
        ///    PRAGMA EXCEPTION_INIT (Erre [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        internal static string tiu_alarmdata {
            get {
                return ResourceManager.GetString("tiu_alarmdata", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à create or replace
        ///TRIGGER tub_acces_accesc2 BEFORE UPDATE ON acces_accesc2 FOR EACH ROW
        ///
        ///DECLARE
        ///    ToDayStr	VARCHAR2 (20);	/* date et heure actuelle au format YYYY MM DD HH24:MI:SS */
        ///    ToDaySec	NUMBER;		/* idem en nombre de secondes depuis le 01/01/1998 00:00:00 */
        ///    Mess	VARCHAR2 (1800);   /* message d&apos;alarme */
        ///    OldMask	NUMBER;		/* 1 si l&apos;alarme était masquée avant le changement, 0 sinon  */
        ///    NewMask	NUMBER;		/* 1 si l&apos;alarme devient masquée après le changement, 0 sinon */
        ///
        ///    Prog [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        internal static string tub_acces_accesc2 {
            get {
                return ResourceManager.GetString("tub_acces_accesc2", resourceCulture);
            }
        }
    }
}
