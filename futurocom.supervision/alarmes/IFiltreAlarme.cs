using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace futurocom.supervision
{
    public interface IFiltreAlarme: I2iSerializable
    {
        bool IsInFiltre(IAlarme alarme);

        HashSet<CDbKey> ListeIdsTypesAlarmes { get; set; }
        HashSet<CDbKey> ListeIdsSites { get; set; }
        HashSet<CDbKey> ListeIdsEquipementsLogiques { get; set; }
        HashSet<CDbKey> ListeIdsLiensReseau { get; set; }
        HashSet<CDbKey> ListeIdsEntiesSnmp { get; set; }
    }
}
