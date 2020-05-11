using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.data;

namespace timos.data.sites.releve.actions
{
    public class CActionCreerEquipement : CActionTraitementReleveEquipement
    {
        //---------------------------------------------------------------
        public CActionCreerEquipement ( CReleveEquipement releve )
            :base ( releve )
        {
        }

        //---------------------------------------------------------------
        public override IEnumerable<CActionTraitementReleveEquipement> GetSousActionsPossibles()
        {
            return new CActionTraitementReleveEquipement[0];
        }

        //---------------------------------------------------------------
        public override string Libelle
        {
            get { return I.T("Create equipment @1 @2|20205",
                ReleveEquipement.TypeEquipement.Libelle,ReleveEquipement.NumSerie); }
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

        //----------------------------------------------------------------------------------
        public override CResultAErreur ExecuteAction(
            CTraitementReleveEquipement traitementExecutant,
            CEquipement equipementParent,
            CContexteDonnee ctxDonnee)
        {
            CEquipement newEqpt = new CEquipement(ctxDonnee);
            newEqpt.CreateNewInCurrentContexte();
            CResultAErreur result = CActionModifierEquipement.MajEquipement(newEqpt,
                traitementExecutant.ReleveEquipement);
            newEqpt.SetEmplacementSansHistorique ( traitementExecutant.ReleveEquipement.ReleveSite.Site,
                equipementParent );
            EquipementParentPourTraitementsFils = newEqpt;
            CStatutEquipement status = ReleveEquipement.ReleveSite.StatutEquipementParDefaut;
            if (status == null)
            {
                result.EmpileErreur(I.T("You have to define a default status for survey|20221"));
                return result;
            }
            newEqpt.Statut = status;
            return CResultAErreur.True;
        }
        
    }
}
