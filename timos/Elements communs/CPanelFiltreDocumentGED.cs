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
using sc2i.workflow;
using sc2i.documents;

namespace timos
{
	/// <summary>
	/// Description résumée de CPanelFiltreDocumentGed.
	/// </summary>
	public class CPanelFiltreDocumentGed : System.Windows.Forms.UserControl, IControlDefinitionFiltre
	{
		private CFiltreData m_filtre;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private sc2i.win32.common.C2iDateTimeExPicker m_dateDebutModification;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private sc2i.win32.common.C2iDateTimeExPicker m_dateFinModification;
		private sc2i.win32.common.C2iDateTimeExPicker m_dateFinCreation;
		private System.Windows.Forms.Label label5;
		private sc2i.win32.common.C2iDateTimeExPicker m_dateDebutCreation;
        private sc2i.win32.data.navigation.CComboBoxArbreObjetDonneesHierarchique m_cmbCategorie;

		public event EventHandler OnAppliqueFiltre;
		/// <summary> 
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;
		//-------------------------------------------------------------------
		public CPanelFiltreDocumentGed()
		{
			// Cet appel est requis par le Concepteur de formulaires Windows.Forms.
			InitializeComponent();
			m_dateDebutCreation.Value = null;
			m_dateFinCreation.Value = null;
			m_dateDebutModification.Value = null;
			m_dateFinModification.Value = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPanelFiltreDocumentGed));
            this.m_cmbCategorie = new sc2i.win32.data.navigation.CComboBoxArbreObjetDonneesHierarchique();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_dateDebutModification = new sc2i.win32.common.C2iDateTimeExPicker();
            this.label3 = new System.Windows.Forms.Label();
            this.m_dateFinModification = new sc2i.win32.common.C2iDateTimeExPicker();
            this.label4 = new System.Windows.Forms.Label();
            this.m_dateFinCreation = new sc2i.win32.common.C2iDateTimeExPicker();
            this.label5 = new System.Windows.Forms.Label();
            this.m_dateDebutCreation = new sc2i.win32.common.C2iDateTimeExPicker();
            this.SuspendLayout();
            // 
            // m_cmbCategorie
            // 
            this.m_cmbCategorie.Location = new System.Drawing.Point(197, 10);
            this.m_cmbCategorie.LockEdition = false;
            this.m_cmbCategorie.Name = "m_cmbCategorie";
            this.m_cmbCategorie.NullAutorise = true;
            this.m_cmbCategorie.Size = new System.Drawing.Size(307, 21);
            this.m_cmbCategorie.TabIndex = 1;
            this.m_cmbCategorie.TextNull = "(All)|30329";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(26, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Document category|878";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Last modification between|879";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_dateDebutModification
            // 
            this.m_dateDebutModification.Checked = true;
            this.m_dateDebutModification.CustomFormat = null;
            this.m_dateDebutModification.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_dateDebutModification.Location = new System.Drawing.Point(197, 35);
            this.m_dateDebutModification.LockEdition = false;
            this.m_dateDebutModification.Name = "m_dateDebutModification";
            this.m_dateDebutModification.Size = new System.Drawing.Size(104, 24);
            this.m_dateDebutModification.TabIndex = 4;
            this.m_dateDebutModification.TextNull = I.T("None|148");
            this.m_dateDebutModification.Value = ((sc2i.common.CDateTimeEx)(resources.GetObject("m_dateDebutModification.Value")));
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(301, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "and|64";
            // 
            // m_dateFinModification
            // 
            this.m_dateFinModification.Checked = true;
            this.m_dateFinModification.CustomFormat = null;
            this.m_dateFinModification.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_dateFinModification.Location = new System.Drawing.Point(333, 35);
            this.m_dateFinModification.LockEdition = false;
            this.m_dateFinModification.Name = "m_dateFinModification";
            this.m_dateFinModification.Size = new System.Drawing.Size(104, 24);
            this.m_dateFinModification.TabIndex = 6;
            this.m_dateFinModification.TextNull = I.T("None|148");
            this.m_dateFinModification.Value = ((sc2i.common.CDateTimeEx)(resources.GetObject("m_dateFinModification.Value")));
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Created between|880";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_dateFinCreation
            // 
            this.m_dateFinCreation.Checked = true;
            this.m_dateFinCreation.CustomFormat = null;
            this.m_dateFinCreation.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_dateFinCreation.Location = new System.Drawing.Point(333, 58);
            this.m_dateFinCreation.LockEdition = false;
            this.m_dateFinCreation.Name = "m_dateFinCreation";
            this.m_dateFinCreation.Size = new System.Drawing.Size(104, 24);
            this.m_dateFinCreation.TabIndex = 10;
            this.m_dateFinCreation.TextNull = I.T("None|148");
            this.m_dateFinCreation.Value = ((sc2i.common.CDateTimeEx)(resources.GetObject("m_dateFinCreation.Value")));
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(301, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "and|64";
            // 
            // m_dateDebutCreation
            // 
            this.m_dateDebutCreation.Checked = true;
            this.m_dateDebutCreation.CustomFormat = null;
            this.m_dateDebutCreation.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_dateDebutCreation.Location = new System.Drawing.Point(197, 58);
            this.m_dateDebutCreation.LockEdition = false;
            this.m_dateDebutCreation.Name = "m_dateDebutCreation";
            this.m_dateDebutCreation.Size = new System.Drawing.Size(104, 24);
            this.m_dateDebutCreation.TabIndex = 8;
            this.m_dateDebutCreation.TextNull = I.T("None|148");
            this.m_dateDebutCreation.Value = ((sc2i.common.CDateTimeEx)(resources.GetObject("m_dateDebutCreation.Value")));
            // 
            // CPanelFiltreDocumentGed
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.m_dateFinCreation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_dateDebutCreation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_dateFinModification);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_dateDebutModification);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_cmbCategorie);
            this.Name = "CPanelFiltreDocumentGed";
            this.Size = new System.Drawing.Size(696, 96);
            this.Load += new System.EventHandler(this.CPanelFiltreDocumentGed_Load);
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
			int nIdCategorie  = -1;
			if ( m_cmbCategorie.ElementSelectionne is CCategorieGED )
				nIdCategorie = ((CCategorieGED)m_cmbCategorie.ElementSelectionne).Id;
			ctx["ID_CATEGORIE"] = nIdCategorie;
			ctx["DATE_DEBUT_CREATION"] = m_dateDebutCreation.Value;
			ctx["DATE_DEBUT_MODIF"] = m_dateDebutModification.Value;
			ctx["DATE_FIN_CREATION"] = m_dateFinCreation.Value;
			ctx["DATE_FIN_MODIF"] = m_dateFinModification.Value;

		}
		//-------------------------------------------------------------------
		public void InitFromContexte ( CContexteFormNavigable ctx )
		{
			if ( ctx == null )
				return;
			int nIdCategorie  = (int)ctx["ID_CATEGORIE"];
			if ( nIdCategorie != -1 )
			{
				CCategorieGED cat = new CCategorieGED ( CSc2iWin32DataClient.ContexteCourant );
				if ( cat.ReadIfExists ( nIdCategorie ) )
					m_cmbCategorie.ElementSelectionne = cat;
			}
			m_dateDebutCreation.Value = (CDateTimeEx)ctx["DATE_DEBUT_CREATION"] ;
			m_dateDebutModification.Value = (CDateTimeEx)ctx["DATE_DEBUT_MODIF"];
			m_dateFinCreation.Value = (CDateTimeEx)ctx["DATE_FIN_CREATION"];
			m_dateFinModification.Value = (CDateTimeEx)ctx["DATE_FIN_MODIF"];
		}
		//-------------------------------------------------------------------
		private void CPanelFiltreDocumentGed_Load(object sender, System.EventArgs e)
		{
			sc2i.win32.common.CWin32Traducteur.Translate(this);
			InitCombos();
			AppliquerFiltre();
		}

		//-----------------------------------------------------------------
		private bool m_bComboInit = false;
		private void InitCombos()
		{
			if ( m_bComboInit )
				return;
			m_bComboInit = true;

            m_cmbCategorie.Init(
                typeof(CCategorieGED),
                "CategoriesFilles",
                CCategorieGED.c_champIdParent,
                "Libelle",
                null,
                null);

		}
		
		//-----------------------------------------------------------------
		public bool ShouldShow()
		{
			return true;
		}

		//-----------------------------------------------------------------
		public void AppliquerFiltre()
		{
			CFiltreData filtre = null;
			if ( m_cmbCategorie.ElementSelectionne is CCategorieGED )
			{
				CCategorieGED cat = (CCategorieGED)m_cmbCategorie.ElementSelectionne;
				filtre = new CFiltreDataAvance( CDocumentGED.c_nomTable,
					CRelationDocumentGED_Categorie.c_nomTable+"."+
                    CCategorieGED.c_nomTable+"."+
					CCategorieGED.c_champCodeSystemeComplet+" LIKE @1",
					cat.CodeSystemeComplet + "%" );
			}
			if ( m_dateDebutCreation.Value != null )
			{
				filtre = CFiltreData.GetAndFiltre ( filtre, 
					new CFiltreData ( CDocumentGED.c_champDateCreation+">=@1",
					m_dateDebutCreation.Value.DateTimeValue ));
			}

			if ( m_dateFinCreation.Value != null )
			{
				filtre = CFiltreData.GetAndFiltre ( filtre, 
					new CFiltreData ( CDocumentGED.c_champDateCreation+"<@1",
					CUtilDate.SetTime0(m_dateFinCreation.Value.DateTimeValue.AddDays(1) )));
			}
			if ( m_dateDebutModification.Value != null )
			{
				filtre = CFiltreData.GetAndFiltre ( filtre, 
					new CFiltreData ( CDocumentGED.c_champDateMAJ+">=@1",
					m_dateDebutModification.Value.DateTimeValue ));
			}
			if ( m_dateFinModification.Value != null )
			{
				filtre = CFiltreData.GetAndFiltre ( filtre, 
					new CFiltreData ( CDocumentGED.c_champDateMAJ+"<@1",
					CUtilDate.SetTime0(m_dateFinModification.Value.DateTimeValue.AddDays(1) )));
			}
			Filtre = filtre;
			OnAppliqueFiltre(new object(), null);
		}

		/// ////////////////////////////////////////////////////////////////////
		public void AffecteValeursToNewObjet ( CObjetDonnee objet )
		{
			if ( objet is CDocumentGED && m_cmbCategorie.ElementSelectionne is CCategorieGED)
			{
				((CCategorieGED)m_cmbCategorie.ElementSelectionne).AssocieDocument ( (CDocumentGED)objet );
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

			int nIdCategorie  = -1;
			if ( serializer.Mode == ModeSerialisation.Ecriture && m_cmbCategorie.ElementSelectionne is CCategorieGED )
				nIdCategorie = ((CCategorieGED)m_cmbCategorie.ElementSelectionne).Id;
			serializer.TraiteInt ( ref nIdCategorie );
			if ( serializer.Mode == ModeSerialisation.Lecture && nIdCategorie != -1 )
			{
				CCategorieGED cat = new CCategorieGED ( CSc2iWin32DataClient.ContexteCourant );
				if ( cat.ReadIfExists ( nIdCategorie ) )
					m_cmbCategorie.ElementSelectionne = cat;
			}
			return result;
		}

	}
}
