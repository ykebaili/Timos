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
using timos.data.workflow.gantt;

namespace timos.Parametrage.ConsultationHierarchique
{
	[AutoExec("Autoexec")]
	public partial class CPanelEditFolderConsultationFolder : UserControl, 
		IPanelEditionFolderConsultation,
		IControlALockEdition
	{
		private CFolderConsultationFolder m_folder = null;
		public CPanelEditFolderConsultationFolder()
		{
			InitializeComponent();
		}

		public static void Autoexec()
		{
			CPanelEditConsultationHierarchique.RegisterTypeEditeur(typeof(CFolderConsultationFolder), typeof(CPanelEditFolderConsultationFolder));
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
			m_folder = folder as CFolderConsultationFolder;
            if (m_folder != null)
            {
                m_txtLibelle.Text = m_folder.Libelle;
                m_selectColor.SelectedColor = m_folder.Couleur;
                m_imageSelect.Image = m_folder.Image;
            }
		}

		public CResultAErreur MajChamps()
		{
            if (m_folder != null)
            {
                m_folder.Libelle = m_txtLibelle.Text;
                m_folder.Couleur = m_selectColor.SelectedColor;
                m_folder.Image = m_imageSelect.Image;
            }
			return CResultAErreur.True;
		}

		#endregion

        private void CPanelEditFolderConsultationFolder_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
        }
	}
}
