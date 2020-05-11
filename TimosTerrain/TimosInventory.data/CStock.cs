using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.memorydb;
using System.Data;
using sc2i.common;

namespace TimosInventory.data
{
    [MemoryTable(CStock.c_nomTable, CStock.c_champId)]
    public class CStock : CEntiteLieeATimos
    {
        public const string c_nomTable = "STOCK";
        public const string c_champId = "STCK_ID";
        public const string c_champLibelle = "STCK_LABEL";

        //-----------------------------------------
        public CStock(CMemoryDb db)
            : base(db)
        {
        }

        //-----------------------------------------
        public CStock(DataRow row)
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
        [MemoryParent(true)]
        public CSite SiteContenant
        {
            get
            {
                return GetParent<CSite>();
            }
            set
            {
                SetParent<CSite>(value);
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
            //SerializeChilds<CSite>(serializer);
            return result;
        }
    }
}
