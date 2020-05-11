using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using timos.data.snmp;
using sc2i.common;
using sc2i.win32.common;

namespace timos.snmp
{
    public class CTabPageEntiteSnmp : Crownwood.Magic.Controls.TabPage, IControlALockEdition
    {
        private bool m_bLockEdition = false;
        private IConteneurEntitesSnmp m_conteneur = null;
        private CTypeEntiteSnmp m_typeEntites = null;
        private CPanelEditeEntitesSnmp m_panelEdition = null;


        public void InitChamps(IConteneurEntitesSnmp conteneur, CTypeEntiteSnmp typeEntite)
        {
            m_conteneur = conteneur;
            m_typeEntites = typeEntite;
            Title = typeEntite.Libelle;
            if (m_panelEdition == null)
            {
                m_panelEdition = new CPanelEditeEntitesSnmp();
                m_panelEdition.LockEdition = m_bLockEdition;
                Control = m_panelEdition;
            }
            m_panelEdition.InitChamps(m_conteneur, typeEntite);
        }

        public CResultAErreur MajChamps()
        {
            if (m_panelEdition != null)
                return m_panelEdition.MajChamps();
            return CResultAErreur.True;
        }

        #region IControlALockEdition Membres

        public bool LockEdition
        {
            get
            {
                return m_bLockEdition;
            }
            set
            {
                m_bLockEdition = value;
                if (m_panelEdition != null)
                    m_panelEdition.LockEdition = m_bLockEdition;
                if (OnChangeLockEdition != null)
                    OnChangeLockEdition(this, new EventArgs());
            }
        }

        public event EventHandler OnChangeLockEdition;

        #endregion
    }
}
