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

namespace timos.data.serveur
{
    /// <summary>
    /// Description résumée de CLienDeProxyServeur.
    /// </summary>
    public class CLienDeProxyServeur : CObjetServeurAvecBlob
    {
        //-------------------------------------------------------------------
        public CLienDeProxyServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
            return CLienDeProxy.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
           
			return result;
		}

        //-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
            return typeof(CLienDeProxy);
		}


        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
            if (!result)
                return result;
            DataTable table = contexte.Tables[GetNomTable()];
            if (table == null)
                return result;

            ArrayList lstRows = new ArrayList(table.Rows);
            foreach (DataRow row in lstRows)
            { 
                CLienDeProxy lien = new CLienDeProxy(row);
                if (row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added)
                {
                    lien.ProxySource.ForceChangementSyncSession();
                }
                else if (row.RowState == DataRowState.Deleted)
                {
                    DataRowVersion versionActuelle = lien.VersionToReturn;
                    lien.VersionToReturn = DataRowVersion.Original;
                    if(!lien.ProxySource.IsDeleted)
                        lien.ProxySource.ForceChangementSyncSession();
                    lien.VersionToReturn = versionActuelle;
                }
            }


            return result;
        }

    }
}
