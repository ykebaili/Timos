using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.process.workflow.blocs;
using sc2i.data.dynamic;
using sc2i.win32.data.navigation;
using sc2i.data;
using sc2i.expression;
using sc2i.common;
using sc2i.process.workflow;
using sc2i.win32.common;
using sc2i.win32.data;
using timos.data;
using sc2i.formulaire;
using sc2i.formulaire.win32;
using sc2i.win32.process.workflow.bloc;

namespace timos.process.workflow
{
    public partial class CFormEditionBlocWorkflowProjet : Form
    {
        private CBlocWorkflowProjet m_blocWorkflow = null;
        private List<CAffectationsProprietes> m_listeAffectations;
       
        
        //-------------------------------------------------------
        public CFormEditionBlocWorkflowProjet()
        {
            m_listeAffectations = new List<CAffectationsProprietes>();
            InitializeComponent();
            CWin32Traducteur.Translate(this);
        }

        //-------------------------------------------------------
        public static bool EditeBloc(CBlocWorkflowProjet bloc)
        {
            if (bloc == null)
                return false;
            CFormEditionBlocWorkflowProjet form = new CFormEditionBlocWorkflowProjet();
            form.m_blocWorkflow = bloc;
            bool bResult = form.ShowDialog() == DialogResult.OK;
            form.Dispose();
            return bResult;
        }

        //-------------------------------------------------------
        private void InitChamps()
        {
            if ( m_blocWorkflow == null )
                return;
            m_txtSelectWorkflow.Init(typeof(CTypeWorkflow),
                "Libelle",
                false);
            if (m_blocWorkflow.DbKeyTypeWorkflow != null)
            {
                CTypeWorkflow wkf = new CTypeWorkflow(CSc2iWin32DataClient.ContexteCourant);
                if (wkf.ReadIfExists(m_blocWorkflow.DbKeyTypeWorkflow))
                    m_txtSelectWorkflow.ElementSelectionne = wkf;
            }
            m_txtSelectTypeProjet.Init(typeof(CTypeProjet),
                "Libelle",
                false);
            if (m_blocWorkflow.DbKeyTypeProjet != null)
            {
                CTypeProjet typeProjet = new CTypeProjet(CSc2iWin32DataClient.ContexteCourant);
                if (typeProjet.ReadIfExists(m_blocWorkflow.DbKeyTypeProjet))
                    m_txtSelectTypeProjet.ElementSelectionne = typeProjet;
            }
            m_cmbProjectField.Init ( typeof(CChampCustom),
                CFiltreData.GetAndFiltre ( CChampCustom.GetFiltreChampsForRole ( CWorkflow.c_roleChampCustom),
                    new CFiltreData ( 
                    CChampCustom.c_champTypeObjetDonnee+"=@1",
                    typeof(CProjet).ToString())),
                    "Nom",
                    false );
            if (m_blocWorkflow.IdChampProjet != null)
            {
                CChampCustom champ = new CChampCustom(CSc2iWin32DataClient.ContexteCourant);
                if (champ.ReadIfExists(m_blocWorkflow.IdChampProjet.Value))
                    m_cmbProjectField.ElementSelectionne = champ;
            }

            m_listeAffectations.Clear();
            m_listeAffectations.AddRange(m_blocWorkflow.AffectationsCreationEtDemarrage);

            m_txtFormuleGanttId.Init(new CFournisseurPropDynStd(),
                typeof(CEtapeWorkflow));
            m_txtFormuleGanttId.Formule = m_blocWorkflow.FormuleGanttId;

            m_chkGererIterations.Checked = m_blocWorkflow.GererIteration;
            
        }

        //-------------------------------------------------------
        private CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            CTypeWorkflow wkf = m_txtSelectWorkflow.ElementSelectionne as CTypeWorkflow;
            if (wkf != null)
                m_blocWorkflow.DbKeyTypeWorkflow = wkf.DbKey;
            else
                m_blocWorkflow.DbKeyTypeWorkflow = null;

            CTypeProjet typeProjet = m_txtSelectTypeProjet.ElementSelectionne as CTypeProjet;
            if (typeProjet != null)
                m_blocWorkflow.DbKeyTypeProjet = typeProjet.DbKey;
            else
                m_blocWorkflow.DbKeyTypeProjet = null;

            CChampCustom champ = m_cmbProjectField.ElementSelectionne as CChampCustom;
            if (champ != null)
                m_blocWorkflow.IdChampProjet = champ.Id;
            else
                m_blocWorkflow.IdChampProjet = null;

            m_blocWorkflow.AffectationsCreationEtDemarrage = m_listeAffectations;

            m_blocWorkflow.FormuleGanttId = m_txtFormuleGanttId.Formule;

            m_blocWorkflow.GererIteration = m_chkGererIterations.Checked;

            return result;
        }


        
        //-------------------------------------------------------
        private void CFormEditionBlocWorkflowProjet_Load(object sender, EventArgs e)
        {
            if ( !DesignMode)
                InitChamps();
        }

        private void m_btnAnnuler_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void m_btnOk_Click(object sender, EventArgs e)
        {
            CResultAErreur result = MajChamps();
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void m_lnkAffectationsCreation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            m_listeAffectations = CFormEditProprieteAffectationsProprietes.EditeLesAffectations(
                m_listeAffectations, 
                typeof(CEtapeWorkflow), 
                typeof(CProjet),
                new CFournisseurPropDynStd());
        }

    }

    //-------------------------------------------------------
    [AutoExec("Autoexec")]
    public class CEditeurBlocWorkflowProjet : IEditeurBlocWorkflow
    {
        public static void Autoexec()
        {
            CAllocateurEditeurBlocWorkflow.RegisterEditeur(typeof(CBlocWorkflowProjet),
                typeof(CEditeurBlocWorkflowProjet));
        }

        //-------------------------------------------------------
        public bool EditeBloc(CBlocWorkflow bloc)
        {
            return CFormEditionBlocWorkflowProjet.EditeBloc ( bloc as CBlocWorkflowProjet);
        }

    }

}
