using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using SharpGL;
using timos.data.composantphysique;

namespace timos.composantphysique.ConvertOpenGL
{
    [AutoExec("Autoexec")]
    public class CConvertisseurQuadToOpenGL : CConvertisseurOpenGL
    {
        //-------------------------------------
        public static void Autoexec()
        {
            RegisterConvertisseur(new CConvertisseurQuadToOpenGL());
        }

        //-------------------------------------
        public override void ConvertPrimitive(I3DPrimitive primitive, SharpGL.OpenGL gl)
        {
            C3DPrimitiveQuad quad = primitive as C3DPrimitiveQuad;
            if ( quad == null || quad.Points == null || quad.Points.Length != 4)
                return;
            for (int nTmp = 0; nTmp < 2; nTmp++)
            {
                
                if (nTmp == 0)
                {
                    gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.FILL);
                    gl.Color(GetComposantsCouleur(quad.Couleur));
                }
                else
                {
                    gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.LINE);
                    gl.Color(0.0f, 0.0f, 0.0f, 1.0f);
                }

                gl.Material(OpenGL.FRONT_AND_BACK, OpenGL.SPECULAR, GetComposantsCouleur(quad.Couleur));
                gl.Material(OpenGL.FRONT_AND_BACK, OpenGL.SHININESS, 100.0f);

                gl.Begin(OpenGL.QUADS);                
                //Fond
                //gl.Normal3f(0f, 0f, -1.0f);
                for (int n = 0; n < 4; n++)
                    gl.Vertex(quad.Points[n].X, quad.Points[n].Y, quad.Points[n].Z);

                gl.End();

                

            }

           

        }




        //-------------------------------------
        public override Type[] TypesPrimitivesConverties
        {
            get
            {
                return new Type[]{typeof(C3DPrimitiveQuad)};
            }
        }

        //-------------------------------------

    }
}
