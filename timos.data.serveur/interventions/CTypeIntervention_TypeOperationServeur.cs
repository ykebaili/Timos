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
    /// Description résumée 
    /// </summary>
    public class CTypeIntervention_TypeOperationServeur : CObjetDonneeServeurAvecCache
    {
        //-------------------------------------------------------------------
        public CTypeIntervention_TypeOperationServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CTypeIntervention_TypeOperation.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                CTypeIntervention_TypeOperation relation = (CTypeIntervention_TypeOperation)objet;

				if (relation.TypeOperation == null)
					result.EmpileErreur(I.T( "Operation type cannot be null|150"));
				if (relation.TypeIntervention == null)
					result.EmpileErreur(I.T( "Intervention type cannot be null|151"));
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
            return typeof(CTypeIntervention_TypeOperation);
		}
		//-------------------------------------------------------------------
    }
}
