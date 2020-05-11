using sc2i.common;

namespace timos.acteurs
{
	partial class CControlEditionTypeElementAContacts
	{
		/// <summary> 
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur de composants

		/// <summary> 
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_lnkRemove = new sc2i.win32.common.CWndLinkStd();
            this.m_lvProfils = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn5 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn6 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_lblProfil = new System.Windows.Forms.Label();
            this.m_cmbProfils = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.m_lnkAjouterProfil = new sc2i.win32.common.CWndLinkStd();
            this.m_wndListeFormatNumerotation = new sc2i.win32.common.ListViewAutoFilled();
            this.m_lblModeleContact = new System.Windows.Forms.Label();
            this.m_cmbModeleActeur = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
			this.m_ctrlMD = new sc2i.win32.common.CCtrlUpDownListView();
            this.listViewAutoFilledColumn3 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn4 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_gestionnaireLstProfils = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.SuspendLayout();
            // 
            // m_lnkRemove
            // 
            this.m_lnkRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkRemove.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkRemove.Location = new System.Drawing.Point(3, 277);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkRemove, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkRemove.Name = "m_lnkRemove";
            this.m_lnkRemove.Size = new System.Drawing.Size(104, 16);
            this.m_lnkRemove.TabIndex = 4021;
            this.m_lnkRemove.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkRemove.LinkClicked += new System.EventHandler(this.m_lnkRemove_LinkClicked);
            // 
            // m_lvProfils
            // 
            this.m_lvProfils.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lvProfils.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn5,
            this.listViewAutoFilledColumn6});
            this.m_lvProfils.EnableCustomisation = true;
            this.m_lvProfils.FullRowSelect = true;
            this.m_lvProfils.HideSelection = false;
            this.m_lvProfils.Location = new System.Drawing.Point(3, 86);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lvProfils, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lvProfils.MultiSelect = false;
            this.m_lvProfils.Name = "m_lvProfils";
            this.m_lvProfils.Size = new System.Drawing.Size(302, 185);
            this.m_lvProfils.TabIndex = 4018;
            this.m_lvProfils.UseCompatibleStateImageBehavior = false;
            this.m_lvProfils.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn5
            // 
            this.listViewAutoFilledColumn5.Field = "Ordre";
            this.listViewAutoFilledColumn5.PrecisionWidth = 0;
            this.listViewAutoFilledColumn5.ProportionnalSize = false;
            this.listViewAutoFilledColumn5.Text = "Order|782";
            this.listViewAutoFilledColumn5.Visible = true;
            this.listViewAutoFilledColumn5.Width = 99;
            // 
            // listViewAutoFilledColumn6
            // 
            this.listViewAutoFilledColumn6.Field = "Profil.Libelle";
            this.listViewAutoFilledColumn6.PrecisionWidth = 0;
            this.listViewAutoFilledColumn6.ProportionnalSize = false;
            this.listViewAutoFilledColumn6.Text = "Profile|141";
            this.listViewAutoFilledColumn6.Visible = true;
            this.listViewAutoFilledColumn6.Width = 150;
            // 
            // m_lblProfil
            // 
            this.m_lblProfil.AutoSize = true;
            this.m_lblProfil.Location = new System.Drawing.Point(39, 45);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblProfil, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblProfil.Name = "m_lblProfil";
            this.m_lblProfil.Size = new System.Drawing.Size(95, 13);
            this.m_lblProfil.TabIndex = 4017;
            this.m_lblProfil.Text = "Contact profile|781";
            // 
            // m_cmbProfils
            // 
            this.m_cmbProfils.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbProfils.ComportementLinkStd = true;
            this.m_cmbProfils.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbProfils.ElementSelectionne = null;
            this.m_cmbProfils.FormattingEnabled = true;
            this.m_cmbProfils.IsLink = false;
            this.m_cmbProfils.LinkProperty = "";
            this.m_cmbProfils.ListDonnees = null;
            this.m_cmbProfils.Location = new System.Drawing.Point(80, 59);
            this.m_cmbProfils.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbProfils, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbProfils.Name = "m_cmbProfils";
            this.m_cmbProfils.NullAutorise = false;
            this.m_cmbProfils.ProprieteAffichee = null;
            this.m_cmbProfils.ProprieteParentListeObjets = null;
            this.m_cmbProfils.SelectionneurParent = null;
            this.m_cmbProfils.Size = new System.Drawing.Size(225, 21);
            this.m_cmbProfils.TabIndex = 4020;
            this.m_cmbProfils.TextNull = I.T("(empty)|30195");
            this.m_cmbProfils.Tri = true;
            this.m_cmbProfils.TypeFormEdition = null;
            // 
            // m_lnkAjouterProfil
            // 
            this.m_lnkAjouterProfil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouterProfil.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkAjouterProfil.Location = new System.Drawing.Point(3, 62);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouterProfil, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAjouterProfil.Name = "m_lnkAjouterProfil";
            this.m_lnkAjouterProfil.Size = new System.Drawing.Size(104, 16);
            this.m_lnkAjouterProfil.TabIndex = 4019;
            this.m_lnkAjouterProfil.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouterProfil.LinkClicked += new System.EventHandler(this.m_lnkAjouterProfil_LinkClicked);
            // 
            // m_wndListeFormatNumerotation
            // 
            this.m_wndListeFormatNumerotation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_wndListeFormatNumerotation.EnableCustomisation = true;
            this.m_wndListeFormatNumerotation.FullRowSelect = true;
            this.m_wndListeFormatNumerotation.HideSelection = false;
            this.m_wndListeFormatNumerotation.Location = new System.Drawing.Point(6, 68);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeFormatNumerotation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_wndListeFormatNumerotation.MultiSelect = false;
            this.m_wndListeFormatNumerotation.Name = "m_wndListeFormatNumerotation";
            this.m_wndListeFormatNumerotation.Size = new System.Drawing.Size(238, 158);
            this.m_wndListeFormatNumerotation.TabIndex = 4012;
            this.m_wndListeFormatNumerotation.UseCompatibleStateImageBehavior = false;
            this.m_wndListeFormatNumerotation.View = System.Windows.Forms.View.Details;
            // 
            // m_lblModeleContact
            // 
            this.m_lblModeleContact.Location = new System.Drawing.Point(39, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblModeleContact, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblModeleContact.Name = "m_lblModeleContact";
            this.m_lblModeleContact.Size = new System.Drawing.Size(149, 13);
            this.m_lblModeleContact.TabIndex = 4024;
            this.m_lblModeleContact.Text = "Contacts format|780";
            // 
            // m_cmbModeleActeur
            // 
            this.m_cmbModeleActeur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbModeleActeur.ComportementLinkStd = true;
            this.m_cmbModeleActeur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbModeleActeur.ElementSelectionne = null;
            this.m_cmbModeleActeur.FormattingEnabled = true;
            this.m_cmbModeleActeur.IsLink = false;
            this.m_cmbModeleActeur.LinkProperty = "";
            this.m_cmbModeleActeur.ListDonnees = null;
            this.m_cmbModeleActeur.Location = new System.Drawing.Point(80, 19);
            this.m_cmbModeleActeur.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbModeleActeur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbModeleActeur.Name = "m_cmbModeleActeur";
            this.m_cmbModeleActeur.NullAutorise = true;
            this.m_cmbModeleActeur.ProprieteAffichee = null;
            this.m_cmbModeleActeur.ProprieteParentListeObjets = null;
            this.m_cmbModeleActeur.SelectionneurParent = null;
            this.m_cmbModeleActeur.Size = new System.Drawing.Size(225, 21);
            this.m_cmbModeleActeur.TabIndex = 4023;
            this.m_cmbModeleActeur.TextNull = I.T("(empty)|30195");
            this.m_cmbModeleActeur.Tri = true;
            this.m_cmbModeleActeur.TypeFormEdition = null;
            // 
            // m_ctrlMD
            // 
            this.m_ctrlMD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ctrlMD.ListeGeree = this.m_lvProfils;
            this.m_ctrlMD.Location = new System.Drawing.Point(254, 277);
            this.m_ctrlMD.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_ctrlMD, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_ctrlMD.Name = "m_ctrlMD";
            this.m_ctrlMD.ProprieteNumero = "Ordre";
            this.m_ctrlMD.Size = new System.Drawing.Size(51, 20);
            this.m_ctrlMD.TabIndex = 4016;
            this.m_ctrlMD.ApresRenumeration += new System.EventHandler(this.m_ctrlMD_ApresRenumeration);
            // 
            // listViewAutoFilledColumn3
            // 
            this.listViewAutoFilledColumn3.Field = "TicketEsclave.DescriptionElement";
            this.listViewAutoFilledColumn3.PrecisionWidth = 0;
            this.listViewAutoFilledColumn3.ProportionnalSize = false;
            this.listViewAutoFilledColumn3.Text = "Ticket label|30320";
            this.listViewAutoFilledColumn3.Visible = true;
            this.listViewAutoFilledColumn3.Width = 150;
            // 
            // listViewAutoFilledColumn4
            // 
            this.listViewAutoFilledColumn4.Field = "ClotureAutoEscalve";
            this.listViewAutoFilledColumn4.PrecisionWidth = 0;
            this.listViewAutoFilledColumn4.ProportionnalSize = false;
            this.listViewAutoFilledColumn4.Text = "Cloture Auto";
            this.listViewAutoFilledColumn4.Visible = true;
            this.listViewAutoFilledColumn4.Width = 80;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Label|50";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 120;
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.Field = "FormatNumerotation.Libelle";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Type|54";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 110;
            // 
            // m_gestionnaireLstProfils
            // 
            this.m_gestionnaireLstProfils.ListeAssociee = this.m_lvProfils;
            this.m_gestionnaireLstProfils.ObjetEdite = null;
            // 
            // CControlEditionTypeElementAContacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_lblModeleContact);
            this.Controls.Add(this.m_cmbModeleActeur);
            this.Controls.Add(this.m_cmbProfils);
            this.Controls.Add(this.m_lnkRemove);
            this.Controls.Add(this.m_lvProfils);
            this.Controls.Add(this.m_lnkAjouterProfil);
            this.Controls.Add(this.m_lblProfil);
            this.Controls.Add(this.m_ctrlMD);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControlEditionTypeElementAContacts";
            this.Size = new System.Drawing.Size(318, 302);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn3;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn4;
		private sc2i.win32.common.CCtrlUpDownListView m_ctrlMD;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn1;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn2;
		private sc2i.win32.common.ListViewAutoFilled m_wndListeFormatNumerotation;
		private sc2i.win32.common.ListViewAutoFilled m_lvProfils;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn5;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn6;
		private sc2i.win32.common.CWndLinkStd m_lnkRemove;
		private System.Windows.Forms.Label m_lblProfil;
		private sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees m_cmbProfils;
		private sc2i.win32.common.CWndLinkStd m_lnkAjouterProfil;
		private sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee m_gestionnaireLstProfils;
		private System.Windows.Forms.Label m_lblModeleContact;
		private sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees m_cmbModeleActeur;
	}
}
