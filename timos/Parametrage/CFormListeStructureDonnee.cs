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

namespace timos
{
	[sc2i.win32.data.navigation.ObjectListeur(typeof(C2iStructureExportInDB))]
	public class CFormListeStructuresDonnees : CFormListeStandardTimos, IFormNavigable
	{
		
		private System.ComponentModel.IContainer components = null;

		public CFormListeStructuresDonnees()
			:base(typeof(C2iStructureExportInDB))
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}

		public CFormListeStructuresDonnees(CListeObjetsDonnees liste)
			:base(liste)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}

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

		#region Designer generated code
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			sc2i.win32.common.GLColumn listViewAutoFilledColumn1;
			sc2i.win32.common.GLColumn listViewAutoFilledColumn2;
			listViewAutoFilledColumn1 = new sc2i.win32.common.GLColumn();
			listViewAutoFilledColumn2 = new sc2i.win32.common.GLColumn();
			this.SuspendLayout();
			// 
			// m_panelListe
			// 
			this.m_panelListe.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
																									listViewAutoFilledColumn1,
																									listViewAutoFilledColumn2});
			this.m_panelListe.Visible = true;
			// 
			// listViewAutoFilledColumn1
			// 
			listViewAutoFilledColumn1.Propriete = "Libelle";
            listViewAutoFilledColumn1.Text = "Label|50";
			listViewAutoFilledColumn1.Width = 200;
			// 
			// listViewAutoFilledColumn2
			// 
			listViewAutoFilledColumn2.Propriete = "NomTypeElements";
			listViewAutoFilledColumn2.Text = "Type|30284";
			listViewAutoFilledColumn2.Width = 120;
			// 
			// CFormListeStructuresDonnees
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 376);
			this.Name = "CFormListeStructuresDonnees";
			this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		protected override void InitPanel()
		{
			m_panelListe.InitFromListeObjets(
				m_listeObjets,
				typeof(C2iStructureExportInDB),	
				typeof(CFormEditionStructureDonnee),
				null, "");
			
			m_panelListe.RemplirGrille();

			m_panelListe.MultiSelect = true;
		}
		//-------------------------------------------------------------------
        public override string GetTitle()
        {
            return I.T("Data Structure list|996");
		}
		//-------------------------------------------------------------------
	}
}

