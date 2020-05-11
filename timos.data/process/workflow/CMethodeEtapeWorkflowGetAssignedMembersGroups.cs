using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.process.workflow;
using sc2i.data;
using timos.acteurs;
using timos.securite;

namespace timos.data.process.workflow
{
    [AutoExec("Autoexec")]
    public class CMethodeEtapeWorkflowGetAssignedMembersGroups : CMethodeSupplementaire
    {
        /// <summary>
        /// ///////////////////////////////////////////
        /// </summary>
        private CMethodeEtapeWorkflowGetAssignedMembersGroups()
            : base(typeof(CEtapeWorkflow))
        {
        }

        /// ///////////////////////////////////////////
        public static void Autoexec()
        {
            CGestionnaireMethodesSupplementaires.RegisterMethode(new CMethodeEtapeWorkflowGetAssignedMembersGroups());
        }

        /// ///////////////////////////////////////////
        public override string Description
        {
            get
            {
                return I.T("Return a list of groupes assigned to the current Step|20230");
            }
        }

        /// ///////////////////////////////////////////
        public override CInfoParametreMethodeDynamique[] InfosParametres
        {
            get
            {
                return new CInfoParametreMethodeDynamique[] { };
            }
        }

        /// ///////////////////////////////////////////
        public override string Name
        {
            get
            {
                return "GetAssignedMembersGroups";
            }
        }

        /// ///////////////////////////////////////////
        public override Type ReturnType
        {
            get
            {
                return typeof(CGroupeActeur);
            }
        }

        /// ///////////////////////////////////////////
        public override bool ReturnArrayOfReturnType
        {
            get
            {
                return true;
            }
        }

        /// ///////////////////////////////////////////
        public override object Invoke(object objetAppelle, params object[] parametres)
        {
            CEtapeWorkflow etape = objetAppelle as CEtapeWorkflow;

            if (etape == null || parametres.Length > 0)
                return null;

            List<CGroupeActeur> listeGroupes = new List<CGroupeActeur>();
            List<IAffectableAEtape> listeAffectables = new List<IAffectableAEtape>(etape.Assignments);
            foreach (IAffectableAEtape affectable in listeAffectables)
            {
                CGroupeActeur groupe = affectable as CGroupeActeur;
                if (groupe!= null)
                {
                    listeGroupes.Add(groupe);
                }
            }

            return listeGroupes.ToArray();
        }

    }
}