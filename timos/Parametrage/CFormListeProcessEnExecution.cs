using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using sc2i.win32.navigation;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.win32.data;
using sc2i.common;
using sc2i.process;


namespace timos
{
	[sc2i.win32.data.navigation.ObjectListeur(typeof(CProcessEnExecutionInDb))]
	public class CFormListeProcessEnExecution : CFormListeStandardTimos, IFormNavigable
	{
		
		private System.ComponentModel.IContainer components = null;

		//-------------------------------------------------------------------
		public CFormListeProcessEnExecution()
			:base(typeof(CProcessEnExecutionInDb))
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------
		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		//-------------------------------------------------------------------
		#region Designer generated code
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
			sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
			sc2i.win32.common.GLColumn glColumn3 = new sc2i.win32.common.GLColumn();
			// 
			// m_panelListe
			// 
			glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
			glColumn1.ImageIndex = -1;
			glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
			glColumn1.Name = "Name";
			glColumn1.Propriete = "DateCreation";
			glColumn1.Text = "Création";
			glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			glColumn1.Width = 130;
			glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
			glColumn2.ImageIndex = -1;
			glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
			glColumn2.Name = "Name";
			glColumn2.Propriete = "Etat";
			glColumn2.Text = "Etat";
			glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			glColumn2.Width = 100;
			glColumn3.ControlType = sc2i.win32.common.ColumnControlTypes.None;
			glColumn3.ImageIndex = -1;
			glColumn3.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
			glColumn3.Name = "Name";
			glColumn3.Propriete = "InfoEtat";
			glColumn3.Text = "Info";
			glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			glColumn3.Width = 800;
			this.m_panelListe.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
																					glColumn1,
																					glColumn2,
																					glColumn3});
			this.m_panelListe.Name = "m_panelListe";
			// 
			// CFormListeProcessEnExecution
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 376);
			this.Name = "CFormListeProcessEnExecution";

		}
		#endregion
		//-------------------------------------------------------------------------
		protected override void InitPanel()
		{
			m_panelListe.InitFromListeObjets(
				m_listeObjets,
				typeof(CProcessEnExecutionInDb),	
				typeof(CFormEditionProcessEnExecution),
				null, "");

			m_panelListe.BoutonAjouterVisible = false;
			m_panelListe.BoutonSupprimerVisible = false;

			m_panelListe.RemplirGrille();

			m_panelListe.MultiSelect = true;
		}
		//-------------------------------------------------------------------
        public override string GetTitle()
        {
            return I.T("Actions in progress|992");
		}
		//-------------------------------------------------------------------
	}
}

