using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;
using spv.data;
using timos.data;

namespace spv.data.serveur
{
    public class CSpvElementDeGrapheServeur : CObjetServeur
    {
        ///////////////////////////////////////////////////////////////
        public CSpvElementDeGrapheServeur(int nIdSession)
            : base(nIdSession)
        {
        }

        ///////////////////////////////////////////////////////////////
        public override string GetNomTable()
        {
            return CSpvElementDeGraphe.c_nomTable;
        }

        ///////////////////////////////////////////////////////////////
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


        ///////////////////////////////////////////////////////////////
        public override Type GetTypeObjets()
        {
            return typeof(CSpvElementDeGraphe);
        }
    }       
}
