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

namespace timos.projet.gantt
{
    public partial class CPanelEditParametreDessinBarreGantt : UserControl, IControlALockEdition
    {

        CParametreDessinLigneGantt.CParametreDessinBarreGantt m_parametre = null;

        public CPanelEditParametreDessinBarreGantt()
        {
            InitializeComponent();
        }

        public CParametreDessinLigneGantt.CParametreDessinBarreGantt ParametreDessinBarreGantt
        {
            get
            {
                return m_parametre;
            }
        }
 
        public void Init(CParametreDessinLigneGantt.CParametreDessinBarreGantt parametre)
        {
            m_parametre = parametre;

            m_txtFormuleTexteZone.Init(new CFournisseurPropDynStd(), typeof(IElementDeGantt));
            m_selectCouleurTexte.Init(new CFournisseurPropDynStd(), typeof(IElementDeGantt));
            m_selectCouleurFond1.Init(new CFournisseurPropDynStd(), typeof(IElementDeGantt));
            m_selectCouleurFond2.Init(new CFournisseurPropDynStd(), typeof(IElementDeGantt));
            m_selectCouleurProgression.Init(new CFournisseurPropDynStd(), typeof(IElementDeGantt));
            m_selectCouleurTerminee.Init(new CFournisseurPropDynStd(), typeof(IElementDeGantt));

            m_panelIcones.Init(parametre);

            if (parametre != null)
            {
                m_txtFormuleTexteZone.Formule = parametre.FormuleTexte;
                m_selectCouleurTexte.FormuleCouleur = parametre.FormuleCouleurTexte;
                m_selectCouleurFond1.FormuleCouleur = parametre.FormuleCouleurFond1;
                m_selectCouleurFond2.FormuleCouleur = parametre.FormuleCouleurFond2;
                m_selectCouleurProgression.FormuleCouleur = parametre.FormuleCouleurProgress;
                m_selectCouleurTerminee.FormuleCouleur = parametre.FormuleCouleurTerminee;
            }
        }


        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;

            result = m_panelIcones.MajChamps();
            if (!result)
                return result;

            if (m_parametre != null)
            {
                m_parametre.FormuleTexte = m_txtFormuleTexteZone.Formule;
                m_parametre.FormuleCouleurTexte = m_selectCouleurTexte.FormuleCouleur;
                m_parametre.FormuleCouleurFond1 = m_selectCouleurFond1.FormuleCouleur;
                m_parametre.FormuleCouleurFond2 = m_selectCouleurFond2.FormuleCouleur;
                m_parametre.FormuleCouleurProgress = m_selectCouleurProgression.FormuleCouleur;
                m_parametre.FormuleCouleurTerminee = m_selectCouleurTerminee.FormuleCouleur;
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
