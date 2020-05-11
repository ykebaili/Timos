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
    public class CExecuteurSpecifiqueMenuItemLabel : IExecuteurSpecifiqueActionMenuItem
    {
        //----------------------------------------------------------------------
        public CExecuteurSpecifiqueMenuItemLabel()
        { }

        //----------------------------------------------------------------------
        public static void Autoexec()
        {
            CExecuteurActionSur2iLinkMenuDeroulant.RegisterExecuteurSpécifique(
                typeof(CLabelMenuItem),
                new CExecuteurSpecifiqueMenuItemLabel());
        }


       

        //--------------------------------------------------------------------------
        public ToolStripItem[] GetItemsForContextMenuStrip(IMenuItem menuItem, object sender, object objetCible)
        {
            List<ToolStripItem> listeItems = new List<ToolStripItem>();

            CLabelMenuItem LabelMenuItem = menuItem as CLabelMenuItem;
            if (LabelMenuItem != null)
            {
                CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(objetCible);
                string strLabel = "?";
                if (LabelMenuItem.FormuleLibelle != null)
                {
                    CResultAErreur result = LabelMenuItem.FormuleLibelle.Eval(ctxEval);
                    if (result && result.Data != null)
                        strLabel = result.Data.ToString();
                }
                ToolStripLabel newItem = new ToolStripLabel(strLabel);
                listeItems.Add(newItem);
            }

            return listeItems.ToArray();

        }

       

    }
}
