using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CamusatQowisioServerPlugin
{
    public class CFtpFileInfoComparer : IComparer<FtpFileInfo>
    {
        public CFtpFileInfoComparer()
        {
        }

        public int Compare(FtpFileInfo x, FtpFileInfo y)
        {
            if (x == null || y == null)
                return 0;

            return x.Name.CompareTo(y.Name);
        }


    }
}
