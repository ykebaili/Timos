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
using System.Collections.Generic;
using timos.data.equipement.consommables;

namespace timos.data.commandes
{
	/// <summary>
    /// Lot de valorisations. 
    /// Permet de définir une liste de prix pour des types d'équipements.
    /// Est exploité dans les <see cref="CLivraisonEquipement">livraisons</see>
    /// liées aux <see cref="CCommande">commandes</see>
	/// </summary>
    [DynamicClass("Valuation lot")]
	[Table(CLotValorisation.c_nomTable, CLotValorisation.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CLotValorisationServeur")]
	[TiagClass(CLotValorisation.c_nomTiag, "Id", true)]
	public class CLotValorisation : CObjetDonneeAIdNumeriqueAuto,
		IElementAInterfaceTiag
	{
		public const string c_nomTiag = "Valuation lot";
		public const string c_nomTable = "VALUATION_LOT";
		public const string c_champId = "VALOT_ID";
        public const string c_champLibelle = "VALOT_LABEL";
        public const string c_champDateLot = "VALOT_DATE";

		/// /////////////////////////////////////////////
		public CLotValorisation( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CLotValorisation(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Valuation lot @1|20123", Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            DateLot = DateTime.Now;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champDateLot+" desc"};
		}


		

		/// <summary>
		/// Le libellé du lot
		/// </summary>
		[TableFieldProperty(c_champLibelle, 255)]
		[DynamicField("Label")]
		[TiagField("Label")]
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
        /// Date du lot de livraison
        /// </summary>
        [TableFieldProperty(c_champDateLot)]
        [DynamicField("Lot date")]
        [TiagField("Lot date")]
        public DateTime DateLot
        {
            get
            {
                return (DateTime)Row[c_champDateLot];
            }
            set
            {
                Row[c_champDateLot] = value;
            }
        }


        //-------------------------------------------------------------------
        public void TiagSetOrderIds(object[] cles)
        {
            CCommande cde = new CCommande(ContexteDonnee);
            if (cde.ReadIfExists(cles))
                Commande = cde;
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// <see cref="CCommande">Commande</see> associée au lot de livraison
        /// </summary>
        [Relation(
            CCommande.c_nomTable,
            CCommande.c_champId,
            CCommande.c_champId,
            false,
            false,
            false)]
        [DynamicField("Order")]
        [TiagRelation(typeof(CCommande), "TiagSetOrderIds")]
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


        //---------------------------------------------
        /// <summary>
        /// Liste des <see cref="CValorisationEquipement">valorisations</see> correspondant au lot
        /// </summary>
        [RelationFille(typeof(CValorisationElement), "LotValorisation")]
        [DynamicChilds("Valuations", typeof(CValorisationElement))]
        public CListeObjetsDonnees Valorisations
        {
            get
            {
                return GetDependancesListe(CValorisationElement.c_nomTable, c_champId);
            }
        }

        //---------------------------------------------
        /// <summary>
        /// Liste des <see cref="CLivraisonLotValorisation">objets de relation</see> de ce lot 
        /// vers les livraisons correspondantes
        /// </summary>
        [RelationFille(typeof(CLivraisonLotValorisation), "LotDeValorisation")]
        [DynamicChilds("Deliveries links", typeof(CLivraisonLotValorisation))]
        public CListeObjetsDonnees RelationsLivraisons
        {
            get
            {
                return GetDependancesListe(CLivraisonLotValorisation.c_nomTable, c_champId);
            }
        }

        //--------------------------------------------------------------------
        public void AjouterEquipementsDepuisLivraisonInCurrentContext ( CLivraisonEquipement livraison )
        {
            if ( livraison == null )
                return;
            HashSet<int> setPresents = new HashSet<int>();
            foreach ( CValorisationElement val in Valorisations )
            {
                if ( val.TypeEquipement != null )
                    setPresents.Add ( val.TypeEquipement.Id );
            }
            foreach ( CLigneLivraisonEquipement ligne in livraison.Lignes )
            {
                if ( ligne.Equipement != null && ligne.Equipement.TypeEquipement != null && 
                    !setPresents.Contains ( ligne.Equipement.TypeEquipement.Id ))
                {
                    CValorisationElement valo = new CValorisationElement ( ContexteDonnee );
                    valo.CreateNewInCurrentContexte();
                    valo.TypeEquipement = ligne.Equipement.TypeEquipement;
                    valo.LotValorisation = this;
                    setPresents.Add(ligne.Equipement.TypeEquipement.Id);
                }
            }
        }
        
        //--------------------------------------------------------------------
        public void AjouterEquipementsDepuisCommandeInCurrentContext(CCommande commande)
        {
            if (commande == null)
                return;
            HashSet<IElementCommandable> setCommandablesPresents = new HashSet<IElementCommandable>();
            foreach (CValorisationElement val in Valorisations)
            {
                IElementCommandable eltCom = val.ElementValorisé as IElementCommandable;
                if (eltCom != null)
                    setCommandablesPresents.Add(eltCom);
            }
            foreach (CLigneCommande ligne in commande.Lignes)
            {
                if (ligne.ElementCommandé != null &&
                    !setCommandablesPresents.Contains(ligne.ElementCommandé))
                {
                    CValorisationElement valo = new CValorisationElement(ContexteDonnee);
                    valo.CreateNewInCurrentContexte();
                    valo.ElementValorisé = ligne.ElementCommandé;
                    valo.LotValorisation = this;
                    setCommandablesPresents.Add(ligne.ElementCommandé);
                }
            }
        }

        //-----------------------------------------------------------
        public CValorisationElement GetValorisationElement(IElementValorisable elt)
        {
            if (elt is CTypeEquipement)
                return GetValorisation((CTypeEquipement)elt);
            if (elt is CTypeConsommable)
                return GetValorisation((CTypeConsommable)elt);
            if (elt is CTypeOperation)
                return GetValorisation((CTypeOperation)elt);
            return null;
        }


        //-----------------------------------------------------------
        public CValorisationElement GetValorisation(CEquipement eqt)
        {
            if (eqt == null)
                return null;
            return GetValorisation(eqt.TypeEquipement);
        }

        //-----------------------------------------------------------
        public CValorisationElement GetValorisation ( CTypeEquipement tp )
        {
            if (tp == null)
                return null;
            CListeObjetsDonnees lstValos = Valorisations;
            lstValos.Filtre = new CFiltreData(CTypeEquipement.c_champId + "=@1",
                tp.Id);
            if (lstValos.Count > 0)
                return lstValos[0] as CValorisationElement;
            return null;
        }

        //-----------------------------------------------------------
        public CValorisationElement GetValorisation(CTypeConsommable tp)
        {
            if (tp == null)
                return null;
            CListeObjetsDonnees lstValos = Valorisations;
            lstValos.Filtre = new CFiltreData(CTypeConsommable.c_champId + "=@1",
                tp.Id);
            if (lstValos.Count > 0)
                return lstValos[0] as CValorisationElement;
            return null;
        }

        //-----------------------------------------------------------
        public CValorisationElement GetValorisation(CTypeOperation tp)
        {
            if (tp == null)
                return null;
            CListeObjetsDonnees lstValos = Valorisations;
            lstValos.Filtre = new CFiltreData(CTypeOperation.c_champId + "=@1",
                tp.Id);
            if (lstValos.Count > 0)
                return lstValos[0] as CValorisationElement;
            return null;
        }
	}
}

