using System;
using System.Collections.Generic;
using System.Text;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;
using timos.securite;

namespace timos.data.serveur
{
    public class CModeleEtiquetteSchemaServeur : CObjetServeur
    {
        
        //-------------------------------------------------------------------
        public CModeleEtiquetteSchemaServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
           CResultAErreur result = CResultAErreur.True;
           try
           {
                CModeleEtiquetteSchema modele =  (CModeleEtiquetteSchema)objet;
             // Verifie le champ "Libelle"
               if (modele.Libelle == "")
                   result.EmpileErreur(I.T("The model label cannot be empty|30003"));
           }
           catch (Exception e)
           {
               result.EmpileErreur(new CErreurException(e));
           }
           return result;
        }

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CModeleEtiquetteSchema.c_nomTable;
		}

        public override Type GetTypeObjets()
        {
            return typeof(CModeleEtiquetteSchema);
        }
    }
    

}
