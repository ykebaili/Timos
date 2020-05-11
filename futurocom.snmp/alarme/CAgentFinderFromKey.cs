using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.expression;
using futurocom.snmp.Messaging;
using futurocom.snmp.Mib;
using sc2i.common;
using futurocom.supervision;
using sc2i.common.SimpleMatch;
using futurocom.snmp.dynamic;
using futurocom.easyquery;
using futurocom.snmp.entitesnmp;
using sc2i.common.memorydb;
using System.Data;
using sc2i.common.trace;

namespace futurocom.snmp.alarme
{
    /// <summary>
    /// Permet d'identifier un Agent SNMP à partir d'un clé calculée par formule, 
    /// au lieu de se baser uniquement sur son adresse IP principale. 
    /// La clé calculée sera comparée à la valeur du champ Adresse IP secondaire de l'Agent
    /// </summary>
    [MemoryTable ( CAgentFinderFromKey.c_nomTable, CAgentFinderFromKey.c_champId)]
    public class CAgentFinderFromKey : CEntiteDeMemoryDbAIdAuto, IFournisseurProprietesDynamiques
    {
        private const string c_strNomVariableTrap = "Trap";

        public const string c_nomTable = "AGENT_FINDER";
        public const string c_champId = "AGENTFINDER_ID";
        public const string c_champLibelle = "AGENTFINDER_LABEL";
        public const string c_champDescription = "AGENTFINDER_DESC";
        public const string c_champFieldsFromTrap = "AGENTFIND_TRAP_FIELDS";
        public const string c_champFieldsSupplementaires = "AGENTFIND_ADDED_FIELDS";
        public const string c_champEntrepriseValue = "AGENTFIND_ENTREPRISE_VALUE";
        public const string c_champSpecificValue = "AGENTFIND_SPECIFIC_VALUE";
        public const string c_champCommunityValue = "AGENTFIND_COMMUNITY_VALUE";
        public const string c_champGenericCode = "AGENTFIND_GENERIC_CODE";
        public const string c_champFormuleCleSpecifique = "AGENTFIND_KEY_FORMULA";
        public const string c_champFormuleConditionApplication = "AGENTFIND_APPLICATION_FORMULA";
        public const string c_champAutoUpdateIpOnMediationServices = "AGENTFIND_UPDATE_MEDIATION_IP";
        public const string c_champAutoUpdateIpOnTimosDatabase = "AGENTFIND_UPDATE_TIMOS_IP";


        //---------------------------------------
        public CAgentFinderFromKey(CMemoryDb db )
            :base ( db )
        {
        }

        //---------------------------------------
        public CAgentFinderFromKey(DataRow row)
            : base(row)
        {
        }

        //---------------------------------------
        public override void MyInitValeursParDefaut()
        {
            Libelle = "";
            Description = "";
            EntrepriseRequestedValue = "";
            SpecificRequestedValue = "";
            CommunityRequestedValue = "";
        }

        //---------------------------------------
        [MemoryField(c_champFieldsFromTrap)]
        public IEnumerable<CTrapField> FieldsFromTrap
        {
            get
            {
                IEnumerable<CTrapField> lst = Row.Get<IEnumerable<CTrapField>>(c_champFieldsFromTrap);
                if (lst == null)
                {
                    lst = new List<CTrapField>();
                    Row[c_champFieldsFromTrap] = lst;
                }
                return lst;
            }
        }

        //---------------------------------------
        private List<CTrapField> FieldsFromTrapList
        {
            get
            {
                return (List<CTrapField>)FieldsFromTrap;
            }
        }

        //---------------------------------------
        [MemoryField(c_champFieldsSupplementaires)]
        public IEnumerable<CTrapFieldSupplementaire> FieldsSupplementaires
        {
            get
            {
                IEnumerable<CTrapFieldSupplementaire> lst = Row.Get <IEnumerable<CTrapFieldSupplementaire>>(c_champFieldsSupplementaires);
                if (lst == null)
                {
                    lst = new List<CTrapFieldSupplementaire>();
                    Row[c_champFieldsSupplementaires] = lst;
                }
                return lst;
            }
        }

        //---------------------------------------
        private List<CTrapFieldSupplementaire> FieldsSupplementairesList
        {
            get
            {
                return (List<CTrapFieldSupplementaire>)FieldsSupplementaires;
            }
        }

