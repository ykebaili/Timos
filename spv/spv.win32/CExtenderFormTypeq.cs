using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.data;

using timos.data;

using spv.data;



namespace spv.win32
{
    public partial class CExtenderFormTypeq : CExtendeurFormEditionStandardTabPage
    {
        private CSpvTypeq m_spvTypeq = null;

        public CExtenderFormTypeq()
        {
            InitializeComponent();
            Title = I.T("Supervision|9");
        }

        public override Type TypeObjetEtendu
        {
            get
            {
                return typeof(CTypeEquipement);
            }
        }

        protected CTypeEquipement TypeEquipement
        {
            get
            {
                return ObjetEdite as CTypeEquipement;
            }
        }


        private EGenreCommutateur GetInterfaceCommutState()
        {
            if (m_radioNotCommut.Checked)
                return EGenreCommutateur.NotCommut;

            if (m_radio2vers1.Checked)
                return EGenreCommutateur.TwoToOne;

            return EGenreCommutateur.nToOne;
        }

        private void SetInterfaceCommuteState()
        {
            m_radioNotCommut.Checked = true;
            
            switch (m_spvTypeq.TypeCommutateur)
            {
                case EGenreCommutateur.TwoToOne:
                    m_radio2vers1.Checked = true;
                    break;

                case EGenreCommutateur.nToOne:
                    m_radio_nVers1.Checked = true;
                    break;
            }
            
        }

        public override sc2i.common.CResultAErreur MyInitChamps()
        {
            if (ObjetEdite is CTypeEquipement)
            {
                m_spvTypeq = CSpvTypeq.GetSpvTypeqFromTypeEquipement(ObjetEdite as CTypeEquipement) as CSpvTypeq;
            }

            CResultAErreur result = base.MyInitChamps();
            if (!result)
                return result;

            
            if (result && m_spvTypeq != null)
            {
                m_txtBoxRefSnmp.Text = m_spvTypeq.ReferenceSnmp;
                m_txtBoxIdentOID.Text = m_spvTypeq.OIDIdentifiantSnmp;
                m_txtBoxIdentNom.Text = m_spvTypeq.NomIdentifiantSnmp;
                m_txtBoxIdentValeur.Text = m_spvTypeq.ValeurIdentifiantSnmp;
                m_txtBoxCommutOID.Text = m_spvTypeq.OIDCommutateur;
                m_chkAutomaticMIB.Checked = m_spvTypeq.ChercheOIDParMIB;
                m_chkToSupervise.Checked = m_spvTypeq.ASurveiller;
                m_chkJustDiscovered.Checked = m_spvTypeq.NouvellementDecouvert;
                SetInterfaceCommuteState();
                InitTreePossibleMibs();
                InitListSelectedMibs();
            }
            else
            {
                m_txtBoxRefSnmp.Text = "";
                m_txtBoxIdentOID.Text = "";
                m_txtBoxIdentNom.Text = "";
                m_txtBoxIdentValeur.Text = "";
                m_txtBoxCommutOID.Text = "";
                m_chkAutomaticMIB.Checked = false;
                m_chkToSupervise.Checked = false;
                m_chkJustDiscovered.Checked = false;
                m_radioNotCommut.Checked = true;
                m_listMibs.Items.Clear();
                m_TreeMibs.Nodes.Clear();
            }

            return result;
        }


        public override sc2i.common.CResultAErreur MyMajChamps()
        {
            CResultAErreur result = base.MyMajChamps();
            if (!result)
                return result;

            if (TypeEquipement != null && m_spvTypeq == null && m_extModeEdition.ModeEdition)
            {
                m_spvTypeq = CSpvTypeq.GetSpvTypeqFromTypeEquipementAvecCreation(TypeEquipement);
            }

            if (m_spvTypeq != null)
            {
                m_spvTypeq.ReferenceSnmp = m_txtBoxRefSnmp.Text;
                m_spvTypeq.OIDIdentifiantSnmp = m_txtBoxIdentOID.Text;
                m_spvTypeq.NomIdentifiantSnmp = m_txtBoxIdentNom.Text;
                m_spvTypeq.ValeurIdentifiantSnmp = m_txtBoxIdentValeur.Text;
                m_spvTypeq.OIDCommutateur = m_txtBoxCommutOID.Text;
                m_spvTypeq.TypeCommutateur = GetInterfaceCommutState();
                m_spvTypeq.ASurveiller = m_chkToSupervise.Checked;
                m_spvTypeq.NouvellementDecouvert = m_chkJustDiscovered.Checked;
                m_spvTypeq.ChercheOIDParMIB = m_chkAutomaticMIB.Checked;

                MajListMibs();
            }

            return result;
        }

        private void MajListMibs()
        {
            DeleteOldMibs();
            CreateNewMibs();
        }

        private void CreateNewMibs()
        {
            int nNbItems = m_listMibs.Items.Count;
            if (nNbItems > 0)
            {
                CSpvTypeq_Mibmodule spvTypeqMib = new CSpvTypeq_Mibmodule(m_spvTypeq.ContexteDonnee);
                for (int i = 0; i < nNbItems; i++)
                {
                    CSpvMibmodule spvMib = (CSpvMibmodule) m_listMibs.Items[i].Tag;
                    CFiltreData filtre = new CFiltreData(CSpvTypeq_Mibmodule.c_champTYPEQ_ID + "=@1 AND " +
                                                        CSpvTypeq_Mibmodule.c_champMIBMODULE_ID + "=@2",
                                                        m_spvTypeq.Id, spvMib.Id);
                    if (!spvTypeqMib.ReadIfExists(filtre))
                    {
                        CSpvTypeq_Mibmodule typeqMib = new CSpvTypeq_Mibmodule(m_spvTypeq.ContexteDonnee);
                        typeqMib.CreateNewInCurrentContexte(new object[]{m_spvTypeq.Id, spvMib.Id});
                        
                    }
                }
            }
        }

