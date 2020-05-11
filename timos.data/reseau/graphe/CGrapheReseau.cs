using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using sc2i.common;

namespace timos.data.reseau.graphe
{

    public interface IComposantDeGrapheReseau
    {
        int IdSchemaReseau { get;}
        int IdObjet { get;}
    }

    public delegate bool IntegreNoeudDelegate(CNoeudDeGrapheReseau noeud);
    public delegate bool IntegreLiaisonDelegate(CLienDeGrapheReseau lien);

    public class CGrapheReseau
    {
        //Elements du graphe ( noeuds et liens )
        private CBaseElementsDeGraphe<CNoeudDeGrapheReseau> m_baseNoeuds = new CBaseElementsDeGraphe<CNoeudDeGrapheReseau>();
        private CBaseElementsDeGraphe<CLienDeGrapheReseau> m_baseLiens = new CBaseElementsDeGraphe<CLienDeGrapheReseau>();

        //Successeurs et précédesseurs
        private CDicSuccesseurs m_dicSuccesseurs = new CDicSuccesseurs();
        private CDicPredecesseurs m_dicPredecesseurs = new CDicPredecesseurs();

        private int m_nIdSchemaReseauRacine = -1;

        private CBaseGraphesReseau m_baseDeGraphes = null;

        private ESensAllerRetourLienReseau? m_sensGraphe = null;

        //Graphes integrés dans ce graphe
        private CBaseGraphesReseau m_graphesIntegres = new CBaseGraphesReseau();


        #region classes pour successeurs et predecesseurs
        private abstract class CDicNoeudToLien : Dictionary<CNoeudDeGrapheReseau, List<CLienDeGrapheReseau>>
        {
            public void AddLienToNoeud ( CNoeudDeGrapheReseau noeud, CLienDeGrapheReseau lien )
            {
                List<CLienDeGrapheReseau> lst = null;
                if ( !TryGetValue ( noeud, out lst ) )
                {
                    lst = new List<CLienDeGrapheReseau>();
                    this[noeud] = lst;
                }
                if ( !lst.Contains ( lien ) )
                    lst.Add ( lien );
            }

            public List<CLienDeGrapheReseau> GetLiensFromNoeud ( CNoeudDeGrapheReseau noeud )
            {
                List<CLienDeGrapheReseau> lst = null;
                if ( TryGetValue ( noeud, out lst ) )
                    return lst;
                return new List<CLienDeGrapheReseau>();
            }

            public void IntegreLiens(CDicNoeudToLien dic)
            {
                foreach (KeyValuePair<CNoeudDeGrapheReseau, List<CLienDeGrapheReseau>> valp in dic)
                {
                    foreach (CLienDeGrapheReseau lien in valp.Value)
                        AddLienToNoeud(valp.Key, lien);
                }
            }
        }
        private class CDicSuccesseurs : CDicNoeudToLien
        {
            public void AddSuccesseur(CNoeudDeGrapheReseau noeud, CLienDeGrapheReseau lien)
            {
                AddLienToNoeud(noeud, lien);
            }
            public List<CLienDeGrapheReseau> GetSuccesseurs(CNoeudDeGrapheReseau noeud)
            {
                return GetLiensFromNoeud(noeud);
            }
        }

        private class CDicPredecesseurs : CDicNoeudToLien
        {
            public void AddPredecesseur(CNoeudDeGrapheReseau noeud, CLienDeGrapheReseau lien)
            {
                AddLienToNoeud(noeud, lien);
            }
            public List<CLienDeGrapheReseau> GetPredecesseurs(CNoeudDeGrapheReseau noeud)
            {
                return GetLiensFromNoeud(noeud);
            }
        }
        #endregion

        public CGrapheReseau()
        {
            m_baseDeGraphes = new CBaseGraphesReseau();
        }

        public CGrapheReseau( CBaseGraphesReseau baseDeGraphes )
        {
            m_baseDeGraphes = baseDeGraphes;
            if (m_baseDeGraphes == null)
                m_baseDeGraphes = new CBaseGraphesReseau();
        }

