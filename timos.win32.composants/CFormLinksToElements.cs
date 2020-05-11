using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using sc2i.data;

namespace timos.win32.composants
{
	/// <summary>
	/// Description résumée de CFormLinksToElements.
	/// </summary>
	public class CFormLinksToElements : System.Windows.Forms.Form
	{
		private CObjetDonneeAIdNumerique m_objetSel = null;
		private sc2i.win32.common.GlacialList m_wndListe;
		private sc2i.win32.common.C2iPanelOmbre m_panelFond;
		private System.Windows.Forms.Button m_btnAnnuler;
        protected sc2i.win32.common.CExtStyle m_ExtStyle;
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CFormLinksToElements()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Code généré par le Concepteur Windows Form
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormLinksToElements));
            this.m_wndListe = new sc2i.win32.common.GlacialList();
            this.m_panelFond = new sc2i.win32.common.C2iPanelOmbre();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_ExtStyle = new sc2i.win32.common.CExtStyle();
            this.m_panelFond.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_wndListe
            // 
            this.m_wndListe.AllowColumnResize = true;
            this.m_wndListe.AllowMultiselect = false;
            this.m_wndListe.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.m_wndListe.AlternatingColors = false;
            this.m_wndListe.AutoHeight = true;
            this.m_wndListe.AutoSort = true;
            this.m_wndListe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_wndListe.CanChangeActivationCheckBoxes = false;
            this.m_wndListe.CheckBoxes = false;
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Column1";
            glColumn1.Propriete = "DescriptionElement";
            glColumn1.Text = "Element|30085";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 480;
            this.m_wndListe.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_wndListe.ContexteUtilisation = "";
            this.m_wndListe.EnableCustomisation = true;
            this.m_wndListe.FocusedItem = null;
            this.m_wndListe.ForeColor = System.Drawing.Color.Black;
            this.m_wndListe.FullRowSelect = true;
            this.m_wndListe.GLGridLines = sc2i.win32.common.GLGridStyles.gridNone;
            this.m_wndListe.GridColor = System.Drawing.Color.Gray;
            this.m_wndListe.HeaderHeight = 0;
            this.m_wndListe.HeaderStyle = sc2i.win32.common.GLHeaderStyles.Normal;
            this.m_wndListe.HeaderTextColor = System.Drawing.Color.Black;
            this.m_wndListe.HeaderVisible = false;
            this.m_wndListe.HeaderWordWrap = false;
            this.m_wndListe.HotColumnIndex = -1;
            this.m_wndListe.HotItemIndex = -1;
            this.m_wndListe.HotTracking = false;
            this.m_wndListe.HotTrackingColor = System.Drawing.Color.LightGray;
            this.m_wndListe.ImageList = null;
            this.m_wndListe.ItemHeight = 17;
            this.m_wndListe.ItemWordWrap = false;
            this.m_wndListe.ListeSource = null;
            this.m_wndListe.Location = new System.Drawing.Point(0, 0);
            this.m_wndListe.MaxHeight = 17;
            this.m_wndListe.Name = "m_wndListe";
            this.m_wndListe.SelectedTextColor = System.Drawing.Color.White;
            this.m_wndListe.SelectionColor = System.Drawing.Color.DarkBlue;
            this.m_wndListe.ShowBorder = true;
            this.m_wndListe.ShowFocusRect = false;
            this.m_wndListe.Size = new System.Drawing.Size(488, 176);
            this.m_wndListe.SortIndex = 0;
            this.m_ExtStyle.SetStyleBackColor(this.m_wndListe, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_ExtStyle.SetStyleForeColor(this.m_wndListe, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_wndListe.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.m_wndListe.TabIndex = 2;
            this.m_wndListe.Text = "glacialList1";
            this.m_wndListe.OnChangeSelection += new System.EventHandler(this.m_wndListe_OnChangeSelection);
            // 
            // m_panelFond
            // 
            this.m_panelFond.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelFond.Controls.Add(this.m_btnAnnuler);
            this.m_panelFond.Controls.Add(this.m_wndListe);
            this.m_panelFond.ForeColor = System.Drawing.Color.Black;
            this.m_panelFond.Location = new System.Drawing.Point(0, 0);
            this.m_panelFond.LockEdition = false;
            this.m_panelFond.Name = "m_panelFond";
            this.m_panelFond.Size = new System.Drawing.Size(504, 232);
            this.m_ExtStyle.SetStyleBackColor(this.m_panelFond, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_ExtStyle.SetStyleForeColor(this.m_panelFond, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelFond.TabIndex = 3;
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.m_btnAnnuler.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAnnuler.Image")));
            this.m_btnAnnuler.Location = new System.Drawing.Point(216, 176);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(40, 40);
            this.m_ExtStyle.SetStyleBackColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAnnuler.TabIndex = 4014;
            // 
            // CFormLinksToElements
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(184)))));
            this.CancelButton = this.m_btnAnnuler;
            this.ClientSize = new System.Drawing.Size(504, 225);
            this.Controls.Add(this.m_panelFond);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CFormLinksToElements";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.m_ExtStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "CFormLinksToElements";
            this.m_panelFond.ResumeLayout(false);
            this.m_panelFond.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		public static CObjetDonneeAIdNumerique SelectObjet ( CObjetDonneeAIdNumerique[] objets, Point position )
		{
			CFormLinksToElements form = new CFormLinksToElements();
			form.Location = position;
			if ( form.Right > Screen.PrimaryScreen.WorkingArea.Width )
				form.Left -= form.Right-Screen.PrimaryScreen.WorkingArea.Width;
			if ( form.Bottom > Screen.PrimaryScreen.WorkingArea.Height )
				form.Top -= form.Bottom - Screen.PrimaryScreen.WorkingArea.Height;
			form.m_wndListe.ListeSource = objets;
			CObjetDonneeAIdNumerique objet = null;
			if ( form.ShowDialog() == DialogResult.OK )
				objet = form.m_objetSel;
			form.Dispose();
			return objet;
		}

		private void m_btnFermer_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void m_wndListe_OnChangeSelection(object sender, System.EventArgs e)
		{
			if ( m_wndListe.SelectedItems.Count > 0 )
			{
				m_objetSel = (CObjetDonneeAIdNumerique)m_wndListe.SelectedItems[0];
				DialogResult = DialogResult.OK;
				Close();
			}
		}

	}
}
