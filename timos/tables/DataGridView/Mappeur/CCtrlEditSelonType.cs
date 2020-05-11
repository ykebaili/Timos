using System;
using System.Threading;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using sc2i.common;

namespace timos.tables
{

	/// <summary>
	/// Supporte :
	/// 
	///  --  TYPE  --  COLL  --
	/// 
	///		String		X
	///		Bool		X
	///		DateTime	X
	///		Int			
	///		Double
	/// </summary>
	public partial class CCtrlEditSelonType : UserControl, IDataGridViewEditingControl
	{

		internal enum ModeFonctionnement
		{ 
			Texte,
			Entier,
			Decimal,
			Date,
			Bool,
		}

		private string m_strTextTrue = "";
		private string m_strTextFalse = "";


		public CCtrlEditSelonType()
		{
			InitializeComponent();
			m_strTextFalse = I.T("False|1377");
			m_strTextTrue = I.T("True|1376");
		}


		public bool Initialiser(object o, Type t)
		{
			m_lastVal = null;
			m_defaultVal = null;

			if (t == null)
				m_type = o.GetType();
			else
				m_type = t;

			if (m_type == null || !SetModeFonctionnement() || !InitControl())
				return false;


			SetValue(o);

			if (m_mode == ModeFonctionnement.Texte)
			{
				m_textBox.SelectionStart = 0;
				m_textBox.SelectionLength = m_textBox.Text.Length;
			}
			return true;
		}

		private ModeFonctionnement m_mode;

		private CTextBoxZoomable m_textBox;
		//private CheckBox m_checkBox;
		private ComboBox m_cmbBool;
		private DateTimePicker m_dateTimePicker;
		private C2iTextBoxNumerique m_textBoxNumerique;


		private Type m_type;
		private bool SetModeFonctionnement()
		{
			if (m_type == typeof(string))
				m_mode = ModeFonctionnement.Texte;
			else if (m_type == typeof(bool))
				m_mode = ModeFonctionnement.Bool;
			else if (m_type == typeof(DateTime))
				m_mode = ModeFonctionnement.Date;
			else if (m_type == typeof(int))
				m_mode = ModeFonctionnement.Entier;
			else if (m_type == typeof(double))
				m_mode = ModeFonctionnement.Decimal;
			else
				return false;

			return true;
		}
		private bool InitControl()
		{
			try
			{
				for (int i = Controls.Count; i > 0; i--)
					Controls[i - 1].Dispose();

				Control ctrl = null;
				switch (m_mode)
				{
					case ModeFonctionnement.Texte:
						m_textBox = new CTextBoxZoomable();
						m_textBox.Text = DefaultValueSelonType.ToString();
						m_textBox.KeyDown += new KeyEventHandler(m_textBox_KeyDown);
						m_textBox.TextChanged += new EventHandler(m_control_ValueChanged);
						ctrl = m_textBox;
						break;
					case ModeFonctionnement.Entier:
					case ModeFonctionnement.Decimal:
						m_textBoxNumerique = new C2iTextBoxNumerique();
						m_textBoxNumerique.NullAutorise = true;
						m_textBoxNumerique.SelectAllOnEnter = true;
						m_textBoxNumerique.DecimalAutorise = (m_mode == ModeFonctionnement.Decimal);
						if (m_mode == ModeFonctionnement.Decimal)
							m_textBoxNumerique.Arrondi = 8;
						else
							m_textBoxNumerique.Arrondi = 0;
						m_textBoxNumerique.TextChanged += new EventHandler(m_control_ValueChanged);
						ctrl = m_textBoxNumerique;
						
						break;
					case ModeFonctionnement.Date:
						m_dateTimePicker = new DateTimePicker();
						m_dateTimePicker.Format = DateTimePickerFormat.Short;
						m_dateTimePicker.Value = (DateTime)DefaultValueSelonType;
						m_dateTimePicker.ValueChanged += new EventHandler(m_control_ValueChanged);
						ctrl = m_dateTimePicker;
						break;
					case ModeFonctionnement.Bool:
						m_cmbBool = new ComboBox();
						m_cmbBool.DropDownStyle = ComboBoxStyle.DropDownList;
						m_cmbBool.Items.Add(I.T("Is Null|96"));
						m_cmbBool.Items.Add(m_strTextFalse);
						m_cmbBool.Items.Add(m_strTextTrue);
						m_cmbBool.SelectedIndexChanged += new EventHandler(m_control_ValueChanged);
						m_cmbBool.SelectedIndex = 0;
						ctrl = m_cmbBool;
						break;
					default:
						break;
				}


				Controls.Add(ctrl);
				ctrl.Dock = DockStyle.Fill;
				ctrl.BringToFront();
				return true;
			}
			catch
			{
				return false;
			}

		}
		
