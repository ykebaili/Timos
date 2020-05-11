using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;
using sc2i.drawing;
using sc2i.common;
using System.ComponentModel;
using sc2i.formulaire;

namespace timos.data.composantphysique
{
    public enum EGraduationOrientation
    {
        HorizMinToMax,
        HorizMaxToMin,
        VertMinToMax,
        VertMaxToMin
    };

    

    [WndName("Invisible graduated container")]
    [VisibleInInterface]
    public class C2iComposant3DConteneurGradue : C2iComposant3D, IConteneurGradue
    {
        private int m_nEspaceGraduations = 10000;

        private EGraduationOrientation m_orientation = EGraduationOrientation.VertMaxToMin;

        private E3DAlignement m_HorizontalAlignment = E3DAlignement.None;
        private E3DAlignement m_VerticalAlignment = E3DAlignement.None;
        private E3DAlignement m_DepthAlignment = E3DAlignement.None;

        private EFaceVueDynamique m_faceAlignement = EFaceVueDynamique.Front;

        private List<string> m_prefixesCoordonneesAssocies = new List<string>();


        //-------------------------------------------
        public C2iComposant3DConteneurGradue()
            :base()
        {
            BackColor = Color.White;
            ForeColor = Color.Black;
        }

       
        //-------------------------------------------
        [Category("Childs position")]
        public EGraduationOrientation GraduationOrientation
        {
            get
            {
                return m_orientation;
            }
            set
            {
                m_orientation = value;
                RepositionneChilds();
            }
        }

        //-------------------------------------------
        [Category("Childs position")]
        public EFaceVueDynamique AlignmentFace
        {
            get
            {
                return m_faceAlignement;
            }
            set
            {
                m_faceAlignement = value;
                RepositionneChilds();
            }
        }

        //-------------------------------------------
        [Category("Childs position")]
        public E3DAlignement HorizontalAlignment
        {
            get
            {
                return m_HorizontalAlignment;
            }
            set
            {
                m_HorizontalAlignment = value;
                RepositionneChilds();
            }
        }

        //-------------------------------------------
        [Category("Childs position")]
        public E3DAlignement VerticalAlignment
        {
            get
            {
                return m_VerticalAlignment;
            }
            set
            {
                m_VerticalAlignment = value;
                RepositionneChilds();
            }
        }

        //-------------------------------------------
        [Category("Childs position")]
        public E3DAlignement DepthAlignment
        {
            get
            {
                return m_DepthAlignment;
            }
            set
            {
                m_DepthAlignment = value;
                RepositionneChilds();
            }
        }

        //-------------------------------------------
        public override void Draw2D(sc2i.drawing.CContextDessinObjetGraphique contexte, EFaceVueDynamique faceVisible, System.Drawing.Size sizeReference)
        {
            I2iObjetGraphique rect = Get2D(faceVisible);
            Brush br = new SolidBrush(BackColor);
            Rectangle rct = CUtilRect.Normalise(rect.RectangleAbsolu);
            contexte.Graphic.FillRectangle(br, rct);
            br.Dispose();
            

            contexte.Graphic.DrawRectangle(Pens.Beige, rct);
            
            
            Pen pen = new Pen(Color.Black);
            if (ConvertFaceToLocal(faceVisible) == AlignmentFace)
            {
                if (m_nEspaceGraduations > 0)
                {
                    switch (GraduationOrientation)
                    {
                        case EGraduationOrientation.HorizMinToMax:
                            for (int n = 0; n < rct.Width; n += m_nEspaceGraduations)
                            {
                                contexte.Graphic.DrawLine(pen, rct.Left+n, rct.Top , rct.Left+n, rct.Bottom);
                            }
                            break;
                        case EGraduationOrientation.HorizMaxToMin:
                            for (int n = rct.Width; n >0; n -= m_nEspaceGraduations)
                            {
                                contexte.Graphic.DrawLine(pen, rct.Left + n, rct.Top, rct.Left + n, rct.Bottom);
                            }
                            break;
                        case EGraduationOrientation.VertMinToMax:
                            for (int n = 0; n < rct.Height; n += m_nEspaceGraduations)
                            {
                                contexte.Graphic.DrawLine(pen, rct.Left, rct.Top + n, rct.Right, rct.Top + n);
                            }
                            break;
                        case EGraduationOrientation.VertMaxToMin:
                            for (int n = Size.Height; n > 0; n -= m_nEspaceGraduations)
                            {
                                contexte.Graphic.DrawLine(pen, rct.Left, rct.Top + n, rct.Right, rct.Top + n);
                            }
                            break;
                        default:
                            break;
                    }
                   
                }
            }
            pen.Dispose();

            foreach (C2iComposant3D fils in SortChildsFor2D(faceVisible))
                fils.Draw2D(contexte, faceVisible, sizeReference);
        }

