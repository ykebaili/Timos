using System;
using System.Data;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;


namespace timos.data.commandes.serveur
{
	/// <summary>
	/// Description résumée de CFonctionEquipementServeur.
	/// </summary>
	public class CCommandeServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
		public CCommandeServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CCommande.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CCommande Commande = (CCommande)objet;

				if (Commande.TypeCommande == null )
					result.EmpileErreur (I.T( "Order must be associated to an order type|20167"));

                
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
			return typeof(CCommande);
		}
		//-------------------------------------------------------------------

	
	}
}
