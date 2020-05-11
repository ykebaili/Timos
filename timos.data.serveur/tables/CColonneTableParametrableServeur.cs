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
	/// Description résumée de CColonneTableParametrableServeur.
	/// </summary>
	public class CColonneTableParametrableServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
		public CColonneTableParametrableServeur(int nIdSession)
			: base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable()
		{
			return CColonneTableParametrable.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CColonneTableParametrable col = (CColonneTableParametrable)objet;
				if (col.TypeDonneeChamp == null)
					result.EmpileErreur(I.T("Column Data Type must be defined|377"));
				if (col.Position < 0)
					result.EmpileErreur(I.T("Invalid Column position|378"));


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
			return typeof(CColonneTableParametrable);
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
