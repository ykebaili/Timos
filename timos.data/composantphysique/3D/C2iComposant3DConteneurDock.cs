using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;
using sc2i.drawing;
using sc2i.common;
using sc2i.formulaire;

namespace timos.data.composantphysique
{
    [WndName("Docking container")]
    [VisibleInInterface]
    public class C2iComposant3DConteneurDock : C2iComposant3D
    {
        private bool m_bIsDocking = false;

        public C2iComposant3DConteneurDock()
            : base()
        {
            BackColor = Color.White;
            ForeColor = Color.Black;
        }

        public override void Draw2D(sc2i.drawing.CContextDessinObjetGraphique contexte, EFaceVueDynamique faceVisible, System.Drawing.Size sizeReference)
        {
            I2iObjetGraphique rect = Get2D(faceVisible);
            Brush br = new HatchBrush(HatchStyle.Divot, ForeColor, Color.FromArgb(50, BackColor));
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

            return result;
        }

        //-----------------------------------------------------
        public override CEmplacementDansParent GetNewEmplacementForChild(C2iComposant3D fils)
        {
            return new CDockStyle(fils);
        }

        //-----------------------------------------------------
        protected override void MyRepositionneChilds()
        {
            base.MyRepositionneChilds();
            DockChilds();
        }

        //-----------------------------------------------------
        private void DockChilds()
        {
            if (m_bIsDocking)
                return;
            m_bIsDocking = true;
            C3DPoint offset = new C3DPoint(0, 0, 0);
            C3DSize size = Size;
            foreach (C2iComposant3D composantFils in Childs)
            {
                CDockStyle dockStyle = composantFils.LocationInParent as CDockStyle;
                if (dockStyle != null)
                {
                    switch (dockStyle.DockStyle)
                    {
                        case E3DDockStyle.Top:
                            composantFils.Size = new C3DSize(
                                size.With,
                                composantFils.Size.Height,
                                size.Depth);
                            composantFils.Position = new C3DPoint(
                                offset.X,
                                offset.Y + size.Height - composantFils.Size.Height,
                                offset.Z);
                            size.Inflate(
                                0,
                                -composantFils.Size.Height,
                                0);
                            break;
                        case E3DDockStyle.Bottom:
                            composantFils.Size = new C3DSize(
                                size.With,
                                composantFils.Size.Height,
                                size.Depth);
                            composantFils.Position = new C3DPoint(
                                offset.X,
                                offset.Y,
                                offset.Z);
                            size.Inflate(
                                0,
                                -composantFils.Size.Height,
                                0);
                            offset.Offset(
                                0,
                                composantFils.Size.Height,
                                0);
                            break;
                        case E3DDockStyle.Left:
                            composantFils.Size = new C3DSize(
                                composantFils.Size.With,
                                size.Height,
                                size.Depth);
                            composantFils.Position = new C3DPoint(
                                offset.X,
                                offset.Y,
                                offset.Z);
                            size.Inflate(
                                -composantFils.Size.With,
                                0,
                                0);
                            offset.Offset(
                                composantFils.Size.With,
                                0,
                                0);
                            break;
                        case E3DDockStyle.Right:
                            composantFils.Size = new C3DSize(
                                composantFils.Size.With,
                                size.Height,
                                size.Depth);
                            composantFils.Position = new C3DPoint(
                                offset.X + size.With - composantFils.Size.With,
                                offset.Y,
                                offset.Z);
                            size.Inflate(
                                -composantFils.Size.With,
                                0,
                                0);
                            break;
                        case E3DDockStyle.Back:
                            composantFils.Size = new C3DSize(
                                size.With,
                                size.Height,
                                composantFils.Size.Depth);
                            composantFils.Position = new C3DPoint(
                                offset.X,
                                offset.Y,
                                offset.Z);
                            size.Inflate(0,
                                0,
                                -composantFils.Size.Depth);
                            offset.Offset(0, 0, composantFils.Size.Depth);
                            break;
                        case E3DDockStyle.Front:
                            composantFils.Size = new C3DSize(
                                size.With,
                                size.Height,
                                composantFils.Size.Depth);
                            composantFils.Position = new C3DPoint(
                                offset.X,
                                offset.Y,
                                offset.Z + size.Depth - composantFils.Size.Depth);
                            size.Inflate(
                                0,
                                0,
                                -composantFils.Size.Depth);
                            break;
                        case E3DDockStyle.Fill:
                            composantFils.Position = offset;
                            composantFils.Size = size;
                            break;
                        default:
                            break;
                    }
                }
            }
            m_bIsDocking = false;

        }
    }
}
