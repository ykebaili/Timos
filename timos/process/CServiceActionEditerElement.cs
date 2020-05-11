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

namespace timos.process
{
	/// <summary>
	/// Description résumée de CServiceActionEditerElement.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CServiceActionEditerElement : CServiceSurClient
	{
		/// ///////////////////////////////////////////
		public override string IdService
		{
			get
			{
				return CActionEditerElement.c_idServiceClientEditerElement;
			}
		}

		public static void Autoexec()
		{
			CSessionClient.RegisterServiceSurClient ( new CServiceActionEditerElement() );
		}

		/// ///////////////////////////////////////////
        private CActionEditerElement.CParametreEditionElement m_parametreEdition = null;
        private CResultAErreur m_resultEdit = CResultAErreur.True;
        private string m_strCodeFormulaire = "";

        private void EditeElement()
        {
            CObjetDonneeAIdNumeriqueAuto objet = null;

            bool bIsNewContexte = false;
            CContexteDonnee contexteDonnee = CSc2iWin32DataClient.ContexteCourant;
            if (m_parametreEdition.IdVersionAForcer != contexteDonnee.IdVersionDeTravail)
            {
                contexteDonnee = (CContexteDonnee)CSc2iWin32DataClient.ContexteCourant.Clone();// GetNewContexteDonneeInSameThread(m_parametreEdition.IdSession, true);
                contexteDonnee.SetEnableAutoStructure ( true );
                contexteDonnee.SetVersionDeTravail(m_parametreEdition.IdVersionAForcer, false);
                bIsNewContexte = true;
            }
            objet = m_parametreEdition.ReferenceObjet.GetObjet(contexteDonnee) as CObjetDonneeAIdNumeriqueAuto;
            if (objet == null)
            {
                m_resultEdit.EmpileErreur(I.T("The object to edit doesn't exist|1078"));
                return ;
            }

            CReferenceTypeForm refTypeForm = null;
            if (m_strCodeFormulaire != string.Empty)
                refTypeForm = CFormFinder.GetRefFormToEdit(objet.GetType(), m_strCodeFormulaire);
            else
                refTypeForm = CFormFinder.GetRefFormToEdit(objet.GetType());

            if (refTypeForm == null)
            {
                m_resultEdit.EmpileErreur(I.T("The system is not able to edit elements from type @1|1076", m_parametreEdition.GetType().ToString()));
                return;
            }

            try
            {
                CFormEditionStandard form = refTypeForm.GetForm(objet) as CFormEditionStandard;
                if (form != null)
                    CFormNavigateurPopup.Show(form);//, CTimosApp.Navigateur);

            }
            catch (Exception e)
            {
                m_resultEdit.EmpileErreur(new CErreurException(e));
            }
            finally
            {
                if (bIsNewContexte)
                {
                    contexteDonnee.Dispose();
                    contexteDonnee = null;
                }
            }
        }
       

		/// ///////////////////////////////////////////
		public override sc2i.common.CResultAErreur RunService(object parametre)
		{
			CResultAErreur result = CResultAErreur.True;
			if ( !(parametre is CActionEditerElement.CParametreEditionElement ) )
			{
				result.EmpileErreur (I.T( "Parameter type imcompatible with 'edit element' service|1077"));
				return result;
			}
			CActionEditerElement.CParametreEditionElement parametreEdition = (CActionEditerElement.CParametreEditionElement)parametre;
            if (
                parametreEdition.DansNavigateurPrincipal && 
                parametreEdition.IdVersionAForcer == CSc2iWin32DataClient.ContexteCourant.IdVersionDeTravail )
            {
                CObjetDonnee objet = parametreEdition.ReferenceObjet.GetObjet(CSc2iWin32DataClient.ContexteCourant);
                if (objet == null)
                {
                    result.EmpileErreur(I.T("The object to edit doesn't exist|1078"));
                    return result;
                }
                return CTimosApp.Navigateur.EditeElement(objet, parametreEdition.DansNouvelOnglet, parametreEdition.CodeFormulaire);
            }

            m_parametreEdition = parametreEdition;
            m_strCodeFormulaire = parametreEdition.CodeFormulaire;
            m_resultEdit = CResultAErreur.True;
            Thread th = new Thread (new ThreadStart(EditeElement) );
			th.SetApartmentState ( ApartmentState.STA );
			th.Start();
			th.Join();

            return m_resultEdit;
		}

		

	}
}
