using System;
using System.Linq;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;
using timos.securite;
using sc2i.data.dynamic.loader;
using timos.data.snmp;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using timos.data.snmp.serveur;

namespace timos.data.serveur
{
	/// <summary>
	/// Description résumée de CRelationEntiteSnmp_ChampCustomServeur.
	/// </summary>
	public class CRelationEntiteSnmp_ChampCustomServeur : CRelationElementAChamp_ChampCustomServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CRelationEO_ChampCustomServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationEntiteSnmp_ChampCustomServeur( int nIdSession )
			:base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationEntiteSnmp_ChampCustom.c_nomTable;
		}
		
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationEntiteSnmp_ChampCustom);
		}

        //-------------------------------------------------------------------
        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
            if (!result)
                return result;
            DataTable table = contexte.Tables[GetNomTable()];
            if (table == null)
                return result;
            HashSet<DataRow> rowsAgent = null;
            ArrayList lstRows = new ArrayList(table.Rows);
            HashSet<CEntiteSnmp> entitesARecalculer = new HashSet<CEntiteSnmp>();
            foreach (DataRow row in lstRows)
            {
                if (row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added)
                {
                    if (rowsAgent == null)
                        rowsAgent = CAgentSnmpServeur.GetTableAgentsAMettreAJourToSnmp(contexte, true);
                    if (rowsAgent != null)
                    {
                        CRelationEntiteSnmp_ChampCustom rel = new CRelationEntiteSnmp_ChampCustom(row);
                        CEntiteSnmp entite = rel.ElementAChamps as CEntiteSnmp;
                        if (entite != null)
                        {
                            entitesARecalculer.Add ( entite );
                            rowsAgent.Add(entite.AgentSnmp.Row.Row);
                        }
                    }
                }
            }

            foreach (CEntiteSnmp entite in entitesARecalculer)
            {
                entite.RecalcLibelle();
            }
            return result;
        }
		
        
       
	}
}
