using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using timos.data;
using sc2i.win32.common;

namespace timos.coordonnees
{
	public partial class CFormPopupSaisieCoordonnee : Form
	{
		private IObjetAFilsACoordonnees m_parent = null;
		private IObjetACoordonnees m_fils = null;
		private string m_strCoordonnee = "";

		private List<CControleSaisieNiveauCoordonnee> m_controlesParNiveau = new List<CControleSaisieNiveauCoordonnee>();

		//----------------------------------------------------------------------
		public CFormPopupSaisieCoordonnee()
		{
			InitializeComponent();
		}

		//----------------------------------------------------------------------
		public static bool EditeCoordonnee(
			Point ptSouris,
			IObjetAFilsACoordonnees parent,
			IObjetACoordonnees fils,
			ref string strCoordonnee)
		{
			if (parent == null)
				return false;
			if (fils == null)
				return false;
			if (parent.ParametrageCoordonneesApplique == null)
			{
				CFormAlerte.Afficher(I.T("No coordinate system defined|30124"), EFormAlerteType.Erreur);
				return false;
			}
			CFormPopupSaisieCoordonnee form = new CFormPopupSaisieCoordonnee();

			form.m_parent = parent;
			form.m_fils = fils;
			form.m_strCoordonnee = strCoordonnee;

			if (ptSouris.X + form.Width > Screen.PrimaryScreen.WorkingArea.Width)
				ptSouris.X = Screen.PrimaryScreen.WorkingArea.Width - form.Width;

			form.Location = ptSouris;

			bool bResult = form.ShowDialog() == DialogResult.OK;
			if (bResult)
				strCoordonnee = form.m_strCoordonnee;
			return bResult;
		}

		//----------------------------------------------------------------------
		private void CFormPopupSaisieCoordonnee_Load(object sender, EventArgs e)
		{
			sc2i.win32.common.CWin32Traducteur.Translate(this);
			CParametrageSystemeCoordonnees parametrage = m_parent.ParametrageCoordonneesApplique;

			m_lblParent.Text = m_parent.DescriptionElement;
			m_lblSystemeCoordonnees.Text = parametrage.SystemeCoordonnees.Libelle;

			int nHeight = Height - m_panelData.Height;
			m_panelData.SuspendDrawing();
			List<CParametrageNiveau> lst = new List<CParametrageNiveau>();
			foreach (CParametrageNiveau parNiv in parametrage.RelationParametragesNiveau)
				lst.Add(parNiv);
			lst.Sort(new CParametrageNiveauPositionComparer());
			foreach (CParametrageNiveau niveau in lst)
			{
				CControleSaisieNiveauCoordonnee ctrl = new CControleSaisieNiveauCoordonnee();
				m_controlesParNiveau.Add(ctrl);
				m_panelData.Controls.Add(ctrl);
				ctrl.Dock = DockStyle.Top;
				ctrl.BringToFront();
				ctrl.Init(niveau);
				ctrl.OnChangeValue += new EventHandler(ctrl_OnChangeValue);
				nHeight += ctrl.Height;
			}
			Height = nHeight;
			m_panelData.ResumeDrawing();
			string[] strCoords = m_strCoordonnee.Split(CSystemeCoordonnees.c_separateurNumerotations);
			int nIndex = 0;
			foreach (string strVal in strCoords)
			{
				if (nIndex < m_controlesParNiveau.Count)
					m_controlesParNiveau[nIndex++].Valeur = strVal;
			}
		}

		//----------------------------------------------------------------------
		void ctrl_OnChangeValue(object sender, EventArgs e)
		{
			DiffereVerification();
		}

		//----------------------------------------------------------------------
		private void DiffereVerification()
		{
			m_timerVerif.Enabled = false;
			m_timerVerif.Enabled = true;
		}


		//----------------------------------------------------------------------
		private void m_timerVerif_Tick(object sender, EventArgs e)
		{
			m_timerVerif.Enabled = false;
			Verifie();
		}

		//----------------------------------------------------------------------
		private bool Verifie()
		{
			m_strCoordonnee = "";
			foreach (CControleSaisieNiveauCoordonnee ctrl in m_controlesParNiveau)
				m_strCoordonnee += ctrl.Valeur + CSystemeCoordonnees.c_separateurNumerotations;
			while (m_strCoordonnee.Length > 0 && m_strCoordonnee[m_strCoordonnee.Length - 1] == CSystemeCoordonnees.c_separateurNumerotations)
				m_strCoordonnee = m_strCoordonnee.Substring(0, m_strCoordonnee.Length - 1);
			CResultAErreur result = m_parent.IsCoordonneeValide(m_strCoordonnee, m_fils);
			if (!result)
				m_lblErreur.Text = result.Erreur.ToString();
			else
				m_lblErreur.Text = m_strCoordonnee;
			return result.Result;
		}

		//----------------------------------------------------------------------
		private void m_btnOk_Click(object sender, EventArgs e)
		{
			if (!Verifie())
			{
				CFormAlerte.Afficher(m_lblErreur.Text, EFormAlerteType.Erreur);
				return;
			}
			DialogResult = DialogResult.OK;
			Close();
		}

		//----------------------------------------------------------------------
	}
}