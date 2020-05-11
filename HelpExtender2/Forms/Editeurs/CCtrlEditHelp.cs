using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using sc2i.common;
using sc2i.win32.common;

namespace HelpExtender
{
	public partial class CCtrlEditHelp : UserControl
	{
		private class CStyle
		{
			private string m_strLibelle = "";
			private string m_strBalise = "";
			public CStyle(string strBalise, string strLibelle)
			{
				m_strLibelle = strLibelle;
				m_strBalise = strBalise;
			}
			public string Balise
			{
				get
				{
					return m_strBalise;
				}
			}

			public override string ToString()
			{
				return m_strLibelle;
			}
		}
		//Liste des ressources affichées et converties en fichier dans le HTML
		private List<CRessourceFichier> m_listeRessourcesFichier = new List<CRessourceFichier>();
		#region ++ Constructeurs ++
		public CCtrlEditHelp()
		{
			InitializeComponent();
			m_htmlEditor.toolStripButtonHyperLink.Visible = false;
			m_htmlEditor.toolStripButtonImage.Visible = false;
			m_comboExStyles.Items.Add(new CStyle("H1", "Title 1"));
			m_comboExStyles.Items.Add(new CStyle("H2", "Title 2"));
			m_comboExStyles.Items.Add(new CStyle("H3", "Title 3"));
			m_comboExStyles.Items.Add(new CStyle("H4", "Title 4"));
			m_comboExStyles.Items.Add(new CStyle("H5", "Title 5"));
			m_comboExStyles.SelectedIndexChanged += new EventHandler(m_comboStyles_SelectedIndexChanged);

		}

		void m_comboStyles_SelectedIndexChanged(object sender, EventArgs e)
		{
			CStyle style = (CStyle)m_comboExStyles.SelectedItem;
			if (style != null)
			{
				string strHtml = "<" + style.Balise + ">" + m_htmlEditor.SelectedHTML + "</" + style.Balise + ">";
				m_htmlEditor.InsertHtml ( strHtml );
			}
		}
		#endregion

		#region :: Propriétés ::
		private CHelpData.FichierLie m_fichierSelec;
		private bool m_bInitialise;
		private CHelpData m_help;
		private bool m_bHasChange = false;
		//private static Point m_lastPosition = new Point(0, 0);
		//private static Size m_lastSize = new Size(0, 0);
		#endregion

		#region ~~ Méthodes ~~
		public void Initialiser(CHelpData hlp)
		{
			//m_htmlEditor.Fonts = FontFamily.Families;
			CHelpExtender.ArreterClignotementControl();
			m_bInitialise = false;
			m_help = hlp;

			if (m_help != null)
			{
				_ntick = 0;
				m_t = new Timer();
				m_t.Tick += new EventHandler(t_Tick);
				m_t.Start();
			}

			if (hlp.TypeLiaison == ETypeLiaisonAide.Control)
				CHelpExtender.FaireClignoterControl(hlp.Controle);

			m_bInitialise = true;
		}

		private void InitialiserChamps()
		{
			//Infos générales
			ctrl_selectLiaison.Enabled = false;
			ctrl_selectLiaison.Liaison = m_help.TypeLiaison;
			txt_designation.Text = m_help.Designation;
			m_txtTitre.Text = m_help.Titre;
			m_txtNomCourt.Text = m_help.NomCourt;

			//Contenu HTML
			/*m_htmlEditor.HTMLDesignMode = true;
			m_htmlEditor.DesignModeButtonVisible = true;*/
			m_htmlEditor.BodyHtml = m_help.TexteHTML;
			ConvertImagesResToFiles();
			//m_htmlEditor.DocumentHTML = m_help.TexteHTML;
			//m_htmlEditor.Initialiser(m_help);
			/*m_htmlEditor.BoutonModeHTML = false;*/


			//Visualisation
			m_chkAidePopup.Checked = m_help.VisualisationAide == EVisualisationAide.Popup;
			if (m_chkAidePopup.Checked)
				pan_Popup.Visible = true;
			else
				pan_Popup.Visible = false;

			m_numUpSizeY.Value = m_help.SizePopup.Height;
			m_numUpSizeX.Value = m_help.SizePopup.Width;

			//Reference liées
			lv_voiraussi.Items.Clear();
			foreach (CHelpData hlp in m_help.VoirAussiExplicite)
				AjouterHelpLiee(hlp);

			//Indicateur de modification
			m_bHasChange = false;
//			m_htmlEditor.HasChange = false;

			InitialiserFichiers();
		}

