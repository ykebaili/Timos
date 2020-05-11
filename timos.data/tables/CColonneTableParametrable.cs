using System;
using System.Collections;
using System.Data;

using System.Collections.Generic;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;

namespace timos.data
{
    /// <summary>
    /// Colonne de <see cref="CTableParametrable">table paramétrable</see>
    /// </summary>
	[DynamicClass("Custom Column Table")]
	[Table(CColonneTableParametrable.c_nomTable, CColonneTableParametrable.c_champId, true)]
	[ObjetServeurURI("CColonneTableParametrableServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_TablesParam_ID)]
    public class CColonneTableParametrable : CObjetDonneeAIdNumeriqueAuto
	{
		public const string c_nomTable = "CUSTOM_TABLE_COLUMN";

		public const string c_champId = "COL_ID";
		public const string c_champLibelle = "COL_LABEL";

		public const string c_champAllowNull = "COL_NULL";
		public const string c_champLargeurCol = "COL_WIDTH";

		public const string c_champPosition = "COL_POS";
		public const string c_champType = "COL_TYPEDONNEE";

		public const string c_champPKId = "COL_PKID";


		/// /////////////////////////////////////////////
		public CColonneTableParametrable(CContexteDonnee contexte)
			: base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CColonneTableParametrable(DataRow row)
			: base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get { return I.T( "Custom Table column @1|438",Libelle); }
		}


		public override string ToString()
		{
			return Libelle;
		}

		/// <summary>
		/// Libellé de la colonne<br/>
		/// (obligatoire).<br/>
        /// Doit être unique dans le type de table correspondant.
		/// </summary>
		[TableFieldProperty(c_champLibelle, 30)]
		[DynamicField("Label")]
		public string Libelle
		{
			get { return (string)Row[c_champLibelle]; }
			set { Row[c_champLibelle] = value; }
		}

		/// <summary>
		/// Indique si la colonne autorise ou non le Null,<br/>
        /// pour les données contenues au niveau des tables de ce type.<br/>
		/// (obligatoire)
		/// </summary>
		[TableFieldProperty(c_champAllowNull)]
		[DynamicField("Allow Null")]
		public bool AllowNull
		{
			get 
			{
				if (IsPrimaryKey)
					return false;
				return (bool)Row[c_champAllowNull]; 
			}
			set { Row[c_champAllowNull] = value; }
		}

		//----------------------------------------------------------------
        /// <summary>
        /// Type de la donnée pour cette colonne
        /// </summary>
		[DynamicField("Type")]
		public C2iTypeDonnee TypeDonneeChamp
		{
			get
			{
				return new C2iTypeDonnee((TypeDonnee)Row[c_champType], null);
			}
			set
			{
				Row[c_champType] = (int)value.TypeDonnee;
			}
		}

		////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champType)]
		public int TypeDonneeInt
		{
			get
			{
				return (int)Row[c_champType];
			}
			set
			{
				Row[c_champType] = (int)value;
			}
		}
		

        /// <summary>
        /// Rang (index) de la colonne dans la liste des colonnes,<br/>
        /// pour le type de table correspondant; commence à 0.
        /// </summary>
		[TableFieldProperty(c_champPosition, 30)]
		[DynamicField("Position")]
		public int Position
		{
			get { return (int)Row[c_champPosition]; }
			set { Row[c_champPosition] = value; }
		}

        /// <summary>
        /// Indique si la colonne fait partie de la clé primaire,<br/>
        /// pour le type de table correspondant
        /// </summary>
		[DynamicField("Is Primary Key")]
		public bool IsPrimaryKey
		{
			get
			{
				return PrimaryKeyPosition != null;
			}
		}

        /// <summary>
        /// Rang (index) de la colonne dans la clé primaire<br/>
        /// pour le type de table correspondant. Commence à 0.<br/>
        /// Si la colonne ne fait pas partie de la clé primaire,<br/>
        /// renvoie nul.
        /// </summary>
		[TableFieldProperty(c_champPKId, 30, NullAutorise = true)]
		[DynamicField("Primary Key Id")]
		public int? PrimaryKeyPosition
		{
			get 
			{
				if (Row[c_champPKId] == DBNull.Value)
					return null;
				else
					return (int?)Row[c_champPKId]; 
			}
			set 
			{
				if(value == null)
					Row[c_champPKId] = DBNull.Value; 
				else
					Row[c_champPKId] = value; 
			}
		}

        /// <summary>
        /// Largeur de la colonne (en nombre de pixels),<br/>
        /// telle qu'on souhaite la voir s'afficher pour une table,<br/>
        /// du type de table correspondant.
        /// </summary>
		[TableFieldProperty(c_champLargeurCol, 30)]
		[DynamicField("Column width")]
		public int LargeurColonne
		{
			get { return (int)Row[c_champLargeurCol]; }
			set { Row[c_champLargeurCol] = value; }
		}

        /// <summary>
        /// Type de table paramétrable auquel cette colonne appartient
        /// </summary>
		[RelationAttribute(
		  CTypeTableParametrable.c_nomTable,
		   CTypeTableParametrable.c_champId,
		   CTypeTableParametrable.c_champId,
			true,
			true,
			false)]
		[DynamicField("Custom Table Type")]
		public CTypeTableParametrable TypeTable
		{
			get { return (CTypeTableParametrable)GetParent(CTypeTableParametrable.c_champId, typeof(CTypeTableParametrable)); }
			set { SetParent(CTypeTableParametrable.c_champId, value); }
		}


		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			AllowNull = true;
			LargeurColonne = 100;

		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] { c_champPosition };
		}

		public DataColumn GetDataColumn()
		{
			DataColumn dt = new DataColumn(Libelle);
			dt.DataType = TypeDonneeChamp.TypeDotNetAssocie;
			dt.AllowDBNull = AllowNull;
			return dt;
		}

	}
}
