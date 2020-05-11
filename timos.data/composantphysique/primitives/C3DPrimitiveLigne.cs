using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using sc2i.common;

namespace timos.data.composantphysique
{
    public class C3DPrimitiveLigne : I3DPrimitive
    {

        private C3DPoint[] m_points;
        private Color m_couleur = Color.Orange;

        //--------------------------------------------------
        public C3DPrimitiveLigne(C3DPoint[] pts, Color couleur)
        {
            m_points = pts;
            m_couleur = couleur;
        }

        //--------------------------------------------------
        public Color Couleur
        {
            get
            {
                return m_couleur;
            }
        }

        //--------------------------------------------------
        public bool IsTransparente
        {
            get
            {
                return Couleur.A < 253;
            }
        }

        //--------------------------------------------------
        public C3DPoint[] Points
        {
            get
            {
                return m_points;
            }
        }

        

        //--------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //--------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            List<C3DPoint> lst = new List<C3DPoint>(m_points);
            if (result)
                result = serializer.TraiteListe<C3DPoint>(lst);
            m_points = lst.ToArray();
            if (result)
            {
                int nTmp = m_couleur.ToArgb();
                serializer.TraiteInt(ref nTmp);
                m_couleur = Color.FromArgb(nTmp);
            }
            return result;
        }
    }
}
