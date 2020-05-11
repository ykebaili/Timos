using System;
using System.Collections;

using sc2i.common;

namespace timos.data
{
	/// <summary>
	/// Description résumée de CEtatBaseIntervention.
	/// </summary>
    public enum EtatFractionIntervention
	{
		AFaire = 20,
		EnCours = 30,
		Terminee = 50,
		Annulee = 60
	}
	public class CEtatFractionIntervention : CEnumALibelle<EtatFractionIntervention>
	{

		public CEtatFractionIntervention(EtatFractionIntervention etat)
			: base(etat)
		{
		}

		/// //////////////////////////////////////////////////////
		public override string Libelle
		{
			get
			{
				switch (Code)
				{
					case EtatFractionIntervention.AFaire:
						return I.T( "Planned|155");
					case EtatFractionIntervention.EnCours:
						return I.T( "In progress|156");
					case EtatFractionIntervention.Terminee:
						return I.T( "Ended|158");
					case EtatFractionIntervention.Annulee:
						return I.T( "Cancelled|159");
				}
				return "";
			}
		}

		
	}
}
