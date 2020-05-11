using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace timos.data.composantphysique
{
    public class CVecteur3D
    {
        double[] m_values;

        public CVecteur3D(double fX, double fY, double fZ, double fS)
        {
            m_values = new double[]{fX, fY,fZ, fS};
        }

        public double this[int nLigne]
        {
            get
            {
                if (nLigne >= 0 && nLigne < 4 )
                    return m_values[nLigne];
                return 0;
            }
            set
            {
                if (nLigne >= 0 && nLigne < 4 )
                    m_values[nLigne] = value;
            }

        }

        public static CVecteur3D operator *(CTransformation3D matrice, CVecteur3D vecteur)
        {
            CVecteur3D newVecteur = new CVecteur3D(0, 0, 0, 0);
            for (int nLigne = 0; nLigne < 4; nLigne++)
            {
                double fVal = 0;
                for (int nTmp = 0; nTmp < 4; nTmp++)
                    fVal += matrice[nLigne, nTmp] * vecteur[nTmp];
                newVecteur[nLigne] = fVal;
            }
            return newVecteur;
        }
    }

    public class CTransformation3D
    {
        private Stack<double[,]> m_stackMatrices = new Stack<double[,]>();
        public enum EAxe
        {
            X,
            Y,
            Z
        };
        private double[,] m_values = new double[,]{
            {1, 0, 0,0},
            {0,1,0,0 },
            {0,0,1,0},
            {0,0,0,1}
        };

        private CTransformation3D()
        {
        }

        public CTransformation3D ( double[,] valeurs )
        {
            if (valeurs == null || valeurs.Length != 16)
                throw new Exception("Bad matrix size");
            m_values = valeurs;
        }

        public static CTransformation3D Identity
        {
            get
            {
                return new CTransformation3D();
            }
        }

        public static CTransformation3D GetTranslation(double fDx, double fDy, double fDz)
        {
            CTransformation3D t = new CTransformation3D();
            t[0, 3] = fDx;
            t[1, 3] = fDy;
            t[2, 3] = fDz;
            return t;
        }

        public static CTransformation3D GetRotation(double fRotationXDegres, double fRotationYDegre, double fRotationZDegre)
        {
            return GetRotation(EAxe.X, fRotationXDegres) *
                GetRotation(EAxe.Y, fRotationYDegre) *
                GetRotation(EAxe.Z, fRotationZDegre);
            
        }

        public static CTransformation3D GetRotation(EAxe axe, double fAngleDegres)
        {
            CTransformation3D matrice = CTransformation3D.Identity;
            if (fAngleDegres == 0)
                return matrice;
            double fAngle = fAngleDegres / 180.0 * Math.PI;
            double fCos = Math.Cos(fAngle);
            double fSin = Math.Sin(fAngle);


            switch (axe)
            {
                case EAxe.X:
                    matrice[1, 1]=fCos;
                    matrice[1, 2]=-fSin;
                    matrice[2, 1]=fSin;
                    matrice[2, 2]=fCos;
                    break;
                case EAxe.Y:
                    matrice[0, 0]=fCos;
                    matrice[0, 2]=fSin;
                    matrice[2, 0]=-fSin;
                    matrice[2, 2]=fCos;
                    break;
                case EAxe.Z:
                    matrice[0, 0]=fCos;
                    matrice[0, 1]=-fSin;
                    matrice[1, 0]=fSin;
                    matrice[1, 1]=fCos;
                    break;
            }
            return matrice;
        }

        public double this[int nLigne, int nCol]
        {
            get{
                if ( nLigne >= 0 && nLigne < 4 && nCol >= 0 && nCol < 4 )
                    return m_values[nLigne, nCol];
                return 0;
            }
            set{
                if ( nLigne >= 0 && nLigne < 4 && nCol >= 0 && nCol < 4 )
                m_values[nLigne, nCol] = value;
            }
        }

        public static CTransformation3D operator * (CTransformation3D matriceGauche, CTransformation3D matriceDroite )
        {
            CTransformation3D trans = new CTransformation3D();

            for ( int nCol = 0; nCol < 4; nCol++ )
                for (int nLigne = 0; nLigne < 4; nLigne++)
                {
                    double fVal = 0;
                    for (int nTmp = 0; nTmp < 4; nTmp++)
                        fVal += matriceGauche[nLigne, nTmp] * matriceDroite[nTmp, nCol];
                    trans[nLigne, nCol] = fVal;
                }
            return trans;
        }

        public override string ToString()
        {
            StringBuilder bl = new StringBuilder();
            for ( int nLigne = 0; nLigne < 4; nLigne++ )
            {
                for ( int nCol = 0; nCol < 4; nCol++ )
                {
                    bl.Append ( this[nLigne, nCol].ToString("0.00") );
                    bl.Append ( '\t' );
                }
                bl.Remove ( bl.Length-1, 1 );
                bl.Append("\r\n");
            }
            bl.Remove ( bl.Length-2, 2 );
            return bl.ToString();
        }

        public void PushRotation(double fAngleX, double fAngleY, double fAngleZ)
        {
            m_stackMatrices.Push(m_values);
            CTransformation3D t = GetRotation(fAngleX, fAngleY, fAngleZ);
            m_values = (this * t).m_values;
        }

        public void PushTranslation ( double fDx, double fDy, double fDz )
        {
            m_stackMatrices.Push ( m_values );
            CTransformation3D t = GetTranslation ( fDx, fDy, fDz );
            m_values = (this*t).m_values;
        }

        public void Pop()
        {
            m_values = m_stackMatrices.Pop();
        }

        public C3DPoint Transforme(C3DPoint point)
        {
            CVecteur3D vecteur = new CVecteur3D(point.X, point.Y, point.Z, 1.0);
            vecteur = this*vecteur;
            return new C3DPoint ( (int)vecteur[0], (int)vecteur[1], (int)vecteur[2] );
        }

        public C3DSize Transforme(C3DSize size)
        {
            CVecteur3D vecteur = new CVecteur3D(size.With, size.Height, size.Depth, 0.0);
            vecteur = this * vecteur;
            return new C3DSize((int)Math.Round(vecteur[0]), (int)Math.Round(vecteur[1]), (int)Math.Round(vecteur[2]));
        }
    }
}
