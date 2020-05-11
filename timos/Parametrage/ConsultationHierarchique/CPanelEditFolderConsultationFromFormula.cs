using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using timos.data.workflow.ConsultationHierarchique;
using sc2i.common;
using sc2i.expression;

namespace timos.Parametrage.ConsultationHierarchique
{
	[AutoExec("Autoexec")]
	public partial class CPanelEditFolderConsultationFromFormula : UserControl, 
		IPanelEditionFolderConsultation,
		IControlALockEdition
	{
		private CFolderConsultationFromFormula m_folder = null;
		public CPanelEditFolderConsultationFromFormula()
		{
			InitializeComponent();
		}

		public static void Autoexec()
		{
			CPanelEditConsultationHierarchique.RegisterTypeEditeur(typeof(CFolderConsultationFromFormula), typeof(CPanelEditFolderConsultationFromFormula));
		}

		#region IControlALockEdition Membres

		public bool LockEdition
		{
			get
			{
				return !m_gestionnaireModeEdition.ModeEdition;
			}
			set
			{
				m_gestionnaireModeEdition.ModeEdition = !value;
				if (OnChangeLockEdition != null)
					OnChangeLockEdition(this, new EventArgs());
			}
		}

		public event EventHandler OnChangeLockEdition;

		#endregion

		#region IPanelEditionFolderConsultation Membres

		public void InitChamps(CFolderConsultationHierarchique folder)
		{
			m_folder = folder as CFolderConsultationFromFormula;
            if (m_folder != null)
            {
                m_txtLibelle.Text = m_folder.Libelle;
                m_txtFormuleLibelle.Formule = m_folder.FormuleAffichage;
                m_txtFormuleLibelle.Init(new CFournisseurGeneriqueProprietesDynamiques(),
                    new CObjetPourSousProprietes ( m_folder ));
                m_txtFormuleElements.Formule = m_folder.FormuleObjets;
                m_txtFormuleElements.Init(new CFournisseurGeneriqueProprietesDynamiques(),
                    new CObjetPourSousProprietes(m_folder.FolderParent));
                m_selectColor.SelectedColor = m_folder.Couleur;
                m_imageSelect.Image = m_folder.Image;
            }
		}

		public CResultAErreur MajChamps()
		{
            if (m_folder != null)
            {
                m_folder.Libelle = m_txtLibelle.Text;
                m_folder.FormuleAffichage = m_txtFormuleLibelle.Formule;
                m_folder.FormuleObjets = m_txtFormuleElements.Formule;
                m_folder.Couleur = m_selectColor.SelectedColor;
                m_folder.Image = m_imageSelect.Image;
            }
			return CResultAErreur.True;
		}

		#endregion

        //--------------------------------------------------------------
        private void CPanelEditFolderConsultationFromFormula_Load_1(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
        }

        //--------------------------------------------------------------
        private void m_txtFormuleElements_Validated(object sender, EventArgs e)
        {
            m_folder.FormuleObjets = m_txtFormuleElements.Formule;
            m_txtFormuleLibelle.Init(new CFournisseurGeneriqueProprietesDynamiques(),
                    new CObjetPourSousProprietes(m_folder));
        }

        
	}
}
