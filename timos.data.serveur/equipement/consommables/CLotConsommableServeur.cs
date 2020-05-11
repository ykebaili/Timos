using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data.serveur;
using timos.data.equipement.consommables;
using sc2i.common;
using sc2i.data;

namespace timos.data.serveur.equipement.consommables
{
    public class CLotConsommableServeur : CObjetServeur
    {
        public CLotConsommableServeur(int nIdSession)
            : base(nIdSession)
        {
        }

        public override string GetNomTable()
        {
            return CLotConsommable.c_nomTable;
        }

        public override Type GetTypeObjets()
        {
            return typeof(CLotConsommable);
        }

        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;

            CLotConsommable lot = objet as CLotConsommable;
            if (lot != null)
            {
                if (lot.Reference == string.Empty)
                    result.EmpileErreur(I.T("The Lot Reference cannot be null|10034"));
            }

            return result;

        }
    }
}
