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
using sc2i.win32.data.navigation;
using sc2i.win32.common.customizableList;

namespace timos.commandes
{
    public partial class CControleEditeLigneLivraisonEquipement : CCustomizableListControl, IControlALockEdition
    {
        private CStatutEquipement m_defaultStatus = null;
        private IEmplacementEquipement m_defaultEmplacement = null;

        //-------------------------------------------------------------
        public CControleEditeLigneLivraisonEquipement()
        {
            InitializeComponent();
        }

        

        //-------------------------------------------------------------
        public IEmplacementEquipement DefaultEmplacement
        {
            get
            {
                return m_defaultEmplacement;
            }
            set
            {
                m_defaultEmplacement = value;
                MajEmplacementEtStatutEquipement();
                UpdateControleCoordonnee();
            }
        }

        //-------------------------------------------------------------
        public CStatutEquipement DefaultStatus
        {
            get
            {
                return m_defaultStatus;
            }
            set
            {
                m_defaultStatus = value;
                MajEmplacementEtStatutEquipement();

            }
        }

        //-------------------------------------------------------------
        private void UpdateControleContainer()
        {
            CFiltreData filtreRacine = null;
            CFiltreData filtreEnfants = null;
            if (m_defaultEmplacement == null)
            {
                filtreRacine = new CFiltreDataImpossible();
            }
            else
            {
                filtreRacine = new CFiltreData ( m_defaultEmplacement.GetChampId()+"=@1",
                    m_defaultEmplacement.Id );
                CTypeEquipement tpEquip = m_selectTypeEquipement.ElementSelectionne as CTypeEquipement;
                
                if (tpEquip != null)
                {
                    //Trouve tous les équipements qui peuvent contenir celui-ci
                    StringBuilder bl = new StringBuilder();
                    foreach (CTypeEquipement tpIncluant in tpEquip.TousLesTypesIncluants)
                    {
                        bl.Append(tpIncluant.Id);
                        bl.Append(',');
                    }
                    if (bl.Length > 0)
                    {
                        bl.Remove(bl.Length - 1, 1);
                        filtreEnfants = new CFiltreData ( CTypeEquipement.c_champId+" in ("+
                            bl.ToString()+")");
                    }
                    else
                        filtreEnfants = new CFiltreDataImpossible();
                }
            }
            m_cmbEquipementConteneur.Init(typeof(CEquipement),
                        "EquipementsContenus",
                        CEquipement.c_champIdEquipementContenant,
                        "Libelle",
                        filtreEnfants,
                        filtreRacine);
        }

        //-------------------------------------------------------------
        public CItemLigneLivraison ItemLigne
        {
            get
            {
                return CurrentItem as CItemLigneLivraison;
            }
        }

        //-------------------------------------------------------------
        private void UpdateControleCoordonnee()
        {
            if (m_defaultEmplacement == null || ItemLigne == null)
            {
                m_editCoordonnee.Visible = false;
            }
            else
            {
                CEquipement eqtParent = m_cmbEquipementConteneur.ElementSelectionne as CEquipement;
                if (eqtParent != null && eqtParent.ParametrageCoordonneesApplique == null)
                    m_editCoordonnee.Visible = false;
                else
                {
                    //Il faut que la ligne soit créée et que l'équipement aussi
                    MyMajChamps();
                    ItemLigne.AssureEquipement(m_defaultStatus, m_defaultEmplacement);
                    if (ItemLigne.LigneLivraison != null && ItemLigne.LigneLivraison.Equipement != null)
                    {
                        CEquipement ept = ItemLigne.LigneLivraison.Equipement;
                        if (ept == null || ept.ConteneurFilsACoordonnees == null || ept.ConteneurFilsACoordonnees.ParametrageCoordonneesApplique == null)
                        {
                            m_editCoordonnee.Visible = false;
                        }
                        else
                        {
                            m_editCoordonnee.Visible = true;
                            m_editCoordonnee.Init(ept.ConteneurFilsACoordonnees, ept);
                            m_editCoordonnee.LockEdition = LockEdition;
                        }
                    }
                }
            }
                
        }

