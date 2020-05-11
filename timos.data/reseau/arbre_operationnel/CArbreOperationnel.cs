using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using timos.data.reseau.graphe;

namespace timos.data.reseau.arbre_operationnel
{
    public class CArbreOperationnel
    {
        private CElementDeArbreOperationnel m_elementRacine = null;

        public CArbreOperationnel()
        {
        }

        public CElementDeArbreOperationnel ElementRacine
        {
            get
            {
                return m_elementRacine;
            }
        }

        public CResultAErreur CalculeArbre(
            CSchemaReseau schema,
            ESensAllerRetourLienReseau sens,
            CBaseGraphesReseau baseGraphes)
        {
            CResultAErreur result = CResultAErreur.True;

            if (baseGraphes == null)
                baseGraphes = new CBaseGraphesReseau();

            CGrapheReseau graphe = baseGraphes.GetGrapheExistant(schema, sens);
            if (graphe == null)
            {
                graphe = new CGrapheReseau(baseGraphes);
                result = graphe.CalculeGraphe(schema, sens);
                if (!result)
                    return result;
                baseGraphes.AddGrapheReseau(schema.Id, sens, graphe);
            }

            switch (schema.ModeOperationnel.Code)
            {
                case EModeOperationnelSchema.AllMandatory:
                    return CalculArbreTousNecessaires(schema, graphe);
                case EModeOperationnelSchema.AutomaticRedundancy:
                    return CalculArbreRedondanceAuto(schema, graphe);
                case EModeOperationnelSchema.Custom:
                    result.EmpileErreur("For future use");
                    return result;
                default:
                    break;
            }

            return result;
        }

        public CResultAErreur CalculArbreTousNecessaires(
            CSchemaReseau schema,
            CGrapheReseau graphe )
        {
            CResultAErreur result = CResultAErreur.True;
            return result;
        }


        //structure temporaire, pour séparer les éléments de sous schéma
        private struct CRacineDeSchema
        {
            public CElementDeArbreOperationnelOperateur ElementRacine;
            public CElementDeArbreOperationnelSousSchema ElementSousSchema;
            public int IdSchema;

            public CRacineDeSchema ( 
                int nIdSchema,
                CElementDeArbreOperationnelSousSchema elementSousSchema,
                CElementDeArbreOperationnelOperateur elementRacine )
            {
                ElementSousSchema = elementSousSchema;
                ElementRacine = elementRacine;
                IdSchema = nIdSchema;
            }
        }

        //-------------------------------------------------
        /// <summary>
        /// Calcule un arbre en mode redondance auto pour 
        /// un schéma
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="graphe"></param>
        /// <returns></returns>
        public CResultAErreur CalculArbreRedondanceAuto(
            CSchemaReseau schema,
            CGrapheReseau graphe)
        {
            return CalculArbreRedondanceAuto(
                schema,
                graphe,
                null,
                null);
        }

