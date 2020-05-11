using System;
using System.Collections;
using System.Text;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;

namespace timos.data.serveur
{
    /// <summary>
    /// Description résumée .
    /// </summary>
    public class CRelationTypeContrainte_TypeRessourceServeur : CObjetDonneeServeurAvecCache
    {
        //-------------------------------------------------------------------
        public CRelationTypeContrainte_TypeRessourceServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationTypeContrainte_TypeRessource.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                // Interdit les doublons dans la table de relation Type Contrainte/Type Ressource


                
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
            return typeof(CRelationTypeContrainte_TypeRessource);
		}
		
        //-------------------------------------------------------------------
        
        
    }
}
