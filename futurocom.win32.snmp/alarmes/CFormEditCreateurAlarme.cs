using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using futurocom.snmp.alarme;
using futurocom.supervision;
using sc2i.expression;
using sc2i.common;
using sc2i.win32.common;
using sc2i.common.memorydb;

namespace futurocom.win32.snmp.alarmes
{
    public partial class CFormEditCreateurAlarme : Form
    {
        private CCreateurAlarme m_createur = null;
        private IBaseTypesAlarmes m_baseTypesAlarmes = null;

        public CFormEditCreateurAlarme()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------
        public static bool EditeCreateur(CCreateurAlarme createur, IBaseTypesAlarmes baseAlarmes)
        {
            CFormEditCreateurAlarme form = new CFormEditCreateurAlarme();
            CMemoryDb dbEdition = new CMemoryDb();
            form.m_createur = dbEdition.ImporteObjet(createur, true, true) as CCreateurAlarme;
            //form.m_createur = CCloner2iSerializable.Clone(createur) as CCreateurAlarme;
            form.m_createur.TrapHandler = createur.TrapHandler;
            form.m_baseTypesAlarmes = baseAlarmes;
            bool bResult = false;
            if (form.ShowDialog() == DialogResult.OK)
            {
                createur.Database.ImporteObjet(form.m_createur, true, true);
                bResult = true;
            }
            form.Dispose();
            return bResult;
        }


        //-------------------------------------------------------
        private void InitChamps()
        {
            m_txtLibelle.Text = m_createur.Libelle;
            m_txtCode.Text = m_createur.Code;
            m_cmbTypeAlarme.ListDonnees = m_baseTypesAlarmes.TypesAlarmes;
            m_cmbTypeAlarme.SelectedValue = m_createur.TypeAlarme;

            m_txtFormuleCondition.Init(m_createur, typeof(CTrapInstance));
            m_txtFormuleCondition.Formule = m_createur.FormuleCondition;

            C2iExpression formuleConversion = m_createur.FormuleActions;
            if (!(formuleConversion is C2iExpressionGraphique))
            {
                C2iExpressionGraphique graf = new C2iExpressionGraphique();
                graf.InitFromFormule(formuleConversion);
                formuleConversion = graf;
            }
            m_editeurActionConversion.Init(formuleConversion as C2iExpressionGraphique,
                m_createur,
                new CObjetPourSousProprietes(m_createur.TrapHandler.TypeAgent));
        }

        //-------------------------------------------------------
        private CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            m_createur.TypeAlarme = m_cmbTypeAlarme.SelectedValue as CLocalTypeAlarme;
            m_createur.FormuleCondition = m_txtFormuleCondition.Formule;
            m_editeurActionConversion.ExpressionGraphique.RefreshFormuleFinale();
            m_createur.FormuleActions = m_editeurActionConversion.ExpressionGraphique;
            m_createur.Libelle = m_txtLibelle.Text;
            m_createur.Code = m_txtCode.Text;
            return result;
        }

        private void m_btnOk_Click(object sender, EventArgs e)
        {
            CResultAErreur result = MajChamps();
            if (result)
                result = m_createur.VerifieDonnees();
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void m_cmbTypeAlarme_SelectedValueChanged(object sender, EventArgs e)
        {
            m_createur.TypeAlarme = (CLocalTypeAlarme)m_cmbTypeAlarme.SelectedValue;
        }

        private void CFormEditCreateurAlarme_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
            InitChamps();
        }
    }
}