        //---------------------------------------------------------------------------------
        private bool m_bIsEnInitialisation = false;
        protected override CResultAErreur  MyInitChamps(CCustomizableListItem item)
        {
            m_bIsEnInitialisation = true;
            CItemLigneLivraison itemLigne = item as CItemLigneLivraison;
            CWin32Traducteur.Translate(this);
            m_selectTypeEquipement.Init ( 
                typeof(CTypeEquipement),
                "Libelle",
                false );
            if (itemLigne != null)
            {
                m_selectTypeEquipement.ElementSelectionne = itemLigne.TypeEquipement;
                InitSelectReference();
                m_txtSelectReference.ElementSelectionne = itemLigne.RefConstructeur;
                m_txtSerial.Text = itemLigne.NumeroSerie;
                m_chkEstRecue.Checked = itemLigne.IsChecked;
                m_cmbEquipementConteneur.ElementSelectionne = itemLigne.EquipementConteneur;
            }
            UpdateControleContainer();
            UpdateControleCoordonnee();
            UpdateVisuel();
            m_bIsEnInitialisation = false;
            return CResultAErreur.True;
        }

        //---------------------------------------------------------------------------------
        private void InitSelectReference()
        {
            CRelationTypeEquipement_Constructeurs lastRel = m_txtSelectReference.ElementSelectionne as CRelationTypeEquipement_Constructeurs;
            CFiltreData filtre = null;
            CTypeEquipement typeEquipement = m_selectTypeEquipement.ElementSelectionne as CTypeEquipement;
            if (typeEquipement != null)
            {
                filtre = new CFiltreData(CTypeEquipement.c_champId + "=@1",
                         typeEquipement.Id);
            }
            m_txtSelectReference.InitAvecFiltreDeBase(
                typeof(CRelationTypeEquipement_Constructeurs),
                "Libelle",
                filtre,
                true);
            if (lastRel != null && typeEquipement == null && lastRel.TypeEquipement == typeEquipement)
                m_txtSelectReference.ElementSelectionne = lastRel;
        }

        //---------------------------------------------------------------------------------
        private void m_txtSelectReference_OnSelectedObjectChanged(object sender, EventArgs e)
        {
            CRelationTypeEquipement_Constructeurs rel = m_txtSelectReference.ElementSelectionne as CRelationTypeEquipement_Constructeurs;
            if (rel != null)
                m_selectTypeEquipement.ElementSelectionne = rel.TypeEquipement;
            InitSelectReference();
            AutoCheckLine();
        }

        //---------------------------------------------------------------------------------
        private void m_selectTypeEquipement_OnSelectedObjectChanged(object sender, EventArgs e)
        {
            CRelationTypeEquipement_Constructeurs rel = m_txtSelectReference.ElementSelectionne as CRelationTypeEquipement_Constructeurs;
            InitSelectReference();
            if (rel != null && m_selectTypeEquipement.ElementSelectionne != rel.TypeEquipement)
                m_selectTypeEquipement.ElementSelectionne = rel.TypeEquipement;
            CTypeEquipement tp = m_selectTypeEquipement.ElementSelectionne as CTypeEquipement;
            AutoCheckLine();
            UpdateControleCoordonnee();
        }


        #region IControlALockEdition Membres
        //---------------------------------------------------------------------------------
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
        //---------------------------------------------------------------------------------
        public event EventHandler OnChangeLockEdition;

        #endregion

