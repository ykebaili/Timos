using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using timos.data;
using sc2i.win32.common;

namespace timos.coordonnees
{
	public partial class CControleSaisieNiveauCoordonnee : UserControl
	{
		private CParametrageNiveau m_niveau = null;
		private CArbreVocabulaire m_arbreVocabulaire;

		public CControleSaisieNiveauCoordonnee()
		{
			InitializeComponent();
		}

		//--------------------------------------------------
		public void Init ( CParametrageNiveau niveau )
		{
			m_niveau = niveau;

			if ( m_niveau == null )
			{
				Visible = false;
				return;
			}
			m_lblLibelle.Text = m_niveau.Libelle;
			//m_lblPrefixe.Text = m_niveau.RelationSysCoor_FormatNum.Prefixes;
			m_arbreVocabulaire = new CArbreVocabulaire(1,0,"");
			foreach (string strPrefixe in m_niveau.RelationSysCoor_FormatNum.PrefixesPossibles)
			{
				m_arbreVocabulaire.StockeMot(strPrefixe, "");
			}
			m_arbreVocabulaire.TouteLaListeSurChaineVide = true;
			m_txtValeur.Arbre = m_arbreVocabulaire;
			m_txtValeur.Text = "";
			m_lblUnite.Text = "";
			if ( m_niveau.RelationSysCoor_FormatNum.Unite != null )
				m_lblUnite.Text = m_niveau.RelationSysCoor_FormatNum.Unite.Libelle;
			string strAide =  "";
			strAide =  m_niveau.PremiereReference + "->"+m_niveau.DerniereReference;
			m_lblAide.Text = strAide;
			m_tooltip.SetToolTip ( m_lblAide,strAide );
			SetAideTooltip();
		}

		//--------------------------------------------------
		public string Valeur
		{
			get
			{
				return m_txtValeur.Text;
		}
			set
			{
				m_txtValeur.Text = value;
			}
		}

		public event EventHandler OnChangeValue;

		//-------------------------------------------------------
		private void m_txtValeur_TextChanged(object sender, EventArgs e)
		{
			VerifieCoordonnee();
		}

		//-------------------------------------------------------
		private void SetAideTooltip()
		{
			string strAide = m_niveau.RelationSysCoor_FormatNum.FormatNumerotation.Libelle;
			foreach (string strPrefixe in m_niveau.RelationSysCoor_FormatNum.PrefixesPossibles)
				strAide += "\r\n" + strPrefixe;
			m_tooltip.SetToolTip(m_txtValeur, strAide);
		}


		//-------------------------------------------------------
		private void VerifieCoordonnee()
		{
			CResultAErreur result = CResultAErreur.True;
			string strNum = m_niveau.RelationSysCoor_FormatNum.IsolerReference(m_txtValeur.Text);
			if (m_txtValeur.Text != "")
				result = m_niveau.RelationSysCoor_FormatNum.GetIndex ( m_txtValeur.Text );
			if (!result)
			{
				m_txtValeur.BackColor = Color.Red;
				m_tooltip.SetToolTip(m_txtValeur, result.Erreur.ToString());
			}
			else
			{
				m_txtValeur.BackColor = Color.White;
				SetAideTooltip();
			}
			if (OnChangeValue != null)
				OnChangeValue(this, new EventArgs());
		}


		//-------------------------------------------------------
		public override void Refresh()
		{
			VerifieCoordonnee();
		}

	}
}
