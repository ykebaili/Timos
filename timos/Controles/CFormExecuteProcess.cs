using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;

using sc2i.common;
using sc2i.data;
using sc2i.process;
using System.Text;

namespace timos
{
	/// <summary>
	/// Description résumée de CFormExecuteProcess.
	/// </summary>
	public class CFormExecuteProcess : System.Windows.Forms.Form, IIndicateurProgression
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label m_labelInfo;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Timer m_timerClignote;
		private System.ComponentModel.IContainer components;

		private delegate CResultAErreur RepriseActionDelegate ( CProcessEnExecutionInDb processEnExec, int nIdAction );
		private delegate CResultAErreur StartProcessDelegate ( CProcess process, CReferenceObjetDonnee refCible, int nIdSession, int? nIdVersion  );
		private delegate CResultAErreur StartProcessMultiplesDelegate ( CProcess process, CReferenceObjetDonnee[] refCible, int nIdSession, int? nIdVersion  );
		private delegate CResultAErreur RunEventDelegate ( IDeclencheurAction declencheur, CObjetDonneeAIdNumerique objetCible );
		private delegate CResultAErreur RunEventMultiplesDelegate ( IDeclencheurAction declencheur, CObjetDonneeAIdNumerique[] objetCible );

		private RepriseActionDelegate m_repriseAction = null;
		private StartProcessDelegate m_startProcess = null;
		private StartProcessMultiplesDelegate m_startProcessMultiples = null;
		private RunEventDelegate m_runEvent = null;
		private System.Windows.Forms.Label m_txtInfo;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private RunEventMultiplesDelegate m_runEventMultiples= null;


