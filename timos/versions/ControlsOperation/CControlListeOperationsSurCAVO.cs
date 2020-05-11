using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using timos.data.version;

using sc2i.common;
using sc2i.data.dynamic;
using sc2i.data;
using sc2i.expression;

namespace timos.version
{
	public partial class CControlListeOperationsSurCAVO : UserControl
	{
		public CControlListeOperationsSurCAVO()
		{
			InitializeComponent();
			DoubleBuffered = true;
		}

		private CAuditVersionObjet m_cavo;
		public void Init(CAuditVersionObjet cavo)
		{
			m_cavo = cavo;
			if (m_cavo == null)
			{
				m_dgvViewer.DataSource = null;
				return;
			}
			InitMappageControlVisualisation();
			InitFiltrageChamps();
			AfficherOperations();
		}

		private void InitMappageControlVisualisation()
		{
			if (m_lstTypeOperations.Items.Count == 0)
			{
				m_dgvViewer.AjouterMappage(typeof(IChampPourVersion), typeof(CControlIChampPourVersion));
				m_dgvViewer.AjouterMappage(typeof(CTypeOperationSurObjet), typeof(CControlTypeOperationAuditVersion));
				m_dgvViewer.AjouterMappage(typeof(CValeurCAVOO), typeof(CControlValeurCAVOO));
				m_dgvViewer.AjouterMappage(typeof(CValeurCAVOOEntite), typeof(CControlOpertionCAVOOEntite));
				m_dgvViewer.AjouterMappage(typeof(string), typeof(CControlVivantString));
				m_dgvViewer.AjouterMappage(typeof(Type), typeof(CControlVivantTypeConvivial));

			}
		}

		private void InitTypesOperations()
		{
			if (m_lstTypeOperations.Items.Count == 0)
			{
				CTypeOperationSurObjet.TypeOperation[] typesPoss = CTypeOperationSurObjet.ValeursEnumPossibles;
				foreach (CTypeOperationSurObjet.TypeOperation top in typesPoss)
				{
					if (top == CTypeOperationSurObjet.TypeOperation.Aucune)
						continue;
					ListViewItem itm = new ListViewItem(new CTypeOperationSurObjet(top).Libelle);
					itm.Tag = top;
					m_lstTypeOperations.Items.Add(itm);
					itm.Checked = true;
				}
			}
		}
		public void InitFiltrageChamps()
		{
			m_bCheckWithoutEvent = true;
			InitTypesOperations();
			List<string> lstChamps = new List<string>();
			m_lstChamps.Items.Clear();
			foreach (CAuditVersionObjetOperation cavoo in m_cavo.Datas)
			{
				if (cavoo.Champ == null)
					continue;
				string strNomChamp = cavoo.Champ.NomConvivial;
				if (!lstChamps.Contains(strNomChamp))
				{
					lstChamps.Add(cavoo.Champ.NomConvivial);
					ListViewItem itm = new ListViewItem(strNomChamp);
					string strTypeChamp = "";
					if (cavoo.Champ.GetType() == typeof(CChampCustomPourVersion))
					{
						strTypeChamp = I.T("Custom Field|30215");
					}
					else
						strTypeChamp = I.T("Field|85");


					Type tpChamp = CActivatorSurChaine.GetType(cavoo.TypeValeurString);
					if (tpChamp == typeof(CDetailOperationSurObjet))
					{
					}

					itm.SubItems.Add(strTypeChamp);

					itm.SubItems.Add(DynamicClassAttribute.GetNomConvivial(tpChamp));
					m_lstChamps.Items.Add(itm);
					itm.Checked = true;
				}
			}
			m_bCheckWithoutEvent = false;
		}
		private bool m_bCheckWithoutEvent = false;
		private void AfficherOperations()
		{
			List<CAuditVersionObjetOperation> lstOperations = new List<CAuditVersionObjetOperation>();
			if (!m_cavo.TypeElement.IsAssignableFrom(typeof(IObjetABlobAVersionPartielle)))
				foreach (CAuditVersionObjetOperation op in m_cavo.Datas)
					lstOperations.Add(op);
			else
			{
			}
			ConstruireDataTable(lstOperations);
		}

		private interface IValeurCAVOO
		{
		}
		public class CValeurCAVOO : IValeurCAVOO
		{
			public override string ToString()
			{
				if (CAVOO == null)
					return base.ToString();
				if (Valeur == null)
					return "NULL";
				return Valeur.ToString();
			}
			public CValeurCAVOO(CAuditVersionObjetOperation cavoo, EOrigineVersion origine)
			{
				m_valeur = origine == EOrigineVersion.Cible ? cavoo.ValeurCible : cavoo.ValeurSource;
				m_origine = origine;
				m_cavoo = cavoo;
			}