        private void DeleteOldMibs()
        {
            CSpvTypeq_Mibmodule typeqMib;
            for (int i = m_spvTypeq.TypeqModulesMIB.Count - 1; i >= 0; i--)
            {
                typeqMib = (CSpvTypeq_Mibmodule) m_spvTypeq.TypeqModulesMIB[i];

                bool bTrouve = false;
                for (int j = 0; j < m_listMibs.Items.Count; j++)
                {
                    if (m_listMibs.Items[j].SubItems[0].Text == typeqMib.SpvMibmodule.NomModuleUtilisateur)
                    {
                        bTrouve = true;
                        break;
                    }
                }

                if (!bTrouve)
                    typeqMib.Delete();
            }
        }

        // Recherche des MIBs sélectionnées, c'est à dire celles associées au type
        // d'équipement.
        private void InitListSelectedMibs()
        {
            m_listMibs.Items.Clear();
            foreach (CSpvTypeq_Mibmodule typeqMib in m_spvTypeq.TypeqModulesMIB)
            {
                ListViewItem item = new ListViewItem();
                m_listMibs.Items.Add(item);
                m_listMibs.UpdateItemWithObject(item, typeqMib.SpvMibmodule);
            }
        }

        /// <summary>
        /// Recherche les enfant d'un noeud
        /// </summary>
        /// <param name="familleId">ID de la famille. 0 si noeud root</param>
        private void InitChildrenNodes(Int32 familleId, TreeNodeCollection parentCollection)
        {
            CListeObjetsDonnees listeFamilles = new CListeObjetsDonnees(m_spvTypeq.ContexteDonnee,
                                                                typeof(CSpvFamilleMibmodule));

            CListeObjetsDonnees listeMibs = new CListeObjetsDonnees(m_spvTypeq.ContexteDonnee, 
                                                                typeof(CSpvMibmodule));

            if (familleId == 0)
            {
                listeFamilles.Filtre = new CFiltreData(CSpvFamilleMibmodule.c_champFAMILLE_CLASSID + "=@1 AND " +
                                            CSpvFamilleMibmodule.c_champFAMILLE_BINDINGID + " IS NULL",
                                            CSpvFamilleMibmodule.c_classID);
                listeMibs.Filtre = new CFiltreData(CSpvMibmodule.c_champFAMILLE_ID + " IS NULL");
            }
            else
            {
                listeFamilles.Filtre = new CFiltreData(CSpvFamilleMibmodule.c_champFAMILLE_CLASSID + "=@1 AND " +
                                            CSpvFamilleMibmodule.c_champFAMILLE_BINDINGID + "=@2",
                                            CSpvFamilleMibmodule.c_classID, familleId);
                listeMibs.Filtre = new CFiltreData(CSpvMibmodule.c_champFAMILLE_ID + "=@1", familleId);
            }

            // Recherche des familles de modules MIB
            if (listeFamilles.Count > 0)
            {
                TreeNode node;
                foreach (CSpvFamilleMibmodule spvFamille in listeFamilles)
                {
                    node = parentCollection.Add(spvFamille.Libelle);
                    node.Tag = spvFamille;
                    InitChildrenNodes(spvFamille.Id, node.Nodes);
                }
            }

            // Recherche des modules MIB sans famille
            if (listeMibs.Count > 0)
            {
                TreeNode node;
                foreach (CSpvMibmodule spvMib in listeMibs)
                {
                    node = parentCollection.Add(spvMib.NomModuleUtilisateur);
                    node.Tag = spvMib;
                }
            }
        }


        // Recherche des familles de MIBs et des MIBs sans parent
        // Remarque : chaque niveau inclus est recherché lorsqu'on clique
        // sur le noeud courant
        private void InitTreePossibleMibs()
        {
            m_TreeMibs.Nodes.Clear();
            InitChildrenNodes(0, m_TreeMibs.Nodes);
        }//MyInitChamps()


        private void m_lnkAjouter_LinkClicked(object sender, EventArgs e)
        {
            TreeNode node = m_TreeMibs.SelectedNode;
            if (node != null)
            {
                object objet = node.Tag;
                if (objet.GetType() == typeof (CSpvMibmodule))
                {
                    foreach (ListViewItem item in m_listMibs.Items)
                    {
                        if (item.SubItems[0].Text == ((CSpvMibmodule)objet).NomModuleUtilisateur)
                            return;
                    }
                    ListViewItem item2 = new ListViewItem();
                    m_listMibs.Items.Add(item2);
                    m_listMibs.UpdateItemWithObject(item2, objet);
                }
            }

            /*
             * if (m_txtBoxExtremite.Text.Trim().Length == 0)
                return;

            CExtremiteLienSurSite extremite = new CExtremiteLienSurSite(ContexteDonnee);
            extremite.Site = LeSite;
            extremite.Libelle = m_txtBoxExtremite.Text;

            ListViewItem item = new ListViewItem();
            m_wndListeExtremites.Items.Add(item);
            m_wndListeExtremites.UpdateItemWithObject(item, extremite);
            foreach (ListViewItem itemSel in m_wndListeExtremites.SelectedItems)
                itemSel.Selected = false;
            item.Selected = true;
            m_txtBoxExtremite.Text = "";*/
        }

        private void m_lnkSupprimer_LinkClicked(object sender, EventArgs e)
        {
            if (m_listMibs.SelectedItems.Count > 0)
            {
                for (int i = m_listMibs.SelectedItems.Count - 1; i >= 0; i--)
                    m_listMibs.Items.Remove(m_listMibs.SelectedItems[i]);
            }

        }//MyMajChamps()
    }
}

