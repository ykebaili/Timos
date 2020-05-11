using System;
using System.Collections.Generic;
using System.Text;

namespace TimosInventory.data
{

	/// <summary>
	/// Tous les objets qui d�finissent un syst�me de coordonn�es
	/// </summary>
	public interface IObjetASystemeDeCoordonnee
	{
		/// <summary>
		/// Retourne le param�trage appliqu� � l'�l�ment
		/// </summary>
		CParametrageSystemeCoordonnees ParametrageCoordonneesApplique { get;}
		
		/// <summary>
		/// Retourne le IObjetASystemeDeCoordonneeParent susceptible de fournir le param�trage h�rit�
		/// </summary>
		IObjetASystemeDeCoordonnee DonnateurParametrageCoordonneeHerite { get;}

		/// <summary>
		/// Retourne le param�trage 
		/// </summary>
		CParametrageSystemeCoordonnees ParametrageCoordonneesPropre { get; }



	}
}
