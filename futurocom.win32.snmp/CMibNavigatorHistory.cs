using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using futurocom.snmp;

namespace futurocom.win32.snmp
{
    public class CMibNavigatorHistory
    {
        private int m_nCurrentIndex = -1;
        private List<IDefinition> m_listeDefinitions = new List<IDefinition>();

        //----------------------------------------------------
        public void SetCurrent(IDefinition definition)
        {
            if (definition != GetCurrent())
            {
                while (m_listeDefinitions.Count()-1 > m_nCurrentIndex)
                    m_listeDefinitions.RemoveAt(m_listeDefinitions.Count() - 1);
                m_listeDefinitions.Add(definition);
                m_nCurrentIndex = m_listeDefinitions.Count - 1;
            }
        }

        //----------------------------------------------------
        public IDefinition GetCurrent()
        {
            if (m_nCurrentIndex >= 0 && m_nCurrentIndex < m_listeDefinitions.Count)
                return m_listeDefinitions[m_nCurrentIndex];
            return null;
        }

        //----------------------------------------------------
        public IDefinition MovePrevious()
        {
            if (m_nCurrentIndex > 0)
            {
                m_nCurrentIndex--;
            }
            return GetCurrent();
        }

        //----------------------------------------------------
        public IDefinition MoveNext()
        {
            if (m_nCurrentIndex <= m_listeDefinitions.Count - 2)
                m_nCurrentIndex++;
            return GetCurrent();
        }

        //----------------------------------------------------
        public bool HasPrevious
        {
            get
            {
                return m_nCurrentIndex > 0;
            }
        }

        //----------------------------------------------------
        public bool HasNext
        {
            get
            {
                return m_nCurrentIndex <= m_listeDefinitions.Count() - 2;
            }
        }


    }
}
