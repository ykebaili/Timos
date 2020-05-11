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
using timos.data;
using sc2i.common.unites.standard;
using sc2i.common.unites;
using sc2i.expression;
using sc2i.win32.expression;

namespace timos.projet.besoin
{
    [AutoExec("Autoexec")]
    public partial class CEditeurDonneesBesoinProjet : UserControl, IEditeurDonneeBesoin
    {
        private CDonneeBesoinProjet m_calculProjet;
        private CBesoin m_besoin;
        private IEnumerable<CItemBesoin> m_items = null;

        //------------------------------------------------------
        public CEditeurDonneesBesoinProjet()
        {
            InitializeComponent();
            sc2i.win32.common.CWin32Traducteur.Translate(this);
            m_txtDuree.DefaultFormat = CGestionnaireUnites.GetUnite(CClasseUniteTemps.c_idDAY).LibelleCourt;
            m_txtDuree.UseValueFormat = false;
        }

        //------------------------------------------------------
        public static void Autoexec()
        {
            CAllocateurEditeurDonneeBesoin.RegisterEditeur(
                ETypeEditeurBesoin.EditeurDonnees, 
                typeof(CDonneeBesoinProjet),
                typeof(CEditeurDonneesBesoinProjet));
        }

        //------------------------------------------------------
        public IDonneeBesoin DonneeBesoin
        {
            get { return m_calculProjet; }
        }

        //------------------------------------------------------
        private bool m_bIsInitializing = false;
        public void Init(IDonneeBesoin calcul, CBesoin besoin, CItemBesoin itemBesoin, IEnumerable<CItemBesoin> items)
        {
            m_bIsInitializing = true;
            m_calculProjet = calcul as CDonneeBesoinProjet;
            m_besoin = besoin;
            m_items = items;

            if ( m_calculProjet != null  && besoin != null)
            {
                m_txtSelectTypeProjet.Init(typeof(CTypeProjet), "Libelle", false );
                m_txtSelectTypeProjet.ElementSelectionne = (m_calculProjet.GetTypeProjet(besoin.ContexteDonnee));
                Visible = true;
                StringBuilder bl = new StringBuilder ( );
                foreach ( CBesoinDependance dep in besoin.LiensBesoinsDontJeDepend )
                {
                    bl.Append ( dep.BesoinReference.Index );
                    bl.Append(';');
                }
                if ( bl.Length > 0 )
                    bl.Remove ( bl.Length-1, 1);
                m_txtReferences.Text = bl.ToString();

                if (m_calculProjet.DureeJours == 0)
                    m_txtDuree.UnitValue = null;
                else
                    m_txtDuree.UnitValue = new CValeurUnite(m_calculProjet.DureeJours, CClasseUniteTemps.c_idDAY);
                m_txtTemplateKey.Text = m_calculProjet.CleProjetTemplate;
            }
            else
            {
                Visible = false;
            }
            m_bIsInitializing = false;
                
        }

        //------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if ( m_besoin == null || m_calculProjet != null && m_items != null)
            {
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
                            if ( item != null && item.Besoin != null && item.Besoin.TypeBesoinCode == (int)ETypeDonneeBesoin.Projet)
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
                m_calculProjet.SetTypePRojet(m_txtSelectTypeProjet.ElementSelectionne as CTypeProjet);
                if (m_txtDuree.UnitValue != null)
                {
                    m_calculProjet.DureeJours = m_txtDuree.UnitValue.ConvertTo(CClasseUniteTemps.c_idDAY).Valeur;
                }
                else
                    m_calculProjet.DureeJours = 0;
                m_calculProjet.CleProjetTemplate = m_txtTemplateKey.Text.Trim();
                
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

        private void m_txtProjet_Validated(object sender, EventArgs e)
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

        //------------------------------------------------------------------------
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (OnDataChanged != null && !m_bIsInitializing)
                OnDataChanged(this, null);
        }

        //------------------------------------------------------------------------
        public void RefreshFromExternalChangeOnDonnee()
        {
        }

        //------------------------------------------------------------------------
        private void m_txtSelectTypeProjet_OnSelectedObjectChanged(object sender, EventArgs e)
        {

        }

        //------------------------------------------------------------------------
        private void m_txtSelectTypeProjet_ElementSelectionneChanged(object sender, EventArgs e)
        {
            if (OnDataChanged != null && !m_bIsInitializing)
                OnDataChanged(this, null);
        }

        //------------------------------------------------------------------------
        private void m_btnFormula_Click(object sender, EventArgs e)
        {
            C2iExpression formule = m_calculProjet.FormuleInitialisation;
            if (CFormStdEditeFormule.EditeFormule(ref formule,
                new CFournisseurGeneriqueProprietesDynamiques(),
                typeof(CProjet),
                true))
            {
                m_calculProjet.FormuleInitialisation = formule;
                if (OnDataChanged != null && !m_bIsInitializing)
                    OnDataChanged(this, null);
            }
        }

    }
}
