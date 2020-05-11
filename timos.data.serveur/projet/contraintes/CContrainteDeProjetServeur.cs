using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

using timos.securite;
using timos.data.projet.Contraintes;

namespace timos.data.serveur.projet.Contraintes
{
    /// <summary>
    ///
    /// </summary>
    public class CContrainteDeProjetServeur : CObjetServeur
    {

        //-------------------------------------------------------------------
        public CContrainteDeProjetServeur(int nIdSession)
            : base(nIdSession)
        {
        }

        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CContrainteDeProjet.c_nomTable;
        }

        //-------------------------------------------------------------------
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                CContrainteDeProjet contrainte = (CContrainteDeProjet)objet;


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
            return typeof(CContrainteDeProjet);
        }
    }
}
