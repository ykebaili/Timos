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
using System.Collections;

namespace timos.projet.gantt
{
    public partial class CPanelEditParametresIconeGantt : UserControl, IControlALockEdition
    {

        CParametreDessinLigneGantt.CParametreDessinGantt m_parametre;
        private Dictionary<Type, bool> m_dicTypeParametreIcone_presenceControl = new Dictionary<Type, bool>();

        public CPanelEditParametresIconeGantt()
        {
            InitializeComponent();
        }

        //--------------------------------------------------------------
        public void Init(CParametreDessinLigneGantt.CParametreDessinGantt parametre)
        {
            m_parametre = parametre;

            // Supprime tous les controles du panel icones
            ArrayList lstToRemove = new ArrayList(m_panelIcones.Controls);
            foreach (Control ctrl in lstToRemove)
            {
                if (ctrl is IEditeurParametreIconeGantt)
                {
                    ctrl.Visible = false;
                    ctrl.Parent = null;
                    m_panelIcones.Controls.Remove(ctrl);
                    ctrl.Dispose();
                }
            }

            // Charge tous les parametres Icone
            foreach (IParametreIconeGantt param in parametre.ParametresIcones)
            {
                AjouterControlIcone(param);
            }

        }

        //--------------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;

            List<IParametreIconeGantt> lstIcones = new List<IParametreIconeGantt>();
            foreach (Control ctrl in m_panelIcones.Controls)
            {
                IEditeurParametreIconeGantt editeur = ctrl as IEditeurParametreIconeGantt;
                if (editeur != null)
                {
                    editeur.MajChamps();
                    lstIcones.Add(editeur.ParametreIconeGantt);
                }
            }

            m_parametre.ParametresIcones = lstIcones.ToArray();

            return result;
        }
        
        //--------------------------------------------------------------
        private void m_lnkAjouter_LinkClicked(object sender, EventArgs e)
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            List<Type> lstTypesIcones = CAllocateurEditeurParametreIconeGantt.GetTousLesTypesDeParametresIconeGanttEditables();

            foreach (Type tp in lstTypesIcones.ToArray())
            {
                object[] attribs = tp.GetCustomAttributes(typeof(NomConvivialParametreIconeGanttAttribute), false);
                if (attribs.Length == 1)
                {
                    bool present = false;
                    m_dicTypeParametreIcone_presenceControl.TryGetValue(tp, out present);
                    if (((NomConvivialParametreIconeGanttAttribute)attribs[0]).IsUnique && present)
                        continue;

                    ToolStripMenuItem item = new ToolStripMenuItem(
                        ((NomConvivialParametreIconeGanttAttribute)attribs[0]).Libelle);
                    item.Tag = tp;
                    Image imgIcone = null;
                    imgIcone = ((IParametreIconeGantt)Activator.CreateInstance(tp)).Image;
                    if (imgIcone != null)
                        item.Image = imgIcone;
                    item.Click += new EventHandler(itemAjouterIcone_Click);
                    menu.Items.Add(item);
                }
            }

            menu.Show(m_lnkAjouter, new Point(0, 22));

        }


        //----------------------------------------------------------------------
        void itemAjouterIcone_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                Type tpIcone = item.Tag as Type;
                if(tpIcone == null)
                    return;

                // Créer un ouveau IParametreIconeGantt
                IParametreIconeGantt newParamIcone = Activator.CreateInstance(tpIcone) as IParametreIconeGantt;
                AjouterControlIcone(newParamIcone);
            }
        }

        //----------------------------------------------------------------------
        private void AjouterControlIcone(IParametreIconeGantt param)
        {
            Type tpIcone = param.GetType();
            m_dicTypeParametreIcone_presenceControl[tpIcone] = true;

            // Ajoute un controle correspondant au type à éditer
            IEditeurParametreIconeGantt newControl = CAllocateurEditeurParametreIconeGantt.GetEditeurForType(tpIcone);
            if (newControl != null)
            {
                ((Control)newControl).Dock = DockStyle.Top;
                newControl.DeleteIconeEventHendler += new EventHandler(newControl_DeleteIconeEventHendler);
                newControl.LockEdition = !m_extModeEdition.ModeEdition;
                newControl.Init(param);
                CWin32Traducteur.Translate(newControl);
                m_panelIcones.Controls.Add((Control)newControl);
                ((Control)newControl).BringToFront();
            }
        }

        //----------------------------------------------------------------------
        void newControl_DeleteIconeEventHendler(object sender, EventArgs e)
        {
            Control controlASupprimer = sender as Control;
            if (controlASupprimer != null)
            {
                Type tp = ((IEditeurParametreIconeGantt)controlASupprimer).ParametreIconeGantt.GetType();
                m_dicTypeParametreIcone_presenceControl[tp] = false;

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
