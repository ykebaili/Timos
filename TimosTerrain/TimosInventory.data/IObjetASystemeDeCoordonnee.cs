using System;
using System.Collections.Generic;
using System.Text;

namespace TimosInventory.data
{

	/// <summary>
	/// Tous les objets qui définissent un système de coordonnées
	/// </summary>
	public interface IObjetASystemeDeCoordonnee
	{
		/// <summary>
		/// Retourne le paramétrage appliqué à l'élément
		/// </summary>
		CParametrageSystemeCoordonnees ParametrageCoordonneesApplique { get;}
		
		/// <summary>
		/// Retourne le IObjetASystemeDeCoordonneeParent susceptible de fournir le paramétrage hérité
		/// </summary>
		IObjetASystemeDeCoordonnee DonnateurParametrageCoordonneeHerite { get;}

		/// <summary>
		/// Retourne le paramétrage 
		/// </summary>
		CParametrageSystemeCoordonnees ParametrageCoordonneesPropre { get; }



	}
}
