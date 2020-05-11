using System;
using System.Collections;
using System.Collections.Generic;

using sc2i.common;

namespace sc2i.expression.expressions
{
	/// <summary>
	/// Description résumée de C2iExpressionPlus.
	/// </summary>
	[Serializable]
	[AutoExec("Autoexec")]
	public class C2iExpressionCodesParents : C2iExpressionAnalysable
	{
		/// //////////////////////////////////////////
		public C2iExpressionCodesParents()
		{
		}


		/// //////////////////////////////////////////
		public static void Autoexec()
		{
			CAllocateur2iExpression.Register2iExpression(new C2iExpressionCodesParents().IdExpression,
				typeof(C2iExpressionCodesParents));
		}


		/// //////////////////////////////////////////
		protected override CInfo2iExpression GetInfosSansCache()
		{
			CInfo2iExpression info = new CInfo2iExpression(0, "ParentCode", typeof(string[]), I.TT(GetType(), "ParentCode( text, size) : returns all parental code relative of a hierarchical code by using the specified size for each level|357"), CInfo2iExpression.c_categorieTexte);
			info.AddDefinitionParametres( new CInfo2iDefinitionParametres(typeof(string), typeof(int)));
			return info;
		}

		/// //////////////////////////////////////////
		public override CResultAErreur MyEval ( CContexteEvaluationExpression ctx, object[] valeursParametres )
		{
			CResultAErreur result = CResultAErreur.True;
			//Tente la conversion du second en int
			try
			{
				string str1 = valeursParametres[0].ToString();
				int nSize = Convert.ToInt32(valeursParametres[1]);
				{
					int nPos = str1.Length - nSize;
					List<string> lst = new List<string>();
					while ( nPos > 0 )
					{
						lst.Add ( str1.Substring(0, nPos ));
						nPos -= nSize;
					}
					result.Data = lst.ToArray();
				}
			}
			catch
			{
				result.EmpileErreur(I.T("Error in ParentCode function|358"));
				return result;
			}
			return result;
		}

		
	}
}
