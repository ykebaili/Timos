using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace timos.data
{
    /// <summary>
    /// Utilisé lors du décodage d'une coordonnée, contient
    /// le détail d'un niveau
    /// </summary>
    public class CNiveauCoordonnee
    {
        /// <summary>
        /// coordonnée brute
        /// </summary>
        private string m_strCoordonneeNiveau = "";

        /// <summary>
        /// Préfixe
        /// </summary>
        private string m_strPrefixe = "";

        /// <summary>
        /// Index du niveau
        /// </summary>
        private int m_nIndex = 0;

        public CNiveauCoordonnee(string strCoordonneeNiveau, string strPrefixe, int nIndex)
        {
            m_strCoordonneeNiveau = strCoordonneeNiveau;
            m_strPrefixe = strPrefixe;
            m_nIndex = nIndex;
        }

        public string CoordonneeNiveau
        {
            get
            {
                return m_strCoordonneeNiveau;
            }
        }

        public string Prefixe
        {
            get
            {
                return m_strPrefixe;
            }
        }

        public int Index
        {
            get
            {
                return m_nIndex;
            }
        }
    }
}
