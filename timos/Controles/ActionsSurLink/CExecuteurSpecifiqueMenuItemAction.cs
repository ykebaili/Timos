using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.custom;
using System.Windows.Forms;
using sc2i.formulaire;
using sc2i.expression;

namespace timos.Controles.ActionsSurLink
{
    ///////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 
    /// </summary>
    [AutoExec("Autoexec")]
    public class CExecuteurSpecifiqueMenuItemAction : IExecuteurSpecifiqueActionMenuItem
    {
        //----------------------------------------------------------------------
        public CExecuteurSpecifiqueMenuItemAction()
        { }

        //----------------------------------------------------------------------
        public static void Autoexec()
        {
            CExecuteurActionSur2iLinkMenuDeroulant.RegisterExecuteurSpécifique(
                typeof(CActionMenuItem),
                new CExecuteurSpecifiqueMenuItemAction());
        }


        //----------------------------------------------------------------------
        private class CCoupleActionObjet
        {
            public readonly CActionSur2iLink Action;
            public readonly object ObjetCible;

            public CCoupleActionObjet(CActionSur2iLink action,
                object cible)
            {
                Action = action;
                ObjetCible = cible;
            }
        }

        //--------------------------------------------------------------------------
        public ToolStripItem[] GetItemsForContextMenuStrip(IMenuItem menuItem, object sender, object objetCible)
        {
            List<ToolStripItem> listeItems = new List<ToolStripItem>();

            CActionMenuItem actionMenuItem = menuItem as CActionMenuItem;
            if (actionMenuItem != null)
            {
                ToolStripMenuItem newItem = new ToolStripMenuItem(actionMenuItem.Libelle);
                if ( actionMenuItem.FormuleLibelle != null )
                {
                    CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(objetCible);

                    CResultAErreur result = actionMenuItem.FormuleLibelle.Eval(ctx);
                    if (result && result.Data != null)
                        newItem.Text = result.Data.ToString();
                }
                newItem.Tag = new CCoupleActionObjet(actionMenuItem.Action, objetCible);
                if (actionMenuItem.Action != null && actionMenuItem.Action is CActionSur2iLinkMenuDeroulant)
                {
                    CExecuteurActionSur2iLinkMenuDeroulant executeurActionMenu = new CExecuteurActionSur2iLinkMenuDeroulant();
                    CResultAErreur result = executeurActionMenu.ExecuteAction(
                        (CActionSur2iLinkMenuDeroulant)actionMenuItem.Action, sender, objetCible);
                    if (result)
                        newItem.DropDownItems.AddRange((ToolStripItem[])result.Data);
                }
                else
                    newItem.Click += new EventHandler(ActionMenuItem_Click);

                listeItems.Add(newItem);
            }

            return listeItems.ToArray();

        }

        //-------------------------------------------------------------------------------
        public static void ActionMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem itemClic = sender as ToolStripMenuItem;
            if (itemClic != null)
            {
                CCoupleActionObjet coupleAction = itemClic.Tag as CCoupleActionObjet;
                if (coupleAction != null && coupleAction.Action != null)
                {
                    CResultAErreur result = CExecuteurActionSur2iLink.ExecuteAction(itemClic, coupleAction.Action, coupleAction.ObjetCible);
                    if (!result)
                        sc2i.win32.common.CFormAlerte.Afficher(result.Erreur);

                }
            }
        }

    }
}
