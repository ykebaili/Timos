using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using sc2i.common;
using sc2i.win32.common;

namespace timos.tables
{
	public partial class CCtrlEditListeColonneFilter : UserControl
	{

		private Type m_typeEles;
		private Hashtable m_indexage;
		private RadioButton m_rbtLast;
		private DataGridViewColumn m_col;
		private bool m_bMultiSelect;
		private bool m_bSelecOnClicControl;
		private List<CDataGridViewColonneFilterComponent> m_elements;
		private bool m_bChangementSelec;

		public bool AjoutPossible
		{
			get
			{
				return m_panBtns.Visible;
			}
			set
			{
				m_panBtns.Visible = value;
			}
		}
		public bool SelectionPossible
		{
			get
			{
				return m_panChks.Visible;
			}
			set
			{
				m_panChks.Visible = value;
			}
		}

		[Browsable(false)]
		public List<CDataGridViewColonneFilterComponent> ElementsSelectionnes
		{
			get
			{
				List<CDataGridViewColonneFilterComponent> lst = new List<CDataGridViewColonneFilterComponent>();
				foreach (Control c in m_panChks.Controls)
				{
					if (c is Panel)
					{
						try
						{
							if (m_bMultiSelect)
							{
								CheckBox chk = (CheckBox)c.Controls[0];
								if (chk.Checked)
									foreach (CDataGridViewColonneFilterComponent ele in m_elements)
										if (ele.Equals((CDataGridViewColonneFilterComponent)m_indexage[chk.Name]))
										{
											lst.Add(ele);
											break;
										}
							}
							else
							{
								RadioButton rbt = (RadioButton)c.Controls[0];
								if (rbt.Checked)
								{
									foreach (CDataGridViewColonneFilterComponent ele in m_elements)
										if (ele.Equals((CDataGridViewColonneFilterComponent)m_indexage[rbt.Name]))
										{
											lst.Add(ele);
											break;
										}
									break;
								}
							}
						}
						catch
						{
						}
					}
				}
				return lst;
			}
			set
			{
				if (m_elements == null)
					return;
				m_bChangementSelec = true;
				foreach (CDataGridViewColonneFilterComponent ele in m_elements)
				{
					if (!m_bMultiSelect)
						((RadioButton)GetControlSelectOf(ele)).Checked = false;
					else
						((CheckBox)GetControlSelectOf(ele)).Checked = false;
				}

				m_bChangementSelec = false;
				foreach (CDataGridViewColonneFilterComponent ele in value)
				{
					if (!m_bMultiSelect)
						((RadioButton)GetControlSelectOf(ele)).Checked = true;
					else
						((CheckBox)GetControlSelectOf(ele)).Checked = true;
				}
			}
		}

		private Control GetControlSelectOf(CDataGridViewColonneFilterComponent ele)
		{
			string idx = GetIndex(ele);
			foreach (Control c in m_panChks.Controls)
				if (c is Panel && c.Name == idx)
					return c.Controls[0];

			return null;
		}
		private Control GetControlSelectOf(string name)
		{
			foreach (Control c in m_panChks.Controls)
				if (c is Panel && c.Name == name)
					return c.Controls[0];
					
			return null;
		}


		public List<CDataGridViewColonneFilterComponent> Elements
		{
			get
			{
				return m_elements;
			}
		}
		public bool SelectionMultiple
		{
			get
			{
				return m_bMultiSelect;
			}
			set
			{
				if (value != m_bMultiSelect)
				{
					m_bMultiSelect = value;
					for (int i = m_panChks.Controls.Count; i > 0; i--)
					{
						Control p = m_panChks.Controls[i - 1];
						if (p is Panel)
						{
							try
							{
								if (m_bMultiSelect)
								{
									CheckBox chk = (CheckBox)p.Controls[0];
									RadioButton rbt = new RadioButton();
									rbt.Name = chk.Name;
									rbt.Checked = chk.Checked;
									p.Controls.Clear();
									p.Controls.Add(rbt);
								}
								else
								{
									RadioButton rbt = (RadioButton)p.Controls[0];
									CheckBox chk = new CheckBox();
									chk.Name = rbt.Name;
									chk.Checked = rbt.Checked;
									p.Controls.Clear();
									p.Controls.Add(chk);
								}
							}
							catch
							{ }
						}
					}
				}
			}
		}
		public bool SelectionAuClicSurControl
		{
			get
			{
				return m_bSelecOnClicControl;
			}
			set
			{
				m_bSelecOnClicControl = value;
			}
		}

		
		public CCtrlEditListeColonneFilter()
		{
			InitializeComponent();
		}

