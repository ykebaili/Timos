using System;

using sc2i.common;


namespace timos.data
{
	[Flags]
	public enum ETypeAnomalieProjet
	{
		PrePlanificationIncomplete = 1,
		PlanificationIncomplete = 2,
		NonRespectContrainteDate = 4,
		Boucle = 8,
        Autre = 16
	}

	public class CTypeAnomalieProjet : CEnumALibelle<ETypeAnomalieProjet>
	{
		/// //////////////////////////////////////////////////////
		public CTypeAnomalieProjet(ETypeAnomalieProjet ope)
			: base(ope)
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
					case ETypeAnomalieProjet.Boucle:
						result = I.T( "Loop / Structural inconsistency|533");
						break;
					case ETypeAnomalieProjet.NonRespectContrainteDate:
						result = I.T("Not respect of date constraints|534");
						break;
					case ETypeAnomalieProjet.PrePlanificationIncomplete:
						result = I.T("Incomplete Pre-planning|535");
						break;
					case ETypeAnomalieProjet.PlanificationIncomplete:
						result = I.T("Incomplete planning|536");
						break;
                    case ETypeAnomalieProjet.Autre :
                        result = I.T("Other|20060");
                        break;
					default:
						break;
				}
				return result;
			}
		}
	}
}
