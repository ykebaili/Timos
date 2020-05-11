using System;
using System.Collections;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;

namespace timos.data.serveur
{
    /// <summary>
    /// Description résumée 
    /// </summary>
    public class CIntervention_RessourceServeur : CObjetDonneeServeurAvecCache
    {
        //-------------------------------------------------------------------
        public CIntervention_RessourceServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CIntervention_Ressource.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                CIntervention_Ressource relation = (CIntervention_Ressource)objet;
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
            return typeof(CIntervention_Ressource);
		}
		
		//-------------------------------------------------------------------
		public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
		{
			CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
			return result;				
		}
    }
}
