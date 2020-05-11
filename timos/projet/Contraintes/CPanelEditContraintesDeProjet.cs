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
using sc2i.data.dynamic;
using sc2i.expression;

using timos.data;
using timos.data.projet.gantt;
using timos.data.projet.Contraintes;
using System.Collections;
using timos.projet.Contraintes;

namespace timos.projet.gantt
{
    public partial class CPanelEditContraintesDeProjet : UserControl, IControlALockEdition
    {

        CProjet m_projetEdite;

        public CPanelEditContraintesDeProjet()
        {
            InitializeComponent();
        }

        //--------------------------------------------------------------
        public void Init(CProjet projet)
        {
            m_projetEdite = projet;

            if (m_projetEdite != null)
            {
                // Supprime tous les controles du panel contraintes
                ArrayList lstToRemove = new ArrayList(m_panelContraintes.Controls);
                foreach (Control ctrl in lstToRemove)
                {
                    if (ctrl is CControlEditionContrainteDeProjet)
                    {
                        ctrl.Visible = false;
                        ctrl.Parent = null;
                        m_panelContraintes.Controls.Remove(ctrl);
                        ctrl.Dispose();
                    }
                }

                // Charge tous les parametres Icone
                foreach (IContrainteDeProjet contrainte in m_projetEdite.ContraintesPropres)
                {
                    AjouterControlContrainte(contrainte);
                }
            }
        }

        //--------------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;

            foreach (Control ctrl in m_panelContraintes.Controls)
            {
                CControlEditionContrainteDeProjet control = ctrl as CControlEditionContrainteDeProjet;
                if (control != null)
                {
                    control.MajChamps();
                }
            }

            return result;
        }
        
        //--------------------------------------------------------------
        private void m_lnkAjouter_LinkClicked(object sender, EventArgs e)
        {
            if (m_projetEdite != null)
            {
                CContrainteDeProjet nouvelleContrainte = new CContrainteDeProjet(m_projetEdite.ContexteDonnee);
                nouvelleContrainte.CreateNewInCurrentContexte();
                nouvelleContrainte.Projet = m_projetEdite;
                nouvelleContrainte.Date = m_projetEdite.DateDebutGantt;

                AjouterControlContrainte(nouvelleContrainte);
            }
        }

        //----------------------------------------------------------------------
        private void AjouterControlContrainte(IContrainteDeProjet contrainte)
        {

            CControlEditionContrainteDeProjet newControl = new CControlEditionContrainteDeProjet();            
            if (newControl != null)
            {
                ((Control)newControl).Dock = DockStyle.Top;
                newControl.DeleteContrainteEventHandler += new EventHandler(newControl_DeleteContrainteEventHandler);
                newControl.LockEdition = !m_extModeEdition.ModeEdition;
                newControl.Init(contrainte);
                CWin32Traducteur.Translate(newControl);
                m_panelContraintes.Controls.Add((Control)newControl);
                ((Control)newControl).BringToFront();
            }
        }

        void newControl_DeleteContrainteEventHandler(object sender, EventArgs e)
        {
            CControlEditionContrainteDeProjet controlASupprimer = sender as CControlEditionContrainteDeProjet;
            if (controlASupprimer != null)
            {
                // Supprime la contrainte
                CContrainteDeProjet contrainteASupprimer = controlASupprimer.Contrainte as CContrainteDeProjet;
                if (contrainteASupprimer != null)
                {
                    contrainteASupprimer.Delete();
                }
                // Supprime le control
                controlASupprimer.Visible = false;
                Control parent = controlASupprimer.Parent;
                controlASupprimer.Parent = null;
                parent.Controls.Remove(controlASupprimer);
                controlASupprimer.Dispose();
            }
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
    }
}
