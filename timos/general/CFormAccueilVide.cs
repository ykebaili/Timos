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
using System.IO;
using sc2i.data.dynamic;
using sc2i.win32.common;
using sc2i.win32.data.dynamic;
using sc2i.expression;
using sc2i.common.memorydb;
using timos.data.supervision;
using timos.Properties;

namespace timos
{
	/// <summary>
	/// Description résumée de CFormAccueilVide.
	/// </summary>
    [DynamicForm("Home")]
	public class CFormAccueilVide : CFormMaxiSansMenu, IFormNavigable
    {
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre3;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox m_chkSuiviDates;
        protected sc2i.win32.common.CToolTipTraductible m_ToolTipTraductible;
        private IContainer components;

		public CFormAccueilVide()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
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
            this.c2iPanelOmbre3 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_chkSuiviDates = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_ToolTipTraductible = new sc2i.win32.common.CToolTipTraductible(this.components);
            this.c2iPanelOmbre3.SuspendLayout();
            this.SuspendLayout();
            // 
            // c2iPanelOmbre3
            // 
            this.c2iPanelOmbre3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.c2iPanelOmbre3.Controls.Add(this.m_chkSuiviDates);
            this.c2iPanelOmbre3.Controls.Add(this.label4);
            this.c2iPanelOmbre3.Location = new System.Drawing.Point(8, 304);
            this.c2iPanelOmbre3.LockEdition = false;
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
            this.m_chkSuiviDates.Name = "m_chkSuiviDates";
            this.m_chkSuiviDates.Size = new System.Drawing.Size(104, 24);
            this.m_extStyle.SetStyleBackColor(this.m_chkSuiviDates, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkSuiviDates, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkSuiviDates.TabIndex = 5;
            this.m_chkSuiviDates.Text = "Date reporting|30174";
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
            this.label4.Text = "Miscellaneous|30175";
            // 
            // CFormAccueilVide
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(692, 474);
            this.Name = "CFormAccueilVide";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "CFormAccueilVide";
            this.Load += new System.EventHandler(this.CFormAccueil_Load);
            this.Activated += new System.EventHandler(this.CFormAccueil_Activated);
            this.Enter += new System.EventHandler(this.CFormAccueil_Enter);
            this.c2iPanelOmbre3.ResumeLayout(false);
            this.c2iPanelOmbre3.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void CFormAccueil_Load(object sender, System.EventArgs e)
		{
            CCustomiseurFenetresStandard.BrancheSurFenetre(this);
		}

		#region Membres de IFormNavigable

        public event ContexteFormEventHandler AfterGetContexte;
        public event ContexteFormEventHandler AfterInitFromContexte;

        public CContexteFormNavigable GetContexte()
        {
            CContexteFormNavigable contexte = new CContexteFormNavigable(GetType());
            if (AfterGetContexte != null)
                AfterGetContexte(this, contexte);
            return contexte;
        }


        public bool QueryClose()
        {
            return true;
        }

        public sc2i.common.CResultAErreur InitFromContexte(CContexteFormNavigable contexte)
        {
            if (AfterInitFromContexte != null)
                AfterInitFromContexte(this, contexte);
            return CResultAErreur.True;
        }
        //------------------------------------------------------------------
        public CResultAErreur Actualiser()
        {
            CResultAErreur result = InitFromContexte(GetContexte());
            CCustomiseurFenetresStandard.RefreshWindow(this);
            return result;

        }

		#endregion

		#region Membres de IDisposable

		void System.IDisposable.Dispose()
		{
			// TODO : ajoutez l'implémentation de CFormAccueilVide.System.IDisposable.Dispose
		}

		#endregion



		private void CFormAccueil_Enter(object sender, System.EventArgs e)
		{
			CTimosApp.Titre = I.T( "Home page|710");
		}

		

		private void CFormAccueil_Activated(object sender, System.EventArgs e)
		{
            
		}

        public string GetTitle()
        {
            Actualiser();
            return I.T("Home page|710");
            
        }

        public Image GetImage()
        {
            return Resources.home;
        }


      


	}

}

