using sc2i.common;
using sc2i.common.sig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace futurocom.sig.cartography
{
    public class CGPSLineTrace : I2iSerializable
    {
        private SLatLong m_pointDepart = new SLatLong(0, 0);
        private List<CGPSLineSegment> m_listeSegments = new List<CGPSLineSegment>();


        //-------------------------------------------------
        public CGPSLineTrace()
        {
        }

        

        //-------------------------------------------------
        public SLatLong PointDepart
        {
            get
            {
                return m_pointDepart;
            }
            set
            {
                m_pointDepart = value;
            }
        }

        //-------------------------------------------------
        public SLatLong PointArrivee
        {
            get
            {
                if (m_listeSegments.Count() > 0)
                    return m_listeSegments[m_listeSegments.Count() - 1].PointDestination;
                return PointDepart;
            }
        }

        //-------------------------------------------------
        public IEnumerable<CGPSLineSegment> Segments
        {
            get
            {
                return m_listeSegments.AsReadOnly();
            }
            set
            {
                m_listeSegments.Clear();
                if (value != null)
                    m_listeSegments.AddRange(value);
            }
        }

        //-------------------------------------------------
        public void AddSegment ( CGPSLineSegment segment )
        {
            m_listeSegments.Add(segment);
        }

        //-------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            double fVal = m_pointDepart.Latitude;
            serializer.TraiteDouble(ref fVal);
            m_pointDepart.Latitude = fVal;
            fVal = m_pointDepart.Longitude;
            serializer.TraiteDouble(ref fVal);
            m_pointDepart.Longitude = fVal;

            result = serializer.TraiteListe<CGPSLineSegment>(m_listeSegments, new object[]{this});
            if (!result)
                return result;

            return result;
        }

        

        //-------------------------------------------------
        internal void DiviseSegment(CGPSLineSegment segmentToDivise)
        {
            List<CGPSLineSegment> lstSegments = new List<CGPSLineSegment>();
            SLatLong lastPoint = PointDepart;
            foreach ( CGPSLineSegment segment in Segments )
            {
                if (segment == segmentToDivise)
                {

                    SLatLong pt = new SLatLong(
                        (lastPoint.Latitude + segment.PointDestination.Latitude) / 2,
                        (lastPoint.Longitude + segment.PointDestination.Longitude) / 2);
                    CGPSLineSegment newSeg = new CGPSLineSegment(this);
                    newSeg.PointDestination = pt;
                    newSeg.Libelle = segment.Libelle;
                    newSeg.Width = segment.Width;
                    newSeg.Couleur = segment.Couleur;
                    newSeg.TypeLigne = segment.TypeLigne;
                    lstSegments.Add(newSeg);
                    lstSegments.Add(segment);
                }
                else
                    lstSegments.Add(segment);
                lastPoint = segment.PointDestination;
            }
            Segments = lstSegments;
        }

        //---------------------------------------------------------
        public IEnumerable<IMapItem> DeleteStartPoint(CMapDatabase database)
        {
            if (m_listeSegments.Count() > 1)
            {
                //Trouve l'item correspondant au segment 0
                CGPSLineSegment segment = m_listeSegments.ElementAt(0);
                IMapItem item = database.FindItemFromTag(segment);
                PointDepart = segment.PointDestination;
                m_listeSegments.RemoveAt(0);
                if (item != null)
                    return new IMapItem[] { item };
            }
            return new IMapItem[0];

        }

        //---------------------------------------------------------
        public IEnumerable<IMapItem> DeleteSegment(CMapDatabase database, CGPSLineSegment segment)
        {
            if (segment != null && m_listeSegments.Count() > 1)
            {
                IMapItem item = database.FindItemFromTag(segment);
                m_listeSegments.Remove(segment);
                if (item != null)
                    return new IMapItem[] { item };
            }
            return new IMapItem[0];
        }
    }
}
