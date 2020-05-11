using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.drawing;
using System.Collections;
using System.Drawing;
using sc2i.common;

namespace timos.data.composantphysique
{
    [Serializable]
    public class C2i3DEn2D : I2iObjetGraphique, IEquatable<C2i3DEn2D>
    {
        private C2iComposant3D m_composant3D = null;
        private EFaceVueDynamique m_faceVisible = EFaceVueDynamique.Front;
        //private Size m_referenceSize;
        private bool m_bIsElementReference = false;

        private bool m_bIsLock = false;

        //-----------------------------------------------
        public C2i3DEn2D()
        { }
        //-----------------------------------------------
        public C2i3DEn2D(
            C2iComposant3D composant,
            EFaceVueDynamique face)
        {
            m_composant3D = composant;
            m_faceVisible = face;
        }

        //-----------------------------------------------
        public C2iComposant3D Composant3D
        {
            get
            {
                return m_composant3D;
            }
        }

        //-----------------------------------------------
        public Size SizeReference
        {
            get
            {
                if (Parent != null)
                    return Parent.Size;
                return Size;
            }
        }

        //-----------------------------------------------
        public string TooltipText
        {
            get
            {
                return "";
            }
        }

        //-----------------------------------------------
        public bool LockChilds
        {
            get
            {
                return m_composant3D.LockChilds;
            }
            set
            {
                m_composant3D.LockChilds = value;
            }
        }

        //-----------------------------------------------
        public bool IsElementReference
        {
            get
            {
                return m_bIsElementReference;
            }
            set
            {
                m_bIsElementReference = value;
            }
        }

        //-----------------------------------------------
        public EFaceVueDynamique FaceVisible
        {
            get
            {
                return m_faceVisible;
            }
            set
            {
                m_faceVisible = value;
            }
        }

        //-----------------------------------------------
        public static implicit operator C2iComposant3D(C2i3DEn2D objet2D)
        {
            return objet2D.Composant3D;
        }


        //-----------------------------------------------
        public bool AcceptChilds
        {
            get
            {
                bool bResult = Composant3D.AcceptChilds;
                if (Composant3D.IsModeRuntime)
                    bResult &= Composant3D.AcceptChildsAtRuntime;
                return bResult;
            }
        }

        //-----------------------------------------------
        public bool AddChild(I2iObjetGraphique child)
        {
            C2i3DEn2D composant = child as C2i3DEn2D;
            if (composant != null)
            {
                bool bResult = Composant3D.AddFils(composant.Composant3D);
                if (bResult && ChildAdded != null)
                    ChildAdded(child);
                return bResult;
            }
            return false;
        }

        //-----------------------------------------------
        public System.Collections.ArrayList AllChilds()
        {
            ArrayList lst = new ArrayList();
            foreach (C2iComposant3D fils in Composant3D.AllChilds())
                lst.Add(fils.Get2D(FaceVisible));
            return lst;
        }

        //-----------------------------------------------
        public void BringToFront(I2iObjetGraphique child)
        {
            C2i3DEn2D c3d = child as C2i3DEn2D;
            if (c3d != null)
                Composant3D.BringToFront(c3d.Composant3D);
        }

        //-----------------------------------------------
        public event EventHandlerChild ChildAdded;

        //-----------------------------------------------
        public event EventHandlerChild ChildRemoved;

        //-----------------------------------------------
        public I2iObjetGraphique[] Childs
        {
            get
            {
                List<I2iObjetGraphique> lst = new List<I2iObjetGraphique>(Composant3D.Childs.Select(c => c.Get2D(FaceVisible)));
                return lst.ToArray();
            }
        }

        //-----------------------------------------------
        public System.Drawing.Rectangle ClientRect
        {
            get
            {
                return new Rectangle(new Point(0, 0),
                    m_composant3D.SizeAbsolue.GetSize2D(FaceVisible));
            }
        }

        //-----------------------------------------------
        public Point OrigineCliente
        {
            get
            {
                return new Point(0, 0);
            }
        }

        //-----------------------------------------------
        public System.Drawing.Rectangle ClientToGlobal(System.Drawing.Rectangle rect)
        {
            throw new Exception("Not usable in 3D");
        }

        //-----------------------------------------------
        public System.Drawing.Point ClientToGlobal(System.Drawing.Point pt)
        {
            throw new Exception("Not usable in 3D");
        }