        //---------------------------------------------------------------------------------
        protected override CResultAErreur MyMajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (ItemLigne != null)
            {
                ItemLigne.IsChecked = m_chkEstRecue.Checked;
                ItemLigne.TypeEquipement = m_selectTypeEquipement.ElementSelectionne as CTypeEquipement;
                ItemLigne.RefConstructeur = m_txtSelectReference.ElementSelectionne as CRelationTypeEquipement_Constructeurs;
                ItemLigne.EquipementConteneur = m_cmbEquipementConteneur.ElementSelectionne as CEquipement;
                ItemLigne.NumeroSerie = m_txtSerial.Text;
            }
            return result;
        }


        private void m_lnkEditer_LinkClicked(object sender, EventArgs e)
        {
            if (ItemLigne == null)
                return;
            CEquipement equipement = null;
            MyMajChamps();
            if (!ItemLigne.AssureEquipement(m_defaultStatus, m_defaultEmplacement))
                return;
            if (ItemLigne.LigneLivraison == null )
                return;
            equipement = ItemLigne.LigneLivraison.Equipement;
            if (ItemLigne.LigneLivraison.ContexteDonnee.IsEnEdition)
            {
                int nIdContexteCreation = ItemLigne.LigneLivraison.ContexteDonnee.IdContexteDonnee;
                bool bHasForceNotNew = false;
                if (equipement.IsNewInThisContexte())
                {
                    //force l'équipement a ne pas être consideré comme nouveau
                    equipement.Row[CContexteDonnee.c_colIdContexteCreation] = -1;
                    bHasForceNotNew = true;
                }

                CFormNavigateurPopup.Show(new CFormEditionEquipement(equipement));
                if (bHasForceNotNew && equipement.IsValide())
                {
                    equipement.Row[CContexteDonnee.c_colIdContexteCreation] = nIdContexteCreation;
                }
                if (!equipement.IsValide())
                    ItemLigne.LigneLivraison.Equipement = null;
                else
                {
                    m_selectTypeEquipement.ElementSelectionne = equipement.TypeEquipement;
                    m_txtSelectReference.ElementSelectionne = equipement.RelationConstructeur;
                    m_txtSerial.Text = equipement.NumSerie;
                    m_cmbEquipementConteneur.ElementSelectionne = equipement.EquipementContenant;
                    m_editCoordonnee.Coordonnee = equipement.Coordonnee;
                }
            }
            else
                CTimosApp.Navigateur.AffichePage(new CFormEditionEquipement(equipement));
        }

        private void m_txtSerial_TextChanged(object sender, EventArgs e)
        {
            AutoCheckLine();
        }

        private void AutoCheckLine()
        {
            if (ItemLigne == null || m_bIsEnInitialisation)
                return;
            if (ItemLigne.LigneLivraison == null && m_selectTypeEquipement.ElementSelectionne != null)
                m_chkEstRecue.Checked = true;
            if ((m_txtSelectReference.ElementSelectionne != null ||
               m_txtSerial.Text.Trim() != "") && !m_chkEstRecue.Checked)
                m_chkEstRecue.Checked = true;
            if (m_txtSelectReference.ElementSelectionne == null &&
                m_txtSerial.Text.Trim() == "" && ItemLigne.LigneLivraison == null)
                m_chkEstRecue.Checked = false;
        }

        /*/// <summary>
        /// Crée ou supprime la ligne de livraison en fonction de l'état des boutons
        /// </summary>
        private void CreateOrDeleteLigne()
        {
            if ( !m_extModeEdition.ModeEdition || ItemLigne == null)
                return;

            if (m_chkEstRecue.Checked)
            {
                if (ItemLigne.LigneLivraison != null)
                    return;
                else
                {
                    MyMajChamps();
                    ItemLigne.AssureLigneLivraison();
                    ItemLigne.AssureEquipement(m_defaultStatus, m_defaultEmplacement);
                    UpdateVisuel();
                }
            }
            else
            {
                if (ItemLigne.LigneLivraison != null && ItemLigne.LigneLivraison.IsNew())
                {
                    if (ItemLigne.LigneLivraison.Equipement != null && ItemLigne.LigneLivraison.Equipement.IsNew())
                    {
                        ItemLigne.LigneLivraison.Equipement.Delete(true);
                        ItemLigne.LigneLivraison.Delete(true);
                        ItemLigne.LigneLivraison = null;
                        UpdateVisuel();
                    }
                }
            }
            
        }*/


