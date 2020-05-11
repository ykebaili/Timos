using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using System.Globalization;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

using sc2i.common;
using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.win32.data;
using sc2i.win32.common;

using timos.acteurs;
using timos.data;
using timos.data.preventives;
using System.Reflection;
using timos.Properties;
using sc2i.win32.data.navigation.RefTypeForm;

namespace timos
{
	public class CFormEditionPreferenceTypeForm : CFormMaxiSansMenu, IFormNavigable
	{
		#region Designer generated code
        private sc2i.win32.common.CExtLinkField m_extLinkField;
		private sc2i.win32.common.C2iPanelOmbre m_panGeneral;
        private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private Button m_btnEditerObjet;
		private Button m_btnValiderModifications;
        private Button m_btnAnnulerModifications;
        private SplitContainer m_splitContainer;
        private ListView m_wndListeTypes;
        private ColumnHeader m_colType;
        private Label label1;
        //private ListViewAutoFilled m_wndListeParametres;
        //private ListViewAutoFilledColumn listViewAutoFilledColumn2;
        private Panel m_panelSelectForm;
        private CPanelEditRefTypeFormAvecCondition m_panelFormPref;
        private CGestionnaireEditionSousObjetDonnee cGestionnaireEditionSousObjetDonnee1;
		private System.ComponentModel.IContainer components = null;

