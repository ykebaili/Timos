using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.win32.common.customizableList;
using timos.data.projet.besoin;
using sc2i.data;
using System.Drawing;
using System.Windows.Forms;
using sc2i.common;

namespace timos.projet.besoin
{
    public class CControleListeQuantites : CCustomizableListAvecNiveau
    {
        private CBesoin m_besoin = null;
        public CControleListeQuantites()
            : base()
        {
        }

        protected override void RenumerotteItems()
        {
            base.RenumerotteItems();
            if (!LockEdition)
            {
                foreach (CItemQuantite item in Items)
                {
                    item.Quantite.Index = item.Index;
                }
            }
        }

        //--------------------------------------------------------------------
        public void Init(CBesoin besoin)
        {
            CurrentItemIndex = null;
            Items = new CCustomizableListItem[0];
            m_besoin = besoin;

            if (m_besoin != null)
            {
                List<CCustomizableListItem> items = new List<CCustomizableListItem>();
                CListeObjetsDonnees lstQuantites = m_besoin.Quantites;
                lstQuantites.Filtre = new CFiltreData(CBesoinQuantite.c_champIdQteParente+ " is null");
                foreach (CBesoinQuantite q in lstQuantites )
                {
                    AddItemQuantiteEtFils(null, q, items);
                }
                Items = items.ToArray();
            }
            Refresh();
        }

        //--------------------------------------------------------------------
        private void AddItemQuantiteEtFils(CItemQuantite itemParent, CBesoinQuantite q, List<CCustomizableListItem> lstItems)
        {
            CItemQuantite item = new CItemQuantite(q, itemParent);
            lstItems.Add(item);
            foreach (CBesoinQuantite qFils in q.QuantitesFilles)
                AddItemQuantiteEtFils(item, qFils, lstItems);
        }

        //--------------------------------------------------------------------
        protected override void HighlightZoneItem(Point ptScreen)
        {
            if ( m_nItemDragElement == null )
                base.HighlightZoneItem(ptScreen);
            else
            {
                Rectangle rct = GetItemRect(m_nItemDragElement.Value);
                if (rct != m_lastRectHighlight)
                {
                    HideHighlight();
                    Brush br = new SolidBrush(Color.FromArgb(64, 0, 255, 0));
                    Graphics g = m_panelDessin.CreateGraphics();
                    g.FillRectangle(br, rct);
                    g.Dispose();
                    br.Dispose();
                    m_lastRectHighlight = rct;
                }
                Point ptLocal = m_panelDessin.PointToScreen(new Point(rct.Left, rct.Top));
                //ptLocal = PointToClient(new Point(ptScreen.X - m_picFillBesoin.Width / 2, ptLocal.Y));
            }
        }

        protected override void HideHighlight()
        {
            base.HideHighlight();
//            m_picFillBesoin.Visible = false;
        }

        //--------------------------------------------------------------------
        private int? m_nItemDragElement = null;
        public override DragDropEffects GetDragDropEffect(DragEventArgs e)
        {
            DragDropEffects eff = base.GetDragDropEffect(e);
            m_nItemDragElement = null;
            if (eff == DragDropEffects.None)
            {
                CReferenceObjetDonnee refe = e.Data.GetData(typeof(CReferenceObjetDonnee)) as CReferenceObjetDonnee;
                if (refe != null)
                {
                    Point pt = PointToClient(new Point(e.X, e.Y));
                    int? nItemIndex = GetItemIndexAtPosition(pt.Y);
                    if (nItemIndex != null)
                    {
                        CItemQuantite item = Items[nItemIndex.Value] as CItemQuantite;
                        if (item != null && item.Quantite != null &&
                            item.Quantite.QuantiteParente == null &&
                            (item.Quantite.TypeEntiteAssocie == null ||
                            item.Quantite.RelationsElementsSelectionnes.Count == 0 ||
                            item.Quantite.TypeEntiteAssocie == refe.TypeObjet))
                        {
                            eff = DragDropEffects.Link;
                            m_nItemDragElement = nItemIndex;
                        }
                    }
                }
            }
            return eff;
        }

        int? m_nIndexBeforeDragDrop = null;
        protected override void m_panelDessin_DragEnter(object sender, DragEventArgs e)
        {
            m_nIndexBeforeDragDrop = CurrentItemIndex;
            CurrentItemIndex = null;
            m_panelDessin.Refresh();
            base.m_panelDessin_DragEnter(sender, e);
        }

