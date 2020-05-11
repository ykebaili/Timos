using System;
using System.Collections;

using sc2i.common;
using sc2i.multitiers.client;
using timos.data.snmp;

namespace sc2i.expression
{
	/// <summary>
	/// Description résumée de C2iExpressionPlus.
	/// </summary>
	[Serializable]
    [AutoExec("Autoexec")]
	public class C2iExpressionSynchroMediation : C2iExpressionAnalysable
	{
		/// //////////////////////////////////////////
        public C2iExpressionSynchroMediation()
		{
		}

        public static void Autoexec()
        {
            CAllocateur2iExpression.Register2iExpression(new C2iExpressionSynchroMediation().IdExpression,
                typeof(C2iExpressionSynchroMediation));
        }

		/// //////////////////////////////////////////
        protected override CInfo2iExpression GetInfosSansCache()
		{
			CInfo2iExpression info = new CInfo2iExpression( 
				0, 
				"MediationSynchronisation", 
				typeof(double),
				I.TT(GetType(), "MediationSynchronisation()\nUpdate mediation services and proxies configuration|20103"),
				CInfo2iExpression.c_categorieDivers );
            info.AddDefinitionParametres( new CInfo2iDefinitionParametres(new Type[]{}));
			return info;
		}

 
		/// //////////////////////////////////////////
		public override CTypeResultatExpression TypeDonnee
		{
			get
			{
                return new CTypeResultatExpression(typeof(bool), false);
			}
		}

		/// //////////////////////////////////////////
		public override CResultAErreur MyEval ( CContexteEvaluationExpression ctx, object[] valeursParametres )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
                ISynchroMediation synchro = C2iFactory.GetNewObjetForSession("CSynchroMediation", typeof(ISynchroMediation), 0) as ISynchroMediation;
                result = synchro.DoSynchro();
                if (result)
                    result.Data = true;
                else
                    result.Data = false;
			}
			catch ( Exception e )
			{
				result.EmpileErreur ( new CErreurException ( e ) );
			}
			return result;
		}
	}
}
