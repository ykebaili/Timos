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
	[sc2i.win32.data.navigation.ObjectListeur(typeof(CFiltreDynamiqueInDb))]
	public class CFormListeFiltresDynamiques : sc2i.win32.data.navigation.CFormListeStandard, IFormNavigable
	{
		
		private System.ComponentModel.IContainer components = null;

		//-------------------------------------------------------------------
		public CFormListeFiltresDynamiques()
			:base(typeof(CFiltreDynamiqueInDb))
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
			sc2i.win32.common.GLColumn listViewAutoFilledColumn4;
			listViewAutoFilledColumn4 = new sc2i.win32.common.GLColumn();
			this.SuspendLayout();
			// 
			// m_panelListe
			// 
			this.m_panelListe.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
																									listViewAutoFilledColumn4});
			this.m_panelListe.Visible = true;
			// 
			// listViewAutoFilledColumn4
			// 
			listViewAutoFilledColumn4.Propriete = "Libelle";
            listViewAutoFilledColumn4.Text = "Label|50";
			listViewAutoFilledColumn4.Width = 308;
			// 
			// CFormListeFiltresDynamiques
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 376);
			this.Name = "CFormListeFiltresDynamiques";
			this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		protected override void InitPanel()
		{
			m_panelListe.InitFromListeObjets(
				m_listeObjets,
				typeof(CFiltreDynamiqueInDb),	
				typeof(CFormEditionFiltreDynamique),
				null, "");

			m_panelListe.RemplirGrille();

			m_panelListe.MultiSelect = true;
		}
		//-------------------------------------------------------------------
        public override string GetTitle()
        {
            return I.T("Dynamic Filter list|985");
		}
		//-------------------------------------------------------------------
	}
}

