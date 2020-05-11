using System;
using System.Collections.Generic;
using System.Text;
using timos.securite;

using sc2i.common;

namespace timos.data
{
    [DynamicClass("Resource owner")]
    public interface IPossesseurRessource
    {
		[DynamicField("Label")]
        string Libelle {get;}
    }
}
