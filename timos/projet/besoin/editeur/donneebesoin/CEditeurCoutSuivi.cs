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
using sc2i.win32.common;

namespace timos.projet.besoin
{

    public partial class CEditeurCoutSuivi : UserControl, IEditeurDonneeBesoin
    {
        private CBesoin m_besoin = null;
        private CItemBesoin m_itemBesoin = null;


        public CEditeurCoutSuivi()
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
        public void Init(IDonneeBesoin donnee, CBesoin besoin, CItemBesoin itemBesoin, IEnumerable<CItemBesoin> items)
        {
            m_besoin = besoin;
            m_itemBesoin = itemBesoin;
            FillDatas();
        }

        private void FillDatas()
        {
            m_bIsInitializing = true;
            if (m_besoin != null)
            {
                m_chkSaisiAsPrevisionnel.Checked = m_besoin.UtiliserSaisiAsPrevisionnel || !m_besoin.HasSatisfactions;
                m_chkSaisiAsReel.Checked = m_besoin.UtiliserSaisiAsReel;
                m_chkSaisiAsPrevisionnel.Visible = !m_besoin.HasChildren;
                m_chkSaisiAsReel.Visible = !m_besoin.HasChildren;
                m_txtCoutReel.DoubleValue = m_itemBesoin.CoutReel;
                m_txtCoutCalculé.DoubleValue = m_itemBesoin.CoutPrevisionnel;
                StringBuilder bl = new StringBuilder();
                CBesoin b = m_besoin;
                while (b != null)
                {
                    CBesoinQuantite qte = b.RegroupementQuantite;
                    if (qte != null)
                    {
                        bl.Append(qte.Quantite);
                        bl.Append(" ");
                        bl.Append(qte.Libelle);
                        bl.Append(", ");
                    }
                    b = b.BesoinParent;
                }
                if (bl.Length > 0)
                    bl.Remove(bl.Length - 2, 2);

                m_lblRegroupement.Text = bl.ToString();
                m_txtCoutSaisi.DoubleValue = m_itemBesoin.CoutSaisi;
                UpdateIconeFiger();
                UpdateIconeHierarchie();
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
                m_besoin, 
                m_itemBesoin, 
                m_menuDetailCoutCalculé, 
                false, 
                m_picInfoCalculPrévisionnel);
        }

        private void m_picInfoCoutReel_Click(object sender, EventArgs e)
        {
            new CUtilMenuElementACout().ShowMenuDetailCalcul(
                m_besoin, 
                m_itemBesoin, 
                m_menuDetailCoutCalculé, 
                true, 
                m_picInfoCoutReel);
        }

        /*private bool m_bMenuForCoutReel = false;
        private void ShowMenuDetailCalcul(bool bCoutReel)
        {
            m_bMenuForCoutReel = bCoutReel;
            foreach (ToolStripItem item in new ArrayList(m_menuDetailCoutCalculé.Items))
            {
                m_menuDetailCoutCalculé.Items.Remove(item);
                item.Dispose();
            }
            if (m_besoin != null)
            {
                foreach ( IElementACout elt in m_besoin.GetSourcesDeCout(bCoutReel) )
                {
                    ToolStripItem item = CreateItemSatisfaction(m_besoin, elt);
                    if ( item != null )
                        m_menuDetailCoutCalculé.Items.Add(item);
                }
                if (m_menuDetailCoutCalculé.Items.Count>0)
                    m_menuDetailCoutCalculé.Items.Add ( new ToolStripSeparator());
                
                ToolStripMenuItem itemSatisfaction = new ToolStripMenuItem();
                double fCout = bCoutReel ? m_besoin.CoutReel : m_besoin.CoutPrevisionnel;
                itemSatisfaction.Text = (m_menuDetailCoutCalculé.Items.Count > 0?"--->":"")+ fCout.ToString("0.####");
                itemSatisfaction.Image = Resources.PuzzleMal20;
                m_menuDetailCoutCalculé.Items.Add(itemSatisfaction);

                bool bShouldAddSeparateur = true;

                
                foreach (CItemBesoin childItem in m_itemBesoin.ChildItems)
                {
                    if (childItem.Besoin.GetImputationsAFaireSurUtilisateursDeCout().GetCoutImputéeA(m_besoin, bCoutReel) == 0)
                    {
                        if (bShouldAddSeparateur)
                            m_menuDetailCoutCalculé.Items.Add(new ToolStripSeparator());
                        ToolStripMenuItem item = new ToolStripMenuItem();
                        double fVal = bCoutReel ? childItem.CoutReel : childItem.CoutPrevisionnel;
                        item.Text = fVal.ToString("0.####") + "   " + childItem.Besoin.Libelle;
                        item.Image = DynamicClassAttribute.GetImage(childItem.Besoin.GetType());
                        m_menuDetailCoutCalculé.Items.Add(item);
                    }
                }
                    
            }
            if (m_menuDetailCoutCalculé.Items.Count > 0)
                m_menuDetailCoutCalculé.Show(
                    bCoutReel?m_picInfoCoutReel:m_picInfoCalculPrévisionnel, 
                    new Point(0, m_picInfoCalculPrévisionnel.Height));
        }

        private ToolStripItem CreateItemSatisfaction(IElementACout utilisateur, IElementACout source)
        {
            CImputationsCouts imputation = source.GetImputationsAFaireSurUtilisateursDeCout();
            if (imputation != null)
            {
                CImputationCout i = imputation.GetImputation(utilisateur);
                if (i != null && i.Poids != 0)
                {
                    double fVal = imputation.GetCoutImputéeA(utilisateur, m_bMenuForCoutReel);
                    ToolStripMenuItem itemElementACout = new ToolStripMenuItem();
                    itemElementACout.Text = fVal.ToString("0.####") + "   " + ((ISatisfactionBesoin)source).LibelleSatisfactionComplet;
                    if (source is ISatisfactionBesoin && utilisateur is CBesoin)
                    {
                        double fPct = CUtilSatisfaction.GetPourcentageFor( (CBesoin)utilisateur, (ISatisfactionBesoin)source);
                        itemElementACout.Text += " (" + fPct.ToString("0.##") + "%)";
                    }
                    else
                        itemElementACout.Text += "  (100%)";


                    itemElementACout.Tag = source;
                    itemElementACout.Image = DynamicClassAttribute.GetImage(source.GetType());
                    if (fVal == 0)
                        itemElementACout.BackColor = Color.LightPink;
                    if (source.GetSourcesDeCout(m_bMenuForCoutReel).Length > 0)
                    {
                        ToolStripMenuItem dummy = new ToolStripMenuItem();
                        itemElementACout.DropDownItems.Add(dummy);
                        itemElementACout.DropDownOpening += new EventHandler(itemElementACout_DropDownOpening);
                    }
                    itemElementACout.MouseUp += new MouseEventHandler(itemElementACout_MouseUp);
                    return itemElementACout;
                }
            }
            return null;
        }


        //---------------------------------------------------------
        void itemElementACout_MouseUp(object sender, MouseEventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null && (e.Button == MouseButtons.Right || item.DropDownItems.Count == 0))
            {
                ISatisfactionBesoin elt = item != null ? item.Tag as ISatisfactionBesoin : null;
                if (elt != null)
                {
                    CFormMain.GetInstance().EditeElement(elt.ObjetPourEditionSatisfaction, false, "");
                }
            }
        }


        //---------------------------------------------------------
        void itemElementACout_DropDownOpening(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            IElementACout elt = item != null ? item.Tag as IElementACout : null;
            if (elt != null)
            {
                if (item.DropDownItems.Count == 1 && item.DropDownItems[0].Tag == null)
                {
                    item.DropDownItems.Clear();
                }
                foreach (IElementACout source in elt.GetSourcesDeCout(m_bMenuForCoutReel))
                {
                    ToolStripItem itemFils = CreateItemSatisfaction(elt, source);
                    if (itemFils != null)
                        item.DropDownItems.Add(itemFils);
                }
            }
        }*/


