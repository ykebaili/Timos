using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.common;
using futurocom.snmp;
using futurocom.snmp.Mib;
using sc2i.win32.common;

namespace futurocom.win32.snmp
{
    [AutoExec("Autoexec")]
    public partial class CPanelDetailObjetDossier : UserControl, ISNMPClassViewer
    {
        private IDefinition m_definition = null;
        public IMibNavigator MibNavigator { get; set; }

        //------------------------------------
        public CPanelDetailObjetDossier()
        {
            InitializeComponent();
            CWin32Traducteur.Translate(this);
            
        }

        //------------------------------------
        public static void Autoexec()
        {
            CSNMPClassViewer.RegisterViewer(typeof(OidValueAssignment), typeof(CPanelDetailObjetDossier));
        }


        //------------------------------------
        public void DisplayElement(IDefinition definition)
        {
            OidValueAssignment objectType = definition.Entity as OidValueAssignment;
            m_exLinkField.FillDialogFromObjet(objectType);
            m_definition = definition;

            //Ajoute les \r à la description
            string strDesc = definition.Description;
            if (!strDesc.Contains("\r"))
                strDesc = strDesc.Replace("\n", "\r\n");
            m_lblDescription.Text = strDesc;

            //Récupère l'OID
            m_lblOID.Text = ObjectIdentifier.Convert(definition.GetNumericalForm());

            UpdateVisuPages();
        }

        
        
     
        

        //---------------------------------------------
        private void UpdateVisuPages()
        {
           
        }

       
    }
}
