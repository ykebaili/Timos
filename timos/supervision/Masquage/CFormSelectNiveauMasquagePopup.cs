using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using futurocom.supervision;
using sc2i.win32.common;

namespace timos.supervision.Masquage
{
    public partial class CFormSelectNiveauMasquagePopup : Form
    {
        public CFormSelectNiveauMasquagePopup()
        {
            InitializeComponent();
        }

        private CLocalCategorieMasquageAlarme m_elementSelectionne = null;

        
        internal void Init(CLocalCategorieMasquageAlarme[] listeSource, CLocalCategorieMasquageAlarme lastElementSelectionne)
        {
            int nCount = listeSource.Count() + 1;
            Height = (nCount * 25) + m_lblTitre.Height + m_panelBas.Height + 20;

            m_selectNiveauMasquage.Init(listeSource, lastElementSelectionne);

        }

        public CLocalCategorieMasquageAlarme ElementSelectionne
        {
            get
            {
                return m_elementSelectionne;
            }
        }

        private void m_btnOK_Click(object sender, EventArgs e)
        {
            m_elementSelectionne = m_selectNiveauMasquage.ElementSelectionne;
            if (m_elementSelectionne != null)
                DialogResult = DialogResult.OK;
            else
                DialogResult = DialogResult.No;
        }

        private void m_btnAnnuler_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void CFormSelectNiveauMasquagePopup_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
        }

    }
}
