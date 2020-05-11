using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.custom;
using sc2i.common;
using sc2i.formulaire;
using sc2i.expression;

namespace sc2i.custom
{
    public class CLabelMenuItem : IMenuItem
    {
        string m_strLibelle = "";
        C2iExpression m_formuleCondition = null;
        C2iExpression m_formuleLibelle = null;
        int m_nNumeroOrdre = 0;

        public CLabelMenuItem() :
            base()
        { }

        public int NumeroOrdre
        {
            get
            {
                return m_nNumeroOrdre;
            }
            set
            {
                m_nNumeroOrdre = value;
            }
        }

        public C2iExpression FormuleLibelle
        {
            get
            {
                return m_formuleLibelle;
            }
            set
            {
                m_formuleLibelle = value;
            }
        }

        public string Libelle
        {
            get
            {
                if (m_formuleLibelle != null)
                    return m_formuleLibelle.GetString();
                return I.T("Not defined label|20249");
            }
            set { }
            
        }

        public C2iExpression FormuleCondition
        {
            get
            {
                return m_formuleCondition;
            }
            set
            {
                m_formuleCondition = value;
            }
        }


        private int GetNumVersion()
        {
            return 0;
        }

        //--------------------------------------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);

            serializer.TraiteString(ref m_strLibelle);
            if (!result)
                return result;
            result = serializer.TraiteObject<C2iExpression>(ref m_formuleCondition);
            if (!result)
                return result;
            result = serializer.TraiteObject<C2iExpression>(ref m_formuleLibelle);
            if (!result) 
                return result;
            
            serializer.TraiteInt(ref m_nNumeroOrdre);

            return result;

        }


    }

}
