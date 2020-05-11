using sc2i.common.sig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace futurocom.sig.cartography
{
    public class CMoveablePointForGPSPoint : CMoveablePoint
    {
        private CGPSPoint m_gpsPoint = null;
        IMapItem m_mapItem = null;
        public CMoveablePointForGPSPoint ( CMapDatabase database, CGPSPoint pt )
            :base ( database, new SLatLong(pt.Latitude, pt.Longitude))
        {
            m_gpsPoint = pt;
            foreach (IMapItem item in pt.FindMapItems(database))
                m_mapItem = item;
        }


        protected override void MyMoveTo(SLatLong point)
        {
            m_gpsPoint.Latitude = point.Latitude;
            m_gpsPoint.Longitude = point.Longitude;
            m_gpsPoint.UpdateMapItems(MapDataBase, new List<IMapItem>());
            Point = point;

        }

        public override IEnumerable<IMapItem> MapItems
        {
            get
            {
                if (m_mapItem != null)
                    return new IMapItem[] { m_mapItem };
                return new IMapItem[0];
            }
        }
    }
}
