using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.data.dynamic.Macro;
using sc2i.data;
using sc2i.win32.data;
using sc2i.common;
using sc2i.expression;
using sc2i.win32.common;

namespace timos.macro
{
    [AutoExec("Autoexec")]
    public partial class CEditeurMacroObjet : UserControl, IEditeurElementDeMacro, IControlALockEdition
    {
        private CMacroObjet m_macroObjet = null;
        public CEditeurMacroObjet()
        {
            InitializeComponent();
        }

        public static void Autoexec()
        {
            CControleEditeMacro.RegisterEditeur(typeof(CMacroObjet), typeof(CEditeurMacroObjet));
        }

        public void InitChamps(object obj)
        {
            m_macroObjet=  obj as CMacroObjet;
            if (m_macroObjet != null)
            {
                m_macroObjet.Macro.VariableCurrentElement.SetTypeDonnee(new CTypeResultatExpression(typeof(string), false));
                m_txtDesignation.Text = m_macroObjet.DesignationObjet;
                m_txtFormule.Formule = m_macroObjet.FormuleSelectionObjet;
                m_txtFormuleCondition.Formule = m_macroObjet.FormuleCondition;
                m_txtFormule.Init(m_macroObjet.Macro, new CObjetPourSousProprietes(m_macroObjet.Macro));
                m_txtFormuleCondition.Init ( m_macroObjet.Macro, new CObjetPourSousProprietes(m_macroObjet.Macro ));
            }
        }

        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if ( m_macroObjet != null )
            {
                m_macroObjet.FormuleSelectionObjet = m_txtFormule.Formule;
                m_macroObjet.FormuleCondition = m_txtFormuleCondition.Formule;
                m_macroObjet.DesignationObjet = m_txtDesignation.Text;
            }
            return result;

        }




        #region IControlALockEdition Membres

        public bool LockEdition
        {
            get
            {
                return !m_extModeEdition.ModeEdition;
            }
            set
            {
                m_extModeEdition.ModeEdition = !value;
                if (OnChangeLockEdition != null)
                    OnChangeLockEdition(this, null);
            }
        }

        public event EventHandler OnChangeLockEdition;

        #endregion
    }
}