        public CNoeudDeGrapheReseau GetNoeudForElement(IElementALiensReseau elt, CSchemaReseau schema)
        {
            if (elt is CSite)
                return GetNoeudForSite(elt as CSite, schema);
            if (elt is CEquipementLogique)
                return GetNoeudForEquipement(elt as CEquipementLogique, schema);
            return null;
        }

        public CNoeudDeGrapheReseauSite GetNoeudForSite(CSite site, CSchemaReseau schema)
        {
            if (site == null || schema == null)
                return null;
            return m_baseNoeuds.GetObjet(typeof(CNoeudDeGrapheReseauSite), site.Id, schema.Id) as CNoeudDeGrapheReseauSite;
        }

        public CNoeudDeGrapheReseauEquipement GetNoeudForEquipement(CEquipementLogique equipement, CSchemaReseau schema)
        {
            if (equipement == null || schema == null)
                return null;
            return m_baseNoeuds.GetObjet(typeof(CNoeudDeGrapheReseauEquipement), equipement.Id, schema.Id) as CNoeudDeGrapheReseauEquipement;
        }

        public ESensAllerRetourLienReseau? SensDuGraphe
        {
            get
            {
                return m_sensGraphe;
            }
        }

        ///////////////////////////////////////////////////////////////////////////
        //Fonctions supplémentaire à appeler pour integrer un élément dans le graphe
        public IntegreLiaisonDelegate IntegreLiaison;
        public IntegreNoeudDelegate IntegreNoeud;

        ///////////////////////////////////////////////////////////////////////////
        //Calcule un sous graphe
        //Le data du result contient le graphe
        private CResultAErreur CalculeSousGraphe ( CSchemaReseau schema )
        {
            CResultAErreur result = CResultAErreur.True;
            CGrapheReseau graphe = m_baseDeGraphes.GetGrapheExistant(schema, SensDuGraphe); ;
            if ( graphe != null )
            {
                if (m_graphesIntegres.GetGrapheExistant(schema, SensDuGraphe) == null)
                    IntegreSousGraphe(graphe);
                result.Data = graphe;
                return result;
            }
            graphe = new CGrapheReseau(m_baseDeGraphes);
            graphe.IntegreLiaison = IntegreLiaison;
            graphe.IntegreNoeud = IntegreNoeud;
            result = graphe.CalculeGraphe(schema, SensDuGraphe);
            if ( result )
            {
                result.Data = graphe;
                //Intègre les éléments du sous graphe dans ce graphe
                IntegreSousGraphe(graphe);
            }
            return result;
        }

        private void IntegreSousGraphe(CGrapheReseau graphe)
        {
            m_baseNoeuds.IntegreBase(graphe.m_baseNoeuds);
            m_baseLiens.IntegreBase(graphe.m_baseLiens);
            m_dicSuccesseurs.IntegreLiens(graphe.m_dicSuccesseurs);
            m_dicPredecesseurs.IntegreLiens(graphe.m_dicPredecesseurs);
            m_graphesIntegres.AddGrapheReseau(graphe.m_nIdSchemaReseauRacine, graphe.SensDuGraphe, graphe);
        }



        ///Récupère un noeud dans un sous schéma. Si le sous schema n'existe pas, il est calculé
        //Le data du result contient le noeud
        private CResultAErreur GetNoeudDansSousSchema ( IElementALiensReseau element, CCheminLienReseau chemin )
        {
            CResultAErreur result = CResultAErreur.True;
            CGrapheReseau sousGraphe = null;
            CSchemaReseau schemaFils = chemin.EtapeFinale as CSchemaReseau;
            if (schemaFils == null)
            {
                result.EmpileErreur(I.T("Can not find link extremity|20043"));
                return result;
            }
            result = CalculeSousGraphe(schemaFils);
            sousGraphe = result.Data as CGrapheReseau;
            if ( !result || sousGraphe == null)
            {
                result.EmpileErreur("Erreur in sub diagram @1|20044", schemaFils.Libelle);
                return result;
            }
            CNoeudDeGrapheReseau noeud = sousGraphe.GetNoeudForElement ( element, schemaFils );
            result.Data = noeud;
            return result;
        }

            
            
