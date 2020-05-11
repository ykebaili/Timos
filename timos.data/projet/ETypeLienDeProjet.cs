using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using sc2i.data;
using sc2i.common;
using sc2i.process;
using sc2i.multitiers.client;

using sc2i.data.dynamic;
using sc2i.common.planification;

using timos.securite;
using timos.acteurs;


namespace timos.data
{


	public enum ETypeAttacheLienDeProjet
	{ 
		Debut = 0,
		Fin = 10,
	}
	public class CTypeAttacheLienDeProjet : CEnumALibelle<ETypeAttacheLienDeProjet>
	{
		/// //////////////////////////////////////////////////////
		public CTypeAttacheLienDeProjet(ETypeAttacheLienDeProjet ope)
			: base(ope)
		{
		}

		/// //////////////////////////////////////////////////////
		public override string Libelle
		{
			get
			{
				string result = "";
				switch (Code)
				{
					case ETypeAttacheLienDeProjet.Debut:
						result = I.T("Start|70");
						break;
					case ETypeAttacheLienDeProjet.Fin:
						result = I.T("End|71");
						break;
				}

				return result;

			}
		}

		public static implicit operator CTypeAttacheLienDeProjet(ETypeAttacheLienDeProjet valEnum)
		{
			return new CTypeAttacheLienDeProjet(valEnum);
		}

	}


	public enum ETypeLienDeProjet
	{
		DemarrentEnMemeTemps = 0,
		FinissentEnMemeTemps = 10,
		ElementADemarreQuandElementBTermine = 30,
		ElementBDemarreQuandElementATermine = 40,

	}

	public class CTypeLienDeProjet : CEnumALibelleB<ETypeLienDeProjet,CTypeLienDeProjet>
	{
		/// //////////////////////////////////////////////////////
		public CTypeLienDeProjet(ETypeLienDeProjet ope)
			: base(ope)
		{
		}

		/// //////////////////////////////////////////////////////
		public override string Libelle
		{
			get
			{
				string result = "";
				switch (Code)
				{
					case ETypeLienDeProjet.DemarrentEnMemeTemps:
						result = I.T( "Start at the same time|458");
						break;
					case ETypeLienDeProjet.FinissentEnMemeTemps:
						result = I.T( "Finish at the same time|459");
						break;
					case ETypeLienDeProjet.ElementADemarreQuandElementBTermine:
						result = I.T( "A element starts when element B finishes|461");
						break;
					case ETypeLienDeProjet.ElementBDemarreQuandElementATermine:
						result = I.T( "B element starts when element A finishes|462");
						break;
					default:
						break;
				}

				return result;
			
			}
		}

		public static implicit operator CTypeLienDeProjet(ETypeLienDeProjet valEnum)
		{
			return new CTypeLienDeProjet(valEnum);
		}

	}



	/// <summary>
	/// Opérations sur enums. Tres utile pour les combobox
	/// </summary>
	public abstract class CUtilSurEnum2
	{
		public class CCoupleEnumLibelle
		{
			private int m_nValeur;
			private string m_strLibelle;
			public CCoupleEnumLibelle(int nValeur, string strLibelle)
			{
				m_nValeur = nValeur;
				m_strLibelle = strLibelle;
			}

			public override string ToString()
			{
				return m_strLibelle; ;
			}

			public override bool Equals(object obj)
			{
				if (obj is int)
					return Valeur == (int)obj;
				if (obj is CCoupleEnumLibelle)
					return Valeur == ((CCoupleEnumLibelle)obj).Valeur;
				return false;
			}

			public override int GetHashCode()
			{
				return m_strLibelle.GetHashCode() + Valeur;
			}

			/// ////////////////////////////
			[DescriptionField]
			public string Libelle
			{
				get
				{
					return m_strLibelle;
				}
			}

			/// ////////////////////////////
			public int Valeur
			{
				get
				{
					return m_nValeur;
				}
			}

		}
		/// <summary>
		/// Isole les mots dans le nom d'enum grâce aux majuscules
		/// et insère des espaces entre eux
		/// </summary>
		/// <param name="strNomEnum"></param>
		/// <returns></returns>

