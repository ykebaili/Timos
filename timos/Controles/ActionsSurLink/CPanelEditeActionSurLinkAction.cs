using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.custom;
using sc2i.formulaire;
using sc2i.data;
using sc2i.expression;
using sc2i.process;
using sc2i.win32.data;
using sc2i.win32.common;
using sc2i.common;

namespace timos.Controles.ActionsSurLink
{
    [AutoExec("Autoexec")]
    public partial class CPanelEditeActionSurLinkAction : UserControl, IEditeurUneActionSur2iLink
    {
        private CActionSur2iLinkExecuterProcess m_actionEditee = null;
        private CObjetPourSousProprietes m_objetPourSousProprietes = null;

        //-----------------------------------------------------------------------------------------------------
        public CPanelEditeActionSurLinkAction()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        public static void Autoexec()
        {
            CGestionnaireEditeursActionsSur2iLink.RegisterEditeur(
                I.T("Execute an Action|154"),
                typeof(CActionSur2iLinkExecuterProcess),
                typeof(CPanelEditeActionSurLinkAction));
        }


        //-----------------------------------------------------------------------------------------------------
        public void InitChamps(CActionSur2iLink action, CObjetPourSousProprietes objetPourSousProprietes)
        {
            m_actionEditee = action as CActionSur2iLinkExecuterProcess;
            if (m_actionEditee == null)
            {
                Visible = false;
                return;
            }
            Visible = true;

            m_objetPourSousProprietes = objetPourSousProprietes;
            CObjetPourSousProprietes objetPourFiltreActions = m_objetPourSousProprietes;
            CDefinitionMultiSourceForExpression multi = m_objetPourSousProprietes.ElementAVariableInstance as CDefinitionMultiSourceForExpression;
            if (multi != null)
                objetPourFiltreActions = multi.DefinitionObjetPrincipal;
            CFiltreData filtre = null;
            if (objetPourFiltreActions == null || objetPourFiltreActions.TypeAnalyse == null)
                filtre = new CFiltreData(CProcessInDb.c_champTypeCible + "=@1", "");
            else
            {
                filtre = new CFiltreData(CProcessInDb.c_champTypeCible + "=@1 or " +
                    CProcessInDb.c_champTypeCible + "=@2 or " +
                CProcessInDb.c_champTypeCible + "=@3",
                "",
                objetPourFiltreActions.TypeAnalyse.ToString(),
                typeof(CObjetDonneeAIdNumerique).ToString());
            }

            m_selectionneurProcess.InitAvecFiltreDeBase<CProcessInDb>("Libelle", filtre, true);
            CProcessInDb process = new CProcessInDb(CSc2iWin32DataClient.ContexteCourant);
            CProcess processPourParametres = null;
            if (process.ReadIfExists(((CActionSur2iLinkExecuterProcess)m_actionEditee).IdProcessInDb))
            {
                m_selectionneurProcess.ElementSelectionne = process;
                processPourParametres = process.Process;
            }


            if (objetPourFiltreActions != null && objetPourFiltreActions.TypeAnalyse != null)
            {
                m_panelEvenementManuel.Visible = true;
                CFiltreData filtreDeBase = new CFiltreData(
                    CEvenement.c_champTypeEvenement + "=@1 and " +
                    CEvenement.c_champTypeCible + "=@2",
                    (int)TypeEvenement.Manuel,
                    objetPourFiltreActions.TypeAnalyse.ToString());

                m_selectionneurEvenementManuel.InitAvecFiltreDeBase<CEvenement>(
                    "Libelle",
                    filtreDeBase, true);

                CEvenement evt = new CEvenement(CSc2iWin32DataClient.ContexteCourant);
                if (evt.ReadIfExists(((CActionSur2iLinkExecuterProcess)m_actionEditee).IdEvenement))
                {
                    m_selectionneurEvenementManuel.ElementSelectionne = evt;
                    processPourParametres = null;
                }
            }
            else
            {
                m_panelEvenementManuel.Visible = false;
                m_selectionneurEvenementManuel.ElementSelectionne = null;
            }
            m_chkHideProgress.Checked = ((CActionSur2iLinkExecuterProcess)m_actionEditee).MasquerProgressProcess;
            InitListeFormulesParametres(processPourParametres, m_actionEditee);
        }

        /////////////////////////////////////////////////////////////////////////////////
        private void InitListeFormulesParametres(CProcess process, CActionSur2iLinkExecuterProcess action)
        {
            if (process == null)
            {
                m_panelParametresAction.Visible = false;
                return;
            }
            m_panelParametresAction.Visible = true;
            Dictionary<string, CFormuleNommee> dicFormulesCreees = new Dictionary<string, CFormuleNommee>();
            if (action != null)
            {
                foreach (CFormuleNommee formule in action.FormulesPourParametres)
                    dicFormulesCreees[formule.Libelle] = formule;
            }
            List<CFormuleNommee> lst = new List<CFormuleNommee>();
            if (process != null)
            {
                foreach (IVariableDynamique variable in process.ListeVariables)
                {
                    if (variable.IsChoixUtilisateur())
                    {
                        CFormuleNommee formuleAffectee = null;
                        if (dicFormulesCreees.TryGetValue(variable.Nom, out formuleAffectee))
                            lst.Add(formuleAffectee);
                        else
                            lst.Add(new CFormuleNommee(variable.Nom, null));
                    }
                }
            }
            m_panelParametresAction.Init(lst.ToArray(), m_objetPourSousProprietes, new CFournisseurGeneriqueProprietesDynamiques());
        }

        /////////////////////////////////////////////////////////////////////////////////
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_selectionneurProcess.ElementSelectionne is CProcessInDb)
            {
                ((CActionSur2iLinkExecuterProcess)m_actionEditee).IdProcessInDb = ((CProcessInDb)m_selectionneurProcess.ElementSelectionne).Id;

            }
            else if (m_selectionneurEvenementManuel.ElementSelectionne is CEvenement)
            {
                ((CActionSur2iLinkExecuterProcess)m_actionEditee).IdEvenement = ((CEvenement)m_selectionneurEvenementManuel.ElementSelectionne).Id;
            }
            else
            {
                result.EmpileErreur(I.T("Select action to execute|20859"));
                return result;
            }
            ((CActionSur2iLinkExecuterProcess)m_actionEditee).MasquerProgressProcess = m_chkHideProgress.Checked;
            ((CActionSur2iLinkExecuterProcess)m_actionEditee).FormulesPourParametres = m_panelParametresAction.GetFormules();
            return result;
        }


        /////////////////////////////////////////////////////////////////////////////////
        private void m_selectionneurProcess_ElementSelectionneChanged(object sender, EventArgs e)
        {
            if (m_selectionneurProcess.ElementSelectionne != null)
            {
                m_selectionneurEvenementManuel.ElementSelectionne = null;
                CProcessInDb process = m_selectionneurProcess.ElementSelectionne as CProcessInDb;
                if (process != null)
                    InitListeFormulesParametres(process.Process, m_actionEditee as CActionSur2iLinkExecuterProcess);
                else
                    InitListeFormulesParametres(null, null);
            }
        }

        /////////////////////////////////////////////////////////////////////////////////
        private void m_selectionneurEvenementManuel_ElementSelectionneChanged(object sender, EventArgs e)
        {
            if (m_selectionneurEvenementManuel.ElementSelectionne != null)
            {
                m_selectionneurProcess.ElementSelectionne = null;
                InitListeFormulesParametres(null, m_actionEditee as CActionSur2iLinkExecuterProcess);
            }
        }

    }
}
