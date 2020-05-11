using System;
using System.Collections.Generic;
using System.Text;
using timos.data;
using sc2i.data;
using timos.data.reseau.graphe;
using sc2i.drawing;
using System.Drawing;
using timos.data.reseau.arbre_operationnel;
using sc2i.common;

namespace spv.data.VueAnimee
{

    public enum EEtatOperationnelSchema
    {
        HS = 0,
        Degrade = 5,
        OK = 10
    }

    public class CInfoSchemaDeSchemaSupervise : CInfoElementDeSchemaSupervise
    {
        
        //Relations vers les objets SPV
        private static CInfoRelation m_relationFromSiteSpvToSite = null;
        private static CInfoRelation m_relationFromEquipementSpvToEquipement = null;
        private static CInfoRelation m_relationFromLiaisonSpvToLiaison = null;

        //Graphe aller si on travaille avec un sens aller/retour, ou graphe simple sinon
        private List<CGrapheReseau> m_listeGraphes = new List<CGrapheReseau>();
        private CBaseCheminsPointAPoint m_baseChemins = new CBaseCheminsPointAPoint();
        private Dictionary<CNoeudDeGrapheReseau, bool> m_dicNoeudsIsoles = new Dictionary<CNoeudDeGrapheReseau, bool>();

        private CBaseGraphesReseau m_baseGraphes = new CBaseGraphesReseau();

        private int m_nIdSchemaReseau;
        private int m_nIdSchemaReseauSpv;

        private bool m_bIsOperationnel = true;
        private EEtatOperationnelSchema m_etatOperationnel = EEtatOperationnelSchema.OK;

        public CInfoSchemaDeSchemaSupervise(
            CInfoElementDeSchemaSupervise parent,
            CElementDeSchemaReseau eltDeSchema,
            CBasePourVueAnimee basePourVue,
            int nNiveauProfondeur)
            :base ( parent, eltDeSchema, basePourVue, nNiveauProfondeur )
        {
        }

        /// <summary>
        /// Initialise l'objet à partir d'un schéma
        /// </summary>
        /// <param name="schema"></param>
        internal override void InitFromElementDeSchema(CElementDeSchemaReseau elt)
        {
            base.InitFromElementDeSchema(elt);
            CSchemaReseau schema = elt.SchemaReseauContenu;
            if (schema == null)
                schema = elt.SchemaReseauInclus;
            
            if ( schema == null )
                throw new Exception("Bad element for supervision data ");
            InitFromSchema(schema);
        }


        /////////////////////////////////////////////////////////////////
        //S'assure que les CInfoRelation vers les objets SPV sont bien connues
        private void AssureRelationsToSpv()
        {
            if (m_relationFromEquipementSpvToEquipement == null)
                foreach (CInfoRelation relation in CContexteDonnee.GetListeRelationsTable(CEquipementLogique.c_nomTable))
                    if (relation.TableParente == CEquipementLogique.c_nomTable && relation.TableFille == CSpvEquip.c_nomTable)
                    {
                        m_relationFromEquipementSpvToEquipement = relation;
                        break;
                    }
            if (m_relationFromLiaisonSpvToLiaison == null)
                foreach (CInfoRelation relation in CContexteDonnee.GetListeRelationsTable(CLienReseau.c_nomTable))
                    if (relation.TableParente == CLienReseau.c_nomTable && relation.TableFille == CSpvLiai.c_nomTable)
                    {
                        m_relationFromLiaisonSpvToLiaison = relation;
                        break;
                    }
            if (m_relationFromSiteSpvToSite == null)
                foreach (CInfoRelation relation in CContexteDonnee.GetListeRelationsTable(CSite.c_nomTable))
                    if (relation.TableParente == CSite.c_nomTable && relation.TableFille == CSpvSite.c_nomTable)
                    {
                        m_relationFromSiteSpvToSite = relation;
                        break;
                    }
            if (m_relationFromEquipementSpvToEquipement == null)
                throw new Exception("Error in finding relation from site to Supervised site");
            if (m_relationFromLiaisonSpvToLiaison == null)
                throw new Exception("Error in finding relation form link to Supervised link");
            if (m_relationFromSiteSpvToSite == null)
                throw new Exception("Error in finding relation from site to supervised site");
        }

        public int IdSchema
        {
            get { return m_nIdSchemaReseau; }
        }

