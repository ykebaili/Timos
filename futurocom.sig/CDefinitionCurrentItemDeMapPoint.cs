using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.expression;
using sc2i.common;

namespace futurocom.sig
{
    [Serializable]
    public class CDefinitionCurrentItemMapPoint : CDefinitionProprieteDynamique
    {
        public const string c_cleType = "MAPPOINT_CURRENT";

        //-------------------------------------------
        public CDefinitionCurrentItemMapPoint()
            : base()
        {
        }
        //-------------------------------------------
        public CDefinitionCurrentItemMapPoint(IMapItemGenertorFromEntities generator)
            : base("Current generated item",
            "Current generated item",
            new CTypeResultatExpression ( generator.TypeElementsDessines, false),
            true, true)
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
    public class CInterpreteurProprieteCurrentItemMapPoint : IInterpreteurProprieteDynamique
    {
        //-----------------------------------------------------------------
        public static void Autoexec()
        {
            CInterpreteurProprieteDynamique.RegisterTypeDefinition(
                CDefinitionCurrentItemMapPoint.c_cleType,
                typeof(CInterpreteurProprieteCurrentItemMapPoint));
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
            IMapItemGenertorFromEntities generator = objet as IMapItemGenertorFromEntities;
            if (generator != null)
                result.Data = generator.CurrentGeneratedItem;
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
