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
    public class CMethodeEtapeWorkflowGetAssignedMembers : CMethodeSupplementaire
    {
        /// <summary>
        /// ///////////////////////////////////////////
        /// </summary>
        private CMethodeEtapeWorkflowGetAssignedMembers()
            : base(typeof(CEtapeWorkflow))
        {
        }

        /// ///////////////////////////////////////////
        public static void Autoexec()
        {
            CGestionnaireMethodesSupplementaires.RegisterMethode(new CMethodeEtapeWorkflowGetAssignedMembers());
        }

        /// ///////////////////////////////////////////
        public override string Description
        {
            get
            {
                return I.T("Return a list of Members assigned to the current Step|10034");
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
                return "GetAssignedMembers";
            }
        }

        /// ///////////////////////////////////////////
        public override Type ReturnType
        {
            get
            {
                return typeof(CActeur);
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

            List<CActeur> listeActeurs = new List<CActeur>();
            List<IAffectableAEtape> listeAffectables = new List<IAffectableAEtape>(etape.Assignments);
            foreach (IAffectableAEtape affectable in listeAffectables)
            {
                CActeur acteur = affectable as CActeur;
                if (acteur != null)
                {
                    listeActeurs.Add(acteur);
                }
                else
                {
                    CGroupeActeur groupe = affectable as CGroupeActeur;
                    if (groupe != null)
                    {
                        foreach (CRelationActeur_GroupeActeur relation in groupe.RelationsActeur)
                        {
                            listeActeurs.Add(relation.Acteur);
                        }
                    }
                    else
                    {
                        CProfilUtilisateur profil = affectable as CProfilUtilisateur;
                        if (profil != null)
                        {
                            CListeObjetDonneeGenerique<CActeur> lstActeursDansProfil =
                                new CListeObjetDonneeGenerique<CActeur>(etape.ContexteDonnee);
                            lstActeursDansProfil.Filtre = new CFiltreDataAvance(
                                CActeur.c_nomTable,
                                CDonneesActeurUtilisateur.c_nomTable + "." +
                                CRelationUtilisateur_Profil.c_nomTable + "." +
                                CProfilUtilisateur.c_nomTable + "." +
                                CProfilUtilisateur.c_champId + " = @1",
                                profil.Id);
                            foreach (CActeur acteurProfil in lstActeursDansProfil)
                            {
                                listeActeurs.Add(acteurProfil);
                            }
                        }
                    }
                }
            }

            return listeActeurs.ToArray();
        }

    }
}