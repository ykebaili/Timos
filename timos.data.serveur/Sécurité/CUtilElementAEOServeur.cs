using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using sc2i.common;
using sc2i.data;
using timos.securite;
using sc2i.data.serveur;
using sc2i.multitiers.server;

namespace timos.securite
{
	[AutoExec("Autoexec")]
	public class CUtilElementAEOServeur : C2iObjetServeur, IUtilElementAEOServeur
	{
		public CUtilElementAEOServeur ( int nIdSession )
			:base(nIdSession)
		{
		}
		//----------------------------------------------------------------
		public static void Autoexec()
		{
			//Enregistre une fonction qui surveille les éléments à EO
			CContexteDonneeServeur.AddTraitementAvantSauvegarde ( new TraitementSauvegardeExterne(CContexteDonneeServeur_DoTraitementExterneAvantSauvegarde) );
		}

		//----------------------------------------------------------------
		/// <summary>
		/// Nom de la table->Bool qui dit si c'est un élément à EO
		/// </summary>
		private static Hashtable m_tablesElementsAEO = new Hashtable();


		//----------------------------------------------------------------
		/// <summary>
		/// Vérifie que les parents des Elements à eo n'ont pas bougé
		/// </summary>
		/// <param name="contexte"></param>
		/// <param name="result"></param>
		/// <param name="tableData"></param>
		static CResultAErreur CContexteDonneeServeur_DoTraitementExterneAvantSauvegarde(CContexteDonnee contexte, Hashtable tableData)
		{
            CResultAErreur result = CResultAErreur.True;

            ArrayList lstTables = new ArrayList ( contexte.Tables );
			foreach (DataTable table in lstTables)
			{
				object val = m_tablesElementsAEO[table.TableName];
				if (val == null)
				{
					Type tp = CContexteDonnee.GetTypeForTable(table.TableName);
					val = typeof(IElementAEO).IsAssignableFrom(tp);
					m_tablesElementsAEO[table.TableName] = val;
				}
				if ((bool)val)
				{
					Type tp = CContexteDonnee.GetTypeForTable(table.TableName);
					//On vérifie chaque élément
					ArrayList lst = new ArrayList(table.Rows);
					foreach (DataRow row in lst)
					{
						if (row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added)
						{
							IElementAEO elt = (IElementAEO)Activator.CreateInstance(tp, new object[] { row });
							result = OnChangementElementAEO(elt);
							if (!result)
								return result;
						}
					}
				}
			}
            return result;
		}

		public CResultAErreur UpdateEOs(CReferenceObjetDonnee referenceObject)
		{
			CResultAErreur result = CResultAErreur.True;
			using (CContexteDonnee contexte = new CContexteDonnee(IdSession, true, false))
			{
				CObjetDonnee objet = referenceObject.GetObjet(contexte);
				if (objet is IElementAEO)
				{
					result = CUtilElementAEO.UpdateEOSInCurrentContext((IElementAEO)objet);
					if (result)
						result = contexte.SaveAll(true);
					return result;
				}
			}
			return result;
		}

		


		


		//----------------------------------------------------------------
		/// <summary>
		/// Controle si les donnateurs d'EO ont changé, si oui,
		/// répercute les EOS du donnateur sur l'élément et ses héritiers
		/// </summary>
		/// <param name="elt"></param>
		/// <returns></returns>
		public static CResultAErreur OnChangementElementAEO(IElementAEO elt)
		{
			CResultAErreur result = CResultAErreur.True;
			if ( elt == null )
				return result;
			CObjetDonneeAIdNumerique objet = (CObjetDonneeAIdNumerique)elt;
			Hashtable tableParentsOld = new Hashtable();
			Hashtable tableParentsNew = new Hashtable();

			bool bHasChange = objet.Row.RowState == DataRowState.Added;

			if (!bHasChange || objet.Row.RowState == DataRowState.Modified)
			{
				DataRowVersion version = objet.VersionToReturn;
				objet.VersionToReturn = DataRowVersion.Original;
				IElementAEO[] donnateurs = elt.DonnateursEO;
				if (donnateurs != null)
					foreach (IElementAEO donnateur in donnateurs)
						if (donnateur != null)
							tableParentsOld[donnateur] = true;
				
				objet.VersionToReturn = version;
				donnateurs = elt.DonnateursEO;
				if (donnateurs != null)
					foreach (IElementAEO donnateur in donnateurs)
						if (donnateur != null)
						{
							if (!tableParentsOld.Contains(donnateur))
							{
								bHasChange = true;
								break;
							}
							tableParentsNew[donnateur] = true;
						}
				//Vérifie que les anciens sont tous là
				foreach ( IElementAEO old in tableParentsOld.Keys )
					if (!tableParentsNew.Contains(old))
					{
						bHasChange = true;
						break;
					}
			}
			if (bHasChange)
			{
				//On est bon pour retravailler l'élément et tous ses fils
				CUtilElementAEO.UpdateEOSInCurrentContext(elt);
			}


			return result;
		}
	}
}

