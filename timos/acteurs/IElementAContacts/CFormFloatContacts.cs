using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.win32.common;
using timos.data;

namespace timos.acteurs
{
	public partial class CFormFloatContacts : CFloatingFormBase
	{
		private bool m_bInitialise = false;
		private IElementAContacts m_elemAActeursPoss = null;
		
		protected CFormFloatContacts()
		{
			m_bInitialise = false;
			InitializeComponent();
			m_ctrlContacts.ChangementTailleAffichage += new EventHandler(CFormFloatContactsPhase_ChangementTailleControle);
			
		}



		public static void AfficherContacts(IElementAContacts elemAActeursPoss)
		{
			CFormFloatContacts frm = new CFormFloatContacts();

			frm.m_elemAActeursPoss = elemAActeursPoss;
			frm.Show();

		}

		private void CFormFloatContactsPhase_Load(object sender, EventArgs e)
		{
			m_diffOmbreLargeur = m_panOmbre.Width - m_panConteneur.Width;
			m_diffOmbreHauteur = m_panOmbre.Height - m_panConteneur.Height;
			m_txtErr.Visible = false;
			m_ctrlContacts.m_frmConteneur = this;
			if(m_elemAActeursPoss.TypeElementAContactPossible != null)
				m_ctrlContacts.Init(m_elemAActeursPoss);
			else 
			{
				Close();
				return;
			}

			m_panConteneur.Size = new Size(m_ctrlContacts.LargeurOptimale, m_ctrlContacts.HauteurOptimale + 2);
			Size = new Size(m_ctrlContacts.LargeurOptimale + m_diffOmbreLargeur, m_ctrlContacts.HauteurOptimale + m_diffOmbreHauteur + 2);
			AjustePosition();
			
			m_ctrlContacts.Dock = DockStyle.Fill;

			if (m_ctrlContacts.RienAAfficher)
			{
				m_txtErr.Text = m_ctrlContacts.MessageErreur;
				m_ctrlContacts.Visible = false;
				m_txtErr.Visible = true;
				m_txtErr.Enabled = false;
				m_txtErr.Dock = DockStyle.Fill;
				m_panConteneur.Size = new Size(284, 54);
				Size = new Size(300, 60);
			}
			m_bInitialise = true;
		}

		private void AjustePosition()
		{
			if (Location.X + Size.Width > Screen.PrimaryScreen.WorkingArea.Width)
				Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Size.Width, Location.Y);
			if (Location.Y + Size.Height > Screen.PrimaryScreen.WorkingArea.Height)
				Location = new Point(Location.X, Screen.PrimaryScreen.WorkingArea.Height - Size.Height);

		}

		private int m_diffOmbreLargeur;
		private int m_diffOmbreHauteur;

		void CFormFloatContactsPhase_ChangementTailleControle(object sender, EventArgs e)
		{
			if (m_bInitialise)
			{
				m_panConteneur.Size = new Size(m_ctrlContacts.LargeurOptimale, m_ctrlContacts.HauteurOptimale);
				Size = new Size(m_ctrlContacts.LargeurOptimale + m_diffOmbreLargeur, m_ctrlContacts.HauteurOptimale + m_diffOmbreHauteur);
				AjustePosition();
			}
		}
	}
}