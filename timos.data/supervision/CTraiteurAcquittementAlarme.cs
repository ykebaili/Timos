using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using futurocom.supervision;
using sc2i.common;
using sc2i.data;

namespace timos.data.supervision
{
    [AutoExec("Autoexec")]
    public class CTraiteurAcquittementAlarme : ITraiteurAcquittementAlarme
    {

        public static void Autoexec()
        {
            CLocalAlarme.TraiteurAcquittement = new CTraiteurAcquittementAlarme();
            
        }
    
        public CResultAErreur AcquitteAlarme(string strIdAlarme, DateTime dateAcquittement, int nIdSession)
        {
            CResultAErreur result = CResultAErreur.True;
            using (CContexteDonnee context = new CContexteDonnee(nIdSession, true, false))
            {
                CAlarme alarmeAAcquitter = new CAlarme(context);
                if(alarmeAAcquitter.ReadIfExists(new CFiltreData(
                    CAlarme.c_champAlarmId + " = @1",
                    strIdAlarme)))
                {
                    bool bResult = alarmeAAcquitter.Acknowledge();
                    if (!bResult)
                        result.EmpileErreur(I.T("Error in Alarm @1 Acknowledge function|10021", alarmeAAcquitter.Libelle));
                }
                else
                    result.EmpileErreur(I.T("Alarm Id @1 not found|10022", strIdAlarme));
            }

            return result;
        }

    }
}
