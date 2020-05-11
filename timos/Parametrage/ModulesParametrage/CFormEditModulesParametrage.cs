using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using sc2i.data;
using sc2i.win32.common;
using sc2i.common;
using sc2i.win32.data.navigation;
using sc2i.win32.navigation;
using timos.Parametrage.ModulesParametrage;
using sc2i.data.dynamic;


namespace timos.Parametrage
{
    public partial class CFormEditModulesParametrage : Form
    {
        public CFormEditModulesParametrage()
        {
            InitializeComponent();
            m_panelModulesParametrage.OnListElementsItemDoubleClick += new EventHandler(m_panelModulesParametrage_OnListElementsItemDoubleClick);
            m_panelModulesParametrage.OnChangeAlwaysVisibleMode += new sc2i.win32.data.dynamic.OnChangeAlwaysVisibleModeEvent(m_panelModulesParametrage_OnChangeAlwaysVisibleMode);
            m_panelModulesParametrage.OnAutoArrangeWindow += new EventHandler(m_panelModulesParametrage_OnAutoArrangeWindow);
            m_timerSauvegarde.Enabled = true;
        }

        void m_panelModulesParametrage_OnAutoArrangeWindow(object sender, EventArgs e)
        {
            Form formPrincipale = CFormMain.GetInstance();

            int unQuart = (int)Screen.PrimaryScreen.WorkingArea.Width / 4;
            int troisQuart = (int)Screen.PrimaryScreen.WorkingArea.Width - unQuart;
            this.Location = new Point(0, 0);
            this.Size = new Size(unQuart, Screen.PrimaryScreen.WorkingArea.Height);

            formPrincipale.WindowState = FormWindowState.Normal;
            formPrincipale.Location = new Point(this.Width, 0);
            formPrincipale.Size = new Size(troisQuart, Screen.PrimaryScreen.WorkingArea.Height);
        }

        void m_panelModulesParametrage_OnChangeAlwaysVisibleMode(object sender, bool bAlwaysVisible)
        {
            this.TopMost = bAlwaysVisible;
        }

        void m_panelModulesParametrage_OnListElementsItemDoubleClick(object sender, EventArgs e)
        {
            // Affiche l'élement dans Timos
            CObjetDonneeAIdNumerique element = sender as CObjetDonneeAIdNumerique;
            if (element != null)
            {
                CReferenceTypeForm referenceForm = CFormFinder.GetRefFormToEdit(element.GetType());
                if (referenceForm != null)
                {
                    IFormNavigable form = referenceForm.GetForm((CObjetDonneeAIdNumeriqueAuto)element) as IFormNavigable;
                    if (form != null)
                        CTimosApp.Navigateur.AffichePage(form);

                }


            }
        }

        private static CFormEditModulesParametrage m_instance = null;
        private CContexteDonnee m_contexte;

        public static void EditModules()
        {
            EditModules(null);
        }

        public static void EditModules(CModuleParametrage moduleToSelect)
        {
            if (m_instance == null)
            {
                m_instance = new CFormEditModulesParametrage();
                m_instance.m_contexte = new CContexteDonnee(CTimosApp.SessionClient.IdSession, true, false);
                m_instance.Show();
            }
            else
            {
                m_instance.Focus();
                m_instance.BringToFront();
            }
            if (moduleToSelect != null)
                m_instance.SelectModule(moduleToSelect);
        }

        private void CFormEditModulesParametrage_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
            m_panelModulesParametrage.InitChamps(m_contexte);
            CParametreVisuModuleParametrage parametre = CTimosAppRegistre.GetParametreVisuModulesParametrage();
            if (parametre != null)
                AppliqueParametre(parametre);

        }

        private void SelectModule(CModuleParametrage module)
        {
            if (module != null)
                m_panelModulesParametrage.SelectModule(module);
        }

        private void AppliqueParametre(CParametreVisuModuleParametrage parametre)
        {
            if (parametre.Size.Width > 5)
                Size = parametre.Size;
            if (parametre.Position.X != -1 && parametre.Position.Y != -1)
                Location = parametre.Position;
            if (CFormMain.GetInstance() != null)
            {
                if (parametre.TimosSize.Width > 5)
                    CFormMain.GetInstance().Size = parametre.TimosSize;
                if (parametre.TimosPosition.X != -1 && parametre.TimosPosition.Y != -1)
                    CFormMain.GetInstance().Location = parametre.TimosPosition;
                if (parametre.TimosAgrandi)
                    CFormMain.GetInstance().WindowState = FormWindowState.Maximized;
                else
                    CFormMain.GetInstance().WindowState = FormWindowState.Normal;
            }
            
                
            m_panelModulesParametrage.SetParametreAffichage(parametre);
        }

        private void SaveParametreAffichage()
        {
            CParametreVisuModuleParametrage parametre = new CParametreVisuModuleParametrage();
            m_panelModulesParametrage.FillParametreAffichage(parametre);
            parametre.Size = Size;
            parametre.Position = Location;
            if (CFormMain.GetInstance() != null)
            {
                parametre.TimosPosition = CFormMain.GetInstance().Location;
                parametre.TimosSize = CFormMain.GetInstance().Size;
                parametre.TimosAgrandi = CFormMain.GetInstance().WindowState == FormWindowState.Maximized;
                CTimosAppRegistre.SaveParametreVisuModulesParametrage(parametre);

            }

        }



        private CResultAErreur SaveAll()
        {
            CResultAErreur result = CResultAErreur.True;

            result = m_contexte.SaveAll(true);
            
            if (!result)
                CFormAlerte.Afficher(result.MessageErreur, EFormAlerteBoutons.Ok, EFormAlerteType.Erreur);

            return result;
        }

        private void m_btnOK_Click(object sender, EventArgs e)
        {
            CResultAErreur result = SaveAll();
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }
        }

        private void m_btnAnnuler_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
            m_instance = null;
        }

        private void m_btnEnregistreModifs_Click(object sender, EventArgs e)
        {
            SaveAll();
        }

        private void m_panelModulesParametrage_Load(object sender, EventArgs e)
        {

        }

        private void m_timerSauvegarde_Tick(object sender, EventArgs e)
        {
            if (m_contexte.HasChanges())
                m_imgModified.Visible = !m_imgModified.Visible;
            else
                m_imgModified.Visible = false;
        }

        private void CFormEditModulesParametrage_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveParametreAffichage();
        }
    }
}
