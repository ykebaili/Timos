using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using spv.data;
using sc2i.data;
using sc2i.win32.data;

namespace spv.win32
{
    public class CUtilCouleursAlarmes
    {
        public static ImageList GetImageListSeverity(int nSize)
        {
            Image[] images = CSpvAlarmcouleur.GetImageListSeverity(new Size(nSize, nSize), CSc2iWin32DataClient.ContexteCourant);
            ImageList lst = new ImageList();
            lst.Images.AddRange(images);
            return lst;
        }
    }
}
