using System;
using System.Resources;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.common;

using timos.data;

namespace timos
{
	public partial class CControlEditMappageColonne : UserControl
	{
		public CControlEditMappageColonne()
		{
			InitializeComponent();
			m_chkNull.Checked = false;
			sc2i.win32.common.CWin32Traducteur.Translate(this);
		}

		/// <summary>
		/// Initialisation en controle entête
		/// </summary>
		public void Initialiser(bool bDefaultValue)
		{
			ModeEntete = true;
			ValeurDefautPossible = bDefaultValue;
		}
		
		/// <summary>
		/// Initialisation en controle de visualisation Colonne Cible
		/// </summary>
		/// <param name="mappage"></param>
		public void Initialiser(CMappageColonneTableParametrableColonneTableParametrable mappage)
		{
			m_mappage = mappage;
			m_mappage.SourceChanged += new EventHandler(ChangementSource);
			m_ctrlEditVal.Initialiser(null, mappage.ColonneB.TypeDonneeChamp.TypeDotNetAssocie);
			IsColonneSource = false;
			InitialiserAffichage();
		}

		
		/// <summary>
		/// Initialisation en controle de visualisation en Colonne source
		/// </summary>
		/// <param name="mappage"></param>
		/// <param name="tpTableSrc"></param>
		public void Initialiser(CMappageColonneTableParametrableColonneTableParametrable mappage, CTypeTableParametrable tpTableSrc)
		{
			m_mappage = mappage;
			m_ctrlEditVal.Initialiser(null, mappage.ColonneB.TypeDonneeChamp.TypeDotNetAssocie);
			m_tpTableSrc = tpTableSrc;
			IsColonneSource = true;
			InitialiserAffichage();
		}

		public bool ModeEntete
		{
			get
			{
				return m_lblTitreValeur.Visible;
			}
			set
			{
				m_lblTitreKey.Visible = value;
				m_lblTitreNom.Visible = value;
				m_lblTitreNull.Visible = value;
				m_lblTitreType.Visible = value;
				m_lblTitreValeur.Visible = value;
				m_chkNull.Visible = !value;
				if (value)
				{
					m_lblTitreKey.BringToFront();
					m_lblTitreNom.BringToFront();
					m_lblTitreNull.BringToFront();
					m_lblTitreType.BringToFront();
					m_lblTitreValeur.BringToFront();
				}
				else
				{
					m_lblTitreKey.SendToBack();
					m_lblTitreNom.SendToBack();
					m_lblTitreNull.SendToBack();
					m_lblTitreType.SendToBack();
					m_lblTitreValeur.SendToBack();
				}
			}
		}



		private CMappageColonneTableParametrableColonneTableParametrable m_mappage;
		private CTypeTableParametrable m_tpTableSrc;


		private bool IsColonneSource
		{
			get
			{
				return m_cmbNom.Visible;
			}
			set
			{
				m_cmbNom.Visible = value;
				m_lblNom.Visible = !value;
				ValeurDefautPossible = !value;
			}
		}


		private void ActualiserDefautPossible()
		{
			m_ctrlEditVal.Enabled = m_mappage.ColonneA == null || !m_mappage.ColonneB.AllowNull;
			m_chkNull.Enabled = m_ctrlEditVal.Enabled;
		}
		private void ChangementSource(object sender, EventArgs e)
		{
			ActualiserDefautPossible();
		}

