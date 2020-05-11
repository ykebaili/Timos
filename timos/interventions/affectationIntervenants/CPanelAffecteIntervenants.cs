using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using timos.data;
using timos.acteurs;
using sc2i.win32.common;
using sc2i.common;

namespace timos.interventions
{
    public partial class CPanelAffecteIntervenants : UserControl, IControlALockEdition
    {
        private CTypeIntervention m_lastTypeInterventionInit = null;
        private CIntervention m_intervention;

        public CPanelAffecteIntervenants()
        {
            InitializeComponent();
        }

        public CIntervention Intervention
        {
            get
            {
                return m_intervention;
            }
        }

        public void Init(CIntervention intervention)
        {
            m_intervention = intervention;

            
            this.SuspendDrawing();
            
            List<CControleAffecteIntervenantsDeProfil> listeDispo = new List<CControleAffecteIntervenantsDeProfil>();
            foreach (Control ctrl in this.Controls)
                if (ctrl is CControleAffecteIntervenantsDeProfil)
                {
                    ctrl.Visible = false;
                    listeDispo.Add((CControleAffecteIntervenantsDeProfil)ctrl);
                }
            if (Intervention.TypeIntervention != null)
            {
                m_lastTypeInterventionInit = Intervention.TypeIntervention;
                foreach (CTypeIntervention_ProfilIntervenant relProfil in Intervention.TypeIntervention.RelationsProfilsIntervenants)
                {
                    CControleAffecteIntervenantsDeProfil ctrl = null;
                    if (listeDispo.Count > 0)
                    {
                        ctrl = listeDispo[0];
                        listeDispo.RemoveAt(0);
                    }
                    else
                    {
                        ctrl = new CControleAffecteIntervenantsDeProfil();
                        this.Controls.Add(ctrl);

                    }
                    ctrl.Visible = true;
                    ctrl.InitChamps(m_intervention, relProfil);
                    ctrl.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
                    ctrl.Dock = DockStyle.Top;
                    ctrl.BringToFront();
                }
            }
            this.ResumeDrawing();
        }

        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            foreach (Control ctrl in Controls)
            {
                CControleAffecteIntervenantsDeProfil ctrlA = ctrl as CControleAffecteIntervenantsDeProfil;
                if (ctrlA != null)
                {
                    result &= ctrlA.MajChamps();
                }
            }
            return result;
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

        private void CPanelAffecteIntervenants_Enter(object sender, EventArgs e)
        {
            
            if ( Intervention != null && 
                m_lastTypeInterventionInit != Intervention.TypeIntervention )
            {
                if (m_gestionnaireModeEdition.ModeEdition)
                    Intervention.RecalcProfilsIntervenantsInCurrentContext(false);
                Init ( Intervention );
                

            }


        }
    }
}
