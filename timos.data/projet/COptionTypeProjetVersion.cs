using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace timos.data.projet
{
    public enum EOptionTypeProjetVersion
    {
        NoVersion = 0,
        VersionManuelle = 1,
        VersionAutomatique = 2
    }

    public class COptionTypeProjetVersion : CEnumALibelle<EOptionTypeProjetVersion>
    {
        //-------------------------------------------------------------------
        public COptionTypeProjetVersion(EOptionTypeProjetVersion option)
            : base(option)
        {
        }

        //-------------------------------------------------------------------
        public override string Libelle
        {
            get {
                switch (Code)
                {
                    case EOptionTypeProjetVersion.NoVersion:
                        return I.T("No version|20112");
                        break;
                    case EOptionTypeProjetVersion.VersionManuelle:
                        return I.T("Manual création|20113");
                        break;
                    case EOptionTypeProjetVersion.VersionAutomatique:
                        return I.T("Automatic creation|20114");
                        break;
                    default:
                        break;
                }
                return "";
            }
        }
    }
}
