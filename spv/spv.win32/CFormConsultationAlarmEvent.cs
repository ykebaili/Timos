using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.data;
using sc2i.common;
using sc2i.win32.common;
using sc2i.win32.navigation;
using sc2i.win32.data;
using sc2i.win32.data.navigation;

using timos.data;

using spv.data.ConsultationAlarmes;
using spv.data;
using timos.acteurs;

namespace spv.win32
{
    public partial class CFormConsultationAlarmEvent : CFormMaxiSansMenu, IFormNavigable
    {
        private CInfoAlarmeAffichee m_AlarmInfo;
        private CContexteDonnee m_ctxDonnee;

        public CFormConsultationAlarmEvent()
        {
            InitializeComponent();
        }

        public CFormConsultationAlarmEvent(CInfoAlarmeAffichee alarmInfo, CContexteDonnee ctx)
        {
            InitializeComponent();

            m_AlarmInfo = alarmInfo;
            m_ctxDonnee = ctx;
            Init();
        }

        private void Init()
        {
            CWin32Traducteur.Translate(this);
         
            /*m_btnAcquit.Text = I.T("Acquit|60035");
            m_btnRetombe.Text = I.T("Close|60036");
            m_btnMask.Text = I.T("Mask|60037");
            m_btnDetailsAlarm.Text = I.T("Details|60030");
            m_btnDetailsElement.Text = I.T("Details|60030");
            groupBox3.Text = I.T("Event|60031");
            label6.Text = I.T("Duration|60034");
            label10.Text = I.T("End|60033");
            label11.Text = I.T("Start|60032");
            groupBox1.Text = I.T("Alarm|60046");
            label5.Text = I.T("Event type|60025");
            groupBox2.Text = I.T("Threshold|60027");
            label4.Text = I.T("Value|60029");
            label3.Text = I.T("Name|60028");
            label2.Text = I.T("Severity|60026");
            label9.Text = I.T("Alarm name|60024");
            groupBox4.Text = I.T("Defective managed element|60039");
            label1.Text = I.T("Type|60040");
            label7.Text = I.T("Alarm wiring|60041");
            label8.Text = I.T("Name|60028");
            label12.Text = I.T("Type|60040");
            groupBox5.Text = I.T("Are concerned|60042");
            label14.Text = I.T("Sites|60045");
            label13.Text = I.T("Customers|60044");
            label15.Text = I.T("Services|60043");*/
            
            
            Text = I.T("Event|60031");

            if(m_AlarmInfo.Duree != null)
                m_txtAlarmDuration.Text = m_AlarmInfo.Duree.ToString();
            else
                m_txtAlarmDuration.Text = "";
            
            if(m_AlarmInfo.DateFin!=null)
                m_txtAlarmStop.Text = m_AlarmInfo.DateFin.ToString();
            else
                m_txtAlarmStop.Text = "";

            m_txtAlarmStart.Text = m_AlarmInfo.AlarmDate.ToString();

            if (m_AlarmInfo.AlarmeGeree != null && m_AlarmInfo.AlarmeGeree.AlarmEvent != null)
                m_txtEventType.Text = m_AlarmInfo.AlarmeGeree.AlarmEvent.Libelle;
            else
                m_txtEventType.Text = "";

            m_txtSeuilValue.Text = (m_AlarmInfo.SeuilValeur==null) ? "" : m_AlarmInfo.SeuilValeur.ToString();
            m_txtSeuilNom.Text = m_AlarmInfo.SeuilName;
            
            if (m_AlarmInfo.Severity != null)
                m_txtGravite.Text = m_AlarmInfo.Severity.Libelle;
            else
                m_txtGravite.Text = "";

            m_txtLibelle.Text = m_AlarmInfo.AlarmeGeree.Name;
            m_txtCablageAlarm.Text = m_AlarmInfo.EDC;
            m_txtElementName.Text = m_AlarmInfo.ElementGereName;
            m_txtElementType.Text = m_AlarmInfo.ElementGereType;
            
            if(m_AlarmInfo.InfoSite!=null)
                m_lstSites.Items.Add(m_AlarmInfo.InfoSite);
           
            foreach ( CInfoClientAlarmeAffichee client in m_AlarmInfo.ClientsConcernes)
                m_lstClients.Items.Add(client);

            foreach ( CInfoServiceAlarmeAffichee service in m_AlarmInfo.ServicesConcernes)
                m_lstServices.Items.Add(service);

            if (!m_AlarmInfo.WaiteToBeAcknowledged())
                m_btnAcquit.Enabled = false;
            else
                m_btnAcquit.Enabled = true;

        }

