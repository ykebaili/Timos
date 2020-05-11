using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using sc2i.data;
using timos.securite;
using sc2i.win32.data;
using sc2i.common;

namespace timos.Securite.DroitsEdition
{
    public partial class CFormEditDroitsSurType : Form
    {
        private CDroitEditionType m_droitSurType = null;

        //--------------------------------------------------------------
        public CFormEditDroitsSurType()
        {
            InitializeComponent();
            CWin32Traducteur.Translate(this);
        }

        //--------------------------------------------------------------
        public static void EditeDroits ( Type type )
        {
            if ( type == null )
                return;
            CFormEditDroitsSurType form = new CFormEditDroitsSurType();
            using ( CContexteDonnee contexte = CSc2iWin32DataClient.ContexteCourant.GetContexteEdition() )
            {
                CDroitEditionType droit = new CDroitEditionType(contexte);
                if ( !droit.ReadIfExists ( new CFiltreData ( CDroitEditionType.c_champTypeElements+"=@1",
                    type.ToString() )))
                {
                    droit.CreateNewInCurrentContexte();
                    droit.TypeElements = type;
                }
                form.m_droitSurType = droit;
                if ( form.ShowDialog() == DialogResult.OK )
                {
                    CResultAErreur result = contexte.CommitEdit();
                    if ( !result )
                        CFormAlerte.Afficher ( result.Erreur );
                }
                else
                    contexte.CancelEdit();
            }
            form.Dispose();
            return;
        }

        //--------------------------------------------------------------
        private void CFormEditDroitsSurType_Load(object sender, EventArgs e)
        {
            m_wndListeCouples.Init(m_droitSurType);
        }

        //--------------------------------------------------------------
        private void m_btnAnnuler_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        //--------------------------------------------------------------
        private void m_btnOk_Click(object sender, EventArgs e)
        {
            CResultAErreurType<CParametreDroitEditionType> result = m_wndListeCouples.GetParametre();
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }
            m_droitSurType.ParametreDroits = result.DataType;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
