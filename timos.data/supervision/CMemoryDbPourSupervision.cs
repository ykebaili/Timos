using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.memorydb;
using sc2i.data;

namespace timos.data.supervision
{
    public static class CMemoryDbPourSupervision
    {
        public static CMemoryDb GetMemoryDb(CContexteDonnee ctx)
        {
            CMemoryDb db = new CMemoryDb();
            db.AddFournisseurElementsManquants(new CBaseTypeAlarmeFromBDD(ctx, db));
            return db;
        }

    }
}