        private void m_btnDetailsElement_Click(object sender, EventArgs e)
        {
                
        }

        // Détail de l'alarme gérée correspondante
        private void m_btnDetailsAlarm_Click(object sender, EventArgs e)
        {
        }

        private void m_btnAcquit_Click(object sender, EventArgs e)
        {
            CSpvAlarmeDonnee spvAlarmData = null;

            if (m_AlarmInfo != null)
                spvAlarmData = m_AlarmInfo.GetSpvAlarme(m_ctxDonnee);

            if (spvAlarmData == null)
                return;


            CResultAErreur result = spvAlarmData.AcquitterNow();
            if (!result)
                CFormAlerte.Afficher(result);

            m_AlarmInfo.EstAcquittee = spvAlarmData.Acquittee;

            if (!m_AlarmInfo.WaiteToBeAcknowledged())
                m_btnAcquit.Enabled = false;
            else
                m_btnAcquit.Enabled = true;

        }

        private void m_btnRetombe_Click(object sender, EventArgs e)
        {
            // Pour faire retomber l'alarme, on crée 
            //CSpvAlarmeDonnee.Retomber(m_AlarmInfo.IdSpvEvtAlarme, m_ctxDonnee);
            CResultAErreur result = 
                CSpvAlarmeDonnee.Retomber(m_AlarmInfo.IdSpvAlarmeData, m_ctxDonnee);
            if (!result)
                CFormAlerte.Afficher(result);
            //CSpvAlarmeEvenement.Retomber(m_AlarmInfo.IdSpvAlarme, m_ctxDonnee);
        }

 
        private void m_btnMask_Click(object sender, EventArgs e)
        {
            CSpvAlarmeDonnee spvAlarmData = null;

            if (m_AlarmInfo != null)
                spvAlarmData = m_AlarmInfo.GetSpvAlarme(m_ctxDonnee);

            if (spvAlarmData == null)
                return;
            int id = spvAlarmData.SpvLienAccesAlarme.Id;//test
         //   CFormEditionMasquage editionMask = new CFormEditionMasquage(spvAlarm.SpvAccesAccesc, false);
         //   editionMask.ShowDialog();

            //CFormEditionCablageAccesAlarmeBoucle form = new CFormEditionCablageAccesAlarmeBoucle(spvAlarm.SpvAccesAccesc);
            CFormEditionAccesAlarmeEquipement form = new CFormEditionAccesAlarmeEquipement(spvAlarmData.SpvLienAccesAlarme);
            Navigateur.AffichePage(form);

          /*  CReferenceTypeForm refTypeForm = CFormFinder.GetRefFormToEdit(objTimos.GetType());
            if (refTypeForm != null)
            {
                IFormNavigable frm = refTypeForm.GetForm(objTimos) as IFormNavigable;
                Navigateur.AffichePage(frm);
            }*/

        }

        /*
         * private void m_btnMask_Click(object sender, EventArgs e)
        {
            CSpvAlarmeEvenement spvAlarm = null;

            if (m_AlarmInfo != null)
                spvAlarm = m_AlarmInfo.GetSpvAlarm(m_ctxDonnee);

            if (spvAlarm == null)
                return;
            int id = spvAlarm.SpvAccesAccesc.Id;//test
         //   CFormEditionMasquage editionMask = new CFormEditionMasquage(spvAlarm.SpvAccesAccesc, false);
         //   editionMask.ShowDialog();

            //CFormEditionCablageAccesAlarmeBoucle form = new CFormEditionCablageAccesAlarmeBoucle(spvAlarm.SpvAccesAccesc);
            CFormEditionAccesAlarmeEquipement form = new CFormEditionAccesAlarmeEquipement(spvAlarm.SpvAccesAccesc);
            Navigateur.AffichePage(form);

        }*/

