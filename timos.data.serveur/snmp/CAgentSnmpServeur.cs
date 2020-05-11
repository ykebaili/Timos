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

namespace timos.data.snmp.serveur
{
    /// <summary>
    /// Description résumée de CAgentSnmpServeur.
    /// </summary>
    [AutoExec("Autoexec")]
    public class CAgentSnmpServeur : CObjetServeurAvecBlob
    {
        public const string c_cleDataAgentsAMettreAjour = "UPDATETOSNMPAGENTS";
        //-------------------------------------------------------------------
        public CAgentSnmpServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

        //-------------------------------------------------------------------
        public static void Autoexec()
        {
            CContexteDonneeServeur.AddTraitementAvantSauvegarde ( new TraitementSauvegardeExterne(CContexteDonneeServeur_DoTraitementExterneAvantSauvegarde) );
        }
		
        public override string GetNomTable ()
		{
			return CAgentSnmp.c_nomTable;
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
            return typeof(CAgentSnmp);
		}

        //-------------------------------------------------------------------
        internal static HashSet<DataRow> GetTableAgentsAMettreAJourToSnmp(CContexteDonnee ctx, bool bCreateSiNull)
        {
            DataTable table = ctx.Tables[CAgentSnmp.c_nomTable];
            if (table == null)
            {
                if (!bCreateSiNull)
                    return null;
                ctx.GetTableSafe(CAgentSnmp.c_nomTable);
            }
            HashSet<DataRow> rows = table.ExtendedProperties[c_cleDataAgentsAMettreAjour] as HashSet<DataRow>;
            if (rows == null && bCreateSiNull)
            {
                rows = new HashSet<DataRow>();
                table.ExtendedProperties[c_cleDataAgentsAMettreAjour] = rows;
            }
            return rows;
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Fait un traitement global avant sauvegarde pour s'assurer que tous les éléments
        /// qui imposent une mise à jour de l'agent SNMP ont bien préparé la liste des agents
        /// à mettre à jour.
        /// </summary>
        /// <param name="contexte"></param>
        /// <param name="tableData"></param>
        /// <param name="result"></param>
        public static CResultAErreur CContexteDonneeServeur_DoTraitementExterneAvantSauvegarde(CContexteDonnee contexte, Hashtable tableData)
        {
            CResultAErreur result = CResultAErreur.True;
            HashSet<DataRow> rows = GetTableAgentsAMettreAJourToSnmp(contexte, false);
            if (rows != null)
            {
                foreach (DataRow row in rows)
                {
                    CAgentSnmp agent = new CAgentSnmp(row);
                    try
                    {
                        if ( agent.AutoUpdate )
                            result = agent.UpdateToSnmpInCurrentContext(true);
                    }
                    catch (Exception e)
                    {
                        result.EmpileErreur(new CErreurException(e));
                    }
                    if (!result)
                    {
                        string strTexte = I.T("Error while update SNMP agent @1|20157", agent.SnmpIp);
                        strTexte += "\r\n";
                        strTexte += result.Erreur.ToString();
                        C2iEventLog.WriteErreur(strTexte);
                    }
                    result = CResultAErreur.True;
                }
            }
            DataTable table = contexte.Tables[CAgentSnmp.c_nomTable];
            if (table != null)
                table.ExtendedProperties.Remove(c_cleDataAgentsAMettreAjour);
            return result;
        }
		
    }
}
