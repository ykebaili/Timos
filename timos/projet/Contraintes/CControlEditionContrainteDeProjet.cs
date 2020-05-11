using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using sc2i.common;
using sc2i.expression;
using sc2i.data.dynamic;
using sc2i.win32.common;

using timos.data;
using timos.data.projet.gantt;
using timos.data.projet.gantt.icones;
using timos.data.projet.Contraintes;

namespace timos.projet.Contraintes
{
    public partial class CControlEditionContrainteDeProjet : UserControl, IControlALockEdition
    {
        private IContrainteDeProjet m_contrainte;

        public CControlEditionContrainteDeProjet()
        {
            InitializeComponent();
        }

        public IContrainteDeProjet Contrainte
        {
            get
            {
                return m_contrainte;
            }
        }

        //-------------------------------------------------------------------------
        public void Init(IContrainteDeProjet contrainte)
        {
            m_contrainte = contrainte;

            m_selectModeContrainte.Fill(
                CUtilSurEnum.GetEnumsALibelle(typeof(CModeContrainteDeGantt)),
                "Libelle",
                false);

            if (contrainte != null)
            {
                m_selectModeContrainte.SelectedValue = contrainte.Mode;
                m_dtContrainte.Value = contrainte.Date;
                m_txtCommentaire.Text = contrainte.Commentaire;
            }
        }

        //-------------------------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;

            if (m_contrainte != null)
            {
                m_contrainte.Mode = m_selectModeContrainte.SelectedValue as CModeContrainteDeGantt;
                m_contrainte.Date = m_dtContrainte.Value;
                m_contrainte.Commentaire = m_txtCommentaire.Text;

            }

            return result;
        }
        

        #region IControlALockEdition Membres

        public bool LockEdition
        {
            get
            {
                return !m_extModeEdition.ModeEdition;
            }
            set
            {
                m_extModeEdition.ModeEdition = !value;
                if (OnChangeLockEdition != null)
                    OnChangeLockEdition(this, new EventArgs());
            }
        }

        public event EventHandler OnChangeLockEdition;

        #endregion

        //---------------------------------------------------------------------
        public event EventHandler DeleteContrainteEventHandler;
        private void m_lnkDelete_LinkClicked(object sender, EventArgs e)
        {
            if (DeleteContrainteEventHandler != null)
                DeleteContrainteEventHandler(this, new EventArgs());
        }
    }
}
