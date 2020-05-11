using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using sc2i.common;
using sc2i.expression;
using sc2i.data.dynamic;
using sc2i.win32.common;

using timos.data;
using timos.data.projet.gantt;
using timos.data.projet.gantt.icones;


namespace timos.projet.gantt
{
    [AutoExec("AutoExec")]
    public partial class CControlSelectIconeGanttStandard : UserControl,
                                                        IControlALockEdition,
                                                        IEditeurParametreIconeGantt
    {
        IParametreIconeGantt m_parametre;

        public CControlSelectIconeGanttStandard()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------
        public static void AutoExec()
        {
            CAllocateurEditeurParametreIconeGantt.RegisterEditeur(typeof(CParametreIconeGanttRetard), typeof(CControlSelectIconeGanttStandard));
            CAllocateurEditeurParametreIconeGantt.RegisterEditeur(typeof(CParametreIconeGanttWarning), typeof(CControlSelectIconeGanttStandard));
            CAllocateurEditeurParametreIconeGantt.RegisterEditeur(typeof(CParametreIconeGanttTermine), typeof(CControlSelectIconeGanttStandard));
            CAllocateurEditeurParametreIconeGantt.RegisterEditeur(typeof(CParametreIconeGanttAuto), typeof(CControlSelectIconeGanttStandard));
        }

        //-------------------------------------------------------------------------
        public void Init(IParametreIconeGantt parametre)
        {
            m_parametre = parametre;

            m_txtFormuleToolTip.Init(new CFournisseurPropDynStd(), typeof(IElementDeGantt));

            if (parametre != null)
            {
                m_selectIcone.Image = parametre.Image;
                m_txtFormuleToolTip.Formule = parametre.Tooltip;
            }
        }

        //-------------------------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;

            CParametreIconeGanttRetard paramRetard = m_parametre as CParametreIconeGanttRetard;
            if (paramRetard != null)
            {
                paramRetard.Tooltip = m_txtFormuleToolTip.Formule;
            }
            CParametreIconeGanttWarning paramWarning = m_parametre as CParametreIconeGanttWarning;
            if (paramWarning != null)
            {
                paramWarning.Tooltip = m_txtFormuleToolTip.Formule;
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
                    OnChangeLockEdition(this, new EventArgs());
            }
        }

        public event EventHandler OnChangeLockEdition;

        #endregion


        //--------------------------------------------------------------------------

        private void m_lnkDelete_LinkClicked(object sender, EventArgs e)
        {
            if (DeleteIconeEventHendler != null)
                DeleteIconeEventHendler(this, new EventArgs());
        }

        #region IEditeurParametreIconeGantt Membres

        public IParametreIconeGantt ParametreIconeGantt
        {
            get
            {
                return m_parametre;
            }
            set
            {
                m_parametre = value;
            }
        }

        public event EventHandler DeleteIconeEventHendler;

        #endregion


    }
}
