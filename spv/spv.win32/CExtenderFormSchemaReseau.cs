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
using spv.win32.VueAnimee;
using sc2i.win32.navigation;
using spv.data.VueAnimee;

namespace spv.win32
{
    public partial class CExtendeurFormSchemaReseau : CExtendeurFormEditionStandardTabPage
    {
        //private CSpvService m_spvService = null;
        //private CSpvTypeService m_typeService = null;

        public CExtendeurFormSchemaReseau()
        {
            InitializeComponent();
            Title = I.T("Supervision|9");
        }

        public override Type TypeObjetEtendu
        {
            get
            {
                return typeof(CSchemaReseau);
            }
        }

        protected CSchemaReseau SchemaReseau
        {
            get
            {
                return ObjetEdite as CSchemaReseau;
            }
        }



        //--------------------------------------------------------------
        public override sc2i.common.CResultAErreur MyInitChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            m_panelService.Visible = false;
            if (ObjetEdite is CSchemaReseau)
            {/*
                m_typeService = CSpvTypeService.GetObjetSpvFromObjetTimos(SchemaReseau.TypeSchemaReseau);
                if (m_typeService != null)
                {
                    if (m_extModeEdition.ModeEdition)
                        m_spvService = CSpvService.GetObjetSpvFromObjetTimosAvecCreation(ObjetEdite as CSchemaReseau);
                    else
                        m_spvService = CSpvService.GetObjetSpvFromObjetTimos(SchemaReseau);
                    if (m_spvService != null)
                    {
                        m_panelService.Visible = true;
                */
                        result = InitChampsForService();
                        if (!result)
                            return result;
                //    }
                //}
            }
            result = base.MyInitChamps();
            if (!result)
                return result;

#if DEBUG
            m_btnTestArbre.Visible = true;
#endif


            return result;
        }//MyInitChamps()

        //--------------------------------------------------------------
        private CResultAErreur InitChampsForService()
        {
            CResultAErreur result = CResultAErreur.True;
            /*
            m_cmbClient.Init(typeof(CSpvClient), "CLIENT_NOM", null, true);
            m_cmbClient.ElementSelectionne = m_spvService.SpvClient;*/
           return result;
        }

        //--------------------------------------------------------------
        private CResultAErreur MajChampsForService()
        {
            CResultAErreur result = CResultAErreur.True;
            /*
            m_spvService.SpvClient = m_cmbClient.ElementSelectionne as CSpvClient;
            m_spvService.TypeService = CSpvTypeService.GetObjetSpvFromObjetTimos(SchemaReseau.TypeSchemaReseau);
            */
            return result;
        }


        //--------------------------------------------------------------
        public override sc2i.common.CResultAErreur MyMajChamps()
        {
            CResultAErreur result = base.MyMajChamps();
            if (!result)
                return result;
            //if (m_spvService != null)
            //    result = MajChampsForService();
            
            return result;
        }

        //--------------------------------------------------------------
        private void m_chkSuperviser_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void CExtendeurFormSchemaReseau_OnChangementSurObjet(string strNomChamp)
        {
            if ( m_extModeEdition.ModeEdition &&  strNomChamp == CTypeSchemaReseau.c_champId )
            {
                MajChamps();
                InitChamps();
            }
        }

        private void m_lnkSuperviser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            IFormNavigable formNavigable = FindForm() as IFormNavigable;
            if (formNavigable != null && formNavigable.Navigateur != null)
                CFormSupervisionSchema.Superviser(SchemaReseau, formNavigable.Navigateur);
            else
                CFormAlerte.Afficher(I.T("Function not available in this context|20020"));
        }

        private void m_lnkHistoriqueEvenements_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<CReferenceObjetDonnee> lst = CBasePourVueAnimee.GetTousLesConcernesSpv(SchemaReseau);
            Dictionary<int, bool> dicIdsSitesSpv = new Dictionary<int, bool>();
            Dictionary<int,bool> dicIdsLiaisons = new Dictionary<int,bool>();
            Dictionary<int, bool> dicIdsEquips = new Dictionary<int,bool>();
            foreach ( CReferenceObjetDonnee reference in lst )
            {
                Dictionary<int, bool> dic = null;
                if ( reference.TypeObjet == typeof(CSpvSite ) )
                    dic = dicIdsSitesSpv;
                if ( reference.TypeObjet == typeof(CSpvLiai ) )
                    dic = dicIdsLiaisons;
                if ( reference.TypeObjet == typeof ( CSpvEquip ) )
                    dic = dicIdsEquips;
                if ( dic != null )
                    dic[(int)reference.ClesObjet[0]] = true;
            }
            StringBuilder blIdsSites = new StringBuilder();
            foreach ( int nId in dicIdsSitesSpv.Keys )
            {
                blIdsSites.Append (nId);
                blIdsSites.Append (',');
            }
            StringBuilder blIdsLiens = new StringBuilder();
            foreach ( int nId in dicIdsLiaisons.Keys )
            {
                blIdsLiens.Append(nId);
                blIdsLiens.Append(',');
            }
            StringBuilder blIdsEquip = new StringBuilder();
            foreach ( int nId in dicIdsEquips.Keys )
            {
                blIdsEquip.Append ( nId );
                blIdsEquip.Append(',');
            }
            string strFiltre = "";
            if ( blIdsSites.Length > 0 )
            {
                blIdsSites.Remove ( blIdsSites.Length-1, 1);
                strFiltre = CSpvAlarmeDonnee.c_champSITE_ID+" in ("+blIdsSites.ToString()+")";
            }
            if ( blIdsLiens.Length > 0 )
            {
                blIdsLiens.Remove ( blIdsLiens.Length-1, 1);
                if ( strFiltre.Length > 0 )
                    strFiltre += " or ";
                strFiltre += CSpvAlarmeDonnee.c_champLIAI_ID + " in (" + blIdsLiens.ToString() + ")";
            }
            if ( blIdsEquip.Length > 0 )
            {
                blIdsEquip.Remove ( blIdsEquip.Length-1, 1);
                if ( strFiltre.Length > 0 )
                    strFiltre += " or ";
                strFiltre += CSpvAlarmeDonnee.c_champEQUIP_ID + " in (" + blIdsEquip.ToString() + ")";
            }
            CFiltreData filtre = null;
            if ( strFiltre.Length == 0 )
            {
                filtre = new CFiltreDataImpossible();
            }
            else
            {
                filtre = new CFiltreData(strFiltre);
            }
            CListeObjetsDonnees lstAlarmes = new CListeObjetsDonnees(SchemaReseau.ContexteDonnee, typeof(CSpvAlarmeDonnee), filtre);

            IFormNavigable formNavigable = FindForm() as IFormNavigable;
            if (formNavigable != null && formNavigable.Navigateur != null)
            {
                CFormListeAlarms form = new CFormListeAlarms ( lstAlarmes );
                formNavigable.Navigateur.AffichePage ( form );
            }
        }

        private void m_btnTestArbre_Click(object sender, EventArgs e)
        {
            CSpvSchemaReseau spvSchema = CSpvSchemaReseau.GetObjetSpvFromObjetTimos(SchemaReseau);
            if ( spvSchema != null )
                CFormTestSpvGraph.ShowArbreSpv(spvSchema);
        }

    }
}

