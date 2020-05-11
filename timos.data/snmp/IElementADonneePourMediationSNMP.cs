using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace timos.data.snmp
{
    public interface IElementADonneePourMediationSNMP
    {

        /// <summary>
        /// REtourne la liste des id de proxys concernés par cet élément
        /// Retourne null si tous les proxys sont concernés
        /// </summary>
        int[] IdsProxysConcernesParDonneesMediation { get; }

        int[] IdsProxysConcernesParConfigurationProxy { get; }
    }
}
