using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.data;

namespace timos.data.sites.releve.actions
{
    public class CActionTestMajEquipement : CActionTraitementReleveEquipement
    {
        public CActionTestMajEquipement(CReleveEquipement releve)
            : base(releve)
        {
        }

        public override IEnumerable<CActionTraitementReleveEquipement> GetSousActionsPossibles()
        {
            List<CActionTraitementReleveEquipement> lstActions = new List<CActionTraitementReleveEquipement>();
            CEquipement eqpt = ReleveEquipement.Equipement;
            if (
                eqpt.NumSerie.ToUpper().Trim() != ReleveEquipement.NumSerie.ToUpper().Trim() ||
                eqpt.TypeEquipement != ReleveEquipement.TypeEquipement ||
                eqpt.RelationConstructeur != ReleveEquipement.ReferenceConstructeur ||
                eqpt.Coordonnee != ReleveEquipement.Coordonnee ||
                !eqpt.Emplacement.Equals(ReleveEquipement.ReleveSite.Site) ||
                HasChampsCustomChange ( ReleveEquipement, eqpt ))
            {
                lstActions.Add(new CActionModifierEquipement(ReleveEquipement));
            }
            return lstActions.AsReadOnly();

        }

        //---------------------------------------------------
        private bool HasChampsCustomChange(CReleveEquipement releve, CEquipement equipement)
        {
            foreach (CRelationReleveEquipement_ChampCustom rel in releve.RelationsChampsCustom)
            {
                if (rel.ChampCustom != null && (rel.ChampCustom.HasRoleSecondaire(CEquipement.c_roleChampCustom) ||
                    rel.ChampCustom.CodeRole == CEquipement.c_roleChampCustom))
                {
                    object v1 = rel.Valeur;
                    object v2 = equipement.GetValeurChamp(rel.ChampCustom.Id);
                    if (v1 == v2)
                        return false;
                    if (v1 != null && v1.Equals(v2))
                        return false;
                    if ((v1 == null && v2 == "") || (v1 == "" && v2 == null))
                        return false;
                    return true;
                }
            }
            return false;
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
