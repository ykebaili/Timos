using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.process.workflow;

namespace timos.process.workflow
{
    public partial class CPanelDessineWorkflowEnCours : UserControl
    {
        private CWorkflow m_workflowRacine =  null;
        public CPanelDessineWorkflowEnCours()
        {
            InitializeComponent();
        }

        private void m_trackZoom_ValueChanged(object sender, EventArgs e)
        {
            if (!m_bIsRefreshingTrack)
                SetZoomFromTrack();
        }

        //------------------------------------------------------------------
        private void SetZoomFromTrack()
        {
            int nVal = m_trackZoom.Value;
            if (nVal == 10)
                m_panelWorkflow.Echelle = 1;
            else if (nVal < 10)
            {
                float fVal = nVal * (1 - m_panelWorkflow.MinZoom) / 10 + m_panelWorkflow.MinZoom;
                m_panelWorkflow.Echelle = fVal;
            }
            else
            {
                float fVal = (nVal - 10) * (m_panelWorkflow.MaxZoom - 1) / 10 + 1;
                m_panelWorkflow.Echelle = fVal;
            }
            m_panelWorkflow.Refresh();
        }

        //------------------------------------------------------------------
        private bool m_bIsRefreshingTrack = false;
        private void RefreshTrackZoom()
        {
            try
            {
                m_bIsRefreshingTrack = true;
                m_trackZoom.Minimum = 0;
                m_trackZoom.Maximum = 20;
                if (m_panelWorkflow.Echelle == 1)
                    m_trackZoom.Value = 10;
                else if (m_panelWorkflow.Echelle < 1)
                {
                    double fVal = (m_panelWorkflow.Echelle - m_panelWorkflow.MinZoom) * 10;
                    fVal /= (1 - m_panelWorkflow.MinZoom);
                    m_trackZoom.Value = (int)fVal;
                }
                else
                {
                    double fVal = (m_panelWorkflow.Echelle - 1) * 10;
                    fVal /= (m_panelWorkflow.MaxZoom - 1);
                    m_trackZoom.Value = (int)fVal + 10;
                }
            }
            catch { }
            m_lblZoom.Text = "x" + m_panelWorkflow.Echelle.ToString("0.#");
            m_bIsRefreshingTrack = false;
        }

        //---------------------------------------------------------------------------
        private void m_panelWorkflow_EchelleChanged(object sender, EventArgs e)
        {
            RefreshTrackZoom();
        }


        //---------------------------------------------------------------------------
        public void Init ( CWorkflow workflow )
        {
            if (workflow == null || workflow.TypeWorkflow == null)
            {
                Visible = false;
                return;
            }
            Visible = true;            
            m_workflowRacine = workflow;
            m_panelWorkflow.Init ( workflow );
            RefreshTrackZoom();
        }


        //---------------------------------------------------------------------------
        private void m_panelWorkflow_WorkflowEditeChanged(object sender, EventArgs e)
        {
            m_btnUpLevel.Visible = m_panelWorkflow.CanUpLevel();
            if (WorkflowAfficheChanged != null)
            {
                WorkflowAfficheChanged(WorkflowAfficheChanged, null);
            }
        }

        //---------------------------------------------------------------------------
        private void m_btnUpLevel_Click(object sender, EventArgs e)
        {
            m_panelWorkflow.UpLevel();
        }

        //---------------------------------------------------------------------------
        public event EventHandler WorkflowAfficheChanged;

        //---------------------------------------------------------------------------
        public CWorkflow WorkflowAffiche
        {
            get
            {
                return m_panelWorkflow.WorkflowAffiche;
            }
        }


        

        
                

        
            
        




    }
}
