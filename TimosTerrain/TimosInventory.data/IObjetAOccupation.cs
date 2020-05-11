using System;
using System.Collections.Generic;
using System.Text;

namespace TimosInventory.data
{
	/// <summary>
	/// Objet occupant de la place (nb unit�s et unit�)
	/// </summary>
	public interface IObjetAOccupation
	{
		/// <summary>
		/// Retourne l'occupation appliqu�e
		/// </summary>
		COccupationCoordonnees OccupationCoordonneeAppliquee { get;}

		/// <summary>
		/// Retourne le IObjetASystemeDeCoordonneeParent susceptible de fournir le param�trage h�rit�
		/// </summary>
		IObjetAOccupation DonnateurOccupationCoordonneeHerite { get;}

		/// <summary>
		/// Retourne le param�trage 
		/// </summary>
		COccupationCoordonnees OccupationCoordonneesPropre { get;set; }

	}
}
