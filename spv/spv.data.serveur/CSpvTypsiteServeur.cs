using System;
using System.Data;
using System.Collections;
using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;
using spv.data;
using timos.data;

namespace spv.data.serveur
{
    [AutoExec("Autoexec")]
    public class CSpvTypsiteServeur : CMappableTimosServeur<CTypeSite, CSpvTypsite>
	{
        public static void Autoexec()
        {
            RegisterPropagation();
        }

		
		///////////////////////////////////////////////////////////////
		public CSpvTypsiteServeur ( int nIdSession )
			:base(nIdSession)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CSpvTypsite.c_nomTable;
		}
		
		///////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees ( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				//TODO : Insérer la logique de vérification de donnée
			}
			catch ( Exception e )
			{
				result.EmpileErreur( new CErreurException ( e ) );
			}
			return result;
		}


		///////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CSpvTypsite);
		}

        ///////////////////////////////////////////////////////////////
        protected override bool ShouldAutoCreateObjetSpv(CTypeSite objetTimos)
        {
            // On crée toujours un type de site SPV pour un type de site SMT
            return true;
        }
	}
}
