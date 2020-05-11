using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Lys.Licence;
using Lys.Applications.Timos.Smt;

using sc2i.common;

namespace timos
{
	public partial class CFormEditionAssociationsControlModules : Form
	{
		public CFormEditionAssociationsControlModules()
		{
			InitializeComponent();
		}
		private List<object> ModulesAppPossibles
		{
			get
			{
				List<object> modules = new List<object>();
				List<CLicenceModuleAppPrtct> modulesPoss = CConfigModulesTimos.ModulesApplicatifPossibles;
				foreach(CLicenceModuleAppPrtct m in modulesPoss)
				    modules.Add(m);
				return modules;
			}
		}
		private List<object> ModulesClientPossibles
		{
			get
			{
				List<object> modules = new List<object>();
				List<CLicenceModuleClientPrtct> modulesPoss = CConfigModulesTimos.ModulesClientPossibles;
				foreach (CLicenceModuleClientPrtct m in modulesPoss)
					modules.Add(m);
				return modules;
			}
		}

		public void Initialiser(string strNomControl, List<CLicenceModuleAppPrtct> modulesApp, List<CLicenceModuleClientPrtct> modulesClient)
		{
			Text = I.T("List of modules associated with the control|30003") + strNomControl;

			List<object> modulesAppSelec = new List<object>();
			foreach (CLicenceModuleAppPrtct m in modulesApp)
				modulesAppSelec.Add(m);

			m_ctrlModulesApp.Initialiser(modulesAppSelec, CConfigModulesTimos.ModulesApplicatifPossibles, "Id", "Nom", "Description");


			List<object> modulesClientSelec = new List<object>();
			foreach (CLicenceModuleClientPrtct m in modulesClient)
				modulesClientSelec.Add(m);

			m_ctrlModulesClient.Initialiser(modulesClientSelec, CConfigModulesTimos.ModulesClientPossibles, "Id", "Nom", "Description");
		}

		public List<CLicenceModuleClientPrtct> ModulesClientSelec
		{
			get
			{
				List<CLicenceModuleClientPrtct> modulesClientFinaux = new List<CLicenceModuleClientPrtct>();
				List<object> modulesClient = m_ctrlModulesClient.ElementsSelectionnes;
				foreach (object m in modulesClient)
					modulesClientFinaux.Add((CLicenceModuleClientPrtct)m);
				return modulesClientFinaux;
			}
		}
		public List<CLicenceModuleAppPrtct> ModulesApplicatifSelec
		{
			get
			{
				List<CLicenceModuleAppPrtct> modulesAppFinaux = new List<CLicenceModuleAppPrtct>();
				List<object> modulesApp = m_ctrlModulesApp.ElementsSelectionnes;
				foreach (object m in modulesApp)
					modulesAppFinaux.Add((CLicenceModuleAppPrtct)m);
				return modulesAppFinaux;
			}
		}

		private void m_ctrlModulesClient_ChangementSelection(object sender, EventArgs e)
		{
			List<object> elements = sender != null ? (List<object>)sender : null;
			if (elements != null && elements.Count == 1)
				ModuleSelec = (CLicenceModulePrtct)elements[0];
			else
				ModuleSelec = null;
		}

		private void m_ctrlModulesApp_ChangementSelection(object sender, EventArgs e)
		{
			List<object> elements = sender != null ? (List<object>)sender : null;
			if (elements != null && elements.Count == 1)
				ModuleSelec = (CLicenceModulePrtct)elements[0];
			else
				ModuleSelec = null;
		}

		private CLicenceModulePrtct ModuleSelec
		{
			set
			{
				m_lblDescrip.Visible = value != null;
				m_txtDescrip.Visible = value != null;
				if (value == null)
					return;
				m_lblDescrip.Text = I.T("Module Description|30004") + (value is CLicenceModuleAppPrtct? I.T("Application|30005"):I.T("Client |30006")) + value.Nom+ " :";
				m_txtDescrip.Text = value.Description;
			}
		}
	}
}
