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
    public partial class CControleEditeMapLineGenerator : UserControl, IControleEditeMapItem, IControlALockEdition
    {
        private CMapLineGenerator m_mapLineGenerator = null;
        //-----------------------------------------------
        public CControleEditeMapLineGenerator()
        {
            InitializeComponent();
        }

        //-----------------------------------------------
        public static void Autoexec()
        {
            CAllocateurInterfaceMapItemGenerator.RegisterControle(typeof(CMapLineGenerator), typeof(CControleEditeMapLineGenerator));
        }
        //-----------------------------------------------
        public void InitChamps(IMapItemGenerator item)
        {
            m_mapLineGenerator = item as CMapLineGenerator;
            if (m_mapLineGenerator == null)
            {
                Visible = false;
                return;
            }
            Visible = true;
            m_panelFiltre.InitSansVariables(m_mapLineGenerator.Filtre);
            m_txtLibelle.Text = m_mapLineGenerator.Libelle;
            m_panelDessins.Init(m_mapLineGenerator);

            m_txtFormuleLatitude1.Init(item.Generator, m_mapLineGenerator.TypeElementsDessines);
            m_txtFormuleLongitude1.Init(item.Generator, m_mapLineGenerator.TypeElementsDessines);
            m_txtFormuleLatitude2.Init(item.Generator, m_mapLineGenerator.TypeElementsDessines);
            m_txtFormuleLongitude2.Init(item.Generator, m_mapLineGenerator.TypeElementsDessines);

            m_txtFormuleLongitude1.Formule = m_mapLineGenerator.FormuleLongitude1;
            m_txtFormuleLatitude1.Formule = m_mapLineGenerator.FormuleLatitude1;
            m_txtFormuleLongitude2.Formule = m_mapLineGenerator.FormuleLongitude2;
            m_txtFormuleLatitude2.Formule = m_mapLineGenerator.FormuleLatitude2;
            UpdateVisuActionSurClick();
        }

        //-----------------------------------------------
        private void UpdateVisuActionSurClick()
        {
            m_panelActionNotNull.Visible = m_mapLineGenerator.ActionSurClick != null;
        }


        //-----------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_mapLineGenerator != null)
            {
                m_mapLineGenerator.Filtre = m_panelFiltre.FiltreDynamique;
                m_mapLineGenerator.Libelle = m_txtLibelle.Text;
                result = m_panelDessins.MajChamps();
                m_mapLineGenerator.FormuleLatitude1 = m_txtFormuleLatitude1.Formule;
                m_mapLineGenerator.FormuleLongitude1 = m_txtFormuleLongitude1.Formule;
                m_mapLineGenerator.FormuleLatitude2 = m_txtFormuleLatitude2.Formule;
                m_mapLineGenerator.FormuleLongitude2 = m_txtFormuleLongitude2.Formule;
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
            m_txtFormuleLongitude1.Init( m_mapLineGenerator.Generator, typeSelectionne);
            m_txtFormuleLatitude1.Init ( m_mapLineGenerator.Generator, typeSelectionne);
        }

        //-----------------------------------------------
        private void m_btnDeleteActionSurClick_Click(object sender, EventArgs e)
        {
            if (m_mapLineGenerator.ActionSurClick != null)
            {
                if (CFormAlerte.Afficher(I.T("Remove action ?|20016"),
                    EFormAlerteBoutons.OuiNon,
                    EFormAlerteType.Question) == DialogResult.Yes)
                {
                    m_mapLineGenerator.ActionSurClick = null;
                    UpdateVisuActionSurClick();
                }
            }
        }

        //-----------------------------------------------
        private void m_lnkClickAction_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_panelFiltre.FiltreDynamique != null && m_panelFiltre.FiltreDynamique.TypeElements != null)
            {
                CActionSur2iLink action = m_mapLineGenerator.ActionSurClick;
                CActionSur2iLinkEditor.EditeAction(ref action, m_panelFiltre.FiltreDynamique.TypeElements);
                m_mapLineGenerator.ActionSurClick = action;
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
                return m_mapLineGenerator;
            }
        }

        
        
    }
}