		private void InitialiserAffichage()
		{
			if (IsColonneSource)
			{
				m_cmbNom.BeginUpdate();
				m_cmbNom.Items.Clear();
				m_itm = new CItemAucun("Aucune");
				m_cmbNom.Items.Add(m_itm);
				CColonneTableParametrable col = m_mappage.ColonneB;
				foreach (CColonneTableParametrable c in m_tpTableSrc.Colonnes)
					if (c.TypeDonneeChamp.TypeDotNetAssocie == col.TypeDonneeChamp.TypeDotNetAssocie)
						m_cmbNom.Items.Add(c);

				m_cmbNom.EndUpdate();

				if (m_mappage.ColonneA == null)
				{
					m_cmbNom.SelectedItem = m_itm;
					InfosColonnePossible = false;
				}
				else
					m_cmbNom.SelectedItem = m_mappage.ColonneA;
			}
			else
			{
				m_lblNom.Text = m_mappage.ColonneB.Libelle;

				m_ctrlEditVal.Valeur = GetDefaultVal();
				m_chkNull.Checked = !m_mappage.ColonneB.AllowNull;
			}
			MAJInfosColonne();
			ActualiserDefautPossible();
		}
		private object GetDefaultVal()
		{
			switch (m_mappage.ColonneB.TypeDonneeChamp.TypeDonnee)
			{
				case sc2i.data.dynamic.TypeDonnee.tBool:
					return false;
				case sc2i.data.dynamic.TypeDonnee.tDate:
					return DateTime.Now.Date;
				case sc2i.data.dynamic.TypeDonnee.tDouble:
				case sc2i.data.dynamic.TypeDonnee.tEntier:
					return 0;
				case sc2i.data.dynamic.TypeDonnee.tString:
					return "";
				case sc2i.data.dynamic.TypeDonnee.tObjetDonneeAIdNumeriqueAuto:
				default:
					return null;
			}
		}

		private CItemAucun m_itm;

		private class CItemAucun
		{
			public CItemAucun(string strNomNull)
			{
				m_strNomNull = strNomNull;
			}
			private string m_strNomNull;
			public string Libelle
			{
				get
				{
					return m_strNomNull;
				}
			}
			public override string ToString()
			{
				return Libelle;
			}

		}

		private void m_cmbNom_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (m_cmbNom.SelectedItem == m_itm)
			{
				InfosColonnePossible = false;
			}
			else
			{
				InfosColonnePossible = true;
				MAJInfosColonne();
			}
			MAJChamp();
		}
		public void MAJInfosColonne()
		{

			CColonneTableParametrable col = null;
			if (IsColonneSource)
			{
				if (m_cmbNom.SelectedItem != m_itm)
					col = (CColonneTableParametrable)m_cmbNom.SelectedItem;
			}
			else
				col = m_mappage.ColonneB;


			m_panKey.BackgroundImage = col != null && col.IsPrimaryKey ? Properties.Resources.cle : null;
			m_panObligatoire.BackgroundImage = col != null && col.AllowNull ? Properties.Resources.ok : null;
			if(col != null)
				m_lblType.Text = col.TypeDonneeChamp.Libelle;
		}

		public bool InfosColonnePossible
		{
			get
			{
				return m_panKey.Visible;
			}
			set
			{
				//m_panInfo.Visible = value;
				m_panKey.Visible = value;
				m_splitterKey.Visible = value;
				m_panObligatoire.Visible = value;
				m_splitterObligatoire.Visible = value;
				m_panType.Visible = value;
			}
		}
		public bool ValeurDefautPossible
		{
			get
			{
				return m_panValeur.Visible;
			}
			set
			{
				m_panValeur.Visible = value;
				m_splitterNom.Visible = value;
				if (!value)
					m_panNom.Dock = DockStyle.Fill;
				else
					m_panNom.Dock = DockStyle.Left;
			}
		}

		public CResultAErreur MAJChamp()
		{
			CResultAErreur result = CResultAErreur.True;
			if(IsColonneSource)
			{
				if (m_cmbNom.SelectedItem == m_itm)
					m_mappage.ColonneA = null;
				else
					m_mappage.ColonneA = (CColonneTableParametrable)m_cmbNom.SelectedItem;
			}
			else
			{
				if(!m_chkNull.Checked)
					m_mappage.DefaultValueAtoB = null;
				else
					m_mappage.DefaultValueAtoB = m_ctrlEditVal.Valeur;
			}
			return result;
		}

		public Panel PanneauInfos
		{
			get
			{
				return m_panInfo;
			}
		}
		public Panel PanneauValeurDefaut
		{
			get
			{
				return m_panValeur;
			}
		}

		private void m_chkNull_CheckedChanged(object sender, EventArgs e)
		{
			if (m_chkNull.Checked)
			{
				m_chkNull.Dock = DockStyle.Left;
				m_chkNull.Width = 15;
				m_ctrlEditVal.BringToFront();
			}
			else
			{
				m_chkNull.Dock = DockStyle.Fill;
				m_chkNull.BringToFront();
			}

			m_ctrlEditVal.Visible = m_chkNull.Checked;
		}
	}
}
