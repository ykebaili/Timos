using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using sc2i.win32.navigation;
using sc2i.data;
using sc2i.workflow;
using sc2i.win32.data;
using sc2i.process;
using sc2i.common;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectListeur(typeof(CComportementGenerique))]
	public class CFormListeComportementsGeneriques : CFormListeStandardTimos, IFormNavigable
	{
		
		private System.ComponentModel.IContainer components = null;

		public CFormListeComportementsGeneriques()
			:base(typeof(CComportementGenerique))
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
			glColumn1.Name = "Namex";
			glColumn1.Propriete = "Libelle";
            glColumn1.Text = "Label|50";
			glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			glColumn1.Width = 400;
			this.m_panelListe.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
																					glColumn1});
			this.m_panelListe.Name = "m_panelListe";
			// 
			// CFormListeComportementsGeneriques
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 376);
			this.Name = "CFormListeComportementsGeneriques";

		}
		#endregion
		//-------------------------------------------------------------------------
		protected override void InitPanel()
		{
			m_panelListe.InitFromListeObjets(
				m_listeObjets,
				typeof(CComportementGenerique),	
				typeof(CFormEditionComportementGenerique),
				null, "");

			m_panelListe.ControlFiltreStandard = new CPanelFiltreChampCustom();
			
			m_panelListe.RemplirGrille();

			m_panelListe.MultiSelect = true;
		}
		//-------------------------------------------------------------------
        public override string GetTitle()
        {
            return I.T("Behavior list|983");
		}
		//-------------------------------------------------------------------
	}
}