        //-----------------------------------------------
        public Point ClientToGlobal ( Point pt, C3DPoint dimensionsManquantes )
        {
            C3DPoint pt3D = ConvertTo3D(pt, dimensionsManquantes);
            pt3D = m_composant3D.ClientToGlobal(pt3D);
            C2i3DEn2D parent = this;
            while (parent.Parent != null)
                parent = parent.Parent as C2i3DEn2D;
            return parent.ConvertTo2D(pt3D);
        }

        //-----------------------------------------------
        public System.Drawing.Point[] ClientToGlobal(System.Drawing.Point[] pts)
        {
            throw new Exception("Not usable in 3D");
        }

        //-----------------------------------------------
        public object Clone()
        {
            throw new NotImplementedException();
        }

        //-----------------------------------------------
        public bool ContainsChild(I2iObjetGraphique child)
        {
            return Childs.FirstOrDefault(c => c == child) != null;
        }

        //-----------------------------------------------
        public void DeleteChild(I2iObjetGraphique child)
        {
            C2i3DEn2D c3D = child as C2i3DEn2D;
            if (c3D != null)
                m_composant3D.RemoveFils(c3D);
        }

        //-----------------------------------------------
        public void Draw(CContextDessinObjetGraphique ctx)
        {
            m_composant3D.Draw2D(ctx, FaceVisible, SizeReference);
        }

        //-----------------------------------------------
        public void DrawSelected(System.Drawing.Graphics g)
        {

        }

        //-----------------------------------------------
        public void FrontToBack(I2iObjetGraphique child)
        {
            C2i3DEn2D c3d = child as C2i3DEn2D;
            if (c3d != null)
                Composant3D.FrontToBack(c3d.Composant3D);
        }

        //-----------------------------------------------
        public System.Drawing.Bitmap GetBitmapCopie(int nTailleImage, bool bChildsOnly)
        {
            return null;
        }

        //-----------------------------------------------
        public Point GlobalToClient(Point pt)
        {
            return pt;// throw new Exception("Not usable in 3D");
        }

        //-----------------------------------------------
        public System.Drawing.Point GlobalToClient(System.Drawing.Point pt, C3DPoint dimensionManquante)
        {
            C2i3DEn2D parent = this;
            while (parent.Parent != null)
                parent = parent.Parent as C2i3DEn2D;
            C3DPoint pt3D = parent.ConvertTo3D(pt, dimensionManquante);
            pt3D = m_composant3D.GlobalToClient(pt3D);
            return ConvertTo2D(pt3D);
        }

        //-----------------------------------------------
        public System.Drawing.Point[] GlobalToClient(System.Drawing.Point[] pts)
        {
            throw new Exception("Not usable in 3D");
        }

        //-----------------------------------------------
        public System.Drawing.Rectangle GlobalToClient(System.Drawing.Rectangle rect)
        {
            throw new Exception("Not usable in 3D");
        }

        //-----------------------------------------------
        public bool IsAChildOf(I2iObjetGraphique parent, I2iObjetGraphique supposedChild)
        {
            foreach (I2iObjetGraphique enfant in parent.Childs)
                if (supposedChild.Equals(enfant) || IsAChildOf(enfant, supposedChild))
                    return true;
            return false;
        }

        //-----------------------------------------------
        public bool IsChildOf(I2iObjetGraphique wnd)
        {
            return IsAChildOf(wnd, this);
        }
        //-----------------------------------------------
        public bool IsLock
        {
            get
            {
                return m_bIsLock;
            }
            set
            {
                m_bIsLock = value;
            }
        }

        //-----------------------------------------------
        public bool IsPointIn(System.Drawing.Point pt)
        {
            return CUtilRect.Normalise(RectangleAbsolu).Contains(pt);
        }

        //-----------------------------------------------
        public event EventHandlerObjetGraphique LocationChanged;

        //-----------------------------------------------
        public System.Drawing.Point Magnetise(System.Drawing.Point pt)
        {
            return pt;
        }

        //-----------------------------------------------
        public bool NoDelete
        {
            get { return IsElementReference; }
        }

        //-----------------------------------------------
        public bool NoMove
        {
            get { return false; }
        }

        //-----------------------------------------------
        public bool NoPoignees
        {
            get { return false; }
        }

        //-----------------------------------------------
        public bool NoRectangleSelection
        {
            get { return false; }
        }

        //-----------------------------------------------
        public void OnDesignDoubleClick(System.Drawing.Point ptAbsolu)
        {
        }

