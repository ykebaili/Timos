using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace HelpExtender
{
	public partial class CFormAide : Form
	{
		#region :: Propriétés ::
		private static CFormAide m_form = null;
		private CHelpData m_helpData;
		private bool m_bEnableAideSurSouris = false;
		private static List<CHelpData> m_pileNavigation;
		private static int m_positionnav;
		Control m_lastControlPopup = null;
		#endregion

		#region ++ Constructeurs ++
		public CFormAide()
		{
			InitializeComponent();
			m_pileNavigation = new List<CHelpData>();
			m_positionnav = 0;
			visualiseur.LiensVersHelpActifs = false;
		}
		#endregion

		#region ~~ Méthodes ~~
		//Pop Up
		public static IntPtr GetWindowFromPoint(Point p)
		{
			IntPtr hWndParent = WindowFromPoint(p);

			if (hWndParent != IntPtr.Zero)
			{
				MapWindowPoints(IntPtr.Zero, hWndParent, ref p, 1);
				IntPtr hWndChild = ChildWindowFromPoint(hWndParent, p);

				if (hWndChild != IntPtr.Zero)
					return hWndChild;
			}

			return hWndParent;
		}
		public static void ShowHelp ( CHelpData help, Control owner )
		{
			if ( m_form == null || m_form.Owner != owner)
			{
				if (m_form != null)
				{
					m_form.Visible = false;
					m_form.Dispose();
					m_form = null;
				}
				m_form = new CFormAide();
				m_form.Location = new Point ( Screen.PrimaryScreen.WorkingArea.Width - m_form.Width );
				m_form.Size = new Size(m_form.Width, Screen.PrimaryScreen.WorkingArea.Height);
			}
			m_form.Initialiser(help);
		}
		private void PopupHelp(CHelpData help)
		{
			Point pt = Cursor.Position;
			pt.Offset(0, 5);
			CWebViewerPopup.Popup(pt, help);
		}

		private void Precedant()
		{
			if (m_positionnav > 0)
			{
				m_positionnav--;
				Afficher(m_pileNavigation[m_positionnav]);
			}
		}
		private void Suivant()
		{
			if (m_pileNavigation.Count > (m_positionnav + 1))
			{
				m_positionnav++;
				Afficher(m_pileNavigation[m_positionnav]);
			}
		}

		public CHelpData GetHelpToView(Control ctrl)
		{
			CHelpData help = CHelpData.GetHelp(ctrl, "");
			while (!help.DejaEnregistre)
			{
				Type tp = ctrl.GetType();
				if (ctrl is CHelpData.CtrlPartiel)
					tp = ((CHelpData.CtrlPartiel)ctrl).Type;
				while (tp != null)
				{
					help = CHelpData.GetHelp(tp, "");
					if (help.DejaEnregistre)
						return help;
					tp = tp.BaseType;
				}
				ctrl = ctrl.Parent;
				if (ctrl == null)
					return null;
				help = CHelpData.GetHelp(ctrl, "");
			}
			return help;
		}


		public void Initialiser(CHelpData hlp)
		{
			//ctrl_voirAussi.TitreMenu = "Documents Connexes";

			m_positionnav++;
			for (int i = m_positionnav; i < m_pileNavigation.Count; i++)
				m_pileNavigation.RemoveAt(i);

			m_pileNavigation.Add(hlp);
			if (hlp.TypeLiaison == ETypeLiaisonAide.Control && !CHelpExtender.ModeEdition)
			{
				Control ctrl = hlp.Controle;
				CHelpData helpToShow = GetHelpToView(ctrl);
				if (helpToShow != null)
					hlp = helpToShow;
			}
			Afficher(hlp);
			
		}
		private void Afficher(CHelpData help)
		{

			m_helpData = help;

			visualiseur.Initialiser(help);

			//Titre
			SetTitre(help);


			if (help == null)
			{
				if (Visible)
					Visible = false;
				return;
			}

			int nState = GetKeyState(0x11);
			if (nState < 0 && CHelpExtender.AutoriseModeEdition)
			{
				EditeHelp(help);
				return;
			}

			//if (!m_bAutoriseEdition || help.VisualisationAide == EVisualisationAide.Popup)
			//{
			//    while ((!help.HasData || help.VisualisationAide == EVisualisationAide.Popup) && help.Controle != null && help.Controle.Parent != null)
			//    {
			//        help = CHelpData.SourceAide.GetHelp(help.Controle.Parent, help.Contexte);
			//        if (help == null)
			//            return;
			//    }
			//}
			if (!help.HasData && !CHelpExtender.ModeEdition)
			{
				Visible = false;
				return;
			}


			//Menu Voir aussi
			ctrl_voirAussi.Initialiser(help, CHelpExtender.ModeEdition);
			m_lblTitre.Text = help.Titre;

			//Disponibilité du bouton d'edition
			m_btnEditer.Visible = CHelpExtender.AutoriseModeEdition;
			m_chkModeEdition.Visible = CHelpExtender.AutoriseModeEdition;
			pan_separateur2.Visible = CHelpExtender.AutoriseModeEdition;

			Visible = true;
			Focus();
			BringToFront();
		}

		private void SetTitre(CHelpData hlp)
		{
			Text = hlp.Titre;
			//string strTitre = "";
			//switch (hlp.TypeLiaison)
			//{
			//    case ETypeLiaisonAide.Control:
			//        strTitre = "Control : " + hlp.Controle.Name;
			//        break;
			//    case ETypeLiaisonAide.Type:
			//        strTitre = "Type : " + hlp.TypeLie.Name;
			//        break;
			//    case ETypeLiaisonAide.Aucune:
			//        strTitre = "Document indépendant";
			//        break;
			//    case ETypeLiaisonAide.GroupeControls:
			//        strTitre = "Groupe de Control : " + hlp.Controle.Name;
			//        break;
			//    default:
			//        break;
			//}
			//Text = strTitre;
		}
		
		private void EditeHelp ( CHelpData help )
		{
			CFormEditHelp form = new CFormEditHelp();
			form.Initialiser(help);
			form.ShowDialog();
			m_helpData = form.HelpSelectionne;


		}
		private void EditerMenu()
		{
		}
		#endregion

		#region ** Evenements **
		#region Navigation vers un autre help
		private void ctrl_voirAussi_ClicSurElement(object sender, EventArgs e)
		{
			CHelpData hlp = ctrl_voirAussi.HelpSelectionne;
			if (hlp != null)
				Initialiser(hlp);
		}

		private void visualiseur_NavigationVersHelp(object sender, ArgumentsEvenementNavigationVersAide e)
		{
			Afficher(e.Help);
		}
		#endregion

		#region Boutons
		private void m_btnEditer_Click(object sender, EventArgs e)
		{
			EditeHelp(m_helpData);
			ShowHelp(m_helpData, m_form.Owner);
		}
		private void m_btnHelp_Click(object sender, EventArgs e)
		{
			Capture = true;
			m_bEnableAideSurSouris = true;
		}
		private void m_btnMenu_Click(object sender, EventArgs e)
		{
			CFormMenu frm = new CFormMenu();
			frm.Initialiser(CHelpData.SourceAide.MenuRoot, CHelpExtender.ModeEdition);
			frm.ShowDialog();
		}
		#endregion

		#region Global
		private void CFormAide_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			Visible = false;
			CHelpExtender.ArreterClignotementControl();
		}
		private void CFormAide_MouseMove(object sender, MouseEventArgs e)
		{
			if (m_bEnableAideSurSouris)
			{
				Cursor = Cursors.Help;
				Point pt = PointToScreen(new Point(e.X, e.Y));
				IntPtr ptr = GetWindowFromPoint(pt);
				try
				{
					Control ctrl = Control.FromHandle(ptr);
					if (ctrl != null)
					{
						if (!ctrl.Equals(m_lastControlPopup))
						{
							m_lastControlPopup = ctrl;
							if (CHelpData.SourceAide.HasHelp(ctrl, ""))
							{
								CHelpData help = CHelpData.SourceAide.GetHelp(ctrl, "");
								if (help.VisualisationAide == EVisualisationAide.Popup)
								{
									PopupHelp(help);
									return;
								}
							}
						}
						else
							return;
					}
				}
				catch
				{
				}
			}
			PopupHelp(null);
		}
		private void CFormAide_MouseDown(object sender, MouseEventArgs e)
		{
			if (Capture)
			{
				Capture = false;
				m_bEnableAideSurSouris = false;
				Cursor = Cursors.Arrow;
			}
		}
		#endregion

		//Navigation
		private void btn_suivant_Click(object sender, EventArgs e)
		{
			Suivant();
		}
		private void btn_precedant_Click(object sender, EventArgs e)
		{
			Precedant();
		}


		#endregion

		#region API Windows
		[DllImport("user32.dll")]
		private static extern int GetKeyState(int nKeyCode);
		[DllImport( "user32.dll" ) ]
		private static extern IntPtr WindowFromPoint( Point p );
		[ DllImport( "user32.dll" ) ]
		private static extern IntPtr ChildWindowFromPoint( IntPtr hWndParent, Point p );
		[ DllImport( "user32.dll", SetLastError = true ) ]
		private static extern int MapWindowPoints( IntPtr hWndFrom, IntPtr hWndTo, ref Point lpPoints, uint cPoints );
		#endregion

		private void m_chkModeEdition_CheckedChanged(object sender, EventArgs e)
		{
			CHelpExtender.ModeEdition = m_chkModeEdition.Checked;
			m_chkModeEdition.Image = m_chkModeEdition.Checked ? m_imagesCadenas.Images[0] : m_imagesCadenas.Images[1];
			ctrl_voirAussi.Initialiser(m_helpData, CHelpExtender.ModeEdition);
		}


	}
}