using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using sc2i.win32.common.customizableList;
using sc2i.common;
using timos.data;
using sc2i.data;
using timos.acteurs;
using timos.win32.composants;

namespace timos.interventions
{
    public partial class CControleAffecteUnIntervenantDeProfil : CCustomizableListControl, IControlALockEdition
    {
        private CIntervention m_intervention = null;
        private CTypeIntervention_ProfilIntervenant m_relProfil = null;
        //------------------------------------------------------------------------
        public CControleAffecteUnIntervenantDeProfil()
        {
            InitializeComponent();
            CWin32Traducteur.Translate(this);
        }

        //------------------------------------------------------------------------
        public void InitIntervention(CIntervention intervention,
            CTypeIntervention_ProfilIntervenant relProfil)
        {
            m_intervention = intervention;
            m_relProfil = relProfil;
        }

        #region IControlALockEdition Membres
        //------------------------------------------------------------------------
        public bool LockEdition
        {
            get
            {
                return !m_extModeEdition.ModeEdition;
            }
            set
            {
                m_extModeEdition.ModeEdition = !value;
                if (OnChangeLockEdition != null)
                    OnChangeLockEdition(this, null);
            }
        }

        public event EventHandler OnChangeLockEdition;

        #endregion

        //-----------------------------------------------------------------
        public override bool IsFixedSize
        {
            get
            {
                return true;
            }
        }

        //---------------------------------------------------------------------------------------
        protected override CResultAErreur MyInitChamps(CCustomizableListItem item)
        {
            CResultAErreur result = base.MyInitChamps(item);
            if (item != null)
            {
                if ( m_intervention != null && m_relProfil != null )
                {
                    if (!IsCreatingImage)
                    {
                        // Init la la TextBoxSelectionne avec le filtre par défaut des Intervenants et un filtre rapide
                        CFiltreData filtre = null;
                        if (m_intervention != null && m_intervention.TypeIntervention != null && m_intervention.TypeIntervention.FiltreDynamiqueIntervenants != null)
                        {
                            result = m_intervention.TypeIntervention.FiltreDynamiqueIntervenants.GetFiltreData();
                            if (result)
                            {
                                filtre = result.Data as CFiltreData;
                            }
                        }
                        m_txtSelectIntervenant.InitAvecFiltreDeBase<CActeur>("IdentiteComplete", filtre, true);
                    }
                    else
                        m_txtSelectIntervenant.Init<CActeur>("IdentiteComplete", false);
                }
                CIntervention_Intervenant rel = item.Tag as CIntervention_Intervenant;
                if (rel != null && rel.IsValide())
                {
                    m_txtSelectIntervenant.ElementSelectionne = rel.Intervenant;
                }
                else
                    m_txtSelectIntervenant.ElementSelectionne = null;
            }
            return result;
        }

        //---------------------------------------------------------------------------------------
        private void m_txtSelectIntervenant_ElementSelectionneChanged(object sender, EventArgs e)
        {
            HasChange = true;
        }

        //---------------------------------------------------------------------------------------
        protected override CResultAErreur MyMajChamps()
        {
            CResultAErreur result = base.MyMajChamps();
            if (result && CurrentItem != null)
            {
                CIntervention_Intervenant rel = CurrentItem.Tag as CIntervention_Intervenant;
                CActeur acteur = m_txtSelectIntervenant.ElementSelectionne as CActeur;
                if (rel == null && acteur != null )
                {
                    rel = new CIntervention_Intervenant(m_intervention.ContexteDonnee);
                    rel.CreateNewInCurrentContexte();
                    rel.Intervention = m_intervention;
                    rel.RelationProfil = m_relProfil;
                    CurrentItem.Tag = rel;
                }
                if (rel != null)
                {
                    rel.Intervenant = acteur;
                }
            }
            return result;
        }


        //-----------------------------------------------------------------------------
        private void m_lnkAffectationRapide_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ( m_relProfil != null && m_intervention != null )
            {
			    CFormChercheIntervenant.FindIntervenant(
                    m_intervention,
                    m_relProfil,
				new SetIntervenantEventHandler(OnSelectIntervenant));
            }
        }

        //-------------------------------------------------------------------------------------
        private void OnSelectIntervenant(object sender, CActeur acteur)
        {
            m_txtSelectIntervenant.ElementSelectionne = acteur;
        }

        //-------------------------------------------------------------------------------------
        private void m_picDelete_Click(object sender, EventArgs e)
        {

        }

        
    }
}
