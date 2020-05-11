using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace futurocom.supervision
{
    public interface IEntiteDeclencheuseAlarme
    {
        CDbKey IdSiteAssocie { get; }
        CDbKey IdEquipementLogiqueAssocie { get; }
        CDbKey IdLienReseauAssocie { get; }
        CDbKey IdEntiteSnmpAssociee { get; }
    }


}
