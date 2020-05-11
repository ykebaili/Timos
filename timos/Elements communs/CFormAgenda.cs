using System;
using System.Drawing;
using System.Collections;
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
using timos.acteurs;
using timos.win32.composants;
using sc2i.workflow;
using timos.securite;
using timos.Properties;

namespace timos
{
	public class CFormAgenda : CFormMaxiSansMenu, IFormNavigable
	{
		private CListeObjetsDonnees m_listeActeurs = null;
		private CObjetDonneeAIdNumerique[] m_objetsAccedes = new CObjetDonneeAIdNumerique[0];
		private System.ComponentModel.IContainer components = null;
		private timos.win32.composants.CcontrolAgenda m_controlAgenda;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label m_lblObjet;
		private System.Windows.Forms.Panel m_panelRechActeur;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox m_txtFiltrer;
		private System.Windows.Forms.Label label3;
		private sc2i.win32.common.GlacialList m_wndListeActeurs;
		private System.Windows.Forms.Button m_btnOK;
		private System.Windows.Forms.Button m_btnAnnuler;
		private System.Windows.Forms.Button m_btnMultiples;
		private System.Windows.Forms.Panel m_panelEntete;
		//----------------------------------------------------------------------
		public CFormAgenda()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}

		//----------------------------------------------------------------------
		public CFormAgenda( CObjetDonneeAIdNumerique objetAccede)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
			m_objetsAccedes = new CObjetDonneeAIdNumerique[] {objetAccede};
		}

		//----------------------------------------------------------------------
		public CFormAgenda( CObjetDonneeAIdNumerique[] objetsAccedes)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
			m_objetsAccedes = objetsAccedes;
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
			}
			base.Dispose( disposing );
		}
		//----------------------------------------------------------------------
		#region Code généré par le concepteur
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormAgenda));
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            this.m_controlAgenda = new timos.win32.composants.CcontrolAgenda();
            this.m_panelEntete = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lblObjet = new System.Windows.Forms.Label();
            this.m_panelRechActeur = new System.Windows.Forms.Panel();
            this.m_btnMultiples = new System.Windows.Forms.Button();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_btnOK = new System.Windows.Forms.Button();
            this.m_wndListeActeurs = new sc2i.win32.common.GlacialList();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtFiltrer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_panelEntete.SuspendLayout();
            this.m_panelRechActeur.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_controlAgenda
            // 
            this.m_controlAgenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_controlAgenda.DateEnCours = new System.DateTime(2008, 1, 7, 16, 13, 6, 421);
            this.m_controlAgenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_controlAgenda.ForeColor = System.Drawing.Color.Black;
            this.m_controlAgenda.Location = new System.Drawing.Point(0, 36);
            this.m_controlAgenda.Name = "m_controlAgenda";
            this.m_controlAgenda.Size = new System.Drawing.Size(800, 336);
            this.m_extStyle.SetStyleBackColor(this.m_controlAgenda, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_controlAgenda, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_controlAgenda.TabIndex = 0;
            this.m_controlAgenda.OnAfficherEntreeAgenda += new timos.win32.composants.DemandeAffichageEntreeAgendaEventHandler(this.m_controlAgenda_OnAfficherEntreeAgenda);
            // 
            // m_panelEntete
            // 
            this.m_panelEntete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelEntete.Controls.Add(this.label2);
            this.m_panelEntete.Controls.Add(this.m_lblObjet);
            this.m_panelEntete.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelEntete.ForeColor = System.Drawing.Color.Black;
            this.m_panelEntete.Location = new System.Drawing.Point(0, 0);
            this.m_panelEntete.Name = "m_panelEntete";
            this.m_panelEntete.Size = new System.Drawing.Size(800, 36);
            this.m_extStyle.SetStyleBackColor(this.m_panelEntete, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelEntete, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelEntete.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Beige;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 28);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTitrePanel);
            this.label2.TabIndex = 1;
            this.label2.Text = "Diary|80";
            // 
            // m_lblObjet
            // 
            this.m_lblObjet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lblObjet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lblObjet.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.m_lblObjet.ForeColor = System.Drawing.Color.Black;
            this.m_lblObjet.Location = new System.Drawing.Point(92, 4);
            this.m_lblObjet.Name = "m_lblObjet";
            this.m_lblObjet.Size = new System.Drawing.Size(704, 28);
            this.m_extStyle.SetStyleBackColor(this.m_lblObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_lblObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_lblObjet.TabIndex = 0;
            this.m_lblObjet.Click += new System.EventHandler(this.m_lblObjet_Click);
            // 
            // m_panelRechActeur
            // 
            this.m_panelRechActeur.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelRechActeur.Controls.Add(this.m_btnMultiples);
            this.m_panelRechActeur.Controls.Add(this.m_btnAnnuler);
            this.m_panelRechActeur.Controls.Add(this.m_btnOK);
            this.m_panelRechActeur.Controls.Add(this.m_wndListeActeurs);
            this.m_panelRechActeur.Controls.Add(this.label3);
            this.m_panelRechActeur.Controls.Add(this.m_txtFiltrer);
            this.m_panelRechActeur.Controls.Add(this.label1);
            this.m_panelRechActeur.ForeColor = System.Drawing.Color.Black;
            this.m_panelRechActeur.Location = new System.Drawing.Point(96, 32);
            this.m_panelRechActeur.Name = "m_panelRechActeur";
            this.m_panelRechActeur.Size = new System.Drawing.Size(296, 304);
            this.m_extStyle.SetStyleBackColor(this.m_panelRechActeur, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelRechActeur, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelRechActeur.TabIndex = 2;
            this.m_panelRechActeur.Visible = false;
            this.m_panelRechActeur.Leave += new System.EventHandler(this.m_panelRechActeur_Leave);
            // 
            // m_btnMultiples
            // 
            this.m_btnMultiples.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_btnMultiples.Image = ((System.Drawing.Image)(resources.GetObject("m_btnMultiples.Image")));
            this.m_btnMultiples.Location = new System.Drawing.Point(8, 280);
            this.m_btnMultiples.Name = "m_btnMultiples";
            this.m_btnMultiples.Size = new System.Drawing.Size(75, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnMultiples, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnMultiples, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnMultiples.TabIndex = 7;
            this.m_btnMultiples.Click += new System.EventHandler(this.m_btnMultiples_Click);
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnuler.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAnnuler.Image")));
            this.m_btnAnnuler.Location = new System.Drawing.Point(208, 280);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(75, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAnnuler.TabIndex = 6;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // m_btnOK
            // 
            this.m_btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_btnOK.Image = ((System.Drawing.Image)(resources.GetObject("m_btnOK.Image")));
            this.m_btnOK.Location = new System.Drawing.Point(128, 280);
            this.m_btnOK.Name = "m_btnOK";
            this.m_btnOK.Size = new System.Drawing.Size(75, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnOK, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnOK, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOK.TabIndex = 5;
            this.m_btnOK.Click += new System.EventHandler(this.m_btnOK_Click);
            // 
            // m_wndListeActeurs
            // 
            this.m_wndListeActeurs.AllowColumnResize = true;
            this.m_wndListeActeurs.AllowMultiselect = false;
            this.m_wndListeActeurs.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.m_wndListeActeurs.AlternatingColors = false;
            this.m_wndListeActeurs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndListeActeurs.AutoHeight = true;
            this.m_wndListeActeurs.AutoSort = true;
            this.m_wndListeActeurs.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_wndListeActeurs.CanChangeActivationCheckBoxes = false;
            this.m_wndListeActeurs.CheckBoxes = false;
            glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "Column1";
            glColumn2.Propriete = "Libelle";
            glColumn2.Text = "Acteur";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 270;
            this.m_wndListeActeurs.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn2});
            this.m_wndListeActeurs.ContexteUtilisation = "";
            this.m_wndListeActeurs.EnableCustomisation = false;
            this.m_wndListeActeurs.FocusedItem = null;
            this.m_wndListeActeurs.FullRowSelect = true;
            this.m_wndListeActeurs.GLGridLines = sc2i.win32.common.GLGridStyles.gridNone;
            this.m_wndListeActeurs.GridColor = System.Drawing.Color.Gray;
            this.m_wndListeActeurs.HeaderHeight = 0;
            this.m_wndListeActeurs.HeaderStyle = sc2i.win32.common.GLHeaderStyles.Normal;
            this.m_wndListeActeurs.HeaderTextColor = System.Drawing.Color.Black;
            this.m_wndListeActeurs.HeaderVisible = false;
            this.m_wndListeActeurs.HeaderWordWrap = false;
            this.m_wndListeActeurs.HotColumnIndex = -1;
            this.m_wndListeActeurs.HotItemIndex = -1;
            this.m_wndListeActeurs.HotTracking = false;
            this.m_wndListeActeurs.HotTrackingColor = System.Drawing.Color.LightGray;
            this.m_wndListeActeurs.ImageList = null;
            this.m_wndListeActeurs.ItemHeight = 17;
            this.m_wndListeActeurs.ItemWordWrap = false;
            this.m_wndListeActeurs.ListeSource = null;
            this.m_wndListeActeurs.Location = new System.Drawing.Point(0, 36);
            this.m_wndListeActeurs.MaxHeight = 17;
            this.m_wndListeActeurs.Name = "m_wndListeActeurs";
            this.m_wndListeActeurs.SelectedTextColor = System.Drawing.Color.White;
            this.m_wndListeActeurs.SelectionColor = System.Drawing.Color.DarkBlue;
            this.m_wndListeActeurs.ShowBorder = true;
            this.m_wndListeActeurs.ShowFocusRect = false;
            this.m_wndListeActeurs.Size = new System.Drawing.Size(296, 244);
            this.m_wndListeActeurs.SortIndex = 0;
            this.m_extStyle.SetStyleBackColor(this.m_wndListeActeurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeActeurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeActeurs.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.m_wndListeActeurs.TabIndex = 4;
            this.m_wndListeActeurs.Text = "glacialList1";
            this.m_wndListeActeurs.DoubleClick += new System.EventHandler(this.m_wndListeActeurs_DoubleClick);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.ForeColor = System.Drawing.Color.Beige;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(296, 16);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTitrePanel);
            this.label3.TabIndex = 2;
            this.label3.Text = "Select a Member|843";
            // 
            // m_txtFiltrer
            // 
            this.m_txtFiltrer.Location = new System.Drawing.Point(55, 16);
            this.m_txtFiltrer.Name = "m_txtFiltrer";
            this.m_txtFiltrer.Size = new System.Drawing.Size(237, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtFiltrer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFiltrer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFiltrer.TabIndex = 1;
            this.m_txtFiltrer.Validated += new System.EventHandler(this.m_txtFiltrer_Validated);
            this.m_txtFiltrer.TextChanged += new System.EventHandler(this.m_txtFiltrer_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter|14";
            // 
            // CFormAgenda
            // 
            this.AcceptButton = this.m_btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(184)))));
            this.CancelButton = this.m_btnAnnuler;
            this.ClientSize = new System.Drawing.Size(800, 372);
            this.Controls.Add(this.m_panelRechActeur);
            this.Controls.Add(this.m_controlAgenda);
            this.Controls.Add(this.m_panelEntete);
            this.Name = "CFormAgenda";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Load += new System.EventHandler(this.CFormAgenda_Load);
            this.m_panelEntete.ResumeLayout(false);
            this.m_panelRechActeur.ResumeLayout(false);
            this.m_panelRechActeur.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
		//----------------------------------------------------------------------
		#region Membres de IFormNavigable

        public event ContexteFormEventHandler AfterGetContexte;
        public event ContexteFormEventHandler AfterInitFromContexte;

		public CContexteFormNavigable GetContexte()
		{
			CContexteFormNavigable contexte = new CContexteFormNavigable ( GetType() );
			if ( contexte == null )
				return null;
			if ( m_objetsAccedes != null )
			{
				ArrayList lst = new ArrayList (  );
				foreach ( CObjetDonneeAIdNumerique objet in m_objetsAccedes )
					lst.Add ( new CReferenceObjetDonnee ( objet ) );
				CStringSerializer serializer = new CStringSerializer(ModeSerialisation.Ecriture );
				serializer.TraiteArrayListOf2iSerializable ( lst );
				contexte["OBJETS"] = serializer.String;
			}
			contexte["DATE"] = m_controlAgenda.DateEnCours;
            if (AfterGetContexte != null)
                AfterGetContexte(this, contexte);
			return contexte;
		}

		public bool QueryClose()
		{
			return true;
		}

		public CResultAErreur InitFromContexte(CContexteFormNavigable contexte)
		{
			CResultAErreur result = CResultAErreur.True;
			if ( !result )
				return result;
			if(  contexte["OBJETS"] != null )
			{
				ArrayList lst = new ArrayList();
				CStringSerializer serializer = new CStringSerializer ( (string)contexte["OBJETS"], ModeSerialisation.Lecture);
				ArrayList lstObjets = new ArrayList();
				if ( serializer.TraiteArrayListOf2iSerializable ( lst ))
				{
					foreach ( CReferenceObjetDonnee reference in lst )
						lstObjets.Add ( reference.GetObjet(CSc2iWin32DataClient.ContexteCourant) );
					m_objetsAccedes = (CObjetDonneeAIdNumerique[])lstObjets.ToArray ( typeof(CObjetDonneeAIdNumerique) );
				}
			}
			m_controlAgenda.DateEnCours = (DateTime)contexte["DATE"];
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
		private void CFormAgenda_Load(object sender, System.EventArgs e)
		{
            CWin32Traducteur.Translate(this);
			UpdateAgenda();
			m_listeActeurs = new CListeObjetsDonnees ( CSc2iWin32DataClient.ContexteCourant,
				typeof(CActeur) );
			UpdateListe();		
			UpdateLibelleElement();
		}

		//----------------------------------------------------------------------
		private void UpdateListe()
		{
			m_listeActeurs.Filtre = new CFiltreDataAvance ( CActeur.c_nomTable,
				CDonneesActeurUtilisateur.c_nomTable+"."+
				CDonneesActeurUtilisateur.c_champAgendaPersonnel+"=@1",
				true );
			if ( m_txtFiltrer.Text.Trim() != "" )
			{
				m_listeActeurs.Filtre.Filtre += " and "+
					CActeur.c_champNom+" like @2";
				m_listeActeurs.Filtre.Parametres.Add ( "%"+m_txtFiltrer.Text.Trim()+"%" );
			}
			m_wndListeActeurs.ListeSource = null;
			m_wndListeActeurs.ListeSource = m_listeActeurs;
			m_wndListeActeurs.Refresh();
		}

		//----------------------------------------------------------------------
		private void m_controlAgenda_OnAfficherEntreeAgenda(IEntreeAgenda entree)
		{
			if ( entree is CEntreeAgenda )
			{
				CTimosApp.Navigateur.AffichePage(new CFormEditionEntreeAgenda((CEntreeAgenda)entree));
			}
            else if ( entree is timos.data.CFractionIntervention )
            {
                CTimosApp.Navigateur.AffichePage ( new CFormEditionIntervention ( ((timos.data.CFractionIntervention)entree).Intervention ));
            }
			else
			{
				CFormAlerte.Afficher(I.T("This entry cannot be edited|856"), EFormAlerteType.Erreur);
			}
		}

		//----------------------------------------------------------------------
		private void UpdateLibelleElement()
		{
			if ( m_objetsAccedes != null )
			{
				if ( m_objetsAccedes.Length == 1)
					m_lblObjet.Text = m_objetsAccedes[0].DescriptionElement;
				else
					m_lblObjet.Text = m_objetsAccedes.Length.ToString()+I.T(" elements|30125");
			}
			else
				m_lblObjet.Text = "";
		}

		private void m_btnOK_Click(object sender, System.EventArgs e)
		{
			if ( m_wndListeActeurs.SelectedItems.Count == 1 )
			{
				m_objetsAccedes =  new CObjetDonneeAIdNumerique[]{(CObjetDonneeAIdNumerique)m_wndListeActeurs.SelectedItems[0]};
				m_panelRechActeur.Visible = false;
				UpdateAgenda();
			}
		}

		/// ////////////////////////////////////////
		private void m_btnAnnuler_Click(object sender, System.EventArgs e)
		{
			m_panelRechActeur.Visible = false;
		}

		/// ////////////////////////////////////////
		private void m_lblObjet_Click(object sender, System.EventArgs e)
		{
			m_panelRechActeur.Visible = true;
			m_txtFiltrer.Focus();
		}

		private void m_panelRechActeur_Leave(object sender, System.EventArgs e)
		{
			m_panelRechActeur.Visible = false;
		}

		private void m_txtFiltrer_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtFiltrer_Validated(object sender, System.EventArgs e)
		{
			UpdateListe();
		}

		private void m_wndListeActeurs_DoubleClick(object sender, System.EventArgs e)
		{
			m_btnOK_Click ( m_btnOK, new EventArgs());
		}

		
		private void UpdateAgenda()
		{
			CTimosApp.Titre = I.T("Member Diary|30126");
			m_controlAgenda.SetElementsAAgenda ( m_objetsAccedes );
			m_controlAgenda.Refresh();
			UpdateLibelleElement();
		}

		private void m_btnMultiples_Click(object sender, System.EventArgs e)
		{
			m_panelRechActeur.Visible = false;
			CObjetDonneeAIdNumerique[] liste = CFormSelectElementsMultiples.GetListeElements (
				typeof(CActeur), null, m_objetsAccedes );
			if ( liste != null )
			{
				m_objetsAccedes = liste;
				UpdateAgenda();
			}
		}

        public string GetTitle()
        {
            return I.T("Member Diary|30126"); 
        }

        public Image GetImage()
        {
            return Resources.calendar;
        }

	}
}

