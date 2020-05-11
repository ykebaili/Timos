using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.documents;

using sc2i.win32.common;
using sc2i.win32.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using timos.Properties;

namespace timos
{
	[DynamicForm("Report visualization")]
	public class CFormListeVisualisationsRapport : CFormMaxiSansMenu, IFormNavigable
	{
		protected sc2i.win32.common.ListViewAutoFilled m_listView;
		protected CListeObjetsDonnees m_listeObjets = null;
		protected CContexteFormNavigable m_contexte;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn1;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn2;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees m_cmbCategorie;

		private System.ComponentModel.IContainer components = null;

		public CFormListeVisualisationsRapport()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
			m_listeObjets = new CListeObjetsDonnees( CSc2iWin32DataClient.ContexteCourant, typeof(C2iRapportCrystal), false );
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

		#region Code généré par le concepteur
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.m_listView = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cmbCategorie = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.SuspendLayout();
            // 
            // m_listView
            // 
            this.m_listView.AllowColumnReorder = true;
            this.m_listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn1,
            this.listViewAutoFilledColumn2});
            this.m_listView.EnableCustomisation = true;
            this.m_listView.FullRowSelect = true;
            this.m_listView.Location = new System.Drawing.Point(0, 32);
            this.m_listView.Name = "m_listView";
            this.m_listView.Size = new System.Drawing.Size(476, 364);
            this.m_extStyle.SetStyleBackColor(this.m_listView, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_listView, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_listView.TabIndex = 4;
            this.m_listView.UseCompatibleStateImageBehavior = false;
            this.m_listView.View = System.Windows.Forms.View.Details;
            this.m_listView.DoubleClick += new System.EventHandler(this.m_listView_DoubleClick);
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Report|1005";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 200;
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.Field = "CategorieRapport.Libelle";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Category|852";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 120;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 16);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 5;
            this.label1.Text = "Filter by category|1004";
            // 
            // m_cmbCategorie
            // 
            this.m_cmbCategorie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbCategorie.ComportementLinkStd = true;
            this.m_cmbCategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbCategorie.ElementSelectionne = null;
            this.m_cmbCategorie.IsLink = false;
            this.m_cmbCategorie.LinkProperty = "";
            this.m_cmbCategorie.ListDonnees = null;
            this.m_cmbCategorie.Location = new System.Drawing.Point(120, 4);
            this.m_cmbCategorie.LockEdition = false;
            this.m_cmbCategorie.Name = "m_cmbCategorie";
            this.m_cmbCategorie.NullAutorise = true;
            this.m_cmbCategorie.ProprieteAffichee = null;
            this.m_cmbCategorie.ProprieteParentListeObjets = null;
            this.m_cmbCategorie.SelectionneurParent = null;
            this.m_cmbCategorie.Size = new System.Drawing.Size(356, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbCategorie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbCategorie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbCategorie.TabIndex = 6;
            this.m_cmbCategorie.TextNull = I.T("(All)|30329");
            this.m_cmbCategorie.Tri = true;
            this.m_cmbCategorie.TypeFormEdition = null;
            this.m_cmbCategorie.SelectedValueChanged += new System.EventHandler(this.m_cmbCategorie_SelectedValueChanged);
            // 
            // CFormListeVisualisationsRapport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(480, 400);
            this.Controls.Add(this.m_cmbCategorie);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_listView);
            this.Name = "CFormListeVisualisationsRapport";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.CFormListeVisualisationsRapport_Closing);
            this.Load += new System.EventHandler(this.CFormListeVisualisationsRapport_Load);
            this.ResumeLayout(false);

		}
		#endregion

        public event ContexteFormEventHandler AfterGetContexte;
        public event ContexteFormEventHandler AfterInitFromContexte;
		//-------------------------------------------------------------------
		public CContexteFormNavigable GetContexte()
		{
			CContexteFormNavigable ctx = new CContexteFormNavigable(GetType() );
			//ctx["ListeObjets"] = CStockeurObjetPersistant.GetPersistantData(m_listeObjets);
			CStringSerializer serializer = new CStringSerializer(ModeSerialisation.Ecriture);
			I2iSerializable obj = m_listeObjets;
			serializer.TraiteObject ( ref obj );
			ctx["ListeObjets"] = serializer.String;
            if (AfterGetContexte != null)
                AfterGetContexte(this, ctx);
			return ctx;
		}
		//-------------------------------------------------------------------
		public CResultAErreur InitFromContexte(CContexteFormNavigable ctx)
		{
			CResultAErreur result = CResultAErreur.True;
			m_contexte = ctx;
			/*m_listeObjets = (CListeObjetsDonnees)CStockeurObjetPersistant.AlloueFromPersistantData(
				(byte[])ctx["ListeObjets"], CSc2iWin32DataClient.ContexteCourant );*/
			CStringSerializer serializer = new CStringSerializer((string)ctx["ListeObjets"], ModeSerialisation.Lecture);
			I2iSerializable obj = null;
			if ( serializer.TraiteObject ( ref obj, CSc2iWin32DataClient.ContexteCourant ))
				m_listeObjets = (CListeObjetsDonnees)obj;
			else
				m_listeObjets = null;
            if (AfterInitFromContexte != null)
                AfterInitFromContexte(this, ctx);
			return result;
		}

        //------------------------------------------------------------------
        public CResultAErreur Actualiser()
        {
            return InitFromContexte(GetContexte());
        }

		//-------------------------------------------------------------------
		private bool m_bComboCatIsInit = false;
		private CResultAErreur InitComboCategorie(bool bForce)
		{
			
			CResultAErreur result = CResultAErreur.True;
			if (m_bComboCatIsInit && !bForce)
				return result;
			result = m_cmbCategorie.Init(typeof(C2iCategorieRapportCrystal), "Libelle" ,false );
			if (result)
				m_bComboCatIsInit = true;
			return result;
		}
		//-------------------------------------------------------------------
		private void m_cmbCategorie_SelectedValueChanged(object sender, System.EventArgs e)
		{
			if (!m_bComboCatIsInit)
				return;
			m_listeObjets.Filtre = null;
			if (m_cmbCategorie.SelectedValue!=null)
			{
				int nId = ((C2iCategorieRapportCrystal)m_cmbCategorie.SelectedValue).Id;
				m_listeObjets.Filtre = new CFiltreData(C2iCategorieRapportCrystal.c_champId + " = @1", nId );
			}
			m_listView.Remplir(m_listeObjets);
		}
		//-------------------------------------------------------------------
		private void CFormListeVisualisationsRapport_Load(object sender, System.EventArgs e)
		{
			if ( !DesignMode )
			{
				CSc2iWin32DataNavigationRegistre.ReadListViewAutoFilled( m_listView, this.Name );
				m_listView.Remplir(m_listeObjets);
			}

			CResultAErreur result = InitComboCategorie(false);
            
			CSc2iWin32DataNavigation.Navigateur.TitreFenetreEnCours = I.T( "Crystal Reports list|1003");
			CCustomiseurFenetresStandard.BrancheSurFenetre ( this );
		}
		//-------------------------------------------------------------------
		private void CFormListeVisualisationsRapport_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			CSc2iWin32DataNavigationRegistre.SaveListViewAutoFilled( m_listView, this.Name );
		}
		//-------------------------------------------------------------------
		public bool QueryClose()
		{
			return true;
		}
		//-------------------------------------------------------------------
		private void m_listView_DoubleClick(object sender, System.EventArgs e)
		{
			C2iRapportCrystal rapport = (C2iRapportCrystal) m_listView.SelectedItems[0].Tag;
			CFormVisualisationRapport frm = new CFormVisualisationRapport(rapport);
			CSc2iWin32DataNavigation.Navigateur.AffichePage(frm);
		}

		//-------------------------------------------------------------------
        public virtual Image GetImage()
        {
            return Resources.report;
        }

        //-------------------------------------------------------------------
        public virtual string GetTitle()
        {
            return I.T("Crystal Reports list|1003");
        }
    
	}
}

