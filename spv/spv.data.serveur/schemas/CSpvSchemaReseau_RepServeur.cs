using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;
using spv.data;
using timos.data;
using spv.data;

namespace spv.data.serveur
{
	public class CSpvSchemaReseau_RepServeur : CObjetServeur
	{
		///////////////////////////////////////////////////////////////
		public CSpvSchemaReseau_RepServeur ( int nIdSession )
			:base(nIdSession)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CSpvSchemaReseau_Rep.c_nomTable;
		}
		
		///////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees ( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			

			return result;
		}


        ///////////////////////////////////////////////////////////////
        public override Type GetTypeObjets()
        {
            return typeof(CSpvSchemaReseau_Rep);
        }


       

        
	}
}
