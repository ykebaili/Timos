using System;
using System.Data;

using sc2i.data;
using sc2i.common;

using sc2i.workflow;
using tiag.client;

namespace timos.data
{
	/// <summary>
	/// Indique les types de d'équipements logiques pouvant être inclus dans un type de d'équipement logique
	/// </summary>
	[Table(CRelationTypeEquipementLogique_TypesIncluables.c_nomTable, CRelationTypeEquipementLogique_TypesIncluables.c_champId, true)]
	[FullTableSync]
	[ObjetServeurURI("CRelationTypeEquipementLogique_TypesIncluablesServeur")]
	[TiagClass(CRelationTypeEquipementLogique_TypesIncluables.c_nomTiag, "Id", true)]
	public class CRelationTypeEquipementLogique_TypesIncluables : CObjetDonneeAIdNumeriqueAuto, IElementAInterfaceTiag
	{
		public const string c_nomTiag = "Logical Equipment type/Can include";
		public const string c_nomTable = "EQUIPMENT_LGC_TYPE_INCL";

		public const string c_champId = "EQTLGTP_INC_ID";
		public const string c_champIdTypeIncluant = "EQTLGTP_INC_INCLUING";
		public const string c_champIdTypeInclu = "EQTLGTP_INC_INCLUDED";

		//////////////////////////////////////////////////////////////////////////
		public CRelationTypeEquipementLogique_TypesIncluables( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		//////////////////////////////////////////////////////////////////////////
		public CRelationTypeEquipementLogique_TypesIncluables(DataRow row )
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
				return I.T("Inclusion of Equipment function Type|20020");
			}
		}

		//////////////////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		//---------------------------------------------------------------------------
		public void TiagSetIncludingTypeKeys ( object[] lstCles )
		{
			CTypeEquipementLogique tp = new CTypeEquipementLogique ( ContexteDonnee );
			if ( tp.ReadIfExists ( lstCles ) )
				TypeIncluant = tp;
		}
		
		//---------------------------------------------------------------------------
		[RelationAttribute(
			CTypeEquipementLogique.c_nomTable, 
			CTypeEquipementLogique.c_champId,
			CRelationTypeEquipementLogique_TypesIncluables.c_champIdTypeIncluant,
			true,
			false,
			false)]
		[DynamicField("Including type")]
		[TiagRelation ( typeof ( CTypeEquipementLogique ), "TiagSetIncludingTypeKeys")]
		public CTypeEquipementLogique TypeIncluant
		{
			get
			{
				return (CTypeEquipementLogique)GetParent ( c_champIdTypeIncluant, typeof(CTypeEquipementLogique));
			}
			set
			{
				SetParent(c_champIdTypeIncluant, value);
			}
		}

		
		//---------------------------------------------------------------------------
		public void TiagSetIncludedTypeKeys ( object[] lstCles )
		{
			CTypeEquipementLogique tp = new CTypeEquipementLogique ( ContexteDonnee );
			if ( tp.ReadIfExists ( lstCles ) )
				TypeInclu = tp;
		}
		//////////////////////////////////////////////////////////////////////////
		[RelationAttribute(
			CTypeEquipementLogique.c_nomTable, 
			CTypeEquipementLogique.c_champId, 
			CRelationTypeEquipementLogique_TypesIncluables.c_champIdTypeInclu, 
			true, 
			true)]
		[DynamicField("Included type")]
		[TiagRelation ( typeof(CTypeEquipementLogique), "TiagSetIncludedTypeKeys")]
		public CTypeEquipementLogique TypeInclu
		{
			get
			{
				return (CTypeEquipementLogique)GetParent(c_champIdTypeInclu, typeof(CTypeEquipementLogique));
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
