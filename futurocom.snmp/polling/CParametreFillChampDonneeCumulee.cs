using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.DonneeCumulee;
using sc2i.expression;
using sc2i.common;

namespace futurocom.snmp.polling
{
    [Serializable]
    public class CParametreFillChampDonneeCumulee : I2iSerializable
    {
        private CChampDonneeCumulee m_champ = null;
        private C2iExpression m_formuleSource = null;

        //---------------------------------------------
        public CParametreFillChampDonneeCumulee()
        {
        }

        //---------------------------------------------
        public CChampDonneeCumulee Champ
        {
            get
            {
                return m_champ;
            }
            set
            {
                m_champ = value;
            }
        }

        //---------------------------------------------
        public C2iExpression FormuleSource
        {
            get
            {
                return m_formuleSource;
            }
            set
            {
                m_formuleSource = value;
            }
        }

        //---------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //---------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
            if ( !result )
                return result;
            result = serializer.TraiteObject<CChampDonneeCumulee>(ref m_champ);
            if ( result) 
                result = serializer.TraiteObject<C2iExpression>(ref m_formuleSource);
            return result;
        }
    }

    public class CListeParametresFillChampDonneeCumulee : List<CParametreFillChampDonneeCumulee>, I2iSerializable
    {

        //----------------------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        
        //----------------------------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteListe<CParametreFillChampDonneeCumulee>(this);
            return result;
        }
    }

}
