using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.expression;
using sc2i.common;

namespace futurocom.snmp.entitesnmp
{
    public interface IChampEntiteSNMP : I2iSerializable
    {
        [DynamicField("Field name")]
        string NomChamp { get; set; }

        [DynamicField("Data type")]
        ETypeChampBasique TypeChamp { get; set; }

        string Id { get; }

        [DynamicField("Description")]
        string Description { get; set; }

        [DynamicField("Read only")]
        bool IsReadOnly { get; set; }
    }
}
