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

namespace timos.commandes
{
    public partial class CControleEditeLigneCommande : UserControl, IControlALockEdition
    {
        private bool m_bIsFirst = false;
        private CLigneCommande m_ligne = null;

        private CDonneesActeurFournisseur m_fournisseurPourFiltre = null;

        public CControleEditeLigneCommande()
        {
            InitializeComponent();
        }

        public void Init(CLigneCommande ligne, bool bFirst)
        {
            CWin32Traducteur.Translate(this);
            IsFirst = bFirst;
            
            m_ligne = ligne;
            m_selectTypeEquipement.Init ( 
                typeof(CTypeEquipement),
                "Libelle",
                false );
            m_selectTypeEquipement.ElementSelectionne = ligne.TypeEquipement;
            InitSelectReference();
            m_txtSelectReference.ElementSelectionne = ligne.ReferenceFournisseur;

            m_txtReference.Text = ligne.Reference;
            m_txtTexte.Text = ligne.Libelle;
            m_txtQte.DoubleValue = ligne.Quantite;
        }

        public CDonneesActeurFournisseur FournisseurPourFiltre
        {
            get
            {
                return m_fournisseurPourFiltre;
            }
            set
            {
                m_fournisseurPourFiltre = value;
                CFiltreData filtre = null;
                if (value != null)
                {
                    filtre = new CFiltreDataAvance(CTypeEquipement.c_nomTable,
                            CRelationTypeEquipement_Fournisseurs.c_nomTable + "." +
                            CDonneesActeurFournisseur.c_champId + "=@1",
                            m_fournisseurPourFiltre.Id);
                }
                m_selectTypeEquipement.InitAvecFiltreDeBase(typeof(CTypeEquipement), "Libelle", filtre, true);
                InitSelectReference();
            }
        }


        private bool m_bInInitReference = false;
        private void InitSelectReference()
        {
            CRelationTypeEquipement_Fournisseurs lastRel = m_txtSelectReference.ElementSelectionne as CRelationTypeEquipement_Fournisseurs;
            CFiltreData filtre = null;
            CTypeEquipement typeEquipement = m_selectTypeEquipement.ElementSelectionne as CTypeEquipement;
            if (typeEquipement != null)
            {
                filtre = CFiltreData.GetAndFiltre(filtre,
                     new CFiltreData(CTypeEquipement.c_champId + "=@1",
                         typeEquipement.Id));
            }
            else if (m_fournisseurPourFiltre != null)
            {
                filtre = CFiltreData.GetAndFiltre(filtre,
                    new CFiltreData(CDonneesActeurFournisseur.c_champId + "=@1",
                        m_fournisseurPourFiltre.Id));
            }
            m_txtSelectReference.InitAvecFiltreDeBase(
                typeof(CRelationTypeEquipement_Fournisseurs),
                "Libelle",
                filtre,
                true);
            if (lastRel != null && typeEquipement == null && lastRel.TypeEquipement == typeEquipement)
                m_txtSelectReference.ElementSelectionne = lastRel;


        }

        public event EventHandler OnAddLine;
        public event EventHandler OnGoDown;
        public event EventHandler OnGoUp;
        public event EventHandler OnDelete;

        private void m_txtSelectReference_OnSelectedObjectChanged(object sender, EventArgs e)
        {
            CRelationTypeEquipement_Fournisseurs rel = m_txtSelectReference.ElementSelectionne as CRelationTypeEquipement_Fournisseurs;
            if (rel != null)
                m_selectTypeEquipement.ElementSelectionne = rel.TypeEquipement;
            InitSelectReference();
            if (rel != null && rel.Reference.Trim() != "")
                m_txtReference.Text = rel.Reference;
        }

        private void m_selectTypeEquipement_OnSelectedObjectChanged(object sender, EventArgs e)
        {
            CRelationTypeEquipement_Fournisseurs rel = m_txtSelectReference.ElementSelectionne as CRelationTypeEquipement_Fournisseurs;
            InitSelectReference();
            if (rel != null && m_selectTypeEquipement.ElementSelectionne != rel.TypeEquipement)
                m_selectTypeEquipement.ElementSelectionne = rel.TypeEquipement;
            CTypeEquipement tp = m_selectTypeEquipement.ElementSelectionne as CTypeEquipement;
            if (tp != null)
                m_txtTexte.Text = tp.Libelle;
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

        public bool IsFirst
        {
            get
            {
                return m_bIsFirst;
            }
            set
            {
                if (value)
                {
                    m_panelTop.Visible = true;
                    Size = new Size(Size.Width, m_panelData.Height+m_panelTop.Height);
                }
                else
                {
                    m_panelTop.Visible = false;
                    Size = new Size(Size.Width, m_panelData.Height);
                }
            }
        }

        private void m_btnInsert_Click(object sender, EventArgs e)
        {
            if (OnGoUp != null)
                OnGoUp(this, null);
        }

        private void m_btnAdd_Click(object sender, EventArgs e)
        {
            if (OnGoDown != null)
                OnGoDown(this, null);

        }

        private void m_btnPoubelle_Click(object sender, EventArgs e)
        {
            if (OnDelete != null)
                OnDelete(this, null);

        }

        private void m_btnLigneSuivante_Click(object sender, EventArgs e)
        {
            if (OnAddLine != null)
                OnAddLine(this, null);
        }

        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (!m_ligne.IsValide())
                return result;
            CTypeEquipement typeEquipement = m_selectTypeEquipement.ElementSelectionne as CTypeEquipement;
            if ( typeEquipement == null )
            {
                result.EmpileErreur ( I.T("Invalid equipment type on line @1|20401", (m_ligne.Numero+1).ToString()));
                m_selectTypeEquipement.Focus();
            }
            if ( m_txtQte.DoubleValue == null )
            {
                result.EmpileErreur(I.T("Invalid quantity on line @1|20402", (m_ligne.Numero+1).ToString() ));
                m_txtQte.Focus();
            }
            if ( !result )
                return result;
            m_ligne.TypeEquipement = typeEquipement;
            m_ligne.ReferenceFournisseur = m_txtSelectReference.ElementSelectionne as CRelationTypeEquipement_Fournisseurs;
            m_ligne.Libelle = m_txtTexte.Text;
            m_ligne.Quantite = m_txtQte.DoubleValue.Value;
            m_ligne.Reference = m_txtReference.Text;
            return result;
        }

        public CLigneCommande Ligne
        {
            get
            {
                return m_ligne;
            }
        }

    }
}
