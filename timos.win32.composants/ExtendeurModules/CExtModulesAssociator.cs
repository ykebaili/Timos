using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Design;

using Lys.Licence;
using sc2i.multitiers.client;
using sc2i.win32.common;
using Lys.Applications.Timos.Smt;
using sc2i.common;

namespace timos
{
	[ProvideProperty("Modules", typeof(Control))]
	public class CExtModulesAssociator : Component, IExtenderProvider
	{
		public CExtModulesAssociator()
		{

		}

		

		public event ExtModulesAssociatorEvent LancementApplication;
		public event ConfigureControlEvent ApplicationConfiguration;
		public event EventHandler FinApplication;

		public void ClearSurveillance()
		{
			ClearSurveillanceControlesAddedNonAutorise();
			ClearSurveillanceControlesEnabledChangedNonAutorise();
			ClearSurveillanceControlesLockEditionChangedNonAutorise();
			ClearSurveillanceControlesVisibleChangedNonAutorise();
			ClearSurveillanceControlesParentChangedNonAutorise();
		}

		public void AppliquerConfiguration(CConfigModulesTimos configuration)
		{
			if (!DesignMode && configuration != null)
			{
				if (LancementApplication != null)
				{
					EventArgConfigureControl arg = new EventArgConfigureControl();
					LancementApplication(arg);
					if (arg.Cancel)
					{
						if (FinApplication != null)
							FinApplication(this, new EventArgs());
						return;
					}
				}

				ClearSurveillance();

				foreach (Control ctrl in m_associations.Keys)
				{
					string association = m_associations[ctrl];
					if(association == null || association == "")
						continue;

					#region Recuperation de la restriction a Appliquer
					ERestriction restriction = ERestriction.Aucune;

					//Combinaison des restrictions
					List<string> strIdsModulesApp = CSerializerModulesLicence.GetIdsModulesApp(association);
					bool bFind = strIdsModulesApp.Count == 0;
					foreach (string strIdApp in strIdsModulesApp)
					{
						CLicenceModuleAppPrtct mApp = configuration.GetModuleApp(strIdApp);
						if (mApp != null)
						{
							restriction = restriction | mApp.Restriction;
							bFind = true;
							if (restriction == ERestriction.Hide)
								break;
						}
					}

					if(bFind && restriction != ERestriction.Hide)
					{
						List<string> strIdsModulesClient = CSerializerModulesLicence.GetIdsModulesClient(association);
						bFind = strIdsModulesClient.Count == 0;
						foreach (string strId in strIdsModulesClient)
						{
							CLicenceModuleClientPrtct mCli = configuration.GetModuleClient(strId);
							if (mCli != null)
							{
								restriction = restriction | mCli.Restriction;
								bFind = true;
								if (restriction == ERestriction.Hide)
								break;
							}
						}
					}

					if (!bFind)
						restriction = ERestriction.Hide;
					#endregion

					if (ApplicationConfiguration != null)
					{
						EventArgConfigureControl arg = new EventArgConfigureControl();
						ApplicationConfiguration(ctrl, restriction, arg);
						if (arg.Cancel)
							return;
					}

					#region Affectation du controle et mise sous surveillance
					switch (restriction)
					{
						case ERestriction.Hide:
							ctrl.Visible = false;

							if (ctrl is Crownwood.Magic.Controls.TabPage)
							{
								DetacheC2iTabPage((Crownwood.Magic.Controls.TabPage)ctrl);
								AjouterControleParentChangedNonAutorise(ctrl);
							}
							else if (ctrl is TabPage)
							{
							    TabPage tbp = (TabPage)ctrl;
								//if (tbp.Parent != null && tbp.Parent is TabControl)
								//{
								//    AjouterControleAddedNonAutorise(tbp.Parent);
								//    tbp.Parent = null;
								//}
								tbp.Parent = null;
								AjouterControleParentChangedNonAutorise(tbp);
							}
							AjouterControleVisibleChangedNonAutorise(ctrl);
							break;

						case ERestriction.ReadOnly:
							if (typeof(IControlALockEdition).IsAssignableFrom(ctrl.GetType()))
							{
								IControlALockEdition ctrlALock = (IControlALockEdition)ctrl;
								ctrlALock.LockEdition = true;
								AjouterControleLockEditionChangedNonAutorise(ctrlALock);
							}
							else
							{
								ctrl.Enabled = false;
								AjouterControleEnableChangedNonAutorise(ctrl);
							}
							break;

						case ERestriction.NoCreate:
							break;
						case ERestriction.NoDelete:
							break;
					
						case ERestriction.NoCreate | ERestriction.NoDelete:
						case ERestriction.Aucune:
						default:
							break;
					}
					#endregion
				}
				if (FinApplication != null)
					FinApplication(this, new EventArgs());
			}
		}

