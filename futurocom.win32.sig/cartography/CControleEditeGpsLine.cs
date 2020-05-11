using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sc2i.common.sig;
using sc2i.common;
using futurocom.sig.cartography;
using sc2i.common.unites;
using sc2i.common.unites.standard;

namespace futurocom.win32.sig.cartography
{
    [AutoExec("Autoexec")]
    public partial class CControleEditeGpsLine : UserControl, IEditeurItemCarte
    {
        CGPSLine m_ligneEditee = null;
        //---------------------------------------------------------
        public CControleEditeGpsLine()
        {
            InitializeComponent();
        }

        //---------------------------------------------------------
        public static void Autoexec()
        {
            CGestionnaireEditionItemCarte.RegisterEditeur(typeof(CGPSLine), typeof(CControleEditeGpsLine));
        }

        //---------------------------------------------------------
        private bool m_bIsInInit = false;
        public void Init(object item)
        {
            m_bIsInInit = true;
            m_ligneEditee = item as CGPSLine;
            m_txtTypeLigne.Init(typeof(CGPSTypeLigne), "Libelle", false);
            if (m_ligneEditee == null)
                Visible = false;
            else
            {
                RefreshData();
                
            }
            m_bIsInInit = false;
        }

        //---------------------------------------------------------
        public void RefreshData()
        {
            if ( m_ligneEditee != null )
            {
                m_txtLibelle.Text = m_ligneEditee.Libelle;
                m_txtTypeLigne.ElementSelectionne = m_ligneEditee.TypeLigne;
            }
        }

        //---------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_gestionnaireModeEdition.ModeEdition && m_ligneEditee != null)
            {
                try
                {
                    m_ligneEditee.Libelle = m_txtLibelle.Text;
                    m_ligneEditee.TypeLigne = m_txtTypeLigne.ElementSelectionne as CGPSTypeLigne;
                }
                catch ( Exception e )
                {
                    result.EmpileErreur(new CErreurException(e));
                }
            }
            return result;
        }

        


        //---------------------------------------------------------
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

        //---------------------------------------------------------
        public event EventHandler OnModification;

        //---------------------------------------------------------
        private void DoOnModification()
        {
            MajChamps();
            if (OnModification != null)
                OnModification(this, new EventArgs());
        }

        //---------------------------------------------------------
        private bool ShouldTraiteModification
        {
            get
            {
                return !m_bIsInInit &&
                    m_gestionnaireModeEdition.ModeEdition &&
                    m_ligneEditee != null;
            }
        }

        //---------------------------------------------------------
        private void m_txtLibelle_Validated(object sender, EventArgs e)
        {
            if (ShouldTraiteModification && 
                m_txtLibelle.Text != m_ligneEditee.Libelle)
                DoOnModification();
        }

        //---------------------------------------------------------
        private void m_txtTypeLigne_ElementSelectionneChanged(object sender, EventArgs e)
        {
            if (ShouldTraiteModification &&
                m_txtTypeLigne.ElementSelectionne != m_ligneEditee.TypeLigne)
                DoOnModification();
        }
    }
}
