using System;
using System.Drawing;
using System.Collections;
using System.Text;
using System.Threading;

using sc2i.common;
using sc2i.multitiers.client;
using System.Windows.Forms;

namespace timos
{
	/// <summary>
	/// Description résumée de CFormProgressTimos.
	/// </summary>
	public class CFormProgressTimos : System.Windows.Forms.Form, IIndicateurProgression, I2iMarshalObject
	{
		private static CFormProgressTimos m_form = null;
		private ArrayList m_listeLibelles = new ArrayList();
		//Vrai si l'utilisateur a demandé l'annulation du traitement
		private bool m_bCancelRequest = false;
		private CGestionnaireSegmentsProgression m_gestionnaireSegments = new CGestionnaireSegmentsProgression();
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label m_labelInfo;
		private System.Windows.Forms.Button m_btnReduire;
		private System.Windows.Forms.ToolTip m_tooltip;
		private System.Windows.Forms.LinkLabel m_lnkAnnuler;
		private System.Windows.Forms.ProgressBar m_progressBar;
		private System.Windows.Forms.Panel m_panelMove;
		private System.Windows.Forms.Label label2;
        protected sc2i.win32.common.CExtStyle m_ExtStyle;
		private System.ComponentModel.IContainer components;

		public CFormProgressTimos()
		{
			InitializeComponent();
            sc2i.win32.common.CWin32Traducteur.Translate(this);
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.m_labelInfo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.m_panelMove = new System.Windows.Forms.Panel();
            this.m_lnkAnnuler = new System.Windows.Forms.LinkLabel();
            this.m_progressBar = new System.Windows.Forms.ProgressBar();
            this.m_btnReduire = new System.Windows.Forms.Button();
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.m_ExtStyle = new sc2i.win32.common.CExtStyle();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_labelInfo
            // 
            this.m_labelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_labelInfo.ForeColor = System.Drawing.Color.Black;
            this.m_labelInfo.Location = new System.Drawing.Point(0, 40);
            this.m_labelInfo.Name = "m_labelInfo";
            this.m_labelInfo.Size = new System.Drawing.Size(324, 60);
            this.m_ExtStyle.SetStyleBackColor(this.m_labelInfo, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_labelInfo, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_labelInfo.TabIndex = 1;
            this.m_labelInfo.Text = "Processing...|814";
            this.m_labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.m_panelMove);
            this.panel1.Controls.Add(this.m_lnkAnnuler);
            this.panel1.Controls.Add(this.m_progressBar);
            this.panel1.Controls.Add(this.m_btnReduire);
            this.panel1.Controls.Add(this.m_labelInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 149);
            this.m_ExtStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
            this.m_ExtStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(316, 24);
            this.m_ExtStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 12;
            this.label2.Text = "Timos";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_panelMove
            // 
            this.m_panelMove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelMove.Location = new System.Drawing.Point(0, 0);
            this.m_panelMove.Name = "m_panelMove";
            this.m_panelMove.Size = new System.Drawing.Size(292, 8);
            this.m_ExtStyle.SetStyleBackColor(this.m_panelMove, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_panelMove, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMove.TabIndex = 6;
            // 
            // m_lnkAnnuler
            // 
            this.m_lnkAnnuler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lnkAnnuler.ForeColor = System.Drawing.Color.Black;
            this.m_lnkAnnuler.LinkColor = System.Drawing.Color.Black;
            this.m_lnkAnnuler.Location = new System.Drawing.Point(260, 125);
            this.m_lnkAnnuler.Name = "m_lnkAnnuler";
            this.m_lnkAnnuler.Size = new System.Drawing.Size(48, 16);
            this.m_ExtStyle.SetStyleBackColor(this.m_lnkAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_lnkAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAnnuler.TabIndex = 5;
            this.m_lnkAnnuler.TabStop = true;
            this.m_lnkAnnuler.Text = "Cancel|11";
            this.m_lnkAnnuler.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.m_lnkAnnuler.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAnnuler_LinkClicked);
            // 
            // m_progressBar
            // 
            this.m_progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_progressBar.Location = new System.Drawing.Point(10, 103);
            this.m_progressBar.Name = "m_progressBar";
            this.m_progressBar.Size = new System.Drawing.Size(300, 22);
            this.m_ExtStyle.SetStyleBackColor(this.m_progressBar, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_progressBar, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_progressBar.TabIndex = 4;
            // 
            // m_btnReduire
            // 
            this.m_btnReduire.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnReduire.Location = new System.Drawing.Point(300, 0);
            this.m_btnReduire.Name = "m_btnReduire";
            this.m_btnReduire.Size = new System.Drawing.Size(16, 8);
            this.m_ExtStyle.SetStyleBackColor(this.m_btnReduire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_btnReduire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnReduire.TabIndex = 3;
            this.m_tooltip.SetToolTip(this.m_btnReduire, "Réduire cette fenêtre");
            this.m_btnReduire.Click += new System.EventHandler(this.m_btnReduire_Click);
            // 
            // CFormProgressTimos
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(322, 149);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "CFormProgressTimos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.m_ExtStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "Traitement en cours";
            this.Load += new System.EventHandler(this.CFormProgressTimos_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// /////////////////////////////////////////////////////////////////
		private void CFormProgressTimos_Load(object sender, System.EventArgs e)
		{
		}

		/// /////////////////////////////////////////////////////////////////
		public void PushSegment ( int nMin, int nMax )
		{
			m_gestionnaireSegments.PushSegment ( nMin, nMax );
		}

		/////////////////////////////////////
		public void PushLibelle(string strLibelle)
		{
			m_listeLibelles.Add(strLibelle);
		}

		/// /////////////////////////////////////////////////////////////////
		public void PopLibelle()
		{
			if (m_listeLibelles.Count > 0)
				m_listeLibelles.RemoveAt(m_listeLibelles.Count - 1);
		}

		/// /////////////////////////////////////////////////////////////////
		public void SetBornesSegment ( int nMin, int nMax )
		{
			m_gestionnaireSegments.MinValue = nMin;
			m_gestionnaireSegments.MaxValue = nMax;
		}

		/// /////////////////////////////////////////////////////////////////
		public void PopSegment()
		{
			m_gestionnaireSegments.PopSegment();
		}

		/// /////////////////////////////////////////////////////////////////
		public void SetValue ( int nValue )
		{
            m_progressBar.BeginInvoke((MethodInvoker)delegate
            {
                try
                {
                    m_progressBar.Value = m_gestionnaireSegments.GetValeurReelle(nValue);
                    Text = m_progressBar.Value.ToString() + "% " + "Traitement en cours";
                    Refresh();
                    m_progressBar.Refresh();
                }
                catch { }
            });
		}

		/// /////////////////////////////////////////////////////////////////
		public void SetInfo ( string strInfo )
		{
            m_labelInfo.BeginInvoke((MethodInvoker)delegate
            {
                StringBuilder builder = new StringBuilder();
                foreach (string strLibelle in m_listeLibelles)
                {
                    builder.Append(strLibelle);
                    builder.Append("/");
                }
                builder.Append(strInfo);
                m_labelInfo.Text = builder.ToString();
                m_labelInfo.Refresh();
            });
		}

		/// /////////////////////////////////////////////////////////////////
		public bool CancelRequest
		{
			get
			{
				return m_bCancelRequest;
			}
		}

		/// /////////////////////////////////////////////////////////////////
		public bool CanCancel
		{
			get
			{
				return m_lnkAnnuler.Visible;
			}
			set
			{
                m_lnkAnnuler.Invoke((MethodInvoker)delegate
                {
                    m_lnkAnnuler.Visible = value;
                });
			}
		}

		/// /////////////////////////////////////////////////////////////////
		private void OnEndProcess ( IAsyncResult result )
		{
            if (IsHandleCreated)
            {
                Invoke((MethodInvoker)delegate
                {
                    ResetSegmentsProgression();
                    Close();
                    m_form = null;
                });
            }

		}

		/// /////////////////////////////////////////////////////////////////
		public static void StartThreadWithProgress ( string strTitre, ThreadStart fonctionDemarrage,bool bWaitEnd  )
		{
			if ( m_form == null )
				m_form = new CFormProgressTimos();
			m_form.ResetSegmentsProgression();
			m_form.TopMost = true;
			m_form.BringToFront();
			m_form.m_labelInfo.Text = strTitre;
			m_form.Show();
			m_form.TopMost = false;
            m_form.Refresh();
			if (bWaitEnd)
			{

				try
				{
					Thread th = new Thread(fonctionDemarrage);
					th.SetApartmentState(ApartmentState.STA);
					th.Start();
					th.Join();
                }
                catch{}
                try
                {
					m_form.Hide();
				}
				catch
				{ }
			}
			else
				fonctionDemarrage.BeginInvoke(new AsyncCallback(m_form.OnEndProcess), null); 
		}


		/// /////////////////////////////////////////////////////////////////
		public void ResetSegmentsProgression()
		{
			m_gestionnaireSegments = new CGestionnaireSegmentsProgression();
		}

		/// /////////////////////////////////////////////////////////////////
		public static IIndicateurProgression Indicateur
		{
			get
			{
				if ( m_form == null )
					m_form =new CFormProgressTimos();
				return m_form;
			}
		}


		public void Masquer(bool bMasquer)
		{
            Invoke((MethodInvoker)delegate
            {
                if (bMasquer)
                    SendToBack();
                else
                {
                    BringToFront();
                    Refresh();
                }
            });
		}

		/// /////////////////////////////////////////////////////////////////
		private void m_lnkAnnuler_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_bCancelRequest = true;
			m_labelInfo.Text = "Cancel in progress|30111";
		}

		private void m_btnReduire_Click(object sender, System.EventArgs e)
		{
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
		}
		#region Membres de I2iMarshalObject

		public void RenouvelleBailParAppel()
		{
			string strTemp = ToString();
		}

        private string m_strIdUnique = "";
        public string UniqueId
        {
            get
            {
                if (m_strIdUnique.Length == 0)
                    m_strIdUnique = CUniqueIdentifier.GetNew();
                return m_strIdUnique;
            }
        }

		#endregion
	}
}
