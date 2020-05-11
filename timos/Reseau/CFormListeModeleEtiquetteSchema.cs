using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using sc2i.win32.navigation;
using sc2i.data;
using sc2i.win32.data;
using sc2i.data.dynamic;
using sc2i.common;

using timos.data;

namespace timos
{
    [sc2i.win32.data.navigation.ObjectListeur(typeof(CModeleEtiquetteSchema))]
    public class CFormListeModeleEtiquetteSchema : CFormListeStandardTimos, IFormNavigable
    {

        private System.ComponentModel.IContainer components = null;

        public CFormListeModeleEtiquetteSchema()
            : base(typeof(CModeleEtiquetteSchema))
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
            sc2i.win32.common.GLColumn listViewAutoFilledColumn1;
            listViewAutoFilledColumn1 = new sc2i.win32.common.GLColumn();
            // 
            // m_panelListe
            // 
            this.m_panelListe.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
																									listViewAutoFilledColumn1});
            this.m_panelListe.Name = "m_panelListe";
            // 
            // listViewAutoFilledColumn1
            // 
            listViewAutoFilledColumn1.Propriete = "Libelle";
            listViewAutoFilledColumn1.Text = "Label|50";
            listViewAutoFilledColumn1.Width = 120;
            // 
            // CFormListeChampsCalcules
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(448, 376);
            this.Name = "CFormListeModeleEtiquetteSchema";

        }
        #endregion
        //-------------------------------------------------------------------
        protected override void InitPanel()
        {
            m_panelListe.InitFromListeObjets(
                m_listeObjets,
                typeof(CModeleEtiquetteSchema),
                typeof(CFormEditionModeleEtiquetteSchema),
                null, "");

            m_panelListe.RemplirGrille();
        }

        //-------------------------------------------------------------------
        public override string GetTitle()
        {
            return I.T("Diagram label models|30405");
        }

    }
}

