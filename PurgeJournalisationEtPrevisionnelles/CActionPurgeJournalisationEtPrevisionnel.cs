using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using sc2i.common;
using sc2i.process;
using sc2i.process.serveur;
using sc2i.data;
using sc2i.multitiers.client;
using sc2i.data.serveur;
using System.Collections;
using sc2i.data.dynamic;


namespace PurgeAudilog
{
	[AutoExec("Autoexec")]
	public class CActionPurgeJournalisationEtPrevisionnel : IActionSurServeur
	{

		public CActionPurgeJournalisationEtPrevisionnel()
			: base()
		{
		}

		public static void Autoexec()
		{
			CDeclencheurActionSurServeur.RegisterAction(new CActionPurgeJournalisationEtPrevisionnel());
		}



		#region IActionSurServeur Membres

		public string CodeType
		{
			get { return "PURGE_JOURN_PREV"; }
		}

		public string Description
		{
			get { return "Purge la journalisation et le prévisionnel"; }
		}

		public CResultAErreur Execute(int nIdSession, System.Collections.Hashtable valeursParametres)
		{
			CResultAErreur result = CResultAErreur.True;
			using (CContexteDonnee contexte = new CContexteDonnee(nIdSession, true, false))
			{
				CSessionClient session = CSessionClient.GetSessionForIdSession ( nIdSession );
				session.BeginTrans();
				try
				{
					CHandlerEvenementServeur.SuspendGestionnaire(true);
					IDatabaseConnexion connexion = CSc2iDataServer.GetInstance().GetDatabaseConnexion(nIdSession, typeof(CVersionDonneesObjetServeur));
					//Supprime les versions
					string strRequete = "delete from " + CVersionDonneesObjetOperation.c_nomTable;
					result = connexion.RunStatement(strRequete);
					if (!result)
						return result;

					strRequete = "delete from " + CVersionDonneesObjet.c_nomTable;
					result = connexion.RunStatement(strRequete);
					if (!result)
						return result;

					foreach (CInfoRelation info in CContexteDonnee.GetListeRelationsTable(CVersionDonnees.c_nomTable))
					{
						if (info.TableParente == CVersionDonnees.c_nomTable)
						{
							strRequete = "update " + info.TableFille + " set " +
								info.ChampsFille[0] + "=null where " +
								info.ChampsFille[0] + " is not null";
							result = connexion.RunStatement(strRequete);
							if (!result)
								return result;
						}
					}
					strRequete = "delete from " + CVersionDonnees.c_nomTable;
					result = connexion.RunStatement(strRequete);
					if (!result)
						return result;

					contexte.SetVersionDeTravail(-1, false);
					//Charge toutes les tables
					List<Type> typesAChamps = new List<Type>();
					foreach (Type tp in CContexteDonnee.GetAllTypes())
					{
						contexte.GetTableSafe(CContexteDonnee.GetNomTableForType(tp));
						if (typeof(IObjetDonneeAChamps).IsAssignableFrom(tp))
							typesAChamps.Add ( tp );
					}

					/*Problème sur les champs custom : parfois (c'est rare, mais ça arrive
					 * les valeurs de champs ne sont pas supprimées alors que l'entité est bien
					 * supprimée. On ne sait pas pourquoi, mais les lignes suivantes
					 * règlent le problème*/
                    foreach (Type tp in typesAChamps)
                    {
                        string strNomTable = CContexteDonnee.GetNomTableForType(tp);
                        IObjetDonneeAChamps elt = (IObjetDonneeAChamps)Activator.CreateInstance(tp, new object[] { contexte });
                        string strTableValeurs = elt.GetNomTableRelationToChamps();
                        strRequete = "Update " + strTableValeurs + " set " +
                            CSc2iDataConst.c_champIsDeleted + "=1 where " +
                            elt.GetChampId() + " in (select " + elt.GetChampId() + " from " +
                            strNomTable + " where " + CSc2iDataConst.c_champIsDeleted + "=1)";
                        result = connexion.RunStatement(strRequete);
                        if (!result)
                            return result;
                    }

					ArrayList lstTables = CContexteDonnee.GetTableOrderDelete(contexte);

                    DataTable tableChampsCustomEnDernier = null;
					foreach (DataTable table in lstTables)
					{
                        /* J'ai un problème avec la table Champs Custom
                         * La requête suivante ne passe pas même directement dans SQL Server
                         * DELETE FROM CUSTOM_FIELD WHERE (SC2I_VERSION IS NOT NULL) OR (SC2I_DELETED = 1)
                         * Si je ne traite pas cette table, la purge se passe bien
                         *  */
                        if (table.TableName == CChampCustom.c_nomTable)
                        {
                            tableChampsCustomEnDernier = table;
                            continue;
                        }
						if (table.Columns.Contains(CSc2iDataConst.c_champIdVersion))
						{
							 strRequete = "delete from " + table.TableName + " where " +
								CSc2iDataConst.c_champIdVersion + " is not null or " +
								CSc2iDataConst.c_champIsDeleted + "=1";
							result = connexion.RunStatement(strRequete);
							if (!result)
								return result;
						}
					}

                    //if (tableChampsCustomEnDernier != null)
                    //{
                    //    if (tableChampsCustomEnDernier.Columns.Contains(CSc2iDataConst.c_champIdVersion))
                    //    {
                    //        strRequete = "delete from " + tableChampsCustomEnDernier.TableName + " where " +
                    //           CSc2iDataConst.c_champIdVersion + " is not null or " +
                    //           CSc2iDataConst.c_champIsDeleted + "=1";
                    //        result = connexion.RunStatement(strRequete);
                    //        if (!result)
                    //            return result;
                    //    }
                    //}


				}
				catch (Exception e)
				{
					result.EmpileErreur(new CErreurException(e));
				}
				finally
				{
					CHandlerEvenementServeur.SuspendGestionnaire(false);
					if (!result)
						session.RollbackTrans();
					else
						result = session.CommitTrans();
				}
			}

			
			return result;
		}

		public string Libelle
		{
			get { return "Purge journalisation et prévisionnelles"; }
		}

		public string[] NomsParametres
		{
			get { return new string[] {  }; }
		}

		#endregion
	}
}