        protected override void m_panelDessin_DragLeave(object sender, EventArgs e)
        {
            base.m_panelDessin_DragLeave(sender, e);
            CurrentItemIndex = m_nIndexBeforeDragDrop;
        }

        protected override void m_panelDessin_DragDrop(object sender, DragEventArgs e)
        {
            if ( m_nItemDragElement == null )
                base.m_panelDessin_DragDrop(sender, e);
            else
            {
                CItemQuantite item = Items[m_nItemDragElement.Value] as CItemQuantite;
                if ( item != null )
                {
                    CBesoinQuantite bq = item.Quantite;
                    CReferenceObjetDonnee[] lstRefs = e.Data.GetData(typeof(CReferenceObjetDonnee[])) as CReferenceObjetDonnee[];
                    if (lstRefs == null)
                    {
                        CReferenceObjetDonnee refObj = e.Data.GetData(typeof(CReferenceObjetDonnee)) as CReferenceObjetDonnee;
                        if (refObj != null)
                            lstRefs = new CReferenceObjetDonnee[] { refObj };
                    }
                    if ( lstRefs != null )
                    {
                        string strMes = "";
                        if (lstRefs.Count() == 1)
                        {
                            CObjetDonneeAIdNumerique objet = lstRefs[0].GetObjet(item.Quantite.ContexteDonnee) as CObjetDonneeAIdNumerique;
                            if (objet != null)
                            {
                                strMes = objet.DescriptionElement;
                            }
                        }
                        else
                            strMes = I.T("@1 elements|20640", lstRefs.Count().ToString());
                        if (MessageBox.Show(I.T("Add @1 to selection ?|20639",
                            strMes), "",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            foreach (CReferenceObjetDonnee refObjet in lstRefs)
                            {
                                CObjetDonneeAIdNumerique objet = refObjet.GetObjet(item.Quantite.ContexteDonnee) as CObjetDonneeAIdNumerique;
                                if (objet != null)
                                {
                                    bq.AddSelectedEntity(objet);
                                    CurrentItemIndex = CurrentItemIndex;
                                }
                            }
                        }
                            
                    }
                }
            }
        }
    }



    //-------------------------------------------------------------
    public class CItemQuantite : CCustomizableListItemANiveau
    {
        public CItemQuantite(CBesoinQuantite q, CItemQuantite itemParent)
            :base(itemParent)
        {
            Tag = q;
        }

        public CBesoinQuantite Quantite
        {
            get
            {
                return Tag as CBesoinQuantite;
            }
            set
            {
                Tag = value;
            }
        }

        public override bool IsCollapse
        {
            get
            {
                return false;
            }
        }

        
        public override bool OnChangeParent(CCustomizableListItemANiveau item)
        {
            CItemQuantite it = item as CItemQuantite;
            if (Quantite != null && (it != null || item == null))
            {
                if (it != null)
                    Quantite.QuantiteParente = it.Quantite;
                else
                    Quantite.QuantiteParente = null;
                return true;
            }
            return false;
        }

        //--------------------------------------------------
        public override Color? ColorInactive
        {
            get
            {
                if (Quantite != null && Quantite.Besoin != null)
                {
                    int nNiveau = Quantite.Besoin.Niveau;
                    int nR = 255;
                    int nG = 255;
                    int nB = 255;
                    //réduction des couleurs suivant les niveaux :
                    /*0:1->5 : R et G
                     * 1:6->10 : R et B
                     * 2:11->15 : G et B
                     * 3:16->20 : R
                     * 4:21->25 : G
                     * 5:26->30 : B
                     * Au dela, reste blanc (ça permet de changer les couleurs sur 30 niveaux !
                     */
                    int nTranche = (nNiveau) / 5;
                    int nDec = ((nNiveau) % 5 + 1) * 25;
                    switch (nTranche)
                    {
                        case 0:
                            nR = 255 - nDec;
                            nG = 255 - nDec;
                            break;
                        case 1:
                            nR = 255 - nDec;
                            nB = 255 - nDec;
                            break;
                        case 2:
                            nG = 255 - nDec;
                            nB = 255 - nDec;
                            break;
                        case 3:
                            nR = 255 - nDec;
                            break;
                        case 4:
                            nG = 255 - nDec;
                            break;
                        case 5:
                            nB = 255 - nDec;
                            break;
                    }
                    return Color.FromArgb(nR, nG, nB);
                }
                return Color.White;
            }
        }

        
    }
}
