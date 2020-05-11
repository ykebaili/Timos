using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.win32.data.navigation;
using spv.data;
using timos.data;
using sc2i.common;
using sc2i.win32.common;
using sc2i.data;
using sc2i.expression;
using sc2i.data.dynamic;

namespace spv.win32
{
    public partial class CExtendeurFormChampCustom : CExtendeurFormEditionStandardTabPage
    {
        private CSpvChampCustomSNMP m_champSNMP = null;

        public CExtendeurFormChampCustom()
        {
            InitializeComponent();
            Title = I.T("SNMP|20008");
        }

        public override Type TypeObjetEtendu
        {
            get
            {
                return typeof(CChampCustom);
            }
        }

        protected CChampCustom ChampCustom
        {
            get
            {
                return ObjetEdite as CChampCustom;
            }
        }



        //--------------------------------------------------------------
        public override sc2i.common.CResultAErreur MyInitChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            result = base.MyInitChamps();
            if (!result)
                return result;
            m_txtFormuleIndex.Init(new CFournisseurGeneriqueProprietesDynamiques(), typeof(CEquipementLogique));
            if (ChampCustom.CodeRole != CEquipementLogique.c_roleChampCustom)
            {
                m_panelSNMP.Visible = false;
                m_champSNMP = null;
            }
            else
            {
                m_panelSNMP.Visible = true;
                if (m_extModeEdition.ModeEdition)
                    m_champSNMP = CSpvChampCustomSNMP.GetObjetSpvFromObjetTimosAvecCreation(ChampCustom);
                else
                    m_champSNMP = CSpvChampCustomSNMP.GetObjetSpvFromObjetTimos(ChampCustom);
                if (m_champSNMP == null)
                    m_panelSNMP.Visible = false;
                else
                {
                    m_txtOID.Text = m_champSNMP.OID;
                    m_txtFormuleIndex.Formule = m_champSNMP.FormuleIndex;
                }
            }

            return result;
        }//MyInitChamps()

        //--------------------------------------------------------------
        public override sc2i.common.CResultAErreur MyMajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_champSNMP != null)
            {
                m_champSNMP.OID = m_txtOID.Text;
                if (m_txtOID.Text.Trim() == "")
                    m_champSNMP.FormuleIndex = null;
                else
                {
                    C2iExpression formule = m_txtFormuleIndex.Formule;
                    if (formule == null)
                    {
                        result = m_txtFormuleIndex.ResultAnalyse;
                        if (!result)
                            result.EmpileErreur(I.T("Error in SNMP index formula|20012"));
                    }
                    else
                        m_champSNMP.FormuleIndex = formule;
                }
            }
            return result;
            
        }

        //--------------------------------------------------------------
        private void m_chkSuperviser_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void CExtendeurFormChampCustom_OnChangementSurObjet(string strNomChamp)
        {
            if (strNomChamp == CChampCustom.c_champCodeRole)
            {
                MyMajChamps();
                MyInitChamps();
            }
        }

        private void m_btnSelectOID_Click(object sender, EventArgs e)
        {
            CSpvMibVariable variable = CFormSelectOID.SelectVariable();
            if (variable != null)
                m_txtOID.Text = variable.OidObjet;
        }

        private void m_txtOID_TextChanged(object sender, EventArgs e)
        {
            //Mise à jour du libellé de la variable
            CSpvMibVariable variable = new CSpvMibVariable(ChampCustom.ContexteDonnee);
            if (variable.ReadIfExists(
                new CFiltreData(CSpvMibVariable.c_champMIBOBJ_OID + "=@1",
                m_txtOID.Text)))
            {
                m_lblVariable.Text = variable.NomOfficielComplet;
                m_tooltip.SetToolTip(m_lblVariable, m_lblVariable.Text);
            }
            else
            {
                m_lblVariable.Text = "?";
                m_tooltip.SetToolTip(m_lblVariable, "");
            }
        }
    }
}

