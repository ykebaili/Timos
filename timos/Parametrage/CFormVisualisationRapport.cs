using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using sc2i.common;
using sc2i.data;
using sc2i.win32.common;
using sc2i.documents;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.win32.data;
using sc2i.formulaire;
using sc2i.data.dynamic;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using timos.Properties;

namespace timos
{
    [DynamicForm("Report Visualiser", "GetInfosParametres")]
	public class CFormVisualisationRapport : CFormMaxiSansMenu, IFormNavigable, IFormDynamiqueAParametres
	{
		private System.ComponentModel.IContainer components = null;

		private C2iRapportCrystal m_rapport = null;

		private CFichierLocalTemporaire m_fichierDonnees = new CFichierLocalTemporaire ( "mdb");
		
		protected CContexteFormNavigable m_contexte;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer m_viewer;
		private CProxyGED m_proxyGED = null;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
        private sc2i.formulaire.win32.editor.CPanelFormulaireSurElement m_panelFiltre;
		private System.Windows.Forms.Panel panel2;

		private CDocumentGED m_document = null;
		private CReducteurControle m_reducteur;
        private Button m_btnFiltrer;
        private Label m_lblReport;
		private DataSet m_dataset = null;
		//----------------------------------------------------------------------
		public CFormVisualisationRapport()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//----------------------------------------------------------------------
		public CFormVisualisationRapport(C2iRapportCrystal rapport)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();

			m_rapport = rapport;
		}
		//----------------------------------------------------------------------
		public CFormVisualisationRapport(CDocumentGED document, DataSet ds)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();

