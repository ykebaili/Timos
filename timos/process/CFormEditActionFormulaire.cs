using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using sc2i.expression;
using sc2i.process;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.formulaire;
using sc2i.win32.data.dynamic;
using sc2i.win32.process;


namespace timos.process
{
	[AutoExec("Autoexec")]
	public class CFormEditActionFormulaire : sc2i.win32.process.CFormEditObjetDeProcess
	{
        private sc2i.win32.common.C2iPanelOmbre m_panelOmbre;
        private System.Windows.Forms.Panel m_panelEdition;
		private System.Windows.Forms.Label m_lblDescriptif;
		private System.Windows.Forms.TextBox m_txtDescriptif;
		private System.Windows.Forms.CheckBox m_chkCanCancel;
		private sc2i.win32.common.CExtStyle m_ExtStyle;
        private sc2i.formulaire.win32.editor.CPanelEditionFullFormulaire m_panelEditionFullFormulaire;
		private System.ComponentModel.IContainer components = null;

		public CFormEditActionFormulaire()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();

			// TODO : ajoutez les initialisations après l'appel à InitializeComponent
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		public static void Autoexec()
		{
			CEditeurActionsEtLiens.RegisterEditeur ( typeof(CActionFormulaire), typeof(CFormEditActionFormulaire));
		}


		public CActionFormulaire ActionFormulaire
		{
			get
			{
				return (CActionFormulaire)ObjetEdite;
			}
		}

