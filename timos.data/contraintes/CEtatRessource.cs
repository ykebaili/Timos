using System;
using System.Collections;

using sc2i.common;

namespace timos.data
{
	/// <summary>
	/// L'etat de <see cref="CRessourceMaterielle">ressource</see> définie son statut actuel
	/// </summary>
    public enum EtatRessource
	{
		Active = 0,
		Inactive = 10,
		Utilisée = 20
	}

	/// <summary>
	/// L'etat de <see cref="CRessourceMaterielle">Ressource</see> définie son statut actuel
	/// </summary>
	public class CEtatRessource : CEnumALibelle<EtatRessource>
	{
		public CEtatRessource(EtatRessource res)
			:base (res)
		{
		}

		/////////////////////////////////////////////////////////
		public override string Libelle
		{
			get
			{
				switch (this.Code)
				{
					case EtatRessource.Active:
						return I.T( "Enabled|150");
					case EtatRessource.Inactive:
						return I.T( "Disabled|151");
					case EtatRessource.Utilisée:
						return I.T( "Used|152");
				}
				return "";
			}
		}
	}
}
