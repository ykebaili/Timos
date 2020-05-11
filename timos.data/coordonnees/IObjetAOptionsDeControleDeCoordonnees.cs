using System;
using System.Collections.Generic;
using System.Text;

namespace timos.data
{
	[Flags]
	public enum EOptionControleCoordonnees
	{
		TousControles = 0,
		IgnorerLesFilsSansCoordonnees = 1,
		IgnorerLesUnites = 2,
		IgnorerLoccupation = 4,
		AutoriserPlusieursFilsSurLaMemeCoordonnee = 8,
        IgnorerLesSites = 16,
        IgnorerLesEquipements = 32,
        IgnorerLesStocks = 64
	};


	/// <summary>
	/// tous les objets qui d�finissent des options de contr�le de coordonn�es
	/// </summary>
	public interface IObjetAOptionsDeControleDeCoordonnees
	{
		/// <summary>
		/// Indique quelles sont les options qui ne seront pas utilis�es
		/// </summary>
		EOptionControleCoordonnees? OptionsDisponibles { get;}

		/// <summary>
		/// Retourne les options appliqu�es � l'�l�ment
		/// </summary>
		EOptionControleCoordonnees? OptionsControleCoordonneesApplique { get;}
		
		/// <summary>
		/// Retourne le IObjetAOptionsDeControleDeCoordonnees susceptible de fournir le param�trage h�rit�
		/// </summary>
		IObjetAOptionsDeControleDeCoordonnees DonnateurOptionsControleCoordonneesHerite { get;}

		/// <summary>
		/// Retourne les options propres � l'�l�ment
		/// </summary>
		EOptionControleCoordonnees? OptionsControleCoordonneesPropre { get; set;}

		/// <summary>
		/// Retourne vrai si les options de contr�le peuvent �tre h�rit�
		/// </summary>
		bool CanHeriteOptionsControleCoordonnees { get;}
	}
}
