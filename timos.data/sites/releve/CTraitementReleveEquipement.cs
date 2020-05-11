using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using timos.data.sites.releve;
using sc2i.data;
using timos.data.sites.releve.actions;
using sc2i.common;

namespace timos.data
{
    public class CTraitementReleveEquipement
    {
        private List<CTraitementReleveEquipement> m_traitementsFils = new List<CTraitementReleveEquipement>();

        private CReleveEquipement m_releve;
        private CActionTraitementReleveEquipement m_action = null;
        private string m_strInfo = "";
        private EEtatValidationReleveEquipement m_etatValidation = EEtatValidationReleveEquipement.None;

        //------------------------------------------------------------------
        public CTraitementReleveEquipement()
        {
        }

        //------------------------------------------------------------------
        public IEnumerable<CTraitementReleveEquipement> TraitementsFils
        {
            get
            {
                return m_traitementsFils.AsReadOnly();
            }
        }

        //------------------------------------------------------------------
        public void AddTraitementFils(CTraitementReleveEquipement traitement)
        {
            m_traitementsFils.Add(traitement);
        }

        //------------------------------------------------------------------
        public CActionTraitementReleveEquipement Action
        {
            get
            {
                return m_action;
            }
            set
            {
                if (m_etatValidation == EEtatValidationReleveEquipement.Appliquée)
                    return;
                m_action = value;
            }
        }

        //------------------------------------------------------------------
        public CReleveEquipement ReleveEquipement
        {
            get
            {
                return m_releve;
            }
            set
            {
                m_releve = value;
                m_etatValidation = m_releve != null ? m_releve.EtatValidation.Code : EEtatValidationReleveEquipement.None;
                m_strInfo = m_releve != null ? m_releve.InformationsChoix : "";
            }
        }

        //------------------------------------------------------------------
        public CActionTraitementReleveEquipement GetDefaultAction()
        {
            if (ReleveEquipement == null)
                return null;
            CActionTraitementReleveEquipement action = null;
            if (ReleveEquipement.Presence == true)
                action = new CActionSiPresent(ReleveEquipement);
            else if (ReleveEquipement.Presence == false)
                action = new CActionSiAbsent(ReleveEquipement);
            else
                action = new CActionSiPresenceNulle(ReleveEquipement);
            m_strInfo = action.Info;
            IEnumerable<CActionTraitementReleveEquipement> lst = action.GetSousActionsPossibles();
            while (lst.Count() == 1)
            {
                action = lst.ElementAt(0);
                if (action.Info.Trim().Length > 0)
                    m_strInfo = action.Info;
                lst = action.GetSousActionsPossibles();
            }
            if (action != null && action.GetSousActionsPossibles().Count() == 0 &&
                !action.IsExecutable)
                action = null;
            if (action != null && action.Info.Trim().Length > 0)
                m_strInfo = action.Info;
            if (action == null && m_strInfo.Trim().Length == 0)
                m_strInfo = sc2i.common.I.T("Nothing to signal on survey, check contained equipments|20219");
            return action;
        }

        //------------------------------------------------------------------
        public void CalculeAction()
        {
            Action = GetDefaultAction();
        }

        //------------------------------------------------------------------
        public string Info
        {
            get
            {
                return m_strInfo;
            }
        }

        //------------------------------------------------------------------
        public EEtatValidationReleveEquipement EtatValidation
        {
            get
            {
                if (Action == null)
                    return EEtatValidationReleveEquipement.Appliquée;
                if (!Action.IsExecutable)
                    return EEtatValidationReleveEquipement.None;
                return m_etatValidation;
            }
            set
            {
                m_etatValidation = value;
            }
        }

       

        //------------------------------------------------------------------
        public bool HasChildToValidate()
        {
            return m_traitementsFils.FirstOrDefault(e => e.HasChildToValidate() || e.EtatValidation==EEtatValidationReleveEquipement.None) != null;
        }

        //------------------------------------------------------------------
        public void StoreInContexte(CContexteDonnee ctx)
        {
            CReleveEquipement releve = m_releve.GetObjetInContexte(ctx) as CReleveEquipement;
            if (releve != null)
            {
                releve.CodeEtatValidationAction = (int)EtatValidation;
                releve.InformationsChoix = Info;
                releve.Action = this.Action;
            }
            foreach (CTraitementReleveEquipement traitement in TraitementsFils)
            {
                traitement.StoreInContexte(ctx);
            }
        }

        //------------------------------------------------------------------
        public CResultAErreur Execute(CContexteDonnee ctxExecution, CEquipement equipementParent)
        {
            CResultAErreur result = CResultAErreur.True;
            CEquipement eqpt = ReleveEquipement.Equipement;
            if (Action != null && EtatValidation == EEtatValidationReleveEquipement.Validé)
            {
                result = Action.ExecuteAction(this, equipementParent, ctxExecution);
                eqpt = Action.EquipementParentPourTraitementsFils;
            }
            if (!result)
                return result;
            foreach (CTraitementReleveEquipement traitement in TraitementsFils)
            {
                result = traitement.Execute(ctxExecution, eqpt);
                if (!result)
                    return result;
            }
            if (result && EtatValidation == EEtatValidationReleveEquipement.Validé)
            {
                EtatValidation = EEtatValidationReleveEquipement.Appliquée;
                CReleveEquipement releve = ReleveEquipement.GetObjetInContexte(ctxExecution) as CReleveEquipement;
                releve.CodeEtatValidationAction = (int)EEtatValidationReleveEquipement.Appliquée;
            }
            return result;
        }

    }
}