        //---------------------------------------
        public CInterrogateurSnmp InterrogateurSNMP
        {
            get
            {
                if (TypeAgent != null)
                    return TypeAgent.InterrogateurSNMP;
                return null;
            }
        }

        //---------------------------------------
        [MemoryParent(true)]
        public CTypeAgentPourSupervision TypeAgent
        {
            get
            {
                return GetParent<CTypeAgentPourSupervision>();
            }
            set
            {
                SetParent<CTypeAgentPourSupervision>(value);
            }
        }

        //---------------------------------------
        public void AddFieldFromTrap(CTrapField field)
        {
            if (field == null)
                return;
            if (FieldsFromTrapList.FirstOrDefault(f => f.Name == field.Name) == null)
                FieldsFromTrapList.Add(field);
        }

        //---------------------------------------
        public void RemoveFieldFromTrap(CTrapField field)
        {
            FieldsFromTrapList.Remove(field);
        }

        //---------------------------------------
        public void ClearFieldsFromTrap()
        {
            FieldsFromTrapList.Clear();
        }

        //---------------------------------------
        public void AddFieldSupplementaire(CTrapFieldSupplementaire field)
        {
            if (field == null)
                return;
            if (FieldsSupplementairesList.FirstOrDefault(f => f.Name == field.Name) == null)
                FieldsSupplementairesList.Add(field);
        }

        //---------------------------------------
        public void RemoveFieldSupplementaire(CTrapFieldSupplementaire field)
        {
            FieldsSupplementairesList.Remove(field);
        }

        //---------------------------------------
        public void ClearFieldsSupplementaires()
        {
            FieldsSupplementairesList.Clear();
        }

        //---------------------------------------
        [DynamicField("Label")]
        [MemoryField(c_champLibelle)]
        public string Libelle
        {
            get
            {
                return Row.Get<string>(c_champLibelle);
            }
            set
            {
                Row[c_champLibelle] = value;
            }
        }

        //---------------------------------------
        [DynamicField("Description")]
        [MemoryField(c_champDescription)]
        public string Description
        {
            get
            {
                return Row.Get<string>(c_champDescription);
            }
            set
            {
                Row[c_champDescription] = value;
            }
        }


        //---------------------------------------
        /// <summary>
        /// Pour que ce handler se déclenche, Entreprise doit avoir la valeur demandée
        /// sauf si la valeur requested est vide
        /// </summary>
        [DynamicField("Entreprise requested value")]
        [MemoryField(c_champEntrepriseValue)]
        public string EntrepriseRequestedValue
        {
            get
            {
                return Row.Get<string>(c_champEntrepriseValue);
            }
            set
            {
                Row[c_champEntrepriseValue] = value;
            }
        }

        //---------------------------------------
        [DynamicField("Specific requested value")]
        [MemoryField(c_champSpecificValue)]
        /// <summary>
        /// Pour que ce handler se déclenche, Specific doit avoir la valeur demandée
        /// sauf si la valeur requested est vide
        /// </summary>
        public string SpecificRequestedValue
        {
            get
            {
                return Row.Get<string>(c_champSpecificValue);
            }
            set
            {
                Row[c_champSpecificValue] = value;
            }
        }

        //---------------------------------------
        [DynamicField("Community requested value")]
        /// <summary>
        /// Pour que ce handler se déclenche, Community doit être
        /// égale la valeur spécifiée
        /// Sauf si la valeur requested est vide
        /// </summary>
        [MemoryField(c_champCommunityValue)]
        public string CommunityRequestedValue
        {
            get
            {
                return Row.Get<string>(c_champCommunityValue);
            }
            set
            {
                Row[c_champCommunityValue] = value;
            }
        }

        //---------------------------------------
        /// <summary>
        /// Pour que le handler se déclenche, Generic doit avoir la valeur
        /// spécifiée, sauf si la valeur spécifiée est nulle
        /// </summary>
        [MemoryField(c_champGenericCode)]
        public GenericCode? GenericRequestedValue
        {
            get
            {
                return (GenericCode ?)Row.Get<int?>(c_champGenericCode);
            }
            set
            {
                Row[c_champGenericCode] = value;
            }
        }

