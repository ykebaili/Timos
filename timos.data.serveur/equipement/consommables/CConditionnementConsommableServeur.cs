using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data;
using timos.data.equipement.consommables;

namespace timos.data.serveur.equipement.consommables
{
    public class CConditionnementConsommableServeur : CObjetServeur
    {
        public CConditionnementConsommableServeur(int nIdSession)
            : base(nIdSession)
        {
        }
        
        public override string GetNomTable()
        {
            return CConditionnementConsommable.c_nomTable;
        }

        public override Type GetTypeObjets()
        {
            return typeof(CConditionnementConsommable);
        }

        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;

            CConditionnementConsommable conditionnement = objet as CConditionnementConsommable;
            if (conditionnement != null)
            {
                //if (conditionnement.Fournisseur == null)
                //    result.EmpileErreur(I.T("The Packaging Supplier cannot be null|10031"));
                if (conditionnement.TypeConsommable == null)
                    result.EmpileErreur(I.T("The Consumable Type associated to the Packaging cannot be null|10032"));
                if (conditionnement.Reference == string.Empty)
                    result.EmpileErreur(I.T("The Packaging Reference cannot be null|10033"));
            }

            return result;

        }
    }
}
