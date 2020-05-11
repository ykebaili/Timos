using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using sc2i.expression;
using sc2i.process;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.win32.expression;
using sc2i.win32.process;

using timos.data;
using sc2i.win32.common;
using sc2i.data;


namespace timos
{
	public class CFormEditeParametrageRemplissageTypeActivite : System.Windows.Forms.Form
	{
		private CParametreRemplissageActiviteParIntervention m_parametre = null;
		private CTypeActiviteActeur m_typeActivite = null;
		private CControleEditeFormule m_txtFormule = null;
		private Panel panel2;
		private Panel m_panelFormules;
		private sc2i.win32.expression.CControlAideFormule m_wndAideFormule;
		private Panel panel1;
		private Button m_btnAnnuler;
		private Button m_btnOk;
		private sc2i.win32.common.CExtStyle cExtStyle1;
        private SplitContainer splitContainer1;
		private System.ComponentModel.IContainer components = null;

		public CFormEditeParametrageRemplissageTypeActivite()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();

			// TODO : ajoutez les initialisations après l'appel à InitializeComponent
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


		public static bool EditeParametre( ref CParametreRemplissageActiviteParIntervention parametre,
			CTypeActiviteActeur typeActivite)
		{
			CFormEditeParametrageRemplissageTypeActivite form = new CFormEditeParametrageRemplissageTypeActivite();
			form.m_typeActivite = typeActivite;
			form.m_parametre = parametre;
			bool bResult = form.ShowDialog() == DialogResult.OK ;
			if (bResult)
				parametre = form.m_parametre;
			form.Dispose();
			return bResult;
		}


