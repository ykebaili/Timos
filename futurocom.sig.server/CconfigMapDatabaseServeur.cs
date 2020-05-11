using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;


namespace futurocom.sig.serveur
{
	/// <summary>
	/// Description rÃ©sumÃ©e de CConfigMapDatabaseServeur.
	/// </summary>
	public class CConfigMapDatabaseServeur : CObjetServeurAvecBlob
	{
		//-------------------------------------------------------------------
#if PDA
		public CConfigMapDatabaseServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CConfigMapDatabaseServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CConfigMapDatabase.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CConfigMapDatabase config = (CConfigMapDatabase)objet;

				if ( config.Libelle == "")
					result.EmpileErreur(I.T("Map setup should not be empty|20000"));
				if (!CObjetDonneeAIdNumerique.IsUnique(config, CConfigMapDatabase.c_champLibelle, config.Libelle))
					result.EmpileErreur(I.T( "Map setup '@1' already exist|20001",config.Libelle));
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
			return typeof(CConfigMapDatabase);
		}
		//-------------------------------------------------------------------
	}
}
