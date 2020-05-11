using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using timos.data.reseau.graphe;
using sc2i.common;
using sc2i.data;

namespace timos.data.reseau.arbre_operationnel
{
    public class CElementDeArbreOperationnelEntite: CElementDeArbreOperationnel
    {
        private CComposantDeGrapheReseau m_composant;

        public CElementDeArbreOperationnelEntite(
            CElementDeArbreOperationnel elementParent,
            CComposantDeGrapheReseau composant)
            :base ( elementParent )
        {
            m_composant = composant;
        }

        /// <summary>
        /// Indique le composant lié à l'élément
        /// </summary>
        public CComposantDeGrapheReseau Composant
        {
            get
            {
                return m_composant;
            }
            set
            {
                m_composant = value;
            }
        }


        public override void Simplifier()
        {
        }

        public override string ToString()
        {
            return  sc2i.common.DynamicClassAttribute.GetNomConvivial(m_composant.GetType()) + "/" + m_composant.IdSchemaReseau+"_"+m_composant.IdObjet;
        }

        public override string GetKeyFactorisation()
        {
            return sc2i.common.DynamicClassAttribute.GetNomConvivial(m_composant.GetType()) + "/" + m_composant.IdSchemaReseau + "_" + m_composant.IdObjet;  
        }

        public override string GetFullKey()
        {
            return GetKeyFactorisation();
        }

        protected override void  MyRecalculeCoefOperationnelFromChilds()
        {
        }

        public override IEnumerable<CElementDeArbreOperationnel> Fils
        {
            get
            {
                return new CElementDeArbreOperationnel[0];
            }
        }

        /// <summary>
        /// Le data du result contient l'élément de cablage ou null
        /// </summary>
        /// <param name="sens"></param>
        /// <param name="contexteDonnee"></param>
        /// <returns></returns>
        public CResultAErreur GetElementCablage(
            ESensAllerRetourLienReseau ? sens,
            CContexteDonnee contexteDonnee)
        {
            CResultAErreur result = CResultAErreur.True;

            CNoeudDeGrapheReseauSite noeudSite = Composant as CNoeudDeGrapheReseauSite;
            if (noeudSite == null || !noeudSite.IsCable)//Pas un site ou pas cablé
                return result;

            CSchemaReseau schema = new CSchemaReseau(contexteDonnee);
            if (!schema.ReadIfExists(Composant.IdSchemaReseau))
            {
                result.EmpileErreur(I.T("Can not find network diagram @1|20051", Composant.IdSchemaReseau.ToString()));
                return result;
            }

            CSchemaReseau schemaCablage = schema.GetSousSchemas().FirstOrDefault(s =>
                                            s.SiteApparenance != null &&
                                            s.SiteApparenance.Id == noeudSite.IdSite);
                                                     
            
            CGrapheReseau grapheCablage = new CGrapheReseau ( null );
            result = grapheCablage.CalculeGraphe(schemaCablage, sens );
            if ( !result )
                return result;
            CArbreOperationnel arbreGraphe = new CArbreOperationnel ();
            result = arbreGraphe.CalculArbreRedondanceAuto ( schemaCablage, grapheCablage );
            if (result)
                result.Data = arbreGraphe.ElementRacine;
            return result;
        }

    }
}
