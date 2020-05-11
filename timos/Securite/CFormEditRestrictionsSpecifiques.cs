using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using timos.data.securite;
using sc2i.win32.common;
using sc2i.data;
using sc2i.common;

namespace timos.Securite
{
    public partial class CFormEditRestrictionsSpecifiques : Form
    {
        private IElementARestrictionsSpecifiques m_elementARestrictions = null;
        public CFormEditRestrictionsSpecifiques()
        {
            InitializeComponent();
        }

        //------------------------------------------------------
        public static void EditeRestricitionsSpecifiques(
            IElementARestrictionsSpecifiques element,
            bool bModeEdition)
        {
            CFormEditRestrictionsSpecifiques form = new CFormEditRestrictionsSpecifiques();
            CObjetDonneeAIdNumerique objet = element as CObjetDonneeAIdNumerique;
            objet.BeginEdit();
            form.m_elementARestrictions = objet as IElementARestrictionsSpecifiques;
            form.m_extModeEdition.ModeEdition = bModeEdition;
            if (form.ShowDialog() == DialogResult.OK && bModeEdition)
            {
                CResultAErreur result = objet.CommitEdit();
                if (!result)
                {
                    CFormAlerte.Afficher(result.Erreur);
                }
            }
            else
                objet.CancelEdit();
            form.Dispose();
        }

        //------------------------------------------------------
        private void CFormEditRestrictionsSpecifiques_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
            m_panelRestrictions.Init(m_elementARestrictions);
        }

        //------------------------------------------------------
        private void m_btnOk_Click(object sender, EventArgs e)
        {
            CResultAErreur result = m_panelRestrictions.MajChamps();
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        //------------------------------------------------------
        private void m_btnAnnuler_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        //------------------------------------------------------


    }
}
