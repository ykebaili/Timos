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
    public class CDefinitionProprieteDynamiqueSNMPVariable : CDefinitionProprieteDynamique
    {
        public static string c_cleType = "SNMPFIELD";

        public CDefinitionProprieteDynamiqueSNMPVariable()
            : base()
        {
        }

        //-------------------------------------------------------------------------
        public CDefinitionProprieteDynamiqueSNMPVariable(IDefinition definition)
            : base(definition.Name, ObjectIdentifier.Convert(definition.GetNumericalForm()).Replace('.','_'),
            new CTypeResultatExpression(typeof(string), false), false, false)
        {
            Rubrique = CInterrogateurSnmp.CalcRubriqueChamp(definition);
        }

        //-------------------------------------------------------------------------
        public override string CleType
        {
            get
            {
                return c_cleType;
            }
        }

        //-------------------------------------------------------------------------
    }

    //--------------------------------------------------------------
    [AutoExec("Autoexec")]
    public class CInterpreteurProprieteDynamiqueSNMPVariable : IInterpreteurProprieteDynamique
    {
        //--------------------------------------------------------------
        public static void Autoexec()
        {
            CInterpreteurProprieteDynamique.RegisterTypeDefinition(
                CDefinitionProprieteDynamiqueSNMPVariable.c_cleType,
                typeof(CInterpreteurProprieteDynamiqueSNMPVariable));
        }

        //--------------------------------------------------------------
        public IOptimiseurGetValueDynamic GetOptimiseur(Type tp, string strPropriete)
        {
            return null;
        }

        //--------------------------------------------------------------
        public sc2i.common.CResultAErreur GetValue(object objet, string strPropriete)
        {
            CResultAErreur result = CResultAErreur.True;
            CInterrogateurSnmp mibDyn = objet as CInterrogateurSnmp;
            if ( mibDyn != null )
            {

                try{
                    CResultAErreurType<Variable> resVar = mibDyn.Connexion.Get ( ObjectIdentifier.Convert ( strPropriete.Replace('_','.')) );
                    if ( resVar )
                        result.Data = resVar.DataType.Data.ToString();
                }
                catch{}
            }
            return result;
        }

        //--------------------------------------------------------------
        public sc2i.common.CResultAErreur SetValue(object objet, string strPropriete, object valeur)
        {
            CResultAErreur result = CResultAErreur.True;
            CInterrogateurSnmp mibDyn = objet as CInterrogateurSnmp;
            if (mibDyn != null)
            {

                try
                {
                    string strOID = strPropriete;
                    if (strOID[strOID.Length - 1] != '.')
                        strOID += ".";
                    strOID += "0";
                    result = mibDyn.Connexion.Set(ObjectIdentifier.Convert(strPropriete.Replace('_', '.')), valeur);
                    result.Data = valeur;

                }
                catch { }
            }
            return result;
        }

        //--------------------------------------------------------------
        public bool ShouldIgnoreForSetValue(string strPropriete)
        {
            return false;
        }

        
    }
}

