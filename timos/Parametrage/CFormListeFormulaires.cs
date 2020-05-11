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
	[sc2i.win32.data.navigation.ObjectListeur(typeof(CFormulaire))]
	public class CFormListeFormulaires : CFormListeStandardTimos, IFormNavigable
	{
		
		private System.ComponentModel.IContainer components = null;
		private string m_strCodeRole = "";
		//-------------------------------------------------------------------
		public CFormListeFormulaires()
			:base(typeof(CFormulaire))
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}

		//-------------------------------------------------------------------
		public CFormListeFormulaires( string strCodeRole)
			:base(typeof(CFormulaire))
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
			m_strCodeRole = strCodeRole;
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
			// 
			// m_panelListe
			// 
			glColumn1.BackColor = System.Drawing.Color.Transparent;
			glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
			glColumn1.ForColor = System.Drawing.Color.Black;
			glColumn1.ImageIndex = -1;
			glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
			glColumn1.Name = "Name";
			glColumn1.Propriete = "Libelle";
            glColumn1.Text = "Label|50";
			glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			glColumn1.Width = 308;
			this.m_panelListe.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
																					glColumn1});
			this.m_panelListe.Name = "m_panelListe";
			this.m_panelListe.Size = new System.Drawing.Size(448, 376);
			this.m_panelListe.OnNewObjetDonnee += new sc2i.win32.data.navigation.OnNewObjetDonneeEventHandler(this.m_panelListe_OnNewObjetDonnee);
			// 
			// CFormListeFormulaires
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 376);
			this.Name = "CFormListeFormulaires";

		}
		#endregion
		//-------------------------------------------------------------------------
		protected override void InitPanel()
		{
            if (m_strCodeRole != "")
                m_panelListe.FiltreDeBase = CFormulaire.GetFiltreFormulairesForRole(m_strCodeRole);
				/*m_panelListe.FiltreDeBase = new CFiltreData ( 
					CFormulaire.c_champCodeRole+"=@1",
					m_strCodeRole );*/

            if (FiltreDeBase == null)
            {
                FiltreDeBase = new CFiltreData(
                    CFormulaire.c_champCodeRole + "<>@1 or " + CFormulaire.c_champCodeRole + " is null",
                    sc2i.custom.CRoleFormulaireSurImpressionWin32.c_roleChampCustom);
            }
            m_panelListe.InitFromListeObjets(
				m_listeObjets,
				typeof(CFormulaire),	
				typeof(CFormEditionFormulaireAvance),
				null, "");

			m_panelListe.RemplirGrille();
            m_panelListe.ControlFiltreStandard = new CPanelFiltreFormulaire();

			m_panelListe.MultiSelect = true;
		}
		//-------------------------------------------------------------------
        public override string GetTitle()
        {
            return I.T("Custom Form list|986");
		}

		private void m_panelListe_OnNewObjetDonnee(object sender, sc2i.data.CObjetDonnee nouvelObjet, ref bool bCancel)
		{
            if (bCancel)
                return;
			if ( nouvelObjet is CFormulaire && m_strCodeRole != "" )
				((CFormulaire)nouvelObjet).CodeRole = m_strCodeRole;
		}
		//-------------------------------------------------------------------
	}
}