        //-----------------------------------------------
        public I2iObjetGraphique Parent
        {
            get
            {
                if (m_composant3D.Parent != null)
                    return new C2i3DEn2D(m_composant3D.Parent, FaceVisible);
                return null;
            }
            set
            {
                C2i3DEn2D c3D = value as C2i3DEn2D;
                if (c3D != null)
                    m_composant3D.Parent = c3D;

            }
        }

        //-----------------------------------------------
        public C2i3DEn2D Parent2D
        {
            get
            {
                return Parent as C2i3DEn2D;
            }
            set
            {
                Parent = value;
            }
        }

        //-----------------------------------------------
        public Point ConvertTo2D(C3DPoint pt)
        {
            switch (FaceVisible)
            {
                default:
                case EFaceVueDynamique.Front:
                    return new Point(pt.X,
                        pt.Y);
                case EFaceVueDynamique.Left:
                    return new Point(
                        pt.Z,
                        pt.Y);
                case EFaceVueDynamique.Top:
                    return new Point(
                        pt.X,
                        pt.Z);
                case EFaceVueDynamique.Rear:
                    return new Point(
                        pt.X,
                        pt.Y);
                case EFaceVueDynamique.Right:
                    return new Point(
                        pt.Z,
                        pt.Y);
                case EFaceVueDynamique.Bottom:
                    return new Point(
                        pt.X,
                        pt.Z);
            }
        }

        //-----------------------------------------------
        public C3DPoint ConvertTo3D ( Point pt, C3DPoint dimensionsManquantes )
        {
            C3DPoint pt3D = new C3DPoint();
            switch (FaceVisible)
            {
                case EFaceVueDynamique.Front:
                    pt3D = new C3DPoint(
                        pt.X,
                        pt.Y,
                        dimensionsManquantes.Z);
                    break;
                case EFaceVueDynamique.Left:
                    pt3D = new C3DPoint(
                        dimensionsManquantes.X,
                        pt.Y,
                        pt.X);
                    break;
                case EFaceVueDynamique.Top:
                    pt3D = new C3DPoint(
                        pt.X,
                        dimensionsManquantes.Y,
                        pt.Y);
                    break;
                case EFaceVueDynamique.Rear:
                    pt3D = new C3DPoint(
                        pt.X,
                        pt.Y,
                        dimensionsManquantes.Z);
                    break;
                case EFaceVueDynamique.Right:
                    pt3D = new C3DPoint(
                        dimensionsManquantes.X,
                        pt.Y,
                        pt.X);
                    break;
                case EFaceVueDynamique.Bottom:
                    m_composant3D.Position = new C3DPoint(
                        pt.X,
                        dimensionsManquantes.Y,
                        pt.Y);
                    break;
                default:
                    break;
            }
            return pt3D;
        }

        //-----------------------------------------------
        public System.Drawing.Point Position
        {
            get
            {
                return ConvertTo2D(m_composant3D.Position);
            }
            set
            {
                m_composant3D.Position = ConvertTo3D(value, m_composant3D.Position);
                if (LocationChanged != null)
                    LocationChanged(this);
            }
        }

        //-----------------------------------------------
        public System.Drawing.Point PositionAbsolue
        {
            get
            {
                if (Parent != null)
                    return Parent2D.ClientToGlobal(Position, m_composant3D.Position);
                return Position;
            }
            set
            {
                if (Parent != null)
                    Position = Parent2D.GlobalToClient(value, m_composant3D.PositionAbsolue);
                else
                    Position = value;
            }
        }

        //-----------------------------------------------
        public System.Drawing.Rectangle RectangleAbsolu
        {
            get
            {
                Point pt = PositionAbsolue;
                Size sz = Size;
                return new Rectangle(
                    pt, sz );/*
                    Math.Min ( pt.X, pt.X + sz.Width ),
                    Math.Min ( pt.Y, pt.Y + sz.Height ),
                    Math.Abs ( sz.Width ),
                    Math.Abs ( sz.Height ) );*/
            }
        }

        //-----------------------------------------------
        public void RemoveChild(I2iObjetGraphique child)
        {
            DeleteChild(child);
            if (ChildRemoved != null)
                ChildAdded(child);
        }

        //-----------------------------------------------
        public void RepositionneChilds()
        {

        }

        //-----------------------------------------------
        public void ResumeLayout()
        {

        }