        //-------------------------------------------------
        /// <summary>
        /// Calcule l'arbre entre deux noeuds pour un schéma
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="graphe"></param>
        /// <param name="noeudDepart"></param>
        /// <param name="noeudArrivee"></param>
        /// <returns></returns>
        public CResultAErreur CalculArbreRedondanceAuto(
            CSchemaReseau schema,
            CGrapheReseau graphe, 
            CNoeudDeGrapheReseau noeudDepart,
            CNoeudDeGrapheReseau noeudArrivee )
        {
            CResultAErreur result = CResultAErreur.True;
            CNoeudDeGrapheReseau[] noeudsEntree;
            if (noeudDepart != null)
                noeudsEntree = new CNoeudDeGrapheReseau[] { noeudDepart };
            else if ( schema.LienReseau == null )//Ce n'est pas un schéma de lien
                noeudsEntree = graphe.GetNoeudsEntreeNiveau0();
            else
            {
                noeudsEntree = new CNoeudDeGrapheReseau[]{
                    graphe.GetNoeudForElement ( schema.LienReseau.Element1, schema )
                };
            }
            CNoeudDeGrapheReseau[] noeudsSortie;
            if (noeudArrivee != null)
                noeudsSortie = new CNoeudDeGrapheReseau[] { noeudArrivee };
            else if ( schema.LienReseau == null )//Ce n'est pas un schéma de lien
                noeudsSortie = graphe.GetNoeudsSortieNiveau0();
            else
            {
                noeudsSortie = new CNoeudDeGrapheReseau[]{
                    graphe.GetNoeudForElement ( schema.LienReseau.Element2, schema )
                };
            }

            CElementDeArbreOperationnelOperateurEt eltSource = new CElementDeArbreOperationnelOperateurEt(null);
            m_elementRacine = eltSource;

            //Ajoute les éléments seuls
            foreach (CNoeudDeGrapheReseau noeud in graphe.GetNoeudsIsoles())
            {
                if ( schema.LienReseau == null || noeud.Equals ( noeudsEntree[0] ) || noeud.Equals(noeudsSortie[0] ))
                    //si c'est un schéma de lien n'ajoute que les noeuds isolé correspondant à l'entrée ou à la sortie
                {
                CElementDeArbreOperationnelEntite composant = new CElementDeArbreOperationnelEntite(eltSource, noeud);
                eltSource.AddFils(composant);
                result = composant.GetElementCablage(graphe.SensDuGraphe, schema.ContexteDonnee);
                if (!result)
                    return result;
                CElementDeArbreOperationnel elementCablage = result.Data as CElementDeArbreOperationnel;
                if (elementCablage != null)
                    eltSource.AddFils(elementCablage);
                }
            }
            
            foreach (CNoeudDeGrapheReseau noeudEntree in noeudsEntree)
            {
                foreach (CNoeudDeGrapheReseau noeudSortie in noeudsSortie)
                {
                    List<CCheminDeGrapheReseau> chemins = graphe.GetChemins(noeudEntree, noeudSortie);
                    if (chemins.Count() > 0)
                    {
                        CElementDeArbreOperationnelOperateurOu ouPourExtremites = new CElementDeArbreOperationnelOperateurOu(eltSource);
                        eltSource.AddFils(ouPourExtremites);
                        foreach (CCheminDeGrapheReseau chemin in chemins) //parcours tous les chemins en mettant un ou dessus
                        {
                            Stack<CRacineDeSchema> lstRacines = new Stack<CRacineDeSchema>();
                            CRacineDeSchema racine = new CRacineDeSchema(schema.Id, null, new CElementDeArbreOperationnelOperateurEt(ouPourExtremites));
                            ouPourExtremites.AddFils(racine.ElementRacine);
                            lstRacines.Push(racine);
                            int nLien = 0;
                            foreach (CLienDeGrapheReseau lien in chemin.Liens)
                            {
                                CRacineDeSchema racineEnCours = lstRacines.Peek();
                                if (lien.EtapesNoeudDepart != null)
                                {
                                    int[] idsSchemas = lien.EtapesNoeudDepart.IdsSchemas;
                                    //Dépile les sous schémas
                                    for (int nEtape = idsSchemas.Count() - 1; nEtape >= 0; nEtape--)
                                    {
                                        int nIdSchema = idsSchemas[nEtape];
                                        if (racineEnCours.IdSchema != nIdSchema)
                                        {
                                            result.EmpileErreur(I.T("Bad path for link @1 in graph for @2 diagram|20050",
                                                lien.IdLienReseau.ToString(), lien.IdSchemaReseau.ToString()));
                                            return result;
                                        }
                                        if ( racineEnCours.ElementSousSchema != null )
                                            racineEnCours.ElementSousSchema.NoeudArrive = lien.NoeudDepart;
                                        lstRacines.Pop();
                                        racineEnCours = lstRacines.Peek();
                                    }
                                }
                                //Si les extremités du lien sont cablées, le lien est dans un et, sinon,
                                //il est directement sous la racine en cours
                                CElementDeArbreOperationnelOperateur elementParentDeLien = racineEnCours.ElementRacine;

                                //Si ce n'est pas le dernier lien, on ajoute que les cablages des noeuds de départ,
                                //Puisque le cablage du noeud d'arrivé sera le cablage du noeud de départ du prochain lien
                                //Par contre, si c'est le dernier lien du chemin, il faut ajouter ce cablage
                                
                                if ((lien.NoeudDepart is CNoeudDeGrapheReseauSite && ((CNoeudDeGrapheReseauSite)lien.NoeudDepart).IsCable) ||
                                    (nLien == chemin.Liens.Count()-1 && (lien.NoeudArrive is CNoeudDeGrapheReseauSite && ((CNoeudDeGrapheReseauSite)lien.NoeudArrive).IsCable)))
                                {
                                    elementParentDeLien = new CElementDeArbreOperationnelOperateurEt(racineEnCours.ElementRacine);
                                    racineEnCours.ElementRacine.AddFils(elementParentDeLien);
                                }
                                elementParentDeLien.AddFils(new CElementDeArbreOperationnelEntite(elementParentDeLien, lien));

                                //Cablage du site entrée
                                CNoeudDeGrapheReseauSite noeudSite = lien.NoeudDepart as CNoeudDeGrapheReseauSite;
                                if (noeudSite != null && noeudSite.IsCable)
                                {
                                    //Le noeud correspondant à l'élément est déjà dans le schéma du lien
                                    CElementDeArbreOperationnelEntite elementNoeud = new CElementDeArbreOperationnelEntite(null, noeudSite);
                                    result = elementNoeud.GetElementCablage(graphe.SensDuGraphe, schema.ContexteDonnee);
                                    if (!result)
                                        return result;
                                    CElementDeArbreOperationnel elementCablage = result.Data as CElementDeArbreOperationnel;
                                    if ( elementCablage != null )
                                        elementParentDeLien.AddFils ( elementCablage );
                                }
                                //Cablage du site sortie
                                noeudSite = lien.NoeudArrive as CNoeudDeGrapheReseauSite;
                                if ( noeudSite != null && noeudSite.IsCable && nLien == chemin.Liens.Count()-1 )
                                {
                                    CElementDeArbreOperationnelEntite elementNoeud = new CElementDeArbreOperationnelEntite(null, noeudSite );
                                    result = elementNoeud.GetElementCablage ( graphe.SensDuGraphe, schema.ContexteDonnee );
                                    if ( !result )
                                        return result;
                                    CElementDeArbreOperationnel elementCablage  = result.Data as CElementDeArbreOperationnel;
                                    if ( elementCablage != null )
                                        elementParentDeLien.AddFils ( elementCablage );
                                }

                                if (lien.EtapesNoeudArrivee != null)
                                {
                                    int[] idsSchemas = lien.EtapesNoeudArrivee.IdsSchemas;
                                    foreach (int nIdSchema in idsSchemas)
                                    {
                                        CElementDeArbreOperationnelSousSchema eltSousSchema = new CElementDeArbreOperationnelSousSchema(racineEnCours.ElementRacine);
                                        eltSousSchema.NoeudDepart = lien.NoeudArrive;
                                        eltSousSchema.ElementDeArbre = new CElementDeArbreOperationnelOperateurEt(racine.ElementRacine);
                                        eltSousSchema.IdSchema = nIdSchema;
                                        CRacineDeSchema newRacine = new CRacineDeSchema(
                                            nIdSchema,
                                            eltSousSchema,
                                            eltSousSchema.ElementDeArbre as CElementDeArbreOperationnelOperateur);
                                        lstRacines.Push(newRacine);
                                        racineEnCours.ElementRacine.AddFils(eltSousSchema);
                                        racineEnCours = newRacine;
                                    }
                                }
                                nLien++;
                                
                            }
                        }
                    }
                }
            }
            eltSource.Simplifier();
            return result;
        }


            
    }
}
