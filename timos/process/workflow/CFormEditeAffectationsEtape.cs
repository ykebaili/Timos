using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.process.workflow;
using sc2i.common;
using sc2i.win32.common;

namespace timos.process.workflow
{
    public partial class CFormEditeAffectationsEtape : Form
    {
        private CEtapeWorkflow m_etape =  null;
        public CFormEditeAffectationsEtape()
        {
            InitializeComponent();
        }



        //---------------------------------------------------------------------
        public static bool EditeAffectations(CEtapeWorkflow etape)
        {
            CFormEditeAffectationsEtape form = new CFormEditeAffectationsEtape();
            form.m_etape = etape;
            bool bOk = form.ShowDialog() == DialogResult.OK;
            form.Dispose();
            return bOk;
        }

        //---------------------------------------------------------------------
        private void CFormEditeAffectationsEtape_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
            m_lblEtape.Text = m_etape.Libelle;
            m_panelAffectations.Init(m_etape.Affectations.GetAffectables());
        }

        //---------------------------------------------------------------------
        private void m_btnAnnuler_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        //---------------------------------------------------------------------
        private void m_btnOk_Click(object sender, EventArgs e)
        {
            CAffectationsEtapeWorkflow aff = new CAffectationsEtapeWorkflow();
            foreach (IAffectableAEtape affectable in m_panelAffectations.ListeAffectables)
                aff.AddAffectable(affectable);
            m_etape.BeginEdit();
            m_etape.Affectations = aff;
            CResultAErreur result = m_etape.CommitEdit();
            if (!result)
            {
                m_etape.CancelEdit();
                CFormAlerte.Afficher(result.Erreur);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }


            

    }
}
