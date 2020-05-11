using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

using sc2i.common;
using sc2i.drawing;
using sc2i.formulaire;

namespace timos.data
{
    public class C2iSymbolePort : C2iSymboleSelectionMultiple
    {

        private CPort m_port;

       

        public CPort Port
        {
            get
            {
                return (m_port);
            }

            set
            {
                m_port = value;
            }

        }



      

        public override Point Position
        {
            get
            {
                return base.Position;
            }
            set
            {
                base.Position = value;


                if(m_port !=null)
                {
                   m_port.PosX = value.X;
                   m_port.PosY = value.Y;
               }
            }
        }



    }
}
