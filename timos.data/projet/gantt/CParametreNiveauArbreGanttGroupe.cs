using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.expression;

namespace timos.data.projet.gantt
{
    public class CParametreNiveauArbreGanttGroupe : CParametreNiveauArbreGantt
    {
        private C2iExpression m_formuleGroupe = null;

        //-----------------------------------
        public CParametreNiveauArbreGanttGroupe()
        {
        }

        //-----------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-----------------------------------
        public override CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = base.Serialize(serializer);
            if (!result)
                return result;
            result = serializer.TraiteObject<C2iExpression>(ref m_formuleGroupe);
            if (!result)
                return result;

            return result;
        }

        //-----------------------------------
        public C2iExpression FormuleGroupe
        {
            get
            {
                return m_formuleGroupe;
            }
            set
            {
                m_formuleGroupe = value;
            }
        }

        //-----------------------------------
        public override void RangeProjets(
            IEnumerable<CElementDeGanttProjet> lstEltsProjets, 
            CElementDeGantt elementParent)
        {
            Dictionary<string, List<CElementDeGanttProjet>> lstCles = new Dictionary<string, List<CElementDeGanttProjet>>();
            foreach (CElementDeGanttProjet elt in lstEltsProjets)
            {
                CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(elt.ProjetAssocie);
                CResultAErreur result = FormuleGroupe.Eval(ctx);
                string strVal = "?";
                if (result && result.Data != null)
                    strVal = result.Data.ToString();
                List<CElementDeGanttProjet> lstElts = null;
                if (!lstCles.TryGetValue(strVal, out lstElts))
                {
                    lstElts = new List<CElementDeGanttProjet>();
                    lstCles[strVal] = lstElts;
                }
                lstElts.Add(elt);
            }
            foreach (KeyValuePair<string, List<CElementDeGanttProjet>> kv in lstCles)
            {
                CElementDeGanttGroupe groupe = new CElementDeGanttGroupe(elementParent, kv.Key);
                groupe.Image = Image;
                if (ParametreFils == null)
                {
                    foreach (CElementDeGanttProjet elt in kv.Value)
                        elt.ElementParent = groupe;
                }
                else
                    ParametreFils.RangeProjets(kv.Value, groupe);
            }
        }


    }
}
