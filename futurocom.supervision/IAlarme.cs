using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace futurocom.supervision
{
    public interface IAlarme
    {
        CDbKey TypeAlarmeId { get; }
        CDbKey SiteId { get; }
        CDbKey LienId { get; }
        CDbKey EquipementId { get; }
        CDbKey EntiteSnmpId { get; }
    }
}
