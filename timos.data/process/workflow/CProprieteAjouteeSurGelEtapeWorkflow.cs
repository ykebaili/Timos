using sc2i.common;
using sc2i.expression;
using sc2i.process.workflow.gels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using timos.acteurs;

namespace timos.data.process.workflow
{
    [AutoExec("Autoexec")]
    public class CProprieteAjouteeSurGelEtapeWorkflow
    {
        public static void Autoexec()
        {
            CGestionnaireProprietesAjoutees.RegisterDynamicField(
                typeof(CGelEtapeWorkflow),
                "Freez_Start_Member",
                new CTypeResultatExpression(typeof(CActeur), false),
                new GetDynamicValueDelegate(GetActeurResponsableDebutGel),
                null,
                "");

            CGestionnaireProprietesAjoutees.RegisterDynamicField(
                typeof(CGelEtapeWorkflow),
                "Freez_End_Member",
                new CTypeResultatExpression(typeof(CActeur), false),
                new GetDynamicValueDelegate(GetActeurResponsableFinGel),
                null,
                "");
        }

        //-------------------------------------------------------------------------------
        public static object GetActeurResponsableDebutGel(object source)
        {
            CGelEtapeWorkflow gelEtape = source as CGelEtapeWorkflow;
            if (gelEtape == null)
                return null;
            
            CActeur acteur = new CActeur(gelEtape.ContexteDonnee);
            if(acteur.ReadIfExists(gelEtape.KeyResponsabelDebutGel))
                return acteur;

            return null;
        }

        //-------------------------------------------------------------------------------
        public static object GetActeurResponsableFinGel(object source)
        {
            CGelEtapeWorkflow gelEtape = source as CGelEtapeWorkflow;
            if (gelEtape == null)
                return null;

            CActeur acteur = new CActeur(gelEtape.ContexteDonnee);
            if (acteur.ReadIfExists(gelEtape.KeyResponsabelFinGel))
                return acteur;

            return null;
        }
    }
}
