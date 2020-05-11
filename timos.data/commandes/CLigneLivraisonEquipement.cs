using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

using tiag.client;

using timos.data;

namespace timos.data.commandes
{
	/// <summary>
    /// Une ligne de livraison dans la <see cref="CLivraisonEquipement">livraison</see> d'une <see cref="CCommande">commande</see>
	/// </summary>
    [DynamicClass("Delivery line")]
	[Table(CLigneLivraisonEquipement.c_nomTable, CLigneLivraisonEquipement.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CLigneLivraisonEquipementServeur")]
	[TiagClass(CLigneLivraisonEquipement.c_nomTiag, "Id", true)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_Stock_ID)]
	public class CLigneLivraisonEquipement : CObjetDonneeAIdNumeriqueAuto,
		IElementAInterfaceTiag
	{
		public const string c_nomTiag = "Delivery line";
		public const string c_nomTable = "DELIVERY_LINE";
		public const string c_champId = "DELLIV_ID";
        public const string c_champNumero = "DELLI_NUM";

		/// /////////////////////////////////////////////
		public CLigneLivraisonEquipement( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CLigneLivraisonEquipement(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Delivery line|20122");
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champNumero};
		}


       


        //-----------------------------------------------------------
        /// <summary>
        /// N° de la ligne de livraison à l'intérieur de la livraison
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
        //-------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstCles"></param>
        public void TiagSetDeliveryKeys(object[] lstCles)
        {
            CLivraisonEquipement livraisonEquipement = new CLivraisonEquipement(ContexteDonnee);
            if (LivraisonEquipement.ReadIfExists(lstCles))
                LivraisonEquipement = livraisonEquipement;
        }
        //-------------------------------------------------------------------
        /// <summary>
        /// Relation vers <see cref="CLivraisonEquipement">la livraison parente</see> à laquelle la ligne de livraison appartient
        /// </summary>
        [Relation(
            CLivraisonEquipement.c_nomTable,
            CLivraisonEquipement.c_champId,
            CLivraisonEquipement.c_champId,
            true,
            true,
            false)]
        [DynamicField("Delivery")]
        [TiagRelation(typeof(CLivraisonEquipement), "TiagSetDeliveryKeys")]
        public CLivraisonEquipement LivraisonEquipement
        {
            get
            {
                return (CLivraisonEquipement)GetParent(CLivraisonEquipement.c_champId, typeof(CLivraisonEquipement));
            }
            set
            {
                SetParent(CLivraisonEquipement.c_champId, value);
            }
        }

        //-------------------------------------------------------------------

        //-------------------------------------------------------------------
        /// <summary>
        /// <see cref="CLigneCommande">Ligne de commande</see> correspondant à la ligne de livraison
        /// </summary>
        [Relation(
            CLigneCommande.c_nomTable,
            CLigneCommande.c_champId,
            CLigneCommande.c_champId,
            false,
            false,
            false)]
        [DynamicField("Associated order line")]
        public CLigneCommande LigneDeCommandeAssociee
        {
            get
            {
                return (CLigneCommande)GetParent(CLigneCommande.c_champId, typeof(CLigneCommande));
            }
            set
            {
                SetParent(CLigneCommande.c_champId, value);
            }
        }

	


        //-------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstCles"></param>
        public void TiagSetEquipmentKeys(object[] lstCles)
        {
            CEquipement equipement = new CEquipement(ContexteDonnee);
            if (equipement.ReadIfExists(lstCles))
                Equipement = equipement;
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// <see cref="CEquipement">Equipement</see> livré
        /// </summary>
        [Relation(
            CEquipement.c_nomTable,
            CEquipement.c_champId,
            CEquipement.c_champId,
            true,
            false,
            false)]
        [DynamicField("Equipment")]
        [TiagRelation(typeof(CEquipement), "TiagSetEquipmentKeys")]
        public CEquipement Equipement
        {
            get
            {
                return (CEquipement)GetParent(CEquipement.c_champId, typeof(CEquipement));
            }
            set
            {
                SetParent(CEquipement.c_champId, value);
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


	}
}