		//-------------------------------------------------------------------
		void m_control_ValueChanged(object sender, EventArgs e)
		{
			m_bValueChanged = true;
			if(EditingControlDataGridView != null)
				EditingControlDataGridView.NotifyCurrentCellDirty(true);
			if (ChangementValeur != null)
				ChangementValeur(this, new EventArgs());
		}

		void m_textBox_KeyDown(object sender, KeyEventArgs e)
		{
			if ( e.KeyCode == Keys.Up )
			{
				m_dgv.Focus();
				SendKeys.Send ( Keys.Up+"");
				e.Handled = false;
			}
		}

		public Control ControlEdition
		{
			get
			{
				switch (m_mode)
				{
					case ModeFonctionnement.Texte:
						return m_textBox;
					case ModeFonctionnement.Entier:
					case ModeFonctionnement.Decimal:
						return m_textBoxNumerique;
					case ModeFonctionnement.Date:
						return m_dateTimePicker;
					case ModeFonctionnement.Bool:
						return m_cmbBool;
					default:
						return null;
				}
			}
		}



		//Valeur par Defaut
		private object m_lastVal;
		private object m_defaultVal;
		public object DefaultValue
		{
			get
			{
				if (m_defaultVal != null && m_defaultVal != DBNull.Value)
					return m_defaultVal;
				else
					return DefaultValueSelonType;
			}
			set
			{
				m_defaultVal = value;
			}
		}
		public object DefaultValueSelonType
		{
			get
			{
				switch (m_mode)
				{
					case ModeFonctionnement.Texte:
						return "";
					case ModeFonctionnement.Entier:
					case ModeFonctionnement.Decimal:
						return 0;
					case ModeFonctionnement.Date:
						return DateTime.Now;
					case ModeFonctionnement.Bool:
						return false;
					default:
						return null;
				}
			}
		}
		public static object GetDefaultValue(Type t)
		{
			if (t == typeof(string))
				return "";
			else if (t == typeof(bool))
				return false;
			else if (t == typeof(DateTime))
				return DateTime.Now;
			else if (t == typeof(int) || t == typeof(double))
				return 0;
			else
				return null;
		}


		//Lecture Ecriture
		private bool m_bValueChanged = false;
		
		public object Valeur
		{
			get
			{
				return GetValue();
			}
			set
			{
				SetValue(value);
			}
		}

	
		private bool SetValue(object val)
		{
			if (!SetValInControlWithoutEvent(val))
				return false;

			if(ChangementValeur != null)
				ChangementValeur(this, new EventArgs());
			return true;


		}
		private object GetValue()
		{
			switch (m_mode)
			{
				case ModeFonctionnement.Texte:			return m_textBox != null?m_textBox.Text:null;
				case ModeFonctionnement.Entier:
					try
					{
						return m_textBoxNumerique != null ? (object)m_textBoxNumerique.IntValue : null;
					}
					catch
					{
						m_textBoxNumerique.IntValue = 0;
						return 0;
					}
				case ModeFonctionnement.Decimal:		
					return m_textBoxNumerique != null?(object)m_textBoxNumerique.DoubleValue:null;
				case ModeFonctionnement.Date:			
					return m_dateTimePicker != null?(object)m_dateTimePicker.Value:null;
				case ModeFonctionnement.Bool:
					if (m_cmbBool == null || m_cmbBool.SelectedIndex == 0 )
						return null;
					return m_cmbBool.SelectedIndex == 2;
				default:								return null;
			}
		}
		


		//Evenement
		public event EventHandler ChangementValeur;

