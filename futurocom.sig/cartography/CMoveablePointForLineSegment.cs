using futurocom.sig.cartography;
using sc2i.common.sig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace futurocom.sig.cartography
{
    public class CMoveablePointForLineSegment : CMoveablePoint
    {
        private CGPSLineSegment m_segment = null;
        List<IMapItem> m_listeItems = new List<IMapItem>();
        private CGPSLine m_line = null;
        public CMoveablePointForLineSegment(CMapDatabase database, CGPSLine line,  CGPSLineSegment segment)
            :base ( database, segment.PointDestination )
        {
            m_segment = segment;
            m_line = line;
            m_listeItems.AddRange(line.FindMapItems(database));

        }

        //--------------------------------------------------------------
        protected override void MyMoveTo(SLatLong point)
        {
            m_segment.PointDestination = point;
            m_line.UpdateMapItems(MapDataBase, new List<IMapItem>());
        }

        //--------------------------------------------------------------
        public override IEnumerable<IMapItem> MapItems
        {
            get { return m_listeItems.AsReadOnly(); }
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
        //Retourne la liste des items supprimés
        public override IEnumerable<IMapItem> Delete(CMapDatabase database)
        {
            if (m_line != null)
                return m_line.DetailLigne.DeleteSegment(database, m_segment);
            return new IMapItem[0];
        }
    }
}
