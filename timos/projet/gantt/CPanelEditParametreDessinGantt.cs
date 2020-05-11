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
using sc2i.expression;

using timos.data;
using timos.data.projet.gantt;

namespace timos.projet.gantt
{
    public partial class CPanelEditParametreDessinGantt : UserControl, IControlALockEdition
    {

        CParametreDessinLigneGantt.CParametreDessinGantt m_parametre = null;

        public CPanelEditParametreDessinGantt()
        {
            InitializeComponent();
        }

        public CParametreDessinLigneGantt.CParametreDessinGantt ParametreDessinGantt
        {
            get
            {
                return m_parametre;
            }
        }
 
        public void Init(CParametreDessinLigneGantt.CParametreDessinGantt parametre)
        {
            m_parametre = parametre;

            m_txtFormuleTexteZone.Init(new CFournisseurPropDynStd(), typeof(IElementDeGantt));
            m_selectColeurTexte.Init(new CFournisseurPropDynStd(), typeof(IElementDeGantt));
            m_panelIcones.Init(parametre);
            if (parametre != null)
            {
                m_txtFormuleTexteZone.Formule = parametre.FormuleTexte;
                m_selectColeurTexte.FormuleCouleur = parametre.FormuleCouleurTexte;
            }
        }


        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;

            result =  m_panelIcones.MajChamps();
            if (!result)
                return result;

            if (m_parametre != null)
            {
                m_parametre.FormuleTexte = m_txtFormuleTexteZone.Formule;
                m_parametre.FormuleCouleurTexte = m_selectColeurTexte.FormuleCouleur;
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