        /// <summary>
        /// Calcule un graphe pour un schéma donné
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="sens"></param>
        /// <returns></returns>
        public CResultAErreur CalculeGraphe(
            CSchemaReseau schema,
            ESensAllerRetourLienReseau? sens)
        {
            CResultAErreur result = CResultAErreur.True;
            m_baseDeGraphes.AddGrapheReseau(schema.Id, sens, this);
            m_sensGraphe = sens;
            m_nIdSchemaReseauRacine = schema.Id;
            m_baseLiens.Clear();
            m_baseNoeuds.Clear();
            m_dicSuccesseurs.Clear();
            m_dicPredecesseurs.Clear();
            Dictionary<int, CNoeudDeGrapheReseauSite> dicIdSiteToNoeud = new Dictionary<int, CNoeudDeGrapheReseauSite>();
            Dictionary<int, CNoeudDeGrapheReseauEquipement> dicIdEquipementToNoeud = new Dictionary<int, CNoeudDeGrapheReseauEquipement>();
            foreach (CElementDeSchemaReseau elt in schema.ElementsDeSchema)//Ne prend que les éléments de premier niveau
            {
                CSite site = elt.ElementAssocie as CSite;
                if (site != null)
                {
                    CNoeudDeGrapheReseauSite noeud = new CNoeudDeGrapheReseauSite(site.Id, schema.Id, elt.IsCableALinterieur);
                    if (!m_baseNoeuds.Contains(noeud))
                    {
                        if (IntegreNoeud == null || IntegreNoeud(noeud))
                        {
                            m_baseNoeuds.Add(noeud);
                            dicIdSiteToNoeud[site.Id] = noeud;
                        }
                    }
                }
                else
                {
                    CEquipementLogique eqpt = elt.ElementAssocie as CEquipementLogique;
                    if (eqpt != null)
                    {
                        CNoeudDeGrapheReseauEquipement noeud = new CNoeudDeGrapheReseauEquipement(eqpt.Id, schema.Id);
                        if (!m_baseNoeuds.Contains(noeud))
                        {
                            if (IntegreNoeud == null || IntegreNoeud(noeud))
                            {
                                m_baseNoeuds.Add(noeud);
                                dicIdEquipementToNoeud[eqpt.Id] = noeud;
                            }
                        }
                    }
                }
            }

            Dictionary<int, CGrapheReseau> dicGraphesCalcules = new Dictionary<int, CGrapheReseau>();
            foreach (CElementDeSchemaReseau elt in schema.GetElementsForType<CLienReseau>() )
            {
                if (elt.SchemaReseau.Id == schema.Id )//Ne prend pas les sous schémas
                {
                    CLienReseau lien = elt.ElementAssocie as CLienReseau;
                    if (lien != null)
                    {
                        if (m_sensGraphe != null)
                        {
                            CDonneeDessinLienDeSchemaReseau donneeDessin = elt.DonneeDessin as CDonneeDessinLienDeSchemaReseau;
                            if (donneeDessin == null)
                                continue;
                            if (m_sensGraphe.Value != donneeDessin.Forward_Backward)
                                continue;
                        }
                        EDirectionLienReseau[] directions = new EDirectionLienReseau[]
                        {
                            EDirectionLienReseau.UnVersDeux,
                            EDirectionLienReseau.DeuxVersUn
                        };
                        foreach (EDirectionLienReseau direction in directions)
                        {
                            if (direction == lien.Direction.Code || lien.Direction == EDirectionLienReseau.Bidirectionnel)
                            {
                                int nSigne = direction == EDirectionLienReseau.UnVersDeux ? 1 : -1;
                                IElementALiensReseau elt1 = null;
                                IElementALiensReseau elt2 = null;
                                CCheminLienReseau chemin1 = null;
                                CCheminLienReseau chemin2 = null;
                                if (direction == EDirectionLienReseau.UnVersDeux)
                                {
                                    elt1 = lien.Element1;
                                    chemin1 = elt.RacineChemin1;
                                    elt2 = lien.Element2;
                                    chemin2 = elt.RacineChemin2;
                                }
                                else if (direction == EDirectionLienReseau.DeuxVersUn)
                                {
                                    elt1 = lien.Element2;
                                    chemin1 = elt.RacineChemin2;
                                    elt2 = lien.Element1;
                                    chemin2 = elt.RacineChemin2;
                                }
                                if (!(elt1 is CSite) && !(elt1 is CEquipementLogique))
                                    elt1 = null;
                                if (!(elt2 is CSite) && !(elt2 is CEquipementLogique))
                                    elt2 = null;
                                if (elt1 != null && elt2 != null)
                                {
                                    CNoeudDeGrapheReseau noeud1 = null;
                                    if (chemin1 != null)
                                    {
                                        result = GetNoeudDansSousSchema(elt1, chemin1);//Result testé ensuite avec noeud1 = null;
                                        noeud1 = result.Data as CNoeudDeGrapheReseau;
                                    }
                                    else
                                    {
                                        if (elt1 is CSite)
                                        {
                                            CNoeudDeGrapheReseauSite noeudSite = null;
                                            dicIdSiteToNoeud.TryGetValue(elt1.Id, out noeudSite);
                                            noeud1 = noeudSite;
                                        }
                                        else if (elt1 is CEquipementLogique)
                                        {
                                            CNoeudDeGrapheReseauEquipement noeudEqpt = null;
                                            dicIdEquipementToNoeud.TryGetValue(elt1.Id, out noeudEqpt);
                                            noeud1 = noeudEqpt;
                                        }
                                    }
                                    if (noeud1 == null)
                                    {
                                        result.EmpileErreur(I.T("Can not find link @1 extremity|20043", lien.Libelle));
                                        return result;
                                    }

                                    CNoeudDeGrapheReseau noeud2 = null;
                                    if (chemin2 != null)
                                    {
                                        result = GetNoeudDansSousSchema(elt2, chemin2);//Result testé ensuite avec noeud2= null;
                                        noeud2 = result.Data as CNoeudDeGrapheReseau;
                                    }
                                    else
                                    {
                                        if (elt2 is CSite)
                                        {
                                            CNoeudDeGrapheReseauSite noeudSite = null;
                                            dicIdSiteToNoeud.TryGetValue(elt2.Id, out noeudSite);
                                            noeud2 = noeudSite;
                                        }
                                        else if (elt2 is CEquipementLogique)
                                        {
                                            CNoeudDeGrapheReseauEquipement noeudEquip = null;
                                            dicIdEquipementToNoeud.TryGetValue(elt2.Id, out noeudEquip);
                                            noeud2 = noeudEquip;
                                        }
                                    }
                                    if (noeud2 == null)
                                    {
                                        result.EmpileErreur(I.T("Can not find link @1 extremity|20043", lien.Libelle));
                                        return result;
                                    }

                                    CLienDeGrapheReseau lienDeGraphe = m_baseLiens.GetObjet(typeof(CLienDeGrapheReseau), nSigne*lien.Id, schema.Id);
                                    if (lienDeGraphe == null)
                                    {
                                        CEtapesExtremiteLienDeGraphe etapes1 = null;
                                        if (chemin1 != null)
                                            etapes1 = new CEtapesExtremiteLienDeGraphe(chemin1);
                                        CEtapesExtremiteLienDeGraphe etapes2 = null;
                                        if (chemin2 != null)
                                            etapes2 = new CEtapesExtremiteLienDeGraphe(chemin2);

                                        lienDeGraphe = new CLienDeGrapheReseau(
                                            nSigne * lien.Id,
                                            schema.Id,
                                            noeud1,
                                            noeud2,
                                            etapes1,
                                            etapes2);
                                        if (IntegreLiaison == null || IntegreLiaison(lienDeGraphe))
                                        {
                                            m_baseLiens.Add(lienDeGraphe);
                                            m_dicSuccesseurs.AddSuccesseur(noeud1, lienDeGraphe);
                                            m_dicPredecesseurs.AddPredecesseur(noeud2, lienDeGraphe);
                                        }
                                    }
                                    
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        private void RemoveNoeud(CNoeudDeGrapheReseau noeud)
        {
            foreach (CLienDeGrapheReseau lien in m_dicSuccesseurs.GetSuccesseurs(noeud))
                m_baseLiens.Remove(lien);
            foreach (CLienDeGrapheReseau lien in m_dicPredecesseurs.GetPredecesseurs(noeud))
                m_baseLiens.Remove(lien);
        }

        public bool HasChemin(IElementALiensReseau elt1, IElementALiensReseau elt2)
        {
            Type typeNoeuds1 = null;
            if (elt1 is CSite)
                typeNoeuds1 = typeof(CNoeudDeGrapheReseauSite);
            else if (elt1 is CEquipementLogique)
                typeNoeuds1 = typeof(CNoeudDeGrapheReseauEquipement);
            else
                return false;

            Type typeNoeuds2 = null;
            if (elt2 is CSite)
                typeNoeuds2 = typeof(CNoeudDeGrapheReseauSite);
            else if (elt2 is CEquipementLogique)
                typeNoeuds2 = typeof(CNoeudDeGrapheReseauEquipement);
            else
                return false;

            Dictionary<CNoeudDeGrapheReseau, bool> noeudsUtilises = new Dictionary<CNoeudDeGrapheReseau, bool>();
            CNoeudDeGrapheReseau noeudDepart = m_baseNoeuds.GetObjet(typeNoeuds1, elt1.Id, m_nIdSchemaReseauRacine);
            CNoeudDeGrapheReseau noeudArrivee = m_baseNoeuds.GetObjet(typeNoeuds2, elt2.Id, m_nIdSchemaReseauRacine);
            if (noeudDepart == null || noeudArrivee == null)
                return false;
            return HasChemin(noeudDepart, noeudArrivee, noeudsUtilises);
        }

        private bool HasChemin(
            CNoeudDeGrapheReseau noeudDepartSouhaite,
            CNoeudDeGrapheReseau noeudArriveSouhaite,
            Dictionary<CNoeudDeGrapheReseau, bool> dicNoeudsUtilises)
        {
            List<CLienDeGrapheReseau> liensSuivants = new List<CLienDeGrapheReseau>();
            foreach (CLienDeGrapheReseau lien in m_dicSuccesseurs.GetSuccesseurs(noeudDepartSouhaite))
            {
                if (!dicNoeudsUtilises.ContainsKey(lien.NoeudArrive))
                {
                    if (lien.NoeudArrive == noeudArriveSouhaite)
                        return true;
                    liensSuivants.Add(lien);
                }
            }
            foreach (CLienDeGrapheReseau lien in liensSuivants)
            {
                if (HasChemin(lien.NoeudArrive, noeudArriveSouhaite, dicNoeudsUtilises))
                    return true;
            }
            return false;
        }


        public List<CCheminDeGrapheReseau> GetChemins(CNoeudDeGrapheReseau noeud1, CNoeudDeGrapheReseau noeud2)
        {
            List<CCheminDeGrapheReseau> lstFinale = new List<CCheminDeGrapheReseau>();
            CCheminDeGrapheReseau chemin = new CCheminDeGrapheReseau();
            FindChemins(chemin, noeud1, noeud2, lstFinale);
            return lstFinale;
        }

        private void FindChemins(CCheminDeGrapheReseau chemin, 
            CNoeudDeGrapheReseau noeudDepart,
            CNoeudDeGrapheReseau noeudArrive, 
            List<CCheminDeGrapheReseau> cheminsTrouves)
        {
            if (noeudArrive.Equals(noeudDepart))
            {
                cheminsTrouves.Add(chemin);
                return;
            }
            else
            {
                foreach (CLienDeGrapheReseau lien in m_dicSuccesseurs.GetSuccesseurs(noeudDepart))
                {
                    if (!chemin.Contains(lien.NoeudArrive))
                        FindChemins(chemin + lien, lien.NoeudArrive, noeudArrive, cheminsTrouves);
                }
            }
        }

        /// <summary>
        /// REtourne les ids des sites qui n'ont aucun lien
        /// </summary>
        /// <param name="sens"></param>
        /// <returns></returns>
        public CNoeudDeGrapheReseau[] GetNoeudsIsoles()
        {
            List<CNoeudDeGrapheReseau> lstNoeuds = new List<CNoeudDeGrapheReseau>();
            foreach (CNoeudDeGrapheReseau noeud in m_baseNoeuds)
            {
                if (noeud.IdSchemaReseau == m_nIdSchemaReseauRacine)
                {
                    if (m_dicPredecesseurs.GetPredecesseurs(noeud).Count == 0 &&
                        m_dicSuccesseurs.GetSuccesseurs(noeud).Count == 0)
                    {
                        lstNoeuds.Add(noeud);
                    }
                }
            }
            return lstNoeuds.ToArray();
        }

        /// <summary>
        /// Retourne tous les noeuds entre ( qui n'ont pas de lien en entrée) du schéma de réseau (et 
        /// pas de sous schémas) auquel est lié le graphe
        /// </summary>
        /// <returns></returns>
        public CNoeudDeGrapheReseau[] GetNoeudsEntreeNiveau0()
        {
            List<CNoeudDeGrapheReseau> lstNoeuds = new List<CNoeudDeGrapheReseau>();
            foreach (CNoeudDeGrapheReseau noeud in m_baseNoeuds)
            {
                if (noeud.IdSchemaReseau == m_nIdSchemaReseauRacine)
                {
                    if (m_dicPredecesseurs.GetPredecesseurs(noeud).Count == 0)
                        lstNoeuds.Add(noeud);
                }
            }
            return lstNoeuds.ToArray();
        }


        /// <summary>
        /// Retourne tous les noeuds sortie ( qui n'ont pas de lien en sortie) du schéma de réseau (et 
        /// pas de sous schémas) auquel est lié le graphe
        /// </summary>
        /// <returns></returns>
        public CNoeudDeGrapheReseau[] GetNoeudsSortieNiveau0()
        {
            List<CNoeudDeGrapheReseau> lstNoeuds = new List<CNoeudDeGrapheReseau>();
            foreach (CNoeudDeGrapheReseau noeud in m_baseNoeuds)
            {
                if (noeud.IdSchemaReseau == m_nIdSchemaReseauRacine)
                {
                    if (m_dicSuccesseurs.GetSuccesseurs(noeud).Count == 0)
                        lstNoeuds.Add(noeud);
                }
            }
            return lstNoeuds.ToArray();
        }

        public CNoeudDeGrapheReseau[] GetNoeudsNiveau0()
        {
            List<CNoeudDeGrapheReseau> lstNoeuds = new List<CNoeudDeGrapheReseau>();
            foreach (CNoeudDeGrapheReseau noeud in m_baseNoeuds)
            {
                if (noeud.IdSchemaReseau == m_nIdSchemaReseauRacine)
                    lstNoeuds.Add(noeud);
            }
            return lstNoeuds.ToArray();
        }

        public CLienDeGrapheReseau[] GetLiensNiveau0()
        {
            List<CLienDeGrapheReseau> lstLiens = new List<CLienDeGrapheReseau>();
            foreach (CLienDeGrapheReseau lien in m_baseLiens)
            {
                if (lien.IdSchemaReseau == m_nIdSchemaReseauRacine)
                    lstLiens.Add(lien);
            }
            return lstLiens.ToArray();
        }


        
    }
}
