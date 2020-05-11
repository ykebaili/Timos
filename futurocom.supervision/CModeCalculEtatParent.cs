using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace futurocom.supervision
{
    public enum EModeCalculEtatParent
    {
        AllChildsClosed = 0,
        OneChildClosed,
        Manual
    }

    [Serializable]
    public class CModeCalculEtatParent : CEnumALibelle<EModeCalculEtatParent>
    {
        public CModeCalculEtatParent(EModeCalculEtatParent code)
            : base(code)
        {
        }

        public override string Libelle
        {
            get {
                switch (Code)
                {
                    case EModeCalculEtatParent.AllChildsClosed:
                        return I.T("Close when all childs are closed|20006");
                        break;
                    case EModeCalculEtatParent.OneChildClosed:
                        return I.T("Close when one childs are closed|20007");
                        break;
                    case EModeCalculEtatParent.Manual:
                        return I.T("Manual|20008");
                        break;
                    default:
                        break;
                }
                return "";
            }
            
        }
    }
}
