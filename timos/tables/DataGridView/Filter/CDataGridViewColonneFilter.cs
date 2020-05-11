using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using sc2i.data;

namespace timos.tables
{

	public class CCDataGridViewColonneFilter : CDataGridViewColonneFilterComponent
	{
		public CCDataGridViewColonneFilter(DataGridViewColumn col)
			: base(col)
		{
		}

		public override EOperateurElementAComposantFiltre? FilsOperateur
		{
			get { return EOperateurElementAComposantFiltre.Ou ; }
		}

		public string FiltreRow
		{
			get
			{
				CFormatteurFiltreDataToStringDataTable formateur = new CFormatteurFiltreDataToStringDataTable();
				string filtre = formateur.GetString(new CFiltreData(GetComposantFiltre().GetString()));
				filtre = filtre.Replace("\"", "'");
				
				Regex exp = new Regex(@"(HasNo)\s*(\(\[.*\]\))");
				filtre = exp.Replace(filtre, "$2 is null");
				
				exp = new Regex(@"(Has)\s*(\(\[.*\]\))");
				filtre = exp.Replace(filtre, "$2 is not null");

				exp = new Regex(@"(\[.*\]\s*)(NotLike)(\s*'.*')");
				filtre = exp.Replace(filtre, "$1 not like $3");

				return filtre;
			}
		}

	}
}
