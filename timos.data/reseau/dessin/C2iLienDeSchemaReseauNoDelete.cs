using System;
using System.Collections.Generic;
using System.Text;
using sc2i.drawing;
using sc2i.common;
using sc2i.data;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Collections;

namespace timos.data
{
    public class C2iLienDeSchemaReseauNoDelete : C2iLienDeSchemaReseau
    {

        //cette classe sert � repr�senter le lien �dit� dans le dessin du sch�lma associ� � ce lien
        //

        public  C2iLienDeSchemaReseauNoDelete()
            : base()
        {

        }

        //lien �dit�
        private CLienReseau m_lienReseau;
        

        public CLienReseau LienReseau
        {
            get
            {
                return m_lienReseau;
            }
            set
            {
                m_lienReseau = value;
            }
        }

       
        //on emp�che de supprimer le lien du sch�ma
        public override bool NoDelete
        {
            get
            {
                return true;
            }
        }

        protected override void MyDraw(CContextDessinObjetGraphique ctx)
        {

           if(LienReseau==null)
               return;
            if(LienReseau.SchemaReseau==null)
                return;

            ForeColor = Color.Cyan ;
            LineWidth = 2;

              //Trouve l'objet de sch�ma associ� � elt 1 et � elt2
            C2iObjetDeSchema objet1 = null;
            C2iObjetDeSchema objet2 = null;

            IElementALiensReseau elt1=LienReseau.Element1;
            IElementALiensReseau elt2=LienReseau.Element2;

            bool bTmp = false;
            objet1 = GetObjetElement(elt1, ref bTmp);
            objet2 = GetObjetElement(elt2, ref bTmp);
           

           if (objet1 == null || objet2 == null)
               return;

           //on interdit de supprimer les �l�ments � l'extr�mit� du lien
           objet1.SetNoDelete(true);
           objet2.SetNoDelete(true);

            //calcul des extr�mit�s du lien
            Point pt1 = new Point(objet1.Position.X + objet1.Size.Width / 2,
                   objet1.Position.Y + objet1.Size.Height / 2);

            Point pt2 = new Point(objet2.Position.X + objet2.Size.Width / 2,
                objet2.Position.Y + objet2.Size.Height / 2);


             Position = new Point(Math.Min(pt1.X, pt2.X), Math.Min(pt1.Y, pt2.Y));
             Size = new Size(Math.Abs(pt2.X - pt1.X), Math.Abs(pt2.Y - pt1.Y));
            //dessin du lien
             Pen pen = new Pen(ForeColor, LineWidth);
             ctx.Graphic.DrawLine(pen, pt1, pt2);
             DrawFleches(ctx, pen,null, pt1, pt2,LienReseau.Direction);



             pen.Dispose();

            

        }


       

       

      
    }
}
