using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using sc2i.common;
using sc2i.formulaire;
using sc2i.custom;
using sc2i.data;

namespace timos.Controles.ActionsSurLink
{
    public partial class CFormExecuteActionFormulairePopup : CFloatingFormBase
    {
        CActionSur2iLinkFormulairePopup m_actionExecutee;

        public CFormExecuteActionFormulairePopup()
        {
            InitializeComponent();
        }

        public static void Popup(Point p, CActionSur2iLinkFormulairePopup action, IObjetDonnee objetEdite, bool bModeEdition)
        {
            if (action == null)
                return;
            
            CFormExecuteActionFormulairePopup form = new CFormExecuteActionFormulairePopup();
            form.m_actionExecutee = action;

            Size sz = action.Formulaire.Size;
            Screen scr = Screen.FromPoint(p);
            Point ptStart = p;
            if (ptStart.X + sz.Width > scr.WorkingArea.Right)
                ptStart.Offset(-sz.Width, 0);
            if (ptStart.Y + sz.Height > scr.WorkingArea.Bottom)
                ptStart.Offset(0, -sz.Height);
            form.Location = ptStart;
            form.Size = sz;

            form.m_gestionnaireModeEdition.ModeEdition = bModeEdition;
            form.m_panelFormulaire.InitPanel(action.Formulaire, objetEdite);

            form.Show();
        }


        //-------------------------------------------------------------------------------
        private void m_btnAnnuler_Click(object sender, EventArgs e)
        {
            Hide();
        }

        //------------------------------------------------------------------------------
        protected override void OnPopupHiding(CancelEventArgs e)
        {
            base.OnPopupHiding(e);

            CResultAErreur result = m_panelFormulaire.AffecteValeursToElement();
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                e.Cancel = true;
            }
        }


    }
}
