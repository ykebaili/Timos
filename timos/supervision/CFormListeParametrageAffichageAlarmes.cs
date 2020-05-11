using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using sc2i.win32.navigation;
using sc2i.data;
using sc2i.win32.data;
using sc2i.common;

using timos.acteurs;
using timos.data.supervision;
using timos.data.projet.gantt;

namespace timos.supervision
{
    [sc2i.win32.data.navigation.ObjectListeur(typeof(CParametrageAffichageListeAlarmes))]
	public class CFormListeParametrageAffichageAlarmes : CFormListeStandardTimos, IFormNavigable
	{
        private Panel m_panelAfficherAlarmes;
        private Button m_btnAfficherAlarmes;
		
		private System.ComponentModel.IContainer components = null;

        public CFormListeParametrageAffichageAlarmes()
            : base(typeof(CParametrageAffichageListeAlarmes))
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
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

		#region Designer generated code
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormListeParametrageAffichageAlarmes));
            this.m_btnAfficherAlarmes = new System.Windows.Forms.Button();
            this.m_panelAfficherAlarmes = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnActions)).BeginInit();
            this.m_panelActions.SuspendLayout();
            this.m_panelLinkList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imgListe)).BeginInit();
            this.m_panelMilieu.SuspendLayout();
            this.m_panelAfficherAlarmes.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lnkListe
            // 
            this.m_extStyle.SetStyleBackColor(this.m_lnkListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkListe.Text = "List";
            // 
            // m_btnActions
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelActions
            // 
            this.m_extStyle.SetStyleBackColor(this.m_panelActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lnkActions
            // 
            this.m_extStyle.SetStyleBackColor(this.m_lnkActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkActions.Text = "Actions";
            // 
            // m_panelLinkList
            // 
            this.m_extStyle.SetStyleBackColor(this.m_panelLinkList, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelLinkList, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_imgListe
            // 
            this.m_extStyle.SetStyleBackColor(this.m_imgListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_imgListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
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
            glColumn1.Name = "Name";
            glColumn1.Propriete = "Libelle";
            glColumn1.Text = "Label|50";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 120;
            this.m_panelListe.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_panelListe.Size = new System.Drawing.Size(800, 376);
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
            this.m_panelDroit.Location = new System.Drawing.Point(800, 0);
            this.m_panelDroit.Size = new System.Drawing.Size(0, 376);
            this.m_extStyle.SetStyleBackColor(this.m_panelDroit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDroit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelBas
            // 
            this.m_panelBas.Location = new System.Drawing.Point(0, 376);
            this.m_panelBas.Size = new System.Drawing.Size(800, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelHaut
            // 
            this.m_panelHaut.Size = new System.Drawing.Size(800, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMilieu
            // 
            this.m_panelMilieu.Controls.Add(this.m_panelAfficherAlarmes);
            this.m_panelMilieu.Size = new System.Drawing.Size(800, 376);
            this.m_extStyle.SetStyleBackColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMilieu.Controls.SetChildIndex(this.m_panelListe, 0);
            this.m_panelMilieu.Controls.SetChildIndex(this.m_panelLinkList, 0);
            this.m_panelMilieu.Controls.SetChildIndex(this.m_panelActions, 0);
            this.m_panelMilieu.Controls.SetChildIndex(this.m_panelAfficherAlarmes, 0);
            // 
            // m_btnAfficherAlarmes
            // 
            this.m_btnAfficherAlarmes.BackColor = System.Drawing.Color.Transparent;
            this.m_btnAfficherAlarmes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnAfficherAlarmes.ForeColor = System.Drawing.Color.Blue;
            this.m_btnAfficherAlarmes.Location = new System.Drawing.Point(8, 2);
            this.m_btnAfficherAlarmes.Name = "m_btnAfficherAlarmes";
            this.m_btnAfficherAlarmes.Size = new System.Drawing.Size(90, 22);
            this.m_extStyle.SetStyleBackColor(this.m_btnAfficherAlarmes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAfficherAlarmes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAfficherAlarmes.TabIndex = 6;
            this.m_btnAfficherAlarmes.Text = "Display|10247";
            this.m_btnAfficherAlarmes.UseVisualStyleBackColor = false;
            this.m_btnAfficherAlarmes.Click += new System.EventHandler(this.m_btnAfficherAlarmes_Click);
            // 
            // m_panelAfficherAlarmes
            // 
            this.m_panelAfficherAlarmes.BackgroundImage = global::timos.Properties.Resources.fond_menu_liste_3;
            this.m_panelAfficherAlarmes.Controls.Add(this.m_btnAfficherAlarmes);
            this.m_panelAfficherAlarmes.Location = new System.Drawing.Point(492, 0);
            this.m_panelAfficherAlarmes.Name = "m_panelAfficherAlarmes";
            this.m_panelAfficherAlarmes.Size = new System.Drawing.Size(111, 25);
            this.m_extStyle.SetStyleBackColor(this.m_panelAfficherAlarmes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelAfficherAlarmes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelAfficherAlarmes.TabIndex = 7;
            // 
            // CFormListeParametrageAffichageAlarmes
            // 
            this.ClientSize = new System.Drawing.Size(800, 376);
            this.Name = "CFormListeParametrageAffichageAlarmes";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnActions)).EndInit();
            this.m_panelActions.ResumeLayout(false);
            this.m_panelLinkList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_imgListe)).EndInit();
            this.m_panelMilieu.ResumeLayout(false);
            this.m_panelAfficherAlarmes.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		
        //-------------------------------------------------------------------
		protected override void InitPanel()
		{
			m_panelListe.InitFromListeObjets(
				m_listeObjets,
                typeof(CParametrageAffichageListeAlarmes),	
				null, "");

			m_panelListe.RemplirGrille();
		}
		
        //-------------------------------------------------------------------
        public override string GetTitle()
        {
            return I.T("Alarm Display Setting List|10223");
		}

        private void m_btnAfficherAlarmes_Click(object sender, System.EventArgs e)
        {
            if (ElementSelectionne != null)
            {
                CParametrageAffichageListeAlarmes paramSelectionne = ElementSelectionne as CParametrageAffichageListeAlarmes;
                if (paramSelectionne != null)
                {
                    CFormConsultationAlarmesEnCours.AfficheAlarmes(
                        CFournisseurAlarmesPourAffichage.GetAlarmesAAfficher(
                            CTimosApp.SessionClient.IdSession),
                            paramSelectionne,
                            CTimosApp.Navigateur);

                }
            }
        }

		
	}
}

