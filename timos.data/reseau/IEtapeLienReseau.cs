using System;
using System.Collections.Generic;
using System.Text;

namespace timos.data
{
    /// <summary>
    /// Tout élément qui peut faire partie du chemin d'un lien réseau
    /// </summary>
    public interface IEtapeLienReseau
    {
        IElementALiensReseau[] ElementsALiensContenus{get;}
        IEtapeLienReseau[] EtapesContenues{get;}
        string Libelle { get;}
    }
}
