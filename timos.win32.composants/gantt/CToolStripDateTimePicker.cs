using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace timos.win32.composants.gantt
{
    public class CToolStripDateTimePicker : ToolStripControlHost
    {

        public CToolStripDateTimePicker() 
            : base (new CDateTimePickerForContextMenu())
        {
            sc2i.win32.common.CWin32Traducteur.Translate(Control);
        }

        public CDateTimePickerForContextMenu DateTimePicker
        {
            get
            {
                return Control as CDateTimePickerForContextMenu;
            }
        }

        protected override System.Drawing.Size DefaultSize
        {
            get
            {
                return new System.Drawing.Size(276, 43);
            }
        }

        public DateTime StartDate
        {
            get
            {
                return DateTimePicker.StartDate;
            }
            set
            {
                DateTimePicker.StartDate = value;
            }
        }

        public DateTime EndDate
        {
            get
            {
                return DateTimePicker.EndDate;
            }
            set
            {
                DateTimePicker.EndDate = value;
            }
        }


        protected override void OnSubscribeControlEvents(Control control)
        {
            base.OnSubscribeControlEvents(control);

            CDateTimePickerForContextMenu dtPicker = (CDateTimePickerForContextMenu)control;
            dtPicker.OnValideDates += new EventHandler(dtPicker_OnValueChange);
        }


        protected override void OnUnsubscribeControlEvents(Control control)
        {
            base.OnUnsubscribeControlEvents(control);
            CDateTimePickerForContextMenu dtPicker = (CDateTimePickerForContextMenu)control;
            dtPicker.OnValideDates -= new EventHandler(dtPicker_OnValueChange);

        }

        public event EventHandler OnValideDates;

        void dtPicker_OnValueChange(object sender, EventArgs e)
        {
            if (OnValideDates != null)
                OnValideDates(this, new EventArgs());
        }

    }
}
