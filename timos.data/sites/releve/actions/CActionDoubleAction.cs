using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.data;

namespace timos.data.sites.releve.actions
{
    public class CActionDoubleAction : CActionTraitementReleveEquipement
    {
        private CActionTraitementReleveEquipement m_action1;
        private CActionTraitementReleveEquipement m_action2;

        //---------------------------------------------------------------
        public CActionDoubleAction(CReleveEquipement releve)
            :base ( releve)
        {
        }

        //---------------------------------------------------------------
        public CActionDoubleAction ( CReleveEquipement releve,
            CActionTraitementReleveEquipement action1,
            CActionTraitementReleveEquipement action2)
            :base ( releve )
        {
            m_action1 = action1;
            m_action2 = action2;
        }

        //---------------------------------------------------------------
        public override IEnumerable<CActionTraitementReleveEquipement> GetSousActionsPossibles()
        {
            return new CActionTraitementReleveEquipement[0];
        }

        //---------------------------------------------------------------
        public override string Libelle
        {
            get
            {
                StringBuilder bl = new StringBuilder();
                if ( m_action1 != null )
                {
                    bl.Append(m_action1.Libelle);
                }
                if ( m_action2 != null )
                {
                    if (bl.Length > 0)
                    {
                        bl.Append(' ');
                        bl.Append(I.T("and|20215"));
                        bl.Append(' ');
                    }
                    bl.Append ( m_action2.Libelle );
                }
                return bl.ToString();
            }

        }

        //---------------------------------------------------------------
        public override bool IsExecutable
        {
            get { return true; }
        }

        //---------------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //---------------------------------------------------------------
        protected override CResultAErreur MySerialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = serializer.TraiteObject<CActionTraitementReleveEquipement>(ref m_action1, ReleveEquipement);
            if (result)
                result = serializer.TraiteObject<CActionTraitementReleveEquipement>(ref m_action2, ReleveEquipement);
            if (!result)
                return result;
            return result;
        }

        //--------------------------------------------------------------------------
        public override CResultAErreur ExecuteAction(
            CTraitementReleveEquipement traitementExecutant,
            CEquipement equipementParent,
            CContexteDonnee ctxDonnee)
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_action1 != null)
                result = m_action1.ExecuteAction(traitementExecutant,
                    equipementParent,
                    ctxDonnee);
            if (result && m_action2 != null)
                result = m_action2.ExecuteAction(traitementExecutant,
                    equipementParent,
                    ctxDonnee);
            return result;
        }
        
    }
}
