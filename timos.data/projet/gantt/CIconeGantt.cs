using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace timos.data.projet.gantt
{
    public class CIconeGantt
    {
        private Image m_image = null;
        private string m_strTooltip = "";

        public CIconeGantt()
        {
        }

        public CIconeGantt(Image img, string strTooltip)
        {
            m_image = img;
            m_strTooltip = strTooltip;
        }


        public Image Image
        {
            get
            {
                return m_image;
            }
        }

        public string Tooltip
        {
            get
            {
                return m_strTooltip;
            }
        }
    }
}
