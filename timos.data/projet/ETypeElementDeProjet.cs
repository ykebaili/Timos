using System;

using sc2i.common;


namespace timos.data
{
	public enum ETypeElementDeProjet
	{
		Projet,
		Intervention,
		Lien
	}

	public class CTypeElementDeProjet : CEnumALibelle<ETypeElementDeProjet>
	{
		/// //////////////////////////////////////////////////////
		public CTypeElementDeProjet(ETypeElementDeProjet ope)
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
					case ETypeElementDeProjet.Intervention:
						result = I.T( "Intervention|456");
						break;
					case ETypeElementDeProjet.Lien:
						result = I.T( "Link|451");
						break;
					case ETypeElementDeProjet.Projet:
						result = I.T( "Project|457");
						break;
					default:
						break;
				}

				return result;
			
			}
		}

	}
}
