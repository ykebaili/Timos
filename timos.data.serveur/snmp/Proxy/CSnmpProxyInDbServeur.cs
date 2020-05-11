using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;
using timos.securite;
using timos.data.snmp;
using timos.data.snmp.Proxy;
using System.Net;
using futurocom.snmp.Proxy;
using sc2i.common.synchronisation;
using sc2i.common.memorydb;

namespace timos.data.serveur
{
    /// <summary>
    /// Description résumée de CSnmpProxyInDbServeur.
    /// </summary>
    public class CSnmpProxyInDbServeur : CObjetServeur
    {
        //-------------------------------------------------------------------
        public CSnmpProxyInDbServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
            return CSnmpProxyInDb.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;

            CSnmpProxyInDb proxy = objet as CSnmpProxyInDb;
            if (proxy != null)
            {
                if (proxy.Libelle.Trim() == string.Empty)
                    result.EmpileErreur(I.T("Proxy label cannot be empty|10020"));
                if(proxy.AdresseIp == string.Empty)
                    result.EmpileErreur(I.T("Proxy IP Address must be defined|10021"));
                if (proxy.Port < IPEndPoint.MinPort || proxy.Port > IPEndPoint.MaxPort)
                    result.EmpileErreur(I.T("Proxy IP Port not valid|10022"));
            }
           
			return result;
		}

		//---------------------------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
            return typeof(CSnmpProxyInDb);
		}


        //---------------------------------------------------------------------------------------
        /*public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result =  base.TraitementAvantSauvegarde(contexte);
            if (!result)
                return result;
            DataTable table = contexte.Tables[GetNomTable()];
            if (table == null)
                return result;

            ArrayList lstRows = new ArrayList(table.Rows);
            HashSet<DataRow> rowsToSend = table.ExtendedProperties[GetType()] as HashSet<DataRow>;
            if (rowsToSend == null)
            {
                rowsToSend = new HashSet<DataRow>();
                table.ExtendedProperties[GetType()] = rowsToSend;
            }
            foreach (DataRow row in lstRows)
            {
                if (row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added)
                {
                    rowsToSend.Add(row);
                }
                if (row.RowState == DataRowState.Deleted)
                {
                    rowsToSend.Add(row);
                }
            }

            return result;
        }*/

        //---------------------------------------------------------------------------------------
        /*public override CResultAErreur TraitementApresSauvegarde(CContexteDonnee contexte, bool bOperationReussie)
        {
            CResultAErreur result = base.TraitementApresSauvegarde(contexte, bOperationReussie);

            if (!result)
                return result;
            DataTable table = contexte.Tables[GetNomTable()];
            if (table == null)
                return result;

            HashSet<DataRow> rowsToSend = table.ExtendedProperties[GetType()] as HashSet<DataRow>;
            if (rowsToSend == null)
                return result;

            HashSet<CSnmpProxyInDb> listeProxiesAMettreAJour = new HashSet<CSnmpProxyInDb>();

            foreach (DataRow row in rowsToSend)
            {
                //if (row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added)
                {
                    CSnmpProxyInDb proxy = new CSnmpProxyInDb(row);
                    FillHashSetProxiesAMettreAJour(proxy, listeProxiesAMettreAJour);
                }
            }

            foreach (CSnmpProxyInDb proxy in listeProxiesAMettreAJour)
            {
                if (proxy != null)
                {
                    System.Net.IPHostEntry h = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
                    //string strMonIp = ((System.Net.IPAddress)h.AddressList.GetValue(0)).ToString();
                    bool bContinue = false;
                    foreach (IPAddress ip in h.AddressList)
                    {
                        if (proxy.AdresseIp == ip.ToString())
                        {
                            CSnmpProxyConfiguration config = proxy.GetConfiguration();
                            

                            
                            CSnmpProxyConfiguration.SetDefaultInstance(proxy.GetConfiguration());
                            bContinue = true;
                        }
                    }
                    if (bContinue)
                        continue;

                    CSynchroniseurBaseDistante.GetSynchroniseur(IdSession).AddOperation(
                        IdSession,
                        proxy.CleBaseDistante,
                        new COperationSynchronisationSurAgentSynchronisation(
                            typeof(CSnmpConfigurationSynchroniseur),
                            proxy.AdresseIp,
                            EOperationSynchronisationSurAgentSynchronisation.CreateOrUpdate,
                            proxy.Id.ToString()));
                }

            }

            table.ExtendedProperties.Remove(GetType());

            return result;
        }*/

        /*
        private void FillHashSetProxiesAMettreAJour(CSnmpProxyInDb proxy, HashSet<CSnmpProxyInDb> hs)
        {
            hs.Add(proxy);
            foreach (CLienDeProxy lien in proxy.LiensDeProxySource)
            {
                if(!hs.Contains(lien.ProxySource))
                    FillHashSetProxiesAMettreAJour(lien.ProxySource, hs);
            }
        }*/

    }
}
