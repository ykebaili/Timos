using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using sc2i.expression;
using futurocom.sig;
using sc2i.data;
using sc2i.common;

namespace futurocom.win32.sig
{
    public partial class CFormEditConfigWndMapView : Form
    {
        private CConfigCalqueMap m_calqueEdite = null;

        private CConfigWndMapView m_configEditee = null;

        private CObjetPourSousProprietes m_objetEdite = null;
        private IFournisseurProprietesDynamiques m_fournisseurProprietes = null;

        //---------------------------------------------------------------------
        public CFormEditConfigWndMapView()
        {
            InitializeComponent();
        }

        //---------------------------------------------------------------------
        private void CFormEditConfigWndMapView_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
        }


        //---------------------------------------------------------------------
        private void c2iTabControl1_SelectionChanged(object sender, EventArgs e)
        {

        }

        //---------------------------------------------------------------------
        public static bool EditeConfig ( 
            CConfigWndMapView config, 
            CObjetPourSousProprietes objetEdite,
            IFournisseurProprietesDynamiques fournisseur)
        {
            CFormEditConfigWndMapView form = new CFormEditConfigWndMapView();
            form.Init ( config, objetEdite, fournisseur );
            bool bResult = form.ShowDialog() == DialogResult.OK;
            form.Dispose();
            return bResult;
        }

        //---------------------------------------------------------------------
        private IFournisseurProprietesDynamiques FournisseurProprietes
        {
            get{
                if ( m_fournisseurProprietes == null )
                    m_fournisseurProprietes = new CFournisseurGeneriqueProprietesDynamiques();
                return m_fournisseurProprietes;
            }
        }

        //---------------------------------------------------------------------
        private CObjetPourSousProprietes ObjetEdite
        {
            get{
                return m_objetEdite;
            }
        }


        //---------------------------------------------------------------------
        private void Init ( 
            CConfigWndMapView config, 
            CObjetPourSousProprietes objetEdite,
            IFournisseurProprietesDynamiques fournisseurProprietes)
        {
            m_configEditee = config;
            m_fournisseurProprietes = fournisseurProprietes;
            m_objetEdite = objetEdite;
            m_txtFormuleLatitude.Init ( FournisseurProprietes, ObjetEdite );
            m_txtFormuleLongitude.Init ( FournisseurProprietes, ObjetEdite );
            m_txtFormuleZoom.Init(FournisseurProprietes, ObjetEdite);
            m_txtFormuleKeepState.Init(FournisseurProprietes, ObjetEdite);
            
            m_txtFormuleLatitude.Formule = m_configEditee.FormuleLatitude;
            m_txtFormuleLongitude.Formule = m_configEditee.FormuleLongitude;
            m_txtFormuleZoom.Formule = m_configEditee.FormuleZoomFactor;
            m_txtFormuleKeepState.Formule = m_configEditee.FormulePreserveStateKey;

            m_chkPreserveCenter.Checked = m_configEditee.PreserveCenter;
            m_chkPreserveLayers.Checked = m_configEditee.PreserveLayers;
            m_chkPreserveMapMode.Checked = m_configEditee.PreserveMapMode;
            m_chkPreserveZoom.Checked = m_configEditee.PreserveZoom;
            

            m_rbtnViewMap.Checked = config.MapMode == EWndMapMode.Map;
            m_rbtnAerial.Checked = config.MapMode == EWndMapMode.Aerial;
            m_rbtnHybride.Checked = config.MapMode == EWndMapMode.Hybrid;

            CListeObjetDonneeGenerique<CConfigMapDatabase> lstConfigs = CConfigMapDatabase.GetConfigsFor(
                CContexteDonneeSysteme.GetInstance(),
                objetEdite );
            m_wndListeCalques.BeginUpdate();
            foreach ( CConfigMapDatabase configDB in lstConfigs )
            {
                bool bIsChecked = false;
                //TESTDBKEYOK
                CConfigCalqueMap configCalque = m_configEditee.GetConfigForCalque ( configDB.DbKey );
                if ( configCalque == null )
                {
                    configCalque = new CConfigCalqueMap();
                    //TESTDBKEYOK
                    configCalque.KeyConfigMapDatabase = configDB.DbKey;
                }
                else
                    bIsChecked = true;
                configCalque.generator = configDB.MapGenerator;
                ListViewItem item = new ListViewItem (configDB.Libelle);
                item.Tag = configCalque;
                item.Checked = bIsChecked;
                m_wndListeCalques.Items.Add ( item );                    
            }
            m_wndListeCalques.EndUpdate();
        }

