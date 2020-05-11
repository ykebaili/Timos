using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using sc2i.common;

namespace timos.data
{
	public class CMappageColonneTableParametrableColonneTableParametrable
	{

		public event EventHandler SourceChanged;
		public event EventHandler CibleChanded;

		public CMappageColonneTableParametrableColonneTableParametrable()
		{

		}

		public string Description
		{
			get
			{
				if(m_colA != null && m_colB != null)
				{
					return I.T("Mapping between the column @1 and the column @2|30015", ColonneA.Libelle, ColonneB.Libelle);
				}
				else if (m_colA == null && m_colB != null)
				{
					return I.T("Mapping of the constant @1 for the column @2|30016", (DefaultValueAtoB == DBNull.Value ? "NULL" : DefaultValueAtoB.ToString()), ColonneB.Libelle);
				}
				else if(ColonneA != null && ColonneB == null)
				{
					return I.T("Mapping between the column @1 and undefined column|30017", ColonneA.Libelle);
				}
				else
				{
					return I.T("Mapping between 2 columns undefined|30017");
				}
			}
		}

		private CColonneTableParametrable m_colA;
		public CColonneTableParametrable ColonneA
		{
			get
			{
				return m_colA;
			}
			set
			{
				if (m_colA != value)
				{
					m_colA = value;
					if(SourceChanged != null)
						SourceChanged(value, new EventArgs());
				}
			}
		}

		public CTypeTableParametrable TypeTableColonneA
		{
			get
			{
				if (m_colA != null)
					return m_colA.TypeTable;
				return null;
			}
		}

		private CColonneTableParametrable m_colB;
		public CColonneTableParametrable ColonneB
		{
			get
			{
				return m_colB;
			}
			set
			{
				if (value != m_colB)
				{
					m_colB = value;
					if (CibleChanded != null)
						CibleChanded(value, new EventArgs());
				}
			}
		}
		public CTypeTableParametrable TypeTableColonneB
		{
			get
			{
				if (ColonneB != null)
					return ColonneB.TypeTable;
				return null;
			}
		}
		public bool NeedDefaultValueAtoB
		{
			get
			{
				return m_colA == null || (m_colA.AllowNull && !m_colB.AllowNull);
			}
		}
		private object m_defaultValueAtoB = DBNull.Value;
		public object DefaultValueAtoB
		{
			get
			{
				if (m_defaultValueAtoB == null)
					return DBNull.Value;
				return m_defaultValueAtoB;
			}
			set
			{
				if (value == null)
					m_defaultValueAtoB = DBNull.Value;
				else
					m_defaultValueAtoB = value;
			}
		}

		public CResultAErreur VerifMappage()
		{
			CResultAErreur result = CResultAErreur.True;
			if (ColonneB == null)
			{
                result.EmpileErreur(I.T("No target column is defined|30008"));
				return result;
			}


			if (ColonneA != null && ColonneA.TypeDonneeChamp != null
				&& ColonneB.TypeDonneeChamp != null
				&& ColonneA.TypeDonneeChamp.TypeDotNetAssocie != ColonneB.TypeDonneeChamp.TypeDotNetAssocie)
			{
				result.EmpileErreur(I.T("The column @1 has a different type from the column @2 (@3 <> @4)|30000",ColonneA.Libelle, ColonneB.Libelle, ColonneA.TypeDonneeChamp.Libelle, ColonneB.TypeDonneeChamp.Libelle));
				return result;
			}

			if (NeedDefaultValueAtoB)
			{
				if (ColonneA == null)
				{
					if (DefaultValueAtoB == DBNull.Value && !ColonneB.AllowNull)
						result.EmpileErreur(I.T("The column @1 doesn't accept null values|30001", ColonneB.Libelle));
					else if (DefaultValueAtoB != DBNull.Value && !TypeUtilise.IsAssignableFrom(DefaultValueAtoB.GetType()))
						result.EmpileErreur(I.T("Default value '@1' cannot be converted in type @2|30011", DefaultValueAtoB.ToString(), LabelTypeUtilise));
				}
				else
				{
					if (DefaultValueAtoB == DBNull.Value && !ColonneB.AllowNull)
						result.EmpileErreur(new CErreurValidation(I.T("Warning: the @1 column supports null values but the target column @2 cannot support them and the default value is NULL: lines are not likely to be able to be imported|30013", ColonneA.Libelle, ColonneB.Libelle), true));
					else if (DefaultValueAtoB != DBNull.Value && !TypeUtilise.IsAssignableFrom(DefaultValueAtoB.GetType()))
						result.EmpileErreur(new CErreurValidation(I.T("Warning: the @1 column supports null value but the target column @2 cannot support them and default value is not a @3 type : lines are not likely to be able to be imported|30014", ColonneA.Libelle, ColonneB.Libelle, LabelTypeUtilise), true));
				}
			}
			else
			{
				if (ColonneA.AllowNull)
				{
					if(DefaultValueAtoB != DBNull.Value && !TypeUtilise.IsAssignableFrom(DefaultValueAtoB.GetType()))
					{
						result.EmpileErreur(new CErreurValidation(I.T("Default value '@1' cannot be converted in @2 type|30011", DefaultValueAtoB.ToString(), LabelTypeUtilise), true));
					}
				}
			}

			return result;
		}


		private Type TypeUtilise
		{
			get
			{
				if (ColonneA != null && ColonneA.TypeDonneeChamp != null)
					return ColonneA.TypeDonneeChamp.TypeDotNetAssocie;
				else if (ColonneB != null && ColonneB.TypeDonneeChamp != null)
					return ColonneB.TypeDonneeChamp.TypeDotNetAssocie;
				else
					return null;
			}
		}
		private string LabelTypeUtilise
		{
			get
			{
				if (ColonneA != null && ColonneA.TypeDonneeChamp != null)
					return ColonneA.TypeDonneeChamp.Libelle;
				else if (ColonneB != null && ColonneB.TypeDonneeChamp != null)
					return ColonneB.TypeDonneeChamp.Libelle;
				else
					return "";
			}
		}
	}
}
