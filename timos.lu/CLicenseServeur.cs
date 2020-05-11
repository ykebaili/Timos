using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using sc2i.common;

namespace timos.lu
{
	public class CLicenseServeur : I2iSerializable	
	{
		private string m_strNumLicense = "";
		private string m_strNomClient = "";
		private List<CLimitationEntites> m_listeLimitationsEntites = new List<CLimitationEntites>();

		//--------------------------------------
		public CLicenseServeur()
		{
		}

		//--------------------------------------
		public string NumLicense
		{
			get
			{
				return m_strNumLicense;
			}
			set
			{
				m_strNumLicense = value;
			}
		}

		//--------------------------------------
		public string NomClient
		{
			get
			{
				return m_strNomClient;
			}
			set
			{
				m_strNomClient = value;
			}
		}


		//--------------------------------------
		private int GetNumVersion()
		{
			return 0;
		}


		#region I2iSerializable Membres
		//--------------------------------------
		public CResultAErreur Serialize(C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion(ref nVersion);
			if (!result)
				return result;
			serializer.TraiteString(ref m_strNumLicense);
			serializer.TraiteString(ref m_strNomClient);

			ArrayList lst = new ArrayList(m_listeLimitationsEntites);
			result = serializer.TraiteArrayListOf2iSerializable(lst, new object[0]);
			if (!result)
				return result;
			if (serializer.Mode == ModeSerialisation.Lecture)
			{
				m_listeLimitationsEntites.Clear();
				foreach (CLimitationEntites lim in lst)
					m_listeLimitationsEntites.Add(lim);
			}

			return result;
		}

		#endregion
	}
}
