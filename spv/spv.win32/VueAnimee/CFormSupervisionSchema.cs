using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using timos.data;
using sc2i.win32.common;
using sc2i.common;
using sc2i.win32.navigation;
using spv.data.VueAnimee;
using sc2i.data;

namespace spv.win32.VueAnimee
{
    public partial class CFormSupervisionSchema : Form
    {
        private CSchemaReseau m_schemaSupervise = null;
        private CFormNavigateur m_navigateur = null;

        private CBasePourVueAnimee m_basePourVue = null;
        private CContexteDonnee m_contexteDonnee = null;

        public CFormSupervisionSchema()
        {
            InitializeComponent();
        }

        public CFormSupervisionSchema(CBasePourVueAnimee basePourVue)
        {
        }

        public static void Superviser(CSchemaReseau schemaReseau, CFormNavigateur navigateur)
        {
            CFormSupervisionSchema form = new CFormSupervisionSchema();
            form.m_navigateur = navigateur;
            
            form.WindowState = FormWindowState.Maximized;
            form.InitForSchema(schemaReseau);
            form.Show();
            form.BringToFront();
            form.m_controleSchema.Enabled = false;
            form.m_controleSchema.Refresh();
            //InitCalcul(form);
            new InitCalculDelegate(InitCalcul).BeginInvoke(form, null, null);
        }

        private void InitForSchema(CSchemaReseau schema)
        {
            if (m_contexteDonnee == null)
                m_contexteDonnee = new CContexteDonnee(schema.ContexteDonnee.IdSession, true, true);
            schema = schema.GetObjetInContexte(m_contexteDonnee) as CSchemaReseau;
            m_basePourVue = new CBasePourVueAnimee(m_contexteDonnee, true);
            m_controleSchema.Init(schema, m_basePourVue, m_navigateur);
            m_schemaSupervise = schema;
            
        }

        private delegate void InitCalculDelegate(CFormSupervisionSchema form);

        private static void InitCalcul(CFormSupervisionSchema form)
        {
            form.m_basePourVue.InitForSupervision(form.m_schemaSupervise);
            form.m_controleSchema.Enabled = true;
            form.m_controleSchema.SetChargementTermine(); ;
        }
        
        private void CFormSupervisionSchema_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
        }

        private void m_btnPagePrecedente_Click(object sender, EventArgs e)
        {
            m_controleSchema.DrillUp();
        }

        private void m_btnHome_Click(object sender, EventArgs e)
        {
            m_controleSchema.Home();
        }

        private void m_btnExit_Click(object sender, EventArgs e)
        {
            if (CFormAlerte.Afficher(I.T("Quit supervision view|20016"),
                EFormAlerteBoutons.OuiNon, EFormAlerteType.Question) == DialogResult.Yes)
            {
                Close();
                Dispose();
            }
        }

        private void m_btnRefresh_Click(object sender, EventArgs e)
        {
            m_controleSchema.RedrawSchema();
        }

        private void m_controleSchema_OnChangeSchemaAffiche(object sender, EventArgs e)
        {
            if (m_controleSchema.SchemaAffiche != null)
            {
                CSchemaReseau schema = m_controleSchema.SchemaAffiche;
                if (schema.LienReseau != null)
                    m_lblTitre.Text = schema.LienReseau.Libelle;
                else
                    m_lblTitre.Text = schema.Libelle;
            }
        }

        private void m_chkALwaysVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkALwaysVisible.Checked)
                this.TopMost = true;
            else
                this.TopMost = false;
        }
    }
}