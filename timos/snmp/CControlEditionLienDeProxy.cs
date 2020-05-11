using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using sc2i.win32.data;
using sc2i.data;
using sc2i.common;
using sc2i.win32.common;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.workflow;

using timos.data;
using timos.data.snmp;
using futurocom.easyquery;
using futurocom.snmp.dynamic;
using futurocom.snmp;
using futurocom.easyquery.snmp;
using futurocom.win32.snmp;
using futurocom.snmp.alarme;
using timos.data.supervision;
using futurocom.win32.snmp.alarmes;
using futurocom.snmp.Mib;
using futurocom.supervision;
using timos.data.snmp.Proxy;
using futurocom.snmp.Proxy;
using System.Collections;

namespace timos.snmp
{
    public partial class CControlEditionLienDeProxy : UserControl, IControlALockEdition
    {
        private CLienDeProxy m_lienProxy = null;

        public CControlEditionLienDeProxy()
        {
            InitializeComponent();
        }

        public void Init(CLienDeProxy lienProxy)
        {
            if (lienProxy != null)
            {
                m_lienProxy = lienProxy;
                // Supprime tous les controles du panel
                ArrayList lstToRemove = new ArrayList(m_panelPlagesIP.Controls);
                foreach (Control ctrl in lstToRemove)
                {
                    if (ctrl is CControlEditionPlageIP)
                    {
                        ctrl.Visible = false;
                        ctrl.Parent = null;
                        m_panelPlagesIP.Controls.Remove(ctrl);
                        ctrl.Dispose();
                    }
                }

                // Charge toutes les Plages IP
                foreach (CPlageIP plage in m_lienProxy.PlagesIP.ToArray())
                {
                    AjouterControlPlageIp(plage);
                }
            }

            return;
        }

        private void AjouterControlPlageIp(CPlageIP plage)
        {
            CControlEditionPlageIP newControl = new CControlEditionPlageIP();
            if (newControl != null)
            {
                ((Control)newControl).Dock = DockStyle.Top;
                newControl.DeletePlageEventHandler += new EventHandler(newControl_DeletePlageEventHandler);
                newControl.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
                newControl.Init(plage);
                CWin32Traducteur.Translate(newControl);
                m_panelPlagesIP.Controls.Add((Control)newControl);
                ((Control)newControl).BringToFront();
            }
        }

        void newControl_DeletePlageEventHandler(object sender, EventArgs e)
        {
            CControlEditionPlageIP controlASupprimer = sender as CControlEditionPlageIP;
            if (controlASupprimer != null)
            {
                controlASupprimer.Visible = false;
                Control parent = controlASupprimer.Parent;
                controlASupprimer.Parent = null;
                parent.Controls.Remove(controlASupprimer);
                controlASupprimer.Dispose();
            }
        }

        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            m_lienProxy.ClearPlages();
            foreach (Control ctrl in m_panelPlagesIP.Controls)
            {
                CControlEditionPlageIP control = ctrl as CControlEditionPlageIP;
                if (control != null)
                {
                    control.MajChamps();
                    m_lienProxy.AddPlage(control.PlageIP);
                }
            }
            return result;
        }


        #region IControlALockEdition Membres

        public bool LockEdition
        {
            get
            {
                return !m_gestionnaireModeEdition.ModeEdition;
            }
            set
            {
                m_gestionnaireModeEdition.ModeEdition = !value;

                if (OnChangeLockEdition != null)
                    OnChangeLockEdition(this, new EventArgs());
            }
        }

        public event EventHandler OnChangeLockEdition;

        #endregion

        private void m_lnkAjouter_LinkClicked(object sender, EventArgs e)
        {
            CPlageIP plageIP = new CPlageIP("255.255.255.255", 8);
            AjouterControlPlageIp(plageIP);
        }
    }
}
