using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using System.Drawing;
using sc2i.expression;

namespace timos.data.projet.gantt.icones
{
    /// <summary>
    /// Indique s'il y a des warnings sur l'élement de gantt
    /// </summary>
    [NomConvivialParametreIconeGantt("Standard Warning Icon", true)]
    public class CParametreIconeGanttWarning : IParametreIconeGantt
    {

        private C2iExpression m_formuleTooltip = new C2iExpressionConstante(I.T("Warnings|10009"));

        //---------------------------------------------------------------------
        public CIconeGantt GetIcone(IElementDeGantt element)
        {
            if (element.HasWarnings)
            {
                string strTooltip = "";
                if (Tooltip != null)
                {
                    CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(element);
                    CResultAErreur result = Tooltip.Eval(ctx);
                    if (result)
                        strTooltip = result.Data.ToString();
                }
                return new CIconeGantt(Image, strTooltip);
            }
            return null;
        }

        //-----------------------------------------------------------------------
        public Image Image
        {
            get
            {
                return Resource.Icone_Warning;
            }
        }

        //----------------------------------------------------
        public C2iExpression Tooltip
        {
            get
            {
                return m_formuleTooltip;
            }
            set
            {
                m_formuleTooltip = value;
            }
        }

        //----------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //----------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
            if ( !result )
                return result;

            result = serializer.TraiteObject<C2iExpression>(ref m_formuleTooltip);

            return result;
        }

    }
}
