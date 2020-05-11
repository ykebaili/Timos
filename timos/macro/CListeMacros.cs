using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data.dynamic.Macro;

namespace timos.macro
{
    public static class CListeMacros
    {
        private static List<CMacro> m_listeMacros = new List<CMacro>();

        public static void AddMacro(CMacro macro)
        {
            m_listeMacros.Add(macro);
        }

        public static void RemoveMacro(CMacro macro)
        {
            m_listeMacros.Remove(macro);
        }

        public static IEnumerable<CMacro> Macros
        {
            get
            {
                return m_listeMacros.AsReadOnly();
            }

        }

        public static IEnumerable<CMacro> GetMacrosOn(Type typeElement)
        {
            return from m in m_listeMacros where m.VariableCible != null && m.VariableCible.TypeDonnee.TypeDotNetNatif == typeElement select m;
        }

    }
}
