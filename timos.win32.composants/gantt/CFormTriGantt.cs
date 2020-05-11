using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using timos.data.projet.gantt;
using sc2i.win32.common;

namespace timos.win32.composants.gantt
{
    public partial class CFormTriGantt : Form
    {
        private CControlSortByField[] m_controlsSortBy;
        public CFormTriGantt()
        {
            InitializeComponent();
            m_controlsSortBy = new CControlSortByField[3];
            for (int i = 0; i < m_controlsSortBy.Length; i++)
            {
                CControlSortByField ctrl = new CControlSortByField();
                m_panelSortBy.Controls.Add(ctrl);
                ctrl.Dock = DockStyle.Top;
                ctrl.BringToFront();
                m_controlsSortBy[i] = ctrl;
            }
        }

        private void m_btnAnnuler_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void m_btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Retourne true si validation, le paramètre est alors modifié.
        /// </summary>
        /// <param name="parametre"></param>
        /// <returns></returns>
        public static bool GetParametre(ref CParametreTriGantt parametre)
        {
            CFormTriGantt form = new CFormTriGantt();
            form.Init(parametre);
            parametre = null;
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                parametre = form.GetParametre();
            }
            form.Dispose();
            return result == DialogResult.OK;
        }

        public void Init ( CParametreTriGantt parametre )
        {
            for (int nIndex = 0; nIndex < m_controlsSortBy.Length; nIndex++)
            {
                m_controlsSortBy[nIndex].Init(parametre, nIndex==0);
                if (parametre != null)
                    parametre = parametre.ParametreSuivant;
            }
        }


        public CParametreTriGantt GetParametre()
        {
            CParametreTriGantt parametre = null;
            foreach (CControlSortByField ctrl in m_controlsSortBy.Reverse())
            {
                CParametreTriGantt pNew = ctrl.GetParametre();
                if (pNew != null)
                    pNew.ParametreSuivant = parametre;
                parametre = pNew;
            }
            return parametre;
        }

        private void CFormTriGantt_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
        }
    }
}
