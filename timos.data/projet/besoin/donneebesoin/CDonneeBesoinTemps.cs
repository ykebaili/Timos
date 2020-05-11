using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.unites;
using sc2i.common;
using timos.data.equipement.consommables;
using sc2i.data;

namespace timos.data.projet.besoin
{
    [Serializable]
    public class CDonneeBesoinTemps : CDonneeBesoinTypeConsommable
    {
        
        public override string LibelleStatique
        {
            get
            {
                return I.T("Time|20176");
            }
        }

        public override ETypeDonneeBesoin TypeDonnee
        {
            get
            {
                return ETypeDonneeBesoin.Temps;
            }
        }

        //---------------------------------------------------------
        public override char? ShortKey
        {
            get
            {
                string str = I.T("T|20186").ToUpper();
                if (str.Length > 0)
                    return str[0];
                return null;
            }
        }

        //---------------------------------------------------------
        public bool PeutEtreParent
        {
            get
            {
                return false;
            }
        }
    }
}
