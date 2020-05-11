using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using timos.data.projet.besoin;
using System.Collections;
using sc2i.win32.data;
using timos.General;
using sc2i.win32.data.navigation;
using timos.Properties;
using sc2i.data;
using sc2i.common;
using sc2i.win32.common;

namespace timos.projet.besoin
{
    public partial class CControlePourResumeSatisfaction : UserControl
    {
        private ISatisfactionBesoin m_satisfaction = null;
        private bool m_bIsEnEdition = false;

        public CControlePourResumeSatisfaction()
        {
            InitializeComponent();
        }

        //------------------------------------------
        public void Init(
            ISatisfactionBesoin satisfaction,
            bool bIsEnEdition)
        {
            m_satisfaction = satisfaction;
            m_bIsEnEdition = bIsEnEdition;
            m_picBox.Visible = m_satisfaction != null;
            if ( m_satisfaction != null )
            {
                m_picBox.Image = m_satisfaction.RelationsSatisfaits.Count > 0 ? Resources.PuzzleMal32:Resources.PuzzleMal32Trans;
            }
        }

        //------------------------------------------
        private void m_picBox_Click(object sender, EventArgs e)
        {
            foreach (ToolStripItem item in new ArrayList(m_menuBesoins.Items))
            {
                if (item is CObjetDonneeMenuItem)
                {
                    m_menuBesoins.Items.Remove(item);
                    item.Dispose();
                }
            }
            if (m_satisfaction != null)
            {
                foreach (CBesoin besoin in m_satisfaction.BesoinsSolutionnes)
                {
                    CObjetDonneeMenuItem itemBesoin = new CObjetDonneeMenuItem(
                        besoin,
                        besoin.ObjetPourEditionElementACout,
                        besoin.LibelleResume);

                    double fPct = CUtilSatisfaction.GetPourcentageFor(besoin, m_satisfaction);
                    if ( fPct < 99 )
                    {
                        itemBesoin.Text = fPct.ToString("0.##")+"% "+besoin.LibelleResume;

                        CToolStripPourcentage toolStripPourcentage = new CToolStripPourcentage(fPct);
                        toolStripPourcentage.OnValideSaisie += new EventHandler(toolStripPourcentage_OnValideSaisie);
                        toolStripPourcentage.Tag = besoin;
                        itemBesoin.DropDownItems.Add(toolStripPourcentage);

                        CObjetDonneeMenuItem itemEditBesoin = new CObjetDonneeMenuItem(
                            besoin,
                            besoin.ObjetPourEditionElementACout,
                            besoin.LibelleResume);
                        itemEditBesoin.Image = timos.Properties.Resources.PuzzleFem20;
                        itemBesoin.DropDownItems.Add(itemEditBesoin);
                    }
                    itemBesoin.Image = timos.Properties.Resources.PuzzleFem20;
                    m_menuBesoins.Items.Add(itemBesoin);
                }
            }
            if (m_menuBesoins.Items.Count > 0)
                m_menuBesoins.Show(this, new Point(0, Height));
        }


        //------------------------------------------
        void toolStripPourcentage_OnValideSaisie(object sender, EventArgs e)
        {
            CToolStripPourcentage pct = sender as CToolStripPourcentage;
            CBesoin besoin = pct != null?pct.Tag  as CBesoin:null;
            if (besoin != null && pct.Value != null)
            {
                if (CFormAlerte.Afficher(I.T("Change repartition for '@1' uses '@2'% of '@3' cost ?|20687",
                    besoin.LibelleComplet,
                    pct.Value.Value.ToString("0.##"),
                    m_satisfaction.Libelle),
                    EFormAlerteBoutons.OuiNon,
                    EFormAlerteType.Question) == DialogResult.Yes)
                {
                    if (!m_bIsEnEdition)
                    {
                        using (CContexteDonnee ctx = new CContexteDonnee(m_satisfaction.ContexteDonnee.IdSession, true, false))
                        {
                            besoin = besoin.GetObjetInContexte(ctx) as CBesoin;
                            CObjetDonnee satObj = m_satisfaction as CObjetDonnee;
                            if (satObj != null)
                            {
                                satObj = satObj.GetObjetInContexte(ctx);
                                ISatisfactionBesoin satInContexte = satObj as ISatisfactionBesoin;
                                CUtilSatisfaction.SetPourcentageFor(besoin, satInContexte, pct.Value.Value);
                            }
                            CResultAErreur result = ctx.SaveAll(false);
                            if (!result)
                                CFormAlerte.Afficher(result.Erreur);
                        }
                    }
                    else
                    {
                        CUtilSatisfaction.SetPourcentageFor(besoin, m_satisfaction, pct.Value.Value);
                    }
                }
            }
                   
        }

