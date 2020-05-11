using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using sc2i.common;
using sc2i.data;
using sc2i.win32.data;
using sc2i.data.dynamic;
using sc2i.win32.data.dynamic;
using sc2i.expression;
using sc2i.win32.common;
using sc2i.workflow;
using sc2i.win32.data.navigation;

namespace timos.win32.composants
{
	/// <summary>
	/// Description résumée de CFormSelectElementsMultiples.
	/// </summary>
	public class CFormSelectElementsMultiples : System.Windows.Forms.Form
	{
		private sc2i.win32.common.C2iPanelOmbre m_panelGeneral;
		private System.Windows.Forms.Button m_btnAnnuler;
		private System.Windows.Forms.Button m_btnOk;
		private System.Windows.Forms.Panel panel1;
		private timos.win32.composants.CPanelSelectListeElements m_panelSelection;
        protected CExtStyle m_ExtStyle;
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CFormSelectElementsMultiples()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormSelectElementsMultiples));
            this.m_panelGeneral = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panelSelection = new timos.win32.composants.CPanelSelectListeElements();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_ExtStyle = new sc2i.win32.common.CExtStyle();
            this.m_panelGeneral.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelGeneral
            // 
            this.m_panelGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelGeneral.Controls.Add(this.m_panelSelection);
            this.m_panelGeneral.Controls.Add(this.panel1);
            this.m_panelGeneral.ForeColor = System.Drawing.Color.Black;
            this.m_panelGeneral.Location = new System.Drawing.Point(0, 0);
            this.m_panelGeneral.LockEdition = false;
            this.m_panelGeneral.Name = "m_panelGeneral";
            this.m_panelGeneral.Size = new System.Drawing.Size(504, 403);
            this.m_ExtStyle.SetStyleBackColor(this.m_panelGeneral, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_ExtStyle.SetStyleForeColor(this.m_panelGeneral, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelGeneral.TabIndex = 4008;
            // 
            // m_panelSelection
            // 
            this.m_panelSelection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelSelection.ForeColor = System.Drawing.Color.Black;
            this.m_panelSelection.Location = new System.Drawing.Point(0, 0);
            this.m_panelSelection.LockEdition = false;
            this.m_panelSelection.Name = "m_panelSelection";
            this.m_panelSelection.Size = new System.Drawing.Size(488, 336);
            this.m_ExtStyle.SetStyleBackColor(this.m_panelSelection, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_ExtStyle.SetStyleForeColor(this.m_panelSelection, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelSelection.TabIndex = 4015;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.m_btnOk);
            this.panel1.Controls.Add(this.m_btnAnnuler);
            this.panel1.Location = new System.Drawing.Point(192, 336);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 48);
            this.m_ExtStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 4014;
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnOk.ForeColor = System.Drawing.Color.White;
            this.m_btnOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btnOk.Image")));
            this.m_btnOk.Location = new System.Drawing.Point(14, 0);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(40, 40);
            this.m_ExtStyle.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOk.TabIndex = 4012;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.m_btnAnnuler.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAnnuler.Image")));
            this.m_btnAnnuler.Location = new System.Drawing.Point(62, 0);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(40, 40);
            this.m_ExtStyle.SetStyleBackColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAnnuler.TabIndex = 4013;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // CFormSelectElementsMultiples
            // 
            this.AcceptButton = this.m_btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.m_btnAnnuler;
            this.ClientSize = new System.Drawing.Size(504, 400);
            this.Controls.Add(this.m_panelGeneral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CFormSelectElementsMultiples";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.m_ExtStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "CFormSelectElementsMultiples";
            this.Load += new System.EventHandler(this.CFormSelectElementsMultiples_Load);
            this.m_panelGeneral.ResumeLayout(false);
            this.m_panelGeneral.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void m_btnAnnuler_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void m_btnOk_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		/// <summary>
		/// Sélectionne une liste d'éléments du type demandé
		/// </summary>
		/// <param name="typeElements"></param>
		/// <param name="filtreElements"></param>
		/// <param name="elementsSelectionnes"></param>
		/// <returns>null si abandon, sinon, une liste d'éléments</returns>
		public static CObjetDonneeAIdNumerique[] GetListeElements ( Type typeElements,
			CFiltreData filtreElements,
			CObjetDonneeAIdNumerique[] elementsSelectionnes )
		{
			CFormSelectElementsMultiples form = new CFormSelectElementsMultiples( );
			form.m_panelSelection.Init ( typeElements, elementsSelectionnes, filtreElements ); 
			bool bResult = form.ShowDialog() == DialogResult.OK;
			CObjetDonneeAIdNumerique[] objets = null;
			if ( bResult )
				objets = form.m_panelSelection.ElementSelectionnes;
			form.Dispose();
			return objets;
		}

        private void CFormSelectElementsMultiples_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
        }
	}
}
