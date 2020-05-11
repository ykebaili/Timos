using System;
using System.Collections.Generic;
using System.Text;

namespace timos.data
{
    /// <summary>
    /// Tout élément qui peut être placé sur un schéma de réseau
    /// (sites, equipements, liens, schémas de réseau)
    /// </summary>
    public interface IElementDeSchemaReseau : IElementASymbolePourDessin
    {
        /// <summary>
        /// Crée l'objet de schéma correspondant à cet élément
        /// </summary>
        /// <param name="cElementDeSchemaReseau"></param>
        /// <returns></returns>
        C2iObjetDeSchema GetObjetDeSchema(CElementDeSchemaReseau cElementDeSchemaReseau);
    }

}