        public virtual List<I2iObjetGraphique> SelectionnerElements(Point pt)
        {
            return SelectionnerElements(pt, true);
        }

        //Retourne les elements correspondant au point dans l'ordre Z (du plus pret au plus profond)
        public virtual List<I2iObjetGraphique> SelectionnerElements(Point pt, bool bTestLockChilds)
        {
            List<I2iObjetGraphique> elements = new List<I2iObjetGraphique>();
            SelectionnerElements(pt, elements, true, bTestLockChilds);
            elements.Reverse();
            if (IsPointIn(pt))
                elements.Add(this);
            return elements;
        }

        protected List<I2iObjetGraphique> SelectionnerElements(
            Point pt,
            List<I2iObjetGraphique> elements,
            bool bSortSurProfondeurVisible,
            bool bTestLockChilds)
        {
            
            if ( !bTestLockChilds || !m_composant3D.LockChilds )
                foreach (I2iObjetGraphique ele in Childs)
                    if (ele.IsPointIn(pt))
                    {
                        C2i3DEn2D d2 = ele as C2i3DEn2D;
                        if (d2 != null)
                        {
                            if (!bTestLockChilds || !d2.Composant3D.IsModeRuntime || d2.Composant3D.CanSelectAtRuntime)
                                elements.Add(ele);
                            d2.SelectionnerElements(pt, elements, false, bTestLockChilds);
                        }
                        
                    }
            if (bSortSurProfondeurVisible)
            {
                elements.Sort(delegate(I2iObjetGraphique a, I2iObjetGraphique b)
                        {
                            if (a is C2i3DEn2D && b is C2i3DEn2D)
                            {
                                return ((C2i3DEn2D)a).Composant3D.GetPointForSort2D(FaceVisible).CompareTo(
                                    ((C2i3DEn2D)b).Composant3D.GetPointForSort2D(FaceVisible));
                            }
                            return 0;
                        });
            }
            return elements;
        }





        public I2iObjetGraphique SelectionnerElementAvantElement(Point pt, I2iObjetGraphique element)
        {
            List<I2iObjetGraphique> selection = SelectionnerElements(pt);
            selection.Reverse();
            int nIdxElement = selection.IndexOf(element);
            if (nIdxElement > 0)
                return selection[nIdxElement - 1];
            return null;
        }
        public I2iObjetGraphique SelectionnerElementApresElement(Point pt, I2iObjetGraphique element)
        {
            List<I2iObjetGraphique> selection = SelectionnerElements(pt);
            int nIdxElement = selection.IndexOf(element);
            if (nIdxElement < selection.Count - 1)
                return selection[nIdxElement + 1];
            return null;
        }

        public I2iObjetGraphique SelectionnerElementDuDessus(Point pt)
        {
            return SelectionnerElementDuDessus(pt, null);
        }
        public I2iObjetGraphique SelectionnerElementDuDessus(Point pt, I2iObjetGraphique elementToIgnore)
        {
            List<I2iObjetGraphique> selection = SelectionnerElements(pt);
            int nIndice = -1;
            if (elementToIgnore != null)
            {
                nIndice = selection.IndexOf(elementToIgnore);
                if (nIndice == selection.Count - 1)
                    nIndice = -1;
            }
            int nTest = 0;
            foreach (I2iObjetGraphique ele in selection)
            {
                if (nTest > nIndice)
                    return ele;
                nTest++;
            }
            return null;
        }

        //PREMIER CONTENEUR
        public I2iObjetGraphique SelectionnerElementConteneurDuDessus(Point pt)
        {
            I2iObjetGraphique ele = null;
            return SelectionnerElementConteneurDuDessus(pt, ele);
        }

        public I2iObjetGraphique SelectionnerElementConteneurDuDessus(Point pt, List<I2iObjetGraphique> elementsToIgnore)
        {
            List<I2iObjetGraphique> selection = SelectionnerElements(pt, false);
            I2iObjetGraphique lastSel = null;
            foreach (I2iObjetGraphique ele in selection)
            {
                if (ele.AcceptChilds && (lastSel == null || ele.IsChildOf(lastSel)))
                {
                    bool bOk = true;
                    if (elementsToIgnore != null)
                    {
                        if (elementsToIgnore.Contains(ele))
                            bOk = false;
                        else
                            foreach (I2iObjetGraphique eleToIgnore in elementsToIgnore)
                                if (IsAChildOf(eleToIgnore, ele))
                                {
                                    bOk = false;
                                    break;
                                }
                    }
                    if (bOk)
                        lastSel = ele;
                }
            }
            return lastSel;
        }
        //Ignore l'élément et ces fils
        public I2iObjetGraphique SelectionnerElementConteneurDuDessus(Point pt, I2iObjetGraphique elementToIgnore)
        {
            List<I2iObjetGraphique> selection = SelectionnerElements(pt, false);
            foreach (I2iObjetGraphique ele in selection)
                if (ele.AcceptChilds && (elementToIgnore == null || (!IsAChildOf(elementToIgnore, ele) && elementToIgnore != ele)))
                    return ele;
            return null;
        }

