using System;
using System.Collections;

using sc2i.common;

namespace timos.data
{
	/// <summary>
	/// Description r�sum�e de CEtatClotureDeBase
	/// </summary>
    public enum EtatClotureBase
	{
		R�solue = 0,
		Annul� = 10,
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
					case EtatClotureBase.R�solue:
						return I.T( "Resolved|30064");
					case EtatClotureBase.Annul�:
						return I.T( "Cancelled|30065");
                    case EtatClotureBase.HorsContrat:
						return I.T( "Out of contract scope|30066");
				}
				return "";
			}
		}
	}
}
