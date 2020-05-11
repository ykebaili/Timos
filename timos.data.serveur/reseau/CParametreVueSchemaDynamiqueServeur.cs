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
    public class CParametreVueSchemaDynamiqueServeur : CObjetServeurAvecBlob
    {

        //-------------------------------------------------------------------
        public CParametreVueSchemaDynamiqueServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
           CResultAErreur result = CResultAErreur.True;
           try
           {
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
			return CParametreVueSchemaDynamique.c_nomTable;
		}

        public override Type GetTypeObjets()
        {
            return typeof(CParametreVueSchemaDynamique);
        }
    }
}
