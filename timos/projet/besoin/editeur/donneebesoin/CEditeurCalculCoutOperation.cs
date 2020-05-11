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
using timos.Properties;

namespace timos.projet.besoin
{
    [AutoExec("Autoexec")]
    public partial class CEditeurCalculCoutOperation : UserControl, IEditeurDonneeBesoin
    {
        private CDonneeBesoinTypeOperation m_donneeOperation = null;
        private CBesoin m_besoin = null;
        
        //-----------------------------------------------
        public CEditeurCalculCoutOperation()
        {
            InitializeComponent();
            sc2i.win32.common.CWin32Traducteur.Translate(this);
        }

        //-----------------------------------------------
        public static void Autoexec()
        {
            CAllocateurEditeurDonneeBesoin.RegisterEditeur(
                ETypeEditeurBesoin.EditeurCout, 
                typeof(CDonneeBesoinTypeOperation), 
                typeof(CEditeurCalculCoutOperation));
        }

        //-----------------------------------------------
        public IDonneeBesoin DonneeBesoin
        {
            get
            {
                return m_donneeOperation;
            }
        }

        //-----------------------------------------------
        private bool m_bIsInitializing = false;
        public void Init(IDonneeBesoin calcul, CBesoin besoin, CItemBesoin itemBesoin, IEnumerable<CItemBesoin> items)
        {
            m_bIsInitializing = true;
            m_besoin = besoin;
            m_donneeOperation = calcul as CDonneeBesoinTypeOperation;
            if ( m_donneeOperation != null )
            {
                Visible = true;
                FillFromDonnee();
                
            }
            m_bIsInitializing = false;
        }

        private void FillFromDonnee()
        {
            if (m_donneeOperation == null)
                return;
            m_txtQuantité.IntValue = m_donneeOperation.Quantite;
            if (m_donneeOperation.CoutUnitaire != null)
            {
                m_txtCoutUnitaire.DoubleValue = m_donneeOperation.CoutUnitaire;
            }
            else
                m_txtCoutUnitaire.DoubleValue = null;
            UpdateImageVerrou();
            m_txtCoutUnitaire.LockEdition = LockEdition | m_donneeOperation.IsCoutTarif;
        }


        //-----------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_donneeOperation != null)
            {
                m_donneeOperation.Quantite = m_txtQuantité.IntValue == null?1:m_txtQuantité.IntValue.Value;
                if (!m_donneeOperation.IsCoutTarif)
                    m_donneeOperation.CoutUnitaire = m_txtCoutUnitaire.DoubleValue;
            }
            return result;
        }

        //------------------------------------------------------------------------
        public event EventHandler OnCoutChanged;

        //------------------------------------------------------------------------
        private void m_txtQuantité_Validated(object sender, EventArgs e)
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

        //------------------------------
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (OnDataChanged != null)
                OnDataChanged(this, null);
        }

        //------------------------------------------------------------
        private void UpdateImageVerrou()
        {
            if (m_donneeOperation != null)
            {
                m_btnCoutVerrouillé.Image = m_donneeOperation.IsCoutTarif ?
                        Resources.lock_padlock :
                        Resources.lock_unlock;
            }
        }

        //------------------------------------------------------------
        private void m_btnCoutVerrouillé_Click(object sender, EventArgs e)
        {
            if ( m_donneeOperation != null && !LockEdition)
            {
                m_donneeOperation.IsCoutTarif = !m_donneeOperation.IsCoutTarif;
                if (m_donneeOperation.IsCoutTarif)
                {
                    m_txtCoutUnitaire.LockEdition = true;
                    m_donneeOperation.SetTypeOperation(m_donneeOperation.GetTypeOperation(m_besoin.ContexteDonnee));
                    m_txtCoutUnitaire.DoubleValue = m_donneeOperation.CoutUnitaire;
                    if (OnCoutChanged != null)
                        OnCoutChanged(this, null);
                }
                else
                {
                    m_txtCoutUnitaire.LockEdition = false;
                }
                UpdateImageVerrou();
            }
        }

        //----------------------------------------------------------------------
        private void m_txtCoutUnitaire_Validated(object sender, EventArgs e)
        {
            if (m_donneeOperation != null &&
                !m_donneeOperation.IsCoutTarif && OnCoutChanged != null)
            {
                MajChamps();
                DeclencheOnCoutChanged();
            }
        }

        //------------------------------------------------------------------------
        public void RefreshFromExternalChangeOnDonnee()
        {
            m_bIsInitializing = true;
            if (m_donneeOperation != null)
                FillFromDonnee();
            m_bIsInitializing = false;
        }


        
    }
}
