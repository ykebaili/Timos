using System;
using System.Data;
using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;
using spv.data;

namespace spv.data.serveur
{
	public class CSpvLiai_RepServeur : CObjetServeur
	{
		
		///////////////////////////////////////////////////////////////
		public CSpvLiai_RepServeur ( int nIdSession )
			:base(nIdSession)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CSpvLiai_Rep.c_nomTable;
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
			return typeof(CSpvLiai_Rep);
		}
	}
}
