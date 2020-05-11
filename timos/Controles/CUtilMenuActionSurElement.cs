using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.data;
using sc2i.process;
using sc2i.common;

namespace timos.Controles
{
    public delegate void MenuActionEventHandler(IDeclencheurAction declencheur, CObjetDonneeAIdNumerique objetAction);

    /// <summary>
    /// Permet de gérer un menu affichant les actions possibles
    /// sur un élément
    /// </summary>
    public static class CUtilMenuActionSurElement
    {

        public static void InitMenuActions(
            CObjetDonneeAIdNumerique objet,
            ToolStripItemCollection listMenusARemplir,
            MenuActionEventHandler onClickMenuActionEventHandler)
        {
            listMenusARemplir.Clear();
            IDeclencheurAction[] declencheurs = CRecuperateurDeclencheursActions.GetActionsManuelles(objet, true);
            if (declencheurs.Length != 0)
            {
                foreach (IDeclencheurAction declencheur in declencheurs)
                {
                    string strMenu = "";
                    if (declencheur is IDeclencheurActionManuelle)
                        strMenu = ((IDeclencheurActionManuelle)declencheur).MenuManuel;
                    string[] strMenus = strMenu.Split('/');
                    ToolStripItemCollection listeSousMenus = listMenusARemplir;
                    if (strMenus.Length > 0)
                    {
                        foreach (string strSousMenu in strMenus)
                        {
                            if (strSousMenu.Trim().Length > 0)
                            {
                                ToolStripMenuItem sousMenu = null;
                                foreach (ToolStripMenuItem item in listeSousMenus)
                                    if (item.Text == strSousMenu)
                                    {
                                        sousMenu = item;
                                        break;
                                    }
                                if (sousMenu == null)
                                {
                                    sousMenu = new ToolStripMenuItem(strSousMenu);
                                    listeSousMenus.Add(sousMenu);
                                }
                                listeSousMenus = sousMenu.DropDownItems;
                            }
                        }
                    }
                    CMenuItemActionManuelle itemAction = new CMenuItemActionManuelle(declencheur, objet);
                    if ( onClickMenuActionEventHandler != null )
                        itemAction.OnMenuAction += new MenuActionEventHandler(onClickMenuActionEventHandler);
                    listeSousMenus.Add(itemAction);
                }
            }
            if (listMenusARemplir.Count == 0)
            {
                ToolStripMenuItem itemActionVide = new ToolStripMenuItem(I.T("(None)|10074"));
                itemActionVide.Enabled = false;
                listMenusARemplir.Add(itemActionVide);

            }
        }


    }

    //------------------------------------------------------------------------
    public class CMenuItemActionManuelle : ToolStripMenuItem
    {
        IDeclencheurAction m_declencheur = null;
        CObjetDonneeAIdNumerique m_objetAction = null;

        //------------------------------------------------------------------------
        public CMenuItemActionManuelle(
            IDeclencheurAction declencheur,
            CObjetDonneeAIdNumerique objetAction)
            : base(declencheur.Libelle)
        {
            m_declencheur = declencheur;
            m_objetAction = objetAction;
            Click += new EventHandler(CMenuItemActionManuelle_Click);
        }

        //------------------------------------------------------------------------
        public IDeclencheurAction Declencheur
        {
            get
            {
                return m_declencheur;
            }
        }

        //------------------------------------------------------------------------
        public CObjetDonneeAIdNumerique ObjetAction
        {
            get
            {
                return m_objetAction;
            }
        }

        //------------------------------------------------------------------------
        public event MenuActionEventHandler OnMenuAction;

        //------------------------------------------------------------------------
        void CMenuItemActionManuelle_Click(object sender, EventArgs e)
        {
            if (OnMenuAction != null)
                OnMenuAction(Declencheur, ObjetAction);
        }


    }
}
