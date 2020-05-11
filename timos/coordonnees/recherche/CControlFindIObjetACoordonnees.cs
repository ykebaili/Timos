using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using timos.securite;
using sc2i.common;
using sc2i.data;
using timos.data;
using sc2i.win32.common;

namespace timos.coordonnees
{


	public partial class CControlFindIObjetACoordonnees : UserControl, IControlALockEdition
	{


		private int m_nHauteurPanelOptions;

		private CContexteDonnee m_ctx;

		private bool m_bBoutonDeRechercheVisible;
		private bool m_bOptionsAccessibles;
        private bool m_bOptionsAfficheesAuLancement;

        private bool m_bAfficherListeResultat;
        private bool m_bOptionNavAutoToOneResult;

        private IObjetACoordonnees m_objetRacine;
        private EObjetACoordonnee m_criteresRecherche;

		public bool AfficherListeResultat
		{
			get
			{
                return m_bAfficherListeResultat;
			}
			set
			{
				m_bAfficherListeResultat = value;
			}
		}

        public bool NaviguerAutomatiquementVersResultatUnique
        {
            get
            {
                return m_bOptionNavAutoToOneResult;
            }
            set
            {
                m_bOptionNavAutoToOneResult = value;
            }
        }


		public bool BoutonOptionsVisible
		{
			get
			{
				return m_bOptionsAccessibles;
			}
			set
			{
				m_bOptionsAccessibles = value;
			}
		}


		public bool OptionsAfficheesAuLancement
		{
			get
			{
				return m_bOptionsAfficheesAuLancement;
			}
			set
			{
				m_bOptionsAfficheesAuLancement = value;
			}
		}


		public bool BoutonDeRechercheVisible
		{
			get
			{
				return m_bBoutonDeRechercheVisible;
			}
			set
			{
				m_bBoutonDeRechercheVisible = value;
			}
		}

		//Editeur personnaliser à implémenter
		public EObjetACoordonnee CriteresRecherche
		{
			get
			{
				return m_criteresRecherche;
			}
			set
			{
				m_criteresRecherche = value;
			}
		}


        public string CoordonneeDeBase
        {
            set 
            {
                m_txtBoxCoordonnee.Text = value;
            }
        }
        
		public CControlFindIObjetACoordonnees()
		{
            InitializeComponent();
            m_nHauteurPanelOptions = m_panelOptions.Height;
        }

        private void RecalcSize()
        {
            
        }

		public void Init(CContexteDonnee contexteFonctionnement,IObjetACoordonnees objetRacine, EObjetACoordonnee critere)
		{
            
            m_objetRacine = objetRacine;

			m_ctx = contexteFonctionnement;
			m_txtBoxCoordonnee.ForeColor = Color.Blue;
			m_chklstCriteres.SetItemChecked(0, true);
			m_chklstCriteres.SetItemChecked(1, true);
			m_chklstCriteres.SetItemChecked(2, true);
			m_chklstCriteres.SetItemChecked(3, true);

		}


		private void VerifierCooherenceCoor()
		{
			if (m_txtBoxCoordonnee.Text.Length > 0)
			{
				string coor = m_txtBoxCoordonnee.Text;
				char caracSeparateur = CSystemeCoordonnees.c_separateurNumerotations;

				ActualiserToolTip("");

				if (coor.Substring(0, 1) == caracSeparateur.ToString())
					ActualiserToolTip(I.T("The coordinate cannot begin by a separator|30118"));
				else if (coor.Substring(coor.Length - 1, 1) == caracSeparateur.ToString())
					ActualiserToolTip(I.T("The coordinate seems to be incomplete because it ends with a separator|30119"));
				else
				{
					string[] levels = coor.Split(caracSeparateur.ToString().ToCharArray(), StringSplitOptions.None);
					foreach (string lv in levels)
					{
						if (lv == "" || lv == null)
						{
							ActualiserToolTip(I.T("The coordinate cannot include empty levels|30120"));
							break;
						}
					}
				}
			}
		}

		private void ActualiserToolTip(string messageErr)
		{
			if (messageErr == "")
			{
				m_tooltip.Active = false;
				m_txtBoxCoordonnee.ForeColor = Color.Blue;
			}
			else
			{
				m_tooltip.Active = true;
				m_tooltip.SetToolTip(m_txtBoxCoordonnee, messageErr);
				m_txtBoxCoordonnee.ForeColor = Color.Red;
			}
		}

