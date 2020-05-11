namespace TimosInventory.ControleInventaire
{
    partial class CControlePourInventaire
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControlePourInventaire));
            this.m_panelTop = new System.Windows.Forms.Panel();
            this.m_txtComment = new System.Windows.Forms.TextBox();
            this.m_panelTypeEquipement = new System.Windows.Forms.Panel();
            this.m_panelSerial = new System.Windows.Forms.Panel();
            this.m_txtSerial = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_panelCoord = new System.Windows.Forms.Panel();
            this.m_btnExpand = new System.Windows.Forms.Button();
            this.m_btnAdd = new System.Windows.Forms.Button();
            this.m_panelMarge = new System.Windows.Forms.Panel();
            this.m_error = new System.Windows.Forms.ErrorProvider(this.components);
            this.m_panelChampsCustom = new System.Windows.Forms.Panel();
            this.m_panelBas = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.m_lblLigneBas = new System.Windows.Forms.Label();
            this.m_selectPresence = new TimosInventory.CControlPresence();
            this.m_selectTypeEquipement = new TimosInventory.ControleInventaire.CControleTypeEquipement();
            this.m_txtCoord = new TimosInventory.CTxtSaisieCoordonnee();
            this.m_panelTop.SuspendLayout();
            this.m_panelTypeEquipement.SuspendLayout();
            this.m_panelSerial.SuspendLayout();
            this.m_panelCoord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_error)).BeginInit();
            this.m_panelBas.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelTop
            // 
            this.m_panelTop.Controls.Add(this.m_txtComment);
            this.m_panelTop.Controls.Add(this.m_selectPresence);
            this.m_panelTop.Controls.Add(this.m_panelTypeEquipement);
            this.m_panelTop.Controls.Add(this.m_panelSerial);
            this.m_panelTop.Controls.Add(this.m_panelCoord);
            this.m_panelTop.Controls.Add(this.m_btnExpand);
            this.m_panelTop.Controls.Add(this.m_btnAdd);
            this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTop.Location = new System.Drawing.Point(47, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelTop.Name = "m_panelTop";
            this.m_panelTop.Size = new System.Drawing.Size(740, 42);
            this.m_panelTop.TabIndex = 0;
            // 
            // m_txtComment
            // 
            this.m_txtComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtComment.Location = new System.Drawing.Point(501, 0);
            this.m_extModeEdition.SetModeEdition(this.m_txtComment, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtComment.Multiline = true;
            this.m_txtComment.Name = "m_txtComment";
            this.m_txtComment.Size = new System.Drawing.Size(84, 42);
            this.m_txtComment.TabIndex = 1;
            this.m_txtComment.TextChanged += new System.EventHandler(this.m_txtComment_TextChanged);
            // 
            // m_panelTypeEquipement
            // 
            this.m_panelTypeEquipement.Controls.Add(this.m_selectTypeEquipement);
            this.m_panelTypeEquipement.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelTypeEquipement.Location = new System.Drawing.Point(256, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelTypeEquipement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelTypeEquipement.Name = "m_panelTypeEquipement";
            this.m_panelTypeEquipement.Size = new System.Drawing.Size(245, 42);
            this.m_panelTypeEquipement.TabIndex = 5;
            // 
            // m_panelSerial
            // 
            this.m_panelSerial.Controls.Add(this.m_txtSerial);
            this.m_panelSerial.Controls.Add(this.panel1);
            this.m_panelSerial.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelSerial.Location = new System.Drawing.Point(140, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelSerial, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelSerial.Name = "m_panelSerial";
            this.m_panelSerial.Size = new System.Drawing.Size(116, 42);
            this.m_panelSerial.TabIndex = 4;
            // 
            // m_txtSerial
            // 
            this.m_txtSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtSerial.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_txtSerial, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtSerial.Multiline = true;
            this.m_txtSerial.Name = "m_txtSerial";
            this.m_txtSerial.Size = new System.Drawing.Size(99, 42);
            this.m_txtSerial.TabIndex = 0;
            this.m_txtSerial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtSerial.TextChanged += new System.EventHandler(this.m_txtSerial_TextChanged);
            this.m_txtSerial.Validated += new System.EventHandler(this.m_txtSerial_Validated);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(99, 0);
            this.m_extModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(17, 42);
            this.panel1.TabIndex = 1;
            // 
            // m_panelCoord
            // 
            this.m_panelCoord.Controls.Add(this.m_txtCoord);
            this.m_panelCoord.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelCoord.Location = new System.Drawing.Point(28, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelCoord, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelCoord.Name = "m_panelCoord";
            this.m_panelCoord.Size = new System.Drawing.Size(112, 42);
            this.m_panelCoord.TabIndex = 3;
            // 
            // m_btnExpand
            // 
            this.m_btnExpand.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnExpand.Image = ((System.Drawing.Image)(resources.GetObject("m_btnExpand.Image")));
            this.m_btnExpand.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnExpand, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnExpand.Name = "m_btnExpand";
            this.m_btnExpand.Size = new System.Drawing.Size(28, 42);
            this.m_btnExpand.TabIndex = 0;
            this.m_btnExpand.UseVisualStyleBackColor = true;
            this.m_btnExpand.Click += new System.EventHandler(this.m_btnExpand_Click);
            // 
            // m_btnAdd
            // 
            this.m_btnAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnAdd.Image = global::TimosInventory.Properties.Resources.add;
            this.m_btnAdd.Location = new System.Drawing.Point(716, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnAdd, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnAdd.Name = "m_btnAdd";
            this.m_btnAdd.Size = new System.Drawing.Size(24, 42);
            this.m_btnAdd.TabIndex = 3;
            this.m_btnAdd.UseVisualStyleBackColor = true;
            this.m_btnAdd.Click += new System.EventHandler(this.m_btnAdd_Click);
            // 
            // m_panelMarge
            // 
            this.m_panelMarge.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelMarge.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelMarge, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelMarge.Name = "m_panelMarge";
            this.m_panelMarge.Size = new System.Drawing.Size(47, 65);
            this.m_panelMarge.TabIndex = 0;
            // 
            // m_error
            // 
            this.m_error.ContainerControl = this;
            // 
            // m_panelChampsCustom
            // 
            this.m_panelChampsCustom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelChampsCustom.Location = new System.Drawing.Point(29, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelChampsCustom, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelChampsCustom.Name = "m_panelChampsCustom";
            this.m_panelChampsCustom.Size = new System.Drawing.Size(711, 24);
            this.m_panelChampsCustom.TabIndex = 1;
            // 
            // m_panelBas
            // 
            this.m_panelBas.Controls.Add(this.m_panelChampsCustom);
            this.m_panelBas.Controls.Add(this.label1);
            this.m_panelBas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelBas.Location = new System.Drawing.Point(47, 41);
            this.m_extModeEdition.SetModeEdition(this.m_panelBas, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelBas.Name = "m_panelBas";
            this.m_panelBas.Size = new System.Drawing.Size(740, 24);
            this.m_panelBas.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 24);
            this.label1.TabIndex = 0;
            // 
            // m_lblLigneBas
            // 
            this.m_lblLigneBas.BackColor = System.Drawing.Color.Gray;
            this.m_lblLigneBas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_lblLigneBas.Location = new System.Drawing.Point(0, 65);
            this.m_extModeEdition.SetModeEdition(this.m_lblLigneBas, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblLigneBas.Name = "m_lblLigneBas";
            this.m_lblLigneBas.Size = new System.Drawing.Size(787, 1);
            this.m_lblLigneBas.TabIndex = 0;
            // 
            // m_selectPresence
            // 
            this.m_selectPresence.BackColor = System.Drawing.Color.White;
            this.m_selectPresence.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_selectPresence.Location = new System.Drawing.Point(585, 0);
            this.m_extModeEdition.SetModeEdition(this.m_selectPresence, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_selectPresence.Name = "m_selectPresence";
            this.m_selectPresence.Size = new System.Drawing.Size(131, 42);
            this.m_selectPresence.TabIndex = 2;
            this.m_selectPresence.Value = null;
            this.m_selectPresence.ValueChanged += new System.EventHandler(this.m_selectPresence_ValueChanged_1);
            // 
            // m_selectTypeEquipement
            // 
            this.m_selectTypeEquipement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_selectTypeEquipement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_selectTypeEquipement.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_selectTypeEquipement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_selectTypeEquipement.Name = "m_selectTypeEquipement";
            this.m_selectTypeEquipement.Size = new System.Drawing.Size(245, 42);
            this.m_selectTypeEquipement.TabIndex = 0;
            this.m_selectTypeEquipement.ValueChanged += new System.EventHandler(this.m_txtCoord_ValueChanged);
            // 
            // m_txtCoord
            // 
            this.m_txtCoord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtCoord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtCoord.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_txtCoord, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtCoord.Name = "m_txtCoord";
            this.m_txtCoord.Size = new System.Drawing.Size(112, 42);
            this.m_txtCoord.TabIndex = 0;
            this.m_txtCoord.ValueChanged += new System.EventHandler(this.m_txtCoord_ValueChanged);
            // 
            // CControlePourInventaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_panelTop);
            this.Controls.Add(this.m_panelBas);
            this.Controls.Add(this.m_panelMarge);
            this.Controls.Add(this.m_lblLigneBas);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControlePourInventaire";
            this.Size = new System.Drawing.Size(787, 66);
            this.Load += new System.EventHandler(this.CControlePourInventaire_Load);
            this.m_panelTop.ResumeLayout(false);
            this.m_panelTop.PerformLayout();
            this.m_panelTypeEquipement.ResumeLayout(false);
            this.m_panelSerial.ResumeLayout(false);
            this.m_panelSerial.PerformLayout();
            this.m_panelCoord.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_error)).EndInit();
            this.m_panelBas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_panelTop;
        private System.Windows.Forms.Button m_btnExpand;
        private System.Windows.Forms.Panel m_panelMarge;
        private CTxtSaisieCoordonnee m_txtCoord;
        private System.Windows.Forms.Panel m_panelSerial;
        private System.Windows.Forms.TextBox m_txtSerial;
        private System.Windows.Forms.Panel m_panelCoord;
        private System.Windows.Forms.Panel m_panelTypeEquipement;
        private CControleTypeEquipement m_selectTypeEquipement;
        private CControlPresence m_selectPresence;
        private System.Windows.Forms.Button m_btnAdd;
        private System.Windows.Forms.TextBox m_txtComment;
        private System.Windows.Forms.ErrorProvider m_error;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel m_panelChampsCustom;
        private System.Windows.Forms.Panel m_panelBas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label m_lblLigneBas;
    }
}
