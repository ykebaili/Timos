using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using sc2i.common;

namespace timos
{
	/// <summary>
	/// Description résumée de CFormOrdonnerEntites.
	/// </summary>
	public class CFormOrdonnerEntites : System.Windows.Forms.Form
	{
		private IList m_listeObjets = null;
		private string m_strProprieteOrdre = "";
		private string m_strProprieteToDisplay = "";

		private System.Windows.Forms.ListView m_wndListeEntites;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button m_btnAnnuler;
		private System.Windows.Forms.Button m_btnOk;
		private sc2i.win32.common.C2iNumericUpDown m_numUpPas;
		private sc2i.win32.common.C2iNumericUpDown m_numUpStart;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button m_btnBas;
		private System.Windows.Forms.Button m_btnHaut;
		private System.Windows.Forms.ColumnHeader columnHeader1;
        private sc2i.win32.common.CExtStyle m_extStyle;
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CFormOrdonnerEntites()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormOrdonnerEntites));
            this.m_wndListeEntites = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_numUpPas = new sc2i.win32.common.C2iNumericUpDown();
            this.m_numUpStart = new sc2i.win32.common.C2iNumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_btnBas = new System.Windows.Forms.Button();
            this.m_btnHaut = new System.Windows.Forms.Button();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numUpPas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numUpStart)).BeginInit();
            this.SuspendLayout();
            // 
            // m_wndListeEntites
            // 
            this.m_wndListeEntites.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndListeEntites.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.m_wndListeEntites.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_wndListeEntites.HideSelection = false;
            this.m_wndListeEntites.Location = new System.Drawing.Point(8, 8);
            this.m_wndListeEntites.MultiSelect = false;
            this.m_wndListeEntites.Name = "m_wndListeEntites";
            this.m_wndListeEntites.Size = new System.Drawing.Size(540, 343);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeEntites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeEntites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeEntites.TabIndex = 0;
            this.m_wndListeEntites.UseCompatibleStateImageBehavior = false;
            this.m_wndListeEntites.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 507;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.m_btnAnnuler);
            this.panel1.Controls.Add(this.m_btnOk);
            this.panel1.Location = new System.Drawing.Point(0, 390);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(551, 48);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 2;
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.m_btnAnnuler.Image = global::timos.Properties.Resources.cancel;
            this.m_btnAnnuler.Location = new System.Drawing.Point(282, 4);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(40, 40);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAnnuler.TabIndex = 3;
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnOk.ForeColor = System.Drawing.Color.White;
            this.m_btnOk.Image = global::timos.Properties.Resources.check;
            this.m_btnOk.Location = new System.Drawing.Point(228, 4);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(40, 40);
            this.m_extStyle.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOk.TabIndex = 2;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // m_numUpPas
            // 
            this.m_numUpPas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_numUpPas.DoubleValue = 1;
            this.m_numUpPas.IntValue = 1;
            this.m_numUpPas.Location = new System.Drawing.Point(448, 362);
            this.m_numUpPas.LockEdition = false;
            this.m_numUpPas.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.m_numUpPas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_numUpPas.Name = "m_numUpPas";
            this.m_numUpPas.Size = new System.Drawing.Size(88, 20);
            this.m_extStyle.SetStyleBackColor(this.m_numUpPas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_numUpPas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_numUpPas.TabIndex = 3;
            this.m_numUpPas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_numUpPas.ThousandsSeparator = true;
            this.m_numUpPas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // m_numUpStart
            // 
            this.m_numUpStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_numUpStart.DoubleValue = 0;
            this.m_numUpStart.IntValue = 0;
            this.m_numUpStart.Location = new System.Drawing.Point(282, 362);
            this.m_numUpStart.LockEdition = false;
            this.m_numUpStart.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.m_numUpStart.Name = "m_numUpStart";
            this.m_numUpStart.Size = new System.Drawing.Size(72, 20);
            this.m_extStyle.SetStyleBackColor(this.m_numUpStart, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_numUpStart, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_numUpStart.TabIndex = 4;
            this.m_numUpStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_numUpStart.ThousandsSeparator = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(156, 364);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 5;
            this.label1.Text = "Number from|816";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(372, 364);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 6;
            this.label2.Text = "By step of|817";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_btnBas
            // 
            this.m_btnBas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnBas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnBas.Image = ((System.Drawing.Image)(resources.GetObject("m_btnBas.Image")));
            this.m_btnBas.Location = new System.Drawing.Point(56, 353);
            this.m_btnBas.Name = "m_btnBas";
            this.m_btnBas.Size = new System.Drawing.Size(40, 32);
            this.m_extStyle.SetStyleBackColor(this.m_btnBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnBas.TabIndex = 9;
            this.m_btnBas.Click += new System.EventHandler(this.m_btnBas_Click);
            // 
            // m_btnHaut
            // 
            this.m_btnHaut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnHaut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnHaut.Image = ((System.Drawing.Image)(resources.GetObject("m_btnHaut.Image")));
            this.m_btnHaut.Location = new System.Drawing.Point(16, 353);
            this.m_btnHaut.Name = "m_btnHaut";
            this.m_btnHaut.Size = new System.Drawing.Size(40, 32);
            this.m_extStyle.SetStyleBackColor(this.m_btnHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnHaut.TabIndex = 8;
            this.m_btnHaut.Click += new System.EventHandler(this.m_btnHaut_Click);
            // 
            // CFormOrdonnerEntites
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(552, 439);
            this.ControlBox = false;
            this.Controls.Add(this.m_btnBas);
            this.Controls.Add(this.m_btnHaut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_numUpStart);
            this.Controls.Add(this.m_numUpPas);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_wndListeEntites);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CFormOrdonnerEntites";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.Text = "Entity ordering|30114";
            this.Load += new System.EventHandler(this.CFormOrdonnerEntites_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_numUpPas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numUpStart)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		public static bool ModifieOrdre ( 
			IList listeObjets,
			string strProprieteAAfficher,
			string strProprieteOrdre )
		{
			CFormOrdonnerEntites form = new CFormOrdonnerEntites();
			form.m_listeObjets = listeObjets;
			form.m_strProprieteToDisplay = strProprieteAAfficher;
			form.m_strProprieteOrdre = strProprieteOrdre;
			bool bResult = false;
			if(  form.ShowDialog() == DialogResult.OK )
				bResult = true;
			form.Dispose();
			return bResult;
		}

		/// //////////////////////////////////////////////////
		private class CObjetTrieur : IComparer
		{
			private string m_strPropOrdre ;
			public CObjetTrieur ( string strProprieteOrdre )
			{
				m_strPropOrdre = strProprieteOrdre;
			}

			public int Compare(object x, object y)
			{
				try
				{
					int nVal1 = (int) ( CInterpreteurTextePropriete.GetValue ( x, m_strPropOrdre ) );
					int nVal2 = (int) ( CInterpreteurTextePropriete.GetValue ( y, m_strPropOrdre ) );
					return nVal1.CompareTo(nVal2);
				}
				catch
				{
				}
				return 0;
			}
		}
		/// //////////////////////////////////////////////////
		private void CFormOrdonnerEntites_Load(object sender, System.EventArgs e)
		{
			ArrayList lst = new ArrayList ( m_listeObjets );
			lst.Sort ( new CObjetTrieur ( m_strProprieteOrdre ) );
			m_wndListeEntites.Items.Clear();
			foreach ( object obj in lst )
			{
				ListViewItem item = new ListViewItem (CInterpreteurTextePropriete.GetValue ( obj, m_strProprieteToDisplay ).ToString() );
				item.Tag = obj;
				m_wndListeEntites.Items.Add ( item );
			}
		}

		/// //////////////////////////////////////////////////
		private void m_btnHaut_Click(object sender, System.EventArgs e)
		{
			if ( m_wndListeEntites.SelectedItems.Count == 0 )
				return;
			ListViewItem item = m_wndListeEntites.SelectedItems[0];
			if ( item.Index > 0 )
			{
				int nIndex = item.Index;
				m_wndListeEntites.Items.Remove ( item );
				m_wndListeEntites.Items.Insert ( nIndex-1, item );
				m_wndListeEntites.SelectedItems.Clear();
				item.Selected = true;
			}
		}

		private void m_btnBas_Click(object sender, System.EventArgs e)
		{
			if ( m_wndListeEntites.SelectedItems.Count == 0 )
				return;
			ListViewItem item = m_wndListeEntites.SelectedItems[0];
			if ( item.Index < m_wndListeEntites.Items.Count-1 )
			{
				int nIndex = item.Index;
				m_wndListeEntites.Items.Remove ( item );
				m_wndListeEntites.Items.Insert ( nIndex+1, item );
				m_wndListeEntites.SelectedItems.Clear();
				item.Selected = true;
			}
		}

		private void m_btnOk_Click(object sender, System.EventArgs e)
		{
			int nIndice = m_numUpStart.IntValue;
			int nPas = m_numUpPas.IntValue;

			foreach ( ListViewItem item in m_wndListeEntites.Items )
			{
				CInterpreteurTextePropriete.SetValue ( 
					item.Tag, m_strProprieteOrdre, nIndice );
				nIndice += nPas;
			}
			DialogResult = DialogResult.OK;
			Close();
		}

		/// //////////////////////////////////////////////////
		
				
	}
}
