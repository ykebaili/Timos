using System;
using System.Collections.Generic;
using System.Text;
using timos.data;
using sc2i.data;
using timos.data.snmp;
using sc2i.common;

namespace timos.data.supervision.vueanimee
{
    public class CInfoEntiteSnmpDeSchemaSupervise : CInfoElementDeSchemaSupervise
    {
        private CDbKey m_dbKeyEntiteSnmp;

        public CInfoEntiteSnmpDeSchemaSupervise(
            CInfoElementDeSchemaSupervise parent,
            CElementDeSchemaReseau eltDeSchema,
            CBasePourVueAnimee basePourVue, 
            int nNiveauProfondeur)
            :base ( parent, eltDeSchema, basePourVue, nNiveauProfondeur )
        {
        }

        public CDbKey DbKeyEntiteSnmp
        {
            get
            {
                return m_dbKeyEntiteSnmp;
            }
        }

        internal override void InitFromElementDeSchema(CElementDeSchemaReseau elementDeSchema)
        {

            base.InitFromElementDeSchema(elementDeSchema);
            CEntiteSnmp ettSnmp = elementDeSchema.EntiteSnmp;
            if ( ettSnmp == null )//Ca ne doit jamais arriver
                throw new Exception("Bad element for supervision data ");
            m_dbKeyEntiteSnmp = ettSnmp.DbKey;
            m_dicEntitesSnmpConcernant[ettSnmp.DbKey] = true;
            CDonneeDessinElementDeSchemaReseau donneeDessin = elementDeSchema.DonneeDessin as CDonneeDessinElementDeSchemaReseau;
            if (donneeDessin != null && donneeDessin.CollectChildsAlarms)
            {
                SoitConcernePar(ettSnmp.EntiteSnmpsFilles);
            }

        }

        private void SoitConcernePar ( CListeObjetsDonnees lstEntitesSnmp )
        {
            foreach (CEntiteSnmp ett in lstEntitesSnmp)
            {
                m_dicEntitesSnmpConcernant[ett.DbKey] = true;
            }
            lstEntitesSnmp = lstEntitesSnmp.GetDependances("EntiteSnmpsFilles");
            if (lstEntitesSnmp.Count > 0)
                SoitConcernePar(lstEntitesSnmp);
        }


        protected override void RecalculeGraviteEtMasquage()
        {
            base.RecalculeGraviteEtMasquage();
        }

        public override CReferenceObjetDonnee GetReferenceObjetAssocie()
        {
            return new CReferenceObjetDonnee(typeof(CEntiteSnmp), m_dbKeyEntiteSnmp);
        }

        

    }
}
