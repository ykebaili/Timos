using System;
using System.Collections.Generic;
using System.Text;
using timos.data;
using sc2i.data;

namespace spv.data.VueAnimee
{
    public class CInfoSiteDeSchemaSupervise : CInfoElementDeSchemaSupervise
    {
        private int m_nIdSite = -1;
        private int? m_nIdSiteSpv = null;
        public CInfoSiteDeSchemaSupervise(
            CInfoElementDeSchemaSupervise parent,
            CElementDeSchemaReseau eltDeSchema,
            CBasePourVueAnimee basePourVue,
            int nNiveauProfondeur)
            :base ( parent, eltDeSchema, basePourVue, nNiveauProfondeur )
        {
        }

        internal override void InitFromElementDeSchema(CElementDeSchemaReseau eltDeSchema)
        {
            base.InitFromElementDeSchema(eltDeSchema);
            CSite site = eltDeSchema.Site;
            if (site == null)
                throw new Exception("Bad element for supervision data ");
            InitForSite(site);
            //Cherche les cablages pour ce site
            foreach (CSchemaReseau sousSchema in eltDeSchema.SchemaReseau.SchemaFils)
                if (site.Equals(sousSchema.SiteApparenance))
                {
                    CInfoSchemaDeSchemaSupervise info = new CInfoSchemaDeSchemaSupervise(this, eltDeSchema, m_base,NiveauProfondeur+1);
                    m_listeFils.Add(info);
                    info.InitFromSchema(sousSchema);
                    break;
                }

        }

        internal void InitForSite ( CSite site )
        {
            m_nIdSite = site.Id;

            CSpvSite spvSite = CSpvSite.GetObjetSpvFromObjetTimos(site);

            if (spvSite != null)
            {
                m_nIdSiteSpv = spvSite.Id;
                m_dicSitesSpvConcernant[spvSite.Id] = true;
            }
        }

        public int IdSite
        {
            get
            {
                return m_nIdSite;
            }
        }


        public int? IdSiteSpv
        {
            get
            {
                return m_nIdSiteSpv;
            }
        }

        protected override void RecalculeGravite()
        {
            base.RecalculeGravite();
        }

        public override CReferenceObjetDonnee GetReferenceObjetSpvAssocie()
        {
            if (m_nIdSiteSpv != null)
                return new CReferenceObjetDonnee(typeof(CSpvSite), m_nIdSiteSpv.Value);
            return null;
        }
    }
}
