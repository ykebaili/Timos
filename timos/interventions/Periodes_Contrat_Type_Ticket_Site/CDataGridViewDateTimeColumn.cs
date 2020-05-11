using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace timos.interventions
{
    public class CDataGridViewDateTimeColumn : DataGridViewColumn
    {

        public CDataGridViewDateTimeColumn()
        {
            CellTemplate = new CDataGridViewDateTimeCell();
        }
    }
}
