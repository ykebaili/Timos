using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using timos.securite;
using timos.acteurs;
using sc2i.common;
using sc2i.data;
using sc2i.multitiers.client;

namespace timos.data.securite
{
    /// <summary>
    /// 
    /// </summary>
    public interface IElementARestrictionsSpecifiques : 
        IObjetDonneeAIdNumerique,
        IObjetARestrictionSurEntite
    {
        List<CRelationElement_RestrictionSpecifique> ListeRestrictions { get; }

        void AddRestrictionFor ( CGroupeRestrictionSurType restriction,
            IElementDonnantDesRestrictions elementDonnantDesRestrictions );

        void RemoveRestrictionFor ( CGroupeRestrictionSurType restriction,
            IElementDonnantDesRestrictions elementDonnantDesRestrictions );
        
    }

    /// <summary>
    /// Utilitaire pour les éléments à Restrictions spécifiques
    /// </summary>
    public static class CUtilElementARestrictionsSpecifiques
    {
               
        /// <summary>
        /// 
        /// </summary>
        /// <param name="elt"></param>
        /// <returns></returns>
        public static List<CRelationElement_RestrictionSpecifique> GetRelationsRestrictions(IElementARestrictionsSpecifiques elt)
        {
            CListeObjetDonneeGenerique<CRelationElement_RestrictionSpecifique> rels = new CListeObjetDonneeGenerique<CRelationElement_RestrictionSpecifique>(elt.ContexteDonnee);
            rels.Filtre = new CFiltreData(
                CRelationElement_RestrictionSpecifique.c_champIdElement + "=@1 and " +
                CRelationElement_RestrictionSpecifique.c_champTypeElement + "=@2",
                elt.Id,
                elt.GetType().ToString());
            rels.PreserveChanges = true;
            return rels.ToList();
        }

        //---------------------------------------------------------------------------------------------
        public static CRelationElement_RestrictionSpecifique GetRelationForGroupeRestriction(IElementARestrictionsSpecifiques elt, CGroupeRestrictionSurType groupe)
        {
            CRelationElement_RestrictionSpecifique rel = new CRelationElement_RestrictionSpecifique(elt.ContexteDonnee);
            if (rel.ReadIfExists(new CFiltreData(
                CRelationElement_RestrictionSpecifique.c_champIdElement + "=@1 and " +
                CRelationElement_RestrictionSpecifique.c_champTypeElement + "=@2 and " +
                CGroupeRestrictionSurType.c_champId + "=@3",
                elt.Id,
                elt.GetType().ToString(),
                groupe.Id)))
                return rel;
            return null;
        }

        //---------------------------------------------------------------------------------------------
        public static void AddRestrictionForElementDonnantDesRestrictions(
            IElementARestrictionsSpecifiques elt,
            CGroupeRestrictionSurType groupe,
            IElementDonnantDesRestrictions elementDonnantDesRestrictions)
        {
            CRelationElement_RestrictionSpecifique rel = GetRelationForGroupeRestriction(elt, groupe);
            if (rel == null)
            {
                rel = new CRelationElement_RestrictionSpecifique(elt.ContexteDonnee);
                rel.CreateNewInCurrentContexte();
                rel.ElementLie = elt as CObjetDonneeAIdNumerique;
                rel.GroupeRestriction = groupe;
            }
            CRelationElement_RestrictionSpecifique_Application app = rel.GetRelationFor(elementDonnantDesRestrictions);
            if (app == null)
            {
                app = new CRelationElement_RestrictionSpecifique_Application(elt.ContexteDonnee);
                app.CreateNewInCurrentContexte();
                app.RelationElement_Restriction = rel;
                app.ElementARestrictions = elementDonnantDesRestrictions;
            }
        }

