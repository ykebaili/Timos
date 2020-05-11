using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using sc2i.win32.data;
using sc2i.multitiers.client;
using sc2i.process;
using sc2i.data;
using sc2i.common;

using sc2i.workflow;
using timos.acteurs;

using timos.securite;
using sc2i.win32.common;
using sc2i.process.workflow;
using timos.process.workflow;
using System.Threading;

namespace timos
{
	/// <summary>
	/// Description résumée de CPanelNotificationUtilisateur.
	/// </summary>
	public class CPanelNotificationUtilisateur : System.Windows.Forms.UserControl
	{
		private static int c_nImageIntervention = 0;
        private static int c_nNbClignotementsWorkflow = 20;
		
		private CRecepteurNotification m_recepteurInterventions = null;
        private CRecepteurNotification m_recepteurWorkflow = null;

        private int? m_nIdEtapeToLaunch = null;
        private int m_nNbEtapesEnCours = 0;

        private int m_nNbClignotementsWorkflowsRestant = 0;


		private System.Windows.Forms.PictureBox m_imageInterventionProcess;
		private System.Windows.Forms.Panel m_panelInterventionProcess;
		private System.Windows.Forms.ImageList m_icones;
		private System.Windows.Forms.Timer m_timerClignotant;
		private System.Windows.Forms.ToolTip m_tooltip;
		private System.Windows.Forms.PictureBox m_imageMessagerie;
		private System.Windows.Forms.PictureBox m_btnAgenda;
		private System.Windows.Forms.PictureBox m_btnSynchro;
		private System.Windows.Forms.ImageList m_imagesSynchro;
        private PictureBox m_pictureWorkflow;
        private Panel m_panelWorkflow;
        private Label m_lblNbToDo;
        private System.Windows.Forms.Timer m_timerCheckEtapesEncours;
		private System.ComponentModel.IContainer components;