		public void Initialiser(List<CDataGridViewColonneFilterComponent> elements, DataGridViewColumn col, Type typeElements)
		{
			Initialiser(elements, col, typeElements, false);
		}
		public void Initialiser(List<CDataGridViewColonneFilterComponent> elements, DataGridViewColumn col, Type typeElements , bool selectionMultiple)
		{
			m_typeEles = typeElements;
			m_col = col;
			m_indexage = new Hashtable();
			m_bMultiSelect = selectionMultiple;
			m_bChangementSelec = false;
			m_btnSupprimer.Enabled = false;
			DisposeCtrls(m_panChks);
			DisposeCtrls(m_panElements);
			m_elements = new List<CDataGridViewColonneFilterComponent>();
			foreach (CDataGridViewColonneFilterComponent ele in elements)
				AjouterElement(ele);
		}

		private void DisposeCtrls(Panel p)
		{
			for (int i = p.Controls.Count; i > 0; i--)
				p.Controls[i - 1].Dispose();
		}
		public void SelectionnerElement(CDataGridViewColonneFilterComponent ele)
		{
			try
			{
				ChangementListeSelection(GetControlSelectOf(ele), new EventArgs());
			}
			catch
			{
			}
		}
		public void AjouterElement(CDataGridViewColonneFilterComponent ele)
		{
			m_elements.Add(ele);

			Control ctrl = null;
			if (m_typeEles == typeof(CDataGridViewColonneFilterSituation))
			{
				CCtrlEditColonneFilterSituation edit = new CCtrlEditColonneFilterSituation();
				edit.Initialiser((CDataGridViewColonneFilterSituation)ele);
				ctrl = edit;
			}
			else if (m_typeEles == typeof(CDataGridViewColonneFilterTest))
			{
				CCtrlEditColonneFilterTest edit = new CCtrlEditColonneFilterTest();
				edit.Initialiser((CDataGridViewColonneFilterTest)ele);
				ctrl = edit;
			}
			else
			{
				CFormAlerte.Afficher(I.T( "Impossible to identify the filter component|1179"), EFormAlerteType.Erreur);
				return;
			}
			Indexer(ele);
			ctrl.Name = GetIndex(ele);
			ctrl.Dock = DockStyle.Top;

			m_panElements.Controls.Add(ctrl);
			ctrl.BringToFront();

			//Ajout de la chkbox
			Panel p = new Panel();
			p.Name = ctrl.Name;
			p.Height = ctrl.Height;
			p.Width = 60;
			m_panChks.Controls.Add(p);
			p.Dock = DockStyle.Top;
			p.BringToFront();

			if (m_bMultiSelect)
			{
				CheckBox chk = new CheckBox();
				chk.Name = ctrl.Name;
				chk.Checked = false;
				chk.CheckedChanged += new EventHandler(ChangementListeSelection);
				p.Controls.Add(chk);
			}
			else
			{
				RadioButton rbt = new RadioButton();
				rbt.Name = ctrl.Name;
				rbt.Checked = false;
				rbt.CheckedChanged += new EventHandler(ChangementListeSelection);
				if(m_bSelecOnClicControl)
					ctrl.Click += new EventHandler(ChangementListeSelection);
				p.Controls.Add(rbt);
			}

			if (AjoutElement != null)
				AjoutElement(ele, new EventArgs());
		}

