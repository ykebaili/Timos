using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;

namespace timos.data
{
    [DynamicClass("Constraint owner")]
    public interface IPossesseurContrainte
    {
        [DynamicField("Label")]
        string Libelle { get;}
		List<CContrainte> ToutesLesContraintes { get;}
    }
}
