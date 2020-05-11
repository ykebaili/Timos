using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace timos.data.projet
{
    [Flags]
    public enum EOptionLienProjetEtape
    {
        Standard = 0,
        NoIteration = 1,
        StepKeepDates = 2,
        ResetFlagOnEndStep = 4
    }

    public class COptionLienProjetEtape : CEnumALibelle<EOptionLienProjetEtape>
    {
        //-------------------------------------------------------------------
        public COptionLienProjetEtape(EOptionLienProjetEtape option)
            : base(option)
        {
        }

        //-------------------------------------------------------------------
        [DynamicField("Label")]
        public override string Libelle
        {
            get
            {
                StringBuilder bl = new StringBuilder();
                if ((Code & EOptionLienProjetEtape.NoIteration) == EOptionLienProjetEtape.NoIteration)
                    bl.Append(I.T("No automatic iteration|20241"));
                if ((Code & EOptionLienProjetEtape.StepKeepDates) == EOptionLienProjetEtape.StepKeepDates)
                {
                    if (bl.Length > 0)
                        bl.Append(", ");
                    bl.Append(I.T("Step keep original date|20242"));
                }
                if ((Code & EOptionLienProjetEtape.ResetFlagOnEndStep) == EOptionLienProjetEtape.ResetFlagOnEndStep)
                {
                    if (bl.Length > 0) bl.Append(", ");
                    bl.Append(I.T("Reset flag on step end|20243"));
                }
                if (Code == EOptionLienProjetEtape.Standard)
                    bl.Append(I.T("Standard|20240"));
                return bl.ToString();
            }
        }
    }
}
