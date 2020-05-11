using System;
using System.Collections.Generic;

using System.Text;

using sc2i.common;

namespace timos.data
{

	/// <summary>
	/// tous les objets qui ont des fils avec des coordonnées
	/// </summary>
	public interface IObjetAFilsACoordonnees : IObjetASystemeDeCoordonnee, IObjetAOptionsDeControleDeCoordonnees
	{
		/// <summary>
		/// Retourne la liste de tous les fils à coordonnée contenus
		/// </summary>
		List<IObjetACoordonnees> FilsACoordonnees { get;}

		/// <summary>
		/// Retourne un result true si la coordonnée est correcte pour le fils demandé,
		/// sinon, retourne une erreur
		/// </summary>
		/// <param name="strCoordonnee"></param>
		/// <param name="objet"></param>
		/// <returns></returns>
		CResultAErreur IsCoordonneeValide(string strCoordonnee, IObjetACoordonnees objet);


		/// <summary>
		/// Vérifie que toutes les coordonnées des fils sont valides
		/// </summary>
		/// <returns></returns>
		CResultAErreur VerifieCoordonneesFils();

	}
}
