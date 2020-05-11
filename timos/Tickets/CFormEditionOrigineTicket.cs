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
using timos.acteurs;

using timos.data;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(COrigineTicket))]
	public class CFormEditionOrigineTicket : CFormEditionStdTimos, IFormNavigable
	{
        private C2iPanelOmbre m_panelOmbre1;
        private C2iTextBox m_txtLibelle;
        private Label lbl_label;
        private C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage m_tabPageFormulaires;
        private CComboBoxListeObjetsDonnees m_cmbxSelectFormulaire;
        private Label lbl_forminstruc;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionOrigineTicket()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionOrigineTicket(COrigineTicket origine)
            : base(origine)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionOrigineTicket(COrigineTicket origine, CListeObjetsDonnees liste)
            : base(origine, liste)
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
			this.m_panelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
			this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
			this.lbl_label = new System.Windows.Forms.Label();
			this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
			this.m_tabPageFormulaires = new Crownwood.Magic.Controls.TabPage();
			this.m_cmbxSelectFormulaire = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
			this.lbl_forminstruc = new System.Windows.Forms.Label();
			this.m_panelOmbre1.SuspendLayout();
			this.m_tabControl.SuspendLayout();
			this.m_tabPageFormulaires.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_panelMenu
			// 
			this.m_panelMenu.Size = new System.Drawing.Size(830, 28);
			this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			// 
			// m_panelOmbre1
			// 
			this.m_panelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
			this.m_panelOmbre1.Controls.Add(this.m_txtLibelle);
			this.m_panelOmbre1.Controls.Add(this.lbl_label);
			this.m_panelOmbre1.ForeColor = System.Drawing.Color.Black;
			this.m_extLinkField.SetLinkField(this.m_panelOmbre1, "");
			this.m_panelOmbre1.Location = new System.Drawing.Point(10, 46);
			this.m_panelOmbre1.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelOmbre1, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_panelOmbre1.Name = "m_panelOmbre1";
			this.m_panelOmbre1.Size = new System.Drawing.Size(543, 69);
			this.m_extStyle.SetStyleBackColor(this.m_panelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
			this.m_extStyle.SetStyleForeColor(this.m_panelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
			this.m_panelOmbre1.TabIndex = 4004;
			// 
			// m_txtLibelle
			// 
			this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
			this.m_txtLibelle.Location = new System.Drawing.Point(165, 13);
			this.m_txtLibelle.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_txtLibelle.Name = "m_txtLibelle";
			this.m_txtLibelle.Size = new System.Drawing.Size(340, 20);
			this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_txtLibelle.TabIndex = 3;
			this.m_txtLibelle.Text = "[Label]|30324";
			// 
			// lbl_label
			// 
			this.m_extLinkField.SetLinkField(this.lbl_label, "");
			this.lbl_label.Location = new System.Drawing.Point(19, 16);
			this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_label, sc2i.win32.common.TypeModeEdition.Autonome);
			this.lbl_label.Name = "lbl_label";
			this.lbl_label.Size = new System.Drawing.Size(140, 13);
			this.m_extStyle.SetStyleBackColor(this.lbl_label, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.lbl_label, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.lbl_label.TabIndex = 4;
			this.lbl_label.Text = "Label of ticket origin|631";
			// 
			// m_tabControl
			// 
			this.m_tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
			this.m_tabControl.BoldSelectedPage = true;
			this.m_tabControl.ControlBottomOffset = 16;
			this.m_tabControl.ControlRightOffset = 16;
			this.m_tabControl.ForeColor = System.Drawing.Color.Black;
			this.m_tabControl.IDEPixelArea = false;
			this.m_extLinkField.SetLinkField(this.m_tabControl, "");
			this.m_tabControl.Location = new System.Drawing.Point(10, 121);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_tabControl.Name = "m_tabControl";
			this.m_tabControl.Ombre = true;
			this.m_tabControl.PositionTop = true;
			this.m_tabControl.SelectedIndex = 0;
			this.m_tabControl.SelectedTab = this.m_tabPageFormulaires;
			this.m_tabControl.Size = new System.Drawing.Size(808, 397);
			this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
			this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
			this.m_tabControl.TabIndex = 4005;
			this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_tabPageFormulaires});
			this.m_tabControl.TextColor = System.Drawing.Color.Black;
			// 
			// m_tabPageFormulaires
			// 
			this.m_tabPageFormulaires.Controls.Add(this.m_cmbxSelectFormulaire);
			this.m_tabPageFormulaires.Controls.Add(this.lbl_forminstruc);
			this.m_extLinkField.SetLinkField(this.m_tabPageFormulaires, "");
			this.m_tabPageFormulaires.Location = new System.Drawing.Point(0, 25);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageFormulaires, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_tabPageFormulaires.Name = "m_tabPageFormulaires";
			this.m_tabPageFormulaires.Size = new System.Drawing.Size(792, 356);
			this.m_extStyle.SetStyleBackColor(this.m_tabPageFormulaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_tabPageFormulaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_tabPageFormulaires.TabIndex = 10;
			this.m_tabPageFormulaires.Title = "Forms|106";
			// 
			// m_cmbxSelectFormulaire
			// 
			this.m_cmbxSelectFormulaire.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cmbxSelectFormulaire.ElementSelectionne = null;
			this.m_cmbxSelectFormulaire.FormattingEnabled = true;
			this.m_cmbxSelectFormulaire.IsLink = false;
			this.m_extLinkField.SetLinkField(this.m_cmbxSelectFormulaire, "");
			this.m_cmbxSelectFormulaire.ListDonnees = null;
			this.m_cmbxSelectFormulaire.Location = new System.Drawing.Point(22, 43);
			this.m_cmbxSelectFormulaire.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxSelectFormulaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_cmbxSelectFormulaire.Name = "m_cmbxSelectFormulaire";
			this.m_cmbxSelectFormulaire.NullAutorise = true;
			this.m_cmbxSelectFormulaire.ProprieteAffichee = null;
			this.m_cmbxSelectFormulaire.ProprieteParentListeObjets = null;
			this.m_cmbxSelectFormulaire.SelectionneurParent = null;
			this.m_cmbxSelectFormulaire.Size = new System.Drawing.Size(296, 21);
			this.m_extStyle.SetStyleBackColor(this.m_cmbxSelectFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_cmbxSelectFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_cmbxSelectFormulaire.TabIndex = 0;
			this.m_cmbxSelectFormulaire.TextNull = I.T("(None)|30291");
			this.m_cmbxSelectFormulaire.Tri = true;
			this.m_cmbxSelectFormulaire.SelectionChangeCommitted += new System.EventHandler(this.m_cmbxSelectFormulaire_SelectionChangeCommitted);
			// 
			// lbl_forminstruc
			// 
			this.m_extLinkField.SetLinkField(this.lbl_forminstruc, "");
			this.lbl_forminstruc.Location = new System.Drawing.Point(19, 9);
			this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_forminstruc, sc2i.win32.common.TypeModeEdition.Autonome);
			this.lbl_forminstruc.Name = "lbl_forminstruc";
			this.lbl_forminstruc.Size = new System.Drawing.Size(347, 31);
			this.m_extStyle.SetStyleBackColor(this.lbl_forminstruc, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.lbl_forminstruc, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.lbl_forminstruc.TabIndex = 4;
			this.lbl_forminstruc.Text = "Select the custom form which will be shown on edition forms for tickets "+
				" having this origin|632";
			// 
			// CFormEditionOrigineTicket
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(830, 530);
			this.Controls.Add(this.m_tabControl);
			this.Controls.Add(this.m_panelOmbre1);
			this.m_extLinkField.SetLinkField(this, "");
			this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.Name = "CFormEditionOrigineTicket";
			this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.Controls.SetChildIndex(this.m_panelMenu, 0);
			this.Controls.SetChildIndex(this.m_panelOmbre1, 0);
			this.Controls.SetChildIndex(this.m_tabControl, 0);
			this.m_panelOmbre1.ResumeLayout(false);
			this.m_panelOmbre1.PerformLayout();
			this.m_tabControl.ResumeLayout(false);
			this.m_tabControl.PerformLayout();
			this.m_tabPageFormulaires.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private COrigineTicket OrigineTicket
		{
			get
			{
				return (COrigineTicket)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T( "Ticket Origin|502" + ": " + OrigineTicket.Libelle));

            CListeObjetsDonnees listeFormulaires = new CListeObjetsDonnees(OrigineTicket.ContexteDonnee, typeof(CFormulaire));

            listeFormulaires.Filtre = CFormulaire.GetFiltreFormulairesForRole(OrigineTicket.RoleChampCustomDesElementsAChamp.CodeRole);
/*                new CFiltreData(
                CFormulaire.c_champCodeRole + "=@1",
                OrigineTicket.RoleChampCustomDesElementsAChamp.CodeRole);*/

            m_cmbxSelectFormulaire.Init(
                listeFormulaires,
                "Libelle",
                true);

            m_cmbxSelectFormulaire.ElementSelectionne = OrigineTicket.Formulaire;

            //InitApercuFormulaire();
            

			return result;
		}

		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();

            if (result)
                OrigineTicket.Formulaire = (CFormulaire)m_cmbxSelectFormulaire.ElementSelectionne;

            return result;
        }

        //-------------------------------------------------------------------------
        private void m_cmbxSelectFormulaire_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MAJ_Champs();
            //InitApercuFormulaire();
        }

        //-------------------------------------------------------------------------
        private void InitApercuFormulaire()
        {
            // Uniquement pour faire un aperçu du Formulaire
            //if (OrigineTicket.Formulaire != null)
            //{
            //    CTicket ticket = new CTicket(OrigineTicket.ContexteDonnee);
            //    ticket.CreateNewInCurrentContexte();
            //    m_panelFormulaireSurOrigine.Visible = true;
            //    m_panelFormulaireSurOrigine.InitPanel(OrigineTicket.Formulaire.Formulaire, ticket);
            //}
            //else
            //    m_panelFormulaireSurOrigine.Visible = false;

        }

	}
}

