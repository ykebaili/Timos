using System;
using System.Threading;

using sc2i.common;
using sc2i.multitiers.client;
using sc2i.win32.common;
using timos.client;
using System.Windows.Forms;

namespace timos
{
	/// <summary>
	/// Description résumée de CServicePopupProgressionTimos.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CServicePopupProgressionTimos : CServiceSurClient //, IServiceSurClientPopupProgression
	{
		public CServicePopupProgressionTimos()
		{
		}

		public static void Autoexec()
		{
			CSessionClient.RegisterServiceSurClient ( new CServicePopupProgressionTimos() );
		}

		//Lance le service sur le poste client
		public override CResultAErreur RunService ( object parametre )
		{
			CResultAErreur result = CResultAErreur.True;
			return result;
		}

		public override string IdService
		{
			get
			{
				return "PROGRESS_TMP";
				//return typeof(IServiceSurClientPopupProgression).ToString();
			}
		}

		/// ///////////////////////////////////////////////
		private CFormProgressTimos m_lastForm = null;
		private void StartPopup()
		{
			m_lastForm = new CFormProgressTimos();
			m_lastForm.TopMost = true;
			m_lastForm.ShowDialog();
		}
		

		/// ///////////////////////////////////////////////
		public IIndicateurProgression GetNewIndicateurAndPopup ( )
		{
			Thread th = new Thread(new ThreadStart(StartPopup));
			m_lastForm = null;
			th.Start();
			while ( m_lastForm == null )
				Thread.Sleep(100);
			return m_lastForm;
		}

		/// ///////////////////////////////////////////////
		public void EndIndicateur ( IIndicateurProgression indicateur )
		{
            if (indicateur is System.Windows.Forms.Form)
            {
                ((System.Windows.Forms.Form)indicateur).Invoke((MethodInvoker)delegate
                {
                    ((System.Windows.Forms.Form)indicateur).Hide();
                });
            }
		}

		/// ///////////////////////////////////////////////
		public void AfficheErreur ( CPileErreur erreur )
		{
			CFormAlerte.Afficher ( erreur );
		}


	}
}
