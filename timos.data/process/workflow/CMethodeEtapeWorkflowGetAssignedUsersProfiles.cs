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
    public class CMethodeEtapeWorkflowGetAAssignedUsersProfiles : CMethodeSupplementaire
    {
        /// <summary>
        /// ///////////////////////////////////////////
        /// </summary>
        private CMethodeEtapeWorkflowGetAAssignedUsersProfiles()
            : base(typeof(CEtapeWorkflow))
        {
        }

        /// ///////////////////////////////////////////
        public static void Autoexec()
        {
            CGestionnaireMethodesSupplementaires.RegisterMethode(new CMethodeEtapeWorkflowGetAAssignedUsersProfiles());
        }

        /// ///////////////////////////////////////////
        public override string Description
        {
            get
            {
                return I.T("Return a list of profiles assigned to the current Step|20231");
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
                return "GetAssignedUsersProfiles";
            }
        }

        /// ///////////////////////////////////////////
        public override Type ReturnType
        {
            get
            {
                return typeof(CProfilUtilisateur);
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

            List<CProfilUtilisateur> listeProfils = new List<CProfilUtilisateur>();
            List<IAffectableAEtape> listeAffectables = new List<IAffectableAEtape>(etape.Assignments);
            foreach (IAffectableAEtape affectable in listeAffectables)
            {
                CProfilUtilisateur profil = affectable as CProfilUtilisateur;
                if (profil != null)
                {
                    listeProfils.Add(profil);
                }
            }

            return listeProfils.ToArray();
        }

    }
}