using System;
using System.Collections.Generic;
using System.Text;
using sc2i.drawing;
using sc2i.common;
using sc2i.data;
using sc2i.expression;
using System.Drawing.Drawing2D;
using System.Drawing;
namespace timos.data
{
    [Serializable]
    public class C2iEtiquetteSchema : C2iObjetDeSchema
    {

      


        public Color BorderColor
        {
            get
            {
                return DonneeDessinEtiquette.BorderColor;
            }

            set
            {
                DonneeDessinEtiquette.BorderColor = value;
            }

        }


        public Color BackColor
        {
            get
            {
                return DonneeDessinEtiquette.BackColor;
            }

            set
            {
                DonneeDessinEtiquette.BackColor = value;
            }

        }


        public Color TextColor
        {
            get
            {
                return DonneeDessinEtiquette.TextColor;
            }

            set
            {
               DonneeDessinEtiquette.TextColor = value;
            }

        }



        public ELabelBorderStyle BorderStyle
        {
            get
            {
                return DonneeDessinEtiquette.BorderStyle;
            }

            set
            {
               DonneeDessinEtiquette.BorderStyle = value;
            }

        }

        public int BorderWidth
        {
            get
            {
                return DonneeDessinEtiquette.BorderWidth;
            }

            set
            {
                DonneeDessinEtiquette.BorderWidth = value;
            }

        }

        public Font Font
        {
            get
            {
                return DonneeDessinEtiquette.Font;
            }
            set
            {
                DonneeDessinEtiquette.Font = value;
            }
        }

        public ContentAlignment TextAlign
        {
            get
            {
                return DonneeDessinEtiquette.TextAlign;
            }

            set
            {
                DonneeDessinEtiquette.TextAlign = value;
            }
        }

        public bool DrawLine
        {
            get
            {
                return DonneeDessinEtiquette.DrawLine;
            }
            set
            {
                DonneeDessinEtiquette.DrawLine = value;
            }
        }


        public C2iExpression Formula
        {
            get
            {
                return DonneeDessinEtiquette.Formula;
            }

            set
            {
                DonneeDessinEtiquette.Formula = value;
            }
        }


        [System.ComponentModel.Browsable(false)]
        public int IdObjetAssocie
        {
            get
            {
                return DonneeDessinEtiquette.IdObjetAssocie;
            }

            set
            {
                DonneeDessinEtiquette.IdObjetAssocie = value;
            }

        }




         public  C2iEtiquetteSchema()
            : base()
        {
                        
        }


        


        //------------------------------------     
        protected override IDonneeDessinElementDeSchemaReseau AlloueDonneeDessin()
        {
            return new CDonneeDessinEtiquetteSchema(-1);
        }

        //------------------------------------     
        private CDonneeDessinEtiquetteSchema DonneeDessinEtiquette
        {
            get
            {
                return DonneeDessin as CDonneeDessinEtiquetteSchema;
            }
        }


        //retourne l'objet de schéma associé à l'étiquette
        [System.ComponentModel.Browsable(false)]
        public C2iObjetDeSchema ObjetSchemaAssocie
        {
            get
            {
                
                C2iSchemaReseau schema = Parent as C2iSchemaReseau;
                if (schema != null)
                {
                    return schema.GetChildFromId(IdObjetAssocie);

                }
                else
                    return null;
            }
        }



        //
        public string GetTextResult()
        {
            string texte = "";

            

            if (ObjetSchemaAssocie !=null&& Formula !=null)
            {
                if (ObjetSchemaAssocie.ElementDeSchema != null)
                {
                    if (ObjetSchemaAssocie.ElementDeSchema.ElementAssocie != null)
                    {
                        CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(ObjetSchemaAssocie.ElementDeSchema.ElementAssocie);
                        CResultAErreur result = Formula.Eval(ctx);
                        if (result && result.Data != null)
                            texte = result.Data.ToString();
                    }
                }

            }
            return texte;

        }

        protected override void MyDraw(CContextDessinObjetGraphique ctx)
        {
            Graphics g = ctx.Graphic;
            
            if (ObjetSchemaAssocie != null && DrawLine)
            {
                DrawLineToObjet(ctx);
            }
            Brush b = new SolidBrush(BackColor);
            Rectangle rect = new Rectangle(Position, Size);
            g.FillRectangle(b, rect);
            b.Dispose();
            DrawCadre(g);
            DrawTexte(g);
            base.MyDraw(ctx);
        }

        private void DrawLineToObjet(CContextDessinObjetGraphique ctx)
        {
            Graphics g = ctx.Graphic;
            Pen pen = new Pen(BorderColor);
            Point pt1 = ObjetSchemaAssocie.GetCenterPoint();
            Point pt2 = new Point(Position.X + Size.Width / 2, Position.Y + Size.Height / 2);
            g.DrawLine(pen, pt1, pt2);
            pen.Dispose();
        }


        
         /// /////////////////////////////////////////////////
        protected void DrawCadre(Graphics g)
        {
             
            if (BorderStyle == ELabelBorderStyle.Border)
            {
                Rectangle rect = new Rectangle(Position.X, Position.Y, Size.Width, Size.Height);
                Pen pen = new Pen(BorderColor);
                pen.Width = BorderWidth;
                g.DrawRectangle(pen, rect);
                DrawTexte(g);
                pen.Dispose();
            }

        }

        /// ///////////////////////
        protected void DrawTexte(Graphics g)
        {
            //Graphics g = ctx.Graphic;
            if (Font == null)
                return;
            string text = GetTextResult();
            if (text == "")
                return;

            Brush br = new SolidBrush(TextColor);
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Near;
            format.Alignment = StringAlignment.Near;

            switch (TextAlign)
            {
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomRight:
                    format.LineAlignment = StringAlignment.Far;
                    break;
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleRight:
                    format.LineAlignment = StringAlignment.Center;
                    break;
            }
            switch (TextAlign)
            {
                case ContentAlignment.BottomCenter:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.TopCenter:
                    format.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.TopRight:
                    format.Alignment = StringAlignment.Far;
                    break;
            }

            Rectangle rect = new Rectangle(Position.X, Position.Y, Size.Width, Size.Height);
               
            g.DrawString(text, Font, br, rect, format);
            br.Dispose();
        }



    }
}
