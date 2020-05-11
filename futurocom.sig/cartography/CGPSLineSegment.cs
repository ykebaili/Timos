using sc2i.common;
using sc2i.common.sig;
using sc2i.data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace futurocom.sig.cartography
{
    public class CGPSLineSegment : I2iSerializable
    {
        private SLatLong m_pointDestination = new SLatLong(0, 0);

        private Color m_couleur = Color.DarkBlue;
        private int m_nWidth = 3;
        private string m_strLibelle = "";
        private CGPSLineTrace m_trace = null;

        private string m_strIdTypeLigne = "";

        private CGPSTypeLigne m_typeLigne = null;

        //-------------------------------------------------------
        public CGPSLineSegment(CGPSLineTrace trace)
        {
            m_trace = trace;
        }

        //-------------------------------------------------------
        public string IdTypeLigne
        {
            get
            {
                return m_strIdTypeLigne;
            }
            set
            {
                m_strIdTypeLigne = value;
            }
        }

        //-------------------------------------------------------
        [DynamicField("Line type")]
        public CGPSTypeLigne TypeLigne
        {
            get
            {
                if (m_typeLigne != null)
                    return m_typeLigne;
                if (IdTypeLigne.Length > 0)
                {
                    CGPSTypeLigne type = new CGPSTypeLigne(CContexteDonneeSysteme.GetInstance());
                    if (type.ReadIfExistsUniversalId(IdTypeLigne))
                    {
                        m_typeLigne = type;
                        return type;
                    }
                }
                return null;
            }
            set
            {
                if (value == null)
                    IdTypeLigne = "";
                else
                    IdTypeLigne = value.IdUniversel;
                m_typeLigne = null;
            }
        }

        //-------------------------------------------------------
        public string Libelle
        {
            get
            {
                return m_strLibelle;
            }
            set
            {
                m_strLibelle = value;
            }
        }
        //-------------------------------------------------------
        public Color Couleur
        {
            get
            {
                if (TypeLigne != null)
                    return TypeLigne.DefaultColor;
                return m_couleur;
            }
            set
            {
                m_couleur = value;
            }
        }

        //-------------------------------------------------------
        public int Width
        {
            get
            {
                if (TypeLigne != null)
                    return TypeLigne.DefaultWidth;
                return m_nWidth;
            }
            set
            {
                m_nWidth = value;
            }
        }

        //-------------------------------------------------------
        public SLatLong PointDestination
        {
            get
            {
                return m_pointDestination;
            }
            set
            {
                m_pointDestination = value;
            }
        }

        //-------------------------------------------------------
        [DynamicField("End Latitude")]
        public double LatitudeDestination
        {
            get
            {
                return m_pointDestination.Latitude;
            }
        }

        //-------------------------------------------------------
        [DynamicField("End Longitude")]
        public double LongitudeDestination
        {
            get
            {
                return m_pointDestination.Longitude;
            }
        }

        //-------------------------------------------------------
        private int GetNumVersion()
        {
            return 2;
        }


        //-------------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            serializer.TraiteString(ref m_strLibelle);
            double fVal = m_pointDestination.Latitude;
            serializer.TraiteDouble(ref fVal);
            m_pointDestination.Latitude = fVal;
            fVal = m_pointDestination.Longitude;
            serializer.TraiteDouble(ref fVal);
            m_pointDestination.Longitude = fVal;
            if ( nVersion >= 1 )
            {
                serializer.TraiteInt(ref m_nWidth);
                int nTmp = m_couleur.ToArgb();
                serializer.TraiteInt(ref nTmp);
                m_couleur = Color.FromArgb(nTmp);
            }
            if ( nVersion >= 2 )
                serializer.TraiteString ( ref m_strIdTypeLigne );
            return result;
        }

        //-------------------------------------------------------
        public void DiviseSegment()
        {
            if (m_trace != null)
                m_trace.DiviseSegment(this);
        }
    }
}
