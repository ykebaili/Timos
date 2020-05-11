using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.expression;
using futurocom.supervision;
using sc2i.common.memorydb;
using System.Data;
using sc2i.common.trace;

namespace futurocom.snmp.alarme
{
    [MemoryTable(CCreateurAlarme.c_nomTable, CCreateurAlarme.c_champId)]
    public class CCreateurAlarme : CEntiteDeMemoryDbAIdAuto,IFournisseurProprietesDynamiques
    {
        private const string c_strNomVariableTrap = "Trap";
        private const string c_strNomVariableAlarme = "Alarm";

        public const string c_nomTable = "ALARM_CREATOR";
        public const string c_champId = "ALCR_ID";
        public const string c_champCode = "ALCR_CODE";
        public const string c_champLibelle = "ALCR_LABEL";
        public const string c_champFormuleCondition = "ALCR_CONDITION_FORMULA";
        public const string c_champFormuleAction = "ALCR_ACTION_FORMULA";

        //------------------------------------------------------------
        public CCreateurAlarme(CMemoryDb db)
            :base ( db )
        {
            
        }

        //------------------------------------------------------------
        public CCreateurAlarme(DataRow row)
            : base(row)
        {
        }

        //------------------------------------------------------------
        public override void MyInitValeursParDefaut()
        {
            Code = Guid.NewGuid().ToString();
        }

        //------------------------------------------------------------
        /// <summary>
        /// TrapHandler associé
        /// </summary>
        [MemoryParent(true)]
        public CTrapHandler TrapHandler
        {
            get
            {
                return GetParent<CTrapHandler>();
            }
            set
            {
                SetParent<CTrapHandler>(value);
            }
        }

        //------------------------------------------------------------
        [MemoryField(c_champCode)]
        public string Code
        {
            get
            {
                return Row.Get<string>(c_champCode);

           }
            set
            {
                Row[c_champCode] = value.ToUpper();
            }
        }

        //------------------------------------------------------------
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

        //------------------------------------------------------------
        /// <summary>
        /// Condition évaluée sur CTrapInstance pour voir s'il faut 
        /// lancer cette création
        /// </summary>
        [MemoryField(c_champFormuleCondition)]
        public C2iExpression FormuleCondition
        {
            get
            {
                C2iExpression formule = Row.Get<C2iExpression>(c_champFormuleCondition);
                if (formule == null)
                    formule = new C2iExpressionVrai();
                return formule;
            }
            set
            {
                Row[c_champFormuleCondition] = value;
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
                def = new CDefinitionProprieteDynamiqueVariableFormule(c_strNomVariableTrap,
                        new CTypeResultatExpression(typeof(CTrapInstance), false), true);
                formule.AddVariable(def);
            }
            return def;
        }

        //------------------------------------------------------------
        private CDefinitionProprieteDynamiqueVariableFormule AssureVariableAlarme(C2iExpressionGraphique formule)
        {
            if (formule == null)
                return null;
            CDefinitionProprieteDynamiqueVariableFormule def = formule.Variables.FirstOrDefault(v => v.Nom == c_strNomVariableAlarme);
            if (def == null)
            {
                def = new CDefinitionProprieteDynamiqueVariableFormule(c_strNomVariableAlarme,
                        new CTypeResultatExpression(typeof(CLocalAlarme), false), true);
                formule.AddVariable(def);
            }
            return def;
        }

        //------------------------------------------------------------
        /// <summary>
        /// Formule évaluée sur CTrapInstance, qui remplit les champs
        /// de l'alarme créée
        /// </summary>
        [MemoryField(c_champFormuleAction)]
        public C2iExpressionGraphique FormuleActions
        {
            get
            {
                C2iExpressionGraphique formule = Row.Get<C2iExpressionGraphique>(c_champFormuleAction);
                if (formule == null)
                    formule = new C2iExpressionGraphique();
                AssureVariableTrap(formule);
                AssureVariableAlarme(formule);

                return formule;
            }
            set
            {
                Row[c_champFormuleAction] = value;
            }
        }

        

        //------------------------------------------------------------------
        public CResultAErreur FillAlarm(CTrapInstance trap, CLocalAlarme alarme)
        {
            CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(TrapHandler.TypeAgent);
            CDefinitionProprieteDynamiqueVariableFormule def = AssureVariableTrap(FormuleActions);
            if (def != null)
                ctx.SetValeurVariable(def, trap);
            def = AssureVariableAlarme(FormuleActions);
            if (def != null)
                ctx.SetValeurVariable(def, alarme);

            CResultAErreur result = FormuleActions.Eval(ctx);
            
            if (!result)
                return result;

            return result;
        }

        //---------------------------------------
        [MemoryParent(false)]
        public CLocalTypeAlarme TypeAlarme
        {
            get
            {
                return GetParent<CLocalTypeAlarme>();
            }
            set
            {
                SetParent<CLocalTypeAlarme>(value);
            }
        }

        
        //------------------------------------------------------------------
        public CDefinitionProprieteDynamique[] GetDefinitionsChamps(CObjetPourSousProprietes objet, CDefinitionProprieteDynamique defParente)
        {
            List<CDefinitionProprieteDynamique> lstDefs = new List<CDefinitionProprieteDynamique>();
            if (TrapHandler != null)
                lstDefs.AddRange(TrapHandler.GetDefinitionsChamps(objet, defParente));

            if (objet.TypeAnalyse != null && objet.TypeAnalyse == typeof(CLocalAlarme) && TypeAlarme != null)
            {
                lstDefs.AddRange(TypeAlarme.GetDefinitionsChamps(objet, defParente));
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
        public CResultAErreur VerifieDonnees()
        {
            CResultAErreur result = CResultAErreur.True;
            if (TypeAlarme == null)
            {
                result.EmpileErreur(I.T("Created alarm type must be specified|20001"));
            }
            if (FormuleCondition == null || FormuleCondition.TypeDonnee.TypeDotNetNatif != typeof(bool) ||
                FormuleCondition.TypeDonnee.IsArrayOfTypeNatif)
            {
                result.EmpileErreur(I.T("Condition formula should return a bool value|20002"));
            }
            if (FormuleActions == null)
            {
                result.EmpileErreur(I.T("Invalid action formula|20003"));
            }
            return result;
        }

        //------------------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //------------------------------------------------------------------
        protected override CResultAErreur MySerialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = SerializeChamps(serializer, c_champCode,
                c_champLibelle,
                c_champFormuleCondition,
                c_champFormuleAction);
            if (result)
                result = SerializeParent<CTrapHandler>(serializer);
            if (result)
                result = SerializeParent<CLocalTypeAlarme>(serializer);
            return result;
        }
    }
}
