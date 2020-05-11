using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace timos.data.projet.besoin
{
    /// <summary>
    /// Calcul du coût d'un besoin parent à partir de ces besoins fils
    /// </summary>
    [Serializable]
    public class CDonneeBesoinParent : IDonneeBesoin
    {
        //---------------------------------------------------------
        public void InitFrom(CBesoin besoin, IDonneeBesoin donnee)
        {
        }


        //---------------------------------------------------------
        public double? CalculeCout(CBesoin besoin)
        {
            double? fValeur = null;
            foreach (CBesoin fils in besoin.BesoinsFils)
            {
                double? fCout = fils.CoutSaisiTotalSansRegroupement;
                if (fCout != null)
                {
                    CBesoinQuantite q = fils.RegroupementQuantite;
                    if (q != null)
                        fCout *= q.Quantite;
                    if (fValeur == null)
                        fValeur = 0;
                    fValeur += fCout;
                }
            }
            return fValeur;
        }

        //---------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }


        //---------------------------------------------------------
        public CResultAErreur Serialize(sc2i.common.C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
            return result;
        }

        //---------------------------------------------------------
        public string LibelleStatique
        {
            get { return I.T("Parent cost|20160"); }
        }

        //---------------------------------------------------------
        public bool CanApplyOn(CBesoin besoin)
        {
            return besoin.HasChildren;
        }

        //---------------------------------------------------------
        public ETypeDonneeBesoin TypeDonnee
        {
            get
            {
                return ETypeDonneeBesoin.BesoinParent;
            }
        }

        //---------------------------------------------------------
        public char? ShortKey
        {
            get
            {
                return null;
            }
        }

        //---------------------------------------------------------
        public bool PeutEtreParent
        {
            get
            {
                return true;
            }
        }

    }
}
