using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace timos.interventions
{
    public class CDataGridViewDateTimeCell : DataGridViewTextBoxCell
    {

        protected override void Paint(
            Graphics graphics,
            Rectangle clipBounds,
            Rectangle cellBounds,
            int rowIndex,
            DataGridViewElementStates cellState,
            object value,
            object formattedValue,
            string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            string strDisplay = "";
            if (value is DateTime && ((DateTime)value) != DateTime.MinValue)
            {
                strDisplay = ((DateTime)value).ToString("d");
            }
            base.Paint(graphics, clipBounds, cellBounds,
                rowIndex, cellState,
                value, strDisplay, errorText, cellStyle,
                advancedBorderStyle, paintParts);

            


        }



        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            CDateTimePickerNullable ctrl = DataGridView.EditingControl as CDateTimePickerNullable;
            if (ctrl != null && Value is DateTime)
                ctrl.Value = (DateTime)Value;
            else
                ctrl.Value = DateTime.MinValue;
        }

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, System.ComponentModel.TypeConverter valueTypeConverter, System.ComponentModel.TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            if (value is DateTime)
                return ((DateTime)value).ToString("d");
            return "";
            //return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
        }

        public override Type EditType
        {
            get
            {
                return typeof(CDateTimePickerNullable);
            }
        }

        public override object ParseFormattedValue(object formattedValue, DataGridViewCellStyle cellStyle, System.ComponentModel.TypeConverter formattedValueTypeConverter, System.ComponentModel.TypeConverter valueTypeConverter)
        {
            if (formattedValue is DateTime)
                return formattedValue;
            else
                return DBNull.Value;
            
        }
    }
}
