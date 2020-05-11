using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

using tiag.client;

using timos.data;
using futurocom.snmp.Mib;
using timos.data.snmp;
using futurocom.snmp;
using futurocom.easyquery;
using futurocom.snmp.alarme;
using futurocom.snmp.entitesnmp;
using futurocom.snmp.dynamic;
using futurocom.easyquery.snmp;
using futurocom.snmp.Proxy;
using System.Data;

namespace timos.data.snmp.Proxy
{
    /// <summary>
    /// 
    /// </summary>
    [DynamicClass("SNMP Proxy Link")]
    [Table(CLienDeProxy.c_nomTable, CLienDeProxy.c_champId, true)]
    [FullTableSync]
    [ObjetServeurURI("CLienDeProxyServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModuleSNMP)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParametrageSnmp_ID)]
    public class CLienDeProxy : CObjetDonneeAIdNumeriqueAuto, IElementADonneePourMediationSNMP
    {
        public const string c_nomTable = "SNMP_PROXY_LINK";
        public const string c_champId = "SNMP_PRXLNK_ID";
        public const string c_champProxyDest = "SNMP_PRXLNK_DEST";
        public const string c_champDataListePlages = "SNMP_PRXLNK_DATA";
        // Champs hors BDD
        public const string c_champCacheListePlages = "SNMP_PRXLNK_CACHE";

        /// /////////////////////////////////////////////
        public CLienDeProxy(CContexteDonnee contexte)
            : base(contexte)
        {
        }

        /// /////////////////////////////////////////////
        public CLienDeProxy(DataRow row)
            : base(row)
        {
        }
        
        public override string DescriptionElement
        {
            get { return I.T("SNMP Proxy Link from @1 to @2", ProxySource.Libelle, ProxyDestination.Libelle); }
        }

        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champId };
        }

        protected override void MyInitValeurDefaut()
        {
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [Relation(
            CSnmpProxyInDb.c_nomTable,
            CSnmpProxyInDb.c_champId,
            CSnmpProxyInDb.c_champId,
            true,
            true,
            false)]
        [DynamicField("Source Proxy")]
        public CSnmpProxyInDb ProxySource
        {
            get
            {
                return (CSnmpProxyInDb)GetParent(CSnmpProxyInDb.c_champId, typeof(CSnmpProxyInDb));
            }
            set
            {
                SetParent(CSnmpProxyInDb.c_champId, value);
            }
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [Relation(
            CSnmpProxyInDb.c_nomTable,
            CSnmpProxyInDb.c_champId,
            c_champProxyDest,
            true,
            false,
            false)]
        [DynamicField("Destination Proxy")]
        public CSnmpProxyInDb ProxyDestination
        {
            get
            {
                return (CSnmpProxyInDb)GetParent(c_champProxyDest, typeof(CSnmpProxyInDb));
            }
            set
            {
                SetParent(c_champProxyDest, value);
            }
        }

        //--------------------------------------------------------------------------------
        [TableFieldProperty(c_champDataListePlages, NullAutorise = true)]
        public CDonneeBinaireInRow DataListePlagesIp
        {
            get
            {
                if (Row[c_champDataListePlages] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champDataListePlages);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champDataListePlages, donnee);
                }
                return ((CDonneeBinaireInRow)Row[c_champDataListePlages]).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champDataListePlages] = value;
            }
        }

        /// /////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champCacheListePlages, IsInDb = false, NullAutorise = true)]
        [BlobDecoder]
        public List<CPlageIP> PlagesIP
        {
            get
            {
                // Retourne la valeur en cache
                if (Row[c_champCacheListePlages] != DBNull.Value)
                    return (List<CPlageIP>)Row[c_champCacheListePlages];
                // Sinon récupère la valeur en Base
                List<CPlageIP> listePlages = new List<CPlageIP>();
                if (DataListePlagesIp != null && DataListePlagesIp.Donnees != null)
                {
                    MemoryStream stream = new MemoryStream(DataListePlagesIp.Donnees);
                    try
                    {
                        BinaryReader reader = new BinaryReader(stream);
                        CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);
                        CResultAErreur result = serializer.TraiteListe<CPlageIP>(listePlages);
                        if (!result)
                        {
                            listePlages.Clear();
                        }
                        reader.Close();
                    }
                    catch
                    { }
                    finally
                    {
                        stream.Close();
                    }
                }

                CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheListePlages, listePlages);
                return listePlages;
            }
        }

        public void AddPlage(CPlageIP plage)
        {
            PlagesIP.Add(plage);
            CommitListPlages();
            //int n = PlagesIP.Count;
        }

        public void Remove(CPlageIP plage)
        {
            PlagesIP.Remove(plage);
            CommitListPlages();
        }

        public void ClearPlages()
        {
            PlagesIP.Clear();
            CommitListPlages();
        }

        public void CommitListPlages()
        {
            List<CPlageIP> listePlages = PlagesIP;
            CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheListePlages, DBNull.Value);
            CDonneeBinaireInRow data = DataListePlagesIp;
            if (listePlages == null)
            {
                data.Donnees = null;
                DataListePlagesIp = data;
            }
            else
            {
                MemoryStream stream = new MemoryStream();
                try
                {
                    BinaryWriter writer = new BinaryWriter(stream);
                    CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
                    CResultAErreur result = serializer.TraiteListe<CPlageIP>(listePlages);
                    writer.Close();
                    if (result)
                    {
                        data.Donnees = stream.GetBuffer();
                    }
                }
                catch
                {
                    data.Donnees = null;
                }
                finally
                {
                    stream.Close();
                }
                DataListePlagesIp = data;
            }
        }

        #region IElementADonneePourMediationSNMP Membres

        //-------------------------------------------------------
        public int[] IdsProxysConcernesParDonneesMediation
        {
            get 
            {
                return new int[0];
            }
        }

        //-------------------------------------------------------
        public int[] IdsProxysConcernesParConfigurationProxy
        {
            get 
            { 
                List<int> lst = new List<int>();
                if (Row.HasVersion(DataRowVersion.Current))
                {
                    if (ProxySource != null)
                        lst.Add(ProxySource.Id);
                    if (ProxyDestination != null)
                        lst.Add(ProxyDestination.Id);
                }
                    
                if (Row.HasVersion(DataRowVersion.Original))
                {
                    object oldProxy = Row[CSnmpProxyInDb.c_champId, DataRowVersion.Original];
                    if (oldProxy is int)
                        lst.Add((int)oldProxy);
                    oldProxy = Row[c_champProxyDest, DataRowVersion.Original];
                    if (oldProxy is int)
                        lst.Add((int)oldProxy);
                }
                return lst.ToArray();
            }
        }

        #endregion
        


    }
}
