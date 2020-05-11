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
    public class CRelationTypeSite_TypeTableParametrableServeur : CObjetDonneeServeurAvecCache
    {
        //-------------------------------------------------------------------
		public CRelationTypeSite_TypeTableParametrableServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationTypeSite_TypeTableParametrable.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
				CRelationTypeSite_TypeTableParametrable relation = (CRelationTypeSite_TypeTableParametrable)objet;

                if (relation.TypeSite == null)
					result.EmpileErreur(I.T( "The site type cannot be empty|106"));

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
			return typeof(CRelationTypeSite_TypeTableParametrable);
		}
		//-------------------------------------------------------------------
    }
}
