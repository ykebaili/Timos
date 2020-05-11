using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

namespace timos.data.commandes.serveur
{
	/// <summary>
	/// Description rÃ©sumÃ©e de CLigneCommandeServeur.
	/// </summary>
	public class CLigneCommandeServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CLigneCommandeServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CLigneCommandeServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CLigneCommande.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CLigneCommande LigneCommande = (CLigneCommande)objet;

				if ( LigneCommande.Commande == null)
                    result.EmpileErreur(I.T("Order line must be associated to an order|20165"));
                if (LigneCommande.ElementCommandé == null)
                    result.EmpileErreur(I.T("Order line must be associated to an equipment type or a consumable type|20166"));
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
			return typeof(CLigneCommande);
		}
		//-------------------------------------------------------------------
	}
}
