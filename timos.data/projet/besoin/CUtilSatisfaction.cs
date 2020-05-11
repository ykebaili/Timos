using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.data;
using System.Data;

namespace timos.data.projet.besoin
{
    public static class CUtilSatisfaction
    {

        //------------------------------------------------------------------------------------------------------------------------------
        public static bool IsDirectSatisfactionFor(ISatisfactionBesoin satisfaction, CBesoin besoin)
        {
            if ( besoin == null || satisfaction == null)
                return false;
            CListeObjetsDonnees lstSatisfaits = satisfaction.RelationsSatisfaits;
            lstSatisfaits.Filtre = new CFiltreData(CBesoin.c_champId + "=@1",
                besoin.Id);
            int nCoutn = lstSatisfaits.Count;
            return nCoutn > 0;
        }

        //------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Indique si cette satisfaction satisfait ce besoin directement ou indirectement
        /// </summary>
        /// <param name="satisfaction"></param>
        /// <param name="besoin"></param>
        /// <returns></returns>
        public static bool IsRecursiveSatisfactionFor(ISatisfactionBesoin satisfaction, CBesoin besoin)
        {
            if (besoin == null || satisfaction == null)
                return false;
            HashSet<ISatisfactionBesoin> satisfactionsFaites = new HashSet<ISatisfactionBesoin>();

            return IsRecursiveSatisfactionFor(satisfaction, besoin, satisfactionsFaites);
        }

        //------------------------------------------------------------------------------------------------------------------------------
        private static bool IsRecursiveSatisfactionFor(ISatisfactionBesoin sat, CBesoin besoin, HashSet<ISatisfactionBesoin> satFaites)
        {
            if (sat.Equals(besoin))
                return true;
            if (satFaites.Contains(sat))
                return false;
            satFaites.Add(sat);
            foreach (CBesoin b in sat.BesoinsSolutionnes)
            {
                if (b != null && b.Equals(besoin))
                    return true;
                if (IsRecursiveSatisfactionFor(b, besoin, satFaites))
                    return true;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------------
        public static double GetPourcentageFor(CBesoin besoin, ISatisfactionBesoin satisfaction)
        {
            CImputationsCouts imputations = satisfaction.GetImputationsAFaireSurUtilisateursDeCout();
            CImputationCout imputation = imputations.GetImputation(besoin);
            if (imputations == null)
                return 0;
            if (imputations.PoidsTotal > 0)
                return imputation.Poids / imputations.PoidsTotal * 100;
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------------
        public static void SetPourcentageFor(CBesoin besoin, ISatisfactionBesoin satisfaction, double fPourcentageSouhaité)
        {
            CImputationsCouts imputations = satisfaction.GetImputationsAFaireSurUtilisateursDeCout();
            CImputationCout imputation = imputations.GetImputation(besoin);
            if (fPourcentageSouhaité < 100 && fPourcentageSouhaité >= 0)
            {
                if (imputations != null)
                {
                    double fPoids = imputations.PoidsTotal - imputation.Poids;
                    if (fPoids == 0)
                        return;
                    CListeObjetsDonnees lst = satisfaction.RelationsSatisfaits;
                    lst.Filtre = new CFiltreData(CBesoin.c_champId + "=@1", besoin.Id);
                    if (lst.Count != 0)
                    {
                        double fCalc = fPourcentageSouhaité / 100.0 * fPoids / (1 - fPourcentageSouhaité / 100.0);
                        CRelationBesoin_Satisfaction rel = lst[0] as CRelationBesoin_Satisfaction;
                        rel.RatioCoutReel = fCalc;
                    }
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------
        public static ISatisfactionBesoin[] GetFlattenSatisfactionsHierarchy(ISatisfactionBesoin satisfaction)
        {
            HashSet<ISatisfactionBesoin> set = new HashSet<ISatisfactionBesoin>();
            HashSet<ISatisfactionBesoin> setSatFaits = new HashSet<ISatisfactionBesoin>();
            FillFlattenSatisfactionsHierarchy(satisfaction, set, setSatFaits);
            return set.ToArray();
        }

        //------------------------------------------------------------------------------------------------------------------------------
        private static void FillFlattenSatisfactionsHierarchy(ISatisfactionBesoin satisfaction, HashSet<ISatisfactionBesoin> set, HashSet<ISatisfactionBesoin> setSatFait)
        {
            if (setSatFait.Contains(satisfaction))//Déjà vu
                return;
            setSatFait.Add ( satisfaction );
            set.Add ( satisfaction );
            
            //Si c'est un besoin, ajoute les satisfactions de ce besoin
            CBesoin besoin = satisfaction as CBesoin;
            if (besoin != null)
            {
                foreach (CRelationBesoin_Satisfaction rel in besoin.RelationsSatisfactions)
                {
                    if (rel.Satisfaction != null)
                        FillFlattenSatisfactionsHierarchy(rel.Satisfaction, set, setSatFait);
                }
            }

            ISatisfactionBesoinAvecSousBesoins satSousBes = satisfaction as ISatisfactionBesoinAvecSousBesoins;
            if (satSousBes != null)
            {
                foreach (CBesoin sousBesoin in satSousBes.GetSousBesoinsDeSatisfactionDirects())
                    FillFlattenSatisfactionsHierarchy(sousBesoin, set, setSatFait);
                foreach (ISatisfactionBesoin sousSat in satSousBes.GetSousSatisfactions())
                    FillFlattenSatisfactionsHierarchy(sousSat, set, setSatFait);
            }
        }

        

        
    }
}
