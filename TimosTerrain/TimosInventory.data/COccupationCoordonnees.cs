using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;

namespace TimosInventory.data
{

	/// <summary>
	/// Permet de faire la relation entre une occupation et une unit�.<br/>
    /// Ce concept est exploit� pour g�rer l'occupation d'un �l�ment<br/>
    /// dans un �l�ment englobant (exemple : l'occupation d'un module<br/>
    /// � l'int�rieur d'un ch�ssis).
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
		/// Donne le nombre d'unit�(s) occup�e(s)
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
		/// Sp�cifie l'unit� utilis�e
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
