using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace timos.client.licence
{

   
    [Serializable]
    public class CNombreUtilisePourTypeLicence
    {
        private string m_strIdType;
        private int m_nNombreUtilise;


        public CNombreUtilisePourTypeLicence()
        {
        }

        public CNombreUtilisePourTypeLicence(string strIdType, int nNombreRestant)
        {
            m_strIdType = strIdType;
            m_nNombreUtilise = nNombreRestant;
        }

        public string IdType
        {
            get { return m_strIdType; }
            set { m_strIdType = value; }
        }
        public int NombreUtilise
        {
            get { return m_nNombreUtilise; }
            set { m_nNombreUtilise = value; }
        }
    }
}
