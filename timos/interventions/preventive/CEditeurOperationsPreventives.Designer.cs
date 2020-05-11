namespace timos.interventions.preventives
{
    partial class CEditeurOperationsPreventives
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
            this.m_panelTop = new System.Windows.Forms.Panel();
            this.m_picExtraireListe = new System.Windows.Forms.PictureBox();
            this.m_btnAddOperation = new sc2i.win32.common.CWndLinkStd();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_panelHeader = new sc2i.win32.common.C2iPanel(this.components);
            this.m_lblHeaderComment = new System.Windows.Forms.Label();
            this.m_lblHeaderDuration = new System.Windows.Forms.Label();
            this.m_lblHeaderStartDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_lblHeaderOperationType = new System.Windows.Forms.Label();
            this.m_lblHeaderCode = new System.Windows.Forms.Label();
            this.m_panelHeaderPicto = new System.Windows.Forms.Panel();
            this.m_lblHeaderActeur = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picExtraireListe)).BeginInit();
            this.m_panelHeader.SuspendLayout();
            this.m_panelHeaderPicto.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelDessin
            // 
            this.m_panelDessin.Location = new System.Drawing.Point(0, 46);
            this.m_extModeEdition.SetModeEdition(this.m_panelDessin, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelDessin.Size = new System.Drawing.Size(832, 209);
            // 
            // m_panelTop
            // 
            this.m_panelTop.Controls.Add(this.m_picExtraireListe);
            this.m_panelTop.Controls.Add(this.m_btnAddOperation);
            this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTop.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelTop.Name = "m_panelTop";
            this.m_panelTop.Size = new System.Drawing.Size(832, 24);
            this.m_panelTop.TabIndex = 0;
            // 
            // m_picExtraireListe
            // 
            this.m_picExtraireListe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_picExtraireListe.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_picExtraireListe.Image = global::timos.Properties.Resources.Extract_List;
            this.m_picExtraireListe.Location = new System.Drawing.Point(810, 0);
            this.m_extModeEdition.SetModeEdition(this.m_picExtraireListe, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_picExtraireListe.Name = "m_picExtraireListe";
            this.m_picExtraireListe.Size = new System.Drawing.Size(22, 24);
            this.m_picExtraireListe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_picExtraireListe.TabIndex = 8;
            this.m_picExtraireListe.TabStop = false;
            this.m_picExtraireListe.Click += new System.EventHandler(this.m_picExtraireListe_Click);
            // 
            // m_btnAddOperation
            // 
            this.m_btnAddOperation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnAddOperation.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnAddOperation.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_btnAddOperation.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnAddOperation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnAddOperation.Name = "m_btnAddOperation";
            this.m_btnAddOperation.ShortMode = false;
            this.m_btnAddOperation.Size = new System.Drawing.Size(83, 24);
            this.m_btnAddOperation.TabIndex = 7;
            this.m_btnAddOperation.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_btnAddOperation.LinkClicked += new System.EventHandler(this.m_btnAddOperation_LinkClicked);
            // 
            // m_panelHeader
            // 
            this.m_panelHeader.Controls.Add(this.m_lblHeaderComment);
            this.m_panelHeader.Controls.Add(this.m_lblHeaderDuration);
            this.m_panelHeader.Controls.Add(this.m_lblHeaderStartDate);
            this.m_panelHeader.Controls.Add(this.label6);
            this.m_panelHeader.Controls.Add(this.m_lblHeaderOperationType);
            this.m_panelHeader.Controls.Add(this.m_lblHeaderCode);
            this.m_panelHeader.Controls.Add(this.m_panelHeaderPicto);
            this.m_panelHeader.Controls.Add(this.label1);
            this.m_panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelHeader.Location = new System.Drawing.Point(0, 24);
            this.m_panelHeader.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_panelHeader, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelHeader.Name = "m_panelHeader";
            this.m_panelHeader.Size = new System.Drawing.Size(832, 22);
            this.m_panelHeader.TabIndex = 13;
            // 
            // m_lblHeaderComment
            // 
            this.m_lblHeaderComment.BackColor = System.Drawing.Color.White;
            this.m_lblHeaderComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblHeaderComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblHeaderComment.Location = new System.Drawing.Point(695, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblHeaderComment, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblHeaderComment.Name = "m_lblHeaderComment";
            this.m_lblHeaderComment.Size = new System.Drawing.Size(71, 22);
            this.m_lblHeaderComment.TabIndex = 4;
            this.m_lblHeaderComment.Text = "Comments|51";
            this.m_lblHeaderComment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_lblHeaderDuration
            // 
            this.m_lblHeaderDuration.BackColor = System.Drawing.Color.White;
            this.m_lblHeaderDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblHeaderDuration.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblHeaderDuration.Location = new System.Drawing.Point(581, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblHeaderDuration, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblHeaderDuration.Name = "m_lblHeaderDuration";
            this.m_lblHeaderDuration.Size = new System.Drawing.Size(114, 22);
            this.m_lblHeaderDuration.TabIndex = 6;
            this.m_lblHeaderDuration.Text = "End/Duration|873";
            this.m_lblHeaderDuration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_lblHeaderStartDate
            // 
            this.m_lblHeaderStartDate.BackColor = System.Drawing.Color.White;
            this.m_lblHeaderStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblHeaderStartDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblHeaderStartDate.Location = new System.Drawing.Point(467, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblHeaderStartDate, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblHeaderStartDate.Name = "m_lblHeaderStartDate";
            this.m_lblHeaderStartDate.Size = new System.Drawing.Size(114, 22);
            this.m_lblHeaderStartDate.TabIndex = 7;
            this.m_lblHeaderStartDate.Text = "Start at|1283";
            this.m_lblHeaderStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Right;
            this.label6.Location = new System.Drawing.Point(766, 0);
            this.m_extModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 22);
            this.label6.TabIndex = 5;
            // 
            // m_lblHeaderOperationType
            // 
            this.m_lblHeaderOperationType.BackColor = System.Drawing.Color.White;
            this.m_lblHeaderOperationType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblHeaderOperationType.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblHeaderOperationType.Location = new System.Drawing.Point(212, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblHeaderOperationType, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblHeaderOperationType.Name = "m_lblHeaderOperationType";
            this.m_lblHeaderOperationType.Size = new System.Drawing.Size(255, 22);
            this.m_lblHeaderOperationType.TabIndex = 3;
            this.m_lblHeaderOperationType.Text = "Op. type|882";
            this.m_lblHeaderOperationType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_lblHeaderCode
            // 
            this.m_lblHeaderCode.BackColor = System.Drawing.Color.White;
            this.m_lblHeaderCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblHeaderCode.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblHeaderCode.Location = new System.Drawing.Point(162, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblHeaderCode, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblHeaderCode.Name = "m_lblHeaderCode";
            this.m_lblHeaderCode.Size = new System.Drawing.Size(50, 22);
            this.m_lblHeaderCode.TabIndex = 2;
            this.m_lblHeaderCode.Text = "Op. code|881";
            this.m_lblHeaderCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_panelHeaderPicto
            // 
            this.m_panelHeaderPicto.BackColor = System.Drawing.Color.White;
            this.m_panelHeaderPicto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelHeaderPicto.Controls.Add(this.m_lblHeaderActeur);
            this.m_panelHeaderPicto.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelHeaderPicto.Location = new System.Drawing.Point(22, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelHeaderPicto, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelHeaderPicto.Name = "m_panelHeaderPicto";
            this.m_panelHeaderPicto.Size = new System.Drawing.Size(140, 22);
            this.m_panelHeaderPicto.TabIndex = 8;
            // 
            // m_lblHeaderActeur
            // 
            this.m_lblHeaderActeur.AutoSize = true;
            this.m_lblHeaderActeur.Location = new System.Drawing.Point(3, 3);
            this.m_extModeEdition.SetModeEdition(this.m_lblHeaderActeur, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblHeaderActeur.Name = "m_lblHeaderActeur";
            this.m_lblHeaderActeur.Size = new System.Drawing.Size(52, 13);
            this.m_lblHeaderActeur.TabIndex = 0;
            this.m_lblHeaderActeur.Text = "Author|89";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 22);
            this.label1.TabIndex = 9;
            // 
            // CEditeurOperationsPreventives
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_panelHeader);
            this.Controls.Add(this.m_panelTop);
            this.Items = new sc2i.win32.common.customizableList.CCustomizableListItem[0];
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CEditeurOperationsPreventives";
            this.Size = new System.Drawing.Size(832, 255);
            this.Controls.SetChildIndex(this.m_panelTop, 0);
            this.Controls.SetChildIndex(this.m_panelHeader, 0);
            this.Controls.SetChildIndex(this.m_panelDessin, 0);
            this.m_panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_picExtraireListe)).EndInit();
            this.m_panelHeader.ResumeLayout(false);
            this.m_panelHeaderPicto.ResumeLayout(false);
            this.m_panelHeaderPicto.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_panelTop;
        private sc2i.win32.common.CWndLinkStd m_btnAddOperation;
        private System.Windows.Forms.PictureBox m_picExtraireListe;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private sc2i.win32.common.C2iPanel m_panelHeader;
        private System.Windows.Forms.Label m_lblHeaderComment;
        private System.Windows.Forms.Label m_lblHeaderDuration;
        private System.Windows.Forms.Label m_lblHeaderStartDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label m_lblHeaderOperationType;
        private System.Windows.Forms.Label m_lblHeaderCode;
        private System.Windows.Forms.Panel m_panelHeaderPicto;
        private System.Windows.Forms.Label m_lblHeaderActeur;
        private System.Windows.Forms.Label label1;
    }
}
