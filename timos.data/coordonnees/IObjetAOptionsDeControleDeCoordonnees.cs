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
	/// tous les objets qui définissent des options de contrôle de coordonnées
	/// </summary>
	public interface IObjetAOptionsDeControleDeCoordonnees
	{
		/// <summary>
		/// Indique quelles sont les options qui ne seront pas utilisées
		/// </summary>
		EOptionControleCoordonnees? OptionsDisponibles { get;}

		/// <summary>
		/// Retourne les options appliquées à l'élément
		/// </summary>
		EOptionControleCoordonnees? OptionsControleCoordonneesApplique { get;}
		
		/// <summary>
		/// Retourne le IObjetAOptionsDeControleDeCoordonnees susceptible de fournir le paramétrage hérité
		/// </summary>
		IObjetAOptionsDeControleDeCoordonnees DonnateurOptionsControleCoordonneesHerite { get;}

		/// <summary>
		/// Retourne les options propres à l'élément
		/// </summary>
		EOptionControleCoordonnees? OptionsControleCoordonneesPropre { get; set;}

		/// <summary>
		/// Retourne vrai si les options de contrôle peuvent être hérité
		/// </summary>
		bool CanHeriteOptionsControleCoordonnees { get;}
	}
}
