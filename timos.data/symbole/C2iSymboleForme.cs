using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

using sc2i.common;
using sc2i.drawing;


namespace timos.data
{
    [Serializable]
   public class C2iSymboleForme : C2iSymbole
    {

        public enum PanelBorderStyle
        {
           None,
           Border
        }

        public enum PanelFillStyle
        {
            Solid,
            HatchBrush

        }

       protected PanelBorderStyle m_borderStyle = PanelBorderStyle.Border;

       protected float[] m_customDashPattern = { 1.0f, 1.0f, 1.0f, 1.0f };

       protected System.Drawing.Drawing2D.DashStyle m_lineStyle = System.Drawing.Drawing2D.DashStyle.Solid;

       protected int m_borderWidth = 1;

       protected Size m_gridSize = new Size(8, 8);

       protected PanelFillStyle m_fillStyle = PanelFillStyle.Solid;

       protected HatchStyle? m_hatchStyle = null;


       public C2iSymboleForme()
       {
           Size = new Size(64, 16);
           BackColor = Color.White;
       }

 

    public HatchStyle? HatchBrushStyle
    {
        get
        {
            return m_hatchStyle;
        }
        set
        {
            m_hatchStyle = value;
        }

    }

        public PanelBorderStyle BorderStyle
        {
            get
            {
                return m_borderStyle;
            }
            set
            {
                m_borderStyle = value;


            }
        }

        public System.Drawing.Drawing2D.DashStyle LineStyle
        {
            get
            {
                return m_lineStyle;
            }
            set
            {
                m_lineStyle = value;

            }
        }

        public int BorderWidth
        {

            get
            {
                return m_borderWidth;
            }
            set
            {
                m_borderWidth = value;

            }

        }

        public float[] LineDashPattern
        {
            get
            {
                return m_customDashPattern;
            }

            set
            {
              m_customDashPattern = value;
            }

        }


        public override bool AcceptChilds
        {
            get
            {
                return true;
            }
        }


        /// ///////////////////////////////////////
        public Size GridSize
        {
            get
            {
                return m_gridSize;
            }
            set
            {
                m_gridSize = value;
            }
        }

        /// ///////////////////////////////////////
        public override Point Magnetise(Point pt)
        {
            Point newPt = pt;
            if (m_gridSize.Width > 1)
                newPt.X = (int)(Math.Round((double)(newPt.X / m_gridSize.Width)) * m_gridSize.Width);
            if (m_gridSize.Height > 1)
                newPt.Y = (int)(Math.Round((double)(newPt.Y / m_gridSize.Height)) * m_gridSize.Height);
            return newPt;
        }

        /// ///////////////////////
        [System.ComponentModel.Browsable(false)]
        protected override Point OrigineCliente
        {
            get
            {
                if (BorderStyle == PanelBorderStyle.None)
                    return new Point(0, 0);
                else
                    return new Point(1, 1);
            }
        }


        /// ///////////////////////////////////////
        [System.ComponentModel.Browsable(false)]
        protected override Size ClientSize
        {
            get
            {
                Size sz = Size;
                if (BorderStyle != PanelBorderStyle.None)
                {
                    sz.Width -= 2;
                    sz.Height -= 2;
                }

                return sz;
            }
        }


       private int GetNumVersion()
       {
           return 4;
       }


       protected override CResultAErreur MySerialize(C2iSerializer serializer)
       {
           //return CResultAErreur.True;
           int nVersion = GetNumVersion();
           CResultAErreur result = serializer.TraiteVersion(ref nVersion);
           if (!result)
               return result;

           result = base.MySerialize(serializer);
           if (!result)
               return result;

           int nTmp = m_gridSize.Width;
           serializer.TraiteInt(ref nTmp);
           m_gridSize.Width = nTmp;

           nTmp = m_gridSize.Height;
           serializer.TraiteInt(ref nTmp);
           m_gridSize.Height = nTmp;


           int nStyle = (int)m_borderStyle;
           serializer.TraiteInt(ref nStyle);
           m_borderStyle = (PanelBorderStyle)nStyle;

           serializer.TraiteInt(ref m_borderWidth);
      
           int nLineStyle = (int)m_lineStyle;
           serializer.TraiteInt(ref nLineStyle);
           m_lineStyle = (System.Drawing.Drawing2D.DashStyle)nLineStyle;

           if (nVersion < 2)
           {
               int nFillStyle = (int)m_fillStyle;
               serializer.TraiteInt(ref nFillStyle);
               m_fillStyle = (PanelFillStyle)nFillStyle;

           }

           if(nVersion >3)
           {
                int? nVal = (int?)m_hatchStyle;
                bool bHasVal = nVal != null;
                serializer.TraiteBool(ref bHasVal);
                if (bHasVal)
                {
                    nTmp = nVal != null ? nVal.Value : 0;
                    serializer.TraiteInt(ref nTmp);
                    m_hatchStyle = (HatchStyle?)nTmp;
                }
                else
                {
                    nVal = null;
                    m_hatchStyle = (HatchStyle?)nVal;
                }


                IList listTmp = new ArrayList();
                for (int i = 0; i < 4; i++)
                {
                    double dTmp = (double)m_customDashPattern[i];
                    listTmp.Add((object)dTmp);
                }
                serializer.TraiteListeObjetsSimples(ref listTmp);
                if (serializer.Mode == ModeSerialisation.Lecture)
                {
                    for (int i = 0; i < 4; i++)

                        m_customDashPattern[i] = (float)(double)listTmp[i];
                }
                return result;
           }
  
           return result;

       }
    }
}
