using sc2i.win32.common.customizableList;
namespace timos.commandes
{
    partial class CControleEditeLignesDeLivraisonEquipement
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
            this.m_panelTop = new sc2i.win32.common.C2iPanel(this.components);
            this.m_lnkAddLine = new sc2i.win32.common.CWndLinkStd();
            this.m_wndListeLignes = new sc2i.win32.common.customizableList.CCustomizableList();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.c2iPanel1 = new sc2i.win32.common.C2iPanel(this.components);
            this.m_cmbStatut = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.label6 = new System.Windows.Forms.Label();
            this.m_selectStock = new sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide();
            this.m_cmbTypeDestination = new sc2i.win32.common.C2iComboSelectDynamicClass(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.m_panelEntete = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.m_panelTop.SuspendLayout();
            this.c2iPanel1.SuspendLayout();
            this.m_panelEntete.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelTop
            // 
            this.m_panelTop.Controls.Add(this.m_lnkAddLine);
            this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTop.Location = new System.Drawing.Point(0, 0);
            this.m_panelTop.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_panelTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelTop.Name = "m_panelTop";
            this.m_panelTop.Size = new System.Drawing.Size(837, 23);
            this.m_panelTop.TabIndex = 0;
            // 
            // m_lnkAddLine
            // 
            this.m_lnkAddLine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAddLine.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkAddLine.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkAddLine.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lnkAddLine, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAddLine.Name = "m_lnkAddLine";
            this.m_lnkAddLine.Size = new System.Drawing.Size(112, 23);
            this.m_lnkAddLine.TabIndex = 0;
            this.m_lnkAddLine.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAddLine.LinkClicked += new System.EventHandler(this.m_lnkAddLine_LinkClicked);
            // 
            // m_wndListeLignes
            // 
            this.m_wndListeLignes.CurrentItemIndex = null;
            this.m_wndListeLignes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeLignes.ItemControl = null;
            this.m_wndListeLignes.Items = new sc2i.win32.common.customizableList.CCustomizableListItem[0];
            this.m_wndListeLignes.Location = new System.Drawing.Point(0, 70);
            this.m_extModeEdition.SetModeEdition(this.m_wndListeLignes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_wndListeLignes.Name = "m_wndListeLignes";
            this.m_wndListeLignes.Size = new System.Drawing.Size(837, 240);
            this.m_wndListeLignes.TabIndex = 1;
            // 
            // c2iPanel1
            // 
            this.c2iPanel1.Controls.Add(this.m_cmbStatut);
            this.c2iPanel1.Controls.Add(this.label6);
            this.c2iPanel1.Controls.Add(this.m_selectStock);
            this.c2iPanel1.Controls.Add(this.m_cmbTypeDestination);
            this.c2iPanel1.Controls.Add(this.label5);
            this.c2iPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.c2iPanel1.Location = new System.Drawing.Point(0, 23);
            this.c2iPanel1.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.c2iPanel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.c2iPanel1.Name = "c2iPanel1";
            this.c2iPanel1.Size = new System.Drawing.Size(837, 23);
            this.c2iPanel1.TabIndex = 2;
            // 
            // m_cmbStatut
            // 
            this.m_cmbStatut.ComportementLinkStd = true;
            this.m_cmbStatut.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_cmbStatut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbStatut.ElementSelectionne = null;
            this.m_cmbStatut.FormattingEnabled = true;
            this.m_cmbStatut.IsLink = false;
            this.m_cmbStatut.LinkProperty = "";
            this.m_cmbStatut.ListDonnees = null;
            this.m_cmbStatut.Location = new System.Drawing.Point(663, 0);
            this.m_cmbStatut.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_cmbStatut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbStatut.Name = "m_cmbStatut";
            this.m_cmbStatut.NullAutorise = false;
            this.m_cmbStatut.ProprieteAffichee = null;
            this.m_cmbStatut.ProprieteParentListeObjets = null;
            this.m_cmbStatut.SelectionneurParent = null;
            this.m_cmbStatut.Size = new System.Drawing.Size(156, 21);
            this.m_cmbStatut.TabIndex = 4015;
            this.m_cmbStatut.TextNull = "(empty)";
            this.m_cmbStatut.Tri = true;
            this.m_cmbStatut.TypeFormEdition = null;
            this.m_cmbStatut.SelectedValueChanged += new System.EventHandler(this.m_cmbStatut_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Location = new System.Drawing.Point(493, 0);
            this.m_extModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 23);
            this.label6.TabIndex = 4005;
            this.label6.Text = "Equipments default status|20423";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_selectStock
            // 
            this.m_selectStock.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_selectStock.ElementSelectionne = null;
            this.m_selectStock.Location = new System.Drawing.Point(213, 0);
            this.m_selectStock.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_selectStock, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_selectStock.Name = "m_selectStock";
            this.m_selectStock.SelectedObject = null;
            this.m_selectStock.SelectionLength = 0;
            this.m_selectStock.SelectionStart = 0;
            this.m_selectStock.Size = new System.Drawing.Size(280, 23);
            this.m_selectStock.TabIndex = 4004;
            this.m_selectStock.OnSelectedObjectChanged += new System.EventHandler(this.m_selectStock_OnSelectedObjectChanged);
            // 
            // m_cmbTypeDestination
            // 
            this.m_cmbTypeDestination.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_cmbTypeDestination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeDestination.FormattingEnabled = true;
            this.m_cmbTypeDestination.IsLink = false;
            this.m_cmbTypeDestination.Location = new System.Drawing.Point(92, 0);
            this.m_cmbTypeDestination.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_cmbTypeDestination, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbTypeDestination.Name = "m_cmbTypeDestination";
            this.m_cmbTypeDestination.Size = new System.Drawing.Size(121, 21);
            this.m_cmbTypeDestination.TabIndex = 4016;
            this.m_cmbTypeDestination.TypeSelectionne = null;
            this.m_cmbTypeDestination.SelectionChangeCommitted += new System.EventHandler(this.m_cmbTypeDestination_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 23);
            this.label5.TabIndex = 4003;
            this.label5.Text = "Destination|20422";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_panelEntete
            // 
            this.m_panelEntete.Controls.Add(this.label1);
            this.m_panelEntete.Controls.Add(this.label2);
            this.m_panelEntete.Controls.Add(this.label3);
            this.m_panelEntete.Controls.Add(this.label4);
            this.m_panelEntete.Controls.Add(this.label7);
            this.m_panelEntete.Controls.Add(this.label8);
            this.m_panelEntete.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelEntete.Location = new System.Drawing.Point(0, 46);
            this.m_extModeEdition.SetModeEdition(this.m_panelEntete, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelEntete.Name = "m_panelEntete";
            this.m_panelEntete.Size = new System.Drawing.Size(837, 24);
            this.m_panelEntete.TabIndex = 3;
            this.m_panelEntete.Visible = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(58, 0);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Equipment type|20396";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(188, 0);
            this.m_extModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Manufacturer reference|465";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(380, 0);
            this.m_extModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(318, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Container/coordinate|20426";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 24);
            this.label4.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Dock = System.Windows.Forms.DockStyle.Right;
            this.label7.Location = new System.Drawing.Point(698, 0);
            this.m_extModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 24);
            this.label7.TabIndex = 6;
            this.label7.Text = "Serial n°|223";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Dock = System.Windows.Forms.DockStyle.Right;
            this.label8.Location = new System.Drawing.Point(779, 0);
            this.m_extModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 24);
            this.label8.TabIndex = 4;
            // 
            // CControleEditeLignesDeLivraisonEquipement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_wndListeLignes);
            this.Controls.Add(this.m_panelEntete);
            this.Controls.Add(this.c2iPanel1);
            this.Controls.Add(this.m_panelTop);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleEditeLignesDeLivraisonEquipement";
            this.Size = new System.Drawing.Size(837, 310);
            this.m_panelTop.ResumeLayout(false);
            this.c2iPanel1.ResumeLayout(false);
            this.m_panelEntete.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.C2iPanel m_panelTop;
        private sc2i.win32.common.CWndLinkStd m_lnkAddLine;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private CCustomizableList m_wndListeLignes;
        private sc2i.win32.common.C2iPanel c2iPanel1;
        private sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees m_cmbStatut;
        private System.Windows.Forms.Label label6;
        private sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide m_selectStock;
        private System.Windows.Forms.Label label5;
        private sc2i.win32.common.C2iComboSelectDynamicClass m_cmbTypeDestination;
        private System.Windows.Forms.Panel m_panelEntete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}
