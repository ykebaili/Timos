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
    public class CDefinitionProprieteDynamiqueSnmpColumn : CDefinitionProprieteDynamique
    {
        public const string c_cleType = "SNMPCOL";

        //-------------------------------------------
        public CDefinitionProprieteDynamiqueSnmpColumn()
            : base()
        {
        }
        //-------------------------------------------
        public CDefinitionProprieteDynamiqueSnmpColumn(IDefinition definition)
            : base(definition.Name,
            ObjectIdentifier.Convert(definition.GetNumericalForm()).Replace('.','_'),
            new CTypeResultatExpression(typeof(string), true),
            false, true)
        {
            //Rubrique = CMibDynamic.CalcRubriqueChamp(definition);
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
    public class CInterpreteurProprieteDynamiqueSnmpColumn : IInterpreteurProprieteDynamique
    {
        //-----------------------------------------------------------------
        public static void Autoexec()
        {
            CInterpreteurProprieteDynamique.RegisterTypeDefinition(
                CDefinitionProprieteDynamiqueSnmpColumn.c_cleType,
                typeof(CInterpreteurProprieteDynamiqueSnmpColumn));
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
                string strCol = strPropriete.Replace('_', '.');
                List<string> lstVals = new List<string>();
                if (dtTable.Columns.Contains(strCol))
                {
                    foreach (DataRow row in dtTable.Rows)
                    {
                        object val = row[strCol];
                        lstVals.Add(val == DBNull.Value ? null : val.ToString());
                    }
                }
                result.Data = lstVals.ToArray();
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
