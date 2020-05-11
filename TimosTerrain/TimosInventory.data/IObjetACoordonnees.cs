using System;
using System.Collections.Generic;
using System.Text;
using sc2i.common;



namespace TimosInventory.data
{

	//Tous les ojets qui ont une coordonnée
	public interface IObjetACoordonnees : IObjetAOccupation
	{

        string DescriptionElement { get; }

		/// <summary>
		/// Coordonnée de l'objet
		/// </summary>
		string Coordonnee { get; set; }

		/// <summary>
		/// Coordonnée complete
		/// </summary>
		string CoordonneeComplete { get; }

		/// <summary>
		/// Indique qu'il ne doit pas être fait de contrôle d'unité
		/// sur cet objet
		/// </summary>
		bool IgnorerUnite { get;}
		
		/// <summary>
		/// Retourne l'élément parent (qui contrôle les coordonnée)
		/// </summary>
		IObjetAFilsACoordonnees ConteneurFilsACoordonnees { get; }

		/// <summary>
		/// Vérifie que la coordonnée de l'objet est valide
		/// </summary>
		/// <returns></returns>
		CResultAErreur VerifieCoordonnee();




	}
}
