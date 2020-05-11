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
    public partial class CControlSelectIconeGanttCustom : UserControl,
                                                        IControlALockEdition,
                                                        IEditeurParametreIconeGantt
    {
        IParametreIconeGantt m_parametre;

        public CControlSelectIconeGanttCustom()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------
        public static void AutoExec()
        {
            CAllocateurEditeurParametreIconeGantt.RegisterEditeur(typeof(CParametreIconeGanttCustom), typeof(CControlSelectIconeGanttCustom));
        }

        //-------------------------------------------------------------------------
        public void Init(IParametreIconeGantt parametre)
        {
            m_parametre = parametre;

            m_txtFormuleToolTip.Init(new CFournisseurPropDynStd(), typeof(IElementDeGantt));
            m_txtFormuleVisibilite.Init(new CFournisseurPropDynStd(), typeof(IElementDeGantt));
            if (parametre != null)
            {
                m_selectIcone.Image = parametre.Image;
                CParametreIconeGanttCustom paramCustom = parametre as CParametreIconeGanttCustom;
                if (paramCustom != null)
                {
                    m_txtFormuleVisibilite.Formule = paramCustom.Condition;
                    m_txtFormuleToolTip.Formule = paramCustom.Tooltip;
                }
            }
        }

        //-------------------------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;

            if (m_parametre != null)
            {
                CParametreIconeGanttCustom paramCustom = m_parametre as CParametreIconeGanttCustom;
                if (paramCustom != null)
                {
                    paramCustom.Image = m_selectIcone.Image;
                    paramCustom.Condition = m_txtFormuleVisibilite.Formule;
                    paramCustom.Tooltip = m_txtFormuleToolTip.Formule;
                }
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
