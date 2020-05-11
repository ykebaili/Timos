using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace timos
{
	/// <summary>
	/// Description résumée de CFormViewDataTable.
	/// </summary>
	public class CFormViewDataTable : System.Windows.Forms.Form
	{
		private DataTable m_table = null;
		private System.Windows.Forms.DataGrid m_grid;
		private System.Windows.Forms.Button m_btnFermer;
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CFormViewDataTable()
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
            this.m_grid = new System.Windows.Forms.DataGrid();
            this.m_btnFermer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // m_grid
            // 
            this.m_grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_grid.BackgroundColor = System.Drawing.Color.White;
            this.m_grid.DataMember = "";
            this.m_grid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.m_grid.Location = new System.Drawing.Point(0, 0);
            this.m_grid.Name = "m_grid";
            this.m_grid.ReadOnly = true;
            this.m_grid.Size = new System.Drawing.Size(608, 408);
            this.m_grid.TabIndex = 0;
            // 
            // m_btnFermer
            // 
            this.m_btnFermer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.m_btnFermer.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnFermer.Location = new System.Drawing.Point(260, 410);
            this.m_btnFermer.Name = "m_btnFermer";
            this.m_btnFermer.Size = new System.Drawing.Size(88, 24);
            this.m_btnFermer.TabIndex = 1;
            this.m_btnFermer.Text = "Close|12";
            this.m_btnFermer.Click += new System.EventHandler(this.m_btnFermer_Click);
            // 
            // CFormViewDataTable
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.m_btnFermer;
            this.ClientSize = new System.Drawing.Size(608, 437);
            this.Controls.Add(this.m_btnFermer);
            this.Controls.Add(this.m_grid);
            this.Name = "CFormViewDataTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Request result|818";
            this.Load += new System.EventHandler(this.CFormViewDataTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_grid)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void CFormViewDataTable_Load(object sender, System.EventArgs e)
		{
			m_grid.DataSource = m_table;
		}

		public static void ShowTable ( DataTable table )
		{
			if ( table == null )
				return;
			CFormViewDataTable form = new CFormViewDataTable();
			form.m_table = table;
			form.ShowDialog();
			form.Dispose();
		}

		private void m_btnFermer_Click(object sender, System.EventArgs e)
		{
			Close();
		}
	}
}
