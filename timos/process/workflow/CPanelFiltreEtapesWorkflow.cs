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
using sc2i.process.workflow;
using System.Collections.Generic;

namespace timos
{
	/// <summary>
	/// Description résumée de CPanelFiltreEtapesWorkflow.
	/// </summary>
	public class CPanelFiltreEtapesWorkflow : System.Windows.Forms.UserControl, IControlDefinitionFiltre
	{
		private CFiltreData m_filtre;
        private System.Windows.Forms.Label m_lblNom;
        private System.Windows.Forms.Label m_lblRole;
        private sc2i.win32.common.CComboboxAutoFilled m_cmbEtats;
        protected CExtStyle m_ExtStyle;
        private sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide m_txtActeur;
        private Label label1;
        private sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide m_txtTypeWorkflow;
        private Label label2;
        private TextBox m_txtLabel;

		public event EventHandler OnAppliqueFiltre;
		/// <summary> 
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;
		//-------------------------------------------------------------------
		public CPanelFiltreEtapesWorkflow()
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
            this.m_lblRole = new System.Windows.Forms.Label();
            this.m_cmbEtats = new sc2i.win32.common.CComboboxAutoFilled();
            this.m_ExtStyle = new sc2i.win32.common.CExtStyle();
            this.m_txtActeur = new sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtTypeWorkflow = new sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtLabel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // m_lblNom
            // 
            this.m_lblNom.Location = new System.Drawing.Point(8, 5);
            this.m_lblNom.Name = "m_lblNom";
            this.m_lblNom.Size = new System.Drawing.Size(97, 17);
            this.m_ExtStyle.SetStyleBackColor(this.m_lblNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_lblNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblNom.TabIndex = 0;
            this.m_lblNom.Text = "Affected to|20616";
            // 
            // m_lblRole
            // 
            this.m_lblRole.Location = new System.Drawing.Point(346, 51);
            this.m_lblRole.Name = "m_lblRole";
            this.m_lblRole.Size = new System.Drawing.Size(97, 16);
            this.m_ExtStyle.SetStyleBackColor(this.m_lblRole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_lblRole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblRole.TabIndex = 10;
            this.m_lblRole.Text = "State|20617";
            // 
            // m_cmbEtats
            // 
            this.m_cmbEtats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbEtats.IsLink = false;
            this.m_cmbEtats.ListDonnees = null;
            this.m_cmbEtats.Location = new System.Drawing.Point(453, 48);
            this.m_cmbEtats.LockEdition = false;
            this.m_cmbEtats.Name = "m_cmbEtats";
            this.m_cmbEtats.NullAutorise = true;
            this.m_cmbEtats.ProprieteAffichee = null;
            this.m_cmbEtats.Size = new System.Drawing.Size(136, 21);
            this.m_ExtStyle.SetStyleBackColor(this.m_cmbEtats, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_cmbEtats, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbEtats.TabIndex = 9;
            this.m_cmbEtats.TextNull = "(All)";
            this.m_cmbEtats.Tri = true;
            // 
            // m_txtActeur
            // 
            this.m_txtActeur.ElementSelectionne = null;
            this.m_txtActeur.Location = new System.Drawing.Point(111, 2);
            this.m_txtActeur.LockEdition = false;
            this.m_txtActeur.Name = "m_txtActeur";
            this.m_txtActeur.SelectedObject = null;
            this.m_txtActeur.SelectionLength = 0;
            this.m_txtActeur.SelectionStart = 0;
            this.m_txtActeur.Size = new System.Drawing.Size(527, 20);
            this.m_ExtStyle.SetStyleBackColor(this.m_txtActeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_txtActeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtActeur.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 16);
            this.m_ExtStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 12;
            this.label1.Text = "Label|20619";
            // 
            // m_txtTypeWorkflow
            // 
            this.m_txtTypeWorkflow.ElementSelectionne = null;
            this.m_txtTypeWorkflow.Location = new System.Drawing.Point(111, 25);
            this.m_txtTypeWorkflow.LockEdition = false;
            this.m_txtTypeWorkflow.Name = "m_txtTypeWorkflow";
            this.m_txtTypeWorkflow.SelectedObject = null;
            this.m_txtTypeWorkflow.SelectionLength = 0;
            this.m_txtTypeWorkflow.SelectionStart = 0;
            this.m_txtTypeWorkflow.Size = new System.Drawing.Size(527, 20);
            this.m_ExtStyle.SetStyleBackColor(this.m_txtTypeWorkflow, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_txtTypeWorkflow, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtTypeWorkflow.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.m_ExtStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 13;
            this.label2.Text = "Workflow type|20618";
            // 
            // m_txtLabel
            // 
            this.m_txtLabel.Location = new System.Drawing.Point(111, 48);
            this.m_txtLabel.Name = "m_txtLabel";
            this.m_txtLabel.Size = new System.Drawing.Size(229, 20);
            this.m_ExtStyle.SetStyleBackColor(this.m_txtLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_txtLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLabel.TabIndex = 15;
            // 
            // CPanelFiltreEtapesWorkflow
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.m_txtLabel);
            this.Controls.Add(this.m_txtTypeWorkflow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_txtActeur);
            this.Controls.Add(this.m_lblRole);
            this.Controls.Add(this.m_cmbEtats);
            this.Controls.Add(this.m_lblNom);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CPanelFiltreEtapesWorkflow";
            this.Size = new System.Drawing.Size(652, 84);
            this.m_ExtStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_ExtStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.Load += new System.EventHandler(this.CPanelFiltreEtapesWorkflow_Load);
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
            CActeur acteur = m_txtActeur.ElementSelectionne as CActeur;
            ctx["FILTRE_ACTEUR"] = acteur != null ? (int?)acteur.Id : null;
            CEtatEtapeWorkflow etat = m_cmbEtats.SelectedValue as CEtatEtapeWorkflow;
            ctx["FILTRE_ETAT"] = etat;
            CTypeWorkflow type = m_txtTypeWorkflow.ElementSelectionne as CTypeWorkflow;
            ctx["FILTRE_TYPE_WKF"] = type != null ? (int?)type.Id : null;
            ctx["FILTRE_LABEL"] = m_txtLabel.Text;
		}
		//-------------------------------------------------------------------
		public void InitFromContexte ( CContexteFormNavigable ctx )
		{
            int? nIdActeur = ctx["FILTRE_ACTEUR"] as int?;
            if (nIdActeur != null)
            {
                CActeur acteur = new CActeur(CSc2iWin32DataClient.ContexteCourant);
                if (acteur.ReadIfExists(nIdActeur.Value))
                    m_txtActeur.ElementSelectionne = acteur;
            }
            else
                m_txtActeur.ElementSelectionne = null;
            CEtatEtapeWorkflow etat = ctx["FILTRE_ETAT"] as CEtatEtapeWorkflow;
            if (etat != null)
                m_cmbEtats.SelectedValue = etat;
            else
                m_cmbEtats.SelectedValue = null;

            int? nIdType = ctx["FILTRE_TYPE_WKF"] as int?;
            if (nIdType != null)
            {
                CTypeWorkflow type = new CTypeWorkflow(CSc2iWin32DataClient.ContexteCourant);
                if (type.ReadIfExists(nIdType.Value))
                    m_txtTypeWorkflow.ElementSelectionne = type;
            }
            else
                m_txtTypeWorkflow.ElementSelectionne = null;
            m_txtLabel.Text = ctx["FILTRE_LABEL"] as string;
		}
		
		//-------------------------------------------------------------------
		public void AppliquerFiltre()
		{
            CFiltreData filtre = null;

            CActeur acteur = m_txtActeur.ElementSelectionne as CActeur;
            if (acteur != null)
            {
                CFiltreData filtreAss = new CFiltreData();
                string[] strCodes = acteur.GetListeCodesAffectationEtape();
                foreach (string strCode in strCodes)
                {
                    filtreAss.Filtre += CEtapeWorkflow.c_champAffectations + " like @" +
                        (filtreAss.Parametres.Count + 1) + " or ";
                    filtreAss.Parametres.Add("%~" + strCode + "~%");
                }
                if (filtreAss.Filtre.Length > 0)
                {
                    filtreAss.Filtre = filtreAss.Filtre.Remove(filtreAss.Filtre.Length - 4, 4);
                    filtre = CFiltreData.GetAndFiltre(filtre, filtreAss);
                }
            }
            CEtatEtapeWorkflow etat = m_cmbEtats.SelectedValue as CEtatEtapeWorkflow;
            if (etat != null)
            {
                CFiltreData filtreTmp = new CFiltreData(CEtapeWorkflow.c_champEtat + "=@1",
                    etat.CodeInt);
                filtre = CFiltreData.GetAndFiltre(filtreTmp, filtre);
            }

            CTypeWorkflow type = m_txtTypeWorkflow.ElementSelectionne as CTypeWorkflow;
            if (type != null)
            {
                filtre = CFiltreData.GetAndFiltre(filtre,
                    new CFiltreDataAvance(CEtapeWorkflow.c_nomTable,
                        CTypeEtapeWorkflow.c_nomTable + "." +
                        CTypeWorkflow.c_champId + "=@1", type.Id));
            }
            if (m_txtLabel.Text.Trim().Length > 0)
            {
                filtre = CFiltreData.GetAndFiltre(filtre,
                    new CFiltreDataAvance(CEtapeWorkflow.c_nomTable,
                        "(" + CEtapeWorkflow.c_champLibelle + " like @1) or (" +
                        CEtapeWorkflow.c_champLibelle + "=@2 and " +
                        CTypeEtapeWorkflow.c_nomTable + "." +
                        CTypeEtapeWorkflow.c_champLibelle + " like @1)",
                        "%" + m_txtLabel.Text.Trim() + "%", ""));
            }


            Filtre = filtre;
			
			OnAppliqueFiltre(new object(), null);
		}
		//-------------------------------------------------------------------
		private void CPanelFiltreEtapesWorkflow_Load(object sender, System.EventArgs e)
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
            m_txtActeur.Init(typeof(CActeur), "IdentiteComplete", false);
            
            List<CEtatEtapeWorkflow> lstEtats = new List<CEtatEtapeWorkflow>();
            foreach ( EEtatEtapeWorkflow etat in Enum.GetValues ( typeof(EEtatEtapeWorkflow)) )
            {
                lstEtats.Add ( new CEtatEtapeWorkflow (etat) );
            }
            m_cmbEtats.ProprieteAffichee = "Libelle";
			m_cmbEtats.ListDonnees = lstEtats;
			m_bCombosInit = true;

            m_txtTypeWorkflow.Init(typeof(CTypeWorkflow), "Libelle", false);

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

            CActeur acteur = m_txtActeur.ElementSelectionne as CActeur;
            int? nIdActeur = acteur != null ? (int?)acteur.Id : null;
            serializer.TraiteIntNullable(ref nIdActeur);
            if ( nIdActeur != null && serializer.Mode == ModeSerialisation.Lecture)
            {
                acteur = new CActeur ( CSc2iWin32DataClient.ContexteCourant);
                if ( acteur.ReadIfExists ( nIdActeur.Value ))
                    m_txtActeur.ElementSelectionne = acteur;
            }

            CEtatEtapeWorkflow etat = m_cmbEtats.SelectedValue as CEtatEtapeWorkflow;
            int? nEtat = etat != null?(int?)etat.CodeInt:null;
            serializer.TraiteIntNullable ( ref nEtat );
            if ( serializer.Mode == ModeSerialisation.Lecture && nEtat != null)
            {
                etat = new CEtatEtapeWorkflow((EEtatEtapeWorkflow)nEtat.Value);
                m_cmbEtats.SelectedValue = etat;
            }

            CTypeWorkflow type = m_txtTypeWorkflow.ElementSelectionne as CTypeWorkflow;
            int? nIdType = type != null ? (int?)type.Id : null;
            serializer.TraiteIntNullable(ref nIdType);
            if (nIdType != null && serializer.Mode == ModeSerialisation.Lecture)
            {
                type = new CTypeWorkflow(CSc2iWin32DataClient.ContexteCourant);
                if (type.ReadIfExists(nIdType.Value))
                    m_txtTypeWorkflow.ElementSelectionne = type;
            }

            string strText = m_txtLabel.Text;
            serializer.TraiteString(ref strText);
            if (serializer.Mode == ModeSerialisation.Lecture)
            {
                m_txtLabel.Text = strText;
            }

			return result;
		}
	}
}
