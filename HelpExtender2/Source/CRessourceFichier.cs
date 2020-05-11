using System;
using System.Collections.Generic;
using System.Text;

namespace HelpExtender
{
	public class CRessourceFichier
	{
		private string m_strNomFichierLocal = "";
		private string m_strCle = "";

		//------------------------------------
		public CRessourceFichier()
		{
		}

		//------------------------------------
		public CRessourceFichier(string strCle, string strNomFichierLocal)
		{
			m_strNomFichierLocal = strNomFichierLocal;
			m_strCle = strCle;
		}

		//------------------------------------
		public string NomFichierLocal
		{
			get
			{
				return m_strNomFichierLocal;
			}
		}

		//------------------------------------
		public string Cle
		{
			get
			{
				return m_strCle;
			}
		}
	}
}
