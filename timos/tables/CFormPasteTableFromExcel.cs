using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using sc2i.common;

namespace timos.tables
{
    public partial class CFormPasteTableFromExcel : Form
    {
        private DataTable m_tableToMap = null;

        public class CMapColToColSerializable :Dictionary<string, string>, I2iSerializable
        {
            public const string c_fileSgn = "2ISPREADSHEETMAPFILE";
            private int GetNumVersion()
            {
                return 0;
            }

            public CResultAErreur Serialize(C2iSerializer serializer)
            {
                int nVersion = GetNumVersion();
                CResultAErreur result = serializer.TraiteVersion(ref nVersion);
                if (!result)
                    return result;
                int nCount = Count;
                serializer.TraiteInt(ref nCount);
                switch (serializer.Mode)
                {
                    case ModeSerialisation.Ecriture:
                        foreach (KeyValuePair<string, string> kv in this)
                        {
                            string strKey = kv.Key;
                            string strVal = kv.Value;
                            serializer.TraiteString(ref strKey);
                            serializer.TraiteString(ref strVal);
                        }
                        break;
                    case ModeSerialisation.Lecture:
                        Clear();
                        for (int n = 0; n < nCount; n++)
                        {
                            string strKey = "";
                            string strVal = "";
                            serializer.TraiteString(ref strKey);
                            serializer.TraiteString(ref strVal);
                            this[strKey] = strVal;
                        }
                        break;
                    default:
                        break;
                }
                return result;
            }
                
        }
        private Dictionary<DataColumn, string> m_dicMaps = new Dictionary<DataColumn, string>();
        private bool m_bIsConverted;

        public CFormPasteTableFromExcel()
        {
            InitializeComponent();
            CWin32Traducteur.Translate(this);
        }

        //------------------------------------------------------------------------
        private void UpdatePanelMappage()
        {
            int nCount = 0;
            Dictionary<string, List<DataColumn>> dicStringToCol = new Dictionary<string, List<DataColumn>>();
            foreach (KeyValuePair<DataColumn, string> kv in m_dicMaps)
            {
                if (kv.Value != null)
                {
                    List<DataColumn> lst = null;
                    if (!dicStringToCol.TryGetValue(kv.Value, out lst))
                    {
                        lst = new List<DataColumn>();
                        dicStringToCol[kv.Value] = lst;
                    }
                    lst.Add(kv.Key);
                    nCount++;
                }
            }

            if (nCount == 0 || m_bIsConverted || !(m_grid.DataSource is DataTable))
                m_panelMappage.Visible = false;
            else
            {
                m_panelMappage.SuspendDrawing();
                m_panelMappage.ClearAndDisposeControls();
                int nHeight = 0;
                foreach (DataGridViewColumn header in m_grid.Columns)
                {
                    List<DataColumn> lst = null;
                    if (dicStringToCol.TryGetValue(header.HeaderText, out lst))
                    {
                        int nY = 0;
                        Rectangle rct = m_grid.GetCellDisplayRectangle(header.Index, -1, true);
                        foreach (DataColumn col in lst)
                        {
                            Label lbl = new Label();
                            rct = m_grid.RectangleToScreen(rct);
                            rct = m_panelMappage.RectangleToClient(rct);
                            lbl.Left = rct.Left;
                            lbl.Top = nY;
                            lbl.Width = rct.Width;
                            lbl.Height = rct.Height;
                            lbl.TextAlign = ContentAlignment.MiddleLeft;
                            lbl.BorderStyle = BorderStyle.FixedSingle;
                            lbl.BackColor = m_panelMappage.BackColor;
                            lbl.ForeColor = m_panelMappage.ForeColor;
                            lbl.Text = col.ColumnName;

                            m_panelMappage.Controls.Add(lbl);
                            nY += rct.Height;
                            nHeight = Math.Max(nHeight, nY + 2);
                        }
                    }
                }
                m_panelMappage.ResumeDrawing();
                m_panelMappage.Height = nHeight;
                m_panelMappage.Visible = true;
            }
        }



        //------------------------------------------------------------------------
        public static DataTable PasteFromSpreadSheet(DataTable tableDestination)
        {
            if (tableDestination == null)
                return null;
            CFormPasteTableFromExcel form = new CFormPasteTableFromExcel();
            form.m_tableToMap = tableDestination;
            foreach (DataColumn col in tableDestination.Columns)
            {
                form.m_dicMaps[col] = null;
            }
            DataTable tableRetour = null;
            if ( form.ShowDialog() == DialogResult.OK )
            {
                tableRetour = form.m_tableToMap;
            }
            form.Dispose();
            return tableRetour;
        }
            

