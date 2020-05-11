using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.win32.data.navigation;
using sc2i.data;
using spv.data;
using timos.data;
using sc2i.common;

namespace spv.win32
{
    public partial class CExtenderFormTypeqAlarms : CExtendeurFormEditionStandardTabPage
    {
        private CSpvTypeq m_spvTypeq = null;

        public CExtenderFormTypeqAlarms()
        {
            InitializeComponent();
            Title = I.T("Alarms|50001");
        }

        public override Type TypeObjetEtendu
        {
            get
            {
                return typeof(CTypeEquipement);
            }
        }

        protected CTypeEquipement TypeEquipement
        {
            get
            {
                return ObjetEdite as CTypeEquipement;
            }
        }


        public override sc2i.common.CResultAErreur MyInitChamps()
        {
            if (ObjetEdite is CTypeEquipement)
            {
                m_spvTypeq = CSpvTypeq.GetSpvTypeqFromTypeEquipement(ObjetEdite as CTypeEquipement) as CSpvTypeq;
            }

            CResultAErreur result = base.MyInitChamps();
            if (!result)
                return result;

            
            if (result && m_spvTypeq != null)
            {
                m_PanelTypeAccessAlarm.InitFromListeObjets(
                m_spvTypeq.TypesAccesAlarme,
                typeof(CSpvTypeAccesAlarme),
                typeof(CFormEditionTypeAccesAlarme),
                m_spvTypeq,
                "SpvTypeq");
            }

           
            if (m_spvTypeq == null)
            {
               
                CFiltreDataImpossible filtreImpossible=new CFiltreDataImpossible();
                CListeObjetsDonnees listeVide = new CListeObjetsDonnees(ObjetEdite.ContexteDonnee,typeof(CSpvTypeAccesAlarme));
                listeVide.Filtre = filtreImpossible;

                m_PanelTypeAccessAlarm.InitFromListeObjets(
                    listeVide,
                    typeof(CSpvTypeAccesAlarme),
                    typeof(CFormEditionTypeAccesAlarme),
                    null,
                    "SpvTypeq");
            }

            return result;
        }//MyInitChamps()


        public override sc2i.common.CResultAErreur MyMajChamps()
        {
            CResultAErreur result = base.MyMajChamps();
            if (!result)
                return result;

            /*
            if (TypeEquipement != null && m_spvTypeq == null && m_extModeEdition.ModeEdition)
            {
                m_spvTypeq = CSpvTypeq.GetSpvTypeqFromTypeEquipementAvecCreation(TypeEquipement);
            }
            */

            return result;
        }
    }
}

