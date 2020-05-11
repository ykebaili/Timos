using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.memorydb;
using System.Data;

namespace TimosInventory.data
{
    public abstract class CEntiteLieeATimos : CEntiteDeMemoryDbAIdAuto
    {
        public const string c_champIdTimos = "TIMOS_ID";
        //-----------------------------------------
        public CEntiteLieeATimos(CMemoryDb db)
            : base(db)
        {
        }

        //-----------------------------------------
        public CEntiteLieeATimos(DataRow row)
            : base(row)
        {
        }

        //-----------------------------------------
        public void CreateNew(int nIdTimos)
        {
            base.CreateNew(nIdTimos.ToString());
            IdTimos = nIdTimos;
        }

        //-----------------------------------------
        [MemoryField(c_champIdTimos)]
        public int? IdTimos
        {
            get
            {
                return Row.Get<int?>(c_champIdTimos);
            }
            set
            {
                Row[c_champIdTimos] = value;
            }
        }

        //-----------------------------------------
        public bool ReadIfExistsIdTimos(int nIdTimos)
        {
            return ReadIfExist(new CFiltreMemoryDb(c_champIdTimos+"="+nIdTimos));
        }

    }
}
