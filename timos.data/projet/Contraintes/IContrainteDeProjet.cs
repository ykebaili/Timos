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
    public interface IContrainteDeProjet : IContrainteDeGantt
    {
        /// <summary>
        /// Clé associée à la contrainte
        /// </summary>
        [DynamicField("Key")]
        string Cle { get; set; }

        /// <summary>
        /// Commentaire
        /// </summary>
        [DynamicFieldAttribute("Comment")]
        string Commentaire { get; set; }

    }
}
