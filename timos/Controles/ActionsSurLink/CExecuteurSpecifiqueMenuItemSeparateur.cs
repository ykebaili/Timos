using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.custom;
using System.Windows.Forms;
using sc2i.formulaire;

namespace timos.Controles.ActionsSurLink
{
    ///////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 
    /// </summary>
    [AutoExec("Autoexec")]
    public class CExecuteurSpecifiqueMenuItemSeparateur : IExecuteurSpecifiqueActionMenuItem
    {
        //----------------------------------------------------------------------
        public CExecuteurSpecifiqueMenuItemSeparateur()
        { }

        //----------------------------------------------------------------------
        public static void Autoexec()
        {
            CExecuteurActionSur2iLinkMenuDeroulant.RegisterExecuteurSpécifique(
                typeof(CSeparateurMenuItem),
                new CExecuteurSpecifiqueMenuItemSeparateur());
        }


        //--------------------------------------------------------------------------
        public ToolStripItem[] GetItemsForContextMenuStrip(IMenuItem menuItem, object sender, object objetCible)
        {
            List<ToolStripItem> listeItems = new List<ToolStripItem>();

            CSeparateurMenuItem SeparateurMenuItem = menuItem as CSeparateurMenuItem;
            if (SeparateurMenuItem != null)
            {
                ToolStripSeparator newItem = new ToolStripSeparator();
                listeItems.Add(newItem);
            }

            return listeItems.ToArray();

        }

        

    }
}
