using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace timos.data.projet.besoin
{
    /*[Serializable]
    public class CDonneeBesoinPourcentage : IDonneeBesoin
    {
        private double m_fPourcentage = 0;

        //---------------------------------------------------------------
        public CDonneeBesoinPourcentage()
        {
        }

        //---------------------------------------------------------
        public void InitFrom(IDonneeBesoin donnee)
        {
        }

        //---------------------------------------------------------------
        public double? CalculeCout(CBesoin besoin)
        {
            double fTotal = 0;
            foreach ( CBesoinDependance dep in besoin.LiensBesoinsDontJeDepend )
            {
                double? fCout = dep.BesoinReference.CoutSaisiTotalSansRegroupement;
                if ( fCout != null )
                    fTotal += fCout.Value;
            }
            return fTotal * m_fPourcentage/100;
        }

        //---------------------------------------------------------------
        public double Pourcentage
        {
            get{
                return m_fPourcentage;
            }
            set
            {
                m_fPourcentage = value;
            }
        }

        //---------------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //---------------------------------------------------------------
        public CResultAErreur Serialize(sc2i.common.C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            serializer.TraiteDouble(ref m_fPourcentage);
            return result;
        }

        //---------------------------------------------------------
        public string LibelleStatique
        {
            get { return I.T("Percentage|20161"); }
        }

        //---------------------------------------------------------
        public bool CanApplyOn(CBesoin besoin)
        {
            return besoin.BesoinsFils.Count == 0;
        }

        //---------------------------------------------------------
        public ETypeDonneeBesoin TypeDonnee
        {
            get
            {
                return ETypeDonneeBesoin.Pourcentage;
            }
        }
    }*/
}
