using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using timos.data.projet.gantt;
using sc2i.common;
using sc2i.win32.common;
using System.Collections;
using sc2i.formulaire.win32;

namespace timos.win32.gantt
{

    public partial class CTimeBar : UserControl, IFournisseurXGantt
    {
        private CParametresAffichageGantt m_parametreAffichage = new CParametresAffichageGantt();
        private bool m_bIsDragging = false;
        private EventHandler m_fonctionOnChangeParametre = null;
        private bool m_bAllowChangeDefaultUnit = false;

        public CTimeBar()
        {
            m_fonctionOnChangeParametre = new EventHandler(OnChangeParametre);
            InitializeComponent();
            CWin32Traducteur.Translate(m_menuEchelle);
        }

        public CParametresAffichageGantt ParametreAffichage
        {
            get
            {
                return m_parametreAffichage;
            }
            set
            {
                if (m_parametreAffichage != null)
                    m_parametreAffichage.OnChangeParametrage -= m_fonctionOnChangeParametre;
                m_parametreAffichage = value;
                m_parametreAffichage.OnChangeParametrage += m_fonctionOnChangeParametre;

            }
        }

        public bool AllowChangeDefaultUnit
        {
            get
            {
                return m_bAllowChangeDefaultUnit;
            }
            set
            {
                m_bAllowChangeDefaultUnit = value;
            }
        }

        public void OnChangeParametre(object sender, EventArgs args)
        {
            if (sender == m_parametreAffichage)
                Refresh();
        }


        public DateTime DateFin
        {
            get
            {
                return ParametreAffichage.CalcDateFin(ClientSize.Width);
            }
        }

        private void CTimeBar_Paint(object sender, PaintEventArgs e)
        {
            DateTime dateDebut = ParametreAffichage.DateDebut;
            if (m_bIsDragging)
                dateDebut = m_dateDragEnCours;
            SolidBrush brFond = new SolidBrush(BackColor);
            e.Graphics.FillRectangle(brFond, ClientRectangle);
            //Divise en 2 verticalement
            Pen pen = new Pen(ForeColor);
            int nYSeparation = ClientSize.Height / 2;
            e.Graphics.DrawLine(pen, 0, nYSeparation, ClientSize.Width, nYSeparation);
            int nX = 0;
            DateTime dt = dateDebut;
            DateTime lastDateEntete = dateDebut;
            Brush brTexte = new SolidBrush(ForeColor);
            while (nX < ClientSize.Width)
            {
                Rectangle rct = new Rectangle(nX, nYSeparation + 1, nX + ParametreAffichage.CellWidth, ClientSize.Height - nYSeparation - 2);
                e.Graphics.FillRectangle(brFond, rct);
                e.Graphics.DrawRectangle(pen, rct);
                string strTexteEntete = "";
                string strTextCell = "";
                DateTime oldDate = dt;
                switch (ParametreAffichage.Unit)
                {
                    case EGanttTimeUnit.Hour:
                        if (lastDateEntete.Day != dt.Day || nX == 0)
                        {
                            strTexteEntete = dt.ToShortDateString();
                        }
                        strTextCell = dt.Hour.ToString("00") + ":00";
                        break;
                    case EGanttTimeUnit.Day:
                        if (lastDateEntete.Month != dt.Month || nX == 0)
                        {
                            strTexteEntete = dt.ToString("MMM yy");
                        }
                        strTextCell = dt.ToString("ddd").Substring(0, 1).ToUpper() + " " + dt.ToString("dd");
                        break;
                    case EGanttTimeUnit.Semaine:
                        if (dt.Month != lastDateEntete.Month)
                        {
                            strTexteEntete = dt.ToString("MMM yyyy");
                        }
                        strTextCell = CUtilDate.GetWeekNum(dt).ToString();
                        break;
                    case EGanttTimeUnit.Mois :
                        if (dt.Year != lastDateEntete.Year)
                            strTexteEntete = dt.Year.ToString();
                        strTextCell = dt.ToString("MMM");
                        break;
                }


                if (strTexteEntete.Length > 0)
                {
                    e.Graphics.FillRectangle(brFond, nX, 0, ClientSize.Width, nYSeparation - 1);
                    e.Graphics.DrawLine(pen, new Point(nX, 0), new Point(nX, nYSeparation));
                    e.Graphics.DrawString(strTexteEntete, Font, brTexte, new Point(nX, 1));
                    lastDateEntete = oldDate;
                }

                if (dt < DateTime.Now && ParametreAffichage.AddCells(dt, 1) > DateTime.Now)
                {
                    Brush brFondCell = new SolidBrush(Color.LightGray);
                    e.Graphics.FillRectangle(brFondCell, new Rectangle(nX + 1, nYSeparation + 1, ParametreAffichage.CellWidth - 1, ClientSize.Height - 2));
                    brFondCell.Dispose();
                }

                e.Graphics.DrawString(strTextCell, Font, brTexte, new Point(nX, nYSeparation + 1));
                nX += ParametreAffichage.CellWidth;

                dt = ParametreAffichage.AddCells(dt, 1);
            }
            brTexte.Dispose();
            pen.Dispose();
            brFond.Dispose();
        }

