using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using timos.data;
using testGrilleSites;
using sc2i.common;
using sc2i.win32.common;

namespace timos.interventions
{
    public partial class CControleEditePeriodes : UserControl, IControlALockEdition
    {
        private CContrat m_contrat = null;
        private enum ETypeContenuColonne
        {
            dateDebut,
            dateFin,
            IdPeriode
        }

        private DataTable m_dataTable = null;
        private DateTime m_dateFiltrePeriodes = DateTime.Now;
        private CFaciliteurEditionPeriodesSiteTypeTicket m_faciliteurEditePeriode = null;

        private Dictionary<CTypeTicketContrat, DataColumn> m_dicColsDebut = new Dictionary<CTypeTicketContrat, DataColumn>();
        private Dictionary<CTypeTicketContrat, DataColumn> m_dicColsFin = new Dictionary<CTypeTicketContrat, DataColumn>();
        private Dictionary<CTypeTicketContrat, DataColumn> m_dicColsIdSitePeriode = new Dictionary<CTypeTicketContrat, DataColumn>();

        private Dictionary<CTypeTicketContrat, DataGridViewColumn[]> m_dicColsParTypeTicket = new Dictionary<CTypeTicketContrat,DataGridViewColumn[]>();
            

        public CControleEditePeriodes()
        {
            InitializeComponent();
        }

        private void InitDataSet()
        {
            m_dataTable = new DataTable("SITES");
            m_dataTable.Columns.Add("SITE_ID", typeof(int));
            m_dataTable.Columns.Add("SITE_LABEL", typeof(string));
            foreach (CTypeTicketContrat tt in m_faciliteurEditePeriode.TypesTickets)
            {
                DataColumn col = new DataColumn(tt.TypeTicket.Libelle + " START", typeof(DateTime));
                col.AllowDBNull = true;
                col.ExtendedProperties[typeof(CTypeTicketContrat)] = tt;
                col.ExtendedProperties[typeof(ETypeContenuColonne)] = ETypeContenuColonne.dateDebut;
                m_dataTable.Columns.Add(col);
                m_dicColsDebut[tt] = col;

                col = new DataColumn(tt.TypeTicket.Libelle + " END", typeof(DateTime));
                col.AllowDBNull = true;
                col.ExtendedProperties[typeof(CTypeTicketContrat)] = tt;
                col.ExtendedProperties[typeof(ETypeContenuColonne)] = ETypeContenuColonne.dateFin;
                m_dataTable.Columns.Add(col);
                m_dicColsFin[tt] = col;

                col = new DataColumn(tt.TypeTicket.Libelle + "TypeTicket_Site_Periode_Id", typeof(int));
                col.AllowDBNull = true;
                col.ExtendedProperties[typeof(CTypeTicketContrat)] = tt;
                col.ExtendedProperties[typeof(ETypeContenuColonne)] = ETypeContenuColonne.IdPeriode;
                m_dataTable.Columns.Add(col);
                m_dicColsIdSitePeriode[tt] = col;
            }
            foreach (CSite site in m_faciliteurEditePeriode.Sites)
            {
                DataRow row = m_dataTable.NewRow();
                row["SITE_ID"] = site.Id;
                row["SITE_LABEL"] = site.Libelle;
                m_dataTable.Rows.Add(row);
                foreach (CTypeTicketContrat typeTicket in m_faciliteurEditePeriode.TypesTickets)
                {
                    CTypeTicketContrat_Site ts = typeTicket.GetRelationSite ( site.Id );
                    if (ts != null)
                    {
                        CTypeTicketContrat_Site_Periode tp = ts.GetPeriodeFor(m_dateFiltrePeriodes);
                        if (tp != null)
                        {
                            row[m_dicColsDebut[typeTicket]] = tp.DateDebut;
                            row[m_dicColsFin[typeTicket]] = tp.DateFin;
                            row[m_dicColsIdSitePeriode[typeTicket]] = tp.Id;
                        }
                    }
                }
            }
        }

