using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HelpExtender
{
	public partial class CFormMenu : Form
	{
		#region ++ Constructeurs ++
		public CFormMenu()
		{
			InitializeComponent();
		}
		#endregion
		#region ~~ Méthodes ~~
		public void Initialiser(CMenuItem menuRoot, bool autoriserEdition)
		{
			m_ctrl_editMenu.ChangementTaille += new EventHandler(ctrl_editMenu_ChangementTaille);
			m_ctrl_editMenu.Initialiser(menuRoot, autoriserEdition);
		}


		#endregion

		#region ** Evenements **
		private void CFormMenu_FormClosing(object sender, FormClosingEventArgs e)
		{
			m_ctrl_editMenu.ValideModifs();
			CHelpData.SourceAide.SaveMenu();
		}
		void ctrl_editMenu_ChangementTaille(object sender, EventArgs e)
		{
			Width = m_ctrl_editMenu.Width;
		}
		#endregion

		private void m_btnFermer_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void m_btnExporter_Click(object sender, EventArgs e)
		{
			if ( m_ctrl_editMenu.Menu == null )
				return;
			SaveFileDialog dlg = new SaveFileDialog();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				StreamWriter writer = new StreamWriter(dlg.FileName, false);
				WriteMenu(m_ctrl_editMenu.Menu, writer, "");
				writer.Close();
			}
		}

		private void WriteMenu ( CMenuItem menu, StreamWriter writer, string strPrefixe )
		{
			writer.WriteLine ( strPrefixe+menu.Nom );
			foreach ( CMenuItem sousMenu in menu.Items )
				WriteMenu ( sousMenu, writer, strPrefixe+"\t");
		}
	}
}