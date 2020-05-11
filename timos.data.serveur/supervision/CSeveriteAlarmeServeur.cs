using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data.serveur;
using timos.data.supervision;
using sc2i.common;

namespace timos.data.serveur.supervision
{
    public class CSeveriteAlarmeServeur : CObjetServeur
    {

        public CSeveriteAlarmeServeur(int nIdSession)
            : base(nIdSession)
        {
        }
        

        public override string GetNomTable()
        {
            return CSeveriteAlarme.c_nomTable;
        }

        public override Type GetTypeObjets()
        {
            return typeof(CSeveriteAlarme);
        }

        public override CResultAErreur VerifieDonnees(sc2i.data.CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;

            CSeveriteAlarme severite = objet as CSeveriteAlarme;
            if (severite != null)
            {
                if (severite.Libelle.Trim() == string.Empty)
                    result.EmpileErreur(I.T("Alarm Severity Label connot be empty|10023"));
            }


            return result;
        }


        
    }
}
