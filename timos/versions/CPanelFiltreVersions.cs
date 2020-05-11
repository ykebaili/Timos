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

namespace timos.version
{
	/// <summary>
	/// Description résumée de CPanelFiltreVersions.
	/// </summary>
	public class CPanelFiltreVersions : System.Windows.Forms.UserControl, IControlDefinitionFiltre
	{
		private CFiltreData m_filtre;
		private sc2i.win32.common.CComboboxAutoFilled m_cmbTypeVersion;
		private System.Windows.Forms.Label label1;
        private sc2i.win32.common.CExtStyle m_extStyle;
        private bool m_bComboInit = false;

		public event EventHandler OnAppliqueFiltre;
		/// <summary> 
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;
		//-------------------------------------------------------------------
		public CPanelFiltreVersions()
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
            this.m_cmbTypeVersion = new sc2i.win32.common.CComboboxAutoFilled();
            this.label1 = new System.Windows.Forms.Label();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.SuspendLayout();
            // 
            // m_cmbTypeVersion
            // 
            this.m_cmbTypeVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeVersion.IsLink = false;
            this.m_cmbTypeVersion.ListDonnees = null;
            this.m_cmbTypeVersion.Location = new System.Drawing.Point(151, 5);
            this.m_cmbTypeVersion.LockEdition = false;
            this.m_cmbTypeVersion.Name = "m_cmbTypeVersion";
            this.m_cmbTypeVersion.NullAutorise = true;
            this.m_cmbTypeVersion.ProprieteAffichee = null;
            this.m_cmbTypeVersion.Size = new System.Drawing.Size(242, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeVersion.TabIndex = 1;
            this.m_cmbTypeVersion.TextNull = I.T("(All)|30313");
            this.m_cmbTypeVersion.Tri = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 18);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 2;
            this.label1.Text = "Version Type|1420";
            // 
            // CPanelFiltreVersions
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_cmbTypeVersion);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CPanelFiltreVersions";
            this.Size = new System.Drawing.Size(456, 40);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.Load += new System.EventHandler(this.CPanelFiltreVersions_Load);
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
			ctx["FiltreTypeVersion"] = m_cmbTypeVersion.SelectedValue;
		}
		//-------------------------------------------------------------------
		public void InitFromContexte ( CContexteFormNavigable ctx )
		{
            m_cmbTypeVersion.SelectedValue = (CTypeVersion)ctx["FiltreTypeVersion"];
		}
		//-------------------------------------------------------------------
		private void CPanelFiltreVersions_Load(object sender, System.EventArgs e)
		{
            sc2i.win32.common.CWin32Traducteur.Translate(this);
            InitCombos();
                      
		}

        //-------------------------------------------------------------------
        private void InitCombos()
		{
			if ( m_bComboInit )
				return;
			//m_cmbTypeVersion.ProprieteAffichee = "Libelle";
            //m_cmbTypeVersion.ListDonnees = CUtilSurEnum.GetEnumsALibelle(typeof(CTypeVersion));
            m_cmbTypeVersion.Fill(
                CUtilSurEnum.GetEnumsALibelle(typeof(CTypeVersion)),
                "Libelle",
                true);

            m_bComboInit = true;
		}
		
		//-----------------------------------------------------------------
		public bool ShouldShow()
		{
			return true;
		}

        //-----------------------------------------------------------------
        public void AppliquerFiltre()
		{
            
            if (m_cmbTypeVersion.SelectedValue is CTypeVersion)
            {
                Filtre = new CFiltreData(
                    CVersionDonnees.c_champTypeVersion + " = @1",
                    ((CTypeVersion)m_cmbTypeVersion.SelectedValue).CodeInt);
            }
            else
            {
                Filtre = new CFiltreData ();
            }

			OnAppliqueFiltre(new object(), null);
		}

        //--------------------------------------------------------------------------------
        public void AffecteValeursToNewObjet(CObjetDonnee objet)
		{
			if ( objet is CVersionDonnees && m_cmbTypeVersion.SelectedValue is CTypeVersion )
			{
				((CVersionDonnees)objet).TypeVersion = (CTypeVersion)m_cmbTypeVersion.SelectedValue;
			}
		}

        //-------------------------------------------------------------------------------
        private int GetNumVersion()
		{
			return 0;
		}

        //--------------------------------------------------------------------------------
        public CResultAErreur SerializeFiltre(C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
			if(  !result )
				return result;

            int nCodeTypeVersion = -1;
			if ( m_cmbTypeVersion.SelectedValue is CTypeVersion )
				nCodeTypeVersion = ((CTypeVersion)m_cmbTypeVersion.SelectedValue).CodeInt;
			serializer.TraiteInt ( ref nCodeTypeVersion);
            if (serializer.Mode == ModeSerialisation.Lecture)
            {
                InitCombos();
                m_cmbTypeVersion.SelectedValue = new CTypeVersion((CTypeVersion.TypeVersion)nCodeTypeVersion);
            }
            return result;
		}

	}
}
