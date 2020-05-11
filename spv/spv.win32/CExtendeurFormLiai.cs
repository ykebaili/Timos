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
	public partial class CExtendeurFormLiai : CExtendeurFormEditionStandardTabPage
	{
        private CSpvLiai m_spvLiai=null;

        public CExtendeurFormLiai()
		{
			InitializeComponent();
            Title = I.T("Supervision|9");
		}

		public override Type TypeObjetEtendu
		{
			get
			{
                return typeof(CLienReseau);
			}
		}

        protected CLienReseau LeLienReseau
		{
			get
			{
                return ObjetEdite as CLienReseau;
			}
		}

        

		public override sc2i.common.CResultAErreur MyInitChamps()
		{
            if (ObjetEdite is CLienReseau)
			{
                m_spvLiai = CSpvLiai.GetSpvLiaiFromLienReseau(ObjetEdite as CLienReseau) as CSpvLiai;
			}		
			CResultAErreur result = base.MyInitChamps();
			if (!result)
				return result;

            if (result && m_spvLiai != null)
			{				            
                m_PanelTypeAccessAlarm.InitFromListeObjets(
                m_spvLiai.SpvTypeAccessAlarm,
                typeof(CSpvTypeAccesAlarme),
                typeof(CFormEditionTypeAccesAlarmeBoucle),
                m_spvLiai,
                "SpvLiai");

                m_CablageAccesAlarm.InitFromListeObjets(
                m_spvLiai.AlarmesCables,
                typeof(CSpvLienAccesAlarme),
                typeof(CFormEditionCablageAccesAlarmeBoucle),
                m_spvLiai,
                "SpvLiai");
			}

            if (m_spvLiai == null)
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
                    "SpvLiai");

                m_CablageAccesAlarm.InitFromListeObjets(
                    listeVideAccesc,
                    typeof(CSpvLienAccesAlarme),
                    typeof(CFormEditionCablageAccesAlarmeBoucle),
                    null,
                    "SpvLiai");
            }
           	return result;
        }//MyInitChamps()

        public override sc2i.common.CResultAErreur MyMajChamps()
        {
            CResultAErreur result = base.MyMajChamps();
           if (!result)
                return result;

            if (LeLienReseau != null && m_spvLiai == null && m_extModeEdition.ModeEdition)
			{
                m_spvLiai = CSpvLiai.GetSpvLiaiFromLienReseauAvecCreation(LeLienReseau);
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
