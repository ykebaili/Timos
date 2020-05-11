using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using futurocom.snmp.entitesnmp;
using sc2i.expression;
using sc2i.common;

namespace futurocom.win32.snmp.entitesnmp
{
    public partial class CFormEditChampEntiteFromQuery : Form
    {
        private CChampEntiteFromQuery m_champEdite = null;
        private CTypeEntiteSnmpPourSupervision m_typeEntite = null;

        //-----------------------------------------
        public CFormEditChampEntiteFromQuery()
        {
            InitializeComponent();
        }

        //--------------------------------------
        public static bool EditeChamp(CChampEntiteFromQuery champ,
            CTypeEntiteSnmpPourSupervision typeEntite)
        {
            CFormEditChampEntiteFromQuery form = new CFormEditChampEntiteFromQuery();
            form.m_champEdite = champ;
            form.m_typeEntite = CCloner2iSerializable.Clone(typeEntite) as CTypeEntiteSnmpPourSupervision;
            bool bResult = false;
            if (form.ShowDialog() == DialogResult.OK)
            {
                bResult = true;
                CCloner2iSerializable.CopieTo(form.m_typeEntite, typeEntite);
            }
            form.Dispose();
            return bResult;
        }

        private void cTextBoxZoomFormule1_Load(object sender, EventArgs e)
        {

        }

        private void cTextBoxZoomFormule2_Load(object sender, EventArgs e)
        {

        }

        private void CFormEditChampEntiteSnmpToSnmp_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
            InitChamps();
        }

        //--------------------------------------
        private void InitChamps()
        {
            m_txtNomChamp.Text = m_champEdite.NomChamp;
            m_txtDescription.Text = m_champEdite.Description;
            m_lblDataType.Text = new CTypeChampBasique(m_champEdite.TypeChamp).Libelle;
            m_lblAcces.Text = m_champEdite.IsReadOnly ? I.T("Read only|20101") : I.T("Read/write|20102");

            CFournisseurGeneriqueProprietesDynamiques fournisseur = new CFournisseurGeneriqueProprietesDynamiques();
            CEntiteSnmpPourSupervision entiteTest = m_typeEntite.GetEntiteDeTest();

            m_txtFormuleIndex.Init ( fournisseur,
                new CObjetPourSousProprietes(entiteTest));
            m_txtFormuleIndex.Formule = m_champEdite.FormuleIndex;
        }

        //--------------------------------------
        private CResultAErreur MajChamps()
        {
            m_champEdite.Description = m_txtDescription.Text;
            m_champEdite.FormuleIndex = m_txtFormuleIndex.Formule;
            return m_champEdite.VerifieDonnees();
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



            
    }
}
