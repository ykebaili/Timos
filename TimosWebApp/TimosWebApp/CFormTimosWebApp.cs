using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TimosWebApp.TimosWebService;
using System.ServiceModel.Description;
using sc2i.win32.common;
using sc2i.common;

namespace TimosWebApp
{
    public partial class CFormTimosWebApp : Form
    {
        TimosActionServiceSoapClient m_client = null;
        CTimosWebConfig m_configEnCours = new CTimosWebConfig();
        CMemoryAction m_actionEnCours;
        private const string c_strNomEndPointName = "TimosActionServiceSoap";

        public CFormTimosWebApp()
        {
            InitializeComponent();
        }


        //----------------------------------------------------------------------------
        private void InitFromConfig(CTimosWebConfig config)
        {
            if (config == null)
                return;

            string strURL = config.URL;
            m_txtURL.Text = strURL;
            if (strURL != "")
            {
                try
                {
                    InitClientSoap(strURL);
                    m_actionEnCours = config.Action;
                    m_cmbSelectAction.SelectedValue = config.Action;
                    FillListeVariables(m_actionEnCours);
                }
                catch (Exception ex)
                {
                    m_txtOutput.Text += ex.Message + Environment.NewLine;
                }
            }
        }

        //----------------------------------------------------------------------------
        private void InitClientSoap(string strURL)
        {
            if (strURL != "")
            {
                try
                {
                    m_client = new TimosActionServiceSoapClient(c_strNomEndPointName, strURL);
                    FillListeActions();
                }
                catch (Exception ex)
                {
                    m_txtOutput.Text += ex.Message + Environment.NewLine;
                }
            }
        }

        //----------------------------------------------------------------------------
        private void m_btnReachURL_Click(object sender, EventArgs e)
        {
            InitClientSoap(m_txtURL.Text);
        }

        //----------------------------------------------------------------------------
        private void FillListeActions()
        {
            DataSet ds = m_client.GetActions();
            if (ds != null)
            {
                m_txtOutput.Text += ds.DataSetName + Environment.NewLine;

                DataTable tableActions = ds.Tables[m_client.GetActionTableName()];
                DataTable tableVariables = ds.Tables[m_client.GetVariablesTableNameName()];

                if (tableActions != null)
                {
                    List<CMemoryAction> listeActions = new List<CMemoryAction>();
                    foreach (DataRow row in tableActions.Rows)
                    {
                        CMemoryAction action = new CMemoryAction();
                        action.Id = (int)row[m_client.GetActionIdFieldName()];
                        action.Label = (string)row[m_client.GetActionLabelFieldName()];
                        action.TypeAction = (string)row[m_client.GetActionTypeFieldName()];
                        action.Description = (string)row[m_client.GetActionDescpritionFieldName()];
                        if (tableVariables != null)
                        {
                            List<CCoupleVariableValeur> listeVariables = new List<CCoupleVariableValeur>();
                            foreach (DataRow rowV in tableVariables.Rows)
                            {
                                int nIdAction = (int)rowV[m_client.GetActionIdFieldName()];
                                if (nIdAction == action.Id)
                                {
                                    CMemoryVariable variable = new CMemoryVariable();
                                    variable.Id = (int)rowV[m_client.GetVariableIdFieldName()];
                                    variable.Name = (string)rowV[m_client.GetVariableNameFieldName()];
                                    variable.TypeVariable = (int)rowV[m_client.GetVariableTypeFieldName()];
                                    listeVariables.Add(new CCoupleVariableValeur(variable, ""));
                                }
                            }
                            action.LiseVariables = listeVariables;
                        }
                        listeActions.Add(action);
                    }

                    m_cmbSelectAction.Fill(listeActions, "Label", true);
                }

            }

        }

        //----------------------------------------------------------------------------
        private void m_cmbSelectAction_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MajChamps();
            CMemoryAction action = m_cmbSelectAction.SelectedValue as CMemoryAction;
            if (action != null)
            {
                m_actionEnCours = action;
                FillListeVariables(action);
            }
        }
    
        //----------------------------------------------------------------------------
        void FillListeVariables(CMemoryAction action)
        {
            m_panelVariables.SuspendDrawing();
            m_panelVariables.ClearAndDisposeControls();

            if (action != null)
            {
                foreach (CCoupleVariableValeur coupleVarVal in action.LiseVariables)
                {
                    CControlVariableValeur ctrl = new CControlVariableValeur();
                    ctrl.Init(coupleVarVal);
                    ctrl.Dock = DockStyle.Top;
                    m_panelVariables.Controls.Add(ctrl);
                    ctrl.BringToFront();
                }
            }

            m_panelVariables.ResumeDrawing();

        }

        //----------------------------------------------------------------------------
        CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            m_configEnCours.URL = m_txtURL.Text;
            if (m_actionEnCours != null)
            {
                // MAJ Champs action en cours
                List<CCoupleVariableValeur> listeVariables = new List<CCoupleVariableValeur>();
                foreach (Control ctrl in m_panelVariables.Controls)
                {
                    CControlVariableValeur control = ctrl as CControlVariableValeur;
                    if (control != null)
                    {
                        result = control.MajChamps();
                        if (result)
                            listeVariables.Add(control.CoupleVariableValeur);
                    }
                }
                m_actionEnCours.LiseVariables = listeVariables;
                m_configEnCours.Action = m_actionEnCours;
            }
            return result;
        }

        //----------------------------------------------------------------------------
        private void m_btnStartAction_Click(object sender, EventArgs e)
        {
            MajChamps();
            if (m_actionEnCours != null && m_client != null)
            {
                string strResult = "";
                try
                {
                    List<string> listeParams = new List<string>();
                    foreach (CCoupleVariableValeur couple in m_actionEnCours.LiseVariables)
                    {
                        if (couple.Valeur != "")
                        {
                            listeParams.Add(couple.Variable.Name);
                            listeParams.Add(couple.Valeur);
                        }
                    }
                    if (listeParams.Count > 0)
                    {
                        strResult = m_client.StartAction(m_actionEnCours.Id, listeParams.ToArray());
                    }
                    else
                    {
                        strResult = m_client.StartSimpleAction(m_actionEnCours.Id);
                    }

                    m_txtOutput.Text += strResult + Environment.NewLine;
                }
                catch (Exception ex)
                {
                    m_txtOutput.Text += ex.Message + Environment.NewLine;

                }
            }
        }

        //----------------------------------------------------------------------------
        private void m_btnClearOutput_Click(object sender, EventArgs e)
        {
            m_txtOutput.Text = "";
        }

        //----------------------------------------------------------------------------
        private void m_btnOpenConfig_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Timos Web Config (*.twconfig)|*.twconfig|All files(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (CFormAlerte.Afficher(
                    "Current Web Service configuration will be replaced. Continue ?",
                    EFormAlerteType.Question) == DialogResult.No)
                    return;
                CTimosWebConfig config = new CTimosWebConfig();
                CResultAErreur result = config.ReadFromFile(dlg.FileName);
                if (!result)
                    CFormAlerte.Afficher(result);
                else
                {
                    m_configEnCours = config;
                    InitFromConfig(config);
                }
            }
        }

        //----------------------------------------------------------------------------
        private void m_btnSaveConfig_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Timos Web Config (*.twconfig)|*.twconfig|All files(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                MajChamps();
                string strNomFichier = dlg.FileName;
                CResultAErreur result = m_configEnCours.SaveToFile(strNomFichier);
                if (!result)
                    CFormAlerte.Afficher(result);
                else
                    CFormAlerte.Afficher("Save successful");
            }
        }

       


    }
}
