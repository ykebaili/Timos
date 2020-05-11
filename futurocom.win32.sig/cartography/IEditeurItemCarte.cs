using sc2i.common;
using sc2i.win32.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace futurocom.win32.sig.cartography
{
    public interface IEditeurItemCarte : IControlALockEdition
    {
        void Init(object item);
        void RefreshData();
        event EventHandler OnModification;
    }

    public static class CGestionnaireEditionItemCarte
    {
        private static Dictionary<Type, Type> m_dicTypeObjetToTypeEditeur = new Dictionary<Type, Type>();

        //------------------------------------------------------------------------------
        public static void RegisterEditeur ( Type typeObjet, Type typeEditeur )
        {
            m_dicTypeObjetToTypeEditeur[typeObjet] = typeEditeur;
        }

        //------------------------------------------------------------------------------
        public static Type GetTypeEditeur ( Type typeObjet )
        {
            Type tp = null;
            m_dicTypeObjetToTypeEditeur.TryGetValue(typeObjet, out tp);
            return tp;
        }
    }
}