        //Met à jour la ligne de livraison et l'équipement avec les infos
        //du contrôle.
        private void MajEmplacementEtStatutEquipement()
        {
            if (!m_extModeEdition.ModeEdition || CurrentItem == null)
                return;
            MyMajChamps();
            if (ItemLigne.LigneLivraison != null)
            {
                if (ItemLigne.LigneLivraison.Equipement != null)
                {
                    if ( ItemLigne.LigneLivraison.Equipement.Emplacement == null )
                        ItemLigne.LigneLivraison.Equipement.SetEmplacementSansHistorique(m_defaultEmplacement,
                            ItemLigne.EquipementConteneur);
                    if ( ItemLigne.LigneLivraison.Equipement.Statut == null )
                        ItemLigne.LigneLivraison.Equipement.Statut = m_defaultStatus;
                }
            }
            UpdateVisuel();
        }

        /*/// <summary>
        /// Met à jour l'équipement avec les infos du contrôle
        /// si l'équipement existe uniquement et qu'il est nouveau
        /// </summary>
        private void MajEquipement()
        {
            if (!m_extModeEdition.ModeEdition || ItemLigne == null)
                return;
            if (ItemLigne.LigneLivraison != null && ItemLigne.LigneLivraison.Equipement != null)
            {
                CEquipement eqt = ItemLigne.LigneLivraison.Equipement;
                if (eqt.IsNew())
                {
                    if (m_selectTypeEquipement.ElementSelectionne is CTypeEquipement)
                        eqt.TypeEquipement = m_selectTypeEquipement.ElementSelectionne as CTypeEquipement;
                    if (m_txtSelectReference.ElementSelectionne is CRelationTypeEquipement_Constructeurs)
                        eqt.RelationConstructeur = m_txtSelectReference.ElementSelectionne as CRelationTypeEquipement_Constructeurs;
                    eqt.NumSerie = m_txtSerial.Text;
                    eqt.Statut = m_defaultStatus;
                    if (m_defaultEmplacement != null)
                        eqt.SetEmplacementSansHistorique(
                            m_defaultEmplacement, m_cmbEquipementConteneur.ElementSelectionne as CEquipement);
                    eqt.Coordonnee = m_editCoordonnee.Coordonnee;
                    UpdateVisuel();
                }
                
            }
            
        }*/


        /// <summary>
        /// Met à jour l'état des contrôles de la fenêtre en fonction
        /// de ce qui est initialisé
        /// </summary>
        private bool m_bIsUpdatingVisuel = false;

