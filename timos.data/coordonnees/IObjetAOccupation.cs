using System;
using System.Collections.Generic;
using System.Text;

namespace timos.data
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

		/// <summary>
		/// Retourne vrai si le parametrage de coordonn�es peut �tre h�rit�
		/// </summary>
		bool CanHeriteOccupationCoordonnees { get;}

		
	}
}
