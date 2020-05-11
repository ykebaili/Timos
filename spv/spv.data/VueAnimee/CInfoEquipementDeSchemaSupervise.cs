using System;
using System.Collections.Generic;
using System.Text;
using timos.data;
using sc2i.data;

namespace spv.data.VueAnimee
{
    public class CInfoEquipementDeSchemaSupervise : CInfoElementDeSchemaSupervise
    {
        private int? m_nIdEquipementSpv = null;

        private CInfoRelation m_relationToEquipSpv = null;

        public CInfoEquipementDeSchemaSupervise(
            CInfoElementDeSchemaSupervise parent,
            CElementDeSchemaReseau eltDeSchema,
            CBasePourVueAnimee basePourVue, 
            int nNiveauProfondeur)
            :base ( parent, eltDeSchema, basePourVue, nNiveauProfondeur )
        {
        }

        public int? IdEquipementSpv
        {
            get
            {
                return m_nIdEquipementSpv;
            }
        }

        internal override void InitFromElementDeSchema(CElementDeSchemaReseau elementDeSchema)
        {

            base.InitFromElementDeSchema(elementDeSchema);
            CEquipementLogique eqtLogique = elementDeSchema.EquipementLogique;
            if ( eqtLogique == null )//Ca ne doit jamais arriver
                throw new Exception("Bad element for supervision data ");
            CSpvEquip equip = CSpvEquip.GetObjetSpvFromObjetTimos(eqtLogique);
            if (equip != null)
            {
                m_dicEquipementsSpvConcernant[equip.Id] = true;
                m_nIdEquipementSpv = equip.Id;
            }
            CDonneeDessinElementDeSchemaReseau donneeDessin = elementDeSchema.DonneeDessin as CDonneeDessinElementDeSchemaReseau;
            if (donneeDessin != null && donneeDessin.CollectChildsAlarms)
            {
                SoitConcernePar(eqtLogique.EquipementsLogiquesContenus);
            }

        }

        private void SoitConcernePar ( CListeObjetsDonnees lstEquips )
        {
            if ( m_relationToEquipSpv == null )
            {
                foreach ( CInfoRelation info in CContexteDonnee.GetListeRelationsTable ( CEquipementLogique.c_nomTable ) )
                {
                    if ( info.TableParente == CEquipementLogique.c_nomTable && info.TableFille == CSpvEquip.c_nomTable )
                    {
                        m_relationToEquipSpv = info;
                        break;
                    }
                }
            }
            lstEquips.GetDependances ( m_relationToEquipSpv ).AssureLectureFaite();
            foreach ( CEquipementLogique eqpt in lstEquips )
            {
                CSpvEquip spvEquip = new CSpvEquip (eqpt.ContexteDonnee );
                if ( spvEquip.ReadIfExists ( new CFiltreData ( CSpvEquip.c_champSmtEquipementLogique_Id+"=@1",
                    eqpt.Id), false ))
                    m_dicEquipementsSpvConcernant[spvEquip.Id] = true;
            }
            lstEquips = lstEquips.GetDependances ( "EquipementsLogiquesContenus" );
            if ( lstEquips.Count > 0 )
                SoitConcernePar ( lstEquips );
        }


        protected override void RecalculeGravite()
        {
            base.RecalculeGravite();
        }

        public override CReferenceObjetDonnee GetReferenceObjetSpvAssocie()
        {
            if ( m_nIdEquipementSpv != null )
                return new CReferenceObjetDonnee ( typeof(CSpvEquip), IdEquipementSpv.Value );
            return null;
        }

    }
}
