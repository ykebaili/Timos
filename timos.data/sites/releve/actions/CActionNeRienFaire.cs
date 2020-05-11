using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace timos.data.sites.releve.actions
{
    public class CActionNeRienFaire : CActionTraitementReleveEquipement
    {
        public CActionNeRienFaire(CReleveEquipement releve)
            : base(releve)
        {
        }

        //---------------------------------------------------------------
        public override IEnumerable<CActionTraitementReleveEquipement> GetSousActionsPossibles()
        {
            return new CActionTraitementReleveEquipement[0];
        }

        //----------------------------------------------------------------------------------
        public override string Libelle
        {
            get { return I.T("Do nothing|20209"); }
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
            return result;
        }

        //---------------------------------------------------------------
        public override CResultAErreur ExecuteAction(CTraitementReleveEquipement traitementExecutant, CEquipement equipementParent, sc2i.data.CContexteDonnee ctxDonnee)
        {
            return CResultAErreur.True;
        }
    }
}
