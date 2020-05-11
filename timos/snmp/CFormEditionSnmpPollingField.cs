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
using timos.snmp.polling;
using System.Data;
using timos.data.snmp.polling;
using data.hotel.client;
using System.Collections.Generic;

namespace timos.snmp
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CSnmpPollingField))]
	public class CFormEditionSnmpPollingField : CFormEditionStdTimos, IFormNavigable
	{
        private DataSet m_dataSetStructurePolling = null;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private Label label3;
        private Label label2;
        private C2iTextBox c2iTextBox1;
        private Label label4;
        private Label label5;
        private C2iComboBox m_cmbColonnePolling;
        private C2iComboBox m_cmbTablePolling;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionSnmpPollingField()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionSnmpPollingField(CSnmpPollingField SnmpPollingField)
			:base(SnmpPollingField)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionSnmpPollingField(CSnmpPollingField SnmpPollingField, CListeObjetsDonnees liste)
			:base(SnmpPollingField, liste)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionSnmpPollingField));
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_cmbTablePolling = new sc2i.win32.common.C2iComboBox();
            this.m_cmbColonnePolling = new sc2i.win32.common.C2iComboBox();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnAnnulerModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnAnnulerModifications, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnulerModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnValiderModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnValiderModifications, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnValiderModifications, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSupprimerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnSupprimerObjet, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSupprimerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnEditerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnEditerObjet, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnEditerObjet, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelNavigation
            // 
            this.m_panelNavigation.Location = new System.Drawing.Point(623, 0);
            this.m_panelNavigation.Size = new System.Drawing.Size(175, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lblNbListes
            // 
            this.m_extStyle.SetStyleBackColor(this.m_lblNbListes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblNbListes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnPrecedent
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnPrecedent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnPrecedent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSuivant
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnAjout
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnAjout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAjout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lblId
            // 
            this.m_extStyle.SetStyleBackColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelCle
            // 
            this.m_panelCle.Location = new System.Drawing.Point(515, 0);
            this.m_panelCle.Size = new System.Drawing.Size(108, 28);
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
            // m_imageCle
            // 
            this.m_extStyle.SetStyleBackColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnChercherObjet
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnChercherObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnChercherObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label1, false);
            this.label1.Location = new System.Drawing.Point(16, 38);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Description|20890";
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Nom");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtLibelle, true);
            this.m_txtLibelle.Location = new System.Drawing.Point(132, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(280, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Nom]";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.m_cmbColonnePolling);
            this.c2iPanelOmbre4.Controls.Add(this.m_cmbTablePolling);
            this.c2iPanelOmbre4.Controls.Add(this.label5);
            this.c2iPanelOmbre4.Controls.Add(this.label4);
            this.c2iPanelOmbre4.Controls.Add(this.label3);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.Controls.Add(this.c2iTextBox1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanelOmbre4, false);
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(665, 201);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(26, 38);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 17);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 3;
            this.label3.Text = "Description|20890";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(26, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nom|20888";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c2iTextBox1
            // 
            this.c2iTextBox1.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.c2iTextBox1, "Description");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iTextBox1, true);
            this.c2iTextBox1.Location = new System.Drawing.Point(132, 37);
            this.c2iTextBox1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox1, "");
            this.c2iTextBox1.Multiline = true;
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(504, 88);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 1;
            this.c2iTextBox1.Text = "[Description]";
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label4, true);
            this.label4.Location = new System.Drawing.Point(26, 129);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 3;
            this.label4.Text = "Polling table|20896";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label5, true);
            this.label5.Location = new System.Drawing.Point(26, 153);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 17);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 3;
            this.label5.Text = "Polling field|20897";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_cmbTablePolling
            // 
            this.m_cmbTablePolling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTablePolling.FormattingEnabled = true;
            this.m_cmbTablePolling.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbTablePolling, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbTablePolling, true);
            this.m_cmbTablePolling.Location = new System.Drawing.Point(132, 128);
            this.m_cmbTablePolling.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTablePolling, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbTablePolling, "");
            this.m_cmbTablePolling.Name = "m_cmbTablePolling";
            this.m_cmbTablePolling.Size = new System.Drawing.Size(283, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTablePolling, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTablePolling, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTablePolling.TabIndex = 4;
            this.m_cmbTablePolling.SelectionChangeCommitted += new System.EventHandler(this.m_cmbTablePolling_SelectionChangeCommitted);
            // 
            // m_cmbColonnePolling
            // 
            this.m_cmbColonnePolling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbColonnePolling.FormattingEnabled = true;
            this.m_cmbColonnePolling.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbColonnePolling, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbColonnePolling, false);
            this.m_cmbColonnePolling.Location = new System.Drawing.Point(132, 152);
            this.m_cmbColonnePolling.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbColonnePolling, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbColonnePolling, "");
            this.m_cmbColonnePolling.Name = "m_cmbColonnePolling";
            this.m_cmbColonnePolling.Size = new System.Drawing.Size(283, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbColonnePolling, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbColonnePolling, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbColonnePolling.TabIndex = 5;
            // 
            // CFormEditionSnmpPollingField
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionSnmpPollingField";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.c2iPanelOmbre4.ResumeLayout(false);
            this.c2iPanelOmbre4.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CSnmpPollingField SnmpPollingField
		{
			get
			{
				return (CSnmpPollingField)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T( "Snmp polling field @1|20889", SnmpPollingField.Nom));
            if (m_dataSetStructurePolling == null )
            {
                try
                {
                    m_dataSetStructurePolling = CSnmpPollingHotelClient.GetServer().GetDataSetModele();
                }
                catch { }
                if (m_dataSetStructurePolling == null)
                    m_dataSetStructurePolling = new DataSet();
            }
            FillTablesPolling();
            m_cmbTablePolling.SelectedValue = SnmpPollingField.HotelTableId;
            FillColonnesPolling();
            m_cmbColonnePolling.SelectedValue = SnmpPollingField.HotelColumnId;
			return result;
		}

        //-------------------------------------------------------------------------
        private void FillTablesPolling()
        {
            List<KeyValuePair<string, string>> lstTables = new List<KeyValuePair<string, string>>();
            lstTables.Add(new KeyValuePair<string, string>("", ""));
            foreach ( DataTable table in m_dataSetStructurePolling.Tables )
            {
                if ( table.ExtendedProperties[CDataHotelTable.c_extPropTableId] is string )
                    lstTables.Add ( new KeyValuePair<string,string>(
                        table.ExtendedProperties[CDataHotelTable.c_extPropTableId].ToString(),
                        table.TableName));
            }
            m_cmbTablePolling.DataSource = lstTables;
            m_cmbTablePolling.DisplayMember="Value";
            m_cmbTablePolling.ValueMember = "Key";
        }

        //-------------------------------------------------------------------------
        private void FillColonnesPolling()
        {
            List<KeyValuePair<string,string>> lstCols = new List<KeyValuePair<string,string>>();
            lstCols.Add(new KeyValuePair<string, string>("", ""));
            string strIdTable = m_cmbTablePolling.SelectedValue as string;
            if ( strIdTable != null )
                foreach ( DataTable table in m_dataSetStructurePolling.Tables )
                {
                    if ( table.ExtendedProperties[CDataHotelTable.c_extPropTableId] == strIdTable )
                    {
                        foreach ( DataColumn col in table.Columns )
                        {
                            if ( col.ExtendedProperties[CDataHotelField.c_extPropColumnId] is string )
                                lstCols.Add ( new KeyValuePair<string,string>(
                                    col.ExtendedProperties[CDataHotelField.c_extPropColumnId].ToString(),
                                    col.ColumnName));
                        }
                    }
                }
            m_cmbColonnePolling.DataSource = lstCols;
            m_cmbColonnePolling.DisplayMember="Value";
            m_cmbColonnePolling.ValueMember = "Key";
        }

		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            if (m_cmbTablePolling.SelectedValue is string)
                SnmpPollingField.HotelTableId = m_cmbTablePolling.SelectedValue.ToString();
            if (m_cmbColonnePolling.SelectedValue is string)
                SnmpPollingField.HotelColumnId = m_cmbColonnePolling.SelectedValue.ToString();
            return base.MAJ_Champs();
        }

        //-------------------------------------------------------------------------
        private void m_cmbTablePolling_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FillColonnesPolling();
        }
	}
}

