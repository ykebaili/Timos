using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;
using timos.data.composantphysique;
using sc2i.data;

namespace timos.data
{

	//Tous les ojets qui ont une coordonnée
	public interface IObjetACoordonnees : IObjetAOccupation, IObjetDonnee
	{
		/// <summary>
		/// Description de l'élément
		/// </summary>
		string DescriptionElement { get; }

        /// <summary>
        /// Le libellé de l'élement
        /// </summary>
        string Libelle { get; }

		/// <summary>
		/// Coordonnée de l'objet
		/// </summary>
		string Coordonnee { get; set; }

		/// <summary>
		/// Coordonnée Parente de l'objet
		/// </summary>
		string CoordonneeParente { get; }

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

        C2iComposant3D GetComposantPhysique();



	}
}
