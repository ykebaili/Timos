using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using sc2i.win32.navigation;
using sc2i.data;
using sc2i.win32.data;
using sc2i.common;
using spv.data;

using sc2i.win32.data.navigation;
using sc2i.win32.common;

namespace spv.win32
{
    [sc2i.win32.data.navigation.ObjectListeur(typeof(CConsultationAlarmesEnCoursInDb))]
    public class CFormListeConsultationAlarmesEnCours : CFormListeStandard, IFormNavigable
    {
        private Button m_btnActivate;

        private System.ComponentModel.IContainer components = null;

        public CFormListeConsultationAlarmesEnCours()
            : base(typeof(CConsultationAlarmesEnCoursInDb))
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }

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

        #region Designer generated code
        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormListeConsultationAlarmesEnCours));
            this.m_btnActivate = new System.Windows.Forms.Button();
            this.m_panelMilieu.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelListe
            // 
            this.m_panelListe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Name";
            glColumn1.Propriete = "Libelle";
            glColumn1.Text = "Libelle";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 100;
            this.m_panelListe.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_panelListe.Dock = System.Windows.Forms.DockStyle.None;
            this.m_panelListe.ForeColor = System.Drawing.SystemColors.Desktop;
            this.m_panelListe.Size = new System.Drawing.Size(626, 376);
            this.m_extStyle.SetStyleBackColor(this.m_panelListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelGauche
            // 
            this.m_panelGauche.Size = new System.Drawing.Size(0, 376);
            this.m_extStyle.SetStyleBackColor(this.m_panelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelDroit
            // 
            this.m_panelDroit.Location = new System.Drawing.Point(626, 0);
            this.m_panelDroit.Size = new System.Drawing.Size(0, 376);
            this.m_extStyle.SetStyleBackColor(this.m_panelDroit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDroit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelBas
            // 
            this.m_panelBas.Location = new System.Drawing.Point(0, 376);
            this.m_panelBas.Size = new System.Drawing.Size(626, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelHaut
            // 
            this.m_panelHaut.Size = new System.Drawing.Size(626, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMilieu
            // 
            this.m_panelMilieu.Controls.Add(this.m_btnActivate);
            this.m_panelMilieu.Size = new System.Drawing.Size(626, 376);
            this.m_extStyle.SetStyleBackColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMilieu.Controls.SetChildIndex(this.m_panelListe, 0);
            this.m_panelMilieu.Controls.SetChildIndex(this.m_btnActivate, 0);
            // 
            // m_btnActivate
            // 
            this.m_btnActivate.BackColor = System.Drawing.Color.LightSteelBlue;
            this.m_btnActivate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.m_btnActivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnActivate.ForeColor = System.Drawing.Color.MediumBlue;
            this.m_btnActivate.Location = new System.Drawing.Point(364, 0);
            this.m_btnActivate.Name = "m_btnActivate";
            this.m_btnActivate.Size = new System.Drawing.Size(75, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnActivate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnActivate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnActivate.TabIndex = 2;
            this.m_btnActivate.Text = "Activate";
            this.m_btnActivate.UseVisualStyleBackColor = false;
            this.m_btnActivate.Click += new System.EventHandler(this.m_btnActivate_Click);
            // 
            // CFormListeConsultationAlarmesEnCours
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(626, 376);
            this.Name = "CFormListeConsultationAlarmesEnCours";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMilieu.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        //-------------------------------------------------------------------
        protected override void InitPanel()
        {
            TitreForce = I.T("Current alarm list|10006");

             m_panelListe.InitFromListeObjets(
                 m_listeObjets,
                 typeof(CConsultationAlarmesEnCoursInDb),
                 typeof(CFormEditionConsultationAlarmesEnCours2),
                 null, "");
             
            m_panelListe.RemplirGrille();
        }

        
        private void m_btnActivate_Click(object sender, EventArgs e)
        {
            using (CWaitCursor waiter = new CWaitCursor())
            {
                CListeObjetsDonnees lstConsultations = m_panelListe.GetElementsSelectionnes();
                if (lstConsultations.Count <= 0)
                {
                    CFormAlerte.Afficher(I.T("Any selected consultation |60062"),  EFormAlerteType.Exclamation);
                }
                foreach (CConsultationAlarmesEnCoursInDb consultation in lstConsultations)
                {
                    CFormListeAlarmeEnCours listAlarmeEnCours = new CFormListeAlarmeEnCours(consultation, Navigateur);
                    listAlarmeEnCours.Show();
                }
            }
        }

    }
}
