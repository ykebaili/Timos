using System;
using System.Collections.Generic;
using System.Text;
using sc2i.common;



namespace TimosInventory.data
{

	//Tous les ojets qui ont une coordonn�e
	public interface IObjetACoordonnees : IObjetAOccupation
	{

        string DescriptionElement { get; }

		/// <summary>
		/// Coordonn�e de l'objet
		/// </summary>
		string Coordonnee { get; set; }

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




	}
}
