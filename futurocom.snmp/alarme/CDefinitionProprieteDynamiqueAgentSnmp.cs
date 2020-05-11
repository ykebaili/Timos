using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.expression;
using futurocom.snmp.entitesnmp;

namespace futurocom.snmp.alarme
{
    [Serializable]
    public class CDefinitionProprieteDynamiqueAgentSnmp : CDefinitionProprieteDynamiqueInstance
    {
        public CDefinitionProprieteDynamiqueAgentSnmp()
        {
        }

        public CDefinitionProprieteDynamiqueAgentSnmp ( CAgentSnmpPourSupervision agentSnmp )
            : base("SnmpAgent", "SnmpAgent", agentSnmp, "")
        {
        }

        public override string CleType
        {
            get
            {
                return CDefinitionProprieteDynamiqueDotNet.c_strCleTypeDefinition;
            }
        }



    }
}