		//-------------------------------------------------------------------
		private void LibereRessourceFichierLocales()
		{
			foreach (CRessourceFichier ressource in m_listeRessourcesFichier)
			{
				try
				{
					CHelpData.SourceAide.LibereRessourceFichierLocale(ressource);
				}
				catch
				{ }
			}
			m_listeRessourcesFichier.Clear();
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Convertit les liens images vers de ressources en liens vers de fichiers locaux
		/// </summary>
		private void ConvertImagesResToFiles( )
		{
			LibereRessourceFichierLocales();
			string strBody = m_htmlEditor.BodyHtml;
			string[] strImages = m_htmlEditor.ImageSrcs;
			foreach (string strImage in strImages)
			{
				if (strImage.Length > 6 && strImage.Substring(0, 6).ToUpper() == "RES://")
				{
					string strRes = strImage.Substring(6);
					CRessourceFichier ressource = CHelpData.SourceAide.GetRessourceFichier(strRes);
					if (ressource != null)
					{
						strBody = strBody.Replace(strImage, "file://" + ressource.NomFichierLocal.Replace("\\","/"));
						m_listeRessourcesFichier.Add(ressource);
					}
				}
			}
			m_htmlEditor.BodyHtml = strBody;
		}

		/// <summary>
		/// Convertit les liens fichiers vers des liens image
		/// </summary>
		private string ConvertImagesFilesToRes()
		{
			string strBody = m_htmlEditor.BodyHtml;
			string[] strImages = m_htmlEditor.ImageSrcs;
			Hashtable tableFichiers = new Hashtable();
			foreach (CRessourceFichier ressource in m_listeRessourcesFichier)
				tableFichiers[ressource.NomFichierLocal.ToUpper().Replace('\\','/')] = ressource;
			foreach (string strImage in strImages)
			{
				if (strImage.Length > 7 && strImage.Substring(0, 7).ToUpper() == "FILE://")
				{
					string strFile = strImage.Substring(7).ToUpper();
					while (strFile.Length>0 &&  strFile[0] == '/')
						strFile = strFile.Substring(1);
					CRessourceFichier ressource = (CRessourceFichier)tableFichiers[strFile];
					if (ressource != null)
					{
						strBody = strBody.Replace(strImage, "RES://" + ressource.Cle);
					}
				}
			}
			return strBody;
		}



		private void InitialiserFichiers()
		{
			lv_fichiers.Items.Clear();

			foreach (CHelpData.FichierLie f in m_help.FichiersLies)
				AjouterFichierLie(f);

			chk_hide.Enabled = false;
			lnk_suppFile.Enabled = false;
		}
		private void AjouterFichierLie(CHelpData.FichierLie fichier)
		{
			AjouterFichierLie(fichier, false);
		}
		private void AjouterFichierLie(CHelpData.FichierLie fichier, bool selectionne)
		{
			ListViewItem itm = new ListViewItem(fichier.Nom);
			itm.SubItems.Add(fichier.TypeDeFichier.ToString());
			itm.SubItems.Add(fichier.Extention);
			itm.SubItems.Add(fichier.Masquer.ToString());
			itm.Tag = fichier;
			lv_fichiers.Items.Add(itm);

			itm.Selected = selectionne;
			ActualiserInfosSelectionFichier();
		}
		private void ActualiserInfosSelectionFichier()
		{
			if (lv_fichiers.SelectedItems.Count != 1)
			{
				lnk_suppFile.Enabled = false;
				chk_hide.Enabled = false;
				m_fichierSelec = null;
				return;
			}


			CHelpData.FichierLie f = (CHelpData.FichierLie)lv_fichiers.SelectedItems[0].Tag;
			chk_hide.Checked = f.Masquer;
			lnk_suppFile.Enabled = true;
			chk_hide.Enabled = true;
			m_fichierSelec = f;
		}

		private void AjouterHelpLiee(CHelpData hlp)
		{
			if (hlp == null)
			{
				CFormAlerte.Afficher("erreur chargement aide liée", EFormAlerteType.Erreur);
				return;
			}

			ListViewItem itm = new ListViewItem(hlp.Titre);
			itm.SubItems.Add(hlp.NomCourt);
			itm.SubItems.Add(hlp.TypeLiaison.ToString());
			itm.Tag = hlp;
			lv_voiraussi.Items.Add(itm);

		}

		public bool AssureSave()
		{
			if (m_bHasChange )//|| m_htmlEditor.HasChange)
				if (CFormAlerte.Afficher("Sauvegarder les modifications", EFormAlerteType.Question) == DialogResult.Yes)
					if (!Sauvegarder())
						return false;

			return true;
		}
		public bool Sauvegarder()
		{
			if(m_txtTitre.Text.Trim() == "")
				CFormAlerte.Afficher("Vous devez renseigner le Titre!", EFormAlerteType.Exclamation);
			else if (m_txtNomCourt.Text.Trim() == "")
				m_txtNomCourt.Text = m_txtTitre.Text;
			else
			{
				//m_help.TexteHTML = m_htmlEditor.DocumentHTML;
				m_help.TexteHTML = ConvertImagesFilesToRes (  );
				m_help.Titre = m_txtTitre.Text;
				m_help.VisualisationAide = m_chkAidePopup.Checked ? EVisualisationAide.Popup : EVisualisationAide.Window;
				m_help.NomCourt = m_txtNomCourt.Text;
				m_help.SizePopup = new Size((int)m_numUpSizeX.Value, (int)m_numUpSizeY.Value);
				CResultAErreur result = m_help.Save();
				if (!result)
					return result;
				m_bHasChange = false;
//				m_htmlEditor.HasChange = false;
				return true;
			}
			return false;
		}
		#endregion

		#region ** Evenements **
		#region Détection Modifs
		private void ctrl_selectLiaison_ChangementTypeLiaison(object sender, EventArgs e)
		{
			if (m_bInitialise)
				m_bHasChange = true;
		}
		private void m_txtTitre_TextChanged(object sender, EventArgs e)
		{
			if (m_bInitialise)
				m_bHasChange = true;
		}

		private void m_txtNomCourt_TextChanged(object sender, EventArgs e)
		{
			if(m_bInitialise)
				m_bHasChange = true;
		}

		private void m_txtID_TextChanged(object sender, EventArgs e)
		{
			if (m_bInitialise)
				m_bHasChange = true;
		}
		#endregion

		#region [ Ajout / Suppression ] reference voir aussi
		private void m_lnkAjouter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CFormSelectHelpPage frmSelec = new CFormSelectHelpPage();
			frmSelec.Initialiser(ETypeSelection.SelonTitre);
			frmSelec.AutoriserCreation = false;
			frmSelec.ShowDialog();

			CHelpData voiraussihelp = frmSelec.HelpSelectionne;

			if (voiraussihelp == null)
				return;

			bool endouble = false;
			foreach (CHelpData hlp in m_help.VoirAussiExplicite)
			{
				if (hlp.HelpKey == voiraussihelp.HelpKey)
				{
					CFormAlerte.Afficher("Cet élément est déjà présent", EFormAlerteType.Exclamation);
					endouble = true;
					break;
				}
			}
			if (voiraussihelp.HelpKey == m_help.HelpKey)
			{
				CFormAlerte.Afficher("Vous ne pouvez pas mettre une reference vers le même fichier", EFormAlerteType.Exclamation);
				endouble = true;
			}
			if (endouble)
				return;

			m_help.VoirAussiExplicite.Add(voiraussihelp);
			AjouterHelpLiee(voiraussihelp);
		}
		private void m_lnkSupprimer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (lv_voiraussi.SelectedItems.Count != 1)
				return;

