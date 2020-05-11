using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using System.Globalization;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

using sc2i.common;
using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.win32.data;
using sc2i.win32.common;

using timos.acteurs;
using timos.data;
using timos.data.preventives;
using System.Reflection;
using sc2i.win32.data.dynamic;
using timos.Properties;

namespace timos
{
	public class CFormEditionPreferenceFiltreRapide : CFormMaxiSansMenu, IFormNavigable
	{
		#region Designer generated code
        private sc2i.win32.common.CExtLinkField m_extLinkField;
		private sc2i.win32.common.C2iPanelOmbre m_panGeneral;
        private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private Button m_btnEditerObjet;
		private Button m_btnValiderModifications;
        private Button m_btnAnnulerModifications;
        private SplitContainer m_splitContainer;
        private ListView m_wndListeTypes;
        private ColumnHeader m_colType;
        private Label label1;
        //private ListViewAutoFilled m_wndListeParametres;
        //private ListViewAutoFilledColumn listViewAutoFilledColumn2;
        private Panel m_panelEditFiltre;
        private C2iTextBox m_txtFiltre;
        private C2iPanel c2iPanel1;
        private C2iTextBox c2iTextBox1;
        private sc2i.win32.data.EditionFiltreData.CControlEditeParametresFiltre m_panelParametres;
        private Panel panel1;
        private Label label2;
        private Panel panel2;
        private Button m_btnFiltreDynamique;
        private Label m_lblTypeEnCours;
		private System.ComponentModel.IContainer components = null;

