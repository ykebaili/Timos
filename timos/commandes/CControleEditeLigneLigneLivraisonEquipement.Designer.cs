namespace timos.commandes
{
    partial class CControleEditeLigneLivraisonEquipement
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
            this.m_panelData = new System.Windows.Forms.Panel();
            this.m_selectTypeEquipement = new sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide();
            this.m_txtSelectReference = new sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide();
            this.m_panelContainer = new sc2i.win32.common.C2iPanel(this.components);
            this.m_cmbEquipementConteneur = new sc2i.win32.data.navigation.CComboBoxArbreObjetDonneesHierarchique();
            this.m_editCoordonnee = new timos.coordonnees.CControlEditeCoordonnee();
            this.m_txtSerial = new sc2i.win32.common.C2iTextBox();
            this.m_panelPoubelle = new System.Windows.Forms.Panel();
            this.m_lnkEditer = new sc2i.win32.common.CWndLinkStd();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_chkEstRecue = new System.Windows.Forms.CheckBox();
            this.m_panelData.SuspendLayout();
            this.m_panelContainer.SuspendLayout();
            this.m_panelPoubelle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelData
            // 
            this.m_panelData.Controls.Add(this.m_selectTypeEquipement);
            this.m_panelData.Controls.Add(this.m_txtSelectReference);
            this.m_panelData.Controls.Add(this.m_panelContainer);
            this.m_panelData.Controls.Add(this.m_txtSerial);
            this.m_panelData.Controls.Add(this.m_panelPoubelle);
            this.m_panelData.Controls.Add(this.panel1);
            this.m_panelData.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelData.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelData, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelData.Name = "m_panelData";
            this.m_panelData.Size = new System.Drawing.Size(992, 22);
            this.m_panelData.TabIndex = 2;
            // 
            // m_selectTypeEquipement
            // 
            this.m_selectTypeEquipement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_selectTypeEquipement.ElementSelectionne = null;
            this.m_selectTypeEquipement.Location = new System.Drawing.Point(58, 0);
            this.m_selectTypeEquipement.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_selectTypeEquipement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_selectTypeEquipement.Name = "m_selectTypeEquipement";
            this.m_selectTypeEquipement.SelectedObject = null;
            this.m_selectTypeEquipement.SelectionLength = 0;
            this.m_selectTypeEquipement.SelectionStart = 0;
            this.m_selectTypeEquipement.Size = new System.Drawing.Size(285, 22);
            this.m_selectTypeEquipement.TabIndex = 0;
            this.m_selectTypeEquipement.OnSelectedObjectChanged += new System.EventHandler(this.m_selectTypeEquipement_OnSelectedObjectChanged);
            // 
            // m_txtSelectReference
            // 
            this.m_txtSelectReference.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_txtSelectReference.ElementSelectionne = null;
            this.m_txtSelectReference.Location = new System.Drawing.Point(343, 0);
            this.m_txtSelectReference.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtSelectReference, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtSelectReference.Name = "m_txtSelectReference";
            this.m_txtSelectReference.SelectedObject = null;
            this.m_txtSelectReference.SelectionLength = 0;
            this.m_txtSelectReference.SelectionStart = 0;
            this.m_txtSelectReference.Size = new System.Drawing.Size(192, 22);
            this.m_txtSelectReference.TabIndex = 1;
            this.m_txtSelectReference.OnSelectedObjectChanged += new System.EventHandler(this.m_txtSelectReference_OnSelectedObjectChanged);
            // 
            // m_panelContainer
            // 
            this.m_panelContainer.Controls.Add(this.m_cmbEquipementConteneur);
            this.m_panelContainer.Controls.Add(this.m_editCoordonnee);
            this.m_panelContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_panelContainer.Location = new System.Drawing.Point(535, 0);
            this.m_panelContainer.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_panelContainer, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelContainer.Name = "m_panelContainer";
            this.m_panelContainer.Size = new System.Drawing.Size(318, 22);
            this.m_panelContainer.TabIndex = 19;
            // 
            // m_cmbEquipementConteneur
            // 
            this.m_cmbEquipementConteneur.AutoriserFilsDeAutorises = true;
            this.m_cmbEquipementConteneur.BackColor = System.Drawing.Color.White;
            this.m_cmbEquipementConteneur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_cmbEquipementConteneur.ElementSelectionne = null;
            this.m_cmbEquipementConteneur.Location = new System.Drawing.Point(0, 0);
            this.m_cmbEquipementConteneur.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_cmbEquipementConteneur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbEquipementConteneur.Name = "m_cmbEquipementConteneur";
            this.m_cmbEquipementConteneur.NullAutorise = false;
            this.m_cmbEquipementConteneur.Size = new System.Drawing.Size(170, 21);
            this.m_cmbEquipementConteneur.TabIndex = 0;
            this.m_cmbEquipementConteneur.TextNull = "[None]";
            this.m_cmbEquipementConteneur.ElementSelectionneChanged += new System.EventHandler(this.m_cmbEquipement_ElementSelectionneChanged);
            // 
            // m_editCoordonnee
            // 
            this.m_editCoordonnee.Coordonnee = "";
            this.m_editCoordonnee.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_editCoordonnee.Location = new System.Drawing.Point(170, 0);
            this.m_editCoordonnee.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_editCoordonnee, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_editCoordonnee.Name = "m_editCoordonnee";
            this.m_editCoordonnee.Size = new System.Drawing.Size(148, 22);
            this.m_editCoordonnee.TabIndex = 1;
            // 
            // m_txtSerial
            // 
            this.m_txtSerial.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_txtSerial.EmptyText = "";
            this.m_txtSerial.Location = new System.Drawing.Point(853, 0);
            this.m_txtSerial.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtSerial, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtSerial.Name = "m_txtSerial";
            this.m_txtSerial.Size = new System.Drawing.Size(81, 20);
            this.m_txtSerial.TabIndex = 2;
            this.m_txtSerial.TextChanged += new System.EventHandler(this.m_txtSerial_TextChanged);
            // 
            // m_panelPoubelle
            // 
            this.m_panelPoubelle.BackColor = System.Drawing.Color.White;
            this.m_panelPoubelle.Controls.Add(this.m_lnkEditer);
            this.m_panelPoubelle.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_panelPoubelle.Location = new System.Drawing.Point(934, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelPoubelle, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelPoubelle.Name = "m_panelPoubelle";
            this.m_panelPoubelle.Size = new System.Drawing.Size(58, 22);
            this.m_panelPoubelle.TabIndex = 3;
            // 
            // m_lnkEditer
            // 
            this.m_lnkEditer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkEditer.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkEditer.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkEditer.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lnkEditer, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkEditer.Name = "m_lnkEditer";
            this.m_lnkEditer.Size = new System.Drawing.Size(26, 22);
            this.m_lnkEditer.TabIndex = 0;
            this.m_lnkEditer.TabStop = false;
            this.m_lnkEditer.TypeLien = sc2i.win32.common.TypeLinkStd.Modification;
            this.m_lnkEditer.LinkClicked += new System.EventHandler(this.m_lnkEditer_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.m_chkEstRecue);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(58, 22);
            this.panel1.TabIndex = 0;
            // 
            // m_chkEstRecue
            // 
            this.m_chkEstRecue.Location = new System.Drawing.Point(16, 0);
            this.m_extModeEdition.SetModeEdition(this.m_chkEstRecue, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkEstRecue.Name = "m_chkEstRecue";
            this.m_chkEstRecue.Size = new System.Drawing.Size(19, 22);
            this.m_chkEstRecue.TabIndex = 0;
            this.m_chkEstRecue.UseVisualStyleBackColor = true;
            this.m_chkEstRecue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_chkEstRecue_MouseDown);
            this.m_chkEstRecue.CheckedChanged += new System.EventHandler(this.m_chkEstRecue_CheckedChanged);
            // 
            // CControleEditeLigneLivraisonEquipement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ColorInactive = System.Drawing.Color.White;
            this.Controls.Add(this.m_panelData);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleEditeLigneLivraisonEquipement";
            this.Size = new System.Drawing.Size(992, 22);
            this.m_panelData.ResumeLayout(false);
            this.m_panelData.PerformLayout();
            this.m_panelContainer.ResumeLayout(false);
            this.m_panelPoubelle.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_panelData;
        private sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide m_txtSelectReference;
        private sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide m_selectTypeEquipement;
        private sc2i.win32.common.C2iTextBox m_txtSerial;
        private System.Windows.Forms.Panel m_panelPoubelle;
        private sc2i.win32.common.CWndLinkStd m_lnkEditer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox m_chkEstRecue;
        private sc2i.win32.data.navigation.CComboBoxArbreObjetDonneesHierarchique m_cmbEquipementConteneur;
        private timos.coordonnees.CControlEditeCoordonnee m_editCoordonnee;
        private sc2i.win32.common.C2iPanel m_panelContainer;
    }
}