			m_help.VoirAussiExplicite.Remove((CHelpData)lv_voiraussi.SelectedItems[0].Tag);

			lv_voiraussi.Items.RemoveAt(lv_voiraussi.SelectedItems[0].Index);

		}
		#endregion

		private void m_chkAidePopup_CheckedChanged(object sender, EventArgs e)
		{
			pan_Popup.Visible = m_chkAidePopup.Checked;
			DelaiRefreshDockStyle();
			//Actualiser affichage popup
		}


		#region Pop Up
		private void DelaiRefreshDockStyle()
		{
			m_timerRefreshDockStyle.Stop();
			m_timerRefreshDockStyle.Start();
		}
		private void m_timerRefreshDockStyle_Tick(object sender, EventArgs e)
		{
			try
			{
				m_timerRefreshDockStyle.Stop();
				if (m_chkAidePopup.Checked)
				{
					m_htmlEditor.Dock = DockStyle.None;
					m_htmlEditor.Location = new Point ( 0,0);
					m_htmlEditor.Size = new Size ((int)m_numUpSizeX.Value+4, (int)m_numUpSizeY.Value+2*30);
				}
				else
					m_htmlEditor.Dock = DockStyle.Fill;
			}
			catch
			{
			}
		}

		private void m_numUpSizeX_ValueChanged(object sender, EventArgs e)
		{
			DelaiRefreshDockStyle();
		}
		#endregion

