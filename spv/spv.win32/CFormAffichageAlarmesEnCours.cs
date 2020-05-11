using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using sc2i.win32.navigation;
using sc2i.common;
using sc2i.data;
using sc2i.multitiers.client;
using sc2i.win32.data;

using timos.data;
using timos.data.preventives;
using sc2i.win32.common;
using spv.data.ConsultationAlarmes;

namespace spv.win32
{
	/// <summary>
	/// Description résumée de CFormAffichageAlarmesEnCours.
	/// </summary>
	[DynamicForm("Current alarms")]
	public class CFormAffichageAlarmesEnCours : CFormMaxiSansMenu, IFormNavigable
	{
        CRecepteurNotification m_recepteurNotificationsStart = null;
        CRecepteurNotification m_recepteurNotificationsStop = null;
        CRecepteurNotification m_recepteurNotificationsMask = null;
        CRecepteurNotification m_recepteurNotificationsAcknowledge = null;

		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre3;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox m_chkSuiviDates;
        private ListBox m_wndListeTest;
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CFormAffichageAlarmesEnCours()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

     /*       m_recepteurNotificationsStart = new CRecepteurNotification(CSc2iWin32DataClient.ContexteCourant.IdSession, typeof(CDonneeNotificationAlarmesStart));
            m_recepteurNotificationsStart.OnReceiveNotification += new NotificationEventHandler(OnReceiveNotificationStart);

            m_recepteurNotificationsStop = new CRecepteurNotification(CSc2iWin32DataClient.ContexteCourant.IdSession, typeof(CDonneeNotificationAlarmesStop));
            m_recepteurNotificationsStop.OnReceiveNotification += new NotificationEventHandler(OnReceiveNotificationStop);

            m_recepteurNotificationsMask = new CRecepteurNotification(CSc2iWin32DataClient.ContexteCourant.IdSession, typeof(CDonneeNotificationAlarmesMask));
            m_recepteurNotificationsMask.OnReceiveNotification += new NotificationEventHandler(OnReceiveNotificationMask);

            m_recepteurNotificationsAcknowledge = new CRecepteurNotification(CSc2iWin32DataClient.ContexteCourant.IdSession, typeof(CDonneeNotificationAlarmesAcknowledge));
            m_recepteurNotificationsAcknowledge.OnReceiveNotification += new NotificationEventHandler(OnReceiveNotificationAcknowledge);*/
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
				}
			}
			base.Dispose( disposing );
		}

		#region Code généré par le Concepteur Windows Form
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.c2iPanelOmbre3 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_chkSuiviDates = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_wndListeTest = new System.Windows.Forms.ListBox();
            this.c2iPanelOmbre3.SuspendLayout();
            this.SuspendLayout();
            // 
            // c2iPanelOmbre3
            // 
            this.c2iPanelOmbre3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.c2iPanelOmbre3.Controls.Add(this.m_chkSuiviDates);
            this.c2iPanelOmbre3.Controls.Add(this.label4);
            this.c2iPanelOmbre3.Location = new System.Drawing.Point(10, 10);
            this.c2iPanelOmbre3.LockEdition = false;
            this.c2iPanelOmbre3.Name = "c2iPanelOmbre3";
            this.c2iPanelOmbre3.Size = new System.Drawing.Size(184, 108);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanelOmbre3.TabIndex = 11;
            // 
            // m_chkSuiviDates
            // 
            this.m_chkSuiviDates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_chkSuiviDates.ForeColor = System.Drawing.Color.Maroon;
            this.m_chkSuiviDates.Location = new System.Drawing.Point(16, 32);
            this.m_chkSuiviDates.Name = "m_chkSuiviDates";
            this.m_chkSuiviDates.Size = new System.Drawing.Size(104, 24);
            this.m_extStyle.SetStyleBackColor(this.m_chkSuiviDates, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkSuiviDates, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkSuiviDates.TabIndex = 5;
            this.m_chkSuiviDates.Text = "Suivi des dates";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4;
            this.label4.Text = "Divers";
            // 
            // m_wndListeTest
            // 
            this.m_wndListeTest.FormattingEnabled = true;
            this.m_wndListeTest.Location = new System.Drawing.Point(204, 22);
            this.m_wndListeTest.Name = "m_wndListeTest";
            this.m_wndListeTest.Size = new System.Drawing.Size(348, 381);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeTest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeTest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeTest.TabIndex = 0;
            // 
            // CFormAffichageAlarmesEnCours
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(593, 459);
            this.Controls.Add(this.m_wndListeTest);
            this.Name = "CFormAffichageAlarmesEnCours";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "CFormAffichageAlarmesEnCours";
            this.Load += new System.EventHandler(this.CFormAffichageAlarmesEnCours_Load);
            this.c2iPanelOmbre3.ResumeLayout(false);
            this.c2iPanelOmbre3.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void CFormAffichageAlarmesEnCours_Load(object sender, System.EventArgs e)
		{
        }


		#region Membres de IFormNavigable

		public CContexteFormNavigable GetContexte()
		{
			return new CContexteFormNavigable ( GetType() );
		}

	
		public bool QueryClose()
		{
			return true;
		}

		public sc2i.common.CResultAErreur InitFromContexte(CContexteFormNavigable contexte)
		{
			return CResultAErreur.True;
		}
        //------------------------------------------------------------------
        public CResultAErreur Actualiser()
        {
            return InitFromContexte(GetContexte());
        }

		#endregion

		#region Membres de IDisposable

		void System.IDisposable.Dispose()
		{
			// TODO : ajoutez l'implémentation de CFormAffichageAlarmesEnCours.System.IDisposable.Dispose
		}

		#endregion

      /*  void OnReceiveNotificationStart(IDonneeNotification donnee)
        {
            CDonneeNotificationAlarmesStart donneeAlarme = donnee as CDonneeNotificationAlarmesStart;
            if (donneeAlarme == null)
                return;
            CEvenementAlarmStart[] lstAlarmes = donneeAlarme.Alarmes;
            foreach (CEvenementAlarmStart alarme in lstAlarmes)
                m_wndListeTest.Items.Add(alarme.MessageAlarmBrut);
        }

        void OnReceiveNotificationStop(IDonneeNotification donnee)
        {
            CDonneeNotificationAlarmesStop donneeAlarme = donnee as CDonneeNotificationAlarmesStop;
            if (donneeAlarme == null)
                return;
            CEvenementAlarmStop[] lstAlarmes = donneeAlarme.Alarmes;
            foreach (CEvenementAlarmStop alarme in lstAlarmes)
                ;            
        }

        void OnReceiveNotificationMask(IDonneeNotification donnee)
        {
            CDonneeNotificationAlarmesMask donneeAlarme = donnee as CDonneeNotificationAlarmesMask;
            if (donneeAlarme == null)
                return;
            CEvenementAlarmMask[] lstAlarmes = donneeAlarme.Alarmes;
            foreach (CEvenementAlarmMask alarme in lstAlarmes)
                ;
        }

        void OnReceiveNotificationAcknowledge(IDonneeNotification donnee)
        {
            CDonneeNotificationAlarmesAcknowledge donneeAlarme = donnee as CDonneeNotificationAlarmesAcknowledge;
            if (donneeAlarme == null)
                return;
            CEvenementAlarmAcknowledge[] lstAlarmes = donneeAlarme.Alarmes;
            foreach (CEvenementAlarmAcknowledge alarme in lstAlarmes)
                ;
        }*/


	}
}