		//-------------------------------------------------------------------------
		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.components = new System.ComponentModel.Container();
            this.m_panGeneral = new sc2i.win32.common.C2iPanelOmbre();
            this.m_splitContainer = new System.Windows.Forms.SplitContainer();
            this.m_wndListeTypes = new System.Windows.Forms.ListView();
            this.m_colType = new System.Windows.Forms.ColumnHeader();
            this.m_panelEditFiltre = new System.Windows.Forms.Panel();
            this.m_panelParametres = new sc2i.win32.data.EditionFiltreData.CControlEditeParametresFiltre();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_txtFiltre = new sc2i.win32.common.C2iTextBox();
            this.m_btnFiltreDynamique = new System.Windows.Forms.Button();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.c2iPanel1 = new sc2i.win32.common.C2iPanel(this.components);
            this.m_btnEditerObjet = new System.Windows.Forms.Button();
            this.m_btnAnnulerModifications = new System.Windows.Forms.Button();
            this.m_btnValiderModifications = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_extLinkField = new sc2i.win32.common.CExtLinkField();
            this.m_lblTypeEnCours = new System.Windows.Forms.Label();
            this.m_panGeneral.SuspendLayout();
            this.m_splitContainer.Panel1.SuspendLayout();
            this.m_splitContainer.Panel2.SuspendLayout();
            this.m_splitContainer.SuspendLayout();
            this.m_panelEditFiltre.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.c2iPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panGeneral
            // 
            this.m_panGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panGeneral.Controls.Add(this.m_splitContainer);
            this.m_panGeneral.Controls.Add(this.label1);
            this.m_panGeneral.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panGeneral, "");
            this.m_panGeneral.Location = new System.Drawing.Point(12, 4);
            this.m_panGeneral.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panGeneral, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panGeneral.Name = "m_panGeneral";
            this.m_panGeneral.Size = new System.Drawing.Size(818, 563);
            this.m_extStyle.SetStyleBackColor(this.m_panGeneral, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panGeneral, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panGeneral.TabIndex = 0;
            // 
            // m_splitContainer
            // 
            this.m_splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_splitContainer, "");
            this.m_splitContainer.Location = new System.Drawing.Point(8, 44);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainer, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_splitContainer.Name = "m_splitContainer";
            // 
            // m_splitContainer.Panel1
            // 
            this.m_splitContainer.Panel1.Controls.Add(this.m_wndListeTypes);
            this.m_extLinkField.SetLinkField(this.m_splitContainer.Panel1, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainer.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_splitContainer.Panel2
            // 
            this.m_splitContainer.Panel2.Controls.Add(this.m_panelEditFiltre);
            this.m_extLinkField.SetLinkField(this.m_splitContainer.Panel2, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainer.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainer.Size = new System.Drawing.Size(788, 496);
            this.m_splitContainer.SplitterDistance = 232;
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainer.TabIndex = 3;
            // 
            // m_wndListeTypes
            // 
            this.m_wndListeTypes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_colType});
            this.m_wndListeTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeTypes.HideSelection = false;
            this.m_extLinkField.SetLinkField(this.m_wndListeTypes, "");
            this.m_wndListeTypes.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeTypes, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_wndListeTypes.MultiSelect = false;
            this.m_wndListeTypes.Name = "m_wndListeTypes";
            this.m_wndListeTypes.Size = new System.Drawing.Size(232, 496);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeTypes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeTypes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeTypes.TabIndex = 4;
            this.m_wndListeTypes.UseCompatibleStateImageBehavior = false;
            this.m_wndListeTypes.View = System.Windows.Forms.View.Details;
            this.m_wndListeTypes.SelectedIndexChanged += new System.EventHandler(this.m_wndListeTypes_SelectedIndexChanged);
            // 
            // m_colType
            // 
            this.m_colType.Text = "Object type|1085";
            this.m_colType.Width = 211;
            // 
            // m_panelEditFiltre
            // 
            this.m_panelEditFiltre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelEditFiltre.Controls.Add(this.m_panelParametres);
            this.m_panelEditFiltre.Controls.Add(this.panel2);
            this.m_panelEditFiltre.Controls.Add(this.c2iTextBox1);
            this.m_panelEditFiltre.Controls.Add(this.panel1);
            this.m_panelEditFiltre.Controls.Add(this.c2iPanel1);
            this.m_extLinkField.SetLinkField(this.m_panelEditFiltre, "");
            this.m_panelEditFiltre.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEditFiltre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelEditFiltre.Name = "m_panelEditFiltre";
            this.m_panelEditFiltre.Size = new System.Drawing.Size(552, 496);
            this.m_extStyle.SetStyleBackColor(this.m_panelEditFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEditFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditFiltre.TabIndex = 12;
            this.m_panelEditFiltre.Visible = false;
            // 
            // m_panelParametres
            // 
            this.m_panelParametres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelParametres, "");
            this.m_panelParametres.Location = new System.Drawing.Point(0, 165);
            this.m_panelParametres.LockEdition = true;
            this.m_panelParametres.LockParametre1 = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelParametres, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelParametres.Name = "m_panelParametres";
            this.m_panelParametres.Size = new System.Drawing.Size(552, 331);
            this.m_extStyle.SetStyleBackColor(this.m_panelParametres, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelParametres, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelParametres.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_txtFiltre);
            this.panel2.Controls.Add(this.m_btnFiltreDynamique);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.panel2, "");
            this.panel2.Location = new System.Drawing.Point(0, 65);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(552, 100);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 6;
            // 
            // m_txtFiltre
            // 
            this.m_txtFiltre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_txtFiltre, "");
            this.m_txtFiltre.Location = new System.Drawing.Point(0, 0);
            this.m_txtFiltre.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtFiltre, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtFiltre.Multiline = true;
            this.m_txtFiltre.Name = "m_txtFiltre";
            this.m_txtFiltre.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_txtFiltre.Size = new System.Drawing.Size(527, 100);
            this.m_extStyle.SetStyleBackColor(this.m_txtFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFiltre.TabIndex = 0;
            // 
            // m_btnFiltreDynamique
            // 
            this.m_btnFiltreDynamique.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_extLinkField.SetLinkField(this.m_btnFiltreDynamique, "");
            this.m_btnFiltreDynamique.Location = new System.Drawing.Point(527, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnFiltreDynamique, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnFiltreDynamique.Name = "m_btnFiltreDynamique";
            this.m_btnFiltreDynamique.Size = new System.Drawing.Size(25, 100);
            this.m_extStyle.SetStyleBackColor(this.m_btnFiltreDynamique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnFiltreDynamique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnFiltreDynamique.TabIndex = 5;
            this.m_btnFiltreDynamique.Text = "...";
            this.m_btnFiltreDynamique.UseVisualStyleBackColor = true;
            this.m_btnFiltreDynamique.Click += new System.EventHandler(this.m_btnFiltreDynamique_Click);
            // 
            // c2iTextBox1
            // 
            this.m_extLinkField.SetLinkField(this.c2iTextBox1, "");
            this.c2iTextBox1.Location = new System.Drawing.Point(508, 491);
            this.c2iTextBox1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(100, 20);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_lblTypeEnCours);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.panel1, "");
            this.panel1.Location = new System.Drawing.Point(0, 42);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(552, 23);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 23);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 0;
            this.label2.Text = "Parameters|20110";
            // 
            // c2iPanel1
            // 
            this.c2iPanel1.Controls.Add(this.m_btnEditerObjet);
            this.c2iPanel1.Controls.Add(this.m_btnAnnulerModifications);
            this.c2iPanel1.Controls.Add(this.m_btnValiderModifications);
            this.c2iPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.c2iPanel1, "");
            this.c2iPanel1.Location = new System.Drawing.Point(0, 0);
            this.c2iPanel1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.c2iPanel1.Name = "c2iPanel1";
            this.c2iPanel1.Size = new System.Drawing.Size(552, 42);
            this.m_extStyle.SetStyleBackColor(this.c2iPanel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iPanel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanel1.TabIndex = 1;
            // 
            // m_btnEditerObjet
            // 
            this.m_btnEditerObjet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnEditerObjet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnEditerObjet.ForeColor = System.Drawing.Color.White;
            this.m_btnEditerObjet.Image = global::timos.Properties.Resources.edit;
            this.m_extLinkField.SetLinkField(this.m_btnEditerObjet, "");
            this.m_btnEditerObjet.Location = new System.Drawing.Point(4, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditerObjet, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_btnEditerObjet.Name = "m_btnEditerObjet";
            this.m_btnEditerObjet.Size = new System.Drawing.Size(31, 31);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnEditerObjet.TabIndex = 4019;
            this.m_btnEditerObjet.TabStop = false;
            this.m_btnEditerObjet.Click += new System.EventHandler(this.m_btnEditerObjet_Click);
            // 
            // m_btnAnnulerModifications
            // 
            this.m_btnAnnulerModifications.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnAnnulerModifications.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnulerModifications.Enabled = false;
            this.m_btnAnnulerModifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnAnnulerModifications.ForeColor = System.Drawing.Color.White;
            this.m_btnAnnulerModifications.Image = global::timos.Properties.Resources.cancel;
            this.m_extLinkField.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_btnAnnulerModifications.Location = new System.Drawing.Point(98, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnulerModifications, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnAnnulerModifications.Name = "m_btnAnnulerModifications";
            this.m_btnAnnulerModifications.Size = new System.Drawing.Size(31, 31);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAnnulerModifications.TabIndex = 4021;
            this.m_btnAnnulerModifications.TabStop = false;
            this.m_btnAnnulerModifications.Click += new System.EventHandler(this.m_btnAnnulerModifications_Click);
            // 
            // m_btnValiderModifications
            // 
            this.m_btnValiderModifications.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnValiderModifications.Enabled = false;
            this.m_btnValiderModifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnValiderModifications.ForeColor = System.Drawing.Color.White;
            this.m_btnValiderModifications.Image = global::timos.Properties.Resources.check;
            this.m_extLinkField.SetLinkField(this.m_btnValiderModifications, "");
            this.m_btnValiderModifications.Location = new System.Drawing.Point(67, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnValiderModifications.Name = "m_btnValiderModifications";
            this.m_btnValiderModifications.Size = new System.Drawing.Size(31, 31);
            this.m_extStyle.SetStyleBackColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnValiderModifications.TabIndex = 4020;
            this.m_btnValiderModifications.TabStop = false;
            this.m_btnValiderModifications.Click += new System.EventHandler(this.m_btnValiderModifications_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 24);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4;
            this.label1.Text = "Quick search filter setup|20109";
            // 
            // m_lblTypeEnCours
            // 
            this.m_lblTypeEnCours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblTypeEnCours.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.m_lblTypeEnCours, "");
            this.m_lblTypeEnCours.Location = new System.Drawing.Point(132, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblTypeEnCours, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblTypeEnCours.Name = "m_lblTypeEnCours";
            this.m_lblTypeEnCours.Size = new System.Drawing.Size(420, 23);
            this.m_extStyle.SetStyleBackColor(this.m_lblTypeEnCours, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblTypeEnCours, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblTypeEnCours.TabIndex = 1;
            // 
            // CFormEditionPreferenceFiltreRapide
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(830, 567);
            this.Controls.Add(this.m_panGeneral);
            this.KeyPreview = true;
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CFormEditionPreferenceFiltreRapide";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panGeneral.ResumeLayout(false);
            this.m_panGeneral.PerformLayout();
            this.m_splitContainer.Panel1.ResumeLayout(false);
            this.m_splitContainer.Panel2.ResumeLayout(false);
            this.m_splitContainer.ResumeLayout(false);
            this.m_panelEditFiltre.ResumeLayout(false);
            this.m_panelEditFiltre.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.c2iPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}



		#endregion

        private CContexteDonnee m_contexteDonnee = null;


        private CPreferenceFiltreRapide m_preferenceEditee = null;

        private Type m_typeEdite = null;

		

		public CFormEditionPreferenceFiltreRapide()
		{
			InitializeComponent();
			InitChamps();
			m_gestionnaireModeEdition.ModeEdition = false;
            m_contexteDonnee = CSc2iWin32DataClient.ContexteCourant;
		}

		//INITIALISATION
		public CResultAErreur InitChamps()
		{
			CTimosApp.Titre = I.T("Quick search filter|20108");

            // Init de la liste des types 
            m_wndListeTypes.Items.Clear();
            foreach (CInfoClasseDynamique info in DynamicClassAttribute.GetAllDynamicClass(typeof(TableAttribute)))
            {
                ListViewItem item = new ListViewItem(info.Nom);
                item.Tag = info;
                m_wndListeTypes.Items.Add(item);
            }

            
			return CResultAErreur.True;
		}


		#region IFormNavigable Membres

        public event ContexteFormEventHandler AfterGetContexte;
        public event ContexteFormEventHandler AfterInitFromContexte;

        public CContexteFormNavigable GetContexte()
        {
            CContexteFormNavigable contexte = new CContexteFormNavigable(GetType());
            if (AfterGetContexte != null)
                AfterGetContexte(this, contexte);
            return contexte;
        }


        public bool QueryClose()
        {
            return true;
        }

        public sc2i.common.CResultAErreur InitFromContexte(CContexteFormNavigable contexte)
        {
            if (AfterInitFromContexte != null)
                AfterInitFromContexte(this, contexte);
            return CResultAErreur.True;
        }
        //------------------------------------------------------------------
        public CResultAErreur Actualiser()
        {
            return InitFromContexte(GetContexte());
        }


		#endregion

        private void m_btnEditerObjet_Click(object sender, EventArgs e)
        {
            if (m_wndListeTypes.SelectedItems.Count == 1)
            {
                CInfoClasseDynamique classe = (CInfoClasseDynamique)m_wndListeTypes.SelectedItems[0].Tag;
                if (m_preferenceEditee == null)
                {
                    m_preferenceEditee = new CPreferenceFiltreRapide(m_contexteDonnee);
                    m_preferenceEditee.CreateNew();
                    m_preferenceEditee.TypeObjets = classe.Classe;
                    
                }
                else
                    m_preferenceEditee.BeginEdit();
                m_typeEdite = classe.Classe;
                m_gestionnaireModeEdition.ModeEdition = true;
            }
        }

        private void m_btnValiderModifications_Click(object sender, EventArgs e)
        {
            CResultAErreur result = MAJ_Champs();
            if (result && m_preferenceEditee != null)
            {
                // Enregistre le dictionnaire de préférences dans le registre de la base Timos
                result = m_preferenceEditee.CommitEdit();
                OnChangeTypeSelectionne();
            }
            if (!result)
            {
                CFormAfficheErreur.Show(result.Erreur);
                return;
            }
            m_gestionnaireModeEdition.ModeEdition = false;

        }

        private void m_btnAnnulerModifications_Click(object sender, EventArgs e)
        {
            if (m_preferenceEditee != null)
            {
                if (m_preferenceEditee.IsNew())
                    m_preferenceEditee.CancelCreate();
                else
                    m_preferenceEditee.CancelEdit();
                m_gestionnaireModeEdition.ModeEdition = false;
                OnChangeTypeSelectionne();
            }

        }

        CInfoClasseDynamique m_infoClasseEncours = null;
        private void m_wndListeTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnChangeTypeSelectionne();
        }

        private void OnChangeTypeSelectionne()
        {
            if (m_gestionnaireModeEdition.ModeEdition)
                return;
            m_preferenceEditee = null;
            m_panelEditFiltre.Visible = false;


            if (m_wndListeTypes.SelectedItems.Count == 1)
            {
                CInfoClasseDynamique info = (CInfoClasseDynamique)m_wndListeTypes.SelectedItems[0].Tag;
                if (info != null)
                {
                    m_panelEditFiltre.Visible = true;
                    m_preferenceEditee = CPreferenceFiltreRapide.GetPreferenceForType(info.Classe);
                    CFiltreData filtre = null;
                    if (m_preferenceEditee == null || m_preferenceEditee.FiltrePrefere == null)
                    {
                        filtre = CFournisseurFiltreRapide.GetFiltreRapideForType(info.Classe);
                    }
                    else
                    {
                        filtre = m_preferenceEditee.FiltrePrefere;
                    }
                    if (filtre == null)
                    {
                        filtre = new CFiltreData();
                    }
                    m_txtFiltre.Text = filtre.Filtre;
                    if (filtre.Parametres.Count < 1)
                        filtre.Parametres.Add("");
                    m_lblTypeEnCours.Text = info.Nom;
                    m_panelParametres.Filtre = filtre;
                }
            }

        }

        public CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = CResultAErreur.True;

            if (m_preferenceEditee != null && m_gestionnaireModeEdition.ModeEdition)
            {
                if ( m_txtFiltre.Text == "" )
                    m_preferenceEditee.FiltrePrefere = null;
                else
                {
                    string strNomTable = CContexteDonnee.GetNomTableForType ( m_preferenceEditee.TypeObjets );
                    result = CAnalyseurSyntaxiqueFiltre.AnalyseFormule(m_txtFiltre.Text, strNomTable);
                    if (!result)
                        return result;

                    CFiltreDataAvance filtre = new CFiltreDataAvance(strNomTable,"");
                    filtre.ComposantPrincipal = result.Data as CComposantFiltre;
                    m_panelParametres.AffecteToFiltre(filtre);
                    m_preferenceEditee.FiltrePrefere = filtre;
                }
            }
            return result;
        }

        private void m_btnFiltreDynamique_Click(object sender, EventArgs e)
        {
            CFiltreDynamique filtre = new CFiltreDynamique();
            filtre.TypeElements = m_typeEdite;
            if (CFormEditFiltreDynamique.EditeFiltre(filtre, true, true, null))
            {
                CResultAErreur result = filtre.GetFiltreData();
                if (result)
                {
                    CFiltreData filtreData = result.Data as CFiltreData;
                    m_txtFiltre.Text += filtreData.Filtre;
                }
            }
        }

        public string GetTitle()
        {
            return I.T("Quick search filter|20108");
        }

        public Image GetImage()
        {
            return Resources.filtre2;
        }

        		
	}
}

