using System;
using System.Data;

using sc2i.data;
using sc2i.common;

using sc2i.workflow;

namespace timos.data
{
	/// <summary>
    /// Indique les <see cref="CTypeEquipement">types d'équipements</see> 
    /// pouvant être Remplacés par un autre <see cref="CTypeEquipement">type d'équipement</see> équivalent
	/// </summary>
    [DynamicClass("Equipment type / Equivalent equipment type")]
	[Table(CRelationTypeEquipement_TypeRemplacement.c_nomTable, CRelationTypeEquipement_TypeRemplacement.c_champId, true)]
	[FullTableSync]
	[ObjetServeurURI("CRelationTypeEquipement_TypeRemplacementServeur")]
    [Unique(false, 
        "Another association already exist for the relation Replacable Type/Subtitut Type|149",
        CRelationTypeEquipement_TypeRemplacement.c_champIdTypeRemplacable,
        CRelationTypeEquipement_TypeRemplacement.c_champIdTypeRemplacant)]
	public class CRelationTypeEquipement_TypeRemplacement : CObjetDonneeAIdNumeriqueAuto
	{
		public const string c_nomTable = "EQPT_TYPE_REPLACEMENT_TP";
		public const string c_champId = "EQTTP_RPLT_ID";

        public const string c_champIdTypeRemplacable = "EQTTP_RPLT_RPLCABLE_ID";
        public const string c_champIdTypeRemplacant = "EQTTP_RPLT_RPLCANT_ID";

		public const string c_champBijective = "EQTTP_RPLT_BIJECTIVE";

		//////////////////////////////////////////////////////////////////////////
		public CRelationTypeEquipement_TypeRemplacement( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		//////////////////////////////////////////////////////////////////////////
		public CRelationTypeEquipement_TypeRemplacement(DataRow row )
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
                return I.T( "Spare Equipment Type |120") + " " + TypeRemplacant != null ? TypeRemplacant.Libelle : "";
			}
		}

		//////////////////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		
		//---------------------------------------------------------------------------
        /// <summary>
        /// Indique le Type d'Equipement remplaçable
        /// </summary>
        [RelationAttribute(
			CTypeEquipement.c_nomTable, 
			CTypeEquipement.c_champId,
		    CRelationTypeEquipement_TypeRemplacement.c_champIdTypeRemplacable,
			true,
			true)]
		[DynamicField("Replaceable equipment type")]
		public CTypeEquipement TypeRemplacable
		{
			get
			{
                return (CTypeEquipement)GetParent(c_champIdTypeRemplacable, typeof(CTypeEquipement));
			}
			set
			{
                SetParent(c_champIdTypeRemplacable, value);
			}
		}



        //---------------------------------------------------------------------------
        /// <summary>
        /// Indique le Type d'Equipement remplaçant
        /// </summary>
        [RelationAttribute(
            CTypeEquipement.c_nomTable,
            CTypeEquipement.c_champId,
            CRelationTypeEquipement_TypeRemplacement.c_champIdTypeRemplacant, 
			true, 
			true)]
		[DynamicField("Substitute equipment type")]
        public CTypeEquipement TypeRemplacant
		{
			get
			{
                return (CTypeEquipement)GetParent(c_champIdTypeRemplacant, typeof(CTypeEquipement));
			}
			set
			{
                SetParent(c_champIdTypeRemplacant, value);
			}
		}
		//---------------------------------------------------------
		/// <summary>
		/// Booléen précisant si la relation de remplacement est bijective
		/// </summary>
        [TableFieldProperty(CRelationTypeEquipement_TypeRemplacement.c_champBijective)]
		[DynamicField("Bijective relation")]
		public bool Bijective
		{
			get
			{
				return (bool)Row[c_champBijective];
			}
			set
			{
                Row[c_champBijective] = value;
			}
		}

        
         



	}
}
