using System;
using System.Data;

using sc2i.data;
using sc2i.common;

using sc2i.workflow;

namespace timos.data
{
	/// <summary>
	/// Relation entre un <see cref="CTypeEquipement">Type d'Equipement</see> et un 
	/// <see cref="CTypeStock">Type de Stock</see>.
	/// </summary>
    [DynamicClass("Equipment type / Stock type")]
	[Table(CRelationTypeEquipement_TypeStock.c_nomTable, CRelationTypeEquipement_TypeStock.c_champId, true)]
	[FullTableSync]
	[ObjetServeurURI("CRelationTypeEquipement_TypeStockServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_Stock_ID)]
    public class CRelationTypeEquipement_TypeStock : CObjetDonneeAIdNumeriqueAuto
	{
		public const string c_nomTable = "EQT_TP_STOCK_TP";

		public const string c_champId = "TYPSTO_TYPEQT_ID";

		public const string c_champStockAlerte = "TYPSTO_TYPEQT_ALERT";
		public const string c_champStockCritique = "TYPSTO_TYPEQT_CRITICAL";
		public const string c_champStockOptimal = "TYPSTO_TYPEQT_OPTIMAL";

		//////////////////////////////////////////////////////////////////////////
		public CRelationTypeEquipement_TypeStock( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		//////////////////////////////////////////////////////////////////////////
		public CRelationTypeEquipement_TypeStock(DataRow row )
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
				return I.T( "Stock type|107") + " " + TypeStock != null ? TypeStock.Libelle : "";
			}
		}

		//////////////////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		
		//---------------------------------------------------------------------------
        /// <summary>
        /// Type d'équipement concerné par la relation
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

		

		//--------------------------------------------------------
        /// <summary>
        /// Type de stock concerné par la relation
        /// </summary>
		[RelationAttribute(
			CTypeStock.c_nomTable,
		   CTypeStock.c_champId,
		   CTypeStock.c_champId, 
			true, 
			false)]
		[DynamicField("Stock")]
		public CTypeStock TypeStock
		{
			get
			{
				return (CTypeStock)GetParent(CTypeStock.c_champId, typeof(CTypeStock));
			}
			set
			{
				SetParent(CTypeStock.c_champId, value);
			}
		}
		//---------------------------------------------------------
		/// <summary>
		/// Seuil (nombre d'élément dans le stock) à partir
		/// duquel il serait bon de recommander des équipements de ce type
		/// </summary>
		/// <remarks>
		/// Cette valeur surchage la valeur par défaut du
		/// <see cref="CTypeEquipement">type d'équipement</see>
		/// </remarks>
		[TableFieldProperty(CRelationTypeEquipement_TypeStock.c_champStockAlerte, true)]
		[DynamicField("Alert stock")]
		public int? StockAlerte
		{
			get
			{
				if (Row[c_champStockAlerte] == DBNull.Value)
					return null;
				return (int?)Row[c_champStockAlerte];
			}
			set
			{
				if ( value == null)
					Row[c_champStockAlerte] = DBNull.Value;
				else
					Row[c_champStockAlerte] = value;
			}
		}

		//---------------------------------------------------------
		/// <summary>
		/// Seuil (nombre d'élément dans le stock) à partir
		/// duquel il faut recommander en urgence des équipements de ce type
		/// </summary>
		/// <remarks>
		/// Cette valeur surchage la valeur par défaut du
		/// <see cref="CTypeEquipement">type d'équipement</see>
		/// </remarks>
		[TableFieldProperty(CRelationTypeEquipement_TypeStock.c_champStockCritique, true)]
		[DynamicField("Critical stock")]
		public int? StockCritique
		{
			get
			{
				if (Row[c_champStockCritique] == DBNull.Value)
					return null;
				return (int?)Row[c_champStockCritique];
			}
			set
			{
				if (value == null)
					Row[c_champStockCritique] = DBNull.Value;
				else
					Row[c_champStockCritique] = value;
			}
		}

		//---------------------------------------------------------
		/// <summary>
		/// En cas de commande automatique, indique combien
		/// il faut d'équipements de ce type dans le stock
		/// après la commande
		/// </summary>
		/// <remarks>
		/// Cette valeur surchage la valeur par défaut du
		/// <see cref="CTypeEquipement">type d'équipement</see>
		/// </remarks>
		[TableFieldProperty(CRelationTypeEquipement_TypeStock.c_champStockOptimal, true)]
		[DynamicField("Optimal stock")]
		public int? StockOptimal
		{
			get
			{
				if (Row[c_champStockOptimal] == DBNull.Value)
					return null;
				return (int?)Row[c_champStockOptimal];
			}
			set
			{
				if ( value == null)
					Row[c_champStockOptimal] = DBNull.Value;
				else
					Row[c_champStockOptimal] = value;
			}
		}


	}
}
