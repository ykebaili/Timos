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
    public class CConvertisseurLigneToOpenGL : CConvertisseurOpenGL
    {
        //-------------------------------------
        public static void Autoexec()
        {
            RegisterConvertisseur(new CConvertisseurLigneToOpenGL());
        }

        //-------------------------------------
        public override void ConvertPrimitive(I3DPrimitive primitive, SharpGL.OpenGL gl)
        {
            C3DPrimitiveLigne ligne = primitive as C3DPrimitiveLigne;
            if (ligne == null || ligne.Points == null || ligne.Points.Length < 2)
                return;

            gl.Begin(OpenGL.LINES);
            for (int n = 0; n < ligne.Points.Length; n++)
                gl.Vertex(ligne.Points[n].X, ligne.Points[n].Y, ligne.Points[n].Z);

            gl.End();


        }




        //-------------------------------------
        public override Type[] TypesPrimitivesConverties
        {
            get
            {
                return new Type[]{typeof(C3DPrimitiveLigne)};
            }
        }

        //-------------------------------------

    }
}
