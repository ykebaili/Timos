using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

using tiag.client;

using timos.data;
using timos.data.projet.besoin;
using System.Collections.Generic;
using timos.data.equipement.consommables;
using sc2i.common.unites;

namespace timos.data.commandes
{
    /// <summary>
    /// Tout élément qui peut être commandé
    /// </summary>
    public interface IElementCommandable : IElementValorisable
    {
        IElementCommandable[] ReferencesCommandables{get;}
    }

    /// <summary>
    /// Référence d'un élément commandable quand l'élément commandable peut
    /// se décliner en plusieurs éléments.
    /// </summary>
    public interface IReferenceElementCommandable
    {
        IElementCommandable ElementCommandable { get; }
        string Reference { get; }
    }

	/// <summary>
    /// Une ligne de <see cref="CCommande">commande</see>
	/// </summary>
    [DynamicClass("Order line")]
	[Table(CLigneCommande.c_nomTable, CLigneCommande.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CLigneCommandeServeur")]
	[TiagClass(CLigneCommande.c_nomTiag, "Id", true)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_Stock_ID)]
    [TypeId("CMDLINE")]
    public class CLigneCommande : CObjetDonneeAIdNumeriqueAuto,
		IElementAInterfaceTiag,
        ISatisfactionBesoin
	{
		public const string c_nomTiag = "Order line";
		public const string c_nomTable = "ORDER_LINE";
		public const string c_champId = "ORDLI_ID";
        public const string c_champNumero = "ORDLI_NUM";
        public const string c_champQuantite = "ORDLI_QTE";
        public const string c_champLibelle = "ORDLI_LABEL";
        public const string c_champRef = "ORDLI_REF";

        public const string c_champCoutPrevisionnel = "ORDLI_ESTIMATED_COST";
        public const string c_champCoutReel = "ORDLI_ACTUAL_COST";

		/// /////////////////////////////////////////////
		public CLigneCommande( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CLigneCommande(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Order line|20118");
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            TypesCoutsParentsARecalculer = ETypeCout.Aucun;
            Row[c_champCoutReel] = 0;
            Row[c_champCoutPrevisionnel] = 0;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champNumero};
		}


        //-----------------------------------------------------------
        /// <summary>
        /// Libellé de la ligne
        /// </summary>
        [TableFieldProperty(c_champLibelle, 1024)]
        [DynamicField("Label")]
        public string Libelle
        {
            get
            {
                return (string)Row[c_champLibelle];
            }
            set
            {
                Row[c_champLibelle] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Référence du produit commandé (1024 caractères maximum)
        /// </summary>
        [TableFieldProperty(c_champRef, 1024)]
        [DynamicField("Reference")]
        public string Reference
        {
            get
            {
                return (string)Row[c_champRef];
            }
            set
            {
                Row[c_champRef] = value;
            }
        }



        //-----------------------------------------------------------
        /// <summary>
        /// Numéro de la ligne de commande
        /// </summary>
        [TableFieldProperty(c_champNumero)]
        [DynamicField("Line number")]
        public int Numero
        {
            get
            {
                return (int)Row[c_champNumero];
            }
            set
            {
                Row[c_champNumero] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Nombre d'articles concernant cette ligne de commande
        /// </summary>
        [TableFieldProperty(c_champQuantite)]
        [DynamicField("Quantity")]
        public double Quantite
        {
            get
            {
                return (double)Row[c_champQuantite];
            }
            set
            {
                double fOld = 0;
                if (Row[c_champQuantite] is double)
                    fOld = Quantite;
                Row[c_champQuantite] = value;
                if ( value != Quantite )
                CUtilElementACout.OnChangeCout ( this, false, false );
            }
        }

        //-----------------------------------------------------------
        //-------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstCles"></param>
        public void TiagSetOrderKeys(object[] lstCles)
        {
            CCommande commande = new CCommande(ContexteDonnee);
            if (commande.ReadIfExists(lstCles))
                Commande = commande;
        }
        //-------------------------------------------------------------------
        /// <summary>
        /// <see cref="CCommande">Commande</see> concernée par cette ligne
        /// </summary>
        [Relation(
            CCommande.c_nomTable,
            CCommande.c_champId,
            CCommande.c_champId,
            true,
            true,
            false)]
        [DynamicField("Order")]
        [TiagRelation(typeof(CCommande),"TiagSetOrderKeys")]
        public CCommande Commande
        {
            get
            {
                return (CCommande)GetParent(CCommande.c_champId, typeof(CCommande));
            }
            set
            {
                SetParent(CCommande.c_champId, value);
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstCles"></param>
        public void TiagSetEquipmentTypeKeys(object[] lstCles)
        {
            CTypeEquipement type = new CTypeEquipement(ContexteDonnee);
            if (type.ReadIfExists(lstCles))
                TypeEquipement = type;
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// <see cref="CTypeEquipement">Type d'équipement</see> objet de cette ligne
        /// </summary>
        [Relation(
            CTypeEquipement.c_nomTable,
            CTypeEquipement.c_champId,
            CTypeEquipement.c_champId,
            false,
            false,
            false)]
        [DynamicField("Equipment type")]
        [TiagRelation(typeof(CTypeEquipement), "TiagSetEquipmentTypeKeys")]
        public CTypeEquipement TypeEquipement
        {
            get
            {
                return (CTypeEquipement)GetParent(CTypeEquipement.c_champId, typeof(CTypeEquipement));
            }
            set
            {
                SetParent(CTypeEquipement.c_champId, value);
                if (value != null && ReferenceFournisseur != null && ReferenceFournisseur.TypeEquipement != value)
                    ReferenceFournisseur = null;
                if (value != null)
                {
                    TypeConsommable = null;
                    ConditionnementConsommable = null;
                }
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// <see cref="CRelationTypeEquipement_Fournisseurs">Relation vers la référence constructeur</see>
        /// </summary>
        [Relation(
            CRelationTypeEquipement_Fournisseurs.c_nomTable,
            CRelationTypeEquipement_Fournisseurs.c_champId,
            CRelationTypeEquipement_Fournisseurs.c_champId,
            false,
            false,
            false)]
        [DynamicField("Supplier reference")]
        public CRelationTypeEquipement_Fournisseurs ReferenceFournisseur
        {
            get
            {
                return (CRelationTypeEquipement_Fournisseurs)GetParent(CRelationTypeEquipement_Fournisseurs.c_champId, typeof(CRelationTypeEquipement_Fournisseurs));
            }
            set
            {
                SetParent(CRelationTypeEquipement_Fournisseurs.c_champId, value);
                if (value != null)
                {
                    TypeEquipement = value.TypeEquipement;
                    TypeConsommable = null;
                    ConditionnementConsommable = null;
                }
            }
        }


        //-------------------------------------------------------------------
        /// <summary>
        /// <see cref="CConditionnementConsommable">Relation vers le conditionnement commandé</see>
        /// </summary>
        [Relation(
            CConditionnementConsommable.c_nomTable,
            CConditionnementConsommable.c_champId,
            CConditionnementConsommable.c_champId,
            false,
            false,
            false)]
        [DynamicField("Consumable Conditionning")]
        public CConditionnementConsommable ConditionnementConsommable
        {
            get
            {
                return (CConditionnementConsommable)GetParent(CConditionnementConsommable.c_champId, typeof(CConditionnementConsommable));
            }
            set
            {
                SetParent(CConditionnementConsommable.c_champId, value);
                if (value != null)
                {
                    TypeConsommable = value.TypeConsommable;
                    TypeEquipement = null;
                    ReferenceFournisseur = null;
                }
            }
        }

	




        //-------------------------------------------------------------------
        /// <summary>
        /// Le <see cref="CTypeConsommable">type de consommable</see> commandé si cette ligne concerne un consommable
        /// </summary>
        [Relation(
            CTypeConsommable.c_nomTable,
            CTypeConsommable.c_champId,
            CTypeConsommable.c_champId,
            false,
            true,
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
                if (value != null)
                {
                    TypeEquipement = null;
                    ReferenceFournisseur = null;
                }
            }
        }

        //--------------------------------------------------
        public IElementCommandable ElementCommandé
        {
            get
            {
                CTypeEquipement te = TypeEquipement;
                if (te != null)
                    return te;
                return TypeConsommable;
            }
            set
            {
                CTypeEquipement te = value as CTypeEquipement;
                if (te != null)
                    TypeEquipement = te;
                else
                {
                    CTypeConsommable tc = value as CTypeConsommable;
                    if (tc != null)
                        TypeConsommable = tc;
                    else
                    {
                        TypeConsommable = null;
                        TypeEquipement = null;
                    }
                }
            }
        }

        //--------------------------------------------------
        public IReferenceElementCommandable ReferenceCommandée
        {
            get
            {
                CRelationTypeEquipement_Fournisseurs refFourn = ReferenceFournisseur;
                if (refFourn != null)
                    return refFourn;
                return ConditionnementConsommable;
            }
            set
            {
                CRelationTypeEquipement_Fournisseurs relFourn = value as CRelationTypeEquipement_Fournisseurs;
                if (relFourn != null)
                    ReferenceFournisseur = relFourn;
                else
                {
                    CConditionnementConsommable cond = value as CConditionnementConsommable;
                    if (cond != null)
                        ConditionnementConsommable = cond;
                    else
                    {
                        ReferenceFournisseur = null;
                        ConditionnementConsommable = null;
                    }
                }
            }
        }


	


	


	


	


	

		
		#region IElementAInterfaceTiag Membres

		public object[] TiagKeys
		{
			get { return new object[] { Id }; }
		}

		public string TiagType
		{
			get { return c_nomTiag; }
		}

		#endregion


        //---------------------------------------------
        /// <summary>
        /// Liste des <see cref="CLigneLivraisonEquipement">livraisons</see>
        /// </summary>
        [RelationFille(typeof(CLigneLivraisonEquipement), "LigneDeCommandeAssociee")]
        [DynamicChilds("Delivery lines", typeof(CLigneLivraisonEquipement))]
        public CListeObjetsDonnees LignesLivraison
        {
            get
            {
                return GetDependancesListe(CLigneLivraisonEquipement.c_nomTable, c_champId);
            }
        }



        //---------------------------------------------
        /// <summary>
        /// Besoins satisfaits par cette ligne de commande
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
        /// Relations aux besoins satisfaits par cette ligne de commande
        /// </summary>
        [DynamicChilds("Satisfied needs relations", typeof(CRelationBesoin_Satisfaction))]
        public CListeObjetsDonnees RelationsSatisfaits
        {
            get
            {
                return CRelationBesoin_Satisfaction.GetRelationsBesoinsSatisfaits(this);
            }
        }

        //---------------------------------------------
        public bool CanSatisfaire(CBesoin besoin)
        {
            return (ETypeDonneeBesoin)besoin.TypeBesoinCode == ETypeDonneeBesoin.TypeEquipement;
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

        //---------------------------------------------
        /// <summary>
        /// Libellé de la ligne de commande en tant que satisfaction de besoin
        /// </summary>
        [DynamicField("Satisfaction label")]
        public string LibelleSatisfactionComplet
        {
            get
            {
                return I.T("Order equipment type @1|20166",
                    TypeEquipement != null ? TypeEquipement.Libelle : "?");
            }
        }


        //---------------------------------------------
        public CObjetDonneeAIdNumerique ObjetPourEditionElementACout
        {
            get
            {
                return Commande;
            }
        }

        


        #region IElementACout Membres

        //---------------------------------------------
        /// <summary>
        /// cout prévisionnel de l'achat, se basant sur la valorisation
        /// de l'équipement ou du consommable à la date de la commande
        /// </summary>
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
        /// cout réel de la ligne de commande basée sur les valorisations attachées à la commande ou sur une valorisation correspondant
        /// à la date de livraison
        /// </summary>
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
            if (elementACout == null || elementACout.Row.RowState == DataRowState.Deleted)
                return 0;
            CBesoin besoin = elementACout as CBesoin;
            if (besoin != null)
                return CUtilElementACout.CalcImputationAFaireSur(this, besoin, bCoutReel);
            return 0;
        }

        

        //---------------------------------------------
        public bool IsCoutFromSources(bool bCoutReel)
        {
            return false;
        }

        //---------------------------------------------
        /// <summary>
        /// Indique les types de couts parents à recalculer
        /// </summary>
        [TableFieldProperty(CUtilElementACout.c_champCoutsParentsARecalculer, IsInDb = false)]
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

        //------------------------------------------------------
        public double CalculeTonCoutPuisqueTuNeCalculePasAPartirDesSourcesDeCout(bool bCoutReel)
        {
            if (bCoutReel)
            {
                foreach (CLigneLivraisonEquipement ligneLiv in LignesLivraison)
                {
                    if (ligneLiv.LivraisonEquipement != null)
                    {
                        CValorisationElement valo = ligneLiv.LivraisonEquipement.GetValorisation(ElementCommandé);
                        if (valo != null)
                        {
                            double fQte = 0;
                            if (ElementCommandé is CTypeEquipement)
                                fQte = Quantite;
                            if (ElementCommandé is CTypeConsommable)
                            {
                                //TODO calculer la valeur de consommable
                            }
                            return fQte * valo.Valeur;
                        }
                    }
                }
                return 0;
            }
            else
            {
                if (TypeConsommable != null)
                {
                    return TypeConsommable.GetValuationForDate(Commande.DateCommande, new CValeurUnite(Quantite, ""));
                }
                if (TypeEquipement != null)
                {
                    return TypeEquipement.GetValuationForDate(Commande.DateCommande) * Quantite;
                }
                return 0;
            }
        }

        //--------------------------------------------------------------
        public bool ShouldAjouterCoutPropreAuCoutDesSource(bool bCoutReel)
        {
            return false;
        }


        //---------------------------------------------
        public IElementACout[] GetSourcesDeCout(bool bCoutReel)
        {
            return new IElementACout[0];
        }

        //---------------------------------------------
        public CImputationsCouts GetImputationsAFaireSurUtilisateursDeCout()
        {
            CImputationsCouts imputations = new CImputationsCouts(this);
            foreach (CRelationBesoin_Satisfaction rel in RelationsSatisfaits)
                imputations.AddImputation(rel.Besoin, rel.RatioCoutReelApplique, rel);
            return imputations;
        }

        #endregion
    }
}
