using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using futurocom.easyquery;
using futurocom.snmp.Mib;
using futurocom.snmp;
using System.Data;
using sc2i.common;

namespace futurocom.easyquery.snmp
{
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
            string strOID = OIDString;
            serializer.TraiteString(ref strOID);
            OIDString = strOID;
            serializer.TraiteString(ref m_strName);

            return result;
        }

        //-----------------------------------
        public override CResultAErreur GetDatas(CEasyQuerySource source)
        {
            CResultAErreur result = CResultAErreur.True;
            DataTable table = source.GetTable(this);
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
                            CColumnDefinitionSNMP newCol = new CColumnDefinitionSNMP();
                            newCol.ColumnName = col.Name;
                            newCol.OID = col.GetNumericalForm();
                            newCol.DataType = typeof(string);
                            table.AddColumn(newCol);
                        }
                    }
                }
            }
            return table;
        }

        //-----------------------------------
        public static IEnumerable<ITableDefinition> FromMib(
            CEasyQuerySource laBase, 
            ObjectRegistryBase mibBase,
            CEasyQuerySourceFolder folderRacine)
        {
            List<ITableDefinition> lst = new List<ITableDefinition>();
            if (laBase.Tables.FirstOrDefault(t => t.GetType() == typeof(CTableDefinitionStructureSNMP)) == null)
            {
                CTableDefinitionStructureSNMP table = new CTableDefinitionStructureSNMP();
                if ( folderRacine != null )
                    table.FolderId = folderRacine.Id;
                lst.Add(table);
                table.Fill(mibBase);
                laBase.AddTable(table);
            }
            FillListeTables(laBase, mibBase.Tree.Root, lst, folderRacine );
            return lst.AsReadOnly();
        }

        //-----------------------------------
        private static void FillListeTables(
            CEasyQuerySource laBase, 
            IDefinition definition, 
            List<ITableDefinition> lstToFill,
            CEasyQuerySourceFolder folderRacine)
        {
            foreach (IDefinition children in definition.Children)
            {
                if (children.Type == DefinitionType.Table)
                {
                    CTableDefinitionSNMP table = FromDefinition(laBase, children, folderRacine);
                    if (table != null)
                    {
                        lstToFill.Add(table);
                        laBase.AddTable(table);
                    }
                }
                else if (children.Type == DefinitionType.OidValueAssignment || children.Type == DefinitionType.Scalar)
                {
                    CEasyQuerySourceFolder folder = folderRacine.GetSubFolderWithCreate(children.Name);
                    if (folder != null && children.GetNumericalForm().Length > 0)
                        folder.SetExtendedProperty(c_strExtendedPropertyOID, ObjectIdentifier.Convert(children.GetNumericalForm()));
                    if (children.Type == DefinitionType.Scalar)
                    {
                        folder.SetExtendedProperty(c_strExtendedPropertyValue, new CValeurExtendedProprieteFolderSnmpScalar(ObjectIdentifier.Convert(children.GetNumericalForm())));
                        folder.ImageKey = CValeurExtendedProprieteFolderSnmpScalar.c_strImageScalar;
                    }
                    FillListeTables(laBase, children, lstToFill, folder);
                }
               
            }
        }   
        
    }
}
