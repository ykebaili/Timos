using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace timos.data.projet.Contraintes
{
    /// <summary>
    /// Représente une IContrainteDeProjet induite par Un Lien de projet
    /// Un lien de projet induit deux contraintes
    /// </summary>
    public class CContrainteDeProjetInduite : IContrainteDeProjet
    {
        private DateTime m_date;
        private CModeContrainteDeGantt m_mode;
        private string m_strCle = "";
        private string m_strCommentaire = "";

        public CContrainteDeProjetInduite(DateTime date, CModeContrainteDeGantt mode)
        {
            m_date = date;
            m_mode = mode;
        }

        #region IContrainteDeGantt Membres

        public DateTime Date
        {
            get
            {
                return m_date;
            }
            set
            {
                m_date = value;
            }
        }

        public CModeContrainteDeGantt Mode
        {
            get
            {
                return m_mode;
            }
            set
            {
                m_mode = value;
            }
        }

        public bool ContraintePropre
        {
            get 
            {
                return false; 
            }
        }

         public string Cle
        {
            get
            {
                return m_strCle;
            }
            set
            {
                m_strCle = value;
            }
        }

        public string Commentaire
        {
            get
            {
                return m_strCommentaire;
            }
            set
            {
                m_strCommentaire = value;
            }
        }

        #endregion
    }
}
