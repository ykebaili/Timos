using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using timos.data.symbole.dynamique;
using sc2i.common;
using timos.symbole;
using timos.data;
using System.Reflection;
using timos.data.symbole;
using sc2i.expression;
using sc2i.win32.common;

namespace timos.Reseau
{
    public partial class CFormEditCParametreRepresentationSymbole : Form
    {
        private CParametreRepresentationSymbole m_parametre = null;
        private Type m_typeElements = null;

        private List<CControlEditFormulePropriete> m_listeControlesFormule = new List<CControlEditFormulePropriete>();

        public CFormEditCParametreRepresentationSymbole()
        {
            InitializeComponent();
        }

        public static CParametreRepresentationSymbole EditeParametre(
            Type typeElements,
            CParametreRepresentationSymbole parametre)
        {
            CFormEditCParametreRepresentationSymbole form = new CFormEditCParametreRepresentationSymbole();
            if (parametre != null)
            {
                form.m_parametre = CCloner2iSerializable.Clone(parametre) as CParametreRepresentationSymbole;
                if (form.m_parametre == null)
                    form.m_parametre = new CParametreRepresentationSymbole();
            }
            form.m_typeElements = typeElements;
            DialogResult result = form.ShowDialog();
            CParametreRepresentationSymbole newParametre = parametre;
            if (result == DialogResult.OK)
                newParametre = form.m_parametre;
            form.Dispose();
            return newParametre;
        }

        private void CFormEditCParametreRepresentationSymbole_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
            m_panelEditeurSymbole.Init(m_parametre.Symbole, m_typeElements, false);
        }

        private void m_panelEditeurSymbole_SelectionChanged(object sender, EventArgs e)
        {
            InitPanelFormules();
        }


        private C2iSymbole m_lastSymbolSel = null;
        private void InitPanelFormules()
        {
            ValidePanelFormules();
            m_lastSymbolSel = null;
            C2iSymbole objet = m_panelEditeurSymbole.ObjetSelectionne;
            m_panelFormules.SuspendDrawing();
            foreach ( Control ctrl in m_panelFormules.Controls )
            {
                CControlEditFormulePropriete ctrlFormule = ctrl as CControlEditFormulePropriete;
                if ( ctrl != null )
                {
                    ctrlFormule.Visible = false;
                    ctrlFormule.Clear();
                }
                
            }
            if (objet == null || objet.Name.Trim() == "")
            {
                m_panelFormules.ResumeDrawing();
                return;
            }
            int nControle = 0;
            CParametreRepresentationElementDeSymbole parametreElement = 
                m_parametre.Parametres.FirstOrDefault ( p=>p.ElementName == objet.Name );

            foreach ( PropertyInfo propriete in objet.GetType().GetProperties())
            {
                if (propriete.GetGetMethod() == null)
                    continue;
                if (propriete.PropertyType != typeof(Color) &&
                    propriete.PropertyType != typeof(int) &&
                    propriete.PropertyType != typeof(string) &&
                    propriete.PropertyType != typeof(double) && 
                    propriete.PropertyType != typeof(bool))
                    continue;
                //Ne prend pas le propriétés non browsable
                object[] attrs = propriete.GetCustomAttributes ( typeof(BrowsableAttribute), true);
                if ( attrs.Length > 0 )
                {
                    BrowsableAttribute attr = (BrowsableAttribute)attrs[0];
                    if ( !attr.Browsable )
                        continue;
                }
                CControlEditFormulePropriete ctrlFormule = null;
                if (nControle >= m_listeControlesFormule.Count())
                {
                    ctrlFormule = new CControlEditFormulePropriete();
                    m_panelFormules.Controls.Add(ctrlFormule);
                    ctrlFormule.Dock = DockStyle.Top;
                    m_listeControlesFormule.Add(ctrlFormule);
                }
                else
                    ctrlFormule = m_listeControlesFormule[nControle];
                nControle++;
                C2iExpression formule = null;
                if ( parametreElement != null )
                    formule = parametreElement[propriete.Name];
                ctrlFormule.Init ( m_typeElements, propriete.Name, formule );
                ctrlFormule.Visible = true;
                ctrlFormule.BringToFront();
            }
            m_panelFormules.ResumeDrawing();
            m_lastSymbolSel = objet;
        }

        private void ValidePanelFormules()
        {
            if (m_lastSymbolSel != null)
            {
                CParametreRepresentationElementDeSymbole parametre = new CParametreRepresentationElementDeSymbole();
                parametre.ElementName = m_lastSymbolSel.Name;
                bool bHasFormules = false;
                foreach (Control ctrl in m_panelFormules.Controls)
                {
                    CControlEditFormulePropriete ctrlFormule = ctrl as CControlEditFormulePropriete;
                    if (ctrlFormule != null )
                    {
                        if (ctrlFormule.Propriete.Length > 0 && ctrlFormule.Formule != null)
                        {
                            parametre[ctrlFormule.Propriete] = ctrlFormule.Formule;
                            bHasFormules = true;
                        }
                    }
                }
                if (bHasFormules)
                {
                    m_parametre.AddParametre(parametre);
                }                        
            }
        }

        private void m_btnOk_Click(object sender, EventArgs e)
        {
            ValidePanelFormules();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void m_btnAnnuler_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }





    }
}
