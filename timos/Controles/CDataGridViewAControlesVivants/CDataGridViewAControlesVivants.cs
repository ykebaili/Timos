using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.common;

namespace timos
{
	public delegate Type FirstCellBuildNeedAType(CDataGridViewCellAControleVivant cell);

	public partial class CDataGridViewAControlesVivants : UserControl
	{


		public event FirstCellBuildNeedAType InitialisationCellule;

		public bool EnteteLigneVisible
		{
			get
			{
				return m_dgv.RowHeadersVisible;
			}
			set
			{
				m_dgv.RowHeadersVisible = value;
			}
		}
		public int LargeurEnteteLigne
		{
			get
			{
				return m_dgv.RowHeadersWidth;
			}
			set
			{
				m_dgv.RowHeadersWidth = value;
			}
		}

		public DataGridViewAutoSizeColumnsMode ModeLargeurDesColonnes
		{
			get
			{
				return m_dgv.AutoSizeColumnsMode;
			}
			set
			{
				m_dgv.AutoSizeColumnsMode = value;
			}
		}
		public DataGridViewColumnHeadersHeightSizeMode ModeHauteurDesColonnes
		{
			get
			{
				return m_dgv.ColumnHeadersHeightSizeMode;
			}
			set
			{
				m_dgv.ColumnHeadersHeightSizeMode = value;
			}
		}
		public DataGridViewRowCollection Lignes
		{
			get
			{
				return m_dgv.Rows;
				
			}
		}
		public DataGridViewColumnCollection Colonnes
		{
			get
			{
				return m_dgv.Columns;
			}
		}

		private bool m_bControlesToujoursVivants;
		public bool ControlesToujoursVivant
		{
			get
			{
				return m_bControlesToujoursVivants;
			}
			set
			{
				m_bControlesToujoursVivants = value;
			}
		}

		public CDataGridViewAControlesVivants()
		{
			InitializeComponent();
			DoubleBuffered = true;
			m_dgv.AllowUserToAddRows = false;
			m_dgv.AutoGenerateColumns = false;
			m_dgv.MultiSelect = false;
			m_dgv.ReadOnly = true;
		}

		public bool LectureSeule
		{
			get
			{
				return m_dgv.ReadOnly;
			}
			set
			{
				m_dgv.ReadOnly = value;
			}
		}
		public Color CouleurGrille
		{
			get
			{
				return m_dgv.GridColor;
			}
			set
			{
				m_dgv.GridColor = value;
			}
		}


		//CREATION DES COLONNES
		private void m_dgv_DataSourceChanged(object sender, EventArgs e)
		{
			if (m_dgv.DataSource == null)
			{
				m_dtSource = null;
				return;
			}
			Type tpSrc = m_dgv.DataSource.GetType();
			if (tpSrc == typeof(DataTable))
			{
				m_dtSource = (DataTable)m_dgv.DataSource;
			}
			else if (tpSrc == typeof(DataView))
			{
				m_dtSource = ((DataView)m_dgv.DataSource).Table;
			}
			else if (tpSrc == typeof(DataSet))
			{
				//A VERIFIER
				m_dtSource = ((DataSet)m_dgv.DataSource).Tables[0];
			}
			else
				throw new Exception(I.T("Unknown data type |30059"));

			ConstruireColonnes();
		}

		private DataTable m_dtSource;
		private void ConstruireColonnes()
		{
			m_dgv.Columns.Clear();
			m_dgv.DataBindings.Clear();
			foreach (DataColumn dc in m_dtSource.Columns)
			{
				DataGridViewColumn column = new DataGridViewColumn(new CDataGridViewCellAControleVivant());
				column.DataPropertyName = dc.ColumnName;
				column.HeaderText = dc.ColumnName;
				m_dgv.Columns.Add(column);
			}
		}


