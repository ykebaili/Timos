using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimosInventory.data;
using sc2i.common;
using sc2i.expression;
using System.Windows.Forms;

namespace TimosInventory.CustomField
{
    public interface IControlChampCustom
    {
        CChampCustom ChampCustom { get; set; }
        void InitChamps ( IElementAChamps elt );
        CResultAErreur MajChamps();

        event EventHandler OnValueChanged;
    }

    public static class CAllocateurControlChampCustom
    {
        private static Dictionary<ETypeChampBasique, Type> m_dicTypeChampToTypeControle = new Dictionary<ETypeChampBasique, Type>();

        public static void RegisterControle(ETypeChampBasique typeChamp, Type typeControle)
        {
            m_dicTypeChampToTypeControle[typeChamp] = typeControle;
        }

        public static Control GetNewControle(ETypeChampBasique typeChamp)
        {
            Type tp = null;
            m_dicTypeChampToTypeControle.TryGetValue(typeChamp, out tp);
            if (tp != null)
            {
                return (Control)Activator.CreateInstance(tp, new object[0]);
            }
            return null;
        }
    }
}
