using System;
using System.Collections;
using System.Collections.Generic;

using sc2i.data;
using sc2i.expression;
using sc2i.common;


namespace timos.data.version
{
	public class CAuditVersionCleParticuliere : I2iSerializable
	{

	

		//-------------------------------------------------------------------
		public CAuditVersionCleParticuliere()
		{
			m_strNom = NomCleParDefaut;
		}

		private string m_strNom;
		public string Nom
		{
			get
			{
				return m_strNom;
			}
			set
			{
				if (value == null)
					m_strNom = NomCleParDefaut;
				else
					m_strNom = value;
			}
		}
		public string NomCleParDefaut
		{
			get
			{
				return I.T("Key without name|547");
			}
		}

		public string ChaineIDsPourFiltreSimple
		{
			get
			{
				string strChaine = "";
				foreach (int nId in m_ids)
					strChaine += nId.ToString() + ",";
				if (strChaine != "")
					strChaine = strChaine.Substring(0, strChaine.Length - 1);
				return strChaine;
			}
		}

		private List<int> m_ids = new List<int>();
		public List<int> IDsElementsDuType
		{
			get
			{
				return m_ids;
			}
			set
			{
				m_ids = value;
			}
		}

		private C2iExpression m_formuleCle;
		public C2iExpression FormuleCle
		{
			get
			{
				return m_formuleCle;
			}
			set
			{
				m_formuleCle = value;
			}
		}

		//-------------------------------------------------------------------

		#region I2iSerializable Membres
		private int GetNumVersion()
		{
			return 0;
		}
		public CResultAErreur Serialize(C2iSerializer serializer)
		{
			//VERSION
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion(ref nVersion);
			if (!result)
				return result;

			serializer.TraiteString(ref m_strNom);


			#region IDs des Types
			string strIds = ChaineIDsPourFiltreSimple;
			serializer.TraiteString(ref strIds);
			try
			{
				string[] arrayStrIds = strIds.Split(',');
				m_ids = new List<int>();
				foreach (string strId in arrayStrIds)
					m_ids.Add(int.Parse(strId));
			}
			catch
			{
				result.EmpileErreur(I.T("The reading of Types IDs in the @1 key failed|548",Nom));
				return result;
			}
			#endregion

			//FORMULE
			I2iSerializable iFormuleCle = m_formuleCle;
			result = serializer.SerializeObjet(ref iFormuleCle);
			if(!result)
				return result;
			m_formuleCle = (C2iExpression) iFormuleCle;

			return result;
		}

		#endregion
	}
}