        [Category("Childs position")]
        [CanBeDynamic]
        public double GraduationGapMm
        {
            get
            {
                return GetMmFromCentMm(m_nEspaceGraduations);
            }
            set
            {
                m_nEspaceGraduations = GetCentMmFromMm(value);
            }
        }

        public override bool AcceptChilds
        {
            get
            {
                return true;
            }
        }

        private int GetNumVersion()
        {
            return 0;
        }

        public override CResultAErreur Serialize(sc2i.common.C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = base.Serialize(serializer);
            if (!result)
                return result;
            serializer.TraiteInt(ref m_nEspaceGraduations);

            int nTmp = (int)m_orientation;
            serializer.TraiteInt(ref nTmp);
            m_orientation = (EGraduationOrientation)nTmp;

            nTmp = (int)m_HorizontalAlignment;
            serializer.TraiteInt(ref nTmp);
            m_HorizontalAlignment = (E3DAlignement)nTmp;

            nTmp = (int)m_VerticalAlignment;
            serializer.TraiteInt(ref nTmp);
            m_VerticalAlignment = (E3DAlignement)nTmp;

            nTmp = (int)DepthAlignment;
            serializer.TraiteInt(ref nTmp);
            m_DepthAlignment = (E3DAlignement)nTmp;

            nTmp = (int)m_faceAlignement;
            serializer.TraiteInt(ref nTmp);
            m_faceAlignement = (EFaceVueDynamique)nTmp;

            if (nVersion > 0)
            {
                string strTmp = AssociatedCoordinatePrefixes;
                serializer.TraiteString(ref strTmp);
                AssociatedCoordinatePrefixes = strTmp;
            }

            return result;
        }

        public override CEmplacementDansParent GetNewEmplacementForChild(C2iComposant3D composantFils)
        {
            CGraduateCoordinate coord = new CGraduateCoordinate(composantFils);
            return coord;
        }

        protected EOrientationAxe GetAxeAlignement()
        {
            //Face visible, Orientation
            EOrientationAxe[,] orientations = new EOrientationAxe[,]{
                /*face*/{EOrientationAxe.Xp, EOrientationAxe.Xm, EOrientationAxe.Yp, EOrientationAxe.Ym},
                /*left*/{EOrientationAxe.Zp, EOrientationAxe.Zm, EOrientationAxe.Yp, EOrientationAxe.Ym},
                /*Top*/{EOrientationAxe.Xp, EOrientationAxe.Xm, EOrientationAxe.Zp, EOrientationAxe.Zm},
                /*Back*/{EOrientationAxe.Xp, EOrientationAxe.Xm, EOrientationAxe.Yp, EOrientationAxe.Ym},
                /*right*/{EOrientationAxe.Zp, EOrientationAxe.Zm, EOrientationAxe.Yp, EOrientationAxe.Ym},
                /*bottom*/{EOrientationAxe.Xp, EOrientationAxe.Xm, EOrientationAxe.Zp, EOrientationAxe.Zm}
            };
            return orientations[(int)AlignmentFace, (int)GraduationOrientation];
        }

        public void AjustePosition(C2iComposant3D composant, int nGraduation)
        {
            int nVal = nGraduation * m_nEspaceGraduations;
            int nX = composant.Position.X;
            int nY = composant.Position.Y;
            int nZ = composant.Position.Z;

            switch (HorizontalAlignment)
            {
                case E3DAlignement.Min:
                    nX = 0;
                    break;
                case E3DAlignement.Max:
                    nX = Size.With - composant.Size.With;
                    break;
                case E3DAlignement.Center:
                    nX = (Size.With - composant.Size.With) / 2;
                    break;
            }
            switch (VerticalAlignment)
            {
                case E3DAlignement.Min:
                    nY = 0;
                    break;
                case E3DAlignement.Max:
                    nY = Size.Height - composant.Size.Height;
                    break;
                case E3DAlignement.Center:
                    nY = (Size.Height - composant.Size.Height) / 2;
                    break;
            }
            switch (DepthAlignment)
            {
                case E3DAlignement.Min:
                    nZ = 0;
                    break;
                case E3DAlignement.Max:
                    nZ = Size.Depth - composant.Size.Depth;
                    break;
                case E3DAlignement.Center:
                    nZ = (Size.Depth - composant.Size.Depth) / 2;
                    break;
            }
            composant.Position = new C3DPoint(nX, nY, nZ);
            CPositionneurDansParentAutoFill p = new CPositionneurDansParentAutoFill(composant, GetAxeAlignement());
            int nTaille = new CPositionneurDansParentAutoFill(this, GetAxeAlignement()).TailleOccupee;
            switch (GraduationOrientation)
            {
                case EGraduationOrientation.HorizMinToMax:
                case EGraduationOrientation.VertMinToMax:
                    p.ValeurAxe = nVal;
                    break;

                case EGraduationOrientation.HorizMaxToMin:
                case EGraduationOrientation.VertMaxToMin:
                    p.ValeurAxe = nTaille - nVal;
                    break;
            }
        }

        

        

