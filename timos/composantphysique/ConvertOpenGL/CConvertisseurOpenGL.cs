using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using timos.data.composantphysique;
using SharpGL;
using System.Drawing;

namespace timos.composantphysique.ConvertOpenGL
{
    public abstract class CConvertisseurOpenGL
    {
        /// <summary>
        /// Type de primitive->Convertisseur OPENGL
        /// </summary>
        private static Dictionary<Type, CConvertisseurOpenGL> m_dicConvertisseurs = new Dictionary<Type, CConvertisseurOpenGL>();

        public static void RegisterConvertisseur ( CConvertisseurOpenGL convertisseur )
        {
            foreach (Type tp in convertisseur.TypesPrimitivesConverties)
                m_dicConvertisseurs[tp] = convertisseur;
        }

        public static void CreateOpenGL ( I3DPrimitive primitive, SharpGL.OpenGL gl )
        {
            CConvertisseurOpenGL convertisseur = null;
            if (m_dicConvertisseurs.TryGetValue(primitive.GetType(), out convertisseur))
            {
                convertisseur.ConvertPrimitive(primitive, gl);
            }
        }

        public static void ConvertScene(I3DPrimitive[] primitives, SharpGL.OpenGL gl)
        {
            foreach (I3DPrimitive primitive in primitives)
            {
                if (!primitive.IsTransparente)
                    CreateOpenGL(primitive, gl);
            }
            foreach (I3DPrimitive primitive in primitives)
            {
                if (primitive.IsTransparente)
                    CreateOpenGL(primitive, gl);
            }
        }

        public abstract void ConvertPrimitive(I3DPrimitive primitive, SharpGL.OpenGL gl);

        protected float[] GetComposantsCouleur ( Color couleur )
        {
            float[] bts = new float[]
            {
                ((float)couleur.R)/255.0f,
                ((float)couleur.G)/255.0f,
                ((float)couleur.B)/255.0f,
                Math.Min(((float)couleur.A)/254.0f,1.0f)
            };
            return bts;
        }

            

        public abstract Type[] TypesPrimitivesConverties{get;}

        
            


    }
}
