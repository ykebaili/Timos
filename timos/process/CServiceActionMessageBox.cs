using System;
using System.Windows.Forms;

using sc2i.common;
using sc2i.multitiers.client;
using sc2i.process;
using sc2i.expression;
using sc2i.win32.common;
using System.Threading;

namespace timos.process
{
	/// <summary>
	/// Description résumée de CServiceActionMessageBox.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CServiceActionMessageBox : CServiceSurClient
	{
		/// ///////////////////////////////////////////
		public override string IdService
		{
			get
			{
				return CActionMessageBox.c_idServiceClientMessageBox;
			}
		}

		public static void Autoexec()
		{
			CSessionClient.RegisterServiceSurClient ( new CServiceActionMessageBox() );
		}

        //----------------------------------------------------------------------------
        private CResultAErreur m_result = CResultAErreur.True;
        private CActionMessageBox m_action;
        public void ShowDialogMessageBox()
        {

            EFormAlerteBoutons boutons = EFormAlerteBoutons.Ok;
            EFormAlerteType typeAlerte = EFormAlerteType.Exclamation;
            switch (m_action.TypeBox)
            {
                case CActionMessageBox.TypeMessageBox.OK:
                    boutons = EFormAlerteBoutons.Ok;
                    break;
                case CActionMessageBox.TypeMessageBox.OuiNon:
                    typeAlerte = EFormAlerteType.Question;
                    boutons = EFormAlerteBoutons.OuiNon;
                    break;
                case CActionMessageBox.TypeMessageBox.OKAnnuler:
                    boutons = EFormAlerteBoutons.OkAbandonner;
                    break;
            }
            DialogResult dResult = DialogResult.OK;
            CTimosApp.Navigateur.Invoke((MethodInvoker)delegate
            {
                dResult = CFormAlerte.Afficher(m_action.MessageToDisplay, boutons, typeAlerte, m_action.SecondesMaxiAffichage, CTimosApp.Navigateur);
            });
            m_result.Data = C2iDialogResult.Get2iDialogResultFromDialogResult(dResult);
        }


        //----------------------------------------------------------------------------
        public override sc2i.common.CResultAErreur RunService(object parametre)
		{
            CResultAErreur result = CResultAErreur.True;

            CActionMessageBox action = parametre as CActionMessageBox;
            if (action == null)
            {
                result.EmpileErreur(I.T("Parameter type incompatible with 'Message box' service|1079"));
                return result;
            }
            using (C2iSponsor sponsor = new C2iSponsor())
            {
                m_action = action;
                sponsor.Register(m_action);

                Thread th = new Thread(new ThreadStart(ShowDialogMessageBox));
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
                th.Join();
                return m_result;
            }

		}

	}
}
