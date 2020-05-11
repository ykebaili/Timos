using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using futurocom.snmp.Messaging;
using System.Net;
using futurocom.snmp;
using futurocom.snmp.alarme;
using futurocom.supervision;
using sc2i.win32.common;
using sc2i.expression;
using futurocom.snmp.dynamic;
using futurocom.snmp.expression;

namespace TestSnmp
{
    public partial class CFormTrapReceiver : Form
    {
        private Listener m_listener = new Listener();
        private CGestionnnaireAlarmesTest m_gestionnaireAlarmes = new CGestionnnaireAlarmesTest();

        public CFormTrapReceiver()
        {
            InitializeComponent();
            m_listener.MessageReceived += new EventHandler<MessageReceivedEventArgs>(m_listener_MessageReceived);
            m_listener.AddBinding ( new IPEndPoint ( new IPAddress(new byte[]{0,0,0,0}), 162 ));
            CCurentBaseTypesAlarmes.SetCurrentBase(CBaseTypesAlarmes.Instance);
        }

        void m_listener_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            BeginInvoke ( new OnReceiveMessageDelegate(OnReceiveMessage), e );       
            
        }

        public delegate void OnReceiveMessageDelegate ( MessageReceivedEventArgs e );

        public void OnReceiveMessage(MessageReceivedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            ListViewItem item = new ListViewItem(e.ToString());
            item.Tag = e.Message;

            if (m_wndListView.Items.Count > 0)
                m_wndListView.Items.Insert(0, item);
            else
                m_wndListView.Items.Add(item);

            CTrapInstance trap = CTrapInstance.FromMessage ( 
                e.Message, 
                CBaseTypesAlarmes.Instance.BaseTraps);
            if (trap != null)
            {
                IEnumerable<CTrapHandler> lstTrapsHandlers = CBaseTypesAlarmes.Instance.BaseTraps.GetTrapsHandlersAAppliquer(trap);

                foreach (CTrapHandler handler in lstTrapsHandlers)
                    handler.CreateAlarmesOnTrap(trap);
                foreach (CAlarmeACreer creation in trap.AlarmesACreer)
                    m_gestionnaireAlarmes.CreateAlarme(creation);

                TimeSpan sp = DateTime.Now - dt;
                System.Console.WriteLine("Durée traitement : " + sp.TotalMilliseconds.ToString());
                RefreshListeAlarmes();
            }

        }

        private void RefreshListeAlarmes()
        {
            CTreeViewNodeKeeper keeper=  new CTreeViewNodeKeeper(m_arbreAlarmes);
            m_arbreAlarmes.BeginUpdate();
            m_arbreAlarmes.Nodes.Clear();
            IEnumerable<IAlarme> lst = from a in m_gestionnaireAlarmes.CurrentAlarms where a.Parent == null orderby a.DateDebut descending select a;
            foreach (IAlarme alrm in lst) 
            {
                TreeNode node = new TreeNode();
                FillNode(node, alrm);
                m_arbreAlarmes.Nodes.Add(node);
            }
            if (m_chkAvecAlarmesRetombées.Checked)
            {
                IEnumerable<IAlarme> lstTombées = from a in m_gestionnaireAlarmes.EndedAlarms where a.Parent == null orderby a.DateDebut descending select a;
                foreach (IAlarme alrm in lstTombées)
                {
                    TreeNode node = new TreeNode();
                    FillNode(node, alrm);
                    m_arbreAlarmes.Nodes.Add(node);
                }
            }
            keeper.Apply(m_arbreAlarmes);
            m_arbreAlarmes.EndUpdate();
        }

        private void FillNode(TreeNode node, IAlarme alarme)
        {
            node.Text = alarme.Libelle;
            node.Tag = alarme;
            if (alarme.Etat.Code == EEtatAlarme.Open)
                node.BackColor = Color.LightPink;
            else if (alarme.Etat.Code == EEtatAlarme.Close)
                node.BackColor = Color.LightGreen;
                
            if (alarme.Childs.Count() > 0)
            {
                node.Nodes.Add(new TreeNode());
            }
        }


