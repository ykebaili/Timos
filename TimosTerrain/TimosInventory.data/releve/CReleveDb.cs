using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.memorydb;

namespace TimosInventory.data.releve
{
    public class CReleveDb : CMemoryDb
    {
        /// <summary>
        /// Base de données contenant les éléments Timos
        /// </summary>
        private CMemoryDb m_timosDb = null;

        //-------------------------------------------
        public CReleveDb()
            : base()
        {
        }

        //-------------------------------------------
        public CReleveDb(CMemoryDb timosDb)
        {
            m_timosDb = timosDb;
        }

        //-------------------------------------------
        public CMemoryDb TimosDb
        {
            get
            {
                return m_timosDb;
            }
            set
            {
                m_timosDb = value;
            }
        }

        //-------------------------------------------
        public T GetEntiteTimos<T>(string strId)
            where T : CEntiteLieeATimos
        {
            if (m_timosDb == null)
                return null;
            return m_timosDb.GetEntite<T>(strId);
        }

    }
}