        public int IdSchemaSpv
        {
            get { return m_nIdSchemaReseauSpv; }
        }


        /////////////////////////////////////////////////////////////////
        private CSchemaReseau m_schema = null;
        public void InitFromSchema ( CSchemaReseau schema )
        {
            m_nIdSchemaReseau = schema.Id;
            m_schema = schema;

            CSpvSchemaReseau schemaSPV = CSpvSchemaReseau.GetObjetSpvFromObjetTimos(schema);
            if(schemaSPV != null)
                m_nIdSchemaReseauSpv = schemaSPV.Id;

            CListeObjetsDonnees lstElements = schema.ElementsDeSchema;
            lstElements.ReadDependances(
                "SchemaReseauInclu",
                "SchemaReseauContenu");
            //Charge les données SPV
            AssureRelationsToSpv();
            CListeObjetsDonnees lstTmp = lstElements.GetDependances("Site");
            lstTmp.GetDependances(m_relationFromSiteSpvToSite).AssureLectureFaite();

            lstTmp = lstElements.GetDependances("EquipementLogique");
            lstTmp.GetDependances(m_relationFromEquipementSpvToEquipement).AssureLectureFaite();

            lstTmp = lstElements.GetDependances("LienReseau");
            lstTmp.GetDependances(m_relationFromLiaisonSpvToLiaison).AssureLectureFaite();

            //CSpvService service = CSpvService.GetObjetSpvFromObjetTimos(schema);

            foreach (CElementDeSchemaReseau elt in lstElements)
            {
                IElementDeSchemaReseau elementFils = elt.ElementAssocie;
                if (elementFils != null)
                {
                    CInfoElementDeSchemaSupervise fils = null; 
                    if (elementFils is CSite)
                        fils = new CInfoSiteDeSchemaSupervise(this, elt, m_base, NiveauProfondeur+1);
                    if (elementFils is CLienReseau)
                        fils = new CInfoLienDeSchemaSupervise(this, elt, m_base, NiveauProfondeur+1);
                    if (elementFils is CElementDeSchemaReseau)
                        fils = new CInfoEquipementDeSchemaSupervise(this, elt, m_base,NiveauProfondeur+1);
                    if (elementFils is CSchemaReseau)
                        fils = new CInfoSchemaDeSchemaSupervise(this, elt, m_base,NiveauProfondeur+1);
                    if (elementFils is CEquipementLogique)
                        fils = new CInfoEquipementDeSchemaSupervise(this, elt, m_base, NiveauProfondeur + 1);
                    if (elementFils != null)
                    {
                        fils.InitFromElementDeSchema(elt);
                        m_listeFils.Add(fils);
                    }
                }
            }

            PrepareSupervisionEtatOperationnel(schema);
            CalculArbreOperationnel();

        }

        public CArbreOperationnel ArbreAller
        {
            get { return m_arbreAller; }
        }

        public CArbreOperationnel ArbreRetour
        {
            get { return m_arbreRetour; }
        }

        //-------------------------------------------------------------------------------------
        private CArbreOperationnel m_arbreAller = new CArbreOperationnel();
        private CArbreOperationnel m_arbreRetour = new CArbreOperationnel();
        private void CalculArbreOperationnel()
        {
            // Calcul les graphes
            CResultAErreur result = CResultAErreur.True;

            CGrapheReseau grapheAller = new CGrapheReseau();
            result = grapheAller.CalculeGraphe(m_schema, ESensAllerRetourLienReseau.Forward);
            if (result)
                result = m_arbreAller.CalculArbreRedondanceAuto(m_schema, grapheAller);

            CGrapheReseau grapheRetour = new CGrapheReseau();
            result = grapheRetour.CalculeGraphe(m_schema, ESensAllerRetourLienReseau.Backward);
            if (result)
                result = m_arbreRetour.CalculArbreRedondanceAuto(m_schema, grapheAller);

            
            foreach (CInfoElementDeSchemaSupervise info in this.ListeFils)
            {
                CInfoSchemaDeSchemaSupervise infoSchema = info as CInfoSchemaDeSchemaSupervise;
                if (infoSchema != null)
                {
                    infoSchema.CalculArbreOperationnel();
                }
            }
        }

