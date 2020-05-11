using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using futurocom.easyquery;
using futurocom.snmp.Mib;
using futurocom.snmp;
using System.Data;
using sc2i.common;
using futurocom.snmp.easyquery;

namespace futurocom.easyquery.snmp
{
    [Serializable]
    public class CTableDefinitionSNMP : CTableDefinitionBase
    {

        public const string c_strExtendedPropertyOID = "SNMPOid";
        public const string c_strExtendedPropertyValue = "SNMPValue";

        private uint[] m_nOId = null;
        private string m_strName = "";

        //-----------------------------------
        public CTableDefinitionSNMP()
            :base()
        {
        }

        //-----------------------------------
        public CTableDefinitionSNMP(CEasyQuerySource laBase)
            : base(laBase)
        {
        }

        

        //-----------------------------------
        public override string TableName
        {
            get
            {
                return m_strName;
            }
            set
            {
                m_strName = value;
            }
        }

        //-----------------------------------
        public uint[] OID
        {
            get
            {
                return m_nOId;
            }
            set
            {
                m_nOId = value;
            }
        }

        //-----------------------------------
        public string OIDString
        {
            get
            {
                try
                {
                    return ObjectIdentifier.Convert(OID);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                try
                {
                    OID = ObjectIdentifier.Convert(value);
                }
                catch { }
            }

        }

        //-----------------------------------
        public override string Id
        {
            get { return OIDString; }
        }

        //-----------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-----------------------------------
        public override CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (result)
                result = base.Serialize(serializer);
            if (!result)
                return result;
            string strOID = serializer.Mode == ModeSerialisation.Ecriture ? OIDString : "";
            serializer.TraiteString(ref strOID);
            OIDString = strOID;
            serializer.TraiteString(ref m_strName);

            return result;
        }

        //-----------------------------------
        public override CResultAErreur GetDatas(CEasyQuerySource source, params string[] strIdsColonnesSources)
        {
            CResultAErreur result = CResultAErreur.True;
            List<string> strCols = new List<string>();
            foreach ( IColumnDefinition col in Columns )
            {
                CColumnDefinitionSNMP colSnmp = col as CColumnDefinitionSNMP;
                if (colSnmp != null)
                {
                    if (strIdsColonnesSources.Contains(colSnmp.Id))
                        strCols.Add(colSnmp.OIDString);
                }
            }
            DataTable table = source.GetTable(this, strCols.ToArray());
            if (table != null)
            {
                //Vérifie les types de colonnes, pour éviter les pbs de déclaration dans la mib (merci assentria)
                foreach (IColumnDefinition col in Columns)
                {
                    CColumnDefinitionSNMP colSnmp = col as CColumnDefinitionSNMP;
                    if (colSnmp != null)
                    {
                        DataColumn colDeTable = table.Columns[colSnmp.ColumnName];
                        if (colDeTable != null && colDeTable.DataType != col.DataType)
                        {
                            colSnmp.SnmpType = null;
                            colSnmp.DataType = colDeTable.DataType;
                        }
                    }
                }
            }
            object a = Columns;
            result.Data = table;
            return result;
        }

        //-----------------------------------
        public static CTableDefinitionSNMP FromDefinition(
            CEasyQuerySource laBase, 
            IDefinition def,
            CEasyQuerySourceFolder folder

            )
        {
            CTableDefinitionSNMP table = null;
            if (def.Type == DefinitionType.Table)
            {
                table = new CTableDefinitionSNMP(laBase);
                table.TableName = def.Name;
                table.OID = def.GetNumericalForm();

                if (folder != null)
                {
                    table.FolderId = folder.Id;
                }

                if (def.Children.Count() == 1)
                {
                    CColumnDefinitionSimple colIndex = new CColumnDefinitionSimple("Index", typeof(string));
                    table.AddColumn(colIndex);
                    IDefinition entry = def.Children.ElementAt(0);
                    foreach (IDefinition col in entry.Children)
                    {
                        if (col.Type == DefinitionType.Column)
                        {
                            ObjectType objType = col.Entity as ObjectType;
                            if (objType != null && objType.Access != MaxAccess.notAccessible)
                            {
                                CColumnDefinitionSNMP newCol = new CColumnDefinitionSNMP();
                                newCol.ColumnName = col.Name;
                                newCol.Description = col.Description;
                                newCol.OID = col.GetNumericalForm();
                                TextualConvention conv = objType.Syntax as TextualConvention;
                                if (conv != null)
                                {
                                    newCol.SnmpType = conv.Syntax as AbstractTypeAssignment;
                                }
                                else
                                    newCol.SnmpType = objType.Syntax as AbstractTypeAssignment;
                                if (newCol.SnmpType == null)
                                {
                                    newCol.DataType = typeof(string);
                                    newCol.IsReadOnly = true;
                                }
                                switch (objType.Access)
                                {
                                    case MaxAccess.accessibleForNotify:
                                    case MaxAccess.readOnly:
                                        newCol.IsReadOnly = true;
                                        break;
                                    case MaxAccess.readWrite:
                                    case MaxAccess.readCreate:
                                        newCol.IsReadOnly = false;
                                        break;
                                }
                                table.AddColumn(newCol);
                            }
                        }
                    }
                }
            }
            return table;
        }

