using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using timos.data.commandes;
using timos.data;
using sc2i.data;
using sc2i.win32.common;
using sc2i.common;
using sc2i.win32.common.customizableList;
using sc2i.win32.data.dynamic;
using timos.data.equipement.consommables;
using sc2i.common.unites;
using sc2i.common.unites.standard;

namespace timos.commandes
{
    public partial class CControleEditeValorisationEquipement : CCustomizableListControl, IControlALockEdition
    {
        public event EventHandler OnDelete;
        public event EventHandler OnAddLigne;

        private CDonneesActeurFournisseur m_fournisseurPourFiltre = null;

        //---------------------------------------------------------------
        public CControleEditeValorisationEquipement()
        {
            InitializeComponent();
            CWin32Traducteur.Translate(this);
        }

        protected override CResultAErreur MyInitChamps(CCustomizableListItem item)
        {
            CResultAErreur result = CResultAErreur.True;
            if (item == null)
                return result;
            CValorisationElement ligne = item.Tag as CValorisationElement;
            if (ligne == null || !ligne.IsValide())
            {
                MyInitChamps(null);
                return result;
            }
            CLotValorisation lot = ligne.LotValorisation;

            m_selectTypeEquipement.InitMultiple(new CConfigTextBoxFiltreRapide[]{
                new CConfigTextBoxFiltreRapide(
                    typeof(CTypeEquipement),
                    null,
                    "Libelle"),
            new CConfigTextBoxFiltreRapide(
                typeof(CTypeConsommable),
                null,
                "Libelle"),
            new CConfigTextBoxFiltreRapide(
                typeof(CTypeOperation),
                null,
                "Libelle")}, false);

            m_selectTypeEquipement.ElementSelectionne = ligne.ElementValorisé as CObjetDonnee;
            if (ligne != null && ligne.EquipementsLies.Count > 0)
            {
                m_extModeEdition.SetModeEdition(m_selectTypeEquipement, TypeModeEdition.Autonome);
                m_selectTypeEquipement.LockEdition = true;
            }
            else
            {
                m_extModeEdition.SetModeEdition(m_selectTypeEquipement, TypeModeEdition.EnableSurEdition);
                m_selectTypeEquipement.LockEdition = !m_extModeEdition.ModeEdition;
            }
            m_txtValeur.DoubleValue = ligne != null ? (double?)ligne.Valeur : null;
            if (ligne != null && ligne.IsNew() && ligne.Valeur == 0)
                m_txtValeur.DoubleValue = null;
            UpdateQuantite();
            return result;
        }



        #region IControlALockEdition Membres

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

        //----------------------------------------------------------------
        protected override CResultAErreur MyMajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_extModeEdition.ModeEdition)
            {
                CValorisationElement ligne = CurrentItem != null ? CurrentItem.Tag as CValorisationElement : null;
                if (ligne != null && ligne.IsValide())
                {
                    ligne.ElementValorisé = m_selectTypeEquipement.ElementSelectionne as IElementValorisable;
                    ligne.Valeur = m_txtValeur.DoubleValue == null ? 0 : m_txtValeur.DoubleValue.Value;
                    ligne.QuantiteEtUnite = m_txtQuantite.UnitValue;
                }
            }
            return result;
        }

        //----------------------------------------------------------------
        private void m_btnPoubelle_Click(object sender, EventArgs e)
        {
            if (OnDelete != null)
            {
                OnDelete(this, null);
            }
        }

        //---------------------------------------------------------------
        private void m_btnLigneSuivante_Click(object sender, EventArgs e)
        {
            if (OnAddLigne != null)
            {
                OnAddLigne(this, null);
            }
        }

        public override bool HasChange
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        //----------------------------------------------------------------------------------------------
        private void m_selectTypeEquipement_ElementSelectionneChanged(object sender, EventArgs e)
        {

            UpdateQuantite();
        }

        //----------------------------------------------------------------------------------------------
        private void UpdateQuantite()
        {
            CTypeConsommable tpCons = m_selectTypeEquipement.ElementSelectionne as CTypeConsommable;
            if (tpCons != null && CurrentItem != null)
            {
                CValorisationElement val = CurrentItem.Tag as CValorisationElement;
                IUnite unite = tpCons.Unite;
                if (unite != null)
                {
                    m_txtQuantite.DefaultFormat = unite.LibelleCourt;
                }
                m_txtQuantite.UseValueFormat = true;
                CValeurUnite v = val.QuantiteEtUnite;
                if (v != null && unite != null)
                {
                    if (v.IUnite == null || v.IUnite.Classe.GlobalId != unite.Classe.GlobalId)
                        v = null;
                }
                m_txtQuantite.UnitValue = v;
                m_txtQuantite.LockEdition = LockEdition;
            }
            else
            {
                IUnite unite = CGestionnaireUnites.GetUnite(CClasseUniteUnite.c_idUnite);
                m_txtQuantite.DefaultFormat = unite.LibelleCourt;
                m_txtQuantite.UnitValue = new CValeurUnite(1, unite.LibelleCourt);
                m_txtQuantite.LockEdition = true;
            }

        }
    }
}
