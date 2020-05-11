using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.expression;
using sc2i.drawing;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace timos.data.symbole.dynamique
{
    /// <summary>
    /// Parametre pour modifier dynamiquement la représentation d'un symbole
    /// </summary>
    public class CParametreRepresentationSymbole : I2iSerializable
    {
        private List<CParametreRepresentationElementDeSymbole> m_parametres = new List<CParametreRepresentationElementDeSymbole>();
        private C2iSymbole m_symbole = new C2iSymbole();

        //------------------------------------------
        public CParametreRepresentationSymbole()
        {
        }

        //------------------------------------------
        public IEnumerable<CParametreRepresentationElementDeSymbole> Parametres
        {
            get
            {
                return m_parametres.AsReadOnly();
            }
        }

        //------------------------------------------
        public C2iSymbole Symbole
        {
            get
            {
                return m_symbole;
            }
            set
            {
                m_symbole = value;
            }
        }


        //------------------------------------------
        public void AddParametre ( CParametreRepresentationElementDeSymbole parametre )
        {
            CParametreRepresentationElementDeSymbole oldParam = m_parametres.FirstOrDefault ( p=>p.ElementName == parametre.ElementName );
            if (oldParam != null)
                m_parametres.Remove(oldParam);
            m_parametres.Add(parametre);
        }

        //------------------------------------------
        public void RemoveParametre(CParametreRepresentationElementDeSymbole parametre)
        {
            m_parametres.Remove(parametre);
        }

        //------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        
        //------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;

            result = serializer.TraiteObject<C2iSymbole>(ref m_symbole);
            if (!result)
                return result;

            result = serializer.TraiteListe<CParametreRepresentationElementDeSymbole>(m_parametres);
            if (!result)
                return result;

            return result;
        }

        //------------------------------------------
        protected void ApplyOnSymbole(IElementDeSchemaReseau elementRepresenté)
        {
            if (m_symbole == null)
                return;
            m_symbole.ElementASymbole = elementRepresenté;
            CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(elementRepresenté);
            foreach (CParametreRepresentationElementDeSymbole parametre in Parametres)
            {
                C2iSymbole element = m_symbole.GetChildFromName(parametre.ElementName);
                if (element != null)
                    parametre.ApplyOnElement(element, ctxEval);
            }
        }

        //------------------------------------------
        public void Draw(
            CContextDessinObjetGraphique ctx, 
            IElementDeSchemaReseau element,
            C2iObjetGraphique objetGraphique)
        {
            ApplyOnSymbole(element);
            if (m_symbole != null)
            {
                m_symbole.Transparency = 100;
                Matrix oldMat = ctx.Graphic.Transform;
                C2iLienDeSchemaReseau lien = objetGraphique as C2iLienDeSchemaReseau;
                if (lien != null)
                {
                    //Se place au centre du lien
                    Point pt = lien.GetPointCentral();
                    pt.Offset(-m_symbole.Width/2, -m_symbole.Height/2);
                    ctx.Graphic.TranslateTransform(pt.X, pt.Y);
                }
                else
                {
                    float fEchelleX = (float)objetGraphique.Size.Width / (float)m_symbole.Size.Width;
                    float fEchelleY = (float)objetGraphique.Size.Height / (float)m_symbole.Size.Height;
                    ctx.Graphic.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    ctx.Graphic.TranslateTransform(objetGraphique.Position.X, objetGraphique.Position.Y);
                    ctx.Graphic.ScaleTransform(fEchelleX, fEchelleY);
                }
                m_symbole.Draw(ctx);
                ctx.Graphic.Transform = oldMat;
            }
        }

    }
}
