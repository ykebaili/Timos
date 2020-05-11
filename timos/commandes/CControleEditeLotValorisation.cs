using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.common;
using timos.data.commandes;
using sc2i.win32.common;

namespace timos.commandes
{
    public partial class CControleEditeLotValorisation : UserControl, IControlALockEdition
    {
        private CLotValorisation m_lotValorisation = null;
        public CControleEditeLotValorisation()
        {
            InitializeComponent();
        }

        public CResultAErreur InitChamps(CLotValorisation lot)
        {
            CResultAErreur result = CResultAErreur.True;
            m_lotValorisation = lot;
            m_extLinkField.FillDialogFromObjet(lot);
            m_ctrlValorisations.Init ( m_lotValorisation );
            return result;
        }

        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (!m_gestionnaireModeEdition.ModeEdition || m_lotValorisation == null)
                return result;

            result = m_extLinkField.FillObjetFromDialog(m_lotValorisation);
            if (!result)
                return result;
            result = m_ctrlValorisations.MajChamps();
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
                    OnChangeLockEdition(this, null);
            }
        }

        public event EventHandler OnChangeLockEdition;

        #endregion
    }
}
