using System;
using System.Collections.Generic;
using System.Text;
using timos.data;
using sc2i.data;
using sc2i.common;

namespace timos.data.supervision.vueanimee
{
    public class CInfoEquipementDeSchemaSupervise : CInfoElementDeSchemaSupervise
    {
        private CDbKey m_dbKeyEquipement = null;

        public CInfoEquipementDeSchemaSupervise(
            CInfoElementDeSchemaSupervise parent,
            CElementDeSchemaReseau eltDeSchema,
            CBasePourVueAnimee basePourVue, 
            int nNiveauProfondeur)
            :base ( parent, eltDeSchema, basePourVue, nNiveauProfondeur )
        {
        }

        public CDbKey IdEquipement
        {
            get
            {
                return m_dbKeyEquipement;
            }
        }

        internal override void InitFromElementDeSchema(CElementDeSchemaReseau elementDeSchema)
        {

            base.InitFromElementDeSchema(elementDeSchema);
            CEquipementLogique eqtLogique = elementDeSchema.EquipementLogique;
            if ( eqtLogique == null )//Ca ne doit jamais arriver
                throw new Exception("Bad element for supervision data ");
            m_dbKeyEquipement = eqtLogique.DbKey;
            m_dicEquipementsConcernant[eqtLogique.DbKey] = true;
            CDonneeDessinElementDeSchemaReseau donneeDessin = elementDeSchema.DonneeDessin as CDonneeDessinElementDeSchemaReseau;
            if (donneeDessin != null && donneeDessin.CollectChildsAlarms)
            {
                SoitConcernePar(eqtLogique.EquipementsLogiquesContenus);
            }

        }

        private void SoitConcernePar ( CListeObjetsDonnees lstEquips )
        {
            foreach ( CEquipementLogique eqpt in lstEquips )
            {
                m_dicEquipementsConcernant[eqpt.DbKey] = true;
            }
            lstEquips = lstEquips.GetDependances ( "EquipementsLogiquesContenus" );
            if ( lstEquips.Count > 0 )
                SoitConcernePar ( lstEquips );
        }


        protected override void RecalculeGraviteEtMasquage()
        {
            base.RecalculeGraviteEtMasquage();
        }

        public override CReferenceObjetDonnee GetReferenceObjetAssocie()
        {
            return new CReferenceObjetDonnee(typeof(CEquipementLogique), m_dbKeyEquipement);
        }

        

    }
}
