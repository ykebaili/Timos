using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace timos.data
{
    /// <summary>
    /// Indique que la classe ne supporte pas les macros
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class NoMacroAttribute : Attribute
    {
    }
}
