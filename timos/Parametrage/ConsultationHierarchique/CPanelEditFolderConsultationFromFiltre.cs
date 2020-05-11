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
	public partial class CPanelEditFolderConsultationFromFiltre : UserControl, 
		IPanelEditionFolderConsultation,
		IControlALockEdition
	{
		private CFolderConsultationFromFiltre m_folder = null;
		public CPanelEditFolderConsultationFromFiltre()
		{
			InitializeComponent();
		}

		public static void Autoexec()
		{
			CPanelEditConsultationHierarchique.RegisterTypeEditeur(typeof(CFolderConsultationFromFiltre), typeof(CPanelEditFolderConsultationFromFiltre));
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
			m_folder = folder as CFolderConsultationFromFiltre;
            if (m_folder != null)
            {
                m_txtLibelle.Text = m_folder.Libelle;
                m_txtFormule.Formule = m_folder.FormuleAffichage;
                m_txtFormule.Init(new CFournisseurGeneriqueProprietesDynamiques(),
                    new CObjetPourSousProprietes ( m_folder ));
                m_panelFiltre.Init(m_folder.FiltreDynamique);
                m_selectColor.SelectedColor = m_folder.Couleur;
                m_imageSelect.Image = m_folder.Image;
            }
		}

		public CResultAErreur MajChamps()
		{
            if (m_folder != null)
            {
                m_folder.Libelle = m_txtLibelle.Text;
                m_folder.FormuleAffichage = m_txtFormule.Formule;
                m_folder.FiltreDynamique = m_panelFiltre.FiltreDynamique;
                m_folder.Couleur = m_selectColor.SelectedColor;
                m_folder.Image = m_imageSelect.Image;
            }
			return CResultAErreur.True;
		}

		#endregion

        private void CPanelEditFolderConsultationFromFiltre_Load_1(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
            m_panelFiltre.MasquerFormulaire(true);
        }

        private void m_panelFiltre_OnChangeTypeElements(object sender, Type typeSelectionne)
        {
            m_txtFormule.Init(new CFournisseurGeneriqueProprietesDynamiques(),
                new CObjetPourSousProprietes ( m_folder ));
        }
	}
}
