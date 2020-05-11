using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using timos.data.projet.besoin;
using timos.Properties;
using sc2i.common;
using System.Drawing;


namespace timos.projet.besoin
{
    public class CUtilMenuElementACout
    {
        private bool m_bMenuForCoutReel = false;
        public void ShowMenuDetailCalcul(
            IElementACout utilisateur, 
            CItemBesoin itemBesoin, 
            ContextMenuStrip menu, 
            bool bCoutReel,
            Control ctrlRepere)
        {
            m_bMenuForCoutReel = bCoutReel;
            foreach (ToolStripItem item in new ArrayList(menu.Items))
            {
                menu.Items.Remove(item);
                item.Dispose();
            }
            if (utilisateur != null)
            {
                foreach (IElementACout elt in utilisateur.GetSourcesDeCout(bCoutReel))
                {
                    ToolStripItem item = CreateItemSatisfaction(utilisateur, elt);
                    if (item != null)
                        menu.Items.Add(item);
                }
                if (menu.Items.Count > 0)
                    menu.Items.Add(new ToolStripSeparator());

                ToolStripMenuItem itemSatisfaction = new ToolStripMenuItem();
                double fCout = bCoutReel ? utilisateur.CoutReel : utilisateur.CoutPrevisionnel;
                itemSatisfaction.Text = (menu.Items.Count > 0 ? "--->" : "") + fCout.ToString("0.####");
                itemSatisfaction.Image = Resources.PuzzleMal20;
                menu.Items.Add(itemSatisfaction);

                bool bShouldAddSeparateur = true;

                if (itemBesoin != null)
                {
                    foreach (CItemBesoin childItem in itemBesoin.ChildItems)
                    {
                        if (childItem.Besoin.GetImputationsAFaireSurUtilisateursDeCout().GetCoutImputéeA(utilisateur, bCoutReel) == 0)
                        {
                            if (bShouldAddSeparateur)
                                menu.Items.Add(new ToolStripSeparator());
                            bShouldAddSeparateur = false;
                            ToolStripMenuItem item = new ToolStripMenuItem();
                            double fVal = bCoutReel ? childItem.CoutReel : childItem.CoutPrevisionnel;
                            item.Text = fVal.ToString("0.####") + "   " + childItem.Besoin.Libelle;
                            item.Image = DynamicClassAttribute.GetImage(childItem.Besoin.GetType());
                            menu.Items.Add(item);
                        }
                    }
                }

            }
            if (menu.Items.Count > 0)
                menu.Show(ctrlRepere, new Point(0, ctrlRepere.Height));
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
                    itemElementACout.Text = fVal.ToString("0.####") + "   ";
                    if (source is ISatisfactionBesoin)
                        itemElementACout.Text += ((ISatisfactionBesoin)source).LibelleSatisfactionComplet;
                    else
                        itemElementACout.Text += source.Libelle;
                    if (source is ISatisfactionBesoin && utilisateur is CBesoin)
                    {
                        double fPct = CUtilSatisfaction.GetPourcentageFor((CBesoin)utilisateur, (ISatisfactionBesoin)source);
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
                IElementACout elt = item != null ? item.Tag as IElementACout : null;
                if (elt != null)
                {
                    CFormMain.GetInstance().EditeElement(elt.ObjetPourEditionElementACout, false, "");
                }
            }
        }

        //---------------------------------------------------------
        void itemElementACout_Click(object sender, EventArgs e)
        {


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

                    foreach (IElementACout source in elt.GetSourcesDeCout(m_bMenuForCoutReel))
                    {
                        ToolStripItem itemFils = CreateItemSatisfaction(elt, source);
                        if (itemFils != null)
                            item.DropDownItems.Add(itemFils);
                    }
                }
            }
        }
    }
}
