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

namespace futurocom.win32.snmp
{
    public partial class CMibList : UserControl
    {
        public IMibNavigator MibNavigator { get; set; }

        private bool m_bLockUpdate = false;

        private IDefinition m_root = null;
        private List<IDefinition> m_allDefs = new List<IDefinition>();

        private int m_nSortOnName = 1;
        private int m_nSortOnType = 0;

        //-------------------------------------------
        public CMibList()
        {
            InitializeComponent();
            InitTypes();
            m_imageList.Images.AddRange(CSnmpIcons.GetImagesForDefinitionType());
            m_slidingFiltre.Collapse();
        }

        //-------------------------------------------
        private void InitTypes()
        {
            m_wndListe.Items.Clear();
            foreach ( object valeur in Enum.GetValues ( typeof(DefinitionType) ) )
            {
                ListViewItem item = new ListViewItem(CUtilSurEnum.GetNomConvivial(valeur.ToString()));
                item.Tag = valeur;
                item.Checked = true;
                item.ImageIndex = (int)valeur;
                m_wndListeTypes.Items.Add(item);
            }
            m_timerOnChangeFiltre.Stop();
        }

        //-------------------------------------------
        public void Init(IDefinition root)
        {
            if (!m_bLockUpdate)
            {
                m_root = root;
                InitPath();
                m_allDefs.Clear();
                m_wndListe.Items.Clear();
                FillAllDefs(root);
                Refill();
            }
        }

        //-------------------------------------------
        private void InitPath()
        {
            StringBuilder bl = new StringBuilder();
            IDefinition def = m_root;
            while (def != null)
            {
                bl.Insert(0, def.Name);
                bl.Insert(0, '/');
                def = def.ParentDefinition;
            }
            m_txtPath.Text = bl.ToString();
        }

        //-------------------------------------------
        private void FillAllDefs(IDefinition definition)
        {
            if (definition == null)
                return;
            foreach (IDefinition child in definition.Children)
            {
                m_allDefs.Add(child);
                if ( m_chkRecursive.Checked )
                    FillAllDefs(child);
            }
        }

        //-------------------------------------------
        private void Refill()
        {
            if (m_timerOnChangeFiltre.Enabled)
            {
                m_wndListe.Items.Clear();
                m_timerOnChangeFiltre.Stop();
            }
            m_timerOnChangeFiltre.Start();
        }

        //-------------------------------------------
        private void RefillSansDelai()
        {
            m_wndListe.BeginUpdate();
            m_wndListe.Items.Clear();

            HashSet<DefinitionType> types = new HashSet<DefinitionType>();

            m_allDefs.Sort ( (x,y)=> m_nSortOnName*x.Name.CompareTo(y.Name)+m_nSortOnType*x.Type.ToString().CompareTo(y.Type.ToString() ));
            foreach (ListViewItem item in m_wndListeTypes.CheckedItems)
            {
                if (item.Tag is DefinitionType)
                    types.Add((DefinitionType)item.Tag);
            }
            string strSearch = m_txtName.Text.ToUpper();
            foreach (IDefinition def in from d in m_allDefs
                                        where types.Contains(d.Type) &&
                                        (strSearch == "" || d.Name.ToUpper().Contains ( strSearch ))
                                                select d )
            {
                ListViewItem item = new ListViewItem ( def.Name );
                item.SubItems.Add ( CUtilSurEnum.GetNomConvivial ( def.Type.ToString() ) );
                item.Tag = def;
                item.ImageIndex = (int)def.Type;
                m_wndListe.Items.Add ( item );
            }
            
            m_wndListe.EndUpdate();
        }

        private void m_slidingFiltre_Load(object sender, EventArgs e)
        {

        }

        private void m_wndListe_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == m_colName.Index)
            {
                if (m_nSortOnName == 0)
                    m_nSortOnName = 1;
                else
                    m_nSortOnName = -m_nSortOnName;
                m_nSortOnType = 0;
            }
            if (e.Column == m_colType.Index)
            {
                if (m_nSortOnType == 0)
                    m_nSortOnType = 1;
                else
                    m_nSortOnType = -m_nSortOnType;
                m_nSortOnName = 0;
            }
            RefillSansDelai();
        }

        private void m_timerOnChangeFiltre_Tick(object sender, EventArgs e)
        {
            m_timerOnChangeFiltre.Stop();
            RefillSansDelai();
        }

        private void m_txtName_TextChanged(object sender, EventArgs e)
        {
            Refill();
        }

        private void m_wndListeTypes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            Refill();
        }

        private void m_chkRecursive_CheckedChanged(object sender, EventArgs e)
        {
            Init(m_root);
        }

        

        private void m_wndListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_wndListe.SelectedItems.Count == 1)
            {
                IDefinition def = m_wndListe.SelectedItems[0].Tag as IDefinition;
                if (def != null && MibNavigator != null)
                {
                    m_bLockUpdate = true;
                    MibNavigator.NavigateTo(def.ModuleName, def.Name);
                    m_bLockUpdate = false;
                }
            }
        }

        private void m_wndListe_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo test = m_wndListe.HitTest(new Point(e.X, e.Y));
            if (test.Item != null && test.Item.Tag is IDefinition)
            {
                IDefinition def = test.Item.Tag as IDefinition;
                if (MibNavigator != null)
                    MibNavigator.NavigateTo(def.ModuleName, def.Name);
                Init(def);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MibNavigator != null)
            {
                IDefinition def = MibNavigator.GetCurrent();
                Init(def);
            }
        }

        private void m_menuListeTypes_Opening(object sender, CancelEventArgs e)
        {
            bool bUnSel = m_wndListeTypes.SelectedItems.Count == 1;
            m_mnuExceptThis.Visible = bUnSel;
            m_mnuOnlyThis.Visible = bUnSel;
            m_mnuSepChecks.Visible = bUnSel;
        }

        private void m_mnuOnlyThis_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in m_wndListeTypes.Items)
                item.Checked = item.Selected;
        }

        private void m_mnuExceptThis_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in m_wndListeTypes.Items)
                item.Checked = !item.Selected;
        }

        private void m_mnuAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in m_wndListeTypes.Items)
                item.Checked = true;
        }

        private void m_mnuNone_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in m_wndListeTypes.Items)
                item.Checked = false;
        }

        private void m_wndListeTypes_MouseClick(object sender, MouseEventArgs e)
        {
            /*ListViewHitTestInfo info = m_wndListe.HitTest(new Point(e.X, e.Y));
            if (info != null && info.Item != null)
                info.Item.Selected = true;*/
        }


    }
}