		//-------------------------------------------------------------------------
		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.m_panGeneral = new sc2i.win32.common.C2iPanelOmbre();
            this.m_splitContainer = new System.Windows.Forms.SplitContainer();
            this.m_wndListeTypes = new System.Windows.Forms.ListView();
            this.m_colType = new System.Windows.Forms.ColumnHeader();
            this.m_panelSelectForm = new System.Windows.Forms.Panel();
            this.m_panelFormPref = new sc2i.win32.data.navigation.RefTypeForm.CPanelEditRefTypeFormAvecCondition();
            this.label1 = new System.Windows.Forms.Label();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_btnValiderModifications = new System.Windows.Forms.Button();
            this.m_btnEditerObjet = new System.Windows.Forms.Button();
            this.m_btnAnnulerModifications = new System.Windows.Forms.Button();
            this.m_extLinkField = new sc2i.win32.common.CExtLinkField();
            this.cGestionnaireEditionSousObjetDonnee1 = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_panGeneral.SuspendLayout();
            this.m_splitContainer.Panel1.SuspendLayout();
            this.m_splitContainer.Panel2.SuspendLayout();
            this.m_splitContainer.SuspendLayout();
            this.m_panelSelectForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panGeneral
            // 
            this.m_panGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panGeneral.Controls.Add(this.m_splitContainer);
            this.m_panGeneral.Controls.Add(this.label1);
            this.m_panGeneral.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panGeneral, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panGeneral, false);
            this.m_panGeneral.Location = new System.Drawing.Point(12, 44);
            this.m_panGeneral.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panGeneral, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panGeneral.Name = "m_panGeneral";
            this.m_panGeneral.Size = new System.Drawing.Size(818, 523);
            this.m_extStyle.SetStyleBackColor(this.m_panGeneral, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panGeneral, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panGeneral.TabIndex = 0;
            // 
            // m_splitContainer
            // 
            this.m_splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_splitContainer, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_splitContainer, false);
            this.m_splitContainer.Location = new System.Drawing.Point(8, 44);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainer, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_splitContainer.Name = "m_splitContainer";
            // 
            // m_splitContainer.Panel1
            // 
            this.m_splitContainer.Panel1.Controls.Add(this.m_wndListeTypes);
            this.m_extLinkField.SetLinkField(this.m_splitContainer.Panel1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_splitContainer.Panel1, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainer.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_splitContainer.Panel2
            // 
            this.m_splitContainer.Panel2.Controls.Add(this.m_panelSelectForm);
            this.m_extLinkField.SetLinkField(this.m_splitContainer.Panel2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_splitContainer.Panel2, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainer.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainer.Size = new System.Drawing.Size(788, 456);
            this.m_splitContainer.SplitterDistance = 232;
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainer.TabIndex = 3;
            // 
            // m_wndListeTypes
            // 
            this.m_wndListeTypes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_colType});
            this.m_wndListeTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_wndListeTypes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndListeTypes, false);
            this.m_wndListeTypes.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeTypes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_wndListeTypes.MultiSelect = false;
            this.m_wndListeTypes.Name = "m_wndListeTypes";
            this.m_wndListeTypes.Size = new System.Drawing.Size(232, 456);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeTypes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeTypes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeTypes.TabIndex = 4;
            this.m_wndListeTypes.UseCompatibleStateImageBehavior = false;
            this.m_wndListeTypes.View = System.Windows.Forms.View.Details;
            this.m_wndListeTypes.SelectedIndexChanged += new System.EventHandler(this.m_wndListeTypes_SelectedIndexChanged);
            // 
            // m_colType
            // 
            this.m_colType.Text = "Object type|1085";
            this.m_colType.Width = 211;
            // 
            // m_panelSelectForm
            // 
            this.m_panelSelectForm.Controls.Add(this.m_panelFormPref);
            this.m_panelSelectForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelSelectForm, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelSelectForm, false);
            this.m_panelSelectForm.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSelectForm, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelSelectForm.Name = "m_panelSelectForm";
            this.m_panelSelectForm.Size = new System.Drawing.Size(552, 456);
            this.m_extStyle.SetStyleBackColor(this.m_panelSelectForm, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSelectForm, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSelectForm.TabIndex = 12;
            this.m_panelSelectForm.Visible = false;
            // 
            // m_panelFormPref
            // 
            this.m_panelFormPref.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelFormPref, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelFormPref, false);
            this.m_panelFormPref.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelFormPref, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelFormPref.Name = "m_panelFormPref";
            this.m_panelFormPref.Size = new System.Drawing.Size(552, 456);
            this.m_extStyle.SetStyleBackColor(this.m_panelFormPref, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelFormPref, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFormPref.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label1, false);
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(482, 24);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select an entity type, then its favourite editing form |30225";
            // 
            // m_btnValiderModifications
            // 
            this.m_btnValiderModifications.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnValiderModifications.Enabled = false;
            this.m_btnValiderModifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnValiderModifications.ForeColor = System.Drawing.Color.White;
            this.m_btnValiderModifications.Image = global::timos.Properties.Resources.check;
            this.m_extLinkField.SetLinkField(this.m_btnValiderModifications, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnValiderModifications, false);
            this.m_btnValiderModifications.Location = new System.Drawing.Point(90, -2);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnValiderModifications.Name = "m_btnValiderModifications";
            this.m_btnValiderModifications.Size = new System.Drawing.Size(31, 31);
            this.m_extStyle.SetStyleBackColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnValiderModifications.TabIndex = 4020;
            this.m_btnValiderModifications.TabStop = false;
            this.m_btnValiderModifications.Click += new System.EventHandler(this.m_btnValiderModifications_Click);
            // 
            // m_btnEditerObjet
            // 
            this.m_btnEditerObjet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnEditerObjet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnEditerObjet.ForeColor = System.Drawing.Color.White;
            this.m_btnEditerObjet.Image = global::timos.Properties.Resources.edit;
            this.m_extLinkField.SetLinkField(this.m_btnEditerObjet, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnEditerObjet, false);
            this.m_btnEditerObjet.Location = new System.Drawing.Point(12, -2);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditerObjet, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_btnEditerObjet.Name = "m_btnEditerObjet";
            this.m_btnEditerObjet.Size = new System.Drawing.Size(31, 31);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnEditerObjet.TabIndex = 4019;
            this.m_btnEditerObjet.TabStop = false;
            this.m_btnEditerObjet.Click += new System.EventHandler(this.m_btnEditerObjet_Click);
            // 
            // m_btnAnnulerModifications
            // 
            this.m_btnAnnulerModifications.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnAnnulerModifications.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnulerModifications.Enabled = false;
            this.m_btnAnnulerModifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnAnnulerModifications.ForeColor = System.Drawing.Color.White;
            this.m_btnAnnulerModifications.Image = global::timos.Properties.Resources.cancel;
            this.m_extLinkField.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnAnnulerModifications, false);
            this.m_btnAnnulerModifications.Location = new System.Drawing.Point(127, -2);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnulerModifications, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnAnnulerModifications.Name = "m_btnAnnulerModifications";
            this.m_btnAnnulerModifications.Size = new System.Drawing.Size(31, 31);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAnnulerModifications.TabIndex = 4021;
            this.m_btnAnnulerModifications.TabStop = false;
            this.m_btnAnnulerModifications.Click += new System.EventHandler(this.m_btnAnnulerModifications_Click);
            // 
            // m_extLinkField
            // 
            this.m_extLinkField.SourceTypeString = "";
            // 
            // cGestionnaireEditionSousObjetDonnee1
            // 
            this.cGestionnaireEditionSousObjetDonnee1.ObjetEdite = null;
            // 
            // CFormEditionPreferenceTypeForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(830, 567);
            this.Controls.Add(this.m_panGeneral);
            this.Controls.Add(this.m_btnEditerObjet);
            this.Controls.Add(this.m_btnValiderModifications);
            this.Controls.Add(this.m_btnAnnulerModifications);
            this.KeyPreview = true;
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CFormEditionPreferenceTypeForm";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panGeneral.ResumeLayout(false);
            this.m_panGeneral.PerformLayout();
            this.m_splitContainer.Panel1.ResumeLayout(false);
            this.m_splitContainer.Panel2.ResumeLayout(false);
            this.m_splitContainer.ResumeLayout(false);
            this.m_panelSelectForm.ResumeLayout(false);
            this.ResumeLayout(false);

		}



		#endregion

		

		public CFormEditionPreferenceTypeForm()
		{
			InitializeComponent();
			InitChamps();
			m_gestionnaireModeEdition.ModeEdition = false;
		}

		//INITIALISATION
		public CResultAErreur InitChamps()
		{
			CTimosApp.Titre = I.T("Favourite forms|10024");

            // Init de la liste des types 
            m_wndListeTypes.Items.Clear();
            foreach (CInfoClasseDynamique info in DynamicClassAttribute.GetAllDynamicClass(typeof(TableAttribute)))
            {
                ListViewItem item = new ListViewItem(info.Nom);
                item.Tag = info;
                m_wndListeTypes.Items.Add(item);
            }

            
			return CResultAErreur.True;
		}


		#region IFormNavigable Membres

        public event ContexteFormEventHandler AfterGetContexte;
        public event ContexteFormEventHandler AfterInitFromContexte;

        public CContexteFormNavigable GetContexte()
        {
            CContexteFormNavigable contexte = new CContexteFormNavigable(GetType());
            if (AfterGetContexte != null)
                AfterGetContexte(this, contexte);
            return contexte;
        }


        public bool QueryClose()
        {
            return true;
        }

        public sc2i.common.CResultAErreur InitFromContexte(CContexteFormNavigable contexte)
        {
            if (AfterInitFromContexte != null)
                AfterInitFromContexte(this, contexte);
            return CResultAErreur.True;
        }
        //------------------------------------------------------------------
        public CResultAErreur Actualiser()
        {
            return InitFromContexte(GetContexte());
        }


		#endregion

        private void m_btnEditerObjet_Click(object sender, EventArgs e)
        {

            m_gestionnaireModeEdition.ModeEdition = true;
        }

        private void m_btnValiderModifications_Click(object sender, EventArgs e)
        {
            CResultAErreur result = MAJ_Champs();

            if (result)
            {
                // Enregistre le dictionnaire de préférences dans le registre de la base Timos
                result = CDictionnaireTypeEditeTypeFormPrefere.SaveInstance();
            }
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur.Erreurs);
            }
            else
                m_gestionnaireModeEdition.ModeEdition = false;
            

            CDictionnaireTypeEditeTypeFormPrefere.ResetInstance();

            

        }

        private void m_btnAnnulerModifications_Click(object sender, EventArgs e)
        {

            m_gestionnaireModeEdition.ModeEdition = false;

        }

        CInfoClasseDynamique m_infoClasseEncours = null;
        private void m_wndListeTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            MAJ_Champs();
            if (m_wndListeTypes.SelectedItems.Count == 1)
            {

                CInfoClasseDynamique info = (CInfoClasseDynamique) m_wndListeTypes.SelectedItems[0].Tag;
                if (info != null)
                {
                    m_infoClasseEncours = info;
                    m_panelSelectForm.Visible = true;

                    Type typeAEditer = info.Classe;

                    

                    CDictionnaireTypeEditeTypeFormPrefere dico = CDictionnaireTypeEditeTypeFormPrefere.GetInstance();
                    CReferenceTypeForm refTypeForm = null;
                    if (dico.TryGetValue(typeAEditer, out refTypeForm))
                    {
                        m_panelFormPref.Init(typeAEditer, refTypeForm);
                    }
                    else
                    {
                        CReferenceTypeForm rt = new CReferenceTypeFormAvecCondition();
                        m_panelFormPref.Init(typeAEditer, rt);
                    }

                }

            }
            else
            {
                m_panelSelectForm.Visible = false;
            }

        }

        public CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = CResultAErreur.True;

            if (m_infoClasseEncours != null && m_gestionnaireModeEdition.ModeEdition)
            {
                CDictionnaireTypeEditeTypeFormPrefere dico = CDictionnaireTypeEditeTypeFormPrefere.GetInstance();
                Type typeAEditer = m_infoClasseEncours.Classe;
                CReferenceTypeForm rt = m_panelFormPref.GetReferenceTypeForm();
                if (rt != null)
                    dico[typeAEditer] = rt;
               
            }
            

            return result;

        }

        
        public string GetTitle()
        {
            return I.T("Favourite forms|10024");
        }
        public Image GetImage()
        {
            return Resources.favorite_form;
        }


		
	}
}