        public bool MajChamps()
        {
            if (m_contrat == null)
                return true;
            if (m_faciliteurEditePeriode == null || !m_extModeEdition.ModeEdition)
                return true;
            bool bHasErrors = false;
            foreach (CTypeTicketContrat tt in m_faciliteurEditePeriode.TypesTickets)
            {
                if (tt.IsValide())
                {
                    try
                    {
                        DataColumn colDateDebut = m_dicColsDebut[tt];
                        DataColumn colDateFin = m_dicColsFin[tt];
                        DataColumn colIdPeriode = m_dicColsIdSitePeriode[tt];
                        foreach (DataRow row in m_dataTable.Rows)
                        {
                            if (row.RowState == DataRowState.Modified)
                            {
                                int nIdSite = (int)row["SITE_ID"];
                                DateTime? dateDebut = null;
                                DateTime? dateFin = null;
                                int? nIdPeriode = null;

                                if (row[colDateDebut] != DBNull.Value)
                                    dateDebut = (DateTime)row[colDateDebut];
                                if (row[colDateFin] != DBNull.Value)
                                    dateFin = (DateTime)row[colDateFin];
                                if (row[colIdPeriode] != DBNull.Value)
                                    nIdPeriode = (int)row[colIdPeriode];

                                row.SetColumnError(colDateDebut, "");
                                row.SetColumnError(colDateFin, "");

                                if ((dateDebut == null) != (dateFin == null))
                                {
                                    if (dateDebut == null)
                                        row.SetColumnError(colDateDebut, I.T("Incomplet period|20235"));
                                    if (dateFin == null)
                                        row.SetColumnError(colDateFin, I.T("Incomplet period|20235"));
                                    bHasErrors = true;
                                    continue;
                                }
                                if (dateDebut != null && dateFin != null && dateDebut.Value > dateFin.Value)
                                {
                                    row.SetColumnError(colDateDebut, I.T("Invalid period|20236"));
                                    row.SetColumnError(colDateFin, I.T("Invalid period|20236"));
                                    bHasErrors = true;
                                    continue;
                                }
                                if (dateDebut != null && dateFin != null && (dateDebut > m_dateFiltrePeriodes || dateFin < m_dateFiltrePeriodes))
                                {
                                    row.SetColumnError(colDateDebut, I.T("Periode should contains @1|20237", m_dateFiltrePeriodes.ToString("d")));
                                    row.SetColumnError(colDateFin, I.T("Periode should contains @1|20237", m_dateFiltrePeriodes.ToString("d")));
                                    bHasErrors = true;
                                    continue;
                                }
                                if (!bHasErrors)
                                {
                                    if (dateDebut == null && dateFin == null && nIdPeriode != null)
                                    {
                                        //Suppression de la periode
                                        tt.RemovePeriode(nIdSite, nIdPeriode.Value);

                                    }
                                    if (dateDebut != null && dateFin != null)
                                    {
                                        //Création ou mise à jour de la periode
                                        CTypeTicketContrat_Site_Periode tsp = tt.SetPeriode(nIdSite, nIdPeriode, dateDebut.Value, dateFin.Value);
                                        row[colIdPeriode] = tsp.Id;
                                        foreach (CTypeTicketContrat_Site_Periode tsExistante in tsp.TypeTicketContrat_Site.Periodes)
                                        {
                                            if (tsExistante.Id != tsp.Id && tsExistante.DateDebut <= tsp.DateFin &&
                                                tsExistante.DateFin >= tsp.DateDebut)
                                            {
                                                row.SetColumnError(colDateDebut, I.T("Periode is in conflict with another period|20242"));
                                                row.SetColumnError(colDateFin, I.T("Periode is in conflict with another period|20242"));
                                                bHasErrors = true;
                                                continue;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
            if ( !bHasErrors )
                InitDataSet();
            return !bHasErrors;
        }


        public void Init( CContrat contrat)
        {
            m_contrat = contrat;
            if (m_contrat == null)
            {
                Visible = false;
                return;
            }
            using (CWaitCursor waiter = new CWaitCursor())
            {
                Visible = true;
                m_faciliteurEditePeriode = new CFaciliteurEditionPeriodesSiteTypeTicket();
                m_faciliteurEditePeriode.InitFromContrat(contrat);
                m_dtFiltre.Value = m_dateFiltrePeriodes;
                InitDataSet();

                m_dataTable.AcceptChanges();
                m_grid.AutoGenerateColumns = false;
                m_grid.AllowUserToAddRows = false;
                m_grid.Columns.Clear();
                DataGridViewTextBoxColumn colTxt = new DataGridViewTextBoxColumn();
                colTxt.ReadOnly = true;
                colTxt.HeaderText = "Site";
                colTxt.DataPropertyName = "SITE_LABEL";
                m_grid.Columns.Add(colTxt);

                DataTable table = m_dataTable;
                int nCpt = 0;
                Color couleur = Color.FromArgb(255, 200, 200);
                m_dicColsParTypeTicket.Clear();
                foreach (DataColumn col in table.Columns)
                {
                    CTypeTicketContrat tt = col.ExtendedProperties[typeof(CTypeTicketContrat)] as CTypeTicketContrat;
                    if (tt != null)
                    {
                        ETypeContenuColonne? typeContenu = col.ExtendedProperties[typeof(ETypeContenuColonne)] as ETypeContenuColonne?;
                        if (typeContenu != null && (typeContenu.Value == ETypeContenuColonne.dateDebut ||
                            typeContenu.Value == ETypeContenuColonne.dateFin))
                        {
                            if ((typeContenu == ETypeContenuColonne.dateDebut))
                            {
                                couleur = nCpt % 2 == 0 ? Color.FromArgb(255, 200, 200) : Color.FromArgb(200, 255, 200);
                                nCpt++;
                            }
                            CDataGridViewDateTimeColumn colDt = new CDataGridViewDateTimeColumn();
                            colDt.HeaderText = typeContenu.Value == ETypeContenuColonne.dateDebut ? I.T("Start|20239") : I.T("End|20240");
                            colDt.DefaultCellStyle.BackColor = couleur;
                            colDt.DataPropertyName = col.ColumnName;
                            colDt.Width = 80;
                            m_grid.Columns.Add(colDt);
                            DataGridViewColumn[] cols = null;
                            if (!m_dicColsParTypeTicket.TryGetValue(tt, out cols))
                            {
                                cols = new DataGridViewColumn[2];
                                m_dicColsParTypeTicket[tt] = cols;
                            }
                            if (typeContenu.Value == ETypeContenuColonne.dateDebut)
                                cols[0] = colDt;
                            else
                                cols[1] = colDt;
                        }
                    }
                }
                m_grid.DataSource = m_dataTable;
                m_grid.ReadOnly = !m_extModeEdition.ModeEdition;
                m_panelTypeTicketHeader.Refresh();
            }
        }

        private void m_grid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            m_panelTypeTicketHeader.Invalidate();
        }

        private void RedrawTypeTicketHeader(Graphics g)
        {
            if (DesignMode)
                return;
            try
            {
                foreach (KeyValuePair<CTypeTicketContrat, DataGridViewColumn[]> kv in m_dicColsParTypeTicket)
                {
                    int nLeft = m_grid.GetColumnDisplayRectangle(kv.Value[0].Index,true).Left;
                    int nRight = m_grid.GetColumnDisplayRectangle(kv.Value[1].Index, true).Right;
                    if (nRight - nLeft > 0)
                    {
                        Rectangle rct = new Rectangle(nLeft,
                            0,
                            nRight - nLeft,
                            m_panelTypeTicketHeader.Height);
                        g.FillRectangle(Brushes.White, rct);
                        g.DrawRectangle(Pens.Black, rct);
                        TextRenderer.DrawText ( g, kv.Key.TypeTicket.Libelle, Font, rct, Color.Black, 
                            TextFormatFlags.HorizontalCenter |
                            TextFormatFlags.VerticalCenter |
                            TextFormatFlags.WordBreak );
                        //g.DrawString(kv.Key.Libelle, Font, Brushes.Black, rct, ,);
                    }
                }
            }
            catch
            {
            }

                
        }


        private void m_panelTypeTicketHeader_Paint(object sender, PaintEventArgs e)
        {
            RedrawTypeTicketHeader(e.Graphics);
        }

        private void m_grid_Scroll(object sender, ScrollEventArgs e)
        {
            m_panelTypeTicketHeader.Invalidate();
        }

        private void AfficheHistorique()
        {
            m_panelInfoSite.Visible = false;
            DataGridViewCell cell = m_grid.CurrentCell;
            if (m_grid.SelectedCells.Count == 1 && cell != null )
            {
                DataRowView rowView = m_grid.CurrentRow.DataBoundItem as DataRowView;
                if ( rowView != null )
                {
                    DataRow row = rowView.Row;
                    int nCol = cell.ColumnIndex;
                    DataColumn col = m_dataTable.Columns[m_grid.Columns[nCol].DataPropertyName];
                    if ( col != null )
                    {
                        CTypeTicketContrat tt = col.ExtendedProperties[typeof(CTypeTicketContrat)] as CTypeTicketContrat;
                        if ( tt != null )
                        {
                            int nIdSite = (int)row["SITE_ID"];
                            CSite site = m_faciliteurEditePeriode.GetSite ( nIdSite );
                            m_lblSite.Text = site.Libelle;
                            m_lblTypeTicket.Text = tt.TypeTicket.Libelle;
                            m_panelInfoSite.Visible = true;
                            CTypeTicketContrat_Site ts = tt.GetRelationSite(nIdSite);
                            FillHistorique(ts==null?null:(CTypeTicketContrat_Site_Periode[])ts.Periodes.ToArray(typeof(CTypeTicketContrat_Site_Periode)));
                            return;
                            
                        }
                    }
                }
            }
            
        }

        private void FillHistorique(CTypeTicketContrat_Site_Periode[] periodes)
        {
            if (periodes == null)
            {
                m_gridHistorique.DataSource = null;
                m_gridHistorique.Visible = false;
            }
            else
            {
                m_gridHistorique.Visible = true;
                m_gridHistorique.Columns.Clear();
                m_gridHistorique.AutoGenerateColumns = false;

                CDataGridViewDateTimeColumn colDt = new CDataGridViewDateTimeColumn();
                colDt.HeaderText = I.T("Start|20239");
                colDt.Width = 80;
                colDt.DataPropertyName = "DateDebut";
                m_gridHistorique.Columns.Add(colDt);

                colDt = new CDataGridViewDateTimeColumn();
                colDt.HeaderText = I.T("End|20240");
                colDt.Width = 80;
                colDt.DataPropertyName = "DateFin";
                m_gridHistorique.Columns.Add(colDt);
                m_gridHistorique.DataSource = periodes;
                m_gridHistorique.ReadOnly = !m_extModeEdition.ModeEdition;
            }
        }
                

        private void m_grid_CurrentCellChanged(object sender, EventArgs e)
        {
            AfficheHistorique();
        }

        private void m_gridHistorique_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CTypeTicketContrat_Site_Periode periode = ((CTypeTicketContrat_Site_Periode[])m_gridHistorique.DataSource)[e.RowIndex] as CTypeTicketContrat_Site_Periode;
            if (periode != null)
            {
                DataRowView rowView = m_grid.CurrentRow.DataBoundItem as DataRowView;
                if (rowView != null)
                {
                    DataRow row = rowView.Row;
                    CTypeTicketContrat typeTicket = periode.TypeTicketContrat_Site.TypeTicket_Contrat;
                    object val = row[m_dicColsIdSitePeriode[typeTicket]];
                    if ( val is int && ((int)(val)) == periode.Id )
                    {
                        row[m_dicColsDebut[typeTicket]] = periode.DateDebut;
                        row[m_dicColsFin[typeTicket]] = periode.DateFin;
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
            }
        }

        public event EventHandler OnChangeLockEdition;

        #endregion

        private void m_lnkChangePeriode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool bOk = MajChamps();
            if (!bOk)
            {
                m_dtFiltre.Value = m_dateFiltrePeriodes;
            }
            else
            {
                m_dateFiltrePeriodes = m_dtFiltre.Value.Date;
                InitDataSet();
                m_dataTable.AcceptChanges();
                m_grid.DataSource = m_dataTable;

            }
        }
    }

    
}
