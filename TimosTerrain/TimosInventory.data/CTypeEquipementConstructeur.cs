using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.memorydb;
using System.Data;
using sc2i.common;

namespace TimosInventory.data
{
    [MemoryTable(CTypeEquipementConstructeur.c_nomTable, CTypeEquipementConstructeur.c_champId)]
    public class CTypeEquipementConstructeur : CEntiteLieeATimos
    {
        public const string c_nomTable = "TYPEEQ_MANUF";
        public const string c_champId = "TEQMAN_ID";
        public const string c_champReference = "TEQMAN_REFERENCE";

        //-----------------------------------------
        public CTypeEquipementConstructeur(CMemoryDb db)
            : base(db)
        {
        }

        //-----------------------------------------
        public CTypeEquipementConstructeur(DataRow row)
            : base(row)
        {
        }

        //-----------------------------------------
        public override void MyInitValeursParDefaut()
        {
        }

        //-----------------------------------------
        [MemoryField(c_champReference)]
        public string Reference
        {
            get
            {
                return Row.Get<string>(c_champReference);
            }
            set
            {
                Row[c_champReference] = value;
            }
        }

        //-----------------------------------------
        [MemoryParent(true)]
        public CConstructeur Constructeur
        {
            get
            {
                return GetParent<CConstructeur>();
            }
            set
            {
                SetParent<CConstructeur>(value);
            }
        }

        //-----------------------------------------
        public string Libelle
        {
            get
            {
                CConstructeur c = Constructeur;
                StringBuilder bl = new StringBuilder();
                bl.Append(Reference);
                if (c != null)
                {
                    bl.Append(' ');
                    bl.Append(c.Libelle);
                }
                return bl.ToString();
            }
        }

        //-----------------------------------------
        [MemoryParent(true)]
        public CTypeEquipement TypeEquipement
        {
            get
            {
                return GetParent<CTypeEquipement>();
            }
            set
            {
                SetParent<CTypeEquipement>(value);
            }
        }

        //-----------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-----------------------------------------
        protected override CResultAErreur MySerialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = SerializeChamp(serializer, c_champReference);
            if (result)
                result = SerializeParent<CTypeEquipement>(serializer);
            if (result)
                result = SerializeParent<CConstructeur>(serializer);

            return result;
        }
    }
}