			m_document = document;
			m_dataset = ds;
		}

        //----------------------------------------------------------------------
        /// <summary>
        /// Fonction statique nécessaire sur un DynamicForm
        /// </summary>
        /// <returns></returns>
        public static CInfoParametreDynamicForm[] GetInfosParametres()
        {
            return new CInfoParametreDynamicForm[] {
                new CInfoParametreDynamicForm(
                    m_cParametreReportId , 
                    typeof(object),
                    "This parameter must return the ID or UID of Crystal Report model te be displayed")};
        }

        public const string m_cParametreReportId = "Report_Id";
        //----------------------------------------------------------------------
        public CResultAErreur SetParametres(Dictionary<string, object> dicParametres)
        {
            CResultAErreur result = CResultAErreur.True;

            object obj = null;
            if (dicParametres.TryGetValue(m_cParametreReportId, out obj))
            {
                if (obj is int)
                {
                    m_rapport = new C2iRapportCrystal(CSc2iWin32DataClient.ContexteCourant);
                    if(!m_rapport.ReadIfExists((int) obj))
                    {
                        result.EmpileErreur(I.T("There is no Crystal Report Model corresponding to the Id: @1|10006", ((int)obj).ToString()));
                    }
                }
                else if (obj is string)
                {
                    m_rapport = new C2iRapportCrystal(CSc2iWin32DataClient.ContexteCourant);
                    if (!m_rapport.ReadIfExists(CDbKey.CreateFromStringValue((string)obj)))
                    {
                        result.EmpileErreur(I.T("There is no Crystal Report Model corresponding to the Universal : @1", (string)obj));
                    }
                }
                else
                {
                    result.EmpileErreur(I.T("The Report ID parameter must be an integer value|10007"));
                }

            }

            return result;

        }

        //----------------------------------------------------------------------
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
				if ( m_fichierDonnees != null )
					m_fichierDonnees.Dispose();
				m_fichierDonnees = null;
			}
			base.Dispose( disposing );

			if (m_proxyGED!=null)
				m_proxyGED.Dispose();
		}
		//----------------------------------------------------------------------
		#region Code généré par le concepteur
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.m_viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_btnFiltrer = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_panelFiltre = new sc2i.formulaire.win32.editor.CPanelFormulaireSurElement();
            this.m_reducteur = new sc2i.win32.common.CReducteurControle();
            this.m_lblReport = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_viewer
            // 
            this.m_viewer.ActiveViewIndex = -1;
            this.m_viewer.BackColor = System.Drawing.Color.White;
            this.m_viewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_viewer.Location = new System.Drawing.Point(0, 0);
            this.m_viewer.Name = "m_viewer";
            this.m_viewer.SelectionFormula = "";
            this.m_viewer.Size = new System.Drawing.Size(706, 327);
            this.m_extStyle.SetStyleBackColor(this.m_viewer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_viewer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_viewer.TabIndex = 0;
            this.m_viewer.ViewTimeSelectionFormula = "";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.m_panelFiltre);
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(706, 466);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 4045;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_btnFiltrer);
            this.panel2.Controls.Add(this.m_viewer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 139);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(706, 327);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 4046;
            // 
            // m_btnFiltrer
            // 
            this.m_btnFiltrer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.m_btnFiltrer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnFiltrer.Location = new System.Drawing.Point(437, 3);
            this.m_btnFiltrer.Name = "m_btnFiltrer";
            this.m_btnFiltrer.Size = new System.Drawing.Size(115, 21);
            this.m_extStyle.SetStyleBackColor(this.m_btnFiltrer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnFiltrer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnFiltrer.TabIndex = 4046;
            this.m_btnFiltrer.Text = "Visualize / Filter|1007";
            this.m_btnFiltrer.UseVisualStyleBackColor = false;
            this.m_btnFiltrer.Click += new System.EventHandler(this.m_btnFiltrer_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 135);
            this.splitter1.MinExtra = 1;
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(706, 4);
            this.m_extStyle.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // m_panelFiltre
            // 
            this.m_panelFiltre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelFiltre.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelFiltre.ElementEdite = null;
            this.m_panelFiltre.Location = new System.Drawing.Point(0, 0);
            this.m_panelFiltre.LockEdition = false;
            this.m_panelFiltre.Name = "m_panelFiltre";
            this.m_panelFiltre.Size = new System.Drawing.Size(706, 135);
            this.m_extStyle.SetStyleBackColor(this.m_panelFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFiltre.TabIndex = 0;
            // 
            // m_reducteur
            // 
            this.m_reducteur.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_reducteur.ControleAgrandit = this.m_viewer;
            this.m_reducteur.ControleReduit = this.m_panelFiltre;
            this.m_reducteur.Location = new System.Drawing.Point(349, 28);
            this.m_reducteur.MargeControle = 0;
            this.m_reducteur.ModePositionnement = sc2i.win32.common.CReducteurControle.EModePositionnement.Haut;
            this.m_reducteur.Name = "m_reducteur";
            this.m_reducteur.Size = new System.Drawing.Size(9, 8);
            this.m_extStyle.SetStyleBackColor(this.m_reducteur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_reducteur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_reducteur.TabIndex = 4047;
            this.m_reducteur.TailleReduite = 32;
            // 
            // m_lblReport
            // 
            this.m_lblReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblReport.Location = new System.Drawing.Point(4, 3);
            this.m_lblReport.Name = "m_lblReport";
            this.m_lblReport.Size = new System.Drawing.Size(683, 25);
            this.m_extStyle.SetStyleBackColor(this.m_lblReport, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblReport, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblReport.TabIndex = 4048;
            this.m_lblReport.Text = "Report name";
            // 
            // CFormVisualisationRapport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(706, 498);
            this.Controls.Add(this.m_lblReport);
            this.Controls.Add(this.m_reducteur);
            this.Controls.Add(this.panel1);
            this.Name = "CFormVisualisationRapport";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Load += new System.EventHandler(this.CFormVisualisationRapport_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//----------------------------------------------------------------------
		#region Membres de IFormNavigable
        public event ContexteFormEventHandler AfterGetContexte;
        public event ContexteFormEventHandler AfterInitFromContexte;

        

		public CContexteFormNavigable GetContexte()
		{
			if ( m_rapport == null )
				return null;

			if ( m_rapport.IsNew() )
				return null;

			CContexteFormNavigable ctx = new CContexteFormNavigable(GetType() );
			if ( m_rapport != null )
				ctx["CHAMP_ID"] = m_rapport.Id;
			else
				ctx["CHAMP_ID"] = null;
            if (AfterGetContexte != null)
                AfterGetContexte(this, ctx);
			return ctx;
		}

		public bool QueryClose()
		{
			return true;
		}

		public CResultAErreur InitFromContexte(CContexteFormNavigable contexte)
		{
			CResultAErreur result = CResultAErreur.True;
			m_contexte = contexte;
			
			C2iRapportCrystal tempRapport = new C2iRapportCrystal(CSc2iWin32DataClient.ContexteCourant);

			tempRapport.Id = (int)contexte["CHAMP_ID"];
			m_rapport = tempRapport;

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
		//----------------------------------------------------------------------
		private bool m_bRapportLoadInViewer = false;
		//----------------------------------------------------------------------
		private void CFormVisualisationRapport_Load(object sender, System.EventArgs e)
		{
			if (m_document!=null)
			{
				ReportDocument doc = new ReportDocument();
				m_proxyGED = new CProxyGED ( m_document.ContexteDonnee.IdSession, m_document.ReferenceDoc );
				if (!m_proxyGED.IsFichierRappatrie())
				{
					CResultAErreur result = m_proxyGED.CopieFichierEnLocal();
					if (!result)
						return;
				}
				doc.Load(m_proxyGED.NomFichierLocal);
				doc.Refresh();
				doc.SetDataSource(m_dataset);
				m_viewer.ReportSource = doc;
				return;
			}

			if (!m_bRapportLoadInViewer)
			{
				m_lblReport.Text = "";
				if (m_rapport==null)
					return;
				m_lblReport.Text = m_rapport.Libelle;
				try
				{
					m_proxyGED = new CProxyGED ( m_rapport.ContexteDonnee.IdSession, m_rapport.DocumentGED.ReferenceDoc );
				}
				catch 
				{
					CFormAlerte.Afficher(I.T( "The Report model is not defined|1008"), EFormAlerteType.Erreur);
					return;
				}
				CResultAErreur result = m_proxyGED.CopieFichierEnLocal();
				if (!result)
					return;

				
				m_viewer.DisplayGroupTree = false;

				ChargerPanelFiltre();
				if (!m_panelFiltre.Visible)
					Filtrer();

				m_bRapportLoadInViewer = true;
			}
		}

		//----------------------------------------------------------------------
		private void m_linkRapport_LinkClicked(object sender, System.EventArgs e)
		{
			CFormEditionRapportCrystal frm = new CFormEditionRapportCrystal(m_rapport);
			CSc2iWin32DataNavigation.Navigateur.AffichePage(frm);
		}
		//----------------------------------------------------------------------
		private void ChargerPanelFiltre()
		{
			CMultiStructureExport multiStructure = m_rapport.MultiStructure;
			if ( multiStructure != null && multiStructure.Formulaire != null )
			{
					m_panelFiltre.InitPanel( multiStructure.Formulaire, multiStructure );
					m_panelFiltre.Height = multiStructure.Formulaire.Size.Height;
					m_panelFiltre.Show();
					m_btnFiltrer.Show();
					return;
			}
			/*else 
			{
				if ( m_rapport.Requete != null )
				{
					C2iRequete requete = m_rapport.Requete;
					m_panelFiltre.InitPanel( requete.FormulaireEdition, requete );
					m_panelFiltre.Height = requete.FormulaireEdition.Size.Height;
					m_panelFiltre.Show();
					m_btnFiltrer.Show();
					return;
				}
			}*/

			m_panelFiltre.Hide();
			m_btnFiltrer.Hide();
		}
		//----------------------------------------------------------------------
		private void Filtrer()
		{
			CResultAErreur result = CResultAErreur.True;
			using (new CWaitCursor())
			{
				CMultiStructureExport structure = m_rapport.MultiStructure;
				if ( structure != null && m_panelFiltre.Visible == true )
				{
					result = m_panelFiltre.AffecteValeursToElement();
					if ( !result )
					{
						CFormAlerte.Afficher(result.Erreur);
					}
					if ( m_panelFiltre.ElementEdite != null )
						structure = (CMultiStructureExport)m_panelFiltre.ElementEdite;
				}
				result = m_rapport.CreateReport ( structure, m_fichierDonnees );
			/*
				if ( m_rapport.Requete != null )
				{
					m_panelFiltre.AffecteValeursToElement();
					C2iRequete requete = (C2iRequete)m_panelFiltre.ElementEdite;
					result = m_rapport.CreateReport ( requete, m_fichierDonnees ); 
				}
				else
				{
					using ( CContexteDonnee contexte = new CContexteDonnee ( CSc2iWin32DataClient.ContexteCourant.IdSession, true, false) )
					{
						contexte.EnforceConstraints = false;
						CListeObjetsDonnees liste = new CListeObjetsDonnees(contexte, m_rapport.TypeObjet );
				
						if (m_panelFiltre.Visible && m_panelFiltre.ElementEdite !=null)
						{
							m_panelFiltre.AffecteValeursToElement();
							CFiltreDynamique filtre  = (CFiltreDynamique)m_panelFiltre.ElementEdite;
							result = filtre.GetFiltreData();
							if (!result)
								liste.Filtre = null;
							else
								liste.Filtre = (CFiltreData) result.Data;
						}
						else
							liste.Filtre = null;

						result = m_rapport.CreateReport ( liste, (IElementAVariablesDynamiques)m_panelFiltre.ElementEdite, m_fichierDonnees );
					}
				}*/
				if ( result )
				{
					m_viewer.ReportSource = (ReportDocument)result.Data;
					m_viewer.Refresh();
				}
				if ( !result )
					CFormAlerte.Afficher ( result.Erreur );
			}
		}
		//----------------------------------------------------------------------
		private void m_btnFiltrer_Click(object sender, System.EventArgs e)
		{
			Filtrer();
		}
		//----------------------------------------------------------------------
        public string GetTitle()
        {
            return I.T("Report view|20647");
        }

        public Image GetImage()
        {
            return Resources.report;
        }
	}
}

