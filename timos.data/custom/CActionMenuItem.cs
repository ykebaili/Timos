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
    public class CActionMenuItem : IMenuItem
    {
        string m_strLibelle = "";
        C2iExpression m_formuleLibelle = null;
        CActionSur2iLink m_action = null;
        C2iExpression m_formuleCondition = null;
        int m_nNumeroOrdre = 0;

        public CActionMenuItem() :
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


        private int GetNumVersion()
        {
            return 2;
            //Ajout de la formule de libellé
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

            if (nVersion >= 1)
                serializer.TraiteInt(ref m_nNumeroOrdre);

            if (nVersion >= 2)
                result = serializer.TraiteObject<C2iExpression>(ref m_formuleLibelle);
            if (!result)
                return result;

            return result;

        }


    }

}