		#region Code généré par le concepteur
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.m_panelOmbre = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panelEdition = new System.Windows.Forms.Panel();
            this.m_lblDescriptif = new System.Windows.Forms.Label();
            this.m_txtDescriptif = new System.Windows.Forms.TextBox();
            this.m_chkCanCancel = new System.Windows.Forms.CheckBox();
            this.m_ExtStyle = new sc2i.win32.common.CExtStyle();
            this.m_panelEditionFullFormulaire = new sc2i.formulaire.win32.editor.CPanelEditionFullFormulaire();
            this.m_panelOmbre.SuspendLayout();
            this.m_panelEdition.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelOmbre
            // 
            this.m_panelOmbre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelOmbre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelOmbre.Controls.Add(this.m_panelEdition);
            this.m_panelOmbre.ForeColor = System.Drawing.Color.Black;
            this.m_panelOmbre.Location = new System.Drawing.Point(5, 54);
            this.m_panelOmbre.LockEdition = false;
            this.m_panelOmbre.Name = "m_panelOmbre";
            this.m_panelOmbre.Size = new System.Drawing.Size(727, 344);
            this.m_ExtStyle.SetStyleBackColor(this.m_panelOmbre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_panelOmbre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelOmbre.TabIndex = 2;
            // 
            // m_panelEdition
            // 
            this.m_panelEdition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelEdition.Controls.Add(this.m_panelEditionFullFormulaire);
            this.m_panelEdition.Location = new System.Drawing.Point(3, 3);
            this.m_panelEdition.Name = "m_panelEdition";
            this.m_panelEdition.Size = new System.Drawing.Size(703, 320);
            this.m_ExtStyle.SetStyleBackColor(this.m_panelEdition, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_panelEdition, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEdition.TabIndex = 3;
            // 
            // m_lblDescriptif
            // 
            this.m_lblDescriptif.Location = new System.Drawing.Point(2, 11);
            this.m_lblDescriptif.Name = "m_lblDescriptif";
            this.m_lblDescriptif.Size = new System.Drawing.Size(96, 18);
            this.m_ExtStyle.SetStyleBackColor(this.m_lblDescriptif, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_lblDescriptif, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDescriptif.TabIndex = 3;
            this.m_lblDescriptif.Text = "Title|713";
            // 
            // m_txtDescriptif
            // 
            this.m_txtDescriptif.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDescriptif.Location = new System.Drawing.Point(104, 8);
            this.m_txtDescriptif.Name = "m_txtDescriptif";
            this.m_txtDescriptif.Size = new System.Drawing.Size(588, 20);
            this.m_ExtStyle.SetStyleBackColor(this.m_txtDescriptif, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_txtDescriptif, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtDescriptif.TabIndex = 4;
            // 
            // m_chkCanCancel
            // 
            this.m_chkCanCancel.Location = new System.Drawing.Point(104, 32);
            this.m_chkCanCancel.Name = "m_chkCanCancel";
            this.m_chkCanCancel.Size = new System.Drawing.Size(240, 16);
            this.m_ExtStyle.SetStyleBackColor(this.m_chkCanCancel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_chkCanCancel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkCanCancel.TabIndex = 5;
            this.m_chkCanCancel.Text = "User can cancel the form|1053";
            // 
            // m_panelEditionFullFormulaire
            // 
            this.m_panelEditionFullFormulaire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelEditionFullFormulaire.EntiteEditee = null;
            this.m_panelEditionFullFormulaire.FournisseurProprietes = null;
            this.m_panelEditionFullFormulaire.Location = new System.Drawing.Point(0, 0);
            this.m_panelEditionFullFormulaire.LockEdition = true;
            this.m_panelEditionFullFormulaire.Name = "m_panelEditionFullFormulaire";
            this.m_panelEditionFullFormulaire.Size = new System.Drawing.Size(703, 320);
            this.m_ExtStyle.SetStyleBackColor(this.m_panelEditionFullFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_panelEditionFullFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditionFullFormulaire.TabIndex = 6;
            this.m_panelEditionFullFormulaire.TypeEdite = null;
            this.m_panelEditionFullFormulaire.WndEditee = null;
            // 
            // CFormEditActionFormulaire
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(732, 450);
            this.Controls.Add(this.m_chkCanCancel);
            this.Controls.Add(this.m_txtDescriptif);
            this.Controls.Add(this.m_lblDescriptif);
            this.Controls.Add(this.m_panelOmbre);
            this.Name = "CFormEditActionFormulaire";
            this.m_ExtStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "Form designer|1052";
            this.Load += new System.EventHandler(this.CFormEditActionFormulaire_Load);
            this.Controls.SetChildIndex(this.m_panelOmbre, 0);
            this.Controls.SetChildIndex(this.m_lblDescriptif, 0);
            this.Controls.SetChildIndex(this.m_txtDescriptif, 0);
            this.Controls.SetChildIndex(this.m_chkCanCancel, 0);
            this.m_panelOmbre.ResumeLayout(false);
            this.m_panelOmbre.PerformLayout();
            this.m_panelEdition.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

	

		/// //////////////////////////////////////////
		protected override sc2i.common.CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();
			ActionFormulaire.Descriptif = m_txtDescriptif.Text;
			ActionFormulaire.CanCancel = m_chkCanCancel.Checked;
            ActionFormulaire.Formulaire = (sc2i.formulaire.C2iWndFenetre)m_panelEditionFullFormulaire.WndEditee;
            
			return result;
		}

		
		/// //////////////////////////////////////////
		protected override void InitChamps()
		{
			base.InitChamps ();
            //m_panelEditionFormulaire.ObjetEdite = ActionFormulaire.Formulaire;
            //m_panelEditionFormulaire.Init(typeof(CProcess), ActionFormulaire.Process, ActionFormulaire.Process);
            m_panelEditionFullFormulaire.Init(
                typeof(CProcess),
                ActionFormulaire.Process,
                ActionFormulaire.Formulaire,
                ActionFormulaire.Process);
            m_panelEditionFullFormulaire.LockEdition = false;

			m_txtDescriptif.Text = ActionFormulaire.Descriptif;
			m_chkCanCancel.Checked = ActionFormulaire.CanCancel;
		}

		//-------------------------------------------------------------------------
		private void CFormEditActionFormulaire_Load(object sender, System.EventArgs e)
		{
			if ( !DesignMode )
			{
				try//Sinon pbs au mode design
				{
					//CProprieteVariableFiltreDynamiqueEditor.SetEditeur ( new CSelectionneurVariableAInterfaceUtilisateur(ActionFormulaire.Process) );
                    //m_panelEditionFormulaire.Selection.SelectionChanged += new EventHandler(SelectionChanged);
					//m_listeControles.AddTypeControl ( typeof(C2iWndVariableFiltreDyamique) );
					//m_listeControles.AddTypeControl ( typeof(C2iWndProprieteDynamique) );
					//m_listeControles.AddAssembly ( typeof(C2iWnd).Assembly );
					//m_listeControles.AddAssembly(typeof(C2iWndExpression).Assembly);
                    //m_listeControles.SetTypeEdite(typeof(CProcess));
                    //m_listeControles.AddAllLoadedAssemblies();
					/*m_listeControles.AddTypeControl(typeof(C2iWndVariableFiltreDyamique));
					m_listeControles.AddTypeControl(typeof(C2iWndFormule));
					m_listeControles.AddTypeControl(typeof(C2iWndImage));
					m_listeControles.AddTypeControl(typeof(C2iWndLabel));
					m_listeControles.AddTypeControl(typeof(C2iWndListe));
					m_listeControles.AddTypeControl(typeof(C2iWndPanel));*/
                    //m_listeControles.RefreshControls();
					
					/*CSelectionneurChampPopup selectionneur = new CSelectionneurChampPopup();
					selectionneur.Init(typeof(CProcess), ActionFormulaire.Process, null);
					CProprieteDynamiqueEditor.SetEditeur(selectionneur);

					CEditeurExpressionPopup selectExp = new CEditeurExpressionPopup(typeof(CProcess));
					selectExp.FournisseurProprietes = ActionFormulaire.Process;
					CProprieteExpressionEditor.SetEditeur(selectExp);*/

					
				}
				catch{}
			}
		}

		//-------------------------------------------------------------------------
		private void m_propertyGrid_PropertyValueChanged(object s, System.Windows.Forms.PropertyValueChangedEventArgs e)
		{
            //m_panelEditionFormulaire.Refresh();
		}

		//-------------------------------------------------------------------------
		private void SelectionChanged ( object sender, EventArgs args )
		{
            //if (m_panelEditionFormulaire.Selection.Count == 1)
            //{
            //    m_propertyGrid.SelectedObject = m_panelEditionFormulaire.Selection[0];
            //}
            //else
            //    m_propertyGrid.SelectedObject = null;
            //foreach (C2iWnd wnd in m_panelEditionFormulaire.Selection)
            //    wnd.OnDesignSelect(typeof(CProcess),
            //        ActionFormulaire.Process,
            //        ActionFormulaire.Process);
		}
	}

	
}

