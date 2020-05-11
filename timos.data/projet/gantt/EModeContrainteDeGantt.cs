using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using sc2i.common;

namespace timos.data.projet.Contraintes
{
    [Flags]
    public enum EModeContrainteDeGantt
	{
        DebutAuPlusTot = 1,
        DebutAuPlusTard = 2,
        FinAuPlusTot = 4,
        FinAuPlusTard = 8
	}


    public class CModeContrainteDeGantt : CEnumALibelle<EModeContrainteDeGantt>
    {
        public CModeContrainteDeGantt(EModeContrainteDeGantt modeConrainte)
            :base (modeConrainte)
        {

        }

        //------------------------------------------------------------------
        [DynamicField("Label")]
        public override string Libelle
        {
            get 
            {
                string strRetour = "";
                switch (Code)
                {
                    case EModeContrainteDeGantt.DebutAuPlusTot:
                        strRetour = I.T("Start at the earliest|10011");
                        break;
                    case EModeContrainteDeGantt.DebutAuPlusTard:
                        strRetour = I.T("Start at the lastest|10012");
                        break;
                    case EModeContrainteDeGantt.FinAuPlusTot:
                        strRetour = I.T("End at the earliest|10013");
                        break;
                    case EModeContrainteDeGantt.FinAuPlusTard:
                        strRetour = I.T("End at the latest|10014");
                        break;
                    default:
                        break;
                }

                return strRetour;
            }
        }
    }
}
