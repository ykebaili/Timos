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
    public class CSeparateurMenuItem : IMenuItem
    {
        C2iExpression m_formuleCondition = null;
        int m_nNumeroOrdre = 0;

        public CSeparateurMenuItem() :
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
            return 1;
        }

        //--------------------------------------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);

            result = serializer.TraiteObject<C2iExpression>(ref m_formuleCondition);
            if (!result)
                return result;

            if (nVersion >= 1)
                serializer.TraiteInt(ref m_nNumeroOrdre);

            return result;

        }



         public string Libelle
        {
            get
            {
                return I.T("Separator|20248");
            }
            set
            {
            }
        }
    }

}
