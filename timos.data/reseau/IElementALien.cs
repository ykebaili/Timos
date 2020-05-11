using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using timos.securite;
using sc2i.doccode;

namespace timos.data
{
    /// <summary>
    /// Tout élément qui peut être extremité d'un lien réseau
    /// </summary>
    [DynamicClass("Link end")]
    public interface IElementALiensReseau : IElementDeSchemaReseau
    {
        [DynamicChilds("Links",typeof(IElementALiensReseau))]
        CLienReseau[] Liens { get;}
        [DynamicChilds("Ingoing links", typeof(IElementALiensReseau))]
        CLienReseau[] LiensEntrants { get;}
        [DynamicChilds("Outgoing links", typeof(IElementALiensReseau))]
        CLienReseau[] LiensSortants { get;}
        [DynamicChilds("Possible complements", typeof(IElementALiensReseau))]
        IComplementElementALiensReseau[] ComplementsPossibles { get;}
        [DynamicField("Element type")]
        Type TypeElement { get;}
        [DynamicField("Complement type")]
        Type TypeComplement { get;}
        [DynamicField("Label")]
        string Libelle { get; set;}
        
    }


    [DynamicClass("Link complement")]
    public interface IComplementElementALiensReseau
    {
        [DynamicChilds("Links", typeof(IElementALiensReseau))]
        CLienReseau[] Liens { get;}
        [DynamicField("Label")]
        string Libelle { get; set;}
    }
}
