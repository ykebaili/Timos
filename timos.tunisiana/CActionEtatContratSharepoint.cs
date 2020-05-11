using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.process;
using sc2i.process.serveur;
using sc2i.common;

namespace timos.tunisiana
{
    [AutoExec("Autoexec")]
    public class CActionEtatContratSharepoint : IActionSurServeur
    {
        public static void Autoexec()
        {
            CDeclencheurActionSurServeur.RegisterAction(new CActionEtatContratSharepoint());
        }

        #region IActionSurServeur Membres

        public string CodeType
        {
            get { return "TUN_SHAREPOINT_CNT_STATE"; }
        }

        public string Description
        {
            get { return "Récupérer l'état d'un contrat sharepoint"; }
        }

        public sc2i.common.CResultAErreur Execute(int nIdSession, System.Collections.Hashtable valeursParametres)
        {
            CResultAErreur result = CResultAErreur.True;
            result.Data =  "Test ";
            return result;
        }

        public string Libelle
        {
            get { return "Récupérer l'état contrat sharepoint"; }
        }

        public string[] NomsParametres
        {
            get { return new string[]{"Id contrat", "Champ à récuperer"}; }
        }

        #endregion
    }
}
