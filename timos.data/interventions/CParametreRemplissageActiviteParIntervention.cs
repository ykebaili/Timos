using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using sc2i.common;
using sc2i.expression;
using sc2i.data.dynamic;

namespace timos.data
{
	public class CParametreRemplissageActiviteParIntervention : I2iSerializable
	{
		private List<CRemplisssageChampActiviteActeur> m_listeRemplissage = new List<CRemplisssageChampActiviteActeur>();

		public CParametreRemplissageActiviteParIntervention()
		{
		}

		//------------------------------------------------
		public List<CRemplisssageChampActiviteActeur> ListeRemplissage
		{
			get
			{
				return m_listeRemplissage;
			}
		}

		//------------------------------------------------
		private int GetNumVersion()
		{
			return 0;
		}

		//------------------------------------------------
		public CResultAErreur Serialize ( C2iSerializer serializer )
		{
			int nVersion = GetNumVersion();
			CResultAErreur  result = serializer.TraiteVersion ( ref nVersion );

			ArrayList lst = new ArrayList ( m_listeRemplissage );
			result = serializer.TraiteArrayListOf2iSerializable ( lst );
			if (!result )
				return result;
			if ( serializer.Mode == ModeSerialisation.Lecture )
			{
				m_listeRemplissage.Clear();
				foreach ( CRemplisssageChampActiviteActeur r in lst )
					m_listeRemplissage.Add ( r );
			}
			return result;
		}

		public C2iExpression GetFormuleForChamp(CChampCustom champ)
		{
			foreach (CRemplisssageChampActiviteActeur remplissage in m_listeRemplissage)
				if (remplissage.IdChampCustom == champ.Id)
					return remplissage.Formule;
			return null;
		}
}

	public class CRemplisssageChampActiviteActeur : I2iSerializable
	{
		C2iExpression m_expression = null;
		int m_nIdChampCustom = -1;

		public CRemplisssageChampActiviteActeur()
		{
		}

		//------------------------------------------------
		public C2iExpression Formule
		{
			get
			{
				return m_expression;
			}
			set
			{
				m_expression = value;
			}
		}

		//------------------------------------------------
		public int  IdChampCustom
		{
			get
			{
				return m_nIdChampCustom;
			}
			set
			{
				m_nIdChampCustom = value;
			}
		}


		//------------------------------------------------
		private int GetNumVersion()
		{
			return 0;
		}


		//------------------------------------------------
		public CResultAErreur Serialize(C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion(ref nVersion);
			if (!result)
				return result;

			I2iSerializable objet = m_expression;
			result = serializer.TraiteObject(ref objet);
			if (!result)
				return result;
			if (serializer.Mode == ModeSerialisation.Lecture)
				m_expression = (C2iExpression)objet;

			serializer.TraiteInt(ref m_nIdChampCustom);
			return result;
		}

		

	}
}
