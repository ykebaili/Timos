using System;

using sc2i.common;
using sc2i.data;
using sc2i.common.memorydb;
using sc2i.expression;

namespace TimosInventory.data
{
	/// <summary>
	/// Indique une valeur possible pour un <see cref="CChampCustom">Champ personnalisé</see>
	/// </summary>
    /// <remarks>
    /// Chaque valeur possible de champ calculé génère une entité de ce type.
    /// <p>Chaque valeur possible est un couple 'valeur stockée'/'valeur affichée'. La valeur affichée sera 
    /// présentée aux utilisateurs finaux, alors que la valeur stockée indique ce qui sera stocké
    /// dans la base de données. La séparation des données stockées / affichées offre une plus grande
    /// souplesse dans l'évolution du paramétrage.</p>
    /// <p>Les valeurs stockées possibles sont toujours stockées sous forme de texte, converties par le programme
    /// en une donnée compatible avec le type de données du champ concerné</p>
    /// </remarks>
    [MemoryTable(CValeurChampCustom.c_nomTable, CValeurChampCustom.c_champId)]
	public class CValeurChampCustom : CEntiteLieeATimos
	{
		#region Déclaration des constantes
		public const string c_nomTable = "CUSTOM_FIELD_VALUE";
		public const string c_champId = "CUFLD_ID";
		public const string c_champValue = "CUFLD_VALUE";
		public const string c_champDisplay = "CUFLD_DISPLAY";
        public const string c_champIndex = "CUFLD_INDEX";
		#endregion
		/// <summary>
		/// /////////////////////////////////////////////////////////
		/// </summary>
		/// <param name="ctx"></param>
		public CValeurChampCustom( CMemoryDb db)
			:base ( db )
		{
			
		}

		/// /////////////////////////////////////////////////////////
		public CValeurChampCustom ( System.Data.DataRow row )
			:base ( row )
		{
		}

		/// /////////////////////////////////////////////////////////
		public override void MyInitValeursParDefaut()
		{
			Value = "";
		}

		/// ///////////////////////////////////////////////////////
		public override string GetChampId()
		{
			return c_champId;
		}


		////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return c_nomTable;
		}


		
		////////////////////////////////////////////////////////////
		/// <summary>
		/// Valeur stockée sous forme de texte
		/// </summary>
        [MemoryField(c_champValue)]
        [DynamicField("String value")]
		public string ValueString
		{
			get
			{
				return (string)Row[c_champValue];
			}
			set
			{
				Row[c_champValue] = value;
			}
		}

        ////////////////////////////////////////////////////////////
        [MemoryField(c_champIndex)]
        [DynamicField("Index")]
        public int Index
        {
            get
            {
                return (int)Row[c_champIndex];
            }
            set
            {
                Row[c_champIndex] = value;
            }
        }

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Valeur stockée au format du champ
		/// </summary>
        [DynamicField("Stored value")]
		public object Value
		{
			get
			{
				return new CTypeChampBasique(ChampCustom.TypeDonnee).StringToType(ValueString);
			}
			set
			{
				ValueString = CTypeChampBasique.TypeToString ( value );
			}
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Valeur affichée
		/// </summary>
        [
		MemoryField(c_champDisplay),
		DynamicField("Displayed value")
		]
		public string Display
		{
			get
			{
				return (string)Row[c_champDisplay];
			}
			set
			{
				Row[c_champDisplay] = value.Trim();
			}
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Champ personnalisé auquel se rapporte cette valeur possible
		/// </summary>
        [MemoryParent(true)]
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

		////////////////////////////////////////////////////////////
        //-----------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-----------------------------------------
        protected override CResultAErreur MySerialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = SerializeChamps(serializer,
                c_champIdTimos, 
                c_champValue, 
                c_champDisplay,
                c_champIndex);
            if (result)
                result = SerializeParent<CChampCustom>(serializer);
            return result;
        }
	}
}
