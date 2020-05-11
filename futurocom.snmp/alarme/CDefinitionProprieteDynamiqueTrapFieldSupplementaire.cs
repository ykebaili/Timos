using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.expression;
using sc2i.common;

namespace futurocom.snmp.alarme
{
    [Serializable]
    public class CDefinitionProprieteDynamiqueTrapFieldSupplementaire : CDefinitionProprieteDynamique
    {
        public const string c_cleType = "SUPTRAPFLD";

        public CDefinitionProprieteDynamiqueTrapFieldSupplementaire()
            : base()
        {
        }

        public CDefinitionProprieteDynamiqueTrapFieldSupplementaire(CTrapFieldSupplementaire field)
            : base(field.Name, field.Id, new CTypeResultatExpression(typeof(string), false), true, true)
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
    public class CInterpreteurProprieteDynamiqueTrapFieldSupplementaire : IInterpreteurProprieteDynamique
    {
        //----------------------------------------------------------------------------------
        public static void Autoexec()
        {
            CInterpreteurProprieteDynamique.RegisterTypeDefinition(CDefinitionProprieteDynamiqueTrapFieldSupplementaire.c_cleType, typeof(CInterpreteurProprieteDynamiqueTrapFieldSupplementaire));
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
            string strVal = trap.GetValeurSupplementaire(strPropriete);
            result.Data = strVal;
            return result;
            
        }

        //----------------------------------------------------------------------------------
        public CResultAErreur SetValue(object objet, string strPropriete, object valeur)
        {
            CResultAErreur result = CResultAErreur.True;
            CTrapInstance trap = objet as CTrapInstance;
            if (trap == null)
                return result;
            trap.SetValeurSupplementaire(strPropriete, valeur == null?"":valeur.ToString());
            return result;
        }

        //----------------------------------------------------------------------------------
        public bool ShouldIgnoreForSetValue(string strPropriete)
        {
            return true;
        }

    }
}
