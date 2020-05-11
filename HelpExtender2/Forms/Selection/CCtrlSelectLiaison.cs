using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HelpExtender
{
	public partial class CCtrlSelectLiaison : UserControl
	{
		#region ++ Constructeur ++
		public CCtrlSelectLiaison()
		{
			InitializeComponent();
			Initialiser();
		}
		#endregion

		#region ~~ Méthodes ~~
		public void Initialiser()
		{
			_mbInitialise = false;
			cmb_typeliaison.Items.Clear();
			string[] types = Enum.GetNames(typeof(ETypeLiaisonAide));
			foreach (string s in types)
				cmb_typeliaison.Items.Add(s);

			if (cmb_typeliaison.Items.Count == 0)
				cmb_typeliaison.Enabled = false;
			else
			{
				cmb_typeliaison.Enabled = true;
				cmb_typeliaison.SelectedIndex = 0;
			}
			_mbInitialise = true;
		}
		#endregion
		#region :: Propriete ::
		private bool _mbInitialise;
		#endregion
		#region >> Assesseur <<
		public ETypeLiaisonAide Liaison
		{
			get
			{
				if (cmb_typeliaison.SelectedItem != null)
					return (ETypeLiaisonAide)Enum.Parse(typeof(ETypeLiaisonAide), cmb_typeliaison.SelectedItem.ToString());
				else
					return ETypeLiaisonAide.Aucune;
			}
			set
			{
				cmb_typeliaison.SelectedItem = value.ToString();
			}
		}
		#endregion

		#region ** Evenements **
		public event EventHandler ChangementTypeLiaison;
		private void cmb_typeliaison_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (_mbInitialise && ChangementTypeLiaison != null)
				ChangementTypeLiaison(sender, e);
		}
		#endregion

		

		
	}
}
