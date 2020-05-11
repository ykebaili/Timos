using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using sc2i.win32.navigation;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.win32.data;
using sc2i.win32.data.navigation;
using sc2i.common;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectListeur(typeof(CChampCustom))]
	public class CFormListeChampsCustom : 
		CFormListeStandardTimos, 
		IFormNavigable
	{
		private System.ComponentModel.IContainer components = null;
		private string m_strCodeRole = "";

		//-------------------------------------------------------------------
		public CFormListeChampsCustom()
			:base(typeof(CChampCustom))
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}

		//-------------------------------------------------------------------
		public CFormListeChampsCustom( string strCodeRole )
			:base(typeof(CChampCustom))
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
			glColumn1.Name = "c_colNom";
			glColumn1.Propriete = "Nom";
			glColumn1.Text  = "Name|164";
			glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			glColumn1.Width = 350;
			this.m_panelListe.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
																					glColumn1});
			this.m_panelListe.Name = "m_panelListe";
			this.m_panelListe.Size = new System.Drawing.Size(448, 376);
			this.m_panelListe.OnNewObjetDonnee += new sc2i.win32.data.navigation.OnNewObjetDonneeEventHandler(this.m_panelListe_OnNewObjetDonnee);
			// 
			// CFormListeChampsCustom
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 376);
			this.Name = "CFormListeChampsCustom";

		}
		#endregion
		//-------------------------------------------------------------------------
		protected override void InitPanel()
		{
            CFiltreData filtre = new CFiltreData();
			if ( m_strCodeRole != "" )
			{
				m_panelListe.FiltreDeBase = CChampCustom.GetFiltreChampsForRole(m_strCodeRole);
			}
			m_panelListe.InitFromListeObjets(
				m_listeObjets,
				typeof(CChampCustom),	
				typeof(CFormEditionChampCustom),
				null, "");

			m_panelListe.RemplirGrille();
			m_panelListe.ControlFiltreStandard = new CPanelFiltreChampCustom();

			m_panelListe.MultiSelect = true;
		}
		//-------------------------------------------------------------------
        public override string GetTitle()
        {
            return I.T("Custom Fields list|982");
		}
		

		private void m_panelListe_OnNewObjetDonnee(object sender, sc2i.data.CObjetDonnee nouvelObjet, ref bool bCancel)
		{
            if (bCancel)
                return;
			if ( nouvelObjet is CChampCustom && m_strCodeRole != "" )
				((CChampCustom)nouvelObjet).CodeRole = m_strCodeRole;
		}
	}

	//-------------------------------------------------------------------
	[AutoExec("Autoexec")]
	public class CSelectionneurChampCustomTimos : ISelectionneurChampCustom
	{
		public string m_strCodeRole = "";

		private Type m_typeElementsAChamp = null;


		//-------------------------------------------------------
		public CSelectionneurChampCustomTimos()
		{
		}

		//-------------------------------------------------------
		public static void Autoexec()
		{
			CProprieteChampCustomEditor.SetTypeEditeur(typeof(CSelectionneurChampCustomTimos));
		}

		//-------------------------------------------------------
		public CSelectionneurChampCustomTimos(string strCodeRole)
		{
			m_strCodeRole = strCodeRole;
		}

		//-------------------------------------------------------
		public string CodeRole
		{
			get
			{
				return m_strCodeRole;
			}
			set
			{
				m_strCodeRole = value;
			}
		}

		//-------------------------------------------------------
		public Type TypeElementsAChamp
		{
			get
			{
				return m_typeElementsAChamp;
			}
			set
			{
				m_typeElementsAChamp = value;
				CRoleChampCustom role = CRoleChampCustom.GetRoleForType(m_typeElementsAChamp);
				m_strCodeRole = role.CodeRole;
			}
		}

		//-------------------------------------------------------
		public CChampCustom SelectChamp(CChampCustom lastSelectionne)
		{
			CFormListeChampsCustom form = new CFormListeChampsCustom(m_strCodeRole);
			return (CChampCustom)CFormNavigateurPopupListe.SelectObject ( 
				form, 
				lastSelectionne, 
				CFormNavigateurPopupListe.CalculeContexteUtilisation ( form ));
		}
	}
}



