using System;
using System.Drawing;
using System.Collections;

using sc2i.common;

namespace timos.data
{
	/// <summary>
	/// Description résumée de EEtatPlanification.
	/// </summary>
    public enum EEtatPlanification
	{
		APrePlanifier = 0,
		PrePlanifie = 10,
		Planifie = 20,
		EnStandBy = 30,
		EnRetard = 40,
		EnCours = 50,
		Termine = 60,
		Annule = 70
	}
	public class CEtatPlanification : CEnumALibelle<EEtatPlanification>
	{
		public static Bitmap GetBitmapEtat(EEtatPlanification etat)
		{
			switch (etat)
			{
				case EEtatPlanification.APrePlanifier:
					return Resource.anomaliebloquante;
				case EEtatPlanification.PrePlanifie:
					return Resource.preplanifie;
				case EEtatPlanification.Planifie:
					return Resource.planifie;
				case EEtatPlanification.EnRetard:
					return Resource.retard;
				case EEtatPlanification.Termine:
					return Resource.valide;
				case EEtatPlanification.EnCours:
				case EEtatPlanification.EnStandBy:
				case EEtatPlanification.Annule:
				default:
					return null;
			}
		}
		/// //////////////////////////////////////////////////////
		public CEtatPlanification(EEtatPlanification ope)
			: base(ope)
		{
		}

		//----------------------------------------------------------------
        /// <summary>
        /// Libellé de l'état de planification :
        /// <ul>
        /// <li>A pré-planifier</li>
        /// <li>Pré-planifié</li>
        /// <li>Planifié</li>
        /// <li>En retard</li>
        /// <li>En attente</li>
        /// <li>En cours</li>
        /// <li>Terminé</li>
        /// <li>Annulé</li>
        /// </ul>
        /// </summary>
        [DynamicField("Label")]
		public override string Libelle
		{
			get
			{
				switch (Code)
				{
					case EEtatPlanification.APrePlanifier:
						return I.T("To pre-plan|528");
					case EEtatPlanification.PrePlanifie:
						return I.T("Pre-planned|527");
					case EEtatPlanification.Planifie:
						return I.T("Planned|526");
					case EEtatPlanification.EnRetard:
						return I.T("Delayed|525");
					case EEtatPlanification.EnStandBy:
						return I.T("Standby|529");
					case EEtatPlanification.EnCours:
						return I.T("In progress|156");
					case EEtatPlanification.Termine:
						return I.T("Ended|158");
					case EEtatPlanification.Annule:
						return I.T("Cancelled|159");
					default:
                        return "";
				}
			}
		}

        

	}
}