        private DateTime m_dateDebutDrag;
        private DateTime m_dateDragEnCours;
        private int m_nXStartDrag = 0;
        private void CTimeBar_MouseMove(object sender, MouseEventArgs e)
        {

            if (m_bIsDragging)
            {
                Cursor = Cursors.Hand;
                int nEcart = -((e.X - m_nXStartDrag) / ParametreAffichage.CellWidth) * ParametreAffichage.PrecisionUnit;
                DateTime newDate = ParametreAffichage.AddUnits(ParametreAffichage.DateDebut, nEcart);
                m_dateDragEnCours = newDate;
                Refresh();
            }
            else
                Cursor = Cursors.Arrow;
        }



        DateTime? m_dateClickBeforeMenu = null;
        private int? m_nXClicklBeforeMenu = null;
        private void CTimeBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (m_bIsDragging)
            {
                m_parametreAffichage.DateDebut = m_dateDragEnCours;
                Capture = false;
                m_bIsDragging = false;
            }
            if ((e.Button & MouseButtons.Right) == MouseButtons.Right)
            {
                Point pt = new Point(e.X, e.Y);
                m_dateClickBeforeMenu = GetDateCell ( e.X );
                m_nXClicklBeforeMenu = e.X;
                pt = PointToScreen(pt);
                m_menuEchelle.Show(pt);
            }
        }

        private void CTimeBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (!m_bIsDragging && (e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                m_nXStartDrag = e.X;
                m_dateDebutDrag = ParametreAffichage.DateDebut;
                Capture = true;
                m_bIsDragging = true;
                Cursor = Cursors.Hand;
            }
        }

        private void RecentreFrom(int ?nX, DateTime ?dateCorrespondante)
        {
            if (nX == null || dateCorrespondante == null)
                return;
            DateTime dtStart = m_parametreAffichage.DateDebut;
            DateTime dtPos = GetDateCell(nX.Value);
            TimeSpan spToPos = dtPos - dtStart;
            m_parametreAffichage.DateDebut = dateCorrespondante.Value - spToPos;

        }

        private void m_menuHeure_Click(object sender, EventArgs e)
        {
            if (ParametreAffichage.Unit != EGanttTimeUnit.Hour)
            {
                ParametreAffichage.Unit = EGanttTimeUnit.Hour;
                ParametreAffichage.PrecisionUnit = 1;
                RecentreFrom(m_nXClicklBeforeMenu, m_dateClickBeforeMenu);
            }
        }

        private void m_menuJour_Click(object sender, EventArgs e)
        {
            if (ParametreAffichage.Unit != EGanttTimeUnit.Day)
            {
                ParametreAffichage.Unit = EGanttTimeUnit.Day;
                ParametreAffichage.PrecisionUnit = 1;
                RecentreFrom(m_nXClicklBeforeMenu, m_dateClickBeforeMenu);
            }
        }

        private void m_menuSemaine_Click(object sender, EventArgs e)
        {
            if (ParametreAffichage.Unit != EGanttTimeUnit.Semaine)
            {
                ParametreAffichage.Unit = EGanttTimeUnit.Semaine;
                ParametreAffichage.PrecisionUnit = 1;
                RecentreFrom(m_nXClicklBeforeMenu, m_dateClickBeforeMenu);
            }
        }

