using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.formulaire;
using sc2i.custom;

namespace timos.Controles.ActionsSurLink
{
    public class CGestionnaireControlEditeurSpecifiqueMenuItem
    {
        //--------------------------------------------------------------------------
        public class CInfoTypeMenuItemEditeur
        {
            public string m_strNomMenuItem = "";
            public readonly Type TypeMenuItem = null;
            public readonly Type TypeEditeurSpecifique = null;

            public CInfoTypeMenuItemEditeur(
                string strNomMenuItem,
                Type typeMenuItem,
                Type typeEditeurSpecifique)
            {
                m_strNomMenuItem = strNomMenuItem;
                TypeMenuItem = typeMenuItem;
                TypeEditeurSpecifique = typeEditeurSpecifique;
            }

            public string NomMenuItem
            {
                get
                {
                    return m_strNomMenuItem;
                }
            }
        }

        //--------------------------------------------------------------------------
        private static Dictionary<Type, CInfoTypeMenuItemEditeur> m_dicTypeMenuItemToInfoEditeurSpecifique = new Dictionary<Type, CInfoTypeMenuItemEditeur>();


        //--------------------------------------------------------------------------
        public static void RegisterEditeurSpecifique(string strNomMenuItem, Type typeMenuItem, Type typeEditeurSpecifique)
        {
            m_dicTypeMenuItemToInfoEditeurSpecifique[typeMenuItem] = new CInfoTypeMenuItemEditeur(
                strNomMenuItem, typeMenuItem, typeEditeurSpecifique);
        }

        //--------------------------------------------------------------------------
        public static IEnumerable<CInfoTypeMenuItemEditeur> GetTypesMenuItemsPossibles()
        {
            List<CInfoTypeMenuItemEditeur> lst = new List<CInfoTypeMenuItemEditeur>();
            foreach (CInfoTypeMenuItemEditeur info in m_dicTypeMenuItemToInfoEditeurSpecifique.Values)
                lst.Add(info);
            lst.Sort((x, y) => x.NomMenuItem.CompareTo(y.NomMenuItem));
            return lst.AsReadOnly();
        }

        //--------------------------------------------------------------------------
        public static CInfoTypeMenuItemEditeur GetInfoEditeurForMenuItem(IMenuItem menuItem)
        {
            CInfoTypeMenuItemEditeur info = null;
            if (menuItem != null)
            {
                if (m_dicTypeMenuItemToInfoEditeurSpecifique.TryGetValue(menuItem.GetType(), out info))
                    return info;
            }
            return null;
        }
    }

}

