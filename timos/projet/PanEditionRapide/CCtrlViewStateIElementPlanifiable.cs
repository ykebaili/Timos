using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using sc2i.win32.common;
using sc2i.win32.data.navigation;
using sc2i.data.dynamic;

using timos.data;

namespace timos
{
	public partial class CCtrlViewStateIElementPlanifiable : UserControl
	{
		private IElementDeProjetPlanifiable m_element;
		//------------------------------------------------
		public CCtrlViewStateIElementPlanifiable()
		{
			InitializeComponent();
		}

		//------------------------------------------------
		public void Init(IElementDeProjetPlanifiable element)
		{
			m_element = element;
			m_pbox.BackgroundImage = CEtatPlanification.GetBitmapEtat((EEtatPlanification)m_element.EtatPlanification.CodeInt);
			m_lblEtat.Text = m_element.EtatPlanification.Libelle;
		}
	}
}
