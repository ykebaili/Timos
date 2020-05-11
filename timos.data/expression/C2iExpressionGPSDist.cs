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
	public class C2iExpressionGPSDist : C2iExpressionAnalysable
	{
		/// //////////////////////////////////////////
		public C2iExpressionGPSDist()
		{
		}

        public static void Autoexec()
        {
            CAllocateur2iExpression.Register2iExpression(new C2iExpressionGPSDist().IdExpression,
                typeof(C2iExpressionGPSDist));
        }

		/// //////////////////////////////////////////
        protected override CInfo2iExpression GetInfosSansCache()
		{
			CInfo2iExpression info = new CInfo2iExpression( 
				0, 
				"GPSDist", 
				typeof(double),
				I.TT(GetType(), "GPSDist(Point1X, Point1Y, Point2X, Point2Y)\nReturns the distance between two GPS coordinates|20036"),
				CInfo2iExpression.c_categorieMathematiques );
            info.AddDefinitionParametres(
                new CInfo2iDefinitionParametres(typeof(double), typeof(double), typeof(double), typeof(double)));
			return info;
		}

		/// //////////////////////////////////////////
		public override CTypeResultatExpression TypeDonnee
		{
			get
			{
                return new CTypeResultatExpression(typeof(double), false);
			}
		}

		/// //////////////////////////////////////////
		public override CResultAErreur MyEval ( CContexteEvaluationExpression ctx, object[] valeursParametres )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
                double fDegre = Math.PI / 180.0;
                double fLat1, fLat2, fLong1, fLong2;
                fLong1 = ((double)valeursParametres[0]) * fDegre;
                fLong2 = ((double)valeursParametres[2]) * fDegre;
                fLat1 = ((double)valeursParametres[1]) * fDegre;
                fLat2 = ((double)valeursParametres[3]) * fDegre;
                result.Data = GetGpsDist(fLong1, fLat1, fLong2, fLat2);
			}
			catch
			{
				result.EmpileErreur(I.T("Invalid parameter for GPSDist function|20037"));
			}
			return result;
		}

        public static double GetGpsDist(double fLong1, double fLat1, double fLong2, double fLat2)
        {
            double t1 = Math.Sin(fLat1) * Math.Sin(fLat2);
            double t2 = Math.Cos(fLat1) * Math.Cos(fLat2);
            double t3 = Math.Cos(fLong1 - fLong2);
            double t4 = t2 * t3;
            double t5 = t1 + t4;
            double fDistRad = Math.Atan(-t5 / Math.Sqrt(-t5 * t5 + 1)) + 2 * Math.Atan(1);
            double fDist = fDistRad * 3437.74677 * 1.1508 * 1.6093470878864446;
            return fDist;
        }

	}
}
