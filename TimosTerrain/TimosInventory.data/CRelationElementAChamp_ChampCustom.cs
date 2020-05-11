using System;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.common.unites;
using sc2i.common.memorydb;
using sc2i.expression;


namespace TimosInventory.data
{
   
	/// <summary>
	/// Description résumée de CRelationElementAChamp_ChampCustom.
	/// </summary>
    /// <seealso cref="CChampCustom"/>
	public abstract class CRelationElementAChamp_ChampCustom : CEntiteDeMemoryDbAIdAuto
	{
		public const string c_champValeurInt = "FIELD_VALUE_INT";
		public const string c_champValeurString = "FIELD_VALUE_STRING";
		public const string c_champValeurDouble = "FIELD_VALUE_DOUBLE";
		public const string c_champValeurDate = "FIELD_VALUE_DATE";
		public const string c_champValeurBool = "FIELD_VALUE_BOOL";
		public const string c_champValeurNull = "FIELD_VALUE_IS_NULL";

		//-------------------------------------------------------------------
#if PDA
		public CRelationElementAChamp_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationElementAChamp_ChampCustom(CMemoryDb db)
			:base(db)
		{
		}
		//-------------------------------------------------------------------
		public CRelationElementAChamp_ChampCustom(DataRow row)
			:base(row)
		{
		}

			
		//-------------------------------------------------------------------
		public override void MyInitValeursParDefaut()
		{
		}

		//-------------------------------------------------------------------
		public abstract IElementAChamps ElementAChamps{get;set;}

		//-------------------------------------------------------------------
		public abstract Type GetTypeElementAChamps();

		/// ///////////////////////////////////////////////////////

		//-------------------------------------------------------------------
		public virtual object GetValeur (  )
		{
			if ( ChampCustom == null )
				return "";
			if ( IsNull )
				return null;
			try
			{
				switch ( ChampCustom.TypeDonnee)
				{
					case ETypeChampBasique.Bool :
						return (bool)Row[c_champValeurBool];
					case ETypeChampBasique.Date :
						return (DateTime)Row[c_champValeurDate];
                    case ETypeChampBasique.Decimal:
                        return (double)Row[c_champValeurDouble];
					case ETypeChampBasique.Int :
						return (int)Row[c_champValeurInt];
					case ETypeChampBasique.String:
						return (string)Row[c_champValeurString];
				}
			}
			catch
			{
			}
			return null;
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Valeur du champ. Il n'est pas possible de réaliser un filtre sur ce champ. POur filtrer, il faut utiliser le champ stockant la donnée typée
		/// </summary>
        [DynamicField("Value")]
        public virtual object Valeur
        {
            get
            {
                return GetValeur();
            }
            set
            {
                if (value == null || value == DBNull.Value)
                {
                    IsNull = true;
                    ValeurString = "";
                    ValeurInt = -1;
                    ValeurBool = false;
                    ValeurDouble = 0;
                    return;
                }

                ETypeChampBasique tp = ETypeChampBasique.String;
                if (ChampCustom != null)
                    tp = ChampCustom.TypeDonnee;
                IsNull = false;
                switch (tp)
                {
                    case ETypeChampBasique.Int:
                        try
                        {
                            ValeurInt = Convert.ToInt32(value);
                        }
                        catch
                        {
                            ValeurInt = 0;
                        }
                        break;
                    case ETypeChampBasique.Decimal:
                        try
                        {
                            ValeurDouble = Convert.ToDouble(value);
                        }
                        catch
                        {
                            ValeurDouble = 0;
                        }
                        break;
                    case ETypeChampBasique.String :
                        ValeurString = value.ToString();
                        break;
                    case ETypeChampBasique.Date:
                        try
                        {
                            if (value is CDateTimeEx)
                                ValeurDate = ((CDateTimeEx)value).DateTimeValue;
                            else if (value is DateTime)
                                ValeurDate = (DateTime)value;
                            else
                                ValeurDate = DateTime.Now;
                        }
                        catch
                        {
                            ValeurDate = DateTime.Now;
                        }
                        break;
                    case ETypeChampBasique.Bool:
                        try
                        {
                            ValeurBool = Convert.ToBoolean(value);
                        }
                        catch
                        {
                            ValeurBool = value.ToString() == "1";
                        }
                        break;
                }
            }

        }


		//-------------------------------------------------------------------
		/// <summary>
		/// Valeur du champ si le champ est un champ texte
		/// </summary>
        [MemoryField(c_champValeurString)]
        [DynamicField("String value")]
		public string ValeurString
		{
			get
			{
				return (string)Row[c_champValeurString];
			}
			set
			{
				Row[c_champValeurString] = value;
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Valeur du champ si le champ est un champ entier
		/// </summary>
        [MemoryField(c_champValeurInt)]
        [DynamicField("Int value")]
		public int ValeurInt
		{
			get
			{
				return (int)Row[c_champValeurInt];
			}
			set
			{
				Row[c_champValeurInt] = value;
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Valeur du champ si le champ est un champ décimal
		/// </summary>
        [MemoryField(c_champValeurDouble)]
        [DynamicField("Decimal value")]
		public double ValeurDouble
		{
			get
			{
				return (double)Row[c_champValeurDouble];
			}
			set
			{
				Row[c_champValeurDouble] = value;
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Valeur du champ si le champ est un champ date
		/// </summary>
        [MemoryField(c_champValeurDate)]
        [DynamicField("Date value")]
		public DateTime ValeurDate
		{
			get
			{
				return (DateTime)Row[c_champValeurDate];
			}
			set
			{
				Row[c_champValeurDate] = value;
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Valeur du champ si le champ est un booléen
		/// </summary>
        [MemoryField(c_champValeurBool)]
        [DynamicField("Bool value")]
		public bool ValeurBool
		{
			get
			{
				return (bool)Row[c_champValeurBool];
			}
			set
			{
				Row[c_champValeurBool] = value;
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Indique si le champ a une valeur nulle.
		/// </summary>
        [MemoryField(c_champValeurNull)]
        [DynamicField("Is null")]
		public bool IsNull
		{
			get
			{
				return (bool)Row[c_champValeurNull];
			}
			set
			{
				Row[c_champValeurNull] = value;
			}
		}

		
		//-------------------------------------------------------------------
		/// <summary>
		/// Champ personnalisé auquel correspond cette valeur.
		/// </summary>
        [MemoryParent(false)]
		[DynamicField("Custom Field")]
		public CChampCustom ChampCustom
		{
			get
			{
                return GetParent<CChampCustom>();
			}
			set
			{
                SetParent<CChampCustom>(value);
			}
		}

        //-------------------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-------------------------------------------------------------------
        protected override CResultAErreur MySerialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = SerializeChamps(serializer, c_champValeurBool, c_champValeurDate, c_champValeurDouble, c_champValeurInt,
                c_champValeurNull, c_champValeurString);
            if (result)
                result = SerializeParent<CChampCustom>(serializer);
            return result;
        }

	}
}