        //---------------------------------------------------------------------------------------------
        public static void RemoveRestrictionForElementDonnantDesRestrictions(
            IElementARestrictionsSpecifiques elt,
            CGroupeRestrictionSurType groupe,
            IElementDonnantDesRestrictions elementDonnantDesRestrictions)
        {
            CRelationElement_RestrictionSpecifique rel = GetRelationForGroupeRestriction(elt, groupe);
            if (rel != null)
            {
                CRelationElement_RestrictionSpecifique_Application app = rel.GetRelationFor(elementDonnantDesRestrictions);
                if (app != null)
                    app.Delete(true);
            }
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Complete les restrictions pour un objet donné
        /// </summary>
        /// <param name="restriction"></param>
        public static void CompleteRestriction(IElementARestrictionsSpecifiques element, CRestrictionUtilisateurSurType restriction)
        {
            List<CRelationElement_RestrictionSpecifique> lst = GetRelationsRestrictions(element);
            if (lst.Count == 0)
                return;

            CContexteDonnee contexte = element.ContexteDonnee;
            CSessionClient session = CSessionClient.GetSessionForIdSession(contexte.IdSession);
            IInfoUtilisateur info = null;
            //TESTDBKEYTODO
            CDbKey keyUtilisateur = null;
            if (session != null)
            {
                info = session.GetInfoUtilisateur();
                if (info == null)
                    return;
                if (info.GetDonneeDroit(CDroitDeBaseSC2I.c_droitAdministration) != null)
                    return;
                keyUtilisateur = info.KeyUtilisateur;
            }

            //Application des restrictions qui s'appliquent à tout le monde
            foreach (CRelationElement_RestrictionSpecifique rel in lst.ToArray())
            {
                if (rel.Applications.Count == 0)
                {
                    CListeRestrictionsUtilisateurSurType liste = rel.GroupeRestriction.ListeRestrictions;
                    CRestrictionUtilisateurSurType resTmp = liste.GetRestriction(element.GetType());
                    restriction.Combine(resTmp);
                    lst.Remove(rel);
                }
            }
            if (lst == null || lst.Count == 0 || info == null)
                return;


            CDonneesActeurUtilisateur user = new CDonneesActeurUtilisateur(contexte);

            if (user.ReadIfExists(keyUtilisateur))
            {
                CActeur acteur = user.Acteur;
                while (acteur != null)
                {
                    foreach (CRelationElement_RestrictionSpecifique rel in lst.ToArray())
                    {
                        CRelationElement_RestrictionSpecifique_Application app = rel.GetRelationFor(acteur);
                        if (app != null)
                        {
                            CListeRestrictionsUtilisateurSurType restrictions = rel.GroupeRestriction.ListeRestrictions;
                            CRestrictionUtilisateurSurType resTmp = restrictions.GetRestriction(element.GetType());
                            restriction.Combine(resTmp);
                            lst.Remove(rel);
                        }

                    }
                    acteur = acteur.ActeurParent;
                }
                acteur = user.Acteur;
                if (lst.Count == 0)
                    return;

                foreach (CGroupeActeur groupe in acteur.TousLesGroupesActeur)
                {
                    foreach (CRelationElement_RestrictionSpecifique rel in lst.ToArray())
                    {
                        if (rel.GetRelationFor(groupe) != null)
                        {
                            CListeRestrictionsUtilisateurSurType restrictions = rel.GroupeRestriction.ListeRestrictions;
                            CRestrictionUtilisateurSurType resTmp = restrictions.GetRestriction(element.GetType());
                            restriction.Combine(resTmp);
                            lst.Remove(rel);
                        }
                    }
                    if (lst.Count == 0)
                        return;

                }


                foreach (CRelationUtilisateur_Profil relProfil in user.RelationsProfils)
                {
                    foreach (CRelationElement_RestrictionSpecifique rel in lst.ToArray())
                    {
                        if (rel.GetRelationFor(relProfil.Profil) != null)
                        {
                            CListeRestrictionsUtilisateurSurType restrictions = rel.GroupeRestriction.ListeRestrictions;
                            CRestrictionUtilisateurSurType resTmp = restrictions.GetRestriction(element.GetType());
                            restriction.Combine(resTmp);
                            lst.Remove(rel);
                            if (lst.Count == 0)
                                return;
                        }
                    }
                }

            }
        }
    }
}