		public CFormExecuteProcess()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
			m_repriseAction += new RepriseActionDelegate ( RepriseActionPrivate );
			m_startProcess += new StartProcessDelegate ( StartProcessPrivate );
			m_startProcessMultiples += new StartProcessMultiplesDelegate ( StartProcessMultiplesPrivate );
			m_runEvent += new RunEventDelegate ( RunEventPrivate );
			m_runEventMultiples += new RunEventMultiplesDelegate ( RunEventMultiplesPrivate );
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormExecuteProcess));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.m_labelInfo = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.m_txtInfo = new System.Windows.Forms.Label();
			this.m_timerClignote = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(326, 46);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			// 
			// m_labelInfo
			// 
			this.m_labelInfo.BackColor = System.Drawing.Color.DarkRed;
			this.m_labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_labelInfo.ForeColor = System.Drawing.Color.White;
			this.m_labelInfo.Location = new System.Drawing.Point(104, 36);
			this.m_labelInfo.Name = "m_labelInfo";
			this.m_labelInfo.Size = new System.Drawing.Size(104, 10);
			this.m_labelInfo.TabIndex = 3;
			this.m_labelInfo.Text = "Processing...|814";
			this.m_labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkRed;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.linkLabel1);
			this.panel1.Controls.Add(this.m_labelInfo);
			this.panel1.Controls.Add(this.m_txtInfo);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(568, 77);
			this.panel1.TabIndex = 5;
			// 
			// linkLabel1
			// 
			this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.linkLabel1.LinkColor = System.Drawing.Color.White;
			this.linkLabel1.Location = new System.Drawing.Point(383, 36);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(100, 12);
			this.linkLabel1.TabIndex = 6;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Cancel|11";
			this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// m_txtInfo
			// 
			this.m_txtInfo.BackColor = System.Drawing.Color.DarkRed;
			this.m_txtInfo.ForeColor = System.Drawing.Color.White;
			this.m_txtInfo.Location = new System.Drawing.Point(332, 0);
			this.m_txtInfo.Name = "m_txtInfo";
			this.m_txtInfo.Size = new System.Drawing.Size(235, 36);
			this.m_txtInfo.TabIndex = 5;
			this.m_txtInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// m_timerClignote
			// 
			this.m_timerClignote.Enabled = true;
			this.m_timerClignote.Interval = 500;
			this.m_timerClignote.Tick += new System.EventHandler(this.m_timerClignote_Tick);
			// 
			// CFormExecuteProcess
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(568, 48);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "CFormExecuteProcess";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "CFormExecuteProcess";
			this.Load += new System.EventHandler(this.CFormExecuteProcess_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// /////////////////////////////////////////////////////////////////////////
		private CResultAErreur RepriseActionPrivate (CProcessEnExecutionInDb processEnExec, int nIdAction )
		{
			return processEnExec.RepriseProcess ( nIdAction, this );
		}

		/// /////////////////////////////////////////////////////////////////////////
		private CResultAErreur StartProcessPrivate (CProcess process, CReferenceObjetDonnee refCible, int nIdSession, int? nIdVersion )
		{
			CInfoDeclencheurProcess infoDeclencheur = new CInfoDeclencheurProcess ( TypeEvenement.Manuel );
			return CProcessEnExecutionInDb.StartProcess ( process, infoDeclencheur,refCible, nIdSession, nIdVersion, this );
		}

		
		/// /////////////////////////////////////////////////////////////////////////
		private CResultAErreur StartProcessMultiplesPrivate (CProcess process, CReferenceObjetDonnee[] refsCible, int nIdSession, int? nIdVersion )
		{
			CInfoDeclencheurProcess infoDeclencheur = new CInfoDeclencheurProcess ( TypeEvenement.Manuel );
			return CProcessEnExecutionInDb.StartProcessMultiples ( process, infoDeclencheur,refsCible, nIdSession, nIdVersion, this );
		}

		/// /////////////////////////////////////////////////////////////////////////
		private CResultAErreur RunEventPrivate (IDeclencheurAction declencheur, CObjetDonneeAIdNumerique objetCible )
		{
			CInfoDeclencheurProcess infoDeclencheur = new CInfoDeclencheurProcess ( TypeEvenement.Manuel );
			return declencheur.RunEvent ( objetCible, infoDeclencheur, this );
		}

		/// /////////////////////////////////////////////////////////////////////////
		private CResultAErreur RunEventMultiplesPrivate (IDeclencheurAction declencheur, CObjetDonneeAIdNumerique[] objetsCibles )
		{
			CInfoDeclencheurProcess infoDeclencheur = new CInfoDeclencheurProcess ( TypeEvenement.Manuel );
			return declencheur.RunEventMultiple ( objetsCibles, infoDeclencheur, this );
		}

		/// /////////////////////////////////////////////////////////////////////////
		///Appellée en fin de process
		private void OnEndProcess ( IAsyncResult ar )
		{
            Invoke((MethodInvoker)delegate
            {
                Close();
            });
		}

		/// /////////////////////////////////////////////////////////////////////////
		/// <summary>
		/// Relance une action
		/// </summary>
		/// <param name="processEnExec"></param>
		/// <param name="nIdAction"></param>
		/// <returns></returns>
		public static CResultAErreur RepriseAction( CProcessEnExecutionInDb processEnExec, int nIdAction )
		{
			CFormExecuteProcess form = new CFormExecuteProcess();
			form.Top = 0;
			form.Left =  Screen.PrimaryScreen.WorkingArea.Width/2-form.Width/2;
			
			IAsyncResult res =  form.m_repriseAction.BeginInvoke(processEnExec, nIdAction, 
				new AsyncCallback ( form.OnEndProcess ), null);
			form.ShowDialog();//Bloque le code ici !
			CResultAErreur result = form.m_repriseAction.EndInvoke(res);
			return result;

		}

		/// <summary>
		/// Démarre une action
		/// </summary>
		/// <param name="process"></param>
		/// <param name="nIdSession"></param>
		/// <returns></returns>
		public static CResultAErreur StartProcess ( CProcess process, CReferenceObjetDonnee refCible, int nIdSession, int? nIdVersion, bool bHideProgress )
		{
			CFormExecuteProcess form = new CFormExecuteProcess();
			form.Top = 0;
			form.Left =  Screen.PrimaryScreen.WorkingArea.Width/2-form.Width/2;
			if (bHideProgress)
			{
				return CProcessEnExecutionInDb.StartProcess(
					process,
					new CInfoDeclencheurProcess(TypeEvenement.Manuel),
                    refCible,
					nIdSession,
					nIdVersion,
					null);
			}
			else
			{
				IAsyncResult res = form.m_startProcess.BeginInvoke(process, refCible, nIdSession, nIdVersion,
					new AsyncCallback(form.OnEndProcess), null);
				form.ShowDialog();//Bloque le code ici !
				CResultAErreur result = form.m_startProcess.EndInvoke(res);
				return result;
			}
		}

		/// <summary>
		/// Démarre une action
		/// </summary>
		/// <param name="process"></param>
		/// <param name="nIdSession"></param>
		/// <returns></returns>
		public static CResultAErreur StartProcessMultiples ( CProcess process, CReferenceObjetDonnee[] refsCible, int nIdSession, int? nIdVersion, bool bHideProgress )
		{
			CFormExecuteProcess form = new CFormExecuteProcess();
			form.Top = 0;
			form.Left =  Screen.PrimaryScreen.WorkingArea.Width/2-form.Width/2;
			if (bHideProgress)
			{
				return CProcessEnExecutionInDb.StartProcessMultiples(process, new CInfoDeclencheurProcess(TypeEvenement.Manuel), refsCible, nIdSession, nIdVersion, null);
			}
			else
			{
				IAsyncResult res = form.m_startProcessMultiples.BeginInvoke(process, refsCible, nIdSession, nIdVersion,
					new AsyncCallback(form.OnEndProcess), null);
				form.ShowDialog();//Bloque le code ici !
				CResultAErreur result = form.m_startProcessMultiples.EndInvoke(res);
				return result;
			}
		}

		/// <summary>
		/// Démarre une action
		/// </summary>
		/// <param name="process"></param>
		/// <param name="nIdSession"></param>
		/// <returns></returns>
		public static CResultAErreur RunEvent ( IDeclencheurAction declencheur, CObjetDonneeAIdNumerique objetCible, bool bHideProgress )
		{
			CFormExecuteProcess form = new CFormExecuteProcess();
			form.Top = 0;
			form.Left =  Screen.PrimaryScreen.WorkingArea.Width/2-form.Width/2;
			if (declencheur is IDeclencheurActionManuelle)
				bHideProgress |= ((IDeclencheurActionManuelle)declencheur).HideProgress;
			if (bHideProgress)
			{
				CInfoDeclencheurProcess infoDeclencheur = new CInfoDeclencheurProcess(TypeEvenement.Manuel);
                CAppelleurFonctionAsynchrone appeleur = new CAppelleurFonctionAsynchrone();
                CResultAErreur resultDefault = CResultAErreur.True;
                resultDefault.EmpileErreur(I.T("Asynchronous call error @1|20149","RunEvent"));
                return appeleur.StartFonctionAndWaitAvecCallback(declencheur.GetType(), declencheur,
                    "RunEvent","", resultDefault, objetCible, infoDeclencheur, null) as CResultAErreur;
				//return declencheur.RunEvent(objetCible, infoDeclencheur, null);
			}
			else
			{
				IAsyncResult res = form.m_runEvent.BeginInvoke(declencheur, objetCible,
					new AsyncCallback(form.OnEndProcess), null);
				form.ShowDialog();//Bloque le code ici !
				CResultAErreur result = form.m_runEvent.EndInvoke(res);
				return result;
			}
		}

		/// <summary>
		/// Démarre une action
		/// </summary>
		/// <param name="process"></param>
		/// <param name="nIdSession"></param>
		/// <returns></returns>
		public static CResultAErreur RunEventMultiple ( IDeclencheurAction declencheur, CObjetDonneeAIdNumerique[] objetsCibles, bool bHideProgress )
		{
			CFormExecuteProcess form = new CFormExecuteProcess();
			form.Top = 0;
			form.Left =  Screen.PrimaryScreen.WorkingArea.Width/2-form.Width/2;
			if (declencheur is IDeclencheurActionManuelle)
				bHideProgress |= ((IDeclencheurActionManuelle)declencheur).HideProgress;
			if (bHideProgress)
			{
				CInfoDeclencheurProcess infoDeclencheur = new CInfoDeclencheurProcess(TypeEvenement.Manuel);
				return declencheur.RunEventMultiple(objetsCibles, infoDeclencheur, null);
			}
			else
			{
				IAsyncResult res = form.m_runEventMultiples.BeginInvoke(declencheur, objetsCibles,
					new AsyncCallback(form.OnEndProcess), null);
				form.ShowDialog();//Bloque le code ici !
				CResultAErreur result = form.m_runEventMultiples.EndInvoke(res);
				return result;
			}
		}

		private void m_timerClignote_Tick(object sender, System.EventArgs e)
		{
			m_labelInfo.Visible = !m_labelInfo.Visible;
		}
		#region Membres de IIndicateurProgression
		private ArrayList m_listeLibelles = new ArrayList();
		public void PushSegment(int nMin, int nMax)
		{
			// TODO : ajoutez l'implémentation de CFormExecuteProcess.PushSegment
		}

		public void SetValue(int nValue)
		{
			// TODO : ajoutez l'implémentation de CFormExecuteProcess.SetValue
		}

		private bool m_bCancelRequest = false;
		public bool CancelRequest
		{
			get
			{
				return m_bCancelRequest;
			}
		}

		public void PushLibelle(string strLibelle)
		{
			m_listeLibelles.Add(strLibelle);
		}

		public void PopLibelle()
		{
			if (m_listeLibelles.Count > 0)
				m_listeLibelles.RemoveAt(m_listeLibelles.Count - 1);
		}

		public void PopSegment()
		{
			// TODO : ajoutez l'implémentation de CFormExecuteProcess.PopSegment
		}

		public void SetInfo(string strInfo)
		{
			// TODO : ajoutez l'implémentation de CFormExecuteProcess.SetInfo
			StringBuilder builder = new StringBuilder();
			foreach (string strLibelle in m_listeLibelles)
			{
				builder.Append(strLibelle);
				builder.Append("/");
			}
			builder.Append(strInfo);

			m_txtInfo.Text = builder.ToString() ;
		}

		public bool CanCancel
		{
			get
			{
				return true;
			}
			set
			{
				
			}
		}

		public void SetBornesSegment(int nMin, int nMax)
		{
			// TODO : ajoutez l'implémentation de CFormExecuteProcess.SetBornesSegment
		}

		public void Masquer(bool bMasquer)
		{
			if (bMasquer)
				SendToBack();
			else
			{
				BringToFront();
				Refresh();
			}
		}

		#endregion

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			m_bCancelRequest = true;
			m_txtInfo.Text = I.T("Cancel in progress|30111");
		}

		private void CFormExecuteProcess_Load(object sender, EventArgs e)
		{
			sc2i.win32.common.CWin32Traducteur.Translate(this);
		}
	}
}
