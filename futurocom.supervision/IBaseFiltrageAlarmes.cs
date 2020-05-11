using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace futurocom.supervision
{
    public interface IBaseFiltrageAlarmes
    {
        IEnumerable<CLocalParametrageFiltrageAlarmes> ParametresFiltrage { get; }
    }
}
