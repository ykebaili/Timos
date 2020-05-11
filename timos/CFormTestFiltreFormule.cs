using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using sc2i.data.dynamic;
using timos.acteurs;
using sc2i.common;
using sc2i.data;
using sc2i.win32.data;
using sc2i.expression;

namespace timos
{
    public partial class CFormTestFiltreFormule : Form
    {
        CFiltreDynamique m_filtre = null;
        public CFormTestFiltreFormule()
        {
            InitializeComponent();
            m_filtre = new CFiltreDynamique();
            m_filtre.TypeElements = typeof(CActeur);
        }

        private void CFormTestFiltreFormule_Load(object sender, EventArgs e)
        {
            m_panelFiltre.Init(m_filtre);
            m_panelFiltre.ModeFiltreExpression = true;
            m_panelFiltre.ModeSansType = true;
        }

        private void m_btnTester_Click(object sender, EventArgs e)
        {
            CFiltreDynamique filtre = m_panelFiltre.FiltreDynamique;
            CResultAErreur result = filtre.GetFormuleEquivalente();
            if (result)
            {
                C2iExpression formule = result.Data as C2iExpression;
                CListeObjetDonneeGenerique<CActeur> lst = new CListeObjetDonneeGenerique<CActeur>(CSc2iWin32DataClient.ContexteCourant);
                StringBuilder bl = new StringBuilder();
                int nNbOk = 0;
                foreach (CActeur acteur in lst)
                {
                    CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(acteur);
                    if (formule == null)
                        result.Data = true;
                    else
                        result = formule.Eval(ctx);
                    if (result)
                    {
                        if ( result.Data is bool && (bool)result.Data == true)
                        {
                            bl.Append(acteur.IdentiteComplete);
                            nNbOk++;
                            bl.Append("\r\n");
                        }
                    }
                }
                MessageBox.Show(nNbOk + " elements\r\n" + bl.ToString());
            }
            else
                CFormAfficheErreur.Show ( result.Erreur );
        }
    }
}