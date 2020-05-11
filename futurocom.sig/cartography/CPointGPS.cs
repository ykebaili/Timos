using sc2i.common;
using sc2i.common.sig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace futurocom.sig.cartography
{
    public class CPointGPS
    {
        private SLatLong m_latLong;

        public CPointGPS(SLatLong latLong)
        {
            m_latLong = latLong;
        }

        [DynamicField("Latitude")]
        public double Latitude
        {
            get
            {
                return m_latLong.Latitude;
            }
        }

        [DynamicField("Longitude")]
        public double Longitude
        {
            get
            {
                return m_latLong.Longitude;
            }
        }
    }
}
