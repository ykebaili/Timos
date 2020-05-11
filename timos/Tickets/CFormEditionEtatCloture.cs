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

using timos.data;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CEtatCloture))]
	public class CFormEditionEtatCloture : CFormEditionStdTimos, IFormNavigable
	{
		private System.Windows.Forms.Label lbl_label;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private Label lbl_code;
        private C2iTextBoxNumerique m_txtNumCode;
        private CComboboxAutoFilled m_cmbxSelectEtatDeBase;
        private Label lbl_etatbase;
        private Label label3;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionEtatCloture()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionEtatCloture(CEtatCloture etat)
            : base(etat)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionEtatCloture(CEtatCloture etat, CListeObjetsDonnees liste)
            : base(etat, liste)
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
			this.lbl_label = new System.Windows.Forms.Label();
			this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
			this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
			this.lbl_code = new System.Windows.Forms.Label();
			this.m_txtNumCode = new sc2i.win32.common.C2iTextBoxNumerique();
			this.m_cmbxSelectEtatDeBase = new sc2i.win32.common.CComboboxAutoFilled();
			this.lbl_etatbase = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.c2iPanelOmbre4.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_panelMenu
			// 
			this.m_panelMenu.Size = new System.Drawing.Size(830, 28);
			this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			// 
			// lbl_label
			// 
			this.m_extLinkField.SetLinkField(this.lbl_label, "");
			this.lbl_label.Location = new System.Drawing.Point(16, 16);
			this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_label, sc2i.win32.common.TypeModeEdition.Autonome);
			this.lbl_label.Name = "lbl_label";
			this.lbl_label.Size = new System.Drawing.Size(148, 16);
			this.m_extStyle.SetStyleBackColor(this.lbl_label, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.lbl_label, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.lbl_label.TabIndex = 4002;
			this.lbl_label.Text = "Closing state label|628";
			// 
			// m_txtLibelle
			// 
			this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
			this.m_txtLibelle.Location = new System.Drawing.Point(170, 12);
			this.m_txtLibelle.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_txtLibelle.Name = "m_txtLibelle";
			this.m_txtLibelle.Size = new System.Drawing.Size(350, 20);
			this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_txtLibelle.TabIndex = 0;
			this.m_txtLibelle.Text = "[Label]|30324";
			// 
			// c2iPanelOmbre4
			// 
			this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
			this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
			this.c2iPanelOmbre4.Controls.Add(this.lbl_label);
			this.c2iPanelOmbre4.Controls.Add(this.lbl_code);
			this.c2iPanelOmbre4.Controls.Add(this.m_txtNumCode);
			this.c2iPanelOmbre4.Controls.Add(this.m_cmbxSelectEtatDeBase);
			this.c2iPanelOmbre4.Controls.Add(this.lbl_etatbase);
			this.c2iPanelOmbre4.Controls.Add(this.label3);
			this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
			this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
			this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
			this.c2iPanelOmbre4.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
			this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
			this.c2iPanelOmbre4.Size = new System.Drawing.Size(598, 137);
			this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
			this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
			this.c2iPanelOmbre4.TabIndex = 0;
			// 
			// lbl_code
			// 
			this.m_extLinkField.SetLinkField(this.lbl_code, "");
			this.lbl_code.Location = new System.Drawing.Point(16, 44);
			this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_code, sc2i.win32.common.TypeModeEdition.Autonome);
			this.lbl_code.Name = "lbl_code";
			this.lbl_code.Size = new System.Drawing.Size(148, 13);
			this.m_extStyle.SetStyleBackColor(this.lbl_code, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.lbl_code, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.lbl_code.TabIndex = 4002;
			this.lbl_code.Text = "Closing state code|629";
			// 
			// m_txtNumCode
			// 
			this.m_txtNumCode.Arrondi = 0;
			this.m_txtNumCode.DecimalAutorise = false;
			this.m_txtNumCode.DoubleValue = 0;
			this.m_txtNumCode.IntValue = 0;
			this.m_extLinkField.SetLinkField(this.m_txtNumCode, "");
			this.m_txtNumCode.Location = new System.Drawing.Point(170, 41);
			this.m_txtNumCode.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNumCode, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_txtNumCode.Name = "m_txtNumCode";
			this.m_txtNumCode.NullAutorise = false;
			this.m_txtNumCode.Size = new System.Drawing.Size(116, 20);
			this.m_extStyle.SetStyleBackColor(this.m_txtNumCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_txtNumCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_txtNumCode.TabIndex = 4003;
			this.m_txtNumCode.Text = "0";
			// 
			// m_cmbxSelectEtatDeBase
			// 
			this.m_cmbxSelectEtatDeBase.FormattingEnabled = true;
			this.m_cmbxSelectEtatDeBase.IsLink = false;
			this.m_extLinkField.SetLinkField(this.m_cmbxSelectEtatDeBase, "");
			this.m_cmbxSelectEtatDeBase.ListDonnees = null;
			this.m_cmbxSelectEtatDeBase.Location = new System.Drawing.Point(170, 71);
			this.m_cmbxSelectEtatDeBase.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxSelectEtatDeBase, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_cmbxSelectEtatDeBase.Name = "m_cmbxSelectEtatDeBase";
			this.m_cmbxSelectEtatDeBase.NullAutorise = false;
			this.m_cmbxSelectEtatDeBase.ProprieteAffichee = null;
			this.m_cmbxSelectEtatDeBase.Size = new System.Drawing.Size(116, 21);
			this.m_extStyle.SetStyleBackColor(this.m_cmbxSelectEtatDeBase, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_cmbxSelectEtatDeBase, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_cmbxSelectEtatDeBase.TabIndex = 4004;
			this.m_cmbxSelectEtatDeBase.TextNull = "";
			this.m_cmbxSelectEtatDeBase.Tri = true;
			// 
			// lbl_etatbase
			// 
			this.m_extLinkField.SetLinkField(this.lbl_etatbase, "");
			this.lbl_etatbase.Location = new System.Drawing.Point(17, 74);
			this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_etatbase, sc2i.win32.common.TypeModeEdition.Autonome);
			this.lbl_etatbase.Name = "lbl_etatbase";
			this.lbl_etatbase.Size = new System.Drawing.Size(147, 18);
			this.m_extStyle.SetStyleBackColor(this.lbl_etatbase, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.lbl_etatbase, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.lbl_etatbase.TabIndex = 4002;
			this.lbl_etatbase.Text = "Derives from basic state|630";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.m_extLinkField.SetLinkField(this.label3, "");
			this.label3.Location = new System.Drawing.Point(16, 44);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 13);
			this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label3.TabIndex = 4002;
			this.label3.Text = "Closing state code|30261";
			// 
			// CFormEditionEtatCloture
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(830, 530);
			this.Controls.Add(this.c2iPanelOmbre4);
			this.m_extLinkField.SetLinkField(this, "");
			this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.Name = "CFormEditionEtatCloture";
			this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.Text = "[Code]";
			this.Controls.SetChildIndex(this.m_panelMenu, 0);
			this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
			this.c2iPanelOmbre4.ResumeLayout(false);
			this.c2iPanelOmbre4.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CEtatCloture EtatCloture
		{
			get
			{
				return (CEtatCloture)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T( "Closing state|671") + ": " + EtatCloture.Libelle);

            // Init Code état
            CListeObjetsDonnees lst = new CListeObjetsDonnees(EtatCloture.ContexteDonnee, typeof(CEtatCloture));
            lst.Tri = CEtatCloture.c_champCode;
            int count = lst.Count;
            if (count > 0 && EtatCloture.IsNew())
            {
                int lastCode = ((CEtatCloture)lst[count - 1]).Code;
                m_txtNumCode.IntValue = ++lastCode;
            }
            else
            {
                m_txtNumCode.IntValue = EtatCloture.Code;
            }

            // Combo Etat de Base
            m_cmbxSelectEtatDeBase.Fill(
                CUtilSurEnum.GetEnumsALibelle(typeof(CEtatClotureBase)),
                "Libelle",
                false);
            m_cmbxSelectEtatDeBase.SelectedValue = (CEtatClotureBase) EtatCloture.EtatBase;
            
			return result;
		}
		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();

            if (result)
                EtatCloture.EtatBase = (CEtatClotureBase)m_cmbxSelectEtatDeBase.SelectedValue;
            if (result)
                EtatCloture.Code = (int)m_txtNumCode.IntValue;

            return result;
        }
	}
}

