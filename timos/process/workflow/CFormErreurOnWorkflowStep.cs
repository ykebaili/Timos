using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using sc2i.process.workflow;
using sc2i.common;

namespace timos.process.workflow
{
    public partial class CFormErreurOnWorkflowStep : Form
    {
        private EModeGestionErreurEtapeWorkflow m_modeGestion = EModeGestionErreurEtapeWorkflow.DoNothing;
        public CFormErreurOnWorkflowStep()
        {
            InitializeComponent();
            CWin32Traducteur.Translate(this);
        }

        public static EModeGestionErreurEtapeWorkflow OnError(
            CResultAErreur result,
            EModeGestionErreurEtapeWorkflow modeGestion)
        {
            CModeGestionErreurEtapeWorkflow mode = new CModeGestionErreurEtapeWorkflow(modeGestion);
            if (mode.IsSingleChoice())
                return modeGestion;
            
            CFormErreurOnWorkflowStep form = new CFormErreurOnWorkflowStep();
            form.m_lblMessage.Text = result.Erreur.ToString();

            form.m_btnDoNothing.Visible = (modeGestion & EModeGestionErreurEtapeWorkflow.DoNothing) != 0;
            form.m_btnCancel.Visible = (modeGestion & EModeGestionErreurEtapeWorkflow.CancelStep) != 0;
            form.m_btnError.Visible = (modeGestion & EModeGestionErreurEtapeWorkflow.SetError) != 0;
            form.m_btnTerminer.Visible = (modeGestion & EModeGestionErreurEtapeWorkflow.EndStep) != 0;
            form.ShowDialog();
            form.Dispose();
            return form.m_modeGestion;
        }

        //-------------------------------------------------------------------
        private void m_btnDoNothing_Click(object sender, EventArgs e)
        {
            m_modeGestion = EModeGestionErreurEtapeWorkflow.DoNothing;
            Close();
        }

        //-------------------------------------------------------------------
        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            m_modeGestion = EModeGestionErreurEtapeWorkflow.CancelStep;
            Close();
        }

        //-------------------------------------------------------------------
        private void m_btnTerminer_Click(object sender, EventArgs e)
        {
            m_modeGestion = EModeGestionErreurEtapeWorkflow.EndStep;
            Close();
        }

        //-------------------------------------------------------------------
        private void m_btnError_Click(object sender, EventArgs e)
        {
            m_modeGestion = EModeGestionErreurEtapeWorkflow.SetError;
            Close();
        }

            
            

    }
}
