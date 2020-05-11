using sc2i.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportDocsMyanmar
{
    public interface IElementDeFS : I2iSerializable
    {
        string Nom { get; set; }

        bool HasErreurImport();
        void ClearDataImport();

        CRepertoire RepertoireContenant { get; set; }
    }
}
