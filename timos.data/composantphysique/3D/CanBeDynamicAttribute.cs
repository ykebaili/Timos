using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace timos.data.composantphysique
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CanBeDynamicAttribute : Attribute
    {
    }
}
