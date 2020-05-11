using System;
using System.Collections;


using sc2i.common;

using sc2i.expression;
using sc2i.multitiers.client;
using sc2i.data;
using timos.acteurs;
using timos.securite;

namespace sc2i.expression
{
	/// <summary>
	/// Description résumée de C2iExpressionPlus.
	/// </summary>
	[Serializable]
	[AutoExec("Autoexec")]
	public class C2iExpressionGetUtilisateur: C2iExpressionAnalysable
	{
		/// //////////////////////////////////////////
		public C2iExpressionGetUtilisateur()
		{
		}

		/// //////////////////////////////////////////
		public static void Autoexec()
		{
			CAllocateur2iExpression.Register2iExpression ( new C2iExpressionGetUtilisateur().IdExpression,
				typeof(C2iExpressionGetUtilisateur) );
		}

	

		/// //////////////////////////////////////////
        protected override CInfo2iExpression GetInfosSansCache()
		{
			CInfo2iExpression info = new CInfo2iExpression( 
				0, 
				"GetUserId", 
				typeof(int),
                I.TT(GetType(), "GetUserId() : Returns the User ID associated with the process|360"),
				CInfo2iExpression.c_categorieDivers);
			info.AddDefinitionParametres( new CInfo2iDefinitionParametres(new Type[]{}));
			return info
				;
		}

		/// //////////////////////////////////////////
		public override CResultAErreur MyEval ( CContexteEvaluationExpression ctx, object[] valeursParametres )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
                //TESTDBKEYOK
				CContexteDonnee contexte = (CContexteDonnee)ctx.GetObjetAttache ( typeof(CContexteDonnee) );
				CDbKey key = null;
				if ( contexte != null )
				{
					key = CSessionClient.GetSessionForIdSession ( contexte.IdSession ).GetInfoUtilisateur().KeyUtilisateur;
				}
				else
					key = CSessionClient.GetSessionUnique().GetInfoUtilisateur().KeyUtilisateur;
                result.Data = null;
                if ( key  != null )
                {
                    CDonneesActeurUtilisateur user = new CDonneesActeurUtilisateur(CContexteDonneeSysteme.GetInstance() );
                    if ( user.ReadIfExists ( key ) )
                        result.Data = user.Id;
                }
			}
			catch
			{
				result.Data = -1;
			}
			return result;
		}

		
	}
}
