using System;
using System.Data;

using sc2i.data;
using sc2i.common;

using sc2i.workflow;
using tiag.client;

namespace timos.data
{
	/// <summary>
    /// Indique les <see cref="CTypeEquipement">types d'équipements</see> pouvant être inclus dans un type d'équipement
	/// </summary>
    [DynamicClass("Equipment type / Included equipement type")]
	[Table(CRelationTypeEquipement_TypesIncluables.c_nomTable, CRelationTypeEquipement_TypesIncluables.c_champId, true)]
	[FullTableSync]
	[ObjetServeurURI("CRelationTypeEquipement_TypesIncluablesServeur")]
	[TiagClass(CRelationTypeEquipement_TypesIncluables.c_nomTiag, "Id", true)]
	public class CRelationTypeEquipement_TypesIncluables : CObjetDonneeAIdNumeriqueAuto, IElementAInterfaceTiag
	{
		public const string c_nomTiag = "Equipment type/Can include";
		public const string c_nomTable = "EQUIPMENT_TYPE_INCLUSION";

		public const string c_champId = "EQTTP_INC_ID";
		public const string c_champIdTypeIncluant = "EQTTP_INC_ID_INCLUING";
		public const string c_champIdTypeInclu = "EQTTP_INC_ID_INCLUDED";

		//////////////////////////////////////////////////////////////////////////
		public CRelationTypeEquipement_TypesIncluables( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		//////////////////////////////////////////////////////////////////////////
		public CRelationTypeEquipement_TypesIncluables(DataRow row )
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
				return I.T("Inclusion of Equipment Type|265");
			}
		}

		//////////////////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		//---------------------------------------------------------------------------
		public void TiagSetIncludingTypeKeys ( object[] lstCles )
		{
			CTypeEquipement tp = new CTypeEquipement ( ContexteDonnee );
			if ( tp.ReadIfExists ( lstCles ) )
				TypeIncluant = tp;
		}
		
		//---------------------------------------------------------------------------
        /// <summary>
        /// Type d'équipement pouvant en inclure d'autres (incluant)
        /// </summary>
		[RelationAttribute(
			CTypeEquipement.c_nomTable, 
			CTypeEquipement.c_champId,
			CRelationTypeEquipement_TypesIncluables.c_champIdTypeIncluant,
			true,
			false,
			false)]
		[DynamicField("Including type")]
		[TiagRelation ( typeof ( CTypeEquipement ), "TiagSetIncludingTypeKeys")]
		public CTypeEquipement TypeIncluant
		{
			get
			{
				return (CTypeEquipement)GetParent ( c_champIdTypeIncluant, typeof(CTypeEquipement));
			}
			set
			{
				SetParent(c_champIdTypeIncluant, value);
			}
		}

		
		//---------------------------------------------------------------------------
		public void TiagSetIncludedTypeKeys ( object[] lstCles )
		{
			CTypeEquipement tp = new CTypeEquipement ( ContexteDonnee );
			if ( tp.ReadIfExists ( lstCles ) )
				TypeInclu = tp;
		}
		//-----------------------------------------------------
        /// <summary>
        /// Type d'équipement inclus
        /// </summary>
		[RelationAttribute(
			CTypeEquipement.c_nomTable, 
			CTypeEquipement.c_champId, 
			CRelationTypeEquipement_TypesIncluables.c_champIdTypeInclu, 
			true, 
			true)]
		[DynamicField("Included type")]
		[TiagRelation ( typeof(CTypeEquipement), "TiagSetIncludedTypeKeys")]
		public CTypeEquipement TypeInclu
		{
			get
			{
				return (CTypeEquipement)GetParent(c_champIdTypeInclu, typeof(CTypeEquipement));
			}
			set
			{
				SetParent(c_champIdTypeInclu, value);
			}
		}
	
		#region IElementAInterfaceTiag Membres

		public object[]  TiagKeys
		{
			get { return new object[]{Id}; }
		}

		public string  TiagType
		{
			get { return c_nomTiag; }
		}

		#endregion
	}
}