        public override void FillDicNoeudArbreRacineToInfoElement(
            Dictionary<CElementDeArbreOperationnel, CInfoElementDeSchemaSupervise> dicNoeudArbreRacineToInfoElement)
        {
            base.FillDicNoeudArbreRacineToInfoElement(dicNoeudArbreRacineToInfoElement);

            dicNoeudArbreRacineToInfoElement.Add(m_arbreAller.ElementRacine, this);

        }

        public override void FillDicsElementToNoeudsArbre(
            CDictionnaireElementToNoeudArbre dicEquipementToNoeudArbreOp,
            CDictionnaireElementToNoeudArbre dicSiteToNoeudArbreOp,
            CDictionnaireElementToNoeudArbre dicLiaisonToNoeudArbreOp,
            CDictionnaireElementToNoeudArbre dicServiceToNoeudArbreOp)
        {

            base.FillDicsElementToNoeudsArbre(
                 dicEquipementToNoeudArbreOp,
                 dicSiteToNoeudArbreOp,
                 dicLiaisonToNoeudArbreOp,
                 dicServiceToNoeudArbreOp);

            // Rempli les dictionnaires : Id élement -> liste de noeuds
            
            // Sens aller
            CElementDeArbreOperationnel noeudRacineA = m_arbreAller.ElementRacine;
            FillDicsForNode(noeudRacineA,
                 dicEquipementToNoeudArbreOp,
                 dicSiteToNoeudArbreOp,
                 dicLiaisonToNoeudArbreOp,
                 dicServiceToNoeudArbreOp);

            // Sens Retour
            CElementDeArbreOperationnel noeudRacineR = m_arbreRetour.ElementRacine;
            FillDicsForNode(noeudRacineR,
                 dicEquipementToNoeudArbreOp,
                 dicSiteToNoeudArbreOp,
                 dicLiaisonToNoeudArbreOp,
                 dicServiceToNoeudArbreOp);


        }


        private void FillDicsForNode(CElementDeArbreOperationnel node,
            CDictionnaireElementToNoeudArbre dicEquipementToNoeudArbreOp,
            CDictionnaireElementToNoeudArbre dicSiteToNoeudArbreOp,
            CDictionnaireElementToNoeudArbre dicLiaisonToNoeudArbreOp,
            CDictionnaireElementToNoeudArbre dicServiceToNoeudArbreOp)
        {
            CElementDeArbreOperationnelEntite noeudEntite = node as CElementDeArbreOperationnelEntite;

            if (noeudEntite != null)
            {
                try
                {
                    IElementDeSchemaReseau eltAssocie = noeudEntite.Composant.GetElementAssocie(m_base.ContexteDonnee);

                    if (eltAssocie is CEquipementLogique)
                    {
                        CSpvEquip equipement = CSpvEquip.GetObjetSpvFromObjetTimos((CEquipementLogique)eltAssocie);
                        if (equipement != null)
                            dicEquipementToNoeudArbreOp.Add(equipement.Id, noeudEntite);
                    }
                    else if (eltAssocie is CSite)
                    {
                        CSpvSite site = CSpvSite.GetObjetSpvFromObjetTimos((CSite)eltAssocie);
                        if (site != null)
                            dicSiteToNoeudArbreOp.Add(site.Id, noeudEntite);
                    }
                    else if (eltAssocie is CLienReseau)
                    {
                        CSpvLiai liaison = CSpvLiai.GetObjetSpvFromObjetTimos((CLienReseau)eltAssocie);
                        if (liaison != null)
                            dicLiaisonToNoeudArbreOp.Add(liaison.Id, noeudEntite);
                    }
                    else if (eltAssocie is CSchemaReseau)
                    {
                        CSpvSchemaReseau schema = CSpvSchemaReseau.GetObjetSpvFromObjetTimos((CSchemaReseau)eltAssocie);
                        if (schema != null)
                            dicServiceToNoeudArbreOp.Add(schema.Id, noeudEntite);
                    }
                }
                catch { }
              }

            // Fonction récursive sur les noeuds fils
            foreach (CElementDeArbreOperationnel nodeFils in node.Fils)
            {
                FillDicsForNode(nodeFils,
                     dicEquipementToNoeudArbreOp,
                     dicSiteToNoeudArbreOp,
                     dicLiaisonToNoeudArbreOp,
                     dicServiceToNoeudArbreOp);
            }
 

        }


        protected override void RecalculeGravite()
        {
            base.RecalculeGravite();
            //CalculeIsOperationnel();
            CalculEtatOperationnel();
        }

