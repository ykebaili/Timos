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
    public class CAuditVersionParametrage : I2iSerializable
	{
		//-------------------------------------------------------------------
		public CAuditVersionParametrage()
		{
		}

		public bool IsTypeParametre(string strNomType)
		{
			foreach (CAuditVersionParametrageTypeEntite par in TypesParametres)
				if (par.NomType == strNomType)
					return true;
			return false;
		}

		public CAuditVersionParametrageTypeEntite GetParametrage(string strNomType)
		{
			foreach (CAuditVersionParametrageTypeEntite par in TypesParametres)
				if (par.NomType == strNomType)
					return par;
			return null;
		}


		private List<CAuditVersionParametrageTypeEntite> m_typesParametres = new List<CAuditVersionParametrageTypeEntite>();
		public List<CAuditVersionParametrageTypeEntite> TypesParametres
		{
			get
			{
				return m_typesParametres;
			}
			set
			{
				m_typesParametres = value;
			}
		}


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

			#region CLES PARTICULIERES
			int nNbKeys = m_typesParametres.Count;
			serializer.TraiteInt(ref nNbKeys);
			switch (serializer.Mode)
			{
				case ModeSerialisation.Ecriture:
					foreach (CAuditVersionParametrageTypeEntite k in m_typesParametres)
					{
						result = k.Serialize(serializer);
						if (!result)
							return result;
					}

					break;
				case ModeSerialisation.Lecture:
					m_typesParametres.Clear();
					for (int nK = 0; nK < nNbKeys; nK++)
					{
						CAuditVersionParametrageTypeEntite key = new CAuditVersionParametrageTypeEntite();
						CResultAErreur lecKey = key.Serialize(serializer);
						if (!lecKey)
						{
							result.Erreur += lecKey.Erreur;
							result.Result = false;
						}
						m_typesParametres.Add(key);
					}
					break;
			}
			#endregion

			return result;
		}

		#endregion
	}


}
