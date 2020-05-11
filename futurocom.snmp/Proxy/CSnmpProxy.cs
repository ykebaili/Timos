using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using sc2i.common;
using System.Net;
using System.Collections;
using sc2i.common.memorydb;
using System.Data;
using futurocom.snmp.entitesnmp;

namespace futurocom.snmp.Proxy
{
    [Serializable]
    [MemoryTable(CSnmpProxy.c_nomTable, CSnmpProxy.c_champId)]
    public class CSnmpProxy : CEntiteDeMemoryDbAIdAuto, IComparable, I2iSerializable
    {
        public const string c_nomTable = "SNMP_PROXY";
        public const string c_champId = "SNMPPRX_ID";
        public const string c_champLibelle = "SNMPPRX_LABEL";
        public const string c_champAdresseIp = "SNMPPRX_IP";
        public const string c_champPort = "SNMPPRX_PORT";
        public const string c_champPriorite = "SNMPPRX_PRIORITY";
        public const string c_champPlagesIp = "SNMPPRX_PORTTRAP";
        public const string c_champProxyPrev = "SNMPPRX_PREVPRX";
        public const string c_champPollingFreq = "SNMPPRX_POLL_FREQ";

        public CSnmpProxy(CMemoryDb db)
            : base(db)
        {
        }

        public CSnmpProxy(DataRow row)
            : base(row)
        {
        }

        public override void MyInitValeursParDefaut()
        {
            IsProxyPrev = false;
        }


        //-------------------------------------------------------------------------
        [MemoryField(c_champLibelle)]
        [DynamicField("Label")]
        public string Libelle
        {
            get
            {
                return Row.Get<string>(c_champLibelle);
            }
            set
            {
                Row[c_champLibelle] = value;
            }
        }

        // Pour compatibilité (à supprimer)
        public string NomProxy
        { get { return Libelle; } }

        //-------------------------------------------------------------------------
        [DynamicField("IP Ranges")]
        [MemoryField(c_champPlagesIp)]
        public IEnumerable<CPlageIP> PlagesIP
        {
            get
            {
                IEnumerable<CPlageIP> plages = Row.Get<IEnumerable<CPlageIP>>(c_champPlagesIp);
                if (plages == null)
                {
                    plages = new List<CPlageIP>();
                    Row[c_champPlagesIp] = plages;
                }
                return plages;
            }
        }

        public List<CPlageIP> PlagesIPList
        {
            get
            {
                return (List<CPlageIP>)PlagesIP;
            }
        }

        public void AddPlage(CPlageIP plage)
        {
            PlagesIPList.Add(plage);
        }

        public void RemovePlage(CPlageIP plage)
        {
            PlagesIPList.Remove(plage);
        }

        public void ClearPlages()
        {
            PlagesIPList.Clear();
        }

        //-------------------------------------------------------------------------
        [MemoryField(c_champAdresseIp)]
        [DynamicField("IP Address")]
        public IPAddress AdresseIP 
        {
            get
            {
                return Row.Get<IPAddress>(c_champAdresseIp);
            }
            set
            {
                Row[c_champAdresseIp] = value;
            }
        }


        //-------------------------------------------------------------------------
        [MemoryField(c_champPort)]
        [DynamicField("Port")]
        public int Port
        {
            get
            {
                return Row.Get<int>(c_champPort);
            }
            set
            {
                if (value < IPEndPoint.MinPort || value > IPEndPoint.MaxPort)
                    throw new Exception(I.T("Proxy @1, Port number @2 is out of range|10000", Libelle, value.ToString()));
                Row[c_champPort] = value;
            }
        }

        //-------------------------------------------------------------------------
        [MemoryField(c_champPollingFreq)]
        [DynamicField("Polling frequency")]
        public double FrequencePollingMinutes
        {
            get
            {
                return Row.Get<double>(c_champPollingFreq);
            }
            set
            {
                Row[c_champPollingFreq] = value;
            }
        }


        //-------------------------------------------------------------------------
        [MemoryField(c_champPriorite)]
        [DynamicField("Priority")]
        public int Priorite
        {
            get
            {
                return Row.Get<int>(c_champPriorite);
            }
            set
            {
                Row[c_champPriorite] = value;
            }
        }

        //-------------------------------------------------------------------------
        [MemoryField(c_champProxyPrev)]
        [DynamicField("Is Previous Proxy")]
        public bool IsProxyPrev
        {
            get
            {
                return Row.Get<bool>(c_champProxyPrev);
            }
            set
            {
                Row[c_champProxyPrev] = value;
            }
        }
        
        //-------------------------------------------------------------------------
        public IPEndPoint ProxyEndPoint
        {
            get
            {
                return new IPEndPoint(AdresseIP, Port);
            }
        }

        //-------------------------------------------------------------------------
        // Indique si cette IP est gérée par ce Proxy
        public bool GereIP(IPAddress ip)
        {
            foreach (CPlageIP plage in PlagesIPList)
            {
                if (plage.Match(ip))
                    return true;
            }
            return false;
        }

        //--------------------------------------------------------------------------
        [MemoryChild]
        [DynamicChilds("SNMP Agents", typeof(CAgentSnmpPourSupervision))]
        public CListeEntitesDeMemoryDb<CAgentSnmpPourSupervision> Agents
        {
            get
            {
                return GetFils<CAgentSnmpPourSupervision>();
            }
        }

        //-------------------------------------------------------------------------
        public int CompareTo(object obj)
        {
            return this.Priorite - ((CSnmpProxy)obj).Priorite;
        }

        //-------------------------------------------------------------------------
        ///Pour debug
        public string GetConnexionString()
        {
            return "tcp://" + AdresseIP + ":" + Port + "/ISnmpConnexion";
        }

        //-------------------------------------------------------------------------
        internal ISnmpConnexion GetConnexion()
        {
            return (ISnmpConnexion)Activator.GetObject(typeof(ISnmpConnexion),
                GetConnexionString());
        }


        //-------------------------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-------------------------------------------------------------------------
        protected override CResultAErreur MySerialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;

            SerializeChamps(
                serializer,
                c_champLibelle,
                c_champAdresseIp,
                c_champPort,
                c_champPriorite,
                c_champPlagesIp);

            return result;
        }
       
    }

}
