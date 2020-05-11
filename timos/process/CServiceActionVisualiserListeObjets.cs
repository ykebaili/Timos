using System;
using System.Windows.Forms;

using sc2i.common;
using sc2i.multitiers.client;
using sc2i.process;
using sc2i.expression;
using sc2i.win32.common;
using sc2i.win32.data;	
using timos.process;
using sc2i.data;
using sc2i.win32.data.navigation;
using System.Threading;

namespace timos.process
{
	/// <summary>
	/// Description résumée de CServiceActionVisualiserListeObjets.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CServiceActionVisualiserListeObjets : CServiceSurClient
	{
		/// ///////////////////////////////////////////
		public override string IdService
		{
			get
			{
				return CActionVisualiserListeObjetsDonnee.c_idServiceVisualisationListeObjetsDonnee;
			}
		}

		public static void Autoexec()
		{
			CSessionClient.RegisterServiceSurClient ( new CServiceActionVisualiserListeObjets() );
		}

		/// ///////////////////////////////////////////
		private CParametreServiceVisuListeObjets m_parametreVisu = null;
		private CResultAErreur m_resultEdit = CResultAErreur.True;
		private void AfficheListe (  )
		{

			Type typeForm = CFormFinder.GetTypeFormToList(m_parametreVisu.TypeElements);
			if ( typeForm == null || !typeForm.IsSubclassOf(typeof(CFormListeStandard)))
			{
				m_resultEdit.EmpileErreur(I.T( "The system can not list elements of type @1|1082", m_parametreVisu.TypeElements.ToString()));
				return ;
			}
			try
			{
				CFormListeStandard form = (CFormListeStandard)Activator.CreateInstance ( typeForm, new object[]{});
				form.FiltreDeBase = m_parametreVisu.Filtre;
				if ( m_parametreVisu.TitreFenetre != "" )
					form.TitreForce = m_parametreVisu.TitreFenetre;
				form.ContexteUtilisation = m_parametreVisu.ContexteFenetre;
				CFormNavigateurPopup.Show ( form, CTimosApp.Navigateur );
			}
			catch ( Exception e )
			{
				m_resultEdit.EmpileErreur ( new CErreurException (e));
			}
		}

		/// ///////////////////////////////////////////
		public override sc2i.common.CResultAErreur RunService(object parametre)
		{
			CResultAErreur result = CResultAErreur.True;
			if ( !(parametre is CParametreServiceVisuListeObjets ) )
			{
				result.EmpileErreur (I.T( "Parameter type is not compatible with 'Visualise list' service|1083"));
				return result;
			}
			m_parametreVisu = (CParametreServiceVisuListeObjets)parametre;
			Thread th = new Thread (new ThreadStart(AfficheListe) );
			th.SetApartmentState ( ApartmentState.STA );
			th.Start();
			th.Join();
			
			return m_resultEdit;
		}

		

	}
}
