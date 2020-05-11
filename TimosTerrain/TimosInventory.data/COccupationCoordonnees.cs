using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;

namespace TimosInventory.data
{

	/// <summary>
	/// Permet de faire la relation entre une occupation et une unité.<br/>
    /// Ce concept est exploité pour gérer l'occupation d'un élément<br/>
    /// dans un élément englobant (exemple : l'occupation d'un module<br/>
    /// à l'intérieur d'un châssis).
	/// </summary>
	public class COccupationCoordonnees
	{
		private int m_nNbUnitesOccupees = 1;
		private CUniteCoordonnee m_uniteCoordonnees;

		public COccupationCoordonnees()
		{
		}

		public COccupationCoordonnees(int nNbUnites, CUniteCoordonnee unite)
		{
			m_nNbUnitesOccupees = nNbUnites;
			m_uniteCoordonnees = unite;
		}

		/// <summary>
		/// Donne le nombre d'unité(s) occupée(s)
		/// </summary>
		[DynamicField("Units number")]
		public int NbUnitesOccupees
		{
			get
			{
				return m_nNbUnitesOccupees;
			}
			set
			{
				m_nNbUnitesOccupees = value;
			}
		}

		/// <summary>
		/// Spécifie l'unité utilisée
		/// <see ref="CUniteCoordonnee">Unite</see>
		/// </summary>
		[DynamicField("Unit")]
		public CUniteCoordonnee Unite
		{
			get
			{
				return m_uniteCoordonnees;
			}
			set
			{
				m_uniteCoordonnees = value;
			}
		}

	}
}