		#region SURVEILLANCE CONTROLES
		#region ParentChanged
		public static void DetacheC2iTabPage(Crownwood.Magic.Controls.TabPage tbp)
		{
			if (tbp.Parent != null && tbp.Parent is C2iTabControl)
			{
				C2iTabControl tbctrl = (C2iTabControl)tbp.Parent;
				try
				{
					while (tbctrl.TabPages.Contains(tbp))
					{
						tbctrl.TabPages.Remove(tbp);
					}
				}
				catch
				{ 
				}
			}
		}
		private static List<Control> m_controlesParentChangedNonAutorise = new List<Control>();
		private static void AjouterControleParentChangedNonAutorise(Control ctrl)
		{
			if (!m_controlesParentChangedNonAutorise.Contains(ctrl))
			{
				ctrl.ParentChanged += m_handlerParentChangedNonAutorise;
				m_controlesParentChangedNonAutorise.Add(ctrl);
			}
		}
		private static void ClearSurveillanceControlesParentChangedNonAutorise()
		{
			foreach (Control c in m_controlesParentChangedNonAutorise)
				c.ParentChanged -= m_handlerParentChangedNonAutorise;
			m_controlesParentChangedNonAutorise.Clear();
		}
		private static EventHandler m_handlerParentChangedNonAutorise = new EventHandler(ctrl_ParentChangedNonAutorise);
		private static void ctrl_ParentChangedNonAutorise(object sender, EventArgs e)
		{
			if (sender is Crownwood.Magic.Controls.TabPage)
			{
				DetacheC2iTabPage((Crownwood.Magic.Controls.TabPage)sender);
			}
			else if (sender is Control)
			{
				Control ctrl = (Control)sender;
				Control ctrlParent = ctrl.Parent;
				if (ctrlParent != null)
					ctrlParent.Controls.Remove(ctrl);
			}
		}
		#endregion
		#region ControlAdded
		private static List<Control> m_controlesAddedNonAutorise = new List<Control>();
		private static void AjouterControleAddedNonAutorise(Control ctrl)
		{
			if(!m_controlesAddedNonAutorise.Contains(ctrl))
			{
				ctrl.ControlAdded += m_handlerControlAddedNonAutorise;
				m_controlesAddedNonAutorise.Add(ctrl);
			}
		}
		private static void ClearSurveillanceControlesAddedNonAutorise()
		{
			foreach (Control c in m_controlesAddedNonAutorise)
				c.ControlAdded -= m_handlerControlAddedNonAutorise;
			m_controlesAddedNonAutorise.Clear();
		}
		private static ControlEventHandler m_handlerControlAddedNonAutorise = new ControlEventHandler(ctrl_ControlAddedNonAutorise);
		private static void ctrl_ControlAddedNonAutorise(object sender, ControlEventArgs e)
		{
			if (sender is Control)
				((Control)sender).Controls.Remove(e.Control);
		}
		#endregion
		#region LockEditionChanged
		private static List<IControlALockEdition> m_controlesLockEditionChangedNonAutorise = new List<IControlALockEdition>();
		private static void AjouterControleLockEditionChangedNonAutorise(IControlALockEdition ctrl)
		{
			if (!m_controlesLockEditionChangedNonAutorise.Contains(ctrl))
			{
				ctrl.OnChangeLockEdition += m_handlerLockEditionChangedNonAutorise;
				m_controlesLockEditionChangedNonAutorise.Add(ctrl);
			}
		}
		private static void ClearSurveillanceControlesLockEditionChangedNonAutorise()
		{
			foreach (IControlALockEdition c in m_controlesLockEditionChangedNonAutorise)
				c.OnChangeLockEdition -= m_handlerLockEditionChangedNonAutorise;
			m_controlesLockEditionChangedNonAutorise.Clear();
		}
		private static EventHandler m_handlerLockEditionChangedNonAutorise = new EventHandler(ctrl_LockEditionChangedNonAutorise);
		private static void ctrl_LockEditionChangedNonAutorise(object sender, EventArgs e)
		{
			if (typeof(IControlALockEdition).IsAssignableFrom(sender.GetType()))
			{
				IControlALockEdition ctrlALock = (IControlALockEdition)sender;
				if (!ctrlALock.LockEdition)
					ctrlALock.LockEdition = true;
			}
		}
		#endregion
		#region EnableChanged
		private static List<Control> m_controlesEnableChangedNonAutorise = new List<Control>();
		private static void AjouterControleEnableChangedNonAutorise(Control ctrl)
		{
			if (!m_controlesEnableChangedNonAutorise.Contains(ctrl))
			{
				ctrl.EnabledChanged += m_handlerEnableChangedNonAutorise;
				m_controlesEnableChangedNonAutorise.Add(ctrl);
			}
		}
		private static void ClearSurveillanceControlesEnabledChangedNonAutorise()
		{
			foreach (Control c in m_controlesEnableChangedNonAutorise)
				c.EnabledChanged -= m_handlerEnableChangedNonAutorise;
			m_controlesEnableChangedNonAutorise.Clear();
		}
		private static EventHandler m_handlerEnableChangedNonAutorise = new EventHandler(ctrl_EnableChangedNonAutorise);
		private static void ctrl_EnableChangedNonAutorise(object sender, EventArgs e)
		{
			Control ctrl = (Control)sender;
			if (ctrl.Enabled)
				ctrl.Enabled = false;
		}
		#endregion
		#region VisibleChanged
		private static List<Control> m_controlesVisibleChangedNonAutorise = new List<Control>();
		private static void AjouterControleVisibleChangedNonAutorise(Control ctrl)
		{
			if (!m_controlesVisibleChangedNonAutorise.Contains(ctrl))
			{
				ctrl.VisibleChanged += m_handlerVisibleChangedNonAutorise;
				m_controlesVisibleChangedNonAutorise.Add(ctrl);
			}
		}
		private static void ClearSurveillanceControlesVisibleChangedNonAutorise()
		{
			foreach (Control c in m_controlesVisibleChangedNonAutorise)
				c.VisibleChanged -= m_handlerVisibleChangedNonAutorise;
			m_controlesVisibleChangedNonAutorise.Clear();
		}
		private static EventHandler m_handlerVisibleChangedNonAutorise = new EventHandler(ctrl_VisibleChangedNonAutorise);
		private static void ctrl_VisibleChangedNonAutorise(object sender, EventArgs e)
		{
			Control ctrl = (Control)sender;
			if (ctrl.Visible)
				ctrl.Visible = false;
		}
		#endregion
		#endregion