		public CPanelNotificationUtilisateur()
		{
			// Cet appel est requis par le Concepteur de formulaires Windows.Forms.
			InitializeComponent();

			// TODO : ajoutez les initialisations après l'appel à InitializeComponent
            //Vérifie le droit sur les worfklows
            CSessionClient session = CTimosApp.SessionClient;
            if (session != null && session.GetInfoUtilisateur() != null)
            {
                CRestrictionUtilisateurSurType rest = session.GetInfoUtilisateur().GetRestrictionsSur(typeof(CWorkflow), null);
                if ((rest.RestrictionGlobale & ERestriction.ReadOnly) == ERestriction.ReadOnly)
                {
                    m_panelWorkflow.Visible = false;
                }
            }
		}

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
					if ( m_recepteurInterventions != null )
						m_recepteurInterventions.Dispose();
					m_recepteurInterventions = null;
                    if (m_recepteurWorkflow != null)
                        m_recepteurWorkflow.Dispose();
                    m_recepteurWorkflow = null;
				}
			}
			base.Dispose( disposing );
		}

		#region Code généré par le Concepteur de composants
		/// <summary> 
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPanelNotificationUtilisateur));
            this.m_panelInterventionProcess = new System.Windows.Forms.Panel();
            this.m_imageInterventionProcess = new System.Windows.Forms.PictureBox();
            this.m_icones = new System.Windows.Forms.ImageList(this.components);
            this.m_timerClignotant = new System.Windows.Forms.Timer(this.components);
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.m_btnSynchro = new System.Windows.Forms.PictureBox();
            this.m_imageMessagerie = new System.Windows.Forms.PictureBox();
            this.m_btnAgenda = new System.Windows.Forms.PictureBox();
            this.m_pictureWorkflow = new System.Windows.Forms.PictureBox();
            this.m_imagesSynchro = new System.Windows.Forms.ImageList(this.components);
            this.m_panelWorkflow = new System.Windows.Forms.Panel();
            this.m_lblNbToDo = new System.Windows.Forms.Label();
            this.m_timerCheckEtapesEncours = new System.Windows.Forms.Timer(this.components);
            this.m_panelInterventionProcess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageInterventionProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnSynchro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageMessagerie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnAgenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureWorkflow)).BeginInit();
            this.m_panelWorkflow.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelInterventionProcess
            // 
            this.m_panelInterventionProcess.Controls.Add(this.m_imageInterventionProcess);
            this.m_panelInterventionProcess.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_panelInterventionProcess.Location = new System.Drawing.Point(35, 0);
            this.m_panelInterventionProcess.Name = "m_panelInterventionProcess";
            this.m_panelInterventionProcess.Size = new System.Drawing.Size(34, 32);
            this.m_panelInterventionProcess.TabIndex = 1;
            // 
            // m_imageInterventionProcess
            // 
            this.m_imageInterventionProcess.BackColor = System.Drawing.Color.Transparent;
            this.m_imageInterventionProcess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_imageInterventionProcess.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_imageInterventionProcess.Image = global::timos.Properties.Resources.warning;
            this.m_imageInterventionProcess.Location = new System.Drawing.Point(0, 0);
            this.m_imageInterventionProcess.Name = "m_imageInterventionProcess";
            this.m_imageInterventionProcess.Size = new System.Drawing.Size(32, 32);
            this.m_imageInterventionProcess.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_imageInterventionProcess.TabIndex = 0;
            this.m_imageInterventionProcess.TabStop = false;
            this.m_tooltip.SetToolTip(this.m_imageInterventionProcess, "Une intervention utilisateur est nécéssaire sur certaines actions en cours");
            this.m_imageInterventionProcess.Click += new System.EventHandler(this.m_imageInterventionProcess_Click);
            // 
            // m_icones
            // 
            this.m_icones.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_icones.ImageStream")));
            this.m_icones.TransparentColor = System.Drawing.Color.Transparent;
            this.m_icones.Images.SetKeyName(0, "warning.png");
            this.m_icones.Images.SetKeyName(1, "Picto-anim-avertissement.gif");
            this.m_icones.Images.SetKeyName(2, "");
            this.m_icones.Images.SetKeyName(3, "");
            // 
            // m_timerClignotant
            // 
            this.m_timerClignotant.Enabled = true;
            this.m_timerClignotant.Interval = 500;
            this.m_timerClignotant.Tick += new System.EventHandler(this.m_timerClignotant_Tick);
            // 
            // m_btnSynchro
            // 
            this.m_btnSynchro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnSynchro.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnSynchro.Image = global::timos.Properties.Resources.web;
            this.m_btnSynchro.Location = new System.Drawing.Point(-26, 0);
            this.m_btnSynchro.Name = "m_btnSynchro";
            this.m_btnSynchro.Size = new System.Drawing.Size(29, 32);
            this.m_btnSynchro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_btnSynchro.TabIndex = 5;
            this.m_btnSynchro.TabStop = false;
            this.m_tooltip.SetToolTip(this.m_btnSynchro, "Messagerie");
            this.m_btnSynchro.Visible = false;
            // 
            // m_imageMessagerie
            // 
            this.m_imageMessagerie.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_imageMessagerie.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_imageMessagerie.Image = global::timos.Properties.Resources.email;
            this.m_imageMessagerie.Location = new System.Drawing.Point(3, 0);
            this.m_imageMessagerie.Name = "m_imageMessagerie";
            this.m_imageMessagerie.Size = new System.Drawing.Size(32, 32);
            this.m_imageMessagerie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_imageMessagerie.TabIndex = 3;
            this.m_imageMessagerie.TabStop = false;
            this.m_tooltip.SetToolTip(this.m_imageMessagerie, "Messagerie");
            this.m_imageMessagerie.Visible = false;
            this.m_imageMessagerie.Click += new System.EventHandler(this.m_imageMessagerie_Click);
            // 
            // m_btnAgenda
            // 
            this.m_btnAgenda.BackColor = System.Drawing.Color.Transparent;
            this.m_btnAgenda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnAgenda.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnAgenda.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAgenda.Image")));
            this.m_btnAgenda.Location = new System.Drawing.Point(69, 0);
            this.m_btnAgenda.Name = "m_btnAgenda";
            this.m_btnAgenda.Size = new System.Drawing.Size(33, 32);
            this.m_btnAgenda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_btnAgenda.TabIndex = 4;
            this.m_btnAgenda.TabStop = false;
            this.m_tooltip.SetToolTip(this.m_btnAgenda, "Une intervention utilisateur est nécéssaire sur certaines actions en cours");
            this.m_btnAgenda.Click += new System.EventHandler(this.m_btnAgenda_Click);
            // 
            // m_pictureWorkflow
            // 
            this.m_pictureWorkflow.BackColor = System.Drawing.Color.Transparent;
            this.m_pictureWorkflow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_pictureWorkflow.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_pictureWorkflow.Image = global::timos.Properties.Resources._1346738948_task;
            this.m_pictureWorkflow.Location = new System.Drawing.Point(0, 0);
            this.m_pictureWorkflow.Name = "m_pictureWorkflow";
            this.m_pictureWorkflow.Size = new System.Drawing.Size(36, 32);
            this.m_pictureWorkflow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_pictureWorkflow.TabIndex = 6;
            this.m_pictureWorkflow.TabStop = false;
            this.m_pictureWorkflow.Click += new System.EventHandler(this.m_pictureWorkflow_Click);
            // 
            // m_imagesSynchro
            // 
            this.m_imagesSynchro.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imagesSynchro.ImageStream")));
            this.m_imagesSynchro.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imagesSynchro.Images.SetKeyName(0, "");
            this.m_imagesSynchro.Images.SetKeyName(1, "");
            // 
            // m_panelWorkflow
            // 
            this.m_panelWorkflow.Controls.Add(this.m_lblNbToDo);
            this.m_panelWorkflow.Controls.Add(this.m_pictureWorkflow);
            this.m_panelWorkflow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_panelWorkflow.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_panelWorkflow.Location = new System.Drawing.Point(102, 0);
            this.m_panelWorkflow.Name = "m_panelWorkflow";
            this.m_panelWorkflow.Size = new System.Drawing.Size(54, 32);
            this.m_panelWorkflow.TabIndex = 7;
            this.m_panelWorkflow.Click += new System.EventHandler(this.m_pictureWorkflow_Click);
            // 
            // m_lblNbToDo
            // 
            this.m_lblNbToDo.BackColor = System.Drawing.Color.DarkOrange;
            this.m_lblNbToDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblNbToDo.ForeColor = System.Drawing.Color.White;
            this.m_lblNbToDo.Location = new System.Drawing.Point(28, 3);
            this.m_lblNbToDo.Margin = new System.Windows.Forms.Padding(0);
            this.m_lblNbToDo.Name = "m_lblNbToDo";
            this.m_lblNbToDo.Size = new System.Drawing.Size(20, 18);
            this.m_lblNbToDo.TabIndex = 7;
            this.m_lblNbToDo.Text = "99";
            this.m_lblNbToDo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_lblNbToDo.Visible = false;
            // 
            // m_timerCheckEtapesEncours
            // 
            this.m_timerCheckEtapesEncours.Enabled = true;
            this.m_timerCheckEtapesEncours.Interval = 60000;
            this.m_timerCheckEtapesEncours.Tick += new System.EventHandler(this.m_timerCheckEtapesEncours_Tick);
            // 
            // CPanelNotificationUtilisateur
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.m_btnSynchro);
            this.Controls.Add(this.m_imageMessagerie);
            this.Controls.Add(this.m_panelInterventionProcess);
            this.Controls.Add(this.m_btnAgenda);
            this.Controls.Add(this.m_panelWorkflow);
            this.Name = "CPanelNotificationUtilisateur";
            this.Size = new System.Drawing.Size(156, 32);
            this.Load += new System.EventHandler(this.CPanelNotificationUtilisateur_Load);
            this.m_panelInterventionProcess.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_imageInterventionProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnSynchro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageMessagerie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnAgenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureWorkflow)).EndInit();
            this.m_panelWorkflow.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		private void CPanelNotificationUtilisateur_Load(object sender, System.EventArgs e)
		{
			if ( !DesignMode )
			{
				m_recepteurInterventions = new CRecepteurNotification ( CTimosApp.SessionClient.IdSession, typeof(CDonneeNotificationBesoinIntervention));
				m_recepteurInterventions.OnReceiveNotification += new NotificationEventHandler ( OnNotification ) ;
                m_recepteurWorkflow = new CRecepteurNotification(CTimosApp.SessionClient.IdSession, typeof(CDonneeNotificationWorkflow));
                m_recepteurWorkflow.OnReceiveNotification += new NotificationEventHandler(m_recepteurWorkflow_OnReceiveNotification);

                CDonneesActeurUtilisateur user = CUtilSession.GetUserForSession(CSc2iWin32DataClient.ContexteCourant);
                if (user != null)
                {
                    CListeObjetsDonnees lstPourActeur = user.Acteur.GetEtapeWorkflowsEnCours();
                    m_nNbEtapesEnCours = lstPourActeur.Count;
                    if (m_nNbEtapesEnCours  > 0)
                    {
                        m_lblNbToDo.Text = m_nNbEtapesEnCours.ToString();
                        m_lblNbToDo.Visible = true;
                    }
                    else
                    {
                        m_lblNbToDo.Text = "0";
                        m_lblNbToDo.Visible = false;
                    }
                }

                BeginInvoke((MethodInvoker)delegate
                {
                    UpdateInterventions();
                });
			}
		}

        void m_recepteurWorkflow_OnReceiveNotification(IDonneeNotification donnee)
        {
            CDonneeNotificationWorkflow dw = donnee as CDonneeNotificationWorkflow;
            if (dw == null)
                return;
            string[] strCodesInteressants = CUtilSession.GetCodesAffectationsEtapeConcernant(CSc2iWin32DataClient.ContexteCourant);
            bool bPourMoi = false;
            foreach ( string strCode in strCodesInteressants )
            {
                if ( dw.CodesAffectations.Contains ( "~"+strCode+"~") )
                {
                    bPourMoi = true;
                    break;
                }
            }
            if ( bPourMoi )
            {
                CSessionClient session = CSessionClient.GetSessionForIdSession(dw.IdSessionEnvoyeur);
                CSousSessionClient sousSession = session as CSousSessionClient;
                if (sousSession != null)
                {
                    session = sousSession.RootSession;
                }

                if (session != null && 
                    session.IdSession == CTimosApp.SessionClient.IdSession && 
                    dw.ExecutionAutomatique
                    )
                {
                   m_nIdEtapeToLaunch = dw.IdEtapeSource;
                }
                m_nNbClignotementsWorkflowsRestant += c_nNbClignotementsWorkflow;

                CDonneesActeurUtilisateur user = CUtilSession.GetUserForSession(CSc2iWin32DataClient.ContexteCourant);
                if (user != null)
                {
                    CListeObjetsDonnees lstPourActeur = user.Acteur.GetEtapeWorkflowsEnCours();
                    m_nNbEtapesEnCours = lstPourActeur.Count;
                    if (m_nNbEtapesEnCours > 0)
                    {
                        m_lblNbToDo.Text = m_nNbEtapesEnCours.ToString();
                        m_lblNbToDo.Visible = true;
                    }
                    else
                    {
                        m_lblNbToDo.Text = "0";
                        m_lblNbToDo.Visible = false;
                    }
                }
            }
        }


		/// ///////////////////////////////////////
        private void m_timerClignotant_Tick(object sender, System.EventArgs e)
        {
            if (m_imageInterventionProcess.Image == null)
                m_imageInterventionProcess.Image = m_icones.Images[c_nImageIntervention];
            else
                m_imageInterventionProcess.Image = null;
            if (m_nNbClignotementsWorkflowsRestant > 0)
            {
                if (m_nIdEtapeToLaunch != null)
                {
                    int nId = m_nIdEtapeToLaunch.Value;
                    m_nIdEtapeToLaunch = null;
                    CEtapeWorkflow etape = new CEtapeWorkflow(CSc2iWin32DataClient.ContexteCourant);
                    if (etape.ReadIfExists(nId))
                    {
                        CGestionnaireWorkflowsEnCours.Instance.AfficheEtape(etape);
                    }
                }
                m_pictureWorkflow.Visible = !m_pictureWorkflow.Visible;
                m_lblNbToDo.Visible = m_nNbEtapesEnCours > 0 && m_pictureWorkflow.Visible;
                m_nNbClignotementsWorkflowsRestant--;
            }
            if (m_nNbClignotementsWorkflowsRestant <= 0)
            {
                m_pictureWorkflow.Visible = true;
                m_lblNbToDo.Visible = m_nNbEtapesEnCours > 0;
                m_pictureWorkflow.Invalidate();
            }
        }

		/// ///////////////////////////////////////
		private void m_imageInterventionProcess_Click(object sender, System.EventArgs e)
		{
			CTimosApp.Navigateur.AffichePage ( new CFormListeActionsUtilisateur() );
		}

		/// ///////////////////////////////////////
		public void UpdateInterventions()
		{
			if ( CBesoinInterventionProcess.HasInterventions (
				CTimosApp.SessionClient.IdSession, 
				CTimosApp.SessionClient.GetInfoUtilisateur().KeyUtilisateur ))
				m_panelInterventionProcess.Visible = true;
			else
				m_panelInterventionProcess.Visible = false;
		}

		/// ///////////////////////////////////////
		private void OnNotification ( IDonneeNotification donneeNotification )
		{
			if ( donneeNotification is CDonneeNotificationBesoinIntervention )
			{
				CDonneeNotificationBesoinIntervention dnbi = (CDonneeNotificationBesoinIntervention)donneeNotification;
                if (dnbi.KeyUtilisateurConcerne == CTimosApp.SessionClient.GetInfoUtilisateur().KeyUtilisateur)
                {
                    BeginInvoke((MethodInvoker)delegate
                    {
                        UpdateInterventions();
                    });
                    //CAppeleurFonctionAvecDelai.CallFonctionAvecDelai(this, "UpdateInterventions", 5000);
                    //UpdateInterventions();
                }
			}
		}

		/// ///////////////////////////////////////
		private void m_imageMessagerie_Click(object sender, System.EventArgs e)
		{
		}

		/// ///////////////////////////////////////
		private void m_btnAgenda_Click(object sender, System.EventArgs e)
		{
			try
			{
				CDonneesActeurUtilisateur user = CUtilSession.GetUserForSession ( CSc2iWin32DataClient.ContexteCourant );
				if ( user != null )
				{
					CTimosApp.Navigateur.AffichePage ( new CFormAgenda(user.Acteur) );		
				}
			}
			catch ( Exception ex )
			{
				Console.WriteLine(ex.ToString());
				CFormAlerte.Afficher(I.T("Impossible to reach the agenda|30116"), EFormAlerteType.Erreur);
			}
		}

     
        private void m_pictureWorkflow_Click(object sender, EventArgs e)
        {
            m_nNbClignotementsWorkflowsRestant = 0;
            CFormMain.GetInstance().AffichePage(new CFormListeEtapesWorkflowEnCours());
        }

        private void m_timerCheckEtapesEncours_Tick(object sender, EventArgs e)
        {
            try
            {
                CDonneesActeurUtilisateur user = CUtilSession.GetUserForSession(CSc2iWin32DataClient.ContexteCourant);
                if (user != null)
                {
                    CListeObjetsDonnees lstPourActeur = user.Acteur.GetEtapeWorkflowsEnCours();
                    m_nNbEtapesEnCours = lstPourActeur.Count;
                    if (m_nNbEtapesEnCours > 0)
                    {
                        m_lblNbToDo.Text = m_nNbEtapesEnCours.ToString();
                        m_lblNbToDo.Visible = true;
                    }
                    else
                    {
                        m_lblNbToDo.Text = "0";
                        m_lblNbToDo.Visible = false;
                    }
                }
            }
            catch { }

        }
       

   
	}
}