			private CAuditVersionObjetOperation m_cavoo;
			public CAuditVersionObjetOperation CAVOO
			{
				get
				{
					return m_cavoo;
				}
			}

			private object m_valeur;
			public object Valeur
			{
				get
				{
					return m_valeur;
				}
			}
			private EOrigineVersion m_origine;
			public EOrigineVersion Origine
			{
				get
				{
					return m_origine;
				}
			}
		}
		public class CValeurCAVOOEntite : IValeurCAVOO
		{
			private CObjetDonneeAIdNumerique m_entite;
			public CObjetDonneeAIdNumerique Entite
			{
				get
				{
					return m_entite;
				}
			}


			public override string ToString()
			{
				return DescriptionEntite;
			}
			public CValeurCAVOOEntite(string strDescriptionEntite, int nIdEntite, Type tpEntite, CObjetDonneeAIdNumerique entite)
			{
				m_entite = entite;
				m_nId = nIdEntite;
				m_tpEntite = tpEntite;
				m_strDescription = strDescriptionEntite;
			}
			public bool ElementAccessible
			{
				get
				{
					return m_entite != null;
				}
			}
			private Type m_tpEntite;
			public Type TypeEntite
			{
				get
				{
					return m_tpEntite;
				}
			}

			private string m_strDescription;
			public string DescriptionEntite
			{
				get
				{
					return m_strDescription;
				}
			}

			private int m_nId;
			public int IdEntite
			{
				get
				{
					return m_nId;
				}
			}
		}

		DataTable m_dt;
		private void ConstruireDataTable(List<CAuditVersionObjetOperation> lstOperations)
		{
			m_dt = new DataTable();
			m_dt.Columns.Add("Type opération",typeof(CTypeOperationSurObjet));
			m_dt.Columns.Add("Champ", typeof(IChampPourVersion));
			m_dt.Columns.Add("Type donnée", typeof(Type));
			m_dt.Columns.Add("Valeur Source", typeof(IValeurCAVOO));
			m_dt.Columns.Add("Valeur Cible", typeof(IValeurCAVOO));

			foreach (CAuditVersionObjetOperation cavoo in lstOperations)
			{
				DataRow dr = m_dt.NewRow();
				dr[m_dt.Columns[0]] = cavoo.TypeOperation;
				if (cavoo.Champ != null)
				{
					dr[m_dt.Columns[1]] = cavoo.Champ;
					dr[m_dt.Columns[2]] = CActivatorSurChaine.GetType(cavoo.TypeValeurString);
					dr[m_dt.Columns[3]] = new CValeurCAVOO(cavoo, EOrigineVersion.Source);
					dr[m_dt.Columns[4]] = new CValeurCAVOO(cavoo, EOrigineVersion.Cible);
				}
				else
				{
					string strDescrip = cavoo.VersionObjet.Description;
					dr[m_dt.Columns[2]] = cavoo.TypeEntite;
					if (CUtilAChampID.Contexte == null)
						CUtilAChampID.Contexte = cavoo.ContexteDonnee;

					int nColonne = -1;
					EOrigineVersion origine = EOrigineVersion.Cible;
					if (cavoo.TypeOperation.Code == CTypeOperationSurObjet.TypeOperation.Suppression)
					{
						origine = EOrigineVersion.Source;
						nColonne = 3;
					}
					else
					{
						origine = EOrigineVersion.Cible;
						nColonne = 4;
					}

					if (origine == EOrigineVersion.Source && cavoo.ValeurSource != null
						|| origine == EOrigineVersion.Cible && cavoo.ValeurCible != null)
					{
						dr[m_dt.Columns[nColonne]] = new CValeurCAVOO(cavoo, origine);
					}
					else
					{
						int nIdEntite = cavoo.VersionObjet.IdObjetCible.HasValue ? cavoo.VersionObjet.IdObjetCible.Value : cavoo.VersionObjet.IdObjetSource.Value;
						Type tpEntite = cavoo.VersionObjet.TypeElement;
						CFiltreData filtre = new CFiltreData(CUtilAChampID.GetChampID(tpEntite) + " =@1", nIdEntite);
						CListeObjetsDonnees lstObj = new CListeObjetsDonnees(cavoo.ContexteDonnee, tpEntite, filtre);
						CObjetDonneeAIdNumerique obj = null;
						if (lstObj.Count == 1)
							obj = (CObjetDonneeAIdNumerique)lstObj[0];
						dr[m_dt.Columns[nColonne]] = new CValeurCAVOOEntite(strDescrip, nIdEntite, cavoo.TypeEntite, obj);
					}
				}
				
				m_dt.Rows.Add(dr);
				m_dt.Rows[m_dt.Rows.Count - 1].AcceptChanges();

			}

			m_dgvViewer.LectureSeule = false;
			Bind();

		}

