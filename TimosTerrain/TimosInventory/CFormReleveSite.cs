using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TimosInventory.data.releve;
using TimosInventory.data;
using sc2i.common.memorydb;
using sc2i.common;
using sc2i.win32.common;

namespace TimosInventory
{

    public partial class CFormReleveSite : Form
    {
        CReleveSite m_releve = null;
        public CFormReleveSite()
        {
            InitializeComponent();
        }

        public static void StartReleve(CSite site)
        {
            if (site == null)
                return;

            CReleveDb releveDb = CTimosInventoryDb.GetInventaireDatas();
            releveDb.AcceptChanges();
            //Cherche le relevé dans la base
            CReleveSite releve = new CReleveSite(releveDb);
            if (!releve.ReadIfExist(new CFiltreMemoryDb(
                CSite.c_champId + "=@1",
                site.Id)))
            {
                releve = CReleveSite.GetNewReleve(releveDb, site);
            }
            CFormReleveSite form = new CFormReleveSite();
            form.m_releve = releve;
            form.ShowDialog();
            form.Dispose();
        }

        //--------------------------------------------------------------
        private void CFormReleveSite_Load(object sender, EventArgs e)
        {
            InitForm();
            sc2i.win32.common.CWin32Traducteur.Translate(this);
        }

        //--------------------------------------------------------------
        private void InitForm()
        {
            m_lblTitre.Text = m_releve.Site.Libelle;
            m_lblStartDate.Text = I.T("Started @1|20041", m_releve.DateReleve.ToShortDateString() + " " + m_releve.DateReleve.ToString("HH:mm"));
            m_panelEquipements.Init(m_releve);
        }

        //--------------------------------------------------------------
        private void m_btnSave_Click(object sender, EventArgs e)
        {
            SaveDatas();
        }

        //--------------------------------------------------------------
        private void SaveDatas()
        {
            m_panelEquipements.MajChamps();
            CTimosInventoryDb.SetDbInventaire(CTimosInventoryDb.GetInventaireDatas());
        }

        private void CFormReleveSite_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_panelEquipements.MajChamps();
            CReleveDb releveDb = CTimosInventoryDb.GetInventaireDatas();
            if (releveDb.HasChanges())
            {
                DialogResult res = MessageBox.Show(I.T("Save changes ?|20036"), "",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);
                if (res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                if (res == DialogResult.No)
                {
                    CTimosInventoryDb.GetInventaireDatas().RejectChanges();
                    return;
                }
                SaveDatas();
            }

        }

        //-------------------------------------
        private void m_lnkReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show(I.T("This action will reset the entire survey. Are you sure ?|20042"),
                "",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CListeEntitesDeMemoryDb<CReleveEquipement> lstEqpts = m_releve.RelevesEquipement;
                lstEqpts.Filtre = new CFiltreMemoryDb(CReleveEquipement.c_champIdContenant + " is null");
                CResultAErreur result = CResultAErreur.True;
                foreach (CReleveEquipement releve in lstEqpts.ToArray())
                {
                    result = releve.Delete();
                    if (!result)
                        break;
                }
                if (!result)
                {
                    CFormAlerte.Afficher(result.Erreur);
                }
                else
                {
                    m_releve.DateReleve = DateTime.Now;
                    m_releve.InitEquipementsReleves();
                    InitForm();
                }
            }
        }

        private void m_btnAdd_Click(object sender, EventArgs e)
        {
            CReleveEquipement relEq = CFormCreerEquipement.CreateEquipement(
                m_releve,
                null);
            if (relEq != null)
            {
                m_panelEquipements.AddChildren(relEq, null);
            }
        }

        private void m_btnQuitter_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
