using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using sc2i.common;
using System.Drawing;


namespace timos.data
{

    public enum ESensAllerRetourLienReseau
    {
        Forward=0,
        Backward
    }

    public class CSensAllerRetourLienReseau : CEnumALibelle<ESensAllerRetourLienReseau>
    {
        public CSensAllerRetourLienReseau(ESensAllerRetourLienReseau code)
            : base(code)
        {
        }
        public override string Libelle
        {
            get {
                switch (Code)
                {
                    case ESensAllerRetourLienReseau.Forward:
                        return I.T("Forward|20034");
                    case ESensAllerRetourLienReseau.Backward:
                        return I.T("Backward|20035");
                    default:
                        break;
                }
                return "";
            }
        }
    }
    public class CDonneeDessinLienDeSchemaReseau : CDonneeDessinElementDeSchemaReseau
    {
        /// <summary>
        /// Liste des points, y compris le premier et le dernier
        /// </summary>
        private List<Point> m_listePoints = new List<Point>();

        //Offset du premier point par rapport à l'élément 1
        //Si négatif, il doit être recalculé
        private Point m_pointOffsetElement1 = new Point(-1, -1);

        //Offset du dernier point par rapport à l'élément 2
        private Point m_pointOffsetElement2 = new Point(-1, -1);

        private ESensAllerRetourLienReseau m_sensReseau = ESensAllerRetourLienReseau.Forward;

        private EModeOperationnelSchema m_modeOperationnel = EModeOperationnelSchema.AutomaticRedundancy;


        private Color m_foreColor = Color.Black;

        private int m_nLineWidth = 1;

        private bool m_bIsBezier = false;

        public CDonneeDessinLienDeSchemaReseau(int nIdContexteDonnee)
            :base ( nIdContexteDonnee )
        {
        }

        public CDonneeDessinLienDeSchemaReseau()
            : base()
        {
        }




        public Point[] Points
        {
            get
            {
                if (m_listePoints == null)
                    m_listePoints = new List<Point>();
                return m_listePoints.ToArray();
            }
            set
            {
                m_listePoints = new List<Point>();
                m_listePoints.AddRange(value);
            }
        }



        /// <summary>
        /// Offset entre le premier point et le X,Y de l'élément 1
        /// </summary>
        public Point OffsetElement1
        {
            get
            {
                return m_pointOffsetElement1;
            }
            set
            {
                m_pointOffsetElement1 = value;
            }
        }

        public ESensAllerRetourLienReseau Forward_Backward
        {
            get
            {
                return m_sensReseau;
            }
            set
            {
                m_sensReseau = value;
            }
        }

        public EModeOperationnelSchema Operationnal_Mode
        {
            get
            {
                return m_modeOperationnel;
            }
            set
            {
                m_modeOperationnel = value;
            }
        }

        /// <summary>
        /// Offset entre le dernier point et le X,Y de l'élément 2
        /// </summary>
        public Point OffsetElement2
        {
            get
            {
                return m_pointOffsetElement2;
            }
            set
            {
                m_pointOffsetElement2 = value;
            }
        }


        /// <summary>
        /// Largeur de la ligne
        /// </summary>
        public int LineWidth
        {
            get
            {
                return m_nLineWidth;
            }
            set
            {
                m_nLineWidth = value;

            }
        }

        public bool Curve
        {
            get
            {
                return m_bIsBezier;
            }
            set
            {
                m_bIsBezier = value;
            }
        }


        public Color ForeColor
        {
            get
            {
                return m_foreColor;
            }

            set
            {
                m_foreColor = value;
            }

        }


        public virtual  int GetNumVersion()
        {
            return 5;
            //Version 1 : changement de ArrayPoint en points intermédiaires,
            //Ajout de l'offset element1 et offset element2.
            //Vesrsin de : ajout de la couleur et de la largeur de la ligne
            //3 : ajout de SensReseau
            //4 : ajout du mode opérationnel
            //5 : Ajout de bezier
        }

        
        public override CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;


            result = base. Serialize(serializer);
            if (!result)
                return result;

            int nX, nY;
            if (nVersion >= 1)
            {
                nX = m_pointOffsetElement1.X;
                nY = m_pointOffsetElement1.Y;
                serializer.TraiteInt(ref nX);
                serializer.TraiteInt(ref nY);
                m_pointOffsetElement1 = new Point(nX, nY);

                nX = m_pointOffsetElement2.X;
                nY = m_pointOffsetElement2.Y;
                serializer.TraiteInt(ref nX);
                serializer.TraiteInt(ref nY);
                m_pointOffsetElement2 = new Point(nX, nY);

            }

            if (nVersion >= 2)
            {
                int nTmp;
                nTmp = m_foreColor.ToArgb();
                serializer.TraiteInt(ref nTmp);
                m_foreColor = Color.FromArgb(nTmp);

                serializer.TraiteInt(ref m_nLineWidth);

            }

            int nNbPts = 0;
            nNbPts = Points.Length;
            serializer.TraiteInt(ref nNbPts);
            switch (serializer.Mode)
            {
                case ModeSerialisation.Ecriture:
                        foreach ( Point pt in Points )
                        {
                            nX = pt.X;
                            nY = pt.Y;
                            serializer.TraiteInt(ref nX);
                            serializer.TraiteInt(ref nY);
                        }
                        break;
                case ModeSerialisation.Lecture:
                    m_listePoints = new List<Point>();
                    for (int n = 0; n < nNbPts; n++)
                    {
                        nX = 0;
                        nY = 0;
                        serializer.TraiteInt(ref nX);
                        serializer.TraiteInt(ref nY);
                        m_listePoints.Add(new Point(nX, nY));

                    }
                    break;
            }
            if (nVersion >= 3)
            {
                int nSens = (int)m_sensReseau;
                serializer.TraiteInt(ref nSens);
                m_sensReseau = (ESensAllerRetourLienReseau)nSens;
            }
            if (nVersion >= 4)
            {
                int nMode = (int)m_modeOperationnel;
                serializer.TraiteInt(ref nMode);
                m_modeOperationnel = (EModeOperationnelSchema)nMode;
            }
            if (nVersion >= 5)
            {
                serializer.TraiteBool(ref m_bIsBezier);
            }
            return result;
        }
    }
}
