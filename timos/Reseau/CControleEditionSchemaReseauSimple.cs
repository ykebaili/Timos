using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using timos.data.workflow.ConsultationHierarchique;
using sc2i.win32.data;
using timos.data;
using sc2i.data;
using sc2i.win32.common;
using sc2i.common;
using timos.data.reseau.graphe;
using timos.data.reseau.arbre_operationnel;
using timos.data.symbole.dynamique;

namespace timos.Reseau
{
    public partial class CControleEditionSchemaReseauSimple : UserControl, IControlALockEdition
    {
        private CSchemaReseau m_schemaReseau;
        private C2iObjetDeSchema m_objetDeSchema = null;
        private CLienReseau m_lienEdite = null;
        
        
        public CControleEditionSchemaReseauSimple()
        {
            InitializeComponent();
        }

        public void Init(C2iObjetDeSchema objetEdite, CSchemaReseau schemaReseau)
        {

            m_panelSchema.ObjetEdite = objetEdite;
            m_panelSchema.Editeur = null;
            m_panelSchema.NoClipboard = true;
            m_schemaReseau = schemaReseau;
            m_objetDeSchema = objetEdite;

            m_panelSchema.ObjetSchemaReseau = schemaReseau;
            m_panelSchema.ModeEdition = EModeEditeurSchema.Selection;

            if (schemaReseau != null)
            {
                m_lienEdite = schemaReseau.LienReseau;
                m_panelSchema.LienReseauEdite = m_lienEdite;
            }

        }

        //---------------------------------------------------------------------------
        public CParametreRepresentationSchema ParametreDynamique
        {

            get
            {
                return m_panelSchema.ParametreDynamique;
            }
            set
            {
                m_panelSchema.ParametreDynamique = value;
            }
        }

        //---------------------------------------------------------------------------
        public EModeEditeurSchema ModeEdition
        {

            get
            {
                return m_panelSchema.ModeEdition;
            }
            set
            {
                m_panelSchema.ModeEdition = value;
            }
        }


        //---------------------------------------------------------------------------
        public CPanelEditionObjetGraphique Editeur
        {
            get
            {
                return m_panelSchema;

            }
        }


        //---------------------------------------------------------------------------
        public C2iObjetDeSchema ObjetDeSchema
        {
            get
            {
                return m_objetDeSchema;
            }
        }

        #region IControlALockEdition Membres

        //---------------------------------------------------------------------------
        public bool LockEdition
        {
            get
            {
                return m_panelSchema.LockEdition;
            }
            set
            {
                m_panelSchema.LockEdition = value;
            }
        }

        public event EventHandler OnChangeLockEdition;

        #endregion

        private void m_btnModeSelection_CheckedChanged(object sender, EventArgs e)
        {
            if (m_btnModeSelection.Checked)
            {
                if (m_panelSchema.ModeEdition != EModeEditeurSchema.Selection)
                {
                    m_panelSchema.ModeEdition = EModeEditeurSchema.Selection;
                    m_panelSchema.Focus();
                    Refresh();
                }
            }

        }

        private void m_btnModeZoom_CheckedChanged(object sender, EventArgs e)
        {
            if (m_btnModeZoom.Checked)
            {
                if (m_panelSchema.ModeEdition != EModeEditeurSchema.Zoom)
                {
                    m_panelSchema.ModeEdition = EModeEditeurSchema.Zoom;
                    m_panelSchema.Focus();
                    Refresh();
                }
            }

        }
    }
}
