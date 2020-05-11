using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

using sc2i.win32.common;
using sc2i.common;
using timos.client;
using Lys.Licence;
using sc2i.multitiers.client;
using timos.client.licence;
using timos.FinalCustomer;

namespace timos.general
{
	public partial class CFormAboutBox : Form
	{
        private IList<CAlerteLicence> m_listeAlertes = null;
		public CFormAboutBox()
		{
			InitializeComponent();

            string strFile = CFinalCustomerInformations.GetAboutImageFile();
            if (strFile != null)
            {
                try
                {
                    Image img = Image.FromFile(strFile);
                    if (img != null)
                        m_picBoxTop.Image = img;
                }
                catch
                {
                }
            }

			m_lblSociete.Text = AssemblyCompany;
			m_lblProduit.Text = AssemblyProduct;
			m_lblCopyRight.Text = AssemblyCopyright;

			m_lnkWebSite.Text = AssemblyWebSite;
			m_lnkWebSite.Links.Add(0, AssemblyWebSite.Length, AssemblyWebSite);

			m_lblVersionCliente.Text = I.T("Client version @1|20020",AssemblyVersion);
			m_lblVersionServeur.Text = I.T("Server version @1|20021",AssemblyServeurVersion);
            CWin32Traducteur.Translate(this);
            FillDialog();
		}

        private void FillDialog()
        {
            IGestionnaireSessionsTimos gestionnaire = CSessionClient.GestionnaireSessions as IGestionnaireSessionsTimos;
            CLicenceLogicielPrtct licence = null;
            if (gestionnaire != null)
                licence = gestionnaire.GetLicenceServeur();
            if (licence == null)
            {
                MessageBox.Show(I.T("Global license error|20200"));
                Close();
                return;
            }
            m_lblNumeroLicence.Text = licence.Numero;
            m_lblNomClient.Text = licence.Contrat.Client.Nom;
            if (licence.DateLimiteUtilisation != null)
            {
                m_panelDateExpiration.Visible = true;
                m_lblDateExpiration.Text = licence.DateLimiteUtilisation.Value.ToShortDateString();
            }
            else
            {
                m_panelDateExpiration.Visible = false;
            }

            if (((TimeSpan)(licence.DateLimiteUpgradeLogiciel - DateTime.Now)).TotalDays > 365 * 5)
            {
                m_panelDateMaintenance.Visible = false;
            }
            else
                m_lblDateMaintenance.Text = licence.DateLimiteUpgradeLogiciel.ToShortDateString();



            foreach (CLicenceModuleAppPrtct module in licence.ModulesApp)
            {
                int nIndex = m_lstModules.Items.Add(module.Nom);
            }

            gestionnaire.RefreshNombreUtiliseParTypes();

            IEnumerable<CNombreUtilisePourTypeLicence> lstRestant = gestionnaire.GetNombreRestantParType();
            if (lstRestant == null)
                lstRestant = new List<CNombreUtilisePourTypeLicence>();
            List<CLicenceTypePrtct> lstToShow = new List<CLicenceTypePrtct>(licence.Types);
            lstToShow.Sort((x, y) => x.Nom.CompareTo(y.Nom));
            foreach (CLicenceTypePrtct type in lstToShow)
            {
                ListViewItem item = new ListViewItem(type.Nom);
                string strLicence = type.Nombre.ToString();
               
                item.SubItems.Add(strLicence);
                m_wndListeTypes.Items.Add(item);
                CNombreUtilisePourTypeLicence rest = lstRestant.FirstOrDefault(r => r.IdType.ToUpper() == type.Id.ToUpper());
                if (rest != null)
                {
                    item.SubItems.Add(rest.NombreUtilise.ToString());
                }
                
            }

            foreach (CUserLicencePrtct user in licence.UserLicences)
            {
                ListViewItem item = new ListViewItem(user.NbSimultane.ToString());
                item.SubItems.Add(user.GetNbUsed().ToString());
                if (user.DateValide != null)
                    item.SubItems.Add(user.DateValide.DateTimeValue.ToShortDateString());
                if (user.IsReadOnly)
                    item.SubItems.Add(I.T("Read only|20215"));
                else
                    item.SubItems.Add(I.T("Full|20214"));
                m_wndListeUsers.Items.Add(item);
            }

            m_listeAlertes = gestionnaire.GetAlertesLicences();
            if (m_listeAlertes.Count > 0)
            {
                m_pageLicence.ImageIndex = 0;
                m_panelAlertes.Visible = true;
                foreach (CAlerteLicence alerte in m_listeAlertes)
                {
                    ListViewItem item = new ListViewItem(alerte.MessageAlerte);
                    switch (alerte.Gravite)
                    {
                        case EGraviteAlerte.Info:
                            item.ImageIndex = 1;
                            break;
                        case EGraviteAlerte.Critique:
                            item.ImageIndex = 0;
                            break;
                    }
                    m_wndListeAlertes.Items.Add(item);
                }
                m_tabControl.SelectedTab = m_pageLicence;
            }
            else
            {
                m_panelAlertes.Visible = false;
                m_pageLicence.ImageIndex = -1;
            }



        }



