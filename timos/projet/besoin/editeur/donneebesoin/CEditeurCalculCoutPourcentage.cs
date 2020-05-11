using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.common;
using timos.data.projet.besoin;

namespace timos.projet.besoin
{
    [AutoExec("Autoexec")]
    public partial class CEditeurCalculCoutPourcentage : UserControl, IEditeurDonneeBesoin
    {
        private CDonneeBesoinPourcentage m_calculPourcentage;
        private CBesoin m_besoin;
        private IEnumerable<CItemBesoin> m_items = null;

        //------------------------------------------------------
        public CEditeurCalculCoutPourcentage()
        {
            InitializeComponent();
            sc2i.win32.common.CWin32Traducteur.Translate(this);
        }

        //------------------------------------------------------
        public static void Autoexec()
        {
            CAllocateurEditeurDonneeBesoin.RegisterEditeur(
                ETypeEditeurBesoin.EditeurCout, 
                typeof(CDonneeBesoinPourcentage),
                typeof(CEditeurCalculCoutPourcentage));
        }

        //------------------------------------------------------
        public IDonneeBesoin DonneeBesoin
        {
            get { return m_calculPourcentage; }
        }

        //------------------------------------------------------
        public void Init(IDonneeBesoin calcul, CBesoin besoin, CItemBesoin itemBesoin, IEnumerable<CItemBesoin> items)
        {
            m_calculPourcentage = calcul as CDonneeBesoinPourcentage;
            m_besoin = besoin;
            m_items = items;

            if ( m_calculPourcentage != null  && besoin != null)
            {
                Visible = true;
                m_txtPourcentage.DoubleValue = m_calculPourcentage.Pourcentage;
                StringBuilder bl = new StringBuilder ( );
                foreach ( CBesoinDependance dep in besoin.LiensBesoinsDontJeDepend )
                {
                    bl.Append ( dep.BesoinReference.Index );
                    bl.Append(';');
                }
                if ( bl.Length > 0 )
                    bl.Remove ( bl.Length-1, 1);
                m_txtReferences.Text = bl.ToString();
            }
            else
            {
                Visible = false;
            }
                
        }

        //------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if ( m_besoin == null || m_calculPourcentage != null && m_items != null)
            {
                if ( m_txtPourcentage.DoubleValue != null )
                {
                   m_calculPourcentage.Pourcentage = m_txtPourcentage.DoubleValue.Value;
                }
                else
                    m_calculPourcentage.Pourcentage = 0;
                //Trouve les éléments avec les indexs demandés
                string[] strIndexs = m_txtReferences.Text.Split(';');
                Dictionary<CBesoin, bool> dicDepsASupprimer = new Dictionary<CBesoin,bool>();
                foreach ( CBesoinDependance dep in m_besoin.LiensBesoinsDontJeDepend )
                    dicDepsASupprimer[dep.BesoinReference] = true;
                foreach ( string strIndex in strIndexs )
                {
                    try{
                        int nItem = Int32.Parse ( strIndex );
                        if ( nItem >= 0 && nItem < m_items.Count() )
                        {
                            CItemBesoin item = m_items.ElementAt(nItem);
                            if ( item != null && item.Besoin != null )
                            {
                                m_besoin.AddDependance(item.Besoin);
                                dicDepsASupprimer[item.Besoin] = false;
                            }
                        }
                    }
                    catch{}
                }
                foreach (KeyValuePair<CBesoin, bool> kv in dicDepsASupprimer)
                {
                    if (kv.Value)
                        m_besoin.RemoveDependance(kv.Key);
                }
            }
            return result;
        }

        //------------------------------------------------------
        public event EventHandler OnCoutChanged;

        //------------------------------------------------------
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
                    OnChangeLockEdition ( this, null );
            }
        }
        //------------------------------------------------------
        public event EventHandler OnChangeLockEdition;

        private void m_txtPourcentage_Validated(object sender, EventArgs e)
        {
            DeclencheOnChangeCout();
        }

        private void m_txtReferences_Validated(object sender, EventArgs e)
        {
            DeclencheOnChangeCout();
        }

        private void DeclencheOnChangeCout()
        {
            if (OnCoutChanged != null)
            {
                MajChamps();
                OnCoutChanged(this, null);
            }
        }

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
