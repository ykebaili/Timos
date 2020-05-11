using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;

namespace HelpExtender
{
	/// <summary>
	/// Index d'une aide : stock le mappage en une clé d'aide et
	/// son index dans le CIndexAide
	/// </summary>
	public class CIndexAide : I2iSerializable
	{
		#region :: Propriétés ::
		private string m_strCle;
		private int m_nIndex;
		#endregion

		#region ++ Constructeurs ++
		//----------------------------
		public CIndexAide()
		{
		}
		

		//----------------------------
		public CIndexAide(string strCle, int nIndex)
		{
			m_strCle = strCle.ToUpper();
			m_nIndex = nIndex;
		}
		#endregion

		#region ~~ Méthodes ~~
		//----------------------------
		private int GetNumVersion()
		{
			return 0;
		}

		//----------------------------
		public CResultAErreur Serialize(C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion(ref nVersion);
			if (!result)
				return result;
			serializer.TraiteString(ref m_strCle);
			serializer.TraiteInt(ref m_nIndex);
			return result;
		}
		#endregion

		#region >> Assesseurs <<
		//----------------------------
		public string Cle
		{
			get
			{
				return m_strCle;
			}
			set
			{
				m_strCle = value;
			}
		}

		//----------------------------
		public int Index
		{
			get
			{
				return m_nIndex;
			}
			set
			{
				m_nIndex = value;
			}
		}
		#endregion
	}
}

