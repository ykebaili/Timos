using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using sc2i.win32.data.dynamic;
using timos.data.snmp;
using sc2i.data.dynamic;
using sc2i.common;
using sc2i.win32.data.navigation;
using sc2i.data;
using timos.data.supervision;
using timos.data;

namespace timos.snmp
{
    public partial class CPanelEditeEntiteSnmp : CSlidingZone
    {
        

        private C2iPanel m_panelElementSupervise;
        private Label m_lblElementSupervise;
        private C2iTextBoxSelectionne m_selectElementSupervise;
        private CPanelChampsCustom m_panelChamps;
        private bool m_bIsInit = false;
        private CEntiteSnmp m_entiteEditee = null;

        private Type m_typeElementAssocie = null;
        private CSite m_lastSite = null;
        private CEquipementLogique m_lastEquipement = null;
        private CLienReseau m_lastLien = null;

        private CFiltreData m_filtreElementAssocie = null;
        
        
        public CPanelEditeEntiteSnmp()
        {
            InitializeComponent();
            Collapse();
        }

        
        private void InitZoneSelectionEntite()
        {
            if (m_entiteEditee.TypeEntiteSnmp != null && m_entiteEditee.TypeEntiteSnmp.TypeElementsSupervise != null)
            {
                m_typeElementAssocie = m_entiteEditee.TypeEntiteSnmp.TypeElementsSupervise;

                if (m_entiteEditee.TypeEntiteSnmp.FiltreElementsSupervise != null)
                {
                    CResultAErreur result = m_entiteEditee.TypeEntiteSnmp.FiltreElementsSupervise.GetFiltreData();
                    if (result)
                        m_filtreElementAssocie = result.Data as CFiltreData;
                }
                else
                    m_filtreElementAssocie = null;
            }
            if (m_typeElementAssocie == null && m_entiteEditee.ElementSupervise != null)
                m_typeElementAssocie = m_entiteEditee.ElementSupervise.GetType();
            if (m_typeElementAssocie == typeof(DBNull) || m_typeElementAssocie == null)
            {
                m_selectElementSupervise.Visible = false;
                m_lblElementSupervise.Text = I.T("No associated element|20399");
            }
            else
            {
                m_selectElementSupervise.Visible = true;
                m_lblElementSupervise.Text = DynamicClassAttribute.GetNomConvivial(m_typeElementAssocie);
                CFiltreData filtre = null;
                if (m_filtreElementAssocie != null)
                    filtre = m_filtreElementAssocie;
                m_selectElementSupervise.InitForSelectAvecFiltreDeBase(
                        m_typeElementAssocie,
                        "Libelle",
                        filtre,
                        true);
                m_selectElementSupervise.ElementSelectionne = m_entiteEditee.ElementSupervise as CObjetDonnee;
                if (m_typeElementAssocie == typeof(CSite))
                    m_selectElementSupervise.ElementSelectionne = m_lastSite;
                if (m_typeElementAssocie == typeof(CEquipementLogique))
                    m_selectElementSupervise.ElementSelectionne = m_lastEquipement;
                if (m_typeElementAssocie == typeof(CLienReseau))
                    m_selectElementSupervise.ElementSelectionne = m_lastLien;
            }
        }   

        public void Init(CEntiteSnmp entite)
        {
            CWin32Traducteur.Translate(this);
            m_entiteEditee = entite;
            
            int nHeight = 50;
            foreach ( IRelationDefinisseurChamp_Formulaire rel in entite.TypeEntiteSnmp.RelationsFormulaires )
                nHeight = Math.Max ( rel.Formulaire.Formulaire.Size.Height, nHeight );
            nHeight += TitleHeight + 5;
            nHeight += m_panelElementSupervise.Height;
            TitleText = entite.Libelle+ "    ("+entite.Index+")";
            m_bIsInit = false;
            if (!IsCollapse)
            {
                InitControles();
                
            }
            this.ExtendedSize = nHeight;

        }

        private void InitControles()
        {
            if (m_bIsInit)
                return;
            m_panelChamps.ElementEdite = m_entiteEditee;
            m_lastSite = m_entiteEditee.SiteSupervise;
            m_lastEquipement = m_entiteEditee.EquipementLogiqueSupervise;
            m_lastLien = m_entiteEditee.LienReseauSupervise;
            InitZoneSelectionEntite();
            
            m_bIsInit = true;
        }

        private void CPanelEditeEntiteSnmp_OnCollapseChange(object sender, EventArgs e)
        {
            if (!IsCollapse && !m_bIsInit)
            {
                InitControles();
                /*m_panelChamps.ElementEdite = m_entiteEditee;
                if (m_entiteEditee.TypeEntiteSnmp != null && m_entiteEditee.TypeEntiteSnmp.TypeElementsSupervise != null)
                {
                    CFiltreData filtre = CFournisseurFiltreRapide.GetFiltreRapideForType(m_entiteEditee.TypeEntiteSnmp.TypeElementsSupervise);
                    if (m_entiteEditee.TypeEntiteSnmp.FiltreElementsSupervise != null &&
                        m_entiteEditee.TypeEntiteSnmp.FiltreElementsSupervise.TypeElements == m_entiteEditee.TypeEntiteSnmp.TypeElementsSupervise)
                    {
                        CResultAErreur result = m_entiteEditee.TypeEntiteSnmp.FiltreElementsSupervise.GetFiltreData();
                        if (result)
                            filtre = CFiltreData.GetAndFiltre(
                                filtre,
                                result.Data as CFiltreData);
                    }
                    m_panelElementSupervise.Visible = true;
                    m_lblElementSupervise.Text = DynamicClassAttribute.GetNomConvivial(m_entiteEditee.TypeEntiteSnmp.TypeElementsSupervise);
                    m_selectElementSupervise.Init(
                        CFormFinder.GetTypeFormToList(m_entiteEditee.TypeEntiteSnmp.TypeElementsSupervise),
                        "Libelle",
                        filtre,
                        true);
                    m_selectElementSupervise.ElementSelectionne = m_entiteEditee.ElementSupervise as CObjetDonnee;
                    this.ExtendedSize += m_panelElementSupervise.Height;
                    this.Height = this.ExtendedSize;
                }
                else
                {
                    m_panelElementSupervise.Visible = false;
                }*/

                m_bIsInit = true;
            }
        }

        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_bIsInit)
                result = m_panelChamps.MAJ_Champs();
            if (result && m_bIsInit)
                m_entiteEditee.ElementSupervise = m_selectElementSupervise.ElementSelectionne as IElementSupervise;

            return result;
        }

        public CEntiteSnmp ElementEdite
        {
            get
            {
                return m_entiteEditee;
            }
        }

        private void m_lblElementSupervise_MouseDown(object sender, MouseEventArgs e)
        {
            if (m_entiteEditee.ElementSupervise== null && m_entiteEditee.TypeEntiteSnmp.TypeElementsSupervise == null)
            {
                m_menuTypeElementAssocie.Show(m_lblElementSupervise, new Point(0, m_lblElementSupervise.Height));
            }
        }

        private void m_menuAssocieToSite_Click(object sender, EventArgs e)
        {
            m_typeElementAssocie = typeof(CSite);
            InitZoneSelectionEntite();
        }

        private void m_menuAssocieToEquipement_Click(object sender, EventArgs e)
        {
            m_typeElementAssocie = typeof(CEquipementLogique);
            InitZoneSelectionEntite();
        }

        private void m_menuAssocieToLien_Click(object sender, EventArgs e)
        {
            m_typeElementAssocie = typeof(CLienReseau);
            InitZoneSelectionEntite();
        }
    }
}
