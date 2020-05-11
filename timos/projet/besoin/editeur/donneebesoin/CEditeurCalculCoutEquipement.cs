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
    public partial class CEditeurCalculCoutEquipement : UserControl, IEditeurDonneeBesoin
    {
        private CDonneeBesoinTypeEquipement m_donneeEquipement = null;
        private CBesoin m_besoin = null;
        
        //-----------------------------------------------
        public CEditeurCalculCoutEquipement()
        {
            InitializeComponent();
            sc2i.win32.common.CWin32Traducteur.Translate(this);
        }

        //-----------------------------------------------
        public static void Autoexec()
        {
            CAllocateurEditeurDonneeBesoin.RegisterEditeur(
                ETypeEditeurBesoin.EditeurCout, 
                typeof(CDonneeBesoinTypeEquipement), 
                typeof(CEditeurCalculCoutEquipement));
        }

        //-----------------------------------------------
        public IDonneeBesoin DonneeBesoin
        {
            get
            {
                return m_donneeEquipement;
            }
        }

        //-----------------------------------------------
        private bool m_bIsInitializing = false;
        public void Init(IDonneeBesoin calcul, CBesoin besoin, CItemBesoin itemBesoin, IEnumerable<CItemBesoin> items)
        {
            m_bIsInitializing = true;
            m_besoin = besoin;
            m_donneeEquipement = calcul as CDonneeBesoinTypeEquipement;
            if ( m_donneeEquipement != null )
            {
                Visible = true;
                FillFromDonnee();
                
            }
            m_bIsInitializing = false;
        }

        private void FillFromDonnee()
        {
            if (m_donneeEquipement == null)
                return;
            m_txtQuantité.IntValue = m_donneeEquipement.Quantite;
            if (m_donneeEquipement.Quantite < 0)
                m_txtQuantité.BackColor = Color.Red;
            else
                m_txtQuantité.BackColor = Color.White;
            if (m_donneeEquipement.CoutUnitaire != null)
            {
                m_txtCoutUnitaire.DoubleValue = m_donneeEquipement.CoutUnitaire;
            }
            else
                m_txtCoutUnitaire.DoubleValue = null;
            UpdateImageVerrou();
            m_txtCoutUnitaire.LockEdition = LockEdition | m_donneeEquipement.IsCoutTarif;
        }


        //-----------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_donneeEquipement != null)
            {
                m_donneeEquipement.Quantite = m_txtQuantité.IntValue == null?1:m_txtQuantité.IntValue.Value;
                if (!m_donneeEquipement.IsCoutTarif)
                    m_donneeEquipement.CoutUnitaire = m_txtCoutUnitaire.DoubleValue;
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
            if (m_donneeEquipement != null)
            {
                m_btnCoutVerrouillé.Image = m_donneeEquipement.IsCoutTarif ?
                        Resources.lock_padlock :
                        Resources.lock_unlock;
            }
        }

        //------------------------------------------------------------
        private void m_btnCoutVerrouillé_Click(object sender, EventArgs e)
        {
            if ( m_donneeEquipement != null && !LockEdition)
            {
                m_donneeEquipement.IsCoutTarif = !m_donneeEquipement.IsCoutTarif;
                if (m_donneeEquipement.IsCoutTarif)
                {
                    m_txtCoutUnitaire.LockEdition = true;
                    m_donneeEquipement.SetTypeEquipement(m_donneeEquipement.GetTypeEquipement(m_besoin.ContexteDonnee));
                    m_txtCoutUnitaire.DoubleValue = m_donneeEquipement.CoutUnitaire;
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
            if (m_donneeEquipement != null &&
                !m_donneeEquipement.IsCoutTarif && OnCoutChanged != null)
            {
                MajChamps();
                DeclencheOnCoutChanged();
            }
        }

        //------------------------------------------------------------------------
        public void RefreshFromExternalChangeOnDonnee()
        {
            m_bIsInitializing = true;
            if (m_donneeEquipement != null)
                FillFromDonnee();
            m_bIsInitializing = false;
        }


        
    }
}