		private Dictionary<Control, string> m_associations = new Dictionary<Control, string>();

		[Editor(typeof(CAssociationControlLicenceModulesEditor), typeof(UITypeEditor))]
		public virtual void SetModules(object extendee, string strModules)
		{
			if (extendee is Control)
			{
				Control ctrl = (Control)extendee;
				if (m_associations.ContainsKey(ctrl))
					m_associations[ctrl] = strModules;
				else
					m_associations.Add(ctrl, strModules);
			}
		}
		[Editor(typeof(CAssociationControlLicenceModulesEditor), typeof(UITypeEditor))]
		public virtual string GetModules(object extendee)
		{
			if (extendee is Control)
			{
				Control ctrl = (Control)extendee;
				if (m_associations.ContainsKey(ctrl))
					return m_associations[ctrl];
				return "";
			}
			return null;
		}
		
		#region IExtenderProvider Membres

		public bool CanExtend(object extendee)
		{
			if(extendee is Control)
				return true;
			return false;
		}

		#endregion


		public static class CSerializerModulesLicence
		{
			public const string c_separatorId = ";";
			public const string c_idAppModule = "A";
			public const string c_idClientModule = "C";


			public static List<CLicenceModuleAppPrtct> GetModulesApp(string strModulesSerial)
			{
				return CUtilAConfigModules.GetModulesApp(typeof(CConfigModulesTimos), GetIdsModulesApp(strModulesSerial).ToArray());
			}
			public static List<CLicenceModuleClientPrtct> GetModulesClient(string strModulesSerial)
			{
				return CUtilAConfigModules.GetModulesClients(typeof(CConfigModulesTimos), GetIdsModulesClient(strModulesSerial).ToArray());
			}
			public static string SerializeModules(List<CLicenceModulePrtct> modules)
			{
				List<string> ids = new List<string>();
				foreach (CLicenceModulePrtct m in modules)
					if (m is CLicenceModuleAppPrtct)
						ids.Add(CSerializerModulesLicence.c_idAppModule + m.Id);
					else if (m is CLicenceModuleClientPrtct)
						ids.Add(CSerializerModulesLicence.c_idClientModule + m.Id);

				if (ids.Count > 0)
					return String.Join(CSerializerModulesLicence.c_separatorId, ids.ToArray());
				else
					return "";
			}

