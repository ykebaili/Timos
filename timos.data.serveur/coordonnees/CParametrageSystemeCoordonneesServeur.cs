using System;
using System.Collections;
using System.Data;
using System.Reflection;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

namespace timos.data
{
	/// <summary>
	/// Description résumée de CParametrageSystemeCoordonneesServeur.
	/// </summary>
	public class CParametrageSystemeCoordonneesServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
		public CParametrageSystemeCoordonneesServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CParametrageSystemeCoordonnees.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CParametrageSystemeCoordonnees parametrageSystemeCoordonnees = (CParametrageSystemeCoordonnees)objet;

				//Verification qu'il y est une table cible
				if (parametrageSystemeCoordonnees.ObjetASystemeDeCoordonnees == null)
					result.EmpileErreur(I.T("Coordinate system setting must be related to an object type|184"));

				/*if (result.Result && !parametrageSystemeCoordonnees.CanEdit)
					result.EmpileErreur(I.T( "Coordinate system is currently used by objetcs, it cannot be modified|187"));*/

			}
			catch (Exception e)
			{
				result.EmpileErreur(new CErreurException(e));
			}
			return result;
		}
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CParametrageSystemeCoordonnees);
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
			ArrayList lst = new ArrayList(table.Rows);
			foreach (DataRow row in lst)
			{
				if (row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added)
				{
					//Le paramétrage a été modifié, il faut vérifie s'il y a le droit de le modifier
					CParametrageSystemeCoordonnees parametrage = new CParametrageSystemeCoordonnees(row);
					result = parametrage.IsModifValide();
					if (!result)
						return result;
				}
			}




			return result;
		}


		//------------------------------------------------
		private static string m_strRequeteParametrageInUse = "";

		private class CLockerIsUsed { }

		public bool IsUsed(int[] nIdsParametrages)
		{
			if (nIdsParametrages == null ||
				nIdsParametrages.Length == 0)
				return false;
			using (CContexteDonnee contexte = new CContexteDonnee(IdSession, true, false))
			{
				C2iRequeteAvancee requete = new C2iRequeteAvancee(contexte.IdVersionDeTravail);
				string strIds = "";
				foreach (int nId in nIdsParametrages)
					strIds += nId.ToString() + ",";
				strIds = strIds.Substring(0, strIds.Length - 1);

				lock (typeof(CLockerIsUsed))
				{
					if (m_strRequeteParametrageInUse == "")
					{
						#region Construction de la requÃƒÂªte
						foreach (CInfoRelation relation in CContexteDonnee.GetListeRelationsTable(CParametrageSystemeCoordonnees.c_nomTable))
						{
							if (relation.TableFille == CParametrageSystemeCoordonnees.c_nomTable)
							{
								string strTableObjetAFils = relation.TableParente;
								Type tp = CContexteDonnee.GetTypeForTable(strTableObjetAFils);
								if ( typeof ( IObjetASystemeDeCoordonnee ).IsAssignableFrom (tp) )
								{
									IObjetASystemeDeCoordonnee objTmp = (IObjetASystemeDeCoordonnee)Activator.CreateInstance ( tp, contexte );
									string strProprieteToObjetsAFils = objTmp.ProprieteVersObjetsAFilsACoordonneesUtilisantLeParametrage;
									
									if ( strProprieteToObjetsAFils != "" )
									{
										PropertyInfo info = objTmp.GetType().GetProperty ( strProprieteToObjetsAFils );
										if ( info == null )
											throw new Exception (I.T( "@1 does not have the property @2|242", tp.ToString(), strProprieteToObjetsAFils ));
										object[] attributs = info.GetCustomAttributes ( typeof(RelationFilleAttribute), true);
										if ( attributs == null || attributs.Length != 1 )
											throw new Exception(I.T("The property @1 of the @2 type have no 'ChildAttributeRelation'|243", strProprieteToObjetsAFils, objTmp.GetType().ToString() ));
										tp = ((RelationFilleAttribute)attributs[0]).TypeFille;
									}

									if (typeof(IObjetAFilsACoordonnees).IsAssignableFrom(tp))
									{
										CStructureTable structure = CStructureTable.GetStructure(tp);
										//C'est un fils ÃƒÂ  coordonnées
										//Cherche toutes les relations de ce fils avec des objets ÃƒÂ  coordonnées
										foreach (CInfoRelation relationToObjetACoordonnee in structure.RelationsFilles)
											if (relationToObjetACoordonnee.TableParente == strTableObjetAFils)
											{
												Type tpFils = CContexteDonnee.GetTypeForTable(relationToObjetACoordonnee.TableFille);
												if (typeof(IObjetACoordonnees).IsAssignableFrom(tpFils))
												{
													string strPrefixe = strProprieteToObjetsAFils;
													if (strPrefixe != "")
														strPrefixe += ".";
													//On a une relation vers un fils
													m_strRequeteParametrageInUse += "has(" + strPrefixe + strTableObjetAFils + "." + relationToObjetACoordonnee.Propriete + "." + relationToObjetACoordonnee.ChampsFille[0] + ") or ";
												}
											}
									}

								}
							}
						}
						if (m_strRequeteParametrageInUse != "")
							m_strRequeteParametrageInUse = m_strRequeteParametrageInUse.Substring(0, m_strRequeteParametrageInUse.Length - 4);
						#endregion
					}

				}
				if (m_strRequeteParametrageInUse == "")
					return false;

				CListeObjetsDonnees liste = new CListeObjetsDonnees(contexte, typeof(CParametrageSystemeCoordonnees));
				liste.Filtre = new CFiltreDataAvance(
					CParametrageSystemeCoordonnees.c_nomTable,
					CParametrageSystemeCoordonnees.c_champId + " in (" +
					strIds + ") and (" +
					m_strRequeteParametrageInUse+")");
				if (liste.CountNoLoad == 0)
					return false;
			}
			return true;
		}
	}
}
