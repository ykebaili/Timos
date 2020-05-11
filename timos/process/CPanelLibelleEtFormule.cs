using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using sc2i.data;
using sc2i.expression;
using sc2i.workflow;

namespace timos
{
	/// <summary>
	/// Description résumée de CPanelLibelleEtFormule.
	/// </summary>
	public class CPanelLibelleEtFormule : System.Windows.Forms.UserControl, sc2i.win32.common.IControlALockEdition
	{
		private sc2i.win32.expression.CControleEditeFormule m_txtFormule;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private System.Windows.Forms.Label m_lblLibelle;
		private System.Windows.Forms.PictureBox pictureBox1;
		/// <summary> 
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CPanelLibelleEtFormule()
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
            this.m_lblLibelle = new System.Windows.Forms.Label();
            this.m_txtFormule = new sc2i.win32.expression.CControleEditeFormule();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // m_lblLibelle
            // 
            this.m_lblLibelle.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblLibelle, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblLibelle.Name = "m_lblLibelle";
            this.m_lblLibelle.Size = new System.Drawing.Size(128, 16);
            this.m_lblLibelle.TabIndex = 0;
            this.m_lblLibelle.Text = "[Link]|1059";
            // 
            // m_txtFormule
            // 
            this.m_txtFormule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormule.BackColor = System.Drawing.Color.White;
            this.m_txtFormule.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtFormule.Formule = null;
            this.m_txtFormule.Location = new System.Drawing.Point(128, 0);
            this.m_txtFormule.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtFormule, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtFormule.Name = "m_txtFormule";
            this.m_txtFormule.Size = new System.Drawing.Size(304, 56);
            this.m_txtFormule.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(8, 58);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pictureBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(416, 1);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // CPanelLibelleEtFormule
            // 
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.m_txtFormule);
            this.Controls.Add(this.m_lblLibelle);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelLibelleEtFormule";
            this.Size = new System.Drawing.Size(432, 64);
            this.Load += new System.EventHandler(this.CPanelLibelleEtFormule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		public void Init ( 
			string strLibelle, 
			C2iExpression formule, 
			IFournisseurProprietesDynamiques fournisseur,
			Type typeInterroge)
		{
			m_lblLibelle.Text = strLibelle;
			if ( formule!= null )
				m_txtFormule.Text = formule.GetString();
			else
				m_txtFormule.Text =null;
			m_txtFormule.Init ( fournisseur, typeInterroge );
		}

		public sc2i.win32.expression.CControleEditeFormule ZoneFormule
		{
			get
			{
				return m_txtFormule;
			}
		}

		public string TexteFormule
		{
			get
			{
				return m_txtFormule.Text;
			}
			set
			{
				m_txtFormule.Text = value;
			}
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
					OnChangeLockEdition(this, new EventArgs() );
			}
		}

		public event System.EventHandler OnChangeLockEdition;

		#endregion

        private void CPanelLibelleEtFormule_Load(object sender, EventArgs e)
        {
            sc2i.win32.common.CWin32Traducteur.Translate(this);
        }
	}
}
