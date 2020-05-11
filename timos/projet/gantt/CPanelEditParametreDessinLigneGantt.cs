using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using sc2i.win32.common;
using sc2i.common;
using sc2i.data.dynamic;

using timos.data;
using timos.data.projet.gantt;
using sc2i.expression;

namespace timos.projet.gantt
{
    public partial class CPanelEditParametreDessinLigneGantt : UserControl, IControlALockEdition
    {

        CParametreDessinLigneGantt m_parametre = null;

        public CPanelEditParametreDessinLigneGantt()
        {
            InitializeComponent();
        }

        public CParametreDessinLigneGantt ParametreLigneGantt
        {
            get
            {
                return m_parametre;
            }
        }
 
        public void Init(CParametreDessinLigneGantt parametre)
        {
            m_parametre = parametre;

            if (parametre != null)
            {
                m_numUpDownHauteurLignes.Value = parametre.HauteurLigne;
            }
        }


        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;

            // Les deux formules de couleur

            if (m_parametre != null)
            {
                m_parametre.HauteurLigne = (int)m_numUpDownHauteurLignes.Value;
            }

            return result;
        }

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

   }
}