        //-----------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-----------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = serializer.TraiteObject<C2iComposant3D>(ref m_composant3D);
            int nFace = (int)FaceVisible;
            serializer.TraiteInt(ref nFace);
            FaceVisible = (EFaceVueDynamique)nFace;
            return result;

        }


        //-----------------------------------------------
        public virtual bool AutoExpandFromChildren
        {
            get
            {
                return false;
            }
        }

        //-----------------------------------------------
        public System.Drawing.Size Size
        {
            get
            {
                return m_composant3D.SizeAbsolue.GetSize2D(FaceVisible);
            }
            set
            {
                switch (FaceVisible)
                {
                    case EFaceVueDynamique.Front:
                        m_composant3D.SizeAbsolue = new C3DSize(
                            value.Width,
                            value.Height,
                            m_composant3D.SizeAbsolue.Depth);
                        break;
                    case EFaceVueDynamique.Left:
                        m_composant3D.SizeAbsolue = new C3DSize(
                            m_composant3D.SizeAbsolue.With,
                            value.Height,
                            value.Width);
                        break;
                    case EFaceVueDynamique.Top:
                        m_composant3D.SizeAbsolue = new C3DSize(
                            value.Width,
                            m_composant3D.SizeAbsolue.Height,
                            value.Height);
                        break;
                    case EFaceVueDynamique.Rear:
                        m_composant3D.SizeAbsolue = new C3DSize(
                            value.Width,
                            value.Height,
                            m_composant3D.SizeAbsolue.Depth);
                        break;
                    case EFaceVueDynamique.Right:
                        m_composant3D.SizeAbsolue = new C3DSize(
                            m_composant3D.SizeAbsolue.With,
                            value.Height,
                            value.Width);
                        break;
                    case EFaceVueDynamique.Bottom:
                        m_composant3D.SizeAbsolue = new C3DSize(
                            value.Width,
                            m_composant3D.SizeAbsolue.Height,
                            value.Height);
                        break;
                    default:
                        break;
                }
                if (SizeChanged != null)
                    SizeChanged(this);
            }
        }

        //-----------------------------------------------
        public event EventHandlerObjetGraphique SizeChanged;

        //-----------------------------------------------
        public void SuspendLayout()
        {
        }

        //-----------------------------------------------
        public override bool Equals(object obj)
        {
            C2i3DEn2D c3D = obj as C2i3DEn2D;
            if (c3D != null)
                return Equals(c3D);
            return false;
        }
        //-----------------------------------------------
        public bool Equals(C2i3DEn2D other)
        {
            if (other == null)
                return false;
            return this.Composant3D.Equals(other.Composant3D);
        }

        //-----------------------------------------------
        public override int GetHashCode()
        {
            return Composant3D.GetHashCode();
        }

        public static bool operator != ( C2i3DEn2D obj1, C2i3DEn2D obj2 )
        {
            return !(obj1 == obj2);
        }

        public static bool operator == (C2i3DEn2D obj1, C2i3DEn2D obj2 )
        {
             if ((object)obj1 == null && (object)obj2 == null)
                return true;
            if ((object)obj1 == null || (object)obj2 == null)
                return false;
            return obj1.Equals(obj2);
        }



        #region I2iObjetGraphique Membres


        public void CancelClone()
        {
        }

        public I2iObjetGraphique GetCloneAMettreDansParent(I2iObjetGraphique parent, Dictionary<Type, object> dicObjetsPourCloner)
        {
            return (I2iObjetGraphique)CCloner2iSerializable.Clone(parent, dicObjetsPourCloner);
        }

        #endregion

        #region I2iObjetGraphique Membres


        public bool OnDesignerMouseDown(Point ptLocal)
        {
            return false;
        }

        #endregion
    }
}
