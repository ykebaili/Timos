using System;

using sc2i.common;
using sc2i.expression;
using futurocom.snmp.expression;
using System.Text;

namespace futurocom.snmp.dynamic
{
    /// <summary>
    /// Description résumée de C2iExpressionPlus.
    /// </summary>
    [Serializable]
    public class C2iExpressionToSnmp : C2iExpressionAnalysable
    {

        /// //////////////////////////////////////////
        public C2iExpressionToSnmp()
        {
        }


        /// //////////////////////////////////////////
        public override CObjetPourSousProprietes GetObjetPourSousProprietes()
        {
            return base.GetObjetPourSousProprietes();
        }

        /// //////////////////////////////////////////
        protected override CInfo2iExpression GetInfosSansCache()
        {
            StringBuilder blHelp = new StringBuilder();
            foreach ( SnmpType tp in Enum.GetValues(typeof(SnmpType )))
            {
                blHelp.Append('\n');
                blHelp.Append ( (int)tp);
                blHelp.Append(" : ");
                blHelp.Append ( tp.ToString() );
            }

            CInfo2iExpression info = new CInfo2iExpression(
                0,
                "ConvertToSnmpValue",  
                typeof(ISnmpData),
                "ConvertToSnmpValue(snmpType, string value)\nTries to convert value to SnmpData\nSnmp types are " + blHelp.ToString(),
                CInfo2iExpression.c_categorieDivers);
            info.AddDefinitionParametres(new CInfo2iDefinitionParametres(
                new CInfoUnParametreExpression("SnmpType (see help)", typeof(int)),
                new CInfoUnParametreExpression("Value (string)",typeof(string))));
            return info;
        }

        /// //////////////////////////////////////////
        public override CResultAErreur MyEval(CContexteEvaluationExpression ctx, object[] valeursParametres)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                SnmpType tp = (SnmpType)valeursParametres[0];
                string strVal = valeursParametres[1].ToString();
                result.Data = DataFactory.CreateSnmpDataFromStringUnsafe(tp, strVal);
            }
            catch (Exception e)
            {
                result.EmpileErreur("Error in ToSnmp");
                result.EmpileErreur(new CErreurException(e));
            }
            return result;
        }


    }

}
