using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using sc2i.common;

namespace HelpExtender
{
	public partial class CFormNomLien : Form
	{
		#region .. Enumeration ..
		internal enum EProprieteSourcePourNom
		{
			Titre,
			ID,
			Nom,
			Designation
		}
		#endregion

		#region ++ Constructeur ++
		public CFormNomLien()
		{
			InitializeComponent();
		}
		#endregion

		#region :: Propriétés ::
		private CHelpData _hlp;
		private bool _initialise;
		#endregion

		#region >> Assesseurs <<
		public string Nom
		{
			get
			{
				return txt_nom.Text;
			}
		}
		#endregion

		#region ~~ Méthodes ~~
		public void Initialiser(CHelpData hlp, string preselec)
		{

			txt_nom.Text = preselec;
			_hlp = hlp;
			_initialise = false;
			string[] props = Enum.GetNames(typeof(EProprieteSourcePourNom));
			foreach (string prop in props)
				cmb_prop.Items.Add(prop);

			if (preselec == "")
			{
				rbt_perso.Checked = false;
				txt_nom.Enabled = false;
				cmb_prop.Enabled = true;
			}
			else
			{
				rbt_perso.Checked = true;
				txt_nom.Enabled = true;
				cmb_prop.Enabled = false;
			}

			_initialise = true;

		}
		#endregion

		#region ** Evenements **
		private void cmb_prop_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_initialise)
			{
				EProprieteSourcePourNom typesrc = (EProprieteSourcePourNom) Enum.Parse(typeof(EProprieteSourcePourNom),cmb_prop.SelectedItem.ToString());
				switch (typesrc)
				{
					case EProprieteSourcePourNom.Titre:
						txt_nom.Text = _hlp.Titre;
					 break;
					case EProprieteSourcePourNom.ID:
						txt_nom.Text = _hlp.HelpKey;
					 break;
					case EProprieteSourcePourNom.Nom:
						txt_nom.Text = _hlp.NomCourt;
					 break;
					case EProprieteSourcePourNom.Designation:
						txt_nom.Text = _hlp.Designation;
					 break;
					default:
					 break;
				}
			}
		}

		private void CheckedChanged(object sender, EventArgs e)
		{
			cmb_prop.Enabled = !rbt_perso.Checked;
			txt_nom.Enabled = rbt_perso.Checked;
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			if (txt_nom.Text.Trim() == "")
				CFormAlerte.Afficher(I.T("You must have a name to view the link|30034"), EFormAlerteType.Exclamation);
			else
				Close();
		}

		private void txt_nom_TextChanged(object sender, EventArgs e)
		{
			if (txt_nom.Text.Trim() == "")
				btn_ok.Enabled = false;
			else
				btn_ok.Enabled = true;

		}

		#endregion




		
	}
}