		private void btn_changerctrl_Click(object sender, EventArgs e)
		{
			if (m_help.Controle != null)
			{
				Control ctrl = CFormSelectControl.GetControl(m_help.Controle);
				if (ctrl != null)
				{
					if (AssureSave())
					{
						m_help = CHelpData.GetHelp(ctrl, m_help.Contexte);
						Initialiser(m_help);
					}
				}
			}
		}
		#endregion

		#region Temporaire > pour afficher le fichier
		Timer m_t;
		private int _ntick;
		void t_Tick(object sender, EventArgs e)
		{
			if (_ntick > 1)
			{
				InitialiserChamps();
				m_t.Stop();
			}
			_ntick++;
		}
		#endregion

		#region >> Assesseurs <<
		public CHelpData HelpSelectionne
		{
			get
			{
				return m_help;
			}
		}
		#endregion

		#region Fichiers
		private void lv_fichiers_SelectedIndexChanged(object sender, EventArgs e)
		{
			ActualiserInfosSelectionFichier();
		}
		private void chk_hide_CheckedChanged(object sender, EventArgs e)
		{
			if(m_fichierSelec != null && lv_fichiers.SelectedItems.Count == 1)
			{
				if (((CHelpData.FichierLie)lv_fichiers.SelectedItems[0].Tag).Equals(m_fichierSelec))
				{
					m_fichierSelec.Masquer = chk_hide.Checked;
					lv_fichiers.SelectedItems[0].SubItems[3].Text = chk_hide.Checked.ToString();
				}
			}
		}
		private void lnk_suppFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (m_fichierSelec != null && lv_fichiers.SelectedItems.Count == 1)
				if (((CHelpData.FichierLie)lv_fichiers.SelectedItems[0].Tag).Equals(m_fichierSelec))
					if(m_help.SupprimerFichier(m_fichierSelec))
						lv_fichiers.Items.RemoveAt(lv_fichiers.SelectedItems[0].Index);
		}
		private void lnk_addFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if(ctrl_openFile.ShowDialog() == DialogResult.OK && File.Exists(ctrl_openFile.FileName))
			{
				CHelpData.FichierLie f = new CHelpData.FichierLie(ctrl_openFile.FileName);
				if(m_help.AjouterFichier(f))
					AjouterFichierLie(f, true);
			}
		}
		private void m_htmlEditor_AjoutFichier(object sender, EventArgs e)
		{
			InitialiserFichiers();
		}

		#endregion

		private void m_btnAddLink_Click(object sender, EventArgs e)
		{
			CFormSelectHelpPage frm = new CFormSelectHelpPage();
			frm.Initialiser(ETypeSelection.SelonTitre);
			if (frm.ShowDialog() == DialogResult.OK)
			{
				CHelpData hlp = frm.HelpSelectionne;
				if (hlp == null)
					return;
				string strHTML = m_htmlEditor.SelectedHTML;
				if (strHTML.Trim() == "")
				{
					CFormNomLien frm2 = new CFormNomLien();
					frm2.Initialiser(hlp, m_htmlEditor.SelectedText);
					frm2.ShowDialog();
					strHTML = frm2.Nom;
				}
				strHTML = "<a href=hlp://" + hlp.HelpKey + ">" + strHTML + "</a>";
				m_htmlEditor.InsertHtml(strHTML);
			}
		}


		private TabPage m_lastPage=null;
		private void m_tabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_lastPage == m_tbp_contenu || m_lastPage == null)
				m_txtHtml.Text = m_htmlEditor.BodyHtml;
			if (m_lastPage == m_tbp_HTML )
				m_htmlEditor.BodyHtml = m_txtHtml.Text;
			m_lastPage = m_tabControl.SelectedTab;
		}

		//-------------------------------------------------------------
		private void m_btnAddImage_Click(object sender, EventArgs e)
		{
			FileDialog dlg = new OpenFileDialog();
            dlg.Filter = I.T("All images|*.jpg;*.bmp;*.gif;*.tif;*.ico|Bitmap|*.bmp|Jpeg|*.jpg;*.jpeg|Gif|*.gif|Tif|*.tif|Icon|*.ico|All files|*.*|30233");
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				if (File.Exists(dlg.FileName))
				{
					CResultAErreur result = CHelpData.SourceAide.ReferenceFichier(dlg.FileName, m_help);
					if ( !result )
					{
						CFormAlerte.Afficher( result.Erreur.ToString() , EFormAlerteType.Erreur);
						return;
					}
					CRessourceFichier ressource = (CRessourceFichier)result.Data;
					m_listeRessourcesFichier.Add(ressource);
					string strImage = "<img src='File://" + ressource.NomFichierLocal + "'/>";
					m_htmlEditor.InsertHtml(strImage);
				}
			}
		}

		private bool m_bModeSelectControl = false;
		//-----------------------------------------------------------
		private void m_btnAddControlImage_Click(object sender, EventArgs e)
		{
			Control ctrl = CHelpExtender.GetLastActiveControl();
			if ( ctrl == null )
			{
				CFormAlerte.Afficher(I.T("Function not available|30015"), EFormAlerteType.Exclamation);
				return;
			}
			Form frmThis = FindForm();
			if (frmThis != null)
				frmThis.WindowState = FormWindowState.Minimized;
			//ctrl = CFormSelectControl.GetControl(ctrl);
			m_bModeSelectControl = true;
			Capture = true;
		}

		private void AddImageFromControl(Control ctrl)
		{
			try
			{
				ctrl.Refresh();
				System.Threading.Thread.Sleep(100);
				Bitmap bmp = CScreenCopieur.GetWindowImage(ctrl);
				CHelpExtender.FaireClignoterControl(m_help.Controle);
				string strFichier = "C:\\TMP.BMP";
				bmp.Save(strFichier);
				CResultAErreur result = CHelpData.SourceAide.ReferenceFichier(strFichier, m_help);
				if (!result)
				{
					CFormAlerte.Afficher(result.Erreur.ToString(), EFormAlerteType.Erreur);
					return;
				}
				CRessourceFichier ressource = (CRessourceFichier)result.Data;
				m_listeRessourcesFichier.Add(ressource);
				string strImage = "<img src='File://" + ressource.NomFichierLocal + "'/>";
				m_htmlEditor.InsertHtml(strImage);
			}
			catch
			{
				CFormAlerte.Afficher(I.T("Error while adding an image|30016"), EFormAlerteType.Erreur);
			}
		}

		private void CCtrlEditHelp_MouseUp(object sender, MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Right) == MouseButtons.Right)
			{
				m_bModeSelectControl = false;
				Capture = false;
				Form frm = FindForm();
				if (frm != null)
					frm.WindowState = FormWindowState.Normal;
			}
			if (m_bModeSelectControl && (e.Button & MouseButtons.Left) == MouseButtons.Left)
			{
				Cursor = Cursors.Help;
				Point pt = PointToScreen(new Point(e.X, e.Y));
				IntPtr ptr = GetWindowFromPoint(pt);
				try
				{
					Control ctrl = Control.FromHandle(ptr);
					if (ctrl != null)
					{
						CHelpExtender.ArreterClignotementControl();
						AddImageFromControl(ctrl);
						Capture = false;
						m_bModeSelectControl = false;
						Form frm = FindForm();
						if (frm != null)
							frm.WindowState = FormWindowState.Normal;
					}
				}
				catch
				{
				}
			}

		}

		private Control m_lastControlSelect = null;
		private void CCtrlEditHelp_MouseMove(object sender, MouseEventArgs e)
		{
			if ( m_bModeSelectControl )
			{
				Cursor = Cursors.Help;
				Point pt = PointToScreen(new Point(e.X, e.Y));
				IntPtr ptr = GetWindowFromPoint(pt);
				try
				{
					Control ctrl = Control.FromHandle(ptr);
					if (ctrl != null)
					{

						if ( ctrl != m_lastControlSelect )
						{
							CHelpExtender.ArreterClignotementControl();
							CHelpExtender.FaireClignoterControl ( ctrl );
							m_lastControlSelect = ctrl;
						}
					}
				}
				catch
				{
				}
			}
		}

		#region API Windows
		[DllImport("user32.dll")]
		private static extern int GetKeyState(int nKeyCode);
		[DllImport("user32.dll")]
		private static extern IntPtr WindowFromPoint(Point p);
		[DllImport("user32.dll")]
		private static extern IntPtr ChildWindowFromPoint(IntPtr hWndParent, Point p);
		[DllImport("user32.dll", SetLastError = true)]
		private static extern int MapWindowPoints(IntPtr hWndFrom, IntPtr hWndTo, ref Point lpPoints, uint cPoints);
		#endregion

		public static IntPtr GetWindowFromPoint(Point p)
		{
			IntPtr hWndParent = WindowFromPoint(p);

			if (hWndParent != IntPtr.Zero)
			{
				MapWindowPoints(IntPtr.Zero, hWndParent, ref p, 1);
				IntPtr hWndChild = ChildWindowFromPoint(hWndParent, p);
				while (hWndChild != null)
				{
					MapWindowPoints(hWndParent, hWndChild, ref p, 1);
					IntPtr childDeChild = ChildWindowFromPoint(hWndChild, p);
					if (childDeChild == IntPtr.Zero || childDeChild == hWndChild)
						return hWndChild;
					hWndParent = hWndChild;
					hWndChild = childDeChild;
				}
			}

			return hWndParent;
		}

	}
}
