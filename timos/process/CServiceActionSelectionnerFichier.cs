using System;
using System.Windows.Forms;
using System.Diagnostics;

using sc2i.common;
using sc2i.multitiers.client;
using sc2i.process;
using sc2i.expression;
using sc2i.win32.common;
using System.IO;
using sc2i.documents;
using System.Threading;


namespace timos.process
{
	/// <summary>
	/// Description résumée de CServiceActionSelectionnerFichier.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CServiceActionSelectionnerFichier : CServiceSurClient
	{
		/// ///////////////////////////////////////////
		public override string IdService
		{
			get
			{
                return CActionSelectionFichierClient.c_idServiceSelectionFichierClient;
			}
		}

		public static void Autoexec()
		{
			CSessionClient.RegisterServiceSurClient ( new CServiceActionSelectionnerFichier() );
		}

        /// ///////////////////////////////////////////
        private CActionSelectionFichierClient m_actionSelection = null;
        private string m_strNomFichierSelectionne = "";

        /// ///////////////////////////////////////////
        private void ShowDialogFichier()
        {
            if (m_actionSelection.ForSave)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                try
                {
                    dlg.Title = m_actionSelection.MessageToDisplay;
                    dlg.Filter = m_actionSelection.FiltreToUse;
                    dlg.InitialDirectory = m_actionSelection.InitialDirectory;
                }
                catch { }
                if (dlg.ShowDialog(CTimosApp.Navigateur) == DialogResult.OK)
                    m_strNomFichierSelectionne = dlg.FileName;
                dlg.Dispose();
            }
            else
            {
                OpenFileDialog dlg = new OpenFileDialog();
                try
                {
                    dlg.Title = m_actionSelection.MessageToDisplay;
                    dlg.Filter = m_actionSelection.FiltreToUse;
                    dlg.InitialDirectory = m_actionSelection.InitialDirectory;
                }
                catch { }
                if (dlg.ShowDialog(CTimosApp.Navigateur) == DialogResult.OK)
                    m_strNomFichierSelectionne = dlg.FileName;
                dlg.Dispose();
            }
        }

        /// ///////////////////////////////////////////
        public override sc2i.common.CResultAErreur RunService(object parametre)
        {
            CResultAErreur result = CResultAErreur.True;
            if (!(parametre is CActionSelectionFichierClient))
            {
                result.EmpileErreur(I.T("Bad parameter value for service Select local file|20123"));
                return result;
            }
            m_actionSelection = parametre as CActionSelectionFichierClient;
            m_strNomFichierSelectionne = "";
            CTimosApp.Navigateur.Invoke((MethodInvoker)delegate
            {
                ShowDialogFichier();
            });
            result.Data = m_strNomFichierSelectionne;
            return result;

        }

        /*

		/// ///////////////////////////////////////////
		public override sc2i.common.CResultAErreur RunService(object parametre)
		{
			CResultAErreur result = CResultAErreur.True;
            if (!(parametre is CActionSelectionFichierClient))
            {
                result.EmpileErreur(I.T("Bad parameter value for service Select local file|20123"));
                return result;
            }
            CActionSelectionFichierClient action = parametre as CActionSelectionFichierClient;
            string strNomFichier = "";
            if (action.ForSave)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                try
                {
                    dlg.Title = action.MessageToDisplay;
                    dlg.Filter = action.FiltreToUse;
                    dlg.InitialDirectory = action.InitialDirectory;
                }
                catch { }
                if (dlg.ShowDialog() == DialogResult.OK)
                    strNomFichier = dlg.FileName;
                dlg.Dispose();
            }
            else
            {
                OpenFileDialog dlg = new OpenFileDialog();
                try
                {
                    dlg.Title = action.MessageToDisplay;
                    dlg.Filter = action.FiltreToUse;
                    dlg.InitialDirectory = action.InitialDirectory;
                }
                catch { }
                if (dlg.ShowDialog() == DialogResult.OK)
                    strNomFichier = dlg.FileName;
                dlg.Dispose();
            }
            result.Data = strNomFichier;
            return result;

		}*/

		

	}
}