        //---------------------------------------------------------------------
        /// <summary>
        /// Formule de calcul de la clé d'identification de l'Agent. 
        /// Cette clé sera comparée à la valeur du champ Adresse IP secondaire de l'Agent
        /// </summary>
        [MemoryField(c_champFormuleCleSpecifique)]
        public C2iExpression FormuleCleSpecifique
        {
            get
            {
                C2iExpression formule = Row.Get<C2iExpression>(c_champFormuleCleSpecifique);
                return formule;
            }
            set
            {
                Row[c_champFormuleCleSpecifique] = value;
            }
        }

        /// <summary>
        /// Indique qu'un changement d'ip detecté par ce finder change l'ip
        /// de l'agent sur le service de médiation
        /// </summary>
        [MemoryField(c_champAutoUpdateIpOnMediationServices)]
        public bool AutoUpdateIpOnMediationServices
        {
            get
            {
                return Row.Get<bool>(c_champAutoUpdateIpOnMediationServices);
            }
            set
            {
                Row[c_champAutoUpdateIpOnMediationServices] = value;
            }
        }

        /// <summary>
        /// Indique qu'un changement d'ip detecté par ce finder change l'ip
        /// de l'agent sur le serveur TIMOS
        /// </summary>
        [MemoryField(c_champAutoUpdateIpOnTimosDatabase)]
        public bool AutoUpdateIpOnTimosDatabase
        {
            get
            {
                return Row.Get<bool>(c_champAutoUpdateIpOnTimosDatabase);
            }
            set
            {
                Row[c_champAutoUpdateIpOnTimosDatabase] = value;
            }
        }

        //---------------------------------------
        /// <summary>
        /// Pour que le handler se déclenche, la formule de déclenchement
        /// doit retourner true, à mois qu'elle ne soit vide
        /// </summary>
        [MemoryField(c_champFormuleConditionApplication)]
        public C2iExpression FormuleDeclenchement
        {
            get
            {
                C2iExpression formule = Row.Get<C2iExpression>(c_champFormuleConditionApplication);
                if (formule == null)
                    formule = new C2iExpressionVrai();
                return formule;
            }
            set
            {
                Row[c_champFormuleConditionApplication] = value;
            }
        }

        //------------------------------------------------------------
        private CDefinitionProprieteDynamiqueVariableFormule AssureVariableTrap(C2iExpressionGraphique formule)
        {
            if (formule == null)
                return null;
            CDefinitionProprieteDynamiqueVariableFormule def = formule.Variables.FirstOrDefault(v => v.Nom == c_strNomVariableTrap);
            if (def == null)
            {
                def = new CDefinitionProprieteDynamiqueVariableFormule("Trap",
                        new CTypeResultatExpression(typeof(CTrapInstance), false), true);
                formule.AddVariable(def);
            }
            return def;
        }

        

        //---------------------------------------
        public static CAgentFinderFromKey CreateFromMib(
            IObjectTree tree, 
            IDefinition defNotification,
            CMemoryDb db)
        {
            NotificationType notification = defNotification.Entity as NotificationType;
            if (notification != null)
            {
                CAgentFinderFromKey handler = new CAgentFinderFromKey(db);
                handler.CreateNew();
                handler.Libelle = defNotification.Name;
                handler.Description = defNotification.Description;
                foreach (string strObjet in notification.Objects)
                {
                    CTrapField field = new CTrapField();
                    field.Name = strObjet;
                    IDefinition def = tree.Find(strObjet);
                    if (def != null)
                    {
                        field.OID = ObjectIdentifier.Convert(def.GetNumericalForm());
                        handler.AddFieldFromTrap(field);
                    }
                }
                handler.GenericRequestedValue = GenericCode.EnterpriseSpecific;
                handler.EntrepriseRequestedValue = ObjectIdentifier.Convert(defNotification.GetNumericalForm());
                if (handler.EntrepriseRequestedValue.EndsWith("." + notification.Value.ToString()))
                    handler.EntrepriseRequestedValue = handler.EntrepriseRequestedValue.Remove(handler.EntrepriseRequestedValue.Length - notification.Value.ToString().Length - 1);
                handler.SpecificRequestedValue = notification.Value.ToString();
                return handler;
            }
            TrapType trap = defNotification.Entity as TrapType;
            if (trap != null)
            {
                CAgentFinderFromKey handler = new CAgentFinderFromKey(db);
                handler.CreateNew();
                handler.Libelle = trap.Name;
                handler.Description = trap.Description;
                foreach (string strObjet in trap.Variables)
                {
                    CTrapField field = new CTrapField();
                    field.Name = strObjet;
                    IDefinition def = tree.Find(strObjet);
                    if (def != null)
                    {
                        field.OID = ObjectIdentifier.Convert(def.GetNumericalForm());
                        handler.AddFieldFromTrap(field);
                    }
                }
                handler.GenericRequestedValue = GenericCode.EnterpriseSpecific;
                handler.EntrepriseRequestedValue = ObjectIdentifier.Convert(defNotification.GetNumericalForm());
                if (handler.EntrepriseRequestedValue.EndsWith("." + trap.Value.ToString()))
                    handler.EntrepriseRequestedValue = handler.EntrepriseRequestedValue.Remove(handler.EntrepriseRequestedValue.Length - trap.Value.ToString().Length - 1);
                handler.SpecificRequestedValue = trap.Value.ToString();
                return handler;
            }
            return null;
        }

        

