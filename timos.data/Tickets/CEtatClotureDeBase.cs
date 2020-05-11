using System;
using System.Collections;

using sc2i.common;

namespace timos.data
{
	/// <summary>
	/// Description résumée de CEtatClotureDeBase
	/// </summary>
    public enum EtatClotureBase
	{
		Résolue = 0,
		Annulé = 10,
		HorsContrat = 20
	}

	public class CEtatClotureBase : CEnumALibelle<EtatClotureBase>
	{
		public CEtatClotureBase(EtatClotureBase etat)
			:base (etat)
		{
		}

		/// ///////////////////////////////////////////////////////////////
		public override string Libelle
		{
			get
			{
				switch (this.Code)
				{
					case EtatClotureBase.Résolue:
						return I.T( "Resolved|30064");
					case EtatClotureBase.Annulé:
						return I.T( "Cancelled|30065");
                    case EtatClotureBase.HorsContrat:
						return I.T( "Out of contract scope|30066");
				}
				return "";
			}
		}
	}
}
