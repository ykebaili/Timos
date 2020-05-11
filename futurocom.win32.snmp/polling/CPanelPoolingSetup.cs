using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.common.DonneeCumulee;
using futurocom.snmp.entitesnmp;
using futurocom.snmp.polling;
using sc2i.win32.common.customizableList;
using futurocom.win32.snmp.polling;
using sc2i.common;
using sc2i.common.unites.standard;
using sc2i.common.unites;

namespace futurocom.win32.snmp
{
    public partial class CPanelPoolingSetup : UserControl
    {
        private IEnumerable<ITypeDonneeCumulee> m_listeTypesDonneesCumulees = new List<ITypeDonneeCumulee>();
        private CAgentSnmpPourSupervision m_agent = null;
        private CSnmpPollingSetup m_setup = null;

        private CControleEditeRemplissageChampDonneeCumulee m_controleItem = new CControleEditeRemplissageChampDonneeCumulee();

        public CPanelPoolingSetup()
        {
            InitializeComponent();
            m_wndListeChamps.ItemControl = m_controleItem;
            m_controleItem.LockEdition = false;
            m_txtFrequence.DefaultFormat = CClasseUniteTemps.c_idMIN;
        }

        //--------------------------------------------------
        public void Init(CSnmpPollingSetup pollingSetup,
            CAgentSnmpPourSupervision agent,
            IEnumerable<ITypeDonneeCumulee> lstTypesDonneesCumulees)
        {
            m_agent = agent;
            m_listeTypesDonneesCumulees = lstTypesDonneesCumulees;
            m_setup = pollingSetup;
            m_txtLibelle.Text = pollingSetup.Libelle;
            m_txtFrequence.UnitValue = new CValeurUnite(m_setup.FrequenceMinutes, CClasseUniteTemps.c_idMIN);
            m_cmbTypesDonnees.ListDonnees = lstTypesDonneesCumulees;
            m_cmbTypesDonnees.ProprieteAffichee = "Libelle";
            ITypeDonneeCumulee tp = lstTypesDonneesCumulees.FirstOrDefault(t => t.Id == pollingSetup.IdTypeDonneeCumulee);
            m_cmbTypesDonnees.SelectedValue = tp;

            FillListeChamps();
        }

        //--------------------------------------------------
        private void FillListeChamps()
        {
            List<CCustomizableListItem> lstItems = new List<CCustomizableListItem>();
            ITypeDonneeCumulee type = m_cmbTypesDonnees.SelectedValue as ITypeDonneeCumulee;
            if ( type != null )
            {
                m_controleItem.InitControle ( m_agent, type );
                IEnumerable<CChampDonneeCumulee> champs = type.GetChampsRenseignes();
                foreach ( CChampDonneeCumulee champ in champs)
                {
                    CParametreFillChampDonneeCumulee parametre = m_setup.ParametresFillChamps.FirstOrDefault (
                        c=>c.Champ.Equals(champ));
                    if ( parametre == null )
                    {
                        parametre = new CParametreFillChampDonneeCumulee();
                        parametre.FormuleSource = null;
                        parametre.Champ = champ;
                    }
                    CCustomizableListItem item = new CCustomizableListItem();
                    item.Tag = parametre;
                    lstItems.Add ( item );
                }
            }
            
            m_wndListeChamps.Items = lstItems.ToArray();
        }

        //--------------------------------------------------
        private void m_cmbTypesDonnees_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FillListeChamps();
        }

        //--------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_txtLibelle.Text.Length == 0)
            {
                result.EmpileErreur(I.T("Enter a label for this polling setup|20127"));
                return result;
            }
            ITypeDonneeCumulee tp = m_cmbTypesDonnees.SelectedValue as ITypeDonneeCumulee;
            if (tp == null)
            {
                result.EmpileErreur(I.T("Select a data type|20128"));
                return result;
            }

            result = m_wndListeChamps.MajChamps();
            if (!result)
                return result;
            CListeParametresFillChampDonneeCumulee lstParametres = new CListeParametresFillChampDonneeCumulee();
            foreach (CCustomizableListItem item in m_wndListeChamps.Items)
            {
                CParametreFillChampDonneeCumulee parametre = item.Tag as CParametreFillChampDonneeCumulee;
                if (parametre.FormuleSource != null)
                    lstParametres.Add(parametre);
            }
            m_setup.Libelle = m_txtLibelle.Text;
            m_setup.IdTypeDonneeCumulee = tp.Id;
            m_setup.ParametresFillChamps = lstParametres;
            if (m_txtFrequence.UnitValue == null)
                m_setup.FrequenceMinutes = 0;
            else
                m_setup.FrequenceMinutes = m_txtFrequence.UnitValue.ConvertTo(CClasseUniteTemps.c_idMIN).Valeur;
            return result;
        }
    }
}
