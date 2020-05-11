using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using timos.data;
using sc2i.common;
using sc2i.win32.common;
using sc2i.win32.common.customizableList;
using sc2i.data;
using timos.data.sites.releve;

namespace timos.sites.releve
{
    public partial class CFormSelectActionsReleve : Form, IFiltreurTraitementsReleve
    {
        private CReleveSite m_releve = null;
        private IEnumerable<CTraitementReleveEquipement> m_listeTraitements = new List<CTraitementReleveEquipement>();

        public CFormSelectActionsReleve()
        {
            InitializeComponent();
            sc2i.win32.common.CWin32Traducteur.Translate(this);
            m_panelActions.FiltreurTraitements = this;
        }

        //------------------------------------------------------------------------
        public static void EditeReleve(CReleveSite releve)
        {
            CFormSelectActionsReleve frm = new CFormSelectActionsReleve();
            frm.m_releve = releve;
            frm.Show();
        }

        //------------------------------------------------------------------------
        private void CFormSelectActionsReleve_Load(object sender, EventArgs e)
        {
            m_lblHeader.Text = I.T("Site @1 survey. Date : @2|20789",
                m_releve.Site.LibelleComplet,
                m_releve.DateReleve.ToShortDateString());
            m_listeTraitements = m_releve.GetTraitements();
            m_cmbDefaultStatus.ListDonnees = new CListeObjetsDonnees(m_releve.ContexteDonnee,
                typeof(CStatutEquipement));
            m_cmbDefaultStatus.ElementSelectionne = m_releve.StatutEquipementParDefaut;
            RefillListe();
        }


        //------------------------------------------------------------------------
        private void m_btnSave_Click(object sender, EventArgs e)
        {
            CResultAErreur result = SaveAll();
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
            }
            else
                CFormAlerte.Afficher(I.T("Choices are saved|20790"));            
        }

        //------------------------------------------------------------------------
        private CResultAErreur SaveAll()
        {
            CResultAErreur result = CResultAErreur.True;
            CReleveSite releveToSave = m_releve;
            releveToSave.BeginEdit();
            releveToSave.StatutEquipementParDefaut = m_cmbDefaultStatus.ElementSelectionne as CStatutEquipement;
            foreach (CTraitementReleveEquipement traitement in m_listeTraitements)
            {
                traitement.StoreInContexte(releveToSave.ContexteDonnee);
            }
            result = releveToSave.CommitEdit();
            if (!result)
                releveToSave.CancelEdit();
            return result;
        }

        //------------------------------------------------------------------------
        private void m_btnCheckAll_Click(object sender, EventArgs e)
        {
            RecursiveCheck(m_listeTraitements);
        }

        //------------------------------------------------------------------------
        private void RecursiveCheck ( IEnumerable<CTraitementReleveEquipement> lst )
        {
            foreach (CTraitementReleveEquipement traitement in lst)
            {
                if (traitement.EtatValidation != EEtatValidationReleveEquipement.Validé)
                    traitement.EtatValidation = EEtatValidationReleveEquipement.Validé;
                RecursiveCheck(traitement.TraitementsFils);
            }
            m_panelActions.Refill();
        }

        //------------------------------------------------------------------------
        private void m_btnApplyFilter_Click(object sender, EventArgs e)
        {
            RefillListe();
        }

        //------------------------------------------------------------------------
        private void RefillListe()
        {
            m_panelActions.Init(m_listeTraitements);
        }

        //------------------------------------------------------------------------
        public bool IsVisible ( CTraitementReleveEquipement traitement )
        {
            if(  m_chkMasquerValides.Checked )
            {
                if( traitement != null && (traitement.EtatValidation == EEtatValidationReleveEquipement.None || 
                    traitement.HasChildToValidate() ))
                    return true;
                return false;
            }
            return true;
        }

        //--------------------------------------------------------------------------
        private void m_lblHeader_Click(object sender, EventArgs e)
        {
            if (m_releve != null && m_releve.Site != null)
            {
                CFormMain.GetInstance().EditeElement(m_releve.Site, false,"");
            }
        }

        //--------------------------------------------------------------------------
        private void m_btnExecuter_Click(object sender, EventArgs e)
        {
            CResultAErreur result = SaveAll();
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }
            using (CContexteDonnee ctx = new CContexteDonnee(m_releve.ContexteDonnee.IdSession, true, false))
            {
                CReleveSite releve = m_releve;
                CVersionDonnees version = releve.VersionDonneesPourApplication;
                if (version == null)
                {
                    releve.BeginEdit();
                    version = new CVersionDonnees(releve.ContexteDonnee);
                    version.CreateNewInCurrentContexte();
                    version.CodeTypeVersion = (int)CTypeVersion.TypeVersion.Previsionnelle;
                    version.Libelle = I.T("Site @1 survey (@2)|20796",
                        releve.Site.LibelleComplet, releve.DateReleve.ToShortDateString());
                    releve.VersionDonneesPourApplication = version;
                    releve.CommitEdit();
                }
                version = releve.VersionDonneesPourApplication;
                //ctx.SetVersionDeTravail(version.Id, false);
                foreach (CTraitementReleveEquipement traitement in m_listeTraitements)
                {
                    result = traitement.Execute(ctx, null);
                    if (!result)
                        break;
                }
                if (result)
                    result = ctx.SaveAll(true);
                if ( result )
                    MessageBox.Show(I.T("Modifications have been applied|20798"));
                if (!result)
                {
                    CFormAlerte.Afficher(result.Erreur);
                }
            }
        }
    

           
        

    }
}
