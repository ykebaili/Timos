using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.unites;
using sc2i.common;

namespace timos.data.projet.besoin
{
    [Serializable]
    public class CDonneeBesoinQuantiteCU : IDonneeBesoin
    {
        private CValeurUnite m_valeurQuantite;
        private CValeurUnite m_valeurCU;

        //--------------------------------------------------------------
        public void InitFrom(CBesoin besoin, IDonneeBesoin donnee)
        {
            CDonneeBesoinTypeEquipement dT = donnee as CDonneeBesoinTypeEquipement;
            if (dT != null)
            {
                if (dT.Quantite != null)
                    Quantite = new CValeurUnite(dT.Quantite, "");
                if (dT.CoutUnitaire != null)
                    CoutUnitaire = new CValeurUnite(dT.CoutUnitaire.Value, "");
            }
            else
            {
            }
        }


        //--------------------------------------------------------------
        public double? CalculeCout(CBesoin besoin)
        {
            double? fValeur = null;
            if (m_valeurQuantite != null && m_valeurCU != null)
            {
                try
                {
                    CValeurUnite v = m_valeurQuantite * m_valeurCU;
                    fValeur = v.Valeur;
                }
                catch { }
            }
            return fValeur;
        }

        //--------------------------------------------------------------
        public CValeurUnite Quantite
        {
            get
            {
                return m_valeurQuantite;
            }
            set
            {
                m_valeurQuantite = value;
            }
        }

        //--------------------------------------------------------------
        public CValeurUnite CoutUnitaire
        {
            get
            {
                return m_valeurCU;
            }
            set
            {
                m_valeurCU = value;
            }
        }

        //---------------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //---------------------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = serializer.TraiteObject<CValeurUnite>(ref m_valeurQuantite);
            if (result)
                result = serializer.TraiteObject<CValeurUnite>(ref m_valeurCU);
            return result;
        }

        //---------------------------------------------------------
        public string LibelleStatique
        {
            get { return I.T("Quantity/Unitary cost|20162"); }
        }

        //---------------------------------------------------------
        public bool CanApplyOn(CBesoin besoin)
        {
            return !besoin.HasChildren;
        }

        //---------------------------------------------------------
        public ETypeDonneeBesoin TypeDonnee
        {
            get
            {
                return ETypeDonneeBesoin.QuantiteCU;
            }
        }

        //---------------------------------------------------------
        public char? ShortKey
        {
            get
            {
                string str = I.T("Q|20185").ToUpper();
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
