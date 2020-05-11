using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.win32.common;
using sc2i.data;
using sc2i.win32.data.navigation;
using spv.data;
using timos.data;
using sc2i.common;

namespace spv.win32
{
	public partial class CExtendeurFormSite : CExtendeurFormEditionStandardTabPage
	{
        private CSpvSite m_spvSite=null;

		public CExtendeurFormSite()
		{
			InitializeComponent();
            Title = I.T("Supervision|9");
		}

		public override Type TypeObjetEtendu
		{
			get
			{
				return typeof(CSite);
			}
		}

		protected CSite LeSite
		{
			get
			{
				return ObjetEdite as CSite;
			}
		}

        

		public override sc2i.common.CResultAErreur MyInitChamps()
		{
			if (ObjetEdite is CSite)
			{
				m_spvSite = CSpvSite.GetObjetSpvFromObjetTimos(ObjetEdite as CSite) as CSpvSite;
			}		
			CResultAErreur result = base.MyInitChamps();
			if (!result)
				return result;

			if (result && m_spvSite != null)
			{
				m_txtBoxCommunity.Text = m_spvSite.SNMP_Community;
				m_txtBoxDomaineIp.Text = m_spvSite.DomaineIP;
				m_txtBoxMediation.Text = m_spvSite.EmName;
                
                m_PanelTypeAccessAlarm.InitFromListeObjets(
                m_spvSite.SpvTypeAccessAlarm,
                typeof(CSpvTypeAccesAlarme),
                typeof(CFormEditionTypeAccesAlarmeBoucle),
                m_spvSite,
                "SpvSite");

                m_CablageAccesAlarm.InitFromListeObjets(
                m_spvSite.AlarmesCables,
                typeof(CSpvLienAccesAlarme),
                typeof(CFormEditionCablageAccesAlarmeBoucle),
                m_spvSite,
                "SpvSite");
			}
			else
			{
				m_txtBoxMediation.Text = "";
				m_txtBoxDomaineIp.Text = "";
				m_txtBoxCommunity.Text = "";
			}

            if (m_spvSite == null)
            {   
                CFiltreDataImpossible filtreImpossible = new CFiltreDataImpossible();
                CListeObjetsDonnees listeVideAlarme = new CListeObjetsDonnees(ObjetEdite.ContexteDonnee,typeof(CSpvTypeAccesAlarme));
                CListeObjetsDonnees listeVideAccesc = new CListeObjetsDonnees(ObjetEdite.ContexteDonnee, typeof(CSpvLienAccesAlarme));
                listeVideAlarme.Filtre = filtreImpossible;
                listeVideAccesc.Filtre = filtreImpossible;

                m_PanelTypeAccessAlarm.InitFromListeObjets(
                    listeVideAlarme,
                    typeof(CSpvTypeAccesAlarme),
                    typeof(CFormEditionTypeAccesAlarmeBoucle),
                    null,
                    "SpvSite");

                m_CablageAccesAlarm.InitFromListeObjets(
                    listeVideAccesc,
                    typeof(CSpvLienAccesAlarme),
                    typeof(CFormEditionCablageAccesAlarmeBoucle),
                    null,
                    "SpvSite");
            }
           	return result;
        }//MyInitChamps()

        public override sc2i.common.CResultAErreur MyMajChamps()
        {
            CResultAErreur result = base.MyMajChamps();
           if (!result)
                return result;

			if (LeSite != null && m_spvSite == null && m_extModeEdition.ModeEdition)
			{
				m_spvSite = CSpvSite.GetObjetSpvFromObjetTimosAvecCreation(LeSite);
			}

            if (m_spvSite != null)
            {
				m_spvSite.DomaineIP = m_txtBoxDomaineIp.Text;
                m_spvSite.SNMP_Community = m_txtBoxCommunity.Text;
                m_spvSite.EmName  = m_txtBoxMediation.Text;
            }

            return result;
        }

        private void m_buttonStartAlarm_Click(object sender, EventArgs e)
        {
            CResultAErreur result = CResultAErreur.True;
            CSpvLienAccesAlarme spvLien = (CSpvLienAccesAlarme)m_CablageAccesAlarm.ElementSelectionne;
            if (spvLien != null)
            {
                result = spvLien.ProvoquerAlarme();
                if (!result)
                    CFormAlerte.Afficher(result);
            }
        }

 	}
}
