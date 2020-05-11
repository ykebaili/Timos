using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using sc2i.common;
using sc2i.data;
using sc2i.win32.data.navigation;
using sc2i.win32.data;
using sc2i.win32.common;
using sc2i.win32.navigation;
using timos.acteurs;

namespace timos
{
	/// <summary>
	/// Description résumée de CPanelFiltreActeur.
	/// </summary>
	public class CPanelFiltreActeur : System.Windows.Forms.UserControl, IControlDefinitionFiltre
	{
		private CFiltreData m_filtre;
		private System.Windows.Forms.Label m_lblNom;
		private System.Windows.Forms.TextBox m_txtNom;
		private System.Windows.Forms.Label m_lblVille;
		private System.Windows.Forms.TextBox m_txtVille;
		private System.Windows.Forms.TextBox m_txtCodePostal;
        private System.Windows.Forms.Label m_lblCodePostal;
		private System.Windows.Forms.Label m_lblRole;
		private System.Windows.Forms.Label m_lblGroupe;
		private sc2i.win32.common.CComboboxAutoFilled m_cmbRoles;
        private sc2i.win32.data.CComboBoxListeObjetsDonnees m_cmbGroupes;
        protected CExtStyle m_ExtStyle;

		public event EventHandler OnAppliqueFiltre;
		/// <summary> 
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;
		//-------------------------------------------------------------------
		public CPanelFiltreActeur()
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
            this.m_lblNom = new System.Windows.Forms.Label();
            this.m_txtNom = new System.Windows.Forms.TextBox();
            this.m_txtVille = new System.Windows.Forms.TextBox();
            this.m_lblVille = new System.Windows.Forms.Label();
            this.m_txtCodePostal = new System.Windows.Forms.TextBox();
            this.m_lblCodePostal = new System.Windows.Forms.Label();
            this.m_lblRole = new System.Windows.Forms.Label();
            this.m_cmbRoles = new sc2i.win32.common.CComboboxAutoFilled();
            this.m_lblGroupe = new System.Windows.Forms.Label();
            this.m_cmbGroupes = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
            this.m_ExtStyle = new sc2i.win32.common.CExtStyle();
            this.SuspendLayout();
            // 
            // m_lblNom
            // 
            this.m_lblNom.Location = new System.Drawing.Point(8, 5);
            this.m_lblNom.Name = "m_lblNom";
            this.m_lblNom.Size = new System.Drawing.Size(64, 17);
            this.m_ExtStyle.SetStyleBackColor(this.m_lblNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_lblNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblNom.TabIndex = 0;
            this.m_lblNom.Text = "Name|309";
            // 
            // m_txtNom
            // 
            this.m_txtNom.Location = new System.Drawing.Point(96, 2);
            this.m_txtNom.Name = "m_txtNom";
            this.m_txtNom.Size = new System.Drawing.Size(136, 20);
            this.m_ExtStyle.SetStyleBackColor(this.m_txtNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_txtNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNom.TabIndex = 1;
            // 
            // m_txtVille
            // 
            this.m_txtVille.Location = new System.Drawing.Point(357, 25);
            this.m_txtVille.Name = "m_txtVille";
            this.m_txtVille.Size = new System.Drawing.Size(136, 20);
            this.m_ExtStyle.SetStyleBackColor(this.m_txtVille, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_txtVille, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtVille.TabIndex = 3;
            // 
            // m_lblVille
            // 
            this.m_lblVille.Location = new System.Drawing.Point(246, 28);
            this.m_lblVille.Name = "m_lblVille";
            this.m_lblVille.Size = new System.Drawing.Size(48, 16);
            this.m_ExtStyle.SetStyleBackColor(this.m_lblVille, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_lblVille, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblVille.TabIndex = 2;
            this.m_lblVille.Text = "City|757";
            // 
            // m_txtCodePostal
            // 
            this.m_txtCodePostal.Location = new System.Drawing.Point(357, 2);
            this.m_txtCodePostal.Name = "m_txtCodePostal";
            this.m_txtCodePostal.Size = new System.Drawing.Size(136, 20);
            this.m_ExtStyle.SetStyleBackColor(this.m_txtCodePostal, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_txtCodePostal, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtCodePostal.TabIndex = 5;
            // 
            // m_lblCodePostal
            // 
            this.m_lblCodePostal.Location = new System.Drawing.Point(246, 5);
            this.m_lblCodePostal.Name = "m_lblCodePostal";
            this.m_lblCodePostal.Size = new System.Drawing.Size(105, 17);
            this.m_ExtStyle.SetStyleBackColor(this.m_lblCodePostal, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_lblCodePostal, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblCodePostal.TabIndex = 4;
            this.m_lblCodePostal.Text = "Postal/Zip Code|756";
            // 
            // m_lblRole
            // 
            this.m_lblRole.Location = new System.Drawing.Point(8, 31);
            this.m_lblRole.Name = "m_lblRole";
            this.m_lblRole.Size = new System.Drawing.Size(56, 16);
            this.m_ExtStyle.SetStyleBackColor(this.m_lblRole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_lblRole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblRole.TabIndex = 10;
            this.m_lblRole.Text = "Role|764";
            // 
            // m_cmbRoles
            // 
            this.m_cmbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbRoles.IsLink = false;
            this.m_cmbRoles.ListDonnees = null;
            this.m_cmbRoles.Location = new System.Drawing.Point(96, 28);
            this.m_cmbRoles.LockEdition = false;
            this.m_cmbRoles.Name = "m_cmbRoles";
            this.m_cmbRoles.NullAutorise = true;
            this.m_cmbRoles.ProprieteAffichee = null;
            this.m_cmbRoles.Size = new System.Drawing.Size(136, 21);
            this.m_ExtStyle.SetStyleBackColor(this.m_cmbRoles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_cmbRoles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbRoles.TabIndex = 9;
            this.m_cmbRoles.TextNull = I.T("(All)|30313");
            this.m_cmbRoles.Tri = true;
            // 
            // m_lblGroupe
            // 
            this.m_lblGroupe.Location = new System.Drawing.Point(246, 51);
            this.m_lblGroupe.Name = "m_lblGroupe";
            this.m_lblGroupe.Size = new System.Drawing.Size(72, 16);
            this.m_ExtStyle.SetStyleBackColor(this.m_lblGroupe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_lblGroupe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblGroupe.TabIndex = 12;
            this.m_lblGroupe.Text = "Group|165";
            // 
            // m_cmbGroupes
            // 
            this.m_cmbGroupes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbGroupes.ElementSelectionne = null;
            this.m_cmbGroupes.IsLink = false;
            this.m_cmbGroupes.ListDonnees = null;
            this.m_cmbGroupes.Location = new System.Drawing.Point(357, 48);
            this.m_cmbGroupes.LockEdition = false;
            this.m_cmbGroupes.Name = "m_cmbGroupes";
            this.m_cmbGroupes.NullAutorise = true;
            this.m_cmbGroupes.ProprieteAffichee = null;
            this.m_cmbGroupes.ProprieteParentListeObjets = null;
            this.m_cmbGroupes.SelectionneurParent = null;
            this.m_cmbGroupes.Size = new System.Drawing.Size(136, 21);
            this.m_ExtStyle.SetStyleBackColor(this.m_cmbGroupes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_cmbGroupes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbGroupes.TabIndex = 11;
            this.m_cmbGroupes.TextNull = I.T("(All)|30313");
            this.m_cmbGroupes.Tri = true;
            // 
            // CPanelFiltreActeur
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.m_lblGroupe);
            this.Controls.Add(this.m_cmbGroupes);
            this.Controls.Add(this.m_lblRole);
            this.Controls.Add(this.m_cmbRoles);
            this.Controls.Add(this.m_txtCodePostal);
            this.Controls.Add(this.m_lblCodePostal);
            this.Controls.Add(this.m_txtVille);
            this.Controls.Add(this.m_lblVille);
            this.Controls.Add(this.m_txtNom);
            this.Controls.Add(this.m_lblNom);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CPanelFiltreActeur";
            this.Size = new System.Drawing.Size(512, 79);
            this.m_ExtStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_ExtStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.Load += new System.EventHandler(this.CPanelFiltreActeur_Load);
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
				return 88;
			}
		}
		//-------------------------------------------------------------------
		public void FillContexte ( CContexteFormNavigable ctx )
		{
			ctx["FiltreNom"] = m_txtNom.Text;
			ctx["FiltreCodePostal"] = m_txtCodePostal.Text;
			ctx["FiltreVille"] = m_txtVille.Text;
			ctx["FiltreRole"] = m_cmbRoles.SelectedValue;
			ctx["FiltreGroupe"] = m_cmbGroupes.SelectedValue;
		}
		//-------------------------------------------------------------------
		public void InitFromContexte ( CContexteFormNavigable ctx )
		{
			m_txtNom.Text			= (string) ctx["FiltreNom"];
			m_txtCodePostal.Text	= (string) ctx["FiltreCodePostal"];
			m_txtVille.Text			= (string) ctx["FiltreVille"];
			m_cmbRoles.SelectedValue = (CRoleActeur) ctx["FiltreRole"];
			m_cmbGroupes.SelectedValue = (CGroupeActeur) ctx["FiltreGroupe"];
		}
		//-------------------------------------------------------------------
		private void AddToFiltre(ref string strFiltre, TextBox textBox, string strChamp)
		{
			if (textBox.Text!="")
			{
				if (strFiltre != "")
					strFiltre += " AND ";
				strFiltre += strChamp + " LIKE '" + textBox.Text + "%'";
			}
		}
		
		//-------------------------------------------------------------------
		public void AppliquerFiltre()
		{
			string strFiltre = "";
			CFiltreDataAvance tempFiltre = new CFiltreDataAvance(CActeur.c_nomTable,strFiltre);
			int nNumParam = 1;
			
			AddToFiltre(ref strFiltre, m_txtNom, CActeur.c_champNom);
			AddToFiltre(ref strFiltre, m_txtCodePostal, CActeur.c_champCodePostal);
			AddToFiltre(ref strFiltre, m_txtVille, CActeur.c_champVille);


			if (m_cmbGroupes.SelectedValue!=null)
			{
				if (strFiltre != "")
					strFiltre += " AND ";
				strFiltre += "RelationsGroupes.GroupeActeur." +CGroupeActeur.c_champId + " = @" + nNumParam;
				tempFiltre.Parametres.Add ( ((CGroupeActeur)m_cmbGroupes.SelectedValue).Id );
				nNumParam++;
			}
		
			if (m_cmbRoles.SelectedValue!=null)
			{
				CRoleActeur role = (CRoleActeur)m_cmbRoles.SelectedValue;
				string strNomtable = CContexteDonnee.GetNomTableForType( role.TypeDonneeActeur );

				if (strFiltre != "")
					strFiltre += " AND ";
				strFiltre +=  strNomtable + "." + CActeur.c_champId + " >= 0";
				nNumParam++;
			}

			if (strFiltre=="")
				strFiltre = "1 = 1";
			tempFiltre.Filtre = strFiltre;
			Filtre = tempFiltre;;
			
			OnAppliqueFiltre(new object(), null);
		}
		//-------------------------------------------------------------------
		private void CPanelFiltreActeur_Load(object sender, System.EventArgs e)
		{
            sc2i.win32.common.CWin32Traducteur.Translate(this);
			InitCombos();
		}

		//-------------------------------------------------------------------
		private bool m_bCombosInit = false;
		private void InitCombos()
		{
			if ( m_bCombosInit )
				return ;
			m_cmbRoles.ProprieteAffichee = "Libelle";
			m_cmbRoles.ListDonnees = CRoleActeur.Roles;

			CListeObjetsDonnees listeGroupes = new CListeObjetsDonnees(CSc2iWin32DataClient.ContexteCourant, typeof(CGroupeActeur));
			m_cmbGroupes.Init(listeGroupes, "Nom", true);
			
			m_bCombosInit = true;
		}

		//-------------------------------------------------------------------
		public bool ShouldShow()
		{
			return true;
		}

		/// ////////////////////////////////////////////////////////////////////
		public void AffecteValeursToNewObjet ( CObjetDonnee objet )
		{
			//Rien à faire
		}


		/// ////////////////////////////////////////////////////////////////////
		private int GetNumVersion()
		{
			return 0;
		}

		/// ////////////////////////////////////////////////////////////////////
		public CResultAErreur SerializeFiltre ( C2iSerializer serializer )
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
			if(  !result )
				return result;

			if ( serializer.Mode == ModeSerialisation.Lecture )
				InitCombos();
			
			string strText = m_txtNom.Text;
			serializer.TraiteString ( ref strText );
			m_txtNom.Text = strText;

			strText = m_txtCodePostal.Text;
			serializer.TraiteString ( ref strText );
			m_txtCodePostal.Text = strText;

			strText = m_txtVille.Text;
			serializer.TraiteString ( ref strText );
			m_txtVille.Text = strText;

			string strCodeRole = "";
			if ( m_cmbRoles.SelectedValue is CRoleActeur )
				strCodeRole = ((CRoleActeur)m_cmbRoles.SelectedValue).CodeRole;
			serializer.TraiteString ( ref strCodeRole );
			if ( serializer.Mode == ModeSerialisation.Lecture )
				m_cmbRoles.SelectedValue = CRoleActeur.GetRole ( strCodeRole );

			int nIdGroupe = -1;
			if ( m_cmbGroupes.SelectedValue is CGroupeActeur )
				nIdGroupe =((CGroupeActeur)m_cmbGroupes.SelectedValue).Id;
			serializer.TraiteInt ( ref nIdGroupe );
			if ( serializer.Mode == ModeSerialisation.Lecture )
			{
				if ( nIdGroupe >= 0 )
				{
					CGroupeActeur groupe = new CGroupeActeur( CSc2iWin32DataClient.ContexteCourant );
					if ( groupe.ReadIfExists ( nIdGroupe ) )
						m_cmbGroupes.SelectedValue = groupe;
				}
			}


			


			return result;
		}
	}
}
