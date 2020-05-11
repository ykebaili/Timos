using System;
using System.Windows.Forms;
using System.Diagnostics;

using sc2i.common;
using sc2i.multitiers.client;
using sc2i.process;
using sc2i.expression;
using sc2i.win32.common;

namespace timos.process
{
	/// <summary>
	/// Description résumée de CServiceActionOuvrirFichier.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CServiceActionOuvrirFichier : CServiceSurClient
	{
		/// ///////////////////////////////////////////
		public override string IdService
		{
			get
			{
				return CInfoServiceClientOuvrirFichier.c_idServiceClientOuvrirFichier;
			}
		}

		public static void Autoexec()
		{
			CSessionClient.RegisterServiceSurClient ( new CServiceActionOuvrirFichier() );
		}

		/// ///////////////////////////////////////////
		public override sc2i.common.CResultAErreur RunService(object parametre)
		{
			CResultAErreur result = CResultAErreur.True;
			if ( !(parametre is CInfoServiceClientOuvrirFichier ) )
			{
				result.EmpileErreur (I.T( "Parameter type not compatible with 'open file' service|1080"));
				return result;
			}
			CInfoServiceClientOuvrirFichier info = (CInfoServiceClientOuvrirFichier)parametre;
			System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = info.CommandLine;
            process.StartInfo.Arguments = info.Arguments;
			process.StartInfo.UseShellExecute = true;
			process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
			try
			{
				process.Start();
				if (info.WaitForExit)
				{
					process.WaitForExit();
					result.Data = process.ExitCode;
				}
				else
					result.Data = 0;
			}
			catch (Exception ex )
			{
				result.EmpileErreur ( new CErreurException ( ex ) );
				result.EmpileErreur (I.T( "Error while opening file|1081"));
			}
			return result;
		}

		

	}
}