        private void UpdateVisuel()
        {
            if (m_bIsUpdatingVisuel || ItemLigne == null)
                return;
            try
            {
                m_bIsUpdatingVisuel = true;
                CEquipement equipement = ItemLigne.LigneLivraison == null ? null : ItemLigne.LigneLivraison.Equipement;
                List<Control> controlesActifs = new List<Control>();
                List<Control> controlesInactifs = new List<Control>();
                //Checkbox. La checkbox est active si la ligne de livraison
                //est nouvelle;
                m_chkEstRecue.Checked = ItemLigne.IsChecked;
                if (ItemLigne.LigneLivraison == null || ItemLigne.LigneLivraison.IsNew())
                    controlesActifs.Add(m_chkEstRecue);
                else
                    controlesInactifs.Add(m_chkEstRecue);

                //Sélection du type d'équipement
                //On ne peut sélectionner le type d'équipement que si
                //La ligne n'est pas liée à une ligne de commande
                //et que l'équipement est nouveau
                if (ItemLigne.LigneCommande != null)
                    m_selectTypeEquipement.ElementSelectionne = ItemLigne.LigneCommande.TypeEquipement;
                if (ItemLigne.LigneCommande == null && (ItemLigne.LigneLivraison == null ||
                    ItemLigne.LigneLivraison.IsNew()))
                    controlesActifs.Add(m_selectTypeEquipement);
                else
                    controlesInactifs.Add(m_selectTypeEquipement);

                //Sélection de la référence d'équipement
                //La sélection est active uniquement pour les lignes toutes neuves
                if (ItemLigne.LigneLivraison == null || ItemLigne.LigneLivraison.IsNew())
                    controlesActifs.Add(m_txtSelectReference);
                else
                    controlesInactifs.Add(m_txtSelectReference);

                //Equipement contenant
                //Actif si l'équipement n'est pas null, qu'il est nouveau
                //et qu'il a un type
                if (equipement != null &&
                    equipement.IsNew() && equipement.TypeEquipement != null)
                    controlesActifs.Add(m_cmbEquipementConteneur);
                else
                    controlesInactifs.Add(m_cmbEquipementConteneur);
                UpdateControleContainer();

                //Coordonnée : active pour les nouveaux équipements
                //Contenus dans un conteneur qui gère des coordonnées
                if (equipement != null && equipement.IsNew() &&
                    equipement.Emplacement != null)
                    controlesActifs.Add(m_editCoordonnee);
                else
                    controlesInactifs.Add(m_editCoordonnee);
                UpdateControleCoordonnee();



                //Numéro de série : uniquement pour les nouveaux équipements
                if (ItemLigne.LigneLivraison == null || (equipement != null && equipement.IsNew()))
                    controlesActifs.Add(m_txtSerial);
                else
                    controlesInactifs.Add(m_txtSerial);

                foreach (Control ctrl in controlesActifs)
                {
                    m_extModeEdition.SetModeEdition(ctrl, TypeModeEdition.EnableSurEdition);
                    IControlALockEdition ctLock = ctrl as IControlALockEdition;
                    if (ctLock != null)
                        ctLock.LockEdition = !m_extModeEdition.ModeEdition;
                    else
                        ctrl.Enabled = m_extModeEdition.ModeEdition;
                }
                foreach (Control ctrl in controlesInactifs)
                {
                    m_extModeEdition.SetModeEdition(ctrl, TypeModeEdition.Autonome);
                    IControlALockEdition ctLock = ctrl as IControlALockEdition;
                    if (ctLock != null)
                        ctLock.LockEdition = true;
                    else
                        ctrl.Enabled = false;
                }
            }
            finally
            {
                m_bIsUpdatingVisuel = false;
            }
        }

        private void m_chkEstRecue_CheckedChanged(object sender, EventArgs e)
        {
            /*if (m_extModeEdition.ModeEdition && !m_bIsEnInitialisation)
                CreateOrDeleteLigne();*/
        }

        private void m_cmbEquipement_ElementSelectionneChanged(object sender, EventArgs e)
        {
            UpdateControleCoordonnee();
        }

        private void m_chkEstRecue_MouseDown(object sender, MouseEventArgs e)
        {
            //m_chkEstRecue.Checked = !m_chkEstRecue.Checked;
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
    }

    public class CItemLigneLivraison : CCustomizableListItem
    {
        private CLigneLivraisonEquipement m_ligneLivraison = null;
        
        public CLigneCommande LigneCommande = null;
        public CLivraisonEquipement Livraison = null;

        //Stockage des valeurs des contrôles
        public bool IsChecked = false;
        private CTypeEquipement m_TypeEquipement = null;
        public CRelationTypeEquipement_Constructeurs RefConstructeur = null;
        public CEquipement EquipementConteneur = null;
        public string NumeroSerie = "";

        public CItemLigneLivraison ( CLigneLivraisonEquipement ligneLivraison,
            CLigneCommande ligneCommande,
            CLivraisonEquipement livraison )
        {
            m_ligneLivraison = ligneLivraison;
            LigneCommande = ligneCommande;
            Livraison = livraison;

            InitValeursControles();
        }

