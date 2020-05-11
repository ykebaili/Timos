using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.formulaire;

namespace timos.Controles.ActionsSurLink
{
    public static class CGestionnaireEditeursActionsSur2iLink
    {
        //--------------------------------------------------------------------------
        public class CInfoTypeActionSur2iLink
        {
            public string m_strNomAction = "";
            public readonly Type TypeAction = null;
            public readonly Type TypeEditeur = null;

            public CInfoTypeActionSur2iLink(
                string strNomAction,
                Type typeAction,
                Type typeEditeur)
            {
                m_strNomAction = strNomAction;
                TypeAction = typeAction;
                TypeEditeur = typeEditeur;
            }

            public string NomAction
            {
                get
                {
                    return m_strNomAction;
                }
            }
        }

        //--------------------------------------------------------------------------
        private static Dictionary<Type, CInfoTypeActionSur2iLink> m_dicTypeActionToInfoEditeur = new Dictionary<Type, CInfoTypeActionSur2iLink>();


        //--------------------------------------------------------------------------
        public static void RegisterEditeur(string strNomAction, Type typeAction, Type typeEditeur)
        {
            m_dicTypeActionToInfoEditeur[typeAction] = new CInfoTypeActionSur2iLink(
                strNomAction, typeAction, typeEditeur);
        }

        //--------------------------------------------------------------------------
        public static IEnumerable<CInfoTypeActionSur2iLink> GetTypesActionPossibles()
        {
            List<CInfoTypeActionSur2iLink> lst = new List<CInfoTypeActionSur2iLink>();
            foreach ( CInfoTypeActionSur2iLink info in m_dicTypeActionToInfoEditeur.Values )
                lst.Add ( info );
            lst.Sort( (x,y)=>x.NomAction.CompareTo(y.NomAction));
            return lst.AsReadOnly();
        }

        //--------------------------------------------------------------------------
        public static CInfoTypeActionSur2iLink GetInfoEditeurForAction(CActionSur2iLink action)
        {
            CInfoTypeActionSur2iLink info = null;
            if (action != null)
            {
                if (m_dicTypeActionToInfoEditeur.TryGetValue(action.GetType(), out info))
                    return info;
            }
            return null;
        }
    }
}
