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
using timos.data.equipement.consommables;
using sc2i.common.unites.standard;
using sc2i.data;
using timos.projet.besoin.editeur.donneebesoin;

namespace timos.projet.besoin
{
    [AutoExec("Autoexec")]
    public partial class CEditeurDonneeBesoinConsommable : UserControl, IEditeurDonneeBesoin
    {
        private CDonneeBesoinTypeConsommable m_donneeConsommable = null;
        private CBesoin m_besoin = null;
        
        //-----------------------------------------------
        public CEditeurDonneeBesoinConsommable()
        {
            InitializeComponent();
            sc2i.win32.common.CWin32Traducteur.Translate(this);
        }

        //-----------------------------------------------
        public static void Autoexec()
        {
            CAllocateurEditeurDonneeBesoin.RegisterEditeur(
                ETypeEditeurBesoin.EditeurDonnees, 
                typeof(CDonneeBesoinTypeConsommable), 
                typeof(CEditeurDonneeBesoinConsommable));
            CAllocateurEditeurDonneeBesoin.RegisterEditeur(
               ETypeEditeurBesoin.EditeurDonnees,
               typeof(CDonneeBesoinTemps),
               typeof(CEditeurDonneeBesoinTemps));
        }

        //-----------------------------------------------
        public IDonneeBesoin DonneeBesoin
        {
            get
            {
                return m_donneeConsommable;
            }
        }

        //-----------------------------------------------
        private bool m_bIsInitializing = false;
        public virtual void Init(IDonneeBesoin calcul, CBesoin besoin, CItemBesoin itemBesoin, IEnumerable<CItemBesoin> items)
        {
            m_bIsInitializing = true;
            m_besoin = besoin;
            m_donneeConsommable = calcul as CDonneeBesoinTypeConsommable;
            if ( m_donneeConsommable != null )
            {
                Visible = true;
                InitTypeConsommable();
                m_txtSelectTypeConsommable.ElementSelectionne = m_donneeConsommable.GetTypeConsommable(besoin.ContexteDonnee);
            }
            m_bIsInitializing = false;
        }

        //-----------------------------------------------
        protected virtual void InitTypeConsommable()
        {
            //Supprime les consommables temps
            m_txtSelectTypeConsommable.InitAvecFiltreDeBase(
                typeof(CTypeConsommable),
                "LibelleComplet",
                new CFiltreData(CTypeConsommable.c_champClasseUniteString + "<>@1",
                    CClasseUniteTemps.c_idClasse),
                    false);

        }


        //-----------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_donneeConsommable != null)
            {
                m_donneeConsommable.SetTypeConsommable(m_txtSelectTypeConsommable.ElementSelectionne as CTypeConsommable);
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
        private void m_txtSelectTypeConsommable_ElementSelectionneChanged(object sender, EventArgs e)
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
            if (m_besoin != null && m_donneeConsommable != null)
                m_txtSelectTypeConsommable.ElementSelectionne = m_donneeConsommable.GetTypeConsommable(m_besoin.ContexteDonnee);
            m_bIsInitializing = false;
        }

        
    }
}
