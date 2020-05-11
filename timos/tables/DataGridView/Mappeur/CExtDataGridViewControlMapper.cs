using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

using sc2i.common;
using sc2i.win32.common;

namespace timos.tables
{
	public class CExtDataGridViewControlMapper : Component
	{
		/// <summary>
		/// Si true, on peut sortir de la grille, même s'il y a des erreur
		/// par exemple, en cas d'annulation d'édition
		/// </summary>
		private bool m_bSortieSansControle = false;

		/// <summary>
		/// Datagrid view associé
		/// </summary>
		private DataGridView m_dataGridView;

		//Dataview associé
		private DataView m_dataView;

		///Liste des controles qui annulent l'édition
		private List<Control> m_listeControlesAnnulationEdition = new List<Control>();

		//INITIALISATION
		/// <summary>
		/// Indique que la source de données est en cours d'affectation sur le datasource
		/// </summary>
		private bool m_bInitSourceEnCours = false;
		private IContainer components;


		private List<string> m_lstNomsColonnesAMasquer = new List<string>();

		//--------------------------------------------------------------------		
		public CExtDataGridViewControlMapper()
		{

		}

		//--------------------------------------------------------------------		
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.m_ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			// 
			// ctxMenu
			// 
			this.m_ctxMenu.Name = "ctxMenu";

		}

		/// <summary>
		/// Indique qu'il est possible de sortir de la grille
		/// même s'il y a des erreurs. DAns ce cas, les modifs sont perdues.
		/// Si vrai, la validation de la grille n'est donc pas assurée
		/// /// </summary>
		public bool SortirSansControle
		{
			get
			{
				return m_bSortieSansControle;
			}
			set
			{
				m_bSortieSansControle = value;
			}
		}

		//--------------------------------------------------------------------		
		[System.ComponentModel.Browsable(false)]
		public List<Control> ListeControlesAnnulantEdition
		{
			get
			{
				return m_listeControlesAnnulationEdition;
			}
		}


		//--------------------------------------------------------------------		
		public DataGridView DataGridViewMappe
		{
			get
			{
				return m_dataGridView;
			}
			set
			{
				m_dataGridView = value;
				if (m_dataGridView != null)
				{
					m_dataGridView.RowValidating += new DataGridViewCellCancelEventHandler(m_dgv_RowValidating);
					m_dataGridView.DataSourceChanged += new EventHandler(m_dg_DataSourceChanged);
					m_dataGridView.DataError += new DataGridViewDataErrorEventHandler(m_dgv_DataError);
					m_dataGridView.CellValueChanged += new DataGridViewCellEventHandler(m_dgv_CellValueChanged);
					m_dataGridView.Leave += new EventHandler(m_dataGridView_Leave);
					m_dataGridView.RowValidated += new DataGridViewCellEventHandler(m_dataGridView_RowValidated);
				}
			}
		}

		void m_dataGridView_RowValidated(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewRow row = m_dataGridView.Rows[e.RowIndex];
			row.ErrorText = "";
			foreach (DataGridViewCell cell in row.Cells)
				cell.ErrorText = "";
		}

		void m_dataGridView_Leave(object sender, EventArgs e)
		{
			Form frm = m_dataGridView.FindForm();
			if (frm != null && m_listeControlesAnnulationEdition.Contains(frm.ActiveControl))
				m_bSortieSansControle = true;
			if (m_bSortieSansControle)
			{
				m_dataGridView.CancelEdit();
			}
		}

