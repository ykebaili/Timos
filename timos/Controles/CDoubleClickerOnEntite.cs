using System;
using System.Collections.Generic;
using System.Text;
using sc2i.common;
using sc2i.win32.data.dynamic;
using sc2i.win32.data.navigation;
using sc2i.data;

namespace timos.Controles
{

	[AutoExec("Autoexec")]
	public static class CDoubleClickerOnEntite
	{
		public static void Autoexec()
		{
		}

		//------------------------------------------------------------------------------------------
		static void CControlListeForFormulaire_AfficheEntiteFromListeForFormulaire(object entite)
		{
			try
			{
				if (!(entite is CObjetDonnee))
					return;
                //Type typeForm = CFormFinder.GetTypeFormToEdit(entite.GetType());
                //if (typeof(CFormEditionStandard).IsAssignableFrom ( typeForm))
                //{
                //    CFormEditionStandard form = (CFormEditionStandard)Activator.CreateInstance(typeForm, (CObjetDonnee)entite);
                //    CTimosApp.Navigateur.AffichePage(form);
                //}
                CReferenceTypeForm refTypeForm = CFormFinder.GetRefFormToEdit(entite.GetType());
                if (refTypeForm != null)
                {
                    CFormEditionStandard form = refTypeForm.GetForm((CObjetDonneeAIdNumeriqueAuto)entite) as CFormEditionStandard;
                    if (form != null)
                        CTimosApp.Navigateur.AffichePage(form);
                }

			}
			catch
			{
			}
		}
	}
}