		private void m_txtBoxCoordonnee_TextChanged(object sender, EventArgs e)
		{
			VerifierCooherenceCoor();
		}

		public List<IObjetACoordonnees> GetResultatsRecherche()
		{

			m_criteresRecherche = 0;
			if (m_chklstCriteres.GetItemChecked(0))
                m_criteresRecherche = m_criteresRecherche | EObjetACoordonnee.EntiteOrganisationnelle;
			if (m_chklstCriteres.GetItemChecked(1))
                m_criteresRecherche = m_criteresRecherche | EObjetACoordonnee.Site;
			if (m_chklstCriteres.GetItemChecked(2))
                m_criteresRecherche = m_criteresRecherche | EObjetACoordonnee.Stock;
			if (m_chklstCriteres.GetItemChecked(3))
                m_criteresRecherche = m_criteresRecherche | EObjetACoordonnee.Equipement;

            if (m_criteresRecherche == 0)
			{
				CFormAlerte.Afficher(I.T("You must select at least one research domain|30121"), EFormAlerteType.Exclamation);
				return null;
			}
			if (m_txtBoxCoordonnee.Text == "" || m_txtBoxCoordonnee.Text == null)
			{
				CFormAlerte.Afficher(I.T("You must enter a coordinate|30122"), EFormAlerteType.Exclamation);
				return null;
			}


            List<IObjetACoordonnees> lstResult = CUtilObjetACoordonnees.FindObjetsACoordonnees(m_txtBoxCoordonnee.Text.ToUpper(), m_criteresRecherche, m_objetRacine, m_ctx);
			return lstResult;
		}

        public event EventHandler OnButonSearcheClick;
		private void m_btnSearch_Click(object sender, EventArgs e)
		{
            
            if (OnButonSearcheClick != null)
                OnButonSearcheClick(this, new EventArgs());

            List<IObjetACoordonnees> lstResult = GetResultatsRecherche();
            if (lstResult == null)
                return;

            int nResult = lstResult.Count;
            if (nResult == 0)
                CFormAlerte.Afficher(I.T("No element corresponds to this coordinate|30123"), EFormAlerteType.Exclamation);
            else if (AfficherListeResultat)
                CFormFloatResultIObjetACoordonnees.AfficherResultats(lstResult);
            else if (nResult == 1 && NaviguerAutomatiquementVersResultatUnique)
                CFormFloatResultIObjetACoordonnees.NaviguerVersObjetACoordonnee(lstResult[0]);
 

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

		private void CControlFindIObjetACoordonnees_Load(object sender, EventArgs e)
		{
            sc2i.win32.common.CWin32Traducteur.Translate(this);

            m_btnSearche.Visible = BoutonDeRechercheVisible;
            m_btnOptions.Visible = BoutonOptionsVisible;

            m_chkAfficherResultat.Checked = AfficherListeResultat;
            m_chkNavigAutoToOnetResult.Checked = NaviguerAutomatiquementVersResultatUnique;

            m_panelOptions.Visible = OptionsAfficheesAuLancement;

            UpdateVisu();

		}

        //--------------------------------------------------------------------------
        private void m_btnOptions_Click(object sender, EventArgs e)
        {
            m_panelOptions.Visible = !m_panelOptions.Visible;
            UpdateVisu();
        }

        //--------------------------------------------------------------------------
        private void UpdateVisu()
        {
            if (m_panelOptions.Visible)
            {
                m_btnOptions.Text = "/\\";
                Height = m_panelSearche.Height + m_nHauteurPanelOptions;
            }
            else
            {
                m_btnOptions.Text = "\\/";
                Height = m_panelSearche.Height;
            }
        }

        //------------------------------------------------------------------------------
        private void m_chkAfficherResultat_CheckedChanged(object sender, EventArgs e)
        {
            AfficherListeResultat = m_chkAfficherResultat.Checked;
            m_chkNavigAutoToOnetResult.Enabled = m_chkAfficherResultat.Checked;

        }

        //------------------------------------------------------------------------------
        private void m_chkNavigAutoToOnetResult_CheckedChanged(object sender, EventArgs e)
        {
            NaviguerAutomatiquementVersResultatUnique = m_chkNavigAutoToOnetResult.Checked;
        }

	}


}
