using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.expression;
using sc2i.common;

namespace futurocom.snmp.alarme
{
    [Serializable]
    public class CDefinitionProprieteDynamiqueTrapField : CDefinitionProprieteDynamique
    {
        public const string c_cleType = "SNMPTRAPFLD";

        public CDefinitionProprieteDynamiqueTrapField()
            : base()
        {
        }

        public CDefinitionProprieteDynamiqueTrapField(CTrapField field)
            : base(field.Name, field.OID.Replace('.','_'), new CTypeResultatExpression(typeof(CTrapFieldValueAvecIndex), false), true, true)
        {
        }

        public override string CleType
        {
            get
            {
                return c_cleType;
            }
        }
    }

    //----------------------------------------------------------------------------------
    [AutoExec("Autoexec")]
    public class CInterpreteurProprieteDynamiqueTrapField : IInterpreteurProprieteDynamique
    {
        //----------------------------------------------------------------------------------
        public static void Autoexec()
        {
            CInterpreteurProprieteDynamique.RegisterTypeDefinition(CDefinitionProprieteDynamiqueTrapField.c_cleType, typeof(CInterpreteurProprieteDynamiqueTrapField));
        }

        //----------------------------------------------------------------------------------
        public IOptimiseurGetValueDynamic GetOptimiseur(Type tp, string strPropriete)
        {
            return null;
        }

        //----------------------------------------------------------------------------------
        public CResultAErreur GetValue(object objet, string strPropriete)
        {
            CResultAErreur result = CResultAErreur.True;
            result.Data = "";
            CTrapInstance trap = objet as CTrapInstance;
            if (trap == null)
                return result;
            string strProp = strPropriete.Replace('_', '.');
            foreach (CTrapFieldValueBrute valeur in trap.ValeursVariables)
            {
                if (valeur.OID.StartsWith(strProp))
                {
                    CTrapFieldValueAvecIndex retour = new CTrapFieldValueAvecIndex(
                        valeur.OID.Substring(strProp.Length)+1, valeur.Value);
                    result.Data = retour;
                    return result;
                }
            }
            return result;
            
        }

        //----------------------------------------------------------------------------------
        public CResultAErreur SetValue(object objet, string strPropriete, object valeur)
        {
            CResultAErreur result = CResultAErreur.True;
           
            return result;
        }

        //----------------------------------------------------------------------------------
        public bool ShouldIgnoreForSetValue(string strPropriete)
        {
            return true;
        }

    }
}
