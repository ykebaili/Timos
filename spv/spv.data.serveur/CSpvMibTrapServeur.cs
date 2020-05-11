using System;
using System.Data;
using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;
using spv.data;

namespace spv.data.serveur
{
	public class CSpvMibTrapServeur : CObjetServeur
	{
		
		///////////////////////////////////////////////////////////////
		public CSpvMibTrapServeur ( int nIdSession )
			:base(nIdSession)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CSpvMibVariable.c_nomTable;
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
            return typeof(CSpvMibTrap);
		}


        protected override CFiltreData GetMyFiltreSysteme()
        {
            return new CFiltreData(CSpvMibTrap.c_champMIBOBJ_TYPE + " IN (@1, @2)",
                                   CSpvMibTrap.c_typeTrapV1, CSpvMibTrap.c_typeTrapV2); 
        }
	}
}
