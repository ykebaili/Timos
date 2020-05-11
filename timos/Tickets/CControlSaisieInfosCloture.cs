using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.multitiers.client;
using sc2i.win32.data;
using sc2i.data;
using sc2i.common;
using sc2i.win32.common;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.workflow;
using timos.acteurs;

using timos.data;
using timos.securite;

namespace timos
{
    public partial class CControlSaisieInfosCloture : UserControl, IControlALockEdition
    {
        private CTicket m_ticketEdite;
        
        public CControlSaisieInfosCloture()
        {
            InitializeComponent();
        }

        //---------------------------------------------------------------------------------
        public CResultAErreur Init(CTicket ticket)
        {
            if (ticket == null)
                return CResultAErreur.False;

            CResultAErreur result = CResultAErreur.True;
            m_ticketEdite = ticket;

            result = m_extLinkField.FillDialogFromObjet(m_ticketEdite);
            result = InitComboEtatCloture(true);
            m_cmbxSelectEtatCloture.ElementSelectionne = m_ticketEdite.EtatCloture;
            
            if (m_ticketEdite.DateClotureTechnique != null)
                m_dateClotureTech.Value = (DateTime) m_ticketEdite.DateClotureTechnique;
            else
                m_dateClotureTech.Value = null;

            InitSelectResoluPar();
            m_txtSelectResoluPar.ElementSelectionne = m_ticketEdite.ResponsableClotureTechnique;
            
            return result;
        }

        //---------------------------------------------------------------------------------
        private void InitSelectResoluPar()
        {
            m_txtSelectResoluPar.Init<CActeur>(
                "IdentiteComplete",
                true);
        }


        //---------------------------------------------------------------------------------
        private CResultAErreur InitComboEtatCloture(bool bForceInit)
        {
            CResultAErreur result = CResultAErreur.True;

            CListeObjetsDonnees liste = new CListeObjetsDonnees(m_ticketEdite.ContexteDonnee, typeof(CEtatCloture));
            
            result = m_cmbxSelectEtatCloture.Init(liste, "Libelle", bForceInit);

            return result;
        }

        //---------------------------------------------------------------------------------
        public CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_ticketEdite != null)
            {
                result = m_extLinkField.FillObjetFromDialog(m_ticketEdite);
                m_ticketEdite.EtatCloture = (CEtatCloture)m_cmbxSelectEtatCloture.ElementSelectionne;
                m_ticketEdite.DateClotureTechnique = m_dateClotureTech.Value;
                m_ticketEdite.ResponsableClotureTechnique = (CActeur)m_txtSelectResoluPar.ElementSelectionne;
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

        private void CControlSaisieInfosCloture_Load(object sender, EventArgs e)
        {
            sc2i.win32.common.CWin32Traducteur.Translate(this);
        }
    }
}
