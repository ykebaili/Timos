using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using futurocom.snmp;

namespace futurocom.win32.snmp
{
    public interface ISNMPClassViewer
    {
        void DisplayElement ( IDefinition definition );

        IMibNavigator MibNavigator { get; set; }
    }

    public static class CSNMPClassViewer
    {
        //----------------------------------------------------------------------------------------
        private static Dictionary<Type, Type> m_dicTypeToViewer = new Dictionary<Type, Type>();

        //----------------------------------------------------------------------------------------
        public static void RegisterViewer(Type typeObjetSNMP, Type typeViewer)
        {
            m_dicTypeToViewer[typeObjetSNMP] = typeViewer;
        }

        //----------------------------------------------------------------------------------------
        public static Type GetViewerTypeFor(IDefinition definition)
        {
            if (definition == null)
                return null;
            IEntity entite = definition.Entity;
            if (entite == null)
                return null;
            Type tpViewer = null;
            m_dicTypeToViewer.TryGetValue(entite.GetType(), out tpViewer);
            return tpViewer;
        }
    }
}
