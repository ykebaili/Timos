using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using System.Data;
using sc2i.data;
using tiag.client;

namespace timos.data.projet.besoin
{
    /// <summary>
    /// Une phase de spécification regroupe un ensemble de besoins
    /// </summary>
    [DynamicClass("Needs specification")]
    [Table(CPhaseSpecifications.c_nomTable, CPhaseSpecifications.c_champId, true)]
    [ObjetServeurURI("CPhaseSpecificationsServeur")]
    [TiagClass(CPhaseSpecifications.c_nomTiag, "Id", true)]
    [TypeId("SPECIFICATION")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModuleBesoinsProjet)]
    public class CPhaseSpecifications : CObjetDonneeAIdNumeriqueAuto,
        ISatisfactionBesoinAvecSousBesoins,
        IResumeurDeCouts
    {
        public const string c_nomTiag = "Needs Specification";

        public const string c_nomTable = "SPEC_PHASE";
        public const string c_champId = "SPECPH_ID";
        public const string c_champLibelle = "SPECPH_LABEL";
        public const string c_champUseAsTemplate = "SPECPH_IS_TEMPLATE";
        public const string c_champCoutPrevisionnel = "SPEC_ESTIMATED_COST";
        public const string c_champCoutReel = "SPEC_ACTUAL_COST";

        //-----------------------------------------------
        public CPhaseSpecifications ( CContexteDonnee ctx)
            :base ( ctx )
        {
        }

        //-----------------------------------------------
        public CPhaseSpecifications ( DataRow row )
            :base (row)
        {
        }

        //-----------------------------------------------
        public override string DescriptionElement
        {
            get
            {
                return I.T("Needs specifications @1|20159", Libelle);
            }
        }

        //-----------------------------------------------
        protected override void MyInitValeurDefaut()
        {
            UseAsTemplate = false;
            TypesCoutsParentsARecalculer = ETypeCout.Aucun;
            Row[c_champCoutReel] = 0;
            Row[c_champCoutPrevisionnel] = 0;
        }

        //-----------------------------------------------
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champLibelle, c_champId };
        }

        //-----------------------------------------------
        /// <summary>
        /// Libellé de la phase de spécifications
        /// </summary>
        [TableFieldProperty(c_champLibelle, 255)]
        [DynamicField("Label")]
        public string Libelle
        {
            get
            {
                string strLib = Row.Get<string>(c_champLibelle);
                if (strLib.Length == 0 && Projet != null)
                    return Projet.Libelle;
                return strLib;
            }
            set
            {
                Row[c_champLibelle] = value;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Indique si cette phase peut être utilisée comme modèle
        /// </summary>
        [TableFieldProperty(c_champUseAsTemplate)]
        [DynamicField("Use as Template")]
        public bool UseAsTemplate
        {
            get
            {
                return (bool)Row[c_champUseAsTemplate];
            }
            set
            {
                Row[c_champUseAsTemplate] = value;
            }
        }



        //-----------------------------------------------
        /// <summary>
        /// Besoins associés à cette phase
        /// </summary>
        [RelationFille(typeof(CBesoin), "PhaseSpecifications")]
        [DynamicChilds("Needs", typeof(CBesoin))]
        public CListeObjetsDonnees Besoins
        {
            get
            {
                return GetDependancesListe(CBesoin.c_nomTable, c_champId);
            }
        }


        //-------------------------------------------------------------------
        /// <summary>
        /// Renseigné uniquement si la spécification correspond à un projet
        /// </summary>
        [Relation(
            CProjet.c_nomTable,
            CProjet.c_champId,
            CProjet.c_champId,
            false,
            true,
            true)]
        [DynamicField("Project")]
        public CProjet Projet
        {
            get
            {
                return (CProjet)GetParent(CProjet.c_champId, typeof(CProjet));
            }
            set
            {
                SetParent(CProjet.c_champId, value);
            }
        }

        //---------------------------------------------
        /// <summary>
        /// Retourne toutes les satisfactions liées à cette satisfaction, y compris elle même
        /// </summary>
        /// <returns></returns>
        [DynamicMethod("Returns all satisfactions linked to this satisfaction, including itself")]
        public ISatisfactionBesoin[] GetFlattenSatisfactionsHierarchy()
        {
            return CUtilSatisfaction.GetFlattenSatisfactionsHierarchy(this);
        }

        //-------------------------------------------------------------------
        public void FillSetBesoins ( HashSet<CBesoin> setBesoins, HashSet<ISatisfactionBesoinAvecSousBesoins> setSousElementsFaits )
        {
            if (setSousElementsFaits.Contains(this))
                return;
            setSousElementsFaits.Add(this);
            foreach (CBesoin besoin in Besoins)
                besoin.FillSetBesoins(setBesoins, setSousElementsFaits);
        }

        //---------------------------------------------
        /// <summary>
        /// Cout prévisionnel de la spécification
        /// </summary>
        /// <remarks>
        /// Le cout prévisionnel de la spécification est la somme des coûts prévisionnels de ces
        /// besoins qui ne satisfont aucun besoin
        /// </remarks>
        [TableFieldProperty(c_champCoutPrevisionnel)]
        [DynamicField("Estimated cost")]
        public double CoutPrevisionnel
        {
            get
            {
                return (double)Row[c_champCoutPrevisionnel];
            }
         }

        //---------------------------------------------
        /// <summary>
        /// Cout réel de la spécification
        /// </summary>
        /// <remarks>
        /// Le cout réel de la spécification est la somme des coûts réels de ces
        /// besoins qui ne satisfont aucun besoin
        /// </remarks>
        [TableFieldProperty(c_champCoutReel)]
        [DynamicField("Actual cost")]
        public double CoutReel
        {
            get
            {
                return (double)Row[c_champCoutReel];
            }
        }

        //---------------------------------------------
        
        public double CoutSaisi
        {
            get
            {
                CListeObjetsDonnees lst = Besoins;
                lst.Filtre = new CFiltreData(CBesoin.c_champIdBesoinParent + " is null");
                double fCout = 0;
                foreach (CBesoin b in lst)
                {
                    double? fTmp = b.CoutSaisiTotalAvecRegroupement;
                    if ( fTmp != null )
                        fCout += fTmp.Value;
                }
                return fCout;
            }
        }

        //---------------------------------------------
        [TableFieldProperty(CUtilElementACout.c_champImputationsVersUtilisateurs, 1024)]
        public string ImputationsSurUtilisateursString
        {
            get
            {
                return (string)Row[CUtilElementACout.c_champImputationsVersUtilisateurs];
            }
            set
            {
                Row[CUtilElementACout.c_champImputationsVersUtilisateurs] = value;
            }
        }

        //---------------------------------------------
        [TableFieldProperty(CUtilElementACout.c_champImputationsParLesSources, 1024)]
        public string ImputationsDeSourcesString
        {
            get
            {
                return (string)Row[CUtilElementACout.c_champImputationsParLesSources];
            }
            set
            {
                Row[CUtilElementACout.c_champImputationsParLesSources] = value;
            }
        }

        //---------------------------------------------
        public void SetCoutSansCalculDesParents(double fValeur, bool bCoutReel)
        {
            if (bCoutReel)
                Row[c_champCoutReel] = fValeur;
            else
                Row[c_champCoutPrevisionnel] = fValeur;
        }

        //---------------------------------------------
        public void SetCoutAvecCalculDesParents(double fValeur, bool bCoutReel)
        {
            SetCoutSansCalculDesParents(fValeur, bCoutReel);
            CUtilElementACout.OnChangeCout(this, bCoutReel, false);
        }
        //---------------------------------------------
        public double CalcImputationAFaireSur(IElementACout elementACout, bool bCoutReel)
        {
            if ( elementACout == null || elementACout.Row.RowState == DataRowState.Deleted )
                return 0;
            return CUtilElementACout.CalcImputationAFaireSur(this, elementACout, bCoutReel);
        }
        

        //---------------------------------------------
        public bool IsCoutFromSources(bool bCoutRelle)
        {
            return true;
        }

        //---------------------------------------------
        /// <summary>
        /// Indique les types de couts parents à recalculer
        /// </summary>
        [TableFieldProperty(CUtilElementACout.c_champCoutsParentsARecalculer, IsInDb=false)]
        public ETypeCout TypesCoutsParentsARecalculer
        {
            get
            {
                if (Row[CUtilElementACout.c_champCoutsParentsARecalculer] == DBNull.Value)
                    return ETypeCout.Aucun;
                return (ETypeCout)Row[CUtilElementACout.c_champCoutsParentsARecalculer];
            }
            set
            {
                Row[CUtilElementACout.c_champCoutsParentsARecalculer] = value;
            }
        }

        //---------------------------------------------
        public double CalculeTonCoutPuisqueTuNeCalculePasAPartirDesSourcesDeCout(bool bCoutReel)
        {
            //Sisi, on calcule à partir des sources de coût
            return 0;
        }

        //--------------------------------------------------------------
        public bool ShouldAjouterCoutPropreAuCoutDesSource(bool bCoutReel)
        {
            return false;
        }


 
        //---------------------------------------------
        public IElementACout[] GetSourcesDeCout(bool bCoutReel)
        {
            CListeObjetsDonnees lstBesoins = Besoins;
            lstBesoins.Filtre = new CFiltreData(CBesoin.c_champIdBesoinParent + " is null");
            return lstBesoins.ToArray<CBesoin>();
        }

        //---------------------------------------------
        public CImputationsCouts GetImputationsAFaireSurUtilisateursDeCout()
        {
            CImputationsCouts imputations = new CImputationsCouts(this);
            foreach (CRelationBesoin_Satisfaction rel in RelationsSatisfaits)
            {
                imputations.AddImputation(rel.Besoin, rel.RatioCoutReelApplique, rel);
            }
            if (Projet != null && Projet.Row.RowState != DataRowState.Deleted)
                imputations.AddImputation(Projet, imputations.PoidsTotal == 0 ? 1 : 0, null);

            return imputations;

        }

        //---------------------------------------------
        [DynamicMethod("Force system to calculate estimated cost for this element and its sub elements")]
        public double RecalcEstimatedCost()
        {
            return RecalcEstimatedCost(null);
        }

        //---------------------------------------------
        [DynamicMethod("Force system to calculate actual cost for this element and its sub elements")]
        public double RecalcActualCost()
        {
            return RecalcActualCost(null);
        }

        //---------------------------------------------
        public double RecalcEstimatedCost(IIndicateurProgression indicateur)
        {
            CUtilElementACout.RecalculeCoutDescendant(this, false, true, indicateur);
            return CoutPrevisionnel;
        }

        //---------------------------------------------
        public double RecalcActualCost(IIndicateurProgression indicateur)
        {
            CUtilElementACout.RecalculeCoutDescendant(this, true, true, indicateur);
            return CoutReel;
        }
        


        #region ISatisfactionBesoin Membres
        /// <summary>
        /// Libellé de spécification en tant que satisfaction de besoin
        /// </summary>
        [DynamicField("Satisfaction label")]
        public string LibelleSatisfactionComplet
        {
            get { return I.T("Specification @1|20169", Libelle); }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Besoins satisfaits par cette spécification
        /// </summary>
        [DynamicChilds("Satisfied needs", typeof(CBesoin))]
        public CBesoin[] BesoinsSolutionnes
        {
            get { return CRelationBesoin_Satisfaction.GetBesoinsSatisfaits(this).ToList<CBesoin>().ToArray(); }
        }

        //---------------------------------------------
        /// <summary>
        /// Relations aux besoins satisfaits par cette spécification
        /// </summary>
        [DynamicChilds("Satisfied needs relations", typeof(CRelationBesoin_Satisfaction))]
        
        public CListeObjetsDonnees RelationsSatisfaits
        {
            get { return CRelationBesoin_Satisfaction.GetRelationsBesoinsSatisfaits(this); }
        }


        public bool CanSatisfaire(CBesoin besoin)
        {
            return true;
        }

        //-------------------------------------------------------------------------------------
        [DynamicMethod("Returns true if satisfaction is a direct satisfaction to the need")]
        public bool IsDirectSatisfactionFor(CBesoin besoin)
        {
            return CUtilSatisfaction.IsDirectSatisfactionFor(this, besoin);
        }


        //-------------------------------------------------------------------------------------
        [DynamicMethod("Returns true if satisfaction is a direct or indirect satisfaction to the need")]
        public bool IsRecursiveSatisfactionFor(CBesoin besoin)
        {
            return CUtilSatisfaction.IsRecursiveSatisfactionFor(this, besoin);
        }

        public CObjetDonneeAIdNumerique ObjetPourEditionElementACout
        {
            get
            {
                if (Projet != null) return Projet;
                return this;
            }
        }

        #endregion

        #region ISatisfactionBesoinAvecSousBesoins Membres
        //---------------------------------------------------------
        public CBesoin[] GetSousBesoinsDeSatisfaction()
        {
            CListeObjetsDonnees lstBesoins = Besoins;
            lstBesoins.Filtre = new CFiltreData(CBesoin.c_champIdBesoinParent + " is null");
            return lstBesoins.ToArray<CBesoin>();
        }

        //---------------------------------------------------------
        public CBesoin[] GetSousBesoinsDeSatisfactionDirects()
        {
            return GetSousBesoinsDeSatisfaction();
        }

        //---------------------------------------------------------
        public ISatisfactionBesoin[] GetSousSatisfactions()
        {
            return new ISatisfactionBesoin[0];
        }

        #endregion



        #region IResumeurDeCouts Membres

        //--------------------------------------------------------------------------
        public void FillSetElementsACoutPourResumeCout(bool bCoutReel, Dictionary<IElementACout, bool> dicElementToAPrendreEnCompte)
        {
            List<CBesoin> besoinsAAjouter = new List<CBesoin>();
            CListeObjetsDonnees lst = Besoins;
            lst.Filtre = new CFiltreData(CBesoin.c_champIdBesoinParent + " is null");
            foreach (CBesoin b in lst)
                besoinsAAjouter.Add(b);
            HashSet<CBesoin> setANePasPrendre = new HashSet<CBesoin>();
            while (besoinsAAjouter.Count > 0)
            {
                List<CBesoin> nextGeneration = new List<CBesoin>();
                foreach (CBesoin b in besoinsAAjouter)
                {
                    bool bExclure = false;
                    if (setANePasPrendre.Contains(b))
                        bExclure = true;
                    dicElementToAPrendreEnCompte[b] = !bExclure;
                    bExclure |= b.ExclureLesCoutsDesFils || !b.IsCoutFromSources(bCoutReel);
                    foreach (CBesoin bFils in b.BesoinsFils)
                    {
                        if (bExclure)
                            setANePasPrendre.Add(bFils);
                        nextGeneration.Add(bFils);
                    }
                }
                besoinsAAjouter = nextGeneration;
            }
        }


        //--------------------------------------------------------------------------
        public double GetCoutResume(bool bCoutReel)
        {
            Dictionary<IElementACout, bool> setElementToAPrendreEnCompte = new Dictionary<IElementACout, bool>();
            FillSetElementsACoutPourResumeCout(bCoutReel, setElementToAPrendreEnCompte);
            Dictionary<IElementACout, CImputationsCouts> cacheImputations = new Dictionary<IElementACout, CImputationsCouts>();
            //On a tous les besoins dans un hashet, maintenant, il faut sommer les couts
            double fCout = 0;
            foreach (KeyValuePair<IElementACout, bool> kv in setElementToAPrendreEnCompte)
            {
                if (kv.Value)
                {
                    IElementACout element = kv.Key;
                    if (element is CBesoin)
                    {
                        bool bSourceInSet = false;
                        foreach (IElementACout elt in element.GetSourcesDeCout(bCoutReel))
                        {
                            if (setElementToAPrendreEnCompte.ContainsKey(elt))
                            {
                                bSourceInSet = true;
                                break;
                            }
                        }
                        if (!bSourceInSet)
                            fCout += bCoutReel ? element.CoutReel : element.CoutPrevisionnel;
                        else
                        {
                            foreach (IElementACout source in element.GetSourcesDeCout(bCoutReel))
                            {
                                if (!setElementToAPrendreEnCompte.ContainsKey(source))
                                //Si la source est dans le set, elle sera ajoutée, donc on ne la prend pas
                                {
                                    CImputationsCouts imputations = null;
                                    if (!cacheImputations.TryGetValue(source, out imputations))
                                    {
                                        imputations = source.GetImputationsAFaireSurUtilisateursDeCout();
                                        cacheImputations[source] = imputations;
                                    }

                                    fCout += imputations.GetCoutImputéeA(element, bCoutReel);
                                }
                            }
                        }
                    }
                }
            }
            return fCout;
        }

        #endregion
    }
}
