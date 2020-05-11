using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using timos.data.projet.gantt;
using System.Collections;
using sc2i.win32.common;
using sc2i.common;
using sc2i.data.dynamic;
using timos.data;

namespace timos.projet.gantt
{
    public partial class CPanelEditGroupeGantt : UserControl, IControlALockEdition
    {
        private CParametreNiveauArbreGanttGroupe m_parametre = null;
        public CPanelEditGroupeGantt()
        {
            InitializeComponent();
        }

        public void Init(CParametreNiveauArbreGanttGroupe parametre)
        {
            m_txtFormule.Init(new CFournisseurPropDynStd(), typeof(CProjet));
            m_parametre = parametre;
            m_txtFormule.Formule = parametre.FormuleGroupe;
            m_imageSelect.Image = parametre.Image;
            UpdateChilds();
        }

        public CParametreNiveauArbreGanttGroupe Parametre
        {
            get
            {
                return m_parametre;
            }
        }

        private void UpdateChilds()
        {
            if (m_parametre.ParametreFils as CParametreNiveauArbreGanttGroupe == null)
            {
                m_panelAddChildLevel.Visible = true;
                m_panelChild.Visible = false;
            }
            else
            {
                m_panelAddChildLevel.Visible = false;
                m_panelChild.Visible = true;
                m_panelChild.SuspendDrawing();
                foreach (Control ctrl in new ArrayList(m_panelChild.Controls))
                {
                    m_extModeEdition.SetModeEdition(ctrl, TypeModeEdition.Autonome);
                    m_panelChild.Controls.Remove(ctrl);
                    ctrl.Visible = false;
                    ctrl.Dispose();
                }
                CPanelEditGroupeGantt newPanel = new CPanelEditGroupeGantt();
                newPanel.DeleteFilsEventHandler += new EventHandler(newPanel_DeleteFilsEventHandler);
                m_panelChild.Controls.Add(newPanel);
                CWin32Traducteur.Translate(newPanel);
                newPanel.Dock = DockStyle.Fill;
                m_panelChild.ResumeDrawing();
                m_extModeEdition.SetModeEdition(newPanel, TypeModeEdition.EnableSurEdition);
                newPanel.LockEdition = LockEdition;
                newPanel.Init(m_parametre.ParametreFils as CParametreNiveauArbreGanttGroupe);
            }
        }

        void newPanel_DeleteFilsEventHandler(object sender, EventArgs e)
        {
            m_parametre.ParametreFils = null;
            UpdateChilds();
        }

        public event EventHandler DeleteFilsEventHandler;

        private void m_lnkDelete_LinkClicked(object sender, EventArgs e)
        {
            if (DeleteFilsEventHandler != null)
                DeleteFilsEventHandler(this, null);
        }

        
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

        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_txtFormule.Formule == null )
            {
                result.EmpileErreur(I.T("Incorrect group formula|20166"));
                return result;
            }
            m_parametre.FormuleGroupe = m_txtFormule.Formule;
            m_parametre.Image = m_imageSelect.Image;
            if (m_panelChild.Controls.Count != 0 && m_parametre.ParametreFils != null)
            {
                CPanelEditGroupeGantt panelFils = m_panelChild.Controls[0] as CPanelEditGroupeGantt;
                if (panelFils != null)
                {
                    result = panelFils.MajChamps();
                }
            }
            return result;
        }

        private void m_lnkAddChilds_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_parametre.ParametreFils == null)
            {
                CParametreNiveauArbreGanttGroupe newParametre = new CParametreNiveauArbreGanttGroupe();
                m_parametre.ParametreFils = newParametre;
                UpdateChilds();
            }
        }
    }
}
