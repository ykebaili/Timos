using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using futurocom.sig;
using sc2i.common;

namespace futurocom.win32.sig
{
    public interface IControleEditeMapItem
    {
        void InitChamps ( IMapItemGenerator item );
        CResultAErreur MajChamps();
        IMapItemGenerator CurrentGenerator { get; }
    }

    public static class CAllocateurInterfaceMapItemGenerator
    {
        private static Dictionary<Type, Type> m_dicTypeToTypeControle = new Dictionary<Type, Type>();

        public static void RegisterControle(Type typeMapItem, Type typeControle)
        {
            m_dicTypeToTypeControle[typeMapItem] = typeControle;
        }

        public static IControleEditeMapItem GetNewControle(IMapItemGenerator item)
        {
            if (item == null)
                return null;
            Type tp = null;
            if (m_dicTypeToTypeControle.TryGetValue(item.GetType(), out tp))
            {
                IControleEditeMapItem ctrl = Activator.CreateInstance(tp, new object[0]) as IControleEditeMapItem;
                return ctrl;
            }
            return null;
        }
    }
}
