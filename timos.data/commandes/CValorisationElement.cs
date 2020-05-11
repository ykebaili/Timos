using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

using tiag.client;

using timos.data;
using timos.data.commandes;
using timos.data.equipement.consommables;
using sc2i.common.unites;

namespace timos.data.commandes
{
    public interface IElementValorisable
    {
        string Libelle { get; }
    }


	/// <summary>
	/// Valorisation Equipement, Consommable ou opération. Permet de valoriser des équipements, des consommables ou des opérations d'un même type
	/// </summary>
    [DynamicClass("Equipment type valuation")]
	[Table(CValorisationElement.c_nomTable, CValorisationElement.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CValorisationElementServeur")]
	[TiagClass(CValorisationElement.c_nomTiag, "Id", true)]
    [ReplaceClass("timos.data.commande.CValorisationEquipement")]
	public class CValorisationElement : CObjetDonneeAIdNumeriqueAuto,
		IElementAInterfaceTiag
	{
		public const string c_nomTiag = "Equipment type valuation";
		public const string c_nomTable = "VALUATION_EQT_TYPE";
		public const string c_champId = "VAEQTP_ID";
        public const string c_champValeur = "VAEQTP_VALUE";
        public const string c_champQuantite = "VAEQTP_QTE";
        public const string c_champUnite = "VAEQTP_UNIT";
        

		/// /////////////////////////////////////////////
		public CValorisationElement( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CValorisationElement(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Valuation of @1|20124", TypeEquipement != null?TypeEquipement.Libelle:
                    (TypeConsommable!=null?TypeConsommable.Libelle:
                    (TypeOperation != null?TypeOperation.Libelle:"?")));
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            Quantite = 1;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champId};
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


        //-----------------------------------------------------------
        /// <summary>
        /// Valeur correspondante (montant)
        /// </summary>
        [TableFieldProperty(c_champValeur)]
        [DynamicField("Value")]
        public double Valeur
        {
            get
            {
                return (double)Row[c_champValeur];
            }
            set
            {
                Row[c_champValeur] = value;
            }
        }

        //-----------------------------------------------------------
        [DynamicField("Unitary value")]
        public double ValeurUnitaire
        {
            get
            {
                if (TypeEquipement != null)
                    return Valeur;
                if (TypeConsommable != null)
                {
                    IUnite unite = TypeConsommable.Unite;
                    CValeurUnite vu = new CValeurUnite(Quantite, IdUnite);
                    try
                    {
                        vu = vu.ConvertTo(unite.GlobalId);
                        if (vu.Valeur > 0)
                            return Valeur / vu.Valeur;
                    }
                    catch
                    {

                    }
                }
                return Valeur;
            }
        }

        /// /////////////////////////////////////////////
        /// <summary>
        /// Indique la quantité à laquelle correspond la valorisation
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
                Row[c_champQuantite] = value;
            }
        }

        /// /////////////////////////////////////////////
        [TableFieldProperty(c_champUnite, 200)]
        [DynamicField("Unit id")]
        public string IdUnite
        {
            get
            {
                return (string)Row[c_champUnite];
            }
            set
            {
                Row[c_champUnite] = value;
            }
        }

        /// /////////////////////////////////////////////
        public IUnite Unite
        {
            get
            {
                IUnite unite = CGestionnaireUnites.GetUnite(IdUnite);
                return unite;
            }
            set
            {
                if (value == null)
                    IdUnite = "";
                else
                    IdUnite = value.GlobalId;
            }
        }

        /// /////////////////////////////////////////////
        public CValeurUnite QuantiteEtUnite
        {
            get
            {
                IUnite unite = Unite;
                if (unite == null)
                    return null;
                return new CValeurUnite(Quantite, unite.Classe.UniteBase, unite.LibelleCourt);
            }
            set
            {
                if (value != null)
                {
                    Quantite = value.ConvertToBase();
                    Unite = value.IUnite;
                }
                else
                {
                    Unite = null;
                    Quantite = 1;
                }
            }
        }

        //-------------------------------------------------------------------
        public void TiagSetEquipmentTypeKeys(object[] cles)
        {
            CTypeEquipement te = new CTypeEquipement(ContexteDonnee);
            if (te.ReadIfExists(cles))
            {
                TypeEquipement = te;
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// <see cref="CTypeEquipement">Type d'équipement</see> correspondant
        /// </summary>
        [Relation(
            CTypeEquipement.c_nomTable,
            CTypeEquipement.c_champId,
            CTypeEquipement.c_champId,
            false,
            false,
            true)]
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
            }
        }


        //-------------------------------------------------------------------
        /// <summary>
        /// <see cref="CTypeConsommable">Type de consommable</see> correspondant
        /// </summary>
        [Relation(
            CTypeConsommable.c_nomTable,
            CTypeConsommable.c_champId,
            CTypeConsommable.c_champId,
            false,
            false,
            true)]
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
        
        //-------------------------------------------------------------------
        /// <summary>
        /// <see cref="CTypeOperation">Type d'opération</see> correspondant
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
        public IElementValorisable ElementValorisé
        {
            get
            {
                CTypeEquipement typeEqpt = TypeEquipement;
                if (typeEqpt != null)
                    return typeEqpt;
                if (TypeOperation != null)
                    return TypeOperation;
                return TypeConsommable;
            }
            set
            {
                CTypeEquipement typeEqpt = value as CTypeEquipement;
                if (typeEqpt != null)
                    TypeEquipement = typeEqpt;
                else
                {
                    CTypeConsommable typeConsommable = value as CTypeConsommable;
                    if (typeConsommable != null)
                        TypeConsommable = typeConsommable;
                    else
                    {
                        CTypeOperation typeOperation = value as CTypeOperation;
                        if (typeOperation != null)
                            TypeOperation = typeOperation;
                        else
                        {
                            TypeEquipement = null;
                            TypeConsommable = null;
                        }
                    }
                }
            }
        }



        //-------------------------------------------------------------------
        /// <summary>
        /// <see cref="CLotValorisation">Lot de valorisations</see> auquel cette valorisation appartient
        /// </summary>
        [Relation(
            CLotValorisation.c_nomTable,
            CLotValorisation.c_champId,
            CLotValorisation.c_champId,
            true,
            false,
            false)]
        [DynamicField("Valuation lot")]
        public CLotValorisation LotValorisation    
        {
            get
            {
                return (CLotValorisation)GetParent(CLotValorisation.c_champId, typeof(CLotValorisation));
            }
            set
            {
                SetParent(CLotValorisation.c_champId, value);
            }
        }


        //---------------------------------------------
        /// <summary>
        /// Liste des <see cref="CEquipement">Equipements</see> concernés par cette valorisation
        /// </summary>
        [RelationFille(typeof(CEquipement), "ValorisationEquipement")]
        [DynamicChilds("Linked equipments", typeof(CEquipement))]
        public CListeObjetsDonnees EquipementsLies
        {
            get
            {
                return GetDependancesListe(CEquipement.c_nomTable, c_champId);
            }
        }
        
	}
}
