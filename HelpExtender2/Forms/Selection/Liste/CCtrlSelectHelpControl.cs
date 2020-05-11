using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HelpExtender
{
	public partial class CCtrlSelectHelpControl : UserControl
	{
		#region ++ Constructeurs ++
		public CCtrlSelectHelpControl()
		{
			InitializeComponent();
		}
		#endregion

		#region :: Propriétés ::
		private bool m_bModeCreation;
		#endregion

		#region ~~ Méthodes ~~
		/// <summary>
		/// Constructeur d'initialisation totale des branches d'imbrication de control où l'ont peut trouver des 
		/// fichiers d'aide
		/// </summary>
		public void Initialiser(bool modeCreation)
		{
			m_bModeCreation = modeCreation;

			tv_ctrls.Nodes.Clear();
			CHelpData.CtrlPartiel c = new CHelpData.CtrlPartiel ( CHelpExtender.GetLastActiveControl() );

			if ( c != null )
			{
				TreeNode n = GetNode(c);
				IntegrerFils(c, n);
				if (n.ForeColor == Color.Orange)
				{
					for (int i = 0; i < n.Nodes.Count; i++)
					{
						TreeNode ntmp = n.Nodes[i];
						n.Nodes.RemoveAt(i);
						tv_ctrls.Nodes.Add(ntmp);
					}
				}
				else
					tv_ctrls.Nodes.Add(n);
			}
		}


		/// <summary>
		/// Integre les fils au père passé en parametre.
		/// Si le père ne doit pas être intégré la méthode retourne la liste des fils ou sous fils (à intégrer)
		/// </summary>
		/// <param name="ctrl"></param>
		/// <param name="pere"></param>
		/// <returns></returns>
		private void IntegrerFils(CHelpData.CtrlPartiel ctrlPere, TreeNode noeudPere)
		{
			foreach (CHelpData.CtrlPartiel cfils in ctrlPere.Fils)
			{
				TreeNode nfils = GetNode(cfils);
				if (nfils == null)
					continue;

				IntegrerFils(cfils, nfils);

				if (nfils.ForeColor == Color.Orange)
				{
					for (int i = 0; i < nfils.Nodes.Count; i++)
					{
						TreeNode ntmp = nfils.Nodes[i];
						nfils.Nodes.RemoveAt(i);
						noeudPere.Nodes.Add(ntmp);
					}
				}
				else
					noeudPere.Nodes.Add(nfils);

			}
		}
		private TreeNode GetNode(CHelpData.CtrlPartiel ctrl)
		{
			TreeNode noeud = null;
			Control c = CHelpData.GetControl(ctrl);
			if (c == null)
				return noeud;

			if (CHelpData.SourceAide.HasHelp(c, ""))
			{
				
				CHelpData hlp = CHelpData.SourceAide.GetHelp(ctrl,"");
				string titre = "";
				if (hlp.NomCourt.Trim() != "")
					titre = hlp.NomCourt;
				else if (hlp.Titre.Trim() != "")
					titre = hlp.Titre;
				else
					titre = ctrl.Name;

				noeud = new TreeNode(titre);
				noeud.Tag = hlp;
				noeud.ForeColor = Color.Blue;
			}
			else if (m_bModeCreation)
			{
				noeud = new TreeNode(ctrl.Name);
				noeud.Tag = ctrl;
				noeud.ForeColor = Color.Red;
			}
			else
			{ 
				noeud = new TreeNode(ctrl.Name);
				noeud.Tag = ctrl;
				noeud.ForeColor = Color.Orange;
			}
			return noeud;

		}
		
		#endregion

		#region >> Assesseurs <<
		public CHelpData HelpSelectionne
		{
			get
			{
				if (tv_ctrls.SelectedNode != null)
				{
					if (tv_ctrls.SelectedNode.Tag is CHelpData)
						return (CHelpData)tv_ctrls.SelectedNode.Tag;
					else 
						return new CHelpData(CHelpData.GetControl((CHelpData.CtrlPartiel)tv_ctrls.SelectedNode.Tag),"");
				}
				else
					return null;
			}
		}
		#endregion

		#region ** Evenements **
		private void tv_ctrls_AfterSelect(object sender, TreeViewEventArgs e)
		{
			TreeNode n = tv_ctrls.SelectedNode;
			if (n != null)
			{ 
				CHelpData.CtrlPartiel ctrl = null;
				if (n.Tag is CHelpData)
					ctrl = ((CHelpData)n.Tag).Controle;
				else
					ctrl = (CHelpData.CtrlPartiel) n.Tag;
				CHelpExtender.FaireClignoterControl(ctrl);
			}
		}


		public event EventHandler DoubleClickHelp;
		private void tv_ctrls_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (tv_ctrls.SelectedNode != null && DoubleClickHelp != null)
				DoubleClickHelp(sender, e);
		}
		#endregion



	}
}