using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using futurocom.snmp.entitesnmp;
using futurocom.snmp.alarme;
using futurocom.easyquery;
using sc2i.drawing;
using sc2i.expression;
using sc2i.common;
using sc2i.win32.common;

namespace futurocom.win32.snmp.entitesnmp
{
    public partial class CPanelEditeTypeEntiteSnmp : UserControl, IControlALockEdition
    {
        private CTypeEntiteSnmpPourSupervision m_typeEntite = null;
        private CTypeAgentPourSupervision m_typeAgent = null;

        public CPanelEditeTypeEntiteSnmp()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------
        public void Init(CTypeEntiteSnmpPourSupervision typeEntite,
            CTypeAgentPourSupervision typeAgent)
        {
            m_typeAgent = typeAgent;
            m_typeEntite = typeEntite;
            
            InitChamps();
        }

        //-------------------------------------------------------------------
        private void InitChamps()
        {
            m_extLinkField.FillDialogFromObjet(m_typeEntite);
            m_txtFormuleIndex.Init(new CFournisseurGeneriqueProprietesDynamiques(),
                new CObjetPourSousProprietes(m_typeEntite.GetEntiteDeTest()));
            m_txtFormuleIndex.Formule = m_typeEntite.FormuleIndexParDefaut;
            m_txtFormuleLibelle.Init(new CFournisseurGeneriqueProprietesDynamiques(),
                new CObjetPourSousProprietes(m_typeEntite.GetEntiteDeTest()));
            m_txtFormuleLibelle.Formule = m_typeEntite.FormuleLibelle;
            /*m_panelFormulaire.Init(typeof(CEntiteSnmpPourSupervision),
                m_typeEntite.GetEntiteDeTest(),
                m_typeEntite.Formulaire,
                new CFournisseurGeneriqueProprietesDynamiques());*/
            m_cmbModeGestion.Items.Clear();
            foreach (EModeGestionEntiteAgent mode in Enum.GetValues(typeof(EModeGestionEntiteAgent)))
                m_cmbModeGestion.Items.Add(mode);
            m_cmbModeGestion.SelectedItem = m_typeEntite.ModeGestion;
            
            m_lnkEditSourceQuery.Visible = m_typeEntite.IdObjetDeQuerySource != "";

            UpdateLabelSource();

            FillListeChamps();
        }

        //-------------------------------------------------------------------
        private void UpdateLabelSource()
        {
            CODEQBase objet = GetObjetDeQuerySource();
            if (objet != null && objet.Query != null)
            {
                m_lblRequeteSource.Text = objet.Query.Libelle + " (" + objet.NomFinal + ")";
            }
        }

        //-------------------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = m_extLinkField.FillObjetFromDialog(m_typeEntite);
            if (!result)
                return result;
            m_typeEntite.FormuleIndexParDefaut = m_txtFormuleIndex.Formule;
            m_typeEntite.FormuleLibelle = m_txtFormuleLibelle.Formule;
            if (m_cmbModeGestion.SelectedItem is EModeGestionEntiteAgent)
                m_typeEntite.ModeGestion = (EModeGestionEntiteAgent)m_cmbModeGestion.SelectedItem;
            return result;
        }

        //-------------------------------------------------------------------
        private void FillListeChamps()
        {
            m_wndListeChamps.ListeSource = m_typeEntite.Champs.ToArray();
            m_wndListeChamps.Refresh();
        }

        //-------------------------------------------------------------------
        private void CPanelEditeTypeEntiteSnmp_Load(object sender, EventArgs e)
        {

        }

        
        //-------------------------------------------------------------------
        private class CMenuTableDeRequete : ToolStripMenuItem
        {
            public CODEQBase ObjetDeQuery = null;
            public CMenuTableDeRequete(CODEQBase objet)
                : base(objet.NomFinal)
            {
                ObjetDeQuery = objet;
            }
        }

        //-------------------------------------------------------------------

        private void AssureMenuFromRequete()
        {
            if (m_menuFromRequete.Items.Count != 0)
                return;
            foreach (CEasyQuery query in m_typeAgent.Queries)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(query.Libelle);
                foreach (I2iObjetGraphique objet in query.Childs)
                {
                    CODEQBase objDeQuery = objet as CODEQBase;
                    if (objDeQuery != null)
                    {
                        CMenuTableDeRequete menu = new CMenuTableDeRequete(objDeQuery);
                        item.DropDownItems.Add(menu);
                        menu.Click += new EventHandler(menuDeRequete_Click);
                    }
                }
                m_menuFromRequete.Items.Add(item);
            }
        }


        //-------------------------------------------------------------------
        void menuDeRequete_Click(object sender, EventArgs e)
        {
            CMenuTableDeRequete menu = sender as CMenuTableDeRequete;
            if (menu != null)
            {
                CODEQBase objet = menu.ObjetDeQuery;
                m_typeEntite.FillFromTable(objet);
                UpdateLabelSource();
                FillListeChamps();
            }
        }

        //-------------------------------------------------------------------
        private void snmpFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CChampEntiteFromQuery champ = new CChampEntiteFromQuery();
            if (CFormEditChampEntiteFromQuery.EditeChamp(champ, m_typeEntite))
            {
                m_typeEntite.AddChamp(champ);
                FillListeChamps();
            }
        }

        //-------------------------------------------------------------------
        private void standardField20086ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_wndListeChamps.SelectedItems.Count == 1)
            {
                CChampEntiteFromQuery champ = m_wndListeChamps.SelectedItems[0] as CChampEntiteFromQuery;
                if (champ != null)
                {
                    m_typeEntite.RemoveChamp(champ);
                    FillListeChamps();
                }
            }
        }

        //-------------------------------------------------------------------
        private void m_wndListeChamps_DoubleClick(object sender, EventArgs e)
        {
            if (m_wndListeChamps.SelectedItems.Count == 1)
            {
                CChampEntiteFromQuery champ = m_wndListeChamps.SelectedItems[0] as CChampEntiteFromQuery;
                if (champ != null)
                {
                    if (CFormEditChampEntiteFromQuery.EditeChamp(champ, m_typeEntite))
                        FillListeChamps();
                }
            }
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
                    OnChangeLockEdition(this, new EventArgs());
            }
        }

        public event EventHandler OnChangeLockEdition;

        #endregion


        //------------------------------------------------------------------------------
        private void m_lnkEditSourceQuery_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string strId = m_typeEntite.IdObjetDeQuerySource;
            if (strId != "")
            {
                CODEQBase objet = GetObjetDeQuerySource();
                if ( objet != null && objet.Query != null )
                {
                    CFormEditEasyQuery.EditeQuery(objet.Query);
                }
            }
        }

        //------------------------------------------------------------------------------
        private CODEQBase GetObjetDeQuerySource()
        {
            CEasyQuery query = m_typeAgent.Queries.FirstOrDefault(c => c.GetObjet(m_typeEntite.IdObjetDeQuerySource) != null);
            if (query != null)
                return query.Childs.FirstOrDefault(o => o is IObjetDeEasyQuery && ((IObjetDeEasyQuery)o).Id == m_typeEntite.IdObjetDeQuerySource) as CODEQBase;
            return null;
        }

        private void m_lnkRemoveField_LinkClicked(object sender, EventArgs e)
        {

        }

        private void m_lblRequeteSource_Click(object sender, EventArgs e)
        {
            AssureMenuFromRequete();
            m_menuFromRequete.Show(m_lblRequeteSource, new Point(0, m_lblRequeteSource.Height));
        }
    }
}