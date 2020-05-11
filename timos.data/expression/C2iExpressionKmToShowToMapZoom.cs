using System;
using System.Collections;

using sc2i.common;

namespace sc2i.expression
{
	/// <summary>
	/// Description résumée de C2iExpressionPlus.
	/// </summary>
	[Serializable]
    [AutoExec("Autoexec")]
	public class C2iExpressionKmToShowToMapZoom : C2iExpressionAnalysable
	{
		/// //////////////////////////////////////////
        public C2iExpressionKmToShowToMapZoom()
		{
		}

        public static void Autoexec()
        {
            CAllocateur2iExpression.Register2iExpression(new C2iExpressionKmToShowToMapZoom().IdExpression,
                typeof(C2iExpressionKmToShowToMapZoom));
        }

		/// //////////////////////////////////////////
        protected override CInfo2iExpression GetInfosSansCache()
		{
			CInfo2iExpression info = new CInfo2iExpression( 
				0, 
				"KmToShowToMapZoom", 
				typeof(int),
                I.TT(GetType(), "KmToShowToMapZoom(km)\nReturns the zoom to apply to a map to show the number of kilometers|20260"),
				CInfo2iExpression.c_categorieMathematiques );
            info.AddDefinitionParametres(
                new CInfoUnParametreExpression(I.T("km|20261"), typeof(double)));
			return info;
		}

		/// //////////////////////////////////////////
		public override CTypeResultatExpression TypeDonnee
		{
			get
			{
                return new CTypeResultatExpression(typeof(int), false);
			}
		}

		/// //////////////////////////////////////////
		public override CResultAErreur MyEval ( CContexteEvaluationExpression ctx, object[] valeursParametres )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
                double fScale = Convert.ToDouble(valeursParametres[0]);
                result.Data = Math.Max(Math.Min(20, (int)-(1 + Math.Log(fScale / 591657.55047936) / Math.Log(2))), 1);
			}
			catch
			{
                result.EmpileErreur(I.T("Invalid parameter for KmToShowToMapZoom function|20037"));
			}
			return result;
		}

	}
}
