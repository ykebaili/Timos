using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using futurocom.snmp;
using futurocom.snmp.alarme;
using futurocom.snmp.Mib;
using futurocom.supervision;
using futurocom.easyquery;
using futurocom.easyquery.snmp;
using futurocom.snmp.dynamic;
using futurocom.snmp.entitesnmp;
//using futurocom.win32.snmp.entitesnmp;

namespace futurocom.win32.snmp.alarmes
{
    public partial class CControleEditeBaseSupervision : UserControl
    {
        private CTypeAgentPourSupervision m_baseHandlers = null;
        private IBaseTypesAlarmes m_baseTypesAlarmes = null;
        private CSnmpConnexion m_connexion = null;
        public CControleEditeBaseSupervision()
        {
            InitializeComponent();
        }

        public void Init(
            CSnmpConnexion connexion,
            IDefinition rootDefinition, 
            CTypeAgentPourSupervision baseHandlers,
            IBaseTypesAlarmes baseTypes)
        {
            m_connexion = connexion;
            m_browser.Init(rootDefinition, connexion);
            m_baseHandlers = baseHandlers;
            CDynamicSnmpAgent agent = new CDynamicSnmpAgent(rootDefinition);
            agent.Connexion = connexion;
            m_baseHandlers.AgentAssocie = agent;
            m_baseTypesAlarmes = baseTypes;
            
            FillListeHandlers();
            FillListeQueries();
            FillListeTypeEntites();
        }

        //---------------------------------------------------------------
        private void m_browser_SelectedDefinitionChanged(object sender, EventArgs e)
        {
            m_lnkCreateHandler.Visible = m_browser.SelectedDefinition != null &&
                m_browser.SelectedDefinition.Entity is NotificationType;
        }


        private void FillListeHandlers()
        {
            m_wndListeHandlers.ListeSource = m_baseHandlers.Handlers.ToArray();
            m_wndListeHandlers.Refresh();
        }

        //---------------------------------------------------------------
        private void m_lnkCreateHandler_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            IDefinition def = m_browser.SelectedDefinition;
            if (def != null)
            {
                NotificationType notification = def.Entity as NotificationType;
                if (notification != null)
                {
                    CTrapHandler handler = CTrapHandler.CreateFromMib(def.Tree, def);
                    handler.TrapManager = m_baseHandlers;
                    if (handler != null)
                    {
                        if (CFormEditeTrapHandler.EditeTrapHandler(handler, m_baseTypesAlarmes, m_browser.RootDefinition))
                        {
                            m_baseHandlers.AddTrapHandler(handler);
                            FillListeHandlers();
                        }
                    }
                }
            }
        }

        //---------------------------------------------------------------
        private void m_wndListeHandlers_DoubleClick(object sender, EventArgs e)
        {
            if (m_wndListeHandlers.SelectedItems.Count == 1)
            {
                CTrapHandler handler = m_wndListeHandlers.SelectedItems[0] as CTrapHandler;
                if (handler != null)
                {
                    if (CFormEditeTrapHandler.EditeTrapHandler(handler, m_baseTypesAlarmes, m_browser.RootDefinition))
                    {
                        FillListeHandlers();
                    }
                }
            }
        }

        //---------------------------------------------------------------
        private void m_lnkAddHandler_LinkClicked(object sender, EventArgs e)
        {
            CTrapHandler handler = new CTrapHandler();
            if (CFormEditeTrapHandler.EditeTrapHandler(handler, m_baseTypesAlarmes, m_browser.RootDefinition))
            {
                m_baseHandlers.AddTrapHandler(handler);
                FillListeHandlers();
            }
        }

        //---------------------------------------------------------------
        private void m_wndRemoveHandler_LinkClicked(object sender, EventArgs e)
        {
            if (m_wndListeHandlers.SelectedItems.Count == 1)
            {
                CTrapHandler handler = m_wndListeHandlers.SelectedItems[0] as CTrapHandler;
                if (handler != null)
                {
                    m_baseHandlers.RemoveTrapHandler(handler);
                    FillListeHandlers();
                    
                }
            }
        }

