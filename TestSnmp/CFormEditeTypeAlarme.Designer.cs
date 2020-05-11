namespace TestSnmp
{
    partial class CFormEditeTypeAlarme
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtNom = new System.Windows.Forms.TextBox();
            this.m_wndListeChamps = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.m_lnkAjouterChamp = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkSupprimerChamp = new sc2i.win32.common.CWndLinkStd();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lblTypeParent = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_panelActionsSurParent = new System.Windows.Forms.Panel();
            this.m_txtFormuleSurParent = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtFormuleLibelleAlarme = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_cmbEtatCreation = new System.Windows.Forms.ComboBox();
            this.m_cmbModeCaluclEtat = new System.Windows.Forms.ComboBox();
            this.m_panelActionsSurParent.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom";
            // 
            // m_txtNom
            // 
            this.m_txtNom.Location = new System.Drawing.Point(100, 13);
            this.m_txtNom.Name = "m_txtNom";
            this.m_txtNom.Size = new System.Drawing.Size(204, 20);
            this.m_txtNom.TabIndex = 1;
            // 
            // m_wndListeChamps
            // 
            this.m_wndListeChamps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.m_wndListeChamps.Location = new System.Drawing.Point(14, 213);
            this.m_wndListeChamps.MultiSelect = false;
            this.m_wndListeChamps.Name = "m_wndListeChamps";
            this.m_wndListeChamps.Size = new System.Drawing.Size(382, 167);
            this.m_wndListeChamps.TabIndex = 2;
            this.m_wndListeChamps.UseCompatibleStateImageBehavior = false;
            this.m_wndListeChamps.View = System.Windows.Forms.View.Details;
            this.m_wndListeChamps.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.m_wndListeChamps_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Champ";
            this.columnHeader1.Width = 350;
            // 
            // m_lnkAjouterChamp
            // 
            this.m_lnkAjouterChamp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouterChamp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkAjouterChamp.Location = new System.Drawing.Point(14, 183);
            this.m_lnkAjouterChamp.Name = "m_lnkAjouterChamp";
            this.m_lnkAjouterChamp.Size = new System.Drawing.Size(66, 24);
            this.m_lnkAjouterChamp.TabIndex = 3;
            this.m_lnkAjouterChamp.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouterChamp.LinkClicked += new System.EventHandler(this.m_lnkAjouterChamp_LinkClicked);
            // 
            // m_lnkSupprimerChamp
            // 
            this.m_lnkSupprimerChamp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimerChamp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkSupprimerChamp.Location = new System.Drawing.Point(110, 183);
            this.m_lnkSupprimerChamp.Name = "m_lnkSupprimerChamp";
            this.m_lnkSupprimerChamp.Size = new System.Drawing.Size(125, 24);
            this.m_lnkSupprimerChamp.TabIndex = 4;
            this.m_lnkSupprimerChamp.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimerChamp.LinkClicked += new System.EventHandler(this.m_lnkSupprimerChamp_LinkClicked);
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Location = new System.Drawing.Point(214, 386);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(75, 23);
            this.m_btnAnnuler.TabIndex = 7;
            this.m_btnAnnuler.Text = "Annuler";
            this.m_btnAnnuler.UseVisualStyleBackColor = true;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // m_btnOk
            // 
            this.m_btnOk.Location = new System.Drawing.Point(114, 386);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(75, 23);
            this.m_btnOk.TabIndex = 6;
            this.m_btnOk.Text = "Ok";
            this.m_btnOk.UseVisualStyleBackColor = true;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Type parent";
            // 
            // m_lblTypeParent
            // 
            this.m_lblTypeParent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblTypeParent.Location = new System.Drawing.Point(100, 36);
            this.m_lblTypeParent.Name = "m_lblTypeParent";
            this.m_lblTypeParent.Size = new System.Drawing.Size(204, 23);
            this.m_lblTypeParent.TabIndex = 9;
            this.m_lblTypeParent.Text = "label3";
            this.m_lblTypeParent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 23);
            this.label3.TabIndex = 10;
            this.label3.Text = "Actions sur parent";
            // 
            // m_panelActionsSurParent
            // 
            this.m_panelActionsSurParent.Controls.Add(this.m_txtFormuleSurParent);
            this.m_panelActionsSurParent.Controls.Add(this.label3);
            this.m_panelActionsSurParent.Location = new System.Drawing.Point(0, 62);
            this.m_panelActionsSurParent.Name = "m_panelActionsSurParent";
            this.m_panelActionsSurParent.Size = new System.Drawing.Size(418, 32);
            this.m_panelActionsSurParent.TabIndex = 11;
            // 
            // m_txtFormuleSurParent
            // 
            this.m_txtFormuleSurParent.AllowGraphic = true;
            this.m_txtFormuleSurParent.Formule = null;
            this.m_txtFormuleSurParent.Location = new System.Drawing.Point(112, 7);
            this.m_txtFormuleSurParent.LockEdition = false;
            this.m_txtFormuleSurParent.LockZoneTexte = false;
            this.m_txtFormuleSurParent.Name = "m_txtFormuleSurParent";
            this.m_txtFormuleSurParent.Size = new System.Drawing.Size(303, 20);
            this.m_txtFormuleSurParent.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(11, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 23);
            this.label4.TabIndex = 12;
            this.label4.Text = "Libellé des alarmes";
            // 
            // m_txtFormuleLibelleAlarme
            // 
            this.m_txtFormuleLibelleAlarme.AllowGraphic = true;
            this.m_txtFormuleLibelleAlarme.Formule = null;
            this.m_txtFormuleLibelleAlarme.Location = new System.Drawing.Point(112, 95);
            this.m_txtFormuleLibelleAlarme.LockEdition = false;
            this.m_txtFormuleLibelleAlarme.LockZoneTexte = false;
            this.m_txtFormuleLibelleAlarme.Name = "m_txtFormuleLibelleAlarme";
            this.m_txtFormuleLibelleAlarme.Size = new System.Drawing.Size(303, 22);
            this.m_txtFormuleLibelleAlarme.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(11, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 23);
            this.label5.TabIndex = 14;
            this.label5.Text = "Etat à la création";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(11, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 23);
            this.label6.TabIndex = 15;
            this.label6.Text = "Calcul de l\'état";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cmbEtatCreation
            // 
            this.m_cmbEtatCreation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbEtatCreation.FormattingEnabled = true;
            this.m_cmbEtatCreation.Location = new System.Drawing.Point(112, 122);
            this.m_cmbEtatCreation.Name = "m_cmbEtatCreation";
            this.m_cmbEtatCreation.Size = new System.Drawing.Size(248, 21);
            this.m_cmbEtatCreation.TabIndex = 16;
            // 
            // m_cmbModeCaluclEtat
            // 
            this.m_cmbModeCaluclEtat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbModeCaluclEtat.FormattingEnabled = true;
            this.m_cmbModeCaluclEtat.Location = new System.Drawing.Point(112, 149);
            this.m_cmbModeCaluclEtat.Name = "m_cmbModeCaluclEtat";
            this.m_cmbModeCaluclEtat.Size = new System.Drawing.Size(248, 21);
            this.m_cmbModeCaluclEtat.TabIndex = 17;
            // 
            // CFormEditeTypeAlarme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 425);
            this.Controls.Add(this.m_cmbModeCaluclEtat);
            this.Controls.Add(this.m_cmbEtatCreation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_txtFormuleLibelleAlarme);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_panelActionsSurParent);
            this.Controls.Add(this.m_lblTypeParent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_btnAnnuler);
            this.Controls.Add(this.m_btnOk);
            this.Controls.Add(this.m_lnkSupprimerChamp);
            this.Controls.Add(this.m_lnkAjouterChamp);
            this.Controls.Add(this.m_wndListeChamps);
            this.Controls.Add(this.m_txtNom);
            this.Controls.Add(this.label1);
            this.Name = "CFormEditeTypeAlarme";
            this.Text = "Type d\'alarme";
            this.Load += new System.EventHandler(this.CFormEditeTypeAlarme_Load);
            this.m_panelActionsSurParent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_txtNom;
        private System.Windows.Forms.ListView m_wndListeChamps;
        private sc2i.win32.common.CWndLinkStd m_lnkAjouterChamp;
        private sc2i.win32.common.CWndLinkStd m_lnkSupprimerChamp;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button m_btnAnnuler;
        private System.Windows.Forms.Button m_btnOk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label m_lblTypeParent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel m_panelActionsSurParent;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleSurParent;
        private System.Windows.Forms.Label label4;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleLibelleAlarme;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox m_cmbEtatCreation;
        private System.Windows.Forms.ComboBox m_cmbModeCaluclEtat;
    }
}