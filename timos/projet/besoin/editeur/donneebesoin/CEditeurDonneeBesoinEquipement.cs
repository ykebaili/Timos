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
using timos.data;

namespace timos.projet.besoin
{
    [AutoExec("Autoexec")]
    public partial class CEditeurDonneeBesoinEquipement : UserControl, IEditeurDonneeBesoin
    {
        private CDonneeBesoinTypeEquipement m_donneeEquipement = null;
        private CBesoin m_besoin = null;
        
        //-----------------------------------------------
        public CEditeurDonneeBesoinEquipement()
        {
            InitializeComponent();
            sc2i.win32.common.CWin32Traducteur.Translate(this);
        }

        //-----------------------------------------------
        public static void Autoexec()
        {
            CAllocateurEditeurDonneeBesoin.RegisterEditeur(
                ETypeEditeurBesoin.EditeurDonnees, 
                typeof(CDonneeBesoinTypeEquipement), 
                typeof(CEditeurDonneeBesoinEquipement));
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
            m_donneeEquipement = calcul as CDonneeBesoinTypeEquipement;
            m_besoin = besoin;
            if ( m_donneeEquipement != null )
            {
                Visible = true;
                m_txtSelectTypeEquipement.Init(typeof(CTypeEquipement),
                    "Libelle", false);
                m_txtSelectTypeEquipement.ElementSelectionne = m_donneeEquipement.GetTypeEquipement(besoin.ContexteDonnee);
            }
            m_bIsInitializing = false;
        }

        //-----------------------------------------------
        private CControleBesoin ControleBesoin
        {
            get
            {
                Control parent = Parent;
                while (parent != null && !(parent is CControleBesoin))
                    parent = parent.Parent;
                return parent as CControleBesoin;
            }
        }


        //-----------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_donneeEquipement != null)
            {
                CTypeEquipement tpOld = m_donneeEquipement.GetTypeEquipement(m_besoin.ContexteDonnee);
                CTypeEquipement tpNew = m_txtSelectTypeEquipement.ElementSelectionne as CTypeEquipement;
                CControleBesoin ctrlBesoin = ControleBesoin;
                if ( ctrlBesoin != null )
                {
                    if ((tpOld == null || ctrlBesoin.LibelleBesoin.ToUpper() == tpOld.Libelle.ToUpper() || ctrlBesoin.LibelleBesoin.Trim().Length == 0))
                    {
                        if (tpNew != null)
                            ctrlBesoin.LibelleBesoin = tpNew.Libelle;
                        else
                            ctrlBesoin.LibelleBesoin = "";
                    }
                }
                m_donneeEquipement.SetTypeEquipement(tpNew);
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

        //------------------------------------------------------------------------
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (OnDataChanged != null)
                OnDataChanged(this, null);
        }

        //------------------------------------------------------------------------
        private void m_txtSelectTypeEquipement_ElementSelectionneChanged(object sender, EventArgs e)
        {
            if (!m_bIsInitializing)
            {
                MajChamps();
                if (OnCoutChanged != null)
                    OnCoutChanged(this, null);
                if (OnDataChanged != null)
                    OnDataChanged(this, null);
            }
        }

        //------------------------------------------------------------------------
        public void RefreshFromExternalChangeOnDonnee()
        {
            m_bIsInitializing = true;
            if ( m_besoin != null && m_donneeEquipement != null )
                m_txtSelectTypeEquipement.ElementSelectionne = m_donneeEquipement.GetTypeEquipement(m_besoin.ContexteDonnee);
            m_bIsInitializing = false;
        }

        
    }
}
