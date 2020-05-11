using System;
using System.Collections.Generic;
using System.Text;

namespace timos.data
{
    /// <summary>
    /// Tout �l�ment qui peut �tre plac� sur un sch�ma de r�seau
    /// (sites, equipements, liens, sch�mas de r�seau)
    /// </summary>
    public interface IElementDeSchemaReseau : IElementASymbolePourDessin
    {
        /// <summary>
        /// Cr�e l'objet de sch�ma correspondant � cet �l�ment
        /// </summary>
        /// <param name="cElementDeSchemaReseau"></param>
        /// <returns></returns>
        C2iObjetDeSchema GetObjetDeSchema(CElementDeSchemaReseau cElementDeSchemaReseau);
    }

}
