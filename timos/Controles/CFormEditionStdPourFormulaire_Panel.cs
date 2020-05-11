using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using sc2i.win32.data.dynamic;
using sc2i.data.dynamic;
using sc2i.common;

namespace timos.Controles
{
    public class CFormEditionStdPourFormulaire_Panel : Panel, IControleAGestionRestrictions
    {
        CCreateur2iFormulaireObjetDonnee m_createur = null;
        //---------------------------------------------------------------
        public CFormEditionStdPourFormulaire_Panel()
            : base()
        {
            InitializeComponent();
        }


        //---------------------------------------------------------------
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }

        //---------------------------------------------------------------
        public CCreateur2iFormulaireObjetDonnee Createur
        {
            get
            {
                return m_createur;
            }
            set
            {
                m_createur = value;
            }
        }

        //---------------------------------------------------------------
        private CFormulaire m_formulaire;
        public CFormulaire Formulaire
        {
            get
            {
                return m_formulaire;
            }
            set
            {
                m_formulaire = value;
            }
        }

        //---------------------------------------------------------------
        public void AppliqueRestrictions(CListeRestrictionsUtilisateurSurType restrictions, sc2i.common.Restrictions.IGestionnaireReadOnlySysteme gestionnaireReadOnly)
        {
            if (m_createur != null && restrictions != null && gestionnaireReadOnly != null)
            {
                if (m_formulaire != null && m_formulaire.TypeElementEdite != null)
                {
                    restrictions = restrictions.Clone() as CListeRestrictionsUtilisateurSurType;
                    CRestrictionUtilisateurSurType restriction = restrictions.GetRestriction(m_formulaire.TypeElementEdite);
                    ERestriction rest = restriction.GetRestriction(Formulaire.CleRestriction);
                    if ((int)rest > (int)restriction.RestrictionGlobale)
                        restriction.RestrictionUtilisateur = rest;
                    restrictions.SetRestriction(restriction);
                }
                m_createur.AppliqueRestrictions(restrictions, gestionnaireReadOnly);
            }
        }
        
    }
}
