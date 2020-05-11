using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.expression;
using futurocom.snmp.dynamic;

namespace futurocom.snmp.alarme
{
    [Serializable]
    public class CDefinitionProprieteDynamiqueInterrogateurSnmp : CDefinitionProprieteDynamiqueInstance
    {
        //Se comporte comme une proporiete DotNet, car il s'agit bien d'un proprieté .Net
        public const string c_cleType = CDefinitionProprieteDynamiqueDotNet.c_strCleTypeDefinition;

        public CDefinitionProprieteDynamiqueInterrogateurSnmp()
            : base()
        {
        }

        public CDefinitionProprieteDynamiqueInterrogateurSnmp(CInterrogateurSnmp agent)
            : base("Snmp", "AgentSNMPAssocie", agent, "")
        {
        }

        public override string CleType
        {
            get
            {
                return c_cleType;
            }
        }

    }
}
