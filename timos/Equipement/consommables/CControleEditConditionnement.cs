using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using sc2i.common;
using timos.data.equipement.consommables;
using sc2i.data;
using timos.acteurs;
using timos.data;

namespace timos.Equipement.consommables
{
    public partial class CControleEditConditionnement : UserControl, IControlALockEdition
    {
        CConditionnementConsommable m_conditionnement;
        public CControleEditConditionnement()
        {
            InitializeComponent();
        }

        #region IControlALockEdition Membres

        public bool LockEdition
        {
            get
            {
                return !m_gestionnaireModeEdition.ModeEdition;
            }
            set
            {
                m_gestionnaireModeEdition.ModeEdition = !value;
                if (OnChangeLockEdition != null)
                    OnChangeLockEdition(this, new EventArgs());
            }
        }

        public event EventHandler OnChangeLockEdition;

        #endregion

        public void Init(CConditionnementConsommable conditionnement)
        {
            if (conditionnement == null)
                return;
            m_conditionnement = conditionnement;

            m_txtReference.Text = conditionnement.Reference;
            m_numNombreUnite.IntValue = conditionnement.NombreUnites;
            m_lblDynamicUnit.Text = conditionnement.TypeConsommable.UniteString;

            CFiltreData filtre = new CFiltreDataAvance(
                                        CActeur.c_nomTable,
                                        "Has(" + CDonneesActeurFournisseur.c_nomTable + "." +
                                        CDonneesActeurFournisseur.c_champId + ")");

            m_selectFournisseur.InitAvecFiltreDeBase<CActeur>(
                "Nom",
                filtre,
                true);

            if (m_conditionnement.Fournisseur != null)
                m_selectFournisseur.ElementSelectionne = conditionnement.Fournisseur.Acteur;

        }

        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;

            if (m_conditionnement != null)
            {
                m_conditionnement.Reference = m_txtReference.Text;
                m_conditionnement.NombreUnites = m_numNombreUnite.IntValue != null ? m_numNombreUnite.IntValue.Value : 0;
                CActeur acteurFournisseur = m_selectFournisseur.ElementSelectionne as CActeur;
                if (acteurFournisseur != null)
                    m_conditionnement.Fournisseur = acteurFournisseur.Fournisseur;
                else
                    m_conditionnement.Fournisseur = null;
            }

            return result;
        }

        public CConditionnementConsommable Conditionnement
        {
            get
            {
                return m_conditionnement;
            }
        }

        public event EventHandler OnDeleteConditionnement;
        private void m_lnkSupprimer_LinkClicked(object sender, EventArgs e)
        {
            if (OnDeleteConditionnement != null)
                OnDeleteConditionnement(this, null);
        }

        private void CControleEditConditionnement_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
        }

    }
}
