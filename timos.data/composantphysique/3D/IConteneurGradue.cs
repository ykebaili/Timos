using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace timos.data.composantphysique
{
    interface IConteneurGradue : IComposantPourObjetACoordonnées
    {
        void AjustePosition(C2iComposant3D composant, int nGraduation);
    }


    public enum EOrientationAxe
    {
        Xp = 0, //X+
        Xm = 1, //X-
        Yp,
        Ym,
        Zp,
        Zm
    };

    public class C2iComposantAvecAxeComparer : IComparer<C2iComposant3D>
    {
        private EOrientationAxe m_axe;

        public C2iComposantAvecAxeComparer(EOrientationAxe axe)
        {
            m_axe = axe;
        }

        #region IComparer<C2iComposant3D> Membres

        public int Compare(C2iComposant3D c1, C2iComposant3D c2)
        {
            switch (m_axe)
            {
                case EOrientationAxe.Xp:
                    return c1.Position.X.CompareTo(c2.Position.X);
                case EOrientationAxe.Xm:
                    return c2.Position.X.CompareTo(c1.Position.X);
                case EOrientationAxe.Yp:
                    return c1.Position.Y.CompareTo(c2.Position.Y);
                case EOrientationAxe.Ym:
                    return c2.Position.Y.CompareTo(c1.Position.Y);
                case EOrientationAxe.Zp:
                    return c1.Position.Z.CompareTo(c2.Position.Z);
                case EOrientationAxe.Zm:
                    return c2.Position.Z.CompareTo(c1.Position.Z);
                default:
                    break;
            }
            return 0;
        }

        #endregion
    }

}