        private void OnLstClientsDoubleClick(object sender, EventArgs e)
        {
            if (m_lstClients.SelectedIndices.Count > 0)
            {
                int index = m_lstClients.SelectedIndices[0];

                CSpvClient clientSpv = ((CInfoClientAlarmeAffichee)m_lstClients.Items[index]).GetSpvClient(m_ctxDonnee);
                if (clientSpv != null)
                {
                    CDonneesActeurClient customer = clientSpv.ObjetTimosAssocie;
                    //CDonneesActeurClient customer = clientSpv.ClientSmt;

                    if (customer != null && customer.Acteur != null)
                    {
                        CReferenceTypeForm refTypeForm = CFormFinder.GetRefFormToEdit(customer.Acteur.GetType());
                        if (refTypeForm != null)
                        {
                            IFormNavigable frm = refTypeForm.GetForm(customer.Acteur) as IFormNavigable;
                            Navigateur.AffichePage(frm);
                        }
                    }
                }
            }
        }

        private void OnLstSitesDoubleClick(object sender, EventArgs e)
        {
            if (m_lstSites.SelectedIndices.Count > 0)
            {
                int index = m_lstSites.SelectedIndices[0];

                CSpvSite siteSpv = ((CInfoSiteAlarmeAffichee)m_lstSites.Items[index]).GetSpvSiteByName(m_ctxDonnee);
                
                if (siteSpv != null)
                {
                    CSite site = siteSpv.ObjetTimosAssocie;

                    if (site != null)
                    {
                        CReferenceTypeForm refTypeForm = CFormFinder.GetRefFormToEdit(site.GetType());
                        if (refTypeForm != null)
                        {
                            IFormNavigable frm = refTypeForm.GetForm(site) as IFormNavigable;
                            Navigateur.AffichePage(frm);
                        }
                    }
                }
            }
        }

        private void OnLstServicesDoubleClick(object sender, EventArgs e)
        {
            if (m_lstServices.SelectedIndices.Count > 0)
            {
                int index = m_lstServices.SelectedIndices[0];

                CSpvSchemaReseau serviceSpv = ((CInfoServiceAlarmeAffichee)m_lstServices.Items[index]).GetSpvServiceByName(m_ctxDonnee);
                
                if (serviceSpv != null)
                {
                    CSchemaReseau schema = serviceSpv.ObjetTimosAssocie;

                    if (schema != null)
                    {
                        CReferenceTypeForm refTypeForm = CFormFinder.GetRefFormToEdit(schema.GetType());
                        if (refTypeForm != null)
                        {
                            IFormNavigable frm = refTypeForm.GetForm(schema) as IFormNavigable;
                            Navigateur.AffichePage(frm);
                        }
                    }
                }
            }
        }


        #region IFormNavigable Membres

        public CResultAErreur Actualiser()
        {
            Refresh();
            return CResultAErreur.True;
        }

        public CContexteFormNavigable GetContexte()
        {
            CContexteFormNavigable ctx = new CContexteFormNavigable(GetType());
            ctx["ALARMINFO"] = m_AlarmInfo;
            return ctx;

        }

        public CResultAErreur InitFromContexte(CContexteFormNavigable contexte)
        {
            CResultAErreur result = CResultAErreur.True;
            m_AlarmInfo = contexte["ALARMINFO"] as CInfoAlarmeAffichee;
            if (m_AlarmInfo == null)
            {
                result.EmpileErreur("No alarm info for this page");
            }
            m_ctxDonnee = CSc2iWin32DataClient.ContexteCourant;
            Init();
            return result;
        }

        public bool QueryClose()
        {
            return true;
        }

        #endregion

        private void CFormConsultationAlarmEvent_Load(object sender, EventArgs e)
        {
            Navigateur.TitreFenetreEnCours = I.T("Event|60031");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CFormConsultationAlarmeGeree form =
                new CFormConsultationAlarmeGeree(m_AlarmInfo, m_ctxDonnee);
            Navigateur.AffichePage(form);
        }

        private void m_lnkElementGere_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            IObjetSPVAvecObjetTimos obj = m_AlarmInfo.GetElementGere(m_ctxDonnee) as IObjetSPVAvecObjetTimos;
            if (obj != null)
            {
                CObjetDonneeAIdNumeriqueAuto objTimos = obj.ObjetTimosSansGenerique as CObjetDonneeAIdNumeriqueAuto;
                if (objTimos != null)
                {
                    CReferenceTypeForm refTypeForm = CFormFinder.GetRefFormToEdit(objTimos.GetType());
                    if (refTypeForm != null)
                    {
                        IFormNavigable frm = refTypeForm.GetForm(objTimos) as IFormNavigable;
                        Navigateur.AffichePage(frm);
                    }
                }
            }
        }
    }
}
