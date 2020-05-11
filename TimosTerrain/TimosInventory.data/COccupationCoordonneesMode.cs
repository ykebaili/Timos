using System;
using System.Collections;
using System.Collections.Generic;
using sc2i.common;

namespace TimosInventory.data
{
	//#######################################################################	


	/// <summary>
	/// Définit le mode de fonctionnement d'un systeme de coordonnée sur les niveaux :
	/// 1 - CSystemeCoordonnees
	/// 2 - IDefinisseurSystemeCoordonnees
	/// 3 - IObjetAvecFilsAvecCoordonnees
	/// Les applications de ce mode peuvent être dérogatives et se font du plus petit 
	/// niveaux (IObjetAvecFilsAvecCoordonnees) au plus haut.
	/// </summary>
	public enum EOccupationCoordonneesMode
	{
		Occupation_X_Et_Unite = 0,//teste de l'occupation et de l'unité
		Occupation_1_Et_Unite,//L'occupation est
		Occupation_0_Sans_Unite
	}


	public class COccupationCoordonneesMode : CEnumALibelle<EOccupationCoordonneesMode>
	{
		/// //////////////////////////////////////////////////////
		public COccupationCoordonneesMode(EOccupationCoordonneesMode statut)
			:base(statut)
		{
		}

		/// //////////////////////////////////////////////////////
		public override string Libelle
		{
			get
			{
				string result = "";
				switch (Code)
				{
					case EOccupationCoordonneesMode.Occupation_X_Et_Unite:
						result = I.T( "With place and occupation unit |207");
						break;
					case EOccupationCoordonneesMode.Occupation_1_Et_Unite:
						result = I.T( "With single place and occupation unit|208");
						break;
					case EOccupationCoordonneesMode.Occupation_0_Sans_Unite:
						result = I.T( "Without place and occupation unit|209");
						break;
				}
				return result;
			}
		}

	}

}
