using System;

using sc2i.common;
using sc2i.expression;
using futurocom.snmp.expression;

namespace futurocom.snmp.dynamic
{
    /// <summary>
    /// Description résumée de C2iExpressionPlus.
    /// </summary>
    [Serializable]
    public class C2iExpressionSNMPAgent : C2iExpressionAnalysable
    {

        /// //////////////////////////////////////////
        public C2iExpressionSNMPAgent()
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
            CInfo2iExpression info = new CInfo2iExpression(
                0,
                "SnmpAgent",  
                typeof(CInterrogateurSnmp),
                I.TT(GetType(), "SnmpAgent()\nReturns an SNMP agent"),
                CInfo2iExpression.c_categorieDivers);
            info.AddDefinitionParametres(new CInfo2iDefinitionParametres(new Type[0]));
            return info;
        }

        /// //////////////////////////////////////////
        public override CResultAErreur MyEval(CContexteEvaluationExpression ctx, object[] valeursParametres)
        {
            CResultAErreur result = CResultAErreur.True;
            CInterrogateurSnmp agent = ctx.GetObjetAttache(typeof(CInterrogateurSnmp)) as CInterrogateurSnmp;
            if (agent == null)
            {
                agent = new CInterrogateurSnmp();
                ctx.AttacheObjet(typeof(CInterrogateurSnmp), agent);
            }
            result.Data = agent;
            return result;
        }


    }

}
