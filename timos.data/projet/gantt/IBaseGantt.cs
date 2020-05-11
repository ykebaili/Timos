using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using sc2i.common;

namespace timos.data.projet.gantt
{
    /// <summary>
    /// Objet capable de répondre aux requêtes necéssaires pour afficher
    /// une diagramme de Gantt
    /// </summary>
    public interface IBaseGantt
    {
        IEnumerable<IElementDeGantt> GetElements();
        void AppliqueParametreDessin(CParametreDessinLigneGantt parametre);

        

    }



}
