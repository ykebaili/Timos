using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Lys.Licence;

namespace timos
{

	public class CAssociationControlLicenceModulesEditor : UITypeEditor
	{

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			string strModules = (string)value;
			CFormEditionAssociationsControlModules frm = new CFormEditionAssociationsControlModules();
			List<CLicenceModuleAppPrtct> modulesApp = CExtModulesAssociator.CSerializerModulesLicence.GetModulesApp(strModules);
			List<CLicenceModuleClientPrtct> modulesClient = CExtModulesAssociator.CSerializerModulesLicence.GetModulesClient(strModules);
			string strSujetInvoke = "inconnu";
			if(context.Instance != null)
				if (context.Instance.GetType().IsArray)
				{
					List<string> snames = new List<string>();
					object[] oCtrls = (object[])context.Instance;
					foreach (object o in oCtrls)
						if (o is Control)
							snames.Add(((Control)o).Name);
					if (snames.Count > 0)
						strSujetInvoke = String.Join(" ", snames.ToArray());
				}
				else if (context.Instance is Control)
					strSujetInvoke = ((Control)context.Instance).Name;

			frm.Initialiser(strSujetInvoke, modulesApp, modulesClient);


			IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
			if (edSvc != null)
				edSvc.ShowDialog(frm);

			List<CLicenceModulePrtct> modulesFinaux = new List<CLicenceModulePrtct>();
			modulesApp = frm.ModulesApplicatifSelec;
			foreach (CLicenceModuleAppPrtct mApp in modulesApp)
				modulesFinaux.Add((CLicenceModulePrtct)mApp);

			modulesClient = frm.ModulesClientSelec;
			foreach (CLicenceModuleClientPrtct mCli in modulesClient)
				modulesFinaux.Add((CLicenceModulePrtct)mCli);

			return CExtModulesAssociator.CSerializerModulesLicence.SerializeModules(modulesFinaux);
		}
	}
}
