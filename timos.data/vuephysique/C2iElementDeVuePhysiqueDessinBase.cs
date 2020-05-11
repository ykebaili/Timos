using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.drawing;
using System.Drawing;
using sc2i.common;

namespace timos.data.vuephysique
{
    public abstract class C2iElementDeVuePhysiqueDessinBase : C2iElementDeVuePhysique
    {
        public enum EBorderStyle
        {
            None,
            Border
        }
        private Color m_backColor = Color.White;
        private Color m_foreColor = Color.Black;
        private EBorderStyle m_borderStyle = EBorderStyle.Border;

        private List<I2iObjetGraphique> m_listeChilds = new List<I2iObjetGraphique>();

        public C2iElementDeVuePhysiqueDessinBase()
            : base()
        {
        }

        //--------------------------------------------------------------------
        public override bool AcceptChilds
        {
            get
            {
                return true;
            }
        }
        //--------------------------------------------------------------------
        public override bool AddChild(sc2i.drawing.I2iObjetGraphique child)
        {
            if ( !m_listeChilds.Contains ( child ) )
                m_listeChilds.Add(child);
            return true;
        }

        //--------------------------------------------------------------------
        public override void BringToFront(sc2i.drawing.I2iObjetGraphique child)
        {
            if (m_listeChilds.Contains(child))
            {
                m_listeChilds.Remove(child);
                m_listeChilds.Add(child);
            }
            
        }

        //--------------------------------------------------------------------
        public override I2iObjetGraphique[] Childs
        {
            get { return m_listeChilds.ToArray(); }
        }

        //--------------------------------------------------------------------
        public override bool ContainsChild(sc2i.drawing.I2iObjetGraphique child)
        {
            return m_listeChilds.Contains(child);
        }

        //--------------------------------------------------------------------
        public override void RemoveChild(sc2i.drawing.I2iObjetGraphique child)
        {
            m_listeChilds.Remove(child);
        }

        //--------------------------------------------------------------------
        public override void FrontToBack(sc2i.drawing.I2iObjetGraphique child)
        {
            if (m_listeChilds.Contains(child))
            {
                m_listeChilds.Remove(child);
                m_listeChilds.Insert(0, child);
            }
        }


        //---------------------------------------
        public EBorderStyle BorderStyle
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

        //---------------------------------------
        public Color BackColor
        {
            get
            {
                return m_backColor;
            }
            set
            {
                int nTransparence = Transparency;
                m_backColor = Color.FromArgb(nTransparence, value.R, value.G, value.B);
            }
        }

        
        //---------------------------------------
        public Color ForeColor
        {
            get
            {
                return m_foreColor;
            }
            set
            {
                m_foreColor = value;
            }
        }

        //---------------------------------------
        public int Transparency
        {
            get
            {
                return m_backColor.A;
            }
            set
            {
                m_backColor = Color.FromArgb(Math.Min(0, Math.Max(255, value)),
                    BackColor.R,
                    BackColor.G,
                    BackColor.B);
            }
        }

        //---------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }
    
        //----------------------------------------
        protected override CResultAErreur MySerialize(sc2i.common.C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = base.MySerialize(serializer);
            if (!result)
                return result;

            int nCol = BackColor.ToArgb();
            serializer.TraiteInt(ref nCol);
            m_backColor = Color.FromArgb(nCol);

            nCol = ForeColor.ToArgb();
            serializer.TraiteInt(ref nCol);
            m_foreColor = Color.FromArgb(nCol);

            int nBorder = (int)BorderStyle;
            serializer.TraiteInt(ref nBorder);
            BorderStyle = (EBorderStyle)nBorder;

            result = serializer.TraiteListe<I2iObjetGraphique>(m_listeChilds);

            return result;
        }




    }
}
