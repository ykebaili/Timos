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
    /// Description résumée.
    /// </summary>
    public class CTypeRessourceServeur : CObjetHierarchiqueServeur
    {
        //-------------------------------------------------------------------
        public CTypeRessourceServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CTypeRessource.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                CTypeRessource type_cle = (CTypeRessource)objet;

                // Verifie le champ "Libelle"
                if (type_cle.Libelle == "")
					result.EmpileErreur("Resource Type label cannot be empty|10004");
                


                
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
            return typeof(CTypeRessource);
		}
		//-------------------------------------------------------------------
    }
}
