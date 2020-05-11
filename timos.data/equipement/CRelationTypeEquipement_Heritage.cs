using System;
using System.Data;

using sc2i.data;
using sc2i.common;

using sc2i.workflow;

namespace timos.data
{
	/// <summary>
	/// Indique qu'un type d'équipement hérite d'un autre type d'équipement
	/// L'héritage concerne
	///		-Les champs custom
	///		-Les formulaires
	///		-Les types incluables
	/// </summary>
    [DynamicClass("Equipment Type / Inheritance")]
	[Table(CRelationTypeEquipement_Heritage.c_nomTable, CRelationTypeEquipement_Heritage.c_champId, true)]
	[FullTableSync]
	[ObjetServeurURI("CRelationTypeEquipement_HeritageServeur")]
	public class CRelationTypeEquipement_Heritage : CObjetDonneeAIdNumeriqueAuto
	{
		public const string c_nomTable = "EQT_TYPE_INHERIT";

		public const string c_champId = "EQTTP_HER_ID";
		public const string c_champIdTypeParent = "EQTTP_HER_PARENT_ID";
		public const string c_champIdTypeFils = "EQTTP_HER_CHILD_ID";

		//////////////////////////////////////////////////////////////////////////
		public CRelationTypeEquipement_Heritage( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		//////////////////////////////////////////////////////////////////////////
		public CRelationTypeEquipement_Heritage(DataRow row )
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
				return I.T( "Inheritance of Equipment Type|264");
			}
		}

		//////////////////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		
		//---------------------------------------------------------------------------
        /// <summary>
        /// Type d'équipement parent
        /// </summary>
		[RelationAttribute(
			CTypeEquipement.c_nomTable, 
			CTypeEquipement.c_champId,
			CRelationTypeEquipement_Heritage.c_champIdTypeParent,
			true,
			false,
			false)]
		[DynamicField("Parent type")]
		public CTypeEquipement TypeParent
		{
			get
			{
				return (CTypeEquipement)GetParent ( c_champIdTypeParent, typeof(CTypeEquipement));
			}
			set
			{
				SetParent(c_champIdTypeParent, value);
			}
		}

		

		//----------------------------------------------------------
        /// <summary>
        /// Type d'équipement fils (héritié)
        /// </summary>
		[RelationAttribute(
			CTypeEquipement.c_nomTable, 
			CTypeEquipement.c_champId, 
			CRelationTypeEquipement_Heritage.c_champIdTypeFils, 
			true, 
			true)]
		[DynamicField("Child type")]
		public CTypeEquipement TypeFils
		{
			get
			{
				return (CTypeEquipement)GetParent(c_champIdTypeFils, typeof(CTypeEquipement));
			}
			set
			{
				SetParent(c_champIdTypeFils, value);
			}
		}
	}
}
