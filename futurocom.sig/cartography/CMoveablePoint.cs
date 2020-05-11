using sc2i.common.sig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace futurocom.sig.cartography
{
    public abstract class CMoveablePoint
    {
        private SLatLong m_point;

        private CMapItemImage m_itemSurMap = null;
        private CMapDatabase m_database;

        //-------------------------------------------------
        public CMoveablePoint(CMapDatabase database)
        {
            m_database = database;
        }

        //-------------------------------------------------
        public CMapDatabase MapDataBase
        {
            get
            {
                return m_database;
            }
        }

        //-------------------------------------------------
        public virtual bool IsDeletable
        {
            get
            {
                return false;
            }
        }

        //-------------------------------------------------
        public virtual IEnumerable<IMapItem> Delete(CMapDatabase database)
        {
            return new IMapItem[0];
        }

        //-------------------------------------------------
        public CMapItemImage ItemSurMap
        {
            get
            {
                return m_itemSurMap;
            }
            set
            {
                m_itemSurMap = value;
            }
        }

        //-------------------------------------------------
        public CMoveablePoint(CMapDatabase database, SLatLong latLong )
            :this(database)
        {
            m_point = latLong;
        }

        //-------------------------------------------------
        public SLatLong Point
        {
            get
            {
                return m_point;
            }
            set
            {
                m_point = value;
            }
        }

        //-------------------------------------------------
        public void MoveTo(SLatLong point)
        {
            if (ItemSurMap != null)
            {
                ItemSurMap.Latitude = point.Latitude;
                ItemSurMap.Longitude = point.Longitude;
            }
            MyMoveTo(point);
        }

        //-------------------------------------------------
        protected abstract void MyMoveTo(SLatLong point);

        //-------------------------------------------------
        public abstract IEnumerable<IMapItem> MapItems { get; }
    }
}