		#region Accesseurs d'attribut de l'assembly

		public string AssemblyTitle
		{
			get
			{
				// Obtenir tous les attributs Title de cet assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				// Si au moins un attribut Title existe
				if (attributes.Length > 0)
				{
					// Sélectionnez le premier
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
					// Si ce n'est pas une chaîne vide, le retourner
					if (titleAttribute.Title != "")
						return titleAttribute.Title;
				}
				// Si aucun attribut Title n'existe ou si l'attribut Title était la chaîne vide, retourner le nom .exe
				return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		public string AssemblyWebSite
		{
			get
			{
				return @"http://www.futurocom.com";
			}
		}
		public string AssemblyServeurVersion
		{
			get
			{
				return CTimosApp.SessionClient.SessionSurServeur.GetVersionServeur();
			}
		}
		public string AssemblyVersion
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}

		public string AssemblyDescription
		{
			get
			{
				// Obtenir tous les attributs Description de cet assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
				// Si aucun attribut Description n'existe, retourner une chaîne vide
				if (attributes.Length == 0)
					return "";
				// Si un attribut Description existe, retourner sa valeur
				return ((AssemblyDescriptionAttribute)attributes[0]).Description;
			}
		}

		public string AssemblyProduct
		{
			get
			{
				// Obtenir tous les attributs Product de cet assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
				// Si aucun attribut Product n'existe, retourner une chaîne vide
				if (attributes.Length == 0)
					return "";
				// Si un attribut Product existe, retourner sa valeur
				return ((AssemblyProductAttribute)attributes[0]).Product;
			}
		}

		public string AssemblyCopyright
		{
			get
			{
				// Obtenir tous les attributs Copyright de cet assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
				// Si aucun attribut Copyright n'existe, retourner une chaîne vide
				if (attributes.Length == 0)
					return "";
				// Si un attribut Copyright existe, retourner sa valeur
				return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
			}
		}

		public string AssemblyCompany
		{
			get
			{
				// Obtenir tous les attributs Company de cet assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
				// Si aucun attribut Company n'existe, retourner une chaîne vide
				if (attributes.Length == 0)
					return "";
				// Si un attribut Company existe, retourner sa valeur
				return ((AssemblyCompanyAttribute)attributes[0]).Company;
			}
		}
		#endregion

		private void m_panClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void m_lnkWebSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			ProcessStartInfo sInfo = new ProcessStartInfo(e.Link.LinkData.ToString());
			Process.Start(sInfo);
		}

        private void m_tabControl_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void m_lblDateMaintenance_Click(object sender, EventArgs e)
        {

        }
        
	}
}
