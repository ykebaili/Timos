using System;
using System.Data;
using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;
using spv.data;

namespace spv.data.serveur
{
	public class CSpvMessemServeur : CObjetServeur
	{
		
		///////////////////////////////////////////////////////////////
		public CSpvMessemServeur ( int nIdSession )
			:base(nIdSession)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CSpvMessem.c_nomTable;
		}
		
		///////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees ( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				//TODO : Insérer la logique de vérification de donnée
                CSpvMessem spvMessem = objet as CSpvMessem;
                if (spvMessem.Message == null || spvMessem.Message.Length == 0 || spvMessem.Message == "")
                    result.EmpileErreur(I.T("Message for EmessEM could not be Empty|50021"));
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
			return typeof(CSpvMessem);
		}

	}
}