		#region Code généré par le concepteur
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditeParametrageRemplissageTypeActivite));
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_panelFormules = new System.Windows.Forms.Panel();
            this.m_wndAideFormule = new sc2i.win32.expression.CControlAideFormule();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.cExtStyle1 = new sc2i.win32.common.CExtStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Location = new System.Drawing.Point(3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(723, 416);
            this.cExtStyle1.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 5;
            // 
            // m_panelFormules
            // 
            this.m_panelFormules.AutoScroll = true;
            this.m_panelFormules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelFormules.Location = new System.Drawing.Point(0, 0);
            this.m_panelFormules.Name = "m_panelFormules";
            this.m_panelFormules.Size = new System.Drawing.Size(474, 412);
            this.cExtStyle1.SetStyleBackColor(this.m_panelFormules, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_panelFormules, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFormules.TabIndex = 5;
            // 
            // m_wndAideFormule
            // 
            this.m_wndAideFormule.BackColor = System.Drawing.Color.White;
            this.m_wndAideFormule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndAideFormule.FournisseurProprietes = null;
            this.m_wndAideFormule.Location = new System.Drawing.Point(0, 0);
            this.m_wndAideFormule.Name = "m_wndAideFormule";
            this.m_wndAideFormule.ObjetInterroge = null;
            this.m_wndAideFormule.SendIdChamps = false;
            this.m_wndAideFormule.Size = new System.Drawing.Size(237, 412);
            this.cExtStyle1.SetStyleBackColor(this.m_wndAideFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
            this.cExtStyle1.SetStyleForeColor(this.m_wndAideFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndAideFormule.TabIndex = 0;
            this.m_wndAideFormule.OnSendCommande += new sc2i.win32.expression.SendCommande(this.m_wndAideFormule_OnSendCommande);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnAnnuler);
            this.panel1.Controls.Add(this.m_btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 424);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(729, 48);
            this.cExtStyle1.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 6;
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.m_btnAnnuler.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAnnuler.Image")));
            this.m_btnAnnuler.Location = new System.Drawing.Point(371, 2);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(40, 40);
            this.cExtStyle1.SetStyleBackColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAnnuler.TabIndex = 3;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnOk.ForeColor = System.Drawing.Color.White;
            this.m_btnOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btnOk.Image")));
            this.m_btnOk.Location = new System.Drawing.Point(317, 2);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(40, 40);
            this.cExtStyle1.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOk.TabIndex = 2;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_panelFormules);
            this.cExtStyle1.SetStyleBackColor(this.splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_wndAideFormule);
            this.cExtStyle1.SetStyleBackColor(this.splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer1.Size = new System.Drawing.Size(723, 416);
            this.splitContainer1.SplitterDistance = 478;
            this.cExtStyle1.SetStyleBackColor(this.splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer1.TabIndex = 6;
            // 
            // CFormEditeParametrageRemplissageTypeActivite
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(729, 472);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CFormEditeParametrageRemplissageTypeActivite";
            this.cExtStyle1.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
            this.cExtStyle1.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.Text = "Activity parameters|549";
            this.Load += new System.EventHandler(this.CFormEditeParametrageRemplissageTypeActivite_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion






		/// //////////////////////////////////////////
		protected void InitChamps()
		{
			m_wndAideFormule.FournisseurProprietes = new CFournisseurPropDynStd(true);
			m_wndAideFormule.ObjetInterroge = typeof(CFractionIntervention);
			FillListeChamps();
		}

		/// //////////////////////////////////////////
		private void CFormEditeParametrageRemplissageTypeActivite_Load(object sender, EventArgs e)
		{
			// Traduit le formulaire
			sc2i.win32.common.CWin32Traducteur.Translate(this);

			InitChamps();

		}


		private class CFormuleForParametre : IComparable
		{
			public readonly CChampCustom ChampCustom = null;
			private C2iExpression m_expression;
			private CEditeurFormuleNommee m_editeur;

			public CFormuleForParametre(CChampCustom champCustom)
			{
				ChampCustom = champCustom;
			}

			public C2iExpression Formule
			{
				get
				{
					return m_expression;
				}
				set
				{
					m_expression = value;
				}
			}

			public CEditeurFormuleNommee Editeur
			{
				get
				{
					return m_editeur;
				}
				set
				{
					m_editeur = value;
				}
			}

			public CResultAErreur UpdateFromEditeur()
			{
				CResultAErreur result = m_editeur.ResultAnalyse;
				if (result)
					Formule = m_editeur.Formule;
				return result;
			}
			#region Membres de IComparable

			public int CompareTo(object obj)
			{
				try
				{
					return ChampCustom.Nom.CompareTo(((CFormuleForParametre)obj).ChampCustom.Nom);
				}
				catch
				{
					return -1;
				}
			}

			#endregion


		}

		/// //////////////////////////////////////////
		private ArrayList m_reserveEditeurs = new ArrayList();

		/// //////////////////////////////////////////
		private ArrayList m_listeExpressions = new ArrayList();
		private void FillListeChamps()
		{
			if (m_parametre == null)
				m_parametre = new CParametreRemplissageActiviteParIntervention();
			m_panelFormules.SuspendDrawing();
			foreach (Control ctrl in m_panelFormules.Controls)
			{
				if (ctrl is CEditeurFormuleNommee)
				{
					ctrl.Visible = false;
					m_reserveEditeurs.Add(ctrl);
				}
			}
			ArrayList lst = new ArrayList();

			// Recupère la liste des champs customs liés à des Activités
            CListeObjetsDonnees lstChamps = CChampCustom.GetListeChampsForRole(m_typeActivite.ContexteDonnee, CActiviteActeur.c_roleChampCustom);
            //CChampCustom[] champs = m_typeActivite.TousLesChampsAssocies;
            CChampCustom[] champs = (CChampCustom[]) lstChamps.ToArray(typeof(CChampCustom));

            foreach (CChampCustom champ in champs)
			{
				CFormuleForParametre formule = new CFormuleForParametre(champ);
				formule.Formule = m_parametre.GetFormuleForChamp(champ);
				lst.Add(formule);
			}
			lst.Sort();
			m_listeExpressions = lst;
			int nY = 0;

			foreach (CFormuleForParametre formule in lst)
			{
				CEditeurFormuleNommee editeur = null;
				if (m_reserveEditeurs.Count > 0)
				{
					editeur = (CEditeurFormuleNommee)m_reserveEditeurs[0];
					m_reserveEditeurs.Remove(editeur);
				}
				else
				{
					editeur = new CEditeurFormuleNommee();
					editeur.Parent = m_panelFormules;
				}
				editeur.Visible = true;
				editeur.Width = m_panelFormules.ClientRectangle.Width;
				editeur.Location = new Point(0, nY);
				formule.Editeur = editeur;
				editeur.TextFormule.Enter += new EventHandler(OnEnterZoneFormule);
				editeur.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);
				editeur.Libelle = formule.ChampCustom.Nom;
				editeur.TabIndex = nY;
                editeur.Dock = DockStyle.Top;
                editeur.BringToFront();
				nY += editeur.Size.Height + 1;
				editeur.Formule = formule.Formule;
			}
			m_panelFormules.ResumeDrawing();
		}

		private void m_wndAideFormule_OnSendCommande(string strCommande, int nPosCurseur)
		{
			if (m_txtFormule != null)
				m_wndAideFormule.InsereInTextBox(m_txtFormule, nPosCurseur, strCommande);
		}


		/// //////////////////////////////////////////
		private void OnEnterZoneFormule(object sender, EventArgs args)
		{
			if (sender is CControleEditeFormule)
			{
				if (m_txtFormule != null)
					m_txtFormule.BackColor = Color.White;
				m_txtFormule = (CControleEditeFormule)sender;
				m_txtFormule.BackColor = Color.LightGreen;
			}
		}

		/// //////////////////////////////////////////
		private string GetStringExpression(object elementInterroge, object objet)
		{
			if (objet == null)
				return "";
			return ((C2iExpression)objet).GetString();
		}

		private CResultAErreur MajChamps()
		{
			CResultAErreur result = CResultAErreur.True;
			if (m_parametre == null)
				m_parametre = new CParametreRemplissageActiviteParIntervention();
			m_parametre.ListeRemplissage.Clear();
			foreach (CFormuleForParametre formule in m_listeExpressions)
			{
				result = formule.UpdateFromEditeur();
				if (result)
				{
					C2iExpression expression = formule.Formule;
					if (expression != null)
					{
						CRemplisssageChampActiviteActeur remplissage = new CRemplisssageChampActiviteActeur();
						remplissage.IdChampCustom = formule.ChampCustom.Id;
						remplissage.Formule = formule.Formule;
						m_parametre.ListeRemplissage.Add(remplissage);
					}
				}
				else
				{
					result.EmpileErreur(I.T("Error in the formula of @1|30192", formule.ChampCustom.Nom));
					return result;
				}
			}
			return result;
		}

		private void m_btnOk_Click(object sender, EventArgs e)
		{
			CResultAErreur result = MajChamps();
			if (!result)
			{
				CFormAlerte.Afficher(result.Erreur);
				return;
			}
			DialogResult = DialogResult.OK;
			Close();
		}

		private void m_btnAnnuler_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}

