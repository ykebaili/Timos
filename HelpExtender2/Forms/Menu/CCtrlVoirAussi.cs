using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HelpExtender
{

	public partial class CCtrlVoirAussi : UserControl
	{
		#region ++ Constructeurs ++
		public CCtrlVoirAussi()
		{
			InitializeComponent();
		}
		#endregion

		#region :: Propriétés ::
		private CHelpData m_hlp;
		private CHelpData m_hlpselec;
		private bool m_bEdition;
		private bool m_bPlusDeSeparateur;
		private bool m_bModeClignotement;
		#endregion

		#region ~~ Méthodes ~~
		public void Initialiser(CHelpData hlp, bool editionPossible)
		{
			m_hlp = hlp;
			m_bModeClignotement = true;
			m_bEdition = editionPossible;
			m_bPlusDeSeparateur = false;
			ConstruireMenu();
		}


		public void ConstruireMenu()
		{
			//Effacer les items
			voirAussiToolStripMenuItem.DropDownItems.Clear();

			if (!m_bEdition)
			{
				List<CHelpData> itms = m_hlp.GetTousLesVoirAussi(m_bEdition);
				CHelpDataNameComparer.Trier(ref itms);
				foreach (CHelpData hlp in itms)
					voirAussiToolStripMenuItem.DropDownItems.Add(GetMenuItem(hlp));

			}
			else
			{
				switch (m_hlp.TypeLiaison)
				{
					case ETypeLiaisonAide.Control:
						Add_Rubriques_Control();
						break;
					case ETypeLiaisonAide.Type:
						Add_Rubriques_Type();

						break;
					default:
					case ETypeLiaisonAide.Aucune:
						Add_Rubriques_Aucune();
						break;
				}
			}

			if (voirAussiToolStripMenuItem.DropDownItems.Count > 0)
				mnu.Enabled = true;
			else
				mnu.Enabled = false;
		}

		private ToolStripMenuItem GetMenuItem(CHelpData hlp)
		{
			ToolStripMenuItem itm = new ToolStripMenuItem();
			itm.Tag = hlp;

			if (hlp.DejaEnregistre)
			{
				if (hlp.Titre != null && hlp.Titre.Trim() != "")
					itm.Text = hlp.Titre;
				else if (hlp.NomCourt != null && hlp.NomCourt.Trim() != "")
					itm.Text = hlp.NomCourt;
				else
					itm.Text = "[NOM MANQUANT]";
				itm.ForeColor = Color.Blue;
			}
			else
			{
				switch (hlp.TypeLiaison)
				{
					case ETypeLiaisonAide.Control:
						if(hlp.Controle != null && hlp.Controle.Type != null)
							itm.Text = hlp.Controle.Name + " (Control de type " + hlp.Controle.Type.Name + ")";
						else
							itm.Text = "[NOM INDISPONIBLE] (Control)";

						break;
					case ETypeLiaisonAide.Type:
						if (hlp.TypeLie != null)
							itm.Text = hlp.TypeLie.Name + " (Type)";
						else
							itm.Text = "[NOM INDISPONIBLE] (Type)";

						break;
					case ETypeLiaisonAide.Aucune:
						itm.Text = "[NOM INDISPONIBLE] (Independant)";

						break;
					default:
						break;
				}
				itm.ForeColor = Color.Red;
			}

			itm.Click += new EventHandler(ClickHelp);
			if (m_bModeClignotement && hlp.TypeLiaison == ETypeLiaisonAide.Control)
			{
				itm.MouseHover += new EventHandler(rubriqueType_MouseHover);
				itm.MouseLeave += new EventHandler(rubriqueType_MouseLeave);

			}
			return itm;
		}

		//Rubriques
		private void Add_Rubriques_Control()
		{
			Add_Heritage();
			Add_Interfaces();
			Add_Attributs();

			Add_Type();

			Add_Parents();
			Add_Fils();

			Add_VoirAussiExplicites();

			Add_Lies();

		}

		
		private void Add_Rubriques_Type()
		{
			Add_Heritage();
			Add_Interfaces();
			Add_Attributs();
			Add_VoirAussiExplicites();

			//Add_Lies();
		}
		private void Add_Rubriques_Aucune()
		{
			Add_VoirAussiExplicites();
			//Add_Lies();
		}

		//Documents
		private void AjouterItems(string nomRubrique, List<CHelpData> hlps)
		{
			ToolStripMenuItem rubrique = new ToolStripMenuItem(nomRubrique);
			foreach (CHelpData hlp in hlps)
				rubrique.DropDownItems.Add(GetMenuItem(hlp));

			if (rubrique.DropDownItems.Count > 0)
				voirAussiToolStripMenuItem.DropDownItems.Add(rubrique);
		}

		private void Add_Interfaces()
		{
			List<CHelpData> hlps = m_hlp.GetVoirAussiInterfaces(m_bEdition);
			CHelpDataNameComparer.Trier(ref hlps);
			AjouterItems("Interfaces", hlps);
		}
		private void Add_Heritage()
		{
			List<CHelpData> hlps = m_hlp.GetVoirAussiHeritages(m_bEdition);
			AjouterItems("Heritages", hlps);
		}
		private void Add_Attributs()
		{
			List<CHelpData> hlps = m_hlp.GetVoirAussiAttributs(m_bEdition);
			CHelpDataNameComparer.Trier(ref hlps);
			AjouterItems("Attributs", hlps);
		}

		private void Add_Type()
		{
			voirAussiToolStripMenuItem.DropDownItems.Add(GetMenuItem(m_hlp.GetVoirAussiType(m_bEdition)));
		}
		private void Add_Parents()
		{
			List<CHelpData> hlps = m_hlp.GetVoirAussiParent(m_bEdition);
			AjouterItems("Parents", hlps);
		}
		private void Add_Fils()
		{
			List<CHelpData> hlps = m_hlp.GetVoirAussiEnfants(m_bEdition);
			AjouterItems("Fils", hlps);
		}
		private void Add_Lies()
		{
			List<CHelpData> hlps = m_hlp.VoirAussiExplicite;
			CHelpDataNameComparer.Trier(ref hlps);
			AjouterItems("Faisant Reference", hlps);
		}

		private void Add_VoirAussiExplicites()
		{
			AjouterItems("Voir aussi", m_hlp.VoirAussiExplicite);
		}


		private void AjouterSeparateur()
		{
			if (!m_bPlusDeSeparateur)
			{
				ToolStripSeparator separator = new ToolStripSeparator();
				voirAussiToolStripMenuItem.DropDownItems.Add(separator);
			}
		}
		#endregion

		#region >> Assesseurs <<
		public string TitreMenu
		{
			get
			{
				return "";// voirAussiToolStripMenuItem.Text;
			}
			set
			{
				//voirAussiToolStripMenuItem.Text = value;
			}

		}
		public CHelpData HelpSelectionne
		{
			get
			{
				return m_hlpselec;
			}
		}
		public bool FaireClignoterLesControlsAuSurvol
		{
			get
			{
				return m_bModeClignotement;
			}
			set
			{
				m_bModeClignotement = value;
			}
		}
		#endregion

		#region ** Evenements **
		public event EventHandler ClicSurElement;

		private void ClickHelp(object sender, EventArgs e)
		{
			ToolStripMenuItem itm = (ToolStripMenuItem)sender;
			Type t = itm.Tag.GetType();
			if (t == typeof(CHelpData))
				m_hlpselec = (CHelpData)itm.Tag;
			else
				m_hlpselec = new CHelpData((Control)itm.Tag, "");

			if (ClicSurElement != null)
				ClicSurElement(sender, e);

		}
		void rubriqueType_MouseLeave(object sender, EventArgs e)
		{
			CHelpExtender.ArreterClignotementControl();
		}

		void rubriqueType_MouseHover(object sender, EventArgs e)
		{
			//CHelpExtender.ArreterClignotementControl();
			ToolStripMenuItem itm = (ToolStripMenuItem)sender;
			//Type t = itm.Tag.GetType();
			//if (t == typeof(CHelpData))
			//{
			CHelpData hlpselec = (CHelpData)itm.Tag;
			//    if (hlpselec.TypeLiaison == ETypeLiaisonAide.Control && hlpselec.Controle != null)
					CHelpExtender.FaireClignoterControl(hlpselec.Controle);
			//}
			//else
			//    CHelpExtender.FaireClignoterControl((Control) itm.Tag);
		}
		#endregion
	}
}
