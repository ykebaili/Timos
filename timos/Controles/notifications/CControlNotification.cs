using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common.customizableList;
using sc2i.common;
using sc2i.process.workflow;
using sc2i.multitiers.client;
using timos.Controles.notifications;

namespace timos
{
    public partial class CControlNotification : CCustomizableListControl
    {
        public CControlNotification()
        {
            InitializeComponent();
        }

        public override bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        protected override CResultAErreur MyInitChamps(CCustomizableListItem item)
        {
            CResultAErreur result = CResultAErreur.True;
            if (item != null)
            {
                CFormNotificationPopup.CMessageNotification m = item.Tag as CFormNotificationPopup.CMessageNotification;
                if (m != null)
                {
                    if (m.Image != null)
                    {
                        m_panelImage.Visible = true;
                        m_imageNotif.Image = m.Image;
                    }
                    else
                        m_panelImage.Visible = false;
                    m_link.Text = m.Message;
                    Graphics g = m_link.CreateGraphics();
                    SizeF s = g.MeasureString(m.Message, m_link.Font, m_link.Width);
                    Height = Math.Max((int)s.Height+m_panelSep.Height, 25);
                }
            }
            return result;
        }

        //------------------------------------------------------
        public event EventHandler OnNotificationExecuted;

        //------------------------------------------------------
        private void m_link_Click(object sender, EventArgs e)
        {
            CFormNotificationPopup.CMessageNotification m = CurrentItem != null ?
                CurrentItem.Tag as CFormNotificationPopup.CMessageNotification :
                null;
            if (m != null)
            {
                IDonneeNotification donnee = m.DonneeNotification;
                CGestionnaireNotificationsPopup.ExecuteNotification(donnee);
                if (OnNotificationExecuted != null)
                    OnNotificationExecuted(m, null);
            }

        }
    }
}
