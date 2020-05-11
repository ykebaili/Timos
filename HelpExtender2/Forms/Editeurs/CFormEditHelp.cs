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
	public partial class CFormEditHelp : Form
	{
		#region :: Propriétés ::
		private CCtrlVoirAussi m_mnuVoirAussi;
		private CHelpData m_help;
		private bool m_editionPossible = true;
		private bool m_dejaCharge;
		#endregion

		#region ++ Constructeurs ++
		public CFormEditHelp()
		{
			InitializeComponent();
			m_dejaCharge = false;
			//m_mnuVoirAussi.TitreMenu = "Documents Annexes...";
		}
		#endregion

		#region ~~ Méthodes ~~
		public void Initialiser(CHelpData hlp)
		{
			m_help = hlp;

			if (!m_dejaCharge)
			{
				m_mnuVoirAussi = new CCtrlVoirAussi();
				m_mnuVoirAussi.ClicSurElement += new EventHandler(mnuvoiraussi_ClicSurElement);
				mnu.Items.Add(m_mnuVoirAussi.voirAussiToolStripMenuItem);
				m_dejaCharge = true;
			}
			m_mnuVoirAussi.Initialiser(hlp, true);
			editeur.Initialiser(m_help);

			ModeEditeur(true);

			InitialiserTitreFenetre();

		}

		private void InitialiserTitreFenetre()
		{ 
			string titre = m_help.Titre;
			
			switch (m_help.TypeLiaison)
			{
				case ETypeLiaisonAide.Control:
					titre += " (Control " + m_help.Controle.Text + " de type " + m_help.Controle.Type.Name + ")";
				 break;
				case ETypeLiaisonAide.Type:
					titre += " (Typel " + m_help.TypeLie.Name + ")";
				 break;
				default:
				case ETypeLiaisonAide.Aucune:
					titre += " (document indépendant)";
				 break;
			}

			Text = titre;
		}
		private void ModeEditeur(bool actif)
		{
			editeur.Enabled = actif;
			m_mnuVoirAussi.Enabled = actif;
			enregistrerToolStripMenuItem.Enabled = actif;
			supprimerToolStripMenuItem.Enabled = actif;
		}
		#endregion

		#region >> Assesseurs <<
		public CHelpData HelpSelectionne
		{
			get
			{
				if (editeur.Enabled)
					return editeur.HelpSelectionne;
				else
					return null;
			}
		}

		#endregion


		#region ** Evenements **



		private void CFormEditHelp_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (editeur.AssureSave())
				CHelpExtender.ArreterClignotementControl();
			else
				e.Cancel = true;
		}



		

		private void m_btnOk_Click(object sender, EventArgs e)
		{
			if (editeur.Sauvegarder())
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void m_btnAnnuler_Click(object sender, EventArgs e)
		{
			if(editeur.AssureSave())
				Close();
		}


		#region MenuStrip
		private void documentLiéÀUnTypeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (editeur.AssureSave())
			{

				CFormSelectHelpPage frm = new CFormSelectHelpPage();
				frm.Initialiser(ETypeSelection.SelonTitre);
				if (frm.ShowDialog() == DialogResult.OK)
				{
					CHelpData hlp = frm.HelpSelectionne;
					if (hlp == null)
						return;
					Initialiser(hlp);
				}
			}
		}
		private void documentIndividuelToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (editeur.AssureSave())
			{
				CHelpData hlp = new CHelpData("");
				Initialiser(hlp);
			}
		}
		private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			editeur.Sauvegarder();

		}
		private void fermerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(editeur.AssureSave())
				Close();
		}

		void mnuvoiraussi_ClicSurElement(object sender, EventArgs e)
		{
			if(editeur.AssureSave())
				Initialiser(m_mnuVoirAussi.HelpSelectionne);
		
		}
		private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CFormSelectHelpPage frm = new CFormSelectHelpPage();
			frm.Initialiser(ETypeSelection.SelonTitre);
			if (frm.ShowDialog() == DialogResult.OK && frm.HelpSelectionne != null)
				Initialiser(frm.HelpSelectionne);

		}
		#endregion

		private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (CFormAlerte.Afficher(I.T("Are you sure you want to delete this help file ?|30016"), EFormAlerteType.Question) == DialogResult.OK)
			{
				ModeEditeur(false);
			}
		}
		#endregion

		private void stylesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CFormEditStyles.EditeStyles();
		}

	}
}