using System;
using System.Collections;
using System.Linq;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

using tiag.client;

using timos.data;
using timos.data.projet.besoin;
using System.Collections.Generic;
using System.IO;
using System.Text;
using sc2i.common.unites;
using timos.data.projet.besoin;
using timos.data.equipement.consommables;
using sc2i.common.unites.standard;
using sc2i.expression;

namespace timos.data.projet.besoin
{
	/// <summary>
	/// Permet de définir un besoin.
	/// </summary>
    /// <remarks>
    /// Un besoin représente un élément qu'il faut satisfaire. Le besoin est générallement
    /// utilisé dans une étude, pour calculer un coût prévisionnel.<BR></BR>
    /// La combinaison des projets et des besoins permet de suivre précisément les
    /// écarts entre les coûts prévisionnels et réels.
    /// </remarks>
    [DynamicClass("Need")]
    [Table(CBesoin.c_nomTable, CBesoin.c_champId, true)]
    [ObjetServeurURI("CBesoinServeur")]
    [TiagClass(CBesoin.c_nomTiag, "Id", true)]
    [TypeId("NEED")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModuleBesoinsProjet)]
    public class CBesoin : CObjetHierarchique,
        IElementAInterfaceTiag, ISatisfactionBesoinAvecSousBesoins, IObjetDonneeAIdNumeriqueAuto
    {
        public const string c_nomTiag = "Need";

        public const string c_nomTable = "NEED";
        public const string c_champId = "NEED_ID";
        public const string c_champLibelle = "NEED_LABEL";

        //Hierarchie
        public const string c_champCodeSystemePartiel = "NEED_PARTIAL_SYS_CODE";
        public const string c_champCodeSystemeComplet = "NEED_FULL_SYS_CODE";
        public const string c_champNiveau = "NEED_LEVEL";
        public const string c_champIdBesoinParent = "NEED_PARENT_ID";

        public const string c_champIndex = "NEED_INDEX";
        public const string c_champIdRegroupement = "NEED_RGP";

        public const string c_champCommentaires = "NEED_COMMENTS";

        public const string c_champTypeBesoin = "NEED_TYPE";

        public const string c_champQuantityValue = "NEED_VALUE";
        public const string c_champQuantityUnite = "NEED_QTTY_UNIT";
        public const string c_champUnitaryCost = "NEED_UNITARY_COST";
        public const string c_champUnitaryCostUnite = "NEED_UNITARY_COST_UNIT";

        public const string c_champDureeJoursPrevisionnelle = "NEED_ESTIM_DAYS_DURAT";
        public const string c_champCoutPrevisionnel = "NEED_ESTIMATED_COST";
        public const string c_champUtiliserCoutPrevPropre = "NEED_SE_OWN_PREV_COST";

        public const string c_champCoutReel = "NEED_ACTUAL_COST";
        public const string c_champUtiliserCoutSaisiCommeCoutReel = "NEED_FIXED_ACTUAL_COST";

        public const string c_champTemplateKey = "NEED_TPL_KEY";

        public const string c_champFormuleInitialisation = "NEED_INIT_FORMULA";
        public const string c_champCacheFormuleInitiliasation = "NEED_INIT_FORMULA_CACH";

        public const string c_champAExclureCoutDeFils = "NEED_EXCLUDE_CHILD_COSTS";

        

        public const string c_champFigerCoutPrevisionnel = "NEED_LOCK_ESTIMATED_COST";

        
        public const string c_champHasSatisfactions = "NEED_HAS_SATISFACTIONS";
        public const string c_champHasChildren = "NEED_HAS_CHILDREN";
        
        public const string c_champTAG = "NEED_TAG";


        /// /////////////////////////////////////////////
        public CBesoin(CContexteDonnee contexte)
            : base(contexte)
        {
        }

        /// /////////////////////////////////////////////
        public CBesoin(DataRow row)
            : base(row)
        {
        }

        /// /////////////////////////////////////////////
        public override string DescriptionElement
        {
            get
            {
                return I.T("Need @1|20156", Libelle);
            }
        }

        /// /////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {

            ExclureLesCoutsDesFils = false;
            IdUniversel = CUniqueIdentifier.GetNew();
            TypesCoutsParentsARecalculer = ETypeCout.Aucun;
            Row[c_champCoutReel] = 0;
            Row[c_champCoutPrevisionnel] = 0;
            DonneeBesoin = new CDonneeBesoinQuantiteCU();
            FigerCoutPrevisionnel = false;
            base.MyInitValeurDefaut();
        }
        /// /////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champLibelle };
        }


        /// /////////////////////////////////////////////
        public object[] TiagKeys
        {
            get { return new object[] { Id }; }
        }

        /// /////////////////////////////////////////////
        public string TiagType
        {
            get { return c_nomTiag; }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Id unique universel quelque soit la machine
        /// </summary>
        [TableFieldProperty(CObjetDonnee.c_champIdUniversel, 64)]
        [DynamicField("Universal id")]
        [IndexField]
        [NonCloneable]
        public string IdUniversel
        {
            get
            {
                return (string)Row[CObjetDonnee.c_champIdUniversel];
            }
            set
            {
                Row[CObjetDonnee.c_champIdUniversel] = value;
            }
        }

        //-----------------------------------------------------------
        public bool ReadIfExistsUniversalId(string strId)
        {
            CFiltreData filtre = new CFiltreData(CObjetDonnee.c_champIdUniversel + "=@1",
                strId);
            return ReadIfExists(filtre);
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Permet à l'administrateur de Timos de stocker des informations de configuration
        /// sur un besoin.
        /// </summary>
        [TableFieldProperty(c_champTAG, 1024)]
        [DynamicField("Tag")]
        public string Tag
        {
            get
            {
                return (string)Row[c_champTAG];
            }
            set
            {
                Row[c_champTAG] = value;
            }
        }


        //-----------------------------------------------
        /// <summary>
        /// Besoin parent
        /// </summary>
        [Relation(
            c_nomTable,
            c_champId,
            c_champIdBesoinParent,
            false,
            true,
            true)]
        [DynamicField("Parent need")]
        [TiagRelation(typeof(CBesoin), CAssociationTiag.c_methodeUseDelegate)]
        public CBesoin BesoinParent
        {
            get
            {
                return ObjetParent as CBesoin;
            }
            set
            {
                CBesoin old = BesoinParent;
                if (value != null && !DependDe(value))
                    ObjetParent = value;
                else if (value == null)
                    ObjetParent = null;
                if (old != value)
                {
                    if (value != null)
                        value.ResetHasChildren();
                    if (old != null)
                        old.ResetHasChildren();

                    CUtilElementACout.OnChangeCout(this, false, false);
                    CUtilElementACout.OnChangeCout(this, true, false);
                    if (value != null)
                    {
                        CUtilElementACout.OnChangeCout(value, false, false);
                        CUtilElementACout.OnChangeCout(value, true, true);
                    }
                    if (old != null)
                    {
                        CUtilElementACout.OnChangeCout(old, false, false);
                        CUtilElementACout.OnChangeCout(old, true, true);
                    }
                }
            }
        }


        //-------------------------------------------------------------------
        /// <summary>
        /// Phase de spécification à laquelle appartient ce besoin
        /// </summary>
        [Relation(
            CPhaseSpecifications.c_nomTable,
            CPhaseSpecifications.c_champId,
            CPhaseSpecifications.c_champId,
            true,
            false,
            false)]
        [DynamicField("Specification phase")]
        public CPhaseSpecifications PhaseSpecifications
        {
            get
            {
                return (CPhaseSpecifications)GetParent(CPhaseSpecifications.c_champId, typeof(CPhaseSpecifications));
            }
            set
            {
                SetParent(CPhaseSpecifications.c_champId, value);
            }
        }




        //-----------------------------------------------
        /// <summary>
        /// Liste des besoins fils
        /// </summary>
        [RelationFille(typeof(CBesoin), "BesoinParent")]
        [DynamicChilds("Children needs", typeof(CBesoin))]
        public CListeObjetsDonnees BesoinsFils
        {
            get
            {
                CListeObjetsDonnees lst = GetDependancesListe(CBesoin.c_nomTable, c_champIdBesoinParent);
                if ( IsValide() )
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champHasChildren, lst.Count > 0);
                return lst;
            }
        }

        //-----------------------------------------------
        /// <summary>
        /// Libellé (description) du besoin
        /// </summary>
        [TableFieldProperty(c_champLibelle, 1024)]
        [DynamicField("Label")]
        [TiagField("Label")]
        public override string Libelle
        {
            get
            {
                return Row.Get<string>(c_champLibelle);
            }
            set
            {
                Row[c_champLibelle] = value;
            }
        }



        //-----------------------------------------------
        /// <summary>
        /// Index du besoin dans le parent (permet d'ordonner les lignes de besoin)
        /// </summary>
        [TableFieldProperty(c_champIndex)]
        [DynamicField("Index")]
        [TiagField("Index")]
        public int Index
        {
            get
            {
                return Row.Get<int>(c_champIndex);
            }
            set
            {
                Row[c_champIndex] = value;
            }
        }

        //-----------------------------------------------
        public override string GetChampsTriParDefautSeparesVirgule()
        {
            return c_champIndex + "," + c_champLibelle;
        }


        //-----------------------------------------------
        /// <summary>
        /// Relations aux besoins dépendant de ce besoin
        /// </summary>
        [RelationFille(typeof(CBesoinDependance), "BesoinReference")]
        [DynamicChilds("Dependant needs links", typeof(CBesoinDependance))]
        public CListeObjetsDonnees LiensBesoinsDependant
        {
            get
            {
                return GetDependancesListe(CBesoinDependance.c_nomTable, CBesoinDependance.c_champIdBesoinReference);
            }
        }

        //-----------------------------------------------
        public bool DependDe(CBesoin besoin)
        {
            HashSet<CBesoin> set = new HashSet<CBesoin>();
            FillHashsetDependances(set);
            return set.Contains(besoin);
        }

        //-----------------------------------------------
        private void FillHashsetDependances(HashSet<CBesoin> set)
        {
            if (!set.Contains(this))
            {
                set.Add(this);
                foreach (CBesoinDependance b in LiensBesoinsDontJeDepend)
                {
                    b.BesoinReference.FillHashsetDependances(set);
                }
            }
        }

        //-----------------------------------------------
        public bool AddDependance(CBesoin besoin)
        {
            if (besoin == null || besoin.DependDe(this))
                return false;
            CListeObjetsDonnees lst = LiensBesoinsDontJeDepend;
            lst.Filtre = new CFiltreData(CBesoinDependance.c_champIdBesoinReference + "=@1",
                besoin.Id);
            if (lst.Count == 0)
            {
                CBesoinDependance dep = new CBesoinDependance(ContexteDonnee);
                dep.CreateNewInCurrentContexte();
                dep.BesoinDependant = this;
                dep.BesoinReference = besoin;
            }
            return true;
        }

        //-----------------------------------------------
        public void RemoveDependance(CBesoin besoin)
        {
            CListeObjetsDonnees lst = LiensBesoinsDontJeDepend;
            lst.Filtre = new CFiltreData(CBesoinDependance.c_champIdBesoinReference + "=@1",
                besoin.Id);
            if (lst.Count > 0)
            {
                CObjetDonneeAIdNumeriqueAuto.Delete(lst, true);
            }
        }

        //-----------------------------------------------
        /// <summary>
        /// Relations vers les besoins dont celui-ci dépend
        /// </summary>
        [RelationFille(typeof(CBesoinDependance), "BesoinDependant")]
        [DynamicChilds("Referenced needs links", typeof(CBesoinDependance))]
        public CListeObjetsDonnees LiensBesoinsDontJeDepend
        {
            get
            {
                return GetDependancesListe(CBesoinDependance.c_nomTable, CBesoinDependance.c_champIdBesoinDependant);
            }
        }

        /*//-----------------------------------------------
        [TableFieldProperty(c_champDonneeBesoin, NullAutorise=true)]
        public CDonneeBinaireInRow DataDonneeBesoin
        {
            get
            {
                if (Row[c_champDonneeBesoin] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champDonneeBesoin);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champDonneeBesoin, donnee);
                }
                object obj = Row[c_champDonneeBesoin];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champDonneeBesoin] = value;
            }
        }*/

        //-----------------------------------------------
        /// <summary>
        /// Type de besoin
        /// </summary>
        /// <remarks>
        /// Les valeurs possibles sont
        /// <LI>0 : Quantité et cout unitaire</LI>
        /// <LI>1 : Besoin en type d'équipement</LI>
        /// <LI>2 : Pourcentage</LI>
        /// <LI>3 : Besoin parent</LI>
        /// <LI>4 : Besoin en consommables</LI>
        /// <LI>5 : Besoin en temps</LI>
        /// </remarks>
        [TableFieldProperty(c_champTypeBesoin)]
        [DynamicField("Need type code")]
        public int TypeBesoinCode
        {
            get
            {
                return Row.Get<int>(c_champTypeBesoin);
            }
            set
            {
                Row[c_champTypeBesoin] = value;
            }
        }

        //-----------------------------------------------
        [DynamicField("Need type")]
        public CTypeDonneeBesoin TypeDonneeBesoin
        {
            set
            {
                if (value != null)
                    TypeBesoinCode = value.CodeInt;
            }
            get
            {
                return new CTypeDonneeBesoin((ETypeDonneeBesoin)TypeBesoinCode);
            }
        }


        //-----------------------------------------------
        /// <summary>
        /// Dans le cas d'un besoin de type Quantité/Cout unitaire,
        /// représente la valeur de la quantité exprimé dans l'unité de référence
        /// de l'unité d'expression de la quantité.<BR></BR>
        /// Dans le cas d'un besoin en équipement, indique la quantité d'équipements
        /// du type nécéssaires<BR></BR>
        /// Dans le cas d'un pourcentage, représente le pourcentage
        /// </summary>
        [TableFieldProperty(c_champQuantityValue, NullAutorise = true)]
        [DynamicField("Decimal value")]
        public double? QuantiteValeur
        {
            get
            {
                return Row.Get<double?>(c_champQuantityValue);
            }
            set
            {
                Row[c_champQuantityValue, true] = value;
            }
        }

        //-----------------------------------------------
        /// <summary>
        /// Dans le cas d'un besoin de type quantité/cout unitaire,
        /// représente le code de l'unité utilisée pour exprimer la quantité
        /// </summary>
        [TableFieldProperty(c_champQuantityUnite, 64)]
        [DynamicField("Quantity unit code")]
        public string UniteQuantiteCode
        {
            get
            {
                return (string)Row[c_champQuantityUnite];
            }
            set
            {
                Row[c_champQuantityUnite] = value.Trim();
            }
        }

        //-----------------------------------------------
        /// <summary>
        /// Dans le cas d'un besoin de type quantité/cout unitaire, représente
        /// la quantité avec unité de la quantité<BR></BR>
        /// </summary>
        [DynamicField("Quantity")]
        public CValeurUnite Quantite
        {
            get
            {
                return CUtilUniteObjetDonnee.GetValeur(this,
                    c_champQuantityValue,
                    c_champQuantityUnite);
            }
            set
            {
                CUtilUniteObjetDonnee.SetValeur(value, this,
                    c_champQuantityValue,
                    c_champQuantityUnite);
            }
        }

        //-----------------------------------------------
        [TableFieldProperty(c_champDureeJoursPrevisionnelle)]
        [DynamicField("Estimated days duration")]
        public double DureeJours
        {
            get
            {
                return (double)Row[c_champDureeJoursPrevisionnelle];
            }
            set
            {
                Row[c_champDureeJoursPrevisionnelle] = value;
            }
        }

        //-----------------------------------------------
        /// <summary>
        /// Pour les besoins projets, permet de définir une clé pour ce projet
        /// ce qui évitera de le créer en double au sein d'un même
        /// projet parent lors de l'application du modèle.
        /// </summary>
        [TableFieldProperty(c_champTemplateKey, 255)]
        [DynamicField("Template key")]
        public string SourceTemplateKey
        {
            get
            {
                return (string)Row[c_champTemplateKey];
            }
            set
            {
                Row[c_champTemplateKey] = value;
            }
        }

        //-----------------------------------------------
        ///<summary>
        ///Pour les besois projets : formule d'initialisation du projet
        ///</summary>
        // /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champFormuleInitialisation, NullAutorise = true)]
        public CDonneeBinaireInRow DataFormuleInit
        {
            get
            {
                if (Row[c_champFormuleInitialisation] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champFormuleInitialisation);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champFormuleInitialisation, donnee);
                }
                object obj = Row[c_champFormuleInitialisation];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champFormuleInitialisation] = value;
            }
        }


        // /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champCacheFormuleInitiliasation, IsInDb = false, NullAutorise = true)]
        [BlobDecoder]
        public C2iExpression FormuleInitialisation
        {
            get
            {
                if (Row[c_champCacheFormuleInitiliasation] != DBNull.Value)
                    return (C2iExpression)Row[c_champCacheFormuleInitiliasation];
                CDonneeBinaireInRow data = DataFormuleInit;
                if (data != null && data.Donnees != null)
                {
                    MemoryStream stream = new MemoryStream(data.Donnees);
                        try
                        {
                            using (BinaryReader reader = new BinaryReader(stream))
                            {
                                CSerializerReadBinaire ser = new CSerializerReadBinaire(reader);
                                C2iExpression formule = null;
                                ser.TraiteObject<C2iExpression>(ref formule);
                                CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheFormuleInitiliasation, formule);
                                reader.Close();
                                return formule;
                            }
                        }
                        catch { 
                            
                        }
                    
                    stream.Dispose();
                }
                return null;
            }
            set
            {
                Row[c_champCacheFormuleInitiliasation] = DBNull.Value;
                if (value == null)
                {
                    CDonneeBinaireInRow data = DataFormuleInit;
                    data.Donnees = null;
                    DataFormuleInit = data;

                }
                else
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        C2iExpression formule = value;
                        using (BinaryWriter writer = new BinaryWriter(stream))
                        {
                            CSerializerSaveBinaire ser = new CSerializerSaveBinaire(writer);
                            ser.TraiteObject<C2iExpression>(ref formule);
                            writer.Close();
                        }
                        CDonneeBinaireInRow donnee = DataFormuleInit;
                        donnee.Donnees = stream.ToArray();
                        DataFormuleInit = donnee;
                    }
                }
            }
        }

        //-----------------------------------------------
        /// <summary>
        /// Dans le cas d'un besoin de type Quantité/Cout unitaire,
        /// représente le coût unitaire exprimé dans l'unité de base de l'unité
        /// de coût unitaire
        /// </summary>
        [TableFieldProperty(c_champUnitaryCost, NullAutorise = true)]
        [DynamicField("Unitary cost value")]
        public double? CoutUnitaireValeur
        {
            get
            {
                return Row.Get<double?>(c_champUnitaryCost);
            }
            set
            {
                Row[c_champUnitaryCost, true] = value;
            }
        }

        //-----------------------------------------------
        /// <summary>
        /// Dans le cas d'un besoin de type quantité/cout unitaire,
        /// représente le code de l'unité utilisée pour exprimer le coût unitaire
        /// </summary>
        [TableFieldProperty(c_champUnitaryCostUnite, 64)]
        [DynamicField("Unitary cost unit code")]
        public string UniteCoutUnitaireCode
        {
            get
            {
                return (string)Row[c_champUnitaryCostUnite];
            }
            set
            {
                Row[c_champUnitaryCostUnite] = value;
            }
        }

        //-----------------------------------------------
        /// <summary>
        /// Si vrai, le cout prévisionnel du besoin est son propre coût,
        /// sinon, il s'agit du coût prévisionnel de ses satisfactions
        /// </summary>
        [TableFieldProperty(c_champUtiliserCoutPrevPropre)]
        [DynamicField("Use own estimated cost")]
        public bool UtiliserSaisiAsPrevisionnel
        {
            get
            {
                return (bool)Row[c_champUtiliserCoutPrevPropre];
            }
            set
            {
                bool bOld = false;
                if (Row[c_champUtiliserCoutPrevPropre] is bool)
                    bOld = UtiliserSaisiAsPrevisionnel;
                Row[c_champUtiliserCoutPrevPropre] = value;
                if ( bOld != value )
                    CUtilElementACout.OnChangeCout(this, false, false);
            }
        }

        //-----------------------------------------------
        /// <summary>
        /// Représente le cout éstimé de ce besoin.<BR></BR>
        /// </summary>
        /// <remarks>
        /// si <I>Use own estimated cost</I> est true, le coût prévisionnel
        /// est égal au coût défini dans les propriétés du besoins et ne se calcule <B>jamais</B>
        /// Sinon, c'est la somme des coûts des satisfactions de ce besoin + la somme des sous besoins
        /// qui ne satisfont aucun besoin.
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

        //-----------------------------------------------
        /// <summary>
        /// Représente le cout réel de ce besoin.<BR></BR>
        /// </summary>
        /// <remarks>
        /// si <I>Freeze actual cost</I> est true, le coût réel
        /// est égal au coût défini dans les propriétés du besoins et ne se calcule <B>jamais</B>
        /// Sinon, c'est la somme des coûts des satisfactions de ce besoin + la somme des sous besoins
        /// qui ne satisfont aucun besoin.
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
        public void SetCoutAvecCalculDesParents(double fValeur, bool bCoutReel)
        {
            SetCoutSansCalculDesParents(fValeur, bCoutReel);
            CUtilElementACout.OnChangeCout(this, bCoutReel, false); 
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
            else if ( !FigerCoutPrevisionnel )
                Row[c_champCoutPrevisionnel] = fValeur;
        }

         //---------------------------------------------
        public double CalcImputationAFaireSur(IElementACout elementACout, bool bCoutReel)
        {
            if (elementACout == null || elementACout.Row.RowState == DataRowState.Deleted)
                return 0;
            return CUtilElementACout.CalcImputationAFaireSur(this, elementACout, bCoutReel);
        }

       
        //-----------------------------------------------
        public bool IsCoutFromSources(bool bCoutReel)
        {
            if ( bCoutReel )
                return (!UtiliserSaisiAsReel && HasSatisfactions) || HasChildren;
            else
                return (!FigerCoutPrevisionnel && !UtiliserSaisiAsPrevisionnel && HasSatisfactions) || HasChildren;

        }

        //-----------------------------------------------
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
                ETypeCout typeCout = value;
                if (FigerCoutPrevisionnel)
                    typeCout &= ~ETypeCout.Prévisionnel;
                Row[CUtilElementACout.c_champCoutsParentsARecalculer] = typeCout;
                
            }
        }

        //---------------------------------------------
        public double CalculeTonCoutPuisqueTuNeCalculePasAPartirDesSourcesDeCout(bool bCoutReel)
        {
            if ( !IsCoutFromSources ( bCoutReel ) )
            {
                if ( bCoutReel )
                {
                    if (HasChildren)//Un élément qui a des fils ne peut pas s'auto appliquer
                        return 0;
                    if (UtiliserSaisiAsReel)
                    {
                        double? fVal = CoutSaisiTotalAvecRegroupement;
                        return fVal == null ? 0 : fVal.Value;
                    }
                    return 0;
                }
                else
                {
                    if (FigerCoutPrevisionnel)
                        return CoutPrevisionnel;
                    if (HasChildren)//Un élément qui a des fils ne peut pas s'auto appliquer
                        return 0;
                    double? fCout = CoutSaisiTotalAvecRegroupement;
                    return fCout == null?0:fCout.Value;
                }
            }
            return 0;
        }

        //--------------------------------------------------------------
        public bool ShouldAjouterCoutPropreAuCoutDesSource(bool bCoutReel)
        {
            return false;
        }

        //-----------------------------------------------
        public IElementACout[] GetSourcesDeCout(bool bReel)
        {
            if (bReel && UtiliserSaisiAsReel && !HasChildren)
                return new IElementACout[0];
            if (!bReel && UtiliserSaisiAsPrevisionnel && !HasChildren)
                return new IElementACout[0];
            List<IElementACout> lst = new List<IElementACout>();
            if (HasSatisfactions)
            {
                foreach (CRelationBesoin_Satisfaction rel in RelationsSatisfactions)
                {
                    if (rel.Satisfaction != null)
                        lst.Add(rel.Satisfaction);
                }
            }

            if (!ExclureLesCoutsDesFils)
            {
                foreach (CBesoin fils in BesoinsFils)
                    lst.Add(fils);
            }


            return lst.ToArray();

        }

        //------------------------------------------------------------------------------------------
        public CImputationsCouts GetImputationsAFaireSurUtilisateursDeCout()
        {
            CImputationsCouts imputations = new CImputationsCouts(this);

            foreach (CRelationBesoin_Satisfaction rel in RelationsSatisfaits)
            {
                imputations.AddImputation(rel.Besoin, rel.RatioCoutReelApplique, rel);
            }

            if (BesoinParent != null && BesoinParent.IsValide())
            {
                if (!BesoinParent.ExclureLesCoutsDesFils)
                    imputations.AddImputation(BesoinParent, imputations.PoidsTotal == 0 ? 1 : 0, null);
                else
                    imputations.AddImputation(BesoinParent, 0, null);
            }

            if (PhaseSpecifications != null)
            {
                if ( BesoinParent == null || !BesoinParent.IsValide() || !BesoinParent.ExclureLesCoutsDesFils )
                    imputations.AddImputation(PhaseSpecifications, imputations.PoidsTotal == 0 ? 1 : 0, null);
                else
                    imputations.AddImputation(PhaseSpecifications, 0, null);
            }


            foreach (CBesoinDependance dep in LiensBesoinsDependant)
                imputations.AddUtilisateurNonImputé(dep.BesoinDependant);
            return imputations;
        }

        

        //-----------------------------------------------
        /// <summary>
        /// Si vrai, le cout réel n'est pas calculé à partir des 
        /// satisfactions, mais il est géré de manière autonome sur ce besoin.
        /// </summary>
        [TableFieldProperty(c_champUtiliserCoutSaisiCommeCoutReel)]
        [DynamicField("Freeze actual cost")]
        public bool UtiliserSaisiAsReel
        { 
            get
            {
                return (bool)Row[c_champUtiliserCoutSaisiCommeCoutReel];
            }
            set
            {
                bool bOld = false;
                if (Row[c_champUtiliserCoutSaisiCommeCoutReel] is bool)
                    bOld = value;
                Row[c_champUtiliserCoutSaisiCommeCoutReel] = value;
                if ( value != bOld )
                    CUtilElementACout.OnChangeCout(this, true, false);
            }
        }

        //-----------------------------------------------
        /// <summary>
        /// Indique si ce besoin a des satisfactions
        /// </summary>
        /// <returns></returns>
        [TableFieldProperty(c_champHasSatisfactions, NullAutorise = true, IsInDb = false)]
        [DynamicField("Has satisfactions")]
        public bool HasSatisfactions
        {
            get
            {
                if (Row[c_champHasSatisfactions] == DBNull.Value)
                {
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champHasSatisfactions,
                        RelationsSatisfactions.Count>0);
                }
                return (bool)Row[c_champHasSatisfactions];
            }
        }

        //-----------------------------------------------
        /// <summary>
        /// Force ce besoin à recalculer s'il a des satisfactions
        /// </summary>
        public void ResetHasSatisfactions()
        {
            if ( IsValide() )
                Row[c_champHasSatisfactions] = DBNull.Value;
        }

        //-----------------------------------------------
        /// <summary>
        /// Indique si ce besoin a des besoins fils
        /// </summary>
        /// <returns></returns>
        [TableFieldProperty(c_champHasChildren, NullAutorise = true, IsInDb = false)]
        [DynamicField("Has Children")]
        public bool HasChildren
        {
            get
            {
                if (Row[c_champHasChildren] == DBNull.Value)
                {
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champHasChildren,
                        BesoinsFils.Count > 0);
                }
                return (bool)Row[c_champHasChildren];
            }
        }

        //-----------------------------------------------
        /// <summary>
        /// Force ce besoin à recalculer s'il a des satisfactions
        /// </summary>
        public void ResetHasChildren()
        {
            if ( IsValide() )
                Row[c_champHasChildren] = DBNull.Value;
        }

        //-------------------------------------------------------------------
        public override bool Refresh()
        {
            bool bRetour = base.Refresh();
            ResetHasChildren();
            ResetHasSatisfactions();
            return bRetour;
        }

        //-----------------------------------------------
        protected override CResultAErreur MyCanDelete()
        {
            //On se sert de myCanDelete pour prévenir le parent qu'on risque d'être supprimé
            if (BesoinParent != null)
                BesoinParent.ResetHasChildren();
            return base.MyCanDelete();
        }


        //-----------------------------------------------
        /// <summary>
        /// Si ce besoin est un besoin parent qui est satisfait,
        /// cette propriété permet d'exclure le cout de ses fils, ce qui
        /// indique que la satisfaction de cet élément intègre le cout des
        /// fils de ce besoin
        /// </summary>
        [TableFieldProperty(c_champAExclureCoutDeFils)]
        [DynamicField("Exclude childs costs")]
        public bool ExclureLesCoutsDesFils
        {
            get
            {
                return (bool)Row[c_champAExclureCoutDeFils] && HasChildren ;
            }
            set
            {
                bool bOld = false;
                if (Row[c_champAExclureCoutDeFils] != DBNull.Value)
                    bOld = ExclureLesCoutsDesFils;
                Row[c_champAExclureCoutDeFils] = value;
                if (value != bOld)
                {
                    CUtilElementACout.OnChangeCout(this, false, false);
                    CUtilElementACout.OnChangeCout(this, true, false);
                }
            }
        }

        //-----------------------------------------------
        /// <summary>
        /// Si vrai, le cout prévisionnel ne se recalcule plus, il devient figé
        /// </summary>
        [TableFieldProperty(c_champFigerCoutPrevisionnel)]
        [DynamicField("Lock estimated cost")]
        public bool FigerCoutPrevisionnel
        {
            get
            {
                return (bool)Row[c_champFigerCoutPrevisionnel];
            }
            set
            {
                bool bOld = false;
                if ( Row[c_champFigerCoutPrevisionnel] is bool )
                    bOld = FigerCoutPrevisionnel;
                Row[c_champFigerCoutPrevisionnel] = value;
                if ( value != bOld && !value )
                    CUtilElementACout.OnChangeCout ( this, false, false );
                
            }
        }

        //-----------------------------------------------
        /// <summary>
        /// Dans le cas d'un besoin de type quantité/cout unitaire, représente
        /// le coût unitaire avec unité
        /// </summary>
        [DynamicField("Unitary cost")]
        public CValeurUnite CoutUnitaire
        {
            get
            {
                return CUtilUniteObjetDonnee.GetValeur(this,
                    c_champUnitaryCost,
                    c_champUnitaryCostUnite);
            }
            set
            {
                CUtilUniteObjetDonnee.SetValeur(value,
                    this,
                    c_champUnitaryCost,
                    c_champUnitaryCostUnite);
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Dans le cas d'un besoin  en équipement,
        /// indique le type d'équipement associé au besoin
        /// </summary>
        [Relation(
            CTypeEquipement.c_nomTable,
            CTypeEquipement.c_champId,
            CTypeEquipement.c_champId,
            false,
            false,
            false)]
        [DynamicField("Equipment type")]
        public CTypeEquipement TypeEquipement
        {
            get
            {
                return (CTypeEquipement)GetParent(CTypeEquipement.c_champId, typeof(CTypeEquipement));
            }
            set
            {
                SetParent(CTypeEquipement.c_champId, value);
            }
        }

 
        //-------------------------------------------------------------------
        /// <summary>
        /// Dans le cas d'un besoin  en opération,
        /// indique le type d'opération associé au besoin
        /// </summary>
        [Relation(
            CTypeOperation.c_nomTable,
            CTypeOperation.c_champId,
            CTypeOperation.c_champId,
            false,
            false,
            false)]
        [DynamicField("Operation type")]
        public CTypeOperation TypeOperation
        {
            get
            {
                return (CTypeOperation)GetParent(CTypeOperation.c_champId, typeof(CTypeOperation));
            }
            set
            {
                SetParent(CTypeOperation.c_champId, value);
            }
        }

        
        //-------------------------------------------------------------------
        /// <summary>
        /// Dans le cas d'un besoin  en consommable ou en temps
        /// indique le type de consommable associé au besoin
        /// </summary>
        [Relation(
            CTypeConsommable.c_nomTable,
            CTypeConsommable.c_champId,
            CTypeConsommable.c_champId,
            false,
            false,
            false)]
        [DynamicField("Consumable type")]
        public CTypeConsommable TypeConsommable
        {
            get
            {
                return (CTypeConsommable)GetParent(CTypeConsommable.c_champId, typeof(CTypeConsommable));
            }
            set
            {
                SetParent(CTypeConsommable.c_champId, value);
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Dans le cas d'un besoin  en projet
        /// indique le type de projet
        /// </summary>
        [Relation(
            CTypeProjet.c_nomTable,
            CTypeProjet.c_champId,
            CTypeProjet.c_champId,
            false,
            false,
            false)]
        [DynamicField("Project type")]
        public CTypeProjet TypeProjet
        {
            get
            {
                return (CTypeProjet)GetParent(CTypeProjet.c_champId, typeof(CTypeProjet));
            }
            set
            {
                SetParent(CTypeProjet.c_champId, value);
            }
        }

        //-----------------------------------------------
        public IDonneeBesoin DonneeBesoin
        {
            get
            {
                IDonneeBesoin donnee = null;
                switch ((ETypeDonneeBesoin)TypeBesoinCode)
                {
                    ///Cout Unitaire
                    case ETypeDonneeBesoin.QuantiteCU:
                        CDonneeBesoinQuantiteCU dCU = new CDonneeBesoinQuantiteCU();
                        dCU.CoutUnitaire = CoutUnitaire;
                        dCU.Quantite = Quantite;
                        donnee = dCU;
                        break;

                    ///Type équipement
                    case ETypeDonneeBesoin.TypeEquipement:
                        CDonneeBesoinTypeEquipement dTE = new CDonneeBesoinTypeEquipement();
                        dTE.SetTypeEquipement(TypeEquipement);
                        if (CoutUnitaireValeur != null)
                        {
                            dTE.IsCoutTarif = false;
                            dTE.CoutUnitaire = CoutUnitaireValeur;
                        }
                        else
                        {
                            dTE.IsCoutTarif = true;
                        }
                        double? dVal = QuantiteValeur;
                        if (dVal == null)
                            dTE.Quantite = 1;
                        else
                            dTE.Quantite = (int)dVal.Value;
                        donnee = dTE;
                        break;

                    ///Pourcentage
                    /*case ETypeDonneeBesoin.Pourcentage:
                        CDonneeBesoinPourcentage dPC = new CDonneeBesoinPourcentage();
                        dPC.Pourcentage = QuantiteValeur != null ? QuantiteValeur.Value : 0;
                        break;*/
                    ///Besoin parent
                    case ETypeDonneeBesoin.BesoinParent:
                        donnee = new CDonneeBesoinParent();
                        break;
                    case ETypeDonneeBesoin.TypeConsommable :
                        CDonneeBesoinTypeConsommable dTC = new CDonneeBesoinTypeConsommable();
                        dTC.CoutUnitaire = CoutUnitaire;
                        dTC.Quantite = Quantite;
                        dTC.IsCoutTarif = CoutUnitaireValeur == null;
                        dTC.SetTypeConsommable(TypeConsommable);
                        donnee = dTC;
                        break;
                    case ETypeDonneeBesoin.Temps:
                        CDonneeBesoinTemps dT = new CDonneeBesoinTemps();
                        dT.CoutUnitaire = CoutUnitaire;
                        dT.Quantite = Quantite;
                        dT.IsCoutTarif = CoutUnitaireValeur == null;
                        dT.SetTypeConsommable(TypeConsommable);
                        donnee = dT;
                        break;
                    case ETypeDonneeBesoin.Operation:
                        CDonneeBesoinTypeOperation dTo = new CDonneeBesoinTypeOperation();
                        dTo.SetTypeOperation(TypeOperation);
                        if (CoutUnitaireValeur != null)
                        {
                            dTo.IsCoutTarif = false;
                            dTo.CoutUnitaire = CoutUnitaireValeur;
                        }
                        else
                        {
                            dTo.IsCoutTarif = true;
                        }
                        double? dValO = QuantiteValeur;
                        if (dValO == null)
                            dTo.Quantite = 1;
                        else
                            dTo.Quantite = (int)dValO.Value;
                        donnee = dTo;
                        break;
                    case ETypeDonneeBesoin.Projet :
                        CDonneeBesoinProjet dTp = new CDonneeBesoinProjet();
                        dTp.SetTypePRojet(TypeProjet);
                        dTp.CoutSaisi = QuantiteValeur;
                        dTp.DureeJours = DureeJours;
                        dTp.CleProjetTemplate = SourceTemplateKey;
                        dTp.FormuleInitialisation = FormuleInitialisation;
                        donnee = dTp;
                        break;
                }
                if (HasChildren && donnee != null && !donnee.PeutEtreParent)
                    donnee = new CDonneeBesoinParent();
                return donnee;
            }

            set
            {
                if (value == null)
                {
                    TypeBesoinCode = (int)ETypeDonneeBesoin.QuantiteCU;
                }
                else
                {
                    TypeBesoinCode = (int)value.TypeDonnee;
                    switch (value.TypeDonnee)
                    {
                        case ETypeDonneeBesoin.QuantiteCU:
                            CDonneeBesoinQuantiteCU dCU = value as CDonneeBesoinQuantiteCU;
                            Quantite = dCU.Quantite;
                            CoutUnitaire = dCU.CoutUnitaire;
                            TypeEquipement = null;
                            TypeProjet = null;
                            TypeConsommable = null;
                            TypeOperation = null;
                            CValeurUnite v = Quantite;
                            if (v != null && v.IUnite != null &&  v.IUnite.Classe.GlobalId == CClasseUniteTemps.c_idClasse)
                                DureeJours = v.ConvertTo(CClasseUniteTemps.c_idDAY).Valeur;
                            else
                                DureeJours = 0;
                            break;
                        case ETypeDonneeBesoin.TypeEquipement:
                            CDonneeBesoinTypeEquipement dTE = value as CDonneeBesoinTypeEquipement;
                            QuantiteValeur = dTE.Quantite;
                            UniteQuantiteCode = "";
                            UniteCoutUnitaireCode = "";
                            CoutUnitaireValeur = dTE.IsCoutTarif ? null : dTE.CoutUnitaire;
                            TypeEquipement = dTE.GetTypeEquipement(ContexteDonnee);
                            TypeProjet = null;
                            TypeConsommable = null;
                            TypeOperation = null;
                            break;
                        case ETypeDonneeBesoin.Operation:
                            CDonneeBesoinTypeOperation dTO = value as CDonneeBesoinTypeOperation;
                            QuantiteValeur = dTO.Quantite;
                            UniteQuantiteCode = "";
                            UniteCoutUnitaireCode = "";
                            CoutUnitaireValeur = dTO.IsCoutTarif ? null : dTO.CoutUnitaire;
                            TypeOperation = dTO.GetTypeOperation(ContexteDonnee);
                            TypeEquipement = null;
                            TypeProjet = null;
                            TypeConsommable = null;
                            break;
                        /*case ETypeDonneeBesoin.Pourcentage:
                            CDonneeBesoinPourcentage dPC = value as CDonneeBesoinPourcentage;
                            QuantiteValeur = dPC.Pourcentage;
                            UniteQuantiteCode = "";
                            CoutUnitaireValeur = null;
                            break;*/
                        case ETypeDonneeBesoin.BesoinParent:
                            break;
                        case ETypeDonneeBesoin.TypeConsommable :
                        case ETypeDonneeBesoin.Temps:
                            CDonneeBesoinTypeConsommable dTC = value as CDonneeBesoinTypeConsommable;
                            Quantite = dTC.Quantite;
                            CoutUnitaire = dTC.IsCoutTarif ? null : dTC.CoutUnitaire;
                            TypeConsommable = dTC.GetTypeConsommable(ContexteDonnee);
                            TypeEquipement = null;
                            TypeProjet = null;
                            TypeOperation = null;
                            CValeurUnite valU = Quantite;
                            if (valU != null && valU.IUnite != null && valU.IUnite.Classe.GlobalId == CClasseUniteTemps.c_idClasse)
                                DureeJours = valU.ConvertTo(CClasseUniteTemps.c_idDAY).Valeur;
                            else
                                DureeJours = 0;
                            break;
                        case ETypeDonneeBesoin.Projet :
                            CDonneeBesoinProjet dTP = value as CDonneeBesoinProjet;
                            QuantiteValeur = dTP.CoutSaisi;
                            UniteCoutUnitaireCode = "";
                            TypeOperation = null;
                            TypeEquipement = null;
                            TypeConsommable = null;
                            TypeProjet = dTP.GetTypeProjet(ContexteDonnee);
                            DureeJours = dTP.DureeJours;
                            SourceTemplateKey = dTP.CleProjetTemplate;
                            FormuleInitialisation = dTP.FormuleInitialisation;
                            break;
                        default:
                            break;
                    }
                   
                }
                CheckModifCouts();
            }
        }

        //-----------------------------------------------
        //Vérifie la modifications des couts et prépare le recalcul des parents si besoin
        private void CheckModifCouts()
        {
            if (!IsCoutFromSources(false))
            {
                double fVal = CalculeTonCoutPuisqueTuNeCalculePasAPartirDesSourcesDeCout(false);
                if (Math.Abs(fVal - CoutPrevisionnel) > 0.001)
                {
                    CUtilElementACout.OnChangeCout(this, false, false);
                }
            }
            else
                CUtilElementACout.RecalculeCoutDescendant(this, false, false, null);
            if (!IsCoutFromSources(true))
            {
                double fVal = CalculeTonCoutPuisqueTuNeCalculePasAPartirDesSourcesDeCout(true);
                if (Math.Abs(fVal - CoutReel) > 0.001)
                {
                    CUtilElementACout.OnChangeCout(this, true, false);
                }
            }
            else
                CUtilElementACout.RecalculeCoutDescendant(this, true, false, null);
        }



        //-----------------------------------------------
        /// <summary>
        /// Cout prévisionnel propre du besoin sans tenir compte
        /// de sa variable de regroupement
        /// </summary>
        public double? CoutSaisiTotalSansRegroupement
        {
            get
            {
                if (DonneeBesoin != null)
                    return DonneeBesoin.CalculeCout(this);
                return null;
            }
        }

        //-----------------------------------------------
        /// <summary>
        /// Cout prévisionnel propre du besoin en tenant compte
        /// de sa variable de regroupement
        /// </summary>
        public double? CoutSaisiTotalAvecRegroupement
        {
            get
            {
                if (DonneeBesoin != null)
                {
                    double? fCout = DonneeBesoin.CalculeCout(this);
                    CBesoin besAReg = this;
                    while (besAReg != null)
                    {
                        if (besAReg.RegroupementQuantite != null)
                            fCout *= besAReg.RegroupementQuantite.Quantite;
                        besAReg = besAReg.BesoinParent;
                    }
                    return fCout;
                }
                return null;
            }
        }

        //-----------------------------------------------
        /// <summary>
        /// Quantités définies par ce besoin
        /// </summary>
        [RelationFille(typeof(CBesoinQuantite), "Besoin")]
        [DynamicChilds("Quantities", typeof(CBesoinQuantite))]
        public CListeObjetsDonnees Quantites
        {
            get
            {
                return GetDependancesListe(CBesoinQuantite.c_nomTable, c_champId);
            }
        }

        //-----------------------------------------------
        /// <summary>
        /// Identifiant de la quantité parente liée à ce besoin (système)
        /// </summary>
        [TableFieldProperty(c_champIdRegroupement, 64)]
        [DynamicField("Group quantity Id")]
        [TiagField("Group quantity Id")]
        public string IdRegroupementQuantite
        {
            get
            {
                return Row.Get<string>(c_champIdRegroupement);
            }
            set
            {
                Row[c_champIdRegroupement] = value;
            }
        }

        //-----------------------------------------------
        /// <summary>
        /// Commentaires liés au besoin
        /// </summary>
        [TableFieldProperty(c_champCommentaires, 10000, IsLongString=true)]
        [DynamicField("Comments")]
        public string Commentaires
        {
            get
            {
                return (string)Row[c_champCommentaires];
            }
            set
            {
                Row[c_champCommentaires] = value;
            }
        }

        //-----------------------------------------------
        public CBesoinQuantite GetQuantiteRegroupement(string strId)
        {
            foreach (CBesoinQuantite qte in Quantites)
                if (qte.IdUniversel == strId)
                    return qte;
            if (BesoinParent != null)
                return BesoinParent.GetQuantiteRegroupement(strId);
            return null;
        }

        //-----------------------------------------------
        /// <summary>
        /// Quantité parente liée à ce besoin
        /// </summary>
        [DynamicField("Group quantity")]
        public CBesoinQuantite RegroupementQuantite
        {
            get
            {
                string strId = IdRegroupementQuantite;
                if (strId != null && strId.Length > 0 && BesoinParent != null)
                    return BesoinParent.GetQuantiteRegroupement(strId);
                return null;
            }
            set
            {
                string strOld = IdRegroupementQuantite;
                if (value != null && BesoinParent != null && BesoinParent.GetQuantiteRegroupement(value.IdUniversel) != null)
                {
                    IdRegroupementQuantite = value.IdUniversel;
                    AssureCoherenceRegroupementsFils();
                }
                else
                    IdRegroupementQuantite = "";
                if (IdRegroupementQuantite != strOld)
                {
                    HashSet<CBesoin> set = new HashSet<CBesoin>();
                    FillHashsetElementsEtFils(this, set);
                    IEnumerable<IElementACout> lstElts = from b in set select b as IElementACout;
                    CUtilElementACout.OnChangeCout(lstElts, true, false);
                    CUtilElementACout.OnChangeCout(lstElts, true, true);
                }
            }
        }

        //-----------------------------------------------
        //Un parent auquel est affecté un regroupement
        //ne doit pas avoir de fils affectés à des regroupements
        //qui ne seraient pas des regroupement du parent ou de l'un de ses fils.
        private void AssureCoherenceRegroupementsFils()
        {
            if (RegroupementQuantite != null)
            {
                //Vérifie que les fils n'ont pas de regroupement qui sont des
                //regroupements parents de moi-meme
                CBesoinQuantite[] qtesANePasVoirDansLesFils = QuantitesParentes;
                foreach (CBesoin b in BesoinsFils)
                {
                    b.MetANullRegroupementSiParmi(qtesANePasVoirDansLesFils);
                }
            }
        }

        //-----------------------------------------------
        private void MetANullRegroupementSiParmi(CBesoinQuantite[] qtesInterdites)
        {
            if (qtesInterdites.Contains(RegroupementQuantite))
                RegroupementQuantite = null;
            foreach (CBesoin b in BesoinsFils)
                b.MetANullRegroupementSiParmi(qtesInterdites);
        }

        //-----------------------------------------------
        public CBesoinQuantite[] QuantitesParentes
        {
            get
            {
                List<CBesoinQuantite> lst = new List<CBesoinQuantite>();
                if (BesoinParent != null)
                    BesoinParent.FillListeQuantites(lst);
                lst.Sort((x, y) => x.Libelle.CompareTo(y.Libelle));
                return lst.ToArray();
            }
        }

        //-----------------------------------------------
        protected void FillListeQuantites(List<CBesoinQuantite> lst)
        {
            foreach (CBesoinQuantite b in Quantites)
                lst.Add(b);
            if (BesoinParent != null && RegroupementQuantite == null)
                BesoinParent.FillListeQuantites(lst);
        }

        //-----------------------------------------------
        public IEnumerable<CBesoin> GetTousLesBesoinsDontLeCoutEstDépendantDeMonCout()
        {
            HashSet<CBesoin> set = new HashSet<CBesoin>();
            FillHashSetTousLesBesoinsDontLeCoutEstDépendantDeMonCout(set);
            return set.ToArray();
        }

        //-----------------------------------------------
        private void FillHashSetTousLesBesoinsDontLeCoutEstDépendantDeMonCout(HashSet<CBesoin> set)
        {
            if (!set.Contains(this))
            {
                set.Add(this);
                if (BesoinParent != null)
                    BesoinParent.FillHashSetTousLesBesoinsDontLeCoutEstDépendantDeMonCout(set);
                foreach (CBesoinDependance dep in LiensBesoinsDependant)
                    dep.BesoinDependant.FillHashSetTousLesBesoinsDontLeCoutEstDépendantDeMonCout(set);
            }
        }

        //-----------------------------------------------
        public IEnumerable<CBesoin> GetTousLesBesoinsDontLeCoutDependDeMesQuantites()
        {
            HashSet<CBesoin> set = new HashSet<CBesoin>();
            FillTousLesBesoinsDontLeCoutDépendDeMesQuantites(set);
            return set.ToArray();
        }

        //-----------------------------------------------
        private void FillTousLesBesoinsDontLeCoutDépendDeMesQuantites(HashSet<CBesoin> set)
        {
            StringBuilder bl = new StringBuilder();
            foreach (CBesoinQuantite q in Quantites)
            {
                bl.Append("'");
                bl.Append(q.IdUniversel);
                bl.Append("',");
            }
            if (bl.Length > 0)
            {
                bl.Remove(bl.Length - 1, 1);
                CListeObjetDonneeGenerique<CBesoin> lst = new CListeObjetDonneeGenerique<CBesoin>(ContexteDonnee);
                lst.Filtre = new CFiltreData(CBesoin.c_champIdRegroupement + " in (" + bl.ToString() + ")");
                foreach (CBesoin b in lst)
                    FillHashsetElementsEtFils(b, set);
            }
        }

        //-----------------------------------------------
        private void FillHashsetElementsEtFils(CBesoin besoin, HashSet<CBesoin> set)
        {
            set.Add(besoin);
            foreach (CBesoin fils in besoin.BesoinsFils)
                FillHashsetElementsEtFils(fils, set);
        }

     
        //-----------------------------------------------
        public override string ChampCodeSystemeComplet
        {
            get { return c_champCodeSystemeComplet; }
        }

        //-----------------------------------------------
        public override string ChampCodeSystemePartiel
        {
            get { return c_champCodeSystemePartiel; }
        }

        //-----------------------------------------------
        public override string ChampIdParent
        {
            get { return c_champIdBesoinParent; }
        }

        //-----------------------------------------------
        public override string ChampLibelle
        {
            get { return c_champLibelle; }
        }

        //-----------------------------------------------
        public override string ChampNiveau
        {
            get { return c_champNiveau; }
        }

        //----------------------------------------------------
        /// <summary>
        /// Indique le code système complet du besoin.
        /// Ce code système complet est la concaténation du code système partiel du besoin
        /// avec le code système partiel de tous ses parents en remontant la hiérarchie.
        /// Exemple : pour un code système complet tel que : 0012000A0034 :
        /// 0034 est le code partiel du besoin courant
        /// 000A est le code partiel du besoin père
        /// 0012 est le code partiel du besoin grand père
        /// </summary>
        [TableFieldProperty(c_champCodeSystemeComplet, 400)]
        [DynamicField("Full system code")]
        public override string CodeSystemeComplet
        {
            get
            {
                return (string)Row[c_champCodeSystemeComplet];
            }
        }


        //----------------------------------------------------
        /// <summary>
        /// Indique le code système propre au besoin.
        /// Ce code est unique dans son besoin parent.
        /// Ce code est exprimé  sur 4 caractères alphanumériques.
        /// </summary>
        [TableFieldProperty(c_champCodeSystemePartiel, 4)]
        [DynamicField("Partial system code")]
        public override string CodeSystemePartiel
        {
            get
            {
                string strVal = "";
                if (Row[c_champCodeSystemePartiel] != DBNull.Value)
                    strVal = (string)Row[c_champCodeSystemePartiel];
                strVal = strVal.Trim().PadLeft(4, '0');
                return strVal;
            }
        }

        //----------------------------------------------------
        public override int NbCarsParNiveau
        {
            get { return 4; }
        }

        //----------------------------------------------------
        /// <summary>
        /// Indique le niveau hiérarchique( nombre de parents ) du besoin<br/>
        /// Le niveau d'un besoin sans parent est 0.<br/>
        /// Exemple : besoin Site -> Installation -> Main d'oeuvre<br/>
        /// 'Besoin site' a pour niveau 0,<br/>
        /// 'Besoin Installation' inclus dans 'Besoin site' a pour niveau 1 (1 parent en remontant la hiérarchie)<br/>
        /// 'Besoin main d'oeuvre' dans 'Besoin installation' a pour niveau 2 (2 parents en rempontant la hiérachie)
        /// </summary>
        [TableFieldProperty(c_champNiveau)]
        [DynamicField("Level")]
        public override int Niveau
        {
            get
            {
                return (int)Row[c_champNiveau];
            }
        }

        //---------------------------------------------
        /// <summary>
        /// Liste des relations aux éléments satisfaisant ce besoin
        /// </summary>
        [RelationFille(typeof(CRelationBesoin_Satisfaction), "Besoin")]
        [DynamicChilds("Satisfactions links", typeof(CRelationBesoin_Satisfaction))]
        public CListeObjetsDonnees RelationsSatisfactions
        {
            get
            {
                CListeObjetsDonnees lst = GetDependancesListe(CRelationBesoin_Satisfaction.c_nomTable, c_champId);
                if (IsValide())
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champHasSatisfactions, lst.Count > 0);
                return lst;
            }
        }

        //---------------------------------------------
        /// <summary>
        /// Ajoute une satisfaction à un besoin
        /// </summary>
        /// <param name="satisfaction"></param>
        /// <param name="fCoefCout"></param>
        [DynamicMethod("Add a satisfaction to a need", "satisfaction", "Cost ratio")]
        public void AddSatisfaction(ISatisfactionBesoin satisfaction, double? fCoefCout)
        {
            if (satisfaction == null)
                return;
            satisfaction = ((CObjetDonnee)satisfaction).GetObjetInContexte(ContexteDonnee) as ISatisfactionBesoin;
            if ( CUtilElementACout.IsSourceDe(this, satisfaction))
                return;
            //Trouve la relation à la satisfaction
            CListeObjetsDonnees sats = RelationsSatisfactions;
            sats.Filtre = new CFiltreData(
                CRelationBesoin_Satisfaction.c_champIdElement + "=@1 and " +
                CRelationBesoin_Satisfaction.c_champTypeElement + "=@2",
                satisfaction.Id,
                satisfaction.GetType().ToString());
            if (sats.Count != 0)
            {
                ((CRelationBesoin_Satisfaction)sats[0]).RatioCoutReel = fCoefCout;
            }
            else
            {
                CRelationBesoin_Satisfaction rel = new CRelationBesoin_Satisfaction(ContexteDonnee);
                rel.CreateNewInCurrentContexte();
                rel.Satisfaction = satisfaction;
                rel.Besoin = this;
                rel.RatioCoutReel = fCoefCout;
                CRelationBesoin_Satisfaction.ResetCache(satisfaction);
            }
            
            CUtilElementACout.OnChangeCout(satisfaction, false, false);
            CUtilElementACout.OnChangeCout(satisfaction, true, false);
            CUtilElementACout.OnChangeCout(this, false, false);
            CUtilElementACout.OnChangeCout(this, true, false);
            ResetHasSatisfactions();
        }

        //------------------------------------------------------------------
        public void RemoveSatisfaction(ISatisfactionBesoin satisfaction)
        {
            if (satisfaction == null)
                return;
            satisfaction = ((CObjetDonnee)satisfaction).GetObjetInContexte(ContexteDonnee) as ISatisfactionBesoin;
            //Trouve la relation à la satisfaction
            CListeObjetsDonnees sats = RelationsSatisfactions;
            sats.Filtre = new CFiltreData(
                CRelationBesoin_Satisfaction.c_champIdElement + "=@1 and " +
                CRelationBesoin_Satisfaction.c_champTypeElement + "=@2",
                satisfaction.Id,
                satisfaction.GetType().ToString());
            if (sats.Count != 0)
            {
                foreach (CRelationBesoin_Satisfaction rel in sats)
                {
                    CUtilElementACout.OnChangeCout(rel.Satisfaction, false, false);
                    CUtilElementACout.OnChangeCout(rel.Satisfaction, true, false);
                }
                ResetHasSatisfactions();
                CRelationBesoin_Satisfaction.ResetCache(satisfaction);
                CResultAErreur result = CObjetDonneeAIdNumerique.Delete(sats, true);
                CUtilElementACout.OnChangeCout(this, false, false);
                CUtilElementACout.OnChangeCout(this, true, false);

            }
            
        }

        [DynamicField("Summary label")]
        public string LibelleResume
        {
            get
            {
                if (BesoinParent == null)
                    return PhaseSpecifications.Libelle + " " + Libelle;
                else
                    return BesoinParent.LibelleResume + "/" + Libelle;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Libellé du besoin en tant que satisfaction de besoin
        /// </summary>
        [DynamicField("Satisfaction label")]
        public string LibelleSatisfactionComplet
        {
            get { return LibelleResume;}// I.T("Need @1|20167", LibelleResume); }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Besoins satisfaits par ce besoin
        /// </summary>
        [DynamicChilds("Satisfied needs", typeof(CBesoin))]
        public CBesoin[] BesoinsSolutionnes
        {
            get 
            {
                return (CBesoin[])CRelationBesoin_Satisfaction.GetBesoinsSatisfaits(this).ToArray(typeof(CBesoin)); 
            }
        }

        //---------------------------------------------
        /// <summary>
        /// Relations aux besoins satisfaits par ce besoin
        /// </summary>
        [DynamicChilds("Satisfied needs relations", typeof(CRelationBesoin_Satisfaction))]
        public CListeObjetsDonnees RelationsSatisfaits
        {
            get
            {
                return CRelationBesoin_Satisfaction.GetRelationsBesoinsSatisfaits(this);
            }
        }


        //-----------------------------------------------------------
        public bool CanSatisfaire(CBesoin besoin)
        {
            if (besoin != null)
                return true;
            return false;
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

        //-----------------------------------------------------------
        public CObjetDonneeAIdNumerique ObjetPourEditionElementACout
        {
            get
            {
                if (PhaseSpecifications != null && PhaseSpecifications.Projet != null)
                    return PhaseSpecifications.Projet;
                return PhaseSpecifications;
            }
        }


        //-----------------------------------------------------------
        public bool ApplyTemplate(CPhaseSpecifications phaseTemplate)
        {
            if ( phaseTemplate == null )
                return false;
            if (HasChildren)//On n'applique pas de template si il existe des fils
                return false;

            CListeObjetsDonnees besoinsDuTemplate = phaseTemplate.Besoins;
            besoinsDuTemplate.Filtre = new CFiltreData(CBesoin.c_champIdBesoinParent + " is null");
            Dictionary<string, string> dicIdQuantitesOrgToNew = new Dictionary<string,string>();
            Dictionary<int, int> dicBesoinsOrgToNew = new Dictionary<int,int>();
            if (besoinsDuTemplate.Count == 1)
            {
                //Si un seul élément dans le template, copie directement le template
                CBesoin besoin = besoinsDuTemplate[0] as CBesoin;
                CopyFromTemplate ( besoin, dicIdQuantitesOrgToNew, dicBesoinsOrgToNew);
            }
            else
            {
                foreach (CBesoin besoin in besoinsDuTemplate)
                {
                    CBesoin newBesoin = new CBesoin(ContexteDonnee);
                    newBesoin.CreateNewInCurrentContexte();
                    newBesoin.BesoinParent = this;
                    newBesoin.PhaseSpecifications = PhaseSpecifications;
                    newBesoin.Index = besoin.Index;
                    newBesoin.CopyFromTemplate(besoin, dicIdQuantitesOrgToNew, dicBesoinsOrgToNew);
                }
            }

            CopieDependances(dicBesoinsOrgToNew);
            return true;
        }

        //-----------------------------------------------------------
        private void CopieDependances(Dictionary<int, int> dicBesoinsOrgToNew)
        {
            foreach (KeyValuePair<int, int> kv in dicBesoinsOrgToNew)
            {
                CBesoin bOrg = new CBesoin(ContexteDonnee);
                if (!bOrg.ReadIfExists(kv.Key, false))
                    continue;
                CBesoin bDest = new CBesoin(ContexteDonnee);
                if (!bDest.ReadIfExists(kv.Value, false))
                    continue;
                foreach (CBesoinDependance dep in bOrg.LiensBesoinsDontJeDepend)
                {
                    int nIdRefOrg = (int)dep.Row[CBesoinDependance.c_champIdBesoinReference];
                    if (dicBesoinsOrgToNew.ContainsKey(nIdRefOrg))
                    {
                        int nIdRefNew = dicBesoinsOrgToNew[nIdRefOrg];
                        CBesoin besoinRef = new CBesoin(ContexteDonnee);
                        if (besoinRef.ReadIfExists(nIdRefNew, false))
                        {
                            CBesoinDependance newDep = new CBesoinDependance(ContexteDonnee);
                            newDep.CreateNewInCurrentContexte();
                            newDep.BesoinReference = besoinRef;
                            newDep.BesoinDependant = bDest;
                        }
                    }
                }
            }
        }

        //-----------------------------------------------------------
        public Dictionary<int, int> CopyFromTemplate(CBesoin besoinTemplate)
        {
            Dictionary<string, string> mapIdOriginalQuantitesToNew = new Dictionary<string, string>();
            Dictionary<int, int> mapOriginalBesoinsToNew = new Dictionary<int, int>();
            CopyFromTemplate(besoinTemplate, mapIdOriginalQuantitesToNew,
                mapOriginalBesoinsToNew);
            CopieDependances(mapOriginalBesoinsToNew);
            return mapOriginalBesoinsToNew;
        }


        //-----------------------------------------------------------
        public void CopyFromTemplate(CBesoin besoinTemplate,
            Dictionary<string, string> mapIdOriginalQuantitesToNew,
            Dictionary<int, int> mapOriginalBesoinsToNew)
        {
            mapOriginalBesoinsToNew[besoinTemplate.Id] = Id;
            Libelle = besoinTemplate.Libelle;
            CListeObjetsDonnees lstQuantites = besoinTemplate.Quantites;
            lstQuantites.Filtre = new CFiltreData ( CBesoinQuantite.c_champIdQteParente+" is null");
            foreach ( CBesoinQuantite q in lstQuantites )
            {
                CBesoinQuantite newQ = new CBesoinQuantite(ContexteDonnee);
                newQ.CreateNewInCurrentContexte();
                newQ.Besoin = this;
                newQ.CopyFromTemplate(q, mapIdOriginalQuantitesToNew);
            }
            IDonneeBesoin donnee = besoinTemplate.DonneeBesoin;
            DonneeBesoin = donnee;

            if (besoinTemplate.IdRegroupementQuantite != null && besoinTemplate.IdRegroupementQuantite.Trim().Length > 0)
            {
                string strIdDest = null;
                if (mapIdOriginalQuantitesToNew.TryGetValue(besoinTemplate.IdRegroupementQuantite, out strIdDest))
                {
                    if (strIdDest != null)
                        IdRegroupementQuantite = strIdDest;
                }
            }

            foreach (CBesoin filsTemplate in besoinTemplate.BesoinsFils)
            {
                CBesoin filsCible = new CBesoin(ContexteDonnee);
                filsCible.CreateNewInCurrentContexte();
                filsCible.PhaseSpecifications = PhaseSpecifications;
                filsCible.Index = filsTemplate.Index;
                filsCible.BesoinParent = this;
                filsCible.CopyFromTemplate(filsTemplate, mapIdOriginalQuantitesToNew, mapOriginalBesoinsToNew);
            }
        }

        protected override CResultAErreur BeforeDelete()
        {
            CResultAErreur result = base.BeforeDelete();
            return result;
        }


        #region ISatisfactionBesoinAvecSousBesoins Membres

        //---------------------------------------------------------
        public CBesoin[] GetSousBesoinsDeSatisfactionDirects()
        {
            return BesoinsFils.ToArray<CBesoin>();
        }

        //---------------------------------------------------------
        public CBesoin[] GetSousBesoinsDeSatisfaction()
        {
            HashSet<CBesoin> set = new HashSet<CBesoin>();
            foreach (CBesoin besoin in BesoinsFils)
            {
                set.Add(besoin);
                besoin.FillSetSousBesoins(set);
            }
            return set.ToArray();
        }

        //---------------------------------------------------------
        private void FillSetSousBesoins(HashSet<CBesoin> set)
        {
            foreach (CBesoin b in BesoinsFils)
                set.Add(b);
        }

        //---------------------------------------------------------
        public ISatisfactionBesoin[] GetSousSatisfactions()
        {
            return new ISatisfactionBesoinAvecSousBesoins[0];
        }

        #endregion

        public void FillSetBesoins(HashSet<CBesoin> setBesoins, HashSet<ISatisfactionBesoinAvecSousBesoins> setSousElementsFaits)
        {
            if (setBesoins.Contains(this))
                return;
            setBesoins.Add(this);
            foreach (CRelationBesoin_Satisfaction rel in RelationsSatisfactions)
            {
                ISatisfactionBesoinAvecSousBesoins satAvecSubsBesoins = rel.Satisfaction as ISatisfactionBesoinAvecSousBesoins;
                if (satAvecSubsBesoins != null)
                {
                    satAvecSubsBesoins.FillSetBesoins(setBesoins, setSousElementsFaits);
                }
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

                    
    }
}
