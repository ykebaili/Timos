using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data;
using System.Data;
using sc2i.common;
using timos.data.reseau.arbre_operationnel;

namespace spv.data
{
    public class CSpvElementDeGrapheOperateurOu : CSpvElementDeGraphe
    {
        //---------------------------------------------------
        public CSpvElementDeGrapheOperateurOu(CContexteDonnee ctx)
            : base(ctx)
        {
        }

        //---------------------------------------------------
        public CSpvElementDeGrapheOperateurOu(DataRow row)
            : base(row)
        {
        }

        //---------------------------------------------------
        protected override void MyInitValeurDefaut()
        {
            SetType(ETypeElementDeGrapheSpv.Ou);
        }

        //---------------------------------------------------
        public override CFiltreData FiltreStandard
        {
            get
            {
                return new CFiltreData(c_champType + "=@1",
                    (int)ETypeElementDeGrapheSpv.Ou);
            }
        }

        public override string GetStringDebugDescription()
        {
            return "OU";
        }

        
     }
}
