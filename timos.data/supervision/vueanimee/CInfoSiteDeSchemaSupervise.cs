using System;
using System.Collections.Generic;
using System.Text;
using timos.data;
using sc2i.data;
using sc2i.common;

namespace timos.data.supervision.vueanimee
{
    public class CInfoSiteDeSchemaSupervise : CInfoElementDeSchemaSupervise
    {
        private CDbKey m_dbKeySite = null;


        public CInfoSiteDeSchemaSupervise(
            CInfoElementDeSchemaSupervise parent,
            CElementDeSchemaReseau eltDeSchema,
            CBasePourVueAnimee basePourVue,
            int nNiveauProfondeur)
            : base(parent, eltDeSchema, basePourVue, nNiveauProfondeur)
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
                    CInfoSchemaDeSchemaSupervise info = new CInfoSchemaDeSchemaSupervise(this, eltDeSchema, m_base, NiveauProfondeur + 1);
                    m_listeFils.Add(info);
                    info.InitFromSchema(sousSchema);
                    break;
                }

        }

        internal void InitForSite(CSite site)
        {
            m_dbKeySite = site.DbKey;

            m_dicSitesConcernant[site.DbKey] = true;

        }

        public CDbKey IdSite
        {
            get
            {
                return m_dbKeySite;
            }
        }


        protected override void RecalculeGraviteEtMasquage()
        {
            base.RecalculeGraviteEtMasquage();
        }

        public override CReferenceObjetDonnee GetReferenceObjetAssocie()
        {
            return new CReferenceObjetDonnee(typeof(CSite), m_dbKeySite);
        }
    }
}
