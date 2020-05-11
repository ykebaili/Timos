using System;
using System.Data;

using sc2i.common;

using sc2i.common.memorydb;

namespace TimosInventory.data
{
	/// <summary>
	/// Indique qu'un type d'équipement hérite d'un autre type d'équipement
	/// L'héritage concerne
	///		-Les champs custom
	///		-Les formulaires
	///		-Les types incluables
	/// </summary>
	[MemoryTable(CRelationTypeEquipement_Heritage.c_nomTable, CRelationTypeEquipement_Heritage.c_champId)]
	public class CRelationTypeEquipement_Heritage : CEntiteLieeATimos
	{
		public const string c_nomTable = "EQT_TYPE_INHERIT";

		public const string c_champId = "EQTTP_HER_ID";
		public const string c_champIdTypeParent = "EQTTP_HER_PARENT_ID";
		public const string c_champIdTypeFils = "EQTTP_HER_CHILD_ID";

		//////////////////////////////////////////////////////////////////////////
		public CRelationTypeEquipement_Heritage( CMemoryDb db)
			:base(db)
		{
		}

		//////////////////////////////////////////////////////////////////////////
		public CRelationTypeEquipement_Heritage(DataRow row )
			:base(row)
		{
		}

		

		//////////////////////////////////////////////////////////////////////////
		public override void  MyInitValeursParDefaut()
		{
		}

		
		//---------------------------------------------------------------------------
        /// <summary>
        /// Type d'équipement parent
        /// </summary>
		[MemoryParent(c_champIdTypeParent, true )]
		public CTypeEquipement TypeParent
		{
			get
			{
                return GetParent<CTypeEquipement>(c_champIdTypeParent);
			}
			set
			{
                SetParent(value, c_champIdTypeParent);
			}
		}

		

		//----------------------------------------------------------
        /// <summary>
        /// Type d'équipement fils (héritié)
        /// </summary>
        [MemoryParent(c_champIdTypeFils, true)]
		public CTypeEquipement TypeFils
		{
            get
            {
                return GetParent<CTypeEquipement>(c_champIdTypeFils);
            }
            set
            {
                SetParent(value, c_champIdTypeFils);
            }
		}


        //----------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //----------------------------------------------------------
        protected override CResultAErreur MySerialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            SerializeParent<CTypeEquipement>(serializer, c_champIdTypeParent);
            SerializeParent <CTypeEquipement>(serializer, c_champIdTypeFils);
            return result;
        }
	}
}