        private void m_btnPaste_Click(object sender, EventArgs e)
        {
            if (!Clipboard.ContainsText())
                MessageBox.Show("Nothing to paste");
            m_bIsConverted = false;
            m_btnOk.Enabled = false;
            string strPaste = Clipboard.GetText();
            DataTable table = null;
            try
            {
                table = CUtilTexte.GetDataTableFromExcelPaste(strPaste, m_chkUseFirstRowANames.Checked);
            }
            catch (Exception ex)
            {
                CResultAErreur result = CResultAErreur.True;
                result.EmpileErreur(new CErreurException(ex));
                CFormAlerte.Afficher(result.Erreur);
            }
            /*
                
            string[] strLignes = strPaste.Split('\n');
            DataTable table = new DataTable();
            table.BeginLoadData();
            int nLigne = 0;
            foreach (string strLaLigne in strLignes)
            {
                string strLigne = strLaLigne;
                if ( strLigne.Length > 0 && strLigne[strLigne.Length-1] == '\r')
                    strLigne = strLigne.Substring(0, strLigne.Length-1);
                if (strLigne.Length > 0 && strLigne[0] == '\r')
                    strLigne = strLigne.Substring(1, strLigne.Length - 1);
                string[] strCols = strLigne.Split('\t');
                if (nLigne == 0 && m_chkUseFirstRowANames.Checked)
                {
                    foreach (string strCol in strCols)
                    {
                        try
                        {
                            table.Columns.Add(strCol, typeof(string));
                        }
                        catch
                        {
                            try
                            {
                                table.Columns.Add("Column " + table.Columns.Count + 1, typeof(string));
                            }
                            catch
                            {
                                table.Columns.Add(Guid.NewGuid().ToString(), typeof(string));
                            }
                        }
                    }
                    nLigne++;
                    continue;
                }
                nLigne++;
                while (table.Columns.Count < strCols.Length)
                {
                    table.Columns.Add("Col " + table.Columns.Count + 1, typeof(string));
                }
                DataRow row = table.NewRow();
                int nCol = 0;
                foreach (string strVal in strCols)
                {
                    row[nCol++] = strVal;
                }
                table.Rows.Add(row);
            }
            table.EndLoadData();*/
            if (table != null)
            {
                m_grid.DataSource = table;
                UpdatePanelMappage();
            }
        }

        //---------------------------------------------------------------------------------------------
        int m_nIndexColClick = -1;
        private void m_grid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                m_nIndexColClick = e.ColumnIndex;
                ContextMenuStrip menu = new ContextMenuStrip();
                DataColumn col = ((DataTable)m_grid.DataSource).Columns[m_nIndexColClick];
                foreach (KeyValuePair<DataColumn, string> kv in m_dicMaps)
                {
                    ToolStripMenuItem itemMap = new ToolStripMenuItem(kv.Key.ColumnName);
                    itemMap.Tag = kv.Key;
                    if (kv.Value == col.ColumnName)
                        itemMap.Checked = true;
                    itemMap.Click += new EventHandler(itemMap_Click);
                    menu.Items.Add(itemMap);
                }
                Rectangle rct = m_grid.GetCellDisplayRectangle(e.ColumnIndex, -1, true);
                Point pt = new Point(e.X, e.Y);
                pt.Offset(rct.Left+Cursor.Size.Width, rct.Top+Cursor.Size.Height);
                pt = m_grid.PointToScreen(pt);

