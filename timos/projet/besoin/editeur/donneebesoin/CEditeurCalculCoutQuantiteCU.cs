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
    public partial class CEditeurCalculCoutQuantiteCU : UserControl, IEditeurDonneeBesoin
    {
        private CDonneeBesoinQuantiteCU m_calculQte = null;
        private IUnite m_uniteCU = null;
        
        //-----------------------------------------------
        public CEditeurCalculCoutQuantiteCU()
        {
            InitializeComponent();
            sc2i.win32.common.CWin32Traducteur.Translate(this);
        }

        //-----------------------------------------------
        public static void Autoexec()
        {
            CAllocateurEditeurDonneeBesoin.RegisterEditeur(
                ETypeEditeurBesoin.EditeurCout, 
                typeof(CDonneeBesoinQuantiteCU), 
                typeof(CEditeurCalculCoutQuantiteCU));
        }

        //-----------------------------------------------
        public IDonneeBesoin DonneeBesoin
        {
            get
            {
                return m_calculQte;
            }
        }

        //-----------------------------------------------
        private bool m_bIsInitializing = false;
        public void Init(IDonneeBesoin calcul, CBesoin besoin, CItemBesoin itemBesoin, IEnumerable<CItemBesoin> items)
        {
            m_bIsInitializing = true;
            m_calculQte = calcul as CDonneeBesoinQuantiteCU;
            if ( m_calculQte != null )
            {
                Visible = true;
                m_txtQuantité.UnitValue = m_calculQte.Quantite;
                m_lblUniteCU.Text = "";
                m_uniteCU = null;
                if (m_calculQte.CoutUnitaire != null)
                {
                    m_txtCoutUnitaire.DoubleValue = m_calculQte.CoutUnitaire.Valeur;
                    if (m_calculQte.Quantite != null &&  m_calculQte.Quantite.IUnite != null)
                    {
                        string strU = CUtilUnite.GetUniteInverse(m_calculQte.CoutUnitaire.Unite);
                        IUnite u = CGestionnaireUnites.GetUnite(strU);
                        if (u != null && u.Classe.GlobalId == m_calculQte.Quantite.IUnite.Classe.GlobalId)
                        {
                            m_uniteCU = u;
                            m_lblUniteCU.Text = u.LibelleCourt;
                        }
                    }
                }
                else
                    m_txtCoutUnitaire.DoubleValue = null;
            }
            m_bIsInitializing = false;
        }

        //-----------------------------------------------
        private void ShowMenuUnites()
        {
            CValeurUnite v = m_txtQuantité.UnitValue;
            if ( v != null )
            {
                IUnite u = v.IUnite;
                if ( u != null )
                {
                    List<IUnite> lst = new List<IUnite>(CGestionnaireUnites.GetUnites ( u.Classe ));
                    lst.Sort((x, y) => x.FacteurVersBase.CompareTo(y.FacteurVersBase));
                    m_menuUnites.Items.Clear();
                    foreach (IUnite unite in lst)
                    {
                        ToolStripMenuItem itemUnite = new ToolStripMenuItem(unite.LibelleCourt);
                        itemUnite.Tag = unite;
                        m_menuUnites.Items.Add(itemUnite);
                        if (unite.LibelleCourt == m_lblUniteCU.Text)
                            itemUnite.Checked = true;
                        itemUnite.Click += new EventHandler(itemUnite_Click);
                    }
                    m_menuUnites.Show(m_lblUniteCU, new Point(0, m_lblUniteCU.Height));
                }
            }

        }

        void itemUnite_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                IUnite u = item.Tag as IUnite;
                if (u != null)
                {
                    m_lblUniteCU.Text = u.LibelleCourt;
                    m_uniteCU = u;
                    if (OnDataChanged != null)
                        OnDataChanged(this, null);
                    DeclencheOnCoutChanged();
                }
            }
        }

        //-----------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_calculQte != null)
            {
                m_calculQte.Quantite = m_txtQuantité.UnitValue;
                if (m_txtCoutUnitaire.DoubleValue != null)
                {
                    if ( m_uniteCU != null && 
                        m_calculQte.Quantite != null &&
                        (m_calculQte.Quantite.IUnite == null || 
                        m_calculQte.Quantite.IUnite.Classe == m_uniteCU.Classe) )
                        m_calculQte.CoutUnitaire = new CValeurUnite(m_txtCoutUnitaire.DoubleValue.Value,
                            CUtilUnite.GetUniteInverse(m_uniteCU.GlobalId));
                    else
                        m_calculQte.CoutUnitaire = new CValeurUnite(m_txtCoutUnitaire.DoubleValue.Value, "");
                }
                else
                    m_calculQte.CoutUnitaire = null;
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
                CValeurUnite v = m_txtQuantité.UnitValue;
                m_lblUniteCU.Text = "";
                if (v != null && v.IUnite != null && m_uniteCU != null)
                {
                    if (m_uniteCU.Classe == v.IUnite.Classe)
                        m_lblUniteCU.Text = m_uniteCU.LibelleCourt;
                }
                else if (v != null && v.IUnite != null)
                    m_lblUniteCU.Text = v.IUnite.LibelleCourt;

                MajChamps();
                DeclencheOnCoutChanged();
            }
        }

        //-----------------------------------------------
        private void m_txtCoutUnitaire_Validated(object sender, EventArgs e)
        {
            if (!m_bIsInitializing)
            {
                if (m_txtCoutUnitaire.DoubleValue != null && m_txtQuantité.UnitValue != null &&
                    m_txtQuantité.UnitValue.IUnite != null &&
                    m_uniteCU == null)
                    m_uniteCU = m_txtQuantité.UnitValue.IUnite;
                MajChamps();
                DeclencheOnCoutChanged();
            }
        }

        //-----------------------------------------------
        private void m_cmbUniteCU_SelectionChangeCommitted(object sender, EventArgs e)
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

        private void m_lblUniteCU_Click(object sender, EventArgs e)
        {
            ShowMenuUnites();
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
