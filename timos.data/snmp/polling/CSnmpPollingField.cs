using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

using tiag.client;

using timos.data;
using timos.data.snmp.polling;
using data.hotel.client;

namespace timos.snmp.polling
{
	/// <summary>
	/// Permet de définir des champs pour le polling. Chaque champ est par la suite
    /// paramétré sur les types d'entités SNMP pour définir comment la valeur
    /// est obtenue à partir des OID de l'agent
	/// </summary>
    [DynamicClass("Snmp polling field")]
	[Table(CSnmpPollingField.c_nomTable, CSnmpPollingField.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CSnmpPollingFieldServeur")]
	public class CSnmpPollingField : CObjetDonneeAIdNumeriqueAuto,
		IObjetALectureTableComplete
	{
		public const string c_nomTable = "SNMP_POLLING_FIELD";
		public const string c_champId = "SNPOFL_ID";
		public const string c_champNom = "SNPOFL_NAME";
        public const string c_champDescription = "SNPOFL_DESC";
        public const string c_champHotelTable = "SNPOFL_HOT_TABLE";
        public const string c_champHotelCol = "SNPOFL_HOT_COL";

		/// /////////////////////////////////////////////
		public CSnmpPollingField( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CSnmpPollingField(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Snmp polling field : @1|20253",Nom);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champNom};
		}


		

		/// <summary>
		/// Nom du champ (unique)
		/// </summary>
		[TableFieldProperty(c_champNom, 128)]
		[DynamicField("Name")]
		public string Nom
		{
			get
			{
				return (string)Row[c_champNom];
			}
			set
			{
				Row[c_champNom] = value;
			}
		}

        /// <summary>
        /// La description du champ
        /// </summary>
		[TableFieldProperty(c_champDescription, 1024)]
        [DynamicField("Description")]
        public string Description
        {
            get
            {
                return (string)Row[c_champDescription];
            }
            set
            {
                Row[c_champDescription] = value;
            }
        }

        /// <summary>
        /// Le nom de la table Hotel destinée à recevoir cette colonne
        /// </summary>
        [TableFieldProperty(c_champHotelTable, 256)]
        [DynamicField("Hotel table Id")]
        public string HotelTableId
        {
            get
            {
                return (string)Row[c_champHotelTable];
            }
            set
            {
                Row[c_champHotelTable] = value;
            }
        }

        /// <summary>
        /// Le nom de la Colonne de la table Hotel destinée à recevoir cette colonne
        /// </summary>
        [TableFieldProperty(c_champHotelCol, 256)]
        [DynamicField("Hotel column Id")]
        public string HotelColumnId
        {
            get
            {
                return (string)Row[c_champHotelCol];
            }
            set
            {
                Row[c_champHotelCol] = value;
            }
        }

        //-----------------------------------------
        [DynamicField("Hotel table name")]
        public string HotelTableName
        {
            get
            {
                foreach (DataTable table in CSnmpPollingHotelClient.GetDefinitionsTablesFromHotel())
                    if (table.ExtendedProperties[CDataHotelTable.c_extPropTableId] == HotelTableId)
                        return table.TableName;
                return "";
            }
        }

        //-----------------------------------------
        [DynamicField("Hotel Column name")]
        public string HotelColumnName
        {
            get
            {
                foreach (DataTable table in CSnmpPollingHotelClient.GetDefinitionsTablesFromHotel())
                    if (table.ExtendedProperties[CDataHotelTable.c_extPropTableId] == HotelTableId)
                    {
                        foreach (DataColumn col in table.Columns)
                        {
                            if (col.ExtendedProperties[CDataHotelField.c_extPropColumnId] == HotelColumnId)
                                return col.ColumnName;
                        }
                        return "";
                    }
                return "";
            }
        }


	}
}