        //private void FillDicsCoupes(
        //    CInfoElementDeSchemaSupervise[] infos, 
        //    Dictionary<int, bool> dicSitesCoupes, 
        //    Dictionary<int, bool> dicLiensCoupes,
        //    Dictionary<int,bool> dicEquipementsCoupes)
        //{
        //    foreach (CInfoElementDeSchemaSupervise info in infos)
        //    {
        //        if (info.GraviteAlarme >= EGraviteAlarme.Major)
        //        {
        //            CInfoSiteDeSchemaSupervise infoSite = info as CInfoSiteDeSchemaSupervise;
        //            if (infoSite != null)
        //            {
        //                dicSitesCoupes[infoSite.IdSite] = true;
        //            }
        //            else
        //            {
        //                CInfoLienDeSchemaSupervise infoLien = info as CInfoLienDeSchemaSupervise;
        //                if (infoLien != null)
        //                {
        //                    if (!infoLien.IsOperationnel)
        //                        dicLiensCoupes[infoLien.IdLienTimos] = true;
        //                }
        //                else
        //                {
        //                    CInfoEquipementDeSchemaSupervise infoEquip = info as CInfoEquipementDeSchemaSupervise;
        //                    if (infoEquip != null && infoEquip.IdEquipementSpv != null)
        //                        dicEquipementsCoupes[infoEquip.IdEquipementSpv.Value] = true;
        //                }
        //            }

        //        }
        //        FillDicsCoupes ( info.ListeFils, dicSitesCoupes, dicLiensCoupes, dicEquipementsCoupes );
        //    }
        //}

        public bool IsOperationnel
        {
            get
            {
                return m_bIsOperationnel;
            }
        }

        
        public EEtatOperationnelSchema EtatOperationnel 
        {
            get
            {
                return m_etatOperationnel;
            }
            set
            {
                m_etatOperationnel = value;
            }
        }

        private void CalculEtatOperationnel()
        {
            m_arbreAller.ElementRacine.RecalculeCoefOperationnelFromChilds();
            m_arbreRetour.ElementRacine.RecalculeCoefOperationnelFromChilds();

            double fCoefOpAller = m_arbreAller.ElementRacine.CoeffOperationnel;
            double fCoefOpRetour = m_arbreRetour.ElementRacine.CoeffOperationnel;

            double fCoefFinal = Math.Min(fCoefOpAller, fCoefOpRetour);

            if (fCoefFinal == 0.0)
            {
                EtatOperationnel = EEtatOperationnelSchema.HS;
            }
            else if (fCoefFinal > 0.0 && fCoefFinal < 1.0)
            {
                EtatOperationnel = EEtatOperationnelSchema.Degrade;
            }
            else // = 1 forcément
            {
                EtatOperationnel = EEtatOperationnelSchema.OK;
            }

        }


