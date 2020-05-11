using System;
using System.Collections.Generic;
using System.Text;

namespace timos.data
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

		/// <summary>
		/// Retourne vrai si le parametrage de coordonnées peut être hérité
		/// </summary>
		bool CanHeriteParametrageCoordonnees { get;}

		/// <summary>
		/// Description de l'élément
		/// </summary>
		string DescriptionElement { get;}

		/// <summary>
		/// Retourne la propriété (s'il y en a une) qui, à partir du IObjetASysteme de coordonnée,
		/// retourne les fils qui utilisent le paramétrage de ce système de coordonnées (IObjetAFilsACoordonnee)
		/// Si l'objet implémement lui-même IObjetAFilsACoordonnée, retourner ""
		/// </summary>
		string ProprieteVersObjetsAFilsACoordonneesUtilisantLeParametrage { get;}
	}
}
