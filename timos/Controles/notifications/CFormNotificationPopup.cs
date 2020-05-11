using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using sc2i.win32.common.customizableList;
using sc2i.common;
using sc2i.multitiers.client;
using timos.Controles.notifications;

namespace timos
{
    public partial class CFormNotificationPopup : Form
    {
        internal class CMessageNotification
        {
            private string m_strMessage = "";
            private Image m_image = null;
            private IDonneeNotification m_donnee = null;
            private DateTime m_DateExpiration = DateTime.Now.AddSeconds(10);

            public CMessageNotification(
                string strMessage, 
                Image image,
                IDonneeNotification donneeNotification)
            {
                m_strMessage = strMessage;
                m_donnee = donneeNotification;
                m_image = image;
                m_DateExpiration = DateTime.Now.AddSeconds(CParametresNotification.DureeAffichage);
            }

            public string Message
            {
                get
                {
                    return m_strMessage;
                }
            }

            public Image Image
            {
                get
                {
                    return m_image;
                }
            }

            public IDonneeNotification DonneeNotification
            {
                get
                {
                    return m_donnee;
                }
            }

            public DateTime DateExpiration
            {
                get
                {
                    return m_DateExpiration;
                }
            }

        }


        private List<CMessageNotification> m_listeMessages = new List<CMessageNotification>();

        private static CFormNotificationPopup m_instance = null;


        //-----------------------------------------------------
        protected CFormNotificationPopup()
        {
            InitializeComponent();
            CControlNotification ctrlNotif = new CControlNotification();
            m_panelContenu.ItemControl = ctrlNotif;
            ctrlNotif.OnNotificationExecuted += new EventHandler(ctrlNotif_OnNotificationExecuted);
            
        }

        //-----------------------------------------------------
        void ctrlNotif_OnNotificationExecuted(object sender, EventArgs e)
        {
            lock (m_listeMessages)
            {
                CMessageNotification m = sender as CMessageNotification;
                if (m != null)
                {
                    m_listeMessages.Remove(m);
                    AfficheMessages();
                }
            }
        }


        //-----------------------------------------------------
        public static CFormNotificationPopup Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new CFormNotificationPopup();
                return m_instance;
            }
        }

        //-----------------------------------------------------
        private void m_picClose_Click(object sender, EventArgs e)
        {
            lock (m_listeMessages)
            {
                m_listeMessages.Clear();
                Hide();
            }
        }

        //-----------------------------------------------------
        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }
        //-----------------------------------------------------
        private void m_timer_Tick(object sender, EventArgs e)
        {
            lock (m_listeMessages)
            {
                foreach (CMessageNotification m in m_listeMessages.ToArray())
                {
                    if (m.DateExpiration < DateTime.Now)
                        m_listeMessages.Remove(m);
                }
                if (m_listeMessages.Count == 0)
                    Hide();
                else
                    AfficheMessages();
            }
        }

        //-----------------------------------------------------
        private void AfficheMessages()
        {
            if (!IsHandleCreated)
                CreateControl();
            int nHeight = m_panelTop.Height+m_lblBas.Height*2;
            List<CCustomizableListItem> lstItems = new List<CCustomizableListItem>();
            foreach ( CMessageNotification m in m_listeMessages )
            {
                CCustomizableListItem i = new CCustomizableListItem();
                i.Tag = m;
                lstItems.Add(i);
            }
            m_panelContenu.CurrentItemIndex = null;
            m_panelContenu.Items = lstItems.ToArray();
            m_panelContenu.Refill();
            for (int n = 0; n < m_panelContenu.Items.Count(); n++)
                nHeight += m_panelContenu.ItemControl.Height;

            nHeight = Math.Min ( nHeight, 200 );
            Point pt = CFormMain.GetInstance().GetPointBasDroitNotification();
            this.Location = new Point (
                pt.X - Width,
                pt.Y - nHeight );
            Size = new Size (Width, nHeight );
            ShowInactiveTopmost(this);
        }

        const int WS_EX_NOACTIVATE = 0x8000000;
        const int WS_EX_TOOLWINDOW = 0x80;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams param = base.CreateParams;
                param.ExStyle |= WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW;
                return param;
            }
        }

        //-----------------------------------------------------
        public void Init()
        {
            ShowInactiveTopmost(this);
            Hide();
        }



        //-----------------------------------------------------
        public void ShowMessage(string strMessage, Image img, IDonneeNotification donnee)
        {
            if (!IsHandleCreated)
                CreateHandle();
            Invoke(new MethodInvoker(delegate
            {
                PrivateShowMessage(strMessage, img, donnee);
            }));
        }

        //-----------------------------------------------------
        private void PrivateShowMessage ( string strMessage, Image img, IDonneeNotification donnee )
        {
            lock (m_listeMessages)
            {
                if (donnee != null)
                {
                    CMessageNotification m = new CMessageNotification(strMessage, img, donnee);
                    m_listeMessages.Add(m);
                    CParametresNotification.PlaySound();
                }
                AfficheMessages();
            }
        }

        //-----------------------------------------------------
        private const int SW_SHOWNOACTIVATE = 4;
        private const int HWND_TOPMOST = -1;
        private const uint SWP_NOACTIVATE = 0x0010;

        //-----------------------------------------------------
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        static extern bool SetWindowPos(
             int hWnd,           // window handle
             int hWndInsertAfter,    // placement-order handle
             int X,          // horizontal position
             int Y,          // vertical position
             int cx,         // width
             int cy,         // height
             uint uFlags);       // window positioning flags

        //-----------------------------------------------------
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        //-----------------------------------------------------
        static void ShowInactiveTopmost(Form frm)
        {
            ShowWindow(frm.Handle, SW_SHOWNOACTIVATE);
            SetWindowPos(frm.Handle.ToInt32(), HWND_TOPMOST,
            frm.Left, frm.Top, frm.Width, frm.Height,
            SWP_NOACTIVATE);
        }

        private void m_picFut_MouseUp(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Right)==MouseButtons.Right)
            {
                CFormParametresNotification.EditeParametres();
            }
        }

    }
}
