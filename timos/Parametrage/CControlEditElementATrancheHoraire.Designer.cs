using sc2i.common;

namespace timos
{
    partial class CControlEditElementATrancheHoraire
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
            this.m_lnkSupprimerTranche = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkAjouterTranche = new sc2i.win32.common.CWndLinkStd();
            this.m_listViewTranches = new sc2i.win32.common.ListViewAutoFilled();
            this.m_listViewtranchesColHeureDebut = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_listViewtranchesColHeureFin = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_listViewTranchesColTypeOH = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_panelEditionTranche = new sc2i.win32.common.C2iPanel(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cmbxSelectTypeOccupationHpourTranche = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
            this.label2 = new System.Windows.Forms.Label();
            this.m_timePickerHeureFin = new sc2i.win32.common.C2iDateTimePicker();
            this.m_timePickerHeureDebut = new sc2i.win32.common.C2iDateTimePicker();
            this.m_gestionnaireEditionTranches = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_cmbxSelectTypeOccupationH = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_toolTipTraductible = new sc2i.win32.common.CToolTipTraductible(this.components);
            this.m_panelEditionTranche.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lnkSupprimerTranche
            // 
            this.m_lnkSupprimerTranche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkSupprimerTranche.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimerTranche.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkSupprimerTranche.Location = new System.Drawing.Point(10, 294);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSupprimerTranche, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkSupprimerTranche.Name = "m_lnkSupprimerTranche";
            this.m_lnkSupprimerTranche.Size = new System.Drawing.Size(104, 16);
            this.m_lnkSupprimerTranche.TabIndex = 1;
            this.m_lnkSupprimerTranche.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimerTranche.LinkClicked += new System.EventHandler(this.m_lnkSupprimerTranche_LinkClicked);
            // 
            // m_lnkAjouterTranche
            // 
            this.m_lnkAjouterTranche.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouterTranche.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkAjouterTranche.Location = new System.Drawing.Point(10, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouterTranche, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAjouterTranche.Name = "m_lnkAjouterTranche";
            this.m_lnkAjouterTranche.Size = new System.Drawing.Size(104, 16);
            this.m_lnkAjouterTranche.TabIndex = 0;
            this.m_toolTipTraductible.SetToolTip(this.m_lnkAjouterTranche, "Create new Time Slot");
            this.m_lnkAjouterTranche.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouterTranche.LinkClicked += new System.EventHandler(this.m_lnkAjouterTranche_LinkClicked);
            // 
            // m_listViewTranches
            // 
            this.m_listViewTranches.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_listViewTranches.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_listViewtranchesColHeureDebut,
            this.m_listViewtranchesColHeureFin,
            this.m_listViewTranchesColTypeOH});
            this.m_listViewTranches.EnableCustomisation = true;
            this.m_listViewTranches.FullRowSelect = true;
            this.m_listViewTranches.HideSelection = false;
            this.m_listViewTranches.Location = new System.Drawing.Point(3, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_listViewTranches, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_listViewTranches.MultiSelect = false;
            this.m_listViewTranches.Name = "m_listViewTranches";
            this.m_listViewTranches.Size = new System.Drawing.Size(332, 265);
            this.m_listViewTranches.TabIndex = 17;
            this.m_listViewTranches.UseCompatibleStateImageBehavior = false;
            this.m_listViewTranches.View = System.Windows.Forms.View.Details;
            // 
            // m_listViewtranchesColHeureDebut
            // 
            this.m_listViewtranchesColHeureDebut.Field = "HeureDebutString";
            this.m_listViewtranchesColHeureDebut.PrecisionWidth = 0;
            this.m_listViewtranchesColHeureDebut.ProportionnalSize = false;
            this.m_listViewtranchesColHeureDebut.Text = "Start Time|401";
            this.m_listViewtranchesColHeureDebut.Visible = true;
            this.m_listViewtranchesColHeureDebut.Width = 90;
            // 
            // m_listViewtranchesColHeureFin
            // 
            this.m_listViewtranchesColHeureFin.Field = "HeureFinString";
            this.m_listViewtranchesColHeureFin.PrecisionWidth = 0;
            this.m_listViewtranchesColHeureFin.ProportionnalSize = false;
            this.m_listViewtranchesColHeureFin.Text = "End Time|402";
            this.m_listViewtranchesColHeureFin.Visible = true;
            this.m_listViewtranchesColHeureFin.Width = 91;
            // 
            // m_listViewTranchesColTypeOH
            // 
            this.m_listViewTranchesColTypeOH.Field = "TypeOccupationHoraire.Libelle";
            this.m_listViewTranchesColTypeOH.PrecisionWidth = 0;
            this.m_listViewTranchesColTypeOH.ProportionnalSize = false;
            this.m_listViewTranchesColTypeOH.Text = "Occupation Type|409";
            this.m_listViewTranchesColTypeOH.Visible = true;
            this.m_listViewTranchesColTypeOH.Width = 146;
            // 
            // m_panelEditionTranche
            // 
            this.m_panelEditionTranche.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelEditionTranche.Controls.Add(this.label4);
            this.m_panelEditionTranche.Controls.Add(this.label3);
            this.m_panelEditionTranche.Controls.Add(this.m_cmbxSelectTypeOccupationHpourTranche);
            this.m_panelEditionTranche.Controls.Add(this.label2);
            this.m_panelEditionTranche.Controls.Add(this.m_timePickerHeureFin);
            this.m_panelEditionTranche.Controls.Add(this.m_timePickerHeureDebut);
            this.m_panelEditionTranche.Location = new System.Drawing.Point(3, 3);
            this.m_panelEditionTranche.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEditionTranche, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelEditionTranche.Name = "m_panelEditionTranche";
            this.m_panelEditionTranche.Size = new System.Drawing.Size(312, 307);
            this.m_panelEditionTranche.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 126);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Occupation type|409";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 78);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "End Time|402";
            // 
            // m_cmbxSelectTypeOccupationHpourTranche
            // 
            this.m_cmbxSelectTypeOccupationHpourTranche.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbxSelectTypeOccupationHpourTranche.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbxSelectTypeOccupationHpourTranche.ElementSelectionne = null;
            this.m_cmbxSelectTypeOccupationHpourTranche.FormattingEnabled = true;
            this.m_cmbxSelectTypeOccupationHpourTranche.IsLink = false;
            this.m_cmbxSelectTypeOccupationHpourTranche.ListDonnees = null;
            this.m_cmbxSelectTypeOccupationHpourTranche.Location = new System.Drawing.Point(7, 142);
            this.m_cmbxSelectTypeOccupationHpourTranche.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxSelectTypeOccupationHpourTranche, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbxSelectTypeOccupationHpourTranche.Name = "m_cmbxSelectTypeOccupationHpourTranche";
            this.m_cmbxSelectTypeOccupationHpourTranche.NullAutorise = true;
            this.m_cmbxSelectTypeOccupationHpourTranche.ProprieteAffichee = null;
            this.m_cmbxSelectTypeOccupationHpourTranche.ProprieteParentListeObjets = null;
            this.m_cmbxSelectTypeOccupationHpourTranche.SelectionneurParent = null;
            this.m_cmbxSelectTypeOccupationHpourTranche.Size = new System.Drawing.Size(289, 21);
            this.m_cmbxSelectTypeOccupationHpourTranche.TabIndex = 2;
            this.m_cmbxSelectTypeOccupationHpourTranche.TextNull = I.T("(None)|30291");
            this.m_cmbxSelectTypeOccupationHpourTranche.Tri = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 33);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Start Time|401";
            // 
            // m_timePickerHeureFin
            // 
            this.m_timePickerHeureFin.CustomFormat = "HH:mm";
            this.m_timePickerHeureFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_timePickerHeureFin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.m_timePickerHeureFin.Location = new System.Drawing.Point(7, 94);
            this.m_timePickerHeureFin.LockEdition = false;
            this.m_timePickerHeureFin.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_timePickerHeureFin, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_timePickerHeureFin.Name = "m_timePickerHeureFin";
            this.m_timePickerHeureFin.ShowUpDown = true;
            this.m_timePickerHeureFin.Size = new System.Drawing.Size(75, 20);
            this.m_timePickerHeureFin.TabIndex = 1;
            this.m_timePickerHeureFin.Value = new System.DateTime(2003, 4, 2, 9, 17, 49, 526);
            // 
            // m_timePickerHeureDebut
            // 
            this.m_timePickerHeureDebut.CustomFormat = "HH:mm";
            this.m_timePickerHeureDebut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_timePickerHeureDebut.Location = new System.Drawing.Point(7, 49);
            this.m_timePickerHeureDebut.LockEdition = false;
            this.m_timePickerHeureDebut.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_timePickerHeureDebut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_timePickerHeureDebut.Name = "m_timePickerHeureDebut";
            this.m_timePickerHeureDebut.ShowUpDown = true;
            this.m_timePickerHeureDebut.Size = new System.Drawing.Size(75, 20);
            this.m_timePickerHeureDebut.TabIndex = 0;
            this.m_timePickerHeureDebut.Value = new System.DateTime(2003, 4, 2, 9, 17, 49, 526);
            // 
            // m_gestionnaireEditionTranches
            // 
            this.m_gestionnaireEditionTranches.ListeAssociee = this.m_listViewTranches;
            this.m_gestionnaireEditionTranches.ObjetEdite = null;
            this.m_gestionnaireEditionTranches.InitChamp += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionTranches_InitChamp);
            this.m_gestionnaireEditionTranches.MAJ_Champs += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionTranches_MAJ_Champs);
            // 
            // m_cmbxSelectTypeOccupationH
            // 
            this.m_cmbxSelectTypeOccupationH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbxSelectTypeOccupationH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbxSelectTypeOccupationH.ElementSelectionne = null;
            this.m_cmbxSelectTypeOccupationH.FormattingEnabled = true;
            this.m_cmbxSelectTypeOccupationH.IsLink = false;
            this.m_cmbxSelectTypeOccupationH.ListDonnees = null;
            this.m_cmbxSelectTypeOccupationH.Location = new System.Drawing.Point(158, 3);
            this.m_cmbxSelectTypeOccupationH.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxSelectTypeOccupationH, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbxSelectTypeOccupationH.Name = "m_cmbxSelectTypeOccupationH";
            this.m_cmbxSelectTypeOccupationH.NullAutorise = true;
            this.m_cmbxSelectTypeOccupationH.ProprieteAffichee = null;
            this.m_cmbxSelectTypeOccupationH.ProprieteParentListeObjets = null;
            this.m_cmbxSelectTypeOccupationH.SelectionneurParent = null;
            this.m_cmbxSelectTypeOccupationH.Size = new System.Drawing.Size(490, 21);
            this.m_cmbxSelectTypeOccupationH.TabIndex = 0;
            this.m_cmbxSelectTypeOccupationH.TextNull = I.T("(None)|30290");
            this.m_cmbxSelectTypeOccupationH.Tri = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Default Occupation Type|411";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 30);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_listViewTranches);
            this.splitContainer1.Panel1.Controls.Add(this.m_lnkAjouterTranche);
            this.splitContainer1.Panel1.Controls.Add(this.m_lnkSupprimerTranche);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_panelEditionTranche);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitContainer1.Size = new System.Drawing.Size(667, 313);
            this.splitContainer1.SplitterDistance = 345;
            this.splitContainer1.TabIndex = 22;
            // 
            // CControlEditElementATrancheHoraire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_cmbxSelectTypeOccupationH);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControlEditElementATrancheHoraire";
            this.Size = new System.Drawing.Size(670, 343);
            this.m_panelEditionTranche.ResumeLayout(false);
            this.m_panelEditionTranche.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private sc2i.win32.common.CWndLinkStd m_lnkSupprimerTranche;
        private sc2i.win32.common.CWndLinkStd m_lnkAjouterTranche;
        private sc2i.win32.common.ListViewAutoFilled m_listViewTranches;
        private sc2i.win32.common.ListViewAutoFilledColumn m_listViewtranchesColHeureDebut;
        private sc2i.win32.common.ListViewAutoFilledColumn m_listViewtranchesColHeureFin;
        private sc2i.win32.common.C2iPanel m_panelEditionTranche;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private sc2i.win32.common.C2iDateTimePicker m_timePickerHeureFin;
        private sc2i.win32.common.C2iDateTimePicker m_timePickerHeureDebut;
        private sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee m_gestionnaireEditionTranches;
        private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
        private sc2i.win32.data.CComboBoxListeObjetsDonnees m_cmbxSelectTypeOccupationH;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.ListViewAutoFilledColumn m_listViewTranchesColTypeOH;
        private System.Windows.Forms.Label label4;
        private sc2i.win32.data.CComboBoxListeObjetsDonnees m_cmbxSelectTypeOccupationHpourTranche;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private sc2i.win32.common.CToolTipTraductible m_toolTipTraductible;
    }
}
