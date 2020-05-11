using sc2i.common;
using System;
namespace futurocom.snmp
{
    /// <summary>
    /// Type assignment interface.
    /// </summary>
    public interface ITypeAssignment : IConstruct
    {
        /// <summary>
        /// Name.
        /// </summary>
        string Name { get; }

        SnmpType SnmpType { get; }

    }
}
