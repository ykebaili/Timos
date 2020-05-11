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
using timos.data.coordonnees;

namespace timos.coordonnees
{
	public partial class CControlEditeCoordonnee : UserControl, IControlALockEdition
	{
		private IObjetAFilsACoordonnees m_parent = null;
		private IObjetACoordonnees m_fils = null;
		private string m_strCoorBase = "";


		//------------------------------------------------
		public CControlEditeCoordonnee()
		{
			InitializeComponent();
		}

		//------------------------------------------------
		public void Init(IObjetAFilsACoordonnees parent, IObjetACoordonnees fils)
		{
			m_parent = parent;
            if (parent != null)
            {
                EOptionControleCoordonnees? option = parent.OptionsControleCoordonneesApplique;
                if (option == null)
                    option = COptionCoordonnéeGlobale.GetOptionType(fils.ContexteDonnee.IdSession, parent.GetType());
                if (!SObjetAvecFilsAvecCoordonnees.IsAppliquable(option.Value, fils))
                    LockEdition = true;
                else
                    LockEdition = !m_gestionnaireModeEdition.ModeEdition;
            }

			m_fils = fils;
			m_strCoorBase = fils.CoordonneeParente;
			if (m_strCoorBase.Length > 0)
				m_strCoorBase += CSystemeCoordonnees.c_separateurNumerotations;
			m_txtDebut.Text = m_strCoorBase;
            m_txtDebut.LockEdition = true;
            m_txtBoxCoordonnee.Text = fils.Coordonnee;
            
			VerifieDonnees();

		}

		//------------------------------------------------
		public string Coordonnee
		{
			get
			{
				return m_txtBoxCoordonnee.Text;
			}
			set
			{
				m_txtBoxCoordonnee.Text = value; ;
			}
		}

		//------------------------------------------------
		private void m_txtBoxCoordonnee_TextChanged(object sender, EventArgs e)
		{
			DiffereVerifieDonnees();
		}

		//------------------------------------------------
		private void InitToolTip()
		{
			string strAide = "";
			if (m_parent != null && m_parent.ParametrageCoordonneesApplique != null)
			{
				CParametrageSystemeCoordonnees parametrage = m_parent.ParametrageCoordonneesApplique;

				if (parametrage != null)
				{
					strAide = parametrage.SystemeCoordonnees.Libelle;
					List<CParametrageNiveau> lst = new List<CParametrageNiveau>();
					foreach (CParametrageNiveau parametrageNiveau in parametrage.RelationParametragesNiveau)
						lst.Add(parametrageNiveau);
					lst.Sort(new CParametrageNiveauPositionComparer());
					foreach (CParametrageNiveau param in lst)
					{
						strAide += "\r\n-" + param.Libelle + " (" + param.FormatNumerotation.Libelle + ")";
					}
				}
			}
			m_tooltip.SetToolTip(m_txtBoxCoordonnee, strAide);
		}
		//------------------------------------------------
		private void VerifieDonnees()
		{
			m_timerVerification.Enabled = false;
			int nSel = m_txtBoxCoordonnee.SelectionStart;
			//int nSelLength = m_txtBoxCoordonnee.SelectionLength;
			m_txtBoxCoordonnee.Text = m_txtBoxCoordonnee.Text.ToUpper();
            try
            {
                m_txtBoxCoordonnee.SelectionStart = nSel;
                //m_txtBoxCoordonnee.SelectionLength = nSelLength;
            }
            catch
            {
            }

			CResultAErreur result = CResultAErreur.True;
			if (m_parent != null)
			{
				result = m_parent.IsCoordonneeValide(Coordonnee, m_fils);
				if (!result)
				{
					m_txtBoxCoordonnee.BackColor = Color.Red;
					m_tooltip.SetToolTip(m_txtBoxCoordonnee, result.Erreur.ToString());
				}
				else
				{
					InitToolTip();
					m_txtBoxCoordonnee.BackColor = Color.White;
				}
			}
		}

		//------------------------------------------------
		private void m_btnAide_Click(object sender, EventArgs e)
		{
			Point pt = PointToScreen(m_txtBoxCoordonnee.Location);
			string strCoord = m_txtBoxCoordonnee.Text;
			if (timos.coordonnees.CFormPopupSaisieCoordonnee.EditeCoordonnee(
				pt,
				m_parent,
				m_fils,
				ref strCoord))
				m_txtBoxCoordonnee.Text = strCoord;
		}

		//------------------------------------------------
		public override void Refresh()
		{
			DiffereVerifieDonnees();
		}

		//------------------------------------------------
		private void DiffereVerifieDonnees()
		{
			m_timerVerification.Enabled = false;
			m_timerVerification.Enabled = true;
		}

		//------------------------------------------------
		private void m_timerVerification_Tick(object sender, EventArgs e)
		{
			m_timerVerification.Enabled = false;
			VerifieDonnees();
		}




		#region IControlALockEdition Membres

		public bool LockEdition
		{
			get
			{
				return !m_gestionnaireModeEdition.ModeEdition;
			}
			set
			{
				m_gestionnaireModeEdition.ModeEdition = !value;
				if (OnChangeLockEdition != null)
					OnChangeLockEdition(this, new EventArgs());
			}
		}

		public event EventHandler OnChangeLockEdition;

		#endregion

		private bool m_bIsPopingUp = false;
		private void m_tooltip_Popup(object sender, PopupEventArgs e)
		{
			if (m_bIsPopingUp)
				return;
			m_bIsPopingUp = true;
			Point pt = m_txtBoxCoordonnee.Location;
			pt.Y += m_txtBoxCoordonnee.Height-2;
			pt = m_txtBoxCoordonnee.Parent.PointToScreen ( pt );
			Cursor.Position = pt;
			m_tooltip.SetToolTip ( e.AssociatedControl, m_tooltip.GetToolTip ( e.AssociatedControl ));
			m_bIsPopingUp = false;
		}
        
	}
}
