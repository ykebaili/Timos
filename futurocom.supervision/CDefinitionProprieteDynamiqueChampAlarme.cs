using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.expression;
using sc2i.common;

namespace futurocom.supervision
{
    [Serializable]
    public class CDefinitionProprieteDynamiqueChampAlarme : CDefinitionProprieteDynamique
    {
        public const string c_cleType = "ALRMFLD";

        //------------------------------------------------------
        public CDefinitionProprieteDynamiqueChampAlarme()
        {
        }

        //------------------------------------------------------
        public CDefinitionProprieteDynamiqueChampAlarme(CLocalChampTypeAlarme champ)
            : base(champ.NomChamp, champ.Id,
               new CTypeResultatExpression(CTypeChampBasique.GetTypeDotNet(champ.TypeDonnee), false),
               false, false)
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

    [AutoExec("Autoexec")]
    public class CInterpreteurProprieteDynamiqueChampAlarme : IInterpreteurProprieteDynamique
    {

        public static void Autoexec()
        {
            CInterpreteurProprieteDynamique.RegisterTypeDefinition(CDefinitionProprieteDynamiqueChampAlarme.c_cleType, typeof(CInterpreteurProprieteDynamiqueChampAlarme));
        }

        public IOptimiseurGetValueDynamic GetOptimiseur(Type tp, string strPropriete)
        {
            return null;
        }

        public CResultAErreur GetValue(object objet, string strPropriete)
        {
            CResultAErreur result = CResultAErreur.True;
            CLocalAlarme alarme = objet as CLocalAlarme;
            if (alarme == null)
                return result;
            result.Data = alarme.GetValeurChamp(strPropriete);
            return result;
        }

        public CResultAErreur SetValue(object objet, string strPropriete, object valeur)
        {
            CResultAErreur result = CResultAErreur.True;
            CLocalAlarme alarme = objet as CLocalAlarme;
            if (alarme == null)
                return result;
            alarme.SetValeurChamp(strPropriete, valeur);
            return result;
        }

        public bool ShouldIgnoreForSetValue(string strPropriete)
        {
            return false;
        }


    }



}
