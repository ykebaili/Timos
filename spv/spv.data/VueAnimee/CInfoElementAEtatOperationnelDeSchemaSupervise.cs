using System;
using System.Collections.Generic;
using System.Text;
using timos.data;
using timos.data.reseau.graphe;
using sc2i.common;
using sc2i.data;

namespace spv.data.VueAnimee
{
    public abstract class CInfoElementAEtatOperationnelDeSchemaSupervise : CInfoElementDeSchemaSupervise
    {
        //Graphe aller si on travaille avec un sens aller/retour, ou graphe simple sinon
        private List<CGrapheReseau> m_listeGraphes = new List<CGrapheReseau>();
        private CBaseCheminsPointAPoint m_baseChemins = new CBaseCheminsPointAPoint();
        private Dictionary<CNoeudDeGrapheReseau, bool> m_dicNoeudsIsoles = new Dictionary<CNoeudDeGrapheReseau, bool>();

        public CInfoElementAEtatOperationnelDeSchemaSupervise(
            CInfoElementDeSchemaSupervise parent,
            CElementDeSchemaReseau eltDeSchema,
            CBasePourVueAnimee basePourVue)
            :base ( parent, eltDeSchema, basePourVue )
        {
        }

        protected void PrepareSupervisionEtatOperationnel(CSchemaReseau schema)
        {
            m_listeGraphes.Clear();
            List<ESensAllerRetourLienReseau?> lstToCalcul = new List<ESensAllerRetourLienReseau?>();
            if (schema.LienReseau != null)
            {
                lstToCalcul.Add ( null );
            }
            else{
                lstToCalcul.Add ( ESensAllerRetourLienReseau.Forward );
                lstToCalcul.Add ( ESensAllerRetourLienReseau.Backward );
            }
            foreach ( ESensAllerRetourLienReseau? sens in lstToCalcul )
            {
                CGrapheReseau graphe = m_base.BaseGraphes.GetGrapheExistant ( schema, sens );
                if ( graphe == null )
                {
                    graphe = new CGrapheReseau(m_base.BaseGraphes);
                graphe.IntegreLiaison = IntegreLienInGraphe;
                if (graphe.CalculeGraphe(schema, sens))
                    m_listeGraphes.Add(graphe);
                }
                else
                    m_listeGraphes.Add ( graphe );
            }
            if (m_listeGraphes.Count == 2)
            {
                //Si l'un des graphes a des liens et pas l'autre, supprime ce graphe
                int nNbLiens1 = m_listeGraphes[0].GetLiensNiveau0().Length ;
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

            foreach ( CGrapheReseau graphe in m_listeGraphes )
            {
                List<CNoeudDeGrapheReseau> noeudsDepart = new List<CNoeudDeGrapheReseau>(graphe.GetNoeudsEntreeNiveau0());
                List<CNoeudDeGrapheReseau> noeudsArrive = new List<CNoeudDeGrapheReseau>(graphe.GetNoeudsSortieNiveau0());
                foreach ( CNoeudDeGrapheReseau noeudDepart in noeudsDepart )
                {
                    if (m_dicNoeudsIsoles.ContainsKey(noeudDepart))
                        m_dicNoeudsIsoles.Remove(noeudDepart);
                    foreach ( CNoeudDeGrapheReseau noeudArrivee in noeudsArrive )
                    {
                        if (m_dicNoeudsIsoles.ContainsKey(noeudArrivee))
                            m_dicNoeudsIsoles.Remove(noeudArrivee);
                        CPointAPointDeGraphe pap = new CPointAPointDeGraphe(noeudDepart, noeudArrivee);
                        m_baseChemins.Add ( pap, graphe.GetChemins ( noeudDepart, noeudArrivee ));
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
                if (!(lien.Complement1 is CExtremiteLienSurSite) || !(lien.Complement2 is CExtremiteLienSurSite))
                    return false;
                CSpvLiai spvLiai = new CSpvLiai(m_base.ContexteDonnee);
                if (!spvLiai.ReadIfExists(new CFiltreData(CSpvLiai.c_champSmtLienReseau_Id + "=@1",
                    lien.Id), false))
                    return false;
                return true;
            }
            return false;
        }
    }
}
