using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.process.workflow;
using sc2i.data;

namespace timos.data.process.workflow
{
    [AutoExec("Autoexec")]


    public class CMethodeWorkflowGetCurrentProjectForStepType : CMethodeSupplementaire
    {
        /// <summary>
        /// ///////////////////////////////////////////
        /// </summary>
        private CMethodeWorkflowGetCurrentProjectForStepType()
            : base(typeof(CWorkflow))
        {
        }

        /// ///////////////////////////////////////////
        public static void Autoexec()
        {
            CGestionnaireMethodesSupplementaires.RegisterMethode(new CMethodeWorkflowGetCurrentProjectForStepType());
        }

        /// ///////////////////////////////////////////
        public override string Description
        {
            get
            {
                return I.T("Return current project associated to a step type (Step type is referenced by its universal ID|20150");
            }
        }

        /// ///////////////////////////////////////////
        public override CInfoParametreMethodeDynamique[] InfosParametres
        {
            get
            {
                return new CInfoParametreMethodeDynamique[]
                {
                    new CInfoParametreMethodeDynamique("Step type", I.T("Reference a Stef type Universal Id"), typeof(string))
                };
            }
        }

        /// ///////////////////////////////////////////
        public override string Name
        {
            get
            {
                return "GetCurrentProjectForStepType";
            }
        }

        /// ///////////////////////////////////////////
        public override Type ReturnType
        {
            get
            {
                return typeof(CProjet);
            }
        }

        /// ///////////////////////////////////////////
        public override bool ReturnArrayOfReturnType
        {
            get
            {
                return false;
            }
        }


        /// ///////////////////////////////////////////
        public override object Invoke(object objetAppelle, params object[] parametres)
        {
            CWorkflow workflow = objetAppelle as CWorkflow;
            if (workflow == null || parametres.Length ==0 || parametres[0] == null)
                return null;
            string strIdType = parametres[0].ToString();
            CTypeWorkflow typeWorkfow = workflow.TypeWorkflow;
            if (typeWorkfow == null)
                return null;
            CListeObjetsDonnees etapes = typeWorkfow.Etapes;
            etapes.Filtre = new CFiltreData(CObjetDonnee.c_champIdUniversel + "=@1",
                strIdType);
            if (etapes.Count == 0)
                return null;
            CTypeEtapeWorkflow typeEtape = etapes[0] as CTypeEtapeWorkflow;
            CEtapeWorkflow etape = workflow.GetEtapeForType(typeEtape);
            if (etape != null)
                return CGestionnaireProjetsDeWorkflow.GetProjetDirectementAssocie(etape);
            return null;
       }



    }
}