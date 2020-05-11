using System;
using System.Linq;
using System.Collections;
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
using futurocom.snmp.entitesnmp;
using sc2i.expression;
using futurocom.snmp;
using futurocom.easyquery;
using futurocom.easyquery.snmp;
using futurocom.snmp.dynamic;
using futurocom.snmp.Mib;
using sc2i.common.memorydb;
using timos.data.supervision;
using futurocom.snmp.HotelPolling;
using timos.data.snmp.polling;

namespace timos.data.snmp
{

    /// <summary>
    /// Représente tout ou partie :
    /// <ul>
    /// <li>d'un enregistrement dans une table de MIB</li>
    /// <li>de variables scalaires dans une MIB</li>
    /// </ul>
    /// </summary>
    /// <remarks>
    /// Une entité SNMP est un objet hiérarchique pouvant donc avoir un parent<br/>
    /// et des enfants<br/><br/>
    /// Une entité SNMP peut par exemple représenter un châssis dans une baie ou<br/>
    /// une carte dans un châssis ou tout autre chose; tout dépend de la structure<br/>
    /// de la MIB qui est interrogée.
    /// </remarks>
    [DynamicClass("Snmp entity")]
    [Table(CEntiteSnmp.c_nomTable, CEntiteSnmp.c_champId, true)]
    [ObjetServeurURI("CEntiteSnmpServeur")]
    [AutoExec("Autoexec")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModuleSNMP)]
    public class CEntiteSnmp : CObjetHierarchique,        // Objet hiérérchique Prent/fils
                         IObjetDonneeAChamps,
                        IConteneurEntitesSnmp,
                        IElementADonneePourMediationSNMP,
                        IElementDeSchemaReseau

    {
        public const string c_nomTable = "SNMP_ENTITY";

        public const string c_champId = "SNMPETT_ID";

        public const string c_champLibelle = "SNMPETT_LABEL";
        public const string c_champCodeSystemePartiel = "SNMPETT_PARTIAL_SYS_CODE";
        public const string c_champCodeSystemeComplet = "SNMPETT_FULL_SYS_CODE";
        public const string c_champNiveau = "SNMPETT_LEVEL";
        public const string c_champIdParent = "SNMPETT_PARENT_ID";
        public const string c_champFromSnmp = "SNMPETT_FROM_SNMP";
        public const string c_champIndex = "SNMPETT_INDEX";

        public const string c_roleChampCustom = "SNMP_ENTITY";

        /// /////////////////////////////////////////////
        public CEntiteSnmp(CContexteDonnee contexte)
            : base(contexte)
        {
        }

        /// /////////////////////////////////////////////
        public CEntiteSnmp(DataRow row)
            : base(row)
        {
        }

        //-------------------------------------------------------------------
        public static void Autoexec()
        {
            CRoleChampCustom.RegisterRole(c_roleChampCustom, "Snmp entity", typeof(CEntiteSnmp), typeof(CTypeEntiteSnmp));
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
                return I.T("Snmp entity  @1|20093", Libelle);
            }
        }

        /// /////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
            base.MyInitValeurDefaut();
            IsFromSnmp = false;
        }

        /// /////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champIndex + "," + c_champLibelle };
        }

        ///////////////////////////////////////////////
        /// <summary>
        /// Le nom donné à l'entité SNMP.<br/>
        /// Ce nom est défini par paramétrage à partir d'une formule.
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

        //-----------------------------------------------------------
        /// <summary>
        /// Index SNMP de l'entité
        /// </summary>
        [TableFieldProperty(c_champIndex, 255)]
        [DynamicField("Smp index")]
        public string Index
        {
            get
            {
                return (string)Row[c_champIndex];
            }
            set
            {
                Row[c_champIndex] = value;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Indique si la donnée contenue vient de l'interrogation SNMP (VRAI)<br/>
        /// ou d'une saisie (FALSE)
        /// </summary>
        [TableFieldProperty(c_champFromSnmp)]
        [DynamicField("Is from SNMP")]
        public bool IsFromSnmp
        {
            get
            {
                return (bool)Row[c_champFromSnmp];
            }
            set
            {
                Row[c_champFromSnmp] = value;
            }
        }



        //-------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit le Type du EntiteSnmp. Ce champ est obligatoire.
        /// </summary>
        [Relation(CTypeEntiteSnmp.c_nomTable, CTypeEntiteSnmp.c_champId, CTypeEntiteSnmp.c_champId, true, false, true)]
        [DynamicField("Snmp entity type")]
        public CTypeEntiteSnmp TypeEntiteSnmp
        {
            get
            {
                return (CTypeEntiteSnmp)GetParent(CTypeEntiteSnmp.c_champId, typeof(CTypeEntiteSnmp));
            }
            set
            {
                SetParent(CTypeEntiteSnmp.c_champId, value);
            }
        }

        //----------------------------------------------------
        /// <summary>
        /// EntiteSnmp parent dans la hiérarchie.<br/>
        /// Si le EntiteSnmp n'a pas de EntiteSnmp parent la propriété retourne NUL.
        /// </summary>
        [Relation(
            c_nomTable,
            c_champId,
            c_champIdParent,
            false,
            false,
            true)]
        [DynamicField("Parent Entity")]
        public CEntiteSnmp EntiteSnmpParente
        {
            get
            {
                return (CEntiteSnmp)ObjetParent;
            }
            set
            {
                if (value != null)
                {
                    ObjetParent = value;
                    AgentSnmp = value.AgentSnmp;
                }
            }
        }


        //-------------------------------------------------------------------
        /// <summary>
        /// Objet 'Agent SNMP' qui contient l'entité
        /// </summary>
        [Relation(
            CAgentSnmp.c_nomTable,
            CAgentSnmp.c_champId,
            CAgentSnmp.c_champId,
            true,
            true,
            true)]
        [DynamicField("Snmp agent")]
        public CAgentSnmp AgentSnmp
        {
            get
            {
                return (CAgentSnmp)GetParent(CAgentSnmp.c_champId, typeof(CAgentSnmp));
            }
            set
            {
                SetParent(CAgentSnmp.c_champId, value);
            }
        }

        //--------------------------------------------------
        public IConteneurEntitesSnmp ConteneurEntite
        {
            get
            {
                if (EntiteSnmpParente != null)
                    return EntiteSnmpParente;
                return AgentSnmp;
            }
            set
            {
                CEntiteSnmp entite = value as CEntiteSnmp;
                if (entite != null)
                    EntiteSnmpParente = entite;
                else
                    AgentSnmp = value as CAgentSnmp;
            }
        }

        //--------------------------------------------------
        public CListeObjetsDonnees EntitesRacines
        {
            get
            {
                return EntiteSnmpsFilles;
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
        /// Retourne la liste des EntiteSnmps fils dans la hiérarchie
        /// </summary>
        [RelationFille(typeof(CEntiteSnmp), "EntiteSnmpParente")]
        [DynamicChilds("Child entities", typeof(CEntiteSnmp))]
        public CListeObjetsDonnees EntiteSnmpsFilles
        {
            get
            {
                return ObjetsFils;
            }
        }

        //----------------------------------------------------
        /// <summary>
        /// Retourne le code système propre à l'entité SNMP.<br/>
        /// Ce code système est exprimé sur 5 caractères alphanumériques.<br/>
        /// Il est unique dans son parent.
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
        /// Retourne le code système complet de l'entité SNMP
        /// </summary>
        /// <remarks>
        /// Le code complet est composé du code complet de l'entité parente<br/>
        /// et du code propre de l'entité.<br/>
        /// Exemple : si 0001W est le code complet d'une entité châssis<br/>
        /// et 0002B est le code propre d'une entité carte dans le châssis,<br/>
        /// le code complet de l'entité carte est : 0001W0002B
        /// </remarks>
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
        /// Indique le niveau hiérarchique( nombre de parents ) du EntiteSnmp<br/><br/>
        /// Le niveau d'un EntiteSnmp sans parent est 0
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
            return new CRelationEntiteSnmp_ChampCustom(ContexteDonnee);
        }

        //----------------------------------------------------
        public string GetNomTableRelationToChamps()
        {
            return CRelationEntiteSnmp_ChampCustom.c_nomTable;
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
                return new IDefinisseurChampCustom[] { TypeEntiteSnmp };
            }
        }

        //----------------------------------------------------
        public CChampCustom[] GetChampsHorsFormulaire()
        {
            if (TypeEntiteSnmp == null)
                return new CChampCustom[0];

            ArrayList lst = new ArrayList();
            foreach (CRelationTypeEntiteSnmp_ChampCustom rel in TypeEntiteSnmp.RelationsChampsCustomDefinis)
                lst.Add(rel.ChampCustom);

            foreach (CRelationTypeEntiteSnmp_Formulaire rel1 in TypeEntiteSnmp.RelationsFormulaires)
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
        /// Retourne la liste des relations de l'entité SNMP avec les champs personnalisés
        /// </summary>
        [RelationFille(typeof(CRelationEntiteSnmp_ChampCustom), "ElementAChamps")]
        [DynamicChilds("Custom fields relations", typeof(CRelationEntiteSnmp_ChampCustom))]
        public CListeObjetsDonnees RelationsChampsCustom
        {
            get
            {
                return GetDependancesListe(CRelationEntiteSnmp_ChampCustom.c_nomTable, c_champId);
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
        public CResultAErreur SetValeurFromSnmp(int nIdChampCustom, object valeur)
        {
            CResultAErreur result = SetValeurChamp(nIdChampCustom, valeur);
            if (!result)
                return result;
            CRelationEntiteSnmp_ChampCustom rel = CUtilElementAChamps.GetRelationToChamp(this, nIdChampCustom) as CRelationEntiteSnmp_ChampCustom;
            if (rel != null)
            {
                rel.LastSnmpValue = valeur;
            }
            
            return result;
        }



        //----------------------------------------------------------------
        public CEntiteSnmpPourSupervision GetEntitePourSupervision(CTypeEntiteSnmpPourSupervision typeEntite)
        {
            if (typeEntite == null)
                return null;
            //Cherche le type d'entite
            if (typeEntite == null)
                return null;

            CEntiteSnmpPourSupervision entite = new CEntiteSnmpPourSupervision(typeEntite.Database);
            if (!entite.ReadIfExist(Id.ToString(), false))
                entite.CreateNew(Id.ToString());
            else
                if (!entite.IsToRead())
                    return entite;
            entite.Row[CMemoryDb.c_champIsToRead] = false;
            entite.TypeEntite = typeEntite;
            entite.Libelle = Libelle;
            entite.Index = Index;
            if (SiteSupervise != null)
                entite.IdSiteAssocie = SiteSupervise.DbKey;
            if (EquipementLogiqueSupervise != null)
            {
                entite.IdEquipementLogiqueAssocie = EquipementLogiqueSupervise.DbKey;
                entite.IdSiteAssocie = EquipementLogiqueSupervise.Site.DbKey;
            }
            if (LienReseauSupervise != null)
                entite.IdLienReseauAssocie = LienReseauSupervise.DbKey;
            HashSet<int> champsCustomFaits = new HashSet<int>();
            foreach (CChampEntiteFromQueryToChampCustom champ in TypeEntiteSnmp.ChampsFromQuery)
            {
                if (champ.IdChampCustom != null)
                {
                    object val = GetValeurChamp(champ.IdChampCustom.Value);
                    entite.SetValeurChamp(champ.Champ.Id, val);
                    champsCustomFaits.Add(champ.IdChampCustom.Value);
                }
            }
            //Ajoute les champs qui ne font pas parti des champs from query
            foreach (CRelationDefinisseurChamp_ChampCustom def in TypeEntiteSnmp.RelationsChampsCustomDefinis)
            {
                if (!champsCustomFaits.Contains(def.ChampCustom.Id))
                {
                    object val = GetValeurChamp(def.ChampCustom.Id);
                    if (def.ChampCustom.TypeDonneeChamp.TypeDonnee == TypeDonnee.tObjetDonneeAIdNumeriqueAuto && val is CObjetDonneeAIdNumerique)
                    {
                        val = ((CObjetDonneeAIdNumerique)val).Id;
                    }
                    entite.SetValeurChamp(def.ChampCustom.Id.ToString(), val);
                }
            }

            //Ajoute les valeurs des champs calculés
            foreach (CFormuleNommee champ in TypeEntiteSnmp.ChampsCalculesPourMediation)
            {
                if (champ.Formule != null)
                {
                    CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(this);
                    CResultAErreur result = champ.Formule.Eval(ctx);
                    if (result && result.Data != null)
                    {
                        if (result.Data is CObjetDonneeAIdNumerique)
                            result.Data = ((CObjetDonneeAIdNumerique)result.Data).Id;
                        entite.SetValeurChamp(champ.Id, result.Data);
                    }
                }
            }
            return entite;
        }

        //-------------------------------------------------------------------------------
        private CColumnDefinitionSNMP GetSourceColumn(
            IObjetDeEasyQuery objetDeQuery,
            CChampEntiteFromQueryToChampCustom champ)
        {
            if (objetDeQuery == null || objetDeQuery.Query == null)
                return null;

            ITableDefinition table = null;
            IColumnDefinition col = null;
            if (objetDeQuery.Query.FindSource(champ.Champ.ColonneSource, objetDeQuery,
                out table,
                out col))
            {
                return col as CColumnDefinitionSNMP;
            }
            return null;
        }

        //-------------------------------------------------------------------------------
        private CColumnDefinitionSNMP GetSourceColumn(int nIdChampCustom)
        {
            if (TypeEntiteSnmp == null)
                return null;
            CChampEntiteFromQueryToChampCustom field = TypeEntiteSnmp.ChampsFromQuery.FirstOrDefault(c => c.IdChampCustom != null &&
                c.IdChampCustom == nIdChampCustom);
            if (field != null)
                return GetSourceColumn(TypeEntiteSnmp.FindSourceObjetInQuery().DataType, field);
            return null;
        }

        //-------------------------------------------------------------------------------
        public CResultAErreur ReadChampSnmp(int nIdChampCustom, CInterrogateurSnmp dynamicAgent)
        {
            CEntiteSnmpPourSupervision ettPourSup = null;
            return ReadChampSnmp(nIdChampCustom, dynamicAgent, ref ettPourSup);
        }

        //-------------------------------------------------------------------------------
        [DynamicMethod("Returns associated field OID for direct SNMP interrogation")]
        public string GetFieldOID(int nIdChampCustom)
        {
            CResultAErreurType<string> res = GetFieldOIDWithEntitePourSupervision(nIdChampCustom, null);
            if (res)
                return res.DataType;
            return null;
        }

        //-------------------------------------------------------------------------------
        public CResultAErreurType<string> GetFieldOIDWithEntitePourSupervision(int nIdChampCustom, CEntiteSnmpPourSupervision ettPourSup)
        {
            CResultAErreurType<string> resString = new CResultAErreurType<string>();
            CColumnDefinitionSNMP colSnmp = GetSourceColumn(nIdChampCustom);
            if (colSnmp == null)
            {
                CChampCustom champ = new CChampCustom(ContexteDonnee);
                string strChamp = nIdChampCustom.ToString();
                if (champ.ReadIfExists(nIdChampCustom))
                    strChamp = champ.Nom;
                resString.EmpileErreur(I.T("Can not find snmp source for @1|20099", strChamp));
                return resString;
            }

            IEnumerable<CChampEntiteFromQueryToChampCustom> lstChamps = TypeEntiteSnmp.ChampsFromQuery;
            CChampEntiteFromQueryToChampCustom assocChamp = lstChamps.FirstOrDefault(c => c.IdChampCustom == nIdChampCustom);
            string strOID = colSnmp.OIDString;
            string strIndex = Index;
            if (assocChamp != null && assocChamp.Champ.FormuleIndex != null)
            {
                if (ettPourSup == null)
                    ettPourSup = GetEntitePourSupervision(TypeEntiteSnmp.GetTypeEntitePourSupervision(null, false));
                CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(ettPourSup);
                CResultAErreur resTmp = assocChamp.Champ.FormuleIndex.Eval(ctxEval);
                if ( resTmp && resTmp.Data != null )
                    strIndex = resTmp.Data.ToString();
            }
            if (strIndex.Length > 0)
            {
                if (!strIndex.StartsWith("."))
                    strOID += ".";
                strOID += strIndex;
            }
            resString.DataType = strOID;
            return resString;
        }

        //-------------------------------------------------------------------------------
        //Optimisation : l'entité pour sup n'est créée qu'une seul fois lors d'appels multiples
        public CResultAErreur ReadChampSnmp(int nIdChampCustom, CInterrogateurSnmp dynamicAgent, ref CEntiteSnmpPourSupervision ettPourSup)
        {
            CResultAErreur result = CResultAErreur.True;

            CResultAErreurType<string> resOID = GetFieldOIDWithEntitePourSupervision(nIdChampCustom, ettPourSup);
            if (!resOID)
            {
                result.EmpileErreur(resOID.Erreur);
                return result;
            }

            string strOID = resOID.DataType;
            ISnmpData valeur = dynamicAgent.Get(strOID) as ISnmpData;
            CRelationEntiteSnmp_ChampCustom relChamp = CUtilElementAChamps.GetRelationToChamp(this, nIdChampCustom) as CRelationEntiteSnmp_ChampCustom;
            if (relChamp != null)
            {
                if (valeur == null)
                    relChamp.LastSnmpValue = null;
                else
                    relChamp.LastSnmpValue = valeur.ConvertToTypeDotNet();
            }
            result.Data = valeur != null ? valeur.ConvertToTypeDotNet() : null;
            return result;
        }

        //-------------------------------------------------------------------------------
        public CResultAErreur ReadChampSnmp(int nIdChampCustom)
        {
            CResultAErreur result = CResultAErreur.True;
            
            //Va chercher la valeur
            CSnmpConnexion cnx = AgentSnmp.GetNewSnmpConnexion();
            CInterrogateurSnmp agent = new CInterrogateurSnmp();
            agent.Connexion = cnx;
            return ReadChampSnmp(nIdChampCustom, agent);
        }

        //-------------------------------------------------------------------------------
        [DynamicMethod("Prepare system for safe call to GetSnmpValue in thread mode",
            "Custom field id")]
        public void PrepareForAsynchronousGetSnmpValue(int nIdChampCustom)
        {
            GetFieldOID(nIdChampCustom);
        }

        //-------------------------------------------------------------------------------
        [DynamicMethod("Returns SNMP value for specified custom field ID",
            "Custom field ID")]
        public object GetSnmpValueForField(int nIdChampCustom)
        {
            //Récupère l'oid
            string strOid = GetFieldOID(nIdChampCustom);
            if ( strOid != null && strOid.Length > 0 )
            {
                CSnmpConnexion cnx = AgentSnmp.GetNewSnmpConnexion();
                CInterrogateurSnmp agent = new CInterrogateurSnmp();
                agent.Connexion = cnx;
                return agent.Get ( strOid );
            }
            return null;
            /*CResultAErreur result = ReadChampSnmp(nIdChampCustom);
            if (!result)
                return null;
            CRelationEntiteSnmp_ChampCustom relChamp = CUtilElementAChamps.GetRelationToChamp(this, nIdChampCustom) as CRelationEntiteSnmp_ChampCustom;
            if (relChamp != null)
            {
                return relChamp.LastSnmpValue;
            }
            else
            {
            }
            return result.Data ;*/
        }


        //-------------------------------------------------------------------------------
        [DynamicMethod("Set SNMP value (if allowed ) for specified custom field ID, returns true if successfull",
            "Custom field ID","value")]
        public bool SetSnmpValueForField(int nIdChampCustom, object value)
        {
            ITableDefinition table = null;
            IColumnDefinition col = null;

            CResultAErreurType<IObjetDeEasyQuery> resObj = TypeEntiteSnmp.FindSourceObjetInQuery();
            if (!resObj || resObj.DataType == null)
            {
                return false;
            }

            IObjetDeEasyQuery objetSource = resObj.DataType;
            CEasyQuery query = objetSource.Query;
            IEnumerable<CChampEntiteFromQueryToChampCustom> lstChamps = TypeEntiteSnmp.ChampsFromQuery;
            CChampEntiteFromQueryToChampCustom champ = null;
            foreach (CChampEntiteFromQueryToChampCustom champTest in lstChamps)
            {
                if (champTest.IdChampCustom != null &&
                    champTest.IdChampCustom == nIdChampCustom)
                {
                    champ = champTest;
                    break;
                }
            }
            if (champ == null)
                return false;

            if (query.FindSource(champ.Champ.ColonneSource, objetSource,
                out table,
                out col))
            {
                CEntiteSnmpPourSupervision ettPourSup = null;
                CColumnDefinitionSNMP colSnmp = col as CColumnDefinitionSNMP;

                if (colSnmp != null && !colSnmp.IsReadOnly)
                {
                    ISnmpData snmpVal = AbstractTypeAssignment.GetSnmpFromDotNet(colSnmp.SnmpType, value);
                    if (snmpVal == null && value != null)
                        snmpVal = new OctetString(value.ToString());
                    if (snmpVal != null)
                    {
                        string strIndex = Index;
                        if (champ.Champ.FormuleIndex != null)
                        {
                            if (ettPourSup == null)
                                ettPourSup = GetEntitePourSupervision(TypeEntiteSnmp.GetTypeEntitePourSupervision(null, false));
                            CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(ettPourSup);
                            CResultAErreur restTmp = champ.Champ.FormuleIndex.Eval(ctx);
                            if (restTmp && restTmp.Data != null)
                                strIndex = restTmp.Data.ToString();
                        }
                        if (!strIndex.StartsWith("."))
                            strIndex = "." + strIndex;
                        try
                        {
                            CInterrogateurSnmp agent = new CInterrogateurSnmp();
                            agent.Connexion.Version = AgentSnmp.SnmpVersion;
                            agent.ConnexionIp = AgentSnmp.SnmpIp;
                            agent.ConnexionPort = AgentSnmp.SnmpPort;
                            agent.ConnexionCommunity = AgentSnmp.SnmpCommunaute;
                            CResultAErreur resTmp = agent.Set(colSnmp.OIDString + strIndex, snmpVal);
                            if (resTmp)
                                return true;
                        }
                        catch
                        {
                        }



                    }
                }
            }
            return false;
        }

        




        //-------------------------------------------------------------------------------
        public CResultAErreur FillFromSnmp(CEntiteSnmpPourSupervision entiteFromSnmp)
        {
            CResultAErreur result = CResultAErreur.True;
            CTypeAgentSnmp typeAgent = AgentSnmp.TypeAgent;
            CTypeEntiteSnmp[] typesEntites = (CTypeEntiteSnmp[])typeAgent.TypesEntites.ToArray(typeof(CTypeEntiteSnmp));
            CTypeEntiteSnmp typeEntite = typesEntites.FirstOrDefault(t => t.Id.ToString() == entiteFromSnmp.TypeEntite.Id);
            if (typeEntite == null)
            {
                result.EmpileErreur(I.T("Can not find Snmp entity type @1|20309", entiteFromSnmp.TypeEntite.Id));
                return result;
            }
            TypeEntiteSnmp = typeEntite;
            Index = entiteFromSnmp.Index;
            Libelle = entiteFromSnmp.Libelle;

            //Affecte les champs
            foreach (CChampEntiteFromQueryToChampCustom champ in typeEntite.ChampsFromQuery)
            {
                if (champ.IdChampCustom != null)
                {
                    CChampCustom champCustom = new CChampCustom(ContexteDonnee);
                    if (champCustom.ReadIfExists(champ.IdChampCustom))
                    {
                        object valeur = entiteFromSnmp.GetValeurChamp(champ.Champ.Id);
                        if (valeur != null)
                        {
                            if (champCustom.TypeDonneeChamp.TypeDonnee == TypeDonnee.tObjetDonneeAIdNumeriqueAuto)
                            {
                                Type tp = champCustom.TypeObjetDonnee;
                                CObjetDonneeAIdNumerique obj = Activator.CreateInstance(tp, new object[] { ContexteDonnee }) as CObjetDonneeAIdNumerique;
                                if (valeur is int)
                                {
                                    if (obj != null && obj.ReadIfExists((int)valeur, true))
                                        SetValeurFromSnmp(champ.IdChampCustom.Value, obj);
                                }
                                else
                                    SetValeurFromSnmp(champ.IdChampCustom.Value, null);
                            }
                            else
                                SetValeurFromSnmp(champ.IdChampCustom.Value, valeur);
                        }
                    }
                }
            }

            //calcule le libellé
            if (typeEntite.FormuleCalculLibelle != null)
            {
                CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(this);
                result = typeEntite.FormuleCalculLibelle.Eval(ctx);
                if (result && result.Data != null)
                    Libelle = result.Data.ToString();
                result = CResultAErreur.True;
            }

            return result;
        }

        //-----------------------------------------------------------------------
        public void CopieValeurSnmpDansValeurChamp(int nIdChampCustom)
        {
            CRelationEntiteSnmp_ChampCustom rel = CUtilElementAChamps.GetRelationToChamp(this, nIdChampCustom) as CRelationEntiteSnmp_ChampCustom;
            if (rel != null)
                SetValeurFromSnmp(nIdChampCustom, rel.LastSnmpValue);
        }

        //-----------------------------------------------------------------------
        //Si idsChampsAMettreAJour est vide, il faut tout mettre à jour
        public CResultAErreur SendToSnmp(bool bOnlyModifiés, params int[] idsChampsAMettreAJour)
        {
            CResultAErreur result = CResultAErreur.True;
            if (TypeEntiteSnmp == null)
                return result;
            if (TypeEntiteSnmp.ReadOnly)
            {
                result.EmpileErreur(I.T("This is a readonly entity|20127"));
                return result;
            }
            IEnumerable<CChampEntiteFromQueryToChampCustom> lstChamps = TypeEntiteSnmp.ChampsFromQuery;
            Dictionary<string, object> lstValeurs = new Dictionary<string, object>();
            CResultAErreurType<IObjetDeEasyQuery> resObj = TypeEntiteSnmp.FindSourceObjetInQuery ( );
            if ( !resObj || resObj.DataType == null )
            {
                result.EmpileErreur ( resObj.Erreur );
                return result;
            }
                
            IObjetDeEasyQuery objetSource = resObj.DataType;
            CEasyQuery query = objetSource.Query;

            Dictionary<string, string> dicOIDStringToChamp = new Dictionary<string, string>();
            CEntiteSnmpPourSupervision ettPourSup = null;
               
            foreach (CChampEntiteFromQueryToChampCustom champ in lstChamps)
            {
                if (champ.IdChampCustom != null && (idsChampsAMettreAJour.Length == 0 ||
                    idsChampsAMettreAJour.Contains ( champ.IdChampCustom.Value) ) )
                {
                    CRelationElementAChamp_ChampCustom rel = CUtilElementAChamps.GetRelationToChamp(this, champ.IdChampCustom.Value);
                    if (rel != null && (bOnlyModifiés && (rel.Row.RowState == DataRowState.Added || rel.Row.RowState == DataRowState.Modified) ||
                        !bOnlyModifiés))
                    {
                        object valeur = rel.Valeur;

                        ITableDefinition table = null;
                        IColumnDefinition col = null;
                        if (query.FindSource(champ.Champ.ColonneSource, objetSource,
                            out table,
                            out col))
                        {
                            CColumnDefinitionSNMP colSnmp = col as CColumnDefinitionSNMP;
                            
                            if (colSnmp != null && !champ.Champ.IsReadOnly)
                            {
                                ISnmpData snmpVal = AbstractTypeAssignment.GetSnmpFromDotNet(colSnmp.SnmpType, valeur);
                                if (snmpVal == null && valeur != null)
                                    snmpVal = new OctetString(valeur.ToString());
                                if (snmpVal != null)
                                {
                                    string strIndex = Index;
                                    if (champ.Champ.FormuleIndex != null)
                                    {
                                        if (ettPourSup == null)
                                            ettPourSup = GetEntitePourSupervision(TypeEntiteSnmp.GetTypeEntitePourSupervision(null, false));
                                        CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(ettPourSup);
                                        CResultAErreur restTmp = champ.Champ.FormuleIndex.Eval(ctx);
                                        if (restTmp && restTmp.Data != null)
                                            strIndex = restTmp.Data.ToString();
                                    }
                                    if (!strIndex.StartsWith("."))
                                        strIndex = "." + strIndex;
                                    lstValeurs[colSnmp.OIDString+strIndex] = snmpVal;
                                    dicOIDStringToChamp[colSnmp.OIDString + strIndex] = champ.ChampCustom.Nom;
                                }
                            }
                        }
                    }
                }
            }
            if (lstValeurs.Count > 0)
            {
                CInterrogateurSnmp agent = new CInterrogateurSnmp();
                agent.Connexion.Version = AgentSnmp.SnmpVersion;
                agent.ConnexionIp = AgentSnmp.SnmpIp;
                agent.ConnexionPort = AgentSnmp.SnmpPort;
                agent.ConnexionCommunity = AgentSnmp.SnmpCommunaute;
                foreach (KeyValuePair<string, object> kv in lstValeurs)
                {
                    try
                    {
                        CResultAErreur resTmp = agent.Set(kv.Key, kv.Value);

                        if (!resTmp)
                        {
                            string strChamp = null;
                            if (dicOIDStringToChamp.TryGetValue(kv.Key, out strChamp))
                                result.EmpileErreur(new CErreurValidation(I.T("Entity @1 (@2), Field @3 : |20105", Libelle, Index, strChamp) + resTmp.Erreur.ToString(), resTmp.IsAvertissement));
                            else
                                result.EmpileErreur(resTmp.Erreur);
                            if ( !result.IsAvertissement )
                            {
                                return result;
                            }
                        }
                    }
                    catch (Exception e )
                    {
                        result.EmpileErreur(new CErreurException(e));
                    }
                }
            }
            return result;
        }

        //------------------------------------------
        public CResultAErreur LireValeursSnmp()
        {
            CResultAErreur result = CResultAErreur.True;
            if ( TypeEntiteSnmp == null )
                return result;
            IEnumerable<CChampEntiteFromQueryToChampCustom> champs = from champ in TypeEntiteSnmp.ChampsFromQuery
                                 where
                                     champ.IdChampCustom != null && !champ.Champ.NoUpdateFromSnmp
                                 select champ;
            CInterrogateurSnmp dynamicAgent = new CInterrogateurSnmp();
            dynamicAgent.Connexion = AgentSnmp.GetNewSnmpConnexion();
            CEntiteSnmpPourSupervision ettPourSup = null;
            foreach (CChampEntiteFromQueryToChampCustom champ in champs)
            {
                result += ReadChampSnmp(champ.IdChampCustom.Value, dynamicAgent, ref ettPourSup);
            }
            return result;
        }

        //------------------------------------------
        public int[] IdsProxysConcernesParDonneesMediation
        {
            get {
                if (IsValide())
                {
                    if (AgentSnmp != null && AgentSnmp.ProxyDeMediationSnmp != null)
                        return new int[] { AgentSnmp.ProxyDeMediationSnmp.Id };
                    return new int[0];
                }
                return new int[0];
            }
        }

        //------------------------------------------
        public int[] IdsProxysConcernesParConfigurationProxy
        {
            get
            {
                return new int[0];
            }
        }

        //------------------------------------------
        public void RecalcLibelle()
        {
            C2iExpression formule = TypeEntiteSnmp.FormuleCalculLibelle;
            if (formule != null)
            {
                CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(this);
                CResultAErreur result = formule.Eval(ctx);
                if (result && result.Data != null)
                    Libelle = result.Data.ToString();
            }
        }



        //-------------------------------------------------------------------
        /// <summary>
        /// Le Site associé à l'entité SNMP, s'il existe
        /// </summary>
        [Relation(
            CSite.c_nomTable,
            CSite.c_champId,
            CSite.c_champId,
            false,
            false,
            false)]
        [DynamicField("Supervised Site")]
        public CSite SiteSupervise
        {
            get
            {
                return (CSite)GetParent(CSite.c_champId, typeof(CSite));
            }
            set
            {
                SetParent(CSite.c_champId, value);
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// L'équipement logique associé à l'entité SNMP, s'il existe
        /// </summary>
        [Relation(
            CEquipementLogique.c_nomTable,
            CEquipementLogique.c_champId,
            CEquipementLogique.c_champId,
            false,
            false,
            false)]
        [DynamicField("Supervised Logical Equipment")]
        public CEquipementLogique EquipementLogiqueSupervise
        {
            get
            {
                return (CEquipementLogique)GetParent(CEquipementLogique.c_champId, typeof(CEquipementLogique));
            }
            set
            {
                SetParent(CEquipementLogique.c_champId, value);
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Le lien réseau associé à l'entité SNMP, s'il existe
        /// </summary>
        [Relation(
            CLienReseau.c_nomTable,
            CLienReseau.c_champId,
            CLienReseau.c_champId,
            false,
            false,
            false)]
        [DynamicField("Supervised Network Link")]
        public CLienReseau LienReseauSupervise
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


        public IElementSupervise ElementSupervise
        {
            get
            {
                if (SiteSupervise != null)
                    return SiteSupervise;
                else if (EquipementLogiqueSupervise != null)
                    return EquipementLogiqueSupervise;
                else return LienReseauSupervise;
            }
            set
            {
                if (value is CSite)
                    SiteSupervise = (CSite)value;
                else if (value is CEquipementLogique)
                    EquipementLogiqueSupervise = (CEquipementLogique)value;
                else if (value is CLienReseau)
                    LienReseauSupervise = (CLienReseau)value;
            }
        }


        #region IElementDeSchemaReseau Membres

        public C2iObjetDeSchema GetObjetDeSchema(CElementDeSchemaReseau elementDeSchema)
        {
            C2iObjetDeSchema objet = new C2iObjetDeSchema();
            C2iSymbole symbole = SymboleADessiner;
            objet.ElementDeSchema = elementDeSchema;
            return objet;
        }

        #endregion

        #region IElementASymbolePourDessin Membres

        public C2iSymbole SymboleADessiner
        {
            get
            {
                C2iSymbole symbole = null;
                if (TypeEntiteSnmp != null)
                    symbole = TypeEntiteSnmp.SymboleDefiniADessiner;
                if (symbole == null)
                    symbole = CSymbole.GetSymboleParDefaut(typeof(CEntiteSnmp), ContexteDonnee);
                if (symbole != null)
                {
                    symbole = symbole.GetCloneSymbole();
                    symbole.ElementASymbole = this;
                }
                return symbole;
            }
        }

        #endregion

        //---------------------------------------------------------------------------------
        public CResultAErreurType<IEnumerable<CSnmpHotelPolledData>> GetSnmpHotelPolledData()
        {
            CResultAErreurType<IEnumerable<CSnmpHotelPolledData>> result = new CResultAErreurType<IEnumerable<CSnmpHotelPolledData>>();
            List<CSnmpHotelPolledData> lstData = new List<CSnmpHotelPolledData>();
            if ( TypeEntiteSnmp != null )
            {
                foreach ( CSnmpPollingFieldSetup s in TypeEntiteSnmp.PollingFields.Fields )
                {
                    CResultAErreurType<CSnmpHotelPolledData> res = s.GetHotelPolledData(this);
                    if (!res)
                        result.EmpileErreur(res.Erreur);
                    else if (res.DataType is CSnmpHotelPolledData)
                        lstData.Add(res.DataType);
                }
            }
            result.DataType = lstData;
            return result;
        }
    }
}


