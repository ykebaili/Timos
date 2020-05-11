using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using sc2i.common;
using System.Windows.Forms;
using sc2i.win32.navigation;
using sc2i.data;
using sc2i.win32.data;
using sc2i.multitiers.client;
using timos.data;
using timos.securite;


namespace timos
{
    [sc2i.win32.data.navigation.ObjectListeur(typeof(CPort))]
    public class CFormListePorts : CFormListeStandardTimos, IFormNavigable
    {
        private System.ComponentModel.IContainer components = null;

        public CFormListePorts()
            : base(typeof(CPort))
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
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            // 
            // m_panelListe
            // 
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Name";
            glColumn1.Propriete = "Libelle";
            glColumn1.Text = "Label|50";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 300;
         
            this.m_panelListe.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
																					glColumn1});
            this.m_panelListe.Name = "m_panelListe";
            this.m_panelListe.Size = new System.Drawing.Size(504, 376);
            // 
            // CFormListeEquipementsLogiques
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(504, 376);
            this.Name = "CFormListePorts";

        }
        #endregion

        //-------------------------------------------------------------------
        public override string  GetTitle()
        {
            return I.T("Ports list|30373");
        }

        //-------------------------------------------------------------------
        protected override void InitPanel()
        {
            m_panelListe.InitFromListeObjets(
                m_listeObjets,
                typeof(CPort),
                null, "");

            m_panelListe.RemplirGrille();
        }



    }
}