		public static string GetNomConvivial(string strNomEnum)
		{
			string strNomConvivial = "";
			foreach (char car in strNomEnum.ToCharArray())
			{
				if (strNomConvivial == "")
					strNomConvivial += car;
				else
				{
					if (car >= 'A' && car <= 'Z')
						strNomConvivial += " ";
					strNomConvivial += car;
				}
			}
			return strNomConvivial;
		}

		public static CCoupleEnumLibelle[] GetCouplesFromEnum(Type enumType)
		{
			if (!enumType.IsEnum)
				return new CCoupleEnumLibelle[0];
			ArrayList lstCouple = new ArrayList();
			foreach (int nVal in Enum.GetValues(enumType))
			{
				lstCouple.Add(new CCoupleEnumLibelle(nVal, GetNomConvivial(Enum.GetName(enumType, nVal))));
			}
			return (CCoupleEnumLibelle[])lstCouple.ToArray(typeof(CCoupleEnumLibelle));
		}

		[DynamicField("Code")]
		public abstract int CodeInt { get;set;}

		[DynamicField("Label")]
		public abstract string Libelle { get;}
	}

	public class CEnumALibelleB<TmonTypeEnum, TmonTypeCEnumALibelle> : CUtilSurEnum2, IComparable
		where TmonTypeEnum : struct, IComparable
		where TmonTypeCEnumALibelle : CEnumALibelleB<TmonTypeEnum, TmonTypeCEnumALibelle>
	{
		/// //////////////////////////////////////////////////////
		private TmonTypeEnum m_valeurEnum;

		/// //////////////////////////////////////////////////////
		public CEnumALibelleB(TmonTypeEnum statut)
		{
			m_valeurEnum = statut;
		}

		public override string Libelle
		{
			get
			{
				return Code.ToString();
			}
		}

		/// //////////////////////////////////////////////////////
		public override string ToString()
		{
			return Libelle;
		}

		//---------------------------------------------------------------------
        /// <summary>
        /// Code du type de lien entre projets
        /// </summary>
		[DynamicField("Code")]
		public override int CodeInt
		{
			get
			{
				return Convert.ToInt32(m_valeurEnum);
			}
			set
			{
				m_valeurEnum = (TmonTypeEnum)(object)value;// Convert.ChangeType(value, m_statut.GetType());
			}
		}

		/// //////////////////////////////////////////////////////
		public TmonTypeEnum Code
		{
			get
			{
				return m_valeurEnum;
			}
			set
			{
				m_valeurEnum = value;
			}
		}

		/// //////////////////////////////////////////////////////
		public override bool Equals(object obj)
		{
			if (obj != null && obj.GetType() == GetType())
				return ((CUtilSurEnum2)obj).CodeInt.Equals(CodeInt);
			return false;
		}

		/// //////////////////////////////////////////////////////
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public static CUtilSurEnum2[] GetEnumsALibelle(Type tp)
		{
			ArrayList lst = new ArrayList();
			foreach (TmonTypeEnum statut in Enum.GetValues(typeof(TmonTypeEnum)))
			{
				lst.Add(Activator.CreateInstance(tp, new object[] { statut }));
			}
			return (CUtilSurEnum2[])lst.ToArray(typeof(CUtilSurEnum2));
		}

		public static implicit operator TmonTypeEnum(CEnumALibelleB<TmonTypeEnum, TmonTypeCEnumALibelle> valeur)
		{
			return valeur.Code;
		}
		public static implicit operator CEnumALibelleB<TmonTypeEnum, TmonTypeCEnumALibelle>(TmonTypeEnum valeur)
		{
			return (TmonTypeCEnumALibelle)Activator.CreateInstance(typeof(TmonTypeCEnumALibelle), new object[] { valeur });
		}

		public int CompareTo(object obj)
		{
			if (obj == null)
				return -1;
			if (obj.GetType() != GetType())
				return -1;
			return ((CUtilSurEnum2)obj).CodeInt.CompareTo(CodeInt);
		}
	}
}
