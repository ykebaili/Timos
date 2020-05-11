using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

namespace timos.data.serveur
{
	/// <summary>
	/// Description résumée
	/// </summary>
	public class CAttributRessourceServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CCiviliteServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CAttributRessourceServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CAttributRessource.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CAttributRessource att = (CAttributRessource)objet;

                if (att.Libelle == "" && att.AttributTypeContrainte == null)
					result.EmpileErreur(I.T( "The label cannot be empty|126"));
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
			return typeof(CAttributRessource);
		}
		//-------------------------------------------------------------------
	}
}
