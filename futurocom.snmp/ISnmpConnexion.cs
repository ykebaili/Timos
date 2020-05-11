using System;
using sc2i.common;
using futurocom.snmp.mediation;
using futurocom.snmp.Proxy;
using futurocom.supervision;
using sc2i.common.memorydb;
using sc2i.common.trace;
using sc2i.common.DonneeCumulee;
using System.Collections.Generic;
namespace futurocom.snmp
{
    public interface ISnmpConnexion
    {
        string Community { get; set; }
        System.Net.IPEndPoint EndPoint { get; set; }
        CResultAErreurType<System.Collections.Generic.IList<Variable>> Get(System.Collections.Generic.IList<Variable> variables);
        CResultAErreurType<Variable> Get(uint[] oid);
        CResultAErreurType<System.Data.DataTable> GetTable(uint[] oid, params uint[][] colonnesAPrendre);
        CResultAErreur Set(uint[] oid, object valeur);
        int TimeOut { get; set; }
        VersionCode Version { get; set; }
        sc2i.common.CResultAErreurType<System.Collections.Generic.IList<Variable>> Walk(uint[] oid);

        CResultAErreur CreateUpdateObjet(object objet);
        CResultAErreur DeleteObjet(Type typeObjet, string strIdObjet);
        CResultAErreurType<CMappageIdsAlarmes> RemonteAlarmes(CMemoryDb dbContenantLesAlarmesARemonter);
        void RedescendAlarmes(CMemoryDb dbContenantLesAlarmesARedescendre);

        void UpdateAgentIpFromMediation(string strAgentId, string strNewIp, bool bUpdateTimosDb);

        IServiceMediation ServiceMediation { get; }

        void NotifyProxyNecessiteMAJ(int nIdProxy, bool bConfigProxy, bool bServiceMediation, bool bFullSync);

        IDonneeSynchronisationMediation GetDonneesPourSynchro(int nIdProxy, int nIdLastSyncSessionConnue);
        CSnmpProxyConfiguration GetConfigurationDeSnmpProxy(int nIdProxy);

        void SetConfigurationDeSnmpProxy(CSnmpProxyConfiguration config);

        void RemoveTraceListener(IFuturocomTraceListener proxy);

        void AddTraceListener(IFuturocomTraceListener proxy);

        void CalcTimeoutFromIp();

        /// <summary>
        /// Envoie des données poolées au serveur
        /// </summary>
        /// <param name="lstDonnees"></param>
        /// <returns></returns>
        CResultAErreur SendDonneesPooled(List<CDonneeCumuleeTransportable> lstDonnees);
    }
}
