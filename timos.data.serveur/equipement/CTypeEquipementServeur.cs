using System;
using System.Collections;
using System.Data;


using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.multitiers.client;
using timos.acteurs;

namespace timos.data
{
	/// <summary>
	/// Description résumée de CTypeEquipementServeur.
	/// </summary>
	public class CTypeEquipementServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
		public CTypeEquipementServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CTypeEquipement.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur TraitementAvantSauvegarde ( CContexteDonnee contexte )
		{
			CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
			if (!result)
				return result;

            
			//On charge la liste des parametrages
			CListeObjetsDonnees lstobjParam = new CListeObjetsDonnees(contexte, typeof(CParametrageSystemeCoordonnees));

			DataTable dt = contexte.Tables[CTypeEquipement.c_nomTable];
			ArrayList rows = new ArrayList(dt.Rows);
			//foreach (DataRow dr in rows)
			//{
			//    if (dr.RowState == DataRowState.Modified || dr.RowState == DataRowState.Added)
			//    {
			//        //CTypeEquipement typeEquipement = new CTypeEquipement(dr);
			//        //lstobjParam.Filtre = new CFiltreData(CTypeEquipement.c_champId + " = @1", typeEquipement.Id);
			//        //lstobjParam.RowStateFilter = DataViewRowState.OriginalRows;
			//        //CParametrageSystemeCoordonnees paramOld = null;
			//        //if(lstobjParam.Count == 1)
			//        //    paramOld = (CParametrageSystemeCoordonnees)lstobjParam[0];

			//        //result = SDefinisseurSystemeCoordonnees.VerifieDonnees(typeEquipement, paramOld);
			//        //if (!result.Result)
			//        //    break;
			//    }
			//}


            

			return result;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CTypeEquipement typeEquipement = (CTypeEquipement)objet;

				if ( typeEquipement.Libelle == "")
					result.EmpileErreur(I.T("The equipment type label cannot be empty|255"));

				if (!CObjetDonneeAIdNumerique.IsUnique(typeEquipement, CTypeEquipement.c_champLibelle, typeEquipement.Libelle))
					result.EmpileErreur(I.T("This equipment type label already exist|256"));

				//Vérifie les héritages cycliques !!
				foreach ( CRelationTypeEquipement_Heritage heritage in typeEquipement.RelationsTypesFils )
					if (typeEquipement.HeriteDe(heritage.TypeFils))
					{
						result.EmpileErreur(I.T("Cyclic inheritance (child) @1|257",heritage.TypeFils.Libelle ));
						break;
					}
				foreach (CRelationTypeEquipement_Heritage heritage in typeEquipement.RelationsTypesParents)
				{
					if (heritage.TypeParent.HeriteDe(typeEquipement))
					{
						result.EmpileErreur(I.T("Cyclic inheritance (parent) @1|258", heritage.TypeFils.Libelle));
						break;
					}
				}

				if (typeEquipement.Famille == null)
					result.EmpileErreur(I.T("The Equipment Type must be associated to a family|124"));

			}
			catch ( Exception e )
			{
				result.EmpileErreur( new CErreurException ( e ) );
			}
			return result;
		}
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CTypeEquipement);
		}


	}
}