        //---------------------------------------------------------------------
        private void MajCalqueEnCours()
        {
            if (m_calqueEdite != null)
            {
                List<CFormuleNommee> lst = new List<CFormuleNommee>();
                foreach (CFormuleNommee formule in m_wndListeValeursVariables.GetFormules())
                {
                    if (formule.Formule != null)
                        lst.Add(formule);
                }
                m_calqueEdite.ValeursVariablesFiltre = lst.ToArray();
            }
        }

        //---------------------------------------------------------------------
        private void m_wndListeCalques_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_calqueEdite != null)
                MajCalqueEnCours();
            m_calqueEdite = null;
            m_panelOptionsCalque.Visible = false;
            if (m_wndListeCalques.SelectedItems.Count != 1)
            {
                return;
            }
            else
            {
                ListViewItem item = m_wndListeCalques.SelectedItems[0];
                CConfigCalqueMap config = item.Tag as CConfigCalqueMap;
                if (config == null)
                    return;
                m_panelOptionsCalque.Visible = true;
                List<CFormuleNommee> lstFormules = new List<CFormuleNommee>();
                foreach (IVariableDynamique variable in config.generator.ListeVariables)
                {
                    //Trouve la formule existante
                    CFormuleNommee formule = null;
                    foreach (CFormuleNommee f in config.ValeursVariablesFiltre)
                    {
                        if (f.Id == variable.IdVariable)
                        {
                            formule = f;
                            break;
                        }
                    }
                    if (formule == null)
                    {
                        formule = new CFormuleNommee(variable.Nom, null);
                        formule.Id = variable.IdVariable;
                    }
                    lstFormules.Add(formule);
                }
                m_wndListeValeursVariables.Init(
                    lstFormules.ToArray(),
                    m_objetEdite,
                    m_fournisseurProprietes);
                m_calqueEdite = config;
            }
        }

        //---------------------------------------------------------------------
        private CResultAErreur MajChamps()
        {
            MajCalqueEnCours();
            CResultAErreur result = CResultAErreur.True;
            m_configEditee.FormuleLatitude = m_txtFormuleLatitude.Formule;
            m_configEditee.FormuleLongitude = m_txtFormuleLongitude.Formule;
            m_configEditee.FormuleZoomFactor = m_txtFormuleZoom.Formule;
            m_configEditee.FormulePreserveStateKey = m_txtFormuleKeepState.Formule;

            m_configEditee.PreserveCenter = m_chkPreserveCenter.Checked;
            m_configEditee.PreserveLayers = m_chkPreserveLayers.Checked;
            m_configEditee.PreserveMapMode = m_chkPreserveMapMode.Checked;
            m_configEditee.PreserveZoom = m_chkPreserveZoom.Checked;

            if (m_rbtnViewMap.Checked)
                m_configEditee.MapMode = EWndMapMode.Map;
            if (m_rbtnHybride.Checked)
                m_configEditee.MapMode = EWndMapMode.Hybrid;
            if (m_rbtnAerial.Checked)
                m_configEditee.MapMode = EWndMapMode.Aerial;

            List<CConfigCalqueMap> lstCalques = new List<CConfigCalqueMap>();
            foreach (ListViewItem item in m_wndListeCalques.CheckedItems)
            {
                CConfigCalqueMap conf = item.Tag as CConfigCalqueMap;
                if (conf != null)
                    lstCalques.Add(conf);
            }
            m_configEditee.ConfigsCalques = lstCalques.ToArray();
            return result;
        }

        private void m_btnOk_Click(object sender, EventArgs e)
        {
            CResultAErreur result = MajChamps();
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
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

        private void tabPage1_PropertyChanged(Crownwood.Magic.Controls.TabPage page, Crownwood.Magic.Controls.TabPage.Property prop, object oldValue)
        {

        }



    }

    [AutoExec("Autoexec")]
    public class CEditeurConfigWndMapView : IEditeurConfigWndMapView
    {
        private static CEditeurConfigWndMapView m_instance = null;

        //--------------------------------------------------------------
        private CEditeurConfigWndMapView()
        {
        }

        //--------------------------------------------------------------
        public static void Autoexec()
        {
            CConfigWndMapViewEditor.SetEditeur(CEditeurConfigWndMapView.Instance);
        }

        //--------------------------------------------------------------
        public static CEditeurConfigWndMapView Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new CEditeurConfigWndMapView();
                return m_instance;
            }
        }
    
        //--------------------------------------------------------------------------------
        public CConfigWndMapView EditeConfig(
            CConfigWndMapView config, 
            CObjetPourSousProprietes objetEdite,
            IFournisseurProprietesDynamiques fournisseur)
        {
            CFormEditConfigWndMapView.EditeConfig(config, objetEdite, fournisseur);
            return config;
        }
        
    }

}
