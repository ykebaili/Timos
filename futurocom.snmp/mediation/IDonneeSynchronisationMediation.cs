using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.memorydb;
using sc2i.common;
using sc2i.common.DonneeCumulee;

namespace futurocom.snmp.mediation
{
    public interface IDonneeSynchronisationMediation
    {
        int IdSyncSessionDesDonnees{get;}
        CMemoryDb Database{get;}
    }

    public interface ISynchroniseurServiceMediation
    {
        IDonneeSynchronisationMediation GetUpdatesForProxy(int nIdProxy, int nIdSynchroLastDonneesConnues);

        CResultAErreur SendDonneesPooled(List<CDonneeCumuleeTransportable> lstDonnees);
    }
}
