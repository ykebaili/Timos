using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.expression;
using System.Windows.Forms;
using sc2i.data.dynamic;
using sc2i.win32.common;

namespace timos.releve.CustomField
{
    public interface IControlChampCustom : IControlALockEdition
    {
        CChampCustom ChampCustom { get; set; }
        void InitChamps ( IElementAChamps elt );
        CResultAErreur MajChamps();

        event EventHandler OnValueChanged;
    }

    public static class CAllocateurControlChampCustom
    {
        private static Dictionary<TypeDonnee, Type> m_dicTypeChampToTypeControle = new Dictionary<TypeDonnee, Type>();

        public static void RegisterControle(TypeDonnee typeChamp, Type typeControle)
        {
            m_dicTypeChampToTypeControle[typeChamp] = typeControle;
        }

        public static Control GetNewControle(TypeDonnee typeChamp)
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
