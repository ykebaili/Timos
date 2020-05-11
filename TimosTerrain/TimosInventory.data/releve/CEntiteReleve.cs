using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.memorydb;
using System.Data;

namespace TimosInventory.data.releve
{
    public abstract class CEntiteReleve : CEntiteDeMemoryDbAIdAuto
    {
        //---------------------------------------------
        public CEntiteReleve ( CMemoryDb db )
            : base(db)
        {
        }

        //---------------------------------------------
        public CEntiteReleve(DataRow row)
            : base(row)
        {
        }

        //---------------------------------------------
        public T GetEntiteTimos<T>(string strId)
            where T : CEntiteLieeATimos
        {
            CReleveDb db = Database as CReleveDb;
            if (db != null && strId != null)
                return db.GetEntiteTimos<T>(strId);
            return default(T);
        }

    }
}
