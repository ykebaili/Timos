using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;
using timos.data.composantphysique;
using sc2i.data;

namespace timos.data
{

	//Tous les ojets qui ont une coordonn�e
	public interface IObjetACoordonnees : IObjetAOccupation, IObjetDonnee
	{
		/// <summary>
		/// Description de l'�l�ment
		/// </summary>
		string DescriptionElement { get; }

        /// <summary>
        /// Le libell� de l'�lement
        /// </summary>
        string Libelle { get; }

		/// <summary>
		/// Coordonn�e de l'objet
		/// </summary>
		string Coordonnee { get; set; }

		/// <summary>
		/// Coordonn�e Parente de l'objet
		/// </summary>
		string CoordonneeParente { get; }

		/// <summary>
		/// Coordonn�e complete
		/// </summary>
		string CoordonneeComplete { get; }

		/// <summary>
		/// Indique qu'il ne doit pas �tre fait de contr�le d'unit�
		/// sur cet objet
		/// </summary>
		bool IgnorerUnite { get;}
		
		/// <summary>
		/// Retourne l'�l�ment parent (qui contr�le les coordonn�e)
		/// </summary>
		IObjetAFilsACoordonnees ConteneurFilsACoordonnees { get; }

		/// <summary>
		/// V�rifie que la coordonn�e de l'objet est valide
		/// </summary>
		/// <returns></returns>
		CResultAErreur VerifieCoordonnee();

        C2iComposant3D GetComposantPhysique();



	}
}
