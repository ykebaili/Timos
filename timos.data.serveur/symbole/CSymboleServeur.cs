using System;
using System.Collections;
using System.Text;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;

namespace timos.data.serveur
{
    public class  CSymboleServeur : CObjetServeurAvecBlob
    {

        //-------------------------------------------------------------------
        public CSymboleServeur(int nIdSession)
            : base(nIdSession)
        {
        }

        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CSymbole.c_nomTable;
        }

        //-------------------------------------------------------------------
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;

          

            return result;
        }

        //-------------------------------------------------------------------
        public override Type GetTypeObjets()
        {
            return typeof(CSymbole);
        }

    }
}
