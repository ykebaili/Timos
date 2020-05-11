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
	/// Description résumée de CFonctionEquipementServeur.
	/// </summary>
	public class CEquipementLogiqueServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
		public CEquipementLogiqueServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CEquipementLogique.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CEquipementLogique equipementLogique = (CEquipementLogique)objet;

				if (equipementLogique.TypeEquipement == null )
					result.EmpileErreur (I.T( "The logical equipmment type should not be empty|20002"));

                if (equipementLogique.Site == null)
                    result.EmpileErreur(I.T("The logical equipment should be assigned to a Site|20003"));

                else
                {
                    if (equipementLogique.EquipementLogiqueContenant != null)
                    {
                        CTypeEquipement[] typeIncluantPoss = equipementLogique.TypeEquipement.TousLesTypesIncluants;
                        bool bTypePoss = false;
                        foreach (CTypeEquipement tEqtPoss in typeIncluantPoss)
                        {
                            if (tEqtPoss == equipementLogique.EquipementLogiqueContenant.TypeEquipement)
                            {
                                bTypePoss = true;
                                break;
                            }
                        }
                        if (!bTypePoss)
                            result.EmpileErreur(I.T("The parent logical equipment '@1' cannot contain this logical equipment because its type isn't in the incluable types list|20004", equipementLogique.EquipementLogiqueContenant.Libelle));

                        if (equipementLogique.Site.Id != equipementLogique.EquipementLogiqueContenant.Site.Id)
                        {
                            result.EmpileErreur(I.T("The logical equipment '@1' Site cannot be different from the container logical equipment '@2' site|20005", equipementLogique.Libelle, equipementLogique.EquipementLogiqueContenant.Libelle));
                        }
                    }
                }
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

			DataTable dt = contexte.Tables[CEquipementLogique.c_nomTable];
			ArrayList rows = new ArrayList(dt.Rows);
			CResultAErreur resultloc = CResultAErreur.True;
			foreach (DataRow row in rows)
			{
				if (row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added || row.RowState == DataRowState.Deleted )
				{
                    CEquipementLogique eqpt = new CEquipementLogique(row);
				}
				
			}

			return result;
		}

        
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CEquipementLogique);
		}
		//-------------------------------------------------------------------

	
	}
}