        private void CalculeIsOperationnel()
        {
            bool bOldOperationnel = m_bIsOperationnel;
            try
            {
                m_bIsOperationnel = true;
                if (GraviteAlarme < EGraviteAlarme.Major)
                    return;
                Dictionary<int, bool> dicSitesCoupes = new Dictionary<int, bool>();
                Dictionary<int, bool> dicLiensCoupes = new Dictionary<int, bool>();
                Dictionary<int, bool> dicEquipsCoupes = new Dictionary<int, bool>();
                //FillDicsCoupes(m_listeFils.ToArray(), dicSitesCoupes, dicLiensCoupes, dicEquipsCoupes);
                //Vérifie s'il y a des sites isolés en erreur, si oui, état opérationnel HS
                foreach (CNoeudDeGrapheReseau noeud in m_dicNoeudsIsoles.Keys)
                {
                    CNoeudDeGrapheReseauSite noeudSite = noeud as CNoeudDeGrapheReseauSite;
                    if (noeudSite != null && dicSitesCoupes.ContainsKey(noeudSite.IdSite))
                    {
                        m_bIsOperationnel = false;
                        return;
                    }
                    CNoeudDeGrapheReseauEquipement noeudEquip = noeud as CNoeudDeGrapheReseauEquipement;
                    if (noeudEquip != null && dicEquipsCoupes.ContainsKey(noeudEquip.IdEquipement))
                    {
                        m_bIsOperationnel = false;
                        return;
                    }
                }
                foreach (KeyValuePair<CPointAPointDeGraphe, List<CCheminDeGrapheReseau>> papToList in m_baseChemins)
                {
                    CPointAPointDeGraphe pap = papToList.Key;
                    List<CCheminDeGrapheReseau> cheminsPourPap = papToList.Value;
                    bool bHasOkForThisPap = false;
                    foreach (CCheminDeGrapheReseau chemin in cheminsPourPap)
                    {
                        bool bIsOk = true;
                        foreach (CNoeudDeGrapheReseau noeud in chemin.NoeudsUtilises)
                        {
                            CNoeudDeGrapheReseauSite noeudSite = noeud as CNoeudDeGrapheReseauSite;
                            if (noeudSite != null && dicSitesCoupes.ContainsKey(noeudSite.IdSite))
                            {
                                bIsOk = false;
                                break;
                            }
                            CNoeudDeGrapheReseauEquipement noeudEquip = noeud as CNoeudDeGrapheReseauEquipement;
                            if (noeudEquip != null && dicEquipsCoupes.ContainsKey(noeudEquip.IdEquipement))
                            {
                                bIsOk = false;
                                break;
                            }
                        }
                        if (bIsOk)
                        {
                            foreach (CLienDeGrapheReseau lien in chemin.Liens)
                            {
                                if (dicLiensCoupes.ContainsKey(lien.IdLienReseau))
                                {
                                    bIsOk = false;
                                    break;
                                }
                            }
                        }
                        bHasOkForThisPap |= bIsOk;
                    }
                    if (!bHasOkForThisPap)
                    {
                        m_bIsOperationnel = false;
                        return;
                    }
                }
            }
            finally
            {
                if (m_bIsOperationnel != bOldOperationnel)
                    m_base.OnChangementEtatSupervise(this);
            }
        }