        //------------------------------------------------------------------
        public CDefinitionProprieteDynamique[] GetDefinitionsChamps(CObjetPourSousProprietes objet, CDefinitionProprieteDynamique defParente)
        {
            List<CDefinitionProprieteDynamique> lstDefs = new List<CDefinitionProprieteDynamique>();
            lstDefs.AddRange(new CFournisseurGeneriqueProprietesDynamiques().GetDefinitionsChamps(objet));
            if (objet.TypeAnalyse != null && objet.TypeAnalyse == typeof(CTrapInstance))
            {
                foreach (CTrapField field in FieldsFromTrap)
                    lstDefs.Add(new CDefinitionProprieteDynamiqueTrapField(field));
                foreach (CTrapFieldSupplementaire field in FieldsSupplementaires)
                    lstDefs.Add(new CDefinitionProprieteDynamiqueTrapFieldSupplementaire(field));
                lstDefs.Add(new CDefinitionProprieteDynamiqueInterrogateurSnmp(InterrogateurSNMP));
            }
            if (objet.TypeAnalyse != null && objet.TypeAnalyse == typeof(CAgentSnmpPourSupervision))
            {
                //Ajoute les requêtes
                foreach (IRunnableEasyQuery query in TypeAgent.Queries)
                {
                    CDefinitionProprieteDynamiqueRunnableEasyQuery def = new CDefinitionProprieteDynamiqueRunnableEasyQuery(query);
                    def.Rubrique = "Queries";
                    lstDefs.Add(def);
                }

                //Ajoute les listes de types d'entités
                foreach (CTypeEntiteSnmpPourSupervision typeEntite in TypeAgent.TypesEntites)
                {
                    CDefinitionProprieteDynamiqueListeEntitesSnmp def = new CDefinitionProprieteDynamiqueListeEntitesSnmp(typeEntite);
                    def.Rubrique = "Entities";
                    lstDefs.Add(def);
                }

            }
            if (objet.TypeAnalyse == typeof(CEntiteSnmpPourSupervision) )
            {
                if (defParente is CDefinitionProprieteDynamiqueListeEntitesSnmp)
                {
                    CDefinitionProprieteDynamiqueListeEntitesSnmp defListe = defParente as CDefinitionProprieteDynamiqueListeEntitesSnmp;
                    CTypeEntiteSnmpPourSupervision typeEntite = new CTypeEntiteSnmpPourSupervision(Database);
                    if (typeEntite.ReadIfExist(defListe.NomProprieteSansCleTypeChamp))
                    {
                        foreach (IChampEntiteSNMP champ in typeEntite.Champs)
                            lstDefs.Add(new CDefinitionProprieteDynamiqueChampEntiteSnmp(champ));
                    }
                }
                else
                {
                    foreach ( IChampEntiteSNMP champ in TypeAgent.TousLesChampsSNMPDefinis )
                        lstDefs.Add ( new CDefinitionProprieteDynamiqueChampEntiteSnmp ( champ ));
                }

            }
            return lstDefs.ToArray();
        }

        //------------------------------------------------------------------
        public CDefinitionProprieteDynamique[] GetDefinitionsChamps(CObjetPourSousProprietes objet)
        {
            return GetDefinitionsChamps(objet, null);
        }

        //------------------------------------------------------------------
        public CDefinitionProprieteDynamique[] GetDefinitionsChamps(Type typeInterroge, int nNbNiveaux, CDefinitionProprieteDynamique defParente)
        {
            return GetDefinitionsChamps(typeInterroge);
        }

