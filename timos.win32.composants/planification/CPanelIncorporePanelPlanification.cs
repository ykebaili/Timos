using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using sc2i.win32.common;
using sc2i.common.planification;
using sc2i.common;

namespace timos.win32.composants
{
	/// <summary>
	/// Description résumée de CPanelIncorporePanelPlanification.
	/// </summary>
	public class CPanelIncorporePanelPlanification : System.Windows.Forms.UserControl, IControlALockEdition
	{
		private int m_nDefautHeight = 0;
		private System.Windows.Forms.Panel m_panelTop;
		private CEditeurPlanificationIntervention m_panelEdition;
		private System.Windows.Forms.Button m_btnPlus;
		private System.Windows.Forms.Label m_lblTitre;
		private System.Windows.Forms.PictureBox pictureBox1;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private System.Windows.Forms.PictureBox m_btnDelete;
		/// <summary> 
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CPanelIncorporePanelPlanification()
		{
			// Cet appel est requis par le Concepteur de formulaires Windows.Forms.
			InitializeComponent();

			// TODO : ajoutez les initialisations après l'appel à InitializeComponent

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

		#region Code généré par le Concepteur de composants
		/// <summary> 
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CPanelIncorporePanelPlanification));
			this.m_panelTop = new System.Windows.Forms.Panel();
			this.m_btnDelete = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.m_lblTitre = new System.Windows.Forms.Label();
			this.m_btnPlus = new System.Windows.Forms.Button();
			this.m_panelEdition = new CEditeurPlanificationIntervention();
			this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
			this.m_panelTop.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_panelTop
			// 
			this.m_panelTop.Controls.Add(this.m_btnDelete);
			this.m_panelTop.Controls.Add(this.pictureBox1);
			this.m_panelTop.Controls.Add(this.m_lblTitre);
			this.m_panelTop.Controls.Add(this.m_btnPlus);
			this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_panelTop.Location = new System.Drawing.Point(0, 0);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTop, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_panelTop.Name = "m_panelTop";
			this.m_panelTop.Size = new System.Drawing.Size(440, 24);
			this.m_panelTop.TabIndex = 0;
			// 
			// m_btnDelete
			// 
			this.m_btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("m_btnDelete.Image")));
			this.m_btnDelete.Location = new System.Drawing.Point(16, 4);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnDelete, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_btnDelete.Name = "m_btnDelete";
			this.m_btnDelete.Size = new System.Drawing.Size(16, 16);
			this.m_btnDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.m_btnDelete.TabIndex = 3;
			this.m_btnDelete.TabStop = false;
			this.m_btnDelete.Click += new System.EventHandler(this.m_btnDelete_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Black;
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.m_gestionnaireModeEdition.SetModeEdition(this.pictureBox1, sc2i.win32.common.TypeModeEdition.Autonome);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(440, 1);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// m_lblTitre
			// 
			this.m_lblTitre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lblTitre.Location = new System.Drawing.Point(32, 4);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblTitre, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_lblTitre.Name = "m_lblTitre";
			this.m_lblTitre.Size = new System.Drawing.Size(408, 16);
			this.m_lblTitre.TabIndex = 1;
			// 
			// m_btnPlus
			// 
			this.m_btnPlus.Location = new System.Drawing.Point(0, 4);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnPlus, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_btnPlus.Name = "m_btnPlus";
			this.m_btnPlus.Size = new System.Drawing.Size(16, 16);
			this.m_btnPlus.TabIndex = 0;
			this.m_btnPlus.Text = "-";
			this.m_btnPlus.Click += new System.EventHandler(this.m_btnPlus_Click);
			// 
			// m_panelEdition
			// 
			this.m_panelEdition.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_panelEdition.Location = new System.Drawing.Point(0, 24);
			this.m_panelEdition.LockEdition = true;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEdition, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_panelEdition.Name = "m_panelEdition";
			this.m_panelEdition.Size = new System.Drawing.Size(440, 112);
			this.m_panelEdition.TabIndex = 1;
			this.m_panelEdition.Leave += new System.EventHandler(this.m_panelEdition_Leave);
			// 
			// m_gestionnaireModeEdition
			// 
			this.m_gestionnaireModeEdition.ModeEditionChanged += new System.EventHandler(this.m_gestionnaireModeEdition_ModeEditionChanged);
			// 
			// CPanelIncorporePanelPlanification
			// 
			this.Controls.Add(this.m_panelEdition);
			this.Controls.Add(this.m_panelTop);
			this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.Name = "CPanelIncorporePanelPlanification";
			this.Size = new System.Drawing.Size(440, 136);
			this.m_panelTop.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void m_btnPlus_Click(object sender, System.EventArgs e)
		{
			if ( m_panelEdition.Visible )
			{
				Collapse();
			}
			else
			{
				Expand();
			}
		}

		public void Expand()
		{
			Height = m_nDefautHeight;
			m_panelEdition.Visible = true;
			m_btnPlus.Text = "-";
			
		}

		public void Collapse()
		{
			if ( Height > m_panelTop.Height )
				m_nDefautHeight = Height;
			Height = m_panelTop.Height;
			m_btnPlus.Text = "+";
			m_panelEdition.Visible = false;
			UpdateTitre();
		}
		#region Membres de IControlALockEdition

		public bool LockEdition
		{
			get
			{
				return !m_gestionnaireModeEdition.ModeEdition;
			}
			set
			{
				m_gestionnaireModeEdition.ModeEdition = !value;
				if ( OnChangeLockEdition != null )
					OnChangeLockEdition ( this, new EventArgs() );
			}
		}

		public event System.EventHandler OnChangeLockEdition;

		#endregion
		/// //////////////////////////////////////
		public void Init ( CPlanificationTache planification )
		{
			m_panelEdition.Init ( planification );
			m_lblTitre.Text = planification.GetLibelle();
		}

		/// //////////////////////////////////////
		public CResultAErreur MajChamps()
		{
			CResultAErreur result = m_panelEdition.ValideDonnees();
			if ( result && m_panelEdition.Planification != null)
				m_lblTitre.Text = m_panelEdition.Planification.GetLibelle();
			return result;
		}

		/// //////////////////////////////////////
        public CPlanificationTache Planification
		{
			get
			{
				return m_panelEdition.Planification;
			}
		}

		public event EventHandler OnDeletePlanification;
		
		////////////////////////////////////////////////////////////////////////
		private void m_btnDelete_Click(object sender, System.EventArgs e)
		{
			if ( OnDeletePlanification != null )
				OnDeletePlanification(this, new EventArgs() );
		}

		////////////////////////////////////////////////////////////////////////
		private void UpdateTitre()
		{
			m_panelEdition.ValideDonnees();
			if ( Planification != null )
				m_lblTitre.Text = Planification.GetLibelle();
		}

		////////////////////////////////////////////////////////////////////////
		private void m_panelEdition_Leave(object sender, System.EventArgs e)
		{
			//UpdateTitre();
		}

		private void m_gestionnaireModeEdition_ModeEditionChanged(object sender, System.EventArgs e)
		{
			m_btnDelete.Visible = !LockEdition;
		}
	}

}
