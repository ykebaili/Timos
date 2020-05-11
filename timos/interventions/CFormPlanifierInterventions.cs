using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;

using sc2i.win32.navigation;
using sc2i.common;
using timos.data;
using sc2i.data;
using sc2i.multitiers.client;
using sc2i.win32.data;

using timos.securite;
using timos.acteurs;
using sc2i.win32.common;
using timos.Properties;
using System.Collections.Generic;
using sc2i.data.dynamic;

namespace timos
{
	/// <summary>
	/// Description résumée de CFormAccueil.
	/// </summary>
    [DynamicForm("Intervention planning", "GetInfosParametres")]
	public class CFormPlanifierInterventions : CFormMaxiSansMenu, IFormNavigable,
        IFormDynamiqueAParametres
	{
        private const string c_parametreIdActeur = "MEMBER_ID";
        private const string c_parametreIdSite = "SITE_ID";
        private const string c_parametreIdIntervention = "INTERVENTION_ID";
        private const string c_parametreRessource = "RESOURCE_ID";
        private const string c_parametreIdListeInterventions = "INTER_FILTER_LIST_ID";
        private const string c_parametreIdListeActeurs = "MEMBERS_DISPLAY_LIST_ID";
        private const string c_parametreOnlyNotPlanned = "NOT_PLANNED_ONLY";
        private const string c_parmetreOnlyNotAffected = "NOT_AFFECTED_ONLY";
        private const string c_parametreStartDate = "START_DATE";
        private const string c_parametreEndDate = "END_DATE";

		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox m_chkSuiviDates;
        protected sc2i.win32.common.CToolTipTraductible m_ToolTipTraductible1;
		private timos.interventions.CPanelPlanification m_panelTop;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		protected Panel m_panelMenu;
		private Button m_btnEditerObjet;
		private Button m_btnValiderModifications;
		private Button m_btnAnnulerModifications;
        private IContainer components;
		private CContexteDonnee m_contexteDonnee;
		private CContexteDonnee m_contexteEnEdition = null;

		public CFormPlanifierInterventions()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
			m_contexteDonnee = sc2i.win32.data.CSc2iWin32DataClient.ContexteCourant;
			m_panelTop.SetContexteDonnee(m_contexteDonnee);
            DateTime date = DateTime.Now.Date.AddDays(-3);
            m_panelTop.SetDates(date, date.AddDays(6));
		}

		public CFormPlanifierInterventions(IElementAIntervention element)
		{
			InitializeComponent();
			m_contexteDonnee = element.ContexteDonnee;
			m_panelTop.SetContexteDonnee(m_contexteDonnee);
			m_panelTop.ShowElementAIntervention(element);
			DateTime date = DateTime.Now.Date.AddDays(-3);
			m_panelTop.SetDates(date, date.AddDays(6));
		}

        public CFormPlanifierInterventions(CIntervention intervention)
        {
            InitializeComponent();
            m_contexteDonnee = intervention.ContexteDonnee;
            m_panelTop.SetContexteDonnee(m_contexteDonnee);

            InitForIntervention(intervention);
        }

