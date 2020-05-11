using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using sc2i.data;
using sc2i.data.dynamic;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;
using timos.securite;

namespace timos.data
{
	/// <summary>
	/// Description 
	/// </summary>
	public class CTypeTableParametrableServeur : CObjetServeurAvecBlob
	{
		//-------------------------------------------------------------------
		public CTypeTableParametrableServeur(int nIdSession)
			: base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable()
		{
			return CTypeTableParametrable.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CTypeTableParametrable tp = (CTypeTableParametrable)objet;

				if (tp.Libelle == "")
					result.EmpileErreur(I.T( "Custom Table Type label cannot be empty|375"));

				CListeObjetsDonnees lst = new CListeObjetsDonnees(tp.ContexteDonnee, typeof(CTypeTableParametrable));

				lst.Filtre = new CFiltreData(CTypeTableParametrable.c_champLibelle + " = @1 AND " + CTypeTableParametrable.c_champId + " <> @2", tp.Libelle, tp.Id);
				if (lst.Count != 0)
					result.EmpileErreur(I.T( "The Custom Table Type '@1' already exists|376", tp.Libelle));



				//Verif ordre des colonnes
				CListeObjetsDonnees lstcol = tp.Colonnes;
				bool bColChanged = false;
				for (int i = 0; i < lstcol.Count; i++)
				{
					bool find = false;
					CColonneTableParametrable colIdx = (CColonneTableParametrable)lstcol[i];
					foreach (CColonneTableParametrable c in lstcol)
					{
						if (c.Row.RowState != DataRowState.Unchanged)
							bColChanged = true;
						if (c.Libelle == colIdx.Libelle && !colIdx.Equals(c))
							result.EmpileErreur(I.T("Column name @1 is used several times|395", colIdx.Libelle));

						if (c.Position == i)
						{
							if (find)
							{
								result.EmpileErreur(I.T("Error : multiple position @1|367", i.ToString()));
								i = lstcol.Count;
								break;
							}
							else
								find = true;
						}
						if (i > 0 && c.Position >= lstcol.Count)
							result.EmpileErreur(I.T("The position @1 of the Column '@2' is out of range|364", c.Position.ToString(), c.Libelle));
					}
					if (!find)
					{
						result.EmpileErreur(I.T("No column defined at position @1|365", i.ToString()));
						break;
					}
				}

				//Verif Ordre Colonne Primaires
				int cptPKCol = 0;
				foreach (CColonneTableParametrable col in tp.ColonnesClePrimaires)
				{
					if(col.PrimaryKeyPosition != cptPKCol)
					{
						result.EmpileErreur(I.T("Column @1 is part of primary key but its position in the key is @2 instead of @3|396", col.Libelle, col.PrimaryKeyPosition.Value.ToString(), cptPKCol.ToString()));
						break;
					}
					cptPKCol++;
				}

				//Si les colonnes ont bougés
				if (bColChanged)
				{
					CFiltreData filtre = new CFiltreData(CTypeTableParametrable.c_champId + " = @1", tp.Id);
					CListeObjetsDonnees lstAttache = new CListeObjetsDonnees(objet.ContexteDonnee, typeof(CTableParametrable), filtre);
					if (lstAttache.Count > 0)
						foreach (CTableParametrable tableliee in lstAttache)
							result.EmpileErreur(I.T("Columns changes error : The table @1 uses this type|366", tableliee.Libelle));
				}
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
			return typeof(CTypeTableParametrable);
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
			foreach (DataRow row in table.Rows)
			{
				if (row.RowState == DataRowState.Modified)
				{
				}
			}
			return result;

		}

	}
}
