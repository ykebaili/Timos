using futurocom.sig.cartography;
using sc2i.common.sig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace futurocom.sig.cartography
{
    public class CMoveablePointForLineStart : CMoveablePoint
    {
        private CGPSLine m_line = null;

        private IMapItem m_mapItem = null;

        public CMoveablePointForLineStart(CMapDatabase database, CGPSLine line )
            :base ( database, line.DetailLigne.PointDepart )
        {
            m_line = line;
            IEnumerable<IMapItem> items = line.FindMapItems(database);
            if (items.Count() > 0)
                m_mapItem = items.ElementAt(0);
        }

        //--------------------------------------------------------------
        protected override void MyMoveTo(SLatLong point)
        {
            m_line.DetailLigne.PointDepart = point;
            m_line.UpdateMapItems(MapDataBase, new List<IMapItem>());
        }

        //--------------------------------------------------------------
        public override IEnumerable<IMapItem> MapItems
        {
            get
            {
                if (m_mapItem != null)
                    return new IMapItem[] { m_mapItem };
                return null;
            }
        }

        //--------------------------------------------------------------
        public override bool IsDeletable
        {
            get
            {
                return true;
            }
        }

        //--------------------------------------------------------------
        public override IEnumerable<IMapItem> Delete( CMapDatabase database )
        {
            if (m_line != null)
               return  m_line.DetailLigne.DeleteStartPoint( database );
            return new IMapItem[0];
        }
    }
}