        private void InitValeursControles()
        {
            LigneCommande = LigneLivraison != null ? LigneLivraison.LigneDeCommandeAssociee : LigneCommande;

            if (m_ligneLivraison != null && m_ligneLivraison.Equipement != null)
                TypeEquipement = m_ligneLivraison.Equipement.TypeEquipement;
            if (TypeEquipement == null && LigneCommande != null)
                TypeEquipement = LigneCommande.TypeEquipement;
            RefConstructeur = m_ligneLivraison != null && m_ligneLivraison.Equipement != null ? m_ligneLivraison.Equipement.RelationConstructeur : null;
            NumeroSerie = m_ligneLivraison != null && m_ligneLivraison.Equipement != null ? m_ligneLivraison.Equipement.NumSerie : "";
            IsChecked = m_ligneLivraison != null;
            EquipementConteneur = m_ligneLivraison != null && m_ligneLivraison.Equipement != null ? m_ligneLivraison.Equipement.EquipementContenant : null;
        }


        //-----------------------------------------------------------------
        public CLigneLivraisonEquipement LigneLivraison
        {
            get
            {
                return m_ligneLivraison;
            }
            set
            {
                m_ligneLivraison = value;
            }
        }

        //-----------------------------------------------------------------
        public CTypeEquipement TypeEquipement
        {
            get
            {
                return m_TypeEquipement;
            }
            set
            {
                m_TypeEquipement = value;
            }
        }

        //-----------------------------------------------------------------
        public void AssureLigneLivraison()
        {
            if ( m_ligneLivraison == null )
            {
                m_ligneLivraison = new CLigneLivraisonEquipement(Livraison.ContexteDonnee );
                m_ligneLivraison.CreateNewInCurrentContexte();
                m_ligneLivraison.LivraisonEquipement = Livraison;
                m_ligneLivraison.LigneDeCommandeAssociee = LigneCommande;
            }
        }

        //-----------------------------------------------------------------
        public bool AssureEquipement(CStatutEquipement status, IEmplacementEquipement emplacement)
        {
            AssureLigneLivraison();
            if (LigneLivraison.Equipement == null)
            {
                if (TypeEquipement != null)
                {
                    LigneLivraison.Equipement = new CEquipement(LigneLivraison.ContexteDonnee);
                    LigneLivraison.Equipement.CreateNewInCurrentContexte();
                }
                else
                    return false;
            }
            if (LigneLivraison.Equipement != null)
            {
                LigneLivraison.Equipement.TypeEquipement = TypeEquipement;
                LigneLivraison.Equipement.RelationConstructeur = RefConstructeur;
                LigneLivraison.Equipement.NumSerie = NumeroSerie;
                if (status != null && LigneLivraison.Equipement.Statut ==null )
                    LigneLivraison.Equipement.Statut = status;
                if (emplacement != null  && LigneLivraison.Equipement.Emplacement == null)
                    LigneLivraison.Equipement.SetEmplacementSansHistorique(
                        emplacement,
                        EquipementConteneur);
            }
            return LigneLivraison.Equipement != null;
        }

        public CResultAErreur MajChamps(CStatutEquipement status, IEmplacementEquipement emplacement)
        {
            CResultAErreur result = CResultAErreur.True;
            if (IsChecked)
            {
                AssureEquipement(status, emplacement);
            }
            else
            {
                if (LigneLivraison != null)
                {
                    CEquipement eqpt = LigneLivraison.Equipement;
                    if (eqpt == null || eqpt.IsNew())
                    {
                        result = LigneLivraison.Delete(true);
                        if (result && eqpt != null )
                        {
                            result = eqpt.Delete(true);
                        }
                    }
                    
                }
            }
            return result;
        }

        
        
    }
}
