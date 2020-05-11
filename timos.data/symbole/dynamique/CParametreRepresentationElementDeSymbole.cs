using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.expression;
using sc2i.common;
using System.Drawing;
using sc2i.drawing;
using System.Reflection;

namespace timos.data.symbole
{
    /// <summary>
    /// Paramètre pour modifier dynamiquement un élément dans un symbole
    /// </summary>
    public class CParametreRepresentationElementDeSymbole : I2iSerializable
    {
        //Nom de la propriete->Formule de calcul
        private Dictionary<string, C2iExpression> m_dicFormulesParPropriete = new Dictionary<string, C2iExpression>();
        private string m_strElementName = "";

        public CParametreRepresentationElementDeSymbole()
        {
        }

        public CParametreRepresentationElementDeSymbole(string strElementName)
        {
            m_strElementName = strElementName;
        }

        public string ElementName
        {
            get{
                return m_strElementName;
            }
            set{
                m_strElementName = value;
            }
        }

        public C2iExpression this[string strPropriete]
        {
            get{
                C2iExpression retour = null;
                m_dicFormulesParPropriete.TryGetValue ( strPropriete, out retour );
                return retour;
            }
            set
            {
                if ( value == null && m_dicFormulesParPropriete.ContainsKey ( strPropriete ) )
                    m_dicFormulesParPropriete.Remove ( strPropriete );
                else
                    m_dicFormulesParPropriete[strPropriete] = value;
            }
        }

        private int GetNumVersion()
        {
            return 0;
        }

        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
            if ( !result )
                return result;
            serializer.TraiteString ( ref m_strElementName );
            
            int nNbKeys = m_dicFormulesParPropriete.Count();
            serializer.TraiteInt(ref nNbKeys);
            switch (serializer.Mode)
            {
                case ModeSerialisation.Ecriture:
                    foreach (KeyValuePair<string, C2iExpression> kv in m_dicFormulesParPropriete)
                    {
                        string strTmp = kv.Key;
                        C2iExpression formule = kv.Value;
                        serializer.TraiteString(ref strTmp);
                        result = serializer.TraiteObject<C2iExpression>(ref formule);
                        if (!result)
                            return result;
                    }
                    break;
                case ModeSerialisation.Lecture:
                    Dictionary<string, C2iExpression> dic = new Dictionary<string, C2iExpression>();
                    for (int nFormule = 0; nFormule < nNbKeys; nFormule++)
                    {
                        string strTmp = "";
                        C2iExpression formule = null;
                        serializer.TraiteString(ref strTmp);
                        result = serializer.TraiteObject<C2iExpression>(ref formule);
                        if (formule != null)
                            dic[strTmp] = formule;
                    }
                    m_dicFormulesParPropriete = dic;
                    break;
            }

            return result;
        }

        ///Applique le paramètre à un élément
        public void ApplyOnElement(C2iSymbole element, CContexteEvaluationExpression ctxEval)
        {
            foreach (KeyValuePair<string, C2iExpression> kv in m_dicFormulesParPropriete)
            {
                string strPropriete = kv.Key;
                C2iExpression formule = kv.Value;
                if (formule != null)
                {
                    //Trouve la propriete
                    PropertyInfo info = element.GetType().GetProperty(strPropriete);
                    if (info != null && info.GetSetMethod() != null)
                    {
                        MethodInfo methode = info.GetSetMethod();
                        CResultAErreur result = formule.Eval(ctxEval);
                        if (result)
                        {
                            try
                            {
                                methode.Invoke(element, new object[]{result.Data});
                            }
                            catch
                            {
                            }
                        }
                    }
                }
            }
        }
    }
}
