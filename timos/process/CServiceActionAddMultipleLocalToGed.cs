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
using System.Collections.Generic;
using sc2i.win32.process;
using sc2i.win32.data;


namespace timos.process
{
	/// <summary>
	/// Description résumée de CServiceActionSelectionnerFichier.
	/// </summary>
	[AutoExec("Autoexec")]
    public class CServiceActionAddMultipleLocalToGed : CServiceSurClient
	{
		/// ///////////////////////////////////////////
		public override string IdService
		{
			get
			{
                return CActionCopierMultiLocalDansGed.c_idServiceSelectMultiForGed;
			}
		}

		public static void Autoexec()
		{
            CSessionClient.RegisterServiceSurClient(new CServiceActionAddMultipleLocalToGed());
		}

        /// ///////////////////////////////////////////
        private IEnumerable<int> m_listeCategories = null;
        private IEnumerable<CActionCopierMultiLocalDansGed.CInfoFichierToGed> m_listeFichiersSelect = null;

        /// ///////////////////////////////////////////
        private void ShowDialogSelect()
        {
            m_listeFichiersSelect = CFormAddMultipleToGed.GetInfosToAdd(m_listeCategories);
        }

        /// ///////////////////////////////////////////
        public override sc2i.common.CResultAErreur RunService(object parametre)
        {
            CResultAErreur result = CResultAErreur.True;
            if (!(parametre is IEnumerable<int>))
            {
                result.EmpileErreur("Bad parameter value for service Multi documents to EDM");
                return result;
            }
            m_listeCategories = parametre as IEnumerable<int>;
            m_listeFichiersSelect = null;
            CTimosApp.Navigateur.Invoke((MethodInvoker)delegate
            {
                ShowDialogSelect();
            });
            result.Data = m_listeFichiersSelect;
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
