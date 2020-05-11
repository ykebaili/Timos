using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HelpExtender
{
	public partial class CFormSelectControl : Form
	{
		#region :: Propriétés ::
		Control m_controlSel = null;

		Color m_lastBackColor = Color.Green;
		Control m_lastControleClignote = null;
		private int m_nValeurVert = 0;
		private int m_nIncrement = 10;
		#endregion

		#region ++ Constructeurs ++
		public CFormSelectControl()
		{
			InitializeComponent();
		}
		#endregion

		#region ~[ Méthodes ]~
		public static Control GetControl( Control ctrlSelectionne)
		{
			CFormSelectControl form = new CFormSelectControl();
			TreeNode node = form.FillTo(ctrlSelectionne);
			if (ctrlSelectionne.Controls.Count != 0)
			{
				TreeNode nodeBidon = new TreeNode("");
				node.Nodes.Add(nodeBidon);
			}
			form.m_arbre.SelectedNode = node;
			form.m_controlSel = ctrlSelectionne;

			CHelpExtender.ArreterClignotementControl();
			Control ctrl = null;
			if (form.ShowDialog() == DialogResult.OK)
				ctrl = form.m_controlSel;
			CHelpExtender.RepriseClignementControle();

			return ctrl;
		}
		#endregion

		#region ~~ Méthodes ~~
		public TreeNode FillTo(Control ctrlSelectionne)
		{
			if (ctrlSelectionne == null)
				return null;
			TreeNode nodeParent = FillTo(ctrlSelectionne.Parent);
			TreeNode node = new TreeNode(GetTexte(ctrlSelectionne));
			node.Tag = ctrlSelectionne;
			if (nodeParent == null)
				m_arbre.Nodes.Add(node);
			else
			{
				nodeParent.Nodes.Add(node);
				nodeParent.Expand();
			}
			return node;
		}

		private string GetTexte(Control ctrl)
		{
			string strText = "";
			try
			{
				strText = ctrl.Name+" " + " (" + ctrl.GetType() + ")";
			}
			catch
			{
				strText = ctrl.GetType().ToString();
			}
			return strText;
		}

		private void StopClignote()
		{
			m_timer.Stop();
			try
			{
				if (m_lastControleClignote != null)
					m_lastControleClignote.BackColor = m_lastBackColor;
			}
			catch
			{ }
		}
		private void Clignote(Control ctrl)
		{
			StopClignote();
			m_lastBackColor = ctrl.BackColor;
			m_lastControleClignote = ctrl;
			m_nValeurVert = ctrl.BackColor.G;
			m_timer.Start();
		}
		
		private void CreateNode(TreeNode nodeParent, Control ctrl)
		{
			TreeNode node = new TreeNode(GetTexte(ctrl));
			node.Tag = ctrl;
			nodeParent.Nodes.Add(node);
			if (ctrl.Controls.Count > 0)
			{
				TreeNode nodeBidon = new TreeNode();
				node.Nodes.Add(nodeBidon);
			}
		}
		#endregion

		#region ** Evenements **

		private void m_arbre_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Tag == null)
			{
				TreeNode nodeParent = e.Node;
				nodeParent.Nodes.Clear();
				Control ctrl = (Control)nodeParent.Tag;
				foreach (Control fils in ctrl.Controls)
				{
					CreateNode(nodeParent, fils);
				}
			}

		}
		private void m_arbre_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Tag is Control)
			{
				Control ctrl = (Control)e.Node.Tag;
				Clignote(ctrl);
			}
		}

		private void m_timer_Tick(object sender, EventArgs e)
		{
			try
			{
				if (m_lastControleClignote != null)
				{
					m_nValeurVert += m_nIncrement;
					if ( m_nValeurVert < 0 )
					{
						m_nValeurVert = 0;
						m_nIncrement = 10;
					}
					if ( m_nValeurVert > 255 )
					{
						m_nValeurVert = 255;
						m_nIncrement = -10;
					}
					Color c = Color.FromArgb(m_lastBackColor.R, m_nValeurVert, m_lastBackColor.B);
					m_lastControleClignote.BackColor = c;
				}
			}
			catch
			{
			}
		}

		private void CFormSelectControl_FormClosing(object sender, FormClosingEventArgs e)
		{
			StopClignote();
		}

		private void m_btnOk_Click(object sender, EventArgs e)
		{
			if (m_arbre.SelectedNode != null)
			{
				m_controlSel = (Control)m_arbre.SelectedNode.Tag;
				DialogResult = DialogResult.OK;
				Close();
			}
		}
		private void m_btnAnnuler_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		#endregion

		#region >> Assesseurs <<
		public CHelpData HelpSelectionne
		{
			get
			{
				return CHelpData.GetHelp(m_controlSel,"");
			}
		}
		#endregion


	}
}