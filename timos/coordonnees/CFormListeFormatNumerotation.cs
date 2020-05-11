using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using timos.data;
using sc2i.common;
using sc2i.win32.navigation;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.win32.data;
using sc2i.win32.data.navigation;


namespace timos
{
    [sc2i.win32.data.navigation.ObjectListeur(typeof(CFormatNumerotation))]
    public class CFormListeFormatNumerotation :
        CFormListeStandardTimos,
        IFormNavigable
    {
        private System.ComponentModel.IContainer components = null;
        private string m_strCodeRole = "";

        //-------------------------------------------------------------------
        public CFormListeFormatNumerotation()
            : base(typeof(CFormatNumerotation))
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }

        //-------------------------------------------------------------------
        public CFormListeFormatNumerotation(string strCodeRole)
            : base(typeof(CFormatNumerotation))
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
            m_strCodeRole = strCodeRole;
        }
        //-------------------------------------------------------------------
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
        //-------------------------------------------------------------------
        #region Designer generated code
        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormListeFormatNumerotation));
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn3 = new sc2i.win32.common.GLColumn();
            this.m_panelMilieu.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelListe
            // 
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "c_colLibelle";
            glColumn1.Propriete = "Libelle";
            glColumn1.Text = "Label|50";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 350;
            glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "c_colSequence";
            glColumn2.Propriete = "Sequence";
            glColumn2.Text = "Sequence|315";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 200;
            glColumn3.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn3.ActiveControlItems")));
            glColumn3.BackColor = System.Drawing.Color.Transparent;
            glColumn3.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn3.ForColor = System.Drawing.Color.Black;
            glColumn3.ImageIndex = -1;
            glColumn3.IsCheckColumn = false;
            glColumn3.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn3.Name = "c_colLongueur";
            glColumn3.Propriete = "NombreCaractere";
            glColumn3.Text = "Numbering length|314";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 200;
            this.m_panelListe.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3});
            this.m_extStyle.SetStyleBackColor(this.m_panelListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListe.OnNewObjetDonnee += new sc2i.win32.data.navigation.OnNewObjetDonneeEventHandler(this.m_panelListe_OnNewObjetDonnee);
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
            // CFormListeFormatNumerotation
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(448, 376);
            this.Name = "CFormListeFormatNumerotation";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMilieu.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        //-------------------------------------------------------------------------
        protected override void InitPanel()
        {
            m_panelListe.InitFromListeObjets(
                m_listeObjets,
                typeof(CFormatNumerotation),
                typeof(CFormEditionFormatNumerotation),
                null, "");

            m_panelListe.RemplirGrille();

            m_panelListe.MultiSelect = true;
        }
        //-------------------------------------------------------------------
        public override string GetTitle()
        {
            return I.T("List of Numbering Formats|316");
        }


        private void m_panelListe_OnNewObjetDonnee(object sender, sc2i.data.CObjetDonnee nouvelObjet, ref bool bCancel)
        {

            //if (nouvelObjet is CFormatNumerotation && m_strCodeRole != "")
            //    ((CFormatNumerotation)nouvelObjet).CodeRole = m_strCodeRole;
        }
    }

    //-------------------------------------------------------------------
    //public class CSelectionneurFormatNumerotation : ISelectionneurChampCustom
    //{
    //    public string m_strCodeRole = "";

    //    //-------------------------------------------------------
    //    public CSelectionneurFormatNumerotation()
    //    {
    //    }

    //    //-------------------------------------------------------
    //    public CSelectionneurFormatNumerotation(string strCodeRole)
    //    {
    //        m_strCodeRole = strCodeRole;
    //    }

    //    //-------------------------------------------------------
    //    public string CodeRole
    //    {
    //        get
    //        {
    //            return m_strCodeRole;
    //        }
    //        set
    //        {
    //            m_strCodeRole = value;
    //        }
    //    }

    //    //-------------------------------------------------------
    //    public CFormatNumerotation SelectChamp(CFormatNumerotation lastSelectionne)
    //    {
    //        CFormListeFormatNumerotation form = new CFormListeFormatNumerotation(m_strCodeRole);
    //        return (CFormatNumerotation)CFormNavigateurPopupListe.SelectObject( 
    //            form, 
    //            lastSelectionne, 
    //            CFormNavigateurPopupListe.CalculeContexteUtilisation ( form ));
    //    }
    //}
}



