using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Diagnostics;

using System.Windows.Forms;
using sc2i.documents;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;
using sc2i.data.dynamic;
using sc2i.win32.data.dynamic;

namespace timos
{
	/// <summary>
	/// Description résumée de CEditeurEtatCrystal.
	/// </summary>
	public class CEditeurEtatCrystal
	{
		public static void EditeEtat ( string strFichierDonnees, string strNomFichierEtat )
		{
			CResultAErreur result = CResultAErreur.True;
			string strExe = Application.ExecutablePath;
			strExe = strExe.Substring(0, strExe.LastIndexOf('\\')+1);
			strExe += "Crystal\\sc2i.win32.crystal.exe";
			if ( !File.Exists ( strExe ) )
			{
				CFormAlerte.Afficher(I.T("Report Design Component not installed|30207"), EFormAlerteType.Erreur);
				return ;
			}

			try
			{

				System.Diagnostics.Process process = new System.Diagnostics.Process();
				process.StartInfo.FileName = strExe;
				process.StartInfo.Arguments =strFichierDonnees+" "+strNomFichierEtat;
				process.StartInfo.UseShellExecute = true;
				process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
				process.Start();
				process.WaitForExit();
				try
				{
					File.Delete ( strFichierDonnees );
				}
				catch{}
			}					
			catch (Exception ex )
			{
				result.EmpileErreur ( new CErreurException ( ex ) );
				result.EmpileErreur (I.T("Editor launching error|30208"));
				CFormAlerte.Afficher ( result.Erreur );							
			}
		}
	}
}
