namespace timos.Controles.ActionsSurLink
{
    partial class CPanelEditeActionSurLinkAction
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
            this.components = new System.ComponentModel.Container();
            this.cExtStyle1 = new sc2i.win32.common.CExtStyle();
            this.m_panelAction = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.m_panelParametresAction = new sc2i.win32.expression.CControlEditListeFormulesNommees();
            this.m_panelFormules = new sc2i.win32.common.C2iPanel(this.components);
            this.m_chkHideProgress = new System.Windows.Forms.CheckBox();
            this.m_panelEvenementManuel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.m_selectionneurEvenementManuel = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.label1 = new System.Windows.Forms.Label();
            this.m_selectionneurProcess = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_panelAction.SuspendLayout();
            this.m_panelParametresAction.SuspendLayout();
            this.m_panelEvenementManuel.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelAction
            // 
            this.m_panelAction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelAction.Controls.Add(this.label17);
            this.m_panelAction.Controls.Add(this.m_panelParametresAction);
            this.m_panelAction.Controls.Add(this.m_chkHideProgress);
            this.m_panelAction.Controls.Add(this.m_panelEvenementManuel);
            this.m_panelAction.Controls.Add(this.label1);
            this.m_panelAction.Controls.Add(this.m_selectionneurProcess);
            this.m_panelAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelAction.ForeColor = System.Drawing.Color.Black;
            this.m_panelAction.Location = new System.Drawing.Point(0, 0);
            this.m_panelAction.Name = "m_panelAction";
            this.m_panelAction.Size = new System.Drawing.Size(929, 390);
            this.cExtStyle1.SetStyleBackColor(this.m_panelAction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_panelAction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelAction.TabIndex = 4;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(8, 106);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(181, 16);
            this.cExtStyle1.SetStyleBackColor(this.label17, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.label17, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label17.TabIndex = 7;
            this.label17.Text = "Action parameters|20127";
            // 
            // m_panelParametresAction
            // 
            this.m_panelParametresAction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelParametresAction.AutoScroll = true;
            this.m_panelParametresAction.Controls.Add(this.m_panelFormules);
            this.m_panelParametresAction.HasDeleteButton = true;
            this.m_panelParametresAction.HasHadButton = true;
            this.m_panelParametresAction.HeaderTextForFormula = "";
            this.m_panelParametresAction.HeaderTextForName = "";
            this.m_panelParametresAction.HideNomFormule = false;
            this.m_panelParametresAction.Location = new System.Drawing.Point(7, 119);
            this.m_panelParametresAction.LockEdition = false;
            this.m_panelParametresAction.Name = "m_panelParametresAction";
            this.m_panelParametresAction.Size = new System.Drawing.Size(919, 263);
            this.cExtStyle1.SetStyleBackColor(this.m_panelParametresAction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_panelParametresAction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelParametresAction.TabIndex = 6;
            this.m_panelParametresAction.TypeFormuleNomme = typeof(sc2i.expression.CFormuleNommee);
            // 
            // m_panelFormules
            // 
            this.m_panelFormules.AutoScroll = true;
            this.m_panelFormules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelFormules.Location = new System.Drawing.Point(0, 0);
            this.m_panelFormules.LockEdition = false;
            this.m_panelFormules.Name = "m_panelFormules";
            this.m_panelFormules.Size = new System.Drawing.Size(919, 263);
            this.cExtStyle1.SetStyleBackColor(this.m_panelFormules, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_panelFormules, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFormules.TabIndex = 2;
            // 
            // m_chkHideProgress
            // 
            this.m_chkHideProgress.AutoSize = true;
            this.m_chkHideProgress.Location = new System.Drawing.Point(11, 86);
            this.m_chkHideProgress.Name = "m_chkHideProgress";
            this.m_chkHideProgress.Size = new System.Drawing.Size(141, 17);
            this.cExtStyle1.SetStyleBackColor(this.m_chkHideProgress, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_chkHideProgress, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkHideProgress.TabIndex = 5;
            this.m_chkHideProgress.Text = "Hide progress bar|20034";
            this.m_chkHideProgress.UseVisualStyleBackColor = true;
            // 
            // m_panelEvenementManuel
            // 
            this.m_panelEvenementManuel.Controls.Add(this.label7);
            this.m_panelEvenementManuel.Controls.Add(this.label8);
            this.m_panelEvenementManuel.Controls.Add(this.m_selectionneurEvenementManuel);
            this.m_panelEvenementManuel.Location = new System.Drawing.Point(8, 32);
            this.m_panelEvenementManuel.Name = "m_panelEvenementManuel";
            this.m_panelEvenementManuel.Size = new System.Drawing.Size(640, 48);
            this.cExtStyle1.SetStyleBackColor(this.m_panelEvenementManuel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_panelEvenementManuel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEvenementManuel.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(24, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.cExtStyle1.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 1;
            this.label7.Text = "or|63";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(0, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 24);
            this.cExtStyle1.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 3;
            this.label8.Text = "Manual Event|813";
            // 
            // m_selectionneurEvenementManuel
            // 
            this.m_selectionneurEvenementManuel.ElementSelectionne = null;
            this.m_selectionneurEvenementManuel.FonctionTextNull = null;
            this.m_selectionneurEvenementManuel.HasLink = true;
            this.m_selectionneurEvenementManuel.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_selectionneurEvenementManuel.Location = new System.Drawing.Point(125, 16);
            this.m_selectionneurEvenementManuel.LockEdition = false;
            this.m_selectionneurEvenementManuel.Name = "m_selectionneurEvenementManuel";
            this.m_selectionneurEvenementManuel.SelectedObject = null;
            this.m_selectionneurEvenementManuel.Size = new System.Drawing.Size(419, 24);
            this.m_selectionneurEvenementManuel.SpecificImage = null;
            this.cExtStyle1.SetStyleBackColor(this.m_selectionneurEvenementManuel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_selectionneurEvenementManuel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectionneurEvenementManuel.TabIndex = 2;
            this.m_selectionneurEvenementManuel.TextNull = "";
            this.m_selectionneurEvenementManuel.ElementSelectionneChanged += new System.EventHandler(this.m_selectionneurEvenementManuel_ElementSelectionneChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.cExtStyle1.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 1;
            this.label1.Text = "Action|162";
            // 
            // m_selectionneurProcess
            // 
            this.m_selectionneurProcess.ElementSelectionne = null;
            this.m_selectionneurProcess.FonctionTextNull = null;
            this.m_selectionneurProcess.HasLink = true;
            this.m_selectionneurProcess.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_selectionneurProcess.Location = new System.Drawing.Point(133, 9);
            this.m_selectionneurProcess.LockEdition = false;
            this.m_selectionneurProcess.Name = "m_selectionneurProcess";
            this.m_selectionneurProcess.SelectedObject = null;
            this.m_selectionneurProcess.Size = new System.Drawing.Size(419, 24);
            this.m_selectionneurProcess.SpecificImage = null;
            this.cExtStyle1.SetStyleBackColor(this.m_selectionneurProcess, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_selectionneurProcess, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectionneurProcess.TabIndex = 0;
            this.m_selectionneurProcess.TextNull = "";
            this.m_selectionneurProcess.ElementSelectionneChanged += new System.EventHandler(this.m_selectionneurProcess_ElementSelectionneChanged);
            // 
            // CPanelEditeActionSurLinkAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_panelAction);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CPanelEditeActionSurLinkAction";
            this.Size = new System.Drawing.Size(929, 390);
            this.cExtStyle1.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.cExtStyle1.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelAction.ResumeLayout(false);
            this.m_panelAction.PerformLayout();
            this.m_panelParametresAction.ResumeLayout(false);
            this.m_panelEvenementManuel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtStyle cExtStyle1;
        private System.Windows.Forms.Panel m_panelAction;
        private System.Windows.Forms.Label label17;
        private sc2i.win32.expression.CControlEditListeFormulesNommees m_panelParametresAction;
        private sc2i.win32.common.C2iPanel m_panelFormules;
        private System.Windows.Forms.CheckBox m_chkHideProgress;
        private System.Windows.Forms.Panel m_panelEvenementManuel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_selectionneurEvenementManuel;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_selectionneurProcess;
    }
}
