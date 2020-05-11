using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using TimosInventory.data.releve;
using sc2i.common;
using TimosInventory.data;
using sc2i.common.memorydb;
using TimosInventory.CustomField;

namespace TimosInventory
{
    public partial class CFormCreerEquipement : Form
    {
        private CReleveEquipement m_releveEqpt = null;

        //--------------------------------------------------------------
        public CFormCreerEquipement()
        {
            InitializeComponent();
            CWin32Traducteur.Translate(this);
        }

        //--------------------------------------------------------------
        public static CReleveEquipement CreateEquipement(CReleveSite releveSite,
            CReleveEquipement releveEquipementParent)
        {
            CReleveEquipement relEq = new CReleveEquipement((CReleveDb)releveSite.Database);
            relEq.CreateNew();
            relEq.ReleveSite = releveSite;
            relEq.IsPresent = true;
            relEq.ReleveEquipementParent = releveEquipementParent;
            
            if (!EditeEquipement(relEq))
            {
                if (relEq.Equipement != null)
                    relEq.Equipement.Delete();
                relEq.Delete();
                return null;
            }
            return relEq;
        }


        //--------------------------------------------------------------
        public static bool EditeEquipement(CReleveEquipement releve)
        {
            CFormCreerEquipement frm = new CFormCreerEquipement();
            frm.m_releveEqpt = releve;
            DialogResult res = frm.ShowDialog();
            frm.Dispose();
            return res == DialogResult.OK;
        }

        //--------------------------------------------------------------
        private void CFormCreerEquipement_Load(object sender, EventArgs e)
        {
            m_lblSite.Text = m_releveEqpt.ReleveSite.Site.Libelle;
            if ( m_releveEqpt.ReleveEquipementParent != null )
            {
                m_panelEqptParent.Visible = true;
                m_lblEqptParent.Text = m_releveEqpt.ReleveEquipementParent.NumeroSerie+" "+
                    m_releveEqpt.ReleveEquipementParent.TypeEquipement.Libelle+" ("+
                    m_releveEqpt.ReleveEquipementParent.CoordonneeComplete +")";
            }
            else
                m_panelEqptParent.Visible = false;

            m_txtSerial.Text = m_releveEqpt.NumeroSerie;
            m_selectTypeEquipement.Init(m_releveEqpt, true);
            m_panelCoordonnee.Init(m_releveEqpt, true);

            CListeEntitesDeMemoryDb<CChampCustom> lstChamps = new CListeEntitesDeMemoryDb<CChampCustom>(CTimosInventoryDb.GetTimosDatas());
            lstChamps.Filtre = CChampCustom.GetFiltreChampsForRole(CReleveEquipement.c_roleChampCustom);
            if (lstChamps.Count() == 0)
            {
                m_panelChampsCustom.Visible = false;
            }
            else
            {
                m_panelChampsCustom.Visible = true;
                foreach (CChampCustom champOrg in lstChamps)
                {
                    CChampCustom champ = new CChampCustom(CTimosInventoryDb.GetInventaireDatas());
                    if (!champ.ReadIfExist(champOrg.Id))
                    {
                        champ = champOrg.GetChampInMemoryDb(CTimosInventoryDb.GetInventaireDatas());
                    }

                    if (champ != null)
                    {
                        CControleForCustomFieldReleve ctrl = new CControleForCustomFieldReleve();
                        m_panelChampsCustom.Controls.Add(ctrl);
                        ctrl.Dock = DockStyle.Left;
                        ctrl.Init(champ);
                    }
                }
            }

            foreach (Control ctrl in m_panelChampsCustom.Controls)
            {
                CControleForCustomFieldReleve c = ctrl as CControleForCustomFieldReleve;
                if (c != null)
                    c.InitChamps(m_releveEqpt);
            }


        }

        private void m_btnOk_Click(object sender, EventArgs e)
        {
            //Vérifie l'équipement
            CResultAErreur result = CResultAErreur.True;
            result = m_selectTypeEquipement.MajChamps();
            result &= m_panelCoordonnee.MajChamps();

            if ( m_releveEqpt.TypeEquipement == null )
                result.EmpileErreur(I.T("Select equipment type|20030"));
            if (result)
                m_releveEqpt.NumeroSerie = m_txtSerial.Text;
            if (result)
            {
                foreach (Control ctrl in m_panelChampsCustom.Controls)
                {
                    CControleForCustomFieldReleve c = ctrl as CControleForCustomFieldReleve;
                    if (c != null)
                        result = c.MajChamp();
                }

            }
            
            if ( !result )
            {
                CFormAlerte.Afficher ( result.Erreur );
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void m_btnAnnuler_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void m_panelCoordonnee_Enter(object sender, EventArgs e)
        {
            m_selectTypeEquipement.MajChamps();
        }

        //--------------------------------------------------------------


    }
}
