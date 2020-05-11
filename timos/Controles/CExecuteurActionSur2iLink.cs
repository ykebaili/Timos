using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using sc2i.common;
using sc2i.data;
using sc2i.custom;
using sc2i.data.dynamic;
using sc2i.process;
using sc2i.multitiers.client;
using sc2i.win32.common;
using sc2i.win32.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.formulaire;
using sc2i.expression;
using sc2i.formulaire.win32;
using System.Drawing;
using timos.Controles.ActionsSurLink;


namespace timos
{

	/// <summary>
	/// Description résumée de CExecuteurActionSur2iLink.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CExecuteurActionSur2iLink
	{
        
        /// //////////////////////////////////////////////////////////////////
		public static void Autoexec()
		{
			/*sc2i.win32.data.dynamic.CCreateur2iFormulaire.AfterCreateControl += new sc2i.win32.data.dynamic.AfterModifyControlEventHandler(CCreateur2iFormulaire_AfterCreateControl);
			sc2i.win32.data.dynamic.CCreateur2iFormulaire.AfterChangeElementEdite += new sc2i.win32.data.dynamic.AfterModifyControlEventHandler(CCreateur2iFormulaire_AfterChangeElementEdite);
			sc2i.formulaire.win32.CCreateur2iFormulaireV2.AfterCreateControl += new sc2i.formulaire.win32.AfterModifyControlEventHandler(CCreateur2iFormulaire_AfterCreateControl);
			sc2i.formulaire.win32.CCreateur2iFormulaireV2.AfterChangeElementEdite += new sc2i.formulaire.win32.AfterModifyControlEventHandler(CCreateur2iFormulaire_AfterChangeElementEdite);
			*/
			sc2i.formulaire.win32.CExecuteurActionSur2iLink.MethodeExec = new sc2i.formulaire.win32.ExecuteActionSur2iLink(ExecuteAction);
		}

		

		private class CInfoLinkLabel
		{
			public readonly C2iWndLink WndLink;
			public readonly object Cible;

			public CInfoLinkLabel(C2iWndLink link, object cible)
			{
				Cible = cible;
				WndLink = link;
			}
		}
		
		/*/// //////////////////////////////////////////////////////////////////
		private static void CCreateur2iFormulaire_AfterCreateControl ( Control ctrl, C2iWnd wnd, object elementEdite )
		{
			if ( wnd is C2iWndLink && ctrl is LinkLabel )
			{
				ctrl.Tag = new CInfoLinkLabel((C2iWndLink)wnd, elementEdite);
				((LinkLabel)ctrl).LinkClicked += new LinkLabelLinkClickedEventHandler(CExecuteurActionSur2iLink_Click);
			}
		}

		static void CCreateur2iFormulaire_AfterChangeElementEdite(Control ctrl, C2iWnd wnd, object elementEdite)
		{
			if (wnd is C2iWndLink && ctrl is LinkLabel)
			{
				ctrl.Tag = new CInfoLinkLabel((C2iWndLink)wnd, elementEdite);
			}
		}*/

		/*/// //////////////////////////////////////////////////////////////////
		private static void CExecuteurActionSur2iLink_Click ( object sender, LinkLabelLinkClickedEventArgs args )
		{
			if (sender is LinkLabel && ((LinkLabel)sender).Tag is CInfoLinkLabel)
			{
				CInfoLinkLabel info = (CInfoLinkLabel)((LinkLabel)sender).Tag;
				C2iWndLink link = info.WndLink;
				object cible = info.Cible;
				CResultAErreur result = CResultAErreur.True;
				if ( link.ActionAssociee != null )
				{
					Form frm = ((Control)sender).FindForm();
					if (cible == null)
					{
						if (frm != null && frm is IFormEditObjetDonnee)
							cible = ((IFormEditObjetDonnee)frm).GetObjetEdite();
					}
					if (frm != null && frm is CFormEditionStandard)
					{
						if (((CFormEditionStandard)frm).EtatEdition)
						{
							if (CFormAlerte.Afficher(I.T("This action will save your data. Continue ?|1253"),
								EFormAlerteType.Question) == DialogResult.No)
								return;
							if (!((CFormEditionStandard)frm).OnClickValider())
								return;
							((CFormEditionStandard)frm).OnClickModifier();
						}

					}
					if ( frm != null && frm is CFormListeStandard )
					{
						if ( link.ActionAssociee.GetType() == typeof ( CActionSur2iLinkAfficheFormulaireCustom ) ||
							link.ActionAssociee.GetType() == typeof ( CActionSur2iLinkAfficherFormulaire ) ||
							link.ActionAssociee.GetType() == typeof ( CActionSur2iLinkAfficherListe ))
								cible = ((CFormListeStandard)frm).ElementSelectionne;
						else if ( link.ActionAssociee.GetType() == typeof ( CActionSur2iLinkExecuterProcess ) )
								cible = ((CFormListeStandard)frm).ElementsCoches;
					}
					result = ExecuteAction(link.ActionAssociee, cible);
					if ( !result )
						CFormAlerte.Afficher ( result.Erreur );
				}
			}
		}*/
		
		/// <summary>
		/// //////////////////////////////////////////////////////////////////
		/// </summary>
		/// <param name="action"></param>
		/// <returns></returns>
		public static CResultAErreur ExecuteAction ( object sender, CActionSur2iLink action, object objetCible )
		{
			CResultAErreur result = CResultAErreur.True;
            Form frm = null;

			if (!action.AutoriserEnEdition && sender != null && sender is Control)
			{
				frm = ((Control)sender).FindForm();
				object cible = objetCible;
				if (cible == null)
				{
					if (frm != null && frm is IFormEditObjetDonnee)
						cible = ((IFormEditObjetDonnee)frm).GetObjetEdite();
				}
				if (frm != null && frm is IFormEditObjetDonnee)
				{
                    if (((IFormEditObjetDonnee)frm).EtatEdition)
					{
						if (CFormAlerte.Afficher(I.T("This action will save your data. Continue ?|1253"),
							EFormAlerteType.Question) == DialogResult.No)
							return result;
                        if (!((IFormEditObjetDonnee)frm).ValiderModifications())
							return result;
                        CObjetDonnee obj = ((IFormEditObjetDonnee)frm).GetObjetEdite();
						if (obj != null)
						{
							if (cible is CObjetDonnee)
								cible = ((CObjetDonnee)cible).GetObjetInContexte(obj.ContexteDonnee);
						}
						//((CFormEditionStandard)frm).OnClickModifier();
					}

				}
				if (frm != null && frm is CFormListeStandard)
				{
                    if (
                        action.GetType() == typeof(CActionSur2iLinkAfficherFormulaire) ||
                        action.GetType() == typeof(CActionSur2iLinkAfficherListe))
                        cible = ((CFormListeStandard)frm).ElementSelectionne;
                    else
                    {
                        CActionSur2iLinkAfficheFormulaireCustom actionForm = action as CActionSur2iLinkAfficheFormulaireCustom;
                        if (actionForm != null)
                        {
                            cible = ((CFormListeStandard)frm).ElementSelectionne;
                            CFormulaire formulaire = new CFormulaire(CContexteDonneeSysteme.GetInstance());
                            if (formulaire.ReadIfExists(actionForm.IdFormulaireInDb))
                            {
                                if (formulaire.ElementEditeIsArray)
                                    cible = ((CFormListeStandard)frm).ElementsCoches;
                            }
                        }
                        else if (action.GetType() == typeof(CActionSur2iLinkExecuterProcess))
                            cible = ((CFormListeStandard)frm).ElementsCoches;
                    }
				}
				objetCible = cible;
			}
            if (action is CActionSur2iLinkAfficherFormulaire)
                return ExecuteActionFormulaire((CActionSur2iLinkAfficherFormulaire)action, objetCible);
            else if (action is CActionSur2iLinkAfficherListe)
                return ExecuteActionListe((CActionSur2iLinkAfficherListe)action, objetCible);
            else if (action is CActionSur2iLinkExecuterProcess)
            {
                result = ExecuteActionProcess((CActionSur2iLinkExecuterProcess)action, objetCible);
                CFormEditionStandard frmStd = frm as CFormEditionStandard;
                if (frmStd != null)
                {
                    try//La fenêtre peut être fermée par le process, donc ça peut faire des erreurs
                    {
                        frmStd.RefillDialog();
                    }
                    catch { }
                }
                else if (frm == CFormMain.GetInstance())
                {
                    CFormMain.GetInstance().RefreshPanelEtapeWorkflow();
                }
                return result;

            }
            else if (action is CActionSur2iLinkAfficheFormulaireCustom)
                return ExecuteActionFormulaireCustom((CActionSur2iLinkAfficheFormulaireCustom)action, objetCible);
            else if (action is CActionSur2iLinkAfficherEntite)
                return ExecuteActionAfficherEntite((CActionSur2iLinkAfficherEntite)action, objetCible);
            else if (action is CActionSur2iLinkMenuDeroulant)
                return ExecuteActionMenuDeroulant((CActionSur2iLinkMenuDeroulant)action, sender, objetCible);
            else if (action is CActionSur2iLinkFormulairePopup)
                return ExecuteActionFormulairePopup((CActionSur2iLinkFormulairePopup)action, sender, objetCible);

			result = CResultAErreur.True;
			result.EmpileErreur(I.T("Action not managed|30076"));
			return result;
		}


		//////////////////////////////////////////////////////////////////
        /// <summary>
        /// Affiche un Formulaire Standard de l'application. Tous les DynamicForm entre autre
        /// </summary>
        /// <param name="action"></param>
        /// <param name="objetCible"></param>
        /// <returns></returns>
		protected static CResultAErreur ExecuteActionFormulaire ( CActionSur2iLinkAfficherFormulaire action, object objetCible )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				Form frm = (Form)Activator.CreateInstance ( action.TypeFormulaire, new object[0] );
				// Initialise le contexte d'utilisation du Formulaire
                if ( frm is IElementAContexteUtilisation )
					((IElementAContexteUtilisation)frm).ContexteUtilisation = action.ContexteForm;
                // Initialise les Paramètres du formulaire
                if(frm is IFormDynamiqueAParametres)
                {   
                    // Récupère les paramètres évalués de l'action
                    result = action.GetValeursParametres(objetCible);
					if (!result)
						return result;
                    Dictionary<string, object> dicNomParametreValeur = result.Data as Dictionary<string, object>;
					if (dicNomParametreValeur != null)
					{
						result = ((IFormDynamiqueAParametres)frm).SetParametres(dicNomParametreValeur);
						if (!result)
							return result;
					}
                }
				if ( frm is IFormNavigable )
					CTimosApp.Navigateur.AffichePage ( (IFormNavigable)frm );
				else
					frm.ShowDialog();
			}
			catch ( Exception e )
			{
				result.EmpileErreur ( new CErreurException ( e ) );
			}
			return result;
		}

		/// //////////////////////////////////////////////////////////////////
		protected static CResultAErreur ExecuteActionListe ( CActionSur2iLinkAfficherListe action, object objetCible )
		{
			CResultAErreur result = CResultAErreur.True;
			CFiltreDynamique filtre = action.Filtre;
			if ( filtre == null || filtre.TypeElements == null )
			{
				result.EmpileErreur(I.T("Link parameter error : filter is null|30077"));
				return result;
			}

			if ( objetCible != null )
			{
                CObjetPourSousProprietes objetPourSousProp = null;
                objetPourSousProp = new CObjetPourSousProprietes(objetCible);
				IVariableDynamique variable = CActionSur2iLinkAfficherListe.AssureVariableElementCible ( filtre, objetPourSousProp );
				/*if ( variable.TypeDonnee.TypeDotNetNatif != objetCible.GetType() )
				{
					result.EmpileErreur(I.T("Expected type in the filter does not correspond to object type|30078"));
					return result;
				}*/
                if (variable != null)
                    filtre.SetValeurChamp(variable.IdVariable, objetCible);
			}
			result = filtre.GetFiltreData();
			if ( !result )
			{
				result.EmpileErreur ( I.T("Filter error|30079"));
				return result;
			}
			CFiltreData filtreData = (CFiltreData)result.Data;
			Type tp = CFormFinder.GetTypeFormToList ( filtre.TypeElements );
			try
			{
				if ( tp != null ||tp.IsSubclassOf(typeof(CFormListeStandard)) )
				{
					CFormListeStandard form = ( CFormListeStandard )Activator.CreateInstance ( tp, new object[0] );
					CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression ( objetCible);
					ctxEval.AttacheObjet ( typeof(CContexteDonnee ) , CSc2iWin32DataClient.ContexteCourant );
					if ( action.FormuleContexte != null )
					{
						result = action.FormuleContexte.Eval ( ctxEval );
						if ( !result )
						{
							result.EmpileErreur(I.T("Form context evaluation error|30080"));
							return result;
						}
						if ( result.Data != null )
							form.ContexteUtilisation = result.Data.ToString();
					}
					if(  action.FormuleTitre != null )
					{
						result = action.FormuleTitre.Eval ( ctxEval );
						if ( !result )
						{
							result.EmpileErreur(I.T("Form title evaluation error|30081"));
							return result;
						}
						if ( result.Data != null )
							form.TitreForce = result.Data.ToString();
					}
					form.FiltreDeBase = filtreData;
                    form.AffectationsPourNouveauxElements = action.Affectations;
                    form.ObjetReferencePourAffectationsInitiales = objetCible;
                    
                    form.BoutonAjouterVisible = action.ShowBoutonAjouter;
                    form.BoutonModifierVisible = action.ShowBoutonDetail;
                    form.BoutonSupprimerVisible = action.ShowBoutonSupprimer;
                    if (action.IdFiltreDynamiqueAUtiliser >= 0)
                    {
                        CFiltreDynamiqueInDb filtretoUse = new CFiltreDynamiqueInDb(CContexteDonneeSysteme.GetInstance());
                        if (filtretoUse.ReadIfExists(action.IdFiltreDynamiqueAUtiliser))
                        {
                            CFiltreDynamique filtreDyn = filtretoUse.Filtre;
                            if (filtreDyn != null)
                            {
                                CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(objetCible);
                                foreach (CFormuleNommee formule in action.ValeursVariablesFiltre)
                                {
                                    if (formule.Formule != null)
                                    {
                                        CResultAErreur res = formule.Formule.Eval(ctx);
                                        if (res)
                                        {
                                            try
                                            {
                                                string strId = formule.Id;
                                                filtreDyn.SetValeurChamp(strId, res.Data);
                                            }
                                            catch { }
                                        }
                                    }
                                }
                                form.FiltrePrefere = filtreDyn;
                            }
                        }
                            

                    }
                    if (action.ActionSurDetail != null)
                    {
                        CExecuteurActionSurPanelListeSpeedStandard executeur = new CExecuteurActionSurPanelListeSpeedStandard(action.ActionSurDetail, form);
                        form.SetModifierElementDelegate(new CPanelListeSpeedStandard.ModifierElementDelegate(executeur.ExecuteAction));
                    }
					CTimosApp.Navigateur.AffichePage ( form );
				}
				else
					result.EmpileErreur(I.T("Not avaliable|30082"));
			}
			catch ( Exception e )
			{
				result.EmpileErreur ( new CErreurException ( e ) );
			}
			return result;
		}

        

		/// //////////////////////////////////////////////////////////////////
		protected static CResultAErreur ExecuteActionAfficherEntite ( CActionSur2iLinkAfficherEntite action, object objetCible )
		{
			CResultAErreur result = CResultAErreur.True;
			C2iExpression formuleElement = action.FormuleElement;
			if ( formuleElement == null )
			{
                result.EmpileErreur(I.T("Link parameter error : entitty formula is null|30083"));
				return result;
			}

			CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression ( objetCible);
			ctxEval.AttacheObjet ( typeof(CContexteDonnee ) , CSc2iWin32DataClient.ContexteCourant );
			result =  formuleElement.Eval ( ctxEval );
			if ( !result )
			{
                result.EmpileErreur(I.T("Element evaluation error|30084"));
				return result;
			}

			if ( result.Data == null )
			{
                result.EmpileErreur(I.T("Not avaliable|30082"));
				return result;
			}
            object objetEdite = result.Data;

			//Type tp = CFormFinder.GetTypeFormToEdit ( result.Data.GetType() );
            string strCodeFormulaire = "";
            if (action.FormuleCodeFormulaire != null)
            {
                result = action.FormuleCodeFormulaire.Eval(ctxEval);
                if (result && result.Data != null)
                    strCodeFormulaire = result.Data.ToString();
            }
            CReferenceTypeForm refTypeForm = null;
            if(strCodeFormulaire == "")
                refTypeForm = CFormFinder.GetRefFormToEdit(objetEdite.GetType());
            else
                refTypeForm = CFormFinder.GetRefFormToEdit(objetEdite.GetType(), strCodeFormulaire);

			try
			{
                if (refTypeForm != null )
				{
					//CFormEditionStandard form = ( CFormEditionStandard )Activator.CreateInstance ( tp, new object[]{result.Data} );
                    CFormEditionStandard form = refTypeForm.GetForm((CObjetDonneeAIdNumeriqueAuto)objetEdite) as CFormEditionStandard;
					if ( action.FormuleContexte != null )
					{
						result = action.FormuleContexte.Eval ( ctxEval );
						if ( !result )
						{
                            result.EmpileErreur(I.T("Form context evaluation error|30080"));
							return result;
						}
						if ( result.Data != null )
							form.ContexteUtilisation = result.Data.ToString();
					}
					if(  action.FormuleTitre != null )
					{
						result = action.FormuleTitre.Eval ( ctxEval );
						if ( !result )
						{
                            result.EmpileErreur(I.T("Form title evaluation error|30081"));
							return result;
						}
						/*if ( result.Data != null )
							form.TitreForce = result.Data.ToString();*/
					}
					CTimosApp.Navigateur.AffichePage ( form );
				}
				else
                    result.EmpileErreur(I.T("Not avaliable|30082"));
			}
			catch ( Exception e )
			{
				result.EmpileErreur ( new CErreurException ( e ) );
			}
			return result;
		}

        /// //////////////////////////////////////////////////////////////////
        protected static CResultAErreur AffecteVariablesToProcess(CActionSur2iLinkExecuterProcess action,
            CProcess process,
            object cible)
        {
            CResultAErreur result = CResultAErreur.True;
            CContexteEvaluationExpression ctx = new CContexteEvaluationExpression ( cible );
            foreach (CFormuleNommee formule in action.FormulesPourParametres)
            {
                if (formule.Formule != null)
                {
                    result = formule.Formule.Eval(ctx);
                    if (!result)
                    {
                        result.EmpileErreur(I.T("Error while evaluating parameter @1|20128", formule.Libelle));
                        return result;
                    }
                    bool bVariableFound = false;
                    foreach (CVariableDynamique variable in process.ListeVariables)
                    {
                        if (variable.Nom == formule.Libelle)
                        {
                            process.SetValeurChamp(variable.IdVariable, result.Data);
                            bVariableFound = true;
                            break;
                        }
                    }
                    if (!bVariableFound)
                    {
                        result.EmpileErreur(I.T("Process variable @1 doesn't exists|20129", formule.Libelle));
                        return result;
                    }
                }
            }
            return result;
        }

		/// //////////////////////////////////////////////////////////////////
		protected static CResultAErreur ExecuteActionProcess ( CActionSur2iLinkExecuterProcess action, object objetCible )
		{
			CResultAErreur result = CResultAErreur.True;
			CProcessInDb process = new CProcessInDb ( CSc2iWin32DataClient.ContexteCourant );
			if ( process.ReadIfExists ( action.IdProcessInDb ) )
			{
                CProcess processToExecute = process.Process;
                result = AffecteVariablesToProcess(action, processToExecute, objetCible);
                if (!result)
                    return result;
				CInfoDeclencheurProcess infoDecl =  new CInfoDeclencheurProcess ( TypeEvenement.Manuel );
				CReferenceObjetDonnee refObj = null;
                object cibleProcess = objetCible;
                if (cibleProcess is CDefinitionMultiSourceForExpression)
                    cibleProcess = ((CDefinitionMultiSourceForExpression)cibleProcess).ObjetPrincipal;
                if (cibleProcess != null && process.TypeCible != null)
				{
                    if (cibleProcess.GetType().IsArray)
					{
						ArrayList lstRefs = new ArrayList();
                        foreach (object cible in (Array)cibleProcess)
						{
							if ( process.TypeCible.IsAssignableFrom ( cible.GetType() ) && cible is CObjetDonnee)
								lstRefs.Add ( new CReferenceObjetDonnee ( (CObjetDonnee)cible) );
						}
                        if (lstRefs.Count == 0)
                            result.EmpileErreur(I.T("No element selected for requested action|30085"));
                        else
                        {
                            result = CFormExecuteProcess.StartProcessMultiples(processToExecute,
                                (CReferenceObjetDonnee[])lstRefs.ToArray(typeof(CReferenceObjetDonnee)),
                                CTimosApp.SessionClient.IdSession,
                                CSc2iWin32DataClient.ContexteCourant.IdVersionDeTravail,
                                action.MasquerProgressProcess);
                            return result;
                        }
					}
					else
					{
                        if (process.TypeCible.IsAssignableFrom(cibleProcess.GetType()) && cibleProcess is CObjetDonnee)
                            refObj = new CReferenceObjetDonnee((CObjetDonnee)cibleProcess);
					}
				}
				result = CFormExecuteProcess.StartProcess ( processToExecute, 
					refObj, 
					CTimosApp.SessionClient.IdSession,
					CSc2iWin32DataClient.ContexteCourant.IdVersionDeTravail,
					action.MasquerProgressProcess);
			}
			else
			{
				CEvenement evt = new CEvenement ( CSc2iWin32DataClient.ContexteCourant );
				CInfoDeclencheurProcess infoDecl =  new CInfoDeclencheurProcess ( TypeEvenement.Manuel );
                object cibleProcess = objetCible;
                if (cibleProcess is CDefinitionMultiSourceForExpression)
                    cibleProcess = ((CDefinitionMultiSourceForExpression)cibleProcess).ObjetPrincipal;
				if ( evt.ReadIfExists ( action.IdEvenement ) )
				{
                    if (cibleProcess == null)
					{
						result.EmpileErreur(I.T("Impossible to execute the requested event|30086"));
						return result;
					}
                    if (cibleProcess.GetType().IsArray)
					{
						ArrayList lstRefs = new ArrayList();
                        foreach (object cible in (Array)cibleProcess)
						{
							if ( !(cible is CObjetDonneeAIdNumerique ) || !evt.ShouldDeclenche((CObjetDonneeAIdNumerique)cible, ref infoDecl))
							{
								result.EmpileErreur(I.T("The requested action cannot be executed on at least one of the requested elements|30087"));
                            	return result;
							}
							lstRefs.Add ( cible );
						}
						if ( lstRefs.Count == 0 )
						{
							result.EmpileErreur(I.T("No element selected for execution|30088"));
							return result;
						}
						result = CFormExecuteProcess.RunEventMultiple ( 
							evt, 
							(CObjetDonneeAIdNumeriqueAuto[] )lstRefs.ToArray ( typeof ( CObjetDonneeAIdNumeriqueAuto ) ),
							action.MasquerProgressProcess);
					}
					else
					{
                        if (!evt.ShouldDeclenche((CObjetDonneeAIdNumerique)cibleProcess, ref infoDecl))
						{
							result.EmpileErreur(I.T("Impossible to trigger the requested event on this object|30089"));
							return result;
						}
                        result = CFormExecuteProcess.RunEvent(evt, (CObjetDonneeAIdNumerique)cibleProcess, action.MasquerProgressProcess);

					}
				}
				else
				{				
					result.EmpileErreur ( I.T("The requested action does not exist|30090"));
				}
			}
			return result;
		}

		/// //////////////////////////////////////////////////////////////////
		protected static CResultAErreur ExecuteActionFormulaireCustom ( CActionSur2iLinkAfficheFormulaireCustom action, object objetCible )
		{
			CResultAErreur result = CResultAErreur.True;
			CFormulaire formulaire = new CFormulaire ( CSc2iWin32DataClient.ContexteCourant );
			if ( formulaire.ReadIfExists ( action.IdFormulaireInDb ) )
			{
				if ( formulaire.Role != null )
				{
					bool bObjetOk = false;
					if ( objetCible != null )
					{
						CRoleChampCustom role = CRoleChampCustom.GetRoleForType ( objetCible.GetType() );
						if ( role != null && formulaire.HasRole ( role.CodeRole ) )
							bObjetOk = true;
					}
					if ( !bObjetOk )
					{
						result.EmpileErreur(I.T("The object does not correspond to the expected type of the form|30091"));
						return result;
					}
				}
				CTimosApp.Navigateur.AffichePage ( new CFormFormulaireCustom ( formulaire, objetCible ) );
			}
			else
			{
				result.EmpileErreur (I.T("Form|30092")+action.IdFormulaireInDb+(I.T(" does not exist |30093")));
			}
			return result;
		}


        /// /////////////////////////////////////////////////////////////////////////////////////
        private static CResultAErreur ExecuteActionMenuDeroulant(CActionSur2iLinkMenuDeroulant actionMenu, object sender, object objetCible)
        {
            CExecuteurActionSur2iLinkMenuDeroulant executeur = new CExecuteurActionSur2iLinkMenuDeroulant();
            return executeur.ExecuteAction(actionMenu, sender, objetCible);
        }

        /// /////////////////////////////////////////////////////////////////////////////////////
        private static CResultAErreur ExecuteActionFormulairePopup(CActionSur2iLinkFormulairePopup actionPopup, object sender, object objetCible)
        {
            CResultAErreur result = CResultAErreur.True;

            C2iExpression formuleElement = actionPopup.FormuleElementEdite;
            IObjetDonnee elementEdite = null;
            if (formuleElement != null)
            {
                CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(objetCible);
                ctxEval.AttacheObjet(typeof(CContexteDonnee), CSc2iWin32DataClient.ContexteCourant);
                result = formuleElement.Eval(ctxEval);
                if (!result)
                {
                    result.EmpileErreur(I.T("Element evaluation error|30084"));
                    return result;
                }

                if (result.Data == null)
                {
                    result.EmpileErreur(I.T("Not avaliable|30082"));
                    return result;
                }

                elementEdite = result.Data as IObjetDonnee;
            }
            else
                elementEdite = objetCible as IObjetDonnee;

            if (elementEdite != null)
            {
                Point pt = Cursor.Position;
                bool bModeEdition = false;

                if (sender != null)
                {
                    pt = ((Control)sender).Location;

                    Form frm = ((Control)sender).FindForm();
                    if (frm != null && frm is CFormEditionStandard)
                    {
                        bModeEdition = ((CFormEditionStandard)frm).ModeEdition;
                    }
                }
                CFormExecuteActionFormulairePopup.Popup(
                    pt,
                    actionPopup,
                    elementEdite,
                    bModeEdition);
            }
            else
            {
                result.EmpileErreur(I.T("Popup form element is not a valid object|20882"));
            }

            return result;
        }

	}

    ////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 
    /// </summary>
    public class CExecuteurActionSurPanelListeSpeedStandard
    {
        private CActionSur2iLink m_action = null;
        private Control m_controlSource = null;

        public CExecuteurActionSurPanelListeSpeedStandard(CActionSur2iLink action,
            Control ctrlSource)
        {
            m_action = action;
            m_controlSource = ctrlSource;
        }

        public CResultAErreur ExecuteAction(CObjetDonnee objet)
        {
            return CExecuteurActionSur2iLink.ExecuteAction(m_controlSource, m_action, objet);
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////
    public class CExecuteurActionSur2iLinkMenuDeroulant
        {
        private static Dictionary<Type, IExecuteurSpecifiqueActionMenuItem> m_dicTypeActionExecuteur =
            new Dictionary<Type, IExecuteurSpecifiqueActionMenuItem>();

        public static void RegisterExecuteurSpécifique(Type typeAction, IExecuteurSpecifiqueActionMenuItem executeurSpecifique)
        {
            m_dicTypeActionExecuteur[typeAction] = executeurSpecifique;
        }

        public CExecuteurActionSur2iLinkMenuDeroulant()
        {
        }

        //---------------------------------------------------------------------------
        public CResultAErreur ExecuteAction(CActionSur2iLinkMenuDeroulant actionMenu, object sender, object objetCible)
        {
            CResultAErreur result = CResultAErreur.True;

            List<ToolStripItem> listeItems = new List<ToolStripItem>();
            foreach (IMenuItem item in actionMenu.ListeMenuItems)
            {
                bool bAdd = true;
                if (item.FormuleCondition != null)
                {
                    CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(objetCible);
                    result = item.FormuleCondition.Eval(ctx);
                    if (result && !CUtilBool.BoolFromObject(result.Data))
                        bAdd = false;
                }
                if (bAdd)
                {
                    IExecuteurSpecifiqueActionMenuItem executeurSpecifique = null;
                    if (m_dicTypeActionExecuteur.TryGetValue(item.GetType(), out executeurSpecifique))
                    {
                        listeItems.AddRange(executeurSpecifique.GetItemsForContextMenuStrip(item, sender, objetCible));
                    }
                }
            }
            ContextMenuStrip menuDeroulant = new ContextMenuStrip();
            menuDeroulant.Items.Clear();
            menuDeroulant.Items.AddRange(listeItems.ToArray());
            if (menuDeroulant.Items.Count > 0)
            {
                /*if (sender != null)
                    menuDeroulant.Show((Control)sender, new Point(0, ((Control)sender).Height));
                else*/
                    menuDeroulant.Show(Cursor.Position);
            }
            result.Data = listeItems.ToArray();
            return result;
        }
    }


    public interface IExecuteurSpecifiqueActionMenuItem
    {
        ToolStripItem[] GetItemsForContextMenuStrip(IMenuItem menuItem, object sender, object objetCible);
    }

    
  
}
