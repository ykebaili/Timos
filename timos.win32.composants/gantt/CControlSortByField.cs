using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using timos.data.projet.gantt;
using sc2i.data.dynamic;
using sc2i.common;

namespace timos.win32.composants.gantt
{
    public partial class CControlSortByField : UserControl
    {
        public CControlSortByField()
        {
            InitializeComponent();
        }

        public void Init(CParametreTriGantt parametre, bool bIsFirst)
        {
            m_selectChamp.Init(new CFournisseurPropDynStd(false), typeof(IElementDeGantt), null);
            m_rbtnCroissant.Checked = true;
            if (parametre != null)
            {
                m_selectChamp.DefinitionSelectionnee = parametre.Propriete;
                m_rbtnCroissant.Checked = !parametre.Decroissant;
                m_rbtnDecroissant.Checked = parametre.Decroissant;
            }
            else
                m_selectChamp.DefinitionSelectionnee = null;
            m_lblSortBy.Text = bIsFirst ? I.T("Sort by|20011") : I.T("Then|20012");
        }

        public CParametreTriGantt GetParametre()
        {
            if (m_selectChamp.DefinitionSelectionnee != null)
            {
                CParametreTriGantt parametre = new CParametreTriGantt();
                parametre.Propriete = m_selectChamp.DefinitionSelectionnee;
                parametre.Decroissant = m_rbtnDecroissant.Checked;
                return parametre;
            }
            return null;
        }
    }
}
