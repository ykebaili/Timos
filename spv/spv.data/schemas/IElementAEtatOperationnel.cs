using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data;

namespace spv.data
{
    /// <summary>
    /// Pour tous les éléments qui ont un coefficient opérationnel (entre 0 et 1)
    /// </summary>
    public interface IElementACoeffOperationnel : IObjetDonneeAIdNumerique
    {
        double CoefficientOperationnel { get; }
    }
}
