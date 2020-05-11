using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.data;

namespace timos.data.serveur
{
    public class CTypePortServeur : CObjetServeur
    {
        //-------------------------------------------------------------------
		public CTypePortServeur ( int nIdSession )
			:base ( nIdSession )
		{

		}


        public override string GetNomTable()
        {
            return CTypePort.c_nomTable;
        }


        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                CTypePort typePort = (CTypePort)objet;
                if(typePort.Libelle=="")
                    result.EmpileErreur(I.T("Type Port label cannot be empty|50000"));

            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }


            return result;
        }

        public override Type GetTypeObjets()
        {
            return typeof(CTypePort);
        }
    }
}
