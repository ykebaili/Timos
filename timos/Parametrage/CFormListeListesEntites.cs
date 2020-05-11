using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using sc2i.win32.navigation;
using sc2i.data;
using sc2i.win32.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.data.dynamic;


namespace timos
{
	[sc2i.win32.data.navigation.ObjectListeur(typeof(CListeEntites))]
	public class CFormListeListesEntites : CFormListeStandardTimos, IFormNavigable
	{
		private System.ComponentModel.IContainer components = null;

		public CFormListeListesEntites()
			:base(typeof(CListeEntites))
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

			listViewAutoFilledColumn1 = new sc2i.win32.common.GLColumn();
			this.SuspendLayout();
			// 
			// m_panelListe
			// 
			this.m_panelListe.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
																									listViewAutoFilledColumn1});
			this.m_panelListe.Visible = true;
			// 
			// listViewAutoFilledColumn1
			// 
			listViewAutoFilledColumn1.Propriete = "Libelle";
            listViewAutoFilledColumn1.Text = "Label|50";
			listViewAutoFilledColumn1.Width = 120;
			// 
			// CFormListeListesEntites
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 376);
			this.Name = "CFormListeListesEntites";
			this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------
		protected override void InitPanel()
		{
			m_panelListe.InitFromListeObjets(
				m_listeObjets,
				typeof(CListeEntites),	
				typeof(CFormEditionListeEntites),
				null, "");

			m_panelListe.RemplirGrille();
		}
		//-------------------------------------------------------------------
        public override string GetTitle()
        {
            return I.T("Entity Lists|988");
		}
		//-------------------------------------------------------------------
	}
}

