using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.expression;
using sc2i.common;
using futurocom.snmp.expression;

namespace futurocom.snmp.dynamic
{
    [Serializable]
    public class CDefinitionProprieteDynamiqueSnmpTable : CDefinitionProprieteDynamiqueInstance
    {
        public const string c_cleType = "SNMPTABLE";

        //-------------------------------------------
        public CDefinitionProprieteDynamiqueSnmpTable()
            : base()
        {
        }

        //-------------------------------------------
        public CDefinitionProprieteDynamiqueSnmpTable(IDefinition definition)
            :base ( definition.Name, 
            ObjectIdentifier.Convert ( definition.GetNumericalForm() ).Replace('.','_'),
            new CDynamicSnmpTableDef(definition), "")

        {
            Rubrique = CInterrogateurSnmp.CalcRubriqueChamp(definition);
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
    public class CInterpreteurProprieteDynamicSnmpTable : IInterpreteurProprieteDynamique
    {

        //-----------------------------------------------------------------
        public static void Autoexec()
        {
            CInterpreteurProprieteDynamique.RegisterTypeDefinition(
                CDefinitionProprieteDynamiqueSnmpTable.c_cleType,
                typeof(CInterpreteurProprieteDynamicSnmpTable));
        }

        //-----------------------------------------------------------------
        public IOptimiseurGetValueDynamic GetOptimiseur(Type tp, string strPropriete)
        {
            return null;
        }

        //-----------------------------------------------------------------
        public CResultAErreur GetValue(object objet, string strPropriete)
        {
            CResultAErreur result = CResultAErreur.True;
            result.Data = null;
            CInterrogateurSnmp mib = objet as CInterrogateurSnmp;
            if (mib == null)
                return result;
            try
            {
                result.Data = new CDynamicSnmpTable(mib, ObjectIdentifier.Convert(strPropriete.Replace('_', '.')));
            }
            catch
            {
            }
            return result;
        }

        //-----------------------------------------------------------------
        public CResultAErreur SetValue(object objet, string strPropriete, object valeur)
        {
            return CResultAErreur.True;
        }

        //-----------------------------------------------------------------
        public bool ShouldIgnoreForSetValue(string strPropriete)
        {
            return true;
        }
    }
}
