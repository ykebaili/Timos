using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using sc2i.common;
using sc2i.win32.common;
using timos.data.projet.gantt;
using timos.data;

namespace timos.win32.composants.gantt
{

    public partial class CFormConfirmationAvantDeplacementElementDeGantt : Form
    {

        private bool m_bAdesFilsTermines = false;
        private bool m_bAdesFilsNonAuto = false;

        private bool m_bContinuerAvecFilsTermines;
        private bool m_bDeplacerLesFilsNonAuto;

        private bool m_bNePlusPoserLaQuestionDesFilsTermines = false;
        private bool m_bNePlusPoserLaQuestionDesFilsNonAuto = false;

        public CFormConfirmationAvantDeplacementElementDeGantt()
        {
            InitializeComponent();

        }

        //---------------------------------------------------------------
        public bool DeplacerLesFilsNonAuto
        {
            get
            {
                return m_bDeplacerLesFilsNonAuto;
            }
        }


        private IElementDeGantt m_element;
        //---------------------------------------------------------------
        public bool DemanderConfirmation(IElementDeGantt element)
        {
            if (element == null)
                return false;

            m_element = element;


            // Le projet a-t-il des fils terminés ?
            bool bADesFilsTermines = (from e in element.ElementsFils
                                 where e.EstTermine
                                 select e).Count() > 0;
            // Le projet a-t-il des fils dont les dates sotn en Non-auto ?
            bool bADesFilsNonAuto = (from e in element.ElementsFils
                                where !e.DatesAuto
                                select e).Count() > 0;
            if (element is CElementDeGanttProjet)
            {
                if (element.ProjetAssocie != null && (!element.ProjetAssocie.DateDebutAuto && element.ProjetAssocie.HasChilds()))
                    return true;
                bADesFilsTermines |= (from p in element.ProjetAssocie.ProjetsFils.ToList<CProjet>()
                                      where p.DateFinRelle != null
                                      select p).Count() > 0;
                bADesFilsNonAuto |= (from p in element.ProjetAssocie.ProjetsFils.ToList<CProjet>()
                                     where !p.DatesAuto
                                     select p).Count() > 0;
            }



            if (!bADesFilsTermines && !bADesFilsNonAuto)
                return true;

            bool bAfficher = false;
            // Si pas de fils terminés et pas de fils non auto
            if (bADesFilsTermines && !m_bNePlusPoserLaQuestionDesFilsTermines)
                bAfficher = true;
            if (bADesFilsNonAuto && !m_bNePlusPoserLaQuestionDesFilsNonAuto)
                bAfficher = true;

            
            m_bAdesFilsTermines = bADesFilsTermines;
            m_bAdesFilsNonAuto = bADesFilsNonAuto;

            m_panelMessageFilsTermines.Visible = bADesFilsTermines;
            m_panelMessageFilsNonAuto.Visible = bADesFilsNonAuto;

            if (bAfficher)
            {
                if(this.ShowDialog() == DialogResult.Yes)
                    return true;
            }
            else
            {
                if (bADesFilsTermines)
                    return m_bContinuerAvecFilsTermines;
                else
                    return true;
            }

            return false;
        }


        //-----------------------------------------------------------------------------
        private void m_btnValider_Click(object sender, EventArgs e)
        {
            if (m_bAdesFilsTermines)
            {
                m_bContinuerAvecFilsTermines = true;
                m_bNePlusPoserLaQuestionDesFilsTermines = m_chkMemoriserLaReponse.Checked;
            }
            if (m_bAdesFilsNonAuto)
            {
                m_bDeplacerLesFilsNonAuto = m_chkDeplacerFilsNonAuto.Checked;
                m_bNePlusPoserLaQuestionDesFilsNonAuto = m_chkMemoriserLaReponse.Checked;
            }

            DialogResult = DialogResult.Yes;
            Close();
        }

        private void m_btnAnnuler_Click(object sender, EventArgs e)
        {
            if (m_bAdesFilsTermines)
            {
                m_bContinuerAvecFilsTermines = false;
                m_bNePlusPoserLaQuestionDesFilsTermines = m_chkMemoriserLaReponse.Checked;
            }
            DialogResult = DialogResult.No;
            Close();

        }


        private void CFormConfirmationAvantDeplacementElementDeGantt_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);

            m_lblMessageFilsTermines.Text =
                I.T("The Element you are trying to move has one or more child elements that are Ended. Child elements will not be automaticaly moved.|10006") + Environment.NewLine +
                I.T("Are you sure you want to continue to move Element :|10007") + Environment.NewLine +
                m_element.Libelle + " ?";

            m_lblMessageFilsNonAuto.Text =
                I.T("The Element you are trying to move has one or more child elements with Non-Automatic dates|10008") + Environment.NewLine +
                I.T("What do you want to do ?|10009");
            
        }


    }
}
