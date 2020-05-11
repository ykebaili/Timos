using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.memorydb;
using sc2i.common;
using System.Data;

namespace TimosInventory.data
{
    [MemoryTable(CRelationEquipementChampCustom.c_nomTable, CRelationEquipementChampCustom.c_champId)]
    public class CRelationEquipementChampCustom : CRelationElementAChamp_ChampCustom
    {
        public const string c_nomTable = "EQUIPEMENT_CUSTOM_FIELD";
        public const string c_champId = "EQT_FLT_ID";

        //---------------------------------------------------------------
        public CRelationEquipementChampCustom(CMemoryDb db)
            : base(db)
        {
        }

        //---------------------------------------------------------------
        public CRelationEquipementChampCustom(DataRow row)
            : base(row)
        {
        }

        //---------------------------------------------------------------
        [MemoryParent(true)]
        public CEquipement Equipement
        {
            get
            {
                return GetParent<CEquipement>();
            }
            set
            {
                SetParent<CEquipement>(value);
            }
        }

        //---------------------------------------------------------------
        public override IElementAChamps ElementAChamps
        {
            get
            {
                return Equipement;
            }
            set
            {
                Equipement = value as CEquipement;
            }
        }

        //---------------------------------------------------------------
        public override Type GetTypeElementAChamps()
        {
            return typeof(CEquipement);
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

            result = SerializeParent<CEquipement>(serializer);
            return result;
        }
    }
}