        //------------------------------------------
        private void m_menuDisplayMap_Click(object sender, EventArgs e)
        {
            if (m_satisfaction != null)
            {
                CFormEditionStandard frm = FindForm() as CFormEditionStandard;
                if (frm != null)
                    CFormMapBesoinsPopup.Show(frm, m_satisfaction);
            }
        }

        private void m_picBox_DragEnter(object sender, DragEventArgs e)
        {
            CReferenceObjetDonnee[] refs = e.Data.GetData(typeof(CReferenceObjetDonnee[])) as CReferenceObjetDonnee[];
            if (refs == null)
            {
                CReferenceObjetDonnee refe = e.Data.GetData(typeof(CReferenceObjetDonnee)) as CReferenceObjetDonnee;
                if (refe != null)
                {
                    refs = new CReferenceObjetDonnee[] { refe };
                }
            }
            if ( refs != null )
            {
                foreach (CReferenceObjetDonnee refO in refs)
                {
                    if (typeof(CBesoin).IsAssignableFrom(refO.TypeObjet))
                    {
                        e.Effect = DragDropEffects.Link;
                        return;
                    }
                }

                
            }
        }

        //------------------------------------------
        private void m_picBox_DragDrop(object sender, DragEventArgs e)
        {
            CReferenceObjetDonnee[] refs = e.Data.GetData(typeof(CReferenceObjetDonnee[])) as CReferenceObjetDonnee[];
            if (refs == null)
            {
                CReferenceObjetDonnee refe = e.Data.GetData(typeof(CReferenceObjetDonnee)) as CReferenceObjetDonnee;
                if (refe != null)
                {
                    refs = new CReferenceObjetDonnee[] { refe };
                }
            }
            if ( refs != null )
            {
                List<CBesoin> lstBesoins = new List<CBesoin>();
                StringBuilder blListe = new StringBuilder();
                foreach ( CReferenceObjetDonnee refO in refs )
                {
                    if ( typeof(CBesoin).IsAssignableFrom ( refO.TypeObjet ) )
                    {
                        CBesoin besoin = refO.GetObjet(m_satisfaction.ContexteDonnee) as CBesoin;
                        if ( besoin != null )
                        {
                            if ( m_satisfaction.CanSatisfaire ( besoin ) )
                            {
                                lstBesoins.Add ( besoin );
                                blListe.Append ( besoin.Libelle );
                                blListe.Append (" ,");
                            }
                        }
                    }
                }
                if (lstBesoins.Count > 0)
                {
                    blListe.Remove(blListe.Length - 2, 2);
                    if (MessageBox.Show(I.T("@1 will be considered as a solution of @2. Continue ?|20631",
                        m_satisfaction.Libelle, blListe.ToString()), "",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CContexteDonnee ctx = m_satisfaction.ContexteDonnee;
                        if ( !m_bIsEnEdition )
                            ctx = ctx.GetContexteEdition();
                        foreach (CBesoin besoin in lstBesoins)
                        {
                            CBesoin besoinEdit = besoin.GetObjetInContexte(ctx) as CBesoin;
                            besoinEdit.AddSatisfaction(m_satisfaction, null);
                        }
                        if (!m_bIsEnEdition)
                        {
                            CResultAErreur result = ctx.CommitEdit();
                            if (!result)
                            {
                                CFormAlerte.Afficher(result.Erreur);
                                ctx.CancelEdit();
                            }
                            ctx.Dispose();
                        }
                    }
                }
                    
            }
        }

        /*//------------------------------------------
        void itemBesoin_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            CBesoin besoin = item != null ? item.Tag as CBesoin : null;
            if (besoin != null)
            {
                CPhaseSpecifications phase = besoin.PhaseSpecifications;
                phase = phase.GetObjetInContexte(CSc2iWin32DataClient.ContexteCourant) as CPhaseSpecifications;
                CTimosApp.Navigateur.EditeElement(phase, false, "");
            }
        }*/

    }
}
