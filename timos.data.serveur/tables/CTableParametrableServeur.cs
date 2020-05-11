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
	/// Description résumée de CTableParametrableServeur.
	/// </summary>
	public class CTableParametrableServeur : CObjetServeurAvecBlob
	{
		//-------------------------------------------------------------------
		public CTableParametrableServeur(int nIdSession)
			: base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable()
		{
			return CTableParametrable.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CTableParametrable tb = (CTableParametrable)objet;
				if (tb.Libelle == "")
					result.EmpileErreur(I.T( "Custom Table label cannot be empty|373"));

				CListeObjetsDonnees lst = new CListeObjetsDonnees(tb.ContexteDonnee, typeof(CTableParametrable));

				//Nom unique dans son parent
				if (tb.ElementLie == null)
					lst.Filtre = new CFiltreData(
						CTableParametrable.c_champLibelle + " = @1 AND " + CTableParametrable.c_champId + " <> @2", tb.Libelle, tb.Id);
				else
				{
					IElementATableParametrable elt = tb.ElementLie;
					if (elt is CSite)
						lst.Filtre = new CFiltreData(CTableParametrable.c_champLibelle + "=@1 and " +
							CSite.c_champId + "=@2 and "+
							CTableParametrable.c_champId+"<>@3",
							tb.Libelle,
							((CSite)elt).Id,
							tb.Id);
					if (elt is CEquipement)
						lst.Filtre = new CFiltreData(CTableParametrable.c_champLibelle + "=@1 and " +
							CEquipement.c_champId + "=@2 and "+
							CTableParametrable.c_champId+"<>@3",
							tb.Libelle,
							((CEquipement)elt).Id,
							tb.Id);
				}
				if (lst.CountNoLoad != 0)
					result.EmpileErreur(I.T( "The Custom Table '@1' already exists|374", tb.Libelle));

				if(tb.TypeTable == null)
					result.EmpileErreur(I.T( "Custom Table '@1' must have a Custom Table Type|392", tb.Libelle));

				if (tb.Site != null && tb.Equipement != null)
					result.EmpileErreur(I.T( "Custom Table '@1' cannot be linked to both Site (@2) Site and Equipment (@3)|393", tb.Libelle, tb.Site.Libelle, tb.Equipement.Libelle));

				if (tb.ElementLie != null && tb.TypeTable != null)
				{
					bool typetablecompatible = false;
					CListeObjetsDonnees lstTypesPoss = tb.ElementLie.TypesTableParametrablePossibles;
					foreach (CTypeTableParametrable tt in lstTypesPoss)
						if (tt.Equals(tb.TypeTable)) 
						{
							typetablecompatible = true;
							break;
						}

					if(!typetablecompatible)
						result.EmpileErreur(I.T( "The Custom Table Type '@1' of the custom table '@2' isn't compatible with element '@3'|394", tb.TypeTable.Libelle, tb.Libelle, tb.ElementLie.DescriptionElement));

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
			return typeof(CTableParametrable);
		}


		//private static DateTime dtstart;
		//public override CResultAErreur TraitementApresSauvegarde(CContexteDonnee contexte, bool bOperationReussie)
		//{
		//    string duree = DateTime.Now.Subtract(dtstart).TotalMilliseconds.ToString();
		//    return base.TraitementApresSauvegarde(contexte, bOperationReussie);

		//}
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

			//dtstart = DateTime.Now;
			return result;

		}

	}
}

