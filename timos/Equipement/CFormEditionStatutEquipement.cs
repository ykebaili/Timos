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

using timos.data;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CStatutEquipement))]
	public class CFormEditionStatutEquipement : CFormEditionStdTimos, IFormNavigable
	{
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
		private CComboboxAutoFilled m_cmbStatutDeBase;
		private C2iTextBox c2iTextBox1;
		private Label label2;
		private Label label3;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionStatutEquipement()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionStatutEquipement(CStatutEquipement StatutEquipement)
			:base(StatutEquipement)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionStatutEquipement(CStatutEquipement StatutEquipement, CListeObjetsDonnees liste)
			:base(StatutEquipement, liste)
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
			this.label3 = new System.Windows.Forms.Label();
			this.m_cmbStatutDeBase = new sc2i.win32.common.CComboboxAutoFilled();
			this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.c2iPanelOmbre4.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_panelMenu
			// 
			this.m_panelMenu.Size = new System.Drawing.Size(830, 28);
			this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.m_extLinkField.SetLinkField(this.label1, "");
			this.label1.Location = new System.Drawing.Point(16, 12);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 13);
			this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label1.TabIndex = 4002;
			this.label1.Text = "Label|50";
			// 
			// m_txtLibelle
			// 
			this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
			this.m_txtLibelle.Location = new System.Drawing.Point(120, 8);
			this.m_txtLibelle.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_txtLibelle.Name = "m_txtLibelle";
			this.m_txtLibelle.Size = new System.Drawing.Size(292, 20);
			this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_txtLibelle.TabIndex = 0;
			this.m_txtLibelle.Text = "[Label]|30324";
			// 
			// c2iPanelOmbre4
			// 
			this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
			this.c2iPanelOmbre4.Controls.Add(this.label3);
			this.c2iPanelOmbre4.Controls.Add(this.m_cmbStatutDeBase);
			this.c2iPanelOmbre4.Controls.Add(this.c2iTextBox1);
			this.c2iPanelOmbre4.Controls.Add(this.label1);
			this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
			this.c2iPanelOmbre4.Controls.Add(this.label2);
			this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
			this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
			this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
			this.c2iPanelOmbre4.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
			this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
			this.c2iPanelOmbre4.Size = new System.Drawing.Size(440, 113);
			this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
			this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
			this.c2iPanelOmbre4.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.m_extLinkField.SetLinkField(this.label3, "");
			this.label3.Location = new System.Drawing.Point(16, 61);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(86, 13);
			this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label3.TabIndex = 4006;
			this.label3.Text = "Base status|232";
			// 
			// m_cmbStatutDeBase
			// 
			this.m_cmbStatutDeBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cmbStatutDeBase.FormattingEnabled = true;
			this.m_cmbStatutDeBase.IsLink = false;
			this.m_extLinkField.SetLinkField(this.m_cmbStatutDeBase, "");
			this.m_cmbStatutDeBase.ListDonnees = null;
			this.m_cmbStatutDeBase.Location = new System.Drawing.Point(120, 58);
			this.m_cmbStatutDeBase.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbStatutDeBase, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_cmbStatutDeBase.Name = "m_cmbStatutDeBase";
			this.m_cmbStatutDeBase.NullAutorise = false;
			this.m_cmbStatutDeBase.ProprieteAffichee = null;
			this.m_cmbStatutDeBase.Size = new System.Drawing.Size(200, 21);
			this.m_extStyle.SetStyleBackColor(this.m_cmbStatutDeBase, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_cmbStatutDeBase, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_cmbStatutDeBase.TabIndex = 4005;
            this.m_cmbStatutDeBase.TextNull = I.T("(empty)|30195");
			this.m_cmbStatutDeBase.Tri = true;
			// 
			// c2iTextBox1
			// 
			this.m_extLinkField.SetLinkField(this.c2iTextBox1, "Code");
			this.c2iTextBox1.Location = new System.Drawing.Point(120, 32);
			this.c2iTextBox1.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.c2iTextBox1.Name = "c2iTextBox1";
			this.c2iTextBox1.Size = new System.Drawing.Size(292, 20);
			this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.c2iTextBox1.TabIndex = 4004;
			this.c2iTextBox1.Text = "[Code]";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.m_extLinkField.SetLinkField(this.label2, "");
			this.label2.Location = new System.Drawing.Point(16, 35);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 13);
			this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label2.TabIndex = 4003;
			this.label2.Text = "Code|231";
			// 
			// CFormEditionStatutEquipement
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(830, 530);
			this.Controls.Add(this.c2iPanelOmbre4);
			this.m_extLinkField.SetLinkField(this, "");
			this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.Name = "CFormEditionStatutEquipement";
			this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.Controls.SetChildIndex(this.m_panelMenu, 0);
			this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
			this.c2iPanelOmbre4.ResumeLayout(false);
			this.c2iPanelOmbre4.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CStatutEquipement StatutEquipement
		{
			get
			{
				return (CStatutEquipement)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T( "Equipment status|230")+" "+StatutEquipement.Libelle);

			m_cmbStatutDeBase.Fill ( 
                CUtilSurEnum.GetEnumsALibelle(typeof(CStatutBaseEquipement)),
                "Libelle",
                false );

			m_cmbStatutDeBase.SelectedValue = (CStatutBaseEquipement) StatutEquipement.StatutDeBase;



			return result;
		}
		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();

			if(result)
				StatutEquipement.StatutDeBase = (CStatutBaseEquipement)m_cmbStatutDeBase.SelectedValue;

			return result;
        }
	}
}

