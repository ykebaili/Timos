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
    public class CTypePhase_TypeOperationServeur : CObjetDonneeServeurAvecCache
    {
        //-------------------------------------------------------------------
        public CTypePhase_TypeOperationServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CTypePhase_TypeOperation.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                CTypePhase_TypeOperation relation = (CTypePhase_TypeOperation)objet;

				if (relation.TypeOperation == null)
					result.EmpileErreur(I.T( "Operation type cannot be null|150"));
				if (relation.TypePhase == null)
					result.EmpileErreur(I.T( "Phase type cannot be null|417"));
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
            return typeof(CTypePhase_TypeOperation);
		}
		//-------------------------------------------------------------------
    }
}
