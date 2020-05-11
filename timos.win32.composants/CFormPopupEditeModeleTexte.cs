using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using sc2i.win32.common;
using sc2i.workflow;

namespace timos.win32.composants
{
	public partial class CFormPopupEditeModeleTexte : System.Windows.Forms.Form
	{
		public CFormPopupEditeModeleTexte()
		{
			InitializeComponent();
		}

		private void CFormPopupEditeModeleTexte_Load(object sender, EventArgs e)
		{
			CWin32Traducteur.Translate(this);
		}

		public static bool EditeModele(CModeleTexte modele)
		{
			return EditeModele(modele, null);
		}

		public static bool EditeModele ( CModeleTexte modele, object elementDeTest )
		{
			CFormPopupEditeModeleTexte form = new CFormPopupEditeModeleTexte();
			form.m_panelModele.Init(modele, elementDeTest);
			DialogResult res = form.ShowDialog();
			form.Dispose();
			return res == DialogResult.OK;			
		}

		private void m_btnOk_Click(object sender, EventArgs e)
		{ 
			CResultAErreur result = CResultAErreur.True;
			result = m_panelModele.MAJ_Champs();
			if (result)
				result = m_panelModele.ModeleTexte.VerifieDonnees(false);
			if ( !result )
			{
				CFormAlerte.Afficher(result.Erreur.ToString(), EFormAlerteType.Erreur);
				return;
			}
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}