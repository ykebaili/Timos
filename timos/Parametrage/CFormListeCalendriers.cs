using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using sc2i.common;
using System.Windows.Forms;
using sc2i.win32.navigation;
using sc2i.data;
using sc2i.win32.data;

using sc2i.workflow;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectListeur(typeof(CCalendrier))]
	public class CFormListeCalendriers : CFormListeStandardTimos, IFormNavigable
	{
		
		private System.ComponentModel.IContainer components = null;

		public CFormListeCalendriers()
			:base(typeof(CCalendrier))
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
			sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
			// 
			// m_panelListe
			// 
			glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
			glColumn1.ImageIndex = -1;
			glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
			glColumn1.Name = "Name";
			glColumn1.Propriete = "Libelle";
            glColumn1.Text = "Label|50";
			glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			glColumn1.Width = 450;
			this.m_panelListe.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
																					glColumn1});
			this.m_panelListe.Name = "m_panelListe";
			// 
			// CFormListeCalendriers
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 376);
			this.Name = "CFormListeCalendriers";

		}
		#endregion
		//-------------------------------------------------------------------
		protected override void InitPanel()
		{
			m_panelListe.InitFromListeObjets(
				m_listeObjets,
				typeof(CCalendrier),	
				typeof(CFormEditionCalendrier),
				null, "");

			m_panelListe.RemplirGrille();
		}
		//-------------------------------------------------------------------
        public override string GetTitle()
        {
            return I.T("Calendars|188");
		}
		//-------------------------------------------------------------------
	}
}

