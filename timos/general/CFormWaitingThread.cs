using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using sc2i.common;
using System.Reflection;
using sc2i.win32.common;

namespace timos
{
    [AutoExec("Autoexec")]
	public partial class CFormWaitingThread : Form, IMultiThreader
	{

        IAsyncResult m_asyncRes = null;
        private Timer m_timerAttendLaFin;
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private delegate void StartThreadDelegate(Type typeObjetAppele, object objetAppele, string strMethode, object defaultResult, params object[] parametres);

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormWaitingThread));
            this.m_image = new sc2i.win32.common.CAnimatedPictureBox();
            this.m_timerAttendLaFin = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.m_image)).BeginInit();
            this.SuspendLayout();
            // 
            // m_image
            // 
            this.m_image.AnimatedImage = ((System.Drawing.Image)(resources.GetObject("m_image.AnimatedImage")));
            this.m_image.AnimationDelay = 150;
            this.m_image.AnimationOption = sc2i.win32.common.EAnimationOption.Loop;
            this.m_image.Image = ((System.Drawing.Image)(resources.GetObject("m_image.Image")));
            this.m_image.Location = new System.Drawing.Point(0, 0);
            this.m_image.Name = "m_image";
            this.m_image.Size = new System.Drawing.Size(16, 11);
            this.m_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_image.TabIndex = 0;
            this.m_image.TabStop = false;
            this.m_image.Click += new System.EventHandler(this.m_image_Click);
            // 
            // m_timerAttendLaFin
            // 
            this.m_timerAttendLaFin.Enabled = true;
            this.m_timerAttendLaFin.Tick += new System.EventHandler(this.m_timerAttendLaFin_Tick);
            // 
            // CFormWaitingThread
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(53, 24);
            this.ControlBox = false;
            this.Controls.Add(this.m_image);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CFormWaitingThread";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.CFormWaitingThread_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        
        //public static void Go(int nTick)
		//{
		//    CFormWaitingThread frm = new CFormWaitingThread(nTick);
		//    frm.ShowDialog();
		//}

		
		public CFormWaitingThread()
		{
			InitializeComponent();

		}

        public static void Autoexec()
        {
            CAppelleurFonctionAsynchrone.SetTypeMultiThreader(typeof(CFormWaitingThread));
        }

        public void Show(Form frm, IAsyncResult asyncResult)
        {
            m_asyncRes = asyncResult;
            int nHeight = SystemInformation.CaptionHeight;
            Size = new Size(30, nHeight);
            //m_image.Size = new Size(nHeight, nHeight);
            Point pt = new Point(frm.Location.X + frm.Size.Width / 2 - m_image.Width / 2,
                frm.Location.Y + nHeight / 2 - m_image.Height / 2);
            //pt = frm.PointToScreen(new Point(0, 0));
            /*pt = frm.PointToScreen(new Point(frm.ClientSize.Width - m_image.Width,
                frm.ClientSize.Height - m_image.Height));*/
            Location = pt;
            ShowDialog();
        }

		

		private void CFormWaitingThread_Load(object sender, EventArgs e)
		{
            
		}

        private CAnimatedPictureBox m_image;

		

        #region IMultiThreader Membres

        private object m_result = null;
        public object StartFonctionAndWaitAvecCallback(
            Type typeObjetAppele, 
            object objetAppele, 
            string strMethode, 
            string strLibelle,
            object defaultResult,
            params object[] parametres)
        {
            StartThreadDelegate st = new StartThreadDelegate(StartThread);
            IAsyncResult asyncRes = st.BeginInvoke(typeObjetAppele, objetAppele, strMethode, defaultResult, parametres, null, null);
            Show(CTimosApp.Navigateur, asyncRes);
            Dispose();
            return m_result;
        }

        private void StartThread(
            Type typeObjetAppele, 
            object objetAppele, 
            string strMethode, 
            object defaultResult,
            params object[] parametres)
        {
            try
            {
                Type tp = typeObjetAppele;


                MethodInfo info = CUtilType.FindMethodFromParametres(typeObjetAppele, strMethode, parametres);
                if (info == null)
                {
                    m_result = defaultResult;
                    //m_result = new Exception(I.T("Impossible to find the method @1|20148", strMethode));
                    return;
                }
                try
                {
                    m_result = info.Invoke(objetAppele, parametres);
                }
                catch(Exception ex)
                {
                    m_result = defaultResult;
                    if (m_result is CResultAErreur)
                    {
                        ((CResultAErreur)m_result).EmpileErreur(new CErreurException(ex));
                    }                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("6 "+ex.ToString());
            }
            //Close();
        }

        #endregion

        private void m_image_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void m_timerAttendLaFin_Tick(object sender, EventArgs e)
        {
            if (m_asyncRes != null && m_asyncRes.IsCompleted)
            {
                m_timerAttendLaFin.Stop();
                Close();
            }
        }
    }
}