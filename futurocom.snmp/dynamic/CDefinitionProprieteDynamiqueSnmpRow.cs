using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.expression;
using sc2i.common;
using System.Data;

namespace futurocom.snmp.dynamic
{
    [Serializable]
    public class CDefinitionProprieteDynamiqueSnmpRow : CDefinitionProprieteDynamiqueInstance
    {
        public const string c_cleType = "SNMPROW";

        //-------------------------------------------
        public CDefinitionProprieteDynamiqueSnmpRow()
            : base()
        {
        }
        //-------------------------------------------
        public CDefinitionProprieteDynamiqueSnmpRow(CDynamicSnmpTableDef table)
            : base("Rows",
            "ROWS",
            new CDynamicSnmpRowDef(table), 
            true,
            "")
        {
        }

        //-------------------------------------------
        public override string CleType
        {
            get
            {
                return c_cleType;
            }
        }
    }

    [AutoExec("Autoexec")]
    public class CInterpreteurProprieteDynamiqueSnmpRow : IInterpreteurProprieteDynamique
    {
        //-----------------------------------------------------------------
        public static void Autoexec()
        {
            CInterpreteurProprieteDynamique.RegisterTypeDefinition(
                CDefinitionProprieteDynamiqueSnmpRow.c_cleType,
                typeof(CInterpreteurProprieteDynamiqueSnmpRow));
        }
        
        //---------------------------------------------------------------
        public IOptimiseurGetValueDynamic GetOptimiseur(Type tp, string strPropriete)
        {
            return null;
        }

        //---------------------------------------------------------------
        public CResultAErreur GetValue(object objet, string strPropriete)
        {
            CResultAErreur result = CResultAErreur.True;
            result.Data = null;
            CDynamicSnmpTable table = objet as CDynamicSnmpTable;
            if ( table == null )
                return result;
            DataTable dtTable = table.GetTable();
            if (dtTable != null)
            {
                List<CDynamicSnmpRow> lst = new List<CDynamicSnmpRow>();
                for (int n = 0; n < dtTable.Rows.Count; n++)
                    lst.Add(new CDynamicSnmpRow(table, n));
                result.Data = lst.ToArray();
            }
            return result;

        }

        //---------------------------------------------------------------
        public CResultAErreur SetValue(object objet, string strPropriete, object valeur)
        {
            return CResultAErreur.True;
        }

        //---------------------------------------------------------------
        public bool ShouldIgnoreForSetValue(string strPropriete)
        {
            return true;
        }

    }

}
