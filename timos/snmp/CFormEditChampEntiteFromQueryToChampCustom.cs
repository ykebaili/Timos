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
using timos.data.snmp;
using sc2i.data;
using sc2i.data.dynamic;

namespace timos.snmp
{
    public partial class CFormEditChampEntiteFromQueryToChampCustom : Form
    {
        private CContexteDonnee m_contexteDonnee = null;
        private CChampEntiteFromQueryToChampCustom m_champToCustom = null;
        private CChampEntiteFromQuery m_champEdite = null;
        private CTypeEntiteSnmpPourSupervision m_typeEntite = null;

        //-----------------------------------------
        public CFormEditChampEntiteFromQueryToChampCustom()
        {
            InitializeComponent();
        }

        //--------------------------------------
        public static bool EditeChamp(
            CChampEntiteFromQueryToChampCustom champToCustom,
            CTypeEntiteSnmpPourSupervision typeEntite,
            CContexteDonnee contexteDonnee)
        {
            CFormEditChampEntiteFromQueryToChampCustom form = new CFormEditChampEntiteFromQueryToChampCustom();
            form.m_contexteDonnee = contexteDonnee;
            form.m_champToCustom = CCloner2iSerializable.Clone(champToCustom) as CChampEntiteFromQueryToChampCustom;
            form.m_champEdite = form.m_champToCustom.Champ;
            form.m_typeEntite = typeEntite;
            bool bResult = false;
            if (form.ShowDialog() == DialogResult.OK)
            {
                bResult = true;
                CCloner2iSerializable.CopieTo(form.m_champToCustom, champToCustom);
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
            m_chkNoUpdate.Checked = m_champEdite.NoUpdateFromSnmp;
            m_chkNoWriteSNMP.Checked = m_champEdite.IsReadOnly;
            m_lblAcces.Text = m_champEdite.IsReadOnly ? I.T("Read only|20296") : I.T("Read/write|20297");

            CFournisseurGeneriqueProprietesDynamiques fournisseur = new CFournisseurGeneriqueProprietesDynamiques();
            CEntiteSnmpPourSupervision entiteTest = m_typeEntite.GetEntiteDeTest();

            m_txtFormuleIndex.Init ( fournisseur,
                new CObjetPourSousProprietes(entiteTest));
            m_txtFormuleIndex.Formule = m_champEdite.FormuleIndex;

            TypeDonnee typeChampMap = TypeDonnee.tString;
            switch (m_champEdite.TypeChamp)
            {
                case ETypeChampBasique.Bool:
                    typeChampMap = TypeDonnee.tBool;
                    break;
                case ETypeChampBasique.Date:
                    typeChampMap = TypeDonnee.tDate;
                    break;
                case ETypeChampBasique.Decimal:
                    typeChampMap = TypeDonnee.tDouble;
                    break;
                case ETypeChampBasique.Int:
                    typeChampMap = TypeDonnee.tEntier;
                    break;
                case ETypeChampBasique.String:
                    typeChampMap = TypeDonnee.tString;
                    break;
                default:
                    break;
            }
            m_txtSelectChampCustom.InitAvecFiltreDeBase ( typeof(CChampCustom),
                "Nom",
                CFiltreData.GetAndFiltre ( CChampCustom.GetFiltreChampsForRole(CEntiteSnmp.c_roleChampCustom),
                new CFiltreData(CChampCustom.c_champType+"=@1",
                    (int)typeChampMap)),
                false);
            CChampCustom champ = new CChampCustom ( m_contexteDonnee );

            if (m_champToCustom.IdChampCustom != null && champ.ReadIfExists(m_champToCustom.IdChampCustom.Value))
                m_txtSelectChampCustom.ElementSelectionne = champ;
            else
                m_txtSelectChampCustom.ElementSelectionne = null;

        }

        //--------------------------------------
        private CResultAErreur MajChamps()
        {
            m_champEdite.Description = m_txtDescription.Text;
            m_champEdite.FormuleIndex = m_txtFormuleIndex.Formule;
            CChampCustom champ = m_txtSelectChampCustom.ElementSelectionne as CChampCustom;
            if (champ != null)
                m_champToCustom.IdChampCustom = champ.Id;
            else
                m_champToCustom.IdChampCustom = null;
            m_champEdite.NoUpdateFromSnmp = m_chkNoUpdate.Checked;
            m_champEdite.IsReadOnly = m_chkNoWriteSNMP.Checked;
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_lnkCreateField_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_txtSelectChampCustom.ElementSelectionne == null)
            {
                m_champToCustom.IdChampCustom = null;
                if (m_champToCustom.AssociationRapide(m_contexteDonnee, true))
                {
                    CChampCustom champ = new CChampCustom(m_contexteDonnee);
                    if (m_champToCustom.IdChampCustom != null && champ.ReadIfExists(m_champToCustom.IdChampCustom.Value, false))
                        m_txtSelectChampCustom.ElementSelectionne = champ;
                }
            }
        }

        private void m_txtFormuleIndex_Load(object sender, EventArgs e)
        {

        }

        private void m_txtSelectChampCustom_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }



            
    }
}
