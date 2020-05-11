using System;
using System.Data;
using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;
using spv.data;

namespace spv.data.serveur
{
	public class CSpvMibTableServeur : CObjetServeur
	{
		
		///////////////////////////////////////////////////////////////
		public CSpvMibTableServeur ( int nIdSession )
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
            return typeof(CSpvMibTable);
		}

        protected override CFiltreData GetMyFiltreSysteme()
        {
            return new CFiltreData(CSpvMibTable.c_champMIBOBJ_TYPE + "=@1", CSpvMibTable.c_typeTable);
        }
	}
}
