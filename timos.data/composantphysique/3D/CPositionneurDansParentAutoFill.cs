using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace timos.data.composantphysique
{
    public class CPositionneurDansParentAutoFill
    {
        private C2iComposant3D m_composant = null;
        private EOrientationAxe m_axePositionne;


        public CPositionneurDansParentAutoFill(C2iComposant3D composant,
            EOrientationAxe axePositionne)
        {
            m_axePositionne = axePositionne;
            m_composant = composant;
        }

        public int ValeurAxe
        {
            get
            {
                switch (m_axePositionne)
                {
                    default:
                    case EOrientationAxe.Xp:
                        return m_composant.Position.X;
                    case EOrientationAxe.Xm:
                        return m_composant.Position.X + m_composant.Size.With;
                    case EOrientationAxe.Yp:
                        return m_composant.Position.Y;
                    case EOrientationAxe.Ym:
                        return m_composant.Position.Y + m_composant.Size.Height;
                    case EOrientationAxe.Zp:
                        return m_composant.Position.Z;
                    case EOrientationAxe.Zm:
                        return m_composant.Position.Z + m_composant.Size.Depth;
                }
            }
            set
            {
                C3DPoint pt = m_composant.Position;
                switch (m_axePositionne)
                {
                    case EOrientationAxe.Xp :
                        pt = new C3DPoint(value, pt.Y, pt.Z);
                        break;
                    case EOrientationAxe.Xm:
                        pt = new C3DPoint(value - m_composant.Size.With, pt.Y, pt.Z);
                        break;
                    case EOrientationAxe.Yp:
                        pt = new C3DPoint(pt.X, value, pt.Z);
                        break;
                    case EOrientationAxe.Ym:
                        pt = new C3DPoint(pt.X, value - m_composant.Size.Height, pt.Z);
                        break;
                    case EOrientationAxe.Zp:
                        pt = new C3DPoint(pt.X, pt.Y, value);
                        break;
                    case EOrientationAxe.Zm:
                        pt = new C3DPoint(pt.X, pt.Y, value - m_composant.Size.Depth);
                        break;
                }
                m_composant.Position = pt;
            }
        }

        public int TailleOccupee
        {
            get
            {
                switch (m_axePositionne)
                {
                    default:
                    case EOrientationAxe.Xp:
                    case EOrientationAxe.Xm:
                        return m_composant.Size.With;
                    case EOrientationAxe.Yp:
                    case EOrientationAxe.Ym:
                        return m_composant.Size.Height;
                    case EOrientationAxe.Zp:
                    case EOrientationAxe.Zm:
                        return m_composant.Size.Depth;
                }
            }
        }

    }
}