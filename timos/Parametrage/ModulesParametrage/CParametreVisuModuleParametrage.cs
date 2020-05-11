using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using System.Drawing;
using sc2i.win32.data.dynamic;

namespace timos.Parametrage.ModulesParametrage
{
    public class CParametreVisuModuleParametrage : CParametreEditModulesParametrage
    {
        private Size m_size = new Size(0,0);
        private Point m_position = new Point(-1, -1);
        private Size m_timosSize = new Size(0, 0);
        private Point m_timosPosition = new Point(-1, -1);
        private bool m_bTimosAgrandi = true;

        public CParametreVisuModuleParametrage()
        {
        }

        public Size Size
        {
            get
            {
                return m_size;
            }
            set
            {
                m_size = value;
            }
        }

        public Point Position
        {
            get
            {
                return m_position;
            }
            set
            {
                m_position = value;
            }
        }

        public Size TimosSize
        {
            get
            {
                return m_timosSize;
            }
            set
            {
                m_timosSize = value;
            }
        }

        public Point TimosPosition
        {
            get
            {
                return m_timosPosition;
            }
            set
            {
                m_timosPosition = value;
            }
        }

        public bool TimosAgrandi
        {
            get
            {
                return m_bTimosAgrandi;
            }
            set
            {
                m_bTimosAgrandi = value;
            }
        }

        private int GetNumVersion()
        {
            return 0;
        }

        public override CResultAErreur Serialize ( C2iSerializer serializer )
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
            if ( result) 
                result = base.Serialize ( serializer );
            if ( !result) 
                return result;
            int nX = m_size.Width;
            int nY = m_size.Height;
            serializer.TraiteInt ( ref nX );
            serializer.TraiteInt ( ref nY );
            m_size = new Size ( nX, nY );

            nX = m_position.X;
            nY = m_position.Y;
            serializer.TraiteInt ( ref nX );
            serializer.TraiteInt ( ref nY );
            m_position = new Point ( nX, nY );

            nX = m_timosSize.Width;
            nY = m_timosSize.Height;
            serializer.TraiteInt ( ref nX );
            serializer.TraiteInt ( ref nY );
            m_timosSize = new Size ( nX, nY );

            nX = m_timosPosition.X;
            nY = m_timosPosition.Y;
            serializer.TraiteInt ( ref nX );
            serializer.TraiteInt ( ref nY );
            m_timosPosition = new Point ( nX, nY );

            serializer.TraiteBool(ref m_bTimosAgrandi);
            return result;

        }
    }
}