		//FILTRE
		private void Bind()
		{
			string strFiltre = RowFilter;
			if (strFiltre != null && strFiltre != "")
				m_dgvViewer.DataSource = m_dt;// new DataView(m_dt, strFiltre, "", DataViewRowState.Unchanged);
			if (m_dgvViewer.Colonnes.Count == 5)
			{
				m_dgvViewer.ModeLargeurDesColonnes = DataGridViewAutoSizeColumnsMode.Fill;
				m_dgvViewer.EnteteLigneVisible = true;
				m_dgvViewer.LargeurEnteteLigne = 10;
				m_dgvViewer.Colonnes[0].Width = 100;
				m_dgvViewer.Colonnes[1].Width = 100;
				m_dgvViewer.Colonnes[2].Width = 100;
			}

		}
		private string RowFilter
		{
			get
			{
				string strFiltre = "";
				if (m_dt == null || m_dt.Columns.Count < 1)
					return strFiltre;
				string strFiltreChamp = "";
				string strFiltreTypeOp = "";


				strFiltreChamp = "([" + m_dt.Columns[1].ColumnName + "] is null";
				if (m_lstChamps.CheckedItems.Count > 0)
				{
					strFiltreChamp += " OR ";
					foreach (ListViewItem itm in m_lstChamps.CheckedItems)
						strFiltreChamp += "[" + m_dt.Columns[1].ColumnName + "] = '" + itm.Text + "' OR ";
					strFiltreChamp = strFiltreChamp.Substring(0, strFiltreChamp.Length - 3);
				}
				strFiltreChamp += ")";

				strFiltreTypeOp = "(";
				foreach (ListViewItem itm in m_lstTypeOperations.Items)
					if(!itm.Checked)
						strFiltreTypeOp += "[" + m_dt.Columns[0].ColumnName + "] <> '" + itm.Text + "' AND ";
				if (strFiltreTypeOp.Length > 1)
				{
					strFiltreTypeOp = strFiltreTypeOp.Substring(0, strFiltreTypeOp.Length - 4);
					strFiltreTypeOp += ")";
				}
				else
					strFiltreTypeOp = "";

				strFiltre = strFiltreChamp;
				if (strFiltreTypeOp != "")
					strFiltre = strFiltre != "" ? strFiltre + " AND " + strFiltreTypeOp : strFiltreTypeOp;
				return strFiltre;
			}
		}
		private void m_lstChamps_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			if (!m_bCheckWithoutEvent)
				Bind();
		}

	
		//AFFICHAGE PANEL FILTRE
		private int m_nOldHeightPanelChamp;
		private void m_btnFiltresChamp_Click(object sender, EventArgs e)
		{
			if (splitContainer1.SplitterDistance < 50)
			{
				splitContainer1.SplitterDistance = m_nOldHeightPanelChamp;
			}
			else
			{
				
				m_nOldHeightPanelChamp = splitContainer1.SplitterDistance;
				splitContainer1.SplitterDistance = 0;
			}
			m_lstChamps.Visible = !(splitContainer1.SplitterDistance < 50);
			m_lstTypeOperations.Visible = m_lstChamps.Visible;
		}

		private Type m_dgvViewer_InitialisationCellule(CDataGridViewCellAControleVivant cell)
		{
			switch (cell.ColumnIndex)
			{
				case 0:	return typeof(CTypeOperationSurObjet);
				case 1:	return typeof(IChampPourVersion);
				case 2: return typeof(Type);
				case 3:
				case 4:
					if(m_dt.Rows[cell.RowIndex][cell.ColumnIndex] == DBNull.Value || 
						m_dt.Rows[cell.RowIndex][cell.ColumnIndex] == null)
						return typeof(CValeurCAVOO);
					return m_dt.Rows[cell.RowIndex][cell.ColumnIndex].GetType();
				default:
					break;
			}
			return null;
		}


	}

	
}