		//---------------------------------------------------------------------
		void m_dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				DataGridViewCell cell = m_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
				if (cell != null)
				{
					string strErreur = null;
					ValideCell(cell, out strErreur);
				}
			}
			catch
			{
			}
			
		}

		//---------------------------------------------------------------------
		/// <summary>
		/// Teste la valeur d'une cellule
		/// </summary>
		/// <param name="cell"></param>
		/// <param name="strErreur">null si pas d'erreur, le texte de l'erreur sinon</param>
		private void ValideCell(DataGridViewCell cell, out string strErreur)
		{
			strErreur = null;
			if (cell == null)
				return;

			DataColumn col = m_dataView.Table.Columns[cell.ColumnIndex];
			if (!col.AllowDBNull && cell.Value == DBNull.Value)
			{
				strErreur = I.T("The '@1' column cannot be empty|1202", col.ColumnName);
				cell.ErrorText = strErreur;
			}
			else
				cell.ErrorText = "";
			m_dataGridView.Rows[cell.RowIndex].ErrorText = "";
			
		}



		//---------------------------------------------------------------------
		/// <summary>
		/// REtourne vrai si la ligne est valide, false sinon
		/// </summary>
		/// <param name="dataViewRow"></param>
		/// <returns></returns>
		private bool ValideLigne(DataGridViewRow dataViewRow)
		{
			string strErreurLigne = "";
			
			if (OnValidationLigne != null)
				OnValidationLigne(strErreurLigne != "", strErreurLigne);
			return strErreurLigne == "";
		}

		//---------------------------------------------------
		public List<string> NomsColonnesAMasquer
		{
			get
			{
				return m_lstNomsColonnesAMasquer;
			}
		}

		//---------------------------------------------------
		void m_dgv_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
		{
			if (m_bSortieSansControle)
				return;
			if (!m_dataGridView.IsCurrentRowDirty)
				return;
			DataGridViewRow row = m_dataGridView.CurrentRow;
			if (row != null)
				e.Cancel = !ValideLigne(row);
		}

		

		
		/// <summary>
		/// Modifie les propriétés du datagridview associé
		/// pour qu'il applique le comportement du dataGridViewControlMapper
		/// </summary>
		private void InitialiserDataGridView()
		{
			m_dataGridView.AutoGenerateColumns = false;
			m_dataGridView.ShowCellErrors = true;
			m_dataGridView.ShowRowErrors = true;
			m_dataGridView.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(m_dg_RowHeaderMouseClick);
			m_dataGridView.Columns.Clear();

			foreach (DataColumn col in m_dataView.Table.Columns)
			{
				if (!m_lstNomsColonnesAMasquer.Contains(col.ColumnName))
				{
					DataGridViewColumn dgvCol = new DataGridViewColumn(new CDataGridViewCustomCell(col.DataType, col.AllowDBNull));
					dgvCol.HeaderCell.Style = StyleColHeader;
					dgvCol.DataPropertyName = col.ColumnName;
					dgvCol.Name = col.ColumnName;
					dgvCol.SortMode = DataGridViewColumnSortMode.Automatic;
					dgvCol.ReadOnly = col.AutoIncrement;
					dgvCol.Width = GetDefaultSizeCol(dgvCol);
					m_dataGridView.Columns.Add(dgvCol);
				}
			}
		}

		/// <summary>
		/// Crée le dataview qui présente les données à partir
		/// du datasource initial du datagridview
		/// </summary>
		/// <returns></returns>
		private bool InitialiserSource()
		{
			m_dataView = null;
			if (m_dataGridView != null && m_dataGridView.DataSource != null)
			{
				DataTable table = null;
				if (m_dataGridView.DataSource.GetType() == typeof(DataTable))
					table = ((DataTable)m_dataGridView.DataSource);
				else if (m_dataGridView.DataSource.GetType() == typeof(DataView))
					table = ((DataView)m_dataGridView.DataSource).Table;
				else
					return false;

				m_dataView = table.DefaultView;
				m_bInitSourceEnCours = true;
				m_dataGridView.DataSource = m_dataView;
				m_bInitSourceEnCours = false;
				return true;
			}

			return false;
		}

		//-------------------------------------------------
		void m_dg_DataSourceChanged(object sender, EventArgs e)
		{
			if (!m_bInitSourceEnCours && InitialiserSource())
				InitialiserDataGridView();
		}



	
		//STYLES
		private DataGridViewCellStyle m_styleColHeader;
		private DataGridViewCellStyle StyleColHeader
		{
			get
			{
				if (m_styleColHeader == null)
				{
					m_styleColHeader = new DataGridViewCellStyle();
					m_styleColHeader.BackColor = Color.Black;
					m_styleColHeader.ForeColor = Color.White;
					m_styleColHeader.Font = new Font(new FontFamily("arial"), 12, FontStyle.Bold);
				}
				return m_styleColHeader;
			}
		}

		
		//VALIDATION
		public event EventHandlerValidationLigne OnValidationLigne;
		
		
		//------------------------------------------------------------------
		void m_dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			try
			{

				m_dataGridView.Rows[e.RowIndex].ErrorText = e.Exception.Message;
				e.Cancel = true;
			}
			catch
			{
			}
			e.ThrowException = false;
			
		}
		
		//AFFICHAGES
		public void DrawIco(DataGridViewCellPaintingEventArgs e)
		{
			if (m_dataView != null && e.RowIndex == -1 && e.ColumnIndex != -1)
			{
				DataColumn col = m_dataView.Table.Columns[e.ColumnIndex];
				foreach(DataColumn colPrimaryKey in m_dataView.Table.PrimaryKey)
					if(col == colPrimaryKey)
					{
						Image img = Properties.Resources.cle;
						e.Graphics.DrawImageUnscaled(img, new Point(e.CellBounds.X + 2, e.CellBounds.Y + (e.CellBounds.Height / 2) - (img.Height / 2)));
						break;
					}
			}
		}

		//-------------------------------------------------
		private int GetDefaultSizeCol(DataGridViewColumn c)
		{
			if (c.ReadOnly)
				return 30;
			else if (c.ValueType == typeof(string))
				return 200;
			else if (c.ValueType == typeof(int) || c.ValueType == typeof(double))
				return 50;
			else if (c.ValueType == typeof(DateTime))
				return 100;
			else if (c.ValueType == typeof(bool))
				return 50;
			else
				return 200;
			//Font f;
			//Font
			//if(c.Name.wi
		}

		//SUPPRESSION LIGNES
		void m_dg_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (!m_dataGridView.ReadOnly && e.Button == MouseButtons.Right && m_dataGridView.SelectedRows.Count > 0)
			{
				List<int> idx = new List<int>();
				foreach(DataGridViewRow r in m_dataGridView.SelectedRows)
					idx.Add(r.Index);

				Point p = m_dataGridView.PointToClient(Control.MousePosition);
				if (idx.Contains(m_dataGridView.HitTest(p.X,p.Y).RowIndex))
				{
					m_ctxMenu.Items.Clear();
					ToolStripMenuItem mnuSupprimer = new ToolStripMenuItem(I.T("Delete|18"));
					mnuSupprimer.Click += new EventHandler(mnuSupprimerLigne_Click);
					m_ctxMenu.Items.Add(mnuSupprimer);
					m_ctxMenu.Show(Control.MousePosition);
				}
			}
		}

		void mnuSupprimerLigne_Click(object sender, EventArgs e)
		{
			if (CFormAlerte.Afficher(I.T("Delete row(s) ?|1178"), EFormAlerteType.Question) == DialogResult.Yes)
			{
				List<int> idx = new List<int>();
				for (int i = m_dataGridView.SelectedRows.Count; i > 0; i--)
					idx.Add(m_dataGridView.SelectedRows[i - 1].Index);

				idx.Sort();
				try
				{
					foreach (int i in idx)
						m_dataGridView.Rows.RemoveAt(i);
				}
				catch
				{ }
			}
		}
		private ContextMenuStrip m_ctxMenu = new ContextMenuStrip();


	}

	public delegate void EventHandlerValidationLigne(bool valide, string messErr);

}