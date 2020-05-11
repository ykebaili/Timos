using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using sc2i.common;
using sc2i.data;
using sc2i.win32.data;
using sc2i.win32.data.navigation;
using sc2i.win32.navigation;
using sc2i.data.dynamic;

using sc2i.process;

namespace timos
{
	/// <summary>
	/// Description résumée de CPanelFiltreComportementGenerique.
	/// </summary>
	public class CPanelFiltreComportementGenerique : System.Windows.Forms.UserControl, IControlDefinitionFiltre
	{
		private CFiltreData m_filtre;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.CComboboxAutoFilled m_cmbTypeElements;

		public event EventHandler OnAppliqueFiltre;
		/// <summary> 
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;
		//-------------------------------------------------------------------
        public CPanelFiltreComportementGenerique()
		{
			// Cet appel est requis par le Concepteur de formulaires Windows.Forms.
			InitializeComponent();
		}
		//-------------------------------------------------------------------
		/// <summary> 
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		//-------------------------------------------------------------------
		#region Component Designer generated code
		/// <summary> 
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.m_cmbTypeElements = new sc2i.win32.common.CComboboxAutoFilled();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_cmbTypeElements
            // 
            this.m_cmbTypeElements.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeElements.IsLink = false;
            this.m_cmbTypeElements.ListDonnees = null;
            this.m_cmbTypeElements.Location = new System.Drawing.Point(176, 5);
            this.m_cmbTypeElements.LockEdition = false;
            this.m_cmbTypeElements.Name = "m_cmbTypeElements";
            this.m_cmbTypeElements.NullAutorise = true;
            this.m_cmbTypeElements.ProprieteAffichee = null;
            this.m_cmbTypeElements.Size = new System.Drawing.Size(344, 21);
            this.m_cmbTypeElements.TabIndex = 1;
            this.m_cmbTypeElements.TextNull = "(All)|30313";
            this.m_cmbTypeElements.Tri = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Element Type|822";
            // 
            // CPanelFiltreComportementGenerique
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_cmbTypeElements);
            this.Name = "CPanelFiltreComportementGenerique";
            this.Size = new System.Drawing.Size(696, 40);
            this.Load += new System.EventHandler(this.CPanelFiltreComportementGenerique_Load);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------
		public CFiltreData Filtre
		{
			get
			{
				return m_filtre;
			}
			set
			{
				m_filtre = value;
			}
		}
		//-------------------------------------------------------------------
		public int MinHeight
		{
			get
			{
				return 56;
			}
		}
		//-------------------------------------------------------------------
		public void FillContexte ( CContexteFormNavigable ctx )
		{
			ctx["TypeElement"] = m_cmbTypeElements.SelectedValue;
		}
		//-------------------------------------------------------------------
		public void InitFromContexte ( CContexteFormNavigable ctx )
		{
			m_cmbTypeElements.SelectedValue	= (Type)ctx["TypeElement"];
		}
		//-------------------------------------------------------------------
		private void CPanelFiltreComportementGenerique_Load(object sender, System.EventArgs e)
		{
			InitComboType();
		}

		
		//-----------------------------------------------------------------
		public bool ShouldShow()
		{
			return true;
		}

		public void AppliquerFiltre()
		{
			Filtre = new CFiltreData(  );
			if ( m_cmbTypeElements.SelectedValue is Type && m_cmbTypeElements.SelectedValue != typeof ( DBNull ))
			{
				Filtre.Filtre = CComportementGenerique.c_champTypeElementCible+"=@1";
				Filtre.Parametres.Add ( m_cmbTypeElements.SelectedValue.ToString());
			}
			OnAppliqueFiltre(new object(), null);
		}

		/// ////////////////////////////////////////////////////////////////////
		public void AffecteValeursToNewObjet ( CObjetDonnee objet )
		{
			if ( objet is CComportementGenerique && m_cmbTypeElements.SelectedValue is Type && m_cmbTypeElements.SelectedValue != typeof(DBNull) )
			{
				((CComportementGenerique)objet).TypeCible = (Type)m_cmbTypeElements.SelectedValue;
			}
		}

		/// ////////////////////////////////////////////////////////////////////
		private int GetNumVersion()
		{
			return 0;
		}

		/// ////////////////////////////////////////////////////////////////////
		public CResultAErreur SerializeFiltre ( C2iSerializer serializer )
		{
			InitComboType();
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
			if(  !result )
				return result;
			bool bHasType = m_cmbTypeElements.SelectedValue is Type && m_cmbTypeElements.SelectedValue != typeof(DBNull);
			serializer.TraiteBool ( ref bHasType );
			if ( bHasType )
			{
				Type tp = (Type)m_cmbTypeElements.SelectedValue;
				serializer.TraiteType ( ref tp );
				if ( tp != null )
					m_cmbTypeElements.SelectedValue = tp;
			}
			else
				m_cmbTypeElements.SelectedValue = null;
			return result;
		}

		//-------------------------------------------------------------------------
		private CResultAErreur InitComboType()
		{
			CResultAErreur result = CResultAErreur.True;
		
			ArrayList classes = new ArrayList(DynamicClassAttribute.GetAllDynamicClass());
			classes.Add ( new CInfoClasseDynamique ( typeof(DBNull), "Aucun"));
			m_cmbTypeElements.DataSource = null;
			m_cmbTypeElements.DataSource = classes;
			m_cmbTypeElements.ValueMember = "Classe";
			m_cmbTypeElements.DisplayMember = "Nom";
			return result;
		}

	}
}
