using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.memorydb;
using sc2i.common;
using System.Data;

namespace TimosInventory.data.releve
{
    [MemoryTable(CRelationReleveEquipementChampCustom.c_nomTable, CRelationReleveEquipementChampCustom.c_champId)]
    public class CRelationReleveEquipementChampCustom : CRelationElementAChamp_ChampCustom
    {
        public const string c_nomTable = "EQPTSRV_CUSTOM_FIELD";
        public const string c_champId = "EQTSRV_FLT_ID";

        //---------------------------------------------------------------
        public CRelationReleveEquipementChampCustom(CMemoryDb db)
            : base(db)
        {
        }

        //---------------------------------------------------------------
        public CRelationReleveEquipementChampCustom(DataRow row)
            : base(row)
        {
        }

        //---------------------------------------------------------------
        [MemoryParent(true)]
        public CReleveEquipement ReleveEquipement
        {
            get
            {
                return GetParent<CReleveEquipement>();
            }
            set
            {
                SetParent<CReleveEquipement>(value);
            }
        }

        //---------------------------------------------------------------
        public override IElementAChamps ElementAChamps
        {
            get
            {
                return ReleveEquipement;
            }
            set
            {
                ReleveEquipement = value as CReleveEquipement;
            }
        }

        //---------------------------------------------------------------
        public override Type GetTypeElementAChamps()
        {
            return typeof(CReleveEquipement);
        }

        //---------------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //---------------------------------------------------------------
        protected override CResultAErreur MySerialize(sc2i.common.C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if ( result )
                result = base.MySerialize ( serializer );
            if (!result)
                return result;

            result = SerializeParent<CReleveEquipement>(serializer);
            return result;
        }
    }
}
