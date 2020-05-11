using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.drawing;

namespace timos.data.vuephysique
{
    /// <summary>
    /// Une élément de vue physique correspondant à une vue physique
    /// d'un élément
    /// </summary>
    public class C2iElementDeVuePhysiqueElementAVue : C2iElementDeVuePhysique
    {
        private IElementAVuePhysique m_elementRepresente = null;



        public C2iElementDeVuePhysiqueElementAVue()
            : base()
        {
        }

        //-----------------------------------------------
        public IElementAVuePhysique ElementRepresente
        {
            get
            {
                return m_elementRepresente;
            }
            set
            {
                m_elementRepresente = value;
            }
        }

        //-----------------------------------------------
        public override bool AddChild(sc2i.drawing.I2iObjetGraphique child)
        {
            return false;
        }

        //-----------------------------------------------
        public override void BringToFront(sc2i.drawing.I2iObjetGraphique child)
        {
        }

        //-----------------------------------------------
        public override I2iObjetGraphique[] Childs
        {
            get { return new I2iObjetGraphique[0]; }
        }

        //-----------------------------------------------
        public override bool ContainsChild(sc2i.drawing.I2iObjetGraphique child)
        {
            throw new NotImplementedException();
        }

        //-----------------------------------------------
        public override void FrontToBack(sc2i.drawing.I2iObjetGraphique child)
        {
            throw new NotImplementedException();
        }

        //-----------------------------------------------
        protected override void MyDraw(sc2i.drawing.CContextDessinObjetGraphique ctx)
        {
            throw new NotImplementedException();
        }

        //-----------------------------------------------
        public override void RemoveChild(sc2i.drawing.I2iObjetGraphique child)
        {
            throw new NotImplementedException();
        }
    }
}
