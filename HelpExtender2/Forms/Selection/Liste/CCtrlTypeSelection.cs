using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HelpExtender
{
	public partial class CCtrlTypeSelection : UserControl
	{
		#region ++ Constructeurs ++
		public CCtrlTypeSelection()
		{
			InitializeComponent();
			Initialiser();
		}
		#endregion

		#region ~~ Méthodes ~~
		public void Initialiser()
		{
			_initialise = false;
			cmb_typeselec.Items.Clear();
			string[] types = Enum.GetNames(typeof(ETypeSelection));
			foreach (string s in types)
				cmb_typeselec.Items.Add(s);

			if (cmb_typeselec.Items.Count == 0)
				cmb_typeselec.Enabled = false;
			else
			{
				cmb_typeselec.Enabled = true;
				cmb_typeselec.SelectedIndex = 0;
			}
			_initialise = true;
		}
		#endregion
		#region :: Propriete ::
		private bool _initialise;
		#endregion
		#region >> Assesseur <<
		public ETypeSelection Liaison
		{
			get
			{
				if (cmb_typeselec.SelectedItem != null)
					return (ETypeSelection)Enum.Parse(typeof(ETypeSelection), cmb_typeselec.SelectedItem.ToString());
				else
					return ETypeSelection.Independants;
			}
			set
			{
				cmb_typeselec.SelectedItem = value.ToString();
			}
		}
		#endregion

		#region ** Evenements **
		public event EventHandler ChangementTypeLiaison;
		private void cmb_typeselec_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (_initialise && ChangementTypeLiaison != null)
				ChangementTypeLiaison(sender, e);
		}
		#endregion
	}

	public enum ETypeSelection
	{
		Independants,
		Controles,
		Menu,
		SelonTitre,
	}
}
