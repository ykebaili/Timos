using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using timos.data.workflow.ConsultationHierarchique;
using sc2i.data;
using sc2i.win32.common;

namespace timos.Parametrage.ConsultationHierarchique
{
    public partial class CFormTestConsultationHierarchique : Form
    {
        private CFolderConsultationHierarchique m_folderRoot = null;
        private CContexteDonnee m_contexteDonnee = null;
        public CFormTestConsultationHierarchique()
        {
            InitializeComponent();
        }

        private void CFormTestConsultationHierarchique_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
            m_arbre.InitChamps(m_folderRoot, m_contexteDonnee);
        }

        public static void TestFolder(CFolderConsultationHierarchique folder)
        {
            CFormTestConsultationHierarchique form = new CFormTestConsultationHierarchique();
            form.m_folderRoot = folder;
            form.m_contexteDonnee = new CContexteDonnee(CTimosApp.SessionClient.IdSession, true, false);
            form.ShowDialog();
            form.Dispose();
        }
    }
}