using System;
using System.Collections.Generic;
using System.Text;

namespace TimosInventory.data
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
        /// Retourne les options appliqu�es � l'�l�ment
        /// </summary>
        EOptionControleCoordonnees? OptionsControleCoordonneesApplique { get; }

        /// <summary>
        /// Retourne les options propres � l'�l�ment
        /// </summary>
        EOptionControleCoordonnees? OptionsControleCoordonneesPropre { get; set; }

	}
}
