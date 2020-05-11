using System;
using System.Collections;

using sc2i.common;

namespace timos.data
{
	/// <summary>
	/// Description résumée de CEtatBaseIntervention.
	/// </summary>
    public enum RecurrenceListeOperations
	{
		Quotidien = 0,
        Hebdomadaire = 1,
        Bimensuel = 2,
        Mensuel = 3,
        Bimestriel = 4,
        Trimestriel = 5,
        Semestriel = 6,
        Annuel = 7
	}

    public class CRecurrenceListeOperations : CEnumALibelle<RecurrenceListeOperations>
	{

        public CRecurrenceListeOperations(RecurrenceListeOperations etat)
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
                    case RecurrenceListeOperations.Quotidien:
                        return I.T( "Daily|1140");
                    case RecurrenceListeOperations.Hebdomadaire:
                        return I.T( "Weekly|1141");
                    case RecurrenceListeOperations.Bimensuel:
                        return I.T( "Two-monthly|1142");
                    case RecurrenceListeOperations.Mensuel:
                        return I.T( "Monthly|1143");
                    case RecurrenceListeOperations.Bimestriel:
                        return I.T( "Bimonthly|1144");
                    case RecurrenceListeOperations.Trimestriel:
                        return I.T( "Quarterly|1145");
                    case RecurrenceListeOperations.Semestriel:
                        return I.T( "Semi-annual|1146");
                    case RecurrenceListeOperations.Annuel:
                        return I.T( "Annual|1147");
                    default:
                        break;
                }

				return "";
			}
		}

		
	}
}
