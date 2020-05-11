using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using sc2i.win32.common;
using sc2i.common;

namespace TimosInventory
{
    public delegate void DoWorkDelegate ( CFormWaiting waiter );
    public partial class CFormWaiting : Form
    {
        private DoWorkDelegate m_funcToCall = null;

        //---------------------------------------------------
        public CFormWaiting()
        {
            InitializeComponent();
        }

        //---------------------------------------------------
        public static void DoWork(DoWorkDelegate funcToCall)
        {
            CFormWaiting frm = new CFormWaiting();
            frm.m_funcToCall = funcToCall;
            frm.ShowDialog();
        }

        //---------------------------------------------------
        private void CFormWaiting_Load(object sender, EventArgs e)
        {
            m_bkWork.RunWorkerAsync();
        }

        private DateTime? m_dtDebutTravail;
        //---------------------------------------------------
        private void m_bkWork_DoWork(object sender, DoWorkEventArgs e)
        {
            m_dtDebutTravail = DateTime.Now;
            if (m_funcToCall != null)
                m_funcToCall(this);
        }

        //---------------------------------------------------
        private void m_bkWork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is string)
                m_lblMessage.Text = (string)e.UserState;
            
        }

        //---------------------------------------------------
        private void m_bkWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }

        //---------------------------------------------------
        public void ReportProgress(string strProgress)
        {
            m_bkWork.ReportProgress(0, strProgress);
        }

        //---------------------------------------------------
        public void ShowError(string strMessage)
        {
            Invoke((MethodInvoker)delegate
            {
                Visible = false;
            });
            CFormAlerte.Afficher(strMessage, EFormAlerteType.Erreur);
            Invoke((MethodInvoker)delegate
            {
                Visible = true;
            });
        }

        private void m_timerSecs_Tick(object sender, EventArgs e)
        {
            if (m_dtDebutTravail != null)
            {
                TimeSpan sp = DateTime.Now - m_dtDebutTravail.Value;
                m_lblTime.Text = ((int)sp.TotalMinutes) + I.T("m|20013") +
                    Environment.NewLine+
                    ((int)sp.TotalSeconds % 60).ToString().PadLeft(2, '0') +
                    I.T("s|20014");
            }
        }
    }
}