		//-----------------------------------------------------------	
		private bool SetValInControlWithoutEvent(object val)
		{
			bool bSet = true;
			try
			{
				switch (m_mode)
				{
					case ModeFonctionnement.Texte:
						if (val != null)
							m_textBox.Text = val.ToString();
						else
							m_textBox.Text = null;
						break;
					case ModeFonctionnement.Entier:
						if (val is int)
							m_textBoxNumerique.IntValue = (int)val;
						else if (val is string)
							m_textBoxNumerique.Text = (string)val;
						else
							m_textBoxNumerique.IntValue = null;
						break;
					case ModeFonctionnement.Decimal:
						if (val is double)
							m_textBoxNumerique.DoubleValue = (double)val;
						else if (val is string)
							m_textBoxNumerique.Text = (string)val;
						else
							m_textBoxNumerique.DoubleValue = null;
						break;
					case ModeFonctionnement.Date:
						if (val is DateTime)
							m_dateTimePicker.Value = DateTime.Parse(val.ToString().Trim());
						else if (val is string)
							m_dateTimePicker.Text = (string)val;
						break;
					case ModeFonctionnement.Bool:
						if (val is bool)
							m_cmbBool.SelectedIndex = (bool)val ? 2 : 1;
						else if (val is string)
						{
							string strVal = (string)val;
							if (strVal == m_strTextTrue)
								m_cmbBool.SelectedIndex = 2;
							else if (strVal == m_strTextFalse)
								m_cmbBool.SelectedIndex = 1;
							else
							{
								try
								{
									bool bVal = Boolean.Parse(strVal);
									m_cmbBool.SelectedIndex = bVal ? 2 : 1;
								}
								catch
								{
									m_cmbBool.SelectedIndex = 0;
								}
							}
						}
						else m_cmbBool.SelectedIndex = 0;						
						break;
					default:
						bSet = true;
						break;
						}
			}
			catch 
			{
				bSet = false;
			}
			m_lastVal = val;

			return bSet;
		}
		#region IDataGridViewEditingControl Membres
		private int m_rowIndex;
		private DataGridView m_dgv;


		public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
		{
		}
		public DataGridView EditingControlDataGridView
		{
			get
			{
				return m_dgv;
			}
			set
			{
				m_dgv = value;
			}
		}
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


		//Défini si c'est le control d'édition ou le DataGridView qui doit traiter la touche
		//retourne vrai si la touche doit être gérer par le control
		//Bizarement le Enter est tout de même traité par le DGV
		public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
		{
			TextBox txtBox = null;
			CTextBoxZoomable txtBoxZoomable = null;
			if (m_mode == ModeFonctionnement.Texte)
				txtBoxZoomable = m_textBox;
			if (m_mode == ModeFonctionnement.Decimal ||
				m_mode == ModeFonctionnement.Entier)
				txtBox = m_textBoxNumerique;

			switch (keyData)
			{
				case Keys.Escape:
					return false;
				case Keys.Up :
				case Keys.Down :
					if (m_mode == ModeFonctionnement.Entier ||
						m_mode == ModeFonctionnement.Decimal ||
						m_mode == ModeFonctionnement.Texte)
						return false;
					return true;
				case Keys.Right :
					if (txtBox != null && txtBox.SelectionStart == txtBox.Text.Length)
						return false;
					if (txtBoxZoomable != null && txtBoxZoomable.SelectionStart == txtBoxZoomable.Text.Length)
						return false;
					if (m_mode == ModeFonctionnement.Bool)
						return false;
					return true;
				case Keys.Left :
					if (txtBox != null && txtBox.SelectionStart == 0 && txtBox.SelectionLength == 0)
						return false;
					if (txtBoxZoomable != null && txtBoxZoomable.SelectionStart == 0 && txtBoxZoomable.SelectionLength == 0)
						return false;
					if (m_mode == ModeFonctionnement.Bool)
						return false;
					return true;
					
				default:
					return true;
			}
		}
		public Cursor EditingPanelCursor
		{
			get 
			{
				return base.Cursor;
			}
		}
		public int EditingControlRowIndex
		{
			get
			{
				return m_rowIndex;
			}
			set
			{
				m_rowIndex = value;
			}
		}

	

		public void PrepareEditingControlForEdit(bool selectAll)
		{
			
		}
		public bool RepositionEditingControlOnValueChange
		{
			get 
			{
				return false;
			}
		}
		public object EditingControlFormattedValue
		{
			get
			{
				return GetValue();
			}
			set
			{
				SetValue(value);
			}
		}

		public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
		{
			object val = EditingControlFormattedValue;
			if (val == null || val == DBNull.Value)
				return null;
			else if (val is DateTime)
				return ((DateTime)val).ToShortDateString();
			else
				return val.ToString();
		}

		private void CCtrlEditSelonType_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(ControlEdition != null)
				ControlEdition.Focus();
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
		#endregion
	}
}