                menu.Show(pt);
            }
            
        }

        //---------------------------------------------------------
        void itemMap_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            DataColumn col = item != null ? item.Tag as DataColumn : null;
            if (col != null)
            {
                item.Checked = !item.Checked;
                DataColumn colMap = ((DataTable)m_grid.DataSource).Columns[m_nIndexColClick];
                m_dicMaps[col] = item.Checked ? colMap.ColumnName : null;
            }
            UpdatePanelMappage();
        }

        
        //---------------------------------------------------------
        public void ConvertToTableToMap()
        {
            DataTable table = m_grid.DataSource as DataTable;
            if (table == null)
                return ;
            m_tableToMap.Rows.Clear();
            m_tableToMap.AcceptChanges();
            foreach (DataRow row in table.Rows)
            {
                DataRow newRow = m_tableToMap.NewRow();
                string strErrors = "";
                foreach (KeyValuePair<DataColumn, string> kv in m_dicMaps)
                {
                    if (kv.Value != null && table.Columns.Contains(kv.Value))
                    {
                        string strVal = row[kv.Value] as string;
                        if (strVal == null)
                            newRow[kv.Key] = DBNull.Value;
                        else
                        {
                            Type tp = kv.Key.DataType;
                            if (tp == typeof(string))
                                newRow[kv.Key] = strVal;
                            if (tp == typeof(int))
                            {
                                if (strVal.Trim().Length == 0)
                                    newRow[kv.Key] = DBNull.Value;
                                else
                                {
                                    try
                                    {
                                        newRow[kv.Key] = Int64.Parse(strVal);
                                    }
                                    catch
                                    {
                                        newRow[kv.Key] = DBNull.Value;
                                        strErrors += "Can not convert value '" + strVal + "' to integer";
                                    }
                                }
                            }
                            if (tp == typeof(double))
                            {
                                if (strVal.Trim().Length == 0)
                                    newRow[kv.Key] = DBNull.Value;
                                else
                                {
                                    try
                                    {

                                        newRow[kv.Key] = CUtilDouble.DoubleFromString(strVal);
                                    }
                                    catch
                                    {
                                        newRow[kv.Key] = DBNull.Value;
                                        strErrors += "Can not convert value '" + strVal + "' to décimal number";
                                    }
                                }
                            }
                            if (tp == typeof(DateTime))
                            {
                                if (strVal.Trim().Length == 0)
                                    newRow[kv.Key] = DBNull.Value;
                                else
                                {
                                    try
                                    {
                                        newRow[kv.Key] = DateTime.Parse(strVal);
                                    }
                                    catch
                                    {
                                        newRow[kv.Key] = DBNull.Value;
                                        strErrors += "Can not convert value '" + strVal + "' to date time";
                                    }
                                }
                            }
                            if (tp == typeof(bool))
                            {
                                if (strVal.Trim().Length == 0)
                                    newRow[kv.Key] = DBNull.Value;
                                else
                                {
                                    if (strVal.ToUpper() == "OK" ||
                                        strVal.ToUpper() == "TRUE" ||
                                        strVal.ToUpper() == "1")
                                        newRow[kv.Key] = true;
                                    else
                                        newRow[kv.Key] = false;
                                }
                            }
                        }
                        newRow.SetColumnError(kv.Key, strErrors);
                    }
                }

                m_tableToMap.Rows.Add(newRow);
                


            }
            return ;
        }


        private void m_btnConvert_Click_1(object sender, EventArgs e)
        {   
            
            m_bIsConverted = false;
            try
            {
                ConvertToTableToMap();
                m_grid.DataSource = m_tableToMap;
                m_bIsConverted = true;
                m_btnOk.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void m_btnOk_Click(object sender, EventArgs e)
        {
            if (m_bIsConverted)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void m_grid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            UpdatePanelMappage();
        }

        private void m_grid_DataSourceChanged(object sender, EventArgs e)
        {
            UpdatePanelMappage();
        }

        private void m_btnOk_EnabledChanged(object sender, EventArgs e)
        {
            m_btnOpenConfig.Visible = !m_btnOpenConfig.Enabled;
        }

        private void m_btnSaveConfig_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = I.T("Paste map file|*.2iPasteMap|20825");
            if ( dlg.ShowDialog() == DialogResult.Cancel )
                return;
            CMapColToColSerializable map = new CMapColToColSerializable();
            foreach (KeyValuePair<DataColumn, string> kv in m_dicMaps)
            {
                if (kv.Value != null)
                {
                    map[kv.Key.ColumnName] = kv.Value;
                }
            }
            CResultAErreur result = CSerializerObjetInFile.SaveToFile(map, CMapColToColSerializable.c_fileSgn, dlg.FileName);
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
            }
        }

        private void m_btnOpenConfig_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = I.T("Paste map file|*.2iPasteMap|20825");
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            CMapColToColSerializable map = new CMapColToColSerializable();
            CResultAErreur result = CSerializerObjetInFile.ReadFromFile(map, CMapColToColSerializable.c_fileSgn, dlg.FileName);
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }
            if (m_tableToMap != null)
            {
                foreach (KeyValuePair<string, string> kv in map)
                {
                    DataColumn col = m_tableToMap.Columns[kv.Key];
                    if (col != null)
                        m_dicMaps[col] = kv.Value;
                }
            }
            UpdatePanelMappage();

        }

        private void m_grid_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                UpdatePanelMappage();
            }
        }
    }
}
