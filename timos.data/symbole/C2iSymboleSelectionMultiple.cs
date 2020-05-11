using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;


using sc2i.common;
using sc2i.drawing;
using sc2i.formulaire;
namespace timos.data
{
    [Serializable]
    public class C2iSymboleSelectionMultiple : C2iSymbole
    {
        public C2iSymboleSelectionMultiple()
        {
            
        }



        public override bool AddChild(I2iObjetGraphique child)
        {
            
            bool bchild = base.AddChild(child);
            Redimensionner();
           // child.Position = position;
             
            return bchild;
        }


   /*     public override Point Position
        {
            get
            {
                 return base.Position;
            }
            set
            {
                Point oldPos = Position;
                base.Position = value;
                int depX = value.X - oldPos.X;
                int depY =value.Y - oldPos.Y;
                foreach (C2iSymbole symb in Childs)
                {
                   Point newPos = new Point(symb.Position.X+ depX, symb.Position.Y +depY);
                   symb.Position = newPos;
               }
            }
        }*/

        public override Size Size
        {
            get
            {
                return base.Size;
            }
            set
            {
                System.Drawing.Size previousSize = Size;
                System.Drawing.Size newSize=value;
                double dVScale = (double)newSize.Height / (double)previousSize.Height;
                double dHScale = (double)newSize.Width / (double)previousSize.Width;
                base.Size = value;
                foreach (C2iSymbole symb in this.Childs)
                {
                    System.Drawing.Size reSize = new Size((int)((double)symb.Size.Width * dHScale),(int)((double)symb.Size.Height * dVScale));
                    symb.Size = reSize;
                     Point newPos=new Point((int)((double)symb.Position.X * dHScale),(int)((double)symb.Position.Y*dVScale));
                    symb.Position = newPos;
                }
                  
            }
        }
        
        public void Redimensionner()
        {
          int nBottom = 0;
          int nRight = 0;
          int nLeft = int.MaxValue;
          int nTop = int.MaxValue;
          
           foreach (I2iObjetGraphique symbole in this.Childs)
           {
               nLeft = Math.Min(nLeft, symbole.Position.X);
               nRight = Math.Max(nRight, symbole.Position.X + symbole.Size.Width);
               nTop = Math.Min(nTop, symbole.Position.Y);
               nBottom = Math.Max(nBottom, symbole.Position.Y + symbole.Size.Height);

            }

            Point newPosition = new Point(nLeft, nTop);
            base.Position = newPosition;
            System.Drawing.Size newSize = new System.Drawing.Size((nRight - nLeft), (nBottom - nTop));
            base.Size = newSize;
           

        }


    }
    
}



