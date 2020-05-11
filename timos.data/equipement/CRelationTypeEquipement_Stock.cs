using System;
using System.Data;

using sc2i.data;
using sc2i.common;

using sc2i.workflow;

namespace timos.data
{
	/// <summary>
	/// Relation entre un <see cref="CTypeEquipement">Type d'Equipement</see> et un 
	/// <see cref="CStock">Stock</see>.
	/// </summary>
    [DynamicClass("Equipment type / stock")]
    [Table(CRelationTypeEquipement_Stock.c_nomTable, CRelationTypeEquipement_Stock.c_champId, true)]
	[FullTableSync]
	[ObjetServeurURI("CRelationTypeEquipement_StockServeur")]
    [Evenement(
        CRelationTypeEquipement_Stock.c_champEventStockAlerte,
        "Stock Alerte",
        "Le nombre d'�quipements a atteint le seuil d'alerte dans le stock")]
    [Evenement(
        CRelationTypeEquipement_Stock.c_champEventStockCritique,
        "Stock Critique",
        "Le nombre d'�quipements a atteint le seuil critique dans le stock")]

    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_Stock_ID)]
    public class CRelationTypeEquipement_Stock : CObjetDonneeAIdNumeriqueAuto
	{
		public const string c_nomTable = "EQPT_TYPE_STOCK";

		public const string c_champId = "EQPTP_STOCK_ID";

		public const string c_champStockAlerte = "EQPTP_STO_ALERT";
		public const string c_champStockCritique = "EQPTP_STO_CRITICAL";
		public const string c_champStockOptimal = "EQPTP_STO_OPTIMAL";
        public const string c_champNombreEnStock = "EQPTP_STO_NB";
        
        public const string c_champEventStockAlerte = "STOCK_ALERT";
        public const string c_champEventStockCritique = "STOCK_CRITICAL";

		//////////////////////////////////////////////////////////////////////////
		public CRelationTypeEquipement_Stock( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		//////////////////////////////////////////////////////////////////////////
		public CRelationTypeEquipement_Stock(DataRow row )
			:base(row)
		{
		}

		//////////////////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champId};
		}

		//////////////////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Stock @1|105") + " " + Stock != null ? Stock.Libelle : "";
			}
		}

		//////////////////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            // set par d�faut
            Row[c_champNombreEnStock] = 0;
		}

		
		//---------------------------------------------------------------------------
        /// <summary>
        /// Type d'�quipement concern� par la relation
        /// </summary>
		[RelationAttribute(
			CTypeEquipement.c_nomTable, 
			CTypeEquipement.c_champId,
		    CTypeEquipement.c_champId,
			true,
			true,
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

		

		//-----------------------------------------------------------
        /// <summary>
        /// Stock concern� par la relation
        /// </summary>
		[RelationAttribute(
			CStock.c_nomTable,
		    CStock.c_champId,
		    CStock.c_champId, 
			true, 
			false)]
		[DynamicField("Stock")]
		public CStock Stock
		{
			get
			{
				return (CStock)GetParent(CStock.c_champId, typeof(CStock));
			}
			set
			{
				SetParent(CStock.c_champId, value);
			}
		}
		//---------------------------------------------------------
		/// <summary>
		/// Seuil (nombre d'�l�ment dans le stock) � partir
		/// duquel il serait bon de recommander des �quipements de ce type
		/// </summary>
		/// <remarks>
		/// Cette valeur surchage la valeur par d�faut du
		/// <see cref="CTypeEquipement">type d'�quipement</see>
		/// </remarks>
		[TableFieldProperty(CRelationTypeEquipement_Stock.c_champStockAlerte, true)]
		[DynamicField("Alert stock")]
		public int? StockAlerte
		{
			get
			{
				return (int?)Row[c_champStockAlerte, true];
			}
			set
			{
				Row[c_champStockAlerte, true] = value;
			}
		}
        
        //-----------------------------------------------------------------------------------------
        /// <summary>
        /// Seuil d'alerte appliqu�
        /// </summary>
        /// <remarks>
        /// Il s'agit, par ordre de priorit�: du seuil d'alerte d�fini au niveau du stock s'il existe ou
        /// du seuil d'alerte d�fini au niveau du type de stock s'il existe ou
        /// du seuil d'alerte d�fini au niveau du type d'�quipement (par d�faut)
        /// </remarks>
        [DynamicField("Alert stock applied")]
        public int StockAlerteApplique
        {
            get
            {
                if (StockAlerte != null)
                    return (int)StockAlerte;

                if (Stock.TypeStock != null)
                {
                    CRelationTypeEquipement_TypeStock rel = Stock.TypeStock.GetRelationTypeEquipemetStock(TypeEquipement);
                    if (rel.StockAlerte != null)
                        return (int)rel.StockAlerte;
                }
                return TypeEquipement.StockAlerte;
            }
        }



		//---------------------------------------------------------
		/// <summary>
		/// Seuil (nombre d'�l�ment dans le stock) � partir
		/// duquel il faut recommander en urgence des �quipements de ce type
		/// </summary>
		/// <remarks>
		/// Cette valeur surchage la valeur par d�faut du
		/// <see cref="CTypeEquipement">type d'�quipement</see>
		/// </remarks>
		[TableFieldProperty(CRelationTypeEquipement_Stock.c_champStockCritique, true)]
		[DynamicField("Critical stock")]
		public int? StockCritique
		{
			get
			{
				return (int?)Row[c_champStockCritique, true];
			}
			set
			{
			    Row[c_champStockCritique, true] = value;
			}
		}
        //-----------------------------------------------------------------------------------------
        /// <summary>
        /// Seuil critique appliqu�
        /// </summary>
        /// <remarks>
        /// Il s'agit, par ordre de priorit�: du seuil critique d�fini au niveau du stock s'il existe ou
        /// du seuil critique d�fini au niveau du type de stock s'il existe ou
        /// du seuil critique d�fini au niveau du type d'�quipement (par d�faut)
        /// </remarks>
        [DynamicField("Critical stock applied")]
        public int StockCritiqueApplique
        {
            get
            {
                if (StockCritique != null)
                    return (int)StockCritique;

                if (Stock.TypeStock != null)
                {
                    CRelationTypeEquipement_TypeStock rel = Stock.TypeStock.GetRelationTypeEquipemetStock(TypeEquipement);
                    if (rel.StockCritique != null)
                        return (int)rel.StockCritique;
                }
                return TypeEquipement.StockCritique;
            }
        }

		//---------------------------------------------------------
		/// <summary>
		/// En cas de commande automatique, indique combien
		/// il faut d'�quipements de ce type dans le stock
		/// apr�s la commande
		/// </summary>
		/// <remarks>
		/// Cette valeur surchage la valeur par d�faut du
		/// <see cref="CTypeEquipement">type d'�quipement</see>
		/// </remarks>
		[TableFieldProperty(CRelationTypeEquipement_Stock.c_champStockOptimal, true)]
		[DynamicField("Optimal stock")]
		public int? StockOptimal
		{
			get
			{
				return (int?)Row[c_champStockOptimal, true];
			}
			set
			{
				Row[c_champStockOptimal, true] = value;
			}
		}
        //-----------------------------------------------------------------------------------------
        /// <summary>
        /// Stock optimal appliqu�
        /// </summary>
        /// <remarks>
        /// Il s'agit, par ordre de priorit�: du stock optimal d�fini au niveau du stock s'il existe ou
        /// du stock optimal d�fini au niveau du type de stock s'il existe ou
        /// du stock optimal d�fini au niveau du type d'�quipement (par d�faut)
        /// </remarks>
        [DynamicField("Optimal stock applied")]
        public int StockOptimalApplique
        {
            get
            {
                if (StockOptimal != null)
                    return (int)StockOptimal;

                if (Stock.TypeStock != null)
                {
                    CRelationTypeEquipement_TypeStock rel = Stock.TypeStock.GetRelationTypeEquipemetStock(TypeEquipement);
                    if (rel.StockOptimal != null)
                        return (int)rel.StockOptimal;
                }
                return TypeEquipement.StockOptimal;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Retourne le nombre d'�quipements du Type d'Equipement pr�sents dans le Stock
        /// </summary>
        [TableFieldProperty(c_champNombreEnStock)]
        [DynamicField("Number in stock")]
        public int NombreEnStock
        {
            get
            {
                return (int)Row[c_champNombreEnStock];
            }
        }

	}
}
