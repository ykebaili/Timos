using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using sc2i.win32.navigation;
using sc2i.data;
using sc2i.win32.data;
using sc2i.win32.data.navigation;

using sc2i.common;
using timos.data;
using sc2i.win32.common;

namespace timos
{
	public class CFormListeGroupesStd : CFormListeStandardTimos, IFormNavigable
	{
		private CGestionnaireAjoutModifSuppObjetDonnee m_gestionnaireForArbre = null;
		private bool m_bModeListe = true;
		private System.Windows.Forms.Panel m_panelVueHierarchique;
		private System.Windows.Forms.RadioButton m_chkVueListe;
		private System.Windows.Forms.RadioButton m_chkVueArbre;
		private sc2i.win32.common.CWndLinkStd m_btnAjouter;
		private sc2i.win32.common.CWndLinkStd m_btnDetail;
		private sc2i.win32.common.CWndLinkStd m_btnSupprimer;
		private System.Windows.Forms.TreeView m_arbre;
        private C2iPanelFondDegradeStd m_panelVues;
        private C2iPanelFondDegradeStd m_panelBarreMenuVueArbre;
		private System.ComponentModel.IContainer components = null;

		private CFormListeGroupesStd()
		{
		}

		public CFormListeGroupesStd( Type typeObjets)
			:base(typeObjets)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormListeGroupesStd));
            this.m_panelVueHierarchique = new System.Windows.Forms.Panel();
            this.m_panelBarreMenuVueArbre = new sc2i.win32.common.C2iPanelFondDegradeStd();
            this.m_btnAjouter = new sc2i.win32.common.CWndLinkStd();
            this.m_btnDetail = new sc2i.win32.common.CWndLinkStd();
            this.m_btnSupprimer = new sc2i.win32.common.CWndLinkStd();
            this.m_arbre = new System.Windows.Forms.TreeView();
            this.m_chkVueListe = new System.Windows.Forms.RadioButton();
            this.m_chkVueArbre = new System.Windows.Forms.RadioButton();
            this.m_panelVues = new sc2i.win32.common.C2iPanelFondDegradeStd();
            this.m_panelMilieu.SuspendLayout();
            this.m_panelVueHierarchique.SuspendLayout();
            this.m_panelBarreMenuVueArbre.SuspendLayout();
            this.m_panelVues.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelListe
            // 
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Name";
            glColumn1.Propriete = "Libelle";
            glColumn1.Text = "Label|50";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 300;
            this.m_panelListe.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_panelListe.Size = new System.Drawing.Size(666, 376);
            this.m_extStyle.SetStyleBackColor(this.m_panelListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelGauche
            // 
            this.m_panelGauche.Size = new System.Drawing.Size(0, 376);
            this.m_extStyle.SetStyleBackColor(this.m_panelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelDroit
            // 
            this.m_panelDroit.Location = new System.Drawing.Point(666, 0);
            this.m_panelDroit.Size = new System.Drawing.Size(0, 376);
            this.m_extStyle.SetStyleBackColor(this.m_panelDroit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDroit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelBas
            // 
            this.m_panelBas.Location = new System.Drawing.Point(0, 376);
            this.m_panelBas.Size = new System.Drawing.Size(666, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelHaut
            // 
            this.m_panelHaut.Size = new System.Drawing.Size(666, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMilieu
            // 
            this.m_panelMilieu.Controls.Add(this.m_panelVues);
            this.m_panelMilieu.Controls.Add(this.m_panelVueHierarchique);
            this.m_panelMilieu.Size = new System.Drawing.Size(666, 376);
            this.m_extStyle.SetStyleBackColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMilieu.Controls.SetChildIndex(this.m_panelListe, 0);
            this.m_panelMilieu.Controls.SetChildIndex(this.m_panelVueHierarchique, 0);
            this.m_panelMilieu.Controls.SetChildIndex(this.m_panelVues, 0);
            // 
            // m_panelVueHierarchique
            // 
            this.m_panelVueHierarchique.Controls.Add(this.m_arbre);
            this.m_panelVueHierarchique.Controls.Add(this.m_panelBarreMenuVueArbre);
            this.m_panelVueHierarchique.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelVueHierarchique.Location = new System.Drawing.Point(0, 0);
            this.m_panelVueHierarchique.Name = "m_panelVueHierarchique";
            this.m_panelVueHierarchique.Size = new System.Drawing.Size(666, 376);
            this.m_extStyle.SetStyleBackColor(this.m_panelVueHierarchique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelVueHierarchique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelVueHierarchique.TabIndex = 2;
            // 
            // m_panelBarreMenuVueArbre
            // 
            this.m_panelBarreMenuVueArbre.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_panelBarreMenuVueArbre.BackgroundImage")));
            this.m_panelBarreMenuVueArbre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_panelBarreMenuVueArbre.Controls.Add(this.m_btnAjouter);
            this.m_panelBarreMenuVueArbre.Controls.Add(this.m_btnDetail);
            this.m_panelBarreMenuVueArbre.Controls.Add(this.m_btnSupprimer);
            this.m_panelBarreMenuVueArbre.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelBarreMenuVueArbre.Location = new System.Drawing.Point(0, 0);
            this.m_panelBarreMenuVueArbre.Name = "m_panelBarreMenuVueArbre";
            this.m_panelBarreMenuVueArbre.Size = new System.Drawing.Size(666, 32);
            this.m_extStyle.SetStyleBackColor(this.m_panelBarreMenuVueArbre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelBarreMenuVueArbre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelBarreMenuVueArbre.TabIndex = 4;
            // 
            // m_btnAjouter
            // 
            this.m_btnAjouter.BackColor = System.Drawing.Color.Transparent;
            this.m_btnAjouter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnAjouter.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_btnAjouter.Location = new System.Drawing.Point(132, 4);
            this.m_btnAjouter.Name = "m_btnAjouter";
            this.m_btnAjouter.Size = new System.Drawing.Size(72, 24);
            this.m_extStyle.SetStyleBackColor(this.m_btnAjouter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAjouter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAjouter.TabIndex = 0;
            this.m_btnAjouter.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_btnAjouter.LinkClicked += new System.EventHandler(this.m_btnAjouter_LinkClicked);
            // 
            // m_btnDetail
            // 
            this.m_btnDetail.BackColor = System.Drawing.Color.Transparent;
            this.m_btnDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnDetail.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_btnDetail.Location = new System.Drawing.Point(208, 4);
            this.m_btnDetail.Name = "m_btnDetail";
            this.m_btnDetail.Size = new System.Drawing.Size(72, 24);
            this.m_extStyle.SetStyleBackColor(this.m_btnDetail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnDetail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnDetail.TabIndex = 1;
            this.m_btnDetail.TypeLien = sc2i.win32.common.TypeLinkStd.Modification;
            this.m_btnDetail.LinkClicked += new System.EventHandler(this.m_btnModifier_LinkClicked);
            // 
            // m_btnSupprimer
            // 
            this.m_btnSupprimer.BackColor = System.Drawing.Color.Transparent;
            this.m_btnSupprimer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnSupprimer.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_btnSupprimer.Location = new System.Drawing.Point(280, 4);
            this.m_btnSupprimer.Name = "m_btnSupprimer";
            this.m_btnSupprimer.Size = new System.Drawing.Size(105, 24);
            this.m_extStyle.SetStyleBackColor(this.m_btnSupprimer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSupprimer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnSupprimer.TabIndex = 2;
            this.m_btnSupprimer.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_btnSupprimer.LinkClicked += new System.EventHandler(this.m_btnSupprimer_LinkClicked);
            // 
            // m_arbre
            // 
            this.m_arbre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_arbre.Location = new System.Drawing.Point(0, 32);
            this.m_arbre.Name = "m_arbre";
            this.m_arbre.Size = new System.Drawing.Size(666, 344);
            this.m_extStyle.SetStyleBackColor(this.m_arbre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_arbre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_arbre.TabIndex = 3;
            // 
            // m_chkVueListe
            // 
            this.m_chkVueListe.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_chkVueListe.BackColor = System.Drawing.Color.Transparent;
            this.m_chkVueListe.FlatAppearance.BorderSize = 0;
            this.m_chkVueListe.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.m_chkVueListe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkVueListe.Image = global::timos.Properties.Resources.view_list;
            this.m_chkVueListe.Location = new System.Drawing.Point(2, 0);
            this.m_chkVueListe.Name = "m_chkVueListe";
            this.m_chkVueListe.Size = new System.Drawing.Size(26, 24);
            this.m_extStyle.SetStyleBackColor(this.m_chkVueListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkVueListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkVueListe.TabIndex = 0;
            this.m_chkVueListe.UseVisualStyleBackColor = false;
            this.m_chkVueListe.CheckedChanged += new System.EventHandler(this.m_chkVueListe_CheckedChanged);
            // 
            // m_chkVueArbre
            // 
            this.m_chkVueArbre.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_chkVueArbre.BackColor = System.Drawing.Color.Transparent;
            this.m_chkVueArbre.FlatAppearance.BorderSize = 0;
            this.m_chkVueArbre.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.m_chkVueArbre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkVueArbre.Image = global::timos.Properties.Resources.View_tree;
            this.m_chkVueArbre.Location = new System.Drawing.Point(30, 0);
            this.m_chkVueArbre.Name = "m_chkVueArbre";
            this.m_chkVueArbre.Size = new System.Drawing.Size(28, 24);
            this.m_extStyle.SetStyleBackColor(this.m_chkVueArbre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkVueArbre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkVueArbre.TabIndex = 3;
            this.m_chkVueArbre.UseVisualStyleBackColor = false;
            this.m_chkVueArbre.CheckedChanged += new System.EventHandler(this.m_chkVueArbre_CheckedChanged);
            // 
            // m_panelVues
            // 
            this.m_panelVues.BackColor = System.Drawing.Color.Transparent;
            this.m_panelVues.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_panelVues.BackgroundImage")));
            this.m_panelVues.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_panelVues.Controls.Add(this.m_chkVueListe);
            this.m_panelVues.Controls.Add(this.m_chkVueArbre);
            this.m_panelVues.Location = new System.Drawing.Point(489, 1);
            this.m_panelVues.Name = "m_panelVues";
            this.m_panelVues.Size = new System.Drawing.Size(69, 24);
            this.m_extStyle.SetStyleBackColor(this.m_panelVues, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelVues, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelVues.TabIndex = 6;
            // 
            // CFormListeGroupesStd
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(666, 376);
            this.Name = "CFormListeGroupesStd";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Load += new System.EventHandler(this.CFormListeGroupesStd_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.CFormListeGroupesStd_Closing);
            this.m_panelMilieu.ResumeLayout(false);
            this.m_panelVueHierarchique.ResumeLayout(false);
            this.m_panelBarreMenuVueArbre.ResumeLayout(false);
            this.m_panelVues.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		//A surcharger !!!
		public virtual Type GetTypeGroupe(){return null;}
		public virtual Type GetTypeFormEdition(){return null;}

		protected override void InitPanel()
		{
			m_bModeListe = new CTimosAppRegistre().GetIsVueListeForFormListeGroupe(GetType());
			m_chkVueArbre.Checked = !m_bModeListe;
			m_chkVueListe.Checked = m_bModeListe;
			InitAffichage();

			m_gestionnaireForArbre = new CGestionnaireAjoutModifSuppObjetDonnee (
				GetTypeGroupe(),
				GetTypeFormEdition(),
				null,
				"");

			m_panelListe.InitFromListeObjets ( 
				m_listeObjets,
				GetTypeGroupe(),
				GetTypeFormEdition(),
				null,
				"" );

			m_panelListe.RemplirGrille();

			InitAffichage();
		}

		//-------------------------------------------------------------------
		private void FillNode ( TreeNode nodeParent )
		{
			CGroupeStructurant groupe = null;
			IList liste = null;
			if ( nodeParent != null )
			{
				groupe = (CGroupeStructurant)nodeParent.Tag;
				liste = new ArrayList();
				foreach ( IRelationGroupeGroupeNecessaire relation in groupe.RelationsGroupesNecessitants )
					liste.Add ( relation.GroupeNecessitant );
			}
			else
			{
				liste = new CListeObjetsDonnees ( sc2i.win32.data.CSc2iWin32DataClient.ContexteCourant, GetTypeGroupe() );
				string strNomTable = CContexteDonnee.GetNomTableForType ( GetTypeGroupe() );
				((CListeObjetsDonnees)liste).Filtre = new CFiltreDataAvance ( strNomTable, "HasNo(RelationsGroupesNecessitants.Id)");
			}
			foreach ( CGroupeStructurant grp in liste )
			{
				TreeNode node = new TreeNode ( grp.Libelle );
				node.Tag = grp;
				if ( nodeParent == null )
					m_arbre.Nodes.Add ( node );
				else
					nodeParent.Nodes.Add ( node );
				FillNode ( node );
			}
			m_arbre.Sorted = true;
		}

		/// /////////////////////////////////////////
		private void CFormListeGroupesStd_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			new CTimosAppRegistre().SetIsVueListeForFormListeGroupe ( GetType(), m_bModeListe );
		}

		/// /////////////////////////////////////////
		private void InitAffichage()
		{
			m_panelVueHierarchique.Visible = !m_bModeListe;
			base.m_panelListe.Visible = m_bModeListe;
			if ( !m_bModeListe )
			{
				if ( m_arbre.Nodes.Count == 0 )
					FillNode ( null );
				m_panelVueHierarchique.BringToFront();
			}
			else
				base.m_panelListe.BringToFront();
			m_chkVueArbre.BringToFront();
			m_chkVueListe.BringToFront();
            m_panelVues.BringToFront();
		}

		/// /////////////////////////////////////////
		private void m_chkVueListe_CheckedChanged(object sender, System.EventArgs e)
		{
			m_bModeListe = m_chkVueListe.Checked;
			InitAffichage();
		}

		/// /////////////////////////////////////////
		private void m_chkVueArbre_CheckedChanged(object sender, System.EventArgs e)
		{
			m_bModeListe = !m_chkVueArbre.Checked;
			InitAffichage();
		}

		/// ///////////////////////////////////////////////////////////
		private CGroupeStructurant ElementSelectionneDansArbre
		{
			get
			{
				TreeNode node = m_arbre.SelectedNode;
				if ( node != null )
					return (CGroupeStructurant)node.Tag;
				return null;
			}
		}
					

		/// <summary>
		/// ///////////////////////////////////////////////////////////
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_btnAjouter_LinkClicked(object sender, System.EventArgs e)
		{
			CGroupeStructurant groupeParent = ElementSelectionneDansArbre;
			CResultAErreur result = m_gestionnaireForArbre.Ajouter ( null, null );
			if ( !result )
				CFormAlerte.Afficher ( result.Erreur );
		}

		/// ///////////////////////////////////////////////////////////
		private void m_btnModifier_LinkClicked(object sender, System.EventArgs e)
		{
			CGroupeStructurant groupe = ElementSelectionneDansArbre;
			if ( groupe != null )
			{
				CResultAErreur result = m_gestionnaireForArbre.Modifier ( groupe, null, AffectationsPourNouveauxElements );
				if ( !result )
					CFormAlerte.Afficher ( result.Erreur );
			}
		}

		/// ///////////////////////////////////////////////////////////
		private void m_btnSupprimer_LinkClicked(object sender, System.EventArgs e)
		{
			CGroupeStructurant groupe = ElementSelectionneDansArbre;
			if ( groupe != null )
			{
				ArrayList list =  new ArrayList();
				list.Add ( groupe );
				CResultAErreur result = m_gestionnaireForArbre.Supprimer ( list );
				if ( !result )
					CFormAlerte.Afficher ( result.Erreur );
			}
			TreeNode node = m_arbre.SelectedNode;
			if ( node != null )
			{
				TreeNode nodeParent = node.Parent;
				if ( nodeParent != null )
				{
					nodeParent.Nodes.Clear();
					FillNode ( nodeParent );
				}
				else
				{
					m_arbre.Nodes.Clear();
					FillNode ( null );
				}
			}
		}

		private void CFormListeGroupesStd_Load(object sender, System.EventArgs e)
		{
			m_chkVueArbre.BringToFront();
			m_chkVueListe.BringToFront();
		}

		
		
	}
}

