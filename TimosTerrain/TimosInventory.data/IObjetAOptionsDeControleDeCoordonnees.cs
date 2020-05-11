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
	/// tous les objets qui définissent des options de contrôle de coordonnées
	/// </summary>
	public interface IObjetAOptionsDeControleDeCoordonnees
	{
        /// <summary>
        /// Retourne les options appliquées à l'élément
        /// </summary>
        EOptionControleCoordonnees? OptionsControleCoordonneesApplique { get; }

        /// <summary>
        /// Retourne les options propres à l'élément
        /// </summary>
        EOptionControleCoordonnees? OptionsControleCoordonneesPropre { get; set; }

	}
}
