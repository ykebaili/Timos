using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.custom;
using System.Windows.Forms;
using sc2i.common;
using sc2i.expression;
using System.Collections;
using sc2i.formulaire;

namespace timos.Controles.ActionsSurLink
{
    [AutoExec("Autoexec")]
    public class CExecuteurMenuItemListDynamique : IExecuteurSpecifiqueActionMenuItem
    {
        //--------------------------------------------------------------------------------------------------------------------------------------
        public static void Autoexec()
        {
            CExecuteurActionSur2iLinkMenuDeroulant.RegisterExecuteurSpécifique(
                typeof(CActionMenuItemListeDynamique),
                new CExecuteurMenuItemListDynamique());
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        private static object GetObjetPourItem ( object objetCiblePrincipal, object objetCibleItem )
        {
            CDefinitionMultiSourceForExpression multi = objetCiblePrincipal as CDefinitionMultiSourceForExpression;
            if ( multi == null )
                return objetCibleItem;
            CDefinitionMultiSourceForExpression copie = new CDefinitionMultiSourceForExpression(objetCibleItem);
            foreach ( string strSource in multi.GetNomSources() )
                copie.AddSource ( strSource, multi.GetSource ( strSource ) );
            return copie;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        public ToolStripItem[] GetItemsForContextMenuStrip(IMenuItem menuItem, object sender, object objetCible)
        {
            List<ToolStripItem> lstRetour = new List<ToolStripItem>();
            CActionMenuItemListeDynamique menu = menuItem as CActionMenuItemListeDynamique;
            if (menu != null && menu.FormuleListeSource != null &&
                menu.FormuleItemLibelle != null)
            {
                CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(objetCible);
                CResultAErreur result = menu.FormuleListeSource.Eval(ctx);
                if (result)
                {
                    object valeur = result.Data;
                    if (valeur is IEnumerable)
                    {
                        foreach (object obj in (IEnumerable)valeur)
                        {
                            ToolStripMenuItem newMenuItem = CreateMenu(menu, GetObjetPourItem(objetCible, obj));
                            if (newMenuItem != null)
                                lstRetour.Add(newMenuItem);
                        }
                    }
                    else if (valeur != null)
                    {
                        ToolStripMenuItem newMenuItem = CreateMenu(menu, GetObjetPourItem(objetCible, valeur));
                        if (newMenuItem != null)
                            lstRetour.Add(newMenuItem);
                    }
                }
            }
            return lstRetour.ToArray();
        }

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

        //-------------------------------------------------------------------------
        private ToolStripMenuItem CreateMenu ( CActionMenuItemListeDynamique menuListe, object objetCible )
        {
            ToolStripMenuItem menuItem = null;
            if ( menuListe.FormuleItemLibelle != null && menuListe.Action != null)
            {
                CContexteEvaluationExpression ctx = new CContexteEvaluationExpression ( objetCible );
                CResultAErreur result = menuListe.FormuleItemLibelle.Eval ( ctx );
                if ( result && result.Data  != null )
                {
                    menuItem = new ToolStripMenuItem(result.Data.ToString());
                    menuItem.Tag = new CCoupleActionObjet(menuListe.Action, objetCible);
                    menuItem.Click += new EventHandler(menuItem_Click);
                }
            }
            return menuItem;
        }
        //-------------------------------------------------------------------------
        void menuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            CCoupleActionObjet couple = item != null ?
                item.Tag as CCoupleActionObjet :
                null;
            if (couple != null)
            {
                CResultAErreur result = CExecuteurActionSur2iLink.ExecuteAction(sender, couple.Action, couple.ObjetCible);
                if (!result)
                    sc2i.win32.common.CFormAlerte.Afficher(result.Erreur);
            }
        }     
    }
   
}
