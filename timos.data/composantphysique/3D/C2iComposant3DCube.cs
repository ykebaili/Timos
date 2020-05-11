using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using sc2i.drawing;
using System.ComponentModel;
using sc2i.common;

namespace timos.data.composantphysique
{
    [VisibleInInterface]
    public class C2iComposant3DCube : C2iComposant3D
    {
        public C2iComposant3DCube()
        {
            Size = new C3DSize(7500, 7500, 7500);
        }

        protected override void AddPrimitivesToListe(List<I3DPrimitive> lst)
        {
            C3DPrimitiveCube cube = new C3DPrimitiveCube(
                PositionAbsolue, SizeAbsolue, BackColor);
            lst.Add(cube);
        }

        public override void Draw2D(
            sc2i.drawing.CContextDessinObjetGraphique ctx, 
            EFaceVueDynamique faceVisible,
            Size sizeReference)
        {
            I2iObjetGraphique rect = Get2D(faceVisible);
            Brush br = new SolidBrush(BackColor);
            ctx.Graphic.FillRectangle(br, CUtilRect.Normalise(rect.RectangleAbsolu));
            br.Dispose();

            foreach (C2iComposant3D fils in SortChildsFor2D(faceVisible))
                fils.Draw2D(ctx, faceVisible, sizeReference);
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
    }
}
