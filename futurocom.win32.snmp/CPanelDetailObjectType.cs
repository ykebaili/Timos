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
    public partial class CPanelDetailObjectType : UserControl, ISNMPClassViewer
    {
        private IDefinition m_definition = null;
        public IMibNavigator MibNavigator { get; set; }

        //------------------------------------
        public CPanelDetailObjectType()
        {
            InitializeComponent();
            CWin32Traducteur.Translate(this);
            
        }

        //------------------------------------
        public static void Autoexec()
        {
            CSNMPClassViewer.RegisterViewer(typeof(ObjectType), typeof(CPanelDetailObjectType));
        }


        //------------------------------------
        public void DisplayElement(IDefinition definition)
        {
            ObjectType objectType = definition.Entity as ObjectType;
            m_exLinkField.FillDialogFromObjet(objectType);
            m_definition = definition;

            //Ajoute les \r à la description
            string strDesc = definition.Description;
            if (!strDesc.Contains("\r"))
                strDesc = strDesc.Replace("\n", "\r\n");
            m_lblDescription.Text = strDesc;

            if (objectType.Syntax != null)
                m_lblDataType.Text = objectType.Syntax.GetType().Name;

            //Récupère l'OID
            m_lblOID.Text = ObjectIdentifier.Convert(definition.GetNumericalForm());

            if (objectType != null)
            {
                switch (objectType.Access)
                {
                    case MaxAccess.notAccessible:
                        m_txtAccess.Text = I.T("Not accessible|20005");
                        break;
                    case MaxAccess.accessibleForNotify:
                        m_txtAccess.Text = I.T("Accessible for notify|20006");
                        break;
                    case MaxAccess.readOnly:
                        m_txtAccess.Text = I.T("Read only|20007");
                        break;
                    case MaxAccess.readWrite:
                        m_txtAccess.Text = I.T("Read / Write|20008");
                        break;
                    case MaxAccess.readCreate:
                        m_txtAccess.Text = I.T("Read / Create|20009");
                        break;
                    default:
                        break;
                }
            }

            m_wndListeIndices.Items.Clear();
            if (objectType != null)
            {
                foreach (string strIndice in objectType.Indices)
                    m_wndListeIndices.Items.Add(strIndice);
            }
            if (m_definition.Type == DefinitionType.Table || m_definition.Type == DefinitionType.Entry)
            {
                FillPageTable();
            }

            UpdateVisuPages();
        }

        //---------------------------------------------
        private void FillPageTable()
        {
            m_wndListeColonnes.Items.Clear();
            m_wndListeColonnes.BeginUpdate();
            
            List<IDefinition> columns = new List<IDefinition>();

            FillColumns(m_definition, columns);
            foreach (IDefinition col in columns)
            {
                ListViewItem item = new ListViewItem(col.Name);
                ObjectType info = col.Entity as ObjectType;
                if (info != null)
                    item.SubItems.Add(info.Syntax.Name);
                else
                    item.SubItems.Add("");
                string strDesc = info.Description;
                if (!strDesc.Contains('\r'))
                    strDesc = strDesc.Replace("\n", "\r\n");
                item.SubItems.Add(strDesc);
                
                item.ToolTipText = strDesc;
                item.Tag = col;
                item.SubItems[0].Font = m_lblForFontColumnName.Font;
                item.SubItems[0].ForeColor = m_lblForFontColumnName.LinkColor;
                for (int n = 1; n < item.SubItems.Count; n++)
                {
                    item.SubItems[n].Font = m_wndListeColonnes.Font;
                    item.SubItems[n].ForeColor = m_wndListeColonnes.ForeColor;
                }
                m_wndListeColonnes.Items.Add(item);
            }
            m_wndListeColonnes.EndUpdate();
        }
        
        //---------------------------------------------
        private void FillColumns(IDefinition definition, List<IDefinition> lst)
        {
            if (m_definition == null)
                return;
            foreach (IDefinition child in definition.Children)
            {
                if (child.Type == DefinitionType.Column)
                    lst.Add(child);
                else
                    FillColumns(child, lst);
            }
        }

        

        //---------------------------------------------
        private void UpdateVisuPages()
        {
            if (m_wndListeIndices.Items.Count == 0)
            {
                if (m_tabControl.TabPages.Contains(m_pageIndices))
                    m_tabControl.TabPages.Remove(m_pageIndices);
            }
            else
            {
                if (!m_tabControl.TabPages.Contains(m_pageIndices))
                {
                    if ( m_tabControl.TabPages.Count < 3 )
                        m_tabControl.TabPages.Add ( m_pageIndices );
                    else
                        m_tabControl.TabPages.Insert(3, m_pageIndices);
                }
            }
            if (m_definition.Type == DefinitionType.Table || m_definition.Type == DefinitionType.Entry)
            {
                if (!m_tabControl.TabPages.Contains(m_pageTable))
                    m_tabControl.TabPages.Add(m_pageTable);
            }
            else
            {
                if (m_tabControl.TabPages.Contains(m_pageTable))
                    m_tabControl.TabPages.Remove(m_pageTable);
            }
        }

        private void CPanelDetailScalar_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
        }

        private void m_wndListeColonnes_MouseDown(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = m_wndListeColonnes.HitTest(e.X, e.Y);
            if (info.Item != null && info.SubItem != null && info.SubItem == info.Item.SubItems[0] &&
                info.Item.Tag is IDefinition)
            {
                if (MibNavigator != null)
                {
                    IDefinition def = info.Item.Tag as IDefinition;
                    MibNavigator.NavigateTo(def.ModuleName, def.Name);
                }
            }
        }
    }
}
