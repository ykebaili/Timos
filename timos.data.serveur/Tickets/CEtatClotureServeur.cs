using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

using timos.data;

namespace timos.data.serveur
{
	/// <summary>
	/// Description résumée de CEtatClotureServeur.
	/// </summary>
	public class CEtatClotureServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CEtatClotureServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CEtatClotureServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CEtatCloture.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CEtatCloture etat = (CEtatCloture)objet;
                if(etat.Libelle == "")
                    result.EmpileErreur(I.T("The label of the closing state cannot be empty|226"));

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
			return typeof(CEtatCloture);
		}
		//-------------------------------------------------------------------
	}
}
