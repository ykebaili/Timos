using System;
using System.Collections.Generic;
using System.Text;

using Lys.Licence;

using timos.securite;

namespace timos.serveur
{
    public class CInfoSession
    {
        public CUserLicencePrtct UserLicence;
        public CDonneesActeurUtilisateur ActeurUtilisateur;

        public CInfoSession(CDonneesActeurUtilisateur acteurUtilisateur, CUserLicencePrtct userLicence)
        {
            ActeurUtilisateur = acteurUtilisateur;
            UserLicence = userLicence;
        }
    }
}
