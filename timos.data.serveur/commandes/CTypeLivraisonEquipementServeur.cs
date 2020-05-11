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
    public class CTypeLivraisonEquipementServeur : CObjetDonneeServeurAvecCache
    {
        //-------------------------------------------------------------------
        public CTypeLivraisonEquipementServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CTypeLivraisonEquipement.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                CTypeLivraisonEquipement type_LivraisonEquipement = (CTypeLivraisonEquipement)objet;

                // Verifie le champ "Libelle"
                if (type_LivraisonEquipement.Libelle == "")
					result.EmpileErreur(I.T("Delivery type label can not be empty|20170"));

                
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
            return typeof(CTypeLivraisonEquipement);
		}
		//-------------------------------------------------------------------
    }
}
