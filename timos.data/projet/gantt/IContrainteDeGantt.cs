using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using sc2i.common;

namespace timos.data.projet.Contraintes
{
    /// <summary>
    /// 
    /// </summary>
    public interface IContrainteDeGantt
    {
        [DynamicField("Date")]
        DateTime Date { get; set; }
        [DynamicField("Mode")]
        CModeContrainteDeGantt Mode { get; set; }
        [DynamicField("Owned")]
        bool ContraintePropre { get; }
    }
}
