using System;
using System.Collections.Generic;
using System.Text;
using sc2i.common;


namespace HelpExtender
{
	/// <summary>
	/// Liste de CIndexAide
	/// </summary>
	public class CListeIndex : List<CIndexAide>, I2iSerializable
	{
		private int GetNumVersion()
		{
			return 0;
		}

		public CResultAErreur Serialize(C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion(ref nVersion);
			if (!result)
				return result;

			switch (serializer.Mode)
			{
				case ModeSerialisation.Ecriture:
					int nNb = Count;
					serializer.TraiteInt(ref nNb);
					foreach (CIndexAide index in this)
					{
						result = index.Serialize(serializer);
						if (!result)
							return result;
					}
					break;
				case ModeSerialisation.Lecture:
					int nNbToRead = Count;
					Clear();
					serializer.TraiteInt(ref nNbToRead);
					while (nNbToRead > 0)
					{
						CIndexAide index = new CIndexAide();
						result = index.Serialize(serializer);
						if (!result)
							return result;
						Add(index);
						nNbToRead--;
					}
					break;
			}
			return result;
		}
	}

	
}
