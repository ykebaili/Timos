using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data;

namespace timos.data.snmp
{
    /// <summary>
    /// Element qui possède des entités SNMP
    /// il s'agit soit d'un agent snmp , soit d'une entité qui possède des sous entités
    /// </summary>
    public interface IConteneurEntitesSnmp
    {
        CListeObjetsDonnees EntitesRacines { get; }
    }
}
