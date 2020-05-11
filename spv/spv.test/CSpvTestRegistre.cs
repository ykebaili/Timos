using System;
using System.Collections;
using sc2i.common;
using sc2i.multitiers.client;

namespace spv.test
{
    /// <summary>
    /// Description résumée de CTimosAppRegistre.
    /// </summary>
    public class CSpvTestRegistre : C2iMultitiersClientRegistre
    {
        public CSpvTestRegistre()
        {
        }


        public static string ClePrincipale
        {
            get
            {
                return "Software\\Futurocom\\timos\\";
            }
        }

        protected override string GetClePrincipale()
        {
            return ClePrincipale;
        }

        protected override bool IsLocalMachine()
        {
            return false;
        }
    }
}