        private void m_menuMois_Click(object sender, EventArgs e)
        {
            if (ParametreAffichage.Unit != EGanttTimeUnit.Mois)
            {
                ParametreAffichage.Unit = EGanttTimeUnit.Mois;
                ParametreAffichage.PrecisionUnit = 1;
                RecentreFrom(m_nXClicklBeforeMenu, m_dateClickBeforeMenu);
            }
        }


        public int GetX(DateTime dt)
        {
            DateTime dateFin = ParametreAffichage.CalcDateFin(ClientSize.Width);
            DateTime dateDebut = ParametreAffichage.DateDebut;
            TimeSpan spTotal = dateFin - ParametreAffichage.DateDebut;
            TimeSpan spX = dt - ParametreAffichage.DateDebut;
            double fRatioX = spX.TotalHours / spTotal.TotalHours;
            return (int)((ClientSize.Width) * fRatioX);
        }

        /// <summary>
        /// Retourne les limites X d'un élément de gantt
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public int[] GetXBounds(IElementDeGantt element)
        {
            return new int[]{
                GetX ( element.DateDebut ),
                GetX ( element.DateFin )
            };
        }

        //---------------------------------------------
        /// <summary>
        /// Retourne la date de début de la cellule correspondant à X
        /// </summary>
        /// <param name="nX"></param>
        /// <returns></returns>
        public DateTime GetDateCell(int nX)
        {
            DateTime dateDebut = ParametreAffichage.DateDebut;
            int nCell = nX / ParametreAffichage.CellWidth;
            return ParametreAffichage.AddCells(dateDebut, nCell);
        }

        //---------------------------------------------
        public void Highlight(int nXStart, int nXEnd)
        {
            Refresh();
            if (nXEnd < 0)
                return;

            Rectangle rct = new Rectangle(nXStart, ClientSize.Height / 2, nXEnd - nXStart, ClientSize.Height / 2);
            Brush br = new SolidBrush(Color.FromArgb(50, 0, 0, 255));
            Graphics g = CreateGraphics();
            g.FillRectangle(br, rct);
            g.Dispose();
            br.Dispose();
        }

        //---------------------------------------------
        public DateTime AddCells(DateTime date, int nNbCells)
        {
            return ParametreAffichage.AddCells(date, nNbCells);
        }

        //---------------------------------------------
        private class CMenuPrecision : ToolStripMenuItem
        {
            private int m_nPrecision = 1;
            public CMenuPrecision(int nPrecision) :
                base(nPrecision.ToString())
            {
                m_nPrecision = nPrecision;
            }

            public int Precision
            {
                get
                {
                    return m_nPrecision;
                }
            }
        }

        private void precisionToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                foreach (ToolStripMenuItem subItem in new ArrayList(item.DropDownItems))
                {
                    subItem.Dispose();
                }
                item.DropDownItems.Clear();
                foreach (int nVal in ParametreAffichage.GetPrecisionsPossibles())
                {
                    CMenuPrecision menuPrecision = new CMenuPrecision(nVal);
                    item.DropDownItems.Add(menuPrecision);
                    menuPrecision.Click += new EventHandler(menuPrecision_Click);
                }
            }
        }


        void menuPrecision_Click(object sender, EventArgs e)
        {
            CMenuPrecision menu = sender as CMenuPrecision;
            if (menu != null)
            {
                ParametreAffichage.PrecisionUnit = menu.Precision;
                RecentreFrom(m_nXClicklBeforeMenu, m_dateClickBeforeMenu);
            }
        }

        public delegate void ApplyAsDefaultScaleEventHandler(EGanttTimeUnit unit, int nPrecision);

        public event ApplyAsDefaultScaleEventHandler OnApplyAsDefaultScale;

        private void m_menuApplyAsDefaultScale_Click(object sender, EventArgs e)
        {
            if (OnApplyAsDefaultScale != null)
                OnApplyAsDefaultScale(m_parametreAffichage.Unit, m_parametreAffichage.PrecisionUnit);
        }

        private void m_menuEchelle_Opening(object sender, CancelEventArgs e)
        {
            m_menuApplyAsDefaultScale.Visible = m_bAllowChangeDefaultUnit;
        }

        
    }
}
