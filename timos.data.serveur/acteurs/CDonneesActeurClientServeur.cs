using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;
using sc2i.multitiers.client;
using timos.acteurs.serveur;


namespace timos.data.serveur
{
	/// <summary>
	/// Description résumée de CDonneesActeurClientServeur.
	/// </summary>
	public class CDonneesActeurClientServeur : CDonneesActeurServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CDonneesActeurClientServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CDonneesActeurClientServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CDonneesActeurClient.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
#if !PDA_DATA
			try
			{
				CDonneesActeurClient donnees = (CDonneesActeurClient)objet;

				if (donnees.Acteur == null)
					result.EmpileErreur(I.T("The Customer must be related to a Member|270"));
			}
			catch ( Exception e )
			{
				result.EmpileErreur( new CErreurException ( e ) );
			}
#endif
			return result;
		}
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CDonneesActeurClient);
		}
	}
}
