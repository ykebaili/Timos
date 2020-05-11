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

namespace timos.data.commandes
{
	/// <summary>
    /// Objet de relation entre <see cref="CLotValorisation">lot de valorisations</see> 
    /// et <see cref="CLivraisonEquipement">livraison</see>
	/// </summary>
    [DynamicClass("Valuation lot / Delivery")]
	[Table(CLivraisonLotValorisation.c_nomTable, CLivraisonLotValorisation.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CLivraisonLotValorisationServeur")]
	public class CLivraisonLotValorisation : CObjetDonneeAIdNumeriqueAuto
	{
		public const string c_nomTable = "DELIVERY_VALUATION_LOT";
		public const string c_champId = "DELVALOT_ID";
        public const string c_champNumero = "DELVALOT_NUM";

		/// /////////////////////////////////////////////
		public CLivraisonLotValorisation( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CLivraisonLotValorisation(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Delivery/Valuation lot|20125");
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


		

		




        //-------------------------------------------------------------------
        /// <summary>
        /// <see cref="CLivraisonEquipement">Livraison</see> liée
        /// </summary>
        [Relation(
            CLivraisonEquipement.c_nomTable,
            CLivraisonEquipement.c_champId,
            CLivraisonEquipement.c_champId,
            false,
            false,
            false)]
        [DynamicField("Delivery")]
        public CLivraisonEquipement Livraison
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
        /// <summary>
        /// <see cref="CLotValorisation">Lot de valorisations</see> lié
        /// </summary>
        [Relation(
            CLotValorisation.c_nomTable,
            CLotValorisation.c_champId,
            CLotValorisation.c_champId,
            true,
            true,
            false)]
        [DynamicField("Valuation lot")]
        public CLotValorisation LotDeValorisation
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



        //-----------------------------------------------------------
        /// <summary>
        /// Indice (rang) du lot dans la livraison (0 à n)
        /// </summary>
        [TableFieldProperty(c_champNumero)]
        [DynamicField("Indice")]
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

        protected override CResultAErreur BeforeDelete()
        {
            CResultAErreur result = CResultAErreur.True;
            CLotValorisation lot = LotDeValorisation;
            CLivraisonEquipement liv = Livraison;
            if (lot != null && liv != null)
            {
                foreach (CLigneLivraisonEquipement ligne in liv.Lignes)
                {
                    if (ligne.Equipement != null && ligne.Equipement.ValorisationEquipement != null &&
                        ligne.Equipement.ValorisationEquipement.LotValorisation == lot)
                        ligne.Equipement.ValorisationEquipement = null;
                }
            }
            return base.BeforeDelete();
        }

        
	


       

        
	}
}
