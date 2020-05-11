using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.common;
using System.Media;
using timos.Properties;
using sc2i.win32.common;

namespace timos.Controles.notifications
{
    public partial class CFormParametresNotification : Form
    {
        //-----------------------------------------------------
        public CFormParametresNotification()
        {
            InitializeComponent();
            CWin32Traducteur.Translate(this);
        }

        //-----------------------------------------------------
        private void m_btnAnnuler_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        //-----------------------------------------------------
        private void m_btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            if (m_txtDuree.IntValue != null)
            {
                CParametresNotification.DureeAffichage = m_txtDuree.IntValue.Value;
            }
            CParametresNotification.ShouldPlaySound = m_chkPlaySound.Checked;
            CParametresNotification.SoundFile = m_txtNomFichier.Text;
            CParametresNotification.SavePreferences();
        }

        //-----------------------------------------------------
        public static void EditeParametres()
        {
            CFormParametresNotification form = new CFormParametresNotification();
            form.m_txtDuree.IntValue = CParametresNotification.DureeAffichage;
            form.m_chkPlaySound.Checked = CParametresNotification.ShouldPlaySound;
            form.m_txtNomFichier.Text = CParametresNotification.SoundFile;
            form.ShowDialog();
            form.Dispose();
        }

        private void m_btnFichier_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = I.T("Sound file (wav)|*.wav|All files|*.*|20614");
            dlg.FileName = CParametresNotification.SoundFile;
            if (dlg.ShowDialog() == DialogResult.OK)
                m_txtNomFichier.Text = dlg.FileName;
        }

        private void m_btnPlay_Click(object sender, EventArgs e)
        {
            SoundPlayer p = null;
            if (m_txtNomFichier.Text.Trim().Length > 0)
                p = new SoundPlayer(m_txtNomFichier.Text);
            else
                p = new SoundPlayer ( Resources.NotifDefault );
            try
            {
                p.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            p.Dispose();
        }
    }
}
