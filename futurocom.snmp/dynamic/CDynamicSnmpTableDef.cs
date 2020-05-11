using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.expression;

namespace futurocom.snmp.dynamic
{
    [Serializable]
    public class CDynamicSnmpTableDef : IElementAVariableInstance
    {
        private List<CDefinitionProprieteDynamiqueSnmpColumn> m_listeChamps = new List<CDefinitionProprieteDynamiqueSnmpColumn>();
        //------------------------------------------------------------
        public CDynamicSnmpTableDef(IDefinition definition)
        {
            if (definition.Type == DefinitionType.Table && definition.Children.Count() == 1)
            {
                IDefinition entry = definition.Children.ElementAt(0);
                if (entry.Type == DefinitionType.Entry)
                {
                    foreach (IDefinition champ in entry.Children)
                    {
                        m_listeChamps.Add(new CDefinitionProprieteDynamiqueSnmpColumn(champ));
                    }
                }
            }
        }

        public IEnumerable<CDefinitionProprieteDynamiqueSnmpColumn> Colonnes
        {
            get
            {
                return m_listeChamps.AsReadOnly();
            }
        }


        //------------------------------------------------------------
        public CDefinitionProprieteDynamique[] GetProprietesInstance()
        {
            List<CDefinitionProprieteDynamique> lst = new List<CDefinitionProprieteDynamique>();//m_listeChamps.ConvertAll(c => c as CDefinitionProprieteDynamique));
            lst.Add ( new CDefinitionProprieteDynamiqueSnmpRow(this));
            return lst.ToArray();
        }



    }


    
}
