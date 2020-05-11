using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

using timos.securite;

namespace timos.data
{
	/// <summary>
	/// Description résumée de CMouvementRessourceServeur.
	/// </summary>
	public class CMouvementRessourceServeur : CObjetServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CMouvementEquipementServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CMouvementRessourceServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CMouvementRessource.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CMouvementRessource mouvement = (CMouvementRessource)objet;

				if ( mouvement.RessourceDeplace == null )
					result.EmpileErreur (I.T( "Moved Resource cannot be empty|10005"));
				if ( mouvement.EmplacementOrigine == null )
					result.EmpileErreur(I.T( "The movement must be linked to an original location|123"));
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
			return typeof(CMouvementRessource);
		}
		//-------------------------------------------------------------------
	}
}