        //-------------------------------------------------------------------------------
        private void m_chkSaisiAsPrevisionnel_CheckedChanged(object sender, EventArgs e)
        {
            if (!m_bIsInitializing)
            {
                if (m_besoin != null)
                {
                    m_besoin.UtiliserSaisiAsPrevisionnel = m_chkSaisiAsPrevisionnel.Checked;
                    if (OnCoutChanged != null)
                        OnCoutChanged(this, null);
                    if (OnDataChanged != null)
                        OnDataChanged(this, null);
                    FillDatas();
                }
            }
        }

        //-------------------------------------------------------------------------------
        private void m_chkSaisiAsReel_CheckedChanged(object sender, EventArgs e)
        {
            if (!m_bIsInitializing)
            {
                if (m_besoin != null)
                {
                    m_besoin.UtiliserSaisiAsReel = m_chkSaisiAsReel.Checked;
                    if (OnCoutChanged != null)
                        OnCoutChanged(this, null);
                    if (OnDataChanged != null)
                        OnDataChanged(this, null);
                    FillDatas();

                }
            }
        }

        private void m_picFigerPrevisionnel_Click(object sender, EventArgs e)
        {
            if (m_besoin != null && !LockEdition)
            {
                string strMessage = "";
                if (m_besoin.FigerCoutPrevisionnel)
                    strMessage = I.T("Would you like to unlock estimated cost ?|20711");
                else
                    strMessage = I.T("Would you like to lock estimated cost ? (It will not be automatically calculated|20712");
                if (CFormAlerte.Afficher(strMessage, EFormAlerteBoutons.OuiNon, EFormAlerteType.Question) == DialogResult.Yes)
                {
                    m_besoin.FigerCoutPrevisionnel = !m_besoin.FigerCoutPrevisionnel;
                    UpdateIconeFiger();
                    if (OnDataChanged != null)
                        OnDataChanged(this, null);
                }
            }
        }

        private void UpdateIconeFiger()
        {
            if (m_besoin != null && !m_besoin.FigerCoutPrevisionnel)
                m_picFigerPrevisionnel.Image = Resources.lock_unlock;
            else
                m_picFigerPrevisionnel.Image = Resources.lock_padlock;

        }

        private void UpdateIconeHierarchie()
        {
            m_chkExcludeChilds.Visible = m_besoin.HasChildren;
            if (m_besoin != null && m_besoin.ExclureLesCoutsDesFils)
                m_chkExcludeChilds.Image = Resources.noHierarchy;
            else
                m_chkExcludeChilds.Image = Resources.Hierarchy;
        }

        private void m_chkExcludeChilds_CheckedChanged(object sender, EventArgs e)
        {
            if (m_besoin != null && !LockEdition)
            {
                m_besoin.ExclureLesCoutsDesFils = !m_besoin.ExclureLesCoutsDesFils;
                UpdateIconeHierarchie();
                if (OnCoutChanged != null)
                    OnCoutChanged(this, null);
                if (OnDataChanged != null)
                    OnDataChanged(this, null);
                FillDatas();
            }
        }
        
            
    }
}
