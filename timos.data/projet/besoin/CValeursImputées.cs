using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using System.Data;
using sc2i.data;

namespace timos.data.projet.besoin
{
    /// <summary>
    /// Sert à se souvenir de ce qu'une source a imputé sur ses utilisateur ou ce qu'un utilisateur
    /// s'est vu imputé par ces sources
    /// </summary>
    [Serializable]
    public class CValeursImputées
    {
        private Dictionary<string, double> m_dicImputations = new Dictionary<string, double>();

        //--------------------------------------------------
        public CValeursImputées()
        {
        }

        //--------------------------------------------------
        private string GetKey(IElementACout element, bool bCoutReel)
        {
            string strType = element.GetType().Sc2iTypeId();

            string strIdUniversel = "";
            if ( element.Row.RowState == DataRowState.Deleted || element.Row.RowState == DataRowState.Detached )
                strIdUniversel = (string)element.Row[CObjetDonnee.c_champIdUniversel, DataRowVersion.Original];
            else
                strIdUniversel = element.IdUniversel;
            return strType+"|"+strIdUniversel + "|" + (bCoutReel ? "1" : "0");
        }

        //--------------------------------------------------
        public bool DecomposeKey(string strKey, out string strIdType, out string strIdUniversel, out bool bCoutReel)
        {
            string[] strVals = strKey.Split('|');
            if (strVals.Length == 3)
            {
                strIdType = strVals[0];
                strIdUniversel = strVals[1];
                bCoutReel = strVals[2] == "1";
                return true;
            }
            strIdType = "";
            strIdUniversel = "";
            bCoutReel = false;
            return false;
        }

        //--------------------------------------------------
        public void Reset ( bool bCoutReel )
        {
            Dictionary<string, double> dic = new Dictionary<string,double>();
            foreach ( KeyValuePair<string, double> old in m_dicImputations )
            {
                if ( bCoutReel && old.Key.EndsWith("0") ||
                    !bCoutReel && old.Key.EndsWith("1"))
                    dic[old.Key] = old.Value;
            }
            m_dicImputations = dic;
        }


        //--------------------------------------------------
        public CValeursImputées(string strStringSerialization)
        {
            string[] strChaines = strStringSerialization.Split('~');
            foreach (string strChaine in strChaines)
            {
                string[] strParts = strChaine.Split('#');
                if (strParts.Length == 2)
                {
                    string strIdUniversel = strParts[0];
                    double fVal = 0;
                    try
                    {
                        fVal = CUtilDouble.DoubleFromString(strParts[1]);
                    }
                    catch { }
                    m_dicImputations[strIdUniversel] = fVal;
                }
            }
        }

        //--------------------------------------------------
        public void SetImputation(IElementACout element, double fValeur, bool bCoutReel)
        {
            if ( element == null )
                return;
            string strKey = GetKey(element, bCoutReel);

            if (fValeur < 0.001 || element.Row.RowState == DataRowState.Deleted || element.Row.RowState == DataRowState.Detached)
            {
                if (m_dicImputations.ContainsKey(strKey))
                    m_dicImputations.Remove(strKey);
            }
            else
                m_dicImputations[strKey] = fValeur;
        }

        //--------------------------------------------------
        public double GetImputation(IElementACout element, bool bCoutReel)
        {
            if (element == null)
                return 0;
            string strKey = GetKey(element, bCoutReel);

            if (m_dicImputations.ContainsKey(strKey))
                return m_dicImputations[strKey];
            return 0;
        }

        //--------------------------------------------------
        public string GetStringSerialization()
        {
            StringBuilder bl = new StringBuilder();
            foreach (KeyValuePair<string, double> kv in m_dicImputations)
            {
                bl.Append(kv.Key);
                bl.Append('#');
                bl.Append(kv.Value);
                bl.Append("~");
            }
            return bl.ToString();
        }

        //--------------------------------------------------
        public IEnumerable<IElementACout> GetObjetsImputés ( CContexteDonnee contexteDonnee )
        {
            List<IElementACout> lst = new List<IElementACout>();
            foreach (KeyValuePair<string, double> kv in m_dicImputations)
            {
                string strIdType = "";
                string strIdUniversel = "";
                bool bCoutReel = false;
                if (DecomposeKey(kv.Key, out strIdType, out strIdUniversel, out bCoutReel))
                {
                    Type tp = CActivatorSurChaine.GetType(strIdType);
                    if (tp != null)
                    {
                        IElementACout element = Activator.CreateInstance(tp, new object[] { contexteDonnee }) as IElementACout;
                        if (element != null && element.ReadIfExistsUniversalId(strIdUniversel))
                            lst.Add(element);
                    }
                }
            }
            return lst.AsReadOnly();
        }

        internal bool ContainsElement(IElementACout element, bool bCoutReel)
        {
            string strKey = GetKey(element, bCoutReel);
            return m_dicImputations.ContainsKey(strKey);
        }
    }
}
