using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.memorydb;
using sc2i.common;
using futurocom.snmp.entitesnmp;
using sc2i.expression;
using sc2i.common.DonneeCumulee;
using System.Data;
using data.hotel.client;

namespace futurocom.snmp.HotelPolling
{
    [MemoryTable(CSnmpHotelPollingSetup.c_nomTable, CSnmpHotelPollingSetup.c_champId)]
    public class CSnmpHotelPollingSetup : CEntiteDeMemoryDbAIdAuto
    {
        public const string c_IdPollingSystem = "SYS_";

        public const string c_nomTable = "HOTEL_POLLING_SETUP";
        public const string c_champId = "HPOLSET_ID";
        public const string c_champLabel = "HPOLSET_LABEL";

        public const string c_champHotelIP = "HPOLSET_HOTEL_IP";
        public const string c_champHotelPort = "HPOLSET_HOTEL_PORT";
        public const string c_champFrequenceMinutes = "POLSET_FREQ_MINUTES";
        public const string c_champPolledFields = "POLSET_FIELDS_SETTINGS";

        //---------------------------------------
        public CSnmpHotelPollingSetup(CMemoryDb db)
            : base(db)
        {
        }

        //---------------------------------------
        public CSnmpHotelPollingSetup(DataRow row)
            : base(row)
        {
        }

        //---------------------------------------
        public override void MyInitValeursParDefaut()
        {
            Libelle = "";
            HotelPort = 8200;
            FrequenceMinutes = 240;
        }

        //---------------------------------------
        [MemoryField(c_champLabel)]
        [DynamicField("Label")]
        public string Libelle
        {
            get
            {
                return Row.Get<string>(c_champLabel);
            }
            set
            {
                Row[c_champLabel] = value;
            }
        }

        //---------------------------------------
        [MemoryField(c_champHotelIP)]
        [DynamicField("Hotel IP")]
        public string HotelIp
        {
            get
            {
                return Row.Get<string>(c_champHotelIP);
            }
            set
            {
                Row[c_champHotelIP] = value;
            }
        }

        //---------------------------------------
        [MemoryField(c_champHotelPort)]
        [DynamicField("Hotel port")]
        public int HotelPort
        {
            get
            {
                return Row.Get<int>(c_champHotelPort);
            }
            set
            {
                Row[c_champHotelPort] = value;
            }
        }

        //---------------------------------------
        [MemoryField(c_champFrequenceMinutes)]
        [DynamicField("Frequency in minutes")]
        public double FrequenceMinutes
        {
            get
            {
                return Row.Get<double>(c_champFrequenceMinutes);
            }
            set
            {
                Row[c_champFrequenceMinutes] = value;
            }
        }

        //---------------------------------------
        [MemoryParent(true)]
        [DynamicField("Snmp agent")]
        public CAgentSnmpPourSupervision Agent
        {
            get
            {
                return GetParent<CAgentSnmpPourSupervision>();
            }
            set
            {
                SetParent<CAgentSnmpPourSupervision>(value);
            }
        }

        //---------------------------------------
        [DynamicMethod(
            "Add a polled field",
            "Polling formula",
            "Entity Id",
            "Hotel table",
            "Hotel field")]            
        public bool AddFillingField(string strFormula, 
            string strEntityId,
            string strHotelTable,
            string strHotelField)
        {
            try
            {
                //Interprete la formule
                CContexteAnalyse2iExpression ctxAnalyse = new CContexteAnalyse2iExpression(new CFournisseurGeneriqueProprietesDynamiques(), new CObjetPourSousProprietes(Agent));
                CAnalyseurSyntaxiqueExpression analyseur = new CAnalyseurSyntaxiqueExpression(ctxAnalyse);
                CResultAErreur result = analyseur.AnalyseChaine(strFormula);
                if (!result || !(result.Data is C2iExpression))
                    return false;
                C2iExpression formule = result.Data as C2iExpression;
                CSnmpHotelPolledData data = new CSnmpHotelPolledData(
                    formule,
                    strEntityId,
                    strHotelTable,
                    strHotelField);
                CListeSnmpHotelPolledData lst = new CListeSnmpHotelPolledData();
                lst.AddRange(PolledDatas);
                bool bDone = false;
                foreach (CSnmpHotelPolledData p in lst)
                {
                    if ( p.HotelField == strHotelField && p.HotelTable == strHotelTable )
                    {
                        p.Formule = formule;
                        p.EntityId = strEntityId;
                        bDone = true;
                        break;
                    }
                }
                if (!bDone)
                {
                    lst.Add(data);
                }
                PolledDatas = lst;
            }
            catch 
            {
                return false;
            }
            return true;

        }

        //---------------------------------------
        [MemoryField(c_champPolledFields)]
        public CListeSnmpHotelPolledData PolledDatas
        {
            get
            {
                CListeSnmpHotelPolledData p = Row.Get<CListeSnmpHotelPolledData>(c_champPolledFields);
                if (p == null)
                    return new CListeSnmpHotelPolledData(); ;
                return p;
            }
            set
            {
                CListeSnmpHotelPolledData lst = new CListeSnmpHotelPolledData();
                if (value != null)
                {
                    lst.AddRange(value);
                }
                Row[c_champPolledFields] = lst;
            }
        }

        //---------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //---------------------------------------
        protected override CResultAErreur MySerialize(sc2i.common.C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = SerializeChamps(serializer, 
                c_champLabel, 
                c_champHotelIP, 
                c_champHotelPort, 
                c_champFrequenceMinutes, 
                c_champPolledFields);
            if (result)
                result = SerializeParent<CAgentSnmpPourSupervision>(serializer);
            return result;
        }


        //------------------------------------------------------------
        public void DoPoll()
        {
            //Vérifie la connexion à l'hotel
            CDataHotelClient client = new CDataHotelClient(HotelIp, HotelPort);
            if ( client.SafePing())
            {
                //Extrait tous les OID à lire
                HashSet<string> strOids = new HashSet<string>();
                foreach (CSnmpHotelPolledData data in PolledDatas)
                    data.ExtractOids(strOids);
                IList<Variable> lstVars = Agent.ReadSnmp(strOids.ToArray());
                Dictionary<string, object> dicValeurs = new Dictionary<string, object>();
                foreach ( Variable v in lstVars )
                {
                    string strOID = v.Id.ToString();
                    dicValeurs[strOID] = v.Data;
                }

                try
                {
                    CAgentSnmpPourSupervision agent = Agent;
                    agent.SetCacheOID(dicValeurs);

                    //C'est parti
                    foreach (CSnmpHotelPolledData data in PolledDatas)
                    {
                        data.DoPoll(client, agent);
                    }
                }
                finally
                {
                    Agent.SetCacheOID(null);
                }
            }
            
        }
    }
}
