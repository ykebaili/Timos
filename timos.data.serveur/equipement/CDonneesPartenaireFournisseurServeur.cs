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
	/// Description résumée de CDonneesActeurFournisseurServeur.
	/// </summary>
	public class CDonneesActeurFournisseurServeur : CDonneesActeurServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CDonneesActeurFournisseurServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CDonneesActeurFournisseurServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CDonneesActeurFournisseur.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
#if !PDA_DATA
			try
			{
				CDonneesActeurFournisseur donnees = (CDonneesActeurFournisseur)objet;

				if (donnees.Acteur == null)
					result.EmpileErreur(I.T("The Supplier must match a Member|246"));
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
			return typeof(CDonneesActeurFournisseur);
		}
	}
}
