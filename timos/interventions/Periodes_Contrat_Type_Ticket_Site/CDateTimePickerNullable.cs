//----------------------------------------------------------------------------------
// - Author			   - Pham Minh Tri
// - Last Updated      - 19/Nov/2003
//----------------------------------------------------------------------------------
// - Component:        - Nullable DateTimePicker
// - Version:          - 1.0
// - Description:      - A datetimepicker that allow null value.
//----------------------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace timos.interventions
{
    /// <summary>
    /// Summary description for DateTimePicker.
    /// </summary>
    public class CDateTimePickerNullable : System.Windows.Forms.DateTimePicker, IDataGridViewEditingControl
    {
        private DateTimePickerFormat oldFormat = DateTimePickerFormat.Long;

        private string oldCustomFormat = null;
        private bool bIsNull = false;

        public CDateTimePickerNullable()
            : base()
        {
            Format = DateTimePickerFormat.Short;
        }

        public new DateTime Value
        {
            get
            {
                if (bIsNull)
                    return DateTime.MinValue;
                else
                    return base.Value;
            }
            set
            {
                if (value == DateTime.MinValue)
                {
                    if (bIsNull == false)
                    {
                        oldFormat = this.Format;
                        oldCustomFormat = this.CustomFormat;
                        bIsNull = true;
                    }

                    this.Format = DateTimePickerFormat.Custom;
                    this.CustomFormat = "(none)";
                }
                else
                {
                    if (bIsNull)
                    {
                        this.Format = oldFormat;
                        this.CustomFormat = oldCustomFormat;
                        bIsNull = false;
                    }
                    base.Value = value;
                }
            }
        }

        protected override void OnCloseUp(EventArgs eventargs)
        {
            if (Control.MouseButtons == MouseButtons.None)
            {
                if (bIsNull)
                {
                    this.Format = oldFormat;
                    this.CustomFormat = oldCustomFormat;
                    bIsNull = false;
                }
            }
            base.OnCloseUp(eventargs);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            //base.OnKeyUp(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            // base.OnKeyDown(e);
            if (e.KeyCode == Keys.Delete)
            {
                this.Value = DateTime.MinValue;
                OnValueChanged(new EventArgs());
            }
           
                
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' && Value == DateTime.MinValue)
            {
                Value = DateTime.Now;
                Refresh();
                SendKeys.Send(e.KeyChar.ToString());
            }
           
            base.OnKeyPress(e);
        }

        #region IDataGridViewEditingControl Membres
        private DataGridView m_dataGridView = null;
        private int m_nRowIndex;
        private bool m_bHasChange = false;

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
        }

        public DataGridView EditingControlDataGridView
        {
            get
            {
                return m_dataGridView;
            }
            set
            {
                m_dataGridView = value;
            }
        }

        public object EditingControlFormattedValue
        {
            get
            {
                if (Value == DateTime.MinValue)
                    return DBNull.Value;
                return Value;
            }
            set
            {
                if (!(value is DateTime))
                    Value = DateTime.MinValue;
                else
                    Value = (DateTime)value;    
            }
        }

        public int EditingControlRowIndex
        {
            get
            {
                return m_nRowIndex;
            }
            set
            {
                m_nRowIndex = value;
            }
        }

        public bool EditingControlValueChanged
        {
            get
            {
                return m_bHasChange;
            }
            set
            {
                m_bHasChange = value;
            }
        }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            if (keyData == Keys.Left || keyData == Keys.Right)
            {
                return true;
            }
            if ( (keyData & Keys.Shift) == Keys.Shift &&
                ((keyData & Keys.Up) == Keys.Up || (keyData & Keys.Down) == Keys.Down))
            {
                    return true;
            }
            return false;
        }

        public Cursor EditingPanelCursor
        {
            get { return base.Cursor; }
        }


        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            DateTime? dt = EditingControlFormattedValue as DateTime? ;

            if ((context & DataGridViewDataErrorContexts.Display) == DataGridViewDataErrorContexts.Display)
            {
                if (dt == null)
                    return "";
                else
                    return dt.Value.ToString("d");
            }
            else
                return dt;
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
            
        }

        public bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }

        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }

        protected override void  OnValueChanged(EventArgs eventargs)
        {
            m_bHasChange = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }

    }
}
