using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;

namespace timos.interventions
{
    public class CDataGridViewCopyPaste : DataGridView, IControlALockEdition
    {
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;

        public CDataGridViewCopyPaste()
            : base()
        {
            InitializeComponent();
        }

        //--------------------------------------------------------
        private void InitializeComponent()
        {
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // CDataGridViewCopyPaste
            // 
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CDataGridViewCopyPaste_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void CDataGridViewCopyPaste_KeyDown(object sender, KeyEventArgs e)
        {
            if ( (e.KeyCode == Keys.V && (e.Modifiers & Keys.Control) == Keys.Control) ||
                 (e.KeyCode == Keys.Insert && (e.Modifiers & Keys.Control) == Keys.Shift))
                PasteClipboard();
            if (e.KeyCode == Keys.Delete)
            {
                VideSelection();
            }
        }

        private void VideSelection()
        {
            if (!m_extModeEdition.ModeEdition)
                return;
            foreach (DataGridViewCell cell in SelectedCells)
            {
                try
                {
                    cell.Value = DBNull.Value;
                }
                catch
                {
                }
            }
        }

        private bool SetSafeCellValue(DataGridViewCell cell, object valeur)
        {
            try
            {
                if (cell == null || cell.ReadOnly)
                    return false;
                object val = Convert.ChangeType(valeur, cell.ValueType);
                cell.Value = val;
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void PasteClipboard()
        {
            if ( SelectedCells.Count == 0 )
                return;
            if (!m_extModeEdition.ModeEdition)
                return;
            string strText = Clipboard.GetText();
            //Vérifie que le nombre de lignes et de colonnes du texte est cohérent
            List<string[]> lstDatas = new List<string[]>();
            string[] strLignes = strText.Split('\n');
            int? nNbCols = null;
            foreach ( string strLigne in strLignes )
            {
                if (strLigne.Trim() != "")
                {
                    string[] strCols = strLigne.Split('\t');
                    if (nNbCols != null && nNbCols != strCols.Length)
                        return;//Pas un rectangle
                    nNbCols = strCols.Length;
                    lstDatas.Add(strCols);
                }
            }
            int nNbLignes = lstDatas.Count;

            if (lstDatas.Count == 1 && lstDatas[0].Length == 1)
            {
                //Tout copier sur les cellules sélectionnées
                foreach ( DataGridViewCell cell in SelectedCells )
                {
                    SetSafeCellValue ( cell, lstDatas[0][0] );
                }
            }
            else
            {
                if (SelectedCells.Count == 1)
                {
                    int nLigne = SelectedCells[0].RowIndex;
                    //copie vers le bas droite
                    foreach (string[] strDatas in lstDatas)
                    {
                        int nCol = SelectedCells[0].ColumnIndex;
                        foreach (string strData in strDatas)
                        {
                            try
                            {
                                DataGridViewCell cell = this[nCol, nLigne];
                                SetSafeCellValue(cell, strData);
                            }
                            catch { }
                            nCol++;
                        }
                        nLigne++;
                    }
                }
                else
                {
                    int? nLigneMin = null;
                    int? nColMin = null;
                    int? nLigneMax = null;
                    int? nColMax = null;
                    foreach (DataGridViewCell cell in SelectedCells)
                    {
                        if (nLigneMin == null || cell.RowIndex < nLigneMin)
                            nLigneMin = cell.RowIndex;
                        if (nColMin == null || cell.ColumnIndex < nColMin)
                            nColMin = cell.ColumnIndex;
                        if (nLigneMax == null || cell.RowIndex > nLigneMax)
                            nLigneMax = cell.RowIndex;
                        if (nColMax == null || cell.RowIndex > nColMax)
                            nColMax = cell.ColumnIndex;
                    }
                    foreach (DataGridViewCell cell in SelectedCells)
                    {
                        int nLigne = (cell.RowIndex - nLigneMin.Value)%nNbLignes;
                        int nCol = (cell.ColumnIndex - nColMin.Value)%nNbCols.Value;
                        if (nLigne < lstDatas.Count)
                        {
                            string[] strDatas = lstDatas[nLigne];
                            if (nCol < strDatas.Length)
                            {
                                string strVal = strDatas[nCol];
                                SetSafeCellValue(cell, strVal);
                            }
                        }
                    }
                }

            }

            
        }

        #region IControlALockEdition Membres

        public bool LockEdition
        {
            get
            {
                return !m_extModeEdition.ModeEdition;
            }
            set
            {
                m_extModeEdition.ModeEdition = !value;
                if (OnChangeLockEdition != null)
                    OnChangeLockEdition(this, new EventArgs());
                if (value)
                    ReadOnly = true;
                else
                    ReadOnly = false;

            }
        }

        public event EventHandler OnChangeLockEdition;

        #endregion
    }
}
