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
    //Définition d'un évenement qui va déclencher des convertisseurs de traps
    [MemoryTable ( CTrapHandler.c_nomTable, CTrapHandler.c_champId)]
    public class CTrapHandler : CEntiteDeMemoryDbAIdAuto, IFournisseurProprietesDynamiques
    {
        private const string c_strNomVariableTrap = "Trap";

        public const string c_nomTable = "TRAP_HANDLER";
        public const string c_champId = "TRPH_ID";
        public const string c_champLibelle = "TRPH_LABEL";
        public const string c_champDescription = "TRPH_DESC";
        public const string c_champFieldsFromTrap = "TRPH_TRAP_FIELDS";
        public const string c_champFieldsSupplementaires = "TRPH_ADDED_FIELDS";
        public const string c_champEntrepriseValue = "TRPH_ENTREPRISE_VALUE";
        public const string c_champSpecificValue = "TRPH_SPECIFIC_VALUE";
        public const string c_champCommunityValue = "TRPH_COMMUNITY_VALUE";
        public const string c_champGenericCode = "TRPH_GENERIC_CODE";
        public const string c_champFormuleConditionApplication = "TRPH_APPLICATION_FORMULA";
        public const string c_champFormulePretraitementTrap = "TRPH_PRETREAT_FORMULA";
        public const string c_champFormuleIndexEntite = "TRPH_ENTITY_INDEX_FORMULA";


        //---------------------------------------
        public CTrapHandler(CMemoryDb db )
            :base ( db )
        {
        }

        //---------------------------------------
        public CTrapHandler(DataRow row)
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
        /// <summary>
        /// formule qui sera appliquée au trap et lancée 
        /// avant de trouver les convertisseurs à lancer
        /// </summary>
        [MemoryField(c_champFormulePretraitementTrap)]
        public C2iExpressionGraphique FormulePreTraitementTrap
        {
            get
            {
                C2iExpressionGraphique formule = Row.Get<C2iExpressionGraphique>(c_champFormulePretraitementTrap);
                if (formule == null)
                    formule = new C2iExpressionGraphique();
                AssureVariableTrap(formule);
                return formule;
            }
            set
            {
                Row[c_champFormulePretraitementTrap] = value;
            }
        }

        //---------------------------------------
        /// <summary>
        /// formule permettant de retrouver l'index de l'entité associée
        /// </summary>
        [MemoryField(c_champFormuleIndexEntite)]
        public C2iExpression FormuleIndexEntite
        {
            get
            {
                C2iExpression formule = Row.Get<C2iExpression>(c_champFormuleIndexEntite);
                return formule;
            }
            set
            {
                Row[c_champFormuleIndexEntite] = value;
            }
        }

        //---------------------------------------
        [MemoryParent(false)]
        public CTypeEntiteSnmpPourSupervision TypeEntiteAssocie
        {
            get
            {
                return GetParent<CTypeEntiteSnmpPourSupervision>();
            }
            set
            {
                SetParent<CTypeEntiteSnmpPourSupervision>(value);
            }
        }

        //---------------------------------------
        [MemoryChild]
        public CListeEntitesDeMemoryDb<CCreateurAlarme> CreateursAlarmes
        {
            get
            {
                return GetFils<CCreateurAlarme>();
            }
        }


        //---------------------------------------
        public static CTrapHandler CreateFromMib(
            IObjectTree tree, 
            IDefinition defNotification,
            CMemoryDb db)
        {
            NotificationType notification = defNotification.Entity as NotificationType;
            if (notification != null)
            {
                CTrapHandler handler = new CTrapHandler(db);
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
                CTrapHandler handler = new CTrapHandler(db);
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
        public bool ShouldDeclenche(CTrapInstance message)
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

        public void CreateAlarmesOnTrap( CTrapInstance trap, CFuturocomTrace trace)
        {
            trap.CurrentTrapHandler = this;
            CDefinitionProprieteDynamiqueVariableFormule def = AssureVariableTrap(FormulePreTraitementTrap);
            CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(TypeAgent);
            if (def != null)
                ctx.SetValeurVariable(def, trap);
            CResultAErreur result = CResultAErreur.True;
            trap.EntiteAssociee = null;
            if (FormuleIndexEntite != null && TypeEntiteAssocie != null)
            {
                CContexteEvaluationExpression ctxSurThis = new CContexteEvaluationExpression(trap);
                result = FormuleIndexEntite.Eval(ctxSurThis);
                if (result && result.Data != null)
                {
                    CListeEntitesDeMemoryDb<CEntiteSnmpPourSupervision> lst = trap.AgentSnmp.Entites;
                    lst.Filtre = new CFiltreMemoryDb(CEntiteSnmpPourSupervision.c_champIndex + "=@1 and " +
                        CTypeEntiteSnmpPourSupervision.c_champId + "=@2",
                        result.Data.ToString(),
                        TypeEntiteAssocie.Id);
                    if (lst.Count() > 0)
                    {
                        trap.EntiteAssociee = lst.ElementAt(0);
                        if (trace != null) trace.Write(
                          "Trap associated to entity " + trap.EntiteAssociee.Libelle + " (" + trap.EntiteAssociee.TypeEntite.Libelle + ")",
                          ALTRACE.DEBUG);
                    }
                    else
                    {
                        if (trace != null) trace.Write(
                          "Associated entity is null (" + TypeEntiteAssocie.Libelle + " " + result.Data.ToString() + ")",
                          ALTRACE.DEBUG);
                    }
                }
                else
                {
                    if (trace != null)
                    {
                        if (!result)
                            trace.Write(
                                "Error in associed entity index formula : " + result.Erreur.ToString(),
                                ALTRACE.DEBUG);
                        else
                            trace.Write(
                                "Error in associed entity index formula : the formula returned a null result",
                                ALTRACE.DEBUG);
                    }
                }
            }
            bool bEvalPretraite = true;
            if (FormulePreTraitementTrap is C2iExpressionGraphique &&
                FormulePreTraitementTrap.Parametres.Count == 0)
                bEvalPretraite = false;
            if (bEvalPretraite)
            {
                result = FormulePreTraitementTrap.Eval(ctx);
                if (!result && trace != null)
                {
                    trace.Write(
                        "Error in Pretreatment formula " + result.Erreur.ToString(),
                        ALTRACE.DEBUG);
                }
            }


            
            foreach ( CCreateurAlarme createur in CreateursAlarmes )
            {
                if (trace != null) trace.Write(
                 "Try creator " + createur.Libelle+" ("+createur.Code+")",
                 ALTRACE.DEBUG);
                bool bCreer = createur.FormuleCondition.GetType() == typeof(C2iExpressionVrai) ;
                if ( !bCreer )
                {
                    ctx = new CContexteEvaluationExpression ( trap );
                    result = createur.FormuleCondition.Eval ( ctx );
                    if ( result && result.Data is bool && (bool)result.Data )
                    {
                        bCreer = true;
                    }
                    else if (trace != null)
                    {
                        if (!result)
                            trace.Write(
                                "Creator " + createur.Libelle + " condition error : " + result.Erreur.ToString(),
                                ALTRACE.DEBUG);
                        else
                            trace.Write(
                                "Create " + createur.Libelle + " condition returned false",
                                ALTRACE.DEBUG);
                    }
                }
                if (bCreer)
                {
                    if (trace != null)
                        trace.Write(
                            "Creator " + createur.Libelle + " condition returned true",
                            ALTRACE.DEBUG);
                    trap.AddAlarm(createur.Code, 0, trace);
                }
            }
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
            int nIndex = 0;
            foreach ( CCreateurAlarme createur in CreateursAlarmes )
            {
                CResultAErreur resTmp = createur.VerifieDonnees();
                if ( !resTmp )
                {
                    result += resTmp;
                    result.EmpileErreur(I.T("Error in Alarm creator @1|20007", nIndex.ToString() ));
                }
            }
            return result;
        }

        //----------------------------------------------------
        public CCreateurAlarme GetCreateur ( string strCode )
        {
            strCode = strCode.ToUpper();
            return CreateursAlarmes.FirstOrDefault ( c=>c.Code == strCode );
        }

        //----------------------------------------------------
        private int GetNumVersion()
        {
            return 1;
            //1 : ajout de l'entité associée
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
                c_champFormulePretraitementTrap);
            if (result)
                result = SerializeParent<CTypeAgentPourSupervision>(serializer);
            if (result)
                result = SerializeChilds<CCreateurAlarme>(serializer);
            if ( nVersion >= 1 && result )
            {
                result = SerializeParent<CTypeEntiteSnmpPourSupervision>(serializer);
                if ( result )
                    result = SerializeChamps(serializer, c_champFormuleIndexEntite);
            }
            return result;
        }
    }
}