        protected override void MyRepositionneChilds()
        {
            int nCoordMin = 0;
            List<C2iComposant3D> lst = new List<C2iComposant3D>(Childs);
            EOrientationAxe axe = GetAxeAlignement();
            lst.Sort(delegate(C2iComposant3D c1, C2iComposant3D c2)
                    {
                        CPositionneurDansParentAutoFill p1 = new CPositionneurDansParentAutoFill(c1, axe);
                        CPositionneurDansParentAutoFill p2 = new CPositionneurDansParentAutoFill(c2, axe);
                        switch (GraduationOrientation)
                        {
                            case EGraduationOrientation.HorizMinToMax:
                            case EGraduationOrientation.VertMinToMax:
                                return p1.ValeurAxe.CompareTo(p2.ValeurAxe);
                            case EGraduationOrientation.VertMaxToMin:
                            case EGraduationOrientation.HorizMaxToMin:
                                return p2.ValeurAxe.CompareTo(p1.ValeurAxe);
                        }
                        return 0;
                        
                    }
                    );

            int nTaille = new CPositionneurDansParentAutoFill(this, axe).TailleOccupee;
            foreach (C2iComposant3D fils in lst)
            {
                CPositionneurDansParentAutoFill p = new CPositionneurDansParentAutoFill(fils, axe );
                int nPos = 0;
                switch (GraduationOrientation)
                {
                    case EGraduationOrientation.HorizMinToMax:
                    case EGraduationOrientation.VertMinToMax:
                        nPos = (int)(p.ValeurAxe / m_nEspaceGraduations);
                        break;
                    case EGraduationOrientation.HorizMaxToMin:
                    case EGraduationOrientation.VertMaxToMin:
                        nPos = (int)((nTaille-p.ValeurAxe)/m_nEspaceGraduations);
                        break;
                }
                
                if (nPos < nCoordMin)
                    nPos = nCoordMin;
                AjustePosition(fils, nPos);
                CGraduateCoordinate coord = new CGraduateCoordinate(fils);
                coord.Position = nPos;
                fils.LocationInParent = coord;
                nCoordMin = 0;// nPos + Math.Max(1, ((int)(p.TailleOccupee / m_nEspaceGraduations)) + 1);
            }                
        }

        protected override void AddPrimitivesToListe(List<I3DPrimitive> lst)
        {
            base.AddPrimitivesToListe(lst);

        }

        //----------------------------------------------
        [Browsable(false)]
        public string[] PrefixesCoordonneeAssocies
        {
            get
            {
                return m_prefixesCoordonneesAssocies.ToArray();
            }
            set
            {
                m_prefixesCoordonneesAssocies = new List<string>(value);
            }
        }

        //----------------------------------------------
        public string AssociatedCoordinatePrefixes
        {
            get
            {
                string strRetour = "";
                foreach (string strPrefixe in m_prefixesCoordonneesAssocies)
                    strRetour += strPrefixe + ";";
                if (strRetour.Length > 0)
                    strRetour = strRetour.Substring(0, strRetour.Length - 1);
                return strRetour;
            }
            set
            {
                string[] strPrefixes = value.Split(';');
                m_prefixesCoordonneesAssocies = new List<string>(strPrefixes);
            }
        }

        //----------------------------------------------
        public bool AddFilsWithIndex(C2iComposant3D composant, int nIndex)
        {
            AddFils(composant);
            CGraduateCoordinate coord = new CGraduateCoordinate(composant);
            coord.Position = nIndex;
            composant.LocationInParent = coord;
            RepositionneChilds();
            return true;
        }
     }
}
