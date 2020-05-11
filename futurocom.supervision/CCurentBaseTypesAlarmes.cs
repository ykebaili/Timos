using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace futurocom.supervision
{
    /// <summary>
    /// Base d'alarmes utilisée partout
    /// </summary>
    public static class CCurentBaseTypesAlarmes
    {
        private static IBaseTypesAlarmes m_baseTypesAlarmes = null;

        //---------------------------------------------------------------------
        public static void SetCurrentBase(IBaseTypesAlarmes baseTypeAlarmes)
        {
            m_baseTypesAlarmes = baseTypeAlarmes;
        }

        //---------------------------------------------------------------------
        public static IBaseTypesAlarmes CurrentBase
        {
            get
            {
                return m_baseTypesAlarmes;
            }
        }
    }
}