        private void m_btnStartListener_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_listener.Active)
                {
                    m_listener.Stop();
                }
                else
                {
                    m_listener.Start();
                }
                m_btnStartListener.Text = m_listener.Active ? "Stop" : "Start";

            }
            catch (Exception xe)
            {
                MessageBox.Show(xe.ToString());
            }
        }

        private void m_wndListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_wndListView.SelectedItems.Count == 1)
            {
                ISnmpMessage message = m_wndListView.SelectedItems[0].Tag as ISnmpMessage;
                m_wndListeVariables.Items.Clear();
                m_properties.SelectedObject = message.Pdu();
                foreach (Variable v in message.Variables())
                {
                    ListViewItem item = new ListViewItem(v.Id.ToString());
                    item.SubItems.Add(v.Data.ToString());
                    m_wndListeVariables.Items.Add(item);
                }
            }
        }

        private void m_wndListeVariables_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void m_btnGererAlarmes_Click(object sender, EventArgs e)
        {
            CFormEditeBaseAlarmes form = new CFormEditeBaseAlarmes();
            form.ShowDialog();
            form.Dispose();
        }

        private void m_btnGererMibs_Click(object sender, EventArgs e)
        {
            CFormMib form = new CFormMib();
            form.ShowDialog();
            form.Dispose();
        }

        private void m_btnGererSupervision_Click(object sender, EventArgs e)
        {
            CFormParametrageSupervision.EditeSupervision();
        }

        private void m_arbreAlarmes_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Tag == null)
            {
                e.Node.Nodes.Clear();
                IAlarme alarme = e.Node.Tag as IAlarme;
                if (alarme != null)
                {
                    foreach (IAlarme child in alarme.Childs)
                    {
                        TreeNode node = new TreeNode();
                        FillNode(node, child);
                        e.Node.Nodes.Add(node);
                    }
                }
            }
        }

        private class CMenuTypeAlarm : ToolStripMenuItem
        {
            public ITypeAlarme TypeAlarme { get; set; }

            public CMenuTypeAlarm(ITypeAlarme typeAlarme)
                : base(typeAlarme.Libelle)
            {
                TypeAlarme = typeAlarme;
            }
        }

        private void m_btnTest_Click(object sender, EventArgs e)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            foreach (ITypeAlarme typeAlarm in CBaseTypesAlarmes.Instance.TypesAlarmes)
            {
                CMenuTypeAlarm mt = new CMenuTypeAlarm(typeAlarm);
                menu.Items.Add(mt);
                mt.Click += new EventHandler(mt_Click);
            }
            menu.Show(m_btnTest.Left, m_btnTest.Bottom);
        }

        void mt_Click(object sender, EventArgs e)
        {
            CMenuTypeAlarm menu = sender as CMenuTypeAlarm;
            if (menu != null)
            {
                CAlarmeTest alarme = new CAlarmeTest(m_gestionnaireAlarmes);
                alarme.TypeAlarme = menu.TypeAlarme;
                m_gestionnaireAlarmes.GereAlarme(alarme);
                RefreshListeAlarmes();
            }
        }

        private void m_chkAvecAlarmesRetombées_CheckedChanged(object sender, EventArgs e)
        {
            RefreshListeAlarmes();
        }

        private void FillChampsAlarme()
        {
            m_wndInfosAlarme.BeginUpdate();
            m_wndInfosAlarme.Items.Clear();
            TreeNode node = m_arbreAlarmes.SelectedNode;
            if (node != null)
            {
                IAlarme alarme = node.Tag as IAlarme;
                List<IChampAlarme> lst = new List<IChampAlarme>(alarme.TypeAlarme.TousLesChamps);
                lst.Sort((x, y) => x.NomChamp.CompareTo(y.NomChamp));
                foreach (IChampAlarme champ in lst)
                {
                    object val = alarme.GetValeurChamp(champ.NomChamp);
                    ListViewItem item = new ListViewItem(champ.NomChamp);
                    item.SubItems.Add(val == null ? "" : val.ToString());
                    m_wndInfosAlarme.Items.Add(item);
                }
            }
            m_wndInfosAlarme.EndUpdate();
        }

        
        private void m_arbreAlarmes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            FillChampsAlarme();
        }

        private void m_txtTestAlarmes_Enter(object sender, EventArgs e)
        {
            m_txtTestAlarmes.Init(new CFournisseurGeneriqueProprietesDynamiques(),
                new CObjetPourSousProprietes(new CDynamicSnmpAgent(CProjetMib.Instance.Mib.Tree.Root)));
        }
    }
}
