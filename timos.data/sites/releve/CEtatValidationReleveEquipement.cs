using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace timos.data.sites.releve
{
    public enum EEtatValidationReleveEquipement
    {
        None = 0,
        Validé = 10,
        Appliquée = 20
    };
    
    public class CEtatValidationReleveEquipement : CEnumALibelle<EEtatValidationReleveEquipement>
    {
        public CEtatValidationReleveEquipement(EEtatValidationReleveEquipement code)
            : base(code)
        {
        }

        [DynamicField("Label")]
        public override string Libelle
        {
            get
            {
                switch (Code)
                {
                    case EEtatValidationReleveEquipement.None:
                        return I.T("None|20222");
                    case EEtatValidationReleveEquipement.Validé:
                        return I.T("Validated|20223");
                    case EEtatValidationReleveEquipement.Appliquée:
                        return I.T("Applied|20224");
                }
                return "";
            }
        }
    }
}
