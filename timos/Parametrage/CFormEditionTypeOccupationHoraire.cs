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

using sc2i.workflow;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CTypeOccupationHoraire))]
	public class CFormEditionTypeOccupationHoraire : CFormEditionStdTimos, IFormNavigable
	{
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private C2iTextBox c2iTextBox1;
        private Label label2;
        private Label label3;
        private C2iPanel m_panelCouleur;
		private CheckBox checkBox1;
		private CheckBox checkBox2;
		private Label label4;
		private C2iTextBoxNumerique m_txtNumPriorite;
		private Label label5;
        private CheckBox m_chkEstDisponible;
		private CheckBox checkBox3;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionTypeOccupationHoraire()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeOccupationHoraire(CTypeOccupationHoraire civilite)
			:base(civilite)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeOccupationHoraire(CTypeOccupationHoraire civilite, CListeObjetsDonnees liste)
			:base(civilite, liste)
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtNumPriorite = new sc2i.win32.common.C2iTextBoxNumerique();
            this.label5 = new System.Windows.Forms.Label();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_panelCouleur = new sc2i.win32.common.C2iPanel(this.components);
            this.m_chkEstDisponible = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.c2iPanelOmbre4.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(830, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Label |50";
            // 
            // m_txtLibelle
            // 
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(132, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(356, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Label]|30324";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.checkBox3);
            this.c2iPanelOmbre4.Controls.Add(this.checkBox2);
            this.c2iPanelOmbre4.Controls.Add(this.label4);
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtNumPriorite);
            this.c2iPanelOmbre4.Controls.Add(this.label5);
            this.c2iPanelOmbre4.Controls.Add(this.c2iTextBox1);
            this.c2iPanelOmbre4.Controls.Add(this.checkBox1);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.Controls.Add(this.m_panelCouleur);
            this.c2iPanelOmbre4.Controls.Add(this.m_chkEstDisponible);
            this.c2iPanelOmbre4.Controls.Add(this.label3);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(537, 238);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.checkBox3, "TempsDeTravail");
            this.checkBox3.Location = new System.Drawing.Point(132, 153);
            this.m_gestionnaireModeEdition.SetModeEdition(this.checkBox3, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(94, 17);
            this.m_extStyle.SetStyleBackColor(this.checkBox3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.checkBox3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.checkBox3.TabIndex = 4009;
            this.checkBox3.Text = "Work time|976";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.checkBox2, "SurOperation");
            this.checkBox2.Location = new System.Drawing.Point(132, 133);
            this.m_gestionnaireModeEdition.SetModeEdition(this.checkBox2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(175, 17);
            this.m_extStyle.SetStyleBackColor(this.checkBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.checkBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.checkBox2.TabIndex = 4005;
            this.checkBox2.Text = "Can be used on Operations|975";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(16, 197);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4007;
            this.label4.Text = "Priority level|507";
            // 
            // m_txtNumPriorite
            // 
            this.m_txtNumPriorite.Arrondi = 0;
            this.m_txtNumPriorite.DecimalAutorise = false;
            this.m_txtNumPriorite.DoubleValue = 0;
            this.m_txtNumPriorite.IntValue = 0;
            this.m_extLinkField.SetLinkField(this.m_txtNumPriorite, "Priorite");
            this.m_txtNumPriorite.Location = new System.Drawing.Point(132, 194);
            this.m_txtNumPriorite.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNumPriorite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtNumPriorite.Name = "m_txtNumPriorite";
            this.m_txtNumPriorite.NullAutorise = false;
            this.m_txtNumPriorite.Size = new System.Drawing.Size(116, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtNumPriorite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtNumPriorite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNumPriorite.TabIndex = 4008;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(16, 177);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(375, 13);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4006;
            this.label5.Text = "Indicate the Occupation Type priority (a higher number for a higher priority)|977" +
                "";
            // 
            // c2iTextBox1
            // 
            this.m_extLinkField.SetLinkField(this.c2iTextBox1, "Code");
            this.c2iTextBox1.Location = new System.Drawing.Point(132, 34);
            this.c2iTextBox1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(356, 20);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 0;
            this.c2iTextBox1.Text = "[Code]";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.checkBox1, "SurCalendrier");
            this.checkBox1.Location = new System.Drawing.Point(132, 115);
            this.m_gestionnaireModeEdition.SetModeEdition(this.checkBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(171, 17);
            this.m_extStyle.SetStyleBackColor(this.checkBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.checkBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.checkBox1.TabIndex = 4004;
            this.checkBox1.Text = "Can be used on Calendars|974";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(16, 38);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4002;
            this.label2.Text = "Code|231";
            // 
            // m_panelCouleur
            // 
            this.m_panelCouleur.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_panelCouleur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_extLinkField.SetLinkField(this.m_panelCouleur, "");
            this.m_panelCouleur.Location = new System.Drawing.Point(132, 65);
            this.m_panelCouleur.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelCouleur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelCouleur.Name = "m_panelCouleur";
            this.m_panelCouleur.Size = new System.Drawing.Size(32, 20);
            this.m_extStyle.SetStyleBackColor(this.m_panelCouleur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCouleur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelCouleur.TabIndex = 4003;
            this.m_panelCouleur.Click += new System.EventHandler(this.m_panelCouleur_Click);
            // 
            // m_chkEstDisponible
            // 
            this.m_chkEstDisponible.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkEstDisponible, "EstDisponible");
            this.m_chkEstDisponible.Location = new System.Drawing.Point(132, 96);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkEstDisponible, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkEstDisponible.Name = "m_chkEstDisponible";
            this.m_chkEstDisponible.Size = new System.Drawing.Size(252, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkEstDisponible, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkEstDisponible, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkEstDisponible.TabIndex = 4004;
            this.m_chkEstDisponible.Text = "The member is available on this occupation type|973";
            this.m_chkEstDisponible.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(16, 69);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4002;
            this.label3.Text = "Color|457";
            // 
            // CFormEditionTypeOccupationHoraire
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CFormEditionTypeOccupationHoraire";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.c2iPanelOmbre4.ResumeLayout(false);
            this.c2iPanelOmbre4.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CTypeOccupationHoraire TypeOccupationHoraire
		{
			get
			{
				return (CTypeOccupationHoraire)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T("Occupation type |30238") + TypeOccupationHoraire.Libelle);

            m_panelCouleur.BackColor = Color.FromArgb(TypeOccupationHoraire.Couleur);


			return result;
		}
		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();

            if(result)
                TypeOccupationHoraire.Couleur = m_panelCouleur.BackColor.ToArgb();

            return result;
        }


        //-------------------------------------------------------------------------
        private void m_panelCouleur_Click(object sender, EventArgs e)
        {
            // Ouvre le control de selection des couleur Windows
            if (m_gestionnaireModeEdition.ModeEdition)
            {
                ColorDialog colDlg = new ColorDialog();

                colDlg.Color = m_panelCouleur.BackColor;
                colDlg.ShowDialog();
                m_panelCouleur.BackColor = colDlg.Color;
            }
        }


	}
}

