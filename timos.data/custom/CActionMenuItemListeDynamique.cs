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
    public class CActionMenuItemListeDynamique : IMenuItem
    {
        string m_strLibelle = "";
        CActionSur2iLink m_action = null;
        C2iExpression m_formuleCondition = null;
        int m_nNumeroOrdre = 0;
        C2iExpression m_formuleListeSource = null;
        C2iExpression m_formuleItemLibelle = null;

        //----------------------------------------------------
        public CActionMenuItemListeDynamique() :
            base()
        { }


        //----------------------------------------------------
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

        //----------------------------------------------------
        public string Libelle
        {
            get
            {
                return m_strLibelle;
            }
            set
            {
                m_strLibelle = value;
            }
        }

        //----------------------------------------------------
        public CActionSur2iLink Action
        {
            get
            {
                return m_action;
            }
            set
            {
                m_action = value;
            }
        }

        //----------------------------------------------------
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

        //----------------------------------------------------
        public C2iExpression FormuleListeSource
        {
            get
            {
                return m_formuleListeSource;
            }
            set
            {
                m_formuleListeSource = value;
            }
        }

        //----------------------------------------------------
        public C2iExpression FormuleItemLibelle
        {
            get
            {
                return m_formuleItemLibelle;
            }
            set
            {
                m_formuleItemLibelle = value;
            }
        }
        //----------------------------------------------------
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
            result = serializer.TraiteObject<CActionSur2iLink>(ref m_action);
            if (!result)
                return result;
            result = serializer.TraiteObject<C2iExpression>(ref m_formuleCondition);
            if (!result)
                return result;

            serializer.TraiteInt(ref m_nNumeroOrdre);
            result = serializer.TraiteObject<C2iExpression>(ref m_formuleListeSource);
            if (result)
                result = serializer.TraiteObject<C2iExpression>(ref m_formuleItemLibelle);

            return result;

        }


    }

}
