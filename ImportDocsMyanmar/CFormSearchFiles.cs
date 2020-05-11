using sc2i.common;
using sc2i.win32.common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImportDocsMyanmar
{
    public partial class CFormSearchFiles : Form
    {
        private static CFormSearchFiles m_instance = null;

        private Thread m_threadSearch = null;

        private CFormMain m_formMain = null;
        public CFormSearchFiles()
        {
            InitializeComponent();
        }

        public static void Show ( CFormMain frmMain )
        {
            if ( m_instance == null )
            {
                m_instance = new CFormSearchFiles();
            }
            m_instance.m_formMain = frmMain;
            m_instance.Show();
            m_instance.Focus();
        }

        private void m_btnFindNext_Click(object sender, EventArgs e)
        {
            StartSearch();
        }

        private void StartSearch()
        {
            if ( m_threadSearch == null )
            {
                m_threadSearch = new Thread(SearchThread);
                UpdateVisuel();
                m_strDirPattern = m_txtDirPattern.Text;
                m_strFilePattern = m_txtFilePattern.Text;
                m_bCancelRequest = false;
                m_indicateurProgression = CFormProgression.GetNewIndicateurAndPopup("Searching");
                m_threadSearch.Start();
            }
        }

        private void UpdateVisuel()
        {
            m_txtFilePattern.Enabled = m_threadSearch == null;
            m_txtDirPattern.Enabled = m_threadSearch == null;
            m_btnFindNext.Enabled = m_threadSearch == null;
        }

        private bool m_bCancelRequest = false;
        string m_strDirPattern = "";
        string m_strFilePattern = "";
        IIndicateurProgression m_indicateurProgression = null;

        private void SearchThread ( object state )
        {
            Regex regDir = CPatternMatch.Convert(m_strDirPattern);
            Regex regFile = CPatternMatch.Convert(m_strFilePattern);
            CRepertoire repSel = null;
            CFichier ficSel = null;
            CFichier fichierTrouve = null;
            if (m_formMain != null)
            {
                repSel = m_formMain.GetRepertoireSel();
                ficSel = m_formMain.GetFichierSel();
                if (repSel != null)
                {
                    fichierTrouve = repSel.FindNext(true, repSel, ficSel, regDir, regFile, m_indicateurProgression);
                    if (fichierTrouve != null)
                        m_formMain.SelectFichier(fichierTrouve);
                    
                }
            }
            CFormProgression.EndIndicateur(m_indicateurProgression);
            m_threadSearch = null;
            Invoke((MethodInvoker)delegate { UpdateVisuel(); });
            if (fichierTrouve == null)
                MessageBox.Show("Pattern not found");
        }


    }
}
