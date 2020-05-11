using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;
using timos.securite;

namespace timos.data.serveur
{
    /// <summary>
    /// Description résumée de CCheminLienReseauServeur.
    /// </summary>
    public class CCheminLienReseauServeur : CObjetServeurAvecBlob
    {
        //-------------------------------------------------------------------
        public CCheminLienReseauServeur(int nIdSession)
            : base(nIdSession)
        {
        }

        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CCheminLienReseau.c_nomTable;
        }

        //-------------------------------------------------------------------
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;

            try
            {
                CCheminLienReseau CheminLien = (CCheminLienReseau)objet;
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }

            return result;
        }

       

        //-------------------------------------------------------------------
        public override Type GetTypeObjets()
        {
            return typeof(CCheminLienReseau);
        }
        //-------------------------------------------------------------------
    }
}
