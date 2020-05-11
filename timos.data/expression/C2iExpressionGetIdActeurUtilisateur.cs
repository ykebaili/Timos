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
	public class C2iExpressionGetIdActeurUtilisateur: C2iExpressionAnalysable
	{
		/// //////////////////////////////////////////
		public C2iExpressionGetIdActeurUtilisateur()
		{
		}

		/// //////////////////////////////////////////
		public static void Autoexec()
		{
			CAllocateur2iExpression.Register2iExpression ( new C2iExpressionGetIdActeurUtilisateur().IdExpression,
				typeof(C2iExpressionGetIdActeurUtilisateur) );
		}

	

		/// //////////////////////////////////////////
        protected override CInfo2iExpression GetInfosSansCache()
		{
			CInfo2iExpression info = new CInfo2iExpression( 
				0, 
				"GetUserMember", 
				typeof(CActeur),
				I.TT(GetType(), "GetUserMember() : Returns the member associated with the process|359"),
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
                if ( key != null )
                {
					bool bNewContexte =  false;
					if ( contexte == null )
					{
						if ( ctx.ObjetSource is CObjetDonnee )
							contexte = ((CObjetDonnee)ctx.ObjetSource).ContexteDonnee;
						else
						{
                            contexte = CContexteDonneeSysteme.GetInstance();
							bNewContexte = false;
						}
					}
					CDonneesActeurUtilisateur user = new CDonneesActeurUtilisateur ( contexte );
					if ( user.ReadIfExists ( key ) )
						result.Data = user.Acteur;
					else
						result.Data = null;
					if ( bNewContexte )
						contexte.Dispose();
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
