using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.data;

namespace timos.data.sites.releve.actions
{
    public class CActionSiPresentEtLieAEquipement : CActionTraitementReleveEquipement
    {
        //------------------------------------------------------------------------
        public CActionSiPresentEtLieAEquipement(CReleveEquipement releve)
            : base(releve)
        {
        }

        //------------------------------------------------------------------------
        public override IEnumerable<CActionTraitementReleveEquipement> GetSousActionsPossibles()
        {
            List<CActionTraitementReleveEquipement> lstActions = new List<CActionTraitementReleveEquipement>();
            if (!ReleveEquipement.Equipement.Emplacement.Equals(ReleveEquipement.ReleveSite.Site))
                lstActions.Add(new CActionSiEquipementLiePlusSurSite(ReleveEquipement));
            else
                lstActions.Add(new CActionTraiterEquipementLiePresent(ReleveEquipement));
            return lstActions.AsReadOnly();
        }

        //---------------------------------------------------
        public override string Libelle
        {
            get { return I.T("Choose action|20207"); }
        }

        //---------------------------------------------------------------
        public override bool IsExecutable
        {
            get { return false; }
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
            return result;
        }

        //--------------------------------------------------------------------------
        public override CResultAErreur ExecuteAction(
            CTraitementReleveEquipement traitementExecutant,
            CEquipement equipementParent,
            CContexteDonnee ctxDonnee)
        {
            CResultAErreur result = CResultAErreur.True;
            result.EmpileErreur("Action '@1' can not be executed on '@2'|20220",
                Libelle,
                traitementExecutant.ReleveEquipement.DescriptionElement);
            return result;
        }
    }
}
