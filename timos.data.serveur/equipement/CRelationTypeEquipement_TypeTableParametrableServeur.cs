using System;
using System.Collections;
using System.Text;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;

namespace timos.data.serveur
{
    /// <summary>
    /// Description résumée de
    /// </summary>
    public class CRelationTypeEquipement_TypeTableParametrableServeur : CObjetDonneeServeurAvecCache
    {
        //-------------------------------------------------------------------
		public CRelationTypeEquipement_TypeTableParametrableServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationTypeEquipement_TypeTableParametrable.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
				CRelationTypeEquipement_TypeTableParametrable relation = (CRelationTypeEquipement_TypeTableParametrable)objet;

                if (relation.TypeEquipement == null)
					result.EmpileErreur(I.T( "The Equipment type cannot be null|109"));

                if (relation.TypeTableParametrable == null)
                    result.EmpileErreur(I.T("Custom table type cannot be empty|379"));

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
			return typeof(CRelationTypeEquipement_TypeTableParametrable);
		}
		//-------------------------------------------------------------------
    }
}
