using System;
using System.Collections.Generic;
using System.Text;

namespace timos.data
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

		/// <summary>
		/// Retourne vrai si le parametrage de coordonn�es peut �tre h�rit�
		/// </summary>
		bool CanHeriteParametrageCoordonnees { get;}

		/// <summary>
		/// Description de l'�l�ment
		/// </summary>
		string DescriptionElement { get;}

		/// <summary>
		/// Retourne la propri�t� (s'il y en a une) qui, � partir du IObjetASysteme de coordonn�e,
		/// retourne les fils qui utilisent le param�trage de ce syst�me de coordonn�es (IObjetAFilsACoordonnee)
		/// Si l'objet impl�mement lui-m�me IObjetAFilsACoordonn�e, retourner ""
		/// </summary>
		string ProprieteVersObjetsAFilsACoordonneesUtilisantLeParametrage { get;}
	}
}
