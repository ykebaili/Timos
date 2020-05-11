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
using sc2i.data;

namespace timos.projet.besoin
{
    [AutoExec("Autoexec")]
    public partial class CEditeurDonneeBesoinOperation : UserControl, IEditeurDonneeBesoin
    {
        private CDonneeBesoinTypeOperation m_donneeOperation = null;
        private CBesoin m_besoin = null;
        
        //-----------------------------------------------
        public CEditeurDonneeBesoinOperation()
        {
            InitializeComponent();
            sc2i.win32.common.CWin32Traducteur.Translate(this);
        }

        //-----------------------------------------------
        public static void Autoexec()
        {
            CAllocateurEditeurDonneeBesoin.RegisterEditeur(
                ETypeEditeurBesoin.EditeurDonnees, 
                typeof(CDonneeBesoinTypeOperation), 
                typeof(CEditeurDonneeBesoinOperation));
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
            m_donneeOperation = calcul as CDonneeBesoinTypeOperation;
            m_besoin = besoin;
            if ( m_donneeOperation != null )
            {
                Visible = true;
                CFiltreData filtre = null;
                if (besoin.BesoinParent != null && besoin.BesoinParent.TypeOperation != null)
                {
                    filtre = new CFiltreData(CTypeOperation.c_champIdOperationParente + "=@1",
                        besoin.BesoinParent.TypeOperation.Id);
                }
                m_txtSelectTypeOperation.InitAvecFiltreDeBase(typeof(CTypeOperation),
                    "LibelleComplet", filtre, false);
                m_txtSelectTypeOperation.ElementSelectionne = m_donneeOperation.GetTypeOperation(besoin.ContexteDonnee);
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
            if (m_donneeOperation != null)
            {
                CTypeOperation tpOld = m_donneeOperation.GetTypeOperation(m_besoin.ContexteDonnee);
                CTypeOperation tpNew = m_txtSelectTypeOperation.ElementSelectionne as CTypeOperation;
                CControleBesoin ctrlBesoin = ControleBesoin;
                if ( ctrlBesoin != null )
                {
                    if ((tpOld == null || ctrlBesoin.LibelleBesoin.ToUpper() == tpOld.LibelleComplet.ToUpper() || ctrlBesoin.LibelleBesoin.Trim().Length == 0))
                    {
                        if (tpNew != null)
                            ctrlBesoin.LibelleBesoin = tpNew.LibelleComplet;
                        else
                            ctrlBesoin.LibelleBesoin = "";
                    }
                }
                m_donneeOperation.SetTypeOperation(tpNew);
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
        private void m_txtSelectTypeOperation_ElementSelectionneChanged(object sender, EventArgs e)
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
            if ( m_besoin != null && m_donneeOperation != null )
                m_txtSelectTypeOperation.ElementSelectionne = m_donneeOperation.GetTypeOperation(m_besoin.ContexteDonnee);
            m_bIsInitializing = false;
        }

        
    }
}
