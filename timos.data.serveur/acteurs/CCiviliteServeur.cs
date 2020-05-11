using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

namespace timos.acteurs.serveur
{
	/// <summary>
	/// Description rÃ©sumÃ©e de CCiviliteServeur.
	/// </summary>
	public class CCiviliteServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CCiviliteServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CCiviliteServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CCivilite.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CCivilite civilite = (CCivilite)objet;

				if ( civilite.Libelle == "")
					result.EmpileErreur(I.T("Civility Label cannot be empty|269"));
				if (!CObjetDonneeAIdNumerique.IsUnique(civilite, CCivilite.c_champLibelle, civilite.Libelle))
					result.EmpileErreur(I.T( "Civility '@1' already exist|268",civilite.Libelle));
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
			return typeof(CCivilite);
		}
		//-------------------------------------------------------------------
	}
}
