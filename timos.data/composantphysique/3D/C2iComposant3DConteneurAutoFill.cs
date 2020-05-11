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
    [WndName("Invisible Autoarrange container")]
    [VisibleInInterface]
    public class C2iComposant3DConteneurAutoFill : C2iComposant3D, IConteneurGradue
    {
        private EGraduationOrientation m_orientation = EGraduationOrientation.HorizMinToMax;

        private E3DAlignement m_HorizontalAlignment = E3DAlignement.None;
        private E3DAlignement m_VerticalAlignment = E3DAlignement.None;
        private E3DAlignement m_DepthAlignment = E3DAlignement.None;

        private EFaceVueDynamique m_faceAlignement = EFaceVueDynamique.Front;

        private List<string> m_prefixesCoordonneesAssocies = new List<string>();


        //-------------------------------------------
        public C2iComposant3DConteneurAutoFill()
            :base()
        {
            BackColor = Color.White;
            ForeColor = Color.Black;
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
        public EGraduationOrientation FillOrientation
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
            foreach (C2iComposant3D fils in SortChildsFor2D(faceVisible))
                fils.Draw2D(contexte, faceVisible, sizeReference);
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
            return 1;
            //1 ajout des prefixes associés
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

        public void AjustePosition(C2iComposant3D composant, int nGraduation)
        {
            List<C2iComposant3D> lst = GetChildsTries();
            C2iComposant3D cRef= null;
            int nIndex = lst.IndexOf(composant);
            if (lst.Count > nGraduation)
                cRef = lst[nGraduation];
            else if ( lst.Count > 0 )
                cRef = lst[lst.Count - 1];
            CPositionneurDansParentAutoFill p = new CPositionneurDansParentAutoFill(composant, GetAxeAlignement());
            CPositionneurDansParentAutoFill pRef = null;
            if ( cRef != null )
                pRef = new CPositionneurDansParentAutoFill(cRef, GetAxeAlignement());
            int nVal = p.ValeurAxe;
            int nTaille = new CPositionneurDansParentAutoFill(this, GetAxeAlignement()).TailleOccupee;
            switch (FillOrientation)
            {
                case EGraduationOrientation.HorizMinToMax:
                case EGraduationOrientation.VertMinToMax:
                    if (pRef == null)
                        nVal = -1;
                    else
                        nVal = pRef.ValeurAxe + Math.Sign(nGraduation - nIndex);
                    break;
                case EGraduationOrientation.VertMaxToMin:
                case EGraduationOrientation.HorizMaxToMin:
                    if (pRef == null)
                        nVal = nTaille + 1;
                    else
                        nVal = pRef.ValeurAxe - Math.Sign(nGraduation - nIndex);
                    break;
            }
            p.ValeurAxe = nVal;
            MyRepositionneChilds();
        }

	
        private List<C2iComposant3D> GetChildsTries()
        {
            EOrientationAxe axe = GetAxeAlignement();
            List<C2iComposant3D> lst = new List<C2iComposant3D>(Childs);
            lst.Sort(delegate(C2iComposant3D c1, C2iComposant3D c2)
                    {
                        CPositionneurDansParentAutoFill p1 = new CPositionneurDansParentAutoFill(c1, axe);
                        CPositionneurDansParentAutoFill p2 = new CPositionneurDansParentAutoFill(c2, axe);
                        switch (FillOrientation)
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
            return lst;
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
            return orientations[(int)AlignmentFace, (int)FillOrientation];
        }


        protected override void MyRepositionneChilds()
        {
            List<C2iComposant3D> lst = GetChildsTries();
            int nPos = 0;
            int nIndex = 0;
            EOrientationAxe axe = GetAxeAlignement();
            int nTailleTotale = new CPositionneurDansParentAutoFill(this, axe).TailleOccupee;
            foreach (C2iComposant3D fils in lst)
            {
                int nX = fils.Position.X;
                int nY = fils.Position.Y;
                int nZ = fils.Position.Z;

                switch (HorizontalAlignment)
                {
                    case E3DAlignement.Min:
                        nX = 0;
                        break;
                    case E3DAlignement.Max:
                        nX = Size.With - fils.Size.With;
                        break;
                    case E3DAlignement.Center:
                        nX = (Size.With - fils.Size.With) / 2;
                        break;
                }
                switch (VerticalAlignment)
                {
                    case E3DAlignement.Min:
                        nY = 0;
                        break;
                    case E3DAlignement.Max:
                        nY = Size.Height - fils.Size.Height;
                        break;
                    case E3DAlignement.Center:
                        nY = (Size.Height - fils.Size.Height) / 2;
                        break;
                }
                switch (DepthAlignment)
                {
                    case E3DAlignement.Min:
                        nZ = 0;
                        break;
                    case E3DAlignement.Max:
                        nZ = Size.Depth - fils.Size.Depth;
                        break;
                    case E3DAlignement.Center:
                        nZ = (Size.Depth - fils.Size.Depth) / 2;
                        break;
                }
                fils.Position = new C3DPoint(nX, nY, nZ);
                CPositionneurDansParentAutoFill p = new CPositionneurDansParentAutoFill(fils, axe);
                switch (FillOrientation)
                {
                    case EGraduationOrientation.HorizMinToMax:
                    case EGraduationOrientation.VertMinToMax:
                        p.ValeurAxe = nPos;
                        nPos += p.TailleOccupee;
                        break;
                    case EGraduationOrientation.HorizMaxToMin:
                    case EGraduationOrientation.VertMaxToMin:
                        p.ValeurAxe = nTailleTotale - nPos;
                        nPos += p.TailleOccupee;
                        break;
                    default:
                        break;
                }
                CGraduateCoordinate coord = new CGraduateCoordinate();
                coord.Position = nIndex;
                coord.ComposantAssocie = fils;
                fils.LocationInParent = coord;
                nIndex++;
            } 
        }

        //----------------------------------------------
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
            CGraduateCoordinate coord = new CGraduateCoordinate(composant);
            coord.Position = nIndex;
            composant.LocationInParent = coord;
            AddFils(composant);
            return true;
        }
    }
}