        //------------------------------------------------------------------
        public CDefinitionProprieteDynamique[] GetDefinitionsChamps(Type typeInterroge, int nNbNiveaux)
        {
            return GetDefinitionsChamps(typeInterroge);
        }

        //------------------------------------------------------------------
        public CAgentSnmpPourSupervision[] GetAgentsFromKey(CTrapInstance trap)
        {
            CListeEntitesDeMemoryDb<CAgentSnmpPourSupervision> lstAgents =
                new CListeEntitesDeMemoryDb<CAgentSnmpPourSupervision>(Database);

            if(FormuleCleSpecifique != null)
            {
                CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(trap);
                CResultAErreur result = FormuleCleSpecifique.Eval(ctx);
                if (result && result.Data != null && result.Data is string)
                {
                    lstAgents.Filtre = new CFiltreMemoryDb(
                        CAgentSnmpPourSupervision.c_champTrapsIp + " like @1",
                        "%,"+(string)result.Data+",%");

                    return lstAgents.ToArray();
                }
            }

            return new CAgentSnmpPourSupervision[] { };
        }
 
        //----------------------------------------------------
        public CResultAErreur VerifieDonnees()
        {
            CResultAErreur result = CResultAErreur.True;
            if ( Libelle.Length == 0 )
                result.EmpileErreur(I.T("Enter a label form alarm event|20005"));
            if (FormuleDeclenchement == null || FormuleDeclenchement.TypeDonnee.TypeDotNetNatif != typeof(bool) ||
                FormuleDeclenchement.TypeDonnee.IsArrayOfTypeNatif)
                result.EmpileErreur(I.T("Invalid condition formula (should return a boolean value)|20006"));
            
            return result;
        }

        
        //----------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //----------------------------------------------------
        protected override CResultAErreur MySerialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = SerializeChamps(serializer,
                c_champLibelle,
                c_champDescription,
                c_champFieldsFromTrap,
                c_champFieldsSupplementaires,
                c_champEntrepriseValue,
                c_champSpecificValue,
                c_champCommunityValue,
                c_champGenericCode,
                c_champFormuleConditionApplication,
                c_champFormuleCleSpecifique,
                c_champAutoUpdateIpOnMediationServices,
                c_champAutoUpdateIpOnTimosDatabase);

            if (result)
                result = SerializeParent<CTypeAgentPourSupervision>(serializer);

            return result;
        }

        //------------------------------------------------------------------
        public bool ShouldApply(CTrapInstance message)
        {
            if (CommunityRequestedValue != null && CommunityRequestedValue.Length > 0 && message.Community != null && message.Community.Length > 0)
            {
                CSimpleMatch match = CSimpleMatch.FromString(CommunityRequestedValue);
                if (!match.Match(message.Community))
                    return false;
            }
            if (GenericRequestedValue != null)
            {
                if (GenericRequestedValue.Value == GenericCode.EnterpriseSpecific)
                {
                    if (EntrepriseRequestedValue.Length > 0 && message.Entreprise != null)
                    {
                        CSimpleMatch match = CSimpleMatch.FromString(EntrepriseRequestedValue);
                        if (!match.Match(message.Entreprise))
                            return false;
                    }
                    if (SpecificRequestedValue.Length > 0)
                    {
                        CSimpleMatch match = CSimpleMatch.FromString(SpecificRequestedValue);
                        if (!match.Match(message.SpecificValue.ToString()))
                            return false;
                    }
                }
                else //Code générique
                {
                    if (GenericRequestedValue.Value != message.GenericCode)
                        return false;
                }
            }


            if (FormuleDeclenchement != null && !(FormuleDeclenchement is C2iExpressionVrai))
            {
                CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(message);
                CResultAErreur result = FormuleDeclenchement.Eval(ctx);
                if (!result || !(result.Data is bool) || !(bool)result.Data)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Retourne true si une clé de l'agent correspond au finder
        /// </summary>
        /// <param name="agent"></param>
        /// <returns></returns>
        public bool MatchAgent(CTrapInstance trap, CAgentSnmpPourSupervision agent)
        {
            if ( FormuleCleSpecifique != null )
            {
                CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(trap);
                CResultAErreur result = FormuleCleSpecifique.Eval(ctx);
                if (!result || result.Data == null)
                    return false;
                if (agent.TrapsIpString.Contains("," + result.Data.ToString() + ","))
                    return true;
            }
            return false;            
        }
    }
}
