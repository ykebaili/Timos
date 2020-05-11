using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using timos.data.composantphysique;
using SharpGL;

namespace timos.composantphysique.ConvertOpenGL
{
    [AutoExec("Autoexec")]
    public class CConvertisseurCubeToOpenGL : CConvertisseurOpenGL
    {
        //-------------------------------------
        public static void Autoexec()
        {
            RegisterConvertisseur(new CConvertisseurCubeToOpenGL());
        }

        //-------------------------------------
        public override void ConvertPrimitive(I3DPrimitive primitive, SharpGL.OpenGL gl)
        {
            C3DPrimitiveCube cube = primitive as C3DPrimitiveCube;
            if ( cube == null )
                return;
            for (int nTmp = 0; nTmp < 2; nTmp++)
            {
                
                if (nTmp == 0)
                {
                    gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.FILL);
                    gl.Color(GetComposantsCouleur(cube.Couleur));
                }
                else
                {
                    gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.LINE);
                    gl.Color(0.0f, 0.0f, 0.0f, 1.0f);
                }

                gl.Material(OpenGL.FRONT_AND_BACK, OpenGL.SPECULAR, GetComposantsCouleur(cube.Couleur));
                gl.Material(OpenGL.FRONT_AND_BACK, OpenGL.SHININESS, 100.0f);

                gl.Begin(OpenGL.QUADS);                
                //Fond
                gl.Normal3f(0f, 0f, -1.0f);
                gl.Vertex(cube.Position.X, cube.Position.Y, cube.Position.Z);
                gl.Vertex(cube.Position.X, cube.Position.Y + cube.Size.Height, cube.Position.Z);
                gl.Vertex(cube.Position.X + cube.Size.With, cube.Position.Y + cube.Size.Height, cube.Position.Z);
                gl.Vertex(cube.Position.X + cube.Size.With, cube.Position.Y, cube.Position.Z);

                //Gauche
                gl.Normal(new float[] { -100.0f, 0.0f, 0.0f });
                gl.Vertex(cube.Position.X, cube.Position.Y, cube.Position.Z);
                gl.Vertex(cube.Position.X, cube.Position.Y, cube.Position.Z + cube.Size.Depth);
                gl.Vertex(cube.Position.X, cube.Position.Y + cube.Size.Height, cube.Position.Z + cube.Size.Depth);
                gl.Vertex(cube.Position.X, cube.Position.Y + cube.Size.Height, cube.Position.Z);
                
                //Dessus
                //gl.Normal(new float[] { 0.0f, 1.0f, 0.0f });
                gl.Vertex(cube.Position.X, cube.Position.Y + cube.Size.Height, cube.Position.Z);
                gl.Vertex(cube.Position.X, cube.Position.Y + cube.Size.Height, cube.Position.Z + cube.Size.Depth);
                gl.Vertex(cube.Position.X + cube.Size.With, cube.Position.Y + cube.Size.Height, cube.Position.Z + cube.Size.Depth);
                gl.Vertex(cube.Position.X + cube.Size.With, cube.Position.Y + cube.Size.Height, cube.Position.Z);

                //Dessous
                gl.Normal(new float[] { 0.0f, -1.0f, 0.0f });
                gl.Vertex(cube.Position.X, cube.Position.Y, cube.Position.Z);
                gl.Vertex(cube.Position.X + cube.Size.With, cube.Position.Y, cube.Position.Z);
                gl.Vertex(cube.Position.X + cube.Size.With, cube.Position.Y, cube.Position.Z + cube.Size.Depth);
                gl.Vertex(cube.Position.X, cube.Position.Y, cube.Position.Z + cube.Size.Depth);

                //Droite
                gl.Normal(new float[] { 1.0f, 0.0f, 0.0f });
                gl.Vertex(cube.Position.X + cube.Size.With, cube.Position.Y, cube.Position.Z);
                gl.Vertex(cube.Position.X + cube.Size.With, cube.Position.Y + cube.Size.Height, cube.Position.Z);
                gl.Vertex(cube.Position.X + cube.Size.With, cube.Position.Y + cube.Size.Height, cube.Position.Z + cube.Size.Depth);
                gl.Vertex(cube.Position.X + cube.Size.With, cube.Position.Y, cube.Position.Z + cube.Size.Depth);

                //Avant
                gl.Normal(new float[] { 0f, 0f, 1.0f });
                gl.Vertex(cube.Position.X, cube.Position.Y, cube.Position.Z + cube.Size.Depth);
                gl.Vertex(cube.Position.X + cube.Size.With, cube.Position.Y, cube.Position.Z + cube.Size.Depth);
                gl.Vertex(cube.Position.X + cube.Size.With, cube.Position.Y + cube.Size.Height, cube.Position.Z + cube.Size.Depth);
                gl.Vertex(cube.Position.X, cube.Position.Y + cube.Size.Height, cube.Position.Z + cube.Size.Depth);

                gl.End();

                /*if (nTmp == 0)
                {
                    //Gauche
                    
                    gl.Normal(new float[] { -100.0f, 0.0f, 0.0f });
                    for (int nY = 0; nY <= cube.Size.Height; nY += cube.Size.Height / 50)
                    {
                        gl.Begin(OpenGL.QUAD_STRIP);
                        gl.Vertex(cube.Position.X, cube.Position.Y + nY, cube.Position.Z);
                        gl.Vertex(cube.Position.X, cube.Position.Y + nY + cube.Size.Height / 50, cube.Position.Z);

                        for (int nZ = 0; nZ <= cube.Size.Depth; nZ += cube.Size.Depth / 50)
                        {
                            gl.Vertex(cube.Position.X, cube.Position.Y + nY, cube.Position.Z + nZ);
                            gl.Vertex(cube.Position.X, cube.Position.Y + nY + cube.Size.Height / 50, cube.Position.Z + nZ + cube.Size.Depth / 50);
                        }
                    }

                    gl.End();
                }*/

            }

           

        }




        //-------------------------------------
        public override Type[] TypesPrimitivesConverties
        {
            get
            {
                return new Type[]{typeof(C3DPrimitiveCube)};
            }
        }

        //-------------------------------------

    }
}
