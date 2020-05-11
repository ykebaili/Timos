using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using futurocom.easyquery;
using sc2i.drawing;
using futurocom.sig;
using sc2i.common;

namespace futurocom.win32.sig
{
    [AutoExec("Autoexec")]
    public partial class CControleEditeMapRouteFromQuery : UserControl, IControleEditeMapItem, IControlALockEdition
    {
        private CMapRouteFromQuery m_mapRouteFromQuery = null;

        //---------------------------------------------------------------
        public CControleEditeMapRouteFromQuery()
        {
            InitializeComponent();
        }

        //---------------------------------------------------------------
        public static void Autoexec()
        {
            CAllocateurInterfaceMapItemGenerator.RegisterControle(
                typeof(CMapRouteFromQuery), typeof(CControleEditeMapRouteFromQuery));
        }

        //---------------------------------------------------------------
        private void m_cmbTable_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RefreshComboChamps();
        }

        
        private void m_tabControl_SelectionChanged(object sender, EventArgs e)
        {
            FillCombos();
        }

        //---------------------------------------------------------------
        private void FillCombos()
        {
            List<string> lstTables = new List<string>();
            if (m_panelQuery.Query != null)
            {
                foreach (I2iObjetGraphique obj in m_panelQuery.Query.Childs)
                {
                    IObjetDeEasyQuery table = obj as IObjetDeEasyQuery;
                    if (table != null)
                    {
                        lstTables.Add(table.NomFinal);
                    }
                }
            }
            string strLabel = m_cmbTable.Text;
            m_cmbTable.BeginUpdate();
            m_cmbTable.Items.Clear();
            m_cmbTable.Items.AddRange(lstTables.ToArray());
            m_cmbTable.EndUpdate();
            m_cmbTable.Text = strLabel;
            RefreshComboChamps();
        }

        //---------------------------------------------------------------
        private void RefreshComboChamps()
        {
            List<string> lstChamps = new List<string>();
            if (m_cmbTable.Text != "" && m_panelQuery.Query != null)
            {
                IObjetDeEasyQuery table = null;
                foreach (I2iObjetGraphique obj in m_panelQuery.Query.Childs)
                {
                    table = obj as IObjetDeEasyQuery;
                    if (table != null && table.NomFinal == m_cmbTable.Text)
                        break;
                    else
                        table = null;
                }
                if (table != null)
                {
                    foreach (IColumnDeEasyQuery col in table.Columns)
                    {
                        lstChamps.Add(col.ColumnName);
                    }
                }
            }
            UpdateCombo(m_cmbLatitude, lstChamps);
            UpdateCombo(m_cmbLongitude, lstChamps);
            UpdateCombo(m_cmbGroupBy, lstChamps);
            UpdateCombo(m_cmbLabel, lstChamps);
        }

        //----------------------------------------------------------------
        private void UpdateCombo(ComboBox box, List<string> champs)
        {
            string strText = box.Text;
            box.BeginUpdate();
            box.Items.Clear();
            box.Items.AddRange(champs.ToArray());
            box.EndUpdate();
            box.Text = strText;
        }



        //------------------------------------------------------------------------
        public void InitChamps(futurocom.sig.IMapItemGenerator item)
        {
            CMapRouteFromQuery route = item as CMapRouteFromQuery;
            m_mapRouteFromQuery = route;
            if (route != null)
            {
                m_tabControl.Visible = true;
                
                m_panelQuery.Init(route.Query);
                FillCombos();
                m_txtLibelle.Text = route.Libelle;
                m_cmbTable.Text = route.NomTableSource;
                m_cmbGroupBy.Text = route.ChampCleElement;
                m_cmbLabel.Text = route.ChampLibelle;
                m_cmbLatitude.Text = route.ChampLatitude;
                m_cmbLongitude.Text = route.ChampLongitude;
                m_txtDistancePoint.DoubleValue = route.MetresEntrePoints;
            }
            else
                m_tabControl.Visible = false;
        }

        //------------------------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if ( m_mapRouteFromQuery != null )
            {
                m_mapRouteFromQuery.Libelle = m_txtLibelle.Text;
                m_mapRouteFromQuery.Query = m_panelQuery.Query;
                m_mapRouteFromQuery.NomTableSource = m_cmbTable.Text;
                m_mapRouteFromQuery.ChampCleElement = m_cmbGroupBy.Text;
                m_mapRouteFromQuery.ChampLatitude = m_cmbLatitude.Text;
                m_mapRouteFromQuery.ChampLibelle = m_cmbLabel.Text;
                m_mapRouteFromQuery.ChampLongitude = m_cmbLongitude.Text;
                if ( m_txtDistancePoint.DoubleValue != null )
                    m_mapRouteFromQuery.MetresEntrePoints = m_txtDistancePoint.DoubleValue.Value;
                else
                    m_mapRouteFromQuery.MetresEntrePoints = 100;
            }
            return result;
        }


        //------------------------------------------------------------------------
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
                    OnChangeLockEdition(this, null);
            }
        }

        //---------------------------------------------------------------
        public IMapItemGenerator CurrentGenerator
        {
            get
            {
                return m_mapRouteFromQuery;
            }
        }

        public event EventHandler OnChangeLockEdition;

    }
}
