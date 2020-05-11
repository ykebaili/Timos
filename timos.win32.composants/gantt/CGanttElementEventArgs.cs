using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using timos.data.projet.gantt;
using System.Drawing;
using System.Windows.Forms;


namespace timos.win32.gantt
{
    public delegate void GanttElementEventHandler(object sender, CGanttElementEventArgs args);
    public delegate void MoveGanttElementDelegate(IElementDeGantt element, TimeSpan ts, TimeSpan? duree, bool bForceForThisElement);
    public delegate void OnMoveGanttElement(IElementDeGantt element);

    public class CGanttElementEventArgs
    {
        public readonly IElementDeGantt ElementGantt;
        public readonly Point MouseScreenPos;
        public readonly MouseButtons MouseButtons;

        public CGanttElementEventArgs(IElementDeGantt elementGantt,
            Point mouseScreenPos,
            MouseButtons buttons)
        {
            ElementGantt = elementGantt;
            MouseScreenPos = mouseScreenPos;
            MouseButtons = buttons;
        }
    }
}
