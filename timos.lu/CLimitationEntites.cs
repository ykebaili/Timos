using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;

namespace timos.lu
{
	class CLimitationEntites : I2iSerializable
	{
		private Type m_typeEntite = null;
		private int m_nQuantite = 0;

		//-----------------------------------
		public Type TypeEntite
		{
			get
			{
				return m_typeEntite;
			}
			set
			{
				m_typeEntite = value;
			}
		}

		//-----------------------------------
		public int Quantite
		{
			get
			{
				return m_nQuantite;
			}
			set
			{
				m_nQuantite = value;
			}
		}


		#region I2iSerializable Membres
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
			serializer.TraiteType(ref m_typeEntite);
			serializer.TraiteInt(ref m_nQuantite);
			return result;
		}

		#endregion
	}
}
