using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;

using timos.acteurs;
using System.Collections.Generic;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CTypeCaracteristiqueEntite))]
	public class CFormEditionTypeCaracteristiqueEntite : CFormEditionStdTimos, IFormNavigable
	{
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
		private C2iTextBox c2iTextBox1;
		private Label label2;
		private CComboboxAutoFilled m_cmbRoleFormulaire;
		private Label label3;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionTypeCaracteristiqueEntite()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeCaracteristiqueEntite(CTypeCaracteristiqueEntite typeCaracteristiqueEntite)
			:base(typeCaracteristiqueEntite)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeCaracteristiqueEntite(CTypeCaracteristiqueEntite typeCaracteristiqueEntite, CListeObjetsDonnees liste)
			:base(typeCaracteristiqueEntite, liste)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
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
			this.label1 = new System.Windows.Forms.Label();
			this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
			this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
			this.m_cmbRoleFormulaire = new sc2i.win32.common.CComboboxAutoFilled();
			this.label3 = new System.Windows.Forms.Label();
			this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.m_panelCle.SuspendLayout();
			this.m_panelMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
			this.c2iPanelOmbre4.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_btnAnnulerModifications
			// 
			this.m_extLinkField.SetLinkField(this.m_btnAnnulerModifications, "");
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnulerModifications, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extStyle.SetStyleBackColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			// 
			// m_btnValiderModifications
			// 
			this.m_extLinkField.SetLinkField(this.m_btnValiderModifications, "");
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extStyle.SetStyleBackColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			// 
			// m_btnSupprimerObjet
			// 
			this.m_extLinkField.SetLinkField(this.m_btnSupprimerObjet, "");
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSupprimerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extStyle.SetStyleBackColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			// 
			// m_btnEditerObjet
			// 
			this.m_extLinkField.SetLinkField(this.m_btnEditerObjet, "");
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extStyle.SetStyleBackColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			// 
			// m_panelNavigation
			// 
			this.m_panelNavigation.Location = new System.Drawing.Point(754, 0);
			this.m_extStyle.SetStyleBackColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			// 
			// m_panelCle
			// 
			this.m_panelCle.Location = new System.Drawing.Point(610, 0);
			this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			// 
			// m_panelMenu
			// 
			this.m_panelMenu.Size = new System.Drawing.Size(830, 28);
			this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			// 
			// m_btnHistorique
			// 
			this.m_extStyle.SetStyleBackColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			// 
			// label1
			// 
			this.m_extLinkField.SetLinkField(this.label1, "");
			this.label1.Location = new System.Drawing.Point(16, 11);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.label1, "");
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(110, 13);
			this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label1.TabIndex = 4002;
			this.label1.Text = "Label|50";
			// 
			// m_txtLibelle
			// 
			this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
			this.m_txtLibelle.Location = new System.Drawing.Point(132, 8);
			this.m_txtLibelle.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
			this.m_txtLibelle.Name = "m_txtLibelle";
			this.m_txtLibelle.Size = new System.Drawing.Size(376, 20);
			this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_txtLibelle.TabIndex = 0;
			this.m_txtLibelle.Text = "[Label]|30324";
			// 
			// c2iPanelOmbre4
			// 
			this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
			this.c2iPanelOmbre4.Controls.Add(this.m_cmbRoleFormulaire);
			this.c2iPanelOmbre4.Controls.Add(this.label3);
			this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
			this.c2iPanelOmbre4.Controls.Add(this.c2iTextBox1);
			this.c2iPanelOmbre4.Controls.Add(this.label2);
			this.c2iPanelOmbre4.Controls.Add(this.label1);
			this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
			this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
			this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
			this.c2iPanelOmbre4.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
			this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
			this.c2iPanelOmbre4.Size = new System.Drawing.Size(529, 156);
			this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
			this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
			this.c2iPanelOmbre4.TabIndex = 0;
			// 
			// m_cmbRoleFormulaire
			// 
			this.m_cmbRoleFormulaire.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cmbRoleFormulaire.IsLink = false;
			this.m_extLinkField.SetLinkField(this.m_cmbRoleFormulaire, "");
			this.m_cmbRoleFormulaire.ListDonnees = null;
			this.m_cmbRoleFormulaire.Location = new System.Drawing.Point(132, 106);
			this.m_cmbRoleFormulaire.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbRoleFormulaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_extModulesAssociator.SetModules(this.m_cmbRoleFormulaire, "");
			this.m_cmbRoleFormulaire.Name = "m_cmbRoleFormulaire";
			this.m_cmbRoleFormulaire.NullAutorise = true;
			this.m_cmbRoleFormulaire.ProprieteAffichee = "Libelle";
			this.m_cmbRoleFormulaire.Size = new System.Drawing.Size(376, 21);
			this.m_extStyle.SetStyleBackColor(this.m_cmbRoleFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_cmbRoleFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_cmbRoleFormulaire.TabIndex = 2;
            this.m_cmbRoleFormulaire.TextNull = I.T("General form|30331");
			this.m_cmbRoleFormulaire.Tri = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.m_extLinkField.SetLinkField(this.label3, "");
			this.label3.Location = new System.Drawing.Point(16, 109);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.label3, "");
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(66, 13);
			this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label3.TabIndex = 4003;
			this.label3.Text = "Purpose|898";
			// 
			// c2iTextBox1
			// 
			this.c2iTextBox1.AcceptsReturn = true;
			this.m_extLinkField.SetLinkField(this.c2iTextBox1, "Description");
			this.c2iTextBox1.Location = new System.Drawing.Point(132, 34);
			this.c2iTextBox1.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_extModulesAssociator.SetModules(this.c2iTextBox1, "");
			this.c2iTextBox1.Multiline = true;
			this.c2iTextBox1.Name = "c2iTextBox1";
			this.c2iTextBox1.Size = new System.Drawing.Size(376, 66);
			this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.c2iTextBox1.TabIndex = 1;
			this.c2iTextBox1.Text = "[Description]";
			// 
			// label2
			// 
			this.m_extLinkField.SetLinkField(this.label2, "");
			this.label2.Location = new System.Drawing.Point(16, 37);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.label2, "");
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(110, 13);
			this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label2.TabIndex = 4002;
			this.label2.Text = "Description|41";
			// 
			// CFormEditionTypeCaracteristiqueEntite
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(830, 530);
			this.Controls.Add(this.c2iPanelOmbre4);
			this.m_extLinkField.SetLinkField(this, "");
			this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this, "");
			this.Name = "CFormEditionTypeCaracteristiqueEntite";
			this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.Controls.SetChildIndex(this.m_panelMenu, 0);
			this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
			this.m_panelCle.ResumeLayout(false);
			this.m_panelCle.PerformLayout();
			this.m_panelMenu.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
			this.c2iPanelOmbre4.ResumeLayout(false);
			this.c2iPanelOmbre4.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CTypeCaracteristiqueEntite TypeCaracteristiqueEntite
		{
			get
			{
				return (CTypeCaracteristiqueEntite)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();

			CRoleChampCustom[] roles = CRoleChampCustom.Roles;
			List<CRoleChampCustom> rolesACaracteristiques = new List<CRoleChampCustom>();
			foreach (CRoleChampCustom role in roles)
			{
				Type tp = role.TypeAssocie;
				//if (tp != null && typeof(IElementACaracteristique).IsAssignableFrom(tp))
					rolesACaracteristiques.Add(role);
			}
			m_cmbRoleFormulaire.ListDonnees = rolesACaracteristiques;
			m_cmbRoleFormulaire.SelectedValue = TypeCaracteristiqueEntite.Role;

			AffecterTitre(I.T("Characteristic type @1|20041", TypeCaracteristiqueEntite.Libelle));
			return result;
		}

		

		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result =  base.MAJ_Champs();
			if (result)
			{
				TypeCaracteristiqueEntite.Role = m_cmbRoleFormulaire.SelectedValue as CRoleChampCustom;
			}
			return result;
        }

		
	}
}

