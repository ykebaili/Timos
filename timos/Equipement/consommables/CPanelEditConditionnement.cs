using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using timos.data.equipement.consommables;
using sc2i.common;

namespace timos.Equipement.consommables
{
    public partial class CPanelEditConditionnement : UserControl, IControlALockEdition
    {
        CTypeConsommable m_typeConso;
        
        public CPanelEditConditionnement()
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

        public void Init(CTypeConsommable typeConsommable)
        {
            if (typeConsommable == null)
                return;
            m_typeConso = typeConsommable;

            m_panelControles.ClearAndDisposeControls();
            foreach (CConditionnementConsommable pack in m_typeConso.Conditionnements)
            {
                AjouterControle(pack);
            }
        }

        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;

            foreach (Control ctrl in m_panelControles.Controls)
            {
                CControleEditConditionnement ctrlConditionnement = ctrl as CControleEditConditionnement;
                if (ctrlConditionnement != null)
                    result += ctrlConditionnement.MajChamps();
            }

            return result;
        }


        private void m_lnkAjouter_LinkClicked(object sender, EventArgs e)
        {
            if (m_typeConso != null)
            {
                CConditionnementConsommable nouveuPack = new CConditionnementConsommable(m_typeConso.ContexteDonnee);
                nouveuPack.CreateNewInCurrentContexte();
                nouveuPack.TypeConsommable = m_typeConso;
                AjouterControle(nouveuPack);
            }
        }

        private void AjouterControle(CConditionnementConsommable pack)
        {
            CControleEditConditionnement newControl = new CControleEditConditionnement();
            newControl.Init(pack);
            newControl.Dock = DockStyle.Top;
            newControl.OnDeleteConditionnement += new EventHandler(newControl_OnDeleteConditionnement);
            m_panelControles.Controls.Add(newControl);
            newControl.BringToFront();
            newControl.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
        }

        void newControl_OnDeleteConditionnement(object sender, EventArgs e)
        {
            CControleEditConditionnement ctrlconditionnement = sender as CControleEditConditionnement;
            if (ctrlconditionnement != null)
            {
                CConditionnementConsommable pack = ctrlconditionnement.Conditionnement;
                if (pack != null)
                {
                    if (CFormAlerte.Afficher(I.T("Delete Consumabel Packaging @1 ?|10390", pack.Reference), EFormAlerteBoutons.OuiNon, EFormAlerteType.Question) == DialogResult.Yes)
                    {
                        pack.Delete();
                        m_panelControles.Controls.Remove(ctrlconditionnement);
                        ctrlconditionnement.Dispose();
                        ctrlconditionnement = null;
                    }
                }
            }
        }
    }
}
