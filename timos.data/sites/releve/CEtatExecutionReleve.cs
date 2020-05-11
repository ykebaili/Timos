using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace timos.data.sites.releve
{
    public enum EEtatExecutionReleve
    {
        NonEvalué = 0,//L'état d'execution du relevé n'a pas encore été évalué
        AValider = 10,
        AExecuter = 20,//Il faut executer ce relevé
        Execute = 30,//Tout a été fait
        Annule = 40//On n'executera jamais ce relevé
    };
    
    public class CEtatExecutionReleve : CEnumALibelle<EEtatExecutionReleve>
    {
        public CEtatExecutionReleve(EEtatExecutionReleve code)
            : base(code)
        {
        }

        [DynamicField("Label")]
        public override string Libelle
        {
            get
            {
                switch (Code)
                {
                    case EEtatExecutionReleve.NonEvalué:
                        return I.T("None|20225");
                    case EEtatExecutionReleve.AValider :
                        return I.T("To validate|20229");
                    case EEtatExecutionReleve.AExecuter:
                        return I.T("Validated|20226");
                    case EEtatExecutionReleve.Execute:
                        return I.T("Applied|20227");
                    case EEtatExecutionReleve.Annule:
                        return I.T("Cancelled|20228");
                }
                return "";
            }
        }
    }
}