		private void Indexer(CDataGridViewColonneFilterComponent element)
		{
			m_indexage.Add(Guid.NewGuid().ToString(), element);
		}
		private string GetIndex(CDataGridViewColonneFilterComponent element)
		{
			foreach (object o in m_indexage.Keys)
				if (m_indexage[o].Equals(element))
					return o.ToString();
			return "";
		}
		private bool Remove(string idx)
		{
			m_elements.Remove((CDataGridViewColonneFilterComponent)m_indexage[idx]);
			return true;
		}

		public void Valider()
		{
			for (int i = m_elements.Count; i > 0; i--)
				if (!m_elements[i - 1].Valider(true))
					m_elements.RemoveAt(i - 1);
		}
		private bool DeleteEditeur(string id)
		{
			for (int i = m_panElements.Controls.Count; i > 0; i--)
			{
				Control c = m_panElements.Controls[i - 1];
				if (c.Name == id)
				{
					m_panElements.Controls[i - 1].Dispose();
					//m_panElements.Controls.RemoveAt(i - 1);
					return true;
				}
			}

			return false;
		}





		public event EventHandler AjoutElement;
		public event EventHandler ChangementSelection;
		public event EventHandlerCtrlEditListeColonneFilter SuppressionElement;
		void ChangementListeSelection(object sender, EventArgs e)
		{
			if (!m_bChangementSelec)
			{
				if (!m_bMultiSelect)
				{
					m_bChangementSelec = true;
					RadioButton rbt = null;
					if (sender is RadioButton)
						rbt = (RadioButton)sender;
					else
						rbt = (RadioButton)GetControlSelectOf(((Control)sender).Name);
					rbt.Checked = true;
					if (m_rbtLast != null && !m_rbtLast.Equals(rbt))
						m_rbtLast.Checked = false;

					m_rbtLast = rbt;
					m_bChangementSelec = false;
				}

				if (ChangementSelection != null)
					ChangementSelection(sender, e);

				if (ElementsSelectionnes.Count > 0)
					m_btnSupprimer.Enabled = true;
				else
					m_btnSupprimer.Enabled = false;
			}
		}
		private void m_btnSupprimer_Click(object sender, EventArgs e)
		{
			if (CFormAlerte.Afficher(I.T("Delete this element ?|1180"),EFormAlerteType.Question) == DialogResult.No)
				return;

			try
			{
				for (int i = m_panChks.Controls.Count; i > 0; i--)
				{
					Control c = m_panChks.Controls[i - 1];
					if (c is Panel && ((m_bMultiSelect && ((CheckBox)c.Controls[0]).Checked || !m_bMultiSelect && ((RadioButton)c.Controls[0]).Checked)))
					{
						CDataGridViewColonneFilterComponent ele = (CDataGridViewColonneFilterComponent)m_indexage[c.Name];
						if (SuppressionElement != null)
							SuppressionElement(ele);

						if (DeleteEditeur(c.Name) && Remove(c.Name))
						{
							m_panChks.Controls[i - 1].Dispose();
							//m_panChks.Controls.RemoveAt(i - 1);
						}
						else
							CFormAlerte.Afficher(I.T("Error while deleting the element|1181"), EFormAlerteType.Erreur);

						if (!m_bMultiSelect)
							break;
					}
				}
				m_btnSupprimer.Enabled = false;
			}
			catch
			{
				CFormAlerte.Afficher(I.T("General error while deleting the Element|1182"), EFormAlerteType.Erreur);
			}
		}
			
		private void m_btnAjouter_Click(object sender, EventArgs e)
		{
			CDataGridViewColonneFilterComponent element;
			if (m_typeEles == typeof(CDataGridViewColonneFilterSituation))
				element = new CDataGridViewColonneFilterSituation(m_col);
			else if (m_typeEles == typeof(CDataGridViewColonneFilterTest))
				element = new CDataGridViewColonneFilterTest(m_col);
			else
			{
				CFormAlerte.Afficher(I.T( "Impossible to identify the filter component|1179"), EFormAlerteType.Erreur);
				return;
			}
			 
			AjouterElement(element);
		}
	}

	public delegate void EventHandlerCtrlEditListeColonneFilter(CDataGridViewColonneFilterComponent ele);

	
}
