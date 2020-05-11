using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;


namespace timos.data
{
    public enum EExtremiteLienReseau
    {
        Un = 1,
        Deux = 2,
        
    }
    public class CExtremiteLienReseau : CEnumALibelle<EExtremiteLienReseau>
    {
        /// //////////////////////////////////////////////////////
        public CExtremiteLienReseau(EExtremiteLienReseau extremite)
            : base(extremite)
        {
        }

        //---------------------------------------------------------------
        /// <summary>
        /// Libellé de l'extrémité du lien : 'Première extrémité' ou 'Seconde extrémité' suivant qu'il s'agit respectivement de l'extrémité 1 ou de la 2 
        /// </summary>
        [DynamicField("Label")]
        public override string Libelle
        {
            get
            {
                switch (Code)
                {
                    case EExtremiteLienReseau.Un:
                        return I.T("First extremity|20069");
                    case EExtremiteLienReseau.Deux:
                        return I.T("Second extremity|20070");
                   
                }
                return "";
            }
        }
    }
}
