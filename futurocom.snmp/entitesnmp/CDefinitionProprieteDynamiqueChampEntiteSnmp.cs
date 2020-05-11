using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.expression;
using sc2i.common;

namespace futurocom.snmp.entitesnmp
{
    [Serializable]
    public class CDefinitionProprieteDynamiqueChampEntiteSnmp : CDefinitionProprieteDynamique
    {
        public const string c_cleType = "ETTSNMP";

        //-------------------------------------------------------
        public CDefinitionProprieteDynamiqueChampEntiteSnmp()
        {
        }

        //-------------------------------------------------------
        public CDefinitionProprieteDynamiqueChampEntiteSnmp(IChampEntiteSNMP champ)
            : base(champ.NomChamp, champ.Id,
                new CTypeResultatExpression (CTypeChampBasique.GetTypeDotNet(champ.TypeChamp), false),
                false,
                champ.IsReadOnly)
        {
        }

        //-------------------------------------------------------
        public override string CleType
        {
            get
            {
                return c_cleType;
            }
        }
    }

    //-------------------------------------------------------
    [AutoExec("Autoexec")]
    public class CIntepreteurProprieteDynamiqueChampEntiteSnmp : IInterpreteurProprieteDynamique
    {
        public static void Autoexec()
        {
            CInterpreteurProprieteDynamique.RegisterTypeDefinition(CDefinitionProprieteDynamiqueChampEntiteSnmp.c_cleType,
                typeof(CIntepreteurProprieteDynamiqueChampEntiteSnmp));
        }

        public CResultAErreur GetValue(object objet, string strPropriete)
        {
            CResultAErreur result = CResultAErreur.True;
            CEntiteSnmpPourSupervision entite = objet as CEntiteSnmpPourSupervision;
            if (entite != null)
            {
                result.Data = entite.GetValeurChamp(strPropriete);
            }
            return result;

        }

        public CResultAErreur SetValue(object objet, string strPropriete, object valeur)
        {
            CResultAErreur result = CResultAErreur.True;
            CEntiteSnmpPourSupervision entite = objet as CEntiteSnmpPourSupervision;
            if (entite != null)
            {
                entite.SetValeurChamp(strPropriete, valeur);
            }
            return result;
        }

        public bool ShouldIgnoreForSetValue(string strPropriete)
        {
            return false;
        }

        public IOptimiseurGetValueDynamic GetOptimiseur(Type tp, string strPropriete)
        {
            return null;
        }

    }

}
