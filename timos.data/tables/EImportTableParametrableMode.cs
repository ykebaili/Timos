using sc2i.common;

namespace timos.data
{

	public enum EImportTableParametrableMode
	{
		RAZ_Puis_Import = 0,
		Update_Or_Create = 1,
		Delete,
	}

	public class CImportTableParametrableMode : CEnumALibelle<EImportTableParametrableMode>
	{
		/// //////////////////////////////////////////////////////
		public CImportTableParametrableMode(EImportTableParametrableMode ope)
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
					case EImportTableParametrableMode.Delete:
						result = I.T("Delete|72");
						break;
					case EImportTableParametrableMode.RAZ_Puis_Import:
						result = I.T("Overwrite and Import|519");
						break;
					case EImportTableParametrableMode.Update_Or_Create:
						result = I.T("Update or Create|520");
						break;

				}

				return result;

			}
		}

		public static implicit operator CImportTableParametrableMode(EImportTableParametrableMode valEnum)
		{
			return new CImportTableParametrableMode(valEnum);
		}
	}
}
