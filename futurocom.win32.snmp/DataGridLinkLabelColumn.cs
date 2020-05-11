using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;


namespace futurocom.win32.snmp
{
    public class LinkLabelColumnStyle : DataGridColumnStyle
    {
        #region Eventi
        public event LinkLabelLinkClickedEventHandler LinkClicked;
        #endregion

        #region Variabili
        private System.Windows.Forms.LinkLabel ctrl;
        private StringFormat DrawStringFormat;

        private bool gridAdded;
        #endregion

        public LinkLabelColumnStyle()
        {
            ctrl = new System.Windows.Forms.LinkLabel();
            ctrl.Links.Add(0, 0, null);
            ctrl.LinkClicked += new LinkLabelLinkClickedEventHandler(ctrl_Clicked);

            DrawStringFormat = new StringFormat();
            DrawStringFormat.LineAlignment = StringAlignment.Center;
            base.AlignmentChanged += new EventHandler(DataBoundLinkLabel_AlignmentChanged);

            this.Width = GetPreferredSize(null, null).Width;
        }

        #region Overrides
        #region Modifica dato
        protected override void Abort(int rowNum)
        { HideControl(); }
        protected override bool Commit(CurrencyManager datasource, int rowNum)
        {
            HideControl();
            return true;
        }
        protected override void Edit(CurrencyManager source, int rowNum, Rectangle bounds, bool readOnly, string instantText, bool cellIsVisible)
        {
            this.DataGridTableStyle.DataGrid.Select(rowNum);
            if (cellIsVisible)
                PlaceControl(bounds, source, rowNum);
            else
                HideControl();
        }
        #endregion

        #region Determinazione dimensioni
        protected override int GetMinimumHeight()
        { return ctrl.MinimumSize.Height; }
        protected override int GetPreferredHeight(Graphics g, object value)
        { return ctrl.Size.Height; }
        protected override Size GetPreferredSize(Graphics g, object value)
        { return ctrl.Size; }
        #endregion

        #region Disegno cella
        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum)
        { Paint(g, bounds, source, rowNum, false); }
        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, bool alignToRight)
        { Paint(g, bounds, source, rowNum, Brushes.White, Brushes.Blue, alignToRight); }
        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {
            Color FC, BC;

            if (this.DataGridTableStyle.DataGrid.IsSelected(rowNum))
            {
                FC = this.DataGridTableStyle.SelectionForeColor;
                BC = this.DataGridTableStyle.SelectionBackColor;
            }
            else
            {
                FC = Color.Blue;
                BC = ((rowNum & 1) == 1) ? this.DataGridTableStyle.BackColor : this.DataGridTableStyle.AlternatingBackColor;
            }

            using (SolidBrush B = new SolidBrush(BC))
                g.FillRectangle(B, bounds);

            //TODO: Gestire font sottolineato se necessario.
            using (SolidBrush F = new SolidBrush(FC))
                g.DrawString(GetCellText(rowNum, source), this.DataGridTableStyle.DataGrid.Font, F, bounds, DrawStringFormat);
        }
        #endregion

        protected override void SetDataGridInColumn(DataGrid value)
        {
            base.SetDataGridInColumn(value);
            if (!gridAdded) //viene chiamato due volte (non so perché)
            {
                gridAdded = true;

                ctrl.Parent = value;
                value.Controls.Add(ctrl);

                value.MouseMove += new MouseEventHandler(DataGrid_MouseMove);
                value.DataSourceChanged += new EventHandler(DataGrid_DataSourceChanged);
                value.BindingContextChanged += new EventHandler(DataGrid_BindingContextChanged);
                value.BindingContext[value.DataSource, value.DataMember].PositionChanged += new EventHandler(DataGridBinding_PositionChanged);
            }
        }
        protected override void ConcedeFocus()
        { HideControl(); }
        #endregion

        private void PlaceControl(Rectangle bounds, CurrencyManager source, int rowNum)
        {
            if (DataGridTableStyle.DataGrid.IsSelected(rowNum))
            {
                ctrl.BackColor = this.DataGridTableStyle.SelectionBackColor;
                ctrl.LinkColor = Color.White;
            }
            else
            {
                ctrl.BackColor = ((rowNum & 1) == 1) ? this.DataGridTableStyle.BackColor : this.DataGridTableStyle.AlternatingBackColor;
                ctrl.LinkColor = Color.Blue;
            }
            ctrl.Text = GetCellText(rowNum, source);

            System.Windows.Forms.LinkLabel.Link lnk = ctrl.Links[0];
            lnk.LinkData = source.List[rowNum];
            lnk.Length = ctrl.Text.Length;

            ctrl.Bounds = bounds;
            ctrl.Visible = true;
        }
        private void HideControl()
        {
            if (ctrl.Visible)
            {
                ctrl.Visible = false;
                this.Invalidate();
            }
        }

        private String GetCellText(int rowNum, CurrencyManager source)
        {
            object value = GetColumnValueAtRow(source, rowNum);
            return (value == null) || (value == DBNull.Value) ? NullText : value.ToString();
        }

        #region Gestori eventi interni
        void DataGrid_MouseMove(object sender, MouseEventArgs e)
        {
            DataGrid grd = (DataGrid)sender;
            DataGrid.HitTestInfo hti = grd.HitTest(e.Location);

            if ((hti.Type == DataGrid.HitTestType.Cell) &&
                (hti.Column == grd.TableStyles[this.DataGridTableStyle.MappingName].GridColumnStyles.IndexOf(this))) //Se la colonna è quella corrente
                PlaceControl(grd.GetCellBounds(hti.Row, hti.Column), (CurrencyManager)(grd.BindingContext[grd.DataSource, grd.DataMember]), hti.Row);
            else
                HideControl();
        }
        void DataGrid_DataSourceChanged(object sender, EventArgs e)
        { HideControl(); }
        void DataGrid_BindingContextChanged(object sender, EventArgs e)
        { HideControl(); }
        void DataGridBinding_PositionChanged(object sender, EventArgs e)
        { HideControl(); }

        void DataBoundLinkLabel_AlignmentChanged(object sender, EventArgs e)
        {
            switch (this.Alignment)
            {
                case HorizontalAlignment.Center:
                    {
                        ctrl.TextAlign = ContentAlignment.MiddleCenter;
                        DrawStringFormat.Alignment = StringAlignment.Center;
                        break;
                    }
                case HorizontalAlignment.Left:
                    {
                        ctrl.TextAlign = ContentAlignment.MiddleLeft;

                        //TODO: Gestire RTL
                        DrawStringFormat.Alignment = StringAlignment.Near;
                        break;
                    }
                case HorizontalAlignment.Right:
                    {
                        ctrl.TextAlign = ContentAlignment.MiddleRight;

                        //TODO: Gestire RTL
                        DrawStringFormat.Alignment = StringAlignment.Far;
                        break;
                    }
            }

        }

        private void ctrl_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (LinkClicked != null)
                LinkClicked(sender, e);
        }
        #endregion
    }
}
