using System;
using System.Windows.Forms;

using sc2i.common;
using sc2i.multitiers.client;
using sc2i.process;
using sc2i.expression;
using sc2i.win32.common;
using sc2i.win32.data;	
using sc2i.data;

using sc2i.win32.data.navigation;
using System.Threading;
using sc2i.win32.navigation;
using sc2i.process.workflow;
using timos.process.workflow;

namespace timos.process
{
	/// <summary>
	/// Description résumée de CServiceActionAfficherEtapeWorkflow.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CServiceActionAfficherEtapeWorkflow : CServiceSurClient
	{
		/// ///////////////////////////////////////////
		public override string IdService
		{
			get
			{
                return CActionAfficheEtapeWorkflow.c_idServiceClientAfficheEtapeWorkflow;
			}
		}

		public static void Autoexec()
		{
			CSessionClient.RegisterServiceSurClient ( new CServiceActionAfficherEtapeWorkflow() );
		}

		/// ///////////////////////////////////////////
		public override CResultAErreur RunService(object parametre)
		{
			CResultAErreur result = CResultAErreur.True;
			if ( !(parametre is CActionAfficheEtapeWorkflow.CParametreAffichageEtapeWorkflow ) )
			{
				result.EmpileErreur (I.T( "Parameter type imcompatible with 'Display workflow' service|20589"));
				return result;
			}
            CActionAfficheEtapeWorkflow.CParametreAffichageEtapeWorkflow parametreEdition = (CActionAfficheEtapeWorkflow.CParametreAffichageEtapeWorkflow)parametre;
            
            CEtapeWorkflow etape = new CEtapeWorkflow ( CSc2iWin32DataClient.ContexteCourant );
            if ( etape.ReadIfExists ( parametreEdition.IdEtapeWorkflow ) )
            {
                CFormMain.GetInstance().DisplayEtapeFromOtherThread(etape, parametreEdition.DansNouvelOnglet);
            }

            return result;
            
		}

		

	}
}
