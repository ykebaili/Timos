using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using futurocom.sig;
using sc2i.common;
using sc2i.expression;
using sc2i.formulaire;

namespace futurocom.win32.sig
{
    [AutoExec("Autoexec")]
    public partial class CControleEditeMapPointGenerator : UserControl, IControleEditeMapItem, IControlALockEdition
    {
        private CMapPointGenerator m_mapPointGenerator = null;
        //-----------------------------------------------
        public CControleEditeMapPointGenerator()
        {
            InitializeComponent();
        }

        //-----------------------------------------------
        public static void Autoexec()
        {
            CAllocateurInterfaceMapItemGenerator.RegisterControle(typeof(CMapPointGenerator), typeof(CControleEditeMapPointGenerator));
        }
        //-----------------------------------------------
        public void InitChamps(IMapItemGenerator item)
        {
            m_mapPointGenerator = item as CMapPointGenerator;
            if (m_mapPointGenerator == null)
            {
                Visible = false;
                return;
            }
            Visible = true;
            m_panelFiltre.InitSansVariables(m_mapPointGenerator.Filtre);
            m_txtLibelle.Text = m_mapPointGenerator.Libelle;
            m_panelDessins.Init(m_mapPointGenerator);

            m_txtFormuleLatitude.Init(item.Generator, m_mapPointGenerator.TypeElementsDessines);
            m_txtFormuleLongitude.Init(item.Generator, m_mapPointGenerator.TypeElementsDessines);

            m_txtFormuleLongitude.Formule = m_mapPointGenerator.FormuleLongitude;
            m_txtFormuleLatitude.Formule = m_mapPointGenerator.FormuleLatitude;
            UpdateVisuActionSurClick();
        }

        //-----------------------------------------------
        private void UpdateVisuActionSurClick()
        {
            m_panelActionNotNull.Visible = m_mapPointGenerator.ActionSurClick != null;
        }


        //-----------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_mapPointGenerator != null)
            {
                m_mapPointGenerator.Filtre = m_panelFiltre.FiltreDynamique;
                m_mapPointGenerator.Libelle = m_txtLibelle.Text;
                result = m_panelDessins.MajChamps();
                m_mapPointGenerator.FormuleLatitude = m_txtFormuleLatitude.Formule;
                m_mapPointGenerator.FormuleLongitude = m_txtFormuleLongitude.Formule;
            }
            return result;
        }

        

        //-----------------------------------------------
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

        //-----------------------------------------------
        public event EventHandler OnChangeLockEdition;

        //-----------------------------------------------
        private void m_panelFiltre_OnChangeTypeElements(object sender, Type typeSelectionne)
        {
            m_panelDessins.TypeEdite = typeSelectionne;
            m_txtFormuleLongitude.Init( m_mapPointGenerator.Generator, typeSelectionne);
            m_txtFormuleLatitude.Init ( m_mapPointGenerator.Generator, typeSelectionne);
        }

        //-----------------------------------------------
        private void m_btnDeleteActionSurClick_Click(object sender, EventArgs e)
        {
            if (m_mapPointGenerator.ActionSurClick != null)
            {
                if (CFormAlerte.Afficher(I.T("Remove action ?|20016"),
                    EFormAlerteBoutons.OuiNon,
                    EFormAlerteType.Question) == DialogResult.Yes)
                {
                    m_mapPointGenerator.ActionSurClick = null;
                    UpdateVisuActionSurClick();
                }
            }
        }

        //-----------------------------------------------
        private void m_lnkClickAction_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_panelFiltre.FiltreDynamique != null && m_panelFiltre.FiltreDynamique.TypeElements != null)
            {
                CActionSur2iLink action = m_mapPointGenerator.ActionSurClick;
                CActionSur2iLinkEditor.EditeAction(ref action, m_panelFiltre.FiltreDynamique.TypeElements);
                m_mapPointGenerator.ActionSurClick = action;
                UpdateVisuActionSurClick();
            }
            else
            {
                CFormAlerte.Afficher(I.T("Select element type first|20017"));
            }
        }

        //---------------------------------------------------------------
        public IMapItemGenerator CurrentGenerator
        {
            get
            {
                return m_mapPointGenerator ;
            }
        }

        
        
    }
}
