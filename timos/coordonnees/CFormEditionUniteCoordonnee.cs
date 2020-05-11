using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;

using timos.data;
using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;

using sc2i.process;

namespace timos
{
    [sc2i.win32.data.navigation.ObjectEditeur(typeof(CUniteCoordonnee))]
    public class CFormEditionUniteCoordonnee : CFormEditionStdTimos, IFormNavigable
    {
        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre m_panel1;
        private Label m_lblLabel;
		private Label m_lblAbreviation;
		private C2iTextBox m_txtAbreviation;
        private System.ComponentModel.IContainer components = null;

        public CFormEditionUniteCoordonnee()
            : base()
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionUniteCoordonnee(CUniteCoordonnee UniteCoordonnee)
            : base(UniteCoordonnee)
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionUniteCoordonnee(CUniteCoordonnee UniteCoordonnee, CListeObjetsDonnees liste)
            : base(UniteCoordonnee, liste)
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
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

        #region Designer generated code
        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_panel1 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_txtAbreviation = new sc2i.win32.common.C2iTextBox();
            this.m_lblLabel = new System.Windows.Forms.Label();
            this.m_lblAbreviation = new System.Windows.Forms.Label();
            this.m_panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(664, 28);
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
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Label|50";
            // 
            // m_txtLibelle
            // 
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(132, 17);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(239, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Label]|30324";
            // 
            // m_panel1
            // 
            this.m_panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panel1.Controls.Add(this.m_lblLabel);
            this.m_panel1.Controls.Add(this.m_txtLibelle);
            this.m_panel1.Controls.Add(this.m_txtAbreviation);
            this.m_panel1.Controls.Add(this.m_lblAbreviation);
            this.m_panel1.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panel1, "");
            this.m_panel1.Location = new System.Drawing.Point(8, 52);
            this.m_panel1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panel1.Name = "m_panel1";
            this.m_panel1.Size = new System.Drawing.Size(464, 150);
            this.m_extStyle.SetStyleBackColor(this.m_panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panel1.TabIndex = 0;
            // 
            // m_txtAbreviation
            // 
            this.m_extLinkField.SetLinkField(this.m_txtAbreviation, "Abreviation");
            this.m_txtAbreviation.Location = new System.Drawing.Point(132, 43);
            this.m_txtAbreviation.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtAbreviation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtAbreviation.Name = "m_txtAbreviation";
            this.m_txtAbreviation.Size = new System.Drawing.Size(239, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtAbreviation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtAbreviation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtAbreviation.TabIndex = 0;
            this.m_txtAbreviation.Text = "[Abreviation]";
            // 
            // m_lblLabel
            // 
            this.m_lblLabel.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lblLabel, "");
            this.m_lblLabel.Location = new System.Drawing.Point(23, 20);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblLabel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblLabel.Name = "m_lblLabel";
            this.m_lblLabel.Size = new System.Drawing.Size(47, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblLabel.TabIndex = 4005;
            this.m_lblLabel.Text = "Label|50";
            // 
            // m_lblAbreviation
            // 
            this.m_lblAbreviation.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lblAbreviation, "");
            this.m_lblAbreviation.Location = new System.Drawing.Point(26, 46);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblAbreviation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblAbreviation.Name = "m_lblAbreviation";
            this.m_lblAbreviation.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.m_lblAbreviation.Size = new System.Drawing.Size(86, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblAbreviation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblAbreviation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblAbreviation.TabIndex = 4005;
            this.m_lblAbreviation.Text = "Abbreviation|456";
            this.m_lblAbreviation.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CFormEditionUniteCoordonnee
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(664, 561);
            this.Controls.Add(this.m_panel1);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CFormEditionUniteCoordonnee";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_panel1, 0);
            this.m_panel1.ResumeLayout(false);
            this.m_panel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        //-------------------------------------------------------------------------
        private CUniteCoordonnee UniteCoordonnee
        {
            get
            {
				return (CUniteCoordonnee)ObjetEdite;
            }
        }

        //-------------------------------------------------------------------------
        protected override CResultAErreur MyInitChamps()
        {
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T( "Unit |444") + UniteCoordonnee.Libelle);

            return result;
        }

	}
}