			public static List<string> GetIdsModulesClient(string strModulesSerial)
			{
				List<string> strIdsModulesClient = new List<string>();
				string[] ids = strModulesSerial.Split(CSerializerModulesLicence.c_separatorId.ToCharArray());
				foreach (string strId in ids)
					if (strId.Length > 0 && strId.Substring(0, CSerializerModulesLicence.c_idClientModule.Length) == CSerializerModulesLicence.c_idClientModule)
						strIdsModulesClient.Add(strId.Substring(CSerializerModulesLicence.c_idClientModule.Length));
				return strIdsModulesClient;
			}
			public static List<string> GetIdsModulesApp(string strModulesSerial)
			{
				List<string> strIdsModulesApp = new List<string>();
				string[] ids = strModulesSerial.Split(CSerializerModulesLicence.c_separatorId.ToCharArray());
				foreach (string strId in ids)
					if (strId.Length > 1 && strId.Substring(0, CSerializerModulesLicence.c_idAppModule.Length) == CSerializerModulesLicence.c_idAppModule)
						strIdsModulesApp.Add(strId.Substring(CSerializerModulesLicence.c_idAppModule.Length));
				return strIdsModulesApp;
			}
		}
	}

	public delegate void ConfigureControlEvent(Control ctrl, ERestriction restrictionAppliquee, EventArgConfigureControl arg);
	public class EventArgConfigureControl
	{
		public EventArgConfigureControl()
		{

		}
		private bool m_bCancel = false;
		public bool Cancel
		{
			get
			{
				return m_bCancel;
			}
			set
			{
				m_bCancel = value;
			}
		}
	}

	public delegate void ExtModulesAssociatorEvent(EventArgConfigureControl arg);
	public class EventArgExtModulesAssociator
	{
		public EventArgExtModulesAssociator()
		{

		}
		private bool m_bCancel = false;
		public bool Cancel
		{
			get
			{
				return m_bCancel;
			}
			set
			{
				m_bCancel = value;
			}
		}
	}


}
