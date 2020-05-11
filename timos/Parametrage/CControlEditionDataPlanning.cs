using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.multitiers.client;
using sc2i.win32.data;
using sc2i.data;
using sc2i.common;
using sc2i.win32.common;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.workflow;

using timos.data;
using timos.acteurs;

namespace timos
{

    ////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TypeElementEdite"></typeparam>
    public partial class CControlEditionDataPlanning :
                            UserControl,
                            IControlALockEdition,
                            IDataGridViewEditingControl
    {

        private DataGridView m_dataGridView;
        private bool m_bValueChanged = false;
        private int m_nRowIndex;

        private CDataPlanning m_dataPlanning;



        //-------------------------------------------------------------------------
        public CControlEditionDataPlanning()
        {
            InitializeComponent();

        }

        //-------------------------------------------------------------------------
        public CResultAErreur InitControl(CDataPlanning dataPlanning)
        {
            CResultAErreur result = CResultAErreur.True;
            if (dataPlanning == null)
            {
                CActeur acteur = null;
                dataPlanning = new CDataPlanning(typeof(CActeur), acteur);
            }
            m_dataPlanning = dataPlanning;

            CFiltreData filtre = null;

            if (m_dataGridView.Tag is CFiltreData)
                filtre = (CFiltreData)m_dataGridView.Tag;
            
            m_txtSelectElement.InitForSelectAvecFiltreDeBase(
                dataPlanning.TypeElement,
                "Libelle",
                filtre,
                true);

            m_txtSelectElement.ElementSelectionne = (CObjetDonnee) dataPlanning.Element;

            return result;
        }


        //-------------------------------------------------------------------------
        public CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = CResultAErreur.True; 

            //m_dataPlanning.Element = (IElementDataDeTableauPlanning)m_selectElement.ElementSelectionne;
            //m_bValueChanged = true;
            //if (m_dataGridView != null)
            //    m_dataGridView.NotifyCurrentCellDirty(true);

            return result;
        }


        //-----------------------------------------------------------------------------
        #region IControlALockEdition Membres

        public bool LockEdition
        {
            get
            {
                return !m_gestionnaireModeEdition.ModeEdition;
            }
            set
            {
                m_gestionnaireModeEdition.ModeEdition = !value;

                if (OnChangeLockEdition != null)
                    OnChangeLockEdition(this, new EventArgs());
            }
        }

        public event EventHandler OnChangeLockEdition;

        #endregion


        #region IDataGridViewEditingControl Membres

        //-----------------------------------------------------------------------------
        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;
        }

        //-----------------------------------------------------------------------------
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

        //-----------------------------------------------------------------------------
        public object EditingControlFormattedValue
        {
            get
            {
                return m_dataPlanning;
            }
            set
            {
                m_dataPlanning = (CDataPlanning) value;
            }
        }

        //-----------------------------------------------------------------------------
        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            
            //m_dataGridView.CurrentCell.Tag = m_dataPlanning;
            
            //if (this.m_dataPlanning.Element != null)
            //    return this.m_dataPlanning.Element.Libelle;
            //return "";
            
            return EditingControlFormattedValue;
        }

        //-----------------------------------------------------------------------------
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

        //-----------------------------------------------------------------------------
        public bool EditingControlValueChanged
        {
            get
            {
                return m_bValueChanged;
            }
            set
            {
                m_bValueChanged = value;
            }
        }

        //-----------------------------------------------------------------------------
        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            return false;
        }

        //-----------------------------------------------------------------------------
        public Cursor EditingPanelCursor
        {
            get { return m_txtSelectElement.Cursor; }
        }


        //-----------------------------------------------------------------------------
        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // Rien à faire
        }

        //-----------------------------------------------------------------------------
        public bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }

        #endregion


        //-----------------------------------------------------------------------------
        private void m_selectElement_EnabledChanged(object sender, EventArgs e)
        {
        }

        private void m_selectElement_ElementSelectionneChanged(object sender, EventArgs e)
        {
            m_dataPlanning.Element = (IElementDataDeTableauPlanning)m_txtSelectElement.ElementSelectionne;
            m_bValueChanged = true;
            if (m_dataGridView != null)
                m_dataGridView.NotifyCurrentCellDirty(true);

        }

        //-----------------------------------------------------------------------------
        private void CControlEditionDataPlanning_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                SendKeys.Send(e.KeyChar + "");
                if (EditingControlDataGridView != null)
                    EditingControlDataGridView.NotifyCurrentCellDirty(true);
                m_bValueChanged = true;
            }
            catch
            { }
        }
    }


    /////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 
    /// </summary>
    public class CTableauPlanningColumn : DataGridViewColumn
    {
        public CTableauPlanningColumn()
            : base(new CTableauPlanningCell())
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // S'assure que la cellule utilisée est un CDataPlanningCell
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(CTableauPlanningCell)))
                {
                    CFormAlerte.Afficher(I.T("The edition control is not the right one|30205"), EFormAlerteType.Erreur);
                }
                base.CellTemplate = value;
            }
        }
    }



    /////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="typeElementEdite"></typeparam>
    public class CTableauPlanningCell : DataGridViewTextBoxCell
    {
        
        public CTableauPlanningCell()
            : base()
        {
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            
            CControlEditionDataPlanning ctl = DataGridView.EditingControl as CControlEditionDataPlanning;
            

            if (this.Value == DBNull.Value || this.Value == null)
                this.Value = new CDataPlanning(typeof(CActeur), null);
            ctl.InitControl((CDataPlanning)this.Value);
            
        }

        public override void DetachEditingControl()
        {
            base.DetachEditingControl();
            CControlEditionDataPlanning ctl = DataGridView.EditingControl as CControlEditionDataPlanning;
            ctl.MAJ_Champs();            
        }

        public override Type EditType
        {
            get
            {
                // Return the type of the editing contol that CalendarCell uses.
                return typeof(CControlEditionDataPlanning);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that CalendarCell contains.
                return typeof(CDataPlanning);
            }
        }
        
        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            //return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);

            if (value is CDataPlanning)
            {
                CDataPlanning data = (CDataPlanning)value;
                if(data.Element != null)
                    return data.Element.Libelle;
            }
            return value;
        }


        public override object ParseFormattedValue(object formattedValue, DataGridViewCellStyle cellStyle, TypeConverter formattedValueTypeConverter, TypeConverter valueTypeConverter)
        {
            //return base.ParseFormattedValue(formattedValue, cellStyle, formattedValueTypeConverter, valueTypeConverter);

            return formattedValue;
        }


        public override bool KeyEntersEditMode(KeyEventArgs e)
        {
            return base.KeyEntersEditMode(e);
        }
    }

}
