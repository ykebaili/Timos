using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data;
using System.Data;
using timos.data.reseau.arbre_operationnel;
using sc2i.common;

namespace spv.data
{
    public class CSpvElementDeGrapheOperateurEt : CSpvElementDeGraphe
    {
        //-----------------------------------------------------------
        public CSpvElementDeGrapheOperateurEt(CContexteDonnee ctx)
            : base(ctx)
        {
        }

        //-----------------------------------------------------------
        public CSpvElementDeGrapheOperateurEt(DataRow row)
            : base(row)
        {
        }

        //-----------------------------------------------------------
        protected override void MyInitValeurDefaut()
        {
            SetType(ETypeElementDeGrapheSpv.Et);
        }

        //-----------------------------------------------------------
        public override CFiltreData FiltreStandard
        {
            get
            {
                return new CFiltreData(c_champType + "=@1",
                    (int)ETypeElementDeGrapheSpv.Et);
            }
        }

        public override string  GetStringDebugDescription()
        {
            return "ET";
        }

       
    }
}
