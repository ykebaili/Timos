using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.data;

namespace timos.data.sites.releve.actions
{
    public class CActionModifierEquipement : CActionTraitementReleveEquipement
    {
        //-------------------------------------------------------------------------------------
        public CActionModifierEquipement(CReleveEquipement releve)
            : base(releve)
        {
            Info = I.T("The collected data are different from Timos data|20213");
        }

        //-------------------------------------------------------------------------------------
        public override IEnumerable<CActionTraitementReleveEquipement> GetSousActionsPossibles()
        {
            return new List<CActionTraitementReleveEquipement>().AsReadOnly();
        }

        //-------------------------------------------------------------------------------------
        public override string Libelle
        {
            get 
            {
                try
                {
                    if (!ReleveEquipement.Equipement.Emplacement.Equals(
                        ReleveEquipement.ReleveSite.Site))
                        return I.T("Move @1 to @2 and update equipment|20214",
                            ReleveEquipement.Equipement.Libelle,
                            ReleveEquipement.ReleveSite.Site.LibelleComplet);
                }
                catch { }
                return I.T("Update equipment @1|20208", ReleveEquipement.Equipement.Libelle); 
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
            return result;
        }

        //---------------------------------------------------------------
        public static CResultAErreur MajEquipement(CEquipement equipement,
            CReleveEquipement releve)
        {
            if (equipement != null)
            {
                equipement.TypeEquipement = releve.TypeEquipement;
                equipement.RelationConstructeur = releve.ReferenceConstructeur;
                equipement.NumSerie = releve.NumSerie;
                equipement.Coordonnee = releve.Coordonnee;
                foreach (CRelationReleveEquipement_ChampCustom rel in releve.RelationsChampsCustom)
                {
                    if (rel.ChampCustom != null &&
                        (rel.ChampCustom.HasRoleSecondaire(CEquipement.c_roleChampCustom) ||
                        rel.ChampCustom.CodeRole == CEquipement.c_roleChampCustom))
                        equipement.SetValeurChamp(rel.ChampCustom.DbKey.StringValue, rel.Valeur);
                }
            }
            return CResultAErreur.True;
        }

        //---------------------------------------------------------------
        public override CResultAErreur ExecuteAction(
            CTraitementReleveEquipement traitementExecutant, 
            CEquipement equipementParent, 
            CContexteDonnee ctxDonnee)
        {
            return MajEquipement ( 
                (CEquipement)ReleveEquipement.Equipement.GetObjetInContexte ( ctxDonnee ),
                ReleveEquipement );
        }
    }
}
