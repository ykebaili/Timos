using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace timos.data.composantphysique
{
    /// <summary>
    /// Les C2iComposant3D qui savent prendre des fils à coordonnées
    /// </summary>
    public interface IComposantPourObjetACoordonnées
    {
        bool AddFilsWithIndex(C2iComposant3D composant, int nIndex);

        string[] PrefixesCoordonneeAssocies { get; set; }
    }
}
