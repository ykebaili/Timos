using System;
using System.Collections.Generic;
using System.Text;

namespace timos.data
{
	/// <summary>
	/// Objet occupant de la place (nb unités et unité)
	/// </summary>
	public interface IObjetAOccupation
	{
		/// <summary>
		/// Retourne l'occupation appliquée
		/// </summary>
		COccupationCoordonnees OccupationCoordonneeAppliquee { get;}

		/// <summary>
		/// Retourne le IObjetASystemeDeCoordonneeParent susceptible de fournir le paramétrage hérité
		/// </summary>
		IObjetAOccupation DonnateurOccupationCoordonneeHerite { get;}

		/// <summary>
		/// Retourne le paramétrage 
		/// </summary>
		COccupationCoordonnees OccupationCoordonneesPropre { get;set; }

		/// <summary>
		/// Retourne vrai si le parametrage de coordonnées peut être hérité
		/// </summary>
		bool CanHeriteOccupationCoordonnees { get;}

		
	}
}
