using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using sc2i.data;
using sc2i.common;
using sc2i.process;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using sc2i.common.planification;

using timos.securite;
using timos.acteurs;
using timos.data.version;

using tiag.client;
using Lys.Licence.Types;
using Lys.Applications.Timos.Smt;
using System.Data;
using timos.data.supervision;
using sc2i.workflow;


namespace timos.data.commandes
{
	/// <summary>
    /// Livraison d'une <see cref="CCommande">commande</see>
    /// Contient les <see cref="CLigneLivraisonEquipement">lignes de livraison</see> et fait référence à des 
    /// <see cref="CLotValorisation">lots de valorisations</see> permettant d'évaluer le montant de la livraison.
	/// </summary>
	[DynamicClass("Delivery")]
	[ObjetServeurURI("CLivraisonEquipementServeur")]
	[Table(CLivraisonEquipement.c_nomTable, CLivraisonEquipement.c_champId, true)]
	[AutoExec("Autoexec")]
	[TiagClass(CLivraisonEquipement.c_nomTiag, "Id", true)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_Stock_ID)]
	public partial class CLivraisonEquipement : CElementAChamp,
							IElementATypeStructurant<CTypeLivraisonEquipement>

	{
		#region Déclaration des constantes
		public const string c_roleChampCustom = "DELIVERY";
		public const string c_nomTiag = "Delivery";

		public const string c_nomTable = "DELIVERY";
		public const string c_champId = "DELIV_ID";
        public const string c_champNumero = "DELIV_NUMBER";
        public const string c_champDateLivraisonEquipement = "DELIV_CREATE_DATE";
        public const string c_champIdCreateur = "DELIV_CREATEUSER_ID";
		#endregion

		//-------------------------------------------------------------------
		public static void Autoexec()
		{
			CRoleChampCustom.RegisterRole(c_roleChampCustom, I.T("Delivery|20120"), typeof(CLivraisonEquipement), typeof(CTypeLivraisonEquipement));
		}

		//-------------------------------------------------------------------
		public CLivraisonEquipement(CContexteDonnee ctx)
			: base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CLivraisonEquipement(System.Data.DataRow row)
			: base(row)
		{
		}

        //-------------------------------------------------------------------
        public override CRoleChampCustom RoleChampCustomAssocie
        {
            get { return CRoleChampCustom.GetRole(c_roleChampCustom); }
        }


		//-------------------------------------------------------------------
		protected override void MyInitValeurDefaut()
		{
            DateLivraisonEquipement = DateTime.Now;
            Createur = CUtilSession.GetUserForSession(ContexteDonnee);
		}

		//-------------------------------------------------------------------
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] { c_champNumero };
		}

		//-------------------------------------------------------------------
		public override string ToString()
		{
			return NumeroDeLivraisonEquipement;
		}

		//-------------------------------------------------------------------
		public override string DescriptionElement
		{
			get { return I.T("Delivery @1|20121", NumeroDeLivraisonEquipement); }
		}


       //-----------------------------------------------------------
        /// <summary>
        /// Numéro de la livraison
        /// </summary>
        [TableFieldProperty(c_champNumero, 255)]
        [DynamicField("Delivery n°")]
        public string NumeroDeLivraisonEquipement
        {
            get
            {
                return (string)Row[c_champNumero];
            }
            set
            {
                Row[c_champNumero] = value;
            }
        }


		public object[] TiagKeys
		{
			get { return new object[] { Id }; }
		}

		public string TiagType
		{
			get { return c_nomTiag; }
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Utilisé par TIAG pour affecter le type de site par ses clés
		/// </summary>
		/// <param name="lstCles"></param>
		public void TiagSetDeliveryTypeKeys(object[] lstCles)
		{
			CTypeLivraisonEquipement typeLivraisonEquipement = new CTypeLivraisonEquipement(ContexteDonnee);
			if (typeLivraisonEquipement.ReadIfExists(lstCles))
				TypeLivraisonEquipement = typeLivraisonEquipement;
		}

		//-------------------------------------------------------------------
		/// <summary>
        /// <see cref="CTypeLivraisonEquipement">Type de la livraison</see>
		/// </summary>
		[Relation(
			CTypeLivraisonEquipement.c_nomTable,
			CTypeLivraisonEquipement.c_champId,
			CTypeLivraisonEquipement.c_champId,
			false,
			false,
			true)]
		[DynamicField("Delivery type")]
        [TiagRelation(typeof(CTypeLivraisonEquipement), "TiagSetDeliveryTypeKeys")]
		public CTypeLivraisonEquipement TypeLivraisonEquipement
		{
			get 
            {
                return (CTypeLivraisonEquipement)GetParent(CTypeLivraisonEquipement.c_champId, typeof(CTypeLivraisonEquipement)); 
            }
			set
            {
                SetParent(CTypeLivraisonEquipement.c_champId, value); 
            }
		}


		//----------------------------------------------------------------------------------
		/// <summary>
		/// Utilisé par TIAG pour affecter le type de site par ses clés
		/// </summary>
		/// <param name="lstCles"></param>
		public void TiagSetOrderKeys(object[] lstCles)
		{
            CCommande commande = new CCommande(ContexteDonnee);
            if (commande.ReadIfExists(lstCles))
			{
				Commande = commande;
			}
		}

		//-----------------------------------------------------------------------------------
		/// <summary>
        /// <see cref="CCommande">Commande</see> concernée par la livraison
		/// </summary>
		[Relation(
			CCommande.c_nomTable,
            CCommande.c_champId,
            CCommande.c_champId,
			false,
			false,
			true)]
		[DynamicField("Order")]
        [TiagRelation(typeof(CCommande), "TiagSetOrderKeys")]
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


        
        //-----------------------------------------------------------
        /// <summary>
        /// Date de la livraison
        /// </summary>
        [TableFieldProperty(c_champDateLivraisonEquipement)]
        [DynamicField("Delivery date")]
        public DateTime DateLivraisonEquipement
        {
            get
            {
                return (DateTime)Row[c_champDateLivraisonEquipement];
            }
            set
            {
                Row[c_champDateLivraisonEquipement] = value;
            }
        }


        //-------------------------------------------------------------------
        /// <summary>
        /// <see cref="CDonneesActeurUtilisateur">Utilisateur</see> de l'application ayant créé la livraison
        /// </summary>
        [Relation(
            CDonneesActeurUtilisateur.c_nomTable,
            CDonneesActeurUtilisateur.c_champId,
            c_champIdCreateur,
            false,
            false,
            false)]
        [DynamicField("Creator")]
        public CDonneesActeurUtilisateur Createur   
        {
            get
            {
                return (CDonneesActeurUtilisateur)GetParent(c_champIdCreateur, typeof(CDonneesActeurUtilisateur));
            }
            set
            {
                SetParent(c_champIdCreateur, value);
            }
        }
	


		

        #region champs custom
        //-------------------------------------------------------------------
		public override IDefinisseurChampCustom[] DefinisseursDeChamps
		{
			get
			{

				List<IDefinisseurChampCustom> lst = new List<IDefinisseurChampCustom>();

                if (TypeLivraisonEquipement != null)
                    lst.Add(TypeLivraisonEquipement);
				return lst.ToArray();
			}
		}

		//-------------------------------------------------------------------
		public override CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
		{
			return new CRelationLivraisonEquipement_ChampCustom(ContexteDonnee);
		}

		//-------------------------------------------------------------------
		[RelationFille(typeof(CRelationLivraisonEquipement_ChampCustom), "ElementAChamps")]
		[DynamicChilds("Custom fields relations", typeof(CRelationLivraisonEquipement_ChampCustom))]
		public override CListeObjetsDonnees RelationsChampsCustom
		{
			get
			{
				return GetDependancesListe(CRelationLivraisonEquipement_ChampCustom.c_nomTable, GetChampId());
			}
		}
        # endregion

		#region IElementATypeStructurant<CTypeLivraisonEquipement> Membres

		public CTypeLivraisonEquipement ElementStructurant
		{
			get { return TypeLivraisonEquipement; }
		}
		public int IdTypeStructurant
		{
			get
			{
				return (int)Row[CTypeLivraisonEquipement.c_champId];
			}
		}
		#endregion

        //---------------------------------------------
        


        //---------------------------------------------
        /// <summary>
        /// Liste des <see cref="CLigneLivraisonEquipement">lignes</see> de livraison
        /// </summary>
        [RelationFille(typeof(CLigneLivraisonEquipement), "LivraisonEquipement")]
        [DynamicChilds("Delivery lines", typeof(CLigneLivraisonEquipement))]
        public CListeObjetsDonnees Lignes
        {
            get
            {
                return GetDependancesListe(CLigneLivraisonEquipement.c_nomTable, c_champId);
            }
        }




        //---------------------------------------------
        /// <summary>
        /// Liste des <see cref="CLivraisonLotValorisation">lots de valorisation</see> associés aux 
        /// équipements de cette livraison
        /// </summary>
        [RelationFille(typeof(CLivraisonLotValorisation), "Livraison")]
        [DynamicChilds("Valuation lots links", typeof(CLivraisonLotValorisation))]
        public CListeObjetsDonnees RelationsLotsValorisation
        {
            get
            {
                return GetDependancesListe(CLivraisonLotValorisation.c_nomTable, c_champId);
            }
        }

        //---------------------------------------------
        private CValorisationElement GetValorisation(CEquipement equipement)
        {
            if (equipement == null)
                return null;
            return GetValorisation(equipement.TypeEquipement);
        }

        //---------------------------------------------
        public CValorisationElement GetValorisation ( IElementValorisable element )
        {
            foreach (CLivraisonLotValorisation livLot in RelationsLotsValorisation)
            {
                if (livLot.LotDeValorisation != null)
                {
                    CValorisationElement valo = livLot.LotDeValorisation.GetValorisationElement(element);
                    if (valo != null)
                        return valo;
                }
            }
            return null;

        }

        //---------------------------------------------
        /// <summary>
        /// Applique la valorisation aux équipements livrés
        /// </summary>
        [DynamicMethod("Apply valuations to delivered equipments")]
        public void ApplyValuations()
        {
            AppliqueValorisation();
        }

        //---------------------------------------------
        public CResultAErreur AppliqueValorisation()
        {
            CResultAErreur result = CResultAErreur.True;
            HashSet<int> idsLots = new HashSet<int>();
            foreach (CLivraisonLotValorisation livLot in RelationsLotsValorisation)
            {
                if (livLot.LotDeValorisation != null)
                    idsLots.Add(livLot.LotDeValorisation.Id);
            }

            foreach (CLigneLivraisonEquipement ligne in Lignes)
            {
                if (ligne.Equipement != null && 
                    (ligne.Equipement.ValorisationEquipement == null ||
                    idsLots.Contains(ligne.Equipement.ValorisationEquipement.LotValorisation.Id) ))
                    //Comme ça, en cas de modif de l'ordre, on applique la bonne valorisation
                {
                    ligne.Equipement.ValorisationEquipement = GetValorisation(ligne.Equipement);
                }
            }
            return result;
        }
	







      
    }
}