        //-----------------------------------
        public static IEnumerable<ITableDefinition> FromMib(
            CEasyQuerySource laBase, 
            IDefinition rootDefinition,
            CEasyQuerySourceFolder folderRacine)
        {
            List<ITableDefinition> lst = new List<ITableDefinition>();
            if (laBase.Tables.FirstOrDefault(t => t.GetType() == typeof(CTableDefinitionStructureSNMP)) == null)
            {
                CTableDefinitionStructureSNMP table = new CTableDefinitionStructureSNMP();
                if ( folderRacine != null )
                    table.FolderId = folderRacine.Id;
                lst.Add(table);
                table.Fill(rootDefinition);
                laBase.AddTableUniquementPourObjetConnexion(table);
            }
            FillListeTables(laBase, rootDefinition, lst, folderRacine );
            return lst.AsReadOnly();
        }

        //-----------------------------------
        private static void FillListeTables(
            CEasyQuerySource laBase, 
            IDefinition definition, 
            List<ITableDefinition> lstToFill,
            CEasyQuerySourceFolder folderRacine)
        {
            CTableDefinitionSnmpOfScalar tableScalars = null;
            if (definition.Entity != null)
            {
                tableScalars = new CTableDefinitionSnmpOfScalar();
                tableScalars.OIDRacine = definition.GetNumericalForm();
                tableScalars.TableName = folderRacine.Name + "_Scalars";
                tableScalars.FolderId = folderRacine.Id;
            }
            foreach (IDefinition children in definition.Children)
            {
                if (children.Type == DefinitionType.Table)
                {
                    CTableDefinitionSNMP table = FromDefinition(laBase, children, folderRacine);
                    if (table != null)
                    {
                        lstToFill.Add(table);
                        laBase.AddTableUniquementPourObjetConnexion(table);
                    }
                }
                else if (children.Type == DefinitionType.OidValueAssignment )
                {
                    CEasyQuerySourceFolder folder = folderRacine.GetSubFolderWithCreate(children.Name);
                    FillListeTables(laBase, children, lstToFill, folder);
                }
                else if ( children.Type == DefinitionType.Scalar )
                {
                    if (children.Type == DefinitionType.Scalar && tableScalars != null)
                    {
                        CColumnDefinitionSNMP colSnmp = new CColumnDefinitionSNMP();
                        colSnmp.ColumnName = children.Name;
                        colSnmp.OID = children.GetNumericalForm();
                        Type tp = typeof(string);
                        ObjectType objType = children.Entity as ObjectType;
                        if (objType != null)
                        {
                            TextualConvention conv = objType.Syntax as TextualConvention;
                            if (conv != null)
                                tp = ((AbstractTypeAssignment)conv.Syntax).GetTypeDotNet();
                            else
                            {
                                AbstractTypeAssignment abs = objType.Syntax as AbstractTypeAssignment;
                                if (abs != null)
                                    tp = abs.GetTypeDotNet();
                            }
                        }
                        switch (objType.Access)
                        {
                            case MaxAccess.accessibleForNotify:
                            case MaxAccess.readOnly:
                                colSnmp.IsReadOnly = true;
                                break;
                            case MaxAccess.readWrite:
                            case MaxAccess.readCreate:
                                colSnmp.IsReadOnly = false;
                                break;
                        }
                        colSnmp.DataType = tp;
                        tableScalars.AddColumn(colSnmp);
                    }
                    
                }
               
            }
            if (tableScalars != null && tableScalars.Columns.Count() > 0)
            {
                laBase.AddTableUniquementPourObjetConnexion(tableScalars);
                tableScalars.Base = laBase;
            }

        }   
        
    }
}
