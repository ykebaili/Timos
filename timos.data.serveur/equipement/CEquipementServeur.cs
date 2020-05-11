using System;
using System.Data;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;


namespace timos.data
{
	/// <summary>
	/// Description résumée de CEquipementServeur.
	/// </summary>
	public class CEquipementServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
		public CEquipementServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CEquipement.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CEquipement equipement = (CEquipement)objet;

				if (equipement.TypeEquipement == null )
					result.EmpileErreur (I.T( "The Equipment type cannot be null|109"));

				if (equipement.Statut == null)
					result.EmpileErreur(I.T( "The Equipment Status must be defined|125"));

                if (equipement.Emplacement == null)
                    result.EmpileErreur(I.T("Select an initial place for the equipment|137"));

                else
                {
                    if (equipement.EquipementContenant != null)
                    {
                        CTypeEquipement[] typeIncluantPoss = equipement.TypeEquipement.TousLesTypesIncluants;
                        bool bTypePoss = false;
                        foreach (CTypeEquipement tEqtPoss in typeIncluantPoss)
                        {
                            if (tEqtPoss == equipement.EquipementContenant.TypeEquipement)
                            {
                                bTypePoss = true;
                                break;
                            }
                        }
                        if (!bTypePoss)
                            result.EmpileErreur(I.T("The parent Equipment '@1' cannot contain this Equipment because its type isn't in the incluable types list|10000", equipement.EquipementContenant.Libelle));

                        if (equipement.Emplacement.Id != equipement.EquipementContenant.Emplacement.Id)
                        {
                            result.EmpileErreur(I.T("The Equipment '@1' place cannot be different from the container equipment '@2' place|30000", equipement.Libelle, equipement.EquipementContenant.Libelle));
                        }
                    }
                }
                    
				if (result)
					result = SObjetAFilsACoordonneeServeur.VerifieDonnees(equipement);

				if ( result )
					result =equipement.VerifieCoordonnee();

				/*if (result)
					result = CUtilElementAChamps.VerifieDonnees(equipement);*/


			}
			catch ( Exception e )
			{
				result.EmpileErreur( new CErreurException ( e ) );
			}
			return result;
		}

        //----------------------------------------------------------------------------------
		public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
		{
			CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
			if (!result)
				return result;

			DataTable dt = contexte.Tables[CEquipement.c_nomTable];
			ArrayList rows = new ArrayList(dt.Rows);
			CResultAErreur resultloc = CResultAErreur.True;
			foreach (DataRow row in rows)
			{
				if (row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added || row.RowState == DataRowState.Deleted )
				{
                    CEquipement eqpt = new CEquipement(row);

					/*if (eqpt.ParametrageCoordonneesApplique == null)
						eqpt.Coordonnee = "";*/


					CStock stockApres = null;
					if ( row.RowState != DataRowState.Deleted )
						stockApres = eqpt.EmplacementStock;

                    if (row.HasVersion(DataRowVersion.Original))
                    {
                        DataRowVersion currentVersion = eqpt.VersionToReturn;
                        eqpt.VersionToReturn = DataRowVersion.Original;
                        CTypeEquipement typeAvant = eqpt.TypeEquipement;
                        CStock stockAvant = eqpt.EmplacementStock;
                        eqpt.VersionToReturn = currentVersion;

                        if (stockAvant == stockApres)
                            return result;

                        if (stockAvant != null && stockAvant.IsValide())
                        {
                            // Descrémente le nombre en stock 
                            CRelationTypeEquipement_Stock rel = stockAvant.GetRelationTypeEquipemetStock(typeAvant);
                            if (rel != null && rel.NombreEnStock > 0)
                            {
                                int nbAvant = rel.NombreEnStock;
                                rel.Row[CRelationTypeEquipement_Stock.c_champNombreEnStock] = rel.NombreEnStock - 1;
                            }
                        }
                    }

                    
                    if (stockApres != null && stockApres.IsValide())
                    {
                        // Incrémente le nombre en stock
                        CRelationTypeEquipement_Stock rel = stockApres.GetRelationTypeEquipemetStock(eqpt.TypeEquipement);
                        if (rel != null)
                            rel.Row[CRelationTypeEquipement_Stock.c_champNombreEnStock] = rel.NombreEnStock + 1;
                    }

					result = SObjetAFilsACoordonneeServeur.TraitementAvantSauvegarde(eqpt);
					if (!result)
						return result;
				}
				
			}

			return result;
		}

        
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CEquipement);
		}
		//-------------------------------------------------------------------

	
	}
}
