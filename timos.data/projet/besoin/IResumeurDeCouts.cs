using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace timos.data.projet.besoin
{
    public interface IResumeurDeCouts : IElementACout
    {
        /// <summary>
        /// Retourne la liste des éléments qu'il faut sommer pour obtenir le cout résumé
        /// Il s'agit des éléments finaux, pour éviter de cumuler plusieurs fois le même coût dans un résumé donné
        /// </summary>
        /// <returns></returns>
        double GetCoutResume(bool bCoutReel);


    }
}
