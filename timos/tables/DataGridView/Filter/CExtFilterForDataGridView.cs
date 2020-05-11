using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using sc2i.data;
using sc2i.common;
using sc2i.win32.common;

namespace timos.tables
{
	
	public class CExtFilterForDataGridView : Component
	{
		public CExtFilterForDataGridView()
		{

		}

		private DataGridView m_dgv;
		private DataView m_dv;
		private DataTable m_dt;
		private DataGridViewColumn m_colClic;

		public DataGridView DataGridFiltre
		{
			get
			{
				return m_dgv;
			}
			set
			{
				m_dgv = value;
				if (m_dgv != null)
					m_dgv.DataSourceChanged += new EventHandler(m_dgv_DataSourceChanged);
				
			}
		}

		void m_dgv_DataSourceChanged(object sender, EventArgs e)
		{
			if (InitialiserSource())
				m_dgv.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(m_dg_ColumnHeaderMouseClick);
		}

		public void DrawIco(DataGridViewCellPaintingEventArgs e)
		{
			if (e.RowIndex == -1 && e.ColumnIndex != -1 && ColonneFiltree(m_dgv.Columns[e.ColumnIndex]))
			{
				Image img = Properties.Resources.filtre;
				e.Graphics.DrawImageUnscaled(img, new Point(e.CellBounds.X + e.CellBounds.Width - img.Width - 2, e.CellBounds.Y + (e.CellBounds.Height / 2) - (img.Height / 2)));
			}
		}
		
		private bool InitialiserSource()
		{
			m_stylesColHead = new Hashtable();
			m_dv = null;
			if (m_dgv != null && m_dgv.DataSource != null)
			{
				if (m_dgv.DataSource.GetType() == typeof(DataTable))
					m_dt = ((DataTable)m_dgv.DataSource);
				else if (m_dgv.DataSource.GetType() == typeof(DataView))
					m_dt = ((DataView)m_dgv.DataSource).Table;
				else
					return false;

				m_dv = m_dt.DefaultView;
				m_dgv.DataSource = m_dv;
				return true;
			}
			return false;
		}



		//A faire à l'occasion
		private List<ToolStripMenuItem> GetDistinctOnColumn(DataGridViewColumn col)
		{
			List<ToolStripMenuItem> itms = new List<ToolStripMenuItem>();
			return itms;
		}

		private Hashtable m_stylesColHead;
		private DataGridViewCellStyle m_styleFiltre;
		private DataGridViewCellStyle GetStyleFiltre()
		{
			if (m_styleFiltre == null)
			{
				m_styleFiltre = new DataGridViewCellStyle();
				m_styleFiltre.BackColor = Color.Violet;
				m_styleFiltre.Font = new Font(new FontFamily("Arial"), 12, FontStyle.Italic | FontStyle.Bold);
				m_styleFiltre.ForeColor = Color.Yellow;
			}
			return m_styleFiltre;
		}
		private DataGridViewCellStyle GetOldStyle(DataGridViewColumn col)
		{
			return (DataGridViewCellStyle) m_stylesColHead[col];
		}
		private void SetOldStyle(DataGridViewColumn col)
		{
			if(!m_stylesColHead.Contains(col))
				m_stylesColHead.Add(col, col.HeaderCell.Style);
		}
		private void ActualiserEnteteColonne(DataGridViewColumn col)
		{
			//if (ColonneFiltree(col))
			//{
			//    SetOldStyle(col);
			//    col.HeaderCell.Style = GetStyleFiltre();
			//}
			//else
			//    col.HeaderCell.Style = GetOldStyle(col);
		}

		private void AfficherMenu(DataGridViewColumn col)
		{
			m_ctxMenu.Items.Clear();

			//Ajout du menu de filtre
			ToolStripMenuItem mnuFiltrer = new ToolStripMenuItem();
			if (ColonneFiltree(col))
			{
				ToolStripMenuItem mnuSupprimer = new ToolStripMenuItem(I.T("Delete filter|1185"));
				mnuSupprimer.Click += new EventHandler(mnuSupprimer_Click);
				m_ctxMenu.Items.Add(mnuSupprimer);
				mnuFiltrer.Text = I.T("Edit filter...|1183");
			}
			else
				mnuFiltrer.Text = I.T("Filter...|1184");

			mnuFiltrer.Click += new EventHandler(mnuFiltrer_Click);
			m_ctxMenu.Items.Add(mnuFiltrer);


			//Ajout des elements possibles
			//List<ToolStripMenuItem> poss = GetDistinctOnColumn(col);
			//if (poss.Count > 0)
			//    ctxMenu.Items.AddRange(poss);

			m_ctxMenu.Show(Control.MousePosition);

		}

	
		private void Filtrer()
		{
			string filtre = "(";
			int cpt = 0;
			foreach (DataGridViewColumn col in m_dgv.Columns)
				if (ColonneFiltree(col))
				{
					if (filtre != "(")
						filtre += "AND (";

					filtre += ((CCDataGridViewColonneFilter)col.Tag).FiltreRow + ")";
					cpt++;
				}

			if (cpt == 0)
				m_dv.RowFilter = null;
			else
			{
				try
				{
					m_dv.RowFilter = filtre;
				}
				catch(Exception e)
				{
					CFormAlerte.Afficher(e.Message, EFormAlerteType.Erreur);
				}
			}
		}


		public static bool ColonneFiltree(DataGridViewColumn col)
		{
			if (col.Tag != null && ((CCDataGridViewColonneFilter)col.Tag) != null)
				return true;

			return false;
		}

		void m_dg_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				m_colClic = m_dgv.Columns[e.ColumnIndex];
				AfficherMenu(m_colClic);
			}
		}


		void mnuFiltrer_Click(object sender, EventArgs e)
		{
			if (m_colClic != null)
			{
				CFormEditColonneFilter.SetFiltre(m_colClic);
				ActualiserEnteteColonne(m_colClic);
				Filtrer();
			}
		}
		void distinct_Click(object sender, EventArgs e)
		{
			if (m_colClic != null)
			{


				Filtrer();
			}
		}
		void mnuSupprimer_Click(object sender, EventArgs e)
		{
			if (m_colClic != null)
			{
				m_colClic.Tag = null;
				ActualiserEnteteColonne(m_colClic);
				Filtrer();
			}
		}

		private ContextMenuStrip m_ctxMenu = new ContextMenuStrip();
		private IContainer components;

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.m_ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			// 
			// ctxMenu
			// 
			this.m_ctxMenu.Name = "ctxMenu";

		}
	}
}
