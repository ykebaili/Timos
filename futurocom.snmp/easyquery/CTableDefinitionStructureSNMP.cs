﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using futurocom.easyquery;
using System.Data;
using futurocom.snmp;
using futurocom.snmp.Mib;
using sc2i.common;

namespace futurocom.easyquery.snmp
{
    [Serializable]
    public class CTableDefinitionStructureSNMP : CTableDefinitionBaseDonneesFixes
    {
        public const string c_strColumnOID = "systemOID";
        public const string c_strColumnName=  "systemName";
        public const string c_strColumnType = "systemType";

       
        //-----------------------------------------
        public CTableDefinitionStructureSNMP()
            : base()
        {
            AddColumn ( new CColumnDefinitionSimple ( c_strColumnOID, typeof(string)));
            AddColumn ( new CColumnDefinitionSimple ( c_strColumnName, typeof(string)));
            AddColumn ( new CColumnDefinitionSimple ( c_strColumnType, typeof(string)));
        }

        //-----------------------------------
        public override string Id
        {
            get
            {
                return "SNMP_OID_STRUCTURE_TABLE";
            }
        }

        //-----------------------------------
        public override string TableName
        {
            get
            {
                return "SNMP_OID_STRUCTURE";
            }
            set
            {
            }
        }

        //-----------------------------------------
        public void Fill(IDefinition rootDefinition)
        {
            AssureTable();
            foreach (IDefinition def in rootDefinition.Children)
            {
                FillTable(def);
            }
        }

        //-----------------------------------------
        private void FillTable(IDefinition definition)
        {
            AssureTable();
            if (TableContenu == null)
                return;
            DataRow row = TableContenu.NewRow();
            row[c_strColumnOID] = ObjectIdentifier.Convert(definition.GetNumericalForm());
            row[c_strColumnName] = definition.Name;
            row[c_strColumnType] = definition.Type.ToString();
            TableContenu.Rows.Add(row);
            foreach (IDefinition child in definition.Children)
                FillTable(child);
        }

        //-----------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-----------------------------------------
        public override CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (result)
                result = base.Serialize(serializer);
            if (!result)
                return result;
            return result;
        }
    }

    [Serializable]
    public class CTableDefinitionStructureSNMPFiller : IEasyQueryConnexion
    {
        public const string c_strIdTypeConnexion = "SNMP STRUCTURE";

        public bool CanFill(ITableDefinition tableDefinition)
        {
            return tableDefinition is CTableDefinitionStructureSNMP;
        }

        public void ClearCache(ITableDefinition table)
        { 
        }

        public DataTable GetData(ITableDefinition tableDefinition, params string[] strIdsColonnesSource)
        {
            CTableDefinitionStructureSNMP table = tableDefinition as CTableDefinitionStructureSNMP;
            if (table != null)
                return table.GetDatas(null).Data as DataTable;
            return null;
        }


        //---------------------------------------------------
        public void ClearStructure()
        {
            
        }

        //---------------------------------------------------
        public IEnumerable<CEasyQueryConnexionProperty> ConnexionProperties
        {
            get
            {
                return new CEasyQueryConnexionProperty[0];
            }
            set
            {

            }
        }

        //---------------------------------------------------
        public string ConnexionTypeId
        {
            get { return c_strIdTypeConnexion; }
        }

        //---------------------------------------------------
        public string ConnexionTypeName
        {
            get { return "Snmp Structure"; }
        }

        //---------------------------------------------------
        public void FillStructureQuerySource(CEasyQuerySource source)
        {
            
        }

        //---------------------------------------------------
        public string GetConnexionProperty(string strProperty)
        {
            return "";
        }

        public void SetConnexionProperty(string strProperty, string strValeur)
        {
            
        }
        //---------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //---------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
            return result;
        }
    }
}