        private void InitForIntervention(CIntervention intervention)
        {
            m_panelTop.ShowElementAIntervention(intervention.Site);
            List<IRessourceEntreePlanning> lstRes = new List<IRessourceEntreePlanning>();
            foreach (CIntervention_Intervenant relIntervenant in intervention.RelationsIntervenants)
            {
                if (relIntervenant.Intervenant != null)
                    lstRes.Add(relIntervenant.Intervenant);
            }
            foreach (CIntervention_Ressource relRes in intervention.RelationsRessourcesMaterielles)
            {
                if (relRes.Ressource != null)
                    lstRes.Add(relRes.Ressource);
            }
            m_panelTop.ShowRessources(lstRes.ToArray());
            DateTime dateMin = DateTime.Now.Date.AddDays(-3);
            DateTime dateMax = dateMin.AddDays(6);
            if (intervention.DateDebutPrePlanifiee != null)
                dateMin = intervention.DateDebutPrePlanifiee.Value.Date; ;
            if (intervention.DateFinPrePlanifiee != null)
                dateMax = intervention.DateFinPrePlanifiee.Value.Date;
            int nIndex = 0;
            foreach (CFractionIntervention fraction in intervention.Fractions)
            {
                DateTime dtStart = fraction.DateDebutPlanifie;
                DateTime dtFin = fraction.DateFinPlanifiee.AddDays(1);
                if (fraction.DateDebut != null)
                    dtStart = fraction.DateDebut.Value;
                if (fraction.DateFin != null)
                    dtFin = fraction.DateFin.Value.AddDays(1);
                if (nIndex == 0)
                {
                    dateMin = dtStart;
                    dateMax = dtFin;

                }
                else
                {
                    if (dtStart < dateMin)
                        dateMin = dtStart;
                    if (dtFin > dateMax)
                        dateMax = dtFin;
                }
            }
            m_panelTop.SetDates(dateMin, dateMax);
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormPlanifierInterventions));
			this.c2iPanelOmbre3 = new sc2i.win32.common.C2iPanelOmbre();
			this.m_chkSuiviDates = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.m_ToolTipTraductible1 = new sc2i.win32.common.CToolTipTraductible(this.components);
			this.m_panelTop = new timos.interventions.CPanelPlanification();
			this.m_panelMenu = new System.Windows.Forms.Panel();
			this.m_btnEditerObjet = new System.Windows.Forms.Button();
			this.m_btnValiderModifications = new System.Windows.Forms.Button();
			this.m_btnAnnulerModifications = new System.Windows.Forms.Button();
			this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
			this.c2iPanelOmbre3.SuspendLayout();
			this.m_panelMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// c2iPanelOmbre3
			// 
			this.c2iPanelOmbre3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.c2iPanelOmbre3.Controls.Add(this.m_chkSuiviDates);
			this.c2iPanelOmbre3.Controls.Add(this.label4);
			this.c2iPanelOmbre3.Location = new System.Drawing.Point(8, 304);
			this.c2iPanelOmbre3.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre3, sc2i.win32.common.TypeModeEdition.Autonome);
			this.c2iPanelOmbre3.Name = "c2iPanelOmbre3";
			this.c2iPanelOmbre3.Size = new System.Drawing.Size(184, 88);
			this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.c2iPanelOmbre3.TabIndex = 11;
			// 
			// m_chkSuiviDates
			// 
			this.m_chkSuiviDates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_chkSuiviDates.ForeColor = System.Drawing.Color.Maroon;
			this.m_chkSuiviDates.Location = new System.Drawing.Point(16, 32);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkSuiviDates, sc2i.win32.common.TypeModeEdition.Autonome);
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
			this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label4.TabIndex = 4;
			this.label4.Text = "Divers";
			// 
			// m_panelTop
			// 
			this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_panelTop.Location = new System.Drawing.Point(0, 28);
			this.m_panelTop.LockEdition = true;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTop, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_panelTop.Name = "m_panelTop";
			this.m_panelTop.Size = new System.Drawing.Size(724, 272);
			this.m_extStyle.SetStyleBackColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelTop.TabIndex = 0;
			// 
			// m_panelMenu
			// 
			this.m_panelMenu.BackColor = System.Drawing.Color.White;
			this.m_panelMenu.Controls.Add(this.m_btnEditerObjet);
			this.m_panelMenu.Controls.Add(this.m_btnValiderModifications);
			this.m_panelMenu.Controls.Add(this.m_btnAnnulerModifications);
			this.m_panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_panelMenu.Location = new System.Drawing.Point(0, 0);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelMenu, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_panelMenu.Name = "m_panelMenu";
			this.m_panelMenu.Size = new System.Drawing.Size(724, 28);
			this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelMenu.TabIndex = 4001;
			// 
			// m_btnEditerObjet
			// 
			this.m_btnEditerObjet.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btnEditerObjet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_btnEditerObjet.ForeColor = System.Drawing.Color.White;
			this.m_btnEditerObjet.Image = ((System.Drawing.Image)(resources.GetObject("m_btnEditerObjet.Image")));
			this.m_btnEditerObjet.Location = new System.Drawing.Point(8, 0);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditerObjet, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
			this.m_btnEditerObjet.Name = "m_btnEditerObjet";
			this.m_btnEditerObjet.Size = new System.Drawing.Size(24, 26);
			this.m_extStyle.SetStyleBackColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_btnEditerObjet.TabIndex = 0;
			this.m_btnEditerObjet.TabStop = false;
			this.m_btnEditerObjet.Click += new System.EventHandler(this.m_btnEditerObjet_Click);
			// 
			// m_btnValiderModifications
			// 
			this.m_btnValiderModifications.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btnValiderModifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_btnValiderModifications.ForeColor = System.Drawing.Color.White;
			this.m_btnValiderModifications.Image = ((System.Drawing.Image)(resources.GetObject("m_btnValiderModifications.Image")));
			this.m_btnValiderModifications.Location = new System.Drawing.Point(80, 0);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_btnValiderModifications.Name = "m_btnValiderModifications";
			this.m_btnValiderModifications.Size = new System.Drawing.Size(24, 26);
			this.m_extStyle.SetStyleBackColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_btnValiderModifications.TabIndex = 2;
			this.m_btnValiderModifications.TabStop = false;
			this.m_btnValiderModifications.Click += new System.EventHandler(this.m_btnValiderModifications_Click);
			// 
			// m_btnAnnulerModifications
			// 
			this.m_btnAnnulerModifications.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btnAnnulerModifications.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnAnnulerModifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_btnAnnulerModifications.ForeColor = System.Drawing.Color.White;
			this.m_btnAnnulerModifications.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAnnulerModifications.Image")));
			this.m_btnAnnulerModifications.Location = new System.Drawing.Point(112, 0);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnulerModifications, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_btnAnnulerModifications.Name = "m_btnAnnulerModifications";
			this.m_btnAnnulerModifications.Size = new System.Drawing.Size(24, 26);
			this.m_extStyle.SetStyleBackColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_btnAnnulerModifications.TabIndex = 3;
			this.m_btnAnnulerModifications.TabStop = false;
			this.m_btnAnnulerModifications.Click += new System.EventHandler(this.m_btnAnnulerModifications_Click);
			// 
			// CFormPlanifierInterventions
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(724, 300);
			this.Controls.Add(this.m_panelTop);
			this.Controls.Add(this.m_panelMenu);
			this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.Name = "CFormPlanifierInterventions";
			this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.Text = "CFormAccueil";
			this.Enter += new System.EventHandler(this.CFormAccueil_Enter);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CFormPlanifierInterventions_FormClosing);
			this.Load += new System.EventHandler(this.CFormPlanifierInterventions_Load);
			this.c2iPanelOmbre3.ResumeLayout(false);
			this.c2iPanelOmbre3.PerformLayout();
			this.m_panelMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Membres de IFormNavigable
        public event ContexteFormEventHandler AfterGetContexte;
        public event ContexteFormEventHandler AfterInitFromContexte;

		public CContexteFormNavigable GetContexte()
		{
			CContexteFormNavigable contexte = new CContexteFormNavigable(GetType());
			m_panelTop.FillContexteFormNavigable(contexte);
            if (AfterGetContexte != null)
                AfterGetContexte(this, contexte);
			return contexte;
		}

	
		public bool QueryClose()
		{
            bool bRetour = true;
            if (m_gestionnaireModeEdition.ModeEdition)
            {
                DialogResult result = CFormAlerte.Afficher(I.T("Do you want to save modifications ?|30201"),
                    EFormAlerteBoutons.OuiNonCancel, EFormAlerteType.Question);
                if (result == DialogResult.No)
                {
                    if (!CancelModifs())
                        bRetour = false;
                }
                if (result == DialogResult.Yes)
                {
                    if (!ValideModifs())
                        bRetour = false;
                }
                if (result == DialogResult.Cancel)
                    bRetour = false;
            }
            return bRetour;
		}

		public sc2i.common.CResultAErreur InitFromContexte(CContexteFormNavigable contexte)
		{
			CResultAErreur result = m_panelTop.FillFromContexteFormNavigable(contexte);
            if (AfterInitFromContexte != null)
                AfterInitFromContexte(this, contexte);
            return result;
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
			// TODO : ajoutez l'implémentation de CFormAccueil.System.IDisposable.Dispose
		}

		#endregion



		private void CFormAccueil_Enter(object sender, System.EventArgs e)
		{
			CTimosApp.Titre = I.T("Intervention planning|30200");
		}

		private void m_btnEditerObjet_Click(object sender, EventArgs e)
		{
			BeginModeEdition();
		}

		private void BeginModeEdition()
		{
			m_contexteEnEdition = m_contexteDonnee.GetContexteEdition();
			m_panelTop.SetContexteDonnee(m_contexteEnEdition);
			m_gestionnaireModeEdition.ModeEdition = true;
		}

		private void m_btnValiderModifications_Click(object sender, EventArgs e)
		{
			if (ValideModifs())
			{
				m_gestionnaireModeEdition.ModeEdition = false;
			}
		}

		//-------------------------------------------------------
		private void m_btnAnnulerModifications_Click(object sender, EventArgs e)
		{
			if (CancelModifs())
				m_gestionnaireModeEdition.ModeEdition = false ;
		}

		//-------------------------------------------------------
		private bool ValideModifs()
		{
			if (!m_gestionnaireModeEdition.ModeEdition || m_contexteEnEdition == null)
				return false;
			CResultAErreur result = m_contexteEnEdition.SaveAll(true);
			if (!result)
			{
				CFormAlerte.Afficher(result.Erreur);
				return false;
			}
			m_contexteEnEdition.Dispose();
			m_contexteEnEdition = null;
			m_panelTop.SetContexteDonnee(m_contexteDonnee);
			return true;
		}

		//-------------------------------------------------------
		private bool CancelModifs()
		{
			if (m_contexteEnEdition != null)
			{
				m_contexteEnEdition.Dispose();
				m_contexteEnEdition = null;
				m_panelTop.SetContexteDonnee(m_contexteDonnee);
			}
			return true;
		}

		private void CFormPlanifierInterventions_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		private void CFormPlanifierInterventions_Load(object sender, EventArgs e)
		{
			m_gestionnaireModeEdition.ModeEdition = m_gestionnaireModeEdition.ModeEdition;
		}

        public string GetTitle()
        {
            return I.T("Intervention planning|30200");
        }

        public Image GetImage()
        {
            return Resources.planifier;
        }

        //-------------------------------------------------------------------------
        public static CInfoParametreDynamicForm[] GetInfosParametres()
        {
            List<CInfoParametreDynamicForm> lst = new List<CInfoParametreDynamicForm>();
            lst.Add(new CInfoParametreDynamicForm(c_parametreIdActeur, typeof(int),
                I.T("Member Id To display|20653")));
            lst.Add(new CInfoParametreDynamicForm(c_parametreIdIntervention, typeof(int),
                I.T("Intervention Id To display|20655")));
            lst.Add(new CInfoParametreDynamicForm(c_parametreRessource, typeof(int),
                I.T("Resource Id To display|20656")));
            lst.Add(new CInfoParametreDynamicForm(c_parametreIdSite, typeof(int),
                I.T("Site Id To display|20654")));
            lst.Add(new CInfoParametreDynamicForm(c_parametreIdListeActeurs, typeof(int),
                I.T("Entity list id for members to display|20663") ));
            lst.Add(new CInfoParametreDynamicForm(c_parametreIdListeInterventions, typeof(int),
                I.T("Entity list id for interventions filter|20664")));
            lst.Add(new CInfoParametreDynamicForm(c_parametreOnlyNotPlanned, typeof(bool),
                I.T("Display only not planned interventions|20665")));
            lst.Add(new CInfoParametreDynamicForm(c_parmetreOnlyNotAffected, typeof(bool),
                I.T("Display only not affected interventions|20666")));
            lst.Add(new CInfoParametreDynamicForm(c_parametreStartDate, typeof(DateTime),
                I.T("Start date of grid|20749")));
            lst.Add(new CInfoParametreDynamicForm(c_parametreEndDate, typeof(DateTime),
                I.T("End date of grid|20750")));

            return lst.ToArray();
        }

        public CResultAErreur SetParametres(Dictionary<string, object> dicParametres)
        {
            CResultAErreur result = CResultAErreur.True;
            object valeur = null;

            if (dicParametres.TryGetValue(c_parametreIdIntervention, out valeur))
            {
                if (valeur is int)
                {
                    CIntervention intervention = new CIntervention(CSc2iWin32DataClient.ContexteCourant);
                    if (intervention.ReadIfExists((int)valeur))
                        InitForIntervention(intervention);
                }
            }

            List<IRessourceEntreePlanning> lstResourcesAAfficher = new List<IRessourceEntreePlanning>();
            if (dicParametres.TryGetValue(c_parametreIdActeur, out valeur))
            {
                if (valeur is int)
                {
                    CActeur acteur = new CActeur(CSc2iWin32DataClient.ContexteCourant);
                    if (acteur.ReadIfExists((int)valeur))
                        lstResourcesAAfficher.Add(acteur);
                }
            }
            if (dicParametres.TryGetValue(c_parametreIdSite, out valeur))
            {
                if (valeur is int)
                {
                    CSite site = new CSite(CSc2iWin32DataClient.ContexteCourant);
                    if (site.ReadIfExists((int)valeur))
                        m_panelTop.ShowElementAIntervention(site);
                }
            }
            if (dicParametres.TryGetValue(c_parametreRessource, out valeur))
            {
                if (valeur is int)
                {
                    CRessourceMaterielle res = new CRessourceMaterielle(CSc2iWin32DataClient.ContexteCourant);
                    if (res.ReadIfExists((int)valeur))
                        lstResourcesAAfficher.Add(res);
                }
            }
            if ( dicParametres.TryGetValue(c_parametreIdListeActeurs, out valeur ) )
            {
                if ( valeur is int )
                {
                    CListeEntites lstActeurs = new CListeEntites(CSc2iWin32DataClient.ContexteCourant);
                    if ( lstActeurs.ReadIfExists((int)valeur) )
                    {
                        foreach ( CObjetDonnee objet in lstActeurs.ElementsLies )
                        {
                            if ( objet is CActeur )
                                lstResourcesAAfficher.Add ( objet as CActeur );
                        }
                    }
                }
            }
            if ( dicParametres.TryGetValue(c_parametreIdListeInterventions, out valeur ) )
            {
                if ( valeur is int )
                {
                    CListeEntites lstInters = new CListeEntites(CSc2iWin32DataClient.ContexteCourant);
                    if ( lstInters.ReadIfExists ( (int)valeur ) )
                    {
                        if ( lstInters.TypeElements == typeof(CIntervention) )
                            m_panelTop.SetListeFiltreInters ( lstInters );
                    }
                }
            }
            if (dicParametres.TryGetValue(c_parametreOnlyNotPlanned, out valeur))
            {
                if (valeur is bool)
                    m_panelTop.OnlyNotPlanned = (bool)valeur;
            }
            if (dicParametres.TryGetValue(c_parmetreOnlyNotAffected, out valeur))
            {
                if (valeur is bool)
                    m_panelTop.OnlyNotAssigned = (bool)valeur;
            }

            DateTime? dateDebut = null;
            DateTime? dateFin = null;
            if ( dicParametres.TryGetValue(c_parametreStartDate, out valeur ))
            {
                if ( valeur is DateTime )
                    dateDebut = (DateTime)valeur;
            }
            if ( dicParametres.TryGetValue(c_parametreEndDate, out valeur ))
            {
                if ( valeur is DateTime )
                    dateFin = (DateTime)valeur;
            }
            if ( dateDebut != null )
                if ( dateFin == null )
                    dateFin = dateDebut.Value.AddDays(7);
            if ( dateFin != null )
                if ( dateDebut == null )
                    dateDebut= dateFin.Value.AddDays(-7);
            if ( dateDebut != null && dateFin != null )
            {
                if ( dateFin.Value<dateDebut.Value )
                {
                    DateTime tmp = dateDebut.Value;
                    dateDebut = dateFin;
                    dateFin = tmp;
                }
                m_panelTop.SetDates ( dateDebut.Value, dateFin.Value );
            }
            if (lstResourcesAAfficher.Count > 0)
                m_panelTop.ShowRessources(lstResourcesAAfficher.ToArray());
            return result;
        }



	}

}

