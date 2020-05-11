using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using sc2i.common;
using futurocom.snmp.Mib;
using futurocom.snmp;
using futurocom.snmp.alarme;

namespace futurocom.win32.snmp
{
    [AutoExec("Autoexec")]
    public partial class CPanelDetailNotification : UserControl, ISNMPClassViewer
    {
        public IMibNavigator MibNavigator { get; set; }
        private IDefinition m_definition = null;

        public CPanelDetailNotification()
        {
            InitializeComponent();
            CWin32Traducteur.Translate(this);
        }

        //------------------------------------
        public static void Autoexec()
        {
            CSNMPClassViewer.RegisterViewer(typeof(NotificationType), typeof(CPanelDetailNotification));
        }

        //------------------------------------
        private void CPanelDetailNotification_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
        }


        //------------------------------------
        public void DisplayElement(IDefinition definition)
        {
            m_definition = definition;
            NotificationType notificationType = definition.Entity as NotificationType;
            m_exLinkField.FillDialogFromObjet(notificationType);

            //Ajoute les \r à la description
            string strDesc = definition.Description;
            if (!strDesc.Contains("\r"))
                strDesc = strDesc.Replace("\n", "\r\n");
            m_lblDescription.Text = strDesc;

            //Récupère l'OID
            m_lblOID.Text = ObjectIdentifier.Convert(definition.GetNumericalForm());

            

            m_wndListeObjects.Items.Clear();
            foreach (string strObject in notificationType.Objects)
                m_wndListeObjects.Items.Add(strObject);

        }

        //--------------------------------------------------------
        private void m_wndListeObjects_ItemClick(ListViewItem item)
        {
            string strItem = item.Text;
            MibNavigator.NavigateTo(m_definition.ModuleName, strItem);
        }

        //--------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            //CTrapDefinition trap = CTrapDefinition.CreateFromMib(m_definition.Tree, m_definition.Entity as NotificationType);
        }

        //--------------------------------------------------------
        private void m_btnSendTrap_Click(object sender, EventArgs e)
        {
            CFormSendTrap.SendTrap(m_definition, MibNavigator.ObjectTree);
        }
    }
}
