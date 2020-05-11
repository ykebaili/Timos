using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;

namespace spv.data
{
    public enum ESensLiaison
    {
        AVersB = 0,
        BVersA = 1,
        Bidirectionnelle = 2
    }

    public class CSensLiaison : CEnumALibelle<ESensLiaison>
    {
        public CSensLiaison(ESensLiaison sensLiaison)
			: base(sensLiaison)
		{
		}

        public override string Libelle
        {
            get
            {
                switch (Code)
                {
                    case ESensLiaison.AVersB:
                        return I.T("Tip A -> Tip B|50003");
                    case ESensLiaison.BVersA:
                        return I.T("Tip B -> Tip A|50004");
                    case ESensLiaison.Bidirectionnelle:
                        return I.T("Bidirectional|50005");
                    default:
                        break;
                }
                return "";
            }
        }
    }
}
