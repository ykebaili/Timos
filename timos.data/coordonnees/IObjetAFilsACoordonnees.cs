using System;
using System.Collections.Generic;

using System.Text;

using sc2i.common;

namespace timos.data
{

	/// <summary>
	/// tous les objets qui ont des fils avec des coordonn�es
	/// </summary>
	public interface IObjetAFilsACoordonnees : IObjetASystemeDeCoordonnee, IObjetAOptionsDeControleDeCoordonnees
	{
		/// <summary>
		/// Retourne la liste de tous les fils � coordonn�e contenus
		/// </summary>
		List<IObjetACoordonnees> FilsACoordonnees { get;}

		/// <summary>
		/// Retourne un result true si la coordonn�e est correcte pour le fils demand�,
		/// sinon, retourne une erreur
		/// </summary>
		/// <param name="strCoordonnee"></param>
		/// <param name="objet"></param>
		/// <returns></returns>
		CResultAErreur IsCoordonneeValide(string strCoordonnee, IObjetACoordonnees objet);


		/// <summary>
		/// V�rifie que toutes les coordonn�es des fils sont valides
		/// </summary>
		/// <returns></returns>
		CResultAErreur VerifieCoordonneesFils();

	}
}
