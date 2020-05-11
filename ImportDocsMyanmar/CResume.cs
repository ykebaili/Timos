using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImportDocsMyanmar
{
    public class CInfoProjet
    {
        public string CodeProjet="";
        public string Candidat = "";
        public CInfoProjet ( string strCodeProjet, string strCandidate )
        {
            CodeProjet = strCodeProjet;
            Candidat = strCandidate.Substring(strCandidate.Length-2,2);
        }

    }
    
    public class CResume
    {
        public Dictionary<string, List<CInfoProjet>> m_dicRepsToProjets = new Dictionary<string, List<CInfoProjet>>();

        public void Create ( CRepertoire repertoireRacine )
        {
            foreach ( CRepertoire repProjet in repertoireRacine.GetChilds<CRepertoire>())
            {
                foreach ( CRepertoire repCandidat in repProjet.GetChilds<CRepertoire>())
                {
                    CInfoProjet info = new CInfoProjet(repProjet.Nom, repCandidat.Nom);
                    foreach ( CRepertoire repDetail in repCandidat.GetChilds<CRepertoire>())
                        FillDic ( repDetail, info );
                }
            }
        }

        private void FillDic(CRepertoire repertoire, CInfoProjet infoEnCours)
        {
            if (repertoire.GetChilds<CFichier>().Count() > 0)
            {
                List<CInfoProjet> lst = null;
                if (!m_dicRepsToProjets.TryGetValue(repertoire.Nom.ToUpper(), out lst))
                {
                    lst = new List<CInfoProjet>();
                    m_dicRepsToProjets[repertoire.Nom.ToUpper()] = lst;
                }
                lst.Add(infoEnCours);
            }
            foreach (CRepertoire sub in repertoire.GetChilds<CRepertoire>())
                FillDic(sub, infoEnCours);
        }

        public string GetString()
        {
            List<KeyValuePair<string, List<CInfoProjet>>> lst = new List<KeyValuePair<string, List<CInfoProjet>>>();
            lst.AddRange(m_dicRepsToProjets);
            lst.Sort((x, y) => x.Key.CompareTo(y.Key));
            StringBuilder bl = new StringBuilder();
            foreach (KeyValuePair<string, List<CInfoProjet>> kv in lst)
            {
                bl.Append(kv.Key);
                bl.Append("\t");
                foreach (CInfoProjet info in kv.Value)
                {
                    bl.Append(info.CodeProjet);
                    bl.Append("_C");
                    bl.Append(info.Candidat);
                    bl.Append("\t");
                }
                bl.Remove(bl.Length - 1, 1);
                bl.Append(Environment.NewLine);
            }
            return bl.ToString();
        }
    }
}
