using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.expression;
using sc2i.process.workflow;

namespace timos.data.process.workflow
{
    [AutoExec("Autoexec")]
    public static class CProprieteAjouteeEtape_ProjetAssocie
    {
        public static void Autoexec()
        {
            CGestionnaireProprietesAjoutees.RegisterDynamicField ( 
                typeof(CEtapeWorkflow),
                "Step generated project",
                new CTypeResultatExpression(typeof(CProjet), false ),
                new GetDynamicValueDelegate(GetProjetGenereParEtape),
                null,
                "");

            CGestionnaireProprietesAjoutees.RegisterDynamicField(
                typeof(CWorkflow),
                "Current project",
                new CTypeResultatExpression(typeof(CProjet), false),
                new GetDynamicValueDelegate(GetWorkflowCurrentProject),
                null,
                "");
        }

        public static object GetProjetGenereParEtape(object source)
        {
            CEtapeWorkflow etape = source as CEtapeWorkflow;
            if (etape == null)
                return null;
            return CGestionnaireProjetsDeWorkflow.GetProjetDirectementAssocie(etape);
        }

        public static object GetWorkflowCurrentProject(object source)
        {
            CWorkflow wkf = source as CWorkflow;
            if (wkf != null && wkf.EtapeAppelante != null)
            {
                return CGestionnaireProjetsDeWorkflow.FindProjetAssocie(wkf.EtapeAppelante);
            }
            return null;
        }



    }
}
