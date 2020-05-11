using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;
using sc2i.win32.common;
using sc2i.data.dynamic;
using sc2i.expression;

namespace spv.win32
{
    public interface IPanelEditListChampsExport : IControlALockEdition
    {
        //------------------------------------------
        CResultAErreur InitChamps(
            List<C2iChampExport> listChampsExport,
            Type typeObjet,
            CDefinitionProprieteDynamique champOrigine);

        //------------------------------------------
        CResultAErreur MajChamps();
    }
}
