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


namespace spv.win32
{
    [sc2i.win32.data.navigation.ObjectListeur(typeof(CSpvAlarmcouleur))]
    public class CFormListeAlarmColor : CFormListeStandard, IFormNavigable
    {

        private System.ComponentModel.IContainer components = null;
        private ImageList m_ImageListSeverity;
        
        public CFormListeAlarmColor()
            : base(typeof(CSpvAlarmcouleur))
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
            Init();
        }

        public CFormListeAlarmColor(CListeObjetsDonnees listeObjets)
            : base(listeObjets)
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            TitreForce = I.T("Alarm colors|60056");
            m_ImageListSeverity = CUtilCouleursAlarmes.GetImageListSeverity(m_panelListe.Font.Height);
            m_panelListe.OnGetImage += new sc2i.win32.common.GlacialListGetImageEventHandler(GetImage);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormListeAlarmColor));
            this.m_panelMilieu.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelListe
            // 
            this.m_panelListe.BoutonAjouterVisible = false;
            this.m_panelListe.BoutonSupprimerVisible = false;
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Severity";
            glColumn1.Propriete = "TypeCouleur.Libelle";
            glColumn1.Text = "Severity|60026";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 500;
            this.m_panelListe.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_panelListe.HasImages = true;
            this.m_panelListe.Size = new System.Drawing.Size(448, 376);
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
            this.m_panelDroit.Location = new System.Drawing.Point(448, 0);
            this.m_panelDroit.Size = new System.Drawing.Size(0, 376);
            this.m_extStyle.SetStyleBackColor(this.m_panelDroit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDroit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelBas
            // 
            this.m_panelBas.Location = new System.Drawing.Point(0, 376);
            this.m_panelBas.Size = new System.Drawing.Size(448, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelHaut
            // 
            this.m_panelHaut.Size = new System.Drawing.Size(448, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMilieu
            // 
            this.m_panelMilieu.Size = new System.Drawing.Size(448, 376);
            this.m_extStyle.SetStyleBackColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // CFormListeAlarmColor
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BoutonAjouterVisible = false;
            this.BoutonSupprimerVisible = false;
            this.ClientSize = new System.Drawing.Size(448, 376);
            this.Name = "CFormListeAlarmColor";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMilieu.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        //-------------------------------------------------------------------
        protected override void InitPanel()
        {
            m_panelListe.InitFromListeObjets(
                m_listeObjets,
                typeof(CSpvAlarmcouleur),
                typeof(CFormEditionAlarmeCouleur),
                null, "");
            
            m_panelListe.RemplirGrille();            
        }

        public Image GetImage(object obj)
        {
            CSpvAlarmcouleur alarmColor = obj as CSpvAlarmcouleur;
            if (alarmColor != null)
                return m_ImageListSeverity.Images[(int)alarmColor.CodeCouleur];
            else
                return null;
            

        }
    }
}

