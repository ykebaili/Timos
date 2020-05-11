using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using timos.data.projet.besoin;
using sc2i.common;
using System.Collections;
using timos.Properties;
using timos.data;

namespace timos.projet.besoin
{

    public partial class CcontroleResumeElementACout : UserControl
    {
        private IResumeurDeCouts m_resumeur = null;


        public CcontroleResumeElementACout()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------
        public IDonneeBesoin DonneeBesoin
        {
            get { return null ; }
        }

        //-------------------------------------------------------
        private bool m_bIsInitializing = false;
        public void Init(IResumeurDeCouts resumeur)
        {
            CPhaseSpecifications phase = resumeur as CPhaseSpecifications;
            if (phase != null && phase.Projet != null)
                resumeur = phase.Projet;
            m_resumeur = resumeur;
            FillDatas();
        }

        //-------------------------------------------------------
        private void FillDatas()
        {
            m_bIsInitializing = true;

            if (m_resumeur != null)
            {

                double fCoutPrevisionnel = m_resumeur.GetCoutResume(false);
                double fCoutReel = m_resumeur.GetCoutResume(true);
                /*foreach (IElementACout elt in CUtilElementACout.GetElementsACoutFinaux(m_resumeur, false))
                    fCoutPrevisionnel += elt.CoutPrevisionnel;
                foreach ( IElementACout elt in CUtilElementACout.GetElementsACoutFinaux(m_resumeur, true ))
                    fCoutReel += elt.CoutReel;*/

              
                /*CUtilElementACout.RecalculeCoutDescendant(m_resumeur, true, false, null);
                CUtilElementACout.RecalculeCoutDescendant(m_resumeur, false, false, null);
                m_txtCoutReel.DoubleValue = m_resumeur.CoutReel;
                m_txtCoutCalculé.DoubleValue = m_resumeur.CoutPrevisionnel;*/
                m_txtCoutReel.DoubleValue = fCoutReel;
                m_txtCoutCalculé.DoubleValue = fCoutPrevisionnel;
                CPhaseSpecifications phase = m_resumeur as CPhaseSpecifications;
                if (m_resumeur is CProjet)
                    phase = ((CProjet)m_resumeur).Specifications;
                if (phase != null)
                {
                    m_txtCoutSaisi.DoubleValue = phase.CoutSaisi;
                    m_panelSaisi.Visible = true;
                }
                else
                    m_panelSaisi.Visible = false;
                m_lblRegroupement.Text = m_resumeur.Libelle;
            }
            else
            {
                m_txtCoutCalculé.DoubleValue = 0;
                m_txtCoutReel.DoubleValue = 0;
                m_txtCoutSaisi.IntValue  = 0;
            }
            m_bIsInitializing = false;
        }

        //-------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            return CResultAErreur.True;
        }

        //-------------------------------------------------------
        public event EventHandler OnCoutChanged;

        public event EventHandler OnDataChanged;

        //-------------------------------------------------------
        public void RefreshFromExternalChangeOnDonnee()
        {
            
        }

        //-------------------------------------------------------
        public bool LockEdition
        {
            get
            {
                return !m_extModeEdition.ModeEdition;
            }
            set
            {
                m_extModeEdition.ModeEdition = !value;
                if ( OnChangeLockEdition != null )
                    OnChangeLockEdition(this, null );
            }
        }

        public event EventHandler OnChangeLockEdition;

        private void m_picInfoCalculPrévisionnel_Click(object sender, EventArgs e)
        {
            new CUtilMenuElementACout().ShowMenuDetailCalcul(
                m_resumeur,
                null,
                m_menuDetailCoutCalculé,
                false,
                m_picInfoCalculPrévisionnel);
        }

        private void m_picInfoCoutReel_Click(object sender, EventArgs e)
        {
            new CUtilMenuElementACout().ShowMenuDetailCalcul(
                m_resumeur,
                null,
                m_menuDetailCoutCalculé,
                true,
                m_picInfoCoutReel);
        }


       

        
            
    }
}
