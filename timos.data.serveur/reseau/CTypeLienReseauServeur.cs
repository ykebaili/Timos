using System;
using System.Collections;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;
using timos.securite;

namespace timos.data.serveur
{
    public class CTypeLienReseauServeur : CObjetServeurAvecBlob
    {

        //-------------------------------------------------------------------
        public CTypeLienReseauServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
           CResultAErreur result = CResultAErreur.True;
           try
           {
               CTypeLienReseau type_lien = (CTypeLienReseau)objet;
             // Verifie le champ "Libelle"
               if (type_lien.Libelle == "")
                   result.EmpileErreur(I.T("Network link type label cannot be empty|30003"));
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
			return CTypeLienReseau.c_nomTable;
		}

        public override Type GetTypeObjets()
        {
            return typeof(CTypeLienReseau);
        }
    }
}
