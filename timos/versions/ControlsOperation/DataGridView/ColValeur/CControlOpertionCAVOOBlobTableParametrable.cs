using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using sc2i.data;

using timos.data;
using timos.data.version;


namespace timos.version
{
	public partial class CControlOpertionCAVOOBlobTableParametrable : UserControl
	{
		public CControlOpertionCAVOOBlobTableParametrable()
		{
			InitializeComponent();
		}

		private EOrigineVersion m_origine;
		private string m_strLigneCible;
		private string m_strLigneOrigine;
		private DataTable m_dt;
		public void Init(CControlListeOperationsSurCAVO.CValeurCAVOO valeurCAVOO)
		{

			m_origine = valeurCAVOO.Origine;
			m_strLigneCible = valeurCAVOO.CAVOO.ValChampCibleString;
			m_strLigneOrigine = valeurCAVOO.CAVOO.ValChampSourceString;
			byte[] byteOfTb = null;

			if (valeurCAVOO.CAVOO.ValChampCibleBlob.Donnees != null && 
				valeurCAVOO.CAVOO.ValChampCibleBlob.Donnees.Length > 0)
				byteOfTb = valeurCAVOO.CAVOO.ValChampCibleBlob.Donnees;
			else
				byteOfTb = valeurCAVOO.CAVOO.ValChampSourceBlob.Donnees;

			m_dt = CUtilADataTable.UnserializeDataTable(byteOfTb);

			string strLigneConcernee = m_origine == EOrigineVersion.Cible ? m_strLigneCible: m_strLigneOrigine;
			bool bNull = strLigneConcernee == "@NULL";
			if (bNull)
			{
				m_dgv.DataSource = null;
				m_dgv.ContextMenuStrip = null;
				return;
			}
			string[] datas = null;
			if(!bNull)
				datas = strLigneConcernee.Split('|');

			DataRow dr = m_dt.NewRow();
			
			int nCpt = 0;
			foreach (DataColumn dc in m_dt.Columns)
			{
				if (nCpt >= datas.Length)
					break;
				if (dc.ColumnName == "ID")
				{
					dr[dc] = 0;
					continue;
				}
				if (!bNull)
				{
					if (datas[nCpt] == "@NULL")
						dr[dc] = DBNull.Value;
					else
					{
						if (dc.DataType == typeof(DateTime))
							dr[dc] = (DateTime)CUtilTexte.FromUniversalString((string)datas[nCpt], typeof(DateTime));
						else if (dc.DataType == typeof(int))
							dr[dc] = (int)CUtilTexte.FromUniversalString((string)datas[nCpt], typeof(int));
						else if (dc.DataType == typeof(bool))
							dr[dc] = (bool)CUtilTexte.FromUniversalString((string)datas[nCpt], typeof(bool));
						else if (dc.DataType == typeof(double))
							dr[dc] = (double)CUtilTexte.FromUniversalString((string)datas[nCpt], typeof(double));
						else
							dr[dc] = datas[nCpt];
					}
				}
				else
				{
					dc.AllowDBNull = true;
					dr[dc] = DBNull.Value;
				}
				nCpt++;
			}
			m_dt.Rows.Add(dr);
			m_dgv.DataSource = m_dt;
			m_dgv.Columns[0].Visible = false;

			
			m_dgv.CellFormatting += new DataGridViewCellFormattingEventHandler(m_dgv_CellFormatting);

			m_dgv.ColumnWidthChanged += new DataGridViewColumnEventHandler(m_dgv_ColumnWidthChanged);
			m_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			m_dgv.AllowUserToAddRows = false;
			m_dgv.ColumnHeadersVisible = false;
			m_dgv.RowHeadersVisible = true;
			m_dgv.RowHeadersWidth = 10;
			m_dgv.ReadOnly = true;

			ActualiserTextMenu();
			//m_dgv.ColumnHeadersVisible = false;

			//if (diffTable.CreationTable)
			//{
			//}
			//else if (diffTable.ChangementStructureTable)
			//{
			//}
			//else if (diffTable.ChangementClePrimaire)
			//{
			//}
			//else
			//{
			//    //Récupération de la ligne concernée
				
			//}
		}

		void m_dgv_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
		{
			SignalerRedraw();
		}


		private void SignalerRedraw()
		{
			if (Parent != null && Parent.GetType() == typeof(CControlValeurCAVOO))
			{
				CControlValeurCAVOO ctrlValeur = (CControlValeurCAVOO)Parent;
				ctrlValeur.MustBeRedraw = true;
			}
		}

		void m_dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (m_origine == EOrigineVersion.Cible)
			{
				//AJOUT
				if (m_strLigneOrigine == "@NULL")
				{
					e.CellStyle.BackColor = Color.GreenYellow;
					e.CellStyle.SelectionBackColor = Color.GreenYellow;
				}
				//MODIFICATION ?
				else
				{

					string[] dataOriginales = m_strLigneOrigine.Split('|');
					bool bModifie = false;
					string strVal = "";
					if ( e.ColumnIndex-1 < dataOriginales.Length && e.ColumnIndex-1>=0)
						strVal = dataOriginales[e.ColumnIndex - 1];
					if (strVal == "@NULL")
					{
						bModifie = (e.Value != DBNull.Value);
					}
					else
					{
						bModifie = CUtilTexte.ToUniversalString(e.Value) != strVal;
					}

					if (bModifie)
					{
						e.CellStyle.SelectionBackColor = Color.PaleGoldenrod;
						e.CellStyle.BackColor = Color.PaleGoldenrod;
					}
					else
					{
						e.CellStyle.SelectionBackColor = Color.Transparent;
					}
				}
			}
			else
				e.CellStyle.SelectionBackColor = Color.White;

			e.CellStyle.SelectionForeColor = Color.Black;
		}


		private void ActualiserTextMenu()
		{
			if (m_dgv.ColumnHeadersVisible)
				afficherLesEntêtesToolStripMenuItem.Text = I.T("Mask columns|30276");
			else
				afficherLesEntêtesToolStripMenuItem.Text = I.T("Display columns|30277");

		}
		private void afficherLesEntêtesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (m_dgv.DataSource == null)
				return;
			m_dgv.ColumnHeadersVisible = !m_dgv.ColumnHeadersVisible;
			ActualiserTextMenu();
			if (Parent != null && Parent.GetType() == typeof(CControlValeurCAVOO))
			{
				CControlValeurCAVOO ctrlValeur = (CControlValeurCAVOO)Parent;
				ctrlValeur.MustBeRedraw = true;
				if (ctrlValeur.Parent != null && ctrlValeur.Parent.GetType() == typeof(CDataGridViewControleVivant))
				{
					CDataGridViewControleVivant dgvCtrl = (CDataGridViewControleVivant)ctrlValeur.Parent;
					if (m_dgv.ColumnHeadersVisible)
						dgvCtrl.EditingControlDataGridView.CurrentRow.Height += m_dgv.ColumnHeadersHeight + 1;
					else
						dgvCtrl.EditingControlDataGridView.CurrentRow.Height -= m_dgv.ColumnHeadersHeight + 1;
				}

			}
		}
	}
}
