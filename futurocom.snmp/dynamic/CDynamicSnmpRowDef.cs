using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.expression;

namespace futurocom.snmp.dynamic
{
    [Serializable]
    public class CDynamicSnmpRowDef : IElementAVariableInstance
    {
        private List<CDefinitionProprieteDynamique> m_listeChamps = new List<CDefinitionProprieteDynamique>();
        
        //------------------------------------------------------------
        public CDynamicSnmpRowDef(CDynamicSnmpTableDef table)
        {
            foreach ( CDefinitionProprieteDynamiqueSnmpColumn def in table.Colonnes )
            {
                m_listeChamps.Add ( new CDefinitionProprieteDynamicSnmpCell ( def ) );
            }
        }

        //------------------------------------------------------------
        public CDefinitionProprieteDynamique[] GetProprietesInstance()
        {
            List<CDefinitionProprieteDynamique> lst = new List<CDefinitionProprieteDynamique>();
            lst.Add(new CDefinitionProprieteDynamicSnmpCell("Index", "Index", typeof(int), true));
            lst.AddRange((m_listeChamps.ConvertAll(c => c as CDefinitionProprieteDynamique)));
            return lst.ToArray();
        }
    }
}
