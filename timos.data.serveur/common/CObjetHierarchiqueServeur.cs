using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
	/// <summary>
	/// Description résumée de CUtilisateurServeur.
	/// </summary>
	public abstract class CObjetHierarchiqueServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CUtilisateurServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CObjetHierarchiqueServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
		{
			CResultAErreur result = base.TraitementAvantSauvegarde (contexte);
			if ( !result )
				return result;

			result = SObjetHierarchiqueServeur.TraitementAvantSauvegarde(contexte, GetNomTable());

			
			return result;
		}
	}

	public static class SObjetHierarchiqueServeur
	{

		//-------------------------------------------------------------------
		private class CRowSorterSurParent : IComparer
		{
			private string m_strColonne = "";
			public CRowSorterSurParent(string strColonne)
			{
				m_strColonne = strColonne;
			}

			public int Compare(object x, object y)
			{
				object val1, val2;
				if (((DataRow)x).RowState == DataRowState.Deleted ||
					((DataRow)y).RowState == DataRowState.Deleted)
					return 0;

				val1 = ((DataRow)x)[m_strColonne];
				val2 = ((DataRow)y)[m_strColonne];
				if (val1 is IComparable && val2 is IComparable)
					return ((IComparable)val1).CompareTo((IComparable)val2);
				if (val1.Equals(val2))
					return 0;
				return -1;
			}

		}


		//-------------------------------------------------------------------
		public static CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte, string strNomTable)
		{
			CResultAErreur result = CResultAErreur.True;
			if (!result)
				return result;

			DataTable table = contexte.Tables[strNomTable];

			ArrayList lstRows = new ArrayList(table.Rows);

			CObjetHierarchique objet = (CObjetHierarchique)Activator.CreateInstance(CContexteDonnee.GetTypeForTable(strNomTable), new object[] { contexte });

			lstRows.Sort(new CRowSorterSurParent(objet.ChampIdParent));

			object lastParent = DBNull.Value;
			int nLastCode = 0;
			foreach (DataRow row in lstRows)
			{
				//Allocation du code famille
				objet = (CObjetHierarchique)Activator.CreateInstance(CContexteDonnee.GetTypeForTable(strNomTable), new object[] { row });
				if (objet.Row.RowState != DataRowState.Deleted && (objet.CodeSystemePartiel == objet.CodePartielDefaut || HasChange(objet, objet.ChampIdParent)))
				{
					if (!objet.Row[objet.ChampIdParent].Equals(lastParent))
					{
						nLastCode = 0;
						lastParent = objet.Row[objet.ChampIdParent];
					}
					AlloueCode(objet, ref nLastCode);
				}
			}
			return result;
		}

		//-------------------------------------------------------------------
		private static bool HasChange(CObjetDonnee objet, string strColonne)
		{
			DataRow row = objet.Row;
			if (row.RowState == DataRowState.Deleted)
				return false;
			if (row.RowState == DataRowState.Modified)
			{
				object val = row[strColonne, DataRowVersion.Original];
				object valNew = row[strColonne];
				return !valNew.Equals(val);
			}
			if (row.RowState == DataRowState.Added)
				return true;
			return false;
		}

		//-------------------------------------------------------------------
		private static string GetCle(int nValeur, int nNbCars)
		{
			string strCaracteresCode = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			string strCle = "";
			while (nNbCars > 0)
			{
				int nLow = nValeur % strCaracteresCode.Length;
				nValeur = (int)(nValeur - nLow) / strCaracteresCode.Length;
				strCle = strCaracteresCode[nLow] + strCle;
				nNbCars--;
			}
			return strCle;
		}

		//-------------------------------------------------------------------
		private static void AlloueCode(CObjetHierarchique objet, ref int nLastCodeAlloue)
		{
			CFiltreData filtre = null;
			if (objet.ObjetParent != null)
				filtre = new CFiltreData(objet.ChampIdParent + "=@1",
					objet.ObjetParent.Id);
			else
				filtre = new CFiltreData(objet.ChampIdParent + " is null and "+
					objet.ChampCodeSystemePartiel+">@1", GetCle ( nLastCodeAlloue, objet.NbCarsParNiveau) );

			CListeObjetsDonnees listeSoeurs = new CListeObjetsDonnees(objet.ContexteDonnee, objet.GetType(), filtre);
			listeSoeurs.AssureLectureFaite();

			listeSoeurs.InterditLectureInDB = true;

			Hashtable tableCodesUtilises = new Hashtable();
			foreach (CObjetHierarchique obj in listeSoeurs)
				tableCodesUtilises[obj.CodeSystemePartiel] = true;

			//Cherche le prochain numéro libre 
			int nCpt = nLastCodeAlloue;
			string strCle = "";
			do
			{
				nCpt++;
				strCle = GetCle(nCpt, objet.NbCarsParNiveau);
				/*listeSoeurs.Filtre = new CFiltreData(objet.ChampCodeSystemePartiel + "=@1",
					strCle);*/
			}
			while (tableCodesUtilises.ContainsKey ( strCle ));
			nLastCodeAlloue = nCpt;
			objet.ChangeCodePartiel(strCle);
		}
	}
}