		//LANCEMENT CONTROL
		private void m_dgv_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && !m_dgv.ReadOnly)
			{
				m_dgv[e.ColumnIndex, e.RowIndex].Selected = true;
				try
				{
					m_dgv.BeginEdit(false);
				}
				catch
				{
				}
			}
		}
		//FERMETURE CONTROL
		private void m_dgv_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
		{
			if (!m_dgv.ReadOnly)
				m_dgv.EndEdit();
		}


		//DESSINER CONTROL
		private void m_dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
			{
				CDataGridViewCellAControleVivant cell = (CDataGridViewCellAControleVivant)m_dgv[e.ColumnIndex, e.RowIndex];
				if (cell.TypeDonnee == null)
				{
					//Permet de définir un type spécifique à une cellule
					if (InitialisationCellule != null)
						cell.TypeDonnee = InitialisationCellule(cell); 

					if (cell.TypeDonnee == null)
						cell.TypeDonnee = cell.ValueType;
				}

				CDataGridViewCellAControleVivant.ExceptIfNotTypeMappe(cell, m_factory.TypesSupportes);

				if (!cell.IsInEditMode)
				{
					//Initialise le control au premier dessin
					IControlVivant ctrl = m_factory.GetControlVivant(cell);
					CDataGridViewCellAControleVivant.ExceptIfNotControlVivant(cell);

					if (m_bControlesToujoursVivants)
					{
						bool bReadOnly = m_dgv.ReadOnly;
						m_dgv.ReadOnly = false;
						Bitmap bmp = cell.ImageCellule;
						if (bmp != null)
						{
							Rectangle rectPos = new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);
							if (bmp.Width < (rectPos.Width - 1))
							{
								rectPos.X++;
							}

							e.Graphics.DrawImageUnscaled(bmp, rectPos);
							Brush b = new SolidBrush(m_dgv.GridColor);
							Pen p = new Pen(b);
							//Bordure inferieure
							e.Graphics.DrawLine(p,
								new Point(e.CellBounds.X, e.CellBounds.Y + e.CellBounds.Height - 1),
								new Point(e.CellBounds.X + e.CellBounds.Width, e.CellBounds.Y + e.CellBounds.Height - 1));
							//Bordure Droite
							e.Graphics.DrawLine(p,
								new Point(e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y),
								new Point(e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y + e.CellBounds.Height));

							//BordureGauche
							if (cell.ColumnIndex == 0)
							{
								e.Graphics.DrawLine(p,
								new Point(e.CellBounds.X, e.CellBounds.Y),
								new Point(e.CellBounds.X, e.CellBounds.Y + e.CellBounds.Height));
							}
							p.Dispose();
							b.Dispose();
							e.Handled = true;
						}
						m_dgv.ReadOnly = bReadOnly;
					}
				}
			}
		}

		private CFactoryAControleVivant m_factory = new CFactoryAControleVivant();
		public CFactoryAControleVivant FactoryControlVivant
		{
			get
			{
				return m_factory;
			}
			set
			{
				m_factory = value;
			}
		}

		public object DataSource
		{
			get
			{
				if (m_dgv != null && m_dgv.DataSource != null)
				{
					Type tpSrc = m_dgv.DataSource.GetType();

					if(tpSrc == typeof(DataTable))
						return (DataTable)m_dgv.DataSource;
					else if(tpSrc == typeof(DataView))
						return (DataView)m_dgv.DataSource;
				}

				return null;
			}
			set
			{
				if (m_dgv != null)
					m_dgv.DataSource = value;
			}
		}

		private void m_dgv_MouseLeave(object sender, EventArgs e)
		{
			if (!m_dgv.ReadOnly)
				m_dgv.EndEdit();
		}

		public bool AjouterMappage(Type typeDonnee, Type typeIControlVivant)
		{
			if (m_factory == null)
				m_factory = new CFactoryAControleVivant();
			return m_factory.AjouterMappage(typeDonnee, typeIControlVivant);
		}
		public bool RetirerMappager(Type typeDonnee)
		{
			return m_factory.RetirerMappage(typeDonnee);
		}

		//J'ai fait une classe pour que plus tard on puisse faire un editeur
		//personnalisé pour éditer le mappage directement dans le designer
		public class CFactoryAControleVivant
		{
			public List<Type> TypesSupportes
			{
				get
				{
					return new List<Type>(m_mappageColonneControle.Keys);
				}
			}
			public bool AjouterMappage(Type typeDonnee, Type typeIControlVivant)
			{
				if (typeDonnee == null || typeIControlVivant == null)
					return false;
				Type tpIControlVivant = typeof(IControlVivant);
				if (!tpIControlVivant.IsAssignableFrom(typeIControlVivant))
					return false;
				if (m_mappageColonneControle == null)
					m_mappageColonneControle = new Dictionary<Type, Type>();
				m_mappageColonneControle.Add(typeDonnee, typeIControlVivant);
				return true;
			}
			public bool RetirerMappage(Type typeDonnee)
			{
				return m_mappageColonneControle.Remove(typeDonnee);
			}
			private Dictionary<Type, Type> m_mappageColonneControle;

			public IControlVivant GetControlVivant(CDataGridViewCellAControleVivant cell)
			{
				if (cell.ControlVivant == null)
				{
					//Il faut créer une instance du control et le tager à la cellule
					try
					{
						Type tpCtrl = m_mappageColonneControle[cell.TypeDonnee];

						IControlVivant ctrl = (IControlVivant)Activator.CreateInstance(tpCtrl);
						ctrl.Initialiser(cell.Value);
						cell.ControlVivant = ctrl;
					}
					catch 
					{
						throw new Exception(I.T("Impossible to build the edition  control of the cell : colonne |30060")
							+ cell.ColumnIndex + I.T(" Line|30053") + cell.RowIndex);
					}
				}
				return cell.ControlVivant;
			}
		}

	}
}
