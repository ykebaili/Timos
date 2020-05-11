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
    public class CDefinitionProprieteDynamicSnmpCell : CDefinitionProprieteDynamique
    {
        public const string c_cleType = "SNMPCELL";

        //-------------------------------------------------
        public CDefinitionProprieteDynamicSnmpCell()
            :base()
        {
        }

        //-------------------------------------------------
        public CDefinitionProprieteDynamicSnmpCell(CDefinitionProprieteDynamiqueSnmpColumn col)
            :base ( col.Nom, col.NomProprieteSansCleTypeChamp, new CTypeResultatExpression ( col.TypeDonnee.TypeDotNetNatif, false), false, true )
        { 
        }

        //-------------------------------------------------
        public CDefinitionProprieteDynamicSnmpCell(string strNom, string strPropriete, 
            Type tp, bool bIsReadOnly )
            : base(strNom, strPropriete, new CTypeResultatExpression(tp, false), false, bIsReadOnly)
        {
        }

        //-------------------------------------------------
        public override string CleType
        {
            get
            {
                return c_cleType;
            }
        }
    }

    [AutoExec("Autoexec")]
    public class CInterpreteurProprieteDynamiqueSnmpCell: IInterpreteurProprieteDynamique
    {
        //-----------------------------------------------------------------
        public static void Autoexec()
        {
            CInterpreteurProprieteDynamique.RegisterTypeDefinition(
                CDefinitionProprieteDynamicSnmpCell.c_cleType,
                typeof(CInterpreteurProprieteDynamiqueSnmpCell));
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
            CDynamicSnmpRow row = objet as CDynamicSnmpRow;
            if (row != null)
            {
                result.Data =  row.GetValue(strPropriete.Replace('_','.'));
            }
            return result;

        }

        //---------------------------------------------------------------
        public CResultAErreur SetValue(object objet, string strPropriete, object valeur)
        {
            CResultAErreur result = CResultAErreur.True;
            result.Data = null;
            CDynamicSnmpRow row = objet as CDynamicSnmpRow;
            if (row != null)
            {
                row.SetValue(strPropriete.Replace('_', '.'), valeur);
                result.Data = valeur;
            }
            return result;
        }

        //---------------------------------------------------------------
        public bool ShouldIgnoreForSetValue(string strPropriete)
        {
            return false;
        }

    }
}
