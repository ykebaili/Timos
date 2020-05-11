using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace timos.data.snmp
{
    public enum EModeFormulairePourTypeEntite
    {
        UnFormulaireParEntite = 0,
        FormulaireSurAgent,
        AucunFormulaire
    }
    public class CModeFormulairePourTypeEntite : CEnumALibelle<EModeFormulairePourTypeEntite>
    {
        public CModeFormulairePourTypeEntite(EModeFormulairePourTypeEntite mode)
            : base(mode)
        {
        }


        public override string Libelle
        {
            get
            {
                switch (Code)
                {
                    case EModeFormulairePourTypeEntite.UnFormulaireParEntite:
                        return I.T("One form for each entity|20097");

                    case EModeFormulairePourTypeEntite.FormulaireSurAgent:
                        return I.T("Form on Agent|20098");
                    case EModeFormulairePourTypeEntite.AucunFormulaire:
                        return I.T("No form|20247");

                }
                return "";
            }
        }
    }
}
