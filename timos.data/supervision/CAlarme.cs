using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using sc2i.doccode;

using tiag.client;

using Lys.Licence;
using Lys.Applications.Timos.Smt;

using timos.securite;
using timos.data.version;
using timos.data.vuephysique;
using timos.data.composantphysique;
using Lys.Licence.Types;
using futurocom.supervision;
using sc2i.common.memorydb;
using timos.acteurs;
using futurocom.snmp;
using timos.data.snmp;
using sc2i.expression;

namespace timos.data.supervision
{
    /// <summary>
    /// Une alarme est une indication de défaut concernant :
    /// <ul>
    /// <li><see cref="CSite">un site</see>,</li> 
    /// <li><see cref="CEquipement">un équipement logique</see>,</li>
    /// <li><see cref="CLienReseau">un lien réseau</see> ou</li>
    /// <li><see cref="CEntiteSnmp">une entité SNMP</see></li>
    /// </ul><br/>
    /// Une alarme peut être masquée; le masquage peut être amont (dans ce cas,<br/>
    /// l'alarme n'est pas stockée en base de données) ou aval (l'alarme est<br/>
    /// stockée en base de données mais non affichée.
    /// <br/>
    /// <br/>
    /// Une alarme a un  niveau de sévérité qui permet de lui associer une couleur<br/>
    /// et un niveau de priorité qui permet de déclarer les liens et équipements<br/>
    /// hors service ou non en fonction de ce niveau.
    /// <br/>
    /// <br/>
    /// Une alarme peut nécessiter d'être acquittée, avant de disparaître de la liste<br/>
    /// des alarmes en cours les plus récentes.
    /// <br/>
    /// <br/>
	/// Les Alarmes sont hiérarchiques et peuvent inclure des Alarmes Filles;<br/>
    /// exemple : une alarme 'intrusion site' peut inclure une alarme 'ouverture porte'.
    /// </summary>
    [DynamicClass("Alarms")]
    [Table(CAlarme.c_nomTable, CAlarme.c_champId, true)]
    [ObjetServeurURI("CAlarmeServeur")]
    [AutoExec("Autoexec")]
    [TiagClass("Alarm", "Id", true)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModuleSupervision)]
    public class CAlarme : CObjetHierarchique,        // Objet hiérérchique Prent/fils
                         IObjetDonneeAChamps,      // Permet la possibilité d'ajouter des champs custom (et formulaires au Alarme)
                        IObjetSansVersion,
                        IAlarme
    {
        public const string c_nomTable = "ALARMS";
        public const string c_champId = "ALRM_ID";
        public const string c_champLibelle = "ALRM_LABEL";
        public const string c_champAlarmId = "ALRM_ALRM_ID";

        public const string c_champCodeSystemePartiel = "ALRM_PARTIAL_SYS_CODE";
        public const string c_champCodeSystemeComplet = "ALRM_FULL_SYS_CODE";
        public const string c_champNiveau = "ALRM_LEVEL";
        public const string c_champIdParent = "ALRM_PARENT_ID";

        public const string c_champCle = "ALRM_KEY";
        public const string c_champEtat = "ALRM_STATE";
        public const string c_champDateDebut = "ALRM_START_DATE";
        public const string c_champDateFin = "ALRM_END_DATE";
        public const string c_champDateAcquittement = "ALRM_ACK_DATE";
        public const string c_champIsHS = "ALRM_IS_OOO";
        public const string c_champIdMasquagePropre = "ALRM_OWN_MASK_ID";
        public const string c_champIdMasquageHerite = "ALRM_HER_MASK_ID";
        public const string c_champNiveauMasquage = "ALRM_MASK_LEVEL";
        
        public const string c_roleChampCustom = "ALARM";


        /// /////////////////////////////////////////////
        public CAlarme(CContexteDonnee contexte)
            : base(contexte)
        {
        }

        /// /////////////////////////////////////////////
        public CAlarme(DataRow row)
            : base(row)
        {
        }

        //-------------------------------------------------------------------
        public static void Autoexec()
        {
            CRoleChampCustom.RegisterRole(c_roleChampCustom, "Alarms", typeof(CAlarme), typeof(CTypeAlarme));
        }

        //--------------------------------------------------------------------
        public CRoleChampCustom RoleChampCustomAssocie
        {
            get
            {
                return CRoleChampCustom.GetRole(c_roleChampCustom);
            }
        }


        ////////////////////////////////////////////////
        /// <summary>
        /// Description + Label. Ce champ est en lecture seule
        /// </summary>
        public override string DescriptionElement
        {
            get
            {
                return I.T("Alarm  @1|20091", Libelle);
            }
        }

        /// /////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
            base.MyInitValeurDefaut();
            AlarmId = Guid.NewGuid().ToString();
            EtatCode = (int)EEtatAlarme.Open;
            DateDebut = DateTime.Now;
            IsHS = false;
        }

        /// /////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champDateDebut + " desc" };
        }

        ///////////////////////////////////////////////
        /// <summary>
        /// Le nom donné à l'alarme
        /// </summary>
        [TableFieldProperty(c_champLibelle, 255)]
        [DynamicField("Label")]
        [RechercheRapide]
        [TiagField("Label")]
        public override string Libelle
        {
            get
            {
                return (string)Row[c_champLibelle];
            }
            set
            {
                Row[c_champLibelle] = value;
            }
        }


        //------------------------------------------------------------
        /// <summary>
        /// Identifiant de l'alarme (GUID), unique dans la base de données
        /// </summary>
        [TableFieldProperty(c_champAlarmId, 255)]
        [DynamicField("Alarm id")]
        [IndexField]
        [TiagField("GUID")]
        public string AlarmId
        {
            get
            {
                return (string)Row[c_champAlarmId];
            }
            set
            {
                Row[c_champAlarmId] = value;
            }
        }

        
        //-------------------------------------------------------------------
        /// <summary>
        /// Site sur lequel porte cette alarme (s'il existe)
        /// </summary>
        [Relation ( 
            CSite.c_nomTable,
            CSite.c_champId,
            CSite.c_champId,
            false,
            false,
            true)]
        [DynamicField("Site")]
        [TiagRelation(typeof(CSite), CAssociationTiag.c_methodeUseDelegate)]
        public CSite Site
        {
            get{
                return GetParent(CSite.c_champId, typeof(CSite)) as CSite;
            }
            set
            {
                SetParent ( CSite.c_champId, value );
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Equipement logique sur lequel porte cette alarme (s'il existe)
        /// </summary>
        [Relation (
            CEquipementLogique.c_nomTable,
            CEquipementLogique.c_champId,
            CEquipementLogique.c_champId,
            false,
            false,
            true)]
        [DynamicField("Logical equipment")]
        [TiagRelation(typeof(CEquipementLogique), CAssociationTiag.c_methodeUseDelegate)]
        public CEquipementLogique EquipementLogique
        {
            get
            {
                return GetParent(CEquipementLogique.c_champId, typeof(CEquipementLogique)) as CEquipementLogique;
            }
            set
            {
                SetParent(CEquipementLogique.c_champId, value);
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Lien réseau sur lequel porte cette alarme (s'il existe)
        /// </summary>
        [Relation(
            CLienReseau.c_nomTable,
            CLienReseau.c_champId,
            CLienReseau.c_champId,
            false,
            false,
            true)]
        [DynamicField("Network link")]
        [TiagRelation(typeof(CLienReseau), CAssociationTiag.c_methodeUseDelegate)]
        public CLienReseau LienReseau
        {
            get
            {
                return (CLienReseau)GetParent(CLienReseau.c_champId, typeof(CLienReseau));
            }
            set
            {
                SetParent(CLienReseau.c_champId, value);
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Entité SNMP sur laquelle porte cette alarme (si elle existe)
        /// </summary>
        [Relation(
            CEntiteSnmp.c_nomTable,
            CEntiteSnmp.c_champId,
            CEntiteSnmp.c_champId,
            false,
            false,
            true)]
        [DynamicField("Snmp entity")]
        public CEntiteSnmp EntiteSnmp
        {
            get
            {
                return (CEntiteSnmp)GetParent(CEntiteSnmp.c_champId, typeof(CEntiteSnmp));
            }
            set
            {
                SetParent(CEntiteSnmp.c_champId, value);
            }
        }

	


        //-------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit le Type de l'Alarme (champ obligatoire).
        /// </summary>
        [Relation(CTypeAlarme.c_nomTable, CTypeAlarme.c_champId, CTypeAlarme.c_champId, true, false, true)]
        [DynamicField("Alarme type")]
        [TiagRelation(typeof(CTypeAlarme), CAssociationTiag.c_methodeUseDelegate)]
        public CTypeAlarme TypeAlarme
        {
            get
            {
                return (CTypeAlarme)GetParent(CTypeAlarme.c_champId, typeof(CTypeAlarme));
            }
            set
            {
                if (Severite == null)
                {
                    Severite = value.Severite;
                    if ( Severite != null )
                        IsHS = Severite.IsHS;
                }
                SetParent(CTypeAlarme.c_champId, value);
            }
        }


        //----------------------------------------------------
        /// <summary>
        /// Date de début de l'alarme. Cette date n'est pas forcément la date d'apparition<br/>
        /// sur le système TIMOS, mais peut être la date donnée à cette alarme par l'équipement<br/>
        /// dont elle est issue.
        /// </summary>
        [TableFieldProperty(c_champDateDebut)]
        [DynamicField("Start date")]
        [TiagField("Start date")]
        public DateTime DateDebut
        {
            get
            {
                return (DateTime)Row[c_champDateDebut];
            }
            set
            {
                Row[c_champDateDebut] = value;
            }
        }

        //----------------------------------------------------
        /// Date de fin de l'alarme. Cette date n'est pas forcément la date de disparition<br/>
        /// sur le système TIMOS, mais peut être la date de fin donnée à cette alarme par l'équipement<br/>
        /// dont elle est issue.
        [TableFieldProperty(c_champDateFin, NullAutorise = true)]
        [DynamicField("End date")]
        [TiagField("End date")]
        public DateTime? DateFin
        {
            get{
                if ( Row[c_champDateFin] == DBNull.Value )
                    return null;
                return new CDateTimeEx ((DateTime)Row[c_champDateFin]);
            }
            set{
                if (value == null)
                    Row[c_champDateFin] = DBNull.Value;
                else
                {
                    //Row[c_champDateFin] = value.DateTimeValue;
                    //PropageDateFinSurFils(value.DateTimeValue);
                    Row[c_champDateFin] = value;
                    PropageDateFinSurFils((DateTime)value);
                }

            }
        }

        //-------------------------------------------
        public void PropageDateFinSurFils(DateTime dt)
        {
            foreach (CAlarme alarmeFille in AlarmesFilles)
            {   
                if (alarmeFille.DateFin == null)
                    alarmeFille.Row[c_champDateFin] = dt;
                alarmeFille.PropageDateFinSurFils(dt);
            }
        }

        //----------------------------------------------------
        public override int NbCarsParNiveau
        {
            get
            {
                return 5;
            }
        }

        //----------------------------------------------------
        public override string ChampCodeSystemePartiel
        {
            get
            {
                return c_champCodeSystemePartiel;
            }
        }

        //----------------------------------------------------
        public override string ChampCodeSystemeComplet
        {
            get
            {
                return c_champCodeSystemeComplet;
            }
        }

        //----------------------------------------------------
        public override string ChampNiveau
        {
            get
            {
                return c_champNiveau;
            }
        }

        //----------------------------------------------------
        public override string ChampLibelle
        {
            get
            {
                return c_champLibelle;
            }
        }

        //----------------------------------------------------
        public override string ChampIdParent
        {
            get
            {
                return c_champIdParent;
            }
        }


        //----------------------------------------------------
        /// <summary>
        /// Alarme parente dans la hiérarchie. Si l'Alarme n'a pas d'Alarme parente la propriété retourne NUL.
        /// </summary>
        [Relation(
            c_nomTable,
            c_champId,
            c_champIdParent,
            false,
            false,
            true)]
        [DynamicField("Parent Alarm")]
        [TiagRelation(typeof(CAlarme), CAssociationTiag.c_methodeUseDelegate)]
        public CAlarme AlarmeParente
        {
            get
            {
                return (CAlarme)ObjetParent;
            }
            set
            {
                if (value != null)
                    ObjetParent = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Code donnant l'état de l'alarme :<br/>
        /// <ul>
        /// <li> 0 : inconnu</li>
        /// <li>20 : ouverte</li>
        /// <li>40 : fermée</li>
        /// </ul>
        /// </summary>
        [TableFieldProperty(c_champEtat)]
        [DynamicField("State code")]
        [IndexField]
        [TiagField("State code")]
        public int EtatCode
        {
            get
            {
                return (int)Row[c_champEtat];
            }
            set
            {
                Row[c_champEtat] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Etat de l'alarme (cf. 'State code')
        /// </summary>
        [DynamicField("State")]
        public CEtatAlarme Etat
        {
            get
            {
                return new CEtatAlarme((EEtatAlarme)EtatCode);
            }
            set
            {
                if (value != null)
                    EtatCode = value.CodeInt;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Clé de l'alarme. Cette clé est calculée par TIMOS en fonction du<br/>
        /// contexte et de la propriété 'Group_on_key' du type d'alarme correspondant.<br/>
        /// Si, au niveau du type d'alarme, on ne groupe pas sur la clé ('Group_on_key' à False),<br/>
        /// Chaque alarme de ce type a une clé différente (l'alarme est toujours créée).<br/>
        /// Si on groupe sur la clé au niveau du type, la clé est une composition des Id<br/>
        /// des éléments concernés (type d'alarme, site, équipement, lien réseau, entité SNMP)<br/>
        /// augmentée des valeurs des éventuels champs personnalisés définis comme participant<br/>
        /// à la construction de la clé, au niveau du type d'alarme; dans ce cas, lorsque l'alarme<br/>
        /// monte, si celle-ci existe déjà dans la base (même clé), elle n'est pas recréée;<br/>
        /// lorsque l'alarme descend, si celle-ci existe déjà montée dans la base, on fait retomber cette dernière.
        /// </summary>
        [TableFieldProperty(c_champCle, 255)]
        [IndexField]
        [DynamicField("Alarm key")]
        [TiagField("Alarm key")]
        public string Cle
        {
            get
            {
                return (string)Row[c_champCle];
            }
            set
            {
                Row[c_champCle] = value;
            }
        }



        //----------------------------------------------------
        /// <summary>
        /// Retourne la liste des Alarmes filles dans la hiérarchie
        /// </summary>
        [RelationFille(typeof(CAlarme), "AlarmeParente")]
        [DynamicChilds("Child Alarms", typeof(CAlarme))]
        public CListeObjetsDonnees AlarmesFilles
        {
            get
            {
                return ObjetsFils;
            }
        }

        //----------------------------------------------------
        /// <summary>
        /// Indique le code système de l'alarme dans sa hiérarchie. Ce code est unique dans son parent.
        /// Ce code est exprimé sur 5 caractères alphanumériques.
        /// </summary>
        [TableFieldProperty(c_champCodeSystemePartiel, 5)]
        [DynamicField("Partial system code")]
        public override string CodeSystemePartiel
        {
            get
            {
                string strVal = "";
                if (Row[c_champCodeSystemePartiel] != DBNull.Value)
                    strVal = (string)Row[c_champCodeSystemePartiel];
                strVal = strVal.Trim().PadLeft(4, '0');
                return strVal;
            }
        }

        //----------------------------------------------------
        /// <summary>
        /// Indique le code système complet de l'alarme.<br/>
        /// Ce code système complet est la concaténation du code système partiel de l'alarme<br/>
        /// avec le code système complet de son alarme parente.<br/>
        /// Exemple : pour un code système complet tel que : 0004B000HK00001 :<br/>
        /// 00001 est le code partiel de l'alarme fille<br/>
        /// 0004B000HK est le code complet de l'alarme parente<br/>
        /// </summary>
        [TableFieldProperty(c_champCodeSystemeComplet, 400)]
        [DynamicField("Full system code")]
        public override string CodeSystemeComplet
        {
            get
            {
                return (string)Row[c_champCodeSystemeComplet];
            }
        }

        //----------------------------------------------------
        /// <summary>
        /// Indique le niveau hiérarchique( nombre de parents ) de l'alarme.<br/>
        /// Le niveau d'une alarme sans parent est 0.<br/>
        /// Exemple, supposons la hiérarchie d'alarmes suivante : Intrusion site -> Porte -> Ouverture :
        /// 'Intrusion site' a pour niveau 0,
        /// 'Porte' a pour niveau 1 (1 parent en remontant la hiérarchie)
        /// 'Ouverture' a pour niveau 2 (2 parents en remontant la hiérachie)
        /// </summary>
        [TableFieldProperty(c_champNiveau)]
        [DynamicField("Level")]
        public override int Niveau
        {
            get
            {
                return (int)Row[c_champNiveau];
            }
        }


        //----------------------------------------------------
        public CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
        {
            return new CRelationAlarme_ChampCustom(ContexteDonnee);
        }

        //----------------------------------------------------
        public string GetNomTableRelationToChamps()
        {
            return CRelationAlarme_ChampCustom.c_nomTable;
        }

        //----------------------------------------------------
        public CListeObjetsDonnees GetRelationsToChamps(int nIdChamp)
        {
            CListeObjetsDonnees liste = RelationsChampsCustom;
            liste.InterditLectureInDB = true;
            liste.Filtre = new CFiltreData(CChampCustom.c_champId + " = @1", nIdChamp);
            return liste;
        }



        //----------------------------------------------------
        public IDefinisseurChampCustom[] DefinisseursDeChamps
        {
            get
            {
                return new IDefinisseurChampCustom[] { TypeAlarme };
            }
        }

        //----------------------------------------------------
        public CChampCustom[] GetChampsHorsFormulaire()
        {
            if (TypeAlarme == null)
                return new CChampCustom[0];

            ArrayList lst = new ArrayList();
            foreach (CRelationTypeAlarme_ChampCustom rel in TypeAlarme.RelationsChampsCustomDefinis)
                lst.Add(rel.ChampCustom);

            foreach (CRelationTypeAlarme_Formulaire rel1 in TypeAlarme.RelationsFormulaires)
                foreach (CRelationFormulaireChampCustom rel2 in rel1.Formulaire.RelationsChamps)
                    lst.Remove(rel2.Champ);

            return (CChampCustom[])lst.ToArray(typeof(CChampCustom));

        }

        //----------------------------------------------------
        public CFormulaire[] GetFormulaires()
        {
            return CUtilElementAChamps.GetFormulaires(this);
        }

        //----------------------------------------------------
        /// <summary>
        /// Retourne la liste des relations entre l'alarme et les champs personnalisés
        /// </summary>
        [RelationFille(typeof(CRelationAlarme_ChampCustom), "ElementAChamps")]
        [DynamicChilds("Custom fields relations", typeof(CRelationAlarme_ChampCustom))]
        public CListeObjetsDonnees RelationsChampsCustom
        {
            get
            {
                return GetDependancesListe(CRelationAlarme_ChampCustom.c_nomTable, c_champId);
            }
        }

        //----------------------------------------------------------------------------
        public object GetValeurChamp(int nIdChamp)
        {
            return CUtilElementAChamps.GetValeurChamp(this, nIdChamp);
        }

        //-----------------------------------------------------------------------------
        public object GetValeurChamp(int nIdChamp, DataRowVersion version)
        {
            return CUtilElementAChamps.GetValeurChamp(this, nIdChamp, version);
        }

        public object GetValeurChamp(string strIdVariable)
        {
            return CUtilElementAChamps.GetValeurChamp(this, strIdVariable);
        }

        //-----------------------------------------------------------------------------
        public object GetValeurChamp(IVariableDynamique variable)
        {
            if (variable == null)
                return null;
            return GetValeurChamp(variable.IdVariable);
        }

        //---------------------------------------------
        public CResultAErreur SetValeurChamp(string strIdVariable, object valeur)
        {
            return CUtilElementAChamps.SetValeurChamp(this, strIdVariable, valeur);
        }

        //---------------------------------------------
        public CResultAErreur SetValeurChamp(IVariableDynamique variable, object valeur)
        {
            if (variable == null)
                return CResultAErreur.True;
            return SetValeurChamp(variable.IdVariable, valeur);
        }

        //-------------------------------------------------------------------
        public CResultAErreur SetValeurChamp(int nIdChamp, object valeur)
        {
            return CUtilElementAChamps.SetValeurChamp(this, nIdChamp, valeur);
        }

        //----------------------------------------------------
        /// <summary>
        /// Remplit ou met à jour l'alarme à partir de données
        /// issues d'un service de médiation
        /// </summary>
        /// <param name="alarme"></param>
        public void FillFromLocalAlarmeFromMediation(CLocalAlarme alarme)
        {
            Libelle = alarme.Libelle;
            Cle = alarme.GetKey();
            AlarmId = alarme.Id;
            EtatCode = (int)alarme.EtatCode;
            DateDebut = alarme.DateDebut;
            DateFin = alarme.DateFin;
            CTypeAlarme ta = new CTypeAlarme(ContexteDonnee);
            
            if (ta.ReadIfExists(Int32.Parse(alarme.TypeAlarme.Id)))
                TypeAlarme = ta;
            else
                throw new Exception(I.T("Alarm type @1 doesn't exists|20104", alarme.TypeAlarme.Libelle));
            
            Site = null;
            EquipementLogique = null;
            LienReseau = null;
            EntiteSnmp = null;
            //Site
            if (alarme.SiteId != null)
            {
                /*int? nId = CDbKeyAddOn.GetIdFromUniverselId(typeof(CSite), alarme.SiteId);
                if (nId != null)
                    Row[CSite.c_champId] = nId.Value;*/
                CSite site = new CSite(ContexteDonnee);
                if (site.ReadIfExists(alarme.SiteId))
                    Site = site;
            }
            if (alarme.EquipementId != null)
            {
                /*int? nId = CDbKeyAddOn.GetIdFromUniverselId(typeof(CEquipementLogique), alarme.EquipementId);
                if (nId != null)
                    Row[CEquipementLogique.c_champId] = nId.Value;*/
                CEquipementLogique eqt = new CEquipementLogique(ContexteDonnee);
                if (eqt.ReadIfExists(alarme.EquipementId))
                    EquipementLogique = eqt;
            }
            if (alarme.LienId != null)
            {
                /*int? nId = CDbKeyAddOn.GetIdFromUniverselId(typeof(CLienReseau), alarme.LienId);
                if (nId != null)
                    Row[CLienReseau.c_champId] = nId.Value;*/
                CLienReseau lien = new CLienReseau(ContexteDonnee);
                if (lien.ReadIfExists(alarme.LienId))
                    LienReseau = lien;
            }
            if (alarme.EntiteSnmpId != null)
            {
                /*int? nId = CDbKeyAddOn.GetIdFromUniverselId(typeof(CEntiteSnmp), alarme.EntiteSnmpId);
                if (nId != null)
                    Row[CEntiteSnmp.c_champId] = nId.Value;*/
                CEntiteSnmp entite = new CEntiteSnmp(ContexteDonnee);
                if (entite.ReadIfExists(alarme.EntiteSnmpId))
                    EntiteSnmp = entite;
            }
            IsHS = alarme.IsHS;
            if (alarme.IdSeverite != null)
            {
                CSeveriteAlarme severite = new CSeveriteAlarme(ContexteDonnee);
                if (severite.ReadIfExists(Int32.Parse(alarme.IdSeverite)))
                    Severite = severite;
            }
            if (alarme.MasquagePropre != null)
            {
                
                CParametrageFiltrageAlarmes parametreFiltre = new CParametrageFiltrageAlarmes(ContexteDonnee);
                if (parametreFiltre.ReadIfExists(Int32.Parse(alarme.MasquagePropre.Id)))
                    MasquagePropre = parametreFiltre;
            }
            else
                MasquagePropre = null;
            foreach (CChampCustom champ in ta.TousLesChampsAssocies)
            {
                object val = alarme.GetValeurChamp(champ.Id.ToString());
                if (val != null)
                {

                    SetValeurChamp(champ.Id, val);
                }
            }
        }


        //-------------------------------------------------------------------
        /// <summary>
        /// Donne ou définit la sévérité de l'alarme
        /// </summary>
        [Relation(
            CSeveriteAlarme.c_nomTable,
            CSeveriteAlarme.c_champId,
            CSeveriteAlarme.c_champId,
            true,
            false,
            true)]
        [DynamicField("Severity")]
        [TiagRelation(typeof(CSeveriteAlarme), CAssociationTiag.c_methodeUseDelegate)]
        public CSeveriteAlarme Severite
        {
            get
            {
                return (CSeveriteAlarme)GetParent(CSeveriteAlarme.c_champId, typeof(CSeveriteAlarme));
            }
            set
            {
                SetParent(CSeveriteAlarme.c_champId, value);
            }
        }

	


        //---------------------------------------------------------------------
        public CLocalAlarme GetLocalAlarme(CMemoryDb database, bool bAvecFils)
        {
            if (database == null)
                database = CMemoryDbPourSupervision.GetMemoryDb(ContexteDonnee);
            CAlarme alarmeParente = AlarmeParente;
            CLocalAlarme localParent = null;
            if (alarmeParente != null)
            {
                localParent = alarmeParente.GetLocalAlarme(database, false);
            }
            CLocalAlarme alarme = new CLocalAlarme(database);
            if (!alarme.ReadIfExist(AlarmId.ToString(), false))
                alarme.CreateNew(AlarmId.ToString());
            else
                if (!alarme.IsToRead())
                    return alarme;
            alarme.PreventPropagationsAutomatiques = true;
            alarme.Row[CMemoryDb.c_champIsToRead] = false;
            alarme.DateDebut = DateDebut;
            alarme.DateFin = DateFin;
            alarme.TypeAlarme = TypeAlarme.GetTypeForSupervision(database, false);
            alarme.Severite = Severite.GetTypeForSupervision(database);
            alarme.Parent = localParent;
            alarme.EtatCode = (EEtatAlarme)EtatCode;
            alarme.Libelle = Libelle;
            alarme.DateAcquittement = DateAcquittement;
            alarme.SiteId = SiteId;
            alarme.EquipementId = EquipementId;
            alarme.LienId = LienId;
            alarme.EntiteSnmpId = EntiteSnmpId;
            alarme.IsHS = IsHS;
            alarme.NiveauMasquage = NiveauMasquage;
            
            if (Severite != null)
            {
                CLocalSeveriteAlarme sev = Severite.GetTypeForSupervision(database);
                if (sev != null)
                    alarme.Severite = sev;
            }

            if (MasquagePropre != null)
                alarme.MasquagePropre = MasquagePropre.GetLocalParametrageForSupervision(database);
            if (MasquageHerite != null)
                alarme.MasquageHerite = MasquageHerite.GetLocalParametrageForSupervision(database);

            // Recupère les valeurs de champs
            foreach (CRelationAlarme_ChampCustom rel in RelationsChampsCustom)
            {
                object val = rel.Valeur;
                if (val != null)
                {
                    if (val is CObjetDonneeAIdNumerique)
                        val = ((CObjetDonneeAIdNumerique)val).Id;
                    alarme.SetValeurChamp(rel.ChampCustom.Id.ToString(), val);
                }
            }
            alarme.PreventPropagationsAutomatiques = false;
            if (bAvecFils)
            {
                foreach (CAlarme fille in AlarmesFilles)
                    fille.GetLocalAlarme(database, true);
            }
            return alarme;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Donne ou définit la date à laquelle l'alarme a été acquittée<br/>
        /// (c'est à dire, prise en compte par l'utilisateur superviseur)
        /// </summary>
        [TableFieldProperty(c_champDateAcquittement, NullAutorise = true)]
        [DynamicField("Acknowledge Date")]
        [TiagField("Acknowledge Date")]
        public CDateTimeEx DateAcquittement
        {
            get
            {
                if (Row[c_champDateAcquittement] == DBNull.Value)
                    return null;
                return new CDateTimeEx((DateTime)Row[c_champDateAcquittement]);
            }
            set
            {
                if (value == null)
                    Row[c_champDateAcquittement] = DBNull.Value;
                else
                    Row[c_champDateAcquittement] = value.DateTimeValue;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Si VRAI indique que l'élément associé est hors service<br/>
        /// (dépend du  niveau de priorité de l'alarme)
        /// </summary>
        [TableFieldProperty(c_champIsHS)]
        [DynamicField("Is Out of Service")]
        [TiagField("Is Out of service")]
        public bool IsHS
        {
            get
            {
                return (bool)Row[c_champIsHS];
            }
            set
            {
                Row[c_champIsHS] = value;
            }
        }



        //----------------------------------------------------------------------------------
        /// <summary>
        /// Acteur utilisateur ayant acquitté cette alarme
        /// </summary>
        [Relation(
            CActeur.c_nomTable,
            CActeur.c_champId,
            CActeur.c_champId,
            false,
            false,
            false)]
        [DynamicField("Acknowledge Responsible")]
        [TiagRelation(typeof(CActeur), CAssociationTiag.c_methodeUseDelegate)]
        public CActeur ResponsableAcquittement
        {
            get
            {
                return (CActeur)GetParent(CActeur.c_champId, typeof(CActeur));
            }
            set
            {
                SetParent(CActeur.c_champId, value);
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [TableFieldProperty(c_champNiveauMasquage, true)]
        [DynamicField("Masking Level")]
        public int? NiveauMasquage
        {
            get
            {
                if(Row[c_champNiveauMasquage] == DBNull.Value)
                    return null;
                return (int?)Row[c_champNiveauMasquage];
            }
            set
            {
                Row[c_champNiveauMasquage] = value;
            }
        }


        //------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [Relation(
            CParametrageFiltrageAlarmes.c_nomTable,
            CParametrageFiltrageAlarmes.c_champId,
            c_champIdMasquagePropre,
            false,
            false,
            false)]
        [DynamicField("Proper Mask")]
        public CParametrageFiltrageAlarmes MasquagePropre
        {
            get
            {
                return (CParametrageFiltrageAlarmes)GetParent(c_champIdMasquagePropre, typeof(CParametrageFiltrageAlarmes));
            }
            set
            {
                SetParent(c_champIdMasquagePropre, value);
                MasquageHerite = null;
                CalcMasquageGlobal();
            }
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Masquage hérité d'une alarme parente
        /// </summary>
        [Relation(
            CParametrageFiltrageAlarmes.c_nomTable,
            CParametrageFiltrageAlarmes.c_champId,
            c_champIdMasquageHerite,
            false,
            false,
            false)]
        [DynamicField("Inherited Mask")]
        public CParametrageFiltrageAlarmes MasquageHerite
        {
            get
            {
                return (CParametrageFiltrageAlarmes)GetParent(c_champIdMasquageHerite, typeof(CParametrageFiltrageAlarmes));
            }
            set
            {
                if (value == null)
                {
                    if (MasquagePropre != null)
                        SetParent(c_champIdMasquageHerite, MasquagePropre);
                    else
                        SetParent(c_champIdMasquageHerite, null);
                }
                else
                {
                    if (MasquageHerite != null)
                    {
                        if (MasquageHerite.CategorieMasquage.Priorite < value.CategorieMasquage.Priorite)
                            SetParent(c_champIdMasquageHerite, value);
                    }
                    else
                    {
                        if (MasquagePropre != null)
                            SetParent(c_champIdMasquageHerite, MasquagePropre);
                        else
                            SetParent(c_champIdMasquageHerite, value);
                    }
                }
                // Stock en plus le niveau de masquage en vigeur au moment de ce masquage
                if (MasquageHerite != null)
                    NiveauMasquage = MasquageHerite.CategorieMasquage.Priorite;
                else
                    NiveauMasquage = null;
            }
        }

        //---------------------------------------------------------------------------
        public CParametrageFiltrageAlarmes GetMasquageApplique()
        {
            return MasquageHerite;
        }

        /// <summary>
        /// MP : Masquage Propre
        /// MH : Masquage Hérité
        /// Fonction de calcul global du masquage
        /// Appelée obligatoirement lors de la modification du Masquage Propre
        /// Explication de l'algorithme : 
        ///  On remonte jusqu'à l'Alarme racine (Parente.Parente...) et on rappelle cette fonction sur l'Alarme Racine
        ///  On fait cela pour s'assurer que toute la branche soit bien recalculée.
        ///  A partir de l'Alarme racine:
        ///     Si elle a un masquage propre, on propage automatiquement le MH sur toutes ses filles
        ///     Sinon, on lance le calcul du masquage hérité en fonction des filles
        /// </summary>
        private void CalcMasquageGlobal()
        {
            if (AlarmeParente != null)
                AlarmeParente.CalcMasquageGlobal();
            else
            {
                if (MasquagePropre != null)
                    PropageMasquageHeriteSurFilles(MasquagePropre);
                else
                    RecalcMasquageEnCascadeFromFilles();
            }
        }

        /// <summary>
        /// MP : Masquage Propre
        /// MH : Masquage Hérité
        /// Cette fonction ne se pose pas de question,elle propage directement le Mh sur les filles
        /// Elles est récursive, elle propoage le MH sur les filles des filles des filles...
        /// </summary>
        private void PropageMasquageHeriteSurFilles(CParametrageFiltrageAlarmes masque)
        {
            foreach (CAlarme fille in AlarmesFilles)
            {
                fille.MasquageHerite = null;
                fille.MasquageHerite = masque;
                fille.PropageMasquageHeriteSurFilles(fille.GetMasquageApplique());
            }
        }

        /// <summary>
        /// MP : Masquage Propre
        /// MH : Masquage Hérité
        /// Règle de calcul du MH en fonction des Alarmes filles:
        ///     Avant de regarder toutes les filles, si l'Alarme en cours a un MP, on ne tient pas compte de l'état des filles
        ///     et on propage automatiquement un MH sur toutes les filles
        ///     Sinon, on regarde toutes les filles:
        ///         Si toutes les filles sont masquées (MP ou MH) on met l'Alarme en cours à MH = true;
        ///         Si une des filles n'est pas masquée, on met l'Alarme en cours à MH = false;
        ///     En d'autres termes, si toutes mes filles sont masquées, je n'ai pas de raison d'apparaître!
        /// </summary>
        private void RecalcMasquageEnCascadeFromFilles()
        {
            MasquageHerite = null;
            if (MasquagePropre != null)
            {
                // On arrête ici le calcul à partir des filles,
                // et on force la propagation du MH sur les filles
                PropageMasquageHeriteSurFilles(MasquagePropre);
                return;
            }

            foreach (CAlarme fille in AlarmesFilles)
            {
                fille.RecalcMasquageEnCascadeFromFilles();
            }
            bool bMasqueHerite = AlarmesFilles.Count > 0;
            CParametrageFiltrageAlarmes masqueLePlusPrioritaire = null;
            foreach (CAlarme alarmeFille in AlarmesFilles)
            {
                CParametrageFiltrageAlarmes masque = alarmeFille.GetMasquageApplique();
                if (masque == null)
                {
                    bMasqueHerite = false;
                    break;
                }
                else
                {
                    if (masqueLePlusPrioritaire == null ||
                        masque.CategorieMasquage.Priorite < masqueLePlusPrioritaire.CategorieMasquage.Priorite)
                    {
                        masqueLePlusPrioritaire = masque;
                    }
                }
            }
            if (bMasqueHerite)
                MasquageHerite = masqueLePlusPrioritaire;
        }

        //---------------------------------------------------------------------------
        /// <summary>
        /// Fonction permettant d'acquitter cette alarme
        /// </summary>
        /// <returns></returns>
        [DynamicMethod("Acknowledge the current Alarm")]
        public bool Acknowledge()
        {
            CResultAErreur result = CResultAErreur.True;
            if (DateAcquittement != null)
                return false;

            BeginEdit();

            CDonneesActeurUtilisateur utilisateurEnCours =
                CDonneesActeurUtilisateur.GetUserForSession(ContexteDonnee.IdSession, ContexteDonnee);

            if (utilisateurEnCours != null)
            {
                ResponsableAcquittement = utilisateurEnCours.Acteur;
                DateAcquittement = DateTime.Now;
                // Acquitte les alarmes filles en cascade
                foreach (CAlarme alarmeFille in AlarmesFilles)
                {
                    alarmeFille.Acknowledge();
                }
            }

            result = CommitEdit();

            return result.Result; 
        }

       
        //---------------------------------------------------------------------------------
        /// <summary>
        /// Fonction permettant de faire retomber manuellement cette alarme
        /// </summary>
        /// <returns></returns>
        [DynamicMethod("Clear manually the current Alarm")]
        public bool Clear()
        {
            CResultAErreur result = CResultAErreur.True;

            CMemoryDb db = CMemoryDbPourSupervision.GetMemoryDb(this.ContexteDonnee);
            CLocalAlarme alarme = GetLocalAlarme(db, true);
            if (alarme.EtatCode != EEtatAlarme.Close)
                alarme.EtatCode = EEtatAlarme.Close;
            result = CAlarme.TraiteAlarmesManuellement(this.ContexteDonnee.IdSession, db);
            if (result)
                CSnmpConnexion.DefaultInstance.RedescendAlarmes(db);

            return result.Result;
        }

        //---------------------------------------------------------------------------------
        public static CResultAErreur TraiteAlarmesManuellement(int nIdSession, CMemoryDb dbContenantLesAlarmesATraiter)
        {
            IAlarmeServeur alrm = CContexteDonnee.GetTableLoader ( c_nomTable, null, nIdSession ) as IAlarmeServeur;
            return alrm.TraiteAlarmesManuellement ( dbContenantLesAlarmesATraiter );
        }


        //-----------------------------------------------------------------------------------
        /// <summary>
        /// Fonction permettant de masquer cette alarme pour une date et une durée définies
        /// </summary>
        /// <param name="fromDate">Date de début du masquage</param>
        /// <param name="durationHours">Durée en heure du masquage</param>
        /// <returns>TRUE si succès</returns>
        [DynamicMethod("Mask the current Alarm for a specified period. Returns True if the Masking operation was succesful",
            "Information about Masking operation",
            "The DateTime to start Masking from",
            "The Duration of Masking in hours")]
        public bool Mask(string strInformation, DateTime fromDate, double durationHours)
        {
            DateTime dateDebut = fromDate;
            DateTime dateFin = fromDate.AddHours(durationHours);



            return false;
        }

        #region IAlarme Membres

        public CDbKey TypeAlarmeId
        {
            get
            {
                CTypeAlarme tp = TypeAlarme;
                if (tp != null)
                    return tp.DbKey;
                return null;
            }
        }

        public CDbKey SiteId
        {
            get
            {
                CSite site = Site;
                if (site != null)
                    return site.DbKey;
                return null;
            }
        }


        public CDbKey LienId
        {
            get 
            {
                CLienReseau lien = LienReseau;
                if (lien != null)
                    return lien.DbKey;
                return null;
            }
        }

        public CDbKey EquipementId
        {
            get
            {
                CEquipementLogique eqt = EquipementLogique;
                if (eqt != null)
                    return eqt.DbKey;
                return null;
            }
        }

        public CDbKey EntiteSnmpId
        {
            get
            {
                CEntiteSnmp ett = EntiteSnmp;
                if (ett != null)
                    return ett.DbKey;
                return null;
            }
        }

        #endregion
    }

    public interface IAlarmeServeur : IObjetServeur
    {
        CResultAErreur TraiteAlarmesManuellement(CMemoryDb dbContenantLesAlarmesATraiter);
    }

}