        //---------------------------------------------------------------
        private void FillListeQueries()
        {
            m_wndListeQueries.ListeSource = m_baseHandlers.Queries.ToArray();
            m_wndListeQueries.Refresh();
        }


        //---------------------------------------------------------------
        private void m_lnkAddQuery_LinkClicked(object sender, EventArgs e)
        {
            CEasyQuery query = new CEasyQuery();
            if ( EditeQuery ( query ) )
            {
                m_baseHandlers.AddQuery(query);
                FillListeQueries();
            }

        }

        //---------------------------------------------------------------
        private bool EditeQuery ( CEasyQuery query )
        {
            CEasyQuerySource source = new CEasyQuerySource();
            CDynamicSnmpAgent agent = new CDynamicSnmpAgent();
            agent.Connexion = m_connexion;
            source.AddTableFiller(new CSnmpTableFiller(agent));
            CTableDefinitionSNMP.FromMib ( source,  m_browser.RootDefinition, source.RootFolder );
            query.Source = source;
            return CFormEditEasyQuery.EditeQuery ( query );
        }

        //---------------------------------------------------------------
        private void m_wndListeQueries_DoubleClick(object sender, EventArgs e)
        {
            if (m_wndListeQueries.SelectedItems.Count == 1)
            {
                CEasyQuery query = m_wndListeQueries.SelectedItems[0] as CEasyQuery;
                if (query != null )
                {
                    if (EditeQuery(query))
                        FillListeQueries();
                }
            }
        }

        //---------------------------------------------------------------
        private void m_lnkRemoveQuery_LinkClicked(object sender, EventArgs e)
        {
            if (m_wndListeQueries.SelectedItems.Count == 1)
            {
                CEasyQuery query = m_wndListeQueries.SelectedItems[0] as CEasyQuery;
                if (query != null)
                    m_baseHandlers.RemoveQuery(query);
            }
        }

        //---------------------------------------------------------------
        private void FillListeTypeEntites()
        {
            m_wndListeTypesEntites.ListeSource = m_baseHandlers.TypesEntites.ToArray();
            m_wndListeTypesEntites.Refresh();
        }

        //---------------------------------------------------------------
        private void m_wndListeTypesEntites_DoubleClick(object sender, EventArgs e)
        {
            if (m_wndListeTypesEntites.SelectedItems.Count == 1)
            {
                CTypeEntiteSnmpPourSupervision typeEntite = m_wndListeTypesEntites.SelectedItems[0] as CTypeEntiteSnmpPourSupervision;
                if (typeEntite != null)
                {
                    if (CFormEditTypeEntiteSnmp.EditeTypeEntite(typeEntite, m_baseHandlers))
                    {
                        FillListeTypeEntites();
                    }
                }
            }
        }

        //---------------------------------------------------------------
        private void m_lnkAddTypeEntite_LinkClicked(object sender, EventArgs e)
        {
            CTypeEntiteSnmpPourSupervision typeEntite = new CTypeEntiteSnmpPourSupervision();
            if (CFormEditTypeEntiteSnmp.EditeTypeEntite(typeEntite, m_baseHandlers))
            {
                m_baseHandlers.AddTypeEntite(typeEntite);
                FillListeTypeEntites();
            }
        }

        //---------------------------------------------------------------
        private void m_wndRemoveTypeEntite_LinkClicked(object sender, EventArgs e)
        {
            if (m_wndListeHandlers.SelectedItems.Count == 1)
            {
                CTypeEntiteSnmpPourSupervision typeEntite = m_wndListeTypesEntites.SelectedItems[0] as CTypeEntiteSnmpPourSupervision;
                if (typeEntite != null)
                {
                    m_baseHandlers.RemoveTypeEntite(typeEntite);
                    FillListeTypeEntites();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CAgentSnmpPourSupervision agent = new CAgentSnmpPourSupervision();
            agent.TypeAgent = m_baseHandlers;
            agent.Ip = "172.16.1.200";
            agent.SnmpVersion = VersionCode.V1;
            agent.SnmpPort = 161;
            agent.Communaute = "public";
            agent.FillFromSNMP(m_baseHandlers.AgentAssocie);
        }
    }
}
