using sc2i.common;

namespace timos.data.preventives
{

	public enum EEchelleTemps
	{
		Heure = 0,
		Jour = 10,
		Mois = 20,
		Semaine = 30,
		Annee = 40,
	}

	public class CEchelleTemps : CEnumALibelle<EEchelleTemps>
	{
		/// //////////////////////////////////////////////////////
		public CEchelleTemps(EEchelleTemps ope)
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
					case EEchelleTemps.Mois:	result = I.T("Month|63");	break;
					case EEchelleTemps.Jour:	result = I.T("Day|61");		break;
					case EEchelleTemps.Semaine: result = I.T("Week|62");	break;
					case EEchelleTemps.Heure:	result = I.T("Hour|60");	break;
					case EEchelleTemps.Annee:	result = I.T("Year|64");	break;
				}
				return result;
			}
		}

		public static implicit operator CEchelleTemps(EEchelleTemps valEnum)
		{
			return new CEchelleTemps(valEnum);
		}
	}
}
