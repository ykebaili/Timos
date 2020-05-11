using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using sc2i.common;
using sc2i.drawing;
using sc2i.formulaire;
using sc2i.expression;


namespace timos.data
{
    public class C2iSymboleVerrouille : C2iSymbole
    {


        private bool m_bLockSize = true;
        private bool m_bLockPosition = false;
        private C2iSymbole m_symboleContenu=null;


        public C2iSymbole SymboleContenu
        {
            get
            {
                return m_symboleContenu;
            }
            set
            {
                m_symboleContenu = value;
                if (m_symboleContenu != null)
                {
                    Size = m_symboleContenu.Size;
                    Position = m_symboleContenu.Position;
                }               
            }

        }

        public override bool AddChild(I2iObjetGraphique child)
        {
            return false;
        }

        public override void RemoveChild(I2iObjetGraphique child)
        {
            return;
        }

          

        public bool LockSize
        {
            get
            {
                return m_bLockSize;
            }
            set
            {
                m_bLockSize = value;
            }

        }

        public bool LockPosition
        {
            get
            {
                return m_bLockPosition;
            }
            set
            {
                m_bLockPosition = value;
            }

        }


        public override Point Position
        {
            get
            {
                return SymboleContenu.Position;
            }
            set
            {
                if (!LockPosition)
                 if (SymboleContenu != null)
                    SymboleContenu.Position = value;
            }
        }



        public override Size Size
        {
            get
            {
                return SymboleContenu.Size;
            }
            set
            {
                if (!LockSize)
                    if(SymboleContenu!=null)
                         SymboleContenu.Size = value;
            }
        }


        public override void Draw(CContextDessinObjetGraphique ctx)
        {
            if(SymboleContenu!=null)
            SymboleContenu.Draw(ctx);
        }
    }
}
