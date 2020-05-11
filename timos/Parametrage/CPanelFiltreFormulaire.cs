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

namespace timos
{
	/// <summary>
	/// Description résumée de CPanelFiltreFormulaire.
	/// </summary>
	public class CPanelFiltreFormulaire : System.Windows.Forms.UserControl, IControlDefinitionFiltre
	{
		private CFiltreData m_filtre;
		private sc2i.win32.common.CComboboxAutoFilled m_cmbRole;
		private System.Windows.Forms.Label label1;
        private Label label2;
        private TextBox m_txtLibelle;

		public event EventHandler OnAppliqueFiltre;
		/// <summary> 
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;
		//-------------------------------------------------------------------
		public CPanelFiltreFormulaire()
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
            this.m_cmbRole = new sc2i.win32.common.CComboboxAutoFilled();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // m_cmbRole
            // 
            this.m_cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbRole.IsLink = false;
            this.m_cmbRole.ListDonnees = null;
            this.m_cmbRole.Location = new System.Drawing.Point(96, 6);
            this.m_cmbRole.LockEdition = false;
            this.m_cmbRole.Name = "m_cmbRole";
            this.m_cmbRole.NullAutorise = true;
            this.m_cmbRole.ProprieteAffichee = null;
            this.m_cmbRole.Size = new System.Drawing.Size(242, 21);
            this.m_cmbRole.TabIndex = 1;
            this.m_cmbRole.TextNull = "(All)";
            this.m_cmbRole.Tri = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Role|42";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Label|50";
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.Location = new System.Drawing.Point(96, 37);
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(242, 20);
            this.m_txtLibelle.TabIndex = 4;
            // 
            // CPanelFiltreFormulaire
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.m_txtLibelle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_cmbRole);
            this.Name = "CPanelFiltreFormulaire";
            this.Size = new System.Drawing.Size(456, 71);
            this.Load += new System.EventHandler(this.CPanelFiltreFormulaire_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
			ctx["RoleFormulaire"] = m_cmbRole.SelectedValue;
            ctx["LIBELLE"] = m_txtLibelle.Text;
		}
		//-------------------------------------------------------------------
		public void InitFromContexte ( CContexteFormNavigable ctx )
		{
            m_cmbRole.SelectedValue = (CRoleChampCustom)ctx["RoleFormulaire"];
            m_txtLibelle.Text = (string) ctx["LIBELLE"];

		}
		//-------------------------------------------------------------------
		private void CPanelFiltreFormulaire_Load(object sender, System.EventArgs e)
		{
            sc2i.win32.common.CWin32Traducteur.Translate(this);
            InitCombos();
                      
		}

		private bool m_bComboInit = false;
		private void InitCombos()
		{
			if ( m_bComboInit )
				return;
			m_bComboInit = true;
			m_cmbRole.ProprieteAffichee = "Libelle";
			m_cmbRole.ListDonnees = CRoleChampCustom.Roles;
		}
		
		//-----------------------------------------------------------------
		public bool ShouldShow()
		{
			return true;
		}

		public void AppliquerFiltre()
		{
			Filtre = new CFiltreData(  );
			if ( m_cmbRole.SelectedValue is CRoleChampCustom)
			{
                Filtre = CFormulaire.GetFiltreFormulairesForRole(((CRoleChampCustom)m_cmbRole.SelectedValue).CodeRole);
/*                Filtre.Filtre = CFormulaire.c_champCodeRole + "=@1";
                Filtre.Parametres.Add(((CRoleChampCustom)m_cmbRole.SelectedValue).CodeRole);*/
			}

            if (m_txtLibelle.Text != string.Empty)
            {
                if (Filtre.Filtre != string.Empty)
                    Filtre.Filtre += " AND " + CFormulaire.c_champLibelle + " LIKE @2";
                else
                    Filtre.Filtre = CFormulaire.c_champLibelle + " LIKE @1";
                
                Filtre.Parametres.Add("%" + m_txtLibelle.Text + "%");
            }


			OnAppliqueFiltre(new object(), null);
		}

		/// ////////////////////////////////////////////////////////////////////
		public void AffecteValeursToNewObjet ( CObjetDonnee objet )
		{
			if ( objet is CFormulaire && m_cmbRole.SelectedValue is CRoleChampCustom )
			{
				((CFormulaire)objet).Role = (CRoleChampCustom)m_cmbRole.SelectedValue;
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
			InitCombos();
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
			if(  !result )
				return result;
			string strCodeRole = "";
			if ( m_cmbRole.SelectedValue is CRoleChampCustom )
				strCodeRole = ((CRoleChampCustom)m_cmbRole.SelectedValue).CodeRole;
			serializer.TraiteString ( ref strCodeRole );
			m_cmbRole.SelectedValue = CRoleChampCustom.GetRole ( strCodeRole );
			return result;
		}

	}
}
