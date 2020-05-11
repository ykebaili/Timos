using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.common;

namespace timos.win32.composants
{
	public partial class CFormSelectType : Form
	{

		private Type m_typeSel = null;

		public CFormSelectType()
		{
			InitializeComponent();
		}

		//-------------------------------------------------------------------------
		public static Type SelectType( Point pt, List<Type> listeTypes, string strTitre)
		{
			List<CInfoClasseDynamique> lst = new List<CInfoClasseDynamique>();
			foreach (Type tp in listeTypes)
			{
				CInfoClasseDynamique info = new CInfoClasseDynamique(tp, DynamicClassAttribute.GetNomConvivial(tp));
				lst.Add(info);
			}
			return SelectType(pt, lst, strTitre);
		}

		//-------------------------------------------------------------------------
		public static Type SelectType(Point pt, List<CInfoClasseDynamique> listeTypes, string strTitre)
		{
			CFormSelectType form = new CFormSelectType();
			pt = SFormPopup.GetPointForFormPopup(pt, form);
			form.m_lblTitre.Text = strTitre;
			form.InitComboTypes(listeTypes);
			form.Location = pt;
			Type tpRetour = null;
			if (form.ShowDialog() == DialogResult.OK)
				tpRetour = form.m_typeSel;
			form.Dispose();
			return tpRetour;
		}

		//-------------------------------------------------------------------------
		protected void InitComboTypes(List<CInfoClasseDynamique> listeTypes)
		{
			m_cmbTypeElements.DataSource = null;
			m_cmbTypeElements.DataSource = listeTypes;
			m_cmbTypeElements.ValueMember = "Classe";
			m_cmbTypeElements.DisplayMember = "Nom";
		}

		//-------------------------------------------------------------------------
		private void m_btnOk_Click(object sender, EventArgs e)
		{
			if (m_cmbTypeElements.SelectedValue is Type)
			{
				m_typeSel = (Type)m_cmbTypeElements.SelectedValue;
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		//-------------------------------------------------------------------------
		private void m_btnAnnuler_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

	}
}