        protected void PrepareSupervisionEtatOperationnel(CSchemaReseau schema)
        {
            m_listeGraphes.Clear();
            m_baseChemins.Clear();
            List<ESensAllerRetourLienReseau?> lstToCalcul = new List<ESensAllerRetourLienReseau?>();
            if (schema.LienReseau != null)
            {
                lstToCalcul.Add(null);
            }
            else
            {
                lstToCalcul.Add(ESensAllerRetourLienReseau.Forward);
                lstToCalcul.Add(ESensAllerRetourLienReseau.Backward);
            }
            foreach (ESensAllerRetourLienReseau? sens in lstToCalcul)
            {
                CGrapheReseau graphe = m_base.BaseGraphes.GetGrapheExistant(schema, sens);
                if (graphe == null)
                {
                    graphe = new CGrapheReseau(m_base.BaseGraphes);
                    graphe.IntegreLiaison = IntegreLienInGraphe;
                    if (graphe.CalculeGraphe(schema, sens))
                        m_listeGraphes.Add(graphe);
                }
                else
                    m_listeGraphes.Add(graphe);
            }
            if (m_listeGraphes.Count == 2)
            {
                //Si l'un des graphes a des liens et pas l'autre, supprime ce graphe
                int nNbLiens1 = m_listeGraphes[0].GetLiensNiveau0().Length;
                int nNbLiens2 = m_listeGraphes[1].GetLiensNiveau0().Length;
                if (nNbLiens1 == 0 && nNbLiens2 != 0)
                    m_listeGraphes.RemoveAt(0);
                else if (nNbLiens2 == 0)
                    m_listeGraphes.RemoveAt(1);
            }


            //Calcule tous les chemins de point d'entrée à point de sortie.
            m_baseChemins.Clear();
            m_dicNoeudsIsoles = new Dictionary<CNoeudDeGrapheReseau, bool>();
            if (m_listeGraphes.Count > 0)
                foreach (CNoeudDeGrapheReseau noeud in m_listeGraphes[0].GetNoeudsIsoles())
                    m_dicNoeudsIsoles[noeud] = true;
            int nIndex = 0;

            foreach (CGrapheReseau graphe in m_listeGraphes)
            {
                List<CNoeudDeGrapheReseau> noeudsDepart;
                List<CNoeudDeGrapheReseau> noeudsArrive;
                if ( schema.LienReseau != null )
                {
                    noeudsDepart = new List<CNoeudDeGrapheReseau>();
                    noeudsArrive = new List<CNoeudDeGrapheReseau>();
                    CLienReseau lien = schema.LienReseau;
                    CNoeudDeGrapheReseau noeud;
                    List<EDirectionLienReseau> lstCodes = new List<EDirectionLienReseau>();
                    if (lien.Direction.Code == EDirectionLienReseau.Bidirectionnel)
                    {
                        lstCodes.Add(EDirectionLienReseau.UnVersDeux);
                        lstCodes.Add(EDirectionLienReseau.DeuxVersUn);
                    }
                    else
                        lstCodes.Add(lien.Direction.Code);
                    foreach ( EDirectionLienReseau direction in lstCodes )
                    {
                        switch ( direction )
                        {
                        case EDirectionLienReseau.UnVersDeux:
                            noeud = graphe.GetNoeudForElement(lien.Element1, schema);
                            if (noeud != null)
                                noeudsDepart.Add(noeud);
                            noeud = graphe.GetNoeudForElement(lien.Element2, schema);
                            if (noeud != null)
                                noeudsArrive.Add(noeud);
                            break;
                        case EDirectionLienReseau.DeuxVersUn :
                            noeud = graphe.GetNoeudForElement(lien.Element2, schema);
                            if (noeud != null)
                                noeudsDepart.Add(noeud);
                            noeud = graphe.GetNoeudForElement(lien.Element1, schema);
                            if (noeud != null)
                                noeudsArrive.Add(noeud);
                            break;
                        }
                    }
                }
                else
                {
                    noeudsDepart = new List<CNoeudDeGrapheReseau>(graphe.GetNoeudsEntreeNiveau0());
                    noeudsArrive = new List<CNoeudDeGrapheReseau>(graphe.GetNoeudsSortieNiveau0());
                }

                foreach (CNoeudDeGrapheReseau noeudDepart in noeudsDepart)
                {
                    
                    foreach (CNoeudDeGrapheReseau noeudArrivee in noeudsArrive)
                    {
                        
                        CPointAPointDeGraphe pap = new CPointAPointDeGraphe(noeudDepart, noeudArrivee);
                        List<CCheminDeGrapheReseau> chemins = graphe.GetChemins(noeudDepart, noeudArrivee);
                        m_baseChemins.AddChemins(pap, chemins);
                        if ( chemins.Count != 0 )
                        {
                            if (m_dicNoeudsIsoles.ContainsKey(noeudDepart))
                                m_dicNoeudsIsoles.Remove(noeudDepart);
                            if (m_dicNoeudsIsoles.ContainsKey(noeudArrivee))
                                m_dicNoeudsIsoles.Remove(noeudArrivee);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Indique s'il faut intégrer un lien dans un graphe ou non
        /// </summary>
        /// <param name="lien"></param>
        /// <returns></returns>
        private bool IntegreLienInGraphe(CLienDeGrapheReseau lienDeGraphe)
        {
            CLienReseau lien = new CLienReseau(m_base.ContexteDonnee);
            if (lien.ReadIfExists(lienDeGraphe.IdLienReseau, false))
            {
                IElementALiensReseau elt1 = lien.Element1;
                IElementALiensReseau elt2 = lien.Element2;
                if ((!(elt1 is CSite) && !(elt1 is CEquipementLogique)) || (!(elt2 is CSite) && !(elt2 is CEquipementLogique)))
                    return false;
                return true;
                /*if (!(lien.Complement1 is CExtremiteLienSurSite) || !(lien.Complement2 is CExtremiteLienSurSite))
                    return false;
                CSpvLiai spvLiai = new CSpvLiai(m_base.ContexteDonnee);
                if (!spvLiai.ReadIfExists(new CFiltreData(CSpvLiai.c_champSmtLienReseau_Id + "=@1",
                    lien.Id), false))
                    return false;
                return true;*/
            }
            return false;
        }

        public override void AfterDrawObjet(CContextDessinObjetGraphique ctx, C2iObjetDeSchema objet)
        {
            if (!IsConcerneParAlarme)
                return;
            base.AfterDrawObjet(ctx, objet);
            //Image img = m_base.GetImageIsOperationnel(m_bIsOperationnel);
            Image img = m_base.GetImageEtatOperationnel(m_etatOperationnel);
            if (img != null)
            {
                ctx.Graphic.DrawImageUnscaled(img, objet.PositionAbsolue);
            }
        }

        public override CReferenceObjetDonnee GetReferenceObjetSpvAssocie()
        {
            return null;
        }


    }
}
