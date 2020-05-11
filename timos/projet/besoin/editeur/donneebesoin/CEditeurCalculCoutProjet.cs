using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.common.unites;
using sc2i.common;
using timos.data.projet.besoin;

namespace timos.projet.besoin
{
    [AutoExec("Autoexec")]
    public partial class CEditeurCalculCoutProjet : UserControl, IEditeurDonneeBesoin
    {
        private CDonneeBesoinProjet m_donneeProjet = null;
        private CBesoin m_besoin = null;
        
        //-----------------------------------------------
        public CEditeurCalculCoutProjet()
        {
            InitializeComponent();
            sc2i.win32.common.CWin32Traducteur.Translate(this);
        }

        //-----------------------------------------------
        public static void Autoexec()
        {
            CAllocateurEditeurDonneeBesoin.RegisterEditeur(
                ETypeEditeurBesoin.EditeurCout, 
                typeof(CDonneeBesoinProjet), 
                typeof(CEditeurCalculCoutProjet));
        }

        //-----------------------------------------------
        public IDonneeBesoin DonneeBesoin
        {
            get
            {
                return m_donneeProjet;
            }
        }

        //-----------------------------------------------
        private bool m_bIsInitializing = false;
        public void Init(IDonneeBesoin calcul, CBesoin besoin, CItemBesoin itemBesoin, IEnumerable<CItemBesoin> items)
        {
            m_bIsInitializing = true;
            m_donneeProjet = calcul as CDonneeBesoinProjet;
            m_besoin = besoin;
            if ( m_donneeProjet != null )
            {
                if (!besoin.HasChildren)
                {
                    m_txtCoutUnitaire.Visible = true;
                    m_txtCoutUnitaire.DoubleValue = m_donneeProjet.CoutSaisi;
                }
                else
                    m_txtCoutUnitaire.Visible = false;
            }
            m_bIsInitializing = false;
        }

        

        //-----------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_donneeProjet != null)
            {
                if (!m_besoin.HasChildren)
                    m_donneeProjet.CoutSaisi = m_txtCoutUnitaire.DoubleValue;
            }
            return result;
        }

        //------------------------------------------------------------------------
        public event EventHandler OnCoutChanged;


        //-----------------------------------------------
        private void m_txtCoutUnitaire_Validated(object sender, EventArgs e)
        {
            if (!m_bIsInitializing)
            {
                MajChamps();
                DeclencheOnCoutChanged();
            }
        }

       

        //-----------------------------------------------
        private void DeclencheOnCoutChanged()
        {
            if (OnCoutChanged != null)
            {
                MajChamps();
                OnCoutChanged(this, null);
            }
        }


        //------------------------------
        public bool LockEdition
        {
            get
            {
                return !m_extModeEdition.ModeEdition;
            }
            set
            {
                m_extModeEdition.ModeEdition = !value;
                if (OnChangeLockEdition != null)
                    OnChangeLockEdition(this, null);
            }
        }

        //------------------------------
        public event EventHandler OnChangeLockEdition;

       
        public event EventHandler OnDataChanged;

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (OnDataChanged != null)
                OnDataChanged(this, null);
        }

        //------------------------------------------------------------------------
        public void RefreshFromExternalChangeOnDonnee()
        {
        }


        
    }
}
