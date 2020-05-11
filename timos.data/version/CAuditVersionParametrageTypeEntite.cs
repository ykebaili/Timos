using System;
using System.Collections;
using System.Collections.Generic;

using sc2i.data;
using sc2i.data.dynamic;
using sc2i.expression;
using sc2i.common;
using sc2i.process;


namespace timos.data.version
{

	public class CAuditVersionParametrageTypeEntite : I2iSerializable
	{
		public CAuditVersionParametrageTypeEntite()
		{ 

		}
		public CAuditVersionParametrageTypeEntite(Type type)
		{
			m_type = type;
			m_filtre = new CFiltreDynamique();
			m_filtre.TypeElements = m_type;
		}

		private CFiltreDynamique m_filtre;
		public CFiltreDynamique Filtre
		{
			get
			{
				return m_filtre;
			}
			set
			{
				m_filtre = value;
			}
		}


		private Type m_type;
		public Type TypeEntite
		{
			get
			{
				return m_type;
			}
			set
			{
				m_type = value;
			}
		}

		public string NomTypeConvivial
		{
			get
			{
				if(m_type != null)
					return DynamicClassAttribute.GetNomConvivial(m_type);
				else
					return I.T("Unspecified name type|549");

			}
		}


		public string NomType
		{
			get
			{
				if (m_type != null)
					return m_type.Name;
				else
					return I.T("Unspecified name type|549");
			}
		}


		public bool IdTypeFiltre(int nId)
		{
			foreach (CAuditVersionCleParticuliere k in m_clesParticulieres)
				if (k.IDsElementsDuType.Contains(nId))
					return true;

			return false;
		}
		public string GetChaineIdsFiltresPourFiltreSimple()
		{
			string strChaine = "";
			foreach (CAuditVersionCleParticuliere k in m_clesParticulieres)
			{
				string strIdsEle = k.ChaineIDsPourFiltreSimple;
				if(strIdsEle != "")
					strChaine += strIdsEle+ ",";
			}

			if (strChaine != "")
				strChaine = strChaine.Substring(0, strChaine.Length - 1);
			return strChaine;
		}


		private C2iExpression m_formuleDescription;
		public C2iExpression FormuleDescription
		{
			get
			{
				return m_formuleDescription;
			}
			set
			{
				m_formuleDescription = value;
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

		private List<CAuditVersionCleParticuliere> m_clesParticulieres = new List<CAuditVersionCleParticuliere>();
		public List<CAuditVersionCleParticuliere> ClesParticulieres
		{
			get
			{
				return m_clesParticulieres;
			}
			set
			{
				m_clesParticulieres = value;
			}
		}


		#region I2iSerializable Membres
		private int GetNumVersion()
		{
			return 1;
		}
		public CResultAErreur Serialize(C2iSerializer serializer)
		{
			//VERSION
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion(ref nVersion);
			if (!result)
				return result;


			#region CLES PARTICULIERES
			int nNbKeys = m_clesParticulieres.Count;
			serializer.TraiteInt(ref nNbKeys);
			switch (serializer.Mode)
			{
				case ModeSerialisation.Ecriture:
					foreach (CAuditVersionCleParticuliere k in m_clesParticulieres)
					{
						result = k.Serialize(serializer);
						if (!result)
							return result;
					}

					break;
				case ModeSerialisation.Lecture:
					m_clesParticulieres.Clear();
					for (int nK = 0; nK < nNbKeys; nK++)
					{
						CAuditVersionCleParticuliere key = new CAuditVersionCleParticuliere();
						CResultAErreur lecKey = key.Serialize(serializer);
						if (!lecKey)
						{
							result.Erreur += lecKey.Erreur;
							result.Result = false;
						}
						m_clesParticulieres.Add(key);
					}
					break;
			}
			#endregion

			//FILTRE
			I2iSerializable iFiltre = m_filtre;
			result = serializer.SerializeObjet(ref iFiltre);
			if (!result)
				return result;
			if (iFiltre != null)
				m_filtre = (CFiltreDynamique)iFiltre;
			else
				m_filtre = null;


			//TYPE
			bool bHasType = m_type != null;
			serializer.TraiteBool(ref bHasType);
			if (bHasType)
				serializer.TraiteType(ref m_type);
			else
				m_type = null;

			//FORMULE
			I2iSerializable iFormuleCle = m_formuleCle;
			result = serializer.SerializeObjet(ref iFormuleCle);
			if (!result)
				return result;
			if (iFormuleCle != null)
				m_formuleCle = (C2iExpression)iFormuleCle;
			else
				m_formuleCle = null;

			//FORMULE DE DESCRIPTION
			if (nVersion > 0)
			{
				I2iSerializable iFormuleDescription = m_formuleDescription;
				result = serializer.SerializeObjet(ref iFormuleDescription);
				if (!result)
					return result;
				if (iFormuleDescription != null)
					m_formuleDescription = (C2iExpression)iFormuleDescription;
				else
					m_formuleDescription = null;
			}
			return result;
		}
		#endregion
	}
}
