using System;

using sc2i.common;
using sc2i.common.unites;
using sc2i.expression;
using TimosInventory.data;

namespace sc2i.data.dynamic
{
	/// <summary>
	/// Description résumée de CObjetForTestValeurChampCustom.
	/// </summary>
	public class CObjetForTestValeurChampCustom
	{
		/// ///////////////////////////////////////////////////////////////////////////////////////
		public static object GetNewFor ( CChampCustom champ, object valeur )
		{
			return GetNewForTypeDonnee ( champ.TypeDonnee, valeur );
		}

		/// <summary>
		/// ///////////////////////////////////////////////////////////////////////////////////////
		/// </summary>
		/// <param name="typeDonnee"></param>
		/// <returns></returns>
		public static object GetNewForTypeDonnee(ETypeChampBasique typeDonnee, object valeur)
		{
			object objTest = null;
			switch ( typeDonnee )
			{
				case ETypeChampBasique.Bool :
					if ( valeur == null )
						objTest = new CObjetForTestValeurChampCustomBool ( );
					else
						objTest = new CObjetForTestValeurChampCustomBool ( (bool)Convert.ChangeType(valeur, typeof(bool), null));
					break;
				case ETypeChampBasique.Date :
					if ( valeur == null )
						objTest = new CObjetForTestValeurChampCustomDateTime ( );
					else
						objTest = new CObjetForTestValeurChampCustomDateTime ( (DateTime)Convert.ChangeType(valeur, typeof(DateTime), null));
					break;
				case ETypeChampBasique.Decimal :
					if ( valeur == null )
						objTest = new CObjetForTestValeurChampCustomDouble ( );
					else
						objTest = new CObjetForTestValeurChampCustomDouble ( (double)Convert.ChangeType(valeur, typeof(double), null));
					break;
				case ETypeChampBasique.Int :
					if ( valeur == null )
						objTest = new CObjetForTestValeurChampCustomInt ( );
					else
						objTest = new CObjetForTestValeurChampCustomInt ( (int)Convert.ChangeType(valeur, typeof(int), null));
						
					break;
				case ETypeChampBasique.String:
					if ( valeur == null )
						objTest = new CObjetForTestValeurChampCustomString();
					else
						objTest = new CObjetForTestValeurChampCustomString(valeur.ToString());
					break;
			}
			return objTest;
		}
	}

	/// <summary>
	/// ////////////////////////////////////////////////////////////////////////////
	/// </summary>
	public class CObjetForTestValeurChampCustomString : CObjetForTestValeurChampCustom
	{
		string m_strValeur = "";
		public CObjetForTestValeurChampCustomString()
		{
			m_strValeur = "";
		}

		public CObjetForTestValeurChampCustomString(string strValeur)
		{
			m_strValeur = strValeur;
		}

		[DynamicFieldAttribute("Value")]
		public string Valeur
		{
			get
			{
				return m_strValeur;
			}
		}
	}

	/// <summary>
	/// ////////////////////////////////////////////////////////////////////////////
	/// </summary>
	public class CObjetForTestValeurChampCustomInt : CObjetForTestValeurChampCustom
	{
		private int? m_nValeur;

		public CObjetForTestValeurChampCustomInt()
		{
			m_nValeur = null;
		}

		public CObjetForTestValeurChampCustomInt(int nValeur)
		{
			m_nValeur = nValeur;
		}

		[DynamicFieldAttribute("Value")]
		public int? Valeur
		{
			get
			{
				return m_nValeur;
			}
		}
	}

	/// <summary>
	/// ////////////////////////////////////////////////////////////////////////////
	/// </summary>
	public class CObjetForTestValeurChampCustomDouble : CObjetForTestValeurChampCustom
	{
		private double? m_fValeur;

		public CObjetForTestValeurChampCustomDouble()
		{
			m_fValeur = null;
		}
		public CObjetForTestValeurChampCustomDouble(double fValeur)
		{
			m_fValeur = fValeur;
		}

		[DynamicFieldAttribute("Value")]
		public double? Valeur
		{
			get
			{
				return m_fValeur;
			}
		}
	}

	/// <summary>
	/// ////////////////////////////////////////////////////////////////////////////
	/// </summary>
	public class CObjetForTestValeurChampCustomBool : CObjetForTestValeurChampCustom
	{
		private bool m_bValeur;

		public CObjetForTestValeurChampCustomBool()
		{
			m_bValeur = false;
		}
		public CObjetForTestValeurChampCustomBool(bool bValeur)
		{
			m_bValeur = bValeur;
		}

		[DynamicFieldAttribute("Value")]
		public bool Valeur
		{
			get
			{
				return m_bValeur;
			}
		}
	}

	/// <summary>
	/// ////////////////////////////////////////////////////////////////////////////
	/// </summary>
	public class CObjetForTestValeurChampCustomDateTime : CObjetForTestValeurChampCustom
	{
		private DateTime? m_dtValeur;

		public CObjetForTestValeurChampCustomDateTime()
		{
			m_dtValeur = null;
		}
		public CObjetForTestValeurChampCustomDateTime(DateTime dtValeur)
		{
			m_dtValeur = dtValeur;
		}

		[DynamicFieldAttribute("Value")]
		public DateTime? Valeur
		{
			get
			{
				return m_dtValeur;
			}
		}
	}

	
}
