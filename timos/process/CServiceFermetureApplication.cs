using System;
using System.Windows.Forms;
using System.Threading;

using sc2i.common;
using sc2i.multitiers.client;
using sc2i.process;
using sc2i.expression;
using sc2i.win32.common;

namespace timos.process
{
	/// <summary>
	/// Description résumée de CServiceFermetureApplication.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CServiceFermetureApplication : CServiceSurClientFermerApplication
	{

		public static void Autoexec()
		{
			CSessionClient.RegisterServiceSurClient ( new CServiceFermetureApplication() );
		}

		/// ///////////////////////////////////////////
		private void AfficheFenetreFermeture()
		{
			CFormFermetureAutomatique formFermeture = new CFormFermetureAutomatique();
			formFermeture.ShowDialog();
			try
			{
				CTimosApp.SessionClient.CloseSession();
			}
			catch{}
			Application.Exit();
		}

		/// ///////////////////////////////////////////
		public override sc2i.common.CResultAErreur RunService(object parametre)
		{
			CResultAErreur result = CResultAErreur.True;

			Thread th = new Thread ( new ThreadStart ( AfficheFenetreFermeture ) );
			th.Start();
			
			return result;
			
		}

		

	}
}
