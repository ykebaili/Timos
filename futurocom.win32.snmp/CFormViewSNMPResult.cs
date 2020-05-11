using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using futurocom.snmp;
using sc2i.win32.common;
using sc2i.common;

namespace futurocom.win32.snmp
{
    public partial class CFormViewSNMPResult : Form
    {
        private IList<Variable> m_listeVariables = null;
        private string m_strInfoRequete = "";
        private IMibNavigator m_navigateur = null;
        private IObjectTree m_mibTree;

        private List<CInfoResult> m_result = null;

        public CFormViewSNMPResult()
        {
            InitializeComponent();
        }

        public static void ViewResult(
            string strInfoRequete,
            Variable variable,
            IMibNavigator navigateur,
            IObjectTree mibTree)
        {
            List<Variable> lst = new List<Variable>();
            lst.Add(variable);
            ViewResult(strInfoRequete, lst, navigateur, mibTree);
        }


        public static void ViewResult(
            string strInfoRequete, 
            IList<Variable> lstVariables,
            IMibNavigator navigateur,
            IObjectTree mibTree)
        {
            CFormViewSNMPResult form = new CFormViewSNMPResult();
            form.m_listeVariables = lstVariables;
            form.m_strInfoRequete = strInfoRequete;
            form.m_navigateur = navigateur;
            form.m_mibTree = mibTree;
            form.Show();
        }

        private void CFormViewSNMPResult_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
            m_lblRequete.Text = m_strInfoRequete;
            Text = m_strInfoRequete;
            FillGrid();
        }

        private class CInfoResult
        {
            public IDefinition Definition { get; set; }
            public string Oid { get; set; }
            public string Value { get; set; }
            
            public string Name
            {
                get
                {
                if ( Definition != null )
                    return Definition.Name;
                return "";
                }
            }

            public string Index
            {
                get
                {
                    if (Definition != null)
                    {
                        string strOID = ObjectIdentifier.Convert(Definition.GetNumericalForm());
                        return Oid.Replace(strOID, "");
                    }
                    return "";
                }
            }

            
        }


        private void FillGrid()
        {
            m_grid.ReadOnly = true;
            m_result = new List<CInfoResult>();
            if (m_listeVariables == null)
                return;
            foreach ( Variable variable in m_listeVariables )
            {
                CInfoResult info = new CInfoResult();
                if (m_mibTree != null)
                    info.Definition = m_mibTree.FindKnownParent(variable.Id.ToNumerical());
                info.Oid = variable.Id.ToString();
                info.Value = variable.Data != null ? variable.Data.ToString() : "";
                m_result.Add(info);
            }
            m_grid.AutoGenerateColumns = false;

            DataGridViewColumn col = new DataGridViewColumn();
            col.HeaderText = I.T("OID|20001");
            col.CellTemplate = new DataGridViewTextBoxCell();
            col.DataPropertyName = "Oid";
            col.Width = 150;
            m_grid.Columns.Add(col);

            col = new DataGridViewColumn();
            col.HeaderText = I.T("Name|20018");
            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
            col.CellTemplate = linkCell;
            col.DataPropertyName ="Name";
            col.Width = 200;
            m_grid.Columns.Add ( col );

            col = new DataGridViewColumn();
            col.HeaderText = I.T("Index|20043");
            col.DataPropertyName = "Index";
            col.CellTemplate = new DataGridViewTextBoxCell();
            col.Width = 50;
            m_grid.Columns.Add(col);

            
            

            col = new DataGridViewColumn();
            col.HeaderText = I.T("Value|20042");
            col.DataPropertyName = "Value";
            col.CellTemplate = new DataGridViewTextBoxCell();
            col.Width = 200;
            m_grid.Columns.Add ( col );


            m_grid.DataSource = m_result;
        }

        private void m_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                List<CInfoResult> lst = m_grid.DataSource as List<CInfoResult>;
                if (lst != null && e.RowIndex >= 0 && e.RowIndex < lst.Count)
                {
                    CInfoResult info = lst[e.RowIndex];
                    if (info.Definition != null && m_navigateur != null)
                        m_navigateur.NavigateTo(info.Definition.ModuleName, info.Definition.Name);
                }
            }
        }

    }
}
