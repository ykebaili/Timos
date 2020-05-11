using sc2i.common;
using sc2i.common.sig;
using sc2i.expression;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace futurocom.sig
{
    public class CMapLineDessin : I2iSerializable
    {

        //Generateur d'items correspondant
        private CMapLineGenerator m_mapLineGenerator = null;

        //Index (ordre de test de la formule de condition dans L'item generator)
        private int m_nIndex = 0;

        private bool m_bPermanentToolTip = false;

        private C2iExpression m_formuleToolTip = null;
        private C2iExpression m_formuleCondition = null;

        private Color m_lineColor = Color.Blue;
        private int m_nLineWidth = 2;

        //------------------------------------------------------------------------------
        public CMapLineDessin()
        {
        }

        //------------------------------------------------------------------------------
        public CMapLineDessin(CMapLineGenerator lineGenerator)
        {
            m_mapLineGenerator = lineGenerator;
        }

        //-----------------------------------------------
        public CMapLineGenerator LineGenerator
        {
            get
            {
                return m_mapLineGenerator;
            }
            set
            {
                m_mapLineGenerator = value;
            }
        }


        //------------------------------------------------------------------------------
        public Color LineColor
        {
            get
            {
                return m_lineColor;
            }
            set
            {
                m_lineColor = value;
            }
        }

        //-----------------------------------------------
        public bool PermanentToolTip
        {
            get
            {
                return m_bPermanentToolTip;
            }
            set
            {
                m_bPermanentToolTip = value;
            }
        }


        //------------------------------------------------------------------------------
        public int LineWidth
        {
            get
            {
                return m_nLineWidth;
            }
            set
            {
                m_nLineWidth = value;
            }
        }

        //-----------------------------------------------
        public Type TypeElementsDessines
        {
            get
            {
                if (m_mapLineGenerator != null)
                    return m_mapLineGenerator.TypeElementsDessines;
                return null;
            }
        }

        //------------------------------------------------------------------------------
        public int Index
        {
            get
            {
                return m_nIndex;
            }
            set
            {
                m_nIndex = value;
            }
        }
        //------------------------------------------------------------------------------
        public C2iExpression FormuleToolTip
        {
            get
            {
                return m_formuleToolTip;
            }
            set
            {
                m_formuleToolTip = value;
            }
        }

        //------------------------------------------------------------------------------
        public C2iExpression FormuleCondition
        {
            get
            {
                return m_formuleCondition;
            }
            set
            {
                m_formuleCondition = value;
            }
        }

        
        //------------------------------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //------------------------------------------------------------------------------
        public CResultAErreur Serialize ( C2iSerializer serializer )
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            serializer.TraiteInt(ref m_nIndex);
            result = serializer.TraiteObject<C2iExpression>(ref m_formuleCondition);
            if (result)
                result = serializer.TraiteObject<C2iExpression>(ref m_formuleToolTip);
            if (!result)
                return result;
            
            int nCol = m_lineColor.ToArgb();
            serializer.TraiteInt(ref nCol);
            m_lineColor = Color.FromArgb(nCol);

            serializer.TraiteInt(ref m_nLineWidth);
            serializer.TraiteBool ( ref m_bPermanentToolTip );

            return result;

        }


        //---------------------------------------------------------------------------
        public bool GenereItem(
            object obj,
            double fLat1,
            double fLong1,
            double fLat2,
            double fLong2,
            CMapLayer layer)
        {
            CResultAErreur result = CResultAErreur.True;
            CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(this.m_mapLineGenerator);
            if (FormuleCondition != null && !(FormuleCondition is C2iExpressionVrai))
            {
                result = FormuleCondition.Eval(ctx);
                if (!result || result.Data == null)
                    return false;
                bool? bResult = CUtilBool.BoolFromString(result.Data.ToString());
                if (bResult == null || !bResult.Value)
                    return false;
            }
            string strLibelle = "";
            if (FormuleToolTip != null)
            {
                result = FormuleToolTip.Eval(ctx);
                if (result && result.Data != null)
                {
                    strLibelle = result.Data.ToString();
                }
            }


            CMapItemPath line = new CMapItemPath(layer);
            line.LineColor = LineColor;
            line.LineWidth = LineWidth;
            line.ToolTip = strLibelle;
            line.PermanentToolTip = m_bPermanentToolTip;
            line.Tag = obj;
            List<SLatLong> lstPts = new List<SLatLong>();
            lstPts.Add(new SLatLong(fLat1, fLong1));
            //lstPts.Add(new SLatLong((fLat1 + fLat2) / 2, (fLong1 + fLong2) / 2));
            lstPts.Add(new SLatLong(fLat2, fLong2));
            line.Points = lstPts;

            if (LineGenerator.ActionSurClick != null)
                line.MouseClicked += new MapItemClickEventHandler(OnMouseClick);


            return true;
        }

        public void OnMouseClick(IMapItem item)
        {
            if (LineGenerator != null && item != null)
                LineGenerator.OnMapItemClick(item);
        }


    }
}
