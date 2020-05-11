using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.common.sig;
using sc2i.data;

namespace futurocom.sig
{
    public interface IMapItemGenerator : I2iSerializable
    {
        string GeneratorName { get; }
        string Libelle { get; set; }
        CMapDatabaseGenerator Generator { get; set; }
        CResultAErreur GenereItems(CMapDatabase database, CContexteDonnee ctxDonnee);
    }

    public interface IMapItemGenertorFromEntities : IMapItemGenerator
    {
        Type TypeElementsDessines { get; }
        object CurrentGeneratedItem { get; }
    }
}
