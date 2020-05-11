using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.memorydb;
using System.Data;
using sc2i.common;

namespace TimosInventory.data
{
    [MemoryTable(CConstructeur.c_nomTable, CConstructeur.c_champId)]
    public class CConstructeur : CEntiteLieeATimos
    {
        public const string c_nomTable = "MANUFACTURER";
        public const string c_champId = "MAN_ID";
        public const string c_champLibelle = "ST_LABEL";

        //-----------------------------------------
        public CConstructeur(CMemoryDb db)
            : base(db)
        {
        }

        //-----------------------------------------
        public CConstructeur(DataRow row)
            : base(row)
        {
        }

        //-----------------------------------------
        public override void MyInitValeursParDefaut()
        {
        }

        //-----------------------------------------
        [MemoryField(c_champLibelle)]
        public string Libelle
        {
            get
            {
                return Row.Get<string>(c_champLibelle);
            }
            set
            {
                Row[c_champLibelle] = value;
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
            SerializeChamp(serializer, c_champLibelle);
            return result;
        }
    }
}
