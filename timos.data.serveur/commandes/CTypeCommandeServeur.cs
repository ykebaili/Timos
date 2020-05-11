using System;
using System.Collections;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;
using timos.securite;

namespace timos.data.commandes.serveur
{
    /// <summary>
    /// Description rÃ©sumÃ©e 
    /// </summary>
    public class CTypeCommandeServeur : CObjetDonneeServeurAvecCache
    {
        //-------------------------------------------------------------------
        public CTypeCommandeServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CTypeCommande.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                CTypeCommande type_Commande = (CTypeCommande)objet;

                // Verifie le champ "Libelle"
                if (type_Commande.Libelle == "")
					result.EmpileErreur(I.T("Order type label can not be empty|20164"));

                
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
            return typeof(CTypeCommande);
		}
		//-------------------------------------------------------------------
    }
}
