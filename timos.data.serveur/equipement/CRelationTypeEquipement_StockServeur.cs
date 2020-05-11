using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

using sc2i.workflow.serveur;

namespace timos.data
{
	/// <summary>
	/// Description résumée de CRelationTypeEquipement_StockServeur.
	/// </summary>
	public class CRelationTypeEquipement_StockServeur : CObjetServeur
	{


		//-------------------------------------------------------------------
		public CRelationTypeEquipement_StockServeur( int nIdSession )
			:base ( nIdSession )
		{
		}

		
		/// ////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CRelationTypeEquipement_Stock relation = (CRelationTypeEquipement_Stock)objet;
				if ( relation.TypeEquipement == null )
					result.EmpileErreur(I.T( "The Equipment type cannot be null|109"));
				if ( relation.Stock == null )
					result.EmpileErreur(I.T( "The Stock cannot be null|205"));
			}
			catch ( Exception e )
			{
				result.EmpileErreur( new CErreurException(e));
			}
			return result;
		}

		/// ////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CRelationTypeEquipement_Stock.c_nomTable;
		}


		/// ////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CRelationTypeEquipement_Stock);
		}

        //------------------------------------------------------------------------------------
        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result =  base.TraitementAvantSauvegarde(contexte);
            if (!result)
                return result;

            DataTable dt = contexte.Tables[CRelationTypeEquipement_Stock.c_nomTable];
            ArrayList rows = new ArrayList(dt.Rows);
            CResultAErreur resultloc = CResultAErreur.True;
            foreach (DataRow row in rows)
            {
                if (row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added)
                {
                    CRelationTypeEquipement_Stock rel = new CRelationTypeEquipement_Stock(row);
                    int nbApres = rel.NombreEnStock;

                    if (row.HasVersion(DataRowVersion.Original))
                    {
                        DataRowVersion currentVersion = rel.VersionToReturn;
                        rel.VersionToReturn = DataRowVersion.Original;
                        int nbAvant = rel.NombreEnStock;
                        rel.VersionToReturn = currentVersion;
                        // Si seuil Alerte atteint
                        if (nbAvant > rel.StockAlerteApplique && nbApres <= rel.StockAlerteApplique)
                            rel.EnregistreEvenement(CRelationTypeEquipement_Stock.c_champEventStockAlerte, false);
                        // Si seuil Critique atteint
                        if (nbAvant > rel.StockCritiqueApplique && nbApres <= rel.StockCritiqueApplique)
                            rel.EnregistreEvenement(CRelationTypeEquipement_Stock.c_champEventStockCritique, false);
                    }

              }

            }
            return result;

        }

	}
}
