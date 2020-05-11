using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.data;

namespace timos.data.serveur
{
    public class CPortServeur : CObjetServeur
    {
        //-------------------------------------------------------------------
		public CPortServeur ( int nIdSession )
			:base ( nIdSession )
		{

		}


        public override string GetNomTable()
        {
            return CPort.c_nomTable;
        }


        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                CPort port = (CPort)objet;
                if(port.Libelle=="")
                    result.EmpileErreur(I.T("Port label cannot be empty|30003"));

            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }


            return result;
        }

        public override Type GetTypeObjets()
        {
            return typeof(CPort);
        }
    }
}
