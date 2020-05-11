using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using futurocom.supervision;
using sc2i.common;
using sc2i.data;
using futurocom.snmp.mediation;
using sc2i.common.memorydb;
using sc2i.multitiers.client;
using futurocom.snmp;

namespace timos.data.supervision
{
    [AutoExec("Autoexec")]
    public class CTraiteurRetombeeManuelleAlarme : ITraiteurRetombeeManuelleAlarme
    {
        public static void Autoexec()
        {
            CLocalAlarme.m_traiteurRetombee = new CTraiteurRetombeeManuelleAlarme();
            
        }
    
        //-------------------------------------------------------------------------
        public CResultAErreur RetombageManuel(string strIdAlarme, int nIdSession)
        {
            CResultAErreur result = CResultAErreur.True;
            using (CContexteDonnee context = new CContexteDonnee(nIdSession, true, false))
            {
                CAlarme alarmeARetomber = new CAlarme(context);
                if (alarmeARetomber.ReadIfExists(new CFiltreData(
                    CAlarme.c_champAlarmId + " = @1",
                    strIdAlarme)))
                {
                    CMemoryDb db = CMemoryDbPourSupervision.GetMemoryDb(context);
                    CLocalAlarme alarme = alarmeARetomber.GetLocalAlarme(db, true);
                    if (alarme.EtatCode != EEtatAlarme.Close)
                        alarme.EtatCode = EEtatAlarme.Close;
                    result = CAlarme.TraiteAlarmesManuellement(nIdSession, db);
                    if (result)
                        CSnmpConnexion.DefaultInstance.RedescendAlarmes(db);
                }
                else
                    result.EmpileErreur(I.T("Alarm Id @1 not found|10022", strIdAlarme));
            }

            return result;
        }

    }
}
