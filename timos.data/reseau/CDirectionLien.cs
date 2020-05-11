using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;


namespace timos.data
{
    public enum EDirectionLienReseau
    {
        UnVersDeux = 0,
        DeuxVersUn = 1,
        Bidirectionnel = 2,
        
    }
    public class CDirectionLienReseau : CEnumALibelle<EDirectionLienReseau>
    {
        /// //////////////////////////////////////////////////////
        public CDirectionLienReseau(EDirectionLienReseau sens)
            : base(sens)
        {
        }

        //--------------------------------------------------------
        /// <summary>
        /// Libellé correspondant à la direction :
        /// <ul>
        /// <li>Element 1 -> Element 2</li>
        /// <li>Element 2 -> Element 1</li>
        /// <li>Bi-Directionnel</li>
        /// </ul>
        /// </summary>
        [DynamicField("Label")]
        public override string Libelle
        {
            get
            {
                switch (Code)
                {
                    case EDirectionLienReseau.UnVersDeux:
                        return I.T("Element 1 -> Element 2|30091");
                    case EDirectionLienReseau.DeuxVersUn:
                        return I.T("Element 2 -> Element 1|30092");
                    case EDirectionLienReseau.Bidirectionnel:
                        return I.T("Bi-Directionnal|30093");
                   
                }
                return "";
            }
        }
    }
}
