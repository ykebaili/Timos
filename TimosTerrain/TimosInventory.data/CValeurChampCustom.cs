using System;

using sc2i.common;
using sc2i.data;
using sc2i.common.memorydb;
using sc2i.expression;

namespace TimosInventory.data
{
	/// <summary>
	/// Indique une valeur possible pour un <see cref="CChampCustom">Champ personnalis�</see>
	/// </summary>
    /// <remarks>
    /// Chaque valeur possible de champ calcul� g�n�re une entit� de ce type.
    /// <p>Chaque valeur possible est un couple 'valeur stock�e'/'valeur affich�e'. La valeur affich�e sera 
    /// pr�sent�e aux utilisateurs finaux, alors que la valeur stock�e indique ce qui sera stock�
    /// dans la base de donn�es. La s�paration des donn�es stock�es / affich�es offre une plus grande
    /// souplesse dans l'�volution du param�trage.</p>
    /// <p>Les valeurs stock�es possibles sont toujours stock�es sous forme de texte, converties par le programme
    /// en une donn�e compatible avec le type de donn�es du champ concern�</p>
    /// </remarks>
    [MemoryTable(CValeurChampCustom.c_nomTable, CValeurChampCustom.c_champId)]
	public class CValeurChampCustom : CEntiteLieeATimos
	{
		#region D�claration des constantes
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
		/// Valeur stock�e sous forme de texte
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
		/// Valeur stock�e au format du champ
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
		/// Valeur affich�e
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
		/// Champ personnalis� auquel se rapporte cette valeur possible
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
