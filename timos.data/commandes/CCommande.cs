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
using System.Text;


namespace timos.data.commandes
{
	/// <summary>
	/// Permet de modéliser une commande de matériel adressée à un fournisseur.
    /// Une commande comporte des lignes de commande
    /// Une commande peut être livrée en une ou plusieurs fois
	/// </summary>
	[DynamicClass("Order")]
	[ObjetServeurURI("CCommandeServeur")]
	[Table(CCommande.c_nomTable, CCommande.c_champId, true)]
	[AutoExec("Autoexec")]
	[TiagClass(CCommande.c_nomTiag, "Id", true)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_Stock_ID)]
	public partial class CCommande : CElementAChamp,
							IElementATypeStructurant<CTypeCommande>

	{
		#region Déclaration des constantes
		public const string c_roleChampCustom = "ORDER";
		public const string c_nomTiag = "Order";

		public const string c_nomTable = "ORDERS";
		public const string c_champId = "ORD_ID";
        public const string c_champNumero = "ORD_NUMBER";
        public const string c_champDateCommande = "ORDER_CREATE_DATE";
        public const string c_champIdCreateur = "ORDER_CREATEUSER_ID";
		#endregion

		//-------------------------------------------------------------------
		public static void Autoexec()
		{
			CRoleChampCustom.RegisterRole(c_roleChampCustom, I.T("Order|20116"), typeof(CCommande), typeof(CTypeCommande));
		}

		//-------------------------------------------------------------------
		public CCommande(CContexteDonnee ctx)
			: base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CCommande(System.Data.DataRow row)
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
            DateCommande = DateTime.Now;
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
			return Libelle;
		}

        //-------------------------------------------------------------------
        public string Libelle
        {
            get
            {
                StringBuilder bl = new StringBuilder();
                if (Fournisseur != null)
                {
                    bl.Append(Fournisseur.Acteur.IdentiteComplete);
                    bl.Append(" ");
                }
                if (NumeroDeCommande != "")
                {
                    bl.Append(NumeroDeCommande);
                    bl.Append(" ");
                }
                bl.Append(DateCommande.ToShortDateString());
                return bl.ToString();
            }
        }
                


		//-------------------------------------------------------------------
		public override string DescriptionElement
		{
			get { return I.T("Order @1 to @2|20117", NumeroDeCommande, Fournisseur != null?Fournisseur.Acteur.IdentiteComplete:"?"); }
		}


       //-----------------------------------------------------------
        /// <summary>
        /// N° de la commande
        /// </summary>
        [TableFieldProperty(c_champNumero, 255)]
        [DynamicField("Order n°")]
        public string NumeroDeCommande
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
		public void TiagSetOrderTypeKeys(object[] lstCles)
		{
			CTypeCommande typeCommande = new CTypeCommande(ContexteDonnee);
			if (typeCommande.ReadIfExists(lstCles))
				TypeCommande = typeCommande;
		}

		//-------------------------------------------------------------------
		/// <summary>
        /// <see cref="CTypeCommande">Type de la commande</see>
		/// </summary>
		[Relation(
			CTypeCommande.c_nomTable,
			CTypeCommande.c_champId,
			CTypeCommande.c_champId,
			true,
			false,
			true)]
		[DynamicField("Order type")]
        [TiagRelation(typeof(CTypeCommande), "TiagSetOrderTypeKeys")]
		public CTypeCommande TypeCommande
		{
			get 
            {
                return (CTypeCommande)GetParent(CTypeCommande.c_champId, typeof(CTypeCommande)); 
            }
			set
            {
                SetParent(CTypeCommande.c_champId, value); 
            }
		}


		//----------------------------------------------------------------------------------
		/// <summary>
		/// Utilisé par TIAG pour affecter le type de site par ses clés
		/// </summary>
		/// <param name="lstCles"></param>
		public void TiagSetSupplierKeys(object[] lstCles)
		{
            CDonneesActeurFournisseur fournisseur = new CDonneesActeurFournisseur(ContexteDonnee);
            if (fournisseur.ReadIfExists(lstCles))
			{
				Fournisseur = fournisseur;
			}
		}

		//-----------------------------------------------------------------------------------
		/// <summary>
        /// <see cref="CDonneesActeurFournisseur">Fournisseur</see> auquel est destiné la commande
		/// </summary>
		[Relation(
			CDonneesActeurFournisseur.c_nomTable,
            CDonneesActeurFournisseur.c_champId,
            CDonneesActeurFournisseur.c_champId,
			false,
			false,
			true)]
		[DynamicField("Supplier")]
        [TiagRelation(typeof(CDonneesActeurFournisseur), "TiagSetSupplierKeys")]
        public CDonneesActeurFournisseur Fournisseur
		{
			get
			{
                return (CDonneesActeurFournisseur)GetParent(CDonneesActeurFournisseur.c_champId, typeof(CDonneesActeurFournisseur));
			}
			set
			{
                SetParent(CDonneesActeurFournisseur.c_champId, value);
			}
		}



        
        //-----------------------------------------------------------
        /// <summary>
        /// Date de commande
        /// </summary>
        [TableFieldProperty(c_champDateCommande)]
        [DynamicField("Order date")]
        public DateTime DateCommande
        {
            get
            {
                return (DateTime)Row[c_champDateCommande];
            }
            set
            {
                Row[c_champDateCommande] = value;
            }
        }


        //-------------------------------------------------------------------
        /// <summary>
        /// <see cref="CDonneesActeurUtilisateur">Acteur</see> ayant créé la commande
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

                if (TypeCommande != null)
                    lst.Add(TypeCommande);
				return lst.ToArray();
			}
		}

		//-------------------------------------------------------------------
		public override CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
		{
			return new CRelationCommande_ChampCustom(ContexteDonnee);
		}

		//-------------------------------------------------------------------
		[RelationFille(typeof(CRelationCommande_ChampCustom), "ElementAChamps")]
		[DynamicChilds("Custom fields relations", typeof(CRelationCommande_ChampCustom))]
		public override CListeObjetsDonnees RelationsChampsCustom
		{
			get
			{
				return GetDependancesListe(CRelationCommande_ChampCustom.c_nomTable, GetChampId());
			}
		}
        # endregion

		#region IElementATypeStructurant<CTypeCommande> Membres

		public CTypeCommande ElementStructurant
		{
			get { return TypeCommande; }
		}
		public int IdTypeStructurant
		{
			get
			{
				return (int)Row[CTypeCommande.c_champId];
			}
		}
		#endregion


        //---------------------------------------------
        /// <summary>
        /// La liste des <see cref="CLigneCommande">lignes</see> de la commande
        /// </summary>
        [RelationFille(typeof(CLigneCommande), "Commande")]
        [DynamicChilds("Order lines", typeof(CLigneCommande))]
        public CListeObjetsDonnees Lignes
        {
            get
            {
                return GetDependancesListe(CLigneCommande.c_nomTable, c_champId);
            }
        }


        //---------------------------------------------
        /// <summary>
        /// La liste des<see cref="CLivraisonEquipement">livraisons</see>concernant la commande
        /// </summary>
        [RelationFille(typeof(CLivraisonEquipement), "Commande")]
        [DynamicChilds("Deliveries", typeof(CLivraisonEquipement))]
        public CListeObjetsDonnees Livraisons
        {
            get
            {
                return GetDependancesListe(CLivraisonEquipement.c_nomTable, c_champId);
            }
        }



        



      
    }
}
