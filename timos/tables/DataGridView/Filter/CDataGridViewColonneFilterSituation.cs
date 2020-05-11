using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using sc2i.data;

namespace timos.tables
{

	public class CDataGridViewColonneFilterSituation : CDataGridViewColonneFilterComponent
	{
		public CDataGridViewColonneFilterSituation(DataGridViewColumn col)
			:base(col)
		{
		}

		public override EOperateurElementAComposantFiltre? FilsOperateur
		{
			get { return EOperateurElementAComposantFiltre.Et; }
		}
	}
}
