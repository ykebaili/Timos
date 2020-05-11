using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using sc2i.win32.navigation;
using sc2i.data;
using sc2i.win32.data;
using sc2i.common;

using timos.acteurs;
using sc2i.process.workflow;
using sc2i.workflow;
using sc2i.win32.common;
using timos.securite;

namespace timos.process.workflow
{
    [DynamicForm("Current workflow steps")]
	public class CFormListeEtapesWorkflowEnCours : CFormListeStandardTimos, IFormNavigable
	{
		
		private System.ComponentModel.IContainer components = null;

        public CFormListeEtapesWorkflowEnCours()
			:base(typeof(CEtapeWorkflow))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormListeEtapesWorkflowEnCours));
            ((System.ComponentModel.ISupportInitialize)(this.m_btnActions)).BeginInit();
            this.m_panelActions.SuspendLayout();
            this.m_panelLinkList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imgListe)).BeginInit();
            this.m_panelMilieu.SuspendLayout();
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
            this.m_panelListe.Size = new System.Drawing.Size(448, 376);
            this.m_extStyle.SetStyleBackColor(this.m_panelListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListe.OnObjetDoubleClick += new System.EventHandler(this.m_panelListe_OnObjetDoubleClick);
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
            // CFormListeEtapesWorkflowEnCours
            // 
            this.ClientSize = new System.Drawing.Size(448, 376);
            this.Name = "CFormListeEtapesWorkflowEnCours";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnActions)).EndInit();
            this.m_panelActions.ResumeLayout(false);
            this.m_panelLinkList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_imgListe)).EndInit();
            this.m_panelMilieu.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------
		protected override void InitPanel()
		{
            CFormMain.GetInstance().CancelEtapePermanente();

            CFiltreData filtre = null;
            CDonneesActeurUtilisateur user = CUtilSession.GetUserForSession(m_listeObjets.ContexteDonnee);
            if ( user != null )
            {
                CListeObjetsDonnees lstPourActeur = user.Acteur.GetEtapeWorkflowsEnCours();
                filtre = lstPourActeur.FiltrePrincipal;
            }
            else
                filtre = new CFiltreData (CEtapeWorkflow.c_champEtat+"=@1",(int)EEtatEtapeWorkflow.Démarrée);

            /*
            string[] strCodes = CUtilSession.GetCodesAffectationsEtapeConcernant(m_listeObjets.ContexteDonnee);
            CFiltreData filtreAss = new CFiltreData( );
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
            */



            //m_listeObjets.Filtre = filtre;
            m_panelListe.FiltreDeBase = filtre;
			m_panelListe.InitFromListeObjets(
				m_listeObjets,
				typeof(CEtapeWorkflow),	
				null, "");

            m_panelListe.BoutonAjouterVisible = false;
            m_panelListe.BoutonSupprimerVisible = false;
            m_panelListe.BoutonModifierVisible = false;

			m_panelListe.RemplirGrille();
		}
		//-------------------------------------------------------------------
        public override string GetTitle()
        {
            return I.T("Workflows Steps in progress|10400");
		}

        //-------------------------------------------------------------------
        private void m_panelListe_OnObjetDoubleClick(object sender, System.EventArgs e)
        {
            if (m_panelListe.ElementsSelectionnes.Length == 1)
            {
                CEtapeWorkflow etape = m_panelListe.ElementsSelectionnes[0] as CEtapeWorkflow;
                if (etape != null)
                {
                    CResultAErreur result = CGestionnaireWorkflowsEnCours.Instance.AfficheEtape(etape);
                    if (!result)
                        CFormAlerte.Afficher(result.MessageErreur);
                }
            }
        }
		
	}
}

