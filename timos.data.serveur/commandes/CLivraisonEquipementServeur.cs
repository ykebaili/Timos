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
	public class CLivraisonEquipementServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
		public CLivraisonEquipementServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CLivraisonEquipement.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CLivraisonEquipement LivraisonEquipement = (CLivraisonEquipement)objet;

                
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
			return typeof(CLivraisonEquipement);
		}
		//-------------------------------------------------------------------

	
	}
